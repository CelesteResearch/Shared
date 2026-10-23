using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceSpriteFontReader : SourceContentTypeReader<SourceSpriteFont>
    {
        internal SourceSpriteFontReader()
        {
        }

        protected internal override SourceSpriteFont Read(SourceContentReader input, SourceSpriteFont existingInstance)
        {
            if (existingInstance != null)
            {
                input.ReadObject(existingInstance.textureValue);
                input.ReadObject<List<IntRect>>();
                input.ReadObject<List<IntRect>>();
                input.ReadObject<List<char>>();
                input.ReadInt32();
                input.ReadSingle();
                input.ReadObject<List<Vector3>>();
                if (input.ReadBoolean())
                {
                    input.ReadChar();
                }

                return existingInstance;
            }

            SourceTexture2DResource texture = input.ReadObject<SourceTexture2DResource>();
            List<IntRect> glyphBounds = input.ReadObject<List<IntRect>>();
            List<IntRect> cropping = input.ReadObject<List<IntRect>>();
            List<char> characters = input.ReadObject<List<char>>();
            int lineSpacing = input.ReadInt32();
            float spacing = input.ReadSingle();
            List<Vector3> kerningData = input.ReadObject<List<Vector3>>();
            char? defaultCharacter = null;
            if (input.ReadBoolean())
            {
                defaultCharacter = input.ReadChar();
            }

            return new SourceSpriteFont(input.ContentManager.Process.ExtremaArithmetic, texture, glyphBounds, cropping,
                characters, lineSpacing, spacing, kerningData, defaultCharacter);
        }
    }
}
