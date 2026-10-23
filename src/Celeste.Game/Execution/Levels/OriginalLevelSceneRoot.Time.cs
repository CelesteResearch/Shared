using Celeste.Core.Framework.Time;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class
        OriginalLevelSceneRoot : global::Celeste.Game.Execution.Engine.Update.IOriginalEngineLevelTimeScene
    {
        public bool InCredits;
        public bool TimerStarted;

        public void UpdateLevelTime()
        {
            UpdateLevelTimeSourceBody();
            ((global::Celeste.Game.Execution.Levels.Hooks.IOriginalLevelLifecycleSourceHooksEnvironment)EngineContext)
                .LevelSourceHooks.InvokeAfterUpdateTime(this);
        }

        private void UpdateLevelTimeSourceBody()
        {
            if (InCredits || ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSessionArea(Session).ID == 8 ||
                TimerStopped)
                return;
            long ticks = ((ISourceTimeSpanEnvironment)EngineContext).TimeSpans.FromSeconds(EngineContext.RawDeltaTime)
                .Ticks;
            ((IOriginalSaveTimeEnvironment)EngineContext).SaveTime.AddTime(
                ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave,
                ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSessionArea(Session), ticks);
            if (!TimerStarted && !InCutscene)
            {
                var player =
                    Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (player != null && !player.TimePaused)
                    TimerStarted = true;
            }

            if (!Completed && TimerStarted)
                Session.Time += ticks;
        }

        private void ReloadSourceTimerPrefix()
        {
            if (Session.FirstLevel && Session.Strawberries.Count <= 0 && !Session.Cassette &&
                !Session.HeartGem && !Session.HitCheckpoint)
            {
                Session.Time = 0;
                Session.Deaths = 0;
                TimerStarted = false;
            }

            Session.Dashes = Session.DashesAtLevelStart;
        }
    }
}
