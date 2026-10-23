using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display.Canvas
{
    public sealed class CanvasOverlayLayer : CanvasLayer
    {
        private readonly ICanvasOverlayRenderer owner;

        public CanvasOverlayLayer(ICanvasOverlayRenderer owner, CanvasOverlayLayerDefinition definition) : base(
            definition)
        {
            this.owner = owner;
        }

        public override void Render(Vector2 scroll, Action<CanvasDrawCommand> emit, bool mirror) =>
            owner.RenderOverlay(scroll);
    }
}
