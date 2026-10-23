using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveSessionStartPolicy
    {
        void StartSession(OriginalSaveDataState actualSave, ChapterCompletionSession session);
    }
}
