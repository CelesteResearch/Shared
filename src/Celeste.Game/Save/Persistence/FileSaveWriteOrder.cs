using Celeste.Game.Save.Storage;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using Celeste.Formats.Settings;
using System;

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
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys,
            global::Celeste.Game.Execution.Session.OriginalSessionFactory sessions,
            global::Celeste.Game.Save.Runtime.IOriginalSaveAllocationPolicy allocation)
        {
            storage.TryWriteModData(filename, ModData, FlushToDisk, ReportModError);
            ModuleWrites?.Invoke();
            storage.Write(filename, progress, areaKeys, sessions, allocation, settings, FlushToDisk);
        }
    }
}
