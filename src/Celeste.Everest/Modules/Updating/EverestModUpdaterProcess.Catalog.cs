using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        public event Action<Dictionary<string, EverestModUpdateInfo>> OnDownloadModUpdateListCompleted;

        public Dictionary<string, EverestModUpdateInfo> DownloadModUpdateList()
        {
            Dictionary<string, EverestModUpdateInfo> result = null;
            try
            {
                string url = GetModUpdaterDatabaseUrl("modupdater");
                var message =
                    ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                        EverestLogLevel.Verbose);
                if (message.ShouldLog) message.Write("Downloading last versions list from " + url);
                using var client = ((IEverestCompressedHttpEnvironment)engine).CompressedHttp.CreateClient();
                string text = client.GetStringAsync(url).Result;
                result = ((IEverestYamlEnvironment)engine).Yaml.Deserializer
                    .Deserialize<Dictionary<string, EverestModUpdateInfo>>(text);
                foreach (string key in result.Keys) result[key].Name = key;
                message = ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                    EverestLogLevel.Verbose);
                if (message.ShouldLog) message.Write("Downloaded " + result.Count + " item(s)");
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Warn, "ModUpdaterHelper",
                    "Downloading database failed!");
                ((IEverestLoggerProcessEnvironment)engine).Logger.LogDetailed(e);
            }

            OnDownloadModUpdateListCompleted?.Invoke(result);
            return result;
        }

        public SortedDictionary<EverestModUpdateInfo, EverestModuleMetadata> ListAvailableUpdates(
            Dictionary<string, EverestModUpdateInfo> updateCatalog, bool excludeBlacklist)
        {
            var result =
                new SortedDictionary<EverestModUpdateInfo, EverestModuleMetadata>(new MostRecentUpdatedFirst());
            ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Verbose, "ModUpdaterHelper",
                "Checking for updates");
            foreach (SourceEverestModule module in ((ISourceEverestModulesEnvironment)engine).Modules)
            {
                EverestModuleMetadata metadata = module.Metadata;
                if (metadata.PathArchive != null && updateCatalog.ContainsKey(metadata.Name)
                                                 && (!excludeBlacklist || !((IEverestLoaderProcessEnvironment)engine)
                                                     .Loader
                                                     .UpdaterBlacklist.Any(path =>
                                                         Path.Combine(
                                                             ((IEverestLoaderProcessEnvironment)engine).Loader.PathMods,
                                                             path) == metadata.PathArchive)))
                {
                    string hash = BitConverter.ToString(metadata.Hash).Replace("-", "").ToLowerInvariant();
                    var message =
                        ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                            EverestLogLevel.Verbose);
                    if (message.ShouldLog)
                        message.Write("Mod " + metadata.Name + ": installed hash " + hash + ", latest hash(es) " +
                                      string.Join(", ", updateCatalog[metadata.Name].xxHash));
                    if (!updateCatalog[metadata.Name].xxHash.Contains(hash))
                        result[updateCatalog[metadata.Name]] = metadata;
                }
            }

            var summary =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                    EverestLogLevel.Verbose);
            if (summary.ShouldLog) summary.Write(result.Count + " update(s) available");
            return result;
        }

        private string GetModUpdaterDatabaseUrl(string database)
        {
            if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.UseAPIMirror)
            {
                if (database == "modupdater")
                {
                    var message =
                        ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                            EverestLogLevel.Info);
                    if (message.ShouldLog) message.Write("Using mirror for " + database + " database");
                    return "https://everestapi.github.io/updatermirror/everest_update.yaml";
                }

                if (database == "modgraph")
                {
                    var message =
                        ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                            EverestLogLevel.Info);
                    if (message.ShouldLog) message.Write("Using mirror for " + database + " database");
                    return "https://everestapi.github.io/updatermirror/mod_dependency_graph.yaml";
                }
            }

            using var client = ((IEverestCompressedHttpEnvironment)engine).CompressedHttp.CreateClient();
            var fetching =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                    EverestLogLevel.Verbose);
            if (fetching.ShouldLog) fetching.Write("Fetching " + database + " database URL");
            return client.GetStringAsync("https://everestapi.github.io/" + database + ".txt").Result.Trim();
        }

        public void TryDelete(string path)
        {
            if (!File.Exists(path)) return;
            try
            {
                var message =
                    ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                        EverestLogLevel.Verbose);
                if (message.ShouldLog) message.Write("Deleting file " + path);
                File.Delete(path);
            }
            catch (Exception)
            {
                var message =
                    ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                        EverestLogLevel.Warn);
                if (message.ShouldLog) message.Write("Removing " + path + " failed");
            }
        }
    }
}
