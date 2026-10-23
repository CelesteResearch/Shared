using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        // Installed SaveData cctor initializes this process field before Start's first use.
        public int LoadedModSaveDataIndex = int.MinValue;

        int IEverestSaveModuleState.LoadedModSaveDataIndex
        {
            get => LoadedModSaveDataIndex;
            set => LoadedModSaveDataIndex = value;
        }


        public void Start(OriginalSaveDataState data, int slot, IOriginalSaveInitializationServices services)
        {
            context.PublishCurrentSave(data);
            context.CurrentSave.FileSlot = slot;
            AfterInitialize(context.CurrentSave, services);
            LoadModSaveData(slot);
            foreach (var module in saveModules.SaveModules)
            {
                if (module.SaveDataAsync) module.DeserializeSession(slot, module.ReadSession(slot));
#pragma warning disable CS0618 // Preserve original legacy module override dispatch.
                else module.LoadSession(slot, false);
#pragma warning restore CS0618
            }

            ((IOriginalSaveStartSourceHooksEnvironment)engineIdentity.EngineIdentity.Process)
                .AfterSourceSaveStart(context.CurrentSave);
        }

        public void LoadModSaveData(int slot)
        {
            if (LoadedModSaveDataIndex != slot)
            {
                foreach (var module in saveModules.SaveModules)
                {
                    if (module.SaveDataAsync) module.DeserializeSaveData(slot, module.ReadSaveData(slot));
#pragma warning disable CS0618 // Preserve original legacy module override dispatch.
                    else module.LoadSaveData(slot);
#pragma warning restore CS0618
                }

                LoadedModSaveDataIndex = slot;
            }
        }
    }
}
