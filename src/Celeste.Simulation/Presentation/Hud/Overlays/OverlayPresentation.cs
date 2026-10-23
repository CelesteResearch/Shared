using System.Collections;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tagging;

namespace Celeste.Simulation.Presentation.Hud.Overlays
{
    public class OverlayPresentation : SceneEntityState
    {
        protected readonly ISourceEngineContext EngineContext;
        public float Fade;
        public bool XboxOverlay;

        public OverlayPresentation(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            EngineContext = engine;
            Tags = ((ISourceBitTagEnvironment)engine).BitTags.Get("HUD").Value;
            Depth = -100000;
        }

        public override void Added(object actualScene)
        {
            if (actualScene is IOverlayHandler handler) handler.Overlay = this;
            base.Added(actualScene);
        }

        public override void Removed(object actualScene)
        {
            if (actualScene is IOverlayHandler handler && ReferenceEquals(handler.Overlay, this))
                handler.Overlay = null;
            base.Removed(actualScene);
        }

        public IEnumerator FadeIn()
        {
            while (Fade < 1f)
            {
                yield return null;
                Fade += EngineContext.DeltaTime * 4f;
            }

            Fade = 1f;
        }

        public IEnumerator FadeOut()
        {
            while (Fade > 0f)
            {
                yield return null;
                Fade -= EngineContext.DeltaTime * 4f;
            }
        }

        public void RenderFade(ISourceRenderContext context)
        {
            var color = PackedColor.Black *
                        ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeInOut(Fade) *
                        .95f;
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, color);
        }
    }
}
