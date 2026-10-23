using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Graphics.Text
{
    // Original BMFont metrics and glyph pages. This covers ActiveFont's plain
    // text path used by BirdTutorialGui; rich text and stroke effects are separate.
    public sealed class BitmapFontPresentation(float baseSize = 64) : IDisposable
    {
        public sealed class Glyph
        {
            public AtlasEntry Texture;
            public int XOffset, YOffset, XAdvance;
            public readonly Dictionary<int, int> Kerning = new();
        }

        public sealed class FontSize
        {
            private readonly StringBuilder temp = new();

            public string AutoNewline(string text, int width)
            {
                if (string.IsNullOrEmpty(text))
                    return text;
                temp.Clear();
                var array = Regex.Split(text, "(\\s)");
                var num = 0f;
                var array2 = array;
                foreach (var text2 in array2)
                {
                    var x = Measure(text2).X;
                    if (x + num > width)
                    {
                        temp.Append('\n');
                        num = 0f;
                        if (text2.Equals(" "))
                            continue;
                    }

                    if (x > width)
                    {
                        var j = 1;
                        var num2 = 0;
                        for (; j < text2.Length; j++)
                            if (j - num2 > 1 && Measure(text2.Substring(num2, j - num2 - 1)).X > width)
                            {
                                temp.Append(text2.Substring(num2, j - num2 - 1));
                                temp.Append('\n');
                                num2 = j - 1;
                            }

                        var text3 = text2.Substring(num2, text2.Length - num2);
                        temp.Append(text3);
                        num += Measure(text3).X;
                    }
                    else
                    {
                        num += x;
                        temp.Append(text2);
                    }
                }

                return temp.ToString();
            }

            public float Size;
            public bool Outline;
            public List<AtlasEntry> Textures;

            public int LineHeight;

            // The `.fnt`'s `<common base="...">`: the ascent from the block's top to the glyphs' common
            // baseline. Monocle's own `PixelFontSize` does NOT keep it -- the CelesteTAS reference has to
            // add it back with an ILHook (`R:EverestInterop/CommonBaselineFont.cs:23-31` stores
            // `data["common"].AttrInt("base")` into a dynamic field) precisely because it is missing from
            // the type. The port parses the `.fnt` itself, so it can simply keep the value.
            //
            // IT IS NOT `LineHeight`. Measured across every font this port ships, `base` is always
            // smaller: `renogare64` is `lineHeight=64 base=48`, `chinese`/`japanese`/`korean`/`russian`
            // are `64/51`, `renogare192` is `193/145`, and the CelesteTAS HUD face is `32/26`. Code that
            // uses `LineHeight` as the baseline therefore draws text too LOW by that difference -- 16px
            // for the HUD face the room uses.
            public int Baseline;
            public readonly Dictionary<int, Glyph> Characters = new();

            public Glyph Get(int character)
            {
                return Characters.TryGetValue(character, out var glyph) ? glyph : null;
            }

            public float WidthToNextLine(string text, int start)
            {
                float width = 0;
                for (var i = start; i < text.Length && text[i] != '\n'; i++)
                    if (Characters.TryGetValue(text[i], out var glyph))
                    {
                        width += glyph.XAdvance;
                        if (i < text.Length - 1 && glyph.Kerning.TryGetValue(text[i + 1], out var amount))
                            width += amount;
                    }

                return width;
            }

            public float HeightOf(string text)
            {
                if (string.IsNullOrEmpty(text))
                    return 0;
                var lines = 1;
                foreach (var c in text)
                    if (c == '\n')
                        lines++;
                return lines * LineHeight;
            }

            public Vector2 Measure(char text)
            {
                return Characters.TryGetValue(text, out var glyph) ? new(glyph.XAdvance, LineHeight) : Vector2.Zero;
            }

            public Vector2 Measure(string text)
            {
                if (string.IsNullOrEmpty(text))
                    return Vector2.Zero;
                var result = new Vector2(0, LineHeight);
                float width = 0;
                for (var i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\n')
                    {
                        result.Y += LineHeight;
                        if (width > result.X)
                            result.X = width;
                        width = 0;
                        continue;
                    }

                    if (Characters.TryGetValue(text[i], out var glyph))
                    {
                        width += glyph.XAdvance;
                        if (i < text.Length - 1 && glyph.Kerning.TryGetValue(text[i + 1], out var amount))
                            width += amount;
                    }
                }

                if (width > result.X)
                    result.X = width;
                return result;
            }
        }

        private readonly List<FontSize> sizes = [];
        private readonly List<VirtualTexture> managedTextures = [];
        public float BaseSize = baseSize;

        public float LineHeight => Get(BaseSize).LineHeight;

        // The `<common base="...">` of the size this presentation is configured at. Distinct from
        // `LineHeight`; see `FontSize.Baseline` for why (and for the measured values).
        public float Baseline => Get(BaseSize).Baseline;

        public void AddFontSize(string fntPath, Func<string, AtlasEntry> resolvePage, bool outline = false)
        {
            fntPath = ContentFilePath.Normalize(fntPath);
            var xml = new XmlDocument();
            xml.Load(fntPath);
            var font = xml["font"];
            var size = float.Parse(font["info"].GetAttribute("size"), CultureInfo.InvariantCulture);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (sizes.Exists(s => s.Size == size))
                return;
            var pages = new List<AtlasEntry>();
            foreach (XmlElement page in font["pages"])
                pages.Add(resolvePage(Path.Combine(Path.GetDirectoryName(fntPath),
                    ContentFilePath.Normalize(page.GetAttribute("file")))));
            var result = new FontSize
            {
                Textures = pages,
                Size = size,
                LineHeight = Int(font["common"], "lineHeight"),
                Baseline = Int(font["common"], "base"),
                Outline = outline,
            };
            foreach (XmlElement character in font["chars"])
                result.Characters.Add(Int(character, "id"),
                    new()
                    {
                        Texture = pages[Int(character, "page")].GetSubtexture(Int(character, "x"), Int(character, "y"),
                            Int(character, "width"), Int(character, "height")),
                        XOffset = Int(character, "xoffset"), YOffset = Int(character, "yoffset"),
                        XAdvance = Int(character, "xadvance"),
                    });
            if (font["kernings"] != null)
                foreach (XmlElement kerning in font["kernings"])
                    if (result.Characters.TryGetValue(Int(kerning, "first"), out var glyph))
                        glyph.Kerning.Add(Int(kerning, "second"), Int(kerning, "amount"));
            sizes.Add(result);
            sizes.Sort((a, b) => Math.Sign(a.Size - b.Size));
        }

        public Vector2 Measure(string text)
        {
            return Get(BaseSize).Measure(text);
        }

        public void AddManagedTexture(VirtualTexture texture)
        {
            managedTextures.Add(texture);
        }

        public void Dispose()
        {
            foreach (var managedTexture in managedTextures)
                managedTexture.Dispose();
            managedTextures.Clear();
        }

        public FontSize Get(float requested)
        {
            if (sizes.Count == 0)
                throw new InvalidOperationException("No original bitmap font sizes have been loaded.");
            for (var i = 0; i < sizes.Count - 1; i++)
                if (sizes[i].Size >= requested)
                    return sizes[i];
            return sizes[sizes.Count - 1];
        }

        private static int Int(XmlElement element, string name)
        {
            return element.HasAttribute(name) ? int.Parse(element.GetAttribute(name), CultureInfo.InvariantCulture) : 0;
        }
    }
}
