using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime.Assemblies;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Execution;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed partial class EverestStartupRuntimeProcess
    {
        public ReadOnlyCollection<string> Args { get; private set; }

        public void ParseSourceEarlyArguments(string[] args)
        {
            Args = new(args);
            var queue = new Queue<string>(args);
            while (queue.Count > 0)
            {
                var text = queue.Dequeue();
                switch (text)
                {
                    case "--debug":
                        GameRuntime.PlayMode =
                            GameRuntime.PlayModes.Debug;
                        continue;
                    case "--debugger":
                        Debugger.Launch();
                        continue;
                    case "--debugger-attach":
                        WriteSourceEarlyArgumentLog("Waiting for debugger to attach...");
                        while (!Debugger.IsAttached)
                        {
                        }

                        WriteSourceEarlyArgumentLog("Debugger attached");
                        continue;
                    case "--dump":
                        ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry.DumpOnLoad = true;
                        continue;
                    case "--dump-all":
                        ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry.DumpAllRequested = true;
                        continue;
                    case "--whitelist":
                        if (queue.Count >= 1)
                        {
                            ((IEverestLoaderProcessEnvironment)engine).Loader.NameWhitelist = queue.Dequeue();
                            continue;
                        }

                        break;
                }

                if (text == "--blacklist" && queue.Count >= 1)
                {
                    ((IEverestLoaderProcessEnvironment)engine).Loader.NameTemporaryBlacklist = queue.Dequeue();
                }
                else if (text == "--loglevel" && queue.Count >= 1)
                {
                    if (Enum.TryParse<EverestLogLevel>(queue.Dequeue(), true, out var result))
                        ((IEverestLoggerProcessEnvironment)engine).Logger.SetLogLevelFromSettings("", result);
                }
                else if (text == "--use-scancodes")
                {
                    Environment.SetEnvironmentVariable("FNA_KEYBOARD_USE_SCANCODES", "1");
                }
                else if (text == "--no-game-checksum")
                {
                    ((ISourceEverestAssemblyProcessEnvironment)engine).AssemblyContexts.Relinker.SkipGameChecksum =
                        true;
                }
            }
        }

        private void WriteSourceEarlyArgumentLog(string text)
        {
            var message =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("Everest", EverestLogLevel.Info);
            if (message.ShouldLog) message.Write(text);
        }
    }
}
