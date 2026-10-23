using System;
using System.Numerics;
using Celeste.Game.Audio.Mixing;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public ScreenWipePresentation CompleteArea(bool spotlightWipe = true,
            bool skipScreenWipe = false, bool skipCompleteScreen = false)
        {
            RegisterAreaComplete();
            PauseLock = true;
            Action action = !(AreaData.Interlude || skipCompleteScreen)
                ? (Action)(() => EngineContext.Frame.Scenes.NextScene =
                    ((IOriginalLevelExitEnvironment)EngineContext).LevelExits.CreateLevelExit(
                        LevelExitMode.Completed, Session))
                : () => EngineContext.Frame.Scenes.NextScene =
                    ((IOriginalLevelExitEnvironment)EngineContext).LevelExits.CreateLevelExit(
                        LevelExitMode.CompletedInterlude, Session, HiresSnow);
            if (!SkippingCutscene && !skipScreenWipe)
            {
                if (spotlightWipe)
                {
                    var player =
                        SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                    if (player != null)
                        ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.SpotlightFocusPoint =
                            player.Position - Camera.Position - new Vector2(0f, 8f);
                    return new SpotlightWipePresentation(this, false, action);
                }

                return new FadeWipePresentation(this, false, action);
            }

            ((IOriginalGameplayProcess)EngineContext).AudioSession.Runtime.StopGameplaySfx(true);
            action();
            return null;
        }
    }
}
