using System.Collections.Generic;

namespace Celeste.Simulation.Presentation.Particles.Definitions
{
    public sealed class ParticleTypeRegistry
    {
        private readonly List<ParticleTypePresentation> allTypes = [];

        internal void Register(ParticleTypePresentation type)
        {
            allTypes.Add(type);
        }
    }
}
