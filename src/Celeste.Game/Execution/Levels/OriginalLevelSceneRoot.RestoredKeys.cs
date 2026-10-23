using Celeste.Game.Gameplay.Collectibles.Keys;
using Celeste.Simulation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void QueueRestoredSourceKeys(RoomPlayerSession player)
        {
            foreach (var key in Session.Keys)
                Scheduler.QueueSourceEntity(new OriginalKeyState(player, key, (IOriginalKeyProcess)EngineContext));
        }
    }
}
