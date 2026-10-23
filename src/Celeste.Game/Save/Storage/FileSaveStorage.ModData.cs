using Celeste.Game.Save.Data;
using Celeste.Game.Save.Formats.Original;
using Celeste.Formats.Save.Serialization;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using Celeste.Formats.Settings;
using System;
using System.IO;

namespace Celeste.Game.Save.Storage
{
    public sealed partial class FileSaveStorage
    {
        public string ModDataPath(string filename) => Path.Combine(DirectoryPath, filename + "-modsavedata.celeste");

        // Decode only. Installed backup restore belongs to actual AfterInitialize,
        // where its lists and session are transferred to this same save object.
        public OriginalSaveDataState Load(string filename,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys,
            global::Celeste.Game.Execution.Session.OriginalSessionFactory sessions,
            global::Celeste.Game.Save.Runtime.IOriginalSaveAllocationPolicy allocation,
            Action<Exception> reportError = null)
        {
            var bytes = Read(filename);
            if (bytes == null) return null;
            return FileSaveCodec.Deserialize(bytes, areaKeys, sessions, allocation);
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
                string path = ModDataPath(filename);
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
