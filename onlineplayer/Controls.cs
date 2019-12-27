using System;
using System.Windows.Forms;
using static onlineplayer.Utils;
namespace onlineplayer
{
    public partial class Form1
    {
        private void PlayFormList()
        {
            try
            {
                string url = itemsList[listView1.FocusedItem.Index].audio_url.mp3;
                toolStripLabel1.Text = "Loading file...";
                player.Play(url);
                toolStripLabel1.Text = "Loading artwork...";
                pictureBox1.LoadAsync("https://f4.bcbits.com/img/a" + itemsList[listView1.FocusedItem.Index].art_id + "_2.jpg");
                toolStripLabel1.Text = "Done!";
                UpdateInfo();
            }
            catch (NullReferenceException)
            {
                timer1.Stop();
                MessageBox.Show("Cannot start playing due to unknown reasons...", "Opening failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateInfo()
        {
            try
            {
                label1.Text = queueTracks[offset].Title;
                label2.Text = queueTracks[offset].Album.Artist + "\n" + queueTracks[offset].Album + "\n" + queueTracks[offset].Album.ReleaseDate + "\nTrack number " + offset;
            }
            catch (ArgumentOutOfRangeException)
            {
                label1.Text = itemsList[listView1.FocusedItem.Index].title;
                label2.Text = itemsList[listView1.FocusedItem.Index].artist + "\n" + itemsList[listView1.FocusedItem.Index].genre + "\nComments:" + itemsList[listView1.FocusedItem.Index].num_comments;
            }
            timer1.Enabled = true;
            trackBar1.Maximum = (int)player.audioFile.TotalTime.TotalSeconds;
        }


        private void PlayOffset()
        {
            if (queueTracks.Count > offset)
            {
                toolStripLabel1.Text = "Loading track:" + offset;
                player.Play(queueTracks[offset].Mp3Url);
                toolStripLabel1.Text = "Loading artwork";
                pictureBox1.LoadAsync("https://f4.bcbits.com/img/a" + queueTracks[offset].Album.ArtworkId + "_2.jpg");
                toolStripLabel1.Text = "Done!";
                queueList.Items[offset].Selected = true;
                UpdateInfo();
            }
            else
            {
                player.Close();
            }
        }

        private void CleanUp()
        {
            try
            {
                queueList.Items.Clear();
                queueTracks.Clear();
                queueList.LargeImageList.Images.Clear();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void ToogleAllContorls()
        {
            foreach (Control c in Controls)
            {
                c.Enabled = !c.Enabled;
            }
        }

        private void BlockArtist()
        {
            if (streamMode)
            {
                try
                {
                    addBlocked(queueTracks[queueList.FocusedItem.Index].Album.Artist);
                    MessageBox.Show("You blocked " + queueTracks[queueList.FocusedItem.Index].Album.Artist + " this will applyed in next stream mode session", "MISHA!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Selected artist cannot be blocked!", "Something happend", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This feature works only in stream mode", "Not works...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
