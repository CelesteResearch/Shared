using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
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

namespace Celeste.Everest.Menus.MapSearch
{
    public class EverestMapSearchSequence : OuiState
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

        public EverestMapSearchSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        private class SearchMenu : SceneEntityState
        {
            public TextMenuPresentation leftMenu;

            public TextMenuPresentation rightMenu;

            private float leftOffset;

            private float rightOffset;

            public bool leftFocused
            {
                get { return leftMenu.Focused; }
                set
                {
                    leftMenu.Focused = value;
                    rightMenu.Focused = !value;
                }
            }

            public int Selection
            {
                get { return currentMenu.Selection; }
                set { currentMenu.Selection = value; }
            }

            public TextMenuPresentation currentMenu
            {
                get
                {
                    if (!leftFocused)
                    {
                        return rightMenu;
                    }

                    return leftMenu;
                }
            }

            public bool Focused
            {
                get
                {
                    if (!leftMenu.Focused)
                    {
                        return rightMenu.Focused;
                    }

                    return true;
                }
                set
                {
                    if (value)
                    {
                        leftFocused = true;
                        return;
                    }

                    leftMenu.Focused = false;
                    rightMenu.Focused = false;
                }
            }

            public SearchMenu(TextMenuPresentation leftMenu, TextMenuPresentation rightMenu) : base(
                ((ISourceEntitySourceDataEnvironment)leftMenu.EngineContext).EntitySourceDataRegistration)
            {
                Position = Vector2.Zero;
                this.leftMenu = leftMenu;
                this.rightMenu = rightMenu;
            }

            public override void Added(object scene)
            {
                base.Added(scene);
                rightMenu.InnerContent = TextMenuPresentation.InnerContentMode.TwoColumn;
                leftMenu.Position =
                    new Vector2(
                        (float)((ISourceRenderEnvironment)leftMenu.EngineContext).CurrentContext.Graphics.Width / -4f,
                        leftMenu.Position.Y);
                rightMenu.Position =
                    new Vector2(
                        (float)((ISourceRenderEnvironment)leftMenu.EngineContext).CurrentContext.Graphics.Width / 4f,
                        rightMenu.Position.Y);
                leftOffset = leftMenu.Position.X;
                rightOffset = rightMenu.Position.X;
                rightMenu.Focused = false;
                ((ISourceScene)scene).SourceScene.QueueSourceEntity(leftMenu);
                ((ISourceScene)scene).SourceScene.QueueSourceEntity(rightMenu);
            }

            public override void Removed(object scene)
            {
                ((ISourceScene)scene).SourceScene.RemoveEntity(leftMenu);
                ((ISourceScene)scene).SourceScene.RemoveEntity(rightMenu);
                base.Removed(scene);
            }

            public override void Update()
            {
                base.Update();
                leftMenu.Position = new Vector2(leftOffset + Position.X, leftMenu.Position.Y);
                rightMenu.Position = new Vector2(rightOffset + Position.X, rightMenu.Position.Y);
            }
        }

        private MountainCameraState cameraStart;

        private MountainCameraState cameraEnd;

        public List<ChapterSelectIconPresentation> OuiIcons;

        private SearchMenu menu;

        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        private float alpha;

        private PackedColor searchBarColor;

        private List<IEverestMenuItemExt> items = new List<IEverestMenuItemExt>();

        private List<string> sets = new List<string>();

        public bool FromChapterSelect;

        private bool searching;

        private string search = "";

        private string searchPrev = "";

        private TextMenuPresentation.Item searchTitle;

        private bool searchConsumedButton;

        private int itemCount;

        private int matchCount;

        private bool quickMatched;

        private TextMenuPresentation.SubHeader resultHeader;

        private static EverestMenuSubHeaderExt perfectMatchHeader;

        public bool Searching
        {
            get { return searching; }
            set
            {
                if (value != searching)
                {
                    if (value)
                    {
                        TextInput.OnInput += OnTextInput;
                    }
                    else
                    {
                        TextInput.OnInput -= OnTextInput;
                    }
                }

                searching = value;
            }
        }

        private void clearSearch()
        {
            search = "";
        }

        private void cleanExit()
        {
            clearSearch();
            if (FromChapterSelect)
            {
                Process.AudioSession.Play("event:/ui/main/button_back");
                base.Overworld.Goto<ChapterSelectSequence>();
            }
            else
            {
                base.Overworld.Goto<EverestMapListSequence>();
            }
        }

