using System.Numerics;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerJumpScene
    {
        void ISourcePlayerJumpScene.BurstPlayerDust(Vector2 position, float direction, int count, int surfaceIndex)
        {
            var types = ((IOriginalGameplayProcess)EngineContext).ParticleTypes;
            OriginalDust.Burst(EngineContext, position, direction, count,
                surfaceIndex == 40 ? types.SparkyDust : types.Dust);
        }

        void ISourcePlayerJumpScene.BurstPlayerWallSlideDust(RoomPlayerSession actualPlayer, int direction,
            int surfaceIndex)
        {
            var types = ((IOriginalGameplayProcess)EngineContext).ParticleTypes;
            var particle = surfaceIndex == 40 ? types.SparkyDust : types.Dust;
            float offset = particle == types.Dust ? 5f : 2f;
            Vector2 center = actualPlayer.Center;
            if (direction == 1) center += new Vector2(offset, 4f);
            else center += new Vector2(0f - offset, 4f);
            OriginalDust.Burst(EngineContext, center, -(float)System.Math.PI / 2f, 1, particle);
        }

        void ISourcePlayerJumpScene.RecordPlayerJump()
            => ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.TotalJumps++;

        void ISourcePlayerJumpScene.RecordPlayerWallJump()
            => ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.TotalWallJumps++;
    }
}
