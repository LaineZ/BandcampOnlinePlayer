using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace onlineplayer
{
    class HttpTools
    {

        public async Task<String> MakeRequestAsync(String url)
        {
            String responseText = await Task.Run(() =>
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    return new StreamReader(responseStream).ReadToEnd();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error occured:" + e.Message, "пиздец", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            });
            return responseText;
        }

        public async Task<Bitmap> DownloadImagesFromWeb(string address)
        {
            Bitmap responseText = await Task.Run(() =>
            {
                try
                {
                    string filename = Path.GetFileName(address);
                    if (!File.Exists(@"artwork_cache\" + filename))
                    {
                        WebRequest request = WebRequest.Create(address);
                        WebResponse resp = request.GetResponse();
                        Stream respStream = resp.GetResponseStream();
                        Bitmap bmp = new Bitmap(respStream);
                        bmp.Save(@"artwork_cache\" + filename, bmp.RawFormat);
                        respStream.Dispose();
                        return bmp;
                    }
                    else
                    {
                        FileStream fs = File.OpenRead(@"artwork_cache\" + filename);
                        Bitmap bmp = new Bitmap(fs);
                        return bmp;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error occured:" + e.Message, "пиздец", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            });
            return responseText;
        }

        public static string FixJson(string albumData)
        {
            // Some JSON is not correctly formatted in bandcamp pages, so it needs to be fixed before we can deserialize it

            // In trackinfo property, we have for instance:
            //     url: "http://verbalclick.bandcamp.com" + "/album/404"
            // -> Remove the " + "
            var regex = new Regex("(?<root>url: \".+)\" \\+ \"(?<album>.+\",)");
            string fixedData = regex.Replace(albumData, "${root}${album}");

            return fixedData;
        }

        private string GetAlbumData(string htmlCode)
        {
            string startString = "var TralbumData = {";
            string stopString = "};";

            if (htmlCode.IndexOf(startString) == -1)
            {
                // Could not find startString
                throw new Exception("Could not find the following string in HTML code: var TralbumData = {");
            }

            string albumDataTemp = htmlCode.Substring(htmlCode.IndexOf(startString) + startString.Length - 1);
            string albumData = albumDataTemp.Substring(0, albumDataTemp.IndexOf(stopString) + 1);

            return albumData;
        }

        public Album GetAlbum(string htmlCode)
        {
            // Keep the interesting part of htmlCode only
            string albumData;
            try
            {
                albumData = GetAlbumData(htmlCode);
            }
            catch (Exception e)
            {
                throw new Exception("Could not retrieve album data in HTML code.", e);
            }

            // Fix some wrongly formatted JSON in source code
            albumData = FixJson(albumData);

            // Deserialize JSON
            Album album;
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                album = JsonConvert.DeserializeObject<JsonAlbum>(albumData, settings).ToAlbum();
            }
            catch (Exception e)
            {
                throw new Exception("Could not deserialize JSON data.", e);
            }

            return album;
        }
    }
}
