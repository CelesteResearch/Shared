using System.Collections.Generic;
using System.Xml;
using Celeste.Everest.Content.Assets;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed partial class EverestDecalRegistry
    {
        private List<KeyValuePair<string, EverestDecalInfo>> ReadRegistryXml(EverestContentAsset asset)
        {
            var xml = new XmlDocument();
            xml.Load(asset.Stream);
            var result = new List<KeyValuePair<string, EverestDecalInfo>>();
            var root = xml["decals"];
            if (root == null)
            {
                logger.DecalMissingTag(asset);
                return result;
            }

            foreach (XmlNode node in root)
            {
                if (!(node is XmlElement element)) continue;
                string path = (element.HasAttribute("path") ? element.GetAttribute("path") : null)?.ToLower();
                if (path == null)
                {
                    logger.DecalMissingPath(asset);
                    continue;
                }

                var info = new EverestDecalInfo
                    { CustomProperties = new List<KeyValuePair<string, XmlAttributeCollection>>() };
                foreach (XmlNode child in element.ChildNodes)
                    if (child is XmlElement property)
                        info.CustomProperties.Add(
                            new KeyValuePair<string, XmlAttributeCollection>(property.Name, property.Attributes));
                result.Add(new KeyValuePair<string, EverestDecalInfo>(path, info));
            }

            result.Sort((a, b) =>
            {
                int first = a.Key[a.Key.Length - 1] switch { '/' => 2, '*' => 1, _ => 0 };
                int second = b.Key[b.Key.Length - 1] switch { '/' => 2, '*' => 1, _ => 0 };
                return first != second || first != 1 ? second - first : a.Key.Length - b.Key.Length;
            });
            return result;
        }

        private EverestDecalPropertyHandler CreateHandlerOrNull(string decal, string property,
            XmlAttributeCollection attributes)
        {
            if (!handlers.TryGetValue(property, out var factory))
            {
                logger.DecalUnknownProperty(property, decal);
                return null;
            }

            var handler = factory();
            handler.BindSourceLogger(logger);
            handler.Parse(attributes);
            return handler;
        }

        private void RegisterDecal(string path, EverestDecalInfo info)
        {
            if (info.Handlers == null)
            {
                info.Handlers = new List<EverestDecalPropertyHandler>(info.CustomProperties.Count);
                var scale = info.CustomProperties.Find(property => property.Key == "scale");
                if (scale.Value != null)
                {
                    var handler = CreateHandlerOrNull(path, scale.Key, scale.Value);
                    if (handler != null) info.Handlers.Add(handler);
                }

                foreach (var property in info.CustomProperties)
                    if (property.Key != "scale")
                    {
                        var handler = CreateHandlerOrNull(path, property.Key, property.Value);
                        if (handler != null) info.Handlers.Add(handler);
                    }
            }

            logger.DecalRegistered(path, RegisteredDecals.ContainsKey(path));
            RegisteredDecals[path] = info;
        }
    }
}
