using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void ResetSourceLevelLoad(PlayerIntroType playerIntro)
        {
            TimerHidden = false;
            TimerStopped = false;
            LastIntroType = playerIntro;
            Background.Fade = 0f;
            CanRetry = true;
            ScreenPadding = 0f;
            Displacement.Enabled = true;
            PauseLock = false;
            Frozen = false;
            CameraLockMode = RoomCameraLockMode.None;
            RetryPlayerCorpse = null;
            FormationBackdrop.Display = false;
            SaveQuitDisabled = false;
            ColorGrade.LoadLevel();
            InitializeSourceCassetteFields();
            Raining = false;
        }
    }
}
