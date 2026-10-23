using System;
using System.IO;
using System.Reflection;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Menus.Overworld;
using Celeste.Everest.Menus.Title;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        private void LoadAutoUpdated(object source, FileSystemEventArgs e)
        {
            if (!AutoLoadNewMods)
            {
                return;
            }

            string tag = "loader";
            var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Info);
            if (sourceLog1.ShouldLog) sourceLog1.Write("Possible new mod container: " + (e.FullPath));
            ((IEverestLoaderContentEnvironment)sourceEngine).QueuedTasks.Do("LoadAutoUpdated:" + e.FullPath, delegate
            {
                ((IEverestAssetReloadEnvironment)sourceEngine).AssetReload.Do(
                    ((IOriginalGameTextEnvironment)sourceEngine).Text.CleanDialog("ASSETRELOADHELPER_LOADINGNEWMOD") +
                    " " +
                    Path.GetFileName(e.FullPath), delegate
                    {
                        ((ISourceEverestMainThreadEnvironment)sourceEngine).MainThreadProcess.Schedule(delegate
                        {
                            if (Directory.Exists(e.FullPath))
                            {
                                LoadDir(e.FullPath);
                            }
                            else if (e.FullPath.EndsWith(".zip"))
                            {
                                LoadZip(e.FullPath);
                            }

                            ((((IEverestAssetReloadEnvironment)sourceEngine).AssetReload.ReturnToScene as
                                EverestOverworldSequence)?.GetUI<EverestMainMenuSequence>())?.NeedsRebuild();
                        });
                    });
            });
        }

        private void WatcherError(object source, ErrorEventArgs e)
        {
            string tag = "loader";
            var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Error);
            if (sourceLog1.ShouldLog)
                sourceLog1.Write("Error while watching \"" + (PathMods) +
                                 "\" for changes. Updates will no longer be detected.");
            Logger.LogDetailed(e.GetException());
        }

        private void ApplyModHackfixes(EverestModuleMetadata meta, Assembly asm)
        {
        }
    }
}
