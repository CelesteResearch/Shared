using System.Numerics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerSplitParticleScene
    {
        void ISourcePlayerSplitParticleScene.CreateSplitParticles(RoomPlayerSession actualPlayer)
            => Particles.Emit(((IOriginalGameplayProcess)EngineContext).ParticleTypes.Player.P_Split,
                16, actualPlayer.Center, Vector2.One * 6f);
    }
}
