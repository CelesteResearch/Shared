using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Animation
{
    public partial class Sprite
    {
        public void DrawSubrect(ISourceRenderContext context, Vector2 offset, IntRect rectangle,
            ISourceExtremaArithmetic arithmetic)
        {
            if (Texture != null)
            {
                IntRect relativeRect = Texture.GetRelativeRect(rectangle);
                Vector2 adjustment = new Vector2(
                    -arithmetic.Min((float)rectangle.X - Texture.DrawOffset.X, 0f),
                    -arithmetic.Min((float)rectangle.Y - Texture.DrawOffset.Y, 0f));
                ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                    Texture.ReadTextureForSpriteBatch(), RenderPosition + offset, relativeRect,
                    Color.PackedValue, Rotation, Origin - adjustment, Scale,
                    (FlipX ? global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipHorizontally : 0)
                    | (FlipY ? global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipVertically : 0), 0f);
            }
        }
    }
}
