using System;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;

namespace Celeste.Everest.Modules.Settings
{
    public sealed class EverestModuleSettingsStore
    {
        private static readonly ISerializer yamlWriter = new SerializerBuilder()
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.Preserve).Build();

        public string SavesDirectory { get; }
        public string EverestDirectory { get; }
        public Action<string, Exception> Error { get; set; }

        // EverestDirectory is the original PathEverest, containing ModSettings-OBSOLETE.
        public EverestModuleSettingsStore(string savesDirectory, string everestDirectory)
        {
            SavesDirectory =
                Path.GetFullPath(savesDirectory ?? throw new ArgumentNullException(nameof(savesDirectory)));
            EverestDirectory =
                Path.GetFullPath(everestDirectory ?? throw new ArgumentNullException(nameof(everestDirectory)));
        }

        public string FilePath(string moduleName)
        {
            return Path.Combine(SavesDirectory,
                "modsettings-" + RequireName(moduleName) + ".celeste");
        }

        public string LegacyFilePath(string moduleName)
        {
            return Path.Combine(EverestDirectory,
                "ModSettings-OBSOLETE", RequireName(moduleName) + ".yaml");
        }

        public bool Load(string moduleName, object settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var path = FilePath(moduleName);
            if (!File.Exists(path)) path = LegacyFilePath(moduleName);
            if (!File.Exists(path)) return false;
            try
            {
                using (var stream = File.OpenRead(path))
                {
                    if (settings is IEverestBinarySettings binary)
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            binary.Read(reader);
                        }
                    }
                    else
                    {
                        var factory = new DefaultObjectFactory();
                        var rootType = settings.GetType();
                        var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties()
                            .WithObjectFactory(type => type == rootType ? settings : factory.Create(type)).Build();
                        using (var reader = new StreamReader(stream))
                        {
                            deserializer.Deserialize(reader, rootType);
                        }
                    }
                }

                return true;
            }
            catch (Exception error)
            {
                Error?.Invoke(moduleName, error);
                return false;
            }
        }

        public bool Save(string moduleName, object settings, bool flushToDisk = false)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var path = FilePath(moduleName);
            // Everest deletes the old file before recreating it, including when the
            // subsequent serialization fails. Keep that observable behavior.
            if (File.Exists(path)) File.Delete(path);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            try
            {
                using (var stream = File.OpenWrite(path))
                {
                    if (settings is IEverestBinarySettings binary)
                        using (var writer = new BinaryWriter(stream))
                        {
                            binary.Write(writer);
                            if (flushToDisk)
                            {
                                writer.Flush();
                                stream.Flush(true);
                            }
                        }
                    else
                        using (var writer = new StreamWriter(stream))
                        {
                            yamlWriter.Serialize(writer, settings, settings.GetType());
                            if (flushToDisk)
                            {
                                writer.Flush();
                                stream.Flush(true);
                            }
                        }
                }

                return true;
            }
            catch (Exception error)
            {
                Error?.Invoke(moduleName, error);
                return false;
            }
        }

        // A partial port of CoreModuleSettings must not erase newer Everest keys.
        // Merge only fields actually implemented by the supplied settings object.
        public bool SavePreservingUnknown(string moduleName, object settings, bool flushToDisk = false)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var path = FilePath(moduleName);
            if (!File.Exists(path)) return Save(moduleName, settings, flushToDisk);
            var temporary = path + ".merge-pending";
            try
            {
                var current = new YamlStream();
                using (var reader = File.OpenText(path))
                {
                    current.Load(reader);
                }

                var known = new YamlStream();
                using (var reader = new StringReader(yamlWriter.Serialize(settings, settings.GetType())))
                {
                    known.Load(reader);
                }

                if (current.Documents.Count != 1 || known.Documents.Count != 1 ||
                    !(current.Documents[0].RootNode is YamlMappingNode existing) ||
                    !(known.Documents[0].RootNode is YamlMappingNode replacement))
                    throw new InvalidDataException("Core settings YAML must be one mapping document.");
                foreach (var pair in replacement.Children)
                    existing.Children[pair.Key] = pair.Value;
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (var stream = new FileStream(temporary, FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(stream))
                {
                    current.Save(writer, false);
                    if (flushToDisk)
                    {
                        writer.Flush();
                        stream.Flush(true);
                    }
                }

                File.Replace(temporary, path, null);
                return true;
            }
            catch (Exception error)
            {
                Error?.Invoke(moduleName, error);
                return false;
            }
            finally
            {
                if (File.Exists(temporary)) File.Delete(temporary);
            }
        }

        private static string RequireName(string moduleName)
        {
            return string.IsNullOrEmpty(moduleName)
                ? throw new ArgumentException("Module metadata name is required.", nameof(moduleName))
                : moduleName;
        }
    }
}
