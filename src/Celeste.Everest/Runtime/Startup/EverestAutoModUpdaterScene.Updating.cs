using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Runtime.Startup
{
    public partial class EverestAutoModUpdaterScene
    {
        private void AutoUpdate(SortedDictionary<EverestModUpdateInfo, EverestModuleMetadata> updateList)
        {
            int number = 1;
            string zipPath = Path.Combine(((IEverestGamePathEnvironment)EngineContext).PathGame, "mod-update.zip");
            bool installedAny = false;
            bool failed = false;
            foreach (EverestModUpdateInfo update in updateList.Keys)
            {
                string progress =
                    $"[{number}/{updateList.Count}] {((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_UPDATING")} {((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.FormatModName(update.Name)}:";
                try
                {
                    showCancel = true;
                    modUpdatingMessage = progress + " " +
                                         ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog(
                                             "AUTOUPDATECHECKER_DOWNLOADING");
                    var downloading =
                        ((IEverestLoggerProcessEnvironment)EngineContext).Logger.BeginEnabledMessage("AutoModUpdater",
                            EverestLogLevel.Verbose);
                    if (downloading.ShouldLog) downloading.Write("Downloading " + update.URL + " to " + zipPath);
                    Func<int, long, int, bool> progressCallback = delegate(int position, long length, int speed)
                    {
                        if (skipUpdate) return false;
                        if (length > 0)
                            modUpdatingMessage =
                                $"{progress} {((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_DOWNLOADING")} ({(int)Math.Floor(100.0 * ((double)position / (double)length))}% @ {speed} KiB/s)";
                        else
                            modUpdatingMessage =
                                $"{progress} {((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_DOWNLOADING")} ({(int)Math.Floor((double)position / 1000.0)}KiB @ {speed} KiB/s)";
                        return true;
                    };
                    Exception exception = null;
                    foreach (string mirror in ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater
                             .GetAllMirrorUrls(
                                 update.URL))
                    {
                        try
                        {
                            exception = null;
                            var message =
                                ((IEverestLoggerProcessEnvironment)EngineContext).Logger.BeginEnabledMessage(
                                    "AutoModUpdater", EverestLogLevel.Warn);
                            if (message.ShouldLog) message.Write("Downloading from " + mirror);
                            ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.DownloadFileWithProgress(mirror,
                                zipPath, progressCallback);
                            if (!skipUpdate)
                            {
                                modUpdatingMessage = progress + " " +
                                                     ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog(
                                                         "AUTOUPDATECHECKER_VERIFYING");
                                ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.VerifyChecksum(update,
                                    zipPath);
                            }
                        }
                        catch (Exception e)
                        {
                            exception = e;
                            var message =
                                ((IEverestLoggerProcessEnvironment)EngineContext).Logger.BeginEnabledMessage(
                                    "AutoModUpdater", EverestLogLevel.Warn);
                            if (message.ShouldLog)
                                message.Write("Download from " + mirror + " failed, trying another mirror");
                            ((IEverestLoggerProcessEnvironment)EngineContext).Logger.LogDetailed(e);
                            continue;
                        }

                        break;
                    }

                    if (exception != null)
                    {
                        ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.TryDelete(zipPath);
                        throw exception;
                    }

                    showCancel = false;
                    if (skipUpdate)
                    {
                        ((IEverestLoggerProcessEnvironment)EngineContext).Logger.Log(EverestLogLevel.Verbose,
                            "AutoModUpdater", "Update was skipped");
                        ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.TryDelete(zipPath);
                        if (installedAny) break;
                        shouldContinue = true;
                        return;
                    }

                    installedAny = true;
                    modUpdatingMessage = progress + " " +
                                         ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog(
                                             "AUTOUPDATECHECKER_INSTALLING");
                    ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.InstallModUpdate(update,
                        updateList[update],
                        zipPath);
                }
                catch (Exception e)
                {
                    var message =
                        ((IEverestLoggerProcessEnvironment)EngineContext).Logger.BeginEnabledMessage("AutoModUpdater",
                            EverestLogLevel.Warn);
                    if (message.ShouldLog) message.Write("Updating " + update.Name + " failed");
                    ((IEverestLoggerProcessEnvironment)EngineContext).Logger.LogDetailed(e);
                    failed = true;
                    ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.TryDelete(zipPath);
                    break;
                }

                number++;
            }

            showCancel = false;
            if (!failed)
            {
                modUpdatingMessage =
                    ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("DEPENDENCYDOWNLOADER_RESTARTING");
                Thread.Sleep(1000);
                ((IEverestRestartEnvironment)EngineContext).Restart.QuickFullRestart();
                return;
            }

            modUpdatingMessage =
                ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_FAILED");
            cogwheelSpinning = false;
            cogwheelStopTime = RawTimeActive;
            if (installedAny)
            {
                modUpdatingSubMessage =
                    ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_REBOOT");
                confirmToRestart = true;
            }
            else
            {
                modUpdatingSubMessage =
                    ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_CONTINUE");
                confirmToContinue = true;
            }
        }
    }
}
