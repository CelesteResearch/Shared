using System;
using Celeste.Core.Components;

namespace Celeste.Simulation.Presentation.PostProcessing.Displacement
{
    public class DisplacementRenderHookState : SourceComponentState
    {
        public Action RenderDisplacement;

        public DisplacementRenderHookState(Action render) : base(false, true)
        {
            RenderDisplacement = render;
        }
    }
}
