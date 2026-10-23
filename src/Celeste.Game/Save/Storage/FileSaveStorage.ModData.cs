using System;
using System.IO;
using Celeste.Formats.Save.Serialization;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Formats.Original;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Storage
{
    public sealed partial class FileSaveStorage
    {
        public string ModDataPath(string filename)
        {
            return Path.Combine(DirectoryPath, filename + "-modsavedata.celeste");
        }

        // Decode only. Installed backup restore belongs to actual AfterInitialize,
        // where its lists and session are transferred to this same save object.
        public OriginalSaveDataState Load(string filename,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions,
            IOriginalSaveAllocationPolicy allocation,
            Action<Exception> reportError = null)
        {
            var bytes = Read(filename);
            return bytes == null ? null : FileSaveCodec.Deserialize(bytes, areaKeys, sessions, allocation);
        }

        // Original SaveThread ignores Save<ModSaveData>'s boolean and continues
        // with module writes, then the main/settings SaveThread. Report failure,
        // but don't turn sidecar failure into a false main SavingResult.
        public bool TryWriteModData(string filename, byte[] data, bool flushToDisk = true,
            Action<Exception> reportError = null)
        {
            if (data == null) return true;
            try
            {
                WriteVerified(filename + "-modsavedata", data, FileModSaveCodec.Deserialize, flushToDisk);
                return true;
            }
            catch (Exception error)
            {
                reportError?.Invoke(error);
                return false;
            }
        }

        public bool TryDeleteModData(string filename)
        {
            try
            {
                var path = ModDataPath(filename);
                if (File.Exists(path)) File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
