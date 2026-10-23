namespace Celeste.Game.Execution.Threading
{
    public interface IOriginalThreadEnvironment
    {
        OriginalGameThreadSession Threads { get; }
    }
}
