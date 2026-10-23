namespace Celeste.Game.Execution.Levels.Update
{
    public sealed class OriginalLevelUpdatePolicy : IOriginalLevelUpdatePolicy
    {
        public static OriginalLevelUpdatePolicy Shared { get; } = new();

        public void Update(OriginalLevelSceneRoot level)
        {
            level.UpdateOriginalGame();
        }
    }
}
