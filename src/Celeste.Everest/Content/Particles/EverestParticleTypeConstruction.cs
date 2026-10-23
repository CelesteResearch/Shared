using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Everest.Content.Particles
{
    public sealed class EverestParticleTypeConstruction : ISourceParticleTypeConstruction
    {
        public ParticleTypePresentation Create()
        {
            return new();
        }

        public ParticleTypePresentation Clone(ParticleTypePresentation source)
        {
            return new(source);
        }
    }
}
