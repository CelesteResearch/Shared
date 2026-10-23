using Celeste.Core.Components;

namespace Celeste.Simulation.Presentation.Effects.Mirrors
{
    public sealed class MirrorReflectionState : SourceComponentState
    {
        public bool IgnoreEntityVisible;
        public bool IsRendering;

        public MirrorReflectionState() : base(false, true)
        {
        }
    }
}
