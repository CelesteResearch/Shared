using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCompletionPolicy
    {
        void RegisterCompletion(OriginalSaveDataState save, ChapterCompletionSession session);
    }
}
