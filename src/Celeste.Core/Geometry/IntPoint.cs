using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Core.Geometry
{
    /// <summary>XNA `Point` (Classic.room).</summary>
    public struct IntPoint
    {
        public int X, Y;
        public Vector2 ToVector2() => new Vector2(X, Y);

        public IntPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
