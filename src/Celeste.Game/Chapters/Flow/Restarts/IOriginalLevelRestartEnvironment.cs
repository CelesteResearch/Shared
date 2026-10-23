namespace Celeste.Game.Chapters.Flow.Restarts
{
    public interface IOriginalLevelRestartEnvironment
    {
        IOriginalLevelRestartPolicy LevelRestartPolicy { get; }
    }
}
