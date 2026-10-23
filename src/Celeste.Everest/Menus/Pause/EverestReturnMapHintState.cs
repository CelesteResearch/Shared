using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Pause;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
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
            OriginalAreaKey area = AreaKeys.GetSessionArea(session);
            OriginalAreaModeData mode = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[area.ID]
                .Mode[(int)area.Mode];
            if (mode.Checkpoints == null)
                return;
            HashSet<string> checkpoints = ((IOriginalSaveCheckpointEnvironment)engine).SaveCheckpoints
                .GetCheckpoints(((IOriginalGameplayProcess)engine).SaveContext.CurrentSave, area);
            OriginalCheckpointData last = null;
            foreach (OriginalCheckpointData item in mode.Checkpoints)
                if (session.LevelFlags.Contains(item.Level) && checkpoints.Contains(item.Level))
                    last = item;
            string name = GetCheckpointPreviewName(area, last?.Level);
            if (MountainResources.Checkpoints.Has(name))
                checkpoint = MountainResources.Checkpoints[name];
        }

        public override string GetCheckpointPreviewName(OriginalAreaKey area, string level)
            => global::Celeste.Everest.Menus.Chapters.EverestCheckpointPreviewNames.Get(engine, area, level);
    }
}
