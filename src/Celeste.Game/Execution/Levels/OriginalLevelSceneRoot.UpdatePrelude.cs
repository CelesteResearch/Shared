using Celeste.Core.Randomness;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Pause;
using Celeste.Game.Save.Runtime;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private float wasPausedTimer;

        public bool CanPause
        {
            get
            {
                var player =
                    Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);
                if (player != null && !player.Dead && !wasPaused && !Paused && !PauseLock &&
                    !SkippingCutscene && !Transitioning && Wipe == null)
                {
                    if (((IOriginalLevelPauseEnvironment)EngineContext).LevelPause.IsPauseBlockedBySaving(
                            ((IOriginalUserIOEnvironment)EngineContext).UserIO.Saving))
                        return false;

                    if (player.LastBooster != null && player.LastBooster.Ch9HubTransition)
                        return !player.LastBooster.BoostingPlayer;
                    return true;
                }

                return false;
            }
        }

        private bool UpdateSourceEarlyReturns()
        {
            if (unpauseTimer > 0f)
            {
                unpauseTimer -= EngineContext.RawDeltaTime;
                UpdateLevelTime();
                return true;
            }

            if (Overlay != null)
            {
                Overlay.Update();
                Scheduler.CommitQueuedEntityLists();
                return true;
            }

            return false;
        }

        private void UpdateSourceAssistSpeed()
        {
            var speed = 10;
            if (!InCutscene &&
                Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession)
                        .FullName) != null &&
                Wipe == null && !Frozen)
                speed = ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.Assists.GameSpeed;
            EngineContext.Effects.TimeRateB = speed / 10f;
            if (speed != 10)
            {
                if (AssistSpeedSnapshot == null || AssistSpeedSnapshotValue != speed)
                {
                    sourceAudioSession.ReleaseSnapshot(AssistSpeedSnapshot);
                    AssistSpeedSnapshot = null;
                    AssistSpeedSnapshotValue = speed;
                    if (AssistSpeedSnapshotValue < 10)
                        AssistSpeedSnapshot =
                            sourceAudioSession.CreateSnapshot("snapshot:/assist_game_speed/assist_speed_" +
                                                              AssistSpeedSnapshotValue * 10);
                    else if (AssistSpeedSnapshotValue <= 16)
                        AssistSpeedSnapshot =
                            sourceAudioSession.CreateSnapshot("snapshot:/variant_speed/variant_speed_" +
                                                              AssistSpeedSnapshotValue * 10);
                }
            }
            else if (AssistSpeedSnapshot != null)
            {
                sourceAudioSession.ReleaseSnapshot(AssistSpeedSnapshot);
                AssistSpeedSnapshot = null;
                AssistSpeedSnapshotValue = -1;
            }
        }

        private void UpdateSourcePauseInput()
        {
            if (wasPaused && !Paused)
                EndPauseEffects();
            var input = ((ISourceGameInputEnvironment)EngineContext).Input;
            if (CanPause && input.QuickRestart.Pressed)
            {
                input.QuickRestart.ConsumeBuffer();
                Pause(0, false, true);
            }
            else if (CanPause && (input.Pause.Pressed || input.ESC.Pressed))
            {
                input.Pause.ConsumeBuffer();
                input.ESC.ConsumeBuffer();
                Pause();
            }

            if (wasPaused && !Paused)
                wasPaused = false;
            if (Paused)
                wasPausedTimer = 0f;
            else
                wasPausedTimer += EngineContext.DeltaTime;
        }

        private void UpdateSourceGlitch()
        {
            if (!Paused)
                Glitch.Advance(EngineContext.DeltaTime, ((ISourceRandomEnvironment)EngineContext).Random);
        }
    }
}
