using System;
using System.Xml;
using Celeste.Core.Serialization.Xml;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    internal static class EverestAutotilerXmlSourceExtensions
    {
        public static char SourceAttrChar(this XmlElement xml, string name) =>
            Convert.ToChar(xml.Attributes[name].InnerText);

        public static int SourceAttrInt(this XmlElement xml, string name) => SourceXmlAttributes.AttrInt(xml, name);

        public static bool SourceAttrBool(this XmlElement xml, string name) =>
            Convert.ToBoolean(xml.Attributes[name].InnerText);

        public static bool SourceHasChild(this XmlElement xml, string name) => xml[name] != null;
    }
}
