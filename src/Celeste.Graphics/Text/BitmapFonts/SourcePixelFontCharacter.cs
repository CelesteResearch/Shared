using System.Collections.Generic;
using System.Xml;
using Celeste.Core.Serialization.Xml;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Text.BitmapFonts
{
    public class SourcePixelFontCharacter
    {
        public int Character;
        public AtlasEntry Texture;
        public int XOffset;
        public int YOffset;
        public int XAdvance;
        public Dictionary<int, int> Kerning = new();

        // ReSharper disable once ConvertToPrimaryConstructor
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
