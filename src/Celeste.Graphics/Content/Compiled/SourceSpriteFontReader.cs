using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceSpriteFontReader : SourceContentTypeReader<SourceSpriteFont>
    {
        // ReSharper disable once EmptyConstructor
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
                if (input.ReadBoolean()) input.ReadChar();

                return existingInstance;
            }

            var texture = input.ReadObject<SourceTexture2DResource>();
            var glyphBounds = input.ReadObject<List<IntRect>>();
            var cropping = input.ReadObject<List<IntRect>>();
            var characters = input.ReadObject<List<char>>();
            var lineSpacing = input.ReadInt32();
            var spacing = input.ReadSingle();
            var kerningData = input.ReadObject<List<Vector3>>();
            char? defaultCharacter = null;
            if (input.ReadBoolean()) defaultCharacter = input.ReadChar();

            return new(input.ContentManager.Process.ExtremaArithmetic, texture, glyphBounds, cropping,
                characters, lineSpacing, spacing, kerningData, defaultCharacter);
        }
    }
}
