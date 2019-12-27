using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace onlineplayer
{
    public partial class ViewArtwork : Form
    {
        string artidForUrl;

        public ViewArtwork(string artid)
        {
            InitializeComponent();
            artidForUrl = artid;
            pictureBox1.LoadAsync("https://f4.bcbits.com/img/a" + artid + "_0.jpg");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Stream pictureStream;
            saveFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save album artwork image";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((pictureStream = saveFileDialog1.OpenFile()) != null)
                {
                    pictureBox1.Image.Save(pictureStream, ImageFormat.Jpeg);
                    pictureStream.Close();
                }
            }
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void stretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void ViewArtwork_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Dispose();
            GC.Collect();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://f4.bcbits.com/img/a" + artidForUrl + "_0.jpg");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot open in browser!", "Opening failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
