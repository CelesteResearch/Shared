using System;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.Storage;

namespace Celeste.Game.Save.Persistence
{
    // Immutable data captured on the simulation frame. USER_IO executes the
    // original Everest order: optional mod sidecar, modules, then main/settings.
    public sealed class FileSaveWriteOrder
    {
        public readonly byte[] ModData;
        public readonly Action ModuleWrites;
        public readonly bool FlushToDisk;
        public readonly Action<Exception> ReportModError;

        public FileSaveWriteOrder(byte[] modData, Action moduleWrites, bool flushToDisk,
            Action<Exception> reportModError = null)
        {
            ModData = modData == null ? null : (byte[])modData.Clone();
            ModuleWrites = moduleWrites;
            FlushToDisk = flushToDisk;
            ReportModError = reportModError;
        }

        public void Write(FileSaveStorage storage, string filename, byte[] progress, byte[] settings,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions,
            IOriginalSaveAllocationPolicy allocation)
        {
            storage.TryWriteModData(filename, ModData, FlushToDisk, ReportModError);
            ModuleWrites?.Invoke();
            storage.Write(filename, progress, areaKeys, sessions, allocation, settings, FlushToDisk);
        }
    }
}
