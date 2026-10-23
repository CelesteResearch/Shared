using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveDebugPolicy
    {
        OriginalSaveDataState InitializeDebugMode(OriginalUserIOStorage storage,
            IOriginalSaveInitializationServices services, bool loadExisting = true);
    }
}
