using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Audio.Fmod.Events;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Game.UI.Controls;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using DialogLanguage = Celeste.Localization.Languages.DialogLanguage;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Menus.Options
{
    public class MenuOptionsPresentation
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected SettingsState Settings => ((ISettingsContext)engine).Settings;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected Celeste.Localization.Lookup.DialogCatalog Dialog => Text.Dialog;

        protected Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        public MenuOptionsPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        private TextMenuPresentation menu;

        private bool inGame;

        private TextMenuPresentation.Item crouchDashMode;

        private TextMenuPresentation.Item window;

        private TextMenuPresentation.Item viewport;

        private FmodEventReference snapshot;

        public virtual TextMenuPresentation Create(bool inGame = false, FmodEventReference snapshot = null)
        {
            this.inGame = inGame;
            this.snapshot = snapshot;
            menu = new TextMenuPresentation(engine);
            menu.Add(new TextMenuPresentation.Header(Dialog.Clean("options_title")));
            menu.OnClose = delegate { crouchDashMode = null; };
            if (!inGame && Dialog.Languages.Count > 1)
            {
                menu.Add(new TextMenuPresentation.SubHeader(""));
                TextMenuPresentation.LanguageButton languageButton =
                    new TextMenuPresentation.LanguageButton(Dialog.Clean("options_language"), Dialog.Language);
                languageButton.Pressed(SelectLanguage);
                menu.Add(languageButton);
            }

            menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("options_controls")));
            CreateRumble(menu);
            CreateGrabMode(menu);
            crouchDashMode = CreateCrouchDashMode(menu);
            menu.Add(new TextMenuPresentation.Button(Dialog.Clean("options_keyconfig")).Pressed(OpenKeyboardConfig));
            menu.Add(new TextMenuPresentation.Button(Dialog.Clean("options_btnconfig")).Pressed(OpenButtonConfig));
            menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("options_video")));
            menu.Add(
                new TextMenuPresentation.OnOff(Dialog.Clean("options_fullscreen"), Settings.Fullscreen, engine).Change(
                    SetFullscreen));
            menu.Add(window =
                new TextMenuPresentation.Slider(Dialog.Clean("options_window"), (int i) => i + "x", 3, 10,
                    Settings.WindowScale).Change(SetWindow));
            menu.Add(new TextMenuPresentation.OnOff(Dialog.Clean("options_vsync"), Settings.VSync, engine)
                .Change(SetVSync));
            menu.Add(new TextMenuPresentation.OnOff(Dialog.Clean("OPTIONS_DISABLE_FLASH"), Settings.DisableFlashes,
                    engine)
                .Change(delegate(bool b) { Settings.DisableFlashes = b; }));
            menu.Add(new TextMenuPresentation.Slider(Dialog.Clean("OPTIONS_DISABLE_SHAKE"), (int i) => i switch
            {
                2 => Dialog.Clean("OPTIONS_RUMBLE_ON"),
                1 => Dialog.Clean("OPTIONS_RUMBLE_HALF"),
                _ => Dialog.Clean("OPTIONS_RUMBLE_OFF"),
            }, 0, 2, (int)Settings.ScreenShake).Change(delegate(int i) { Settings.ScreenShake = i; }));
            menu.Add(viewport =
                new TextMenuPresentation.Button(Dialog.Clean("OPTIONS_VIEWPORT_PC")).Pressed(OpenViewportAdjustment));
            menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("options_audio")));
            menu.Add(new TextMenuPresentation.Slider(Dialog.Clean("options_music"), (int i) => i.ToString(), 0, 10,
                Settings.MusicVolume).Change(SetMusic).Enter(EnterSound).Leave(LeaveSound));
            menu.Add(new TextMenuPresentation.Slider(Dialog.Clean("options_sounds"), (int i) => i.ToString(), 0, 10,
                Settings.SFXVolume).Change(SetSfx).Enter(EnterSound).Leave(LeaveSound));
            menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("options_gameplay")));
            menu.Add(new TextMenuPresentation.Slider(Dialog.Clean("options_speedrun"), (int i) => i switch
            {
                0 => Dialog.Get("OPTIONS_OFF"),
                1 => Dialog.Get("OPTIONS_SPEEDRUN_CHAPTER"),
                _ => Dialog.Get("OPTIONS_SPEEDRUN_FILE"),
            }, 0, 2, (int)Settings.SpeedrunClock).Change(SetSpeedrunClock));
            if (engine is IMenuOptionsExtensionEnvironment extensions)
            {
                extensions.MenuOptionsExtension?.AddOptions(menu, inGame);
            }

            viewport.Visible = Settings.Fullscreen;
            if (window != null)
            {
                window.Visible = !Settings.Fullscreen;
            }

            if (menu.Height > menu.ScrollableMinSize)
            {
                menu.Position = new Vector2(menu.Position.X, menu.ScrollTargetY);
            }

            return menu;
        }

        private void CreateRumble(TextMenuPresentation menu)
        {
            menu.Add(new TextMenuPresentation.Slider(Dialog.Clean("options_rumble_PC"), (int i) => i switch
            {
                2 => Dialog.Clean("OPTIONS_RUMBLE_ON"),
                1 => Dialog.Clean("OPTIONS_RUMBLE_HALF"),
                _ => Dialog.Clean("OPTIONS_RUMBLE_OFF"),
            }, 0, 2, (int)Settings.Rumble).Change(delegate(int i)
            {
                Settings.Rumble = i;
                Input.Rumble(RumbleStrength.Medium, RumbleLength.Medium);
            }));
        }

        private void CreateGrabMode(TextMenuPresentation menu)
        {
            menu.Add(new TextMenuPresentation.Slider(Dialog.Clean("OPTIONS_GRAB_MODE"), (int i) => i switch
            {
                0 => Dialog.Clean("OPTIONS_BUTTON_HOLD"),
                1 => Dialog.Clean("OPTIONS_BUTTON_INVERT"),
                _ => Dialog.Clean("OPTIONS_BUTTON_TOGGLE"),
            }, 0, 2, (int)Settings.GrabMode).Change(delegate(int i)
            {
                Settings.GrabMode = (GrabMode)i;
                Input.ResetGrab();
            }));
        }

        private TextMenuPresentation.Item CreateCrouchDashMode(TextMenuPresentation menu)
        {
            TextMenuPresentation.Option<int> option =
                new TextMenuPresentation.Slider(Dialog.Clean("OPTIONS_CROUCH_DASH_MODE"),
                    (int i) => (i == 0) ? Dialog.Clean("OPTIONS_BUTTON_PRESS") : Dialog.Clean("OPTIONS_BUTTON_HOLD"), 0,
                    1,
                    (int)Settings.CrouchDashMode).Change(delegate(int i)
                {
                    Settings.CrouchDashMode = (CrouchDashMode)i;
                });
            option.Visible = Input.CrouchDash.Binding.HasInput;
            menu.Add(option);
            return option;
        }

        private void SetFullscreen(bool on)
        {
            Settings.Fullscreen = on;
            Settings.ApplyScreen((IOriginalEngineGraphicsEnvironment)engine,
                (Celeste.Game.Execution.Engine.Screen.IOriginalEngineScreenEnvironment)engine);
            if (window != null)
            {
                window.Visible = !on;
            }

            if (viewport != null)
            {
                viewport.Visible = on;
            }
        }

        private void SetVSync(bool on)
        {
            Settings.VSync = on;
            EngineRuntime.Graphics.SynchronizeWithVerticalRetrace = Settings.VSync;
            EngineRuntime.Graphics.ApplyChanges();
        }

        private void SetWindow(int scale)
        {
            Settings.WindowScale = scale;
            Settings.ApplyScreen((IOriginalEngineGraphicsEnvironment)engine,
                (Celeste.Game.Execution.Engine.Screen.IOriginalEngineScreenEnvironment)engine);
        }

        private void SetMusic(int volume)
        {
            Settings.MusicVolume = volume;
            Settings.ApplyMusicVolume(Audio);
        }

        private void SetSfx(int volume)
        {
            Settings.SFXVolume = volume;
            Settings.ApplySFXVolume(Audio);
        }

        private void SetSpeedrunClock(int val)
        {
            Settings.SpeedrunClock = val;
        }

        private void OpenViewportAdjustment()
        {
            if (engine.Frame.Scenes.CurrentScene is OverworldSequence)
            {
                (engine.Frame.Scenes.CurrentScene as OverworldSequence).ShowInputUI = false;
            }

            menu.Visible = false;
            menu.Focused = false;
            ViewportAdjustmentPresentation viewportAdjustmentUI = new ViewportAdjustmentPresentation(engine);
            viewportAdjustmentUI.OnClose = delegate
            {
                menu.Visible = true;
                menu.Focused = true;
                if (engine.Frame.Scenes.CurrentScene is OverworldSequence)
                {
                    (engine.Frame.Scenes.CurrentScene as OverworldSequence).ShowInputUI = true;
                }
            };
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).AddEntity(viewportAdjustmentUI);
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).OnEndOfFrame += delegate
            {
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.CommitQueuedEntityLists();
            };
        }

        private void SelectLanguage()
        {
            menu.Focused = false;
            LanguageSelectPresentation languageSelectUI = new LanguageSelectPresentation(engine);
            languageSelectUI.OnClose = delegate { menu.Focused = true; };
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).AddEntity(languageSelectUI);
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).OnEndOfFrame += delegate
            {
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.CommitQueuedEntityLists();
            };
        }

        private void OpenKeyboardConfig()
        {
            menu.Focused = false;
            TextMenuPresentation keyboardConfigUI =
                ((IOriginalControlConfigEnvironment)engine).ControlConfigs.CreateKeyboard(engine, this);
            keyboardConfigUI.OnClose = delegate { menu.Focused = true; };
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).AddEntity(keyboardConfigUI);
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).OnEndOfFrame += delegate
            {
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.CommitQueuedEntityLists();
            };
        }

        private void OpenButtonConfig()
        {
            menu.Focused = false;
            if (engine.Frame.Scenes.CurrentScene is OverworldSequence)
            {
                (engine.Frame.Scenes.CurrentScene as OverworldSequence).ShowConfirmUI = false;
            }

            TextMenuPresentation buttonConfigUI =
                ((IOriginalControlConfigEnvironment)engine).ControlConfigs.CreateController(engine, this);
            buttonConfigUI.OnClose = delegate
            {
                menu.Focused = true;
                if (engine.Frame.Scenes.CurrentScene is OverworldSequence)
                {
                    (engine.Frame.Scenes.CurrentScene as OverworldSequence).ShowConfirmUI = true;
                }
            };
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).AddEntity(buttonConfigUI);
            ((SourceSceneState)engine.Frame.Scenes.CurrentScene).OnEndOfFrame += delegate
            {
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.CommitQueuedEntityLists();
            };
        }

        private void EnterSound()
        {
            if (inGame && snapshot != null)
            {
                Audio.EndSnapshot(snapshot);
            }
        }

        private void LeaveSound()
        {
            if (inGame && snapshot != null)
            {
                Audio.ResumeSnapshot(snapshot);
            }
        }

        public void UpdateCrouchDashModeVisibility()
        {
            if (crouchDashMode != null)
            {
                crouchDashMode.Visible = Input.CrouchDash.Binding.HasInput;
            }
        }
    }
}
