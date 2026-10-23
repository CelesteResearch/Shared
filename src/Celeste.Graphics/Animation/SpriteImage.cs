using Celeste.Core.Display;
using System.Numerics;

namespace Celeste.Graphics.Animation
{
    public class SpriteImage : SourceGraphicsComponentState, global::Celeste.Core.Rendering.ISourceComponentRender
    {
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Texture;

        public bool TEST;

        // Output belongs to the currently executing Engine batch, independent of Image.Entity.
        // Entity contributes only RenderPosition; detached and cross-Scene draws use this same context.
        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            if (Texture == null) return;
            global::Celeste.Graphics.Rendering.SourceAtlasDrawing.Draw(context, Entity,
                Texture, RenderPosition, Origin, Color, Scale, Rotation, FlipX, FlipY);
        }

        public virtual float Width => Texture.FrameWidth;
        public virtual float Height => Texture.FrameHeight;

        public SpriteImage(global::Celeste.Graphics.Content.Atlas.AtlasEntry texture)
            : base(false)
        {
            Texture = texture;
        }

        internal SpriteImage(global::Celeste.Graphics.Content.Atlas.AtlasEntry texture, bool active)
            : base(active)
        {
            Texture = texture;
        }

        public SpriteImage SetColor(global::Celeste.Core.Display.PackedColor color)
        {
            Color = color;
            return this;
        }

        public global::Celeste.Graphics.Animation.SpriteImage SetOrigin(float x, float y)
        {
            Origin = new Vector2(x, y);
            return this;
        }

        public global::Celeste.Graphics.Animation.SpriteImage CenterOrigin() => SetOrigin(Width / 2f, Height / 2f);

        public global::Celeste.Graphics.Animation.SpriteImage JustifyOrigin(Vector2 at) =>
            SetOrigin(Width * at.X, Height * at.Y);

        public global::Celeste.Graphics.Animation.SpriteImage JustifyOrigin(float x, float y) =>
            JustifyOrigin(new Vector2(x, y));
    }
}
