using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Levels.Update
{
    public interface IOriginalLevelErrorPolicy
    {
        bool CheckForErrors(ChapterCompletionSession actualSession);
    }
}
