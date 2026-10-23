using System;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Presentation.Particles
{
    public sealed class OriginalParticleTypeConstruction : ISourceParticleTypeConstruction
    {
        private readonly ParticleTypeRegistry registry;

        public OriginalParticleTypeConstruction(ParticleTypeRegistry registry)
            => this.registry = registry ?? throw new ArgumentNullException(nameof(registry));

        public ParticleTypePresentation Create() => new ParticleTypePresentation(registry);

        public ParticleTypePresentation Clone(ParticleTypePresentation source)
            => new ParticleTypePresentation(source, registry);
    }
}
