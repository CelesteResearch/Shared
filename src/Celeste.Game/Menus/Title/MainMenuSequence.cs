using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Controls.Source;
using Celeste.Game.Credits;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Files;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Minigames.CelesteClassic.Emulation;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Game.UI.Menus.Buttons;
using Celeste.Game.UI.Menus.Buttons.Title;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Gui;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Menus.Title
{
    public class MainMenuSequence : OuiState
    {
        protected ISourceEngineContext EngineContext { get; }
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource;

        protected OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)EngineContext).AudioSession;

        protected AtlasData Gui => ((ISourceGuiAtlasResources)EngineContext).GuiAtlas;
        public override bool IsMainMenu => true;

        protected void InitializeDebugMode(bool loadExisting)
        {
            ((IOriginalSaveDebugEnvironment)EngineContext).SaveDebug.InitializeDebugMode(
                ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage,
                (IOriginalSaveInitializationServices)EngineContext, loadExisting);
        }

        private static readonly Vector2 TargetPosition = new(160f, 160f);

        private static readonly Vector2 TweenFrom = new(-500f, 160f);

        private static readonly PackedColor UnselectedColor = PackedColor.White;

        private static readonly PackedColor SelectedColorA = MenuButtonPresentation.HighlightColorA;

        private static readonly PackedColor SelectedColorB = MenuButtonPresentation.HighlightColorB;

        private const float IconWidth = 64f;

        private const float IconSpacing = 20f;

        protected float ease;

        protected MainMenuClimbPresentation climbButton;

        protected List<MenuButtonPresentation> buttons;

        private bool startOnOptions;

        public bool MountainStartFront { get; set; }

        public virtual PackedColor SelectionColor
        {
            get
            {
                if (!((ISettingsContext)EngineContext).Settings.DisableFlashes &&
                    !((SourceSceneState)Scene).BetweenInterval(0.1f))
                    return SelectedColorB;

                return SelectedColorA;
            }
        }

        public MainMenuSequence(ISourceEngineContext engine) : base(engine)
        {
            EngineContext = engine;
            buttons = [];
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Position = TweenFrom;
            CreateButtons();
        }

        public virtual void CreateButtons()
        {
            foreach (var button in buttons) button.RemoveSelf();

            buttons.Clear();
            var vector = new Vector2(320f, 160f);
            var vector2 = new Vector2(-640f, 0f);
            climbButton = new(this, vector, vector + vector2, OnBegin, Gui, EngineContext);
            if (!startOnOptions) climbButton.StartSelected();

            buttons.Add(climbButton);
            vector += Vector2.UnitY * climbButton.ButtonHeight;
            vector.X -= 140f;
            if (GameRuntime.PlayMode == GameRuntime.PlayModes.Debug)
            {
                var mainMenuSmallButton = new MainMenuSmallButtonPresentation("menu_debug",
                    "menu/options", this, vector, vector + vector2, OnDebug, Gui, EngineContext);
                buttons.Add(mainMenuSmallButton);
                vector += Vector2.UnitY * mainMenuSmallButton.ButtonHeight;
            }

            if (((ISettingsContext)EngineContext).Settings.Pico8OnMainMenu ||
                GameRuntime.PlayMode == GameRuntime.PlayModes.Debug ||
                GameRuntime.PlayMode == GameRuntime.PlayModes.Event)
            {
                var mainMenuSmallButton2 = new MainMenuSmallButtonPresentation("menu_pico8",
                    "menu/pico8", this, vector, vector + vector2, OnPico8, Gui, EngineContext);
                buttons.Add(mainMenuSmallButton2);
                vector += Vector2.UnitY * mainMenuSmallButton2.ButtonHeight;
            }

            var mainMenuSmallButton3 = new MainMenuSmallButtonPresentation("menu_options",
                "menu/options", this, vector, vector + vector2, OnOptions, Gui, EngineContext);
            if (startOnOptions) mainMenuSmallButton3.StartSelected();

            buttons.Add(mainMenuSmallButton3);
            vector += Vector2.UnitY * mainMenuSmallButton3.ButtonHeight;
            var additional = (EngineContext as IMainMenuAdditionalButtonEnvironment)?.MainMenuAdditionalButton;
            if (additional != null)
            {
                var additionalButton = new MainMenuSmallButtonPresentation(additional, this, vector,
                    vector + vector2, EngineContext);
                buttons.Add(additionalButton);
                vector += Vector2.UnitY * additionalButton.ButtonHeight;
            }

            var mainMenuSmallButton4 = new MainMenuSmallButtonPresentation("menu_credits",
                "menu/credits", this, vector, vector + vector2, OnCredits, Gui, EngineContext);
            buttons.Add(mainMenuSmallButton4);
            vector += Vector2.UnitY * mainMenuSmallButton4.ButtonHeight;
            var mainMenuSmallButton5 = new MainMenuSmallButtonPresentation("menu_exit",
                "menu/exit", this, vector, vector + vector2, OnExit, Gui, EngineContext);
            buttons.Add(mainMenuSmallButton5);
            vector += Vector2.UnitY * mainMenuSmallButton5.ButtonHeight;
            for (var i = 0; i < buttons.Count; i++)
            {
                if (i > 0) buttons[i].UpButton = buttons[i - 1];

                if (i < buttons.Count - 1) buttons[i].DownButton = buttons[i + 1];

                ((SourceSceneState)Scene).SourceScene.QueueSourceEntity(buttons[i]);
            }

            if (!Visible || !Focused) return;

            foreach (var button2 in buttons) button2.Position = button2.TargetPosition;
        }

        public override void Removed(object scene)
        {
            foreach (var button in buttons) ((SourceSceneState)scene).SourceScene.RemoveEntity(button);

            base.Removed(scene);
        }

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            switch (start)
            {
                case OverworldStartMode.ReturnFromOptions:
                    startOnOptions = true;
                    OwnedComponents.Add(new SimulationCoroutine(EngineContext, Enter(null)));
                    return true;
                case OverworldStartMode.MainMenu:
                    MountainStartFront = true;
                    OwnedComponents.Add(new SimulationCoroutine(EngineContext, Enter(null)));
                    return true;
                default:
                    if (start != OverworldStartMode.ReturnFromOptions)
                        return start == OverworldStartMode.ReturnFromPico8;

                    return true;
            }
        }

        public override IEnumerator Enter(OuiState from)
        {
            if (from is TitleScreenSequence || from is FileSelectSequence)
            {
                Audio.Play("event:/ui/main/whoosh_list_in");
                yield return 0.1f;
            }

            if (from is TitleScreenSequence)
            {
                MenuButtonPresentation.ClearSelection(Scene);
                climbButton.StartSelected();
            }

            Visible = true;
            if (MountainStartFront)
                Overworld.Mountain.SnapCamera(-1,
                    new(new(0f, 6f, 12f), MountainRendererState.RotateLookAt,
                        ((ISourceVectorEnvironment)EngineContext).VectorArithmetic));

            Overworld.Mountain.GotoRotationMode();
            Overworld.Maddy.Hide();
            foreach (var button in buttons) button.TweenIn(0.2f);

            yield return 0.2f;
            Focused = true;
            MountainStartFront = false;
            yield return null;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Focused = false;
            var tween = SourceTweenState.Create(EngineContext.TweenPool,
                SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeInOut, 0.2f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                ease = 1f - t.Eased;
                Position = Vector2Interpolation.Lerp(TargetPosition, TweenFrom, t.Eased,
                    ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
            };
            OwnedComponents.Add(tween);
            var keepClimb = climbButton.Selected && !(next is TitleScreenSequence);
            foreach (var button in buttons)
                if (!(button == climbButton && keepClimb))
                    button.TweenOut(0.2f);

            yield return 0.2f;
            if (keepClimb)
                OwnedComponents.Add(new SimulationCoroutine(EngineContext, SlideClimbOutLate()));
            else
                Visible = false;
        }

        private IEnumerator SlideClimbOutLate()
        {
            yield return 0.2f;
            climbButton.TweenOut(0.2f);
            yield return 0.2f;
            Visible = false;
        }

        public override void Update()
        {
            if (Selected && Focused && Input.MenuCancel.Pressed)
            {
                Focused = false;
                Audio.Play("event:/ui/main/whoosh_list_out");
                Audio.Play("event:/ui/main/button_back");
                Overworld.Goto<TitleScreenSequence>();
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var button in buttons)
                if (button.Scene == Scene)
                    button.Render(context);
        }

        protected virtual void OnDebug()
        {
            Audio.Play("event:/ui/main/whoosh_list_out");
            Audio.Play("event:/ui/main/button_select");
            InitializeDebugMode(true);
            Overworld.Goto<ChapterSelectSequence>();
        }

        private void OnBegin()
        {
            Audio.Play("event:/ui/main/whoosh_list_out");
            Audio.Play("event:/ui/main/button_climb");
            if (GameRuntime.PlayMode == GameRuntime.PlayModes.Event)
            {
                InitializeDebugMode(false);
                Overworld.Goto<ChapterSelectSequence>();
            }
            else
            {
                Overworld.Goto<FileSelectSequence>();
            }
        }

        private void OnPico8()
        {
            Audio.Play("event:/ui/main/button_select");
            Focused = false;
            new FadeWipePresentation((SourceSceneState)Scene, false, delegate
            {
                Focused = true;
                Overworld.EnteringPico8 = true;
                ((IOriginalGameplayProcess)EngineContext).SaveContext.PublishCurrentSave(null);
                OriginalSaveDataState.NoFileAssistChecks(Input);
                EngineContext.Frame.Scenes.NextScene = ClassicConsoleRuntime.Create(EngineContext, Overworld);
            });
        }

        private void OnOptions()
        {
            Audio.Play("event:/ui/main/button_select");
            Audio.Play("event:/ui/main/whoosh_large_in");
            Overworld.Goto<OptionsSequence>();
        }

        private void OnCredits()
        {
            Audio.Play("event:/ui/main/button_select");
            Audio.Play("event:/ui/main/whoosh_large_in");
            Overworld.Goto<OuiCreditsSequence>();
        }

        private void OnExit()
        {
            if (SourceRuntimeExtensions
                    .Get<ISourceGameplayLifecycleExtension>(EngineContext) is
                { } protection)
                protection.InvokeMainMenuExit(OnExitSourceBody);
            else
                OnExitSourceBody();
        }

        private void OnExitSourceBody()
        {
            Audio.Play("event:/ui/main/button_select");
            Focused = false;
            new FadeWipePresentation((SourceSceneState)Scene, false, delegate
            {
                EngineContext.Frame.Scenes.NextScene = new SourceSceneState(EngineContext,
                    ((ISourceSceneCatalogEnvironment)EngineContext).SceneCatalog,
                    ((ISourceSceneUpdatePolicyEnvironment)EngineContext).PlainScenePolicy);
                EngineRuntime.Instance.Exit();
            });
        }
    }
}
