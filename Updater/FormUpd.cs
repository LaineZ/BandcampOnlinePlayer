using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    public partial class FormUpd : Form
    {
        public void Download(string remoteUri)
        {
            string FilePath = "update.zip"; // path where download file to be saved, with filename, here I have taken file name from supplied remote url
            using (WebClient client = new WebClient())
            {
                try
                {
                    Uri uri = new Uri(remoteUri);
                    //delegate method, which will be called after file download has been complete.
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Extract);
                    //delegate method for progress notification handler.
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgessChanged);
                    // uri is the remote url where filed needs to be downloaded, and FilePath is the location where file to be saved
                    client.DownloadFileAsync(uri, FilePath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void ExtractZipFileToDirectory(string sourceZipFilePath, string destinationDirectoryName, bool overwrite)
        {
            using (var archive = ZipFile.Open(sourceZipFilePath, ZipArchiveMode.Read))
            {
                if (!overwrite)
                {
                    archive.ExtractToDirectory(destinationDirectoryName);
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(destinationDirectoryName);
                string destinationDirectoryFullPath = di.FullName;

                foreach (ZipArchiveEntry file in archive.Entries)
                {
                    string completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                    if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new IOException("Trying to extract file outside of destination directory. See this link for more info: https://snyk.io/research/zip-slip-vulnerability");
                    }

                    if (file.Name == "")
                    {// Assuming Empty for Directory
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                        continue;
                    }
                    file.ExtractToFile(completeFileName, true);
                }
            }
        }

        public async Task<String> MakeRequestAsync(String url)
        {
            String responseText = await Task.Run(() =>
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:72.0) Gecko/20100101 Firefox/72.0";
                    WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    return new StreamReader(responseStream).ReadToEnd();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error occured:" + e.Message, url, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            });
            return responseText;
        }

        public void Extract(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "Extracting...";
            ExtractZipFileToDirectory("update.zip", Directory.GetCurrentDirectory(), true);
            System.Diagnostics.Process.Start("onlineplayer.exe");
            File.Delete("update.zip");
            Application.Exit();
        }

        public void ProgessChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label1.Text = "Downloading release: " + e.ProgressPercentage + "%";
            progressBar1.Value = e.ProgressPercentage;
        }

        public FormUpd()
        {
            InitializeComponent();
        }

        private async void FormUpd_Load(object sender, EventArgs e)
        {
            string version = await MakeRequestAsync("https://raw.githubusercontent.com/LaineZ/BandcampOnlinePlayer/master/latestversion.txt");
            Download("https://github.com/LaineZ/BandcampOnlinePlayer/releases/download/" + version.TrimEnd() + "/Player-Win.zip");
        }
    }
}
