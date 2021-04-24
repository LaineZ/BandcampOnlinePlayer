using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace BandcampOnlinePlayer
{
    class MainWindow : Form
    {
        Scrollable ScrollLayout = new Scrollable();
        StackLayout TracksList = new StackLayout();
        StackLayout MainLayout = new StackLayout();

        Button BtnPlay = new Button() { Text = "Play", Width = 30 };
        Button BtnNext = new Button() { Text = "Next", Width = 30 };

        Button BtnPrev = new Button() { Text = "Prev", Width = 30 };

        Slider SlPlayback = new Slider();

        Slider SlVolume = new Slider() { MaxValue = 100 };

        RichTextArea TrackInfo = new RichTextArea() { Wrap = false, ReadOnly = true, Height = 10 };

        public MainWindow()
        {
            ClientSize = new Size(800, 600);
            ScrollLayout.Content = TracksList;

            for (int i = 0; i < 100; i++)
            {
                TracksList.Items.Add(new StackLayoutItem(new Label() { Text = "Item: " + i }) { Expand = true });
            }

            MainLayout.Items.Add(new StackLayoutItem(ScrollLayout, HorizontalAlignment.Center, true));
            MainLayout.Items.Add(new StackLayoutItem(TrackInfo));
            Content = MainLayout;
        }
    }
}
