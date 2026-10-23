using System;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Controls.Source;
using Celeste.Input.Gameplay.Feedback;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlatformCollisionEffects
    {
        bool ISourcePlatformCollisionEffects.ShouldMovePlayerUp(RoomPlayerSession player, int move)
            => ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource.MoveX.Value == Math.Sign(move)
               && Math.Sign(player.Data.Motion.Normal.Speed.X) == Math.Sign(move);

        void ISourcePlatformCollisionEffects.AfterBreakingWall(SourcePlatformEntityState movingPlatform)
        {
            Shake(.2f);
            ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource.Rumble(RumbleStrength.Medium,
                RumbleLength.Medium);
        }
    }
}
