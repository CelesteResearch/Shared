using Celeste.Core.Maps;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalStrawberrySavePolicy
    {
        void Add(OriginalSaveDataState save, int area, int mode, MapEntityId id, bool golden,
            IFileSaveStatistics statistics);

        bool Check(OriginalSaveDataState save, int area, int mode, MapEntityId id);
    }
}
