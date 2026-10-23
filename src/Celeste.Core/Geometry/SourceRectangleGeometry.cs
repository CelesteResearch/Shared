namespace Celeste.Core.Geometry
{
    public static class SourceRectangleGeometry
    {
        public static IntRect ClampTo(IntRect rect, IntRect clamp)
        {
            if (rect.X < clamp.X)
            {
                rect.Width -= clamp.X - rect.X;
                rect.X = clamp.X;
            }

            if (rect.Y < clamp.Y)
            {
                rect.Height -= clamp.Y - rect.Y;
                rect.Y = clamp.Y;
            }

            if (rect.Right > clamp.Right)
            {
                rect.Width = clamp.Right - rect.X;
            }

            if (rect.Bottom > clamp.Bottom)
            {
                rect.Height = clamp.Bottom - rect.Y;
            }

            return rect;
        }
    }
}
