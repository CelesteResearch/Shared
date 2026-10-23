using System;
using System.IO;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Save.IO;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Threading;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed class EverestUserIOStorage : OriginalUserIOStorage
    {
        private readonly IEverestLoggerEnvironment coreSettings;
        private readonly ISourceEverestMainThreadEnvironment mainThread;

        public EverestUserIOStorage(IOriginalUserIOFormat format, IOriginalGameErrorIdentity actualGame,
            string savePath, string backupPath, IEverestLoggerEnvironment coreSettings,
            ISourceEverestMainThreadEnvironment mainThread)
            : base(format, actualGame, savePath, backupPath)
        {
            this.coreSettings = coreSettings;
            this.mainThread = mainThread;
        }

        public override bool Save<T>(string path, byte[] data)
        {
            string handle = GetHandle(path);
            bool success = false;
            try
            {
                string backupHandle = GetBackupHandle(path);
                DirectoryInfo directory = new FileInfo(handle).Directory;
                if (!directory.Exists) directory.Create();
                directory = new FileInfo(backupHandle).Directory;
                if (!directory.Exists) directory.Create();
                using (FileStream stream = File.Open(backupHandle, FileMode.Create, FileAccess.Write))
                    SaveAndFlush(stream, data, 0, data.Length);
                if (ValidateBackup<T>(path))
                {
                    using (FileStream stream = File.Open(handle, FileMode.Create, FileAccess.Write))
                        SaveAndFlush(stream, data, 0, data.Length);
                    success = true;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR: " + error.ToString());
                OriginalGameErrorLog.Write(error, actualGame);
            }

            if (!success) Console.WriteLine("Save Failed");
            return success;
        }

        private void SaveAndFlush(FileStream stream, byte[] data, int offset, int count)
        {
            stream.Write(data, offset, count);
            if (coreSettings.Settings.SaveDataFlush.GetValueOrDefault(true) &&
                !mainThread.MainThreadProcess.IsMainThread)
                stream.Flush(true);
        }
    }
}
