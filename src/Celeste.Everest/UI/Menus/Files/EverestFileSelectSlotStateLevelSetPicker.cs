using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Dialogs;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Graphics.Text;

namespace Celeste.Everest.UI.Menus.Files
{
    internal class EverestFileSelectSlotStateLevelSetPicker : EverestFileSelectSlotState.Button
    {
        private readonly EverestFileSelectSlotState selectSlot;
        private readonly ISourceEngineContext engine;

        private readonly Vector2 arrowOffset;

        private int lastDirection;

        public string NewGameLevelSet { get; private set; }

        public EverestFileSelectSlotStateLevelSetPicker(ISourceEngineContext engine,
            EverestFileSelectSlotState selectSlot)
        {
            this.engine = engine;
            this.selectSlot = selectSlot;
            if (((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Any(area => area.LevelSet ==
                    ((IEverestCurrentCoreSettingsEnvironment)
                        engine).CurrentCoreSettings
                    .DefaultStartingLevelSet))
                NewGameLevelSet = ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings
                    .DefaultStartingLevelSet;

            Label = ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(NewGameLevelSet ??
                "Celeste");
            Scale = 0.5f;
            Action = delegate { changeStartingLevelSet(1); };
            var num = 0f;
            foreach (var area in
                     ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas)
                num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(num,
                    ((ISourceActiveFontScope)engine).ActiveFont
                    .Measure(((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(area.LevelSet))
                    .X);

            arrowOffset = new(20f + num / 2f * Scale, 0f);
        }

        public void Update(bool selected)
        {
            if (selected)
            {
                if (((IOriginalGameInputProcessEnvironment)engine).InputSource.MenuLeft.Pressed)
                    changeStartingLevelSet(-1);
                else if (((IOriginalGameInputProcessEnvironment)engine).InputSource.MenuRight.Pressed)
                    changeStartingLevelSet(1);
            }
            else
            {
                lastDirection = 0;
            }
        }

        public void Render(ISourceRenderContext context, Vector2 position, bool currentlySelected, float wigglerOffset)
        {
            var vector = Vector2.UnitX * (currentlySelected ? wigglerOffset : 0f);
            var color = selectSlot.SelectionColor(currentlySelected);
            var vector2 = lastDirection <= 0 ? vector : Vector2.Zero;
            var vector3 = lastDirection >= 0 ? vector : Vector2.Zero;
            ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, selectSlot, "<",
                position + vector2 - arrowOffset, new(0.5f, 0f), Vector2.One * Scale, color, 2f,
                PackedColor.Black);
            ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, selectSlot, ">",
                position + vector3 + arrowOffset, new(0.5f, 0f), Vector2.One * Scale, color, 2f,
                PackedColor.Black);
        }

        private void changeStartingLevelSet(int direction)
        {
            lastDirection = direction;
            ((IOriginalGameplayProcess)engine).AudioSession.Play(direction > 0
                ? "event:/ui/main/button_toggle_on"
                : "event:/ui/main/button_toggle_off");
            if (NewGameLevelSet == null) NewGameLevelSet = "Celeste";

            var num = direction <= 0
                ? ((List<OriginalAreaData>)
                      ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas)
                  .FindIndex(area =>
                      area.LevelSet == NewGameLevelSet) +
                  direction
                : ((List<OriginalAreaData>)
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas)
                .FindLastIndex(area =>
                    area.LevelSet == NewGameLevelSet) + direction;
            if (num >= ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count) num = 0;

            if (num < 0) num = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count - 1;

            NewGameLevelSet = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[num].LevelSet;
            Label = ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(NewGameLevelSet ??
                "Celeste");
            selectSlot.WiggleMenu();
        }
    }
}
