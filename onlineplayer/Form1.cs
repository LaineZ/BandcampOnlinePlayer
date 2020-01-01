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
using System.Windows.Forms.VisualStyles;
using NAudio.Midi;

namespace onlineplayer
{
    public partial class Form1 : Form
    {
        List<Item> itemsList = new List<Item>();
        List<Track> queueTracks = new List<Track>();

        int offset = 0;
        bool streamMode = false;

        MidiIn midiIn = new MidiIn(int.Parse(getSettingsAttr("settings.xml", "midiDevice")));

        int imgSize = int.Parse(getSettingsAttr("settings.xml", "albumViewSize"));
        bool downloadImgs = getSettingsAttrBool("settings.xml", "saveArtworks");
        string viewStyle = getSettingsAttr("settings.xml", "albumViewType");
        HttpTools httpTools = new HttpTools();

        public Form1()
        {
            InitializeComponent();
            if (viewStyle == "Tile")
            {
                listView1.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader(), new ColumnHeader() });
                listView1.TileSize = new Size(256, imgSize);
            }
            else
            {
                listView1.View = View.LargeIcon;
            }

            queueList.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader(), new ColumnHeader() });
            queueList.TileSize = new Size(256, 64);
            Directory.CreateDirectory("artwork_cache");
    
            toolStripButton5.Enabled = false;
            listView1.MouseUp += (s, args) =>
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

            toolStripTextBox1.Enabled = false;
        }

        void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            MessageBox.Show("Midi receive error:" + e.RawMessage, e.MidiEvent.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {

            ControlChangeEvent cce = e.MidiEvent as ControlChangeEvent;
            NoteEvent note = e.MidiEvent as NoteEvent;


            if (MidiActionsBindings.actionsMidi[0].ControlData.Controller == cce.Controller && MidiActionsBindings.actionsMidi[0].ControlData.ControllerValue == cce.ControllerValue)
            {
                player.PlayPause();
                return;       
            }

            if (MidiActionsBindings.actionsMidi[1].ControlData.Controller == cce.Controller && MidiActionsBindings.actionsMidi[1].ControlData.ControllerValue == cce.ControllerValue)
            {
                return;
            }

            if (MidiActionsBindings.actionsMidi[2].ControlData.Controller == cce.Controller && MidiActionsBindings.actionsMidi[2].ControlData.ControllerValue == cce.ControllerValue)
            {
                return;
            }

            if (MidiActionsBindings.actionsMidi[3].ControlData.Controller == cce.Controller && MidiActionsBindings.actionsMidi[3].ControlData.ControllerValue == cce.ControllerValue)
            {
                return;
            }
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            DownloadFromBandcamp();
        }

        private async void listBox1_Click(object sender, EventArgs e)
        {
            UpdateAlbums();
        }

        AudioPlayer player = new AudioPlayer();

        private void AlbumList(object sender, EventArgs e)
        {
            PlayFormList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Value = (int)player.audioFile.CurrentTime.TotalSeconds;
            TimeSpan time = TimeSpan.FromSeconds(player.audioFile.CurrentTime.TotalSeconds);
            label3.Text = time.ToString(@"hh\:mm\:ss");
            label5.Text = player.outputDevice.PlaybackState.ToString();

            if (Math.Abs(player.audioFile.TotalTime.TotalSeconds - player.audioFile.CurrentTime.TotalSeconds) < 0.1)
            {
                if (!toolStripButton8.Checked)
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
            label4.Text = "Volume: " + trackBar2.Value + "%";
            try
            {
                player.outputDevice.Volume = trackBar2.Value / 100f;

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
                System.Diagnostics.Process.Start(itemsList[listView1.FocusedItem.Index].tralbum_url);
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
            Item selectedAlbum = itemsList.Find(item => item.artist.Equals(listView1.FocusedItem.SubItems[1].Text) && item.title.Equals(listView1.FocusedItem.SubItems[0].Text));
            labelStatus.Text = "Loading tracks metadata... " + selectedAlbum.tralbum_url;
            String response = await httpTools.MakeRequestAsync(selectedAlbum.tralbum_url);
            Album album = httpTools.GetAlbum(response);
            List<ListViewItem> listItems = new List<ListViewItem>();
            foreach (Track trk in album.Tracks)
            {
                ListViewItem lst = new ListViewItem(new string[] { trk.Title, trk.Album.Artist, trk.Album.Title });
                queueList.Items.Add(lst);
                queueTracks.Add(trk);
            }

            HttpClient client = new HttpClient();
            ImageList il = new ImageList();
            il.ImageSize = new Size(64, 64);
            int count = 0;

            foreach (ListViewItem listItem in queueList.Items)
            {
                labelStatus.Text = "Loading ablum tracks images...";
                il.ColorDepth = ColorDepth.Depth32Bit;
                queueList.LargeImageList = il;
                il.Images.Add(await httpTools.DownloadImagesFromWeb("https://f4.bcbits.com/img/a" + queueTracks[count].Album.ArtworkId + "_8.jpg"));
                listItem.ImageIndex = count++;
            }
            labelStatus.Text = "Done!";
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
                Form artForm = new ViewArtwork(itemsList[listView1.FocusedItem.Index].art_id.ToString());
                artForm.Show();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                WaveStreamExtensions.SetPosition(player.audioFile, (double)trackBar1.Value);

            }
            catch (NullReferenceException)
            {
                trackBar1.Value = 0;
                labelStatus.Text = "Cannot seek: Audio file not loaded!";
            }
        }

        private async void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            if (!streamMode)
            {
                toolStripButton5.Enabled = false;
                streamMode = true;
                bool firstSong = false;
                CleanUp();
                toolStripButton5.Text = "Stop stream mode";
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
                                toolStripButton5.Enabled = true;
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
                toolStripButton5.Text = "Play as stream mode";
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            midiIn.Close();
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
            var res = MessageBox.Show("Clear queue items completely?", "Queue manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                queueTracks.Clear();
                queueList.LargeImageList.Images.Clear();
                queueList.Clear();
            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            DownloadFromBandcamp();
        }

        private async void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var alb in itemsList)
            {
                if (alb.title.ToLower().Contains(toolStripTextBox1.Text.ToLower()) || alb.artist.ToLower().Contains(toolStripTextBox1.Text.ToLower()))
                {
                    ListViewItem lst = new ListViewItem(new string[] { alb.title, alb.artist });
                    listView1.Items.Add(lst);
                }
            }
            if (toolStripTextBox1.Text.Length == 0)
            {
                listView1.Items.Clear();
                foreach (var item in itemsList)
                {
                    // title, artist, mp3_url, url, artworkid
                    ListViewItem lst = new ListViewItem(new string[] { item.title, item.artist });
                    listView1.Items.Add(lst);
                }

                int count = 0;
                labelStatus.Text = "Loading ablum images...";
                foreach (ListViewItem listItem in listView1.Items)
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
    }
}
