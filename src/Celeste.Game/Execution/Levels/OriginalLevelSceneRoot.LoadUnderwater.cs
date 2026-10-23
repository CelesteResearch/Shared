using System.Numerics;
using Celeste.Game.Gameplay.Environment.Water;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void AddSourceUnderwaterRoom(Vector2 position, int width, int height)
        {
            Scheduler.QueueSourceEntity(new OriginalWaterState(EngineContext, position,
                false, false, width, height));
        }
    }
}
