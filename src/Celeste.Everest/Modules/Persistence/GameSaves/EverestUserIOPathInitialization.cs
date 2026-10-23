using System.IO;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Save.IO;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public static class EverestUserIOPathInitialization
    {
        public static OriginalUserIOStorage Create(IOriginalUserIOFormat format,
            IOriginalGameErrorIdentity actualGame, IEverestUserIOPathDevice device)
        {
            var storage = new OriginalUserIOStorage(format, actualGame, null, null);
            Initialize(storage, device);
            return storage;
        }

        public static void Initialize(OriginalUserIOStorage storage, IEverestUserIOPathDevice device)
        {
            storage.SavePath = GetSavePath("Saves", device);
            storage.BackupPath = GetSavePath("Backups", device);
        }

        public static string GetSavePath(string name, IEverestUserIOPathDevice device)
        {
            var path = device.GetEnvironmentVariable("EVEREST_SAVEPATH");
            if (!string.IsNullOrEmpty(path)) return Path.Combine(path, name);
            try
            {
                if (device.IsLinux)
                {
                    path = device.GetEnvironmentVariable("XDG_DATA_HOME");
                    if (!string.IsNullOrEmpty(path)) return Path.Combine(path, "Celeste/" + name);
                    path = device.GetEnvironmentVariable("HOME");
                    if (!string.IsNullOrEmpty(path)) return Path.Combine(path, ".local/share/Celeste/" + name);
                }
                else if (device.IsOSX)
                {
                    path = device.GetEnvironmentVariable("HOME");
                    if (!string.IsNullOrEmpty(path))
                        return Path.Combine(path, "Library/Application Support/Celeste/" + name);
                }

                return Path.Combine(device.ApplicationBaseDirectory, name);
            }
            catch
            {
                return Path.Combine(Path.GetDirectoryName(device.ExecutingAssemblyLocation), name);
            }
        }
    }
}
