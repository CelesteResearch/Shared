using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Platforms.ZipMovers
{
    public static partial class ZipMoverDrawing
    {
        public static int CogFrameIndex(float rotation, int alternatingSign, float percent, int frameCount)
        {
            return (int)(Mod((rotation + alternatingSign * percent * (float)Math.PI * 4f) /
                             ((float)Math.PI / 2f), 1f) * frameCount);
        }

        public static AtlasEntry ClipInnerCog(AtlasEntry texture, int width, int height,
            bool left, bool right, bool top, bool bottom, AtlasEntry temporary, out Vector2 offset)
        {
            var rectangle = new IntRect(0, 0, width, height);
            offset = Vector2.Zero;
            if (left)
            {
                offset.X = 2f;
                rectangle.X = 2;
                rectangle.Width -= 2;
            }

            if (right)
            {
                offset.X = -2f;
                rectangle.Width -= 2;
            }

            if (top)
            {
                offset.Y = 2f;
                rectangle.Y = 2;
                rectangle.Height -= 2;
            }

            if (bottom)
            {
                offset.Y = -2f;
                rectangle.Height -= 2;
            }

            return texture.GetSubtexture(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, temporary);
        }
    }
}
