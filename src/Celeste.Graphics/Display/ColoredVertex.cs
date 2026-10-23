using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display
{
    public struct ColoredVertex
    {
        public Vector3 Position;
        public Vector4 Color;

        public ColoredVertex(Vector2 position, Vector4 color)
        {
            Position = new Vector3(position, 0);
            Color = color;
        }
    }
}
