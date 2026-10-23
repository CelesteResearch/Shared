using System;

namespace Celeste.Graphics.Geometry.Tiling
{
    public static class ConnectedBlockAutotiling
    {
        public static void Build(float left, float right, float top, float bottom, Func<float, float, bool> check,
            Action<float, float, int, int> add)
        {
            Build(new FixedBounds(left, right, top, bottom), check, add);
        }

        public static void Build<TBounds>(TBounds bounds, Func<float, float, bool> check,
            Action<float, float, int, int> add)
            where TBounds : struct, IConnectedBlockBounds
        {
            for (var x = bounds.Left; x < bounds.Right; x += 8f)
            for (var y = bounds.Top; y < bounds.Bottom; y += 8f)
            {
                bool l = check(x - 8f, y), r = check(x + 8f, y), t = check(x, y - 8f), b = check(x, y + 8f);
                if (l && r && t && b)
                {
                    if (!check(x + 8f, y - 8f))
                        add(x, y, 3, 0);
                    else if (!check(x - 8f, y - 8f))
                        add(x, y, 3, 1);
                    else if (!check(x + 8f, y + 8f))
                        add(x, y, 3, 2);
                    else if (!check(x - 8f, y + 8f))
                        add(x, y, 3, 3);
                    else
                        add(x, y, 1, 1);
                }
                else if (l && r && !t && b)
                {
                    add(x, y, 1, 0);
                }
                else if (l && r && t && !b)
                {
                    add(x, y, 1, 2);
                }
                else if (l && !r && t && b)
                {
                    add(x, y, 2, 1);
                }
                else if (!l && r && t && b)
                {
                    add(x, y, 0, 1);
                }
                else if (l && !r && !t && b)
                {
                    add(x, y, 2, 0);
                }
                else if (!l && r && !t && b)
                {
                    add(x, y, 0, 0);
                }
                else if (l && !r && t && !b)
                {
                    add(x, y, 2, 2);
                }
                else if (!l && r && t && !b)
                {
                    add(x, y, 0, 2);
                }
            }
        }

        private readonly struct FixedBounds(float left, float right, float top, float bottom) : IConnectedBlockBounds
        {
            public float Left { get; } = left;
            public float Right { get; } = right;
            public float Top { get; } = top;
            public float Bottom { get; } = bottom;
        }
    }
}
