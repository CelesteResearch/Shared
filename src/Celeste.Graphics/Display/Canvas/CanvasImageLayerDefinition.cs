using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Display.Canvas
{
    public sealed class CanvasImageLayerDefinition : CanvasLayerDefinition
    {
        public readonly List<AtlasEntry> Images = [];

        public float FrameRate, Alpha, Scale;
        public Vector2 Speed;
    }
}
