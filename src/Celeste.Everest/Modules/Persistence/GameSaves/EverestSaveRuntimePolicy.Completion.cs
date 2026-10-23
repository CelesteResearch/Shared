using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void RegisterCompletion(OriginalSaveDataState save, ChapterCompletionSession session)
            => OriginalSaveCompletionSource.RegisterCompletion(save, session, this, this);
    }
}
