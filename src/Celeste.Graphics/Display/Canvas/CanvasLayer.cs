using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display.Canvas
{
    public abstract class CanvasLayer
    {
        public Vector2 Position, ScrollFactor;

        protected CanvasLayer(CanvasLayerDefinition definition)
        {
            Position = definition.Position;
            ScrollFactor = definition.ScrollFactor;
        }

        public virtual void Update(float dt)
        {
        }

        public Vector2 GetScrollPosition(Vector2 scroll)
        {
            var p = Position;
            if (ScrollFactor != Vector2.Zero)
            {
                p.X = Position.X + ((Position.X + scroll.X) - Position.X) * ScrollFactor.X;
                p.Y = Position.Y + ((Position.Y + scroll.Y) - Position.Y) * ScrollFactor.Y;
            }

            return p;
        }

        public abstract void Render(Vector2 scroll, Action<CanvasDrawCommand> emit, bool mirror);
    }
}
