using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Audio.Runtime
{
    public sealed class OriginalLevelAudioState
    {
        public FmodEventReference PauseSnapshot;
        public FmodEventReference AssistSpeedSnapshot;
        public int AssistSpeedSnapshotValue = -1;
    }
}
