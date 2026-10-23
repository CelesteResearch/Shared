using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Serialization.Xml;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Files;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Formatting;
using Celeste.Game.Presentation.Hud.Counters;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Runtime;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Menus.Files
{
    public class EverestFileSelectSlotState : SceneEntityState, ISourceFileSelectSlot
    {
        void ISourceFileSelectSlot.CreateButtons()
        {
            CreateButtons();
        }

        int ISourceFileSelectSlot.FileSlot => FileSlot;

        string ISourceFileSelectSlot.Name
        {
            get => Name;
            set => Name = value;
        }

        bool ISourceFileSelectSlot.AssistModeEnabled
        {
            get => AssistModeEnabled;
            set => AssistModeEnabled = value;
        }

        bool ISourceFileSelectSlot.VariantModeEnabled
        {
            get => VariantModeEnabled;
            set => VariantModeEnabled = value;
        }

        bool ISourceFileSelectSlot.Exists
        {
            get => Exists;
            set => Exists = value;
        }

        bool ISourceFileSelectSlot.Corrupted
        {
            get => Corrupted;
            set => Corrupted = value;
        }

        bool ISourceFileSelectSlot.StartingGame
        {
            get => StartingGame;
            set => StartingGame = value;
        }

        bool ISourceFileSelectSlot.Renaming
        {
            get => Renaming;
            set => Renaming = value;
        }

        bool ISourceFileSelectSlot.Assisting
        {
            get => Assisting;
            set => Assisting = value;
        }

        OriginalSaveDataState ISourceFileSelectSlot.SaveData => SaveData;

        protected readonly ISourceEngineContext engine;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected OriginalMountainResources MountainResources =>
            ((IOriginalMountainEnvironment)engine).MountainResources;

        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public class Button
        {
            public string Label;

            public Action Action;

            public float Scale = 1f;
        }

        /// <summary>
        ///     Interface used to tag EverestFileSelectSlotState submenus.
        /// </summary>
        public interface ISubmenu;

        public OriginalSaveDataState SaveData;

        public int FileSlot;

        public string Name;

        public bool AssistModeEnabled;

        public bool VariantModeEnabled;

        public bool Exists;

        public bool Corrupted;

        public string Time;

        public int FurthestArea;

        public Sprite Portrait;

        public bool HasBlackgems;

        public StrawberriesCounterState Strawberries;

        public DeathsCounterState Deaths;

        public List<bool> Cassettes = [];

        public List<bool[]> HeartGems = [];

        private const int height = 300;

        private const int spacing = 10;

        private const float portraitSize = 200f;

        public bool StartingGame;

        public bool Renaming;

        public bool Assisting;

        private readonly FileSelectSequence fileSelect;

        private bool deleting;

        private float highlightEase;

        private float highlightEaseDelay;

        private float selectedEase;

        private float deletingEase;

        private SourceTweenState tween;

        private int buttonIndex;

        private int deleteIndex;

        private readonly WigglerComponent wiggler;

        private float failedToDeleteEase;

        private float failedToDeleteTimer;

        private float screenFlash;

        private float inputDelay;

        private float newgameFade;

        private readonly float timeScale = 1f;

        private Button assistButton;

        private Button variantButton;

        private readonly Sprite normalCard;

        private readonly Sprite goldCard;

        private readonly Sprite normalTicket;

        private readonly Sprite goldTicket;

        private readonly List<Button> buttons = [];

        private EverestFileSelectSlotStateLevelSetPicker newGameLevelSetPicker;

        public bool MissingVanillaData;

        private int maxStrawberryCount;

        private int maxGoldenStrawberryCount;

        private int maxStrawberryCountIncludingUntracked;

        private int maxCassettes;

        private int maxCrystalHeartsExcludingCSides;

        private int maxCrystalHearts;

        private bool summitStamp;

        private bool farewellStamp;

        private int totalGoldenStrawberries;

        private int totalHeartGems;

        private int totalCassettes;

        private bool renamed;

        public Vector2 IdlePosition => new(960f,
            540 + 310 * (FileSlot -
                         SourceFrameworkMath.Clamp(fileSelect.SlotIndex, 1,
                             fileSelect.Slots.Length - 2)));

        public Vector2 SelectedPosition => new(960f, 440f);

        private bool highlighted
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => fileSelect.SlotIndex == FileSlot;
        }

        private bool selected
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => fileSelect.SlotSelected ? highlighted : false;
        }

        private bool Golden
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (!Corrupted && Exists)
                    return ((IOriginalSaveCollectibleTotalsEnvironment)engine).SaveCollectibleTotals
                        .GetTotalStrawberriesSafe(SaveData) >= maxStrawberryCountIncludingUntracked;

                return false;
            }
        }

        private Sprite Card
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => !Golden ? normalCard : goldCard;
        }

        private Sprite Ticket
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => !Golden ? normalTicket : goldTicket;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private EverestFileSelectSlotState(ISourceEngineContext engine, int index, FileSelectSequence fileSelect) :
            base(
                ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            FileSlot = index;
            this.fileSelect = fileSelect;
            Tags |= ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            Visible = false;
            Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.4f, 4f));
            normalTicket = new(engine, MountainResources.FileSelect, "ticket");
            normalTicket.AddLoop("idle", "", 0.1f);
            normalTicket.Add("shine", "", 0.1f, "idle");
            normalTicket.CenterOrigin();
            normalTicket.Play("idle");
            normalCard = new(engine, MountainResources.FileSelect, "card");
            normalCard.AddLoop("idle", "", 0.1f);
            normalCard.Add("shine", "", 0.1f, "idle");
            normalCard.CenterOrigin();
            normalCard.Play("idle");
            goldTicket = new(engine, MountainResources.FileSelect, "ticketShine");
            goldTicket.AddLoop("idle", "", 0.1f, default(int));
            goldTicket.Add("shine", "", 0.05f, "idle", 0, 0, 0, 0, 0, 1, 2, 3, 4, 5);
            goldTicket.CenterOrigin();
            goldTicket.Play("idle");
            goldCard = new(engine, MountainResources.FileSelect, "cardShine");
            goldCard.AddLoop("idle", "", 0.1f, 5);
            goldCard.Add("shine", "", 0.05f, "idle");
            goldCard.CenterOrigin();
            goldCard.Play("idle");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public EverestFileSelectSlotState(ISourceEngineContext engine, int index, FileSelectSequence fileSelect,
            bool corrupted)
            : this(engine, index, fileSelect)
        {
            Corrupted = corrupted;
            Exists = corrupted;
            Setup();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public EverestFileSelectSlotState(ISourceEngineContext engine, int index, FileSelectSequence fileSelect,
            OriginalSaveDataState data)
            : this(engine, index, fileSelect)
        {
            Exists = true;
            SaveData = data;
            Name = data.Name;
            if (!((IOriginalGameTextEnvironment)engine).Text.CanDisplay(
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Language, Name))
                Name = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_DEFAULT");

            if (!((ISettingsContext)engine).Settings.VariantsUnlocked &&
                ((IOriginalSaveCounterEnvironment)engine).SaveCounters.TotalHeartGemsInVanilla(data) >= 24)
                ((ISettingsContext)engine).Settings.VariantsUnlocked = true;

            AssistModeEnabled = data.AssistMode;
            VariantModeEnabled = data.VariantMode;
            Add(Deaths = new(engine, OriginalAreaMode.Normal, false, data.TotalDeaths));
            Add(Strawberries = new(engine, true,
                ((IOriginalSaveCollectibleTotalsEnvironment)engine).SaveCollectibleTotals
                .GetTotalStrawberriesSafe(data)));
            Time = OriginalStatsFormatter.FileTime(data.Time);
            if (TimeSpan.FromTicks(data.Time).TotalHours > 0.0) timeScale = 0.725f;

            FurthestArea = ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(data);
            foreach (var item in
                     ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(data))
            {
                if (((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(item) >
                    ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(data))
                    break;

                if (!((IOriginalAreaInterludeEnvironment)engine).AreaInterlude.IsInterlude(
                        ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas
                            [((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(item)]) &&
                    ((IOriginalSessionConstructionProcess)engine).AreaTable
                    .Areas[((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(item)].CanFullClear)
                {
                    var array = new bool[3];
                    for (var i = 0; i < array.Length; i++) array[i] = item.Modes[i].HeartGem;

                    Cassettes.Add(item.Cassette);
                    HeartGems.Add(array);
                }
            }

            Setup();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Setup()
        {
            var text = "portrait_madeline";
            var id = "idle_normal";
            Portrait = Graphics.PortraitsSpriteBank.Create(text);
            Portrait.Play(id);
            Portrait.Scale = Vector2.One *
                             (200f / Graphics.PortraitsSpriteBank.SpriteData[text].Sources[0].XML
                                 .AttrInt("size", 160));
            Add(Portrait);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CreateButtons()
        {
            orig_CreateButtons();
            if (!Exists)
            {
                if (((IOriginalSessionConstructionProcess)engine).AreaTable.Areas
                    .Select(area => area.LevelSet).Distinct()
                    .Count() > 1)
                {
                    if (newGameLevelSetPicker == null) newGameLevelSetPicker = new(engine, this);

                    buttons.Add(newGameLevelSetPicker);
                }
            }
            else if (!Corrupted)
            {
                buttons.Insert(
                    buttons.FindIndex(button =>
                        button.Label == ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_delete")),
                    new()
                    {
                        Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_rename"),
                        Action = OnExistingFileRenameSelected,
                        Scale = 0.7f,
                    });
            }

            ((IEverestSaveModuleStateEnvironment)engine).SaveModuleState
                .LoadModSaveData(FileSlot);
            ((IEverestFileSelectSlotEventsEnvironment)engine).FileSelectSlotEvents.HandleCreateButtons(buttons, this,
                Exists);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnContinueSelected()
        {
            StartingGame = true;
            Process.AudioSession.Play("event:/ui/main/savefile_begin");
            ((IOriginalSaveStartEnvironment)engine).SaveStart.Start(SaveData, FileSlot,
                ((IOriginalSaveInitializationEnvironment)engine).SaveInitializationServices);
            if (renamed)
            {
                Process.SaveContext.CurrentSave.Name = Name;
                Process.SaveContext.CurrentSave.TheoSisterName =
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean(
                        Name.IndexOf(((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("THEO_SISTER_NAME"),
                            StringComparison.InvariantCultureIgnoreCase) >= 0
                            ? "THEO_SISTER_ALT_NAME"
                            : "THEO_SISTER_NAME");
            }

            Process.SaveContext.CurrentSave.AssistMode = AssistModeEnabled;
            Process.SaveContext.CurrentSave.VariantMode = VariantModeEnabled;
            Process.SaveContext.CurrentSave.AssistModeChecks(((IOriginalSaveInitializationEnvironment)engine)
                .SaveInitializationServices);
            if (((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetCurrentSessionSafe(
                    Process.SaveContext.CurrentSave) != null && ((IOriginalSaveSessionSelectionEnvironment)engine)
                .SaveSessionSelection.GetCurrentSessionSafe(Process.SaveContext.CurrentSave).InArea)
            {
                Process.AudioSession.SetMusic(null);
                Process.AudioSession.SetAmbience(null);
                fileSelect.Overworld.ShowInputUI = false;
                new FadeWipePresentation((ISourceRendererScene)Scene, false,
                    delegate
                    {
                        OriginalLevelEntryRouting.Go(
                            ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                            .GetCurrentSessionSafe(
                                Process.SaveContext.CurrentSave), true, engine.Frame.Scenes,
                            ((IOriginalLevelEntryEnvironment)engine).LevelEntries);
                    });
            }
            else if (((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                         Process.SaveContext.CurrentSave)[0]
                     .Modes[0].Completed || Process.SaveContext.CurrentSave.CheatMode)
            {
                if (((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetCurrentSessionSafe(
                        Process.SaveContext.CurrentSave) != null && ((IOriginalSaveSessionSelectionEnvironment)engine)
                    .SaveSessionSelection.GetCurrentSessionSafe(Process.SaveContext.CurrentSave).ShouldAdvance)
                    ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                        .GetLastAreaReference(Process.SaveContext.CurrentSave).ID =
                        ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(
                            Process.SaveContext.CurrentSave);

                ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.SetCurrentSessionSafe(
                    Process.SaveContext.CurrentSave, null);
                (Scene as OverworldSequence).Goto<ChapterSelectSequence>();
            }
            else
            {
                Process.AudioSession.SetMusic(null);
                Process.AudioSession.SetAmbience(null);
                EnterFirstArea();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnDeleteSelected()
        {
            deleting = true;
            wiggler.Start();
            Process.AudioSession.Play("event:/ui/main/message_confirm");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnNewGameSelected()
        {
            orig_OnNewGameSelected();
            var newGameLevelSet = newGameLevelSetPicker?.NewGameLevelSet;
            ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.SelectNewGameLevelSet(
                newGameLevelSet);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void EnterFirstArea()
        {
            fileSelect.Overworld.Maddy.Disabled = true;
            fileSelect.Overworld.ShowInputUI = false;
            Add(new SimulationCoroutine(engine, EnterFirstAreaRoutine()));
        }

        private IEnumerator EnterFirstAreaRoutine()
        {
            return ((IOriginalFileSlotFirstAreaEnvironment)engine).FileSlotFirstArea.EnterFirstArea(fileSelect, engine);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnRenameSelected()
        {
            Renaming = true;
            var ouiFileNaming = fileSelect.Overworld.Goto<FileNamingSequence>();
            ouiFileNaming.FileSlot = this;
            ouiFileNaming.StartingName = Name;
            Process.AudioSession.Play("event:/ui/main/savefile_rename_start");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnAssistSelected()
        {
            Assisting = true;
            fileSelect.Overworld.Goto<AssistModeSequence>().FileSlot = this;
            Process.AudioSession.Play("event:/ui/main/assist_button_info");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnVariantSelected()
        {
            if (!(((ISettingsContext)engine).Settings.VariantsUnlocked || (SaveData != null && SaveData.CheatMode)))
                return;
            VariantModeEnabled = !VariantModeEnabled;
            if (VariantModeEnabled)
            {
                AssistModeEnabled = false;
                Process.AudioSession.Play("event:/ui/main/button_toggle_on");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/main/button_toggle_off");
            }

            assistButton.Label =
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_ASSIST_" +
                                                                         (AssistModeEnabled ? "ON" : "OFF"));
            variantButton.Label =
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_VARIANT_" +
                                                                         (VariantModeEnabled ? "ON" : "OFF"));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Vector2 HiddenPosition(int x, int y)
        {
            if (!selected) return new Vector2(960f, Y) + new Vector2(x, y) * new Vector2(1920f, 1080f);

            return new Vector2(1920f, 1080f) / 2f + new Vector2(x, y) * new Vector2(1920f, 1080f);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Show()
        {
            var instance = Process.SaveContext.CurrentSave;
            Process.SaveContext.PublishCurrentSave(SaveData);
            var statsSave = SaveData;
            var levelSetStats = statsSave == null
                ? null
                : ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSetStats(statsSave);
            if (levelSetStats != null)
            {
                var strawberries = Strawberries;
                strawberries.Amount = levelSetStats.TotalStrawberries;
                strawberries.OutOf =
                    ((IInstalledLevelSetStatsEnvironment)engine)
                    .LevelSetStatsQueries.GetMaxStrawberries(levelSetStats);
                strawberries.ShowOutOf = levelSetStats.Name != "Celeste" || strawberries.OutOf <= 0;
                strawberries.CanWiggle = false;
                if (levelSetStats.Name == "Celeste")
                {
                    maxStrawberryCount = 175;
                    maxGoldenStrawberryCount = 25;
                    maxStrawberryCountIncludingUntracked = 202;
                    maxCassettes = 8;
                    maxCrystalHeartsExcludingCSides = 16;
                    maxCrystalHearts = 24;
                    summitStamp = ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(SaveData)[7]
                        .Modes[0]
                        .Completed;
                    farewellStamp = ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(SaveData)[10]
                        .Modes[0].Completed;
                }
                else
                {
                    maxStrawberryCount =
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetMaxStrawberries(levelSetStats);
                    maxGoldenStrawberryCount =
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetMaxGoldenStrawberries(levelSetStats);
                    maxStrawberryCountIncludingUntracked =
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetMaxStrawberriesIncludingUntracked(levelSetStats);
                    maxCassettes =
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetMaxCassettes(levelSetStats);
                    maxCrystalHearts =
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetMaxHeartGems(levelSetStats);
                    maxCrystalHeartsExcludingCSides =
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetMaxHeartGemsExcludingCSides(levelSetStats);
                    summitStamp =
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetTotalCompletions(levelSetStats) >=
                        ((IInstalledLevelSetStatsEnvironment)engine)
                        .LevelSetStatsQueries.GetMaxCompletions(levelSetStats);
                    farewellStamp = false;
                }

                totalGoldenStrawberries =
                    ((IInstalledLevelSetStatsEnvironment)engine)
                    .LevelSetStatsQueries.GetTotalGoldenStrawberries(levelSetStats);
                totalHeartGems =
                    ((IInstalledLevelSetStatsEnvironment)engine)
                    .LevelSetStatsQueries.GetTotalHeartGems(levelSetStats);
                totalCassettes =
                    ((IInstalledLevelSetStatsEnvironment)engine)
                    .LevelSetStatsQueries.GetTotalCassettes(levelSetStats);
                FurthestArea =
                    ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(SaveData);
                Cassettes.Clear();
                HeartGems.Clear();
                foreach (var item in
                         ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                             SaveData))
                {
                    if (((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(item) >
                        ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(SaveData))
                        break;

                    if (!((IOriginalAreaInterludeEnvironment)engine).AreaInterlude.IsInterlude(
                            ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[
                                ((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(item)]) &&
                        ((IOriginalSessionConstructionProcess)engine).AreaTable
                        .Areas[((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(item)].CanFullClear)
                    {
                        var array = new bool[3];
                        for (var i = 0; i < array.Length; i++) array[i] = item.Modes[i].HeartGem;

                        Cassettes.Add(item.Cassette);
                        HeartGems.Add(array);
                    }
                }
            }

            Process.SaveContext.PublishCurrentSave(instance);
            orig_Show();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Select(bool resetButtonIndex)
        {
            Visible = true;
            deleting = false;
            StartingGame = false;
            Renaming = false;
            Assisting = false;
            CreateButtons();
            Card.Play("shine");
            Ticket.Play("shine");
            var from = Position;
            wiggler.Start();
            if (resetButtonIndex) buttonIndex = 0;

            deleteIndex = 1;
            inputDelay = 0.1f;
            StartTween(0.25f, [MethodImpl(MethodImplOptions.NoInlining)](f) =>
            {
                Position = Vector2Interpolation.Lerp(from, SelectedPosition, selectedEase = f.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                newgameFade = Math.Max(newgameFade, f.Eased);
            });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Unselect()
        {
            orig_Unselect();
            newGameLevelSetPicker = null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MoveTo(float x, float y)
        {
            var from = Position;
            var to = new Vector2(x, y);
            StartTween(0.25f,
                [MethodImpl(MethodImplOptions.NoInlining)]
                (f) =>
                {
                    Position = Vector2Interpolation.Lerp(from, to, f.Eased,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Hide(int x, int y)
        {
            var from = Position;
            var to = HiddenPosition(x, y);
            StartTween(0.25f,
                [MethodImpl(MethodImplOptions.NoInlining)]
                (f) =>
                {
                    Position = Vector2Interpolation.Lerp(from, to, f.Eased,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                }, true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void StartTween(float duration, Action<SourceTweenState> callback, bool hide = false)
        {
            if (tween != null && tween.Entity == this) tween.RemoveSelf();

            Add(tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot, Easing.CubeInOut,
                duration));
            tween.OnUpdate = callback;
            tween.OnComplete = [MethodImpl(MethodImplOptions.NoInlining)](t) =>
            {
                if (hide) Visible = false;

                tween = null;
            };
            tween.Start();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Update()
        {
            orig_Update();
            if (newGameLevelSetPicker == null || !selected || !fileSelect.Selected || !fileSelect.Focused ||
                StartingGame ||
                tween != null || !(inputDelay <= 0f) || StartingGame || deleting)
                return;

            newGameLevelSetPicker.Update(buttons[buttonIndex] == newGameLevelSetPicker);
            if (!(((ISourceMInputEnvironment)engine).MInput.Keyboard.Check(SourceKeys.LeftControl) &&
                  ((ISourceMInputEnvironment)engine).MInput.Keyboard.Pressed(SourceKeys.S)))
                return;
            ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.DefaultStartingLevelSet =
                newGameLevelSetPicker.NewGameLevelSet;
            if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.SaveDataFlush == true)
                ((IEverestCoreModuleEnvironment)engine).CoreModule
                    .ForceSaveDataFlush++;

            ((IEverestCoreModuleEnvironment)engine).CoreModule.SaveSettings();
            Process.AudioSession.Play("event:/new_content/ui/rename_entry_accept_locked");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Render(ISourceRenderContext context)
        {
            orig_Render(context);
            if (!(selectedEase > 0f)) return;

            var position = Position + new Vector2(0f, -150f + 350f * selectedEase);
            var lineHeight = ((ISourceActiveFontScope)engine).ActiveFont.LineHeight;
            for (var i = 0; i < buttons.Count; i++)
            {
                var button = buttons[i];
                if (button == newGameLevelSetPicker)
                    newGameLevelSetPicker.Render(context, position, buttonIndex == i && !deleting, wiggler.Value * 8f);

                position.Y += lineHeight * button.Scale + 15f;
            }
        }

        public PackedColor SelectionColor(bool selected)
        {
            if (selected)
            {
                if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.AllowTextHighlight &&
                    !((ISourceScene)Scene).SourceScene.Clock.BetweenInterval(0.1f))
                    return TextMenuPresentation.HighlightColorB;

                return TextMenuPresentation.HighlightColorA;
            }

            return PackedColor.White;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool orig_get_Golden()
        {
            if (!Corrupted && Exists)
                return ((IOriginalSaveCollectibleTotalsEnvironment)engine).SaveCollectibleTotals
                    .GetTotalStrawberriesSafe(SaveData) >= 202;

            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void orig_Show()
        {
            Visible = true;
            deleting = false;
            StartingGame = false;
            Renaming = false;
            Assisting = false;
            selectedEase = 0f;
            highlightEase = 0f;
            highlightEaseDelay = 0.35f;
            var from = Position;
            StartTween(0.25f,
                [MethodImpl(MethodImplOptions.NoInlining)]
                (f) =>
                {
                    Position = Vector2Interpolation.Lerp(from, IdlePosition, f.Eased,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void orig_CreateButtons()
        {
            buttons.Clear();
            if (Exists)
            {
                if (!Corrupted)
                {
                    buttons.Add(new()
                    {
                        Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_continue"),
                        Action = OnContinueSelected,
                    });
                    if (SaveData != null)
                    {
                        var list = buttons;
                        var obj = new Button
                        {
                            Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_ASSIST_" +
                                (AssistModeEnabled ? "ON" : "OFF")),
                            Action = OnAssistSelected,
                            Scale = 0.7f,
                        };
                        var item = obj;
                        assistButton = obj;
                        list.Add(item);
                        if (((ISettingsContext)engine).Settings.VariantsUnlocked || SaveData.CheatMode)
                        {
                            var list2 = buttons;
                            var obj2 = new Button
                            {
                                Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_VARIANT_" +
                                    (VariantModeEnabled ? "ON" : "OFF")),
                                Action = OnVariantSelected,
                                Scale = 0.7f,
                            };
                            item = obj2;
                            variantButton = obj2;
                            list2.Add(item);
                        }
                    }
                }

                buttons.Add(new()
                {
                    Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_delete"),
                    Action = OnDeleteSelected,
                    Scale = 0.7f,
                });
            }
            else
            {
                buttons.Add(new()
                {
                    Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_begin"),
                    Action = OnNewGameSelected,
                });
                buttons.Add(new()
                {
                    Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_rename"),
                    Action = OnRenameSelected,
                    Scale = 0.7f,
                });
                var list3 = buttons;
                var obj3 = new Button
                {
                    Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_ASSIST_" +
                        (AssistModeEnabled ? "ON" : "OFF")),
                    Action = OnAssistSelected,
                    Scale = 0.7f,
                };
                var item = obj3;
                assistButton = obj3;
                list3.Add(item);
                if (((ISettingsContext)engine).Settings.VariantsUnlocked)
                {
                    var list4 = buttons;
                    var obj4 = new Button
                    {
                        Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_VARIANT_" +
                            (VariantModeEnabled ? "ON" : "OFF")),
                        Action = OnVariantSelected,
                        Scale = 0.7f,
                    };
                    item = obj4;
                    variantButton = obj4;
                    list4.Add(item);
                }
            }
        }

        private void OnExistingFileRenameSelected()
        {
            renamed = true;
            Renaming = true;
            var ouiFileNaming = fileSelect.Overworld.Goto<FileNamingSequence>();
            ouiFileNaming.FileSlot = this;
            ouiFileNaming.StartingName = Name;
            Process.AudioSession.Play("event:/ui/main/savefile_rename_start");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void orig_OnNewGameSelected()
        {
            Process.AudioSession.SetMusic(null);
            Process.AudioSession.SetAmbience(null);
            Process.AudioSession.Play("event:/ui/main/savefile_begin");
            var created = ((IOriginalSaveAllocationEnvironment)engine).SaveAllocation.CreateSave();
            created.Name = Name;
            created.AssistMode = AssistModeEnabled;
            created.VariantMode = VariantModeEnabled;
            ((IOriginalSaveStartEnvironment)engine).SaveStart.Start(created, FileSlot,
                ((IOriginalSaveInitializationEnvironment)engine).SaveInitializationServices);
            StartingGame = true;
            EnterFirstArea();
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public void orig_Update()
        {
            inputDelay -= engine.DeltaTime;
            Ticket.Update();
            Card.Update();
            if (selected && fileSelect.Selected && fileSelect.Focused && !StartingGame && tween == null &&
                inputDelay <= 0f && !StartingGame)
            {
                if (deleting)
                {
                    if (Input.MenuCancel.Pressed)
                    {
                        deleting = false;
                        wiggler.Start();
                        Process.AudioSession.Play("event:/ui/main/button_back");
                    }
                    else if (Input.MenuUp.Pressed && deleteIndex > 0)
                    {
                        deleteIndex = 0;
                        wiggler.Start();
                        Process.AudioSession.Play("event:/ui/main/rollover_up");
                    }
                    else if (Input.MenuDown.Pressed && deleteIndex < 1)
                    {
                        deleteIndex = 1;
                        wiggler.Start();
                        Process.AudioSession.Play("event:/ui/main/rollover_down");
                    }
                    else if (Input.MenuConfirm.Pressed)
                    {
                        if (deleteIndex == 1)
                        {
                            deleting = false;
                            wiggler.Start();
                            Process.AudioSession.Play("event:/ui/main/button_back");
                        }
                        else if (((IOriginalSaveDeletionEnvironment)engine).SaveDeletion.TryDelete(FileSlot,
                                     ((IOriginalSaveDeletionEnvironment)engine).SaveDeletionServices))
                        {
                            Exists = false;
                            Corrupted = false;
                            deleting = false;
                            deletingEase = 0f;
                            fileSelect.UnselectHighlighted();
                            Process.AudioSession.Play("event:/ui/main/savefile_delete");
                            if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.AllowScreenFlash)
                                screenFlash = 1f;

                            CreateButtons();
                        }
                        else
                        {
                            failedToDeleteEase = 0f;
                            failedToDeleteTimer = 3f;
                            Process.AudioSession.Play("event:/ui/main/button_invalid");
                        }
                    }
                }
                else if (Input.MenuCancel.Pressed)
                {
                    if (fileSelect.HasSlots)
                    {
                        fileSelect.UnselectHighlighted();
                        Process.AudioSession.Play("event:/ui/main/whoosh_savefile_in");
                        Process.AudioSession.Play("event:/ui/main/button_back");
                    }
                }
                else if (Input.MenuUp.Pressed && buttonIndex > 0)
                {
                    buttonIndex--;
                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rollover_up");
                }
                else if (Input.MenuDown.Pressed && buttonIndex < buttons.Count - 1)
                {
                    buttonIndex++;
                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rollover_down");
                }
                else if (Input.MenuConfirm.Pressed)
                {
                    buttons[buttonIndex].Action();
                }
            }

            if (highlightEaseDelay <= 0f)
                highlightEase = ScalarMath.Approach(highlightEase, highlighted && (Exists || !selected) ? 1f : 0f,
                    engine.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            else
                highlightEaseDelay -= engine.DeltaTime;

            Depth = highlighted ? -10 : 0;
            if (Renaming || Assisting)
                selectedEase = ScalarMath.Approach(selectedEase, 0f, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

            deletingEase = ScalarMath.Approach(deletingEase, deleting ? 1f : 0f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            failedToDeleteEase = ScalarMath.Approach(failedToDeleteEase, failedToDeleteTimer > 0f ? 1f : 0f,
                engine.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            failedToDeleteTimer -= engine.DeltaTime;
            screenFlash = ScalarMath.Approach(screenFlash, 0f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public void WiggleMenu()
        {
            wiggler.Start();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void orig_Unselect()
        {
            var from = Position;
            buttonIndex = 0;
            StartTween(0.25f, [MethodImpl(MethodImplOptions.NoInlining)](f) =>
            {
                selectedEase = 1f - f.Eased;
                newgameFade = 1f - f.Eased;
                Position = Vector2Interpolation.Lerp(from, IdlePosition, f.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void orig_Render(ISourceRenderContext context)
        {
            var num = Easing.CubeInOut(highlightEase);
            var num2 = wiggler.Value * 8f;
            if (selectedEase > 0f)
            {
                var vector = Position + new Vector2(0f, -150f + 350f * selectedEase);
                var lineHeight = ((ISourceActiveFontScope)engine).ActiveFont.LineHeight;
                for (var i = 0; i < buttons.Count; i++)
                {
                    var button = buttons[i];
                    var vector2 = Vector2.UnitX * (buttonIndex == i && !deleting ? num2 : 0f);
                    var color = SelectionColor(buttonIndex == i && !deleting);
                    ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, this, button.Label,
                        vector + vector2,
                        new(0.5f, 0f), Vector2.One * button.Scale, color, 2f, PackedColor.Black);
                    vector.Y += lineHeight * button.Scale + 15f;
                }
            }

            var vector3 = Position + Vector2.UnitX * num * 360f;
            Ticket.RenderPosition = vector3;
            Ticket.Render(context);
            if (highlightEase > 0f && Exists && !Corrupted)
            {
                var num3 = -280;
                var num4 = 600;
                for (var j = 0; j < Cassettes.Count; j++)
                {
                    SourceAtlasDrawing.DrawCentered(context, this,
                        MountainResources.FileSelect[Cassettes[j] ? "cassette" : "dot"],
                        vector3 + new Vector2(num3 + (j + 0.5f) * 75f, -75f), PackedColor.White);
                    var array = HeartGems[j];
                    var num5 = 0;
                    for (var k = 0; k < array.Length; k++)
                        if (array[k])
                            num5++;

                    var vector4 = vector3 + new Vector2(num3 + (j + 0.5f) * 75f, -12f);
                    if (num5 == 0)
                    {
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["dot"], vector4,
                            PackedColor.White);
                        continue;
                    }

                    vector4.Y -= (num5 - 1) * 0.5f * 14f;
                    var l = 0;
                    var num6 = 0;
                    for (; l < array.Length; l++)
                        if (array[l])
                        {
                            SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["heartgem" + l],
                                vector4 + new Vector2(0f, num6 * 14), PackedColor.White);
                            num6++;
                        }
                }

                Deaths.Position = vector3 + new Vector2(num3, 68f) - Position;
                Deaths.Render(context);
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this, Time,
                    vector3 + new Vector2(num3 + num4, 68f), new(1f, 0.5f), Vector2.One * timeScale,
                    PackedColor.Black * 0.6f);
            }
            else if (Corrupted)
            {
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean(!MissingVanillaData
                        ? "file_corrupted"
                        : "MISSING_VANILLA_DATA"), vector3, new(0.5f, 0.5f), Vector2.One,
                    PackedColor.Black * 0.8f);
            }
            else if (!Exists)
            {
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_newgame"), vector3,
                    new(0.5f, 0.5f), Vector2.One, PackedColor.Black * 0.8f);
            }

            var vector5 = Position - Vector2.UnitX * num * 360f;
            var num7 = 64;
            var num8 = 16;
            var num9 = Card.Width - num7 * 2 - 200f - num8;
            var x = (0f - Card.Width) / 2f + num7 + 200f + num8 + num9 / 2f;
            var num10 = Exists ? 1f : newgameFade;
            if (!Corrupted)
            {
                if (newgameFade > 0f || Exists)
                {
                    if (AssistModeEnabled)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["assist"], vector5,
                            PackedColor.White * num10);
                    else if (VariantModeEnabled)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["variants"],
                            vector5,
                            PackedColor.White * num10);
                }

                if (Exists && SaveData.CheatMode)
                    SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["cheatmode"], vector5,
                        PackedColor.White * num10);
            }

            Card.RenderPosition = vector5;
            Card.Render(context);
            if (!Corrupted)
            {
                if (Exists)
                {
                    if (((IOriginalSaveCollectibleTotalsEnvironment)engine).SaveCollectibleTotals
                        .GetTotalStrawberriesSafe(SaveData) >= maxStrawberryCount)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["strawberry"],
                            vector5,
                            PackedColor.White * num10);

                    if (((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(SaveData).Count > 7 &&
                        summitStamp)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["flag"], vector5,
                            PackedColor.White * num10);

                    if (totalCassettes >= maxCassettes)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["cassettes"],
                            vector5,
                            PackedColor.White * num10);

                    if (totalHeartGems >= maxCrystalHeartsExcludingCSides)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["heart"], vector5,
                            PackedColor.White * num10);

                    if (totalGoldenStrawberries >= maxGoldenStrawberryCount)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["goldberry"],
                            vector5,
                            PackedColor.White * num10);

                    if (totalHeartGems >= maxCrystalHearts)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["goldheart"],
                            vector5,
                            PackedColor.White * num10);

                    if (((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(SaveData).Count > 10 &&
                        farewellStamp)
                        SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["farewell"],
                            vector5,
                            PackedColor.White * num10);
                }

                if (Exists || Renaming || newgameFade > 0f)
                {
                    Portrait.RenderPosition = vector5 + new Vector2((0f - Card.Width) / 2f + num7 + 100f, 0f);
                    Portrait.Color = PackedColor.White * num10;
                    Portrait.Render(context);
                    SourceAtlasDrawing.DrawCentered(context, this,
                        MountainResources.FileSelect[!Golden ? "portraitOverlay" : "portraitOverlayGold"],
                        Portrait.RenderPosition, PackedColor.White * num10);
                    var name = Name;
                    var position = vector5 + new Vector2(x, -32 + (!Exists ? 64 : 0));
                    var num11 = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f,
                        440f / ((ISourceActiveFontScope)engine).ActiveFont.Measure(name).X);
                    ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this, name, position,
                        new(0.5f, 1f),
                        Vector2.One * num11, PackedColor.Black * 0.8f * num10);
                    if (Renaming && ((ISourceScene)Scene).SourceScene.Clock.BetweenInterval(0.3f))
                        ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this, "|",
                            new(
                                position.X + ((ISourceActiveFontScope)engine).ActiveFont.Measure(name).X * num11 * 0.5f,
                                position.Y), new(0f, 1f), Vector2.One * num11,
                            PackedColor.Black * 0.8f * num10);
                }

                if (Exists)
                {
                    if (FurthestArea < ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count)
                        ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this,
                            ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean(
                                ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[FurthestArea].Name),
                            vector5 + new Vector2(x, -10f), new(0.5f, 0.5f), Vector2.One * 0.8f,
                            PackedColor.Black * 0.6f);

                    Strawberries.Position = vector5 + new Vector2(x, 55f) - Position;
                    Strawberries.Render(context);
                }
            }
            else
            {
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_failedtoload"), vector5,
                    new(0.5f, 0.5f), Vector2.One, PackedColor.Black * 0.8f);
            }

            if (deletingEase > 0f)
            {
                var num12 = Easing.CubeOut(deletingEase);
                var vector6 = new Vector2(960f, 540f);
                var lineHeight2 = ((ISourceActiveFontScope)engine).ActiveFont.LineHeight;
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * num12 * 0.9f);
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_delete_really"),
                    vector6 + new Vector2(0f, -16f - 64f * (1f - num12)), new(0.5f, 1f), Vector2.One,
                    PackedColor.White * num12);
                ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, this,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_delete_yes"),
                    vector6 + new Vector2((deleting && deleteIndex == 0 ? num2 : 0f) * 1.2f * num12,
                        16f + 64f * (1f - num12)), new(0.5f, 0f), Vector2.One * 0.8f,
                    deleting ? SelectionColor(deleteIndex == 0) : PackedColor.Gray, 2f, PackedColor.Black * num12);
                ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, this,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_delete_no"),
                    vector6 + new Vector2((deleting && deleteIndex == 1 ? num2 : 0f) * 1.2f * num12,
                        16f + lineHeight2 + 64f * (1f - num12)), new(0.5f, 0f), Vector2.One * 0.8f,
                    deleting ? SelectionColor(deleteIndex == 1) : PackedColor.Gray, 2f, PackedColor.Black * num12);
                if (failedToDeleteEase > 0f)
                {
                    var position2 = new Vector2(960f, 980f - 100f * deletingEase);
                    var scale = Vector2.One * 0.8f;
                    if (failedToDeleteEase < 1f && failedToDeleteTimer > 0f)
                    {
                        position2 += new Vector2(-5 + ((ISourceRandomEnvironment)engine).Random.Next(10),
                            -5 + ((ISourceRandomEnvironment)engine).Random.Next(10));
                        scale = Vector2.One * (0.8f + 0.2f * (1f - failedToDeleteEase));
                    }

                    ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, this,
                        ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("file_delete_failed"), position2,
                        new(0.5f, 0f), scale, PackedColor.PaleVioletRed * deletingEase, 2f,
                        PackedColor.Black * deletingEase);
                }
            }

            if (screenFlash > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                    PackedColor.White * Easing.CubeOut(screenFlash));
        }

        internal void ScrollTo(float x, float y)
        {
            var from = Position;
            var to = new Vector2(x, y);
            var flag = false;
            if (tween != null && tween.Entity == this)
            {
                flag = true;
                tween.RemoveSelf();
                newgameFade = selectedEase = 0f;
            }

            Add(tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                flag ? Easing.CubeOut : Easing.CubeInOut, 0.25f));
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                Position = Vector2Interpolation.Lerp(from, to, t.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            };
            tween.OnComplete = delegate { tween = null; };
            tween.Start();
        }
    }
}
