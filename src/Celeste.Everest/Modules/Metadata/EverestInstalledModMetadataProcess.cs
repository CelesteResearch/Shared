using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Core.Text;
using Celeste.Everest.Content.Archives;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;

namespace Celeste.Everest.Modules.Metadata
{
    public sealed class EverestInstalledModMetadataProcess
    {
        private readonly ISourceEngineContext engine;
        private EverestLoaderProcess Loader => ((IEverestLoaderProcessEnvironment)engine).Loader;
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;

        // ReSharper disable once ConvertToPrimaryConstructor
        public EverestInstalledModMetadataProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public Dictionary<string, EverestModuleMetadata[]> LoadAllModYamls(Action<float> progressCallback)
        {
            var stopwatch = Stopwatch.StartNew();
            var num = 0;
            var num2 = Directory.GetFiles(Loader.PathMods).Length + Directory.GetDirectories(Loader.PathMods).Length;
            var dictionary = new Dictionary<string, EverestModuleMetadata[]>();
            var source =
                ((ISourceEverestModulesEnvironment)engine).Modules.Select(module =>
                    module.Metadata);
            var files = Directory.GetFiles(Loader.PathMods);
            int i;
            for (i = 0; i < files.Length; i++)
            {
                progressCallback(num / (float)num2);
                num++;
                var fileName = Path.GetFileName(files[i]);
                if (!fileName.EndsWith(".zip")) continue;
                // ReSharper disable once PossibleMultipleEnumeration
                var array =
                    source.Where(meta => meta.PathArchive == files[i]).ToArray();
                if (array.Length == 0) array = loadZip(Path.Combine(Loader.PathMods, fileName));

                if (array != null) dictionary[fileName] = array;
            }

            files = Directory.GetDirectories(Loader.PathMods);
            int i2;
            for (i2 = 0; i2 < files.Length; i2++)
            {
                progressCallback(num / (float)num2);
                num++;
                var fileName2 = Path.GetFileName(files[i2]);
                if (fileName2 == "Cache") continue;
                // ReSharper disable once PossibleMultipleEnumeration
                var array2 =
                    source.Where(meta => meta.PathDirectory == files[i2]).ToArray();
                if (array2.Length == 0) array2 = loadDir(Path.Combine(Loader.PathMods, fileName2));

                if (array2 != null) dictionary[fileName2] = array2;
            }

            stopwatch.Stop();
            const string text = "OuiModToggler";
            var shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
            var str = shouldLog ? new SourceDefaultInterpolatedStringHandler(39, 2) : default;
            if (shouldLog)
            {
                str.AppendLiteral("Found ");
                str.AppendFormatted(dictionary.Count);
                str.AppendLiteral(" mod(s) with yaml files, took ");
                str.AppendFormatted(stopwatch.ElapsedMilliseconds);
                str.AppendLiteral(" ms");
            }

            if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text, str.ToStringAndClear());
            return dictionary;
        }

        private EverestModuleMetadata[] loadZip(string archive)
        {
            try
            {
                using var zipArchive = ZipFile.OpenRead(archive);
                foreach (var entry in zipArchive.Entries)
                {
                    if (entry.FullName == "metadata.yaml")
                    {
                        using var stream = entry.ExtractStream();
                        using var input = new StreamReader(stream);
                        var everestModuleMetadata = ((IEverestYamlEnvironment)engine).Yaml
                            .Deserializer.Deserialize<EverestModuleMetadata>(input);
                        everestModuleMetadata.PathArchive = archive;
                        everestModuleMetadata.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule
                            .Metadata);
                        return [everestModuleMetadata];
                    }

                    if (entry.FullName != "multimetadata.yaml" && entry.FullName != "everest.yaml" &&
                        entry.FullName != "everest.yml")
                        continue;

                    using var stream2 = entry.ExtractStream();
                    using var streamReader = new StreamReader(stream2);
                    if (streamReader.EndOfStream) continue;
                    var array =
                        ((IEverestYamlEnvironment)engine).Yaml.Deserializer.Deserialize<EverestModuleMetadata[]>(
                            streamReader);
                    foreach (var obj in array)
                    {
                        obj.PathArchive = archive;
                        obj.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule.Metadata);
                    }

                    return array;
                }
            }
            catch (Exception value)
            {
                const string text = "loader";
                var shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                var str = shouldLog ? new SourceDefaultInterpolatedStringHandler(41, 2) : default;
                if (shouldLog)
                {
                    str.AppendLiteral("Failed loading everest.yaml in archive ");
                    str.AppendFormatted(archive);
                    str.AppendLiteral(": ");
                    str.AppendFormatted(value);
                }

                if (shouldLog) Logger.Log(EverestLogLevel.Warn, text, str.ToStringAndClear());
            }

            return null;
        }

        private EverestModuleMetadata[] loadDir(string dir)
        {
            try
            {
                var path = Path.Combine(dir, "metadata.yaml");
                if (File.Exists(path))
                {
                    using var input = new StreamReader(path);
                    var everestModuleMetadata =
                        ((IEverestYamlEnvironment)engine).Yaml.Deserializer.Deserialize<EverestModuleMetadata>(input);
                    everestModuleMetadata.PathDirectory = dir;
                    everestModuleMetadata.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule.Metadata);
                    return [everestModuleMetadata];
                }

                path = Path.Combine(dir, "multimetadata.yaml");
                if (!File.Exists(path)) path = Path.Combine(dir, "everest.yaml");

                if (!File.Exists(path)) path = Path.Combine(dir, "everest.yml");

                if (File.Exists(path))
                {
                    using var streamReader = new StreamReader(path);
                    if (streamReader.EndOfStream) return null;
                    var array =
                        ((IEverestYamlEnvironment)engine).Yaml.Deserializer.Deserialize<EverestModuleMetadata[]>(
                            streamReader);
                    foreach (var obj in array)
                    {
                        obj.PathDirectory = dir;
                        obj.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule.Metadata);
                    }

                    return array;
                }
            }
            catch (Exception value)
            {
                const string text = "loader";
                var shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                var str = shouldLog ? new SourceDefaultInterpolatedStringHandler(43, 2) : default;
                if (shouldLog)
                {
                    str.AppendLiteral("Failed loading everest.yaml in directory ");
                    str.AppendFormatted(dir);
                    str.AppendLiteral(": ");
                    str.AppendFormatted(value);
                }

                if (shouldLog) Logger.Log(EverestLogLevel.Warn, text, str.ToStringAndClear());
            }

            return null;
        }
    }
}
