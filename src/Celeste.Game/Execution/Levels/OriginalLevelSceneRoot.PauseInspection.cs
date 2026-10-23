namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool WasPaused
        {
            get => wasPaused;
            set => wasPaused = value;
        }

        public float UnpauseTimer
        {
            get => unpauseTimer;
            set => unpauseTimer = value;
        }
    }
}
