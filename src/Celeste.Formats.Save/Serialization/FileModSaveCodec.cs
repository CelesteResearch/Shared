using System;
using System.IO;
using W = Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    // Everest's vanilla-overwrite recovery payload, separate from each module's
    // own -modsave / -modsession files. No map binding or gameplay callbacks here.
    public static class FileModSaveCodec
    {
        public static byte[] Serialize(W.SaveData save)
        {
            using var stream = new MemoryStream();
            Serialize(stream, save);
            return stream.ToArray();
        }

        public static void Serialize(Stream stream, W.SaveData save)
        {
            if (save == null) throw new ArgumentNullException(nameof(save));
            Serialize(stream, new W.ModSaveData
            {
                LevelSets = save.LevelSets, LevelSetRecycleBin = save.LevelSetRecycleBin,
                LastArea_Safe = save.LastArea_Safe, CurrentSession_Safe = save.CurrentSession_Safe,
            });
        }

        public static void Serialize(Stream stream, W.ModSaveData data)
        {
            SaveXmlWire.WriteDocument(stream, "ModSaveData", SaveXmlWire.WriteModSaveData("ModSaveData", data));
        }

        public static W.ModSaveData Deserialize(byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            using var stream = new MemoryStream(bytes, false);
            return Deserialize(stream);
        }

        public static W.ModSaveData Deserialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            try
            {
                return SaveXmlWire.ReadModSaveData(SaveXmlWire.ReadDocument(stream, "ModSaveData"), true);
            }
            catch (Exception error)
            {
                throw new InvalidOperationException("There is an error in the XML document.", error);
            }
        }

        public static bool NeedsRecovery(W.SaveData save)
        {
            return !save.HasModdedSaveData && (save.LevelSets?.Count ?? 0) <= 1 &&
                   (save.LevelSetRecycleBin?.Count ?? 0) == 0;
        }

        public static void Restore(W.SaveData save, W.ModSaveData data)
        {
            if (save == null) throw new ArgumentNullException(nameof(save));
            if (data == null) throw new ArgumentNullException(nameof(data));
            save.LevelSets = data.LevelSets;
            save.LevelSetRecycleBin = data.LevelSetRecycleBin;
            save.LastArea_Safe = data.LastArea_Safe;
            save.CurrentSession_Safe = data.CurrentSession_Safe;
        }
    }
}
