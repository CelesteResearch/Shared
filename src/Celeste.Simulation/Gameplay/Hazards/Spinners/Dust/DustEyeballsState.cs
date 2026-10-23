using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public class DustEyeballsState : SceneEntityState
    {
        public DustGraphicState Dust;
        public global::Celeste.Core.Display.PackedColor Color;

        public DustEyeballsState(DustGraphicState dust)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)dust.EngineContext)
                .EntitySourceDataRegistration)
        {
            Dust = dust;
            Depth = Dust.Parent.Depth - 1;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Color = Dust.StyleProvider.GetStyle(((IDustGraphicScene)scene).DustAreaID).EyeColor;
        }

        public override void Update()
        {
            base.Update();
            if (Dust.Entity == null || Dust.Scene == null) RemoveSelf();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!Dust.StyleProvider.ShouldRenderEyes) return;
            if (Dust.Visible && Dust.Parent.Visible)
            {
                Vector2 perpendicular = Dust.Normalize(new Vector2(0f - Dust.EyeDirection.Y, Dust.EyeDirection.X));
                if (Dust.LeftEyeVisible)
                    Dust.DrawSourceCentered(context, this, Dust.EyeTexture,
                        Dust.RenderPosition + (Dust.EyeDirection * 5f + perpendicular * 3f) * Dust.Scale, Color);
                if (Dust.RightEyeVisible)
                    Dust.DrawSourceCentered(context, this, Dust.EyeTexture,
                        Dust.RenderPosition + (Dust.EyeDirection * 5f - perpendicular * 3f) * Dust.Scale, Color);
            }
        }
    }
}
