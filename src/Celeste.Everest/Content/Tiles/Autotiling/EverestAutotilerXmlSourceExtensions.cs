using System;
using System.Xml;
using Celeste.Core.Serialization.Xml;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    internal static class EverestAutotilerXmlSourceExtensions
    {
        public static char SourceAttrChar(this XmlElement xml, string name)
        {
            return Convert.ToChar(xml.Attributes[name].InnerText);
        }

        public static int SourceAttrInt(this XmlElement xml, string name)
        {
            return xml.AttrInt(name);
        }

        public static bool SourceAttrBool(this XmlElement xml, string name)
        {
            return Convert.ToBoolean(xml.Attributes[name].InnerText);
        }

        public static bool SourceHasChild(this XmlElement xml, string name)
        {
            return xml[name] != null;
        }
    }
}
