using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace onlineplayer
{
    static class Utils
    {
        public static long GetDirectorySize(string p, string ext)
        {
            // 1
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*." + ext);

            // 2
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4
            // Return total size
            return b;
        }

        public static string getSettingsAttr(string filename, string attrb)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(filename);
            XmlElement xRoot = doc.DocumentElement;
            XmlNode attr;

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    attr = xnode.Attributes.GetNamedItem(attrb);
                    if (attr != null)
                    {
                        return attr.Value;
                    }
                }
                else
                {
                    throw new Exception("XML Attribute count is zero");
                }
            }
            return "Not found"; // IDK
        }

        public static bool getSettingsAttrBool(string filename, string attrib)
        {
            string value = getSettingsAttr(filename, attrib);
            if (value == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void addBlocked(string artist)
        {
            using (StreamWriter sw = File.AppendText("blocked.txt"))
            {
                sw.WriteLine(artist + "\n");
            }

        }

        public static List<string> viewBlocked()
        {
            List<string> blocked = new List<string>();
            string line;
            StreamReader file = new StreamReader("blocked.txt");
            while ((line = file.ReadLine()) != null)
            {
                blocked.Add(line);
            }
            file.Close();
            file.Dispose();
            return blocked;
        }

        public static void deleteBlocked(string toremove)
        {
            List<string> blocked = viewBlocked();
            blocked.Remove(toremove);
            File.WriteAllText("blocked.txt", String.Join("\n", blocked.ToArray()));
        }
    }
}
