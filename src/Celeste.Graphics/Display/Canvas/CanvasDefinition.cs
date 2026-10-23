using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display.Canvas
{
    public sealed class CanvasDefinition
    {
        public Vector2 StartScroll, CenterScroll, Offset;
        public readonly List<CanvasLayerDefinition> Layers = new List<CanvasLayerDefinition>();
    }
}
