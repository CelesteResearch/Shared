using Celeste.Game.Audio.Entities;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Execution.Areas
{
    public static class OriginalAreaLevelBeginCallbacks
    {
        public static void OldSite(OriginalLevelSceneRoot level)
        {
            if (level.Session.Mode == 0)
                level.Scheduler.QueueSourceEntity(
                    new global::Celeste.Game.Gameplay.Enemies.Badeline.Chasers.OldSiteChaseMusicHandlerState(
                        level.EngineContext));
        }

        public static void MirrorTemple(OriginalLevelSceneRoot level)
        {
            level.ConstructSourceSeekerEffectsController();
            if (level.Session.Mode == 0)
                level.Scheduler.QueueSourceEntity(new OriginalTempleEndingMusicHandler(level.EngineContext));
        }
    }
}
