using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static onlineplayer.Utils;

namespace onlineplayer
{
    public partial class FormInit : Form
    {
        public FormInit()
        {
            InitializeComponent();
            labelVersion.Text = "BandcampOnlinePlayer \n" + Core.Info.version + "\ndeveloped by 140bpmdubstep";
            commitText.Text = Core.Info.commit;
        }

        private async void FormInit_Load(object sender, EventArgs e)
        {
            label1.Text = "Loading configuration...";
            if (!File.Exists("settings.xml"))
            {
                XmlWriter xmlWriter = XmlWriter.Create("settings.xml");

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("settings");

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("albumViewType", "Tile");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("albumViewSize", "64");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("saveArtworks", "True");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("loadPages", "100");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("midiDevice", "0");
                xmlWriter.WriteEndElement();


                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("useMidi", "False");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("saveQueue", "True");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

            label1.Text = "Loading tags from bandcamp.com...";

            HttpTools httpTools = new HttpTools();
            String response = await httpTools.MakeRequestAsync("https://bandcamp.com/tags");

            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(response);

            List<string> hrefTags = new List<string>();
            List<string> tags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.StartsWith("/tag/"))
                {
                    tags.Add(att.Value.Replace("/tag/", ""));
                }
            }

            List<Track> restoreQueue = new List<Track>();

            if (File.Exists("queueList.xml") && getSettingsAttrBool("settings.xml", "saveQueue"))
            {
                label1.Text = "Restoring play queue...";

                XmlDocument doc = new XmlDocument();

                doc.Load("queueList.xml");
                XmlElement xRoot = doc.DocumentElement;
                XmlNode attr;

                label1.Text = "Restoring play queue...";

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
                        restoreQueue.Add(trk);
                        label1.Text = "Restoring play queue: " + trk.Album.Artist + " - " + trk.Title + " ...";
                    }
                }
            }
            Form mainForm = new Form1(tags, restoreQueue);
            mainForm.Show();
            label1.Text = "";
            mainForm.FormClosed += MainForm_FormClosed;
            timer1.Start();
            restoreQueue.Clear();

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
    }
}
