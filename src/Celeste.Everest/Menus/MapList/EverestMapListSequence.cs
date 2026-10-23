using Celeste.Input.Runtime;
using Celeste.Core.Display;
using Celeste.Scene.Tracking;
using Celeste.Audio.Fmod.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Simulation;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Controls.Source;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.Data;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Content.Dialogs;
using Celeste.Everest.Menus.Chapters;
using Celeste.Everest.Menus.MapList;
using Celeste.Everest.Menus.MapSearch;
using Celeste.Everest.UI.Controls;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.Runtime.Input;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Audio.Fmod;

namespace Celeste.Everest.Menus.MapList
{
    public class EverestMapListSequence : OuiState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private SourceMInputProcess MInput => ((ISourceMInputEnvironment)engine).MInput;
        private EverestTextInputProcess TextInput => ((IEverestTextInputEnvironment)engine).TextInput;
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        private IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)engine).AreaKeys;
        private IReadOnlyList<IOriginalAreaData> Areas => ((IOriginalAreaSourceTable)engine).Areas;
        private EverestArea GetArea(int id) => (EverestArea)AreaKeys.GetAreaById(id);

        public EverestMapListSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        private MountainCameraState cameraStart;

        private MountainCameraState cameraEnd;

        public List<ChapterSelectIconPresentation> OuiIcons;

        private TextMenuPresentation menu;

        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        private float alpha;

        private int type = 2;

        private int side;

        private List<IEverestMenuItemExt> items = new List<IEverestMenuItemExt>();

        private List<string> sets = new List<string>();

        private TextMenuPresentation CreateMenu(bool inGame, FmodEventReference snapshot)
        {
            menu = new TextMenuPresentation(engine);
            menu.CompactWidthMode = true;
            items.Clear();
            menu.Add(new TextMenuPresentation.Header(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_title")));
            menu.Add(new TextMenuPresentation.SubHeader(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_filters")));
            sets.Clear();
            foreach (EverestArea area in Areas)
            {
                string levelSet = area.LevelSet;
                if (!string.IsNullOrEmpty(levelSet) && !(levelSet == "Celeste") && !sets.Contains(levelSet))
                {
                    sets.Add(levelSet);
                }
            }

            menu.Add(new TextMenuPresentation.Slider(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_type"), delegate(int value)
                {
                    switch (value)
                    {
                        case 0:
                            return ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("levelset_celeste");
                        case 1:
                            return ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_type_everything");
                        case 2:
                            return ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_type_allmods");
                        default:
                            if (((IOriginalGameTextEnvironment)engine).Text.Dialog.Has(
                                    "maplist_type_" + sets[value - 3]))
                            {
                                return ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_type_" +
                                    sets[value - 3]);
                            }

                            return ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(
                                sets[value - 3]);
                    }
                }, 0, 2 + sets.Count, type).Change(delegate(int value)
            {
                type = value;
                ReloadItems();
            }));
            menu.Add(new TextMenuPresentation.Slider(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_side"),
                (int value) => ((char)(65 + value)).ToString(), 0, Enum.GetValues(typeof(OriginalAreaMode)).Length - 1,
                side).Change(delegate(int value)
            {
                side = value;
                ReloadItems();
            }));
            menu.Add(
                new TextMenuPresentation.Button(
                        ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_search"))
                    .Pressed(delegate { base.Overworld.Goto<EverestMapSearchSequence>(); }));
            menu.Add(new TextMenuPresentation.SubHeader(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_list")));
            ReloadItems();
            return menu;
        }

        private void ReloadItems()
        {
            menu.BatchMode = true;
            foreach (TextMenuPresentation.Item item in items)
            {
                menu.Remove(item);
            }

            items.Clear();
            string text = null;
            if (type == 0)
            {
                text = "Celeste";
            }
            else if (type >= 3)
            {
                text = sets[type - 3];
            }

            string text2 = null;
            int num = 0;
            int num2 = int.MaxValue;
            int num3 = int.MaxValue;
            var instance = Process.SaveContext.CurrentSave;
            var areas_Safe = ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(instance);
            for (int i = 0; i < Areas.Count; i++)
            {
                EverestArea area = GetArea(i);
                if (area == null || !area.HasMode(side) ||
                    (!instance.DebugMode && !string.IsNullOrEmpty(area.Metadata?.Parent)))
                {
                    continue;
                }

                string levelSet = area.LevelSet;
                if (type == 1 || ((text != null || !(levelSet == "Celeste")) && (text == null || !(text != levelSet))))
                {
                    string name = area.Name;
                    name = EverestModuleDialogText.CleanOrNull(engine, name) ??
                           EverestStringSource.SpacedPascalCase(name);
                    if (text2 != levelSet)
                    {
                        text2 = levelSet;
                        OriginalLevelSetStats levelSetStatsFor =
                            ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSetStatsFor(
                                Process.SaveContext.CurrentSave, levelSet);
                        num = levelSetStatsFor.AreaOffset;
                        num2 = levelSetStatsFor.UnlockedAreas;
                        num3 = levelSetStatsFor.UnlockedModes;
                        EverestMenuSubHeaderExt subHeaderExt = new EverestMenuSubHeaderExt(
                            ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(levelSet));
                        subHeaderExt.Alpha = 0f;
                        menu.Add(subHeaderExt);
                        items.Add(subHeaderExt);
                    }

                    EverestMenuButtonExt buttonExt = new EverestMenuButtonExt(name);
                    buttonExt.Alpha = 0f;
                    if (area.Icon != "areas/null")
                    {
                        buttonExt.Icon = area.Icon;
                    }

                    buttonExt.IconWidth = 64f;
                    if (levelSet == "Celeste" && i > num + num2)
                    {
                        buttonExt.Disabled = true;
                    }

                    if (side == 1 && !areas_Safe[i].Cassette)
                    {
                        buttonExt.Disabled = true;
                    }

                    if (side >= 2 && num3 < side + 1)
                    {
                        buttonExt.Disabled = true;
                    }

                    menu.Add(buttonExt.Pressed(delegate { Inspect(area, side); }));
                    items.Add(buttonExt);
                }
            }

            menu.BatchMode = false;
            float delayBetweenOptions = 0.03f;
            if (items.Count > 0)
            {
                delayBetweenOptions =
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(0.03f, 1f / (float)items.Count);
            }

            for (int num4 = 0; num4 < items.Count; num4++)
            {
                Add(new SimulationCoroutine(engine, FadeIn(num4, delayBetweenOptions, items[num4])));
            }

            if (menu.Height > menu.ScrollableMinSize)
            {
                menu.Position = new Vector2(menu.Position.X, menu.ScrollTargetY);
            }
        }

        private IEnumerator FadeIn(int i, float delayBetweenOptions, IEverestMenuItemExt item)
        {
            yield return delayBetweenOptions * (float)i;
            Vector2 offset = item.Offset;
            for (float p = 0f; p < 1f; p += engine.Frame.DeltaTime * 4f)
            {
                float num = (item.Alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p));
                item.Offset = offset + new Vector2(0f, 64f * (1f - num));
                yield return null;
            }

            item.Alpha = 1f;
            item.Offset = offset;
        }

        private void ReloadMenu()
        {
            Vector2 position = Vector2.Zero;
            int num = -1;
            if (menu != null)
            {
                position = menu.Position;
                num = menu.Selection;
                ((ISourceScene)Scene).SourceScene.RemoveEntity(menu);
            }

            menu = CreateMenu(inGame: false, null);
            if (num >= 0)
            {
                menu.Selection = num;
                menu.Position = position;
            }

            IEnumerable<TextMenuPresentation> entities =
                ((ISourceScene)Scene).SourceScene.Entities.Entities.OfType<TextMenuPresentation>();
            foreach (var entity in entities) ((ISourceScene)Scene).SourceScene.RemoveEntity(entity);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
        }

        public override IEnumerator Enter(OuiState from)
        {
            ReloadMenu();
            TextMenuPresentation textMenu = menu;
            EverestMapListSequence ouiMapList = this;
            bool visible = true;
            ouiMapList.Visible = true;
            textMenu.Visible = visible;
            menu.Focused = false;
            cameraStart = Overworld.Mountain.UntiltedCamera;
            cameraEnd = cameraStart;
            cameraEnd.Position += -SourceQuaternionMath.Forward(cameraStart.Rotation) * 1f;
            Overworld.Mountain.EaseCamera(Overworld.Mountain.Area, cameraEnd, 2f);
            Overworld.Mountain.AllowUserRotation = false;
            for (float p = 0f; p < 1f; p += engine.Frame.DeltaTime * 4f)
            {
                menu.X = 2880f + -1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }

            menu.Focused = true;
        }

        public override IEnumerator Leave(OuiState next)
        {
            menu.Focused = false;
            Process.AudioSession.Play("event:/ui/main/whoosh_large_out");
            if (Overworld != null)
            {
                Overworld.Maddy.Show = true;
                Overworld.Mountain.EaseCamera(Overworld.Mountain.Area, cameraStart, 0.4f);
            }

            for (float p = 0f; p < 1f; p += engine.Frame.DeltaTime * 4f)
            {
                menu.X = 960f + 1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                alpha = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            TextMenuPresentation textMenu = menu;
            EverestMapListSequence ouiMapList = this;
            bool visible = false;
            ouiMapList.Visible = false;
            textMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && base.Selected)
            {
                base.Overworld.Maddy.Show = false;
                if (Input.MenuCancel.Pressed || Input.Pause.Pressed || Input.ESC.Pressed)
                {
                    Process.AudioSession.Play("event:/ui/main/button_back");
                    base.Overworld.Goto<ChapterSelectSequence>();
                }
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);
            }

            base.Render(context);
        }

        protected void Inspect(EverestArea area, int mode = 0)
        {
            Focused = false;
            Process.AudioSession.Play("event:/ui/world_map/icon/select");
            ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.SetLastAreaSafe(
                Process.SaveContext.CurrentSave, AreaKeys.ToKey(area, mode));
            if (OuiIcons != null && area.ID < OuiIcons.Count)
            {
                OuiIcons[area.ID].Select();
            }

            base.Overworld.Mountain.Model.EaseState(area.MountainState);
            base.Overworld.Goto<EverestChapterPanelSequence>();
        }

        private void Start(EverestArea area, int mode = 0, string checkpoint = null)
        {
            Focused = false;
            Process.AudioSession.Play("event:/ui/world_map/chapter/checkpoint_start");
            Add(new SimulationCoroutine(engine, StartRoutine(area, mode, checkpoint)));
        }

        private IEnumerator StartRoutine(EverestArea area, int mode = 0, string checkpoint = null)
        {
            Overworld.Maddy.Hide(down: false);
            area.Wipe(Overworld, false, null);
            Process.AudioSession.SetMusic(null);
            Process.AudioSession.SetAmbience(null);
            if ((area.ID == 0 || area.ID == 9) && checkpoint == null && mode == 0)
            {
                Overworld.Renderers.UpdateLists();
                Overworld.Renderers.MoveToFront(Overworld.Snow);
            }

            yield return 0.5f;
            OriginalLevelEntryRouting.Go(
                ((IOriginalSessionEnvironment)engine).Sessions.CreateSession(AreaKeys.ToKey(area, mode), checkpoint),
                false,
                engine.Frame.Scenes, ((IOriginalLevelEntryEnvironment)engine).LevelEntries);
        }
    }
}
