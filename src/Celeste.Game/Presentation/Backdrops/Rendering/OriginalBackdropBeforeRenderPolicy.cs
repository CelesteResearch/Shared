using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using System;
using System.Numerics;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Presentation.Backdrops.Rendering
{
    public sealed class OriginalBackdropBeforeRenderPolicy : ISourceBackdropBeforeRenderPolicy
    {
        public bool ShouldBeforeRender(BackdropPresentation backdrop) => true;

        public void Render(BackdropRendererPresentation renderer, ISourceRenderContext context,
            ISourceBackdropScene scene)
            => renderer.RenderOriginal(context, scene);

        public void RenderParallax(ParallaxBackdropPresentation backdrop, ISourceRenderContext context,
            ISourceBackdropScene scene)
            => backdrop.RenderOriginal(context, scene);
    }
}
