using System;
using System.IO;
using System.Linq;
using System.Xml;
using Celeste.Core.IO.Content;
using Celeste.Core.Serialization.Xml;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Everest.Text.BitmapFonts
{
    public class SourceEverestPixelFont : SourcePixelFont
    {
        private readonly IEverestPixelFontProcess process;

        public SourceEverestPixelFont(string face, IEverestPixelFontProcess process) : base(face, process)
        {
            this.process = process;
        }

        public override SourcePixelFontSize AddFontSize(string path, AtlasData atlas = null, bool outline = false)
        {
            path = ContentFilePath.Normalize(path);
            process.Logger.VerbosePixelFontLoading(path);
            SourcePixelFontSize fontSize = null;
            if (File.Exists(path))
            {
                process.Logger.VerbosePixelFontVanilla();
                var data = SourceXmlDocumentLoader.Load(path)["font"];
                fontSize = AddFontSize(path, data, atlas, outline);
                Sizes.Remove(fontSize);
            }

            var modPath = EverestFileProxyPath.Modize(path, process.SourceContentRegistry);
            foreach (var asset in from mod in process.SourceContentRegistry.Mods
                     select mod.Map
                     into map
                     where map.ContainsKey(modPath)
                     select map[modPath])
            {
                process.Logger.VerbosePixelFontMod(asset);
                var data = loadXMLFromModAsset(asset)["font"];
                var newSize = AddFontSize(path, data, atlas, outline);
                Sizes.Remove(newSize);
                fontSize = mergeFonts(fontSize, newSize);
            }

            Sizes.Add(fontSize);
            Sizes.Sort((a, b) => Math.Sign(a.Size - b.Size));
            return fontSize;
        }

        private XmlDocument loadXMLFromModAsset(EverestContentAsset asset)
        {
            var document = new XmlDocument();
            using var stream = asset.Stream;
            document.Load(stream);
            return document;
        }

        private SourcePixelFontSize mergeFonts(SourcePixelFontSize originalSize, SourcePixelFontSize newSize)
        {
            if (originalSize == null) return newSize;
            var imported = 0;
            foreach (var key in newSize.Characters.Keys)
                if (!originalSize.Characters.ContainsKey(key))
                {
                    originalSize.Characters[key] = newSize.Characters[key];
                    imported = unchecked(imported + 1);
                }

            originalSize.Textures.AddRange(newSize.Textures);
            process.Logger.VerbosePixelFontImported(imported);
            return originalSize;
        }
    }
}
