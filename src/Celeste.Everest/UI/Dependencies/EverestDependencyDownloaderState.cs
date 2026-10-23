using Celeste.Localization.Lookup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.Scheduling;
using Celeste.Core.Text;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Metadata;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Runtime;
using Celeste.Everest.UI.Progress;
using Celeste.Everest.UI.ModOptions;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.UI.Dependencies
{
    public class EverestDependencyDownloaderState : EverestLoggedProgressState
    {
        private EverestLoaderProcess Loader => ((IEverestLoaderProcessEnvironment)engine).Loader;
        private EverestModUpdaterProcess ModUpdater => ((IEverestModUpdaterEnvironment)engine).ModUpdater;
        private EverestUpdaterProcess Updater => ((IEverestUpdaterEnvironment)engine).Updater;
        private DialogCatalog Dialog => ((IOriginalGameTextEnvironment)engine).Text.Dialog;

        public EverestDependencyDownloaderState(ISourceEngineContext engine) : base(engine)
        {
        }

        private List<EverestModuleMetadata> MissingDependencies =>
            ((IEverestDependencyDownloadEnvironment)engine).DependencyDownloads.MissingDependencies;

        private bool shouldAutoExit;

        private bool shouldRestart;

        private EverestUpdateEntry everestVersionToInstall;

        private Task task;

        public override IEnumerator Enter(OuiState from)
        {
            Loader.AutoLoadNewMods = false;
            Loader.OnCrawlMod += logCrawlMod;
            Title = Dialog.Clean("DEPENDENCYDOWNLOADER_TITLE");
            task = new Task(downloadAllDependencies);
            Lines = new List<string>();
            Progress = 0;
            ProgressMax = 0;
            shouldAutoExit = true;
            shouldRestart = false;
            task.Start();
            return base.Enter(from);
        }

        public override IEnumerator Leave(OuiState next)
        {
            Loader.AutoLoadNewMods = true;
            Loader.OnCrawlMod -= logCrawlMod;
            return base.Leave(next);
        }

        private void logCrawlMod(string filePath, EverestModuleMetadata meta)
        {
            if (meta != null)
            {
                LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_LOADING_MOD"), meta.ToString(), filePath));
            }
            else
            {
                LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_LOADING_MOD_NOMETA"), filePath));
            }
        }

        private void downloadAllDependencies()
        {
            LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_DOWNLOADING_DATABASE"));
            EverestUpdateEntry entry = null;
            Dictionary<string, EverestModUpdateInfo> dictionary = ModUpdater.DownloadModUpdateList();
            if (dictionary == null)
            {
                shouldAutoExit = false;
                shouldRestart = false;
                LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_DOWNLOAD_DATABASE_FAILED"));
            }
            else
            {
                Dictionary<string, EverestModuleMetadata> dictionary2 = ModUpdater.DownloadModDependencyGraph();
                if (dictionary2 != null)
                {
                    addTransitiveDependencies(dictionary2);
                }

                LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_LOADING_INSTALLED_MODS"));
                Progress = 0;
                ProgressMax = 100;
                Dictionary<string, EverestModuleMetadata[]> dictionary3 =
                    ((IEverestInstalledModMetadataEnvironment)engine).InstalledModMetadata.LoadAllModYamls(
                        delegate(float progress)
                        {
                            Lines[Lines.Count - 1] =
                                $"{Dialog.Clean("DEPENDENCYDOWNLOADER_LOADING_INSTALLED_MODS")} ({(int)(progress * 100f)}%)";
                            Progress = (int)(progress * 100f);
                        });
                ProgressMax = 0;
                Dictionary<EverestModuleMetadata, string> dictionary4 = new Dictionary<EverestModuleMetadata, string>();
                foreach (KeyValuePair<string, EverestModuleMetadata[]> item in dictionary3)
                {
                    EverestModuleMetadata[] value = item.Value;
                    foreach (EverestModuleMetadata key in value)
                    {
                        dictionary4[key] = item.Key;
                    }
                }

                Lines[Lines.Count - 1] = Dialog.Clean("DEPENDENCYDOWNLOADER_LOADING_INSTALLED_MODS") + " " +
                                         Dialog.Clean("DEPENDENCYDOWNLOADER_DONE");
                Logger.Log(EverestLogLevel.Verbose, "OuiDependencyDownloader", "Computing dependencies to download...");
                Dictionary<string, EverestModUpdateInfo> dictionary5 = new Dictionary<string, EverestModUpdateInfo>();
                Dictionary<string, EverestModUpdateInfo> dictionary6 = new Dictionary<string, EverestModUpdateInfo>();
                Dictionary<string, EverestModuleMetadata> dictionary7 = new Dictionary<string, EverestModuleMetadata>();
                bool flag = false;
                HashSet<string> hashSet = new HashSet<string>();
                HashSet<string> hashSet2 = new HashSet<string>();
                HashSet<string> hashSet3 = new HashSet<string>();
                Dictionary<string, HashSet<Version>> dictionary8 = new Dictionary<string, HashSet<Version>>();
                Dictionary<string, string> dictionary9 = new Dictionary<string, string>();
                foreach (EverestModuleMetadata dependency in MissingDependencies)
                {
                    bool shouldLog;
                    if (Loader.Delayed.Any((Tuple<EverestModuleMetadata, Action> delayedMod) =>
                            dependency.Name == delayedMod.Item1.Name))
                    {
                        string text = "OuiDependencyDownloader";
                        string text2 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(43, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" is installed but load is delayed, skipping");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text2, str.ToStringAndClear());
                        continue;
                    }

                    if (dependency.Name == "Everest" || dependency.Name == "EverestCore")
                    {
                        Logger.Log(EverestLogLevel.Verbose, "OuiDependencyDownloader", "Everest should be updated");
                        shouldAutoExit = false;
                        if (dependency.Version.Major != 1 || dependency.Version.Build > 0 ||
                            dependency.Version.Revision > 0)
                        {
                            flag = true;
                        }
                        else if (!flag && (entry == null || entry.Build < dependency.Version.Minor))
                        {
                            entry = findEverestVersionToInstall(dependency.Version.Minor);
                            if (entry == null)
                            {
                                flag = true;
                            }
                        }

                        continue;
                    }

                    if (tryUnblacklist(dependency, dictionary4, hashSet3))
                    {
                        string text = "OuiDependencyDownloader";
                        string text3 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(52, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" is blacklisted, and should be unblacklisted instead");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text3, str.ToStringAndClear());
                        continue;
                    }

                    if (!dictionary.ContainsKey(dependency.Name))
                    {
                        string text = "OuiDependencyDownloader";
                        string text4 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(30, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" was not found in the database");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text4, str.ToStringAndClear());
                        hashSet.Add(dependency.Name);
                        shouldAutoExit = false;
                        continue;
                    }

                    if (dictionary[dependency.Name].xxHash.Count > 1)
                    {
                        string text = "OuiDependencyDownloader";
                        string text5 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(60, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" has multiple versions and cannot be installed automatically");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text5, str.ToStringAndClear());
                        hashSet2.Add(dependency.Name);
                        shouldAutoExit = false;
                        continue;
                    }

                    if (!isVersionCompatible(dependency.Version, dictionary[dependency.Name].Version))
                    {
                        string text = "OuiDependencyDownloader";
                        string text6 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(66, 3) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" has a version in database (");
                            str.AppendFormatted(dictionary[dependency.Name].Version);
                            str.AppendLiteral(") that would not satisfy dependency (");
                            str.AppendFormatted(dependency.Version);
                            str.AppendLiteral(")");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text6, str.ToStringAndClear());
                        HashSet<Version> value2;
                        HashSet<Version> hashSet4 = (dictionary8.TryGetValue(dependency.Name, out value2)
                            ? value2
                            : new HashSet<Version>());
                        hashSet4.Add(dependency.Version);
                        dictionary8[dependency.Name] = hashSet4;
                        dictionary9[dependency.Name] = dictionary[dependency.Name].Version;
                        shouldAutoExit = false;
                        continue;
                    }

                    EverestModuleMetadata everestModuleMetadata = null;
                    foreach (SourceEverestModule module in ((ISourceEverestModulesEnvironment)engine).Modules)
                    {
                        if (module.Metadata.PathArchive != null && module.Metadata.Name == dependency.Name)
                        {
                            everestModuleMetadata = module.Metadata;
                            break;
                        }
                    }

                    if (everestModuleMetadata != null)
                    {
                        string text = "OuiDependencyDownloader";
                        string text7 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(41, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" is already installed and will be updated");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text7, str.ToStringAndClear());
                        dictionary6[dependency.Name] = dictionary[dependency.Name];
                        dictionary7[dependency.Name] = everestModuleMetadata;
                    }
                    else
                    {
                        string text = "OuiDependencyDownloader";
                        string text8 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(18, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" will be installed");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text8, str.ToStringAndClear());
                        dictionary5[dependency.Name] = dictionary[dependency.Name];
                    }
                }

                foreach (EverestModUpdateInfo value3 in dictionary5.Values)
                {
                    downloadDependency(value3, null);
                }

                foreach (EverestModUpdateInfo value4 in dictionary6.Values)
                {
                    downloadDependency(value4, dictionary7[value4.Name]);
                }

                if (hashSet3.Count > 0)
                {
                    shouldRestart = true;
                    if (!unblacklistMods(hashSet3))
                    {
                        shouldAutoExit = false;
                    }
                }

                if (flag)
                {
                    LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_MUST_UPDATE_EVEREST"));
                }

                foreach (string item2 in hashSet)
                {
                    if (item2 == "Celeste")
                    {
                        LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_UPDATE_CELESTE"));
                    }
                    else
                    {
                        LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_MOD_NOT_FOUND"), item2));
                    }
                }

                foreach (string item3 in hashSet2)
                {
                    LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_MOD_NOT_AUTO_INSTALLABLE"), item3));
                }

                foreach (string key2 in dictionary8.Keys)
                {
                    LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_MOD_WRONG_VERSION"), key2,
                        string.Join(", ", dictionary8[key2]), dictionary9[key2]));
                }
            }

            Progress = 1;
            ProgressMax = 1;
            if (shouldAutoExit)
            {
                if (shouldRestart)
                {
                    LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_RESTARTING"));
                    for (int num2 = 3; num2 > 0; num2--)
                    {
                        Lines[Lines.Count - 1] = string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_RESTARTING_IN"), num2);
                        Thread.Sleep(1000);
                    }

                    Lines[Lines.Count - 1] = Dialog.Clean("DEPENDENCYDOWNLOADER_RESTARTING");
                    ((IEverestRestartEnvironment)engine).Restart.QuickFullRestart();
                }
                else
                {
                    Exit();
                }
            }
            else if (entry != null)
            {
                LogLine("\n" + string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_EVEREST_UPDATE"), entry.Build));
                everestVersionToInstall = entry;
            }
            else if (shouldRestart)
            {
                LogLine("\n" + Dialog.Clean("DEPENDENCYDOWNLOADER_PRESS_BACK_TO_RESTART"));
            }
            else
            {
                LogLine("\n" + Dialog.Clean("DEPENDENCYDOWNLOADER_PRESS_BACK_TO_GO_BACK"));
            }
        }

        private void addTransitiveDependencies(Dictionary<string, EverestModuleMetadata> modDependencyGraph)
        {
            List<EverestModuleMetadata> list = new List<EverestModuleMetadata>();
            do
            {
                Logger.Log(EverestLogLevel.Verbose, "OuiDependencyDownloader",
                    "Checking for transitive dependencies...");
                list.Clear();
                foreach (EverestModuleMetadata missingDependency in MissingDependencies)
                {
                    bool shouldLog;
                    if (!modDependencyGraph.TryGetValue(missingDependency.Name, out var value))
                    {
                        string text = "OuiDependencyDownloader";
                        string text2 = text;
                        SourceDefaultInterpolatedStringHandler str;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(27, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(missingDependency.Name);
                            str.AppendLiteral(" was not found in the graph");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text2, str.ToStringAndClear());
                        continue;
                    }

                    foreach (EverestModuleMetadata dependency in value.Dependencies)
                    {
                        string text;
                        SourceDefaultInterpolatedStringHandler str;
                        if (Loader.DependencyLoaded(dependency))
                        {
                            text = "OuiDependencyDownloader";
                            string text3 = text;
                            shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                            str = shouldLog ? new SourceDefaultInterpolatedStringHandler(10, 1) : default;
                            if (shouldLog)
                            {
                                str.AppendFormatted(dependency.Name);
                                str.AppendLiteral(" is loaded");
                            }

                            if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text3, str.ToStringAndClear());
                            continue;
                        }

                        if (MissingDependencies.Any((EverestModuleMetadata dep) => dep.Name == dependency.Name) ||
                            list.Any((EverestModuleMetadata dep) => dep.Name == dependency.Name))
                        {
                            text = "OuiDependencyDownloader";
                            string text4 = text;
                            shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                            str = shouldLog ? new SourceDefaultInterpolatedStringHandler(19, 1) : default;
                            if (shouldLog)
                            {
                                str.AppendFormatted(dependency.Name);
                                str.AppendLiteral(" is already missing");
                            }

                            if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text4, str.ToStringAndClear());
                            continue;
                        }

                        text = "OuiDependencyDownloader";
                        string text5 = text;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                        str = shouldLog ? new SourceDefaultInterpolatedStringHandler(39, 1) : default;
                        if (shouldLog)
                        {
                            str.AppendFormatted(dependency.Name);
                            str.AppendLiteral(" was added to the missing dependencies!");
                        }

                        if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text5, str.ToStringAndClear());
                        list.Add(dependency);
                    }
                }

                MissingDependencies.AddRange(list);
            } while (list.Count > 0);
        }

        private bool tryUnblacklist(EverestModuleMetadata dependency,
            Dictionary<EverestModuleMetadata, string> allModsInformation, HashSet<string> modsToUnblacklist)
        {
            KeyValuePair<EverestModuleMetadata, string> keyValuePair =
                default(KeyValuePair<EverestModuleMetadata, string>);
            foreach (KeyValuePair<EverestModuleMetadata, string> item in allModsInformation)
            {
                if (dependency.Name == item.Key.Name &&
                    (keyValuePair.Key == null || keyValuePair.Key.Version < item.Key.Version))
                {
                    keyValuePair = item;
                }
            }

            if (keyValuePair.Key == null || !Loader.Blacklist.Contains(keyValuePair.Value))
            {
                return false;
            }

            if (modsToUnblacklist.Contains(keyValuePair.Value))
            {
                return true;
            }

            modsToUnblacklist.Add(keyValuePair.Value);
            foreach (EverestModuleMetadata dependency2 in keyValuePair.Key.Dependencies)
            {
                if (!Loader.DependencyLoaded(dependency2))
                {
                    tryUnblacklist(dependency2, allModsInformation, modsToUnblacklist);
                }
            }

            return true;
        }

        private bool unblacklistMods(HashSet<string> modFilenamesToUnblacklist)
        {
            try
            {
                List<string> list = (from l in File.ReadAllLines(Loader.PathBlacklist)
                    select l.Trim()).ToList();
                HashSet<string> hashSet = new HashSet<string>(modFilenamesToUnblacklist);
                using (StreamWriter streamWriter = File.CreateText(Loader.PathBlacklist))
                {
                    foreach (string item in list)
                    {
                        if (modFilenamesToUnblacklist.Contains(item))
                        {
                            LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_MOD_UNBLACKLIST"), item));
                            streamWriter.WriteLine("# " + item);
                            hashSet.Remove(item);
                            Logger.Log(EverestLogLevel.Verbose, "OuiDependencyDownloader",
                                "Commented out line from blacklist.txt: " + item);
                        }
                        else
                        {
                            streamWriter.WriteLine(item);
                        }
                    }
                }

                if (hashSet.Count > 0)
                {
                    LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_UNBLACKLIST_FAILED"));
                    foreach (string item2 in hashSet)
                    {
                        Logger.Log(EverestLogLevel.Warn, "OuiDependencyDownloader",
                            "This mod could not be found in blacklist.txt: " + item2);
                    }

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_UNBLACKLIST_FAILED"));
                Logger.LogDetailed(e);
                return false;
            }
        }

        private bool isVersionCompatible(Version requiredVersion, string databaseVersionString)
        {
            Version installedVersion;
            try
            {
                installedVersion = new Version(databaseVersionString);
            }
            catch (Exception e)
            {
                string text = "OuiDependencyDownloader";
                bool shouldLog;
                SourceDefaultInterpolatedStringHandler str;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                str = shouldLog ? new SourceDefaultInterpolatedStringHandler(32, 1) : default;
                if (shouldLog)
                {
                    str.AppendLiteral("Could not parse version number: ");
                    str.AppendFormatted(databaseVersionString);
                }

                if (shouldLog) Logger.Log(EverestLogLevel.Warn, text, str.ToStringAndClear());
                Logger.LogDetailed(e);
                shouldLog = false;
                return shouldLog;
            }

            return EverestLoaderProcess.VersionSatisfiesDependency(requiredVersion, installedVersion);
        }

        private EverestUpdateEntry findEverestVersionToInstall(int requestedBuild)
        {
            EverestUpdatePriority updatePriority = EverestUpdatePriority.None;
            EverestUpdateEntry entry = null;
            foreach (EverestUpdateSource source in Updater.Sources)
            {
                if (source?.Entries == null ||
                    (source?.UpdatePriority ?? EverestUpdatePriority.Low) == EverestUpdatePriority.None)
                {
                    continue;
                }

                foreach (EverestUpdateEntry entry2 in source.Entries)
                {
                    if (entry2.Build >= requestedBuild && source.UpdatePriority >= updatePriority &&
                        (source.UpdatePriority != updatePriority || !(entry2.Build < entry?.Build)))
                    {
                        updatePriority = source.UpdatePriority;
                        entry = entry2;
                    }
                }
            }

            return entry;
        }

        private void downloadDependency(EverestModUpdateInfo mod, EverestModuleMetadata installedVersion)
        {
            string text = Path.Combine(((IEverestStartupRuntimeEnvironment)engine).EverestRuntime.PathTmp,
                "dependency-download.zip");
            try
            {
                Func<int, long, int, bool> progressCallback = delegate(int position, long length, int speed)
                {
                    if (length > 0)
                    {
                        Lines[Lines.Count - 1] =
                            $"{(int)Math.Floor(100.0 * ((double)position / (double)length))}% @ {speed} KiB/s";
                        Progress = position;
                        ProgressMax = (int)length;
                    }
                    else
                    {
                        Lines[Lines.Count - 1] = $"{(int)Math.Floor((double)position / 1000.0)}KiB @ {speed} KiB/s";
                        ProgressMax = 0;
                    }

                    return true;
                };
                Exception ex = null;
                foreach (string allMirrorUrl in ModUpdater.GetAllMirrorUrls(mod.URL))
                {
                    try
                    {
                        ex = null;
                        LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_DOWNLOADING"), mod.Name, allMirrorUrl));
                        LogLine("", logToLogger: false);
                        Updater.DownloadFileWithProgress(allMirrorUrl, text, progressCallback);
                        ProgressMax = 0;
                        Lines[Lines.Count - 1] = Dialog.Clean("DEPENDENCYDOWNLOADER_DOWNLOAD_FINISHED");
                        LogLine(Dialog.Clean("DEPENDENCYDOWNLOADER_VERIFYING_CHECKSUM"));
                        ModUpdater.VerifyChecksum(mod, text);
                    }
                    catch (Exception ex2)
                    {
                        ex = ex2;
                        Logger.Log(EverestLogLevel.Warn, "OuiDependencyDownloader",
                            "Download failed, trying another mirror");
                        Logger.LogDetailed(ex2);
                        Lines[Lines.Count - 1] =
                            string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_DOWNLOADING_MIRROR"), "");
                        continue;
                    }

                    break;
                }

                if (ex != null)
                {
                    ModUpdater.TryDelete(text);
                    throw ex;
                }

                shouldRestart = true;
                if (installedVersion != null)
                {
                    LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_UPDATING"), mod.Name,
                        installedVersion.Version,
                        mod.Version, installedVersion.PathArchive));
                    ModUpdater.InstallModUpdate(mod, installedVersion, text);
                }
                else
                {
                    string text3 = Path.Combine(Loader.PathMods, mod.Name + ".zip");
                    LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_INSTALLING"), mod.Name, mod.Version, text3));
                    if (File.Exists(text3))
                    {
                        File.Delete(text3);
                    }

                    File.Move(text, text3);
                }
            }
            catch (Exception e)
            {
                LogLine(string.Format(Dialog.Get("DEPENDENCYDOWNLOADER_INSTALL_FAILED"), mod.Name));
                Logger.LogDetailed(e);
                shouldAutoExit = false;
                if (!File.Exists(text))
                {
                    return;
                }

                bool shouldLog;
                try
                {
                    string text4 = "OuiDependencyDownloader";
                    string text5 = text4;
                    SourceDefaultInterpolatedStringHandler str;
                    shouldLog = Logger.GetLogLevel(text4) <= EverestLogLevel.Verbose;
                    str = shouldLog ? new SourceDefaultInterpolatedStringHandler(19, 1) : default;
                    if (shouldLog)
                    {
                        str.AppendLiteral("Deleting temp file ");
                        str.AppendFormatted(text);
                    }

                    if (shouldLog) Logger.Log(EverestLogLevel.Verbose, text5, str.ToStringAndClear());
                    File.Delete(text);
                }
                catch (Exception)
                {
                    string text4 = "OuiDependencyDownloader";
                    string text6 = text4;
                    SourceDefaultInterpolatedStringHandler str2;
                    shouldLog = Logger.GetLogLevel(text4) <= EverestLogLevel.Warn;
                    str2 = shouldLog ? new SourceDefaultInterpolatedStringHandler(16, 1) : default;
                    if (shouldLog)
                    {
                        str2.AppendLiteral("Removing ");
                        str2.AppendFormatted(text);
                        str2.AppendLiteral(" failed");
                    }

                    if (shouldLog) Logger.Log(EverestLogLevel.Warn, text6, str2.ToStringAndClear());
                }
            }
        }

        public override void Update()
        {
            if (everestVersionToInstall != null)
            {
                if (Input.MenuConfirm.Pressed && Focused)
                {
                    Updater.Update(
                        ((IEverestModOptionsEnvironment)engine).EverestUI.ModOptionsInstance.Overworld
                        .Goto<EverestLoggedProgressState>(), everestVersionToInstall);
                }
            }
            else if (task != null && !shouldAutoExit && (task.IsCompleted || task.IsCanceled || task.IsFaulted) &&
                     Input.MenuCancel.Pressed && Focused)
            {
                if (shouldRestart)
                {
                    ((IEverestRestartEnvironment)engine).Restart.QuickFullRestart();
                }
                else
                {
                    Exit();
                }
            }

            base.Update();
        }

        public void Exit()
        {
            task = null;
            Lines.Clear();
            ((ISourceEverestMainThreadEnvironment)engine).MainThreadProcess.Schedule(delegate
            {
                base.Overworld.GetUI<global::Celeste.Everest.Menus.Title.EverestMainMenuSequence>()?.NeedsRebuild();
            });
            Audio.Play("event:/ui/main/button_back");
            base.Overworld.Goto<EverestModOptionsState>();
        }
    }
}
