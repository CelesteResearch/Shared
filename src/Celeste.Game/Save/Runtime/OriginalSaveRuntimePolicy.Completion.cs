using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void RegisterCompletion(OriginalSaveDataState save, ChapterCompletionSession session)
        {
            OriginalSaveCompletionSource.RegisterCompletion(save, session, this, this);
        }
    }
}
