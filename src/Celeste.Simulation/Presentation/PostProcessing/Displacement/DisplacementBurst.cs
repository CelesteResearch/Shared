using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Presentation.PostProcessing.Displacement
{
    public sealed class DisplacementBurst
    {
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Texture;
        public global::Celeste.Scene.Entities.SceneEntityState Follow;
        public Vector2 Position, Origin;
        public float Duration, Percent, ScaleFrom, ScaleTo = 1, AlphaFrom = 1, AlphaTo;
        public Func<float, float> ScaleEaser, AlphaEaser;
        public global::Celeste.Core.Geometry.IntRect? WorldClipRect;
        public global::Celeste.Physics.Collision.Shapes.ColliderGeometry WorldClipCollider;
        public int WorldClipPadding;

        public DisplacementBurst(global::Celeste.Graphics.Content.Atlas.AtlasEntry texture, Vector2 position,
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

        public void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            Vector2 position = Position;
            if (Follow != null) position += Follow.Position;
            float alpha = AlphaFrom + (AlphaTo - AlphaFrom) * (AlphaEaser == null ? Percent : AlphaEaser(Percent));
            float scale = ScaleFrom + (ScaleTo - ScaleFrom) * (ScaleEaser == null ? Percent : ScaleEaser(Percent));
            Vector2 origin = Origin;
            var clip = new global::Celeste.Core.Geometry.IntRect(0, 0, Texture.FrameWidth, Texture.FrameHeight);
            if (WorldClipCollider != null) WorldClipRect = WorldClipCollider.Bounds;
            if (WorldClipRect.HasValue)
            {
                global::Celeste.Core.Geometry.IntRect bounds = WorldClipRect.Value;
                bounds.X -= 1 + WorldClipPadding;
                bounds.Y -= 1 + WorldClipPadding;
                bounds.Width += 1 + WorldClipPadding * 2;
                bounds.Height += 1 + WorldClipPadding * 2;
                float left = position.X - origin.X * scale;
                if (left < bounds.Left)
                {
                    int amount = (int)((bounds.Left - left) / scale);
                    origin.X -= amount;
                    clip.X = amount;
                    clip.Width -= amount;
                }

                float top = position.Y - origin.Y * scale;
                if (top < bounds.Top)
                {
                    int amount = (int)((bounds.Top - top) / scale);
                    origin.Y -= amount;
                    clip.Y = amount;
                    clip.Height -= amount;
                }

                // These use the origin already changed by left/top clipping.
                float right = position.X + (Texture.FrameWidth - origin.X) * scale;
                if (right > bounds.Right) clip.Width -= (int)((right - bounds.Right) / scale);
                float bottom = position.Y + (Texture.FrameHeight - origin.Y) * scale;
                if (bottom > bounds.Bottom) clip.Height -= (int)((bottom - bounds.Bottom) / scale);
            }

            global::Celeste.Graphics.Rendering.SourceAtlasDrawing.Draw(context, null, Texture,
                position, origin, global::Celeste.Core.Display.PackedColor.White * alpha,
                Vector2.One * scale, 0f, clip);
        }
    }
}
