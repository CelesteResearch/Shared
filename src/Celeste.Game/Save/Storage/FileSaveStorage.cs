using System;
using System.Collections.Generic;
using System.IO;
using Celeste.Formats.Settings;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Formats.Original;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Storage
{
    // UserIO persistence: write backup, deserialize it, then overwrite the primary.
    // Thread scheduling belongs to the host's USER_IO worker, not this codec.
    public sealed partial class FileSaveStorage
    {
        public string DirectoryPath { get; }
        public string BackupDirectoryPath { get; }

        public FileSaveStorage(string directory, string backupDirectory = null)
        {
            DirectoryPath = Path.GetFullPath(directory);
            BackupDirectoryPath =
                Path.GetFullPath(backupDirectory ?? Path.Combine(Path.GetDirectoryName(DirectoryPath), "Backups"));
        }

        public string SlotPath(string filename)
        {
            return Path.Combine(DirectoryPath, filename + ".celeste");
        }

        public int GetSlotCount()
        {
            var maximum = 1;
            if (Directory.Exists(DirectoryPath))
                foreach (var file in Directory.GetFiles(DirectoryPath, "*.celeste"))
                    if (int.TryParse(Path.GetFileNameWithoutExtension(file), out var slot))
                        maximum = Math.Max(maximum, slot);
            return maximum + 2;
        }

        public bool Exists(string filename)
        {
            return File.Exists(SlotPath(filename));
        }

        public byte[] Read(string filename)
        {
            return Exists(filename) ? File.ReadAllBytes(SlotPath(filename)) : null;
        }

        public byte[] ReadSettings()
        {
            var path = Path.Combine(DirectoryPath, "settings.celeste");
            return File.Exists(path) ? File.ReadAllBytes(path) : null;
        }

        public void Write(string filename, byte[] file,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions,
            IOriginalSaveAllocationPolicy allocation,
            byte[] settings = null, bool flushToDisk = true)
        {
            var errors = new List<Exception>();
            // Original SaveThread uses &=, so a failed main save does not skip settings.
            if (file != null)
                try
                {
                    WriteVerified(filename, file,
                        bytes => FileSaveCodec.Deserialize(bytes, areaKeys, sessions, allocation), flushToDisk);
                }
                catch (Exception error)
                {
                    errors.Add(error);
                }

            if (settings != null)
                try
                {
                    WriteVerified("settings", settings, bytes => FileSettingsCodec.Deserialize(bytes), flushToDisk);
                }
                catch (Exception error)
                {
                    errors.Add(error);
                }

            if (errors.Count != 0) throw new AggregateException("One or more save files could not be written.", errors);
        }

        public bool TryDelete(string filename)
        {
            try
            {
                var path = SlotPath(filename);
                if (!File.Exists(path)) return false;
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void WriteVerified<T>(string name, byte[] data, Func<byte[], T> deserialize, bool flushToDisk)
            where T : class
        {
            Directory.CreateDirectory(DirectoryPath);
            Directory.CreateDirectory(BackupDirectoryPath);
            var backup = Path.Combine(BackupDirectoryPath, name + ".celeste");
            WriteFile(backup, data, flushToDisk);
            if (deserialize(File.ReadAllBytes(backup)) == null)
                throw new InvalidDataException("The backup could not be loaded: " + name);
            WriteFile(Path.Combine(DirectoryPath, name + ".celeste"), data, flushToDisk);
        }

        private static void WriteFile(string path, byte[] data, bool flushToDisk)
        {
            using (var stream = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                stream.Write(data, 0, data.Length);
                if (flushToDisk) stream.Flush(true);
            }
        }
    }
}