        public void OnTextInput(char c)
        {
            switch (c)
            {
                case '\r':
                    ((SourceSceneState)Scene).OnEndOfFrame += delegate
                    {
                        switchMenu();
                        if (items.Count >= 1)
                        {
                            if (items.Count == 2 || matchCount == 1)
                            {
                                Action action = (items[1] as EverestMenuButtonExt)?.OnPressed;
                                if (action != null)
                                {
                                    clearSearch();
                                    action();
                                    return;
                                }
                            }

                            int num2 = menu.rightMenu.Items.FindIndex((TextMenuPresentation.Item item) =>
                                item is EverestMenuButtonExt { Selectable: not false } buttonExt &&
                                items.Contains(buttonExt));
                            if (num2 > 0)
                            {
                                menu.rightMenu.Selection = num2;
                                Process.AudioSession.Play("event:/ui/main/button_select");
                            }
                        }
                    };
                    goto IL_0208;
                case '\b':
                    if (search.Length > 0)
                    {
                        if (MInput.Keyboard.CurrentState.IsKeyDown(SourceKeys.LeftControl) ||
                            MInput.Keyboard.CurrentState.IsKeyDown(SourceKeys.RightControl))
                        {
                            int num = search.Length - 1;
                            while (num >= 0 && char.IsWhiteSpace(search[num]))
                            {
                                num--;
                            }

                            while (num >= 0 && !char.IsWhiteSpace(search[num]))
                            {
                                num--;
                            }

                            search = search.Substring(0, num + 1);
                        }
                        else
                        {
                            search = search.Substring(0, search.Length - 1);
                        }

                        Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
                    }
                    else
                    {
                        if (!Input.MenuCancel.Pressed)
                        {
                            break;
                        }

                        Process.AudioSession.Play("event:/ui/main/button_back");
                        switchMenu();
                    }

                    goto IL_0208;
                case ' ':
                    if (search.Length > 0 && ActiveFont.Measure(search + c + "_").X < 542f)
                    {
                        search += c;
                    }

                    Process.AudioSession.Play("event:/ui/main/rename_entry_space");
                    goto IL_0208;
                default:
                {
                    if (!char.IsControl(c))
                    {
                        if (ActiveFont.Font.Get(ActiveFont.BaseSize).Characters.ContainsKey(c))
                        {
                            Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                            if (ActiveFont.Measure(search + c + "_").X < 542f)
                            {
                                search += c;
                            }

                            goto IL_0208;
                        }

                        Process.AudioSession.Play("event:/ui/main/button_invalid");
                        break;
                    }

                    break;
                }
                    IL_0208:
                    searchConsumedButton = true;
                    MInput.Disabled = true;
                    MInput.UpdateNull();
                    break;
            }
        }

