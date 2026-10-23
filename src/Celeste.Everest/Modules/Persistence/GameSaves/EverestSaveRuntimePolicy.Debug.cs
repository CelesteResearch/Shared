using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public OriginalSaveDataState InitializeDebugMode(OriginalUserIOStorage storage,
            IOriginalSaveInitializationServices services, bool loadExisting = true)
        {
            OriginalSaveDataState save = null;
            if (loadExisting && storage.Open(OriginalUserIOStorage.Mode.Read))
            {
                save = storage.Load<OriginalSaveDataState>(GetFilename(-1));
                storage.Close();
            }

            if (save == null) save = CreateSave();
            save.DebugMode = true;

            Start(save, -1, services);
            return save;
        }
    }
}
