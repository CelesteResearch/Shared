using System.Collections.Generic;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCheckpointQueries
    {
        bool FoundAnyCheckpoints(OriginalSaveDataState save, OriginalAreaKey area);
        HashSet<string> GetCheckpoints(OriginalSaveDataState save, OriginalAreaKey area);
    }
}
