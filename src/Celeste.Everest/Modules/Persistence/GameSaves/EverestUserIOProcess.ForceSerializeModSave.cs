using Celeste.Game.Save.Data;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestUserIOProcess
    {
        public void ForceSerializeModSave()
        {
            storage.Save<OriginalModSaveData>(initialization.GetFilename(saves.CurrentSave.FileSlot) + "-modsavedata",
                storage.Serialize(new OriginalModSaveData(saves.CurrentSave)));
            foreach (var module in modules.SaveModules)
            {
                if (coreSettings.Settings.SaveDataFlush == true) module.ForceSaveDataFlush += 2;

                if (module.SaveDataAsync)
                {
                    module.WriteSaveData(saves.CurrentSave.FileSlot,
                        module.SerializeSaveData(saves.CurrentSave.FileSlot));
                    module.WriteSession(saves.CurrentSave.FileSlot,
                        module.SerializeSession(saves.CurrentSave.FileSlot));
                }
                else
                {
#pragma warning disable CS0618 // Preserve original legacy module override dispatch.
                    module.SaveSaveData(saves.CurrentSave.FileSlot);
#pragma warning restore CS0618
#pragma warning disable CS0618 // Preserve original legacy module override dispatch.
                    module.SaveSession(saves.CurrentSave.FileSlot);
#pragma warning restore CS0618
                }
            }
        }
    }
}
