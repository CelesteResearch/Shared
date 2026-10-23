namespace Celeste.Simulation.Runtime.Session
{
    public interface ISourceSessionFlagInterceptionEnvironment
    {
        bool AllowSourceSessionFlagChange(ChapterCompletionSession session, string flag, bool setTo);
    }
}