        private SearchMenu CreateMenu(bool inGame, FmodEventReference snapshot)
        {
            menu = new SearchMenu(new TextMenuPresentation(engine), new TextMenuPresentation(engine));
            items.Clear();
            menu.leftMenu.Add(searchTitle =
                new TextMenuPresentation.Header(
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_search")));
            menu.rightMenu.Add(resultHeader = new TextMenuPresentation.SubHeader(string.Format(
                (itemCount == 1)
                    ? ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("maplist_results_singular")
                    : ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("maplist_results_plural"), itemCount)));
            ReloadItems();
            return menu;
        }

        private void ReloadItems()
        {
            itemCount = 0;
            matchCount = 0;
            menu.rightMenu.BatchMode = true;
            foreach (TextMenuPresentation.Item item in items)
            {
                menu.rightMenu.Remove(item);
            }

            items.Clear();
            string text = null;
            int num = 0;
            int num2 = int.MaxValue;
            string[] array = (from text3 in search.Split(' ')
                select text3.ToLower()).ToArray();
            bool flag = false;
            for (int num3 = 0; num3 < Areas.Count; num3++)
            {
                string name = GetArea(num3).Name;
                string text2 = EverestModuleDialogText.CleanOrNull(engine, name) ??
                               EverestStringSource.SpacedPascalCase(name);
                if (text2.ToLower() == search.ToLower())
                {
                    matchCount++;
                }
            }

            var instance = Process.SaveContext.CurrentSave;
            _ = ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(instance);
            for (int num4 = 0; num4 < Areas.Count; num4++)
            {
                EverestArea area = GetArea(num4);
                if (area == null || !area.HasMode(0) ||
                    (!instance.DebugMode && !string.IsNullOrEmpty(area.Metadata?.Parent)))
                {
                    continue;
                }

                string levelSet = area.LevelSet;
                string name2 = area.Name;
                string text2 = EverestModuleDialogText.CleanOrNull(engine, name2) ??
                               EverestStringSource.SpacedPascalCase(name2);
                if (levelSet == "Celeste" && num4 > num + num2)
                {
                    continue;
                }

                List<string> source = new List<string>
                {
                    name2,
                    text2,
                    levelSet,
                    ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(levelSet)
                }.Select((string text3) => text3.ToLower()).ToList();
                List<string> list = array.ToList();
                string[] array2 = array;
                foreach (string hunk in array2)
                {
                    if (source.Any((string target) => target.Contains(hunk)))
                    {
                        list.Remove(hunk);
                    }
                }

                if (list.Count > 0)
                {
                    continue;
                }

                itemCount++;
                EverestMenuButtonExt buttonExt = new EverestMenuButtonExt(text2);
                buttonExt.Alpha = 0f;
                if (area.Icon != "areas/null")
                {
                    buttonExt.Icon = area.Icon;
                }

                buttonExt.IconWidth = 64f;
                if (levelSet == "Celeste" && num4 > num + num2)
                {
                    buttonExt.Disabled = true;
                }

                if (text2.ToLower() == search.ToLower())
                {
                    if (!flag)
                    {
                        perfectMatchHeader =
                            new EverestMenuSubHeaderExt(
                                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("maplist_search_match"));
                        menu.rightMenu.Insert(0, perfectMatchHeader);
                        items.Insert(0, perfectMatchHeader);
                        flag = true;
                    }

                    menu.rightMenu.Insert(1, buttonExt.Pressed(delegate
                    {
                        clearSearch();
                        Inspect(area);
                    }));
                    items.Insert(1, buttonExt);
                    if (matchCount > 1)
                    {
                        text = levelSet;
                        OriginalLevelSetStats levelSetStatsFor =
                            ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSetStatsFor(
                                Process.SaveContext.CurrentSave, levelSet);
                        num = levelSetStatsFor.AreaOffset;
                        num2 = levelSetStatsFor.UnlockedAreas;
                        _ = levelSetStatsFor.UnlockedModes;
                        EverestMenuSubHeaderExt subHeaderExt = new EverestMenuSubHeaderExt(
                            ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(levelSet));
                        subHeaderExt.Alpha = 0f;
                        menu.rightMenu.Insert(1, subHeaderExt);
                        items.Insert(1, subHeaderExt);
                    }
                }
                else
                {
                    if (text != levelSet)
                    {
                        text = levelSet;
                        OriginalLevelSetStats levelSetStatsFor2 =
                            ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSetStatsFor(
                                Process.SaveContext.CurrentSave, levelSet);
                        num = levelSetStatsFor2.AreaOffset;
                        num2 = levelSetStatsFor2.UnlockedAreas;
                        _ = levelSetStatsFor2.UnlockedModes;
                        EverestMenuSubHeaderExt subHeaderExt2 = new EverestMenuSubHeaderExt(
                            ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(levelSet));
                        subHeaderExt2.Alpha = 0f;
                        menu.rightMenu.Add(subHeaderExt2);
                        items.Add(subHeaderExt2);
                    }

                    menu.rightMenu.Add(buttonExt.Pressed(delegate
                    {
                        clearSearch();
                        Inspect(area);
                    }));
                    items.Add(buttonExt);
                }
            }

            if (resultHeader != null)
            {
                resultHeader.Title =
                    string.Format(
                        (itemCount == 1)
                            ? ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("maplist_results_singular")
                            : ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("maplist_results_plural"),
                        itemCount);
            }

            menu.rightMenu.BatchMode = false;
            float delayBetweenOptions = 0.03f;
            if (items.Count > 0)
            {
                delayBetweenOptions =
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(0.03f, 1f / (float)items.Count);
            }

            for (int num6 = 0; num6 < items.Count; num6++)
            {
                Add(new SimulationCoroutine(engine, FadeIn(num6, delayBetweenOptions, items[num6])));
            }

            menu.rightMenu.Selection = ((itemCount > 0) ? 1 : 0);
            if (menu.rightMenu.Height > menu.rightMenu.ScrollableMinSize)
            {
                menu.rightMenu.Position = new Vector2(menu.rightMenu.Position.X, menu.rightMenu.ScrollTargetY);
            }

            quickMatched = flag;
            foreach (TextMenuPresentation.Item item2 in items)
            {
                item2.Disabled = Searching;
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
                _ = menu.leftFocused;
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
            searchBarColor = PackedColor.DarkSlateGray;
            searchBarColor.A = 80;
            FromChapterSelect = !(from is EverestMapListSequence);
            Searching = true;
            ReloadMenu();
            menu.rightMenu.MinWidth = menu.rightMenu.Width;
            SearchMenu searchMenu = menu;
            EverestMapSearchSequence ouiMapSearch = this;
            bool visible = true;
            ouiMapSearch.Visible = true;
            searchMenu.Visible = visible;
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
            FromChapterSelect = false;
            MInput.Disabled = false;
            Searching = false;
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

            SearchMenu searchMenu = menu;
            EverestMapSearchSequence ouiMapSearch = this;
            bool visible = false;
            ouiMapSearch.Visible = false;
            searchMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
        }

        private bool switchMenu()
        {
            bool flag = !menu.leftFocused;
            if (flag || items.Count > 1)
            {
                menu.leftFocused = flag;
                Searching = flag;
                MInput.Disabled = flag;
                int num = (quickMatched ? 1 : 2);
                menu.currentMenu.Selection = (flag ? (-1) : num);
                if (flag)
                {
                    Process.AudioSession.Play("event:/ui/main/button_toggle_off");
                }
                else
                {
                    Process.AudioSession.Play("event:/ui/main/button_toggle_on");
                }

                return true;
            }

            return false;
        }

        public override void Update()
        {
            if (Searching)
            {
                if (MInput.Keyboard.Pressed(SourceKeys.Delete))
                {
                    if (search.Length > 0)
                    {
                        clearSearch();
                        Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/main/button_back");
                        cleanExit();
                    }

                    searchConsumedButton = true;
                    MInput.UpdateNull();
                }

                MInput.Disabled = searchConsumedButton;
            }

            searchConsumedButton = false;
            if (menu != null && menu.Focused && base.Selected)
            {
                base.Overworld.Maddy.Show = false;
                if (search != searchPrev)
                {
                    ReloadItems();
                    searchPrev = search;
                }

                if (Input.MenuCancel.Pressed || Input.Pause.Pressed || Input.ESC.Pressed)
                {
                    if (Searching && search != "")
                    {
                        if (!switchMenu())
                        {
                            cleanExit();
                        }
                    }
                    else
                    {
                        cleanExit();
                    }
                }

                if (Input.MenuRight.Pressed)
                {
                    if (!menu.leftFocused)
                    {
                        return;
                    }

                    switchMenu();
                }

                if (Input.MenuLeft.Pressed)
                {
                    if (menu.leftFocused)
                    {
                        return;
                    }

                    switchMenu();
                }
            }

            base.Update();
            if (Searching)
            {
                base.Overworld.Mountain.SetFreeCam(value: false);
            }

            if (menu == null)
            {
                return;
            }

            foreach (TextMenuPresentation.Item item in menu.rightMenu.Items)
            {
                item.Disabled = Searching;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);
            }

            TextMenuPresentation leftMenu = menu.leftMenu;
            if (searchTitle != null)
            {
                Vector2 vector = leftMenu.Position + leftMenu.Justify * new Vector2(leftMenu.Width, leftMenu.Height);
                Vector2 vector2 = new Vector2(vector.X - 200f, vector.Y + leftMenu.GetYOffsetOf(searchTitle) + 1f);
                SourcePrimitiveDrawing.Rect(context, this, vector2 + new Vector2(-8f, 32f), 416f,
                    (int)(ActiveFont.HeightOf("l" + search) + 8f) * -1, searchBarColor);
                ActiveFont.DrawOutline(context, this, search + (Searching ? "_" : ""), vector2, new Vector2(0f, 0.5f),
                    Vector2.One * 0.75f, PackedColor.White * leftMenu.Alpha, 2f,
                    PackedColor.Black * (leftMenu.Alpha * leftMenu.Alpha * leftMenu.Alpha));
            }

            base.Render(context);
        }

        public override void SceneEnd(object scene)
        {
            Searching = false;
            MInput.Disabled = false;
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
