using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace onlineplayer.Core
{

    public class Config
    {
        public static int midiDevice { get; set; }
        public static int pagesLoad { get; set; }
        public static int viewSize { get; set; }
        public static string viewType { get; set; }
        public static bool useMidi { get; set; }
        public static bool saveArtworks { get; set; }
        public static bool saveQueue { get; set; }
        public static int audioSystem { get; set; }
        public static bool jackReopen { get; set; }

        public static void SaveConfig()
        {
            XmlWriter xmlWriter = XmlWriter.Create("settings.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("settings");

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("albumViewType", viewType);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("albumViewSize", viewSize.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("saveArtworks", saveArtworks.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("loadPages",  pagesLoad.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("midiDevice", midiDevice.ToString());
            xmlWriter.WriteEndElement();


            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("useMidi", useMidi.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("saveQueue", saveQueue.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("audioSystem", audioSystem.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("setting");
            xmlWriter.WriteAttributeString("jackReopen", jackReopen.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public static int TryLoadInt(string attr, int fallback)
        {
            try
            {
                return int.Parse(Utils.getSettingsAttr("settings.xml", attr));
            }
            catch (Exception)
            {
                return fallback;
            }
        }

        public static string TryLoadString(string attr, string fallback)
        {
            try
            {
                return Utils.getSettingsAttr("settings.xml", attr);
            }
            catch (Exception)
            {
                return fallback;
            }
        }

        public static bool TryLoadBool(string attr, bool fallback)
        {
            try
            {
                return Utils.getSettingsAttrBool("settings.xml", attr);
            }
            catch (Exception)
            {
                return fallback;
            }
        }

        public static void LoadConfig()
        {
            // Add here config values
            pagesLoad = TryLoadInt("loadPages", 100);
            midiDevice = TryLoadInt("midiDevice", 0);
            viewSize = TryLoadInt("albumViewSize", 64);
            audioSystem = TryLoadInt("audioSystem", 0);
            viewType = TryLoadString("albumViewType", "Tile");
            saveArtworks = TryLoadBool("saveArtworks", true);
            saveQueue = TryLoadBool("saveQueue", true);
            useMidi = TryLoadBool("useMidi", false);
            jackReopen = TryLoadBool("jackReopen", true);
        }
    }
}
