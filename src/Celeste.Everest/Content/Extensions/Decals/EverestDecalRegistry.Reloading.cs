using Celeste.Scene.Tracking;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed partial class EverestDecalRegistry
    {
        private void ScheduleHotReloadIfNeeded()
        {
            if (!loaded || willHotReload) return;
            willHotReload = true;
            if (reload.IsReloading)
                reload.Events.OnAfterNextReload += silent => DoReload();
            else
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.OnEndOfFrame += DoReload;
        }

        private void DoReload()
        {
            logger.Log(EverestLogLevel.Info, "Decal Registry",
                "Reloading Decal Registry due to new handlers getting registered");
            Load();
            reload.ReloadLevel();
            willHotReload = false;
        }
    }
}
