﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace onlineplayer
{
    public static class Playlist
    {
        public static void SavePlaylist(string filename, List<Track> queueTracks)
        {
            File.Delete(filename);
            XmlWriter xmlWriter = XmlWriter.Create(filename);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("queueList");

            foreach (Track trk in queueTracks)
            {
                xmlWriter.WriteStartElement("track");
                xmlWriter.WriteAttributeString("trackUrl", trk.Url);
                xmlWriter.WriteAttributeString("artistUrl", trk.ArtistUrl);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
    }
}
