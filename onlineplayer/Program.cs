using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace onlineplayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists("settings.xml"))
            {
                XmlWriter xmlWriter = XmlWriter.Create("settings.xml");

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("settings");

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("albumViewType", "Tile");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("albumViewSize", "64");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("saveArtworks", "True");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("loadPages", "100");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("setting");
                xmlWriter.WriteAttributeString("midiDevice", "0");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
            Application.Run(new Form1());
        }
    }
}
