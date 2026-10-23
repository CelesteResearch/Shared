using Celeste.Core.Components;
using Celeste.Game.Execution.Startup;
using Celeste.Input.Runtime;
using Celeste.Scene.Tagging;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public override void FreezeFrameUpdate(SourceBitTag updateTag)
        {
            var tags = ((IOriginalGameTagsEnvironment)EngineContext).Tags;
            if (FrozenOrPaused)
            {
                var input = ((ISourceMInputEnvironment)EngineContext).MInput;
                var disabled = input.Disabled;
                input.Disabled = false;
                if (!Paused) Scheduler.UpdateTaggedEntities(tags.FrozenUpdate, updateTag);
                Scheduler.UpdateTaggedEntities(tags.PauseUpdate, updateTag);
                input.Disabled = disabled;
            }
            else if (!Transitioning)
            {
                if (RetryPlayerCorpse == null) base.FreezeFrameUpdate(updateTag);
                else Scheduler.UpdateTaggedEntities(tags.PauseUpdate, updateTag);
            }
            else
            {
                Scheduler.UpdateTaggedEntities(tags.TransitionUpdate, updateTag, false);
            }

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var entry in Scheduler.Components.GetTrackedComponents("Celeste.PostUpdateHook"))
            {
                var hook = (ScenePostUpdateHook)entry;
                if (((ISourceEntityUpdate)hook.Entity).Active &&
                    (((ISceneEntityTags)hook.Entity).Tags.Bits & updateTag.Value) != 0)
                    hook.OnPostUpdate();
            }
        }
    }
}
