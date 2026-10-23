namespace Celeste.Simulation.Presentation.Effects.Mirrors
{
    public sealed class MirrorReflectionState : global::Celeste.Core.Components.SourceComponentState
    {
        public bool IgnoreEntityVisible;
        public bool IsRendering;

        public MirrorReflectionState() : base(false, true)
        {
        }
    }
}
