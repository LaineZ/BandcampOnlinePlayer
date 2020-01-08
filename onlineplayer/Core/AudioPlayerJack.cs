using NAudio.Wave;
using Jack.NAudio;
using System;
using System.Windows.Forms;
using JackSharp;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace onlineplayer
{
    public class AudioPlayerJack : Core.IAudioPlayer
    {
        public AudioOut outputDevice;
        public WaveFileReader audioFile;

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

            var processStartInfo = new ProcessStartInfo
            {
                FileName = @"ffmpeg",
                Arguments = "-i \"" + url + "\" -f wav tempfile.wav",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            var process = Process.Start(processStartInfo);
            process.WaitForExit(0);
            audioFile = new WaveFileReader("tempfile.wav");
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
                WaveStreamExtensionsJack.SetPosition(audioFile, seconds);
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
    