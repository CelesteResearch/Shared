using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Particles;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public interface IOriginalRefillScene : ISourceScene
    {
        ParticleSystemPresentation ParticlesFG { get; }
        void Shake();
    }
}
