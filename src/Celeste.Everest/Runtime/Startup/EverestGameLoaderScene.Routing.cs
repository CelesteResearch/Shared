using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Runtime.Startup
{
    public partial class EverestGameLoaderScene
    {
        private SourceSceneState GetNextScene(HiresSnowState snow)
        {
            var hook = global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                .Get<IEverestGameLoaderSourceHooksEnvironment>(EngineContext)?.SourceLoaderNextSceneOverride;
            if (hook != null) return hook(this, snow);
            CheckModSaveDataBackups();
            bool showUpdater = false;
            if (((IEverestCurrentCoreSettingsEnvironment)EngineContext).CurrentCoreSettings.AutoUpdateModsOnStartup
                && !((IEverestHeadlessEnvironment)EngineContext).IsHeadless)
            {
                if (!((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.IsAsyncUpdateCheckingDone())
                    showUpdater = true;
                else
                {
                    var updates = ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.GetAsyncLoadedModUpdates();
                    if (updates != null && updates.Count != 0) showUpdater = true;
                }
            }

            if (showUpdater)
                return new EverestAutoModUpdaterScene(EngineContext, snow);
            return ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                OverworldStartMode.Titlescreen, snow);
        }
    }
}
