using NAudio.Midi;
using System;

namespace onlineplayer
{
    public class MidiAction
    {
        public MidiEvent MidiEv { get; set; }
        public ControlChangeEvent ControlData { get; set; }
        public NoteEvent NoteEvent { get; set; }
    }
}