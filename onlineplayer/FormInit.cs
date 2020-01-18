using HtmlAgilityPack;
using Newtonsoft.Json;
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
            if (versionResponse != null)
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
                MessageBox.Show("Cannot determine version", "Update checking failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            switch (Core.Config.audioSystem)
            {
                case 0:
                    Console.WriteLine("using wavout");
                    player = new AudioPlayerMF();
                    break;
                case 1:
                    Console.WriteLine("using jack");
                    player = new AudioPlayerJack();
                    break;
                default:
                    DialogResult res = MessageBox.Show("Unalbe to initialize audio system!\nPressing 'Retry' will be set audiosystem to 'WaveOut'", "Error opening audio device" + Core.Config.audioSystem, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    if (res == DialogResult.Retry)
                    {
                        Console.WriteLine("using wavout");
                        player = new AudioPlayerMF();
                        Core.Config.audioSystem = 0;
                    }
                    if (res == DialogResult.Abort)
                    {
                        Application.Exit();
                    }
                    break;
            }

            if (File.Exists("queueList.xml") && getSettingsAttrBool("settings.xml", "saveQueue"))
            {
                label1.Text = "Loading queue list...";

                XmlDocument doc = new XmlDocument();

                doc.Load("queueList.xml");
                XmlElement xRoot = doc.DocumentElement;
                XmlNode attr;

                label1.Text = "Restoring play queue... (may take by while)";

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

                Parallel.ForEach(resetoreData, async (Models.QueueRestoreData restore) =>
                {
                    string responseAlbum = await httpTools.MakeRequestAsync(restore.ArtistUrl + restore.TrackUrl);

                    Album album = httpTools.GetAlbum(responseAlbum);

                    foreach (Track trk in album.Tracks)
                    {
                        trk.ArtistUrl = restore.ArtistUrl;
                        restoreQueue.Add(trk);
                    }

                    // sorry that not a Rust
                    if (restoreQueue.Count == resetoreData.Count)
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
    }
}
