namespace Celeste.Game.Execution.LevelLoader
{
    public interface IOriginalLevelLoadOverrideEnvironment
    {
        IOriginalLevelLoadOverridePolicy LevelLoadOverrides { get; }
    }
}
