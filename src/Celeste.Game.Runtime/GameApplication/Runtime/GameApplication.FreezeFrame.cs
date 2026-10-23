using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Runtime.Events.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Profiles;
using Celeste.Scene.Scenes;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void UpdateSourceFreezeFrame(ISourceSceneExecution scene)
        {
            if (SourceProfile != GameProfile.InstalledEverest) return;
            var actualScene = scene as SourceSceneState ??
                              throw new InvalidOperationException(
                                  "The installed scene has no freeze-frame update capability.");
            var level = actualScene as OriginalLevelSceneRoot;
            if (level != null && EverestLevelFreezeEvents.HasBeforeFreezeFrameUpdateListeners)
                EverestLevelFreezeEvents.BeforeFreezeFrameUpdate(CreateFreezeFrameContext(level));
            actualScene.FreezeFrameUpdate(EverestTags.FreezeFrameUpdate);
            if (level != null && EverestLevelFreezeEvents.HasAfterFreezeFrameUpdateListeners)
                EverestLevelFreezeEvents.AfterFreezeFrameUpdate(CreateFreezeFrameContext(level));
        }

        private EverestLevelFreezeContext CreateFreezeFrameContext(OriginalLevelSceneRoot level)
        {
            return new(level, level.Scheduler, () => Frame.Effects.FreezeTimer,
                value => Frame.Effects.FreezeTimer = value,
                level.Paused, level.Frozen, level.Transitioning, Frame.RawDeltaTime, Frame.DeltaTime);
        }
    }
}
