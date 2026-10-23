using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Runtime;
using Celeste.Everest.UI.Progress;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Shutdown;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestUpdaterProcess
    {
        private readonly ISourceEngineContext engine;
        internal EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;

        internal EverestCompressedHttpProcess CompressedHttp =>
            ((IEverestCompressedHttpEnvironment)engine).CompressedHttp;

        private EverestStartupRuntimeProcess Runtime => ((IEverestStartupRuntimeEnvironment)engine).EverestRuntime;

        private EverestCoreSettings CoreSettings =>
            ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings;

        private int Build => Runtime.Build;
        private string PathGame => Runtime.PathGame;
        internal readonly Dictionary<string, EverestUpdaterStringLocker> sharedCache = new();

        public EverestUpdaterProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
            Sources = new List<EverestUpdateSource>
            {
                new EverestUpdateSource(this)
                {
                    Name = "updater_src_stable",
                    Description = "updater_src_release_github",
                    MinimumBuild = 3960,
                    UpdatePriority = EverestUpdatePriority.High,
                    Index = GetEverestUpdaterDatabaseURL,
                    ParseData = UpdateListParser("stable")
                },
                new EverestUpdateSource(this)
                {
                    Name = "updater_src_beta",
                    Description = "updater_src_buildbot_azure",
                    MinimumBuild = 3960,
                    Index = GetEverestUpdaterDatabaseURL,
                    ParseData = UpdateListParser("beta")
                },
                new EverestUpdateSource(this)
                {
                    Name = "updater_src_dev",
                    Description = "updater_src_buildbot_azure",
                    MinimumBuild = 3960,
                    Index = GetEverestUpdaterDatabaseURL,
                    ParseData = UpdateListParser("dev")
                }
            };
        }


        public readonly List<EverestUpdateSource> Sources;

        internal Task _VersionListRequestTask;

        private string _everestUpdaterDatabaseURL;

        private readonly object _getUpdaterURLLock = new object();

        public EverestUpdateEntry Newest { get; internal set; }

        public bool HasUpdate
        {
            get
            {
                if (Newest != null && Build != 0)
                {
                    return Newest.Build > Build;
                }

                return false;
            }
        }

        public bool UpdateFailed { get; internal set; }

        public void StartVersionListRequestAtBoot()
            => _VersionListRequestTask = RequestAll();

        public Task RequestAll()
        {
            Task[] array = new Task[Sources.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Sources[i].Request();
            }

            return Task.Factory.ContinueWhenAll(array, delegate
            {
                lock (sharedCache)
                {
                    sharedCache.Clear();
                }

                Logger.Log(EverestLogLevel.Verbose, "updater", "Flushed shared cache");
                List<EverestUpdateEntry> list = new List<EverestUpdateEntry>();
                foreach (EverestUpdateSource source in Sources)
                {
                    if (source.Entries != null && !(source.Name != CoreSettings.CurrentBranch))
                    {
                        list.AddRange(source.Entries);
                    }
                }

                if (list.Count != 0)
                {
                    int num = list.FindIndex((EverestUpdateEntry entry) => entry.Build == Build);
                    if (num == -1)
                    {
                        num = 0;
                    }

                    Newest = list[0];
                    for (int num2 = 1; num2 <= num; num2++)
                    {
                        if (list[num2].Build > Newest.Build)
                        {
                            Newest = list[num2];
                        }
                    }
                }
            });
        }

        private string GetEverestUpdaterDatabaseURL()
        {
            if (CoreSettings.UseAPIMirror)
            {
                Logger.Log(EverestLogLevel.Info, "updater", "Using mirror for the Everest updater database");
                return "https://everestapi.github.io/updatermirror/everest_versions.json";
            }

            lock (_getUpdaterURLLock)
            {
                if (string.IsNullOrEmpty(_everestUpdaterDatabaseURL))
                {
                    using HttpClient httpClient = CompressedHttp.CreateClient();
                    Logger.Log(EverestLogLevel.Verbose, "updater", "Fetching Everest updater database URL");
                    UriBuilder uriBuilder = new UriBuilder(httpClient
                        .GetStringAsync("https://everestapi.github.io/everestupdater.txt").Result.Trim());
                    if ((uriBuilder.Query?.Length ?? 0) > 1)
                    {
                        uriBuilder.Query = uriBuilder.Query.Substring(1) + "&supportsNativeBuilds=true";
                    }
                    else
                    {
                        uriBuilder.Query = "supportsNativeBuilds=true";
                    }

                    _everestUpdaterDatabaseURL = uriBuilder.ToString();
                }
            }

            return _everestUpdaterDatabaseURL;
        }

        private Func<EverestUpdateSource, string, EverestUpdateEntry> CommonLineParser(string root)
        {
            return delegate(EverestUpdateSource source, string line)
            {
                string[] array = line.Split(' ');
                if (array.Length < 2 || array.Length > 3)
                {
                    throw new Exception("Version list format incompatible!");
                }

                string text = array[0];
                if (!text.StartsWith("http://") && !text.StartsWith("https://"))
                {
                    text = root + text;
                }

                if (!text.EndsWith("/" + array[1]))
                {
                    throw new Exception("URL (first column) must end in filename (second column)!");
                }

                string text2 = array[1];
                if (text2.EndsWith(".zip"))
                {
                    text2 = text2.Substring(0, text2.Length - 4);
                }

                if (text2.StartsWith("build-"))
                {
                    text2 = text2.Substring(6);
                }

                int num = text2.IndexOf('-');
                if (num != -1)
                {
                    text2.Substring(num + 1);
                    text2 = text2.Substring(0, num);
                }

                return new EverestUpdateEntry(text2, text, int.Parse(Regex.Match(array[1], "\\d+").Value), source);
            };
        }

        public Func<EverestUpdateSource, string, List<EverestUpdateEntry>> UpdateListParser(string branch)
        {
            return delegate(EverestUpdateSource source, string dataRaw)
            {
                List<EverestUpdateEntry> list = new List<EverestUpdateEntry>();
                foreach (JObject item in JArray.Parse(dataRaw))
                {
                    if (item["branch"].ToString() == branch)
                    {
                        int version = item["version"].ToObject<int>();
                        string url = item["mainDownload"].ToString();
                        JToken value;
                        bool? isNativeBuild = (item.TryGetValue("isNative", out value)
                            ? new bool?(value.ToObject<bool>())
                            : ((bool?)null));
                        list.Add(new EverestUpdateEntry(version.ToString(), url, version, source)
                        {
                            IsNativeBuild = isNativeBuild
                        });
                    }
                }

                return list;
            };
        }

        public Func<EverestUpdateSource, string, List<EverestUpdateEntry>> AzureBuildsParser(string artifactFormat,
            int offset)
        {
            return delegate(EverestUpdateSource source, string dataRaw)
            {
                List<EverestUpdateEntry> list = new List<EverestUpdateEntry>();
                foreach (JObject item in JObject.Parse(dataRaw)["value"] as JArray)
                {
                    int num = item["id"].ToObject<int>();
                    string url = string.Format(artifactFormat, num);
                    EverestUpdateEntry entry =
                        new EverestUpdateEntry((num + offset).ToString(), url, num + offset, source);
                    try
                    {
                        entry.Description = item.SelectToken("triggerInfo['ci.message']").ToString().Split('\n')[0];
                    }
                    catch
                    {
                    }

                    list.Add(entry);
                }

                return list;
            };
        }

        public Func<EverestUpdateSource, string, List<EverestUpdateEntry>> GitHubReleasesParser(int offset,
            bool prerelease = false)
        {
            return delegate(EverestUpdateSource source, string dataRaw)
            {
                List<EverestUpdateEntry> list = new List<EverestUpdateEntry>();
                foreach (JObject item in JArray.Parse(dataRaw))
                {
                    if (prerelease == item["prerelease"].ToObject<bool>())
                    {
                        string value = Regex.Match(item["name"].ToString(), "\\d+$").Value;
                        string text = null;
                        foreach (JObject item2 in item["assets"] as JArray)
                        {
                            if (item2["name"].ToString() == "main.zip")
                            {
                                text = item2["browser_download_url"].ToString();
                                break;
                            }
                        }

                        if (text == null)
                        {
                            throw new Exception("main.zip asset not found for release");
                        }

                        list.Add(new EverestUpdateEntry(value, text, int.Parse(value), source));
                    }
                }

                return list;
            };
        }

        public void CheckForUpdateFailure()
        {
            string path = Path.Combine(PathGame, "everest-update", "update-build.txt");
            if (!File.Exists(path))
            {
                return;
            }

            try
            {
                if (Build != int.Parse(File.ReadAllText(path)))
                {
                    UpdateFailed = true;
                }
            }
            catch (Exception e)
            {
                Logger.Log(EverestLogLevel.Warn, "updater", "Exception when trying to determine update build number");
                Logger.LogDetailed(e);
                UpdateFailed = true;
            }
            finally
            {
                File.Delete(path);
            }
        }

        public void Update(EverestLoggedProgressState progress, EverestUpdateEntry version = null)
        {
            if (version == null)
            {
                version = Newest;
            }

            if (version == null)
            {
                progress.Init<EverestModOptionsState>(
                        ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("updater_title"),
                        new Task(delegate { }), 1)
                    .Progress = 1;
                progress.LogLine(((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_NOUPDATE"));
                progress.WaitForConfirmOnFinish = true;
                return;
            }

            CoreSettings.CurrentBranch = version.Source.Name;
            ((IEverestCoreModuleEnvironment)engine).CoreModule.SaveSettings();
            progress.Init<EverestShutdownState>(
                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("updater_title"),
                new Task(delegate
                {
                    if (DoUpdate(progress, version, PathGame, isUpdate: true) == null)
                    {
                        progress.SwitchGoto<EverestModOptionsState>().WaitForConfirmOnFinish = true;
                    }
                }), 0);
        }

        internal void UpdateLegacyRef(EverestLoggedProgressState progress)
        {
            progress.Init<EverestModOptionsState>(
                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("updater_legacyref_title"), Task.Run(
                    async delegate
                    {
                        string legacyRefInstall = Path.Combine(PathGame, "legacyRef");
                        if (!Directory.Exists(legacyRefInstall))
                        {
                            progress.LogLine(
                                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(
                                    "EVERESTUPDATER_CREATINGLEGACYREF"));
                            CopyInstallDir(Path.Combine(PathGame, "orig"), legacyRefInstall);
                        }

                        EverestUpdateSource source =
                            Sources.First((EverestUpdateSource src) => src.Name.Contains("stable"));
                        source = await source.Request();
                        if (!string.IsNullOrEmpty(source.ErrorDialog))
                        {
                            progress.LogLine(
                                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(source.ErrorDialog));
                            progress.LogLine(
                                $"\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT1")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT2")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT3")}");
                            progress.Progress = 0;
                            progress.ProgressMax = 1;
                            progress.WaitForConfirmOnFinish = true;
                        }
                        else
                        {
                            EverestUpdateEntry entry =
                                source.Entries.FirstOrDefault((EverestUpdateEntry entr) => !entr.IsNativeBuild == true);
                            if (entry == null)
                            {
                                progress.LogLine(
                                    ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(
                                        "EVERESTUPDATER_NOTAVAILABLE"));
                                progress.LogLine(
                                    $"\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT1")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT2")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT3")}");
                                progress.Progress = 0;
                                progress.ProgressMax = 1;
                                progress.WaitForConfirmOnFinish = true;
                            }
                            else
                            {
                                Process process = DoUpdate(progress, entry, legacyRefInstall, isUpdate: false);
                                if (process == null)
                                {
                                    progress.WaitForConfirmOnFinish = true;
                                }
                                else
                                {
                                    progress.LogLine(
                                        ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(
                                            "EVERESTUPDATER_WAITFORINSTALLER"));
                                    int num = 1;
                                    List<string> lines = progress.Lines;
                                    string text = lines[lines.Count - 1].ToString();
                                    while (!process.HasExited)
                                    {
                                        List<string> lines2 = progress.Lines;
                                        lines2[lines2.Count - 1] = text + new string('.', num);
                                        process.WaitForExit(700);
                                        num = num % 3 + 1;
                                    }

                                    List<string> lines3 = progress.Lines;
                                    lines3[lines3.Count - 1] = text;
                                    if (process.ExitCode != 0)
                                    {
                                        string tag = "updater";
                                        var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Warn);
                                        if (sourceLog1.ShouldLog)
                                            sourceLog1.Write(
                                                "LegacyRef update failed: MiniInstaller exited with code " +
                                                (process.ExitCode));
                                        progress.LogLine(string.Format(
                                            ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get(
                                                "EVERESTUPDATER_INSTALLERFAILED"), process.ExitCode));
                                        progress.LogLine(
                                            $"\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT1")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT2")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT3")}");
                                        progress.Progress = 0;
                                        progress.ProgressMax = 1;
                                        progress.WaitForConfirmOnFinish = true;
                                    }
                                    else
                                    {
                                        string path = Path.Combine(legacyRefInstall,
                                            ((IEverestUpdaterPhysicalEnvironment)engine).Flags.VanillaIsFNA
                                                ? "BuildIsFNA.txt"
                                                : "BuildIsXNA.txt");
                                        string path2 = Path.Combine(legacyRefInstall,
                                            ((IEverestUpdaterPhysicalEnvironment)engine).Flags.VanillaIsFNA
                                                ? "BuildIsXNA.txt"
                                                : "BuildIsFNA.txt");
                                        if (File.Exists(path2))
                                        {
                                            File.Delete(path2);
                                        }

                                        if (!File.Exists(path))
                                        {
                                            File.WriteAllText(path, string.Empty);
                                        }
                                    }
                                }
                            }
                        }
                    }), 0);

            static void CopyInstallDir(string srcDir, string dstDir)
            {
                Directory.CreateDirectory(dstDir);
                foreach (string item in Directory.EnumerateFiles(srcDir))
                {
                    string text = Path.Combine(dstDir, Path.GetRelativePath(srcDir, item));
                    string fileName = Path.GetFileName(item);
                    if (!(fileName == "Content") && !(fileName == "Saves"))
                    {
                        if (File.Exists(item))
                        {
                            File.Copy(item, text);
                        }

                        if (Directory.Exists(item))
                        {
                            CopyInstallDir(item, text);
                        }
                    }
                }
            }
        }

        private Process DoUpdate(EverestLoggedProgressState progress, EverestUpdateEntry version, string installTarget,
            bool isUpdate)
        {
            string line =
                $"\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT1")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT2")}\n{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ERRORHINT3")}";
            string text = Path.Combine(installTarget, "everest-update.zip");
            string text2 = (isUpdate ? Path.Combine(installTarget, "everest-update") : installTarget);
            progress.LogLine(string.Format(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("EVERESTUPDATER_UPDATING"), version.Name,
                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(version.Source.Name), version.URL));
            progress.LogLine(((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_DOWNLOADING"));
            try
            {
                DownloadFileWithProgress(version.URL, text, delegate(int position, long length, int speed)
                {
                    if (length > 0)
                    {
                        progress.Lines[progress.Lines.Count - 1] =
                            $"{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_DOWNLOADING_PROGRESS")} {(int)Math.Floor(100.0 * ((double)position / (double)length))}% @ {speed} KiB/s";
                        progress.Progress = position;
                    }
                    else
                    {
                        progress.Lines[progress.Lines.Count - 1] =
                            $"{((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_DOWNLOADING_PROGRESS")} {(int)Math.Floor((double)position / 1000.0)}KiB @ {speed} KiB/s";
                    }

                    progress.ProgressMax = (int)length;
                    return true;
                });
            }
            catch (Exception e)
            {
                progress.LogLine(
                    ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_DOWNLOADFAILED"));
                Logger.LogDetailed(e);
                progress.LogLine(line);
                progress.Progress = 0;
                progress.ProgressMax = 1;
                return null;
            }

            progress.LogLine(
                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_DOWNLOADFINISHED"));
            progress.LogLine(((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_EXTRACTING"));
            bool flag = true;
            try
            {
                if (text2 != installTarget && Directory.Exists(text2))
                {
                    Directory.Delete(text2, recursive: true);
                }

                using ZipArchive zipArchive = ZipFile.OpenRead(text);
                progress.LogLine(
                    $"{zipArchive.Entries.Count} {((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_ZIPENTRIES")}");
                progress.Progress = 0;
                progress.ProgressMax = zipArchive.Entries.Count;
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    if (entry.FullName.Replace('\\', '/').EndsWith("/"))
                    {
                        progress.Progress++;
                        continue;
                    }

                    string text3 = entry.FullName;
                    if (text3.StartsWith("main/"))
                    {
                        text3 = text3.Substring(5);
                    }

                    if (text3 == "MiniInstaller.exe")
                    {
                        flag = false;
                    }

                    string text4 = Path.Combine(text2, text3);
                    string directoryName = Path.GetDirectoryName(text4);
                    if (!Directory.Exists(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (File.Exists(text4))
                    {
                        File.Delete(text4);
                    }

                    progress.LogLine(entry.FullName + " -> " + text4);
                    using (Stream stream = entry.Open())
                    {
                        using Stream destination = File.OpenWrite(text4);
                        stream.CopyTo(destination);
                    }

                    progress.Progress++;
                }
            }
            catch (Exception e2)
            {
                progress.LogLine(
                    ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_EXTRACTIONFAILED"));
                Logger.LogDetailed(e2);
                progress.LogLine(line);
                progress.Progress = 0;
                progress.ProgressMax = 1;
                return null;
            }

            progress.LogLine(
                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_EXTRACTIONFINISHED"));
            progress.Progress = 1;
            progress.ProgressMax = 1;
            if (isUpdate)
            {
                string text5 = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_RESTARTING");
                progress.LogLine(text5);
                for (int num = 3; num > 0; num--)
                {
                    progress.Lines[progress.Lines.Count - 1] = string.Format(
                        ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("EVERESTUPDATER_RESTARTINGIN"), num);
                    Thread.Sleep(1000);
                }

                progress.Lines[progress.Lines.Count - 1] = text5;
            }

            try
            {
                Process process = new Process();
                string text6;
                if (!flag)
                {
                    text6 = (process.StartInfo.FileName = Path.Combine(text2, "MiniInstaller.exe"));
                    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        process.StartInfo.FileName = "mono";
                        process.StartInfo.Arguments = "\"" + text6 + "\"";
                        if (File.Exists("/bin/sh"))
                        {
                            string value = Process.GetCurrentProcess().Id.ToString();
                            process.StartInfo.FileName = "/bin/sh";
                            string text8 = "mono";
                            if (File.Exists("/Library/Frameworks/Mono.framework/Versions/Current/Commands/mono"))
                            {
                                text8 = "/Library/Frameworks/Mono.framework/Versions/Current/Commands/mono";
                            }

                            if (isUpdate)
                            {
                                process.StartInfo.Arguments =
                                    $"-c \"kill -0 {value}; while [ $? = \\\"0\\\" ]; do sleep 1; kill -0 {value}; done; unset MONO_PATH LD_LIBRARY_PATH LC_ALL MONO_CONFIG; {text8} MiniInstaller.exe\"";
                            }
                            else
                            {
                                process.StartInfo.Arguments =
                                    "-c \"unset MONO_PATH LD_LIBRARY_PATH LC_ALL MONO_CONFIG; " +
                                    text8 + " MiniInstaller.exe\"";
                            }
                        }
                    }
                }
                else
                {
                    ProcessStartInfo startInfo = process.StartInfo;
                    object path;
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        path = ((RuntimeInformation.OSArchitecture == Architecture.X64)
                            ? "MiniInstaller-win64.exe"
                            : "MiniInstaller-win.exe");
                    }
                    else if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                        {
                            throw new Exception("Unknown OS platform");
                        }

                        path = "MiniInstaller-osx";
                    }
                    else
                    {
                        path = "MiniInstaller-linux";
                    }

                    text6 = (startInfo.FileName = Path.Combine(text2, (string)path));
                    process.StartInfo.Environment["EVEREST_UPDATE_CELESTE_PID"] =
                        Process.GetCurrentProcess().Id.ToString();
                }

                if (!File.Exists(text6))
                {
                    throw new Exception("Couldn't find MiniInstaller executable");
                }

                if (flag && (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                             RuntimeInformation.IsOSPlatform(OSPlatform.OSX)))
                {
                    Process process2 =
                        Process.Start(new ProcessStartInfo("chmod", "u+x \"" + process.StartInfo.FileName + "\""));
                    process2.WaitForExit();
                    if (process2.ExitCode != 0)
                    {
                        throw new Exception("Failed to set MiniInstaller executable flag");
                    }
                }

                if (isUpdate)
                {
                    File.WriteAllText(Path.Combine(text2, "update-build.txt"), version.Build.ToString());
                }

                process.StartInfo.WorkingDirectory = text2;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                return process;
            }
            catch (Exception e3)
            {
                progress.LogLine(
                    ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("EVERESTUPDATER_STARTINGFAILED"));
                Logger.LogDetailed(e3);
                progress.LogLine(line);
                progress.Progress = 0;
                progress.ProgressMax = 1;
                return null;
            }
        }

        /// <summary>
        ///       Downloads a file and calls the progressCallback parameter periodically with progress information.
        ///       This can be used to display the download progress on screen.
        ///       </summary>
        /// <param name="url">The URL to download the file from</param>
        /// <param name="destPath">The path the file should be downloaded to</param>
        /// <param name="progressCallback">A method called periodically as the download progresses. Parameters are progress, length and speed in KiB/s.
        ///       Should return true for the download to continue, false for it to be cancelled.</param>
        public void DownloadFileWithProgress(string url, string destPath, Func<int, long, int, bool> progressCallback)
        {
            DateTime now = DateTime.Now;
            if (File.Exists(destPath))
            {
                File.Delete(destPath);
            }

            using HttpClient httpClient = CompressedHttp.CreateClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(10000.0);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/octet-stream");
            Task<HttpResponseMessage> async = httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            HttpResponseMessage result;
            try
            {
                result = async.Result;
            }
            catch (AggregateException ex)
            {
                if (async.IsCanceled)
                {
                    throw new TimeoutException("The request to " + url + " timed out.", ex.InnerException);
                }

                throw;
            }

            using (result)
            {
                using Stream stream = result.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
                using FileStream fileStream = File.OpenWrite(destPath);
                if (stream.CanTimeout)
                {
                    stream.ReadTimeout = 10000;
                }

                long num =
                    ((!stream.CanSeek) ? result.Content.Headers.ContentLength.GetValueOrDefault() : stream.Length);
                progressCallback(0, num, 0);
                byte[] array = new byte[4096];
                DateTime dateTime = now;
                int num2 = 1;
                int num3 = 0;
                int num4 = 0;
                int arg = 0;
                int num5 = 0;
                while (num2 > 0)
                {
                    num5 = (int)((num > 0) ? Math.Min(array.Length, num - num4) : array.Length);
                    num2 = stream.Read(array, 0, num5);
                    fileStream.Write(array, 0, num2);
                    num4 += num2;
                    num3 += num2;
                    TimeSpan timeSpan = DateTime.Now - dateTime;
                    if (timeSpan.TotalMilliseconds > 100.0)
                    {
                        arg = (int)((double)num3 / 1024.0 / timeSpan.TotalSeconds);
                        num3 = 0;
                        dateTime = DateTime.Now;
                    }

                    if (!progressCallback(num4, num, arg))
                    {
                        break;
                    }
                }
            }
        }
    }
}
