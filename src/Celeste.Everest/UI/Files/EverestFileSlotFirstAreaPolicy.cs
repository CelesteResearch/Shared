using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Menus.Files;

namespace Celeste.Everest.UI.Files
{
    public sealed class EverestFileSlotFirstAreaPolicy : IOriginalFileSlotFirstAreaPolicy
    {
        public IEnumerator EnterFirstArea(FileSelectSequence fileSelect, ISourceEngineContext engine)
        {
            ((global::Celeste.Everest.UI.Menus.Files.EverestFileSelectSequence)fileSelect).startingNewFile = true;
            var overworld = fileSelect.Overworld;
            var area = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[
                ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetLastAreaSafe(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave).ID];
            if (area.LevelSet != "Celeste")
            {
                var vanilla = ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSetStatsFor(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave, "Celeste");
                vanilla.UnlockedAreas = 1;
                vanilla.AreasIncludingCeleste[0].Modes[0].Completed = true;
            }

            yield return fileSelect.Leave(null);
            overworld.Mountain.Model.EaseState(area.MountainState);
            yield return overworld.Mountain.EaseCamera(0, area.MountainIdle);
            yield return .3f;
            overworld.Mountain.EaseCamera(0, area.MountainZoom, 1f);
            yield return .4f;
            area.Wipe(overworld, false, null);
            overworld.Renderers.UpdateLists();
            overworld.Renderers.MoveToFront(overworld.Snow);
            yield return .5f;
            OriginalLevelEntryRouting.Go(
                ((IOriginalSessionEnvironment)engine).Sessions.CreateSession(
                    ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetLastAreaSafe(
                        ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave)),
                false, engine.Frame.Scenes,
                ((IOriginalLevelEntryEnvironment)engine).LevelEntries);
        }
    }
}
