using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace onlineplayer
{
    public class AudioPlayer
    {
        public WaveOutEvent outputDevice;
        public MediaFoundationReader audioFile;

        public void AudioDev(WaveOutEvent OutPutDevice, MediaFoundationReader AudioFile)
        {
            outputDevice = OutPutDevice;
            audioFile = AudioFile;
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
                    MessageBox.Show("Unable to start playback:\nClean metadata cache and rescan can help fix that problem...\n\n" + e.ToString(), "Audio output error:" + url, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
