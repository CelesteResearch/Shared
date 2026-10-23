using System.Collections.Generic;
using System.IO;
using System.Xml;
using Celeste.Formats.Graphics.Sprites;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Text;
using Celeste.Everest.Content.Types.Graphics;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Content.Graphics
{
    public sealed class EverestGraphicsXmlReader
    {
        private readonly IEverestGraphicsContentIo io;
        private readonly EverestContentRegistry content;
        private readonly EverestLoggerProcess logger;

        public EverestGraphicsXmlReader(IEverestGraphicsContentIo io, EverestContentRegistry content,
            EverestLoggerProcess logger)
        {
            this.io = io;
            this.content = content;
            this.logger = logger;
        }

        public XmlDocument LoadOriginal(string path)
        {
            var document = new XmlDocument();
            using var stream = io.OpenOriginalXml(path);
            document.Load(stream);
            return document;
        }

        public XmlDocument LoadContent(string path)
        {
            if (content.TryGet<AssetTypeXml>(path.Substring(0, path.Length - 4), out var asset))
            {
                var document = new XmlDocument();
                using var stream = asset.Stream;
                document.Load(stream);
                return document;
            }

            return io.OriginalXmlExists(path) ? LoadOriginal(path) : new XmlDocument();
        }

        public XmlDocument LoadSpriteBank(string path)
        {
            if (!io.OriginalXmlExists(path)) return LoadContent(path);
            var document = LoadOriginal(path);
            var baseline = LoadOriginal(path);
            var root = document["Sprites"];
            string virtualPath = path.Substring(0, path.Length - 4).Replace('\\', '/');
            var assets = new List<EverestContentAsset>();
            lock (content.Map)
            {
                foreach (var pair in content.Map)
                {
                    var asset = pair.Value;
                    if (asset.Type == typeof(AssetTypeSpriteBank) && asset.PathVirtual.Equals(virtualPath) &&
                        !asset.PathVirtual.Equals(pair.Key)) assets.Add(asset);
                }
            }

            foreach (var asset in assets)
            {
                string sourcePath = asset.Source.Mod.PathDirectory;
                if (string.IsNullOrEmpty(sourcePath)) sourcePath = asset.Source.Mod.PathArchive;
                using var stream = asset.Stream;
                var mod = new XmlDocument();
                mod.Load(stream);
                EverestSpriteBankXmlFilter.FilterVanillaCopies(baseline, mod, sourcePath, logger);
                foreach (XmlNode node in mod["Sprites"].ChildNodes)
                {
                    if (node is not XmlElement) continue;
                    var imported = document.ImportNode(node, true);
                    var previous = root.SelectSingleNode(node.Name);
                    if (previous != null)
                    {
                        logger.Log(EverestLogLevel.Warn, "Content",
                            "Sprite \"" + node.Name + "\" from " + path + " is overridden by " + sourcePath);
                        root.ReplaceChild(imported, previous);
                    }
                    else root.AppendChild(imported);
                }
            }

            return document;
        }

        public XmlDocument LoadModdedSprites(string path)
        {
            var baseline = LoadOriginal(Path.Combine("Graphics", "Sprites.xml"));
            var mod = LoadContent(path);
            return EverestSpriteBankXmlFilter.FilterVanillaCopies(baseline, mod, path, logger);
        }
    }
}
