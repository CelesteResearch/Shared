using Celeste.Core.Scheduling;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Menus.Overworld
{
    public interface IOriginalOverworldLoaderPostcardPolicy
    {
        int GetVariantHeartCount(OriginalSaveDataState save, ISourceEngineContext engine);
        bool ShouldShowCSide(ChapterCompletionSession session, ISourceEngineContext engine);
    }
}
