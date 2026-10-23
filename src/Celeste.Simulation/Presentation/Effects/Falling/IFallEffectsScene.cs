namespace Celeste.Simulation.Presentation.Effects.Falling
{
    public interface IFallEffectsScene
    {
        FallEffectsPresentation First { get; }
        FallEffectsPresentation Create();
        void Add(FallEffectsPresentation effects);
    }
}
