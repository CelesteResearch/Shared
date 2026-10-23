using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;

namespace Celeste.Simulation.Presentation.PostProcessing.Displacement
{
    public sealed class DisplacementBurst
    {
        public AtlasEntry Texture;
        public SceneEntityState Follow;
        public Vector2 Position, Origin;
        public float Duration, Percent, ScaleFrom, ScaleTo = 1, AlphaFrom = 1, AlphaTo;
        public Func<float, float> ScaleEaser, AlphaEaser;
        public IntRect? WorldClipRect;
        public ColliderGeometry WorldClipCollider;
        public int WorldClipPadding;

        public DisplacementBurst(AtlasEntry texture, Vector2 position,
            Vector2 origin, float duration)
        {
            Texture = texture;
            Position = position;
            Origin = origin;
            Duration = duration;
        }

        public void Update(float dt)
        {
            Percent += dt / Duration;
        }

        public void Render(ISourceRenderContext context)
        {
            var position = Position;
            if (Follow != null) position += Follow.Position;
            var alpha = AlphaFrom + (AlphaTo - AlphaFrom) * (AlphaEaser == null ? Percent : AlphaEaser(Percent));
            var scale = ScaleFrom + (ScaleTo - ScaleFrom) * (ScaleEaser == null ? Percent : ScaleEaser(Percent));
            var origin = Origin;
            var clip = new IntRect(0, 0, Texture.FrameWidth, Texture.FrameHeight);
            if (WorldClipCollider != null) WorldClipRect = WorldClipCollider.Bounds;
            if (WorldClipRect.HasValue)
            {
                var bounds = WorldClipRect.Value;
                bounds.X -= 1 + WorldClipPadding;
                bounds.Y -= 1 + WorldClipPadding;
                bounds.Width += 1 + WorldClipPadding * 2;
                bounds.Height += 1 + WorldClipPadding * 2;
                var left = position.X - origin.X * scale;
                if (left < bounds.Left)
                {
                    var amount = (int)((bounds.Left - left) / scale);
                    origin.X -= amount;
                    clip.X = amount;
                    clip.Width -= amount;
                }

                var top = position.Y - origin.Y * scale;
                if (top < bounds.Top)
                {
                    var amount = (int)((bounds.Top - top) / scale);
                    origin.Y -= amount;
                    clip.Y = amount;
                    clip.Height -= amount;
                }

                // These use the origin already changed by left/top clipping.
                var right = position.X + (Texture.FrameWidth - origin.X) * scale;
                if (right > bounds.Right) clip.Width -= (int)((right - bounds.Right) / scale);
                var bottom = position.Y + (Texture.FrameHeight - origin.Y) * scale;
                if (bottom > bounds.Bottom) clip.Height -= (int)((bottom - bounds.Bottom) / scale);
            }

            SourceAtlasDrawing.Draw(context, null, Texture,
                position, origin, PackedColor.White * alpha,
                Vector2.One * scale, 0f, clip);
        }
    }
}
