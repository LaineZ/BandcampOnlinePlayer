using Eto.Forms;
using Eto.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BandcampOnlinePlayer
{
    class SplashScreen : Form
    {
        ImageView MainImage = new ImageView() { Image = new Bitmap("Assets/splashscreen.jpg") };
        UITimer Fadeout = new UITimer() { Interval = 0.033 };

        public SplashScreen()
        {
            Opacity = 0;
            ClientSize = new Size(640, 360);
            if (Screen != null)
            {
                Location = new Point((int)(Screen.WorkingArea.Width - ClientSize.Width) / 2, (int)(Screen.WorkingArea.Height - ClientSize.Height) / 2);
            }
            Resizable = false;
            WindowStyle = WindowStyle.Utility;
            
            Fadeout.Elapsed += Fadeout_Elapsed;
            Fadeout.Start();

            Content = MainImage;
        }

        private void Fadeout_Elapsed(object sender, EventArgs e)
        {
            Opacity += 0.1;

            if (Opacity > 1)
            {
                Fadeout.Stop();
            }
        }
    }
}
