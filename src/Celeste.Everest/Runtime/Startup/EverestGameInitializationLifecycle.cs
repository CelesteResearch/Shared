#nullable enable annotations
using System;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.AutoSplitting;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Input;
using Celeste.Everest.Runtime.Threading;
using Celeste.Game.Audio.Runtime;
using Celeste.Framework.Startup;

namespace Celeste.Everest.Runtime.Startup
{
    public static class EverestGameInitializationLifecycle
    {
        public static void Initialize(IEverestGameInitializationEnvironment environment, SourceGameProcess game)
        {
            if (environment.InitializationContent.DumpAllRequested)
                environment.InitializationContent.DumpAll();
            environment.InitializationTextInput.Initialize();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var directory =
                    new DirectoryInfo(Path.Combine(environment.InitializationRuntime.PathGame, "orig", "Saves"));
                environment.InitializationRuntime.ShareVanillaSaveFiles =
                    directory.Exists && environment.InitializationSaveLinks.GetDirectoryLinkTarget(directory) != null;
            }
            else
                environment.InitializationRuntime.ShareVanillaSaveFiles = true;

            environment.InitializationAutoSplitter?.Initialize(environment);
            game.Components.Add(environment.InitializationMainThread);
            game.Components.Add(environment.InitializationStaThread);
            environment.ModulesProcess.InitializeModules();
            environment.LoadSourceInitializationDecalRegistry();
            game.Disposed += (sender, args) => Dispose(environment, sender, args);
        }

        private static void Dispose(IEverestGameInitializationEnvironment environment, object sender, EventArgs args)
        {
            environment.InitializationAutoSplitter?.Shutdown();
            environment.InitializationAudio.UnloadSource();
            environment.ModulesProcess.DisposeSourceModDetours();
        }
    }
}
