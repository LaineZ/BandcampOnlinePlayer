using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace onlineplayer
{
    public static class MidiActionsBindings
    {
        [XmlElement("ActionsBinding")]
        internal static List<MidiAction> actionsMidi = new List<MidiAction>();
    }
}
