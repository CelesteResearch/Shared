using Celeste.Core.Scheduling;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Menus.Overworld
{
    public sealed class OriginalOverworldLoaderPostcardPolicy : IOriginalOverworldLoaderPostcardPolicy
    {
        public int GetVariantHeartCount(OriginalSaveDataState save, ISourceEngineContext engine)
            => ((IOriginalSaveCounterEnvironment)engine).SaveCounters.TotalHeartGems(save);

        public bool ShouldShowCSide(ChapterCompletionSession session, ISourceEngineContext engine)
            => session.UnlockedCSide;
    }
}
