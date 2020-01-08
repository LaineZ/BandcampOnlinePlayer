using NAudio.Wave;
using System;

namespace onlineplayer
{
    public static class WaveStreamExtensionsMp3
    {
        // Set position of WaveStream to nearest block to supplied position
        public static void SetPosition(this Mp3FileReader strm, long position)
        {
            // distance from block boundary (may be 0)
            long adj = position % strm.WaveFormat.BlockAlign;
            // adjust position to boundary and clamp to valid range
            long newPos = Math.Max(0, Math.Min(strm.Length, position - adj));
            // set playback position
            strm.Position = newPos;
        }

        // Set playback position of WaveStream by seconds
        public static void SetPosition(this Mp3FileReader strm, double seconds)
        {
            strm.SetPosition((long)(seconds * strm.WaveFormat.AverageBytesPerSecond));
        }

        // Set playback position of WaveStream by time (as a TimeSpan)
        public static void SetPosition(this Mp3FileReader strm, TimeSpan time)
        {
            strm.SetPosition(time.TotalSeconds);
        }

        // Set playback position of WaveStream relative to current position
        public static void Seek(this Mp3FileReader strm, double offset)
        {
            strm.SetPosition(strm.Position + (long)(offset * strm.WaveFormat.AverageBytesPerSecond));
        }
    }
}
