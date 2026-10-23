using System;
using System.Collections.Generic;
using System.Xml;

namespace Celeste.Graphics.Content.Xml
{
    public static class TileExtensions
    {
        public static string Attr(this XmlElement element, string name) => element.GetAttribute(name);
        public static char AttrChar(this XmlElement element, string name) => element.GetAttribute(name)[0];
        public static bool HasAttr(this XmlElement element, string name) => element.HasAttribute(name);
    }
}
