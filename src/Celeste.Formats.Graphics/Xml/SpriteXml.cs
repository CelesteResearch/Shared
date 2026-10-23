using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Xml;

namespace Celeste.Formats.Graphics.Xml
{
    public static class SpriteXml
    {
        public static XmlDocument Load(string path)
        {
            var xml = new XmlDocument();
            xml.Load(path);
            return xml;
        }

        public static string Attr(this XmlElement xml, string name, string fallback) =>
            xml.HasAttribute(name) ? xml.GetAttribute(name) : fallback;

        public static float AttrFloat(this XmlElement xml, string name, float fallback = 0) => xml.HasAttribute(name)
            ? float.Parse(xml.GetAttribute(name), CultureInfo.InvariantCulture)
            : fallback;

        public static bool HasChild(this XmlElement xml, string name) => xml[name] != null;

        public static Vector2 ChildPosition(this XmlElement xml, string name) =>
            new Vector2(xml[name].AttrFloat("x"), xml[name].AttrFloat("y"));

        public static int[] ReadFrames(string csv)
        {
            if (csv == "") return Array.Empty<int>();
            var result = new List<int>();
            foreach (string part in csv.Split(','))
            {
                if (part.IndexOf('-') != -1)
                {
                    var range = part.Split('-');
                    int start = Convert.ToInt32(range[0]), end = Convert.ToInt32(range[1]);
                    for (int i = start; i != end; i += Math.Sign(end - start)) result.Add(i);
                    result.Add(end);
                }
                else if (part.IndexOf('*') != -1)
                {
                    var repeat = part.Split('*');
                    int frame = Convert.ToInt32(repeat[0]), count = Convert.ToInt32(repeat[1]);
                    for (int i = 0; i < count; i++) result.Add(frame);
                }
                else result.Add(Convert.ToInt32(part));
            }

            return result.ToArray();
        }
    }
}
