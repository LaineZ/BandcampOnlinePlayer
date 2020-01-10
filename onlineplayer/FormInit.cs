using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        // Random splashscreen
        List<Image> img = new List<Image>(2);

        public FormInit()
        {
            InitializeComponent();
            labelVersion.Text = "BandcampOnlinePlayer \n" + Core.Info.version + "\ndeveloped by 140bpmdubstep";
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

            label1.Text = "Loading tags from bandcamp.com...";

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
                    tags.Add(att.Value.Replace("/tag/", ""));
                }
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
                Form mainForm = new Form1(tags, restoreQueue);
                mainForm.Show();
                label1.Text = "";
                mainForm.FormClosed += MainForm_FormClosed;
                timer1.Start();
                timer2.Stop();
            }
        }
    }
}
