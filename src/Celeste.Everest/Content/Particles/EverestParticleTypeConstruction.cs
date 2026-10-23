using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Everest.Content.Particles
{
    public sealed class EverestParticleTypeConstruction : ISourceParticleTypeConstruction
    {
        public ParticleTypePresentation Create() => new ParticleTypePresentation();
        public ParticleTypePresentation Clone(ParticleTypePresentation source) => new ParticleTypePresentation(source);
    }
}
