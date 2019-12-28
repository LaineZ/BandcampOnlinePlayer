using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlineplayer
{
    public partial class AlbumList : Form
    {
        readonly List<Json.Item> albms = new List<Json.Item>();

        private async void RebuildImages()
        {
            ImageList il = new ImageList();
            il.ImageSize = new Size(256, 256);
            HttpTools httpTools = new HttpTools();
            int count = 0;
            foreach (ListViewItem listItem in itemsList.Items)
            {
                il.ColorDepth = ColorDepth.Depth32Bit;
                itemsList.LargeImageList = il;
                il.Images.Add(await httpTools.DownloadImagesFromWeb("https://f4.bcbits.com/img/a" + albms[count].art_id + "_2.jpg"));
                listItem.ImageIndex = count++;
            }
        }

        public AlbumList(List<Json.Item> album, List<Track> trk, AudioPlayer player)
        {
            InitializeComponent();
            foreach (var alb in album)
            {
                ListViewItem lst = new ListViewItem(new string[] { alb.title, alb.artist });
                itemsList.Items.Add(lst);
                albms.Add(alb);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void AlbumList_FormClosing(object sender, FormClosingEventArgs e)
        {
            itemsList.Dispose();
            GC.Collect();
        }

        private void AlbumList_Shown(object sender, EventArgs e)
        {
            RebuildImages();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            itemsList.Items.Clear();
            albms.Clear();
            foreach (var alb in albms)
            {
                toolStripLabel2.Text = "Looking: " + alb.title;
                if (alb.title.Contains(toolStrip1.Text) || alb.artist.Contains(toolStrip1.Text) || toolStrip1.Text.Length <= 0)
                {
                    ListViewItem lst = new ListViewItem(new string[] { alb.title, alb.artist });
                    itemsList.Items.Add(lst);
                    albms.Add(alb);
                }
            }
            RebuildImages();
        }
    }
}
