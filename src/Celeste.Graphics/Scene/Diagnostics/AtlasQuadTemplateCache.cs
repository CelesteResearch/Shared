using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Scene.Diagnostics
{
    internal sealed class AtlasQuadTemplateCache
    {
        private sealed class EntryReferenceComparer : IEqualityComparer<AtlasEntry>
        {
            public bool Equals(AtlasEntry a, AtlasEntry b) => ReferenceEquals(a, b);
            public int GetHashCode(AtlasEntry entry) => RuntimeHelpers.GetHashCode(entry);
        }

        private sealed class Template
        {
            internal SourceTexture2DResource Texture;
            internal int X, Y, Width, Height, TextureWidth, TextureHeight;
            internal int OffsetX, OffsetY, Scale;
            internal uint Color;
            internal SourceSpriteQuad Basis;
        }

        private readonly Dictionary<AtlasEntry, Template> entries = new(new EntryReferenceComparer());

        internal void Clear() => entries.Clear();

        internal SourceSpriteQuad Create(AtlasEntry entry, SourceTexture2DResource texture, Vector2 position,
            PackedColor color)
        {
            // Read the live getter even on a hit, before observing the fields it may change.
            float scale = entry.SourceDrawScale;
            float offsetX = entry.OffsetX, offsetY = entry.OffsetY;
            int x = entry.X, y = entry.Y, width = entry.Width, height = entry.Height;
            int textureWidth = texture.Width, textureHeight = texture.Height;
            int offsetXBits = BitConverter.SingleToInt32Bits(offsetX);
            int offsetYBits = BitConverter.SingleToInt32Bits(offsetY);
            int scaleBits = BitConverter.SingleToInt32Bits(scale);
            if (!entries.TryGetValue(entry, out var template) || !ReferenceEquals(template.Texture, texture) ||
                template.X != x || template.Y != y || template.Width != width || template.Height != height ||
                template.TextureWidth != textureWidth || template.TextureHeight != textureHeight ||
                template.OffsetX != offsetXBits || template.OffsetY != offsetYBits ||
                template.Scale != scaleBits || template.Color != color.PackedValue)
            {
                var origin = (Vector2.Zero - new Vector2(offsetX, offsetY)) / scale;
                float sx = (float)x / textureWidth, sy = (float)y / textureHeight;
                float sw = (float)Math.Sign(width) * Math.Max(Math.Abs(width), 5.9604645e-8f) / textureWidth;
                float sh = (float)Math.Sign(height) * Math.Max(Math.Abs(height), 5.9604645e-8f) / textureHeight;
                var basis = new SourceSpriteQuad();
                // Adding negative zero preserves the sign of each untranslated coordinate.
                float negativeZero = BitConverter.Int32BitsToSingle(unchecked((int)0x80000000));
                SourceSpriteGeometry.Generate(ref basis, sx, sy, sw, sh, negativeZero, negativeZero,
                    scale * width, scale * height, color.PackedValue,
                    origin.X / sw / textureWidth, origin.Y / sh / textureHeight, 0f, 1f, 0f, 0);
                template = new Template
                {
                    Texture = texture, X = x, Y = y, Width = width, Height = height,
                    TextureWidth = textureWidth, TextureHeight = textureHeight,
                    OffsetX = offsetXBits, OffsetY = offsetYBits, Scale = scaleBits,
                    Color = color.PackedValue, Basis = basis
                };
                entries[entry] = template;
            }

            var quad = template.Basis;
            quad.Position0.X += position.X;
            quad.Position0.Y += position.Y;
            quad.Position1.X += position.X;
            quad.Position1.Y += position.Y;
            quad.Position2.X += position.X;
            quad.Position2.Y += position.Y;
            quad.Position3.X += position.X;
            quad.Position3.Y += position.Y;
            return quad;
        }
    }
}
