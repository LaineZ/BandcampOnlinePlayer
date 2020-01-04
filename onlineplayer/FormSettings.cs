using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static onlineplayer.Utils;

namespace onlineplayer
{
    public partial class FormSettings : Form
    {
        XmlDocument doc = new XmlDocument();
        bool assignMode = false;
        int selectedIndex = 0;
        MidiIn midiIn;
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

            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                comboBoxMidiInDevices.Items.Add(MidiIn.DeviceInfo(device).ProductName);
            }
            if (comboBoxMidiInDevices.Items.Count > 0)
            {
                comboBoxMidiInDevices.SelectedIndex = 0;
            }
            else
            {
                comboBoxMidiInDevices.Enabled = false;
                listView1.Enabled = false;
                midiControl.Enabled = false;
            }

            int count = 0;

            foreach (MidiAction action in MidiActionsBindings.actionsMidi)
            {
                listView1.Items[count].SubItems[1].Text = action.MidiEv.ToString();
                count++;
            }

            if (getSettingsAttrBool("settings.xml", "useMidi"))
            {
                midiIn = new MidiIn(comboBoxMidiInDevices.SelectedIndex);
                midiIn.MessageReceived += midiIn_MessageReceived;
                midiIn.ErrorReceived += midiIn_ErrorReceived;
                midiIn.Start();
            }

            recomputeSize();
        }

        void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            MessageBox.Show("Midi recive error:" + e.RawMessage, e.MidiEvent.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            if (assignMode)
            {
                try
                {
                    MidiActionsBindings.actionsMidi[selectedIndex].MidiEv = e.MidiEvent;
                    assignMode = false;
                }
                catch (ArgumentOutOfRangeException)
                {
                    MidiAction act = new MidiAction();
                    act.MidiEv = e.MidiEvent;
                    act.ControlData = e.MidiEvent as ControlChangeEvent;
                    act.NoteEvent = e.MidiEvent as NoteEvent;
                    MidiActionsBindings.actionsMidi.Add(act);
                    assignMode = false;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            albumSize.BackColor = Color.FromArgb(255, 255, 255);
            pagesLoad.BackColor = Color.FromArgb(255, 255, 255);
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
                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("albumViewSize", "124");
                xmlWriter.WriteEndElement();
                albumSize.BackColor = Color.FromArgb(255, 0, 0);
            }

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("saveArtworks", checkArtwork.Checked.ToString());
            xmlWriter.WriteEndElement();
            int idk = 0;
            if (int.TryParse(pagesLoad.Text, out idk))
            {
                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("loadPages", pagesLoad.Text);
                xmlWriter.WriteEndElement();
            }
            else
            {
                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("loadPages", "100");
                xmlWriter.WriteEndElement();
                pagesLoad.BackColor = Color.FromArgb(255, 0, 0);
            }

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("midiDevice", comboBoxMidiInDevices.SelectedIndex.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("useMidi", midiControl.Checked.ToString());
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

            foreach (MidiAction midiItem in MidiActionsBindings.actionsMidi)
            {
                ListViewItem lst = new ListViewItem(new string[] { midiItem.MidiEv.ToString() });
                listView1.Items.Add(lst);
            }
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

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            assignMode = !assignMode;
            timer1.Enabled = assignMode;
        }

        private void listView1_EnabledChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (assignMode)
            {
                listView1.FocusedItem.SubItems[1].Text = "Move controller TO ASSIGN!";
                listView1.Enabled = !assignMode;
                selectedIndex = listView1.FocusedItem.Index;
            }
            else
            {
                try
                {
                    listView1.FocusedItem.SubItems[1].Text = MidiActionsBindings.actionsMidi[listView1.FocusedItem.Index].MidiEv.ToString();
                    listView1.Enabled = !assignMode;
                }
                catch (ArgumentOutOfRangeException)
                {
                
                }
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (getSettingsAttrBool("settings.xml", "useMidi")) { midiIn.Close(); }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Reset all settings?", "NO UNDO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                File.Delete("settings.xml");
                MessageBox.Show("All settings has been reset, restart the program to take effect!", "There is no turning back", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
