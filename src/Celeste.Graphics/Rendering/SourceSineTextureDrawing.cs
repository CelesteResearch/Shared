using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Graphics.Rendering
{
    public static class SourceSineTextureDrawing
    {
        public static void Horizontal(ISourceDrawScope scope, AtlasEntry texture, Vector2 position, Vector2 origin,
            Vector2 scale, float rotation, PackedColor color, SourceSpriteEffects effects, float sineCounter,
            float amplitude = 2f, int sliceSize = 2, float sliceAdd = (float)Math.PI / 4f)
        {
            position = new Vector2((float)Math.Floor(position.X), (float)Math.Floor(position.Y));
            var clip = texture.ClipRect;
            clip.Width = sliceSize;
            var index = 0;
            while (clip.X < texture.ClipRect.X + texture.ClipRect.Width)
            {
                var displacement = new Vector2(sliceSize * index,
                    (float)Math.Round(Math.Sin(sineCounter + sliceAdd * index) * amplitude));
                scope.Draw.SpriteBatch.Draw(texture.ReadTextureForSpriteBatch(), position, clip, color.PackedValue,
                    rotation, origin - displacement, scale, effects, 0f);
                index++;
                clip.X += sliceSize;
                clip.Width = Math.Min(sliceSize, texture.ClipRect.X + texture.ClipRect.Width - clip.X);
            }
        }
    }
}
