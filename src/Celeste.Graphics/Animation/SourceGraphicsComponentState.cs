using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Animation
{
    public abstract class SourceGraphicsComponentState(bool active) : SourceComponentState(active, true)
    {
        public Vector2 Position, Origin;

        public float X
        {
            get => Position.X;
            set => Position.X = value;
        }

        public float Y
        {
            get => Position.Y;
            set => Position.Y = value;
        }

        public Vector2 Scale = Vector2.One;
        public PackedColor Color = PackedColor.White;
        public float Rotation;
        public SourceSpriteEffects Effects;

        public bool FlipX
        {
            get => (Effects & SourceSpriteEffects.FlipHorizontally) == SourceSpriteEffects.FlipHorizontally;
            set => Effects = value
                ? Effects | SourceSpriteEffects.FlipHorizontally
                : Effects & ~SourceSpriteEffects.FlipHorizontally;
        }

        public bool FlipY
        {
            get => (Effects & SourceSpriteEffects.FlipVertically) == SourceSpriteEffects.FlipVertically;
            set => Effects = value
                ? Effects | SourceSpriteEffects.FlipVertically
                : Effects & ~SourceSpriteEffects.FlipVertically;
        }

        // Original GraphicsComponent.RenderPosition reads the current actual Entity.
        public Vector2 RenderPosition
        {
            get => (Entity == null ? Vector2.Zero : ((ISourceEntityPosition)Entity).Position) + Position;
            set => Position = value - (Entity == null ? Vector2.Zero : ((ISourceEntityPosition)Entity).Position);
        }

        public void DrawOutline(ISourceRenderContext context, int offset = 1)
        {
            DrawOutline(context, PackedColor.Black, offset);
        }

        public void DrawOutline(ISourceRenderContext context, PackedColor color, int offset = 1)
        {
            var position = Position;
            var previousColor = Color;
            Color = color;
            for (var i = -1; i < 2; i++)
            for (var j = -1; j < 2; j++)
                if (i != 0 || j != 0)
                {
                    Position = position + new Vector2(i * offset, j * offset);
                    Render(context);
                }

            Position = position;
            Color = previousColor;
        }

        public void DrawSimpleOutline(ISourceRenderContext context)
        {
            var position = Position;
            var color = Color;
            Color = PackedColor.Black;
            Position = position + new Vector2(-1f, 0f);
            Render(context);
            Position = position + new Vector2(0f, -1f);
            Render(context);
            Position = position + new Vector2(1f, 0f);
            Render(context);
            Position = position + new Vector2(0f, 1f);
            Render(context);
            Position = position;
            Color = color;
        }
    }
}
