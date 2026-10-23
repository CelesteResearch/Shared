using Celeste.Graphics.Rendering.Textures;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Rendering.Effects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
            get { return lineSpacing; }
            set { lineSpacing = value; }
        }

        public float Spacing
        {
            get { return spacing; }
            set { spacing = value; }
        }

        internal SourceSpriteFont(ISourceExtremaArithmetic arithmetic, SourceTexture2DResource texture,
            List<IntRect> glyphBounds, List<IntRect> cropping, List<char> characters, int lineSpacing, float spacing,
            List<Vector3> kerningData, char? defaultCharacter)
        {
            this.arithmetic = arithmetic;
            Characters = new ReadOnlyCollection<char>(characters.ToArray());
            DefaultCharacter = defaultCharacter;
            LineSpacing = lineSpacing;
            Spacing = spacing;
            textureValue = texture;
            glyphData = glyphBounds;
            croppingData = cropping;
            kerning = kerningData;
            characterMap = characters;
            characterIndexMap = new Dictionary<char, int>(characters.Count);
            for (int i = 0; i < characters.Count; i++)
            {
                characterIndexMap[characters[i]] = i;
            }
        }

        public Vector2 MeasureString(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (text.Length == 0)
            {
                return Vector2.Zero;
            }

            Vector2 zero = Vector2.Zero;
            float num = 0f;
            float num2 = LineSpacing;
            bool flag = true;
            foreach (char c in text)
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
                    {
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");
                    }

                    value = characterIndexMap[DefaultCharacter.Value];
                }

                Vector3 vector = kerning[value];
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
                int height = croppingData[value].Height;
                if ((float)height > num2)
                {
                    num2 = height;
                }
            }

            zero.X = arithmetic.Max(zero.X, num);
            zero.Y += num2;
            return zero;
        }

        public Vector2 MeasureString(StringBuilder text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (text.Length == 0)
            {
                return Vector2.Zero;
            }

            Vector2 zero = Vector2.Zero;
            float num = 0f;
            float num2 = LineSpacing;
            bool flag = true;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
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
                    {
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");
                    }

                    value = characterIndexMap[DefaultCharacter.Value];
                }

                Vector3 vector = kerning[value];
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
                int height = croppingData[value].Height;
                if ((float)height > num2)
                {
                    num2 = height;
                }
            }

            zero.X = arithmetic.Max(zero.X, num);
            zero.Y += num2;
            return zero;
        }
    }
}
