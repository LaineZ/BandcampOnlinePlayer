﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static onlineplayer.Utils;
using static onlineplayer.Json;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace onlineplayer
{
    public partial class Form1
    {
        HttpClient client = new HttpClient();

        private void PlayFormList()
        {
            try
            {
                string url = itemsList[listAlbums.FocusedItem.Index].audio_url.mp3;
                labelStatus.Text = "Loading file...";
                player.Play(url);
                labelStatus.Text = "Loading artwork...";
                pictureArtwork.LoadAsync("https://f4.bcbits.com/img/a" + itemsList[listAlbums.FocusedItem.Index].art_id + "_2.jpg");
                labelStatus.Text = "Done!";
                UpdateInfo();
            }
            catch (NullReferenceException)
            {
                timer1.Stop();
                MessageBox.Show("Cannot start plaback. Try to clean metadata cache and rescan", "Opening failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateAlbumsImages()
        {
            ImageList il = new ImageList();
            int count = 0;
            il.ImageSize = new System.Drawing.Size(imgSize, imgSize);
            if (downloadImgs)
            {
                foreach (ListViewItem listItem in listAlbums.Items)
                {
                    labelStatus.Text = "Loading ablum images...";
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    listAlbums.LargeImageList = il;
                    il.Images.Add(await httpTools.DownloadImagesFromWeb("https://f4.bcbits.com/img/a" + itemsList[count].art_id + "_8.jpg"));
                    listItem.ImageIndex = count++;
                }
            }

            toolSearch.Enabled = true;
            labelStatus.Text = "Done!";
        }

        private void PlayNext()
        {
            try
            {
                if (!toolShuffle.Checked)
                {
                    offset++;
                }
                else
                {
                    Random rand = new Random();
                    offset = rand.Next(0, queueTracks.Count - 1);
                }
                PlayOffset();
            }
            catch (Exception)
            {
                if (queueList.Items.Count > 0)
                {
                    offset = queueList.FocusedItem.Index;
                    labelStatus.Text = "End of queue list!";
                }
                else
                {
                    labelStatus.Text = "Queue is empty!";
                }
            }
        }

        private void PlayPrev()
        {
            try
            {
                if (queueList.Items.Count > 0)
                {
                    offset--;
                    PlayOffset();
                }
                else
                {
                    labelStatus.Text = "Queue is empty!";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                offset = 0;
                PlayOffset();
                labelStatus.Text = "This a first track in queue list!";
            }
        }

        private async void UpdateAlbums()
        {
            // {"filters":{ "format":"all","location":0,"sort":"pop","tags":["experimental"] },"page":2}
            toolStream.Enabled = true;
            for (int i = 1; i < int.Parse(getSettingsAttr("settings.xml", "loadPages")); i++)
            {
                labelStatus.Text = "Loading ablums tag data: " + i + "/" + "100";
                string responseString = "none";
                string sorting = "pop";

                if (!toolSort.Checked) {sorting = "date"; } // if not popularity

                string fname = "artwork_cache/" + i + "_" + listTags.SelectedItem + "_" + sorting + ".json";
                if (!File.Exists(fname))
                {
                    string content = "{\"filters\":{ \"format\":\"all\",\"location\":0,\"sort\":\"" + sorting + "\",\"tags\":[\"" + listTags.SelectedItem + "\"] },\"page\":" + i + "}";
                    HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://bandcamp.com/api/hub/2/dig_deeper", c);
                    responseString = await response.Content.ReadAsStringAsync();
                    File.WriteAllText(fname, responseString);
                }
                else
                {
                    responseString = File.ReadAllText(fname);
                }
                //Console.WriteLine(responseString);
                try
                {
                    RootObject items = JsonConvert.DeserializeObject<RootObject>(responseString);
                    foreach (var item in items.items)
                    {
                        // title, artist, mp3_url, url, artworkid
                        ListViewItem lst = new ListViewItem(new string[] { item.title, item.artist });
                        listAlbums.Items.Add(lst);
                        itemsList.Add(item);
                    }
                }
                catch (Exception ekj)
                {
                    if (ekj is NullReferenceException)
                    {
                        MessageBox.Show("Albums not recived", "Error getting data...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    //MessageBox.Show("Error occured:" + ekj.Message, "пиздец", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                labelStatus.Text = "Done!";
            }

            UpdateAlbumsImages();
        }

        private void UpdateInfo()
        {
            try
            {
                labelTrackName.Text = queueTracks[offset].Title;
                labelTrackInfo.Text = queueTracks[offset].Album.Artist + "\n" + queueTracks[offset].Album.Title + "\n" + queueTracks[offset].Album.ReleaseDate + "\nTrack number " + offset;
            }
            catch (ArgumentOutOfRangeException)
            {
                labelTrackName.Text = itemsList[listAlbums.FocusedItem.Index].title;
                labelTrackInfo.Text = itemsList[listAlbums.FocusedItem.Index].artist + "\n" + itemsList[listAlbums.FocusedItem.Index].genre + "\nComments:" + itemsList[listAlbums.FocusedItem.Index].num_comments;
            }
            timer1.Enabled = true;
            trackSeek.Maximum = (int)player.audioFile.TotalTime.TotalSeconds;
        }


        private void PlayOffset()
        {
            if (queueTracks.Count > offset)
            {
                labelStatus.Text = "Loading track:" + offset;
                player.Play(queueTracks[offset].Mp3Url);
                labelStatus.Text = "Loading artwork";
                pictureArtwork.LoadAsync("https://f4.bcbits.com/img/a" + queueTracks[offset].Album.ArtworkId + "_2.jpg");
                labelStatus.Text = "Done!";
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

       

        private async void DownloadFromBandcamp()
        {
            ToogleAllContorls();
            Form loader = new FormProgress("Fetching tags from bandcamp.com", "Retriving data from bandcamp.com please wait...");
            loader.Show();
            
            // Full clean up
            listTags.Items.Clear();
            listAlbums.Items.Clear();
            CleanUp();

            HttpTools httpTools = new HttpTools();
            String response = await httpTools.MakeRequestAsync("https://bandcamp.com/tags");
            
            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(response);

            List<string> hrefTags = new List<string>();
            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.StartsWith("/tag/"))
                {
                    listTags.Items.Add(att.Value.Replace("/tag/", ""));
                }
            }

            loader.Close();
            ToogleAllContorls();
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