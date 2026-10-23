using Celeste.Game.Gameplay.Collectibles.Refills;
using Celeste.Simulation.Presentation.Particles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IOriginalRefillScene
    {
        ParticleSystemPresentation IOriginalRefillScene.ParticlesFG => ParticlesFG;

        void IOriginalRefillScene.Shake()
        {
            Shake();
        }
    }
}
