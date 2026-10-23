using Celeste.Game.Gameplay.Collectibles.Refills;
using Celeste.Game.Presentation.Particles.Definitions.Refill;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalRefillProcess
    {
        RefillParticleDefinitions
            IOriginalRefillProcess.RefillParticles => ParticleTypes.Refill;
    }
}
