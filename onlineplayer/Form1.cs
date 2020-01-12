using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using static onlineplayer.Utils;
using static onlineplayer.Json;
using NAudio.Midi;
using System.Xml;

namespace onlineplayer
{

    public partial class Form1 : Form
    {
        MidiIn midiIn;

        List<Item> itemsList = new List<Item>();
        List<Track> queueTracks = new List<Track>();
        List<Models.JSON.JsonSearch.Result> searchResults = new List<Models.JSON.JsonSearch.Result>();

        int offset = 0;
        bool streamMode = false;

        int imgSize = int.Parse(getSettingsAttr("settings.xml", "albumViewSize"));
        bool downloadImgs = getSettingsAttrBool("settings.xml", "saveArtworks");
        string viewStyle = getSettingsAttr("settings.xml", "albumViewType");
        HttpTools httpTools = new HttpTools();


        Core.IAudioPlayer player;

        public Form1(List<string> tags, List<Track> restoreQueue)
        {
            InitializeComponent();

            if (Core.Config.audioSystem == 0)
            {
                Console.WriteLine("using wavout");
                player = new AudioPlayerMF();
            }
            if (Core.Config.audioSystem == 1)
            {
                Console.WriteLine("using jack");
                player = new AudioPlayerJack();
            }

            //player.Init();

            if (viewStyle == "Tile")
            {
                listAlbums.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader(), new ColumnHeader() });
                listAlbums.TileSize = new Size(256, imgSize);
            }
            else
            {
                listAlbums.View = View.LargeIcon;
            }

