using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Core.Diagnostics.Runtime;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime.Startup;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandlerProcess
    {
        private string BackupLogFile(Exception error, out string logFileError)
        {
            if (string.IsNullOrEmpty(((IEverestStartupRuntimeEnvironment)EngineContext).EverestRuntime.PathLog))
            {
                logFileError = "<no log file has been written>";
                return null;
            }

            var text = $"log_{DateTime.Now:yyyyMMdd_HHmmss}";
            var text2 = Path.Combine(((IEverestStartupRuntimeEnvironment)EngineContext).EverestRuntime.PathGame,
                "CrashLogs", text + ".txt");
            var num = 2;
            while (File.Exists(text2))
            {
                text2 = Path.Combine(Path.GetDirectoryName(text2), $"{text}_{num}.txt");
                num++;
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(text2));
                File.Copy(((IEverestStartupRuntimeEnvironment)EngineContext).EverestRuntime.PathLog, text2);
                using var streamWriter = new StreamWriter(text2, true);
                streamWriter.WriteLine();
                streamWriter.WriteLine(
                    ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END OF BACKED UP LOG FILE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                streamWriter.WriteLine();
                streamWriter.WriteLine("Celeste/Everest Version: " +
                                       ((IEverestStartupRuntimeEnvironment)EngineContext).EverestRuntime
                                       .VersionCelesteString);
                var runtimeIdentity = ((ISourceRuntimeIdentityDiagnosticsEnvironment)EngineContext)
                    .RuntimeIdentityDiagnostics;
                var runtimeIdentifier = runtimeIdentity.RuntimeIdentifierAvailability ==
                                        SourceRuntimeIdentifierAvailability.Available
                    ? runtimeIdentity.RuntimeIdentifier
                    : "runtime identifier unavailable";
                streamWriter.WriteLine($"Operating System: {RuntimeInformation.OSDescription} [{runtimeIdentifier}]");
                streamWriter.WriteLine(".NET Runtime Description: " + RuntimeInformation.FrameworkDescription);
                try
                {
                    var presentationParameters =
                        ((ISourceGraphicsDeviceEnvironment)EngineContext)
                        .GraphicsDevice?.PresentationParameters;
                    if (presentationParameters != null)
                        streamWriter.WriteLine(
                            $"Presentation Parameters: {presentationParameters.BackBufferWidth}x{presentationParameters.BackBufferHeight} {Enum.GetName(typeof(SourceSurfaceFormat), presentationParameters.BackBufferFormat)} {(presentationParameters.IsFullScreen ? "fullscreen" : "windowed")} {(presentationParameters.PresentationInterval > SourcePresentInterval.Default ? "vsync" : "no vsync")}");

                    var adapter =
                        ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Adapter;
                    if (adapter != null)
                        streamWriter.WriteLine(
                            $"Graphics Adapater: '{adapter.DeviceName}' [{adapter.Description}] {adapter.CurrentDisplayMode.Width}x{adapter.CurrentDisplayMode.Height} {Enum.GetName(typeof(SourceSurfaceFormat), adapter.CurrentDisplayMode.Format)}");
                }
                catch (Exception ex)
                {
                    streamWriter.WriteLine("Error dumping graphics settings: " + ex.GetType().FullName + ": " +
                                           ex.Message);
                }

                streamWriter.WriteLine();
                var memoryDiagnostics =
                    ((ISourceRuntimeMemoryDiagnosticsEnvironment)EngineContext).RuntimeMemoryDiagnostics;
                var memoryInfo =
                    memoryDiagnostics.Availability == SourceRuntimeMemoryAvailability.Available
                        ? memoryDiagnostics.ReadMemoryInfo()
                        : null;
                var procSelf = Process.GetCurrentProcess();
                if (memoryInfo.HasValue)
                {
                    var memInfo = memoryInfo.Value;
                    streamWriter.WriteLine("Managed Heap Size: " + EvalSafe(() =>
                        FormatByteCount(memInfo.HeapSizeBytes) + " (committed: " +
                        FormatByteCount(memInfo.TotalCommittedBytes) + ")"));
                }
                else
                {
                    streamWriter.WriteLine("Managed Heap Size: CLR GC memory diagnostics unavailable");
                }

                streamWriter.WriteLine("Total Memory Usage: " + EvalSafe(() =>
                    $"private={FormatByteCount(procSelf.PrivateMemorySize64)} system={FormatByteCount(procSelf.PagedSystemMemorySize64 + procSelf.NonpagedSystemMemorySize64)} virtual={FormatByteCount(procSelf.VirtualMemorySize64)} physical={FormatByteCount(procSelf.WorkingSet64)} paged={FormatByteCount(procSelf.PagedMemorySize64)}"));
                streamWriter.WriteLine("Peak Memory Usage: " + EvalSafe(() =>
                    $"virtual={FormatByteCount(procSelf.VirtualMemorySize64)} physical={FormatByteCount(procSelf.PeakWorkingSet64)} paged={FormatByteCount(procSelf.PeakPagedMemorySize64)}"));
                if (memoryInfo.HasValue)
                    streamWriter.WriteLine("Available Memory: " +
                                           EvalSafe(() => FormatByteCount(memoryInfo.Value.TotalAvailableMemoryBytes)));
                else
                    streamWriter.WriteLine("Available Memory: CLR GC memory diagnostics unavailable");
                streamWriter.WriteLine();
                streamWriter.WriteLine("Loaded Mods");
                try
                {
                    lock (((ISourceEverestModulesEnvironment)EngineContext).Modules)
                    {
                        var flag =
                            ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.IsAsyncUpdateCheckingDone();
                        var dictionary =
                            new Dictionary<EverestModuleMetadata, EverestModUpdateInfo>();
                        if (flag)
                            try
                            {
                                foreach (var asyncLoadedModUpdate
                                         in
                                         ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater
                                         .GetAsyncLoadedModUpdates())
                                {
                                    asyncLoadedModUpdate.Deconstruct(out var key, out var value);
                                    var value2 = key;
                                    var key2 = value;
                                    dictionary[key2] = value2;
                                }

                                streamWriter.WriteLine(
                                    "(entries marked with * are known to not match latest on the database)");
                            }
                            catch (Exception ex2)
                            {
                                streamWriter.WriteLine(
                                    $"(failed to check update status: {ex2.GetType().FullName}: {ex2.Message})");
                                flag = false;
                            }

                        foreach (var module in
                                 ((ISourceEverestModulesEnvironment)EngineContext).Modules)
                        {
                            streamWriter.Write(" - " + module.Metadata.Name + ": ");
                            streamWriter.Write(module.Metadata.VersionString ?? "");
                            if (flag && dictionary.TryGetValue(module.Metadata, out var value3))
                                streamWriter.Write("* (-> " + value3.Version + ")");

                            var text3 = !(module is SourceNullModule)
                                ? " [" + module.GetType().FullName + "]"
                                : "";
                            streamWriter.Write(text3 ?? "");
                            streamWriter.WriteLine();
                        }
                    }
                }
                catch (Exception ex3)
                {
                    streamWriter.WriteLine(" - error listing mods: " + ex3.GetType().FullName + ": " + ex3.Message);
                }

                streamWriter.WriteLine();
                streamWriter.WriteLine($"Crash Exception: {error}");
                streamWriter.WriteLine();
                streamWriter.WriteLine($"Crash HResult: {error.HResult}");
                streamWriter.WriteLine($"Inner exception (if any): {error.InnerException}");
                streamWriter.WriteLine();
                var frame = new StackTrace(error, true).GetFrame(0);
                if (frame != null)
                {
                    streamWriter.WriteLine($"Last stack frame: {frame}");
                    streamWriter.WriteLine($"Frame IL offset: {frame.GetILOffset()}");
                    streamWriter.WriteLine($"Frame native offset: {frame.GetNativeOffset()}");
                }
                else
                {
                    streamWriter.WriteLine("Couldn't fetch latest frame!");
                }
            }
            catch (Exception ex4)
            {
                Logger.Log(EverestLogLevel.Error, "crit-error-handler", "Error backing up log file:");
                Logger.LogDetailed(ex4, "crit-error-handler");
                logFileError = "<error backing up log file: " + ex4.Message + ">";
                return null;
            }

            if (Logger.GetLogLevel("crit-error-handler") <= EverestLogLevel.Info)
                Logger.Log(EverestLogLevel.Info, "crit-error-handler", "Backed up log file to '" + text2 + "'");
            logFileError = null;
            return text2;

            static string EvalSafe(Func<string> func)
            {
                try
                {
                    return func();
                }
                catch (Exception ex5)
                {
                    return $"<error during evaluation: {ex5.GetType().FullName}: {ex5.Message}>";
                }
            }

            static string FormatByteCount(long bytes)
            {
                if (bytes < 1048576)
                {
                    if (bytes >= 1024) return $"{bytes / 1024f}KB";

                    return $"{bytes}B";
                }

                if (bytes >= 1099511627776L) return $"{bytes / 1073741824 / 1024f}TB";

                if (bytes >= 1073741824) return $"{bytes / 1048576 / 1024f}GB";

                return $"{bytes / 1024 / 1024f}MB";
            }
        }
    }
}
