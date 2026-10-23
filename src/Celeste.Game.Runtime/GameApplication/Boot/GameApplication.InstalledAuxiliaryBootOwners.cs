using System;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Scripting.Lua;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestStaThreadEnvironment,
        IEverestLuaLoaderProcessEnvironment, IEverestUpdaterEnvironment
    {
        private EverestStaThreadProcess sourceStaThread;
        private EverestLuaLoaderProcess sourceLuaLoader;
        private EverestUpdaterProcess sourceUpdater;

        public EverestStaThreadProcess StaThread => sourceStaThread ??
                                                    throw new InvalidOperationException(
                                                        "The actual source STA helper is not constructed.");

        public EverestLuaLoaderProcess LuaLoader => sourceLuaLoader ??
                                                    throw new InvalidOperationException(
                                                        "The actual source Lua loader is not constructed.");

        public EverestUpdaterProcess Updater => sourceUpdater ??
                                                throw new InvalidOperationException(
                                                    "The actual source updater is not constructed.");

        private void ConstructSourceInstalledStaThread()
        {
            if (sourceStaThread != null)
                throw new InvalidOperationException("The actual source STA helper is already constructed.");
            sourceStaThread = new EverestStaThreadProcess(ActualGame.Framework);
        }

        private void ConstructSourceInstalledLuaLoader()
        {
            if (sourceLuaLoader != null)
                throw new InvalidOperationException("The actual source Lua loader is already constructed.");
            sourceLuaLoader = new EverestLuaLoaderProcess(EverestRuntime.PathEverest, SourceContentRegistry,
                ((IEverestLoggerProcessEnvironment)this).Logger, SourceMembers);
            ActualGame.Disposed += DisposeSourceLuaContext;
            // Detour undo still needs both Lua delegates and the physical module readers.
            if (sourceRuntimeModuleMetadata != null)
            {
                ActualGame.Disposed -= DisposeSourceRuntimeModuleMetadata;
                ActualGame.Disposed += DisposeSourceRuntimeModuleMetadata;
            }
        }

        private void DisposeSourceLuaContext(object sender, EventArgs args)
        {
            sourceModulesProcess.DisposeSourceModDetours();
            sourceLuaLoader.DisposeContext();
        }

        private void ConstructSourceInstalledUpdater()
        {
            if (sourceUpdater != null)
                throw new InvalidOperationException("The actual source updater is already constructed.");
            sourceUpdater = new EverestUpdaterProcess(this);
        }

        private void AddSourceInstalledStaThreadComponent() => ActualGame.Components.Add(StaThread);
    }
}
