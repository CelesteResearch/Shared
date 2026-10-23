using Celeste.Game.Gameplay.Collectibles.Refills;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalRefillProcess
    {
        global::Celeste.Game.Presentation.Particles.Definitions.Refill.RefillParticleDefinitions
            IOriginalRefillProcess.RefillParticles => ParticleTypes.Refill;
    }
}
