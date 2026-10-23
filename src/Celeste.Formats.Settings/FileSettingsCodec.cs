using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Celeste.Formats.Settings
{
    public static partial class FileSettingsCodec
    {
        private const string SchemaInstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        // The static codec needs no generated serializers or runtime type registration.
        public static void Prepare()
        {
        }

        public static byte[] Serialize(FileSettingsXml settings)
        {
            using var stream = new MemoryStream();
            Serialize(stream, settings);
            return stream.ToArray();
        }

        public static void Serialize(Stream stream, FileSettingsXml settings)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            using var writer = XmlWriter.Create(stream, new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false), Indent = true, CloseOutput = false,
            });
            WriteSettings(writer, settings);
        }

        public static FileSettingsXml Deserialize(byte[] bytes, bool fullscreenWhenMissing = true)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            using var stream = new MemoryStream(bytes, false);
            return Deserialize(stream, fullscreenWhenMissing);
        }

        public static FileSettingsXml Deserialize(Stream stream, bool fullscreenWhenMissing = true)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            using var reader = XmlReader.Create(stream, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Prohibit, XmlResolver = null, CloseInput = false,
            });
            var settings = ReadSettings(reader, out var fullscreenPresent);
            if (!fullscreenPresent) settings.Fullscreen = fullscreenWhenMissing;
            // The former XmlDocument.Load validated the complete input, including its tail.
            while (reader.Read())
            {
            }

            return settings;
        }
    }
}
