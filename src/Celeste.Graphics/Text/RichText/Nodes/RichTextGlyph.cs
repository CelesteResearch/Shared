using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Graphics.Text.RichText.Drawing;

namespace Celeste.Graphics.Text.RichText.Nodes
{
    public class RichTextGlyph : RichTextNode
    {
        public int Index;

        public int Character;

        public float Position;

        public int Line;

        public int Page;

        public float Delay;

        public float LineWidth;

        public PackedColor Color;

        public float Scale;

        public float Rotation;

        public float YOffset;

        public float Fade;

        public bool Shake;

        public bool Wave;

        public bool Impact;

        public bool IsPunctuation;

        public void Draw(ISourceRenderContext context, object actualEntity, ISourceRichTextDrawProcess engine,
            SourcePixelFont font, float baseSize, Vector2 position, Vector2 scale, float alpha)
        {
            var num = (Impact ? 2f - Fade : 1f) * Scale;
            var zero = Vector2.Zero;
            var vector = scale * num;
            var pixelFontSize = font.Get(baseSize * engine.ExtremaArithmetic.Max(vector.X, vector.Y));
            var pixelFontCharacter = pixelFontSize.Get(Character);
            vector *= baseSize / pixelFontSize.Size;
            position.X += Position * scale.X;
            zero += Shake ? new Vector2(-1 + engine.Random.Next(3), -1 + engine.Random.Next(3)) * 2f : Vector2.Zero;
            zero += Wave
                ? new(0f, (float)Math.Sin(Index * 0.25f + engine.RawTimeActive * 8f) * 4f)
                : Vector2.Zero;
            zero.X += pixelFontCharacter.XOffset;
            zero.Y += pixelFontCharacter.YOffset + (-8f * (1f - Fade) + YOffset * Fade);
            SourceAtlasDrawing.Draw(context, actualEntity, pixelFontCharacter.Texture, position + zero * vector,
                Vector2.Zero, Color * Fade * alpha, vector, Rotation);
        }
    }
}
