using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Backdrops.Weather.Snow;

namespace Celeste.Simulation.Presentation.Backdrops.Formation
{
    public sealed class FormationBackdropPresentation : SceneEntityState
    {
        public const int DefaultDepth = -1999900;
        private readonly ISourceEngineContext engine;
        public bool Display;
        public float Alpha = 1f;
        public bool WasDisplayed { get; private set; }
        public float Fade { get; private set; }

        public FormationBackdropPresentation(ISourceEngineContext engine, int frozenUpdateTag, int globalTag)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = frozenUpdateTag | globalTag;
            Depth = DefaultDepth;
        }

        public override void Update()
        {
            Fade = ScalarMath.Approach(Fade, Display ? 1 : 0, engine.RawDeltaTime * 3f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (Display) WasDisplayed = true;
            if (WasDisplayed)
            {
                var level = Scene as IFormationBackdropScene;
                var snow = level.Foreground.Get<SnowBackdropPresentation>();
                if (snow != null) snow.Alpha = 1f - Fade;
                var windSnow = level.Foreground.Get<WindSnowBackdropPresentation>();
                if (windSnow != null) windSnow.Alpha = 1f - Fade;
                if (Fade <= 0f) WasDisplayed = false;
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var level = Scene as IFormationBackdropScene;
            if (Fade > 0f)
            {
                var color = PackedColor.Black * Fade * Alpha * .85f;
                SourcePrimitiveDrawing.Rect(context, this, level.Camera.Left - 1f, level.Camera.Top - 1f, 322f, 182f,
                    color);
            }
        }
    }
}
