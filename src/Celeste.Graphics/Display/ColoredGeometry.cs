using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display
{
    public sealed class ColoredGeometry
    {
        public int Depth;
        public global::Celeste.Graphics.Display.ColoredVertex[] Vertices;

        public ColoredGeometry(int depth, global::Celeste.Graphics.Display.ColoredVertex[] vertices)
        {
            Depth = depth;
            Vertices = vertices;
        }
    }
}
