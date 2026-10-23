using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Hazards.Rendering
{
    public class StaticHazardBorderState : SceneEntityState
    {
        private readonly SceneEntityState parent;
        private readonly SceneEntityState filler;
        private readonly PackedColor color;

        public StaticHazardBorderState(SceneEntityState parent, SceneEntityState filler,
            ISourceEngineContext engine, PackedColor color)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.parent = parent;
            this.filler = filler;
            this.color = color;
            Depth = parent.Depth + 2;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!parent.Visible) return;
            DrawImages(parent, context, color);
            DrawImages(filler, context, color);
        }

        public static void DrawImages(SceneEntityState entity, ISourceRenderContext context, PackedColor color)
        {
            if (entity == null) return;
            foreach (var component in entity.Components)
            {
                if (component is not SpriteImage image) continue;
                var originalColor = image.Color;
                var originalPosition = image.Position;
                image.Color = color;
                image.Position = originalPosition + new Vector2(0f, -1f);
                image.Render(context);
                image.Position = originalPosition + new Vector2(0f, 1f);
                image.Render(context);
                image.Position = originalPosition + new Vector2(-1f, 0f);
                image.Render(context);
                image.Position = originalPosition + new Vector2(1f, 0f);
                image.Render(context);
                image.Color = originalColor;
                image.Position = originalPosition;
            }
        }
    }
}
