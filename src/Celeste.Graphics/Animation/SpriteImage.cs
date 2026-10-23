using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;

namespace Celeste.Graphics.Animation
{
    public class SpriteImage : SourceGraphicsComponentState, ISourceComponentRender
    {
        public AtlasEntry Texture;

        public bool TEST;

        // Output belongs to the currently executing Engine batch, independent of Image.Entity.
        // Entity contributes only RenderPosition; detached and cross-Scene draws use this same context.
        public override void Render(ISourceRenderContext context)
        {
            if (Texture == null) return;
            SourceAtlasDrawing.Draw(context, Entity,
                Texture, RenderPosition, Origin, Color, Scale, Rotation, FlipX, FlipY);
        }

        public virtual float Width => Texture.FrameWidth;
        public virtual float Height => Texture.FrameHeight;

        public SpriteImage(AtlasEntry texture)
            : base(false)
        {
            Texture = texture;
        }

        internal SpriteImage(AtlasEntry texture, bool active)
            : base(active)
        {
            Texture = texture;
        }

        public SpriteImage SetColor(PackedColor color)
        {
            Color = color;
            return this;
        }

        public SpriteImage SetOrigin(float x, float y)
        {
            Origin = new(x, y);
            return this;
        }

        public SpriteImage CenterOrigin()
        {
            return SetOrigin(Width / 2f, Height / 2f);
        }

        public SpriteImage JustifyOrigin(Vector2 at)
        {
            return SetOrigin(Width * at.X, Height * at.Y);
        }

        public SpriteImage JustifyOrigin(float x, float y)
        {
            return JustifyOrigin(new(x, y));
        }
    }
}
