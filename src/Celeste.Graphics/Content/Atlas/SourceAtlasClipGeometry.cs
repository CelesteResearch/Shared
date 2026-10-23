using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Atlas
{
    public static class SourceAtlasClipGeometry
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntRect RelativeRect(in IntRect sourceClip, Vector2 sourceOffset,
            int x, int y, int width, int height)
        {
            int right = sourceClip.X + sourceClip.Width, bottom = sourceClip.Y + sourceClip.Height;
            int px = sourceClip.X - (int)sourceOffset.X + x, py = sourceClip.Y - (int)sourceOffset.Y + y;
            int sx = Math.Max(sourceClip.X, Math.Min(px, right)), sy = Math.Max(sourceClip.Y, Math.Min(py, bottom));
            return new IntRect(sx, sy, Math.Max(0, Math.Min(px + width, right) - sx),
                Math.Max(0, Math.Min(py + height, bottom) - sy));
        }
    }
}
