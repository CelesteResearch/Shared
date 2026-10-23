using System.Collections.Generic;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Menus.Overworld
{
    public partial class EverestOverworldSequence
    {
        private OriginalSaveDataState CurrentSave => ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave;

        public override void Update()
        {
            lock (((ISourceAreaReloadLockEnvironment)EngineContext).AreaReloadLock)
            {
                base.Update();
                IOriginalAreaData areaData = null;
                var text = (Mountain?.Model as EverestMountainModelState)?.PreviousSID;
                if (text != null)
                    areaData = ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetAreaBySID(text);
                else if (CurrentSave != null)
                    areaData = ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetArea(
                        ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection.GetLastAreaSafe(
                            CurrentSave));
                var mapMetaMountain = ((EverestArea)areaData)?.Metadata?.Mountain;
                Snow3D.Visible = mapMetaMountain?.ShowSnow ?? true;
                if (string.IsNullOrEmpty(((IOriginalGameplayProcess)EngineContext).AudioSession.CurrentMusic))
                    return;
                if (CurrentSave != null &&
                    IsCurrent(o => UIProperties?.GetValueOrDefault(o.GetType())?.PlayCustomMusic == true))
                {
                    var music = mapMetaMountain?.BackgroundMusic;
                    var ambience = mapMetaMountain?.BackgroundAmbience;
                    if (music != null || ambience != null)
                    {
                        ((IOriginalGameplayProcess)EngineContext).AudioSession.SetMusic(music ??
                            "event:/music/menu/level_select");
                        ((IOriginalGameplayProcess)EngineContext).AudioSession.SetAmbience(ambience ??
                            "event:/env/amb/worldmap");
                        customizedChapterSelectMusic = true;
                    }
                    else
                    {
                        restoreNormalMusicIfCustomized();
                    }

                    foreach (var item in mapMetaMountain?.BackgroundMusicParams ??
                                         new Dictionary<string, float>())
                        ((IOriginalGameplayProcess)EngineContext).AudioSession.SetMusicParam(item.Key, item.Value);
                    return;
                }

                restoreNormalMusicIfCustomized();
            }
        }
    }
}
