using System;
using System.Collections.Generic;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private bool failedConstructionDisposed;

        internal void DisposeFailedConstruction(Exception? constructionFailure)
        {
            if (failedConstructionDisposed) return;
            failedConstructionDisposed = true;
            List<Exception>? cleanupFailures = null;

            void Release(Action action)
            {
                try
                {
                    action();
                }
                catch (Exception error)
                {
                    (cleanupFailures ??= new List<Exception>()).Add(error);
                }
            }

            if (sourceLoader != null) Release(sourceLoader.StopWatching);
            if (sourceStaThread != null && (actualGame == null || !actualGame.Components.Contains(sourceStaThread)))
                Release(sourceStaThread.Dispose);
            if (sourceMainThread != null && (actualGame == null || !actualGame.Components.Contains(sourceMainThread)))
                Release(sourceMainThread.Dispose);
            if (sourceModulesProcess != null) Release(sourceModulesProcess.DisposeSourceModDetours);
            if (sourceLuaLoader != null) Release(sourceLuaLoader.DisposeContext);
            var graphicsManager = actualGame != null &&
                                  ReferenceEquals(global::Celeste.Game.Execution.EngineRuntime.Instance, actualGame)
                ? global::Celeste.Game.Execution.EngineRuntime.Graphics
                : null;
            bool managedOwnsPhysicalDevice = graphicsManager?.GraphicsDevice != null;
            if (actualGame != null)
            {
                Release(actualGame.Dispose);
                if (graphicsManager != null) Release(((IDisposable)graphicsManager).Dispose);
            }

            if (sourceAudioSession != null) Release(sourceAudioSession.Dispose);
            if (sourceRuntimeModuleMetadata != null) Release(sourceRuntimeModuleMetadata.Dispose);
            Release(DisposeSourceBootSdkAssemblyResolver);
            if (!managedOwnsPhysicalDevice && sourceGraphicsIO != null) Release(sourceGraphicsIO.DestroyDevice);
            if (sourceAudioMedia != null) Release(sourceAudioMedia.Audio.Dispose);

            if (sourceContentRegistry != null) Release(sourceContentRegistry.Dispose);
            Release(DisposeSourceLog);
            if (cleanupFailures == null) return;
            var cleanupFailure = new AggregateException("Shared game construction cleanup failed.", cleanupFailures);
            if (constructionFailure != null)
                constructionFailure.Data["ConstructionCleanupFailure"] = cleanupFailure;
            else
                throw cleanupFailure;
        }
    }
}
