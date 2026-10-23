using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Core.Display;
using Celeste.Game.Settings;
using Celeste.Core.Maps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Audio.Fmod;
using Celeste.Audio.Fmod.Events;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Controls;
using Celeste.Game.Controls.Source;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Presentation.Hud.Counters;
using Celeste.Game.Presentation.Hud.Collectibles;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Save.Progress;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.UI.Menus.Completion;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Menus.Chapters
{
    public class ChapterPanelSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        protected IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)engine).AreaKeys;

        protected OriginalMountainResources MountainResources =>
            ((IOriginalMountainEnvironment)engine).MountainResources;

        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        protected class Option
        {
            protected readonly ISourceEngineContext engine;

            public Option(ISourceEngineContext engine)
            {
                this.engine = engine;
                Bg = Graphics.GuiAtlas["areaselect/tab"];
                BgColor = SourceHexColor.HexToColor("3c6180");
            }

            public Option(ISourceEngineContext engine, ChapterPanelSequence owner) : this(engine) =>
                owner.ApplyOptionBackground(this);

            protected OriginalGameGraphicsResources Graphics =>
                (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

            protected ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
            public string Label;

            public string ID;

            public AtlasEntry Icon;

            public AtlasEntry Bg;

            public PackedColor BgColor;

            public float Pop;

            public bool Large = true;

            public int Siblings;

            public float Slide;

            public float Appear = 1f;

            public float IconEase = 1f;

            public bool Appeared;

            public float Faded;

            public float CheckpointSlideOut;

            public string CheckpointLevelName;

            public float CheckpointRotation;

            public Vector2 CheckpointOffset;

            public float Scale
            {
                get
                {
                    if (Siblings < 5)
                    {
                        return 1f;
                    }

                    return 0.8f;
                }
            }

            public bool OnTopOfUI => Pop > 0.5f;

            public void SlideTowards(int i, int count, bool snap)
            {
                float num = (float)count / 2f - 0.5f;
                float num2 = (float)i - num;
                if (snap)
                {
                    Slide = num2;
                }
                else
                {
                    Slide = ScalarMath.Approach(Slide, num2, engine.DeltaTime * 4f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }
            }

            public Vector2 GetRenderPosition(Vector2 center)
            {
                float num = (float)(Large ? 170 : 130) * Scale;
                if (Siblings > 0 && num * (float)Siblings > 750f)
                {
                    num = 750 / Siblings;
                }

                Vector2 result = center +
                                 new Vector2(Slide * num, (float)Math.Sin(Pop * (float)Math.PI) * 70f - Pop * 12f);
                result.Y += (1f - Easing.CubeOut(Appear)) * -200f;
                result.Y -= (1f - Scale) * 80f;
                return result;
            }

            public void Render(ISourceRenderContext context, object actualEntity, Vector2 center, bool selected,
                OscillationPulseState wiggler, OscillationPulseState appearPulseComponent)
            {
                float num = Scale + (selected ? (wiggler.Value * 0.25f) : 0f) +
                            (Appeared ? (appearPulseComponent.Value * 0.25f) : 0f);
                Vector2 renderPosition = GetRenderPosition(center);
                PackedColor color = SourceColorInterpolation.Lerp(BgColor, PackedColor.Black, (1f - Pop) * 0.6f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                SourceAtlasDrawing.DrawCentered(context, actualEntity, Bg, renderPosition + new Vector2(0f, 10f), color,
                    (Appeared ? Scale : num) * new Vector2(Large ? 1f : 0.9f, 1f));
                if (IconEase > 0f)
                {
                    float num2 = Easing.CubeIn(IconEase);
                    PackedColor color2 = SourceColorInterpolation.Lerp(PackedColor.White, PackedColor.Black,
                        Faded * 0.6f,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic) * num2;
                    SourceAtlasDrawing.DrawCentered(context, actualEntity, Icon, renderPosition, color2,
                        (float)(Bg.FrameWidth - 50) / (float)Icon.FrameWidth * num * (2.5f - num2 * 1.5f));
                }
            }
        }

        public OriginalAreaKey Area;

        public ChapterAreaProgress RealStats;

        public ChapterAreaProgress DisplayedStats;

        public IOriginalAreaData Data;

        public OverworldStartMode OverworldStartMode;

        public bool EnteringChapter;

        public const int ContentOffsetX = 440;

        public const int NoStatsHeight = 300;

        public const int StatsHeight = 540;

        public const int CheckpointsHeight = 730;

        private bool initialized;

        private string chapter = "";

        private bool selectingMode = true;

        private float height;

        private bool resizing;

        private OscillationPulseState wiggler;

        private OscillationPulseState modeAppearPulseComponent;

        private AtlasEntry card = new AtlasEntry();

        private Vector2 contentOffset;

        private float spotlightRadius;

        private float spotlightAlpha;

        private Vector2 spotlightPosition;

        private AreaCompleteTitlePresentation remixUnlockText;

        private readonly StrawberriesCounterState strawberries;

        private Vector2 strawberriesOffset;

        private readonly DeathsCounterState deaths;

        private Vector2 deathsOffset;

        private HeartGemDisplayState heart;

        private Vector2 heartOffset;

        private int checkpoint;

        protected List<Option> modes = new List<Option>();

        protected List<Option> checkpoints = new List<Option>();

        private FmodEventReference bSideUnlockSfx;

        public Vector2 OpenPosition => new Vector2(1070f, 100f);

        public Vector2 ClosePosition => new Vector2(2220f, 100f);

        public Vector2 IconOffset => new Vector2(690f, 86f);

        private Vector2 OptionsRenderPosition => Position + new Vector2(contentOffset.X, 128f + height);

        protected int option
        {
            get
            {
                if (!selectingMode)
                {
                    return checkpoint;
                }

                return (int)Area.Mode;
            }
            set
            {
                if (selectingMode)
                {
                    Area.Mode = value;
                }
                else
                {
                    checkpoint = value;
                }
            }
        }

        protected List<Option> options
        {
            get
            {
                if (!selectingMode)
                {
                    return checkpoints;
                }

                return modes;
            }
        }

        public ChapterPanelSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            strawberries = new StrawberriesCounterState(engine, centeredX: true, 0, 0, showOutOf: true);
            deaths = new DeathsCounterState(engine, OriginalAreaMode.Normal, centeredX: true, 0);
            heart = new HeartGemDisplayState(engine, 0, hasGem: false);
            Add(strawberries);
            Add(deaths);
            Add(heart);
            deaths.CanWiggle = false;
            strawberries.CanWiggle = false;
            strawberries.OverworldSfx = true;
            Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.4f, 4f));
            Add(modeAppearPulseComponent = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.4f, 4f));
        }

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            if (start == OverworldStartMode.AreaComplete || start == OverworldStartMode.AreaQuit)
            {
                bool shouldAdvance = start == OverworldStartMode.AreaComplete &&
                                     (((IOriginalGamePlayModeEnvironment)engine).PlayMode ==
                                      GameRuntime.PlayModes.Event ||
                                      (((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                                       .GetCurrentSessionSafe(Process.SaveContext.CurrentSave) != null &&
                                       ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                                       .GetCurrentSessionSafe(Process.SaveContext.CurrentSave).ShouldAdvance));
                Position = OpenPosition;
                Reset();
                Add(new SimulationCoroutine(engine, IncrementStats(shouldAdvance)));
                overworld.ShowInputUI = false;
                overworld.Mountain.SnapState(Data.MountainState);
                overworld.Mountain.SnapCamera(Area.ID, Data.MountainZoom);
                overworld.Mountain.EaseCamera(Area.ID, Data.MountainSelect, 1f);
                OverworldStartMode = start;
                return true;
            }

            Position = ClosePosition;
            return false;
        }

        public override IEnumerator Enter(OuiState from)
        {
            Visible = true;
            Area.Mode = (int)OriginalAreaMode.Normal;
            Reset();
            if (engine is global::Celeste.Game.Content.Loading.IOriginalChapterPreparationEnvironment preparation)
                preparation.ChapterPreparation?.PrepareArea(Area.ID, Area.Mode);
            base.Overworld.Mountain.EaseCamera(Area.ID, Data.MountainSelect);
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                yield return null;
                Position = ClosePosition + (OpenPosition - ClosePosition) * Easing.CubeOut(p);
            }

            Position = OpenPosition;
        }

        protected virtual void Reset()
        {
            Area = ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetLastAreaSafe(
                Process.SaveContext.CurrentSave);
            Data = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[Area.ID];
            RealStats =
                ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(Process.SaveContext.CurrentSave)
                [Area.ID];
            if (((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetCurrentSessionSafe(
                    Process.SaveContext.CurrentSave) != null &&
                ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                .GetCurrentSessionSafe(Process.SaveContext.CurrentSave).OldStats != null && AreaKeys
                    .GetSessionArea(
                        ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetCurrentSessionSafe(
                            Process.SaveContext.CurrentSave)).ID == Area.ID)
            {
                DisplayedStats = ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                    .GetCurrentSessionSafe(Process.SaveContext.CurrentSave).OldStats;
                ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.SetCurrentSessionSafe(
                    Process.SaveContext.CurrentSave, null);
            }
            else
            {
                DisplayedStats = RealStats;
            }

            height = GetModeHeight();
            modes.Clear();
            bool flag = false;
            if (!GetAreaInterlude(Data) && Data.HasMode((int)OriginalAreaMode.BSide) && (DisplayedStats.Cassette ||
                    ((Process.SaveContext.CurrentSave.DebugMode || Process.SaveContext.CurrentSave.CheatMode) &&
                     DisplayedStats.Cassette == RealStats.Cassette)))
            {
                flag = true;
            }

            bool num = !GetAreaInterlude(Data) && Data.HasMode((int)OriginalAreaMode.CSide) &&
                       ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Process
                           .SaveContext
                           .CurrentSave) >= 3 && ((IOriginalGamePlayModeEnvironment)engine).PlayMode !=
                       GameRuntime.PlayModes.Event;
            modes.Add(new Option(engine, this)
            {
                Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog
                    .Clean(GetAreaInterlude(Data) ? "FILE_BEGIN" : "overworld_normal").ToUpper(),
                Icon = Graphics.GuiAtlas[GetMenuTexture("menu/play")],
                ID = "A"
            });
            if (flag)
            {
                AddRemixButton();
            }

            if (num)
            {
                modes.Add(new Option(engine, this)
                {
                    Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("overworld_remix2"),
                    Icon = Graphics.GuiAtlas[GetMenuTexture("menu/rmx2")],
                    ID = "C"
                });
            }

            selectingMode = true;
            UpdateStats(wiggle: false);
            SetStatsPosition(approach: false);
            for (int i = 0; i < options.Count; i++)
            {
                options[i].SlideTowards(i, options.Count, snap: true);
            }

            chapter = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("area_chapter")
                .Replace("{x}", AreaKeys.GetChapterIndex(Area, engine).ToString().PadLeft(2));
            contentOffset = new Vector2(440f, 120f);
            initialized = true;
        }

        protected virtual int GetModeHeight()
        {
            ChapterModeProgress areaModeStats = RealStats.Modes[GetStatsMode()];
            bool flag = areaModeStats.Strawberries.Count <= 0;
            if (!GetAreaInterlude(Data) && ((areaModeStats.Deaths > 0 && Area.Mode != (int)OriginalAreaMode.Normal) ||
                                            areaModeStats.Completed || areaModeStats.HeartGem))
            {
                flag = false;
            }

            if (!flag)
            {
                return 540;
            }

            return 300;
        }

        protected Option AddRemixButton()
        {
            Option option = new Option(engine)
            {
                Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("overworld_remix"),
                Icon = Graphics.GuiAtlas[GetMenuTexture("menu/remix")],
                ID = "B"
            };
            ApplyOptionBackground(option);
            modes.Insert(1, option);
            return option;
        }

        public override IEnumerator Leave(OuiState next)
        {
            base.Overworld.Mountain.EaseCamera(Area.ID, Data.MountainIdle);
            Add(new SimulationCoroutine(engine, EaseOut()));
            yield break;
        }

        public IEnumerator EaseOut(bool removeChildren = true)
        {
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                Position = OpenPosition + (ClosePosition - OpenPosition) * Easing.CubeIn(p);
                yield return null;
            }

            if (!base.Selected)
            {
                Visible = false;
            }
        }

        public void Start(string checkpoint = null)
        {
            Focused = false;
            Process.AudioSession.Play("event:/ui/world_map/chapter/checkpoint_start");
            Add(new SimulationCoroutine(engine, StartRoutine(checkpoint)));
        }

        private IEnumerator StartRoutine(string checkpoint = null)
        {
            EnteringChapter = true;
            base.Overworld.Maddy.Hide(down: false);
            base.Overworld.Mountain.EaseCamera(Area.ID, Data.MountainZoom, 1f);
            Add(new SimulationCoroutine(engine, EaseOut(removeChildren: false)));
            yield return 0.2f;
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = PackedColor.Black;
            AreaKeys.GetArea(Area).Wipe(base.Overworld, false, null);
            Process.AudioSession.SetMusic(null);
            Process.AudioSession.SetAmbience(null);
            if ((Area.ID == 0 || Area.ID == 9) && checkpoint == null && Area.Mode == (int)OriginalAreaMode.Normal)
            {
                base.Overworld.Renderers.UpdateLists();
                base.Overworld.Renderers.MoveToFront(base.Overworld.Snow);
            }

            yield return 0.5f;
            OriginalLevelEntryRouting.Go(CreateStartSession(checkpoint), false, engine.Frame.Scenes,
                ((IOriginalLevelEntryEnvironment)engine).LevelEntries);
        }

        private void Swap()
        {
            Focused = false;
            base.Overworld.ShowInputUI = !selectingMode;
            Add(new SimulationCoroutine(engine, SwapRoutine()));
        }

        private IEnumerator SwapRoutine()
        {
            float fromHeight = height;
            int toHeight = (selectingMode ? GetCheckpointPanelHeight() : GetModeHeight());
            resizing = true;
            PlayExpandSfx(fromHeight, toHeight);
            float offset = 800f;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                yield return null;
                contentOffset.X = 440f + offset * Easing.CubeIn(p);
                height = ScalarMath.Lerp(fromHeight, toHeight, Easing.CubeOut(p * 0.5f),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            }

            selectingMode = !selectingMode;
            if (!selectingMode)
            {
                HashSet<string> hashSet = GetPanelCheckpoints();
                int siblings = hashSet.Count + 1;
                checkpoints.Clear();
                checkpoints.Add(new Option(engine, this)
                {
                    Label = GetStartLabel(),
                    BgColor = SourceHexColor.HexToColor("eabe26"),
                    Icon = Graphics.GuiAtlas[GetAreaselectTexture("areaselect/startpoint")],
                    CheckpointLevelName = null,
                    CheckpointRotation = (float)RandomSelection.Choose<int>(Random, -1, 1) *
                                         SourceRandomMath.Range(Random, 0.05f, 0.2f),
                    CheckpointOffset = new Vector2(SourceRandomMath.Range(Random, -16, 16),
                        SourceRandomMath.Range(Random, -16, 16)),
                    Large = false,
                    Siblings = siblings
                });
                foreach (string item in hashSet)
                {
                    checkpoints.Add(new Option(engine, this)
                    {
                        Label = GetCheckpointLabel(item),
                        Icon = Graphics.GuiAtlas[GetAreaselectTexture("areaselect/checkpoint")],
                        CheckpointLevelName = item,
                        CheckpointRotation = (float)RandomSelection.Choose<int>(Random, -1, 1) *
                                             SourceRandomMath.Range(Random, 0.05f, 0.2f),
                        CheckpointOffset = new Vector2(SourceRandomMath.Range(Random, -16, 16),
                            SourceRandomMath.Range(Random, -16, 16)),
                        Large = false,
                        Siblings = siblings
                    });
                }

                if (!RealStats.Modes[(int)Area.Mode].Completed && !Process.SaveContext.CurrentSave.DebugMode &&
                    !Process.SaveContext.CurrentSave.CheatMode)
                {
                    option = checkpoints.Count - 1;
                    for (int i = 0; i < checkpoints.Count - 1; i++)
                    {
                        options[i].CheckpointSlideOut = 1f;
                    }
                }
                else
                {
                    option = 0;
                }

                OnCheckpointOptionsCreated();
                for (int j = 0; j < options.Count; j++)
                {
                    options[j].SlideTowards(j, options.Count, snap: true);
                }
            }

            options[option].Pop = 1f;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                yield return null;
                height = ScalarMath.Lerp(fromHeight, toHeight,
                    Easing.CubeOut(((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f, 0.5f + p * 0.5f)),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                contentOffset.X = 440f + offset * (1f - Easing.CubeOut(p));
            }

            contentOffset.X = 440f;
            height = toHeight;
            Focused = true;
            resizing = false;
        }

        public override void Update()
        {
            if (!initialized)
            {
                return;
            }

            base.Update();
            for (int i = 0; i < options.Count; i++)
            {
                Option option = options[i];
                option.Pop = ScalarMath.Approach(option.Pop, (this.option == i) ? 1f : 0f, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                option.Appear = ScalarMath.Approach(option.Appear, 1f, engine.DeltaTime * 3f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                option.CheckpointSlideOut = ScalarMath.Approach(option.CheckpointSlideOut, (this.option > i) ? 1 : 0,
                    engine.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                option.Faded = ScalarMath.Approach(option.Faded, (this.option != i && !option.Appeared) ? 1 : 0,
                    engine.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                option.SlideTowards(i, options.Count, snap: false);
            }

            if (selectingMode && !resizing)
            {
                height = ScalarMath.Approach(height, GetModeHeight(), engine.DeltaTime * 1600f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            if (base.Selected && Focused)
            {
                if (Input.MenuLeft.Pressed && this.option > 0)
                {
                    Process.AudioSession.Play("event:/ui/world_map/chapter/tab_roll_left");
                    this.option--;
                    wiggler.Start();
                    if (selectingMode)
                    {
                        UpdateStats();
                        PlayExpandSfx(height, GetModeHeight());
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/world_map/chapter/checkpoint_photo_add");
                    }
                }
                else if (Input.MenuRight.Pressed && this.option + 1 < options.Count)
                {
                    Process.AudioSession.Play("event:/ui/world_map/chapter/tab_roll_right");
                    this.option++;
                    wiggler.Start();
                    if (selectingMode)
                    {
                        UpdateStats();
                        PlayExpandSfx(height, GetModeHeight());
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/world_map/chapter/checkpoint_photo_remove");
                    }
                }
                else if (Input.MenuConfirm.Pressed)
                {
                    if (selectingMode)
                    {
                        if (!ShouldUseCheckpointSubmenu())
                        {
                            Start();
                        }
                        else
                        {
                            Process.AudioSession.Play("event:/ui/world_map/chapter/level_select");
                            Swap();
                        }
                    }
                    else
                    {
                        Start(options[this.option].CheckpointLevelName);
                    }
                }
                else if (Input.MenuCancel.Pressed)
                {
                    if (selectingMode)
                    {
                        Process.AudioSession.Play("event:/ui/world_map/chapter/back");
                        base.Overworld.Goto<ChapterSelectSequence>();
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/world_map/chapter/checkpoint_back");
                        Swap();
                    }
                }
            }

            SetStatsPosition(approach: true);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!initialized)
            {
                return;
            }

            Vector2 optionsRenderPosition = OptionsRenderPosition;
            for (int i = 0; i < options.Count; i++)
            {
                if (!options[i].OnTopOfUI)
                {
                    options[i].Render(context, this, optionsRenderPosition, option == i, wiggler,
                        modeAppearPulseComponent);
                }
            }

            bool flag = false;
            if (RealStats.Modes[GetStatsMode()].Completed)
            {
                int mode = GetStatsMode();
                foreach (OriginalLevelEntityData goldenberry in ((IOriginalSessionConstructionProcess)engine).AreaTable
                         .Areas[Area.ID].Mode[mode].MapData.Goldenberries)
                {
                    MapEntityId item = new MapEntityId(goldenberry.Level.Name, goldenberry.ID);
                    if (RealStats.Modes[mode].Strawberries.Contains(item))
                    {
                        flag = true;
                        break;
                    }
                }
            }

            AtlasEntry mTexture =
                Graphics.GuiAtlas[
                    (!flag)
                        ? GetAreaselectTexture("areaselect/cardtop")
                        : GetAreaselectTexture("areaselect/cardtop_golden")];
            SourceAtlasDrawing.Draw(context, this, mTexture, Position + new Vector2(0f, -32f));
            AtlasEntry mTexture2 =
                Graphics.GuiAtlas[
                    (!flag) ? GetAreaselectTexture("areaselect/card") : GetAreaselectTexture("areaselect/card_golden")];
            card = mTexture2.GetSubtexture(0, mTexture2.FrameHeight - (int)height, mTexture2.FrameWidth, (int)height,
                card);
            SourceAtlasDrawing.Draw(context, this, card, Position + new Vector2(0f, -32 + mTexture.FrameHeight));
            for (int j = 0; j < options.Count; j++)
            {
                if (options[j].OnTopOfUI)
                {
                    options[j].Render(context, this, optionsRenderPosition, option == j, wiggler,
                        modeAppearPulseComponent);
                }
            }

            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this, options[option].Label,
                optionsRenderPosition + new Vector2(0f, -140f), Vector2.One * 0.5f,
                Vector2.One * (1f + wiggler.Value * 0.1f), PackedColor.Black * 0.8f);
            if (selectingMode)
            {
                strawberries.Position = contentOffset + new Vector2(0f, 170f) + strawberriesOffset;
                deaths.Position = contentOffset + new Vector2(0f, 170f) + deathsOffset;
                heart.Position = contentOffset + new Vector2(0f, 170f) + heartOffset;
                base.Render(context);
            }

            if (!selectingMode)
            {
                Vector2 center = Position + new Vector2(contentOffset.X, 340f);
                for (int num = options.Count - 1; num >= 0; num--)
                {
                    DrawCheckpoint(context, center, options[num], num);
                }
            }

            SourceAtlasDrawing.Draw(context, this, Graphics.GuiAtlas[GetAreaselectTexture("areaselect/title")],
                Position + new Vector2(GetTitleOffset(-60f), 0f), Vector2.Zero, Data.TitleBaseColor);
            SourceAtlasDrawing.Draw(context, this, Graphics.GuiAtlas[GetAreaselectTexture("areaselect/accent")],
                Position + new Vector2(GetTitleOffset(-60f), 0f), Vector2.Zero, Data.TitleAccentColor);
            string text = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean(AreaKeys.GetArea(Area).Name);
            if (GetAreaInterlude(Data))
            {
                ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this, text,
                    Position + IconOffset + new Vector2(-100f, 0f), new Vector2(1f, 0.5f), Vector2.One * 1f,
                    Data.TitleTextColor * 0.8f);
            }
            else
            {
                ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this, chapter,
                    Position + IconOffset + new Vector2(-100f, -2f), new Vector2(1f, 1f), Vector2.One * 0.6f,
                    Data.TitleAccentColor * 0.8f);
                ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this, text,
                    Position + IconOffset + new Vector2(-100f, -18f), new Vector2(1f, 0f), Vector2.One * 1f,
                    Data.TitleTextColor * 0.8f);
            }

            if (spotlightAlpha > 0f)
            {
                OriginalHiresRendererBatch.EndRender(context);
                SpotlightWipePresentation.DrawSpotlight(engine, spotlightPosition, spotlightRadius,
                    PackedColor.Black * spotlightAlpha);
                OriginalHiresRendererBatch.BeginRender(context);
            }
        }

        protected virtual void DrawCheckpoint(ISourceRenderContext context, Vector2 center, Option option,
            int checkpointIndex)
        {
            AtlasEntry checkpointPreview = GetCheckpointPreview(Area, option.CheckpointLevelName);
            AtlasEntry mTexture = MountainResources.Checkpoints["polaroid"];
            float checkpointRotation = option.CheckpointRotation;
            Vector2 vector = center + option.CheckpointOffset;
            vector += Vector2.UnitX * 800f * Easing.CubeIn(option.CheckpointSlideOut);
            SourceAtlasDrawing.DrawCentered(context, this, mTexture, vector, PackedColor.White, 0.75f,
                checkpointRotation);
            AtlasEntry mTexture2 = Graphics.GuiAtlas["collectables/strawberry"];
            if (checkpointPreview != null)
            {
                Vector2 scale = Vector2.One * 0.75f;
                if (Process.SaveContext.CurrentSave.Assists.MirrorMode)
                {
                    scale.X = 0f - scale.X;
                }

                scale *= 720f / (float)checkpointPreview.FrameWidth;
                OriginalHiresRendererBatch.EndRender(context);
                OriginalHiresRendererBatch.BeginRender(context, SourceBlendState.AlphaBlend,
                    SourceSamplerState.PointClamp);
                SourceAtlasDrawing.DrawCentered(context, this, checkpointPreview, vector, PackedColor.White, scale,
                    checkpointRotation);
                OriginalHiresRendererBatch.EndRender(context);
                OriginalHiresRendererBatch.BeginRender(context);
            }

            int mode = (int)Area.Mode;
            if (!RealStats.Modes[mode].Completed && !Process.SaveContext.CurrentSave.CheatMode &&
                !Process.SaveContext.CurrentSave.DebugMode)
            {
                return;
            }

            Vector2 vec = new Vector2(300f, 220f);
            vec = vector + ((ISourceVectorEnvironment)engine).VectorArithmetic.Rotate(vec, checkpointRotation);
            int num = 0;
            num = ((checkpointIndex != 0)
                ? Data.Mode[mode].Checkpoints[checkpointIndex - 1].Strawberries
                : Data.Mode[mode].StartStrawberries);
            bool[] array = new bool[num];
            foreach (MapEntityId strawberry in RealStats.Modes[mode].Strawberries)
            {
                for (int i = 0; i < num; i++)
                {
                    OriginalLevelEntityData entityData = Data.Mode[mode].StrawberriesByCheckpoint[checkpointIndex, i];
                    if (entityData != null && entityData.Level.Name == strawberry.Level &&
                        entityData.ID == strawberry.ID)
                    {
                        array[i] = true;
                    }
                }
            }

            Vector2 vector2 = Vector2Geometry.AngleToVector(checkpointRotation, 1f);
            Vector2 vector3 =
                CorrectInitialStrawberryOffset(
                    vec - vector2 * num * GetStrawberryWidth(44f, array.Length, checkpointIndex),
                    vector2);
            if (Area.Mode == (int)OriginalAreaMode.Normal && Data.CassetteCheckpointIndex == checkpointIndex)
            {
                Vector2 position = vector3 - vector2 * 60f;
                if (RealStats.Cassette)
                {
                    SourceAtlasDrawing.DrawCentered(context, this, MountainResources.Journal["cassette"], position,
                        PackedColor.White, 1f, checkpointRotation);
                }
                else
                {
                    SourceAtlasDrawing.DrawCentered(context, this, MountainResources.Journal["cassette_outline"],
                        position,
                        PackedColor.DarkGray, 1f, checkpointRotation);
                }
            }

            for (int j = 0; j < num; j++)
            {
                SourceAtlasDrawing.DrawCentered(context, this, mTexture2, vector3,
                    array[j] ? PackedColor.White : (PackedColor.Black * 0.3f), 0.5f, checkpointRotation);
                vector3 += vector2 * GetStrawberryWidth(44f, array.Length, checkpointIndex);
            }
        }

        protected virtual void UpdateStats(bool wiggle = true, bool? overrideStrawberryWiggle = null,
            bool? overrideDeathWiggle = null, bool? overrideHeartWiggle = null)
        {
            ChapterModeProgress areaModeStats = DisplayedStats.Modes[GetStatsMode()];
            IOriginalAreaData areaData = AreaKeys.GetArea(Area);
            deaths.Visible = areaModeStats.Deaths > 0 &&
                             (Area.Mode != (int)OriginalAreaMode.Normal || RealStats.Modes[(int)Area.Mode].Completed) &&
                             !GetAreaInterlude(AreaKeys.GetArea(Area));
            deaths.Amount = areaModeStats.Deaths;
            deaths.SetMode((OriginalAreaMode)(Data.IsFinal ? (int)OriginalAreaMode.CSide : Area.Mode));
            heart.Visible = areaModeStats.HeartGem && !Data.Interlude && areaData.CanFullClear;
            heart.SetCurrentMode((OriginalAreaMode)Area.Mode, areaModeStats.HeartGem);
            strawberries.Visible =
                (areaModeStats.TotalStrawberries > 0 || (areaModeStats.Completed &&
                                                         Area.Mode == (int)OriginalAreaMode.Normal &&
                                                         AreaKeys.GetArea(Area).Mode[0].TotalStrawberries > 0)) &&
                !GetAreaInterlude(AreaKeys.GetArea(Area));
            strawberries.Amount = areaModeStats.TotalStrawberries;
            strawberries.OutOf = Data.Mode[0].TotalStrawberries;
            strawberries.ShowOutOf = areaModeStats.Completed && Area.Mode == (int)OriginalAreaMode.Normal;
            strawberries.Golden = Area.Mode != (int)OriginalAreaMode.Normal;
            if (wiggle)
            {
                if (strawberries.Visible && (!overrideStrawberryWiggle.HasValue || overrideStrawberryWiggle.Value))
                {
                    strawberries.Wiggle();
                }

                if (heart.Visible && (!overrideHeartWiggle.HasValue || overrideHeartWiggle.Value))
                {
                    heart.Wiggle();
                }

                if (deaths.Visible && (!overrideDeathWiggle.HasValue || overrideDeathWiggle.Value))
                {
                    deaths.Wiggle();
                }
            }
        }

        private void SetStatsPosition(bool approach)
        {
            if (heart.Visible && (strawberries.Visible || deaths.Visible))
            {
                heartOffset = Approach(heartOffset, new Vector2(-120f, 0f), !approach);
                strawberriesOffset = Approach(strawberriesOffset, new Vector2(120f, deaths.Visible ? (-40) : 0),
                    !approach);
                deathsOffset = Approach(deathsOffset, new Vector2(120f, strawberries.Visible ? 40 : 0), !approach);
            }
            else if (heart.Visible)
            {
                heartOffset = Approach(heartOffset, Vector2.Zero, !approach);
            }
            else
            {
                strawberriesOffset = Approach(strawberriesOffset, new Vector2(0f, deaths.Visible ? (-40) : 0),
                    !approach);
                deathsOffset = Approach(deathsOffset, new Vector2(0f, strawberries.Visible ? 40 : 0), !approach);
            }
        }

        private Vector2 Approach(Vector2 from, Vector2 to, bool snap)
        {
            if (snap)
            {
                return to;
            }

            return from += (to - from) * (1f - (float)Math.Pow(0.0010000000474974513, engine.DeltaTime));
        }

        private IEnumerator IncrementStatsDisplay(ChapterModeProgress modeStats, ChapterModeProgress newModeStats,
            bool doHeartGem, bool doStrawberries, bool doDeaths, bool doRemixUnlock)
        {
            if (doHeartGem)
            {
                Process.AudioSession.Play("event:/ui/postgame/crystal_heart");
                heart.Visible = true;
                heart.SetCurrentMode((OriginalAreaMode)Area.Mode, has: true);
                heart.Appear((OriginalAreaMode)Area.Mode);
                yield return 1.8f;
            }

            if (doStrawberries)
            {
                strawberries.CanWiggle = true;
                strawberries.Visible = true;
                while (newModeStats.TotalStrawberries > modeStats.TotalStrawberries)
                {
                    int num = newModeStats.TotalStrawberries - modeStats.TotalStrawberries;
                    if (num < 3)
                    {
                        yield return 0.3f;
                    }
                    else if (num < 8)
                    {
                        yield return 0.2f;
                    }
                    else
                    {
                        yield return 0.1f;
                        modeStats.TotalStrawberries++;
                    }

                    modeStats.TotalStrawberries++;
                    strawberries.Amount = modeStats.TotalStrawberries;
                    Input.Rumble(RumbleStrength.Light, RumbleLength.Short);
                }

                strawberries.CanWiggle = false;
                yield return 0.5f;
                if (newModeStats.Completed && !modeStats.Completed && Area.Mode == (int)OriginalAreaMode.Normal)
                {
                    yield return 0.25f;
                    Process.AudioSession.Play((strawberries.Amount >= Data.Mode[0].TotalStrawberries)
                        ? "event:/ui/postgame/strawberry_total_all"
                        : "event:/ui/postgame/strawberry_total");
                    strawberries.OutOf = Data.Mode[0].TotalStrawberries;
                    strawberries.ShowOutOf = true;
                    strawberries.Wiggle();
                    modeStats.Completed = true;
                    Input.Rumble(RumbleStrength.Light, RumbleLength.Medium);
                    yield return 0.6f;
                }
            }

            if (doDeaths)
            {
                Process.AudioSession.Play("event:/ui/postgame/death_appear");
                deaths.CanWiggle = true;
                deaths.Visible = true;
                while (newModeStats.Deaths > modeStats.Deaths)
                {
                    int add;
                    yield return HandleDeathTick(modeStats.Deaths, newModeStats.Deaths, out add);
                    modeStats.Deaths += add;
                    deaths.Amount = modeStats.Deaths;
                    if (modeStats.Deaths >= newModeStats.Deaths)
                    {
                        Process.AudioSession.Play("event:/ui/postgame/death_final");
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/postgame/death_count");
                    }

                    Input.Rumble(RumbleStrength.Light, RumbleLength.Short);
                }

                yield return 0.8f;
                deaths.CanWiggle = false;
            }

            if (doRemixUnlock)
            {
                bSideUnlockSfx = Process.AudioSession.Play("event:/ui/postgame/unlock_bside");
                Option o = AddRemixButton();
                o.Appear = 0f;
                o.IconEase = 0f;
                o.Appeared = true;
                yield return 0.5f;
                spotlightPosition = o.GetRenderPosition(OptionsRenderPosition);
                for (float t = 0f; t < 1f; t += engine.DeltaTime / 0.5f)
                {
                    spotlightAlpha = t * 0.9f;
                    spotlightRadius = 128f * Easing.CubeOut(t);
                    yield return null;
                }

                yield return 0.3f;
                while ((o.IconEase += engine.DeltaTime * 2f) < 1f)
                {
                    yield return null;
                }

                o.IconEase = 1f;
                modeAppearPulseComponent.Start();
                Input.Rumble(RumbleStrength.Medium, RumbleLength.Medium);
                remixUnlockText = new AreaCompleteTitlePresentation(spotlightPosition + new Vector2(0f, 80f),
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("OVERWORLD_REMIX_UNLOCKED"), 1f, engine);
                remixUnlockText.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
                base.Overworld.SourceScene.QueueSourceEntity(remixUnlockText);
                yield return 1.5f;
                for (float t = 0f; t < 1f; t += engine.DeltaTime / 0.5f)
                {
                    spotlightAlpha = (1f - t) * 0.5f;
                    spotlightRadius = 128f + 128f * Easing.CubeOut(t);
                    remixUnlockText.Alpha = 1f - Easing.CubeOut(t);
                    yield return null;
                }

                remixUnlockText.RemoveSelf();
                remixUnlockText = null;
                o.Appeared = false;
            }
        }

        public IEnumerator IncrementStats(bool shouldAdvance)
        {
            Focused = false;
            base.Overworld.ShowInputUI = false;
            if (GetAreaInterlude(Data))
            {
                if (shouldAdvance && OverworldStartMode == OverworldStartMode.AreaComplete)
                {
                    yield return 1.2f;
                    base.Overworld.Goto<ChapterSelectSequence>().AdvanceToNext();
                }
                else
                {
                    Focused = true;
                }

                yield return null;
                yield break;
            }

            IOriginalAreaData data = Data;
            ChapterAreaProgress displayedStats = DisplayedStats;
            ChapterAreaProgress areaStats =
                ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(Process.SaveContext.CurrentSave)
                [data.ID];
            ChapterModeProgress modeStats = displayedStats.Modes[(int)Area.Mode];
            ChapterModeProgress newModeStats = areaStats.Modes[(int)Area.Mode];
            bool doStrawberries = newModeStats.TotalStrawberries > modeStats.TotalStrawberries;
            bool doHeartGem = newModeStats.HeartGem && !modeStats.HeartGem;
            bool doDeaths = newModeStats.Deaths > modeStats.Deaths &&
                            (Area.Mode != (int)OriginalAreaMode.Normal || newModeStats.Completed);
            bool doRemixUnlock = Area.Mode == (int)OriginalAreaMode.Normal &&
                                 data.HasMode((int)OriginalAreaMode.BSide) &&
                                 areaStats.Cassette && !displayedStats.Cassette;
            if (doStrawberries || doHeartGem || doDeaths || doRemixUnlock)
            {
                yield return 0.8f;
            }

            bool skipped = false;
            SimulationCoroutine routine = new SimulationCoroutine(engine,
                IncrementStatsDisplay(modeStats, newModeStats, doHeartGem, doStrawberries, doDeaths, doRemixUnlock));
            Add(routine);
            yield return null;
            while (!routine.Finished)
            {
                if (((ISourceMInputEnvironment)engine).MInput.GamePads[0].Pressed(SourceGamePadButtonFlags.Start) ||
                    ((ISourceMInputEnvironment)engine).MInput.Keyboard.Pressed(SourceKeys.Enter))
                {
                    routine.Active = false;
                    routine.RemoveSelf();
                    skipped = true;
                    bSideUnlockSfx?.Stop(true);
                    Process.AudioSession.Play("event:/new_content/ui/skip_all");
                    break;
                }

                yield return null;
            }

            if (skipped && doRemixUnlock)
            {
                spotlightAlpha = 0f;
                spotlightRadius = 0f;
                if (remixUnlockText != null)
                {
                    remixUnlockText.RemoveSelf();
                    remixUnlockText = null;
                }

                if (modes.Count <= 1 || modes[1].ID != "B")
                {
                    AddRemixButton();
                }
                else
                {
                    Option obj = modes[1];
                    obj.IconEase = 1f;
                    obj.Appear = 1f;
                    obj.Appeared = false;
                }
            }

            DisplayedStats = RealStats;
            if (skipped)
            {
                doStrawberries = doStrawberries && modeStats.TotalStrawberries != newModeStats.TotalStrawberries;
                doDeaths &= modeStats.Deaths != newModeStats.Deaths;
                doHeartGem = doHeartGem && !heart.Visible;
                UpdateStats(wiggle: true, doStrawberries, doDeaths, doHeartGem);
            }

            yield return null;
            if (shouldAdvance && OverworldStartMode == OverworldStartMode.AreaComplete)
            {
                if ((!doDeaths && !doStrawberries && !doHeartGem) ||
                    ((ISettingsContext)engine).Settings.SpeedrunClock != 0)
                {
                    yield return 1.2f;
                }

                base.Overworld.Goto<ChapterSelectSequence>().AdvanceToNext();
            }
            else
            {
                Focused = true;
                base.Overworld.ShowInputUI = true;
            }
        }

        private float HandleDeathTick(int oldDeaths, int newDeaths, out int add)
        {
            int num = newDeaths - oldDeaths;
            if (num < 3)
            {
                add = 1;
                return 0.3f;
            }

            if (num < 8)
            {
                add = 2;
                return 0.2f;
            }

            if (num < 30)
            {
                add = 5;
                return 0.1f;
            }

            if (num < 100)
            {
                add = 10;
                return 0.1f;
            }

            if (num < 1000)
            {
                add = 25;
                return 0.1f;
            }

            add = 100;
            return 0.1f;
        }

        private void PlayExpandSfx(float currentHeight, float nextHeight)
        {
            if (nextHeight > currentHeight)
            {
                Process.AudioSession.Play("event:/ui/world_map/chapter/pane_expand");
            }
            else if (nextHeight < currentHeight)
            {
                Process.AudioSession.Play("event:/ui/world_map/chapter/pane_contract");
            }
        }

        public static string GetCheckpointPreviewName(OriginalAreaKey area, string level, ISourceEngineContext engine)
        {
            if (level == null)
            {
                return ((IOriginalAreaKeyEnvironment)engine).AreaKeys.Format(area);
            }

            return ((IOriginalAreaKeyEnvironment)engine).AreaKeys.Format(area) + "_" + level;
        }

        protected virtual AtlasEntry GetCheckpointPreview(OriginalAreaKey area, string level)
        {
            string checkpointPreviewName = GetCheckpointPreviewName(area, level, engine);
            if (MountainResources.Checkpoints.Has(checkpointPreviewName))
            {
                return MountainResources.Checkpoints[checkpointPreviewName];
            }

            return null;
        }

        protected virtual HashSet<string> GetPanelCheckpoints()
            => ((IOriginalSaveCheckpointEnvironment)engine).SaveCheckpoints.GetCheckpoints(
                Process.SaveContext.CurrentSave,
                Area);

        protected virtual string GetStartLabel()
            => ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("overworld_start");

        protected virtual string GetCheckpointLabel(string level)
            => AreaKeys.GetCheckpointName(Area, level, engine);

        protected virtual string GetAreaselectTexture(string path) => path;
        protected virtual string GetMenuTexture(string path) => path;
        protected virtual float GetTitleOffset(float originalValue) => originalValue;

        protected virtual float GetStrawberryWidth(float originalValue, int strawberryCount, int checkpointIndex) =>
            originalValue;

        protected virtual Vector2 CorrectInitialStrawberryOffset(Vector2 offset, Vector2 direction) => offset;

        protected virtual void ApplyOptionBackground(Option option)
        {
        }

        protected virtual bool GetAreaInterlude(IOriginalAreaData area) => area.Interlude;
        protected virtual bool GetAreaIsFinal(IOriginalAreaData area) => area.IsFinal;

        protected virtual ChapterCompletionSession CreateStartSession(string checkpoint) =>
            ((IOriginalSessionEnvironment)engine).Sessions.CreateSession(Area, checkpoint);

        protected virtual int GetStatsMode() => Area.Mode;
        protected virtual int GetCheckpointPanelHeight() => CheckpointsHeight;

        protected virtual bool ShouldUseCheckpointSubmenu() =>
            ((IOriginalSaveCheckpointEnvironment)engine).SaveCheckpoints.FoundAnyCheckpoints(
                Process.SaveContext.CurrentSave, Area);

        protected virtual void OnCheckpointOptionsCreated()
        {
        }
    }
}
