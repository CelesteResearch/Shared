using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Graphics.Scene.Diagnostics
{
    public static class CameraWorldBounds
    {
        public static Bounds Read(CameraState camera)
        {
            if (camera == null) throw new ArgumentNullException(nameof(camera));
            var inverse = camera.Inverse;
            var viewport = camera.Viewport;
            // Viewport X/Y locate the physical viewport; Camera.Matrix uses local pixels.
            var topLeft = SourceVector2Math.Transform(Vector2.Zero, inverse);
            var topRight = SourceVector2Math.Transform(new Vector2(viewport.Width, 0), inverse);
            var bottomLeft = SourceVector2Math.Transform(new Vector2(0, viewport.Height), inverse);
            var bottomRight = SourceVector2Math.Transform(new Vector2(viewport.Width, viewport.Height), inverse);
            float left = Math.Min(Math.Min(topLeft.X, topRight.X), Math.Min(bottomLeft.X, bottomRight.X));
            float top = Math.Min(Math.Min(topLeft.Y, topRight.Y), Math.Min(bottomLeft.Y, bottomRight.Y));
            float right = Math.Max(Math.Max(topLeft.X, topRight.X), Math.Max(bottomLeft.X, bottomRight.X));
            float bottom = Math.Max(Math.Max(topLeft.Y, topRight.Y), Math.Max(bottomLeft.Y, bottomRight.Y));
            return Bounds.FromEdges(left, top, right, bottom);
        }
    }
}
