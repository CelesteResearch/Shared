using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display.Canvas
{
    public sealed class CanvasImageLayerDefinition : CanvasLayerDefinition
    {
        public readonly List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> Images =
            new List<global::Celeste.Graphics.Content.Atlas.AtlasEntry>();

        public float FrameRate, Alpha, Scale;
        public Vector2 Speed;
    }
}
