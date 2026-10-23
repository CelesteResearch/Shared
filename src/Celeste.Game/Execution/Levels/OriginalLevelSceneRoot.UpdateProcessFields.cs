using Celeste.Audio.Fmod.Events;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private OriginalGameAudioSession sourceAudioSession => ((IOriginalGameplayProcess)EngineContext).AudioSession;

        private FmodEventReference AssistSpeedSnapshot
        {
            get => sourceAudioSession.LevelState.AssistSpeedSnapshot;
            set => sourceAudioSession.LevelState.AssistSpeedSnapshot = value;
        }

        private int AssistSpeedSnapshotValue
        {
            get => sourceAudioSession.LevelState.AssistSpeedSnapshotValue;
            set => sourceAudioSession.LevelState.AssistSpeedSnapshotValue = value;
        }

        public FmodEventReference DialogSnapshot
        {
            get => sourceAudioSession.DialogSnapshot;
            set => sourceAudioSession.DialogSnapshot = value;
        }
    }
}
