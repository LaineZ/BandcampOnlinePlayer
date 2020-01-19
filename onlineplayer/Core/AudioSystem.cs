using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlineplayer.Core
{
    public static class AudioSystem
    {
        public static IAudioPlayer CreateAudioDevice()
        {
            switch (Config.audioSystem)
            {
                case 0:
                    Console.WriteLine("using wavout");
                    return new AudioPlayerMF();
                case 1:
                    Console.WriteLine("using jack");
                    return new AudioPlayerJack();
                default:
                    throw new NullReferenceException();
            }
        }
    }
}
