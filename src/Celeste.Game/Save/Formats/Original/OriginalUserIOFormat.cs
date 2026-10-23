using System;
using System.IO;
using System.Xml.Serialization;
using Celeste.Formats.Save.Serialization;
using Celeste.Formats.Settings;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Settings;

namespace Celeste.Game.Save.Formats.Original
{
// A CPU format boundary: source UserIO controls all storage/retry/thread phases.
    public sealed class OriginalUserIOFormat : IOriginalUserIOFormat
    {
        private readonly IOriginalUserIOFormatEnvironment environment;

        public OriginalUserIOFormat(IOriginalUserIOFormatEnvironment environment)
        {
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public byte[] Serialize<T>(T instance)
        {
            if (typeof(T) == typeof(OriginalSaveDataState))
            {
                using var saveStream = new MemoryStream();
                environment.SaveXmlFormat.CreateSerializer().Serialize(saveStream,
                    FileSaveCodec.ToWire((OriginalSaveDataState)(object)instance, environment.AreaKeys));
                return saveStream.ToArray();
            }

            if (typeof(T) == typeof(OriginalModSaveData))
            {
                using var modStream = new MemoryStream();
                FileModSaveCodec.Serialize(modStream,
                    FileSaveCodec.ToModWire((OriginalModSaveData)(object)instance, environment.AreaKeys));
                return modStream.ToArray();
            }

            if (typeof(T) == typeof(SettingsState))
            {
                var settings = (SettingsState)(object)instance;
                return FileSettingsCodec.Serialize(OriginalSettingsImporter.Export(settings, settings.LanguageId));
            }

            using var stream = new MemoryStream();
            new XmlSerializer(typeof(T)).Serialize(stream, instance);
            return stream.ToArray();
        }

        public bool ValidatePersisted<T>(Stream stream) where T : class
        {
            if (typeof(T) == typeof(OriginalSaveDataState))
                return environment.SaveXmlFormat.CreateSerializer().Deserialize(stream) != null;
            if (typeof(T) == typeof(OriginalModSaveData))
                return FileModSaveCodec.Deserialize(stream) != null;
            if (typeof(T) == typeof(SettingsState))
                return FileSettingsCodec.Deserialize(stream) != null;
            return Deserialize<T>(stream) != null;
        }

        public T Deserialize<T>(Stream stream) where T : class
        {
            if (typeof(T) == typeof(OriginalSaveDataState))
            {
                var wire = environment.SaveXmlFormat.CreateSerializer().Deserialize(stream);
                return (T)(object)FileSaveCodec.FromWire(wire, environment.AreaKeys, environment.Sessions,
                    environment.SaveAllocation);
            }

            if (typeof(T) == typeof(OriginalModSaveData))
            {
                var wire = FileModSaveCodec.Deserialize(stream);
                return (T)(object)FileSaveCodec.ReadModBackup(wire, environment.AreaKeys, environment.Sessions);
            }

            if (typeof(T) == typeof(SettingsState))
            {
                var wire = FileSettingsCodec.Deserialize(stream);
                var settings = environment.SettingsAllocation.Create();
                OriginalSettingsImporter.Import(wire, settings);
                return (T)(object)settings;
            }

            return (T)new XmlSerializer(typeof(T)).Deserialize(stream);
        }
    }
}
