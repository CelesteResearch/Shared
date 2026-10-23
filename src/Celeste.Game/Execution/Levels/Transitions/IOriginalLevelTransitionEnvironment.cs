namespace Celeste.Game.Execution.Levels.Transitions
{
    public interface IOriginalLevelTransitionEnvironment
    {
        IOriginalLevelTransitionPolicy LevelTransitionPolicy { get; }
    }
}
