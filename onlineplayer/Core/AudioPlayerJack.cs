using NAudio.Wave;
using Jack.NAudio;
using System;
using System.Windows.Forms;
using JackSharp;
using System.IO;
using System.Net;

namespace onlineplayer
{
    public class AudioPlayerJack : Core.IAudioPlayer
    {
        public AudioOut outputDevice;
        public Mp3FileReader audioFile;

        public void Init()
        {
            // not used by Jack backend
        }

        public void Close()
        {
            try
            {
                outputDevice.Dispose();
                outputDevice = null;
                audioFile.Dispose();
                audioFile = null;
            }
            catch (NullReferenceException)
            {

            }
        }

        public void Play(string url)
        {
            if (outputDevice == null)
            {
                Processor client = new Processor("BandcampOnlinePlayer", 0, 2, 0, 0, true);
                outputDevice = new AudioOut(client);
            }

            using (WebClient myWebClient = new WebClient())
            {
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(url, "tempfile.mp3");
            }

            audioFile = new Mp3FileReader("tempfile.mp3");
            Wave16ToFloatProvider converter = new Wave16ToFloatProvider(audioFile);
            outputDevice.Init(converter);
            outputDevice.Play();
        }

        public void PlayPause()
        {
            try
            {
                if (outputDevice.PlaybackState == PlaybackState.Paused)
                {
                    outputDevice.Play();
                }
                else
                {
                    outputDevice.Pause();
                }
            }
            catch (NullReferenceException)
            {

            }
        }


        public int GetCurrentTimeSeconds()
        {
            return audioFile.CurrentTime.Seconds;
        }

        public double GetCurrentTimeTotalSeconds()
        {
            try
            {
                return audioFile.CurrentTime.TotalSeconds;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        public double GetTotalTimeSeconds()
        {
            try
            {
                return audioFile.TotalTime.TotalSeconds;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        public void SetPos(double seconds)
        {
            try
            {
                WaveStreamExtensionsMp3.SetPosition(audioFile, seconds);
            }
            catch (NullReferenceException)
            {
                
            }
        }

        public float GetVolume()
        {
            try
            {
                return outputDevice.Volume;
            }
            catch (NullReferenceException)
            {
                return 1.0F;
            }
        }

        public void SetVolume(float volume)
        {
            try
            {
                outputDevice.Volume = volume;
            }
            catch (NullReferenceException)
            {
                
            }
        }

        public string GetPlaybackState()
        {
            try
            {
                return outputDevice.PlaybackState.ToString();
            }
            catch (NullReferenceException)
            {
                return "Jack is stopped";
            }
        }
    }
}
    