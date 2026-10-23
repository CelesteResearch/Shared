using Celeste.Game.Audio;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Game.Execution.Levels
{
    public partial class OriginalLevelSceneRoot : ISourceCoreModeScene
    {
        private RoomCoreMode coreMode;

        public RoomCoreMode CoreMode
        {
            get { return coreMode; }
            set
            {
                if (coreMode == value) return;
                coreMode = value;
                Session.SetFlag("cold", coreMode == RoomCoreMode.Cold);
                ((IOriginalGameplayProcess)EngineContext).AudioSession.SetParameter(
                    ((IOriginalGameplayProcess)EngineContext).AudioSession.CurrentAmbienceEventInstance,
                    "room_state", coreMode != RoomCoreMode.Hot ? 1 : 0);
                if (((IOriginalGameplayProcess)EngineContext).AudioSession.CurrentMusic == "event:/music/lvl9/main")
                {
                    Session.Audio.Music.Layer(1, coreMode == RoomCoreMode.Hot);
                    Session.Audio.Music.Layer(2, coreMode == RoomCoreMode.Cold);
                    OriginalAudioSession.Apply(Session.Audio,
                        ((IOriginalGameplayProcess)EngineContext).AudioSession.ChannelOutput,
                        ((IOriginalGameplayProcess)EngineContext).AudioApplyPolicy);
                }

                foreach (CoreModeListenerState component in SourceScene.Components.GetTrackedComponents(
                             "Celeste.CoreModeListener"))
                {
                    if (component.OnChange != null) component.OnChange(value);
                }
            }
        }
    }
}
