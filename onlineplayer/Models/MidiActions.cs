using NAudio.Midi;

namespace onlineplayer
{

    internal class MidiAction
    {
        public MidiEvent MidiEv { get; set; }
        public string ActionName { get; set; }

        public MidiAction(MidiEvent ev = null)
        {
            MidiEv = ev;
        }
    }
}