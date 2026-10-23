using System;
using Celeste.Game.Execution.LevelLoader;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public ChapterGlassBlockBackgroundSceneState GlassBlockBackground { get; private set; }

        public void ConstructSourceGlassBlockBackground()
        {
            if (GlassBlockBackground != null)
                throw new InvalidOperationException("This Level already constructed its GlassBlockBg.");
            GlassBlockBackground = new(EngineContext);
            Scheduler.QueueSourceEntity(GlassBlockBackground);
        }
    }
}
