using Celeste.Core.Display;
using Celeste.Core.IO.Content;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using Celeste.Core.Rendering;
using Celeste.Core.Serialization.Xml;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Graphics.Text.BitmapFonts
{
    public class SourcePixelFont
    {
        private readonly ISourcePixelFontProcess engine;

        public string Face;

        public List<SourcePixelFontSize> Sizes = new List<SourcePixelFontSize>();

        private List<VirtualTexture> managedTextures = new List<VirtualTexture>();

        public SourcePixelFont(string face, ISourcePixelFontProcess engine)
        {
            this.engine = engine;
            Face = face;
        }

        public virtual SourcePixelFontSize AddFontSize(string path, AtlasData atlas = null, bool outline = false)
        {
            path = ContentFilePath.Normalize(path);
            XmlElement data = (engine.XmlDocumentLoading is OriginalXmlDocumentLoadingPolicy policy
                ? policy.Load(path)
                : SourceXmlDocumentLoader.Load(path))["font"];
            return AddFontSize(path, data, atlas, outline);
        }

        public SourcePixelFontSize AddFontSize(string path, XmlElement data, AtlasData atlas = null,
            bool outline = false)
        {
            path = ContentFilePath.Normalize(path);
            float num = data["info"].AttrFloat("size");
            foreach (SourcePixelFontSize size in Sizes)
            {
                if (size.Size == num)
                {
                    return size;
                }
            }

            List<AtlasEntry> list = new List<AtlasEntry>();
            foreach (XmlElement item in data["pages"])
            {
                string text = ContentFilePath.Normalize(item.Attr("file"));
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
                if (atlas != null && atlas.Has(fileNameWithoutExtension))
                {
                    list.Add(atlas[fileNameWithoutExtension]);
                    continue;
                }

                VirtualTexture virtualTexture = engine.VirtualContent.CreateTexture(
                    Path.Combine(Path.GetDirectoryName(path).Substring(engine.ContentDirectory.Length + 1), text));
                list.Add(new AtlasEntry(virtualTexture));
                managedTextures.Add(virtualTexture);
            }

            SourcePixelFontSize pixelFontSize = new SourcePixelFontSize
            {
                Textures = list,
                Characters = new Dictionary<int, SourcePixelFontCharacter>(),
                LineHeight = data["common"].AttrInt("lineHeight"),
                Size = num,
                Outline = outline
            };
            foreach (XmlElement item2 in data["chars"])
            {
                int num2 = item2.AttrInt("id");
                int index = item2.AttrInt("page", 0);
                pixelFontSize.Characters.Add(num2, new SourcePixelFontCharacter(num2, list[index], item2));
            }

            if (data["kernings"] != null)
            {
                foreach (XmlElement item3 in data["kernings"])
                {
                    int key = item3.AttrInt("first");
                    int key2 = item3.AttrInt("second");
                    int value = item3.AttrInt("amount");
                    SourcePixelFontCharacter value2 = null;
                    if (pixelFontSize.Characters.TryGetValue(key, out value2))
                    {
                        value2.Kerning.Add(key2, value);
                    }
                }
            }

            Sizes.Add(pixelFontSize);
            Sizes.Sort((SourcePixelFontSize a, SourcePixelFontSize b) => Math.Sign(a.Size - b.Size));
            return pixelFontSize;
        }

        public SourcePixelFontSize Get(float size)
        {
            int i = 0;
            for (int num = Sizes.Count - 1; i < num; i++)
            {
                if (Sizes[i].Size >= size)
                {
                    return Sizes[i];
                }
            }

            return Sizes[Sizes.Count - 1];
        }

        public bool Has(float size)
        {
            int i = 0;
            for (int num = Sizes.Count - 1; i < num; i++)
            {
                if (Sizes[i].Size == size)
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw(ISourceRenderContext context, object actualEntity, float baseSize, char character,
            Vector2 position, Vector2 justify, Vector2 scale, PackedColor color)
        {
            SourcePixelFontSize pixelFontSize = Get(baseSize * engine.ExtremaArithmetic.Max(scale.X, scale.Y));
            scale *= baseSize / pixelFontSize.Size;
            pixelFontSize.Draw(context, actualEntity, character, position, justify, scale, color);
        }

        public void Draw(ISourceRenderContext context, object actualEntity, float baseSize, string text,
            Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color, float edgeDepth, PackedColor edgeColor, float stroke,
            PackedColor strokeColor)
        {
            SourcePixelFontSize pixelFontSize = Get(baseSize * engine.ExtremaArithmetic.Max(scale.X, scale.Y));
            scale *= baseSize / pixelFontSize.Size;
            pixelFontSize.Draw(context, actualEntity, text, position, justify, scale, color, edgeDepth, edgeColor,
                stroke,
                strokeColor);
        }

        public void Draw(ISourceRenderContext context, object actualEntity, float baseSize, string text,
            Vector2 position,
            PackedColor color)
        {
            Vector2 one = Vector2.One;
            SourcePixelFontSize pixelFontSize = Get(baseSize * engine.ExtremaArithmetic.Max(one.X, one.Y));
            one *= baseSize / pixelFontSize.Size;
            pixelFontSize.Draw(context, actualEntity, text, position, Vector2.Zero, Vector2.One, color, 0f,
                PackedColor.Transparent, 0f, PackedColor.Transparent);
        }

        public void Draw(ISourceRenderContext context, object actualEntity, float baseSize, string text,
            Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color)
        {
            SourcePixelFontSize pixelFontSize = Get(baseSize * engine.ExtremaArithmetic.Max(scale.X, scale.Y));
            scale *= baseSize / pixelFontSize.Size;
            pixelFontSize.Draw(context, actualEntity, text, position, justify, scale, color, 0f,
                PackedColor.Transparent,
                0f, PackedColor.Transparent);
        }

        public void DrawOutline(ISourceRenderContext context, object actualEntity, float baseSize, string text,
            Vector2 position, Vector2 justify, Vector2 scale, PackedColor color, float stroke, PackedColor strokeColor)
        {
            SourcePixelFontSize pixelFontSize = Get(baseSize * engine.ExtremaArithmetic.Max(scale.X, scale.Y));
            scale *= baseSize / pixelFontSize.Size;
            pixelFontSize.Draw(context, actualEntity, text, position, justify, scale, color, 0f,
                PackedColor.Transparent,
                stroke, strokeColor);
        }

        public void DrawEdgeOutline(ISourceRenderContext context, object actualEntity, float baseSize, string text,
            Vector2 position, Vector2 justify, Vector2 scale, PackedColor color, float edgeDepth, PackedColor edgeColor,
            float stroke = 0f, PackedColor strokeColor = default(PackedColor))
        {
            SourcePixelFontSize pixelFontSize = Get(baseSize * engine.ExtremaArithmetic.Max(scale.X, scale.Y));
            scale *= baseSize / pixelFontSize.Size;
            pixelFontSize.Draw(context, actualEntity, text, position, justify, scale, color, edgeDepth, edgeColor,
                stroke,
                strokeColor);
        }

        public void Dispose()
        {
            foreach (VirtualTexture managedTexture in managedTextures)
            {
                managedTexture.Dispose();
            }

            Sizes.Clear();
        }
    }
}
