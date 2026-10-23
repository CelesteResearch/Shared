using Celeste.Core.Display;
using Celeste.Everest.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using MonoMod.Utils;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.Menus.Title;
using Celeste.Game.Menus.Title;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio.Runtime;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Everest.Menus;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.Menus.InitialSetup
{
    public sealed class EverestCoreOobeSequence : OuiState, IEverestModOptionsSubmenu
    {
        private readonly ISourceEngineContext engine;

        private EverestCoreSettings CoreSettings =>
            ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings;

        private SourceEverestModule CoreModule => ((IEverestCoreModuleEnvironment)engine).CoreModule;
        private OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        public EverestCoreOobeSequence(ISourceEngineContext engine) : base(engine) => this.engine = engine;
        private const float onScreenX = 960f;

        private const float offScreenLeftX = -960f;

        private const float offScreenRightX = 2880f;

        private bool fromModOptions;

        private float fade;

        private TextMenuPresentation menu;

        private Stack<TextMenuPresentation> steps = new Stack<TextMenuPresentation>();

        private int step;

        public TextMenuPresentation CreateMenu(int step)
        {
            switch (step)
            {
                case 0:
                    return new TextMenuPresentation(engine)
                    {
                        new TextMenuPresentation.Header(Text.Dialog.Clean("OOBE_WELCOME_HEADER")),
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_WELCOME_SUBHEADER")),
                        new TextMenuPresentation.Button(Text.Dialog.Clean("OOBE_WELCOME_PLAY")).Pressed(Goto(1)),
                        new TextMenuPresentation.Button(Text.Dialog.Clean("OOBE_WELCOME_SPEEDRUN")).Pressed(Goto(2)),
                        new TextMenuPresentation.Button(Text.Dialog.Clean("OOBE_WELCOME_CREATE")).Pressed(Goto(3)),
                        new TextMenuPresentation.Button(Text.Dialog.Clean("OOBE_WELCOME_SKIP")).Pressed(Exit)
                    };
                case 1:
                    return new TextMenuPresentation(engine)
                    {
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_PLAY")),
                        new TextMenuPresentation.SubHeader(""),
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_SUBHEADER")),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_AUTOUPDATEMODSONSTARTUP"),
                            CoreSettings.AutoUpdateModsOnStartup, engine).Change(delegate(bool value)
                        {
                            CoreSettings.AutoUpdateModsOnStartup = value;
                        }),
                        new TextMenuPresentation.Slider(Text.Dialog.Clean("MODOPTIONS_COREMODULE_DEBUGMODE"),
                                (int i) => Text.Dialog.Clean($"MODOPTIONS_VANILLATRISTATE_{(EverestVanillaTristate)i}"),
                                0,
                                Enum.GetValues(typeof(EverestVanillaTristate)).Length - 1, (int)CoreSettings.DebugMode)
                            .Change(delegate(int value) { CoreSettings.DebugMode = (EverestVanillaTristate)value; }),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_SHOWEVERESTTITLESCREEN"),
                            CoreSettings.ShowEverestTitleScreen, engine).Change(delegate(bool value)
                        {
                            CoreSettings.ShowEverestTitleScreen = value;
                        }),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_USEKEYBOARDFORTEXTINPUT"),
                            CoreSettings.UseKeyboardForTextInput, engine).Change(delegate(bool value)
                        {
                            CoreSettings.UseKeyboardForTextInput = value;
                        }),
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_MORE")),
                        new TextMenuPresentation.Button(Text.Dialog.Clean("OOBE_SETTINGS_OK")).Pressed(Exit)
                    };
                case 2:
                {
                    TextMenuPresentation textMenu2 = new TextMenuPresentation(engine)
                    {
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_SPEEDRUN")),
                        new TextMenuPresentation.SubHeader(""),
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_SUBHEADER")),
                        new TextMenuPresentation.OnOff(Text.Dialog.Clean("MODOPTIONS_COREMODULE_LAUNCHWITHOUTINTRO"),
                            CoreSettings.LaunchWithoutIntro, engine).Change(delegate(bool value)
                        {
                            CoreSettings.LaunchWithoutIntro = value;
                        }),
                        new TextMenuPresentation.Slider(Text.Dialog.Clean("MODOPTIONS_COREMODULE_DEBUGMODE"),
                                (int i) => Text.Dialog.Clean($"MODOPTIONS_VANILLATRISTATE_{(EverestVanillaTristate)i}"),
                                0,
                                Enum.GetValues(typeof(EverestVanillaTristate)).Length - 1, (int)CoreSettings.DebugMode)
                            .Change(delegate(int value) { CoreSettings.DebugMode = (EverestVanillaTristate)value; }),
                        new TextMenuPresentation.OnOff(Text.Dialog.Clean("MODOPTIONS_COREMODULE_SHOWMODOPTIONSINGAME"),
                            CoreSettings.ShowModOptionsInGame, engine).Change(delegate(bool value)
                        {
                            CoreSettings.ShowModOptionsInGame = value;
                        }),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_SHOWEVERESTTITLESCREEN"),
                            CoreSettings.ShowEverestTitleScreen, engine).Change(delegate(bool value)
                        {
                            CoreSettings.ShowEverestTitleScreen = value;
                        }),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_USEKEYBOARDFORTEXTINPUT"),
                            CoreSettings.UseKeyboardForTextInput, engine).Change(delegate(bool value)
                        {
                            CoreSettings.UseKeyboardForTextInput = value;
                        })
                    };
                    CoreSettings.CreateCompatibilityModeEntry(textMenu2, inGame: false);
                    textMenu2.Add(new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_MORE")));
                    textMenu2.Add(new TextMenuPresentation.Button(Text.Dialog.Clean("OOBE_SETTINGS_OK")).Pressed(Exit));
                    return textMenu2;
                }
                case 3:
                {
                    TextMenuPresentation.Item option;
                    TextMenuPresentation textMenu = new TextMenuPresentation(engine)
                    {
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_CREATE")),
                        new TextMenuPresentation.SubHeader(""),
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_SUBHEADER")),
                        new TextMenuPresentation.Slider(Text.Dialog.Clean("MODOPTIONS_COREMODULE_DEBUGMODE"),
                                (int i) => Text.Dialog.Clean($"MODOPTIONS_VANILLATRISTATE_{(EverestVanillaTristate)i}"),
                                0,
                                Enum.GetValues(typeof(EverestVanillaTristate)).Length - 1, (int)CoreSettings.DebugMode)
                            .Change(delegate(int value) { CoreSettings.DebugMode = (EverestVanillaTristate)value; }),
                        (option = new TextMenuPresentation.Slider(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_LAUNCHWITHFMODLIVEUPDATE"),
                            (int i) => Text.Dialog.Clean($"MODOPTIONS_VANILLATRISTATE_{(EverestVanillaTristate)i}"), 0,
                            Enum.GetValues(typeof(EverestVanillaTristate)).Length - 1,
                            (int)CoreSettings.LaunchWithFMODLiveUpdate).Change(delegate(int value)
                        {
                            CoreSettings.LaunchWithFMODLiveUpdate = (EverestVanillaTristate)value;
                        })),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_AUTOUPDATEMODSONSTARTUP"),
                            CoreSettings.AutoUpdateModsOnStartup, engine).Change(delegate(bool value)
                        {
                            CoreSettings.AutoUpdateModsOnStartup = value;
                        }),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_SHOWEVERESTTITLESCREEN"),
                            CoreSettings.ShowEverestTitleScreen, engine).Change(delegate(bool value)
                        {
                            CoreSettings.ShowEverestTitleScreen = value;
                        }),
                        new TextMenuPresentation.OnOff(
                            Text.Dialog.Clean("MODOPTIONS_COREMODULE_USEKEYBOARDFORTEXTINPUT"),
                            CoreSettings.UseKeyboardForTextInput, engine).Change(delegate(bool value)
                        {
                            CoreSettings.UseKeyboardForTextInput = value;
                        }),
                        new TextMenuPresentation.SubHeader(Text.Dialog.Clean("OOBE_SETTINGS_MORE")),
                        new TextMenuPresentation.Button(Text.Dialog.Clean("OOBE_SETTINGS_OK")).Pressed(Exit)
                    };
                    option.NeedsRelaunch(textMenu);
                    return textMenu;
                }
                default:
                    return new TextMenuPresentation(engine);
            }
        }

        public void Next()
        {
            new DynData<TextMenuPresentation>(menu).Set("oobeStep", step);
            steps.Push(menu);
            Add(new SimulationCoroutine(engine, GotoTransition(step + 1)));
        }

        public void Prev()
        {
            Add(new SimulationCoroutine(engine, GotoTransition(steps.Pop(), back: true)));
        }

        public Action Goto(int target, bool back = false)
        {
            return delegate
            {
                new DynData<TextMenuPresentation>(menu).Set("oobeStep", step);
                steps.Push(menu);
                Add(new SimulationCoroutine(engine, GotoTransition(target, back)));
            };
        }

        private IEnumerator GotoTransition(int target, bool back = false)
        {
            TextMenuPresentation textMenu = CreateMenu(target);
            if (textMenu.Height > textMenu.ScrollableMinSize)
            {
                textMenu.Y = textMenu.ScrollTargetY;
            }

            new DynData<TextMenuPresentation>(textMenu).Set("oobeStep", target);
            return GotoTransition(textMenu, back);
        }

        private IEnumerator GotoTransition(TextMenuPresentation target, bool back = false)
        {
            Audio.Play("event:/ui/main/whoosh_list_in");
            TextMenuPresentation menuOld = menu;
            menuOld.Visible = true;
            menuOld.Focused = false;
            step = new DynData<TextMenuPresentation>(target).Get<int>("oobeStep");
            menu = target;
            menu.Visible = true;
            menu.Focused = false;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
            if (back)
            {
                for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
                {
                    menuOld.X = 960f + 1920f * Easing.CubeInOut(p);
                    menu.X = -960f + 1920f * Easing.CubeInOut(p);
                    yield return null;
                }
            }
            else
            {
                for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
                {
                    menuOld.X = 960f - 1920f * Easing.CubeInOut(p);
                    menu.X = 2880f - 1920f * Easing.CubeInOut(p);
                    yield return null;
                }
            }

            menuOld.Visible = false;
            menuOld.RemoveSelf();
            menu.Focused = true;
        }

        private void ReloadMenu()
        {
            if (menu != null)
            {
                ((ISourceScene)Scene).SourceScene.RemoveEntity(menu);
            }

            menu = CreateMenu(step);
            if (menu.Height > menu.ScrollableMinSize)
            {
                menu.Y = menu.ScrollTargetY;
            }

            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
        }

        public override IEnumerator Enter(OuiState from)
        {
            Overworld.ShowInputUI = true;
            fromModOptions = from is EverestModOptionsState;
            if (fromModOptions)
            {
                Add(new SimulationCoroutine(engine, FadeBgTo(1f)));
            }
            else
            {
                fade = 1f;
            }

            steps.Clear();
            step = 0;
            ReloadMenu();
            TextMenuPresentation textMenu = menu;
            EverestCoreOobeSequence ouiOOBE = this;
            bool visible = true;
            ouiOOBE.Visible = true;
            textMenu.Visible = visible;
            menu.Focused = false;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 2880f - 1920f * Easing.CubeOut(p);
                yield return null;
            }

            menu.Focused = true;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Audio.Play("event:/ui/main/whoosh_large_out");
            menu.Focused = false;
            if (fromModOptions)
            {
                Add(new SimulationCoroutine(engine, FadeBgTo(0f)));
            }

            yield return ((IEverestSaveSettingsEnvironment)engine).SaveSettingsProcess.SaveSettings();
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 960f - 1920f * Easing.CubeIn(p);
                yield return null;
            }

            TextMenuPresentation textMenu = menu;
            EverestCoreOobeSequence ouiOOBE = this;
            bool visible = false;
            ouiOOBE.Visible = false;
            textMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
            Overworld.Maddy.Hide();
        }

        private IEnumerator FadeBgTo(float to)
        {
            while (fade != to)
            {
                yield return null;
                fade = ScalarMath.Approach(fade, to, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
        }

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            var hooks =
                global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                    .Get<IEverestMenuStartupHooksEnvironment>(engine);
            return hooks != null
                ? hooks.InvokeSourceOobeStart(() => IsStartInstalled(overworld, start))
                : IsStartInstalled(overworld, start);
        }

        private bool IsStartInstalled(OverworldSequence overworld, OverworldStartMode start)
        {
            if (start != OverworldStartMode.Titlescreen ||
                ((IEverestUpdaterPhysicalEnvironment)engine).Flags.IsHeadless)
            {
                return false;
            }

            if (CoreSettings.CurrentVersion != null)
            {
                if (CoreSettings.SaveDataFlush == true)
                {
                    CoreModule.ForceSaveDataFlush++;
                }

                CoreModule.SaveSettings();
                return false;
            }

            Add(new SimulationCoroutine(engine, Enter(null)));
            return true;
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && base.Selected && Input.MenuCancel.Pressed)
            {
                if (steps.Count > 0)
                {
                    Audio.Play("event:/ui/main/button_back");
                    Prev();
                }
                else if (fromModOptions)
                {
                    base.Overworld.Goto<EverestModOptionsState>();
                }
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * fade);
            base.Render(context);
        }

        public void Exit()
        {
            if (fromModOptions)
            {
                base.Overworld.Goto<EverestModOptionsState>();
            }
            else
            {
                _GotoTitleScreen();
            }
        }

        private void _GotoTitleScreen()
        {
            EverestTitleScreenSequence ouiTitleScreen = base.Overworld.Goto<EverestTitleScreenSequence>();
            ouiTitleScreen.IsStart(base.Overworld, OverworldStartMode.Titlescreen);
            ouiTitleScreen.IsStart(base.Overworld, OverworldStartMode.MainMenu);
            new DynData<TitleScreenSequence>(ouiTitleScreen).Set("alpha", 0f);
            ouiTitleScreen.Visible = true;
        }
    }
}
