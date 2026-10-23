using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Loading;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;

namespace Celeste.Game.Menus.Files
{
    public sealed class OriginalFileSlotFirstAreaPolicy : IOriginalFileSlotFirstAreaPolicy
    {
        public IEnumerator EnterFirstArea(FileSelectSequence fileSelect, ISourceEngineContext engine)
        {
            var overworld = fileSelect.Overworld;
            if (engine is IOriginalChapterPreparationEnvironment preparation)
                preparation.ChapterPreparation?.PrepareArea(0);
            yield return fileSelect.Leave(null);
            yield return overworld.Mountain.EaseCamera(0,
                ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[0].MountainIdle);
            yield return .3f;
            overworld.Mountain.EaseCamera(0,
                ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[0].MountainZoom, 1f);
            yield return .4f;
            ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[0].Wipe(overworld, false, null);
            overworld.Renderers.UpdateLists();
            overworld.Renderers.MoveToFront(overworld.Snow);
            yield return .5f;
            OriginalLevelEntryRouting.Go(
                ((IOriginalSessionEnvironment)engine).Sessions.CreateSession(
                    ((IOriginalAreaKeyEnvironment)engine).AreaKeys.Create(0)),
                false, engine.Frame.Scenes,
                ((IOriginalLevelEntryEnvironment)engine).LevelEntries);
        }
    }
}
