using Celeste.Core.Maps;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void Add(OriginalSaveDataState save, int area, int mode, MapEntityId id,
            bool golden, IFileSaveStatistics statistics)
            => OriginalSaveStrawberrySource.Add(save, area, mode, id, golden, statistics, this, this);

        public bool Check(OriginalSaveDataState save, int area, int mode, MapEntityId id)
            => GetAreasSafe(save)[area].Modes[mode].Strawberries.Contains(id);
    }
}
