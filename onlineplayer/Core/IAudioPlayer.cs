using Jack.NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineplayer.Core
{
    public interface IAudioPlayer
    {
        void Init();
        void Close();
        void PlayPause();
        void Play(string url);
        int GetCurrentTimeSeconds();
        double GetCurrentTimeTotalSeconds();
        double GetTotalTimeSeconds();
        void SetPos(double seconds);
        float GetVolume();
        void SetVolume(float volume);
        string GetPlaybackState();
    }
}
