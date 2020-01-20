using NAudio;
using NAudio.Wave;
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
        Core.WaveProviderToWaveStream waveProcessed;

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
            labelVersion.Text = "Version:" + Core.Info.version + "\n by 140bpmdubstep\nLicensed under MIT License\n2019 - 2020";
            albumView.SelectedItem = Core.Config.viewType;
            albumSize.Text = Core.Config.viewSize.ToString();
            checkArtwork.Checked = Core.Config.saveArtworks;
            pagesLoad.Text = Core.Config.pagesLoad.ToString();
            saveQueue.Checked = Core.Config.saveQueue;
            potReduct.Value = Core.Config.compReduction;
            potThres.Value = Core.Config.compThresh;
            checkComp.Checked = Core.Config.compEnabled;
            if (Core.Config.audioSystem > 0)
            {
                audiosystemBox.SelectedIndex = Core.Config.audioSystem;
            }
            checkReopen.Checked = Core.Config.jackReopen;

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
            albumSize.BackColor = Color.FromArgb(255, 255, 255);
            pagesLoad.BackColor = Color.FromArgb(255, 255, 255);

            Core.Config.viewType = albumView.Text;

            if (int.Parse(albumSize.Text) <= 124)
            {
                Core.Config.viewSize = int.Parse(albumSize.Text);
            }
            else
            {
                Core.Config.viewSize = 124;
                albumSize.BackColor = Color.FromArgb(255, 0, 0);
            }

            Core.Config.saveArtworks = checkArtwork.Checked;
            Core.Config.saveQueue = saveQueue.Checked;

            int pagesSave = 0;

            if (int.TryParse(pagesLoad.Text, out pagesSave))
            {
                Core.Config.pagesLoad = pagesSave;
            }
            else
            {
                Core.Config.pagesLoad = 100;
                pagesLoad.BackColor = Color.FromArgb(255, 0, 0);
            }

            if (audiosystemBox.SelectedIndex == -1)
            {
                Core.Config.audioSystem = 0;
            }
            else
            {
                Core.Config.audioSystem = audiosystemBox.SelectedIndex;
            }
            Core.Config.jackReopen = checkReopen.Checked;
            Core.Config.compEnabled = checkComp.Checked;
            Core.Config.compThresh = (int)potThres.Value;
            Core.Config.compReduction = (int)potReduct.Value;

            Core.Config.SaveConfig();
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Reset all settings?", "NO UNDO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                File.Delete("settings.xml");
                MessageBox.Show("All settings has been reset, restart the program to take effect!", "There is no turning back", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/LaineZ/BandcampOnlinePlayer");
        }

        private void checkComp_CheckedChanged(object sender, EventArgs e)
        {
            potThres.Enabled = checkComp.Checked;
            potReduct.Enabled = checkComp.Checked;
            toolStripButton4.Enabled = checkComp.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkComp.Checked)
            {
                WaveStream example = new WaveFileReader("example.wav");
                labelInfo.Text = "Threshold: " + (int)potThres.Value + " db\nReduction: " + (int)potReduct.Value + " db";
                SimpleCompressorEffect compressorEffect = new SimpleCompressorEffect(example.ToSampleProvider());
                compressorEffect.Threshold = potThres.Value;
                compressorEffect.Ratio = potReduct.Value;
                compressorEffect.Attack = 50;
                compressorEffect.Release = 1000;

                compressorEffect.Enabled = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            WaveOutEvent outputDevice = new WaveOutEvent();
            outputDevice.Init(waveProcessed);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
