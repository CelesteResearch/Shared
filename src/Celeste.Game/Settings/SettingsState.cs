using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Bindings;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Settings
{
    // Runtime preferences and original settings policy. XML wire types are not
    // held here; engine application and menu language indices belong to ports.
    public class SettingsState : IMenuSettingsFlags,
        global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings
    {
        bool IMenuSettingsFlags.VariantsUnlocked
        {
            get => VariantsUnlocked;
            set => VariantsUnlocked = value;
        }

        bool IMenuSettingsFlags.Pico8OnMainMenu
        {
            get => Pico8OnMainMenu;
            set => Pico8OnMainMenu = value;
        }

        public string Version;
        public string DefaultFileName = "";
        public bool Fullscreen;
        public bool VSync = true;
        public bool SetViewportOnce;
        public int WindowScale = 6;
        public int ViewportPadding;
        public int ScreenShake = 1;
        public int Rumble = 2;
        public GrabMode GrabMode;

        public CrouchDashMode CrouchDashMode;

        // Keep actual fields: original TAS legal queries distinguish fields
        // from properties, including SFXVolume.
        public int MusicVolume = 10;
        public int SFXVolume = 10;
        public int SpeedrunClock;
        public int LastSaveFile;
        public bool VariantsUnlocked;
        public bool Pico8OnMainMenu;
        public bool DisableFlashes;
        public bool LaunchInDebugMode;
        public bool LaunchWithFMODLiveUpdate;
        public string LanguageId = "english";
        public SourceInputBinding Left;
        public SourceInputBinding Right;
        public SourceInputBinding Down;
        public SourceInputBinding Up;
        public SourceInputBinding MenuLeft;
        public SourceInputBinding MenuRight;
        public SourceInputBinding MenuDown;
        public SourceInputBinding MenuUp;
        public SourceInputBinding Grab;
        public SourceInputBinding Jump;
        public SourceInputBinding Dash;
        public SourceInputBinding Talk;
        public SourceInputBinding Pause;
        public SourceInputBinding Confirm;
        public SourceInputBinding Cancel;
        public SourceInputBinding Journal;
        public SourceInputBinding QuickRestart;
        public SourceInputBinding DemoDash;
        public SourceInputBinding RightMoveOnly;
        public SourceInputBinding LeftMoveOnly;
        public SourceInputBinding UpMoveOnly;
        public SourceInputBinding DownMoveOnly;
        public SourceInputBinding RightDashOnly;
        public SourceInputBinding LeftDashOnly;
        public SourceInputBinding UpDashOnly;
        public SourceInputBinding DownDashOnly;
#pragma warning disable CS0169
        private bool controlsInitialized;
#pragma warning restore CS0169
#pragma warning disable CS0169
        private bool afterLoadApplied;
#pragma warning restore CS0169
        private string capturedPresentationLanguageId;

        public SettingsState(ISourceInputBindingFactory bindings)
        {
            Left = bindings.Create();
            Right = bindings.Create();
            Down = bindings.Create();
            Up = bindings.Create();
            MenuLeft = bindings.Create();
            MenuRight = bindings.Create();
            MenuDown = bindings.Create();
            MenuUp = bindings.Create();
            Grab = bindings.Create();
            Jump = bindings.Create();
            Dash = bindings.Create();
            Talk = bindings.Create();
            Pause = bindings.Create();
            Confirm = bindings.Create();
            Cancel = bindings.Create();
            Journal = bindings.Create();
            QuickRestart = bindings.Create();
            DemoDash = bindings.Create();
            RightMoveOnly = bindings.Create();
            LeftMoveOnly = bindings.Create();
            UpMoveOnly = bindings.Create();
            DownMoveOnly = bindings.Create();
            RightDashOnly = bindings.Create();
            LeftDashOnly = bindings.Create();
            UpDashOnly = bindings.Create();
            DownDashOnly = bindings.Create();
            if (global::Celeste.Game.Execution.GameRuntime.PlayMode !=
                global::Celeste.Game.Execution.GameRuntime.PlayModes.Debug)
                Fullscreen = true;
        }

        public SettingsState()
        {
            if (global::Celeste.Game.Execution.ProcessState.CelesteRuntimeState.PlayMode !=
                global::Celeste.Game.Execution.ProcessState.CelestePlayMode.Debug)
                Fullscreen = true;
        }

        public void AfterLoad(IOriginalSettingsAfterLoadEnvironment environment)
        {
            SourceInputBinding.SetExclusive(MenuLeft, MenuRight, MenuUp, MenuDown,
                Confirm, Cancel, Journal, Pause);
            MusicVolume = Math.Max(0, Math.Min(10, MusicVolume));
            SFXVolume = Math.Max(0, Math.Min(10, SFXVolume));
            WindowScale = Math.Min(WindowScale, Math.Min(environment.CurrentDisplayWidth / 320,
                environment.CurrentDisplayHeight / 180));
            WindowScale = Math.Max(3, Math.Min(10, WindowScale));
            SetDefaultKeyboardControls(false);
            SetDefaultButtonControls(false);
            if (LaunchInDebugMode)
                global::Celeste.Game.Execution.GameRuntime.PlayMode =
                    global::Celeste.Game.Execution.GameRuntime.PlayModes.Debug;
            environment.SettingsProcess.LastVersion = environment.SettingsProcess.Existed
                ? environment.Settings.Version
                : environment.EngineIdentity.Version.ToString();
            environment.Settings.Version = environment.EngineIdentity.Version.ToString();
        }

        public void ApplyScreen(
            global::Celeste.Game.Execution.Engine.IOriginalEngineGraphicsEnvironment graphics,
            global::Celeste.Game.Execution.Engine.Screen.IOriginalEngineScreenEnvironment screen)
        {
            if (Fullscreen)
            {
                graphics.EngineGraphics.ViewPadding = ViewportPadding;
                screen.EngineScreen.SetFullscreen();
            }
            else
            {
                graphics.EngineGraphics.ViewPadding = 0;
                screen.EngineScreen.SetWindowed(320 * WindowScale, 180 * WindowScale);
            }
        }


        // An unsupported imported mod id must survive a UI which displays the
        // English selection until the user actually selects a different entry.
        public void CaptureLanguagePresentation(string selectedLanguageId)
        {
            capturedPresentationLanguageId = selectedLanguageId;
        }

        public string ResolveLanguageId(string selectedLanguageId)
        {
            return LanguageId != null && selectedLanguageId == capturedPresentationLanguageId
                ? LanguageId
                : selectedLanguageId;
        }

        public bool ApplyLanguageFallback(Func<string, bool> languageExists, string selectedLanguageId)
        {
            if (languageExists(ResolveLanguageId(selectedLanguageId))) return false;
            LanguageId = "english";
            capturedPresentationLanguageId = "english";
            return true;
        }

        public void SetDefaultKeyboardControls(bool reset)
        {
            if (reset || Left.Keyboard.Count <= 0)
            {
                Left.Keyboard.Clear();
                Left.Add(Keys.Left);
            }

            if (reset || Right.Keyboard.Count <= 0)
            {
                Right.Keyboard.Clear();
                Right.Add(Keys.Right);
            }

            if (reset || Down.Keyboard.Count <= 0)
            {
                Down.Keyboard.Clear();
                Down.Add(Keys.Down);
            }

            if (reset || Up.Keyboard.Count <= 0)
            {
                Up.Keyboard.Clear();
                Up.Add(Keys.Up);
            }

            if (reset || MenuLeft.Keyboard.Count <= 0)
            {
                MenuLeft.Keyboard.Clear();
                MenuLeft.Add(Keys.Left);
            }

            if (reset || MenuRight.Keyboard.Count <= 0)
            {
                MenuRight.Keyboard.Clear();
                MenuRight.Add(Keys.Right);
            }

            if (reset || MenuDown.Keyboard.Count <= 0)
            {
                MenuDown.Keyboard.Clear();
                MenuDown.Add(Keys.Down);
            }

            if (reset || MenuUp.Keyboard.Count <= 0)
            {
                MenuUp.Keyboard.Clear();
                MenuUp.Add(Keys.Up);
            }

            if (reset || Grab.Keyboard.Count <= 0)
            {
                Grab.Keyboard.Clear();
                Grab.Add(Keys.Z, Keys.V, Keys.LeftShift);
            }

            if (reset || Jump.Keyboard.Count <= 0)
            {
                Jump.Keyboard.Clear();
                Jump.Add(Keys.C);
            }

            if (reset || Dash.Keyboard.Count <= 0)
            {
                Dash.Keyboard.Clear();
                Dash.Add(Keys.X);
            }

            if (reset || Talk.Keyboard.Count <= 0)
            {
                Talk.Keyboard.Clear();
                Talk.Add(Keys.X);
            }

            if (reset || Pause.Keyboard.Count <= 0)
            {
                Pause.Keyboard.Clear();
                Pause.Add(Keys.Enter);
            }

            if (reset || Confirm.Keyboard.Count <= 0)
            {
                Confirm.Keyboard.Clear();
                Confirm.Add(Keys.C);
            }

            if (reset || Cancel.Keyboard.Count <= 0)
            {
                Cancel.Keyboard.Clear();
                Cancel.Add(Keys.X, Keys.Back);
            }

            if (reset || Journal.Keyboard.Count <= 0)
            {
                Journal.Keyboard.Clear();
                Journal.Add(Keys.Tab);
            }

            if (reset || QuickRestart.Keyboard.Count <= 0)
            {
                QuickRestart.Keyboard.Clear();
                QuickRestart.Add(Keys.R);
            }

            if (reset)
            {
                DemoDash.Keyboard.Clear();
                LeftMoveOnly.Keyboard.Clear();
                RightMoveOnly.Keyboard.Clear();
                UpMoveOnly.Keyboard.Clear();
                DownMoveOnly.Keyboard.Clear();
                LeftDashOnly.Keyboard.Clear();
                RightDashOnly.Keyboard.Clear();
                UpDashOnly.Keyboard.Clear();
                DownDashOnly.Keyboard.Clear();
            }
        }

        public void SetDefaultButtonControls(bool reset)
        {
            if (reset || Left.Controller.Count <= 0)
            {
                Left.Controller.Clear();
                Left.Add(Buttons.LeftThumbstickLeft, Buttons.DPadLeft);
            }

            if (reset || Right.Controller.Count <= 0)
            {
                Right.Controller.Clear();
                Right.Add(Buttons.LeftThumbstickRight, Buttons.DPadRight);
            }

            if (reset || Down.Controller.Count <= 0)
            {
                Down.Controller.Clear();
                Down.Add(Buttons.LeftThumbstickDown, Buttons.DPadDown);
            }

            if (reset || Up.Controller.Count <= 0)
            {
                Up.Controller.Clear();
                Up.Add(Buttons.LeftThumbstickUp, Buttons.DPadUp);
            }

            if (reset || MenuLeft.Controller.Count <= 0)
            {
                MenuLeft.Controller.Clear();
                MenuLeft.Add(Buttons.LeftThumbstickLeft, Buttons.DPadLeft);
            }

            if (reset || MenuRight.Controller.Count <= 0)
            {
                MenuRight.Controller.Clear();
                MenuRight.Add(Buttons.LeftThumbstickRight, Buttons.DPadRight);
            }

            if (reset || MenuDown.Controller.Count <= 0)
            {
                MenuDown.Controller.Clear();
                MenuDown.Add(Buttons.LeftThumbstickDown, Buttons.DPadDown);
            }

            if (reset || MenuUp.Controller.Count <= 0)
            {
                MenuUp.Controller.Clear();
                MenuUp.Add(Buttons.LeftThumbstickUp, Buttons.DPadUp);
            }

            if (reset || Grab.Controller.Count <= 0)
            {
                Grab.Controller.Clear();
                Grab.Add(Buttons.LeftTrigger, Buttons.RightTrigger, Buttons.LeftShoulder, Buttons.RightShoulder);
            }

            if (reset || Jump.Controller.Count <= 0)
            {
                Jump.Controller.Clear();
                Jump.Add(Buttons.A, Buttons.Y);
            }

            if (reset || Dash.Controller.Count <= 0)
            {
                Dash.Controller.Clear();
                Dash.Add(Buttons.X, Buttons.B);
            }

            if (reset || Talk.Controller.Count <= 0)
            {
                Talk.Controller.Clear();
                Talk.Add(Buttons.B);
            }

            if (reset || Pause.Controller.Count <= 0)
            {
                Pause.Controller.Clear();
                Pause.Add(Buttons.Start);
            }

            if (reset || Confirm.Controller.Count <= 0)
            {
                Confirm.Controller.Clear();
                Confirm.Add(Buttons.A);
            }

            if (reset || Cancel.Controller.Count <= 0)
            {
                Cancel.Controller.Clear();
                Cancel.Add(Buttons.B, Buttons.X);
            }

            if (reset || Journal.Controller.Count <= 0)
            {
                Journal.Controller.Clear();
                Journal.Add(Buttons.LeftTrigger);
            }

            if (reset || QuickRestart.Controller.Count <= 0)
            {
                QuickRestart.Controller.Clear();
            }

            if (reset)
            {
                DemoDash.Controller.Clear();
                LeftMoveOnly.Controller.Clear();
                RightMoveOnly.Controller.Clear();
                UpMoveOnly.Controller.Clear();
                DownMoveOnly.Controller.Clear();
                LeftDashOnly.Controller.Clear();
                RightDashOnly.Controller.Clear();
                UpDashOnly.Controller.Clear();
                DownDashOnly.Controller.Clear();
            }
        }

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Left => Left;
        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Right => Right;
        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Down => Down;
        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Up => Up;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.MenuLeft =>
            MenuLeft;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.MenuRight =>
            MenuRight;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.MenuDown =>
            MenuDown;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.MenuUp =>
            MenuUp;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Grab => Grab;
        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Jump => Jump;
        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Dash => Dash;
        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Talk => Talk;
        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Pause => Pause;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Confirm =>
            Confirm;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Cancel =>
            Cancel;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Journal =>
            Journal;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.QuickRestart =>
            QuickRestart;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.DemoDash =>
            DemoDash;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.
            RightMoveOnly => RightMoveOnly;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.LeftMoveOnly =>
            LeftMoveOnly;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.UpMoveOnly =>
            UpMoveOnly;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.DownMoveOnly =>
            DownMoveOnly;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.
            RightDashOnly => RightDashOnly;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.LeftDashOnly =>
            LeftDashOnly;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.UpDashOnly =>
            UpDashOnly;

        SourceInputBinding global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.DownDashOnly =>
            DownDashOnly;

        global::Celeste.Game.Controls.Source.GrabModes
            global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.GrabMode =>
            (global::Celeste.Game.Controls.Source.GrabModes)(int)GrabMode;

        global::Celeste.Game.Controls.Source.CrouchDashModes
            global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.CrouchDashMode =>
            (global::Celeste.Game.Controls.Source.CrouchDashModes)(int)CrouchDashMode;

        global::Celeste.Game.Controls.Source.RumbleAmount
            global::Celeste.Game.Controls.Source.IOriginalGameInputSourceSettings.Rumble =>
            (global::Celeste.Game.Controls.Source.RumbleAmount)(int)Rumble;

        public void ApplyVolumes(global::Celeste.Game.Audio.Runtime.OriginalGameAudioSession audio)
        {
            ApplySFXVolume(audio);
            ApplyMusicVolume(audio);
        }

        public void ApplySFXVolume(global::Celeste.Game.Audio.Runtime.OriginalGameAudioSession audio)
        {
            audio.SfxVolume = (float)SFXVolume / 10f;
        }

        public void ApplyMusicVolume(global::Celeste.Game.Audio.Runtime.OriginalGameAudioSession audio)
        {
            audio.MusicVolume = (float)MusicVolume / 10f;
        }
    }
}
