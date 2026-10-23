using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        internal IOriginalLevelSetStatsQueries LevelSetStatsQueries => (IOriginalLevelSetStatsQueries)counterQueries;
    }
}
