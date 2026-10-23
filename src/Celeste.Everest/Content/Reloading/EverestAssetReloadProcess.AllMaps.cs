using System;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Presentation.Mountain.Views;
using Celeste.Game.Save.Runtime;
using Celeste.Everest.Presentation.Mountain.Model;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadProcess
    {
        public void ReloadAllMaps()
        {
            Events.ReloadAllMaps();
            var source = (IEverestAssetReloadAreaEnvironment)EngineContext;
            var keys = ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys;
            lock (Synchronization.AreaReloadLock)
            {
                var instance = source.SaveContext.CurrentSave;
                var previousArea = keys.GetAreaById(instance?.LastAreaSafe.ID ?? -1);
                string sid = previousArea == null
                    ? keys.GetSID(keys.Default)
                    : keys.GetSID(keys.ToKey(previousArea));
                source.AreaRegistry.Areas = null;
                source.AreaRegistryLoad.Load();
                ((IOriginalMountainViewsEnvironment)EngineContext).MountainViews.ReloadMountainViews();
                if (instance != null)
                {
                    var area = keys.GetAreaBySID(sid);
                    instance.LastAreaSafe = area == null ? keys.Default : keys.ToKey(area);
                    source.SavePreparation.BeforeSave(instance);
                    var initialization = (IOriginalSaveInitializationEnvironment)EngineContext;
                    initialization.SaveInitialization.AfterInitialize(instance,
                        initialization.SaveInitializationServices);
                }

                var mountain = ((IEverestMountainResourceEnvironment)EngineContext).MountainExtension;
                mountain.ReloadMod();
                MainThread.Schedule((Action)mountain.ReloadModData, false);
            }

            if (EngineContext.Frame.Scenes.CurrentScene is OverworldSequence overworld)
            {
                if (overworld.Mountain.Area >= source.AreaRegistry.Areas.Count)
                    overworld.Mountain.EaseCamera(0, source.AreaRegistry.Areas[0].MountainIdle);
                var chapterSelect = overworld.GetUI<ChapterSelectSequence>();
                overworld.UIs.Remove(chapterSelect);
                overworld.SourceScene.RemoveEntity(chapterSelect);
                chapterSelect = new ChapterSelectSequence(EngineContext) { Visible = true };
                overworld.SourceScene.QueueSourceEntity(chapterSelect);
                overworld.UIs.Add(chapterSelect);
                chapterSelect.IsStart(overworld, (OverworldStartMode)(-1));
            }
        }
    }
}
