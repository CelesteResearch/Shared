using System;
using System.IO;
using System.Xml;
using Celeste.Core.Geometry;

namespace Celeste.Formats.Graphics.Atlas
{
    internal static class AtlasSourceReadExtensions
    {
        internal static bool HasAttr(this XmlElement xml, string name)
        {
            return xml.Attributes[name] != null;
        }

        internal static string Attr(this XmlElement xml, string name)
        {
            return xml.Attributes[name].InnerText;
        }

        internal static string Attr(this XmlElement xml, string name, string defaultValue)
        {
            return xml.HasAttr(name) ? xml.Attributes[name].InnerText : defaultValue;
        }

        internal static int AttrInt(this XmlElement xml, string name)
        {
            return Convert.ToInt32(xml.Attributes[name].InnerText);
        }

        internal static IntRect Rect(this XmlElement xml)
        {
            return new(xml.AttrInt("x"), xml.AttrInt("y"), xml.AttrInt("width"), xml.AttrInt("height"));
        }

        internal static string ReadNullTerminatedString(this BinaryReader stream)
        {
            var text = "";
            char c;
            while ((c = stream.ReadChar()) != 0) text += c;
            return text;
        }
    }
}
