using Celeste.Core.Display;
using Celeste.Graphics.Text;
using System;
using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Controls.Source;
using Celeste.Everest.Content.Dialogs;
using Celeste.Everest.Modules.Settings;
using Celeste.Graphics.Display;
using System.Numerics;

namespace Celeste.Everest.UI.Menus.Files
{
    internal class EverestFileSelectSlotStateLevelSetPicker : EverestFileSelectSlotState.Button
    {
        private EverestFileSelectSlotState selectSlot;
        private readonly ISourceEngineContext engine;

        private Vector2 arrowOffset;

        private int lastDirection;

        public string NewGameLevelSet { get; private set; }

        public EverestFileSelectSlotStateLevelSetPicker(ISourceEngineContext engine,
            EverestFileSelectSlotState selectSlot)
        {
            this.engine = engine;
            this.selectSlot = selectSlot;
            if (((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Any((
                        Celeste.Game.Execution.Areas.IOriginalAreaData area) => area.LevelSet ==
                    ((IEverestCurrentCoreSettingsEnvironment)
                        engine).CurrentCoreSettings
                    .DefaultStartingLevelSet))
            {
                NewGameLevelSet = ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings
                    .DefaultStartingLevelSet;
            }

            Label = ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(NewGameLevelSet ??
                "Celeste");
            Scale = 0.5f;
            Action = delegate { changeStartingLevelSet(1); };
            float num = 0f;
            foreach (Celeste.Game.Execution.Areas.IOriginalAreaData area in
                     ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas)
            {
                num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(num,
                    ((ISourceActiveFontScope)engine).ActiveFont
                    .Measure(((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(area.LevelSet))
                    .X);
            }

            arrowOffset = new Vector2(20f + num / 2f * Scale, 0f);
        }

        public void Update(bool selected)
        {
            if (selected)
            {
                if (((IOriginalGameInputProcessEnvironment)engine).InputSource.MenuLeft.Pressed)
                {
                    changeStartingLevelSet(-1);
                }
                else if (((IOriginalGameInputProcessEnvironment)engine).InputSource.MenuRight.Pressed)
                {
                    changeStartingLevelSet(1);
                }
            }
            else
            {
                lastDirection = 0;
            }
        }

        public void Render(ISourceRenderContext context, Vector2 position, bool currentlySelected, float wigglerOffset)
        {
            Vector2 vector = Vector2.UnitX * (currentlySelected ? wigglerOffset : 0f);
            PackedColor color = selectSlot.SelectionColor(currentlySelected);
            Vector2 vector2 = ((lastDirection <= 0) ? vector : Vector2.Zero);
            Vector2 vector3 = ((lastDirection >= 0) ? vector : Vector2.Zero);
            ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, selectSlot, "<",
                position + vector2 - arrowOffset, new Vector2(0.5f, 0f), Vector2.One * Scale, color, 2f,
                PackedColor.Black);
            ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, selectSlot, ">",
                position + vector3 + arrowOffset, new Vector2(0.5f, 0f), Vector2.One * Scale, color, 2f,
                PackedColor.Black);
        }

        private void changeStartingLevelSet(int direction)
        {
            lastDirection = direction;
            ((IOriginalGameplayProcess)engine).AudioSession.Play((direction > 0)
                ? "event:/ui/main/button_toggle_on"
                : "event:/ui/main/button_toggle_off");
            if (NewGameLevelSet == null)
            {
                NewGameLevelSet = "Celeste";
            }

            int num = ((direction <= 0)
                ? (((System.Collections.Generic.List<Celeste.Game.Execution.Areas.OriginalAreaData>)
                       ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas)
                   .FindIndex((Celeste.Game.Execution.Areas.OriginalAreaData area) =>
                       area.LevelSet == NewGameLevelSet) +
                   direction)
                : (((System.Collections.Generic.List<Celeste.Game.Execution.Areas.OriginalAreaData>)
                        ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas)
                    .FindLastIndex((Celeste.Game.Execution.Areas.OriginalAreaData area) =>
                        area.LevelSet == NewGameLevelSet) + direction));
            if (num >= ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count)
            {
                num = 0;
            }

            if (num < 0)
            {
                num = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count - 1;
            }

            NewGameLevelSet = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[num].LevelSet;
            Label = ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(NewGameLevelSet ??
                "Celeste");
            selectSlot.WiggleMenu();
        }
    }
}
