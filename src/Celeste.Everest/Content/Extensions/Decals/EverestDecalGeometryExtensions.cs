using System;
using System.Numerics;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public static class EverestDecalGeometryExtensions
    {
        public static Vector2 GetScaledOffset(this SourceDecalEntityState decal, float x, float y)
            => new Vector2(x * decal.Scale.X, y * decal.Scale.Y);

        public static float GetScaledRadius(this SourceDecalEntityState decal, float radius)
            => radius * ((Math.Abs(decal.Scale.X) + Math.Abs(decal.Scale.Y)) / 2f);

        public static void ScaleRectangle(this SourceDecalEntityState decal, ref float x, ref float y,
            ref float width, ref float height)
        {
            Vector2 scale = decal.Scale;
            x *= Math.Abs(scale.X);
            y *= Math.Abs(scale.Y);
            width *= Math.Abs(scale.X);
            height *= Math.Abs(scale.Y);
            x = scale.X < 0f ? 0f - x - width : x;
            y = scale.Y < 0f ? 0f - y - height : y;
        }

        public static void ScaleRectangle(this SourceDecalEntityState decal, ref int x, ref int y, ref int width,
            ref int height)
        {
            Vector2 scale = decal.Scale;
            x = (int)(x * Math.Abs(scale.X));
            y = (int)(y * Math.Abs(scale.Y));
            width = (int)(width * Math.Abs(scale.X));
            height = (int)(height * Math.Abs(scale.Y));
            x = scale.X < 0f ? -x - width : x;
            y = scale.Y < 0f ? -y - height : y;
        }
    }
}
