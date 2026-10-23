using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public readonly struct ProcessRefillGlowParticleSource(IOriginalRefillProcess engine) : IRefillGlowParticleSource
    {
        public ParticleTypePresentation GetGlow() => engine.RefillParticles.P_Glow;
    }
}
