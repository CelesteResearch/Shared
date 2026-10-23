using System.Numerics;
using Celeste.Game.Presentation.Particles;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerFrameParticleScene
    {
        void ISourcePlayerFrameParticleScene.BurstPlayerForegroundDust(Vector2 position, float direction, int count,
            float range)
            => OriginalDust.BurstFG(EngineContext, position, direction, count, range);
    }
}
