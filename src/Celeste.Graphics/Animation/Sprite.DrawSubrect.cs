using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Graphics.Animation
{
    public partial class Sprite
    {
        public void DrawSubrect(ISourceRenderContext context, Vector2 offset, IntRect rectangle,
            ISourceExtremaArithmetic arithmetic)
        {
            if (Texture != null)
            {
                var relativeRect = Texture.GetRelativeRect(rectangle);
                var adjustment = new Vector2(
                    -arithmetic.Min(rectangle.X - Texture.DrawOffset.X, 0f),
                    -arithmetic.Min(rectangle.Y - Texture.DrawOffset.Y, 0f));
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                    Texture.ReadTextureForSpriteBatch(), RenderPosition + offset, relativeRect,
                    Color.PackedValue, Rotation, Origin - adjustment, Scale,
                    (FlipX ? SourceSpriteEffects.FlipHorizontally : 0)
                    | (FlipY ? SourceSpriteEffects.FlipVertically : 0), 0f);
            }
        }
    }
}
