using Celeste.Game.Gameplay.Enemies.Seekers;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void ConstructSourceSeekerEffectsController()
        {
            Scheduler.QueueSourceEntity(
                new SeekerEffectsControllerState(EngineContext));
        }
    }
}
