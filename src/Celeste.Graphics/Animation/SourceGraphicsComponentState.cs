using Celeste.Core.Display;
using System.Numerics;

namespace Celeste.Graphics.Animation
{
    public abstract class SourceGraphicsComponentState : global::Celeste.Core.Components.SourceComponentState
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

        public global::Celeste.Core.Display.PackedColor Color = global::Celeste.Core.Display.PackedColor
            .White;

        public float Rotation;
        public global::Celeste.Core.Rendering.States.SourceSpriteEffects Effects;

        public bool FlipX
        {
            get => (Effects & global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipHorizontally)
                   == global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipHorizontally;
            set => Effects = value
                ? Effects | global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipHorizontally
                : Effects & ~global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipHorizontally;
        }

        public bool FlipY
        {
            get => (Effects & global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipVertically)
                   == global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipVertically;
            set => Effects = value
                ? Effects | global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipVertically
                : Effects & ~global::Celeste.Core.Rendering.States.SourceSpriteEffects.FlipVertically;
        }

        // Original GraphicsComponent.RenderPosition reads the current actual Entity.
        public Vector2 RenderPosition
        {
            get => (Entity == null
                ? Vector2.Zero
                : ((global::Celeste.Core.Components.ISourceEntityPosition)Entity).Position) + Position;
            set => Position = value - (Entity == null
                ? Vector2.Zero
                : ((global::Celeste.Core.Components.ISourceEntityPosition)Entity).Position);
        }

        protected SourceGraphicsComponentState(bool active) : base(active, true)
        {
        }

        public void DrawOutline(global::Celeste.Core.Rendering.ISourceRenderContext context, int offset = 1)
            => DrawOutline(context, global::Celeste.Core.Display.PackedColor.Black, offset);

        public void DrawOutline(global::Celeste.Core.Rendering.ISourceRenderContext context,
            global::Celeste.Core.Display.PackedColor color, int offset = 1)
        {
            Vector2 position = Position;
            global::Celeste.Core.Display.PackedColor previousColor = Color;
            Color = color;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        Position = position + new Vector2(i * offset, j * offset);
                        Render(context);
                    }
                }
            }

            Position = position;
            Color = previousColor;
        }

        public void DrawSimpleOutline(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            Vector2 position = Position;
            global::Celeste.Core.Display.PackedColor color = Color;
            Color = global::Celeste.Core.Display.PackedColor.Black;
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
