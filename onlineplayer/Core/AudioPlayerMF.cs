using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace onlineplayer
{
    public class AudioPlayerMF : Core.IAudioPlayer
    {
        public WaveOutEvent outputDevice;
        public MediaFoundationReader audioFile;

        public void Init()
        {
            // not used by MediaFoundation backend
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
            Console.WriteLine(url);
            if (audioFile != null)
            {
                Close();
            }

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
            }
            if (audioFile == null)
            {
                try
                {
                    audioFile = new MediaFoundationReader(url);
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to start playback:\n" + e.ToString(), "Audio output error:" + url, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            return audioFile.CurrentTime.TotalSeconds;
        }

        public double GetTotalTimeSeconds()
        {
            return audioFile.TotalTime.TotalSeconds;
        }

        public void SetPos(double seconds)
        {
            WaveStreamExtensions.SetPosition(audioFile, seconds);
        }

        public float GetVolume()
        {
            return outputDevice.Volume;
        }

        public void SetVolume(float volume)
        {
            outputDevice.Volume = volume;
        }

        public string GetPlaybackState()
        {
            return outputDevice.PlaybackState.ToString();
        }
    }
}
    