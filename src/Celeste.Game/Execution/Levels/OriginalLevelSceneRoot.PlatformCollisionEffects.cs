using System;
using Celeste.Game.Controls.Source;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlatformCollisionEffects
    {
        bool ISourcePlatformCollisionEffects.ShouldMovePlayerUp(RoomPlayerSession player, int move)
        {
            return ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource.MoveX.Value == Math.Sign(move)
                   && Math.Sign(player.Data.Motion.Normal.Speed.X) == Math.Sign(move);
        }

        void ISourcePlatformCollisionEffects.AfterBreakingWall(SourcePlatformEntityState movingPlatform)
        {
            Shake(.2f);
            ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource.Rumble(RumbleStrength.Medium,
                RumbleLength.Medium);
        }
    }
}
