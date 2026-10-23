using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private bool wasPaused;
        private float unpauseTimer;

        public FmodEventReference PauseSnapshot
        {
            get => sourceAudioSession.LevelState.PauseSnapshot;
            set => sourceAudioSession.LevelState.PauseSnapshot = value;
        }

        public void StartPauseEffects()
        {
            if (sourceAudioSession.CurrentMusic == "event:/music/lvl0/bridge")
                sourceAudioSession.PauseMusic = true;
            sourceAudioSession.PauseGameplaySfx = true;
            sourceAudioSession.Play("event:/ui/game/pause");
            if (PauseSnapshot == null)
                PauseSnapshot = sourceAudioSession.CreateSnapshot("snapshot:/pause_menu");
        }

        private void EndPauseEffects()
        {
            sourceAudioSession.PauseMusic = false;
            sourceAudioSession.PauseGameplaySfx = false;
            sourceAudioSession.ReleaseSnapshot(PauseSnapshot);
            PauseSnapshot = null;
        }
    }
}
