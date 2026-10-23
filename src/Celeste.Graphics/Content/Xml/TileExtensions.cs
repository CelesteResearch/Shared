using System.Xml;

namespace Celeste.Graphics.Content.Xml
{
    public static class TileExtensions
    {
        // ReSharper disable once ConvertToExtensionBlock
        public static string Attr(this XmlElement element, string name)
        {
            return element.GetAttribute(name);
        }

        public static char AttrChar(this XmlElement element, string name)
        {
            return element.GetAttribute(name)[0];
        }

        public static bool HasAttr(this XmlElement element, string name)
        {
            return element.HasAttribute(name);
        }
    }
}
