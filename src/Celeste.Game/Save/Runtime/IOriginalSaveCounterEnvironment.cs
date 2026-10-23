namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCounterEnvironment
    {
        IOriginalSaveCounterQueries SaveCounters { get; }
    }
}
