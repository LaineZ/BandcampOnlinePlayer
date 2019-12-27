using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using static onlineplayer.Models.Json;
using static onlineplayer.Utils;

namespace onlineplayer
{
    public partial class Form1 : Form
    {

        List<Item> itemsList = new List<Item>();
        List<Track> queueTracks = new List<Track>();

        int offset = 0;
        bool streamMode = false;

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
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            ToogleAllContorls();
            Form loader = new FormProgress("Fetching tags from bandcamp.com", "Retriving data from bandcamp.com please wait...");
            loader.Show();
            listBox1.Items.Clear();
            listView1.Items.Clear();
            HttpTools httpTools = new HttpTools();
            String response = await httpTools.MakeRequestAsync("https://bandcamp.com/tags");
            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(response);

            List<string> hrefTags = new List<string>();
            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.StartsWith("/tag/"))
                {
                    listBox1.Items.Add(att.Value.Replace("/tag/", ""));
                }
            }

            loader.Close();
            ToogleAllContorls();
        }

        private async void listBox1_Click(object sender, EventArgs e)
        {
            // {"filters":{ "format":"all","location":0,"sort":"pop","tags":["experimental"] },"page":2}
            HttpClient client = new HttpClient();
            ImageList il = new ImageList();
            il.ImageSize = new Size(imgSize, imgSize);
            int count = 0;
            toolStripButton5.Enabled = true;
            for (int i = 1; i < 100; i++)
            {
                toolStripLabel1.Text = "Loading ablums tag data: " + i + "/" + "100";
                string responseString = "none";
                if (!File.Exists("artwork_cache/" + i + "_" + listBox1.SelectedItem + ".json"))
                {
                    string content = "{\"filters\":{ \"format\":\"all\",\"location\":0,\"sort\":\"pop\",\"tags\":[\"" + listBox1.SelectedItem + "\"] },\"page\":" + i + "}";
                    HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://bandcamp.com/api/hub/2/dig_deeper", c);
                    responseString = await response.Content.ReadAsStringAsync();
                    File.WriteAllText("artwork_cache/" + i + "_" + listBox1.SelectedItem + ".json", responseString);
                }
                else
                {
                    responseString = File.ReadAllText("artwork_cache/" + i + "_" + listBox1.SelectedItem + ".json");
                }
                //Console.WriteLine(responseString);
                try
                {
                    RootObject items = JsonConvert.DeserializeObject<RootObject>(responseString);
                    foreach (var item in items.items)
                    {
                        // title, artist, mp3_url, url, artworkid
                        ListViewItem lst = new ListViewItem(new string[] { item.title, item.artist });
                        listView1.Items.Add(lst);
                        itemsList.Add(item);
                    }
                }
                catch (Exception ekj)
                {
                    //MessageBox.Show("Error occured:" + ekj.Message, "пиздец", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                toolStripLabel1.Text = "Done!";
            }
            if (downloadImgs)
            {
                foreach (ListViewItem listItem in listView1.Items)
                {
                    toolStripLabel1.Text = "Loading ablum images...";
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    listView1.LargeImageList = il;
                    il.Images.Add(await httpTools.DownloadImagesFromWeb("https://f4.bcbits.com/img/a" + itemsList[count].art_id + "_8.jpg"));
                    listItem.ImageIndex = count++;
                }
            }
            toolStripLabel1.Text = "Done!";
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
            toolStripLabel1.Text = "Loading tracks metadata... " + itemsList[listView1.FocusedItem.Index].tralbum_url;
            String response = await httpTools.MakeRequestAsync(itemsList[listView1.FocusedItem.Index].tralbum_url);
            Album album = httpTools.GetAlbum(response);
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
                toolStripLabel1.Text = "Loading ablum tracks images...";
                il.ColorDepth = ColorDepth.Depth32Bit;
                queueList.LargeImageList = il;
                il.Images.Add(await httpTools.DownloadImagesFromWeb("https://f4.bcbits.com/img/a" + queueTracks[count].Album.ArtworkId + "_8.jpg"));
                listItem.ImageIndex = count++;
            }
            toolStripLabel1.Text = "Done!";
        }

        private void queueList_DoubleClick(object sender, EventArgs e)
        {
            offset = queueList.FocusedItem.Index;
            PlayOffset();
            toolStripLabel1.Text = "Done!";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                if (queueList.Items.Count > 0)
                {
                    offset = queueList.FocusedItem.Index;
                    toolStripLabel1.Text = "End of queue list!";
                }
                else
                {
                    toolStripLabel1.Text = "Queue is empty!";
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (queueList.Items.Count > 0)
                {
                    offset--;
                    PlayOffset();
                }
                else
                {
                    toolStripLabel1.Text = "Queue is empty!";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                offset = 0;
                PlayOffset();
                toolStripLabel1.Text = "This a first track in queue list!";
            }
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
                toolStripLabel1.Text = "All items has been removed!";
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
                toolStripLabel1.Text = "Cannot seek: Audio file not loaded!";
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
                toolStripLabel1.Text = "Loading tracks metadata...";
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
                toolStripLabel1.Text = "Done!";
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
                queueList.Clear();
            }

        }
    }
}
