using Celeste.Core.Randomness;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles
{
    public interface IFinalBossBeamParticleState
    {
        ParticleSystemPresentation ParticleSystem { get; }
        ParticleTypePresentation ParticleType { get; }
        ISourceRandom Random { get; }
    }
}
