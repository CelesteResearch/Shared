using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestSplashProcess
    {
        private readonly EverestLoggerProcess logger;
        private readonly IEverestSplashPhysicalIO io;

        public EverestSplashProcess(EverestLoggerProcess logger,
            IEverestSplashPhysicalIO io)
        {
            this.logger = logger;
            this.io = io;
        }

        private Process splashProcess;

        private NamedPipeServerStream splashPipeServerStream;

        private Task splashPipeServerStreamConnection;

        private readonly object splashPipeLock = new();

        private int loadedMods;

        private int totalMods;

        private Task lastFlush;

        public bool SplashRan { get; private set; }

        public void RunSplash(string targetRenderer = "")
        {
            var processId = io.ProcessId;
            try
            {
                lock (splashPipeLock)
                {
                    splashPipeServerStream = new("EverestSplash" + processId);
                    splashPipeServerStreamConnection = splashPipeServerStream.WaitForConnectionAsync();
                }
            }
            catch (IOException e)
            {
                logger.Log(EverestLogLevel.Error, "EverestSplash",
                    "Could not start up splash server!, skipping splash");
                logger.LogDetailed(e);
                splashPipeServerStreamConnection = null;
                if (splashPipeServerStream != null)
                {
                    if (splashPipeServerStream.IsConnected) splashPipeServerStream.Disconnect();

                    splashPipeServerStream.Dispose();
                    splashPipeServerStream = null;
                }
            }

            if (splashPipeServerStream == null) return;

            try
            {
                var process = new Process();
                object path;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    path = RuntimeInformation.OSArchitecture == Architecture.X64
                        ? "EverestSplash-win64.exe"
                        : "EverestSplash-win.exe";
                }
                else if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) throw new("Unknown OS platform");

                    path = "EverestSplash-osx";
                }
                else
                {
                    path = "EverestSplash-linux";
                }

                process.StartInfo = new(Path.Combine(".", "EverestSplash", (string)path),
                    (targetRenderer != "" ? "--graphics " + targetRenderer : "") + " --server-postfix " +
                    processId);
                splashProcess = process;
                splashProcess.StartInfo.RedirectStandardOutput = true;
                splashProcess.StartInfo.RedirectStandardError = true;
                splashProcess.OutputDataReceived += delegate(object _, DataReceivedEventArgs data)
                {
                    if (data.Data != null && !(data.Data.Trim().TrimEnd('\n', '\r') == ""))
                        logger.Log(EverestLogLevel.Info, "EverestSplash", data.Data);
                };
                splashProcess.ErrorDataReceived += delegate(object _, DataReceivedEventArgs data)
                {
                    if (data.Data != null && !(data.Data.Trim().TrimEnd('\n', '\r') == ""))
                        logger.Log(EverestLogLevel.Error, "EverestSplash", data.Data);
                };
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                    RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    var process2 =
                        Process.Start(new ProcessStartInfo("chmod",
                            "u+x \"" + splashProcess.StartInfo.FileName + "\""));
                    if (process2 == null)
                        logger.Log(EverestLogLevel.Error, "EverestSplash",
                            "Could not chmod splash!");

                    process2?.WaitForExit();
                    if (process2 == null || process2.ExitCode != 0)
                        logger.Log(EverestLogLevel.Error, "EverestSplash",
                            "Chmod failed for the splash!");
                }

                splashProcess.Start();
                splashProcess.BeginOutputReadLine();
                splashProcess.BeginErrorReadLine();
                SplashRan = true;
            }
            catch (Exception e2)
            {
                logger.Log(EverestLogLevel.Error, "EverestSplash", "Starting splash failed!");
                logger.LogDetailed(e2);
                if (splashPipeServerStream.IsConnected) splashPipeServerStream.Disconnect();

                splashPipeServerStream.Dispose();
                splashPipeServerStream = null;
                splashPipeServerStreamConnection = null;
                splashProcess = null;
            }
        }

        public void SetSplashLoadingModCount(int modCount)
        {
            totalMods = modCount;
        }

        public void IncreaseTotalModCount(int amount)
        {
            totalMods += amount;
        }

        public void IncreaseLoadedModCount(string latestLoadedMod)
        {
            loadedMods++;
            SendMessageToSplash("#progress" + loadedMods + ";" + totalMods + ";" + latestLoadedMod);
        }

        public void AllModsLoaded()
        {
            loadedMods = totalMods;
            SendMessageToSplash("#finish" + totalMods + ";Almost done...");
        }

        private void SendMessageToSplash(string message)
        {
            lock (splashPipeLock)
            {
                if (splashPipeServerStream == null || !splashPipeServerStreamConnection.IsCompleted ||
                    !splashPipeServerStream.IsConnected || (lastFlush != null && !lastFlush.IsCompletedSuccessfully))
                    return;

                try
                {
                    var streamWriter = new StreamWriter(splashPipeServerStream);
                    streamWriter.WriteLine(message);
                    lastFlush = streamWriter.FlushAsync();
                    lastFlush.Wait(1000);
                }
                catch (Exception e)
                {
                    logger.Log(EverestLogLevel.Error, "EverestSplash",
                        "Could not send data to splash!");
                    logger.LogDetailed(e);
                }
            }
        }

        public void StopSplash()
        {
            lock (splashPipeLock)
            {
                if (!SplashRan && Environment.GetEnvironmentVariable("EVEREST_SKIP_REQUEST_FOCUS_AFTER_SPLASH") == null)
                    Environment.SetEnvironmentVariable("EVEREST_SKIP_REQUEST_FOCUS_AFTER_SPLASH", "1");

                if (splashPipeServerStream == null) return;

                if (!splashPipeServerStreamConnection.IsCompleted || !splashPipeServerStream.IsConnected ||
                    (lastFlush != null && !lastFlush.IsCompletedSuccessfully))
                {
                    logger.Log(EverestLogLevel.Error, "EverestSplash",
                        "Could not connect to splash");
                    if (!splashProcess.HasExited)
                    {
                        splashProcess.Kill();
                        logger.Log(EverestLogLevel.Error, "EverestSplash",
                            "Splash was still alive. Killed splash!");
                    }

                    return;
                }

                try
                {
                    var streamWriter = new StreamWriter(splashPipeServerStream);
                    streamWriter.WriteLine("#stop");
                    streamWriter.Flush();
                    var thread = new Thread((ThreadStart)delegate
                    {
                        try
                        {
                            new StreamReader(splashPipeServerStream).ReadLine();
                        }
                        catch (Exception e2)
                        {
                            logger.Log(EverestLogLevel.Error, "EverestSplash",
                                "Could not read line!");
                            logger.LogDetailed(e2);
                        }
                    });
                    thread.Start();
                    if (!thread.Join(TimeSpan.FromSeconds(10.0)))
                    {
                        logger.Log(EverestLogLevel.Error, "EverestSplash",
                            "Timeout!, splash did not respond, continuing...");
                        if (!splashProcess.HasExited)
                        {
                            splashProcess.Kill();
                            logger.Log(EverestLogLevel.Error, "EverestSplash",
                                "Splash was still alive. Killed splash!");
                        }
                    }

                    if (splashPipeServerStream.IsConnected) splashPipeServerStream.Disconnect();

                    splashPipeServerStream.Dispose();
                    splashPipeServerStream = null;
                    splashPipeServerStreamConnection = null;
                    splashProcess = null;
                }
                catch (Exception e)
                {
                    logger.Log(EverestLogLevel.Error, "EverestSplash",
                        "Could not stop splash!");
                    logger.LogDetailed(e);
                }
            }
        }
    }
}
