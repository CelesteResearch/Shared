using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Text;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Text.Fonts
{
    public sealed class SourceSpriteFont
    {
        private readonly ISourceExtremaArithmetic arithmetic;
        internal SourceTexture2DResource textureValue;

        internal List<IntRect> glyphData;

        internal List<IntRect> croppingData;

        internal List<Vector3> kerning;

        internal List<char> characterMap;

        internal int lineSpacing;

        internal float spacing;

        internal Dictionary<char, int> characterIndexMap;

        public ReadOnlyCollection<char> Characters { get; private set; }

        public char? DefaultCharacter { get; set; }

        public int LineSpacing
        {
            get => lineSpacing;
            set => lineSpacing = value;
        }

        public float Spacing
        {
            get => spacing;
            set => spacing = value;
        }

        internal SourceSpriteFont(ISourceExtremaArithmetic arithmetic, SourceTexture2DResource texture,
            List<IntRect> glyphBounds, List<IntRect> cropping, List<char> characters, int lineSpacing, float spacing,
            List<Vector3> kerningData, char? defaultCharacter)
        {
            this.arithmetic = arithmetic;
            Characters = new((char[])[.. characters]);
            DefaultCharacter = defaultCharacter;
            LineSpacing = lineSpacing;
            Spacing = spacing;
            textureValue = texture;
            glyphData = glyphBounds;
            croppingData = cropping;
            kerning = kerningData;
            characterMap = characters;
            characterIndexMap = new(characters.Count);
            for (var i = 0; i < characters.Count; i++) characterIndexMap[characters[i]] = i;
        }

        public Vector2 MeasureString(string text)
        {
            if (text == null) throw new ArgumentNullException("text");

            if (text.Length == 0) return Vector2.Zero;

            var zero = Vector2.Zero;
            var num = 0f;
            float num2 = LineSpacing;
            var flag = true;
            foreach (var c in text)
            {
                switch (c)
                {
                    case '\n':
                        zero.X = arithmetic.Max(zero.X, num);
                        zero.Y += LineSpacing;
                        num = 0f;
                        num2 = LineSpacing;
                        flag = true;
                        continue;
                    case '\r':
                        continue;
                }

                if (!characterIndexMap.TryGetValue(c, out var value))
                {
                    if (!DefaultCharacter.HasValue)
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");

                    value = characterIndexMap[DefaultCharacter.Value];
                }

                var vector = kerning[value];
                if (flag)
                {
                    num += Math.Abs(vector.X);
                    flag = false;
                }
                else
                {
                    num += Spacing + vector.X;
                }

                num += vector.Y + vector.Z;
                var height = croppingData[value].Height;
                if (height > num2) num2 = height;
            }

            zero.X = arithmetic.Max(zero.X, num);
            zero.Y += num2;
            return zero;
        }

        public Vector2 MeasureString(StringBuilder text)
        {
            if (text == null) throw new ArgumentNullException("text");

            if (text.Length == 0) return Vector2.Zero;

            var zero = Vector2.Zero;
            var num = 0f;
            float num2 = LineSpacing;
            var flag = true;
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                switch (c)
                {
                    case '\n':
                        zero.X = arithmetic.Max(zero.X, num);
                        zero.Y += LineSpacing;
                        num = 0f;
                        num2 = LineSpacing;
                        flag = true;
                        continue;
                    case '\r':
                        continue;
                }

                if (!characterIndexMap.TryGetValue(c, out var value))
                {
                    if (!DefaultCharacter.HasValue)
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");

                    value = characterIndexMap[DefaultCharacter.Value];
                }

                var vector = kerning[value];
                if (flag)
                {
                    num += Math.Abs(vector.X);
                    flag = false;
                }
                else
                {
                    num += Spacing + vector.X;
                }

                num += vector.Y + vector.Z;
                var height = croppingData[value].Height;
                if (height > num2) num2 = height;
            }

            zero.X = arithmetic.Max(zero.X, num);
            zero.Y += num2;
            return zero;
        }
    }
}