            queueList.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader(), new ColumnHeader() });
            listGlobalSearch.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader(), new ColumnHeader() });
            queueList.TileSize = new Size(256, 64);
            Directory.CreateDirectory("artwork_cache");

            toolStream.Enabled = false;
            listAlbums.MouseUp += (s, args) =>
            {
                if (args.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            };

            queueList.MouseUp += (s, args) =>
            {
                if (args.Button == MouseButtons.Right)
                {
                    contextMenuStrip2.Show(Cursor.Position);
                }
            };

            toolSearch.Enabled = false;

            if (getSettingsAttrBool("settings.xml", "useMidi"))
            {
                midiIn = new MidiIn(int.Parse(getSettingsAttr("settings.xml", "midiDevice")));
            }
            else
            {
                toolMidiClose.Enabled = false;
                toolMidiOpen.Enabled = false;
            }

            // adding tags
            listTags.Items.AddRange(tags.ToArray());
            // adding queue tracks

            foreach (Track trk in restoreQueue)
            {
                ListViewItem lst = new ListViewItem(new string[] { trk.Title, trk.Album.Artist, trk.Album.Title });
                queueList.Items.Add(lst);
                queueTracks.Add(trk);
            }

            if (restoreQueue.Count > 1) { UpdateQueueImages(); }
            labelStatus.Text = "Done!";
        }

        void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            MessageBox.Show("Midi receive error:" + e.RawMessage, e.MidiEvent.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {

            ControlChangeEvent cce = e.MidiEvent as ControlChangeEvent;
            NoteEvent note = e.MidiEvent as NoteEvent;
            try
            {
                // playpause
                if (MidiActionsBindings.actionsMidi[0].ControlData.Controller == cce.Controller && MidiActionsBindings.actionsMidi[0].ControlData.ControllerValue == cce.ControllerValue)
                {
                    player.PlayPause();
                    return;
                }

                if (MidiActionsBindings.actionsMidi[2].ControlData.Controller == cce.Controller && MidiActionsBindings.actionsMidi[1].ControlData.ControllerValue == cce.ControllerValue)
                {
                    if (player.GetVolume() <= 1.0)
                    {
                        player.SetVolume(player.GetVolume() + 0.1F);
                    }
                    return;
                }

                if (MidiActionsBindings.actionsMidi[3].ControlData.Controller == cce.Controller && MidiActionsBindings.actionsMidi[1].ControlData.ControllerValue == cce.ControllerValue)
                {
                    if (player.GetVolume() >= 0)
                    {
                        player.SetVolume(player.GetVolume() - 0.1F);
                    }
                    return;
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            itemsList.Clear();
            listAlbums.Items.Clear();
            listAlbums.LargeImageList.Images.Clear();
            listAlbums.LargeImageList = null;
            toolRefresh.Enabled = false;
            listTags.Enabled = true;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textTags.Text += listTags.SelectedItem + " ";
        }

        private void AlbumList(object sender, EventArgs e)
        {
            PlayFormList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                trackSeek.Enabled = true;
                trackSeek.Value = (int)player.GetCurrentTimeTotalSeconds();
                TimeSpan time = TimeSpan.FromSeconds(player.GetCurrentTimeTotalSeconds());
                label3.Text = time.ToString(@"hh\:mm\:ss");
                label5.Text = player.GetPlaybackState();
            }
            catch (NullReferenceException)
            {
                trackSeek.Enabled = false;
                label3.Text = "00:00:00";
                label5.Text = "Stopped";
            }

            if (Math.Abs(player.GetTotalTimeSeconds() - player.GetCurrentTimeTotalSeconds()) < 0.1)
            {
                if (!toolShuffle.Checked)
                {
                    offset++;
                }
                else
                {
                    Random rand = new Random();
                    offset = rand.Next(0, queueTracks.Count - 1);
                }
                PlayOffset();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Volume: " + trackVolume.Value + "%";
            try
            {
                player.SetVolume(trackVolume.Value / 100f);

            }
            catch (Exception)
            {
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayFormList();
        }

        private void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(itemsList[listAlbums.FocusedItem.Index].tralbum_url);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot open in browser!", "Opening failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void addAlbumTracksInQueueifAvailbleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item selectedAlbum = itemsList.Find(item => item.artist.Equals(listAlbums.FocusedItem.SubItems[1].Text) && item.title.Equals(listAlbums.FocusedItem.SubItems[0].Text));
            labelStatus.Text = "Loading tracks metadata... " + selectedAlbum.tralbum_url;
            String response = await httpTools.MakeRequestAsync(selectedAlbum.tralbum_url);
            Album album = httpTools.GetAlbum(response);

            foreach (Track trk in album.Tracks)
            {
                ListViewItem lst = new ListViewItem(new string[] { trk.Title, trk.Album.Artist, trk.Album.Title });
                queueList.Items.Add(lst);
                trk.ArtistUrl = selectedAlbum.band_url;
                queueTracks.Add(trk);
            }

            UpdateQueueImages();
        }

        private void queueList_DoubleClick(object sender, EventArgs e)
        {
            offset = queueList.FocusedItem.Index;
            PlayOffset();
            labelStatus.Text = "Done!";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PlayNext();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PlayPrev();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            player.PlayPause();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void removeFromQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                queueList.Items.Remove(queueList.FocusedItem);
                queueTracks.RemoveAt(queueList.FocusedItem.Index);
                queueList.LargeImageList.Images.RemoveAt(queueList.FocusedItem.Index);
            }
            catch (NullReferenceException)
            {
                labelStatus.Text = "All items has been removed!";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Form artForm = new ViewArtwork(queueTracks[offset].Album.ArtworkId);
                artForm.Show();
            }
            catch (Exception)
            {
                Form artForm = new ViewArtwork(itemsList[listAlbums.FocusedItem.Index].art_id.ToString());
                artForm.Show();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                player.SetPos((int)trackSeek.Value);
            }
            catch (NullReferenceException)
            {
                trackSeek.Value = 0;
                labelStatus.Text = "Cannot seek: Audio file not loaded!";
            }
        }

        private async void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            if (!streamMode)
            {
                toolStream.Enabled = false;
                streamMode = true;
                bool firstSong = false;
                CleanUp();
                toolStream.Text = "Stop stream mode";
                labelStatus.Text = "Loading tracks metadata...";
                List<string> blocked = viewBlocked();
                foreach (Item item in itemsList)
                {
                    if (!streamMode) { break; }
                    String response = await httpTools.MakeRequestAsync(item.tralbum_url);
                    Album album = httpTools.GetAlbum(response);
                    if (!blocked.Contains(album.Artist))
                    {
                        foreach (Track trk in album.Tracks)
                        {
                            if (!streamMode) { break; }
                            ListViewItem lst = new ListViewItem(new string[] { trk.Title, trk.Album.Artist, trk.Album.Title });
                            queueList.Items.Add(lst);
                            queueTracks.Add(trk);
                        }
                        if (queueList.Items.Count > 0 && !firstSong)
                        {
                            firstSong = true;
                            PlayOffset();
                            toolStream.Enabled = true;
                        }
                    }
                }
                labelStatus.Text = "Done!";
            }
            else
            {
                streamMode = false;
                CleanUp();
                timer1.Stop();
                player.Close();
                toolStream.Text = "Play as stream mode";
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (getSettingsAttrBool("settings.xml", "useMidi")) { midiIn.Close(); }
            Form settings = new FormSettings();
            settings.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            BlockArtist();
        }

        private void blockSelectedArtiststreamingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlockArtist();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Clear queue items completely?", "Queue manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                queueTracks.Clear();
                queueList.LargeImageList.Images.Clear();
                queueList.Clear();
            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            listAlbums.Items.Clear();
            foreach (var alb in itemsList)
            {
                if (alb.title.ToLower().Contains(toolSearch.Text.ToLower()) || alb.artist.ToLower().Contains(toolSearch.Text.ToLower()))
                {
                    ListViewItem lst = new ListViewItem(new string[] { alb.title, alb.artist });
                    listAlbums.Items.Add(lst);
                }
            }
            if (toolSearch.Text.Length == 0)
            {
                listAlbums.Items.Clear();
                foreach (var item in itemsList)
                {
                    // title, artist, mp3_url, url, artworkid
                    ListViewItem lst = new ListViewItem(new string[] { item.title, item.artist });
                    listAlbums.Items.Add(lst);
                }

                int count = 0;
                labelStatus.Text = "Loading ablum images...";
                foreach (ListViewItem listItem in listAlbums.Items)
                {
                    listItem.ImageIndex = count++;
                }
                labelStatus.Text = "Done...";
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            midiIn.Close();
            labelStatus.Text = "MIDI Device closed:" + MidiIn.DeviceInfo(int.Parse(getSettingsAttr("settings.xml", "midiDevice"))).ProductName;

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            try
            {
                midiIn = new MidiIn(int.Parse(getSettingsAttr("settings.xml", "midiDevice")));
                midiIn.Start();
                midiIn.MessageReceived += midiIn_MessageReceived;
                midiIn.ErrorReceived += midiIn_ErrorReceived;
                labelStatus.Text = "MIDI Device opened:" + MidiIn.DeviceInfo(int.Parse(getSettingsAttr("settings.xml", "midiDevice"))).ProductName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "There error starting MIDI-Devices", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolSort_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete("queueList.xml");
            if (getSettingsAttrBool("settings.xml", "saveQueue") && !streamMode && queueTracks.Count > 0)
            {
                Playlist.SavePlaylist("queueList.xml", queueTracks);
            }
            player.Close();
            File.Delete("tempfile.wav");
        }

        private void toolSavePlaylist_Click(object sender, EventArgs e)
        {
            if (queueTracks.Count > 0)
            {
                saveFileDialog1.Filter = "BandcampOnlinePlayer Playlists (*.bpl)|*.bpl";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Playlist.SavePlaylist(saveFileDialog1.FileName, queueTracks);
                    MessageBox.Show("Playlist saved!", "Saved!");
                }
            }
        }

        private async void openPlaylist_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "BandcampOnlinePlayer Playlists (*.bpl)|*.bpl";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog1.FileName;

                XmlDocument doc = new XmlDocument();

                doc.Load(filePath);
                XmlElement xRoot = doc.DocumentElement;
                XmlNode attr;

                labelStatus.Text = "Restoring play queue...";

                List<Models.QueueRestoreData> resetoreData = new List<Models.QueueRestoreData>();

                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        Models.QueueRestoreData restoreTrack = new Models.QueueRestoreData();
                        attr = xnode.Attributes.GetNamedItem("artistUrl");
                        if (attr != null)
                        {
                            restoreTrack.ArtistUrl = attr.Value;
                        }

                        attr = xnode.Attributes.GetNamedItem("trackUrl");
                        if (attr != null)
                        {
                            restoreTrack.TrackUrl = attr.Value;
                        }

                        resetoreData.Add(restoreTrack);
                    }
                }

                foreach (Models.QueueRestoreData restore in resetoreData)
                {
                    string responseAlbum = await httpTools.MakeRequestAsync(restore.ArtistUrl + restore.TrackUrl);
                    Album album = httpTools.GetAlbum(responseAlbum);

                    foreach (Track trk in album.Tracks)
                    {
                        trk.ArtistUrl = restore.ArtistUrl;
                        queueTracks.Add(trk);
                        ListViewItem lst = new ListViewItem(new string[] { trk.Title, trk.Album.Artist, trk.Album.Title });
                        queueList.Items.Add(lst);
                        labelStatus.Text = "Restoring play queue: " + trk.Album.Artist + " - " + trk.Title + " ...";
                    }
                }
            }
            labelStatus.Text = "Done...";
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            listGlobalSearch.Items.Clear();
            searchResults.Clear();
            string response = await httpTools.MakeRequestAsync("https://bandcamp.com/api/fuzzysearch/1/autocomplete?q=" + textBox1.Text);

            if (textBox1.Text.Length > 0)
            {
                try
                {
                    Models.JSON.JsonSearch.RootObject items = JsonConvert.DeserializeObject<Models.JSON.JsonSearch.RootObject>(response);
                    foreach (Models.JSON.JsonSearch.Result searchItem in items.auto.results)
                    {
                        ListViewItem lst;
                        switch (searchItem.type)
                        {
                            case "a":
                                lst = new ListViewItem(new string[] { searchItem.name, searchItem.band_name, "Album" });
                                break;
                            case "f":
                                lst = new ListViewItem(new string[] { searchItem.name, searchItem.band_name, "Fan" });
                                break;
                            case "b":
                                lst = new ListViewItem(new string[] { searchItem.name, searchItem.band_name, "Artist/Band" });
                                break;
                            case "t":
                                lst = new ListViewItem(new string[] { searchItem.name, searchItem.band_name, "Track" });
                                break;
                            default:
                                lst = new ListViewItem(new string[] { searchItem.name, searchItem.band_name, "Unknown: " + searchItem.type });
                                break;
                        }
                        listGlobalSearch.Items.Add(lst);
                        searchResults.Add(searchItem);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private async void listGlobalSearch_DoubleClick(object sender, EventArgs e)
        {
            if (listGlobalSearch.FocusedItem.SubItems[2].Text == "Album" || listGlobalSearch.FocusedItem.SubItems[2].Text == "Track")
            {
                String response = await httpTools.MakeRequestAsync(searchResults[listGlobalSearch.FocusedItem.Index].url);
                Album album = httpTools.GetAlbum(response);

                foreach (Track trk in album.Tracks)
                {
                    ListViewItem lst = new ListViewItem(new string[] { trk.Title, trk.Album.Artist, trk.Album.Title });
                    queueList.Items.Add(lst);
                    trk.ArtistUrl = "https://" + searchResults[listGlobalSearch.FocusedItem.Index].url.Split('/')[2];
                    queueTracks.Add(trk);
                }

                UpdateQueueImages();
            }
            else
            {
                DialogResult res = MessageBox.Show("Open webpage page in external browser?", searchResults[listGlobalSearch.FocusedItem.Index].url, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(searchResults[listGlobalSearch.FocusedItem.Index].url);
                }
            }
        }

        private void playToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PlayOffset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            UpdateAlbums();
            button1.Enabled = false;
        }

        private void textTags_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textTags.Text.Length > 0;
        }
    }
}
