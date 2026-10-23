using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public OriginalSaveDataState InitializeDebugMode(OriginalUserIOStorage storage,
            IOriginalSaveInitializationServices services, bool loadExisting = true)
        {
            OriginalSaveDataState save = null;
            if (loadExisting && storage.Open(OriginalUserIOStorage.Mode.Read))
            {
                save = storage.Load<OriginalSaveDataState>(GetFilename(4));
                storage.Close();
            }

            if (save == null) save = CreateSave();
            save.DebugMode = true;
            save.CurrentSession = null;
            Start(save, 4, services);
            return save;
        }
    }
}
