using System.IO;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public bool TryDelete(int slot, IOriginalSaveDeletionServices services)
        {
            var hasVanilla = false;
            var path = services.GetSaveFilePath(null);
            var filename = GetFilename(slot);
            if (Directory.Exists(path)) hasVanilla = File.Exists(Path.Combine(path, filename + ".celeste"));
            if (hasVanilla)
            {
                if (!services.Delete(GetFilename(slot))) return false;
            }
            else
            {
                diagnostics.Logger.Log(EverestLogLevel.Warn, "SaveData",
                    "Deleting save data for slot " + filename + " which has no vanilla data");
            }

            return TryDeleteModSaveData(slot, services);
        }

        public bool TryDeleteModSaveData(int slot, IOriginalSaveDeletionServices services)
        {
            foreach (var module in saveModules.SaveModules)
                if (module.SaveDataAsync)
                {
                    module.WriteSaveData(slot, null);
                    module.WriteSession(slot, null);
                }
                else
                {
#pragma warning disable CS0618
                    // Preserve original legacy module override dispatch.
                    module.DeleteSaveData(slot);
#pragma warning restore CS0618
#pragma warning disable CS0618
                    // Preserve original legacy module override dispatch.
                    module.DeleteSession(slot);
#pragma warning restore CS0618
                }

            var path = services.GetSaveFilePath(null);
            var filename = GetFilename(slot);
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path, filename + "-modsave-*.celeste");
                for (var i = 0; i < files.Length; i++)
                {
                    var name = Path.GetFileNameWithoutExtension(files[i]);
                    diagnostics.Logger.Log(EverestLogLevel.Info, "SaveData",
                        "Save slot " + filename + " has modsave " + name + " which was not cleaned, deleting file");
                    services.Delete(name);
                }

                files = Directory.GetFiles(path, filename + "-modsession-*.celeste");
                for (var i = 0; i < files.Length; i++)
                {
                    var name = Path.GetFileNameWithoutExtension(files[i]);
                    diagnostics.Logger.Log(EverestLogLevel.Info, "SaveData",
                        "Save slot " + filename + " has modsession " + name + " which was not cleaned, deleting file");
                    services.Delete(name);
                }
            }

            LoadedModSaveDataIndex = int.MinValue;
            var sidecar = filename + "-modsavedata";
            return services.Exists(sidecar) ? services.Delete(sidecar) : true;
        }
    }
}
