using HtmlAgilityPack;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static onlineplayer.Utils;

namespace onlineplayer
{
    public partial class FormInit : Form
    {
        bool processedData = false;
        List<Track> restoreQueue = new List<Track>();
        List<string> tags = new List<string>();
        Core.IAudioPlayer player;

        // Random splashscreen
        List<Image> img = new List<Image>(2);

        public FormInit()
        {
            InitializeComponent();
            if (OSUtils.GetOperatingSystem() == OSPlatform.Linux)
            {
                label1.Hide();
                labelVersion.Hide();
                commitText.Hide();
                this.Size = new Size(640, 360); // Fix that weird bug on linux: https://i.imgur.com/3wdlV3W.png
            }
            labelVersion.Text = "BandcampOnlinePlayer \n" + Core.Info.version + " " +  Core.Info.prefix +"\ndeveloped by 140bpmdubstep";
            commitText.Text = Core.Info.commit;
            // add splashscreeens
            img.Add(Properties.Resources.splash_screen);
            img.Add(Properties.Resources.splashscreen2);

            Random rnd = new Random();
            pictureBox1.Image = img[rnd.Next(0, 2)];
        }

        private async void FormInit_Load(object sender, EventArgs e)
        {
            label1.Text = "Loading configuration...";
            if (!File.Exists("settings.xml"))
            {
                Core.Config.LoadConfig();
                Core.Config.SaveConfig();
            }
            else
            {
                Core.Config.LoadConfig();
            }

            if (!File.Exists("blocked.txt"))
            {
                File.Create("blocked.txt");
            }

            HttpTools httpTools = new HttpTools();


            label1.Text = "Checking for updates...";
            string versionResponse = await httpTools.MakeRequestAsync("https://raw.githubusercontent.com/LaineZ/BandcampOnlinePlayer/master/latestversion.txt");
            if (versionResponse != null && Core.Info.prefix != "(developer edition)")
            {
                if (versionResponse.TrimEnd() != Core.Info.version)
                {
                    DialogResult res = MessageBox.Show("New version is released: " + versionResponse + "\nYour version: " + Core.Info.version + "\nInstall new version?", versionResponse, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("updater.exe");
                        Application.Exit();
                    }
                }
            }
            else
            {
                if (Core.Info.prefix != "(developer edition)")
                {
                    MessageBox.Show("Cannot determine version", "Update checking failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            label1.Text = "Loading tags from bandcamp.com...";

            String response = await httpTools.MakeRequestAsync("https://bandcamp.com/tags");

            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(response);

            List<string> hrefTags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.StartsWith("/tag/"))
                {
                    tags.Add(att.Value.Replace("/tag/", ""));
                }
            }

            label1.Text = "Opening audio devices...";
            try
            {
                player = Core.AudioSystem.CreateAudioDevice();
            }
            catch (NullReferenceException)
            {
                DialogResult res = MessageBox.Show("Unalbe to initialize audio system!\nPressing 'Retry' will be set audiosystem to 'WaveOut'", "Error opening audio device" + Core.Config.audioSystem, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                if (res == DialogResult.Retry)
                {
                    Console.WriteLine("using wavout");
                    Core.Config.audioSystem = 0;
                    player = new AudioPlayerMF();
                }
                if (res == DialogResult.Abort)
                {
                    Application.Exit();
                }
            }

            if (File.Exists("queueList.xml") && getSettingsAttrBool("settings.xml", "saveQueue"))
            {
                label1.Text = "Loading queue list...";

                XmlDocument doc = new XmlDocument();

                doc.Load("queueList.xml");
                XmlElement xRoot = doc.DocumentElement;
                XmlNode attr;

                label1.Text = "Restoring play queue... (this may take a while, click here if you don't want wait)";

                List<Models.QueueRestoreData> resetoreData = new List<Models.QueueRestoreData>();

                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        Models.QueueRestoreData restoreTrack = new Models.QueueRestoreData();
                        try
                        {
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

                            attr = xnode.Attributes.GetNamedItem("position");
                            if (attr != null)
                            {
                                restoreTrack.Number = int.Parse(attr.Value);
                            }

                            resetoreData.Add(restoreTrack);
                            restoreQueue.Add(null);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Queue file is corrupted or have incorrect format\nIt's may a format upgrade and just ignore this error", "Queue list cannot restore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            File.Delete("queueList.xml");
                            processedData = true;
                        }
                    }
                }

                /*
                foreach (Models.QueueRestoreData restore in resetoreData)
                {
                    string responseAlbum = await httpTools.MakeRequestAsync(restore.ArtistUrl + restore.TrackUrl);
                    Album album = httpTools.GetAlbum(responseAlbum);

                    foreach (Track trk in album.Tracks)
                    {
                        trk.ArtistUrl = restore.ArtistUrl;
                        restoreQueue.Add(trk);
                        label1.Text = "Restoring play queue: " + trk.Album.Artist + " - " + trk.Title + " ...";
                    }
                }
                */


                // Extreme Multithreading...

                Parallel.ForEach(resetoreData, async (Models.QueueRestoreData restore, ParallelLoopState state) =>
                {
                    string responseAlbum = await httpTools.MakeRequestAsync(restore.ArtistUrl + restore.TrackUrl);

                    Album album = httpTools.GetAlbum(responseAlbum);

                    foreach (Track trk in album.Tracks)
                    {
                        trk.ArtistUrl = restore.ArtistUrl;
                        restoreQueue[restore.Number] = trk;
                    }

                    // sorry that not a Rust
                    if (restoreQueue.Count(s => s != null) == resetoreData.Count)
                    {
                        processedData = true;
                    }
                });
            }
            else
            {
                processedData = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity-= .01;
            if (this.Opacity <= 0)
            {
                this.Hide();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (processedData)
            {
                Form mainForm = new Form1(tags, restoreQueue, player);
                mainForm.Show();
                label1.Text = "";
                mainForm.FormClosed += MainForm_FormClosed;
                timer1.Start();
                timer2.Stop();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // yes i know this is not cool way
            if (label1.Text == "Restoring play queue... (this may take a while, click here if you don't want wait)")
            {
                processedData = true;
            }
        }
    }
}
