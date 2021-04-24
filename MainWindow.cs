using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace BandcampOnlinePlayer
{
    class MainWindow : Form
    {
        Scrollable ScrollLayout = new Scrollable() { MinimumSize = new Size(800, 600) };
        StackLayout TracksList = new StackLayout();
        TableLayout MainLayout = new TableLayout() { Style = "padded-table" };

        public MainWindow()
        {
            ClientSize = new Size(800, 600);
            ScrollLayout.Content = TracksList;

            for (int i = 0; i < 100; i++)
            {
                TracksList.Items.Add(new StackLayoutItem(new Label() { Text = "Item: " + i }));
            }

            MainLayout.Rows.Add(new TableRow(ScrollLayout) { ScaleHeight = true });
            Content = MainLayout;
        }
    }
}
