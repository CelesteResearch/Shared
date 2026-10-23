using System;
using System.Collections;
using System.IO;
using System.Threading;
using Celeste.Game.Execution.Threading;

namespace Celeste.Game.Save.IO
{
    public class OriginalUserIOStorage : global::Celeste.Game.Save.Runtime.IOriginalSaveDeletionServices
    {
        public enum Mode
        {
            Read,
            Write
        }

        public const string SaveDataTitle = "Celeste Save Data";

        public string SavePath;

        public string BackupPath;

        private const string Extension = ".celeste";

        private readonly IOriginalUserIOFormat format;
        protected readonly IOriginalGameErrorIdentity actualGame;
        private long fileMutationVersion;

        // Hosts can persist actual filesystem changes without observing save UI/routine timing.
        public long FileMutationVersion => Volatile.Read(ref fileMutationVersion);

        public OriginalUserIOStorage(IOriginalUserIOFormat format, IOriginalGameErrorIdentity actualGame,
            string savePath, string backupPath)
        {
            this.format = format;
            this.actualGame = actualGame;
            SavePath = savePath;
            BackupPath = backupPath;
        }

        protected string GetHandle(string name)
        {
            return Path.Combine(SavePath, name + ".celeste");
        }

        protected string GetBackupHandle(string name)
        {
            return Path.Combine(BackupPath, name + ".celeste");
        }

        public string GetSaveFilePath(string name)
        {
            if (!string.IsNullOrEmpty(name)) return GetHandle(name);
            return Path.GetDirectoryName(GetSaveFilePath("dummy"));
        }

        public bool Open(Mode mode)
        {
            return true;
        }

        public virtual bool Save<T>(string path, byte[] data) where T : class
        {
            string handle = GetHandle(path);
            bool flag = false;
            try
            {
                string backupHandle = GetBackupHandle(path);
                DirectoryInfo directory = new FileInfo(handle).Directory;
                if (!directory.Exists)
                {
                    directory.Create();
                    Interlocked.Increment(ref fileMutationVersion);
                }

                directory = new FileInfo(backupHandle).Directory;
                if (!directory.Exists)
                {
                    directory.Create();
                    Interlocked.Increment(ref fileMutationVersion);
                }

                using (FileStream fileStream = File.Open(backupHandle, FileMode.Create, FileAccess.Write))
                {
                    // Create has already created/truncated the backup, even if Write or Dispose later fails.
                    Interlocked.Increment(ref fileMutationVersion);
                    fileStream.Write(data, 0, data.Length);
                }

                if (ValidateBackup<T>(path))
                {
                    File.Copy(backupHandle, handle, overwrite: true);
                    Interlocked.Increment(ref fileMutationVersion);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                OriginalGameErrorLog.Write(ex, actualGame);
            }

            if (!flag)
            {
                Console.WriteLine("Save Failed");
            }

            return flag;
        }

        protected bool ValidateBackup<T>(string path) where T : class
        {
            try
            {
                var backupHandle = GetBackupHandle(path);
                if (File.Exists(backupHandle))
                {
                    using var stream = File.OpenRead(backupHandle);
                    return format.ValidatePersisted<T>(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                OriginalGameErrorLog.Write(ex, actualGame);
            }

            return false;
        }

        public T Load<T>(string path, bool backup = false) where T : class
        {
            string path2 = ((!backup) ? GetHandle(path) : GetBackupHandle(path));
            T result = null;
            try
            {
                if (File.Exists(path2))
                {
                    using (FileStream stream = File.OpenRead(path2))
                    {
                        result = Deserialize<T>(stream);
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                OriginalGameErrorLog.Write(ex, actualGame);
            }

            return result;
        }

        private T Deserialize<T>(Stream stream) where T : class
        {
            return format.Deserialize<T>(stream);
        }

        public bool Exists(string path)
        {
            return File.Exists(GetHandle(path));
        }

        public bool Delete(string path)
        {
            string handle = GetHandle(path);
            if (File.Exists(handle))
            {
                File.Delete(handle);
                Interlocked.Increment(ref fileMutationVersion);
                return true;
            }

            return false;
        }

        public void Close()
        {
        }

        public byte[] Serialize<T>(T instance) => format.Serialize(instance);
    }
}
