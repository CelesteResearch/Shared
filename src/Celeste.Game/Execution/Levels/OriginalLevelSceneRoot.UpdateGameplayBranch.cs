using Celeste.Input.Runtime;
using Celeste.Game.Entities.Protocols;
using Celeste.Simulation.Presentation.Environment.Effects;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public global::Celeste.Game.Presentation.Environment.HiresSnowState HiresSnow;

        private void UpdateSourceGameplayBranch()
        {
            if (SkippingCutscene)
            {
                if (Cutscene.SkipCoroutine != null)
                    Cutscene.SkipCoroutine.Update();
                Renderers.Update();
            }
            else if (FrozenOrPaused)
            {
                bool disabled = ((ISourceMInputEnvironment)EngineContext).MInput.Disabled;
                ((ISourceMInputEnvironment)EngineContext).MInput.Disabled = false;
                Scheduler.UpdateCommitted(
                    (int)(Paused ? OriginalSceneUpdateMode.Paused : OriginalSceneUpdateMode.Frozen));
                ((ISourceMInputEnvironment)EngineContext).MInput.Disabled = disabled;
                if (Wipe != null) Wipe.Update(this);
                if (HiresSnow != null) HiresSnow.Update(this);
                Scheduler.CommitEntityListsForLevel();
            }
            else if (!Transitioning)
            {
                if (RetryPlayerCorpse == null)
                {
                    base.Update();
                }
                else
                {
                    RetryPlayerCorpse.Update();
                    Renderers.Update();
                    Scheduler.UpdateCommitted((int)OriginalSceneUpdateMode.Paused);
                }
            }
            else
            {
                Scheduler.UpdateCommitted((int)OriginalSceneUpdateMode.Transition);
                TransitionSequence.Update();
                Renderers.Update();
            }
        }
    }
}
