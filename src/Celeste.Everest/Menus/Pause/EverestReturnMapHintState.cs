using Celeste.Core.Scheduling;
using Celeste.Everest.Menus.Chapters;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Menus.Pause;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Menus.Pause
{
    public sealed class EverestReturnMapHintState : ReturnMapHintPresentation
    {
        public EverestReturnMapHintState(ISourceEngineContext engine) : base(engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var session = (scene as OriginalLevelSceneRoot)?.Session;
            if (checkpoint != null || session == null ||
                AreaKeys.GetLevelSet(AreaKeys.GetSessionArea(session)) == "Celeste")
                return;
            var area = AreaKeys.GetSessionArea(session);
            var mode = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[area.ID]
                .Mode[area.Mode];
            if (mode.Checkpoints == null)
                return;
            var checkpoints = ((IOriginalSaveCheckpointEnvironment)engine).SaveCheckpoints
                .GetCheckpoints(((IOriginalGameplayProcess)engine).SaveContext.CurrentSave, area);
            OriginalCheckpointData last = null;
            foreach (var item in mode.Checkpoints)
                if (session.LevelFlags.Contains(item.Level) && checkpoints.Contains(item.Level))
                    last = item;
            var name = GetCheckpointPreviewName(area, last?.Level);
            if (MountainResources.Checkpoints.Has(name))
                checkpoint = MountainResources.Checkpoints[name];
        }

        public override string GetCheckpointPreviewName(OriginalAreaKey area, string level)
        {
            return EverestCheckpointPreviewNames.Get(engine, area, level);
        }
    }
}
