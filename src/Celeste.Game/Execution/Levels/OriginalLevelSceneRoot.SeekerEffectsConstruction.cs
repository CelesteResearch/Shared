namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void ConstructSourceSeekerEffectsController()
            => Scheduler.QueueSourceEntity(
                new global::Celeste.Game.Gameplay.Enemies.Seekers.SeekerEffectsControllerState(EngineContext));
    }
}
