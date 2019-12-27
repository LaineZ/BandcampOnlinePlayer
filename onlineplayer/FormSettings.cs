using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static onlineplayer.Utils;

namespace onlineplayer
{
    public partial class FormSettings : Form
    {
        XmlDocument doc = new XmlDocument();

        public void recomputeSize()
        {
            int jsonSize = (int)GetDirectorySize("artwork_cache", "json") / 1024 / 1024;
            int artSize = (int)GetDirectorySize("artwork_cache", "jpg") / 1024 / 1024;
            labelArt.Text = artSize.ToString() + " MB";
            labelMeta.Text = jsonSize.ToString() + " MB";
        }

        public FormSettings()
        {
            InitializeComponent();

            if (File.Exists("settings.xml"))
            {
                doc.Load("settings.xml");
                XmlElement xRoot = doc.DocumentElement;

                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr;

                        attr = xnode.Attributes.GetNamedItem("albumViewType");
                        if (attr != null) { albumView.Text = attr.Value; }

                        attr = xnode.Attributes.GetNamedItem("albumViewSize");
                        if (attr != null) { albumSize.Text = attr.Value; }

                        attr = xnode.Attributes.GetNamedItem("saveArtworks");
                        if (attr != null)
                        {
                            if (attr.Value == "True")
                            {
                                checkArtwork.Checked = true;
                            }
                            else
                            {
                                checkArtwork.Checked = false;
                            }
                        }

                        attr = xnode.Attributes.GetNamedItem("loadPages");
                        if (attr != null) { pagesLoad.Text = attr.Value; }
                    }
                }
            }
            if (File.Exists("blocked.txt"))
            {
                List<string> blockers = viewBlocked();
                foreach (string block in blockers)
                {
                    listBox1.Items.Add(block);
                }
            }
            recomputeSize();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            XmlWriter xmlWriter = XmlWriter.Create("settings.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("settings");

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("albumViewType", albumView.Text);
            xmlWriter.WriteEndElement();

            if (int.Parse(albumSize.Text) <= 124)
            {
                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("albumViewSize", albumSize.Text);
                xmlWriter.WriteEndElement();
            }
            else
            {
                albumSize.BackColor = Color.FromArgb(255, 0, 0);
            }

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("saveArtworks", checkArtwork.Checked.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("loadPages", pagesLoad.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                string[] files = Directory.GetFiles(@"artwork_cache\", "*.jpg");

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            });
            recomputeSize();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                string[] files = Directory.GetFiles(@"artwork_cache\", "*.json");

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            });
            recomputeSize();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Blocked artists")
            {
                toolStripButton2.Enabled = true;
            }
            else
            {
                toolStripButton2.Enabled = false;
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                deleteBlocked(listBox1.GetItemText(listBox1.SelectedItem));
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("you haven’t blocked anyone yet", "you are not misha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
