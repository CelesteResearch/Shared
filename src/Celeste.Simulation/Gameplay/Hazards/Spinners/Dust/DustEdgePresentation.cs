using System;
using Celeste.Core.Components;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public class DustEdgePresentation : SourceComponentState
    {
        public Action<ISourceRenderContext> RenderDust;

        public DustEdgePresentation(Action<ISourceRenderContext> renderDust) : base(false, true)
        {
            RenderDust = renderDust;
        }
    }
}
