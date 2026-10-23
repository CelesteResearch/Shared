using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Simulation.Gameplay.Player.Scene.Particles
{
    public interface ISourcePlayerDashParticleEnvironment
    {
        ParticleTypePresentation DashA { get; }
        ParticleTypePresentation DashB { get; }
        ParticleTypePresentation DashBadB { get; }
    }
}
