namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        // ReSharper disable once ConvertToAutoProperty
        public bool WasPaused
        {
            get => wasPaused;
            set => wasPaused = value;
        }

        // ReSharper disable once ConvertToAutoProperty
        public float UnpauseTimer
        {
            get => unpauseTimer;
            set => unpauseTimer = value;
        }
    }
}
