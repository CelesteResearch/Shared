using System.Collections.Generic;
using System.Xml;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Content.Graphics
{
    public static class EverestSpriteBankXmlFilter
    {
        public static XmlDocument FilterVanillaCopies(XmlDocument vanilla, XmlDocument mod,
            string path, EverestLoggerProcess logger)
        {
            XmlNode baseline = vanilla["Sprites"];
            XmlNode root = mod["Sprites"];
            var identical = new List<XmlNode>();
            var copiedByChanged = new List<string>();
            foreach (var node in GetChildElements(root))
            {
                var original = baseline.SelectSingleNode(node.Name);
                if (original != null)
                {
                    if (Identical(original, node))
                    {
                        identical.Add(node);
                        continue;
                    }

                    logger.Log(EverestLogLevel.Verbose, "SpriteBank",
                        "Sprite \"" + node.Name + "\" will be overridden with " + path + ".");
                    var copy = node.Attributes["copy"]?.Value;
                    if (copy != null) copiedByChanged.Add(copy);
                }
                else
                {
                    logger.Log(EverestLogLevel.Verbose, "SpriteBank",
                        "Sprite \"" + node.Name + "\" will be added from " + path + ".");
                }
            }

            foreach (var node in identical.ToArray())
                if (copiedByChanged.Contains(node.Name))
                    logger.Log(EverestLogLevel.Verbose, "SpriteBank",
                        "Sprite \"" + node.Name + "\" will be overridden with " + path +
                        ", because it is copied by another sprite.");
                else root.RemoveChild(node);

            return mod;
        }

        private static bool Identical(XmlNode first, XmlNode second)
        {
            if (first.Attributes.Count != second.Attributes.Count) return false;
            for (var index = 0; index < first.Attributes.Count; index++)
                if (first.Attributes[index].Name != second.Attributes[index].Name
                    || first.Attributes[index].Value != second.Attributes[index].Value)
                    return false;
            var firstChildren = GetChildElements(first);
            var secondChildren = GetChildElements(second);
            if (firstChildren.Count != secondChildren.Count) return false;
            for (var index = 0; index < firstChildren.Count; index++)
                if (!Identical(firstChildren[index], secondChildren[index]))
                    return false;
            return true;
        }

        private static List<XmlNode> GetChildElements(XmlNode node)
        {
            var elements = new List<XmlNode>();
            foreach (XmlNode child in node.ChildNodes)
                if (child is XmlElement)
                    elements.Add(child);
            return elements;
        }
    }
}
