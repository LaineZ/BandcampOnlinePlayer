using Eto.Drawing;
using Eto.Forms;
using onlineplayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace BandcampOnlinePlayer
{
    class MainWindow : Form
    {
        GridView Tracks = new GridView();
        GridView Queue = new GridView();
        TableLayout MainLayout = new TableLayout();
        TableLayout PlayerControls = new TableLayout();

        Button BtnPlay = new Button() { Text = "Play", Width = 30 };
        Button BtnNext = new Button() { Text = "Next", Width = 30 };
        Button BtnPrev = new Button() { Text = "Prev", Width = 30 };
        Button LoadTags = new Button() { Text = "Load discover" };

        Slider SlPlayback = new Slider() { MaxValue = 300 };
        Label TimeLabel = new Label() { Text = "00:00 / 30:00", Width = 50, VerticalAlignment = VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
        Slider SlVolume = new Slider() { MaxValue = 100 };

        Core.Discover Discover = new Core.Discover(new List<string>() { "metal" });
        RichTextArea TrackInfo = new RichTextArea() { Wrap = false, ReadOnly = true, Height = 16, Text = "Track info goes here" };
        public MainWindow()
        {
            LoadTags.Click += LoadTags_Click;
            Tracks.DataStore = Discover.Content;

            Tracks.Columns.Add(new GridColumn
            {
                DataCell = new TextBoxCell("title"),
                HeaderText = "Tittle"
            });

            Tracks.Columns.Add(new GridColumn
            {
                DataCell = new CheckBoxCell("band_name"),
                HeaderText = "Artist"
            });

            ClientSize = new Size(800, 600);
            PlayerControls.Rows.Add(new TableRow() { Cells = { BtnPrev, BtnPlay, BtnNext, TimeLabel, SlVolume, new TableCell(SlPlayback, true) } });
            MainLayout.Rows.Add(new TableRow() { ScaleHeight = true, Cells = { new TableCell(Tracks) { ScaleWidth = true }, new TableCell(Queue) { ScaleWidth = true } } });
            MainLayout.Rows.Add(new TableRow(new TableCell(TrackInfo) { ScaleWidth = true }, LoadTags));
            MainLayout.Rows.Add(PlayerControls);

            Content = MainLayout;
        }

        private async void LoadTags_Click(object sender, EventArgs e)
        {
            await Discover.GetDiscover();
        }
    }
}
