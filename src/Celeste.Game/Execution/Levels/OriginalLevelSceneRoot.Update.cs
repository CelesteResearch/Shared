using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels.Debug;
using Celeste.Game.Execution.Levels.Update;
using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceSceneExecution
    {
        private IOriginalLevelUpdatePolicy levelUpdatePolicy;

        public void BindSourceLevelUpdatePolicy(IOriginalLevelUpdatePolicy actualPolicy)
        {
            if (levelUpdatePolicy != null)
                throw new InvalidOperationException("The actual Level already bound its source Update policy.");
            levelUpdatePolicy = actualPolicy ?? throw new ArgumentNullException(nameof(actualPolicy));
        }

        public override void Update()
        {
            if (global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                    .Get<global::Celeste.Core.Scheduling.ISourceGameplayLifecycleExtension>(EngineContext) is
                { } lifecycle)
                lifecycle.BeforeLevelUpdate();
            levelUpdatePolicy.Update(this);
            ((global::Celeste.Game.Execution.Levels.Hooks.IOriginalLevelLifecycleSourceHooksEnvironment)EngineContext)
                .LevelSourceHooks.InvokeAfterUpdate(this);
        }

        public void UpdateOriginalGame()
        {
            if (UpdateSourceEarlyReturns()) return;
            UpdateSourceAssistSpeed();
            UpdateSourcePauseInput();
            UpdateLevelTime();
            UpdateSourceSaving();
            UpdateSourceGlitch();
            UpdateSourceGameplayBranch();
            UpdateSourceGameplayTail();
            if (((IOriginalGamePlayModeEnvironment)EngineContext).PlayMode == GameRuntime.PlayModes.Debug)
                ((IOriginalLevelDebugEnvironment)EngineContext).LevelDebug.Update(this);
        }
    }
}
