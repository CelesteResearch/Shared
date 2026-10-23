using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Journal;
using Celeste.Game.Menus.Title;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.Data;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Game.Menus.Chapters;

namespace Celeste.Everest.Menus.Chapters
{
    public class EverestChapterLevelSetPickerSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        protected IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)engine).AreaKeys;

        protected IOriginalSaveProgressionPolicy Progression =>
            ((IOriginalSaveProgressionEnvironment)engine).SaveProgression;

        protected IOriginalSaveSessionSelectionPolicy Selections =>
            ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection;

        protected IOriginalSaveCounterQueries Counters => ((IOriginalSaveCounterEnvironment)engine).SaveCounters;
        protected Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio => Process.AudioSession;
        protected IOriginalAreaSourceTable Areas => ((IOriginalSessionConstructionProcess)engine).AreaTable;

        public EverestChapterLevelSetPickerSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        public int Direction;

        public override IEnumerator Enter(OuiState from)
        {
            if (Direction == 0)
            {
                Overworld.Goto<ChapterSelectSequence>();
            }
            else
            {
                Direction = Math.Sign(Direction);
                yield return 0.25f;
                int iD = Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID;
                string levelSet =
                    ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSet(
                        Process.SaveContext.CurrentSave);
                int count = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count;
                for (int num = (count + iD + Direction) % count; num != iD; num = (count + num + Direction) % count)
                {
                    IOriginalAreaData areaData = AreaKeys.GetAreaById(num);
                    if (areaData == null || areaData.LevelSet != levelSet)
                    {
                        Selections.SetLastAreaSafe(Process.SaveContext.CurrentSave, AreaKeys.ToKey(areaData));
                        break;
                    }
                }
            }

            if (Direction > 0)
            {
                Process.AudioSession.Play("event:/ui/world_map/chapter/pane_expand");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/world_map/chapter/pane_contract");
            }

            Overworld.Goto<ChapterSelectSequence>();
        }

        public override IEnumerator Leave(OuiState next)
        {
            yield break;
        }
    }
}
