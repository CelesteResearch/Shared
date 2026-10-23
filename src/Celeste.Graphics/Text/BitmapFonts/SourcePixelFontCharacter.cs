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
    public class SourcePixelFontCharacter
    {
        public int Character;

        public AtlasEntry Texture;

        public int XOffset;

        public int YOffset;

        public int XAdvance;

        public Dictionary<int, int> Kerning = new Dictionary<int, int>();

        public SourcePixelFontCharacter(int character, AtlasEntry texture, XmlElement xml)
        {
            Character = character;
            Texture = texture.GetSubtexture(xml.AttrInt("x"), xml.AttrInt("y"), xml.AttrInt("width"),
                xml.AttrInt("height"));
            XOffset = xml.AttrInt("xoffset");
            YOffset = xml.AttrInt("yoffset");
            XAdvance = xml.AttrInt("xadvance");
        }
    }
}
