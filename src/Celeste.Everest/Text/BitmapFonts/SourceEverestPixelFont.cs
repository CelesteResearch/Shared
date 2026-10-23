using System;
using System.IO;
using System.Linq;
using System.Xml;
using Celeste.Core.Serialization.Xml;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;

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
                XmlElement data = SourceXmlDocumentLoader.Load(path)["font"];
                fontSize = AddFontSize(path, data, atlas, outline);
                Sizes.Remove(fontSize);
            }

            string modPath = EverestFileProxyPath.Modize(path, process.SourceContentRegistry);
            foreach (EverestContentAsset asset in from mod in process.SourceContentRegistry.Mods
                     select mod.Map
                     into map
                     where map.ContainsKey(modPath)
                     select map[modPath])
            {
                process.Logger.VerbosePixelFontMod(asset);
                XmlElement data = loadXMLFromModAsset(asset)["font"];
                SourcePixelFontSize newSize = AddFontSize(path, data, atlas, outline);
                Sizes.Remove(newSize);
                fontSize = mergeFonts(fontSize, newSize);
            }

            Sizes.Add(fontSize);
            Sizes.Sort((SourcePixelFontSize a, SourcePixelFontSize b) => Math.Sign(a.Size - b.Size));
            return fontSize;
        }

        private XmlDocument loadXMLFromModAsset(EverestContentAsset asset)
        {
            XmlDocument document = new XmlDocument();
            using Stream stream = asset.Stream;
            document.Load(stream);
            return document;
        }

        private SourcePixelFontSize mergeFonts(SourcePixelFontSize originalSize, SourcePixelFontSize newSize)
        {
            if (originalSize == null) return newSize;
            int imported = 0;
            foreach (int key in newSize.Characters.Keys)
            {
                if (!originalSize.Characters.ContainsKey(key))
                {
                    originalSize.Characters[key] = newSize.Characters[key];
                    imported = unchecked(imported + 1);
                }
            }

            originalSize.Textures.AddRange(newSize.Textures);
            process.Logger.VerbosePixelFontImported(imported);
            return originalSize;
        }
    }
}
