using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Core.Text;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Content.Archives;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Metadata
{
    public sealed class EverestInstalledModMetadataProcess
    {
        private readonly ISourceEngineContext engine;
        private EverestLoaderProcess Loader => ((IEverestLoaderProcessEnvironment)engine).Loader;
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;
        public EverestInstalledModMetadataProcess(ISourceEngineContext engine) => this.engine = engine;

        public Dictionary<string, EverestModuleMetadata[]> LoadAllModYamls(Action<float> progressCallback)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int num = 0;
            int num2 = Directory.GetFiles(Loader.PathMods).Length + Directory.GetDirectories(Loader.PathMods).Length;
            Dictionary<string, EverestModuleMetadata[]> dictionary = new Dictionary<string, EverestModuleMetadata[]>();
            IEnumerable<EverestModuleMetadata> source =
                ((ISourceEverestModulesEnvironment)engine).Modules.Select((SourceEverestModule module) =>
                    module.Metadata);
            string[] files = Directory.GetFiles(Loader.PathMods);
            int i;
            for (i = 0; i < files.Length; i++)
            {
                progressCallback((float)num / (float)num2);
                num++;
                string fileName = Path.GetFileName(files[i]);
                if (fileName.EndsWith(".zip"))
                {
                    EverestModuleMetadata[] array =
                        source.Where((EverestModuleMetadata meta) => meta.PathArchive == files[i]).ToArray();
                    if (array.Length == 0)
                    {
                        array = loadZip(Path.Combine(Loader.PathMods, fileName));
                    }

                    if (array != null)
                    {
                        dictionary[fileName] = array;
                    }
                }
            }

            files = Directory.GetDirectories(Loader.PathMods);
            int i2;
            for (i2 = 0; i2 < files.Length; i2++)
            {
                progressCallback((float)num / (float)num2);
                num++;
                string fileName2 = Path.GetFileName(files[i2]);
                if (!(fileName2 == "Cache"))
                {
                    EverestModuleMetadata[] array2 =
                        source.Where((EverestModuleMetadata meta) => meta.PathDirectory == files[i2]).ToArray();
                    if (array2.Length == 0)
                    {
                        array2 = loadDir(Path.Combine(Loader.PathMods, fileName2));
                    }

                    if (array2 != null)
                    {
                        dictionary[fileName2] = array2;
                    }
                }
            }

            stopwatch.Stop();
            string text = "OuiModToggler";
            bool shouldLog;
            SourceDefaultInterpolatedStringHandler str;
            shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
            str = shouldLog ? new SourceDefaultInterpolatedStringHandler(39, 2) : default;
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
                using ZipArchive zipArchive = ZipFile.OpenRead(archive);
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    if (entry.FullName == "metadata.yaml")
                    {
                        using (MemoryStream stream = entry.ExtractStream())
                        {
                            using StreamReader input = new StreamReader(stream);
                            EverestModuleMetadata everestModuleMetadata = ((IEverestYamlEnvironment)engine).Yaml
                                .Deserializer.Deserialize<EverestModuleMetadata>(input);
                            everestModuleMetadata.PathArchive = archive;
                            everestModuleMetadata.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule
                                .Metadata);
                            return new EverestModuleMetadata[1] { everestModuleMetadata };
                        }
                    }

                    if (!(entry.FullName == "multimetadata.yaml") && !(entry.FullName == "everest.yaml") &&
                        !(entry.FullName == "everest.yml"))
                    {
                        continue;
                    }

                    using MemoryStream stream2 = entry.ExtractStream();
                    using StreamReader streamReader = new StreamReader(stream2);
                    if (!streamReader.EndOfStream)
                    {
                        EverestModuleMetadata[] array =
                            ((IEverestYamlEnvironment)engine).Yaml.Deserializer.Deserialize<EverestModuleMetadata[]>(
                                streamReader);
                        EverestModuleMetadata[] array2 = array;
                        foreach (EverestModuleMetadata obj in array2)
                        {
                            obj.PathArchive = archive;
                            obj.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule.Metadata);
                        }

                        return array;
                    }
                }
            }
            catch (Exception value)
            {
                string text = "loader";
                bool shouldLog;
                SourceDefaultInterpolatedStringHandler str;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                str = shouldLog ? new SourceDefaultInterpolatedStringHandler(41, 2) : default;
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
                string path = Path.Combine(dir, "metadata.yaml");
                if (File.Exists(path))
                {
                    using StreamReader input = new StreamReader(path);
                    EverestModuleMetadata everestModuleMetadata =
                        ((IEverestYamlEnvironment)engine).Yaml.Deserializer.Deserialize<EverestModuleMetadata>(input);
                    everestModuleMetadata.PathDirectory = dir;
                    everestModuleMetadata.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule.Metadata);
                    return new EverestModuleMetadata[1] { everestModuleMetadata };
                }

                path = Path.Combine(dir, "multimetadata.yaml");
                if (!File.Exists(path))
                {
                    path = Path.Combine(dir, "everest.yaml");
                }

                if (!File.Exists(path))
                {
                    path = Path.Combine(dir, "everest.yml");
                }

                if (File.Exists(path))
                {
                    using StreamReader streamReader = new StreamReader(path);
                    if (!streamReader.EndOfStream)
                    {
                        EverestModuleMetadata[] array =
                            ((IEverestYamlEnvironment)engine).Yaml.Deserializer.Deserialize<EverestModuleMetadata[]>(
                                streamReader);
                        EverestModuleMetadata[] array2 = array;
                        foreach (EverestModuleMetadata obj in array2)
                        {
                            obj.PathDirectory = dir;
                            obj.PostParse(((IEverestCoreModuleEnvironment)engine).CoreModule.Metadata);
                        }

                        return array;
                    }
                }
            }
            catch (Exception value)
            {
                string text = "loader";
                bool shouldLog;
                SourceDefaultInterpolatedStringHandler str;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                str = shouldLog ? new SourceDefaultInterpolatedStringHandler(43, 2) : default;
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
