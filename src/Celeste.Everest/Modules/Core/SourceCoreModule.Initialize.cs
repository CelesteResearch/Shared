using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using System.Threading.Tasks;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Content.Dialogs;
using Celeste.Everest.Runtime;
using Celeste.Everest.Content.Reloading;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        public override void Initialize()
        {
            ((ISourceCommandsProcessEnvironment)SourceEngine).Commands.FunctionKeyActions[4] = () =>
            {
                var keyboard = ((ISourceMInputEnvironment)SourceEngine).MInput.Keyboard;
                if (keyboard.Check(SourceKeys.LeftControl) || keyboard.Check(SourceKeys.RightControl))
                {
                    if (!(SourceEngine.Frame.Scenes.CurrentScene is GameLoaderScene))
                        ((IEverestRestartEnvironment)SourceEngine).Restart.QuickFullRestart();
                }
                else
                {
                    var level = SourceEngine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;
                    if (level != null)
                    {
                        var reload = ((IEverestAssetReloadEnvironment)SourceEngine).AssetReload;
                        reload.Do(
                            ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog(
                                "ASSETRELOADHELPER_RELOADINGMAP"),
                            _ =>
                            {
                                ((IOriginalAreaDataResolver)SourceEngine).Get(level.Session.AreaID)
                                    .Mode[(int)level.Session.Mode].MapData.Reload();
                                return Task.CompletedTask;
                            }).ContinueWith(_ => reload.ReloadLevel());
                    }
                }
            };
        }
    }
}
