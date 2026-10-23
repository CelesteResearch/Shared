using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Content.Sources;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Startup;
using MAB.DotIgnore;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        public void LoadZip(string archive)
        {
            if (!File.Exists(archive)) archive = Path.Combine(PathMods, archive);

            if (!File.Exists(archive))
            {
                ((IEverestSplashEnvironment)sourceEngine).Splash.IncreaseLoadedModCount(null);
                return;
            }

            var text = "loader";
            var tag = text;
            bool shouldLog;
            var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Verbose);
            if (sourceLog1.ShouldLog) sourceLog1.Write("Loading mod .zip: " + archive);
            EverestModuleMetadata[] array = null;
            IgnoreList ignore = null;
            var flag = false;
            using (var zipArchive = ZipFile.OpenRead(archive))
            {
                foreach (var entry in zipArchive.Entries)
                {
                    text = entry.FullName;
                    shouldLog = text == "everest.yaml" || text == "everest.yml" ? true : false;
                    if (shouldLog)
                    {
                        if (flag)
                        {
                            text = "loader";
                            var tag2 = text;
                            var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Warn);
                            if (sourceLog2.ShouldLog)
                                sourceLog2.Write(archive + " has both everest.yaml and everest.yml. Ignoring " +
                                                 entry.FullName + ".");
                            continue;
                        }

                        using (var stream = entry.Open())
                        {
                            using var streamReader = new StreamReader(stream);
                            try
                            {
                                if (!streamReader.EndOfStream)
                                {
                                    array = ((IEverestYamlEnvironment)sourceEngine).Yaml.Deserializer
                                        .Deserialize<EverestModuleMetadata[]>(streamReader);
                                    var array2 = array;
                                    foreach (var obj in array2)
                                    {
                                        obj.PathArchive = archive;
                                        obj.PostParse(((IEverestCoreModuleEnvironment)sourceEngine).CoreModule
                                            .Metadata);
                                    }
                                }
                            }
                            catch (Exception value)
                            {
                                text = "loader";
                                var tag3 = text;
                                var sourceLog3 = Logger.BeginEnabledMessage(tag3, EverestLogLevel.Warn);
                                if (sourceLog3.ShouldLog)
                                    sourceLog3.Write("Failed parsing " + entry.FullName + " in " + archive + ": " +
                                                     value);
                                FilesWithMetadataLoadFailures.Add(archive);
                            }
                        }

                        flag = true;
                    }
                    else
                    {
                        if (!(entry.FullName == ".everestignore")) continue;

                        var list = new List<string>();
                        using (var stream2 = entry.Open())
                        {
                            using var streamReader2 = new StreamReader(stream2);
                            while (!streamReader2.EndOfStream) list.Add(streamReader2.ReadLine());
                        }

                        ignore = new(list);
                    }
                }
            }

            var contentMeta =
                new ZipContentSource(((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry,
                    ((IEverestLoaderContentEnvironment)sourceEngine).ContentDiagnostics, archive);
            EverestModuleMetadata contentMetaParent = null;
            contentMeta.Ignore = ignore;
            Action callback = delegate
            {
                if (contentMeta != null)
                {
                    if (contentMetaParent != null)
                    {
                        contentMeta.Mod = contentMetaParent;
                        contentMeta.Name = contentMetaParent.Name;
                    }

                    OnCrawlMod?.Invoke(archive, contentMetaParent);
                    ((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry.Crawl(contentMeta);
                    contentMeta = null;
                }
            };
            if (array != null)
            {
                ((IEverestSplashEnvironment)sourceEngine).Splash.IncreaseTotalModCount(array.Length - 1);
                var array2 = array;
                foreach (var everestModuleMetadata in array2)
                {
                    everestModuleMetadata.Multimeta = array;
                    if (contentMetaParent == null) contentMetaParent = everestModuleMetadata;

                    LoadModDelayed(everestModuleMetadata, callback);
                }
            }
            else
            {
                var everestModuleMetadata2 = new EverestModuleMetadata
                {
                    Name = "_zip_" + Path.GetFileNameWithoutExtension(archive),
                    VersionString = "0.0.0-dummy",
                    PathArchive = archive,
                };
                everestModuleMetadata2.PostParse(((IEverestCoreModuleEnvironment)sourceEngine).CoreModule.Metadata);
                contentMetaParent = everestModuleMetadata2;
                LoadModDelayed(everestModuleMetadata2, callback);
            }
        }

        public void LoadDir(string dir)
        {
            if (!Directory.Exists(dir)) dir = Path.Combine(PathMods, dir);

            if (!Directory.Exists(dir))
            {
                ((IEverestSplashEnvironment)sourceEngine).Splash.IncreaseLoadedModCount(null);
                return;
            }

            var text = "loader";
            var tag = text;
            var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Verbose);
            if (sourceLog1.ShouldLog) sourceLog1.Write("Loading mod directory: " + dir);
            EverestModuleMetadata[] array = null;
            var path = Path.Combine(dir, "everest.yaml");
            if (!File.Exists(path))
            {
                path = Path.Combine(dir, "everest.yml");
            }
            else if (File.Exists(Path.Combine(dir, "everest.yml")))
            {
                text = "loader";
                var tag2 = text;
                var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Warn);
                if (sourceLog2.ShouldLog)
                    sourceLog2.Write(dir + " has both everest.yaml and everest.yml. Ignoring everest.yml.");
            }

            if (File.Exists(path))
            {
                using var streamReader = new StreamReader(path);
                try
                {
                    if (!streamReader.EndOfStream)
                    {
                        array = ((IEverestYamlEnvironment)sourceEngine).Yaml.Deserializer
                            .Deserialize<EverestModuleMetadata[]>(streamReader);
                        var array2 = array;
                        foreach (var obj in array2)
                        {
                            obj.PathDirectory = dir;
                            obj.PostParse(((IEverestCoreModuleEnvironment)sourceEngine).CoreModule.Metadata);
                        }
                    }
                }
                catch (Exception value)
                {
                    text = "loader";
                    var tag3 = text;
                    var sourceLog3 = Logger.BeginEnabledMessage(tag3, EverestLogLevel.Warn);
                    if (sourceLog3.ShouldLog)
                        sourceLog3.Write("Failed parsing everest.yaml in " + dir + ": " + value);
                    FilesWithMetadataLoadFailures.Add(dir);
                }
            }

            var contentMeta = new FileSystemContentSource(
                ((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry,
                ((IEverestLoaderContentEnvironment)sourceEngine).ContentDiagnostics,
                ((IEverestLoaderContentEnvironment)sourceEngine).QueuedTasks, dir);
            EverestModuleMetadata contentMetaParent = null;
            var text2 = Path.Combine(dir, ".everestignore");
            if (File.Exists(text2)) contentMeta.Ignore = new(text2);

            Action callback = delegate
            {
                if (contentMeta != null)
                {
                    if (contentMetaParent != null)
                    {
                        contentMeta.Mod = contentMetaParent;
                        contentMeta.Name = contentMetaParent.Name;
                    }

                    OnCrawlMod?.Invoke(dir, contentMetaParent);
                    ((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry.Crawl(contentMeta);
                    contentMeta = null;
                }
            };
            if (array != null)
            {
                ((IEverestSplashEnvironment)sourceEngine).Splash.IncreaseTotalModCount(array.Length - 1);
                var array2 = array;
                foreach (var everestModuleMetadata in array2)
                {
                    everestModuleMetadata.Multimeta = array;
                    if (contentMetaParent == null) contentMetaParent = everestModuleMetadata;

                    LoadModDelayed(everestModuleMetadata, callback);
                }
            }
            else
            {
                var everestModuleMetadata2 = new EverestModuleMetadata
                {
                    Name = "_dir_" + Path.GetFileName(dir),
                    VersionString = "0.0.0-dummy",
                    PathDirectory = dir,
                };
                everestModuleMetadata2.PostParse(((IEverestCoreModuleEnvironment)sourceEngine).CoreModule.Metadata);
                contentMetaParent = everestModuleMetadata2;
                LoadModDelayed(everestModuleMetadata2, callback);
            }
        }
    }
}
