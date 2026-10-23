using System;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public static class ClosingSolidResize
    {
        public static void SetHeight(SourceSolidEntityState solid, int height)
            => SetHeight(solid, height, null);

        public static void SetHeight(SourceSolidEntityState solid, int height, Action<int> move)
        {
            if ((float)height < solid.Collider.Height)
            {
                solid.Collider.Height = height;
                return;
            }

            float y = solid.Y;
            int num = (int)solid.Collider.Height;
            if (solid.Collider.Height < 64f)
            {
                solid.Y -= 64f - solid.Collider.Height;
                solid.Collider.Height = 64f;
            }

            if (move == null)
                solid.MoveVExact(height - num);
            else
                move(height - num);
            solid.Y = y;
            solid.Collider.Height = height;
        }

        public static void SetWidth(SourceSolidEntityState solid, int width)
        {
            if ((float)width < solid.Collider.Width)
            {
                solid.Collider.Width = width;
                return;
            }

            float x = solid.X;
            int num = (int)solid.Collider.Width;
            if (solid.Collider.Width < 64f)
            {
                solid.X -= 64f - solid.Collider.Width;
                solid.Collider.Width = 64f;
            }

            solid.MoveHExact(width - num);
            solid.X = x;
            solid.Collider.Width = width;
        }
    }
}
