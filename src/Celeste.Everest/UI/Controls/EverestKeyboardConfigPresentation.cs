using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Simulation.UI.Menus.Text;
using Color = Celeste.Core.Display.PackedColor;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using Binding = Celeste.Input.Bindings.SourceInputBinding;
using System;
using Celeste.Game.Menus.Controls;

namespace Celeste.Everest.UI.Controls
{
    public class EverestKeyboardConfigPresentation : TextMenuPresentation
    {
        private readonly ISourceEngineContext engine;
        private readonly global::Celeste.Game.Menus.Options.MenuOptionsPresentation menuOptions;
        private OriginalGameInputProcess SourceInput => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private SourceMInputProcess MInput => ((ISourceMInputEnvironment)engine).MInput;

        private global::Celeste.Game.Settings.SettingsState Settings =>
            ((global::Celeste.Game.Settings.ISettingsContext)engine).Settings;

        private global::Celeste.Game.Content.Dialogs.OriginalGameTextProcess Text =>
            ((global::Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)engine).Text;

        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ActiveBitmapFont Font => ((ISourceActiveFontScope)engine).ActiveFont;

        private void Play(string path) => ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine)
            .AudioSession.Play(path);

        private float Approach(float value, float target, float amount) =>
            ScalarMath.Approach(value, target, amount, Extrema);

        private EverestCoreSettings CoreSettings => ((IEverestControlConfigEnvironment)engine).CoreSettings;

        private bool remapping;

        private float remappingEase;

        private Binding remappingBinding;

        private string remappingText;

        private float inputDelay;

        private float timeout;

        private bool closing;

        private float closingDelay;

        private bool resetHeld;

        private float resetTime;

        private float resetDelay;

        public EverestKeyboardConfigPresentation(ISourceEngineContext engine,
            global::Celeste.Game.Menus.Options.MenuOptionsPresentation menuOptions) : base(engine)
        {
            this.engine = engine;
            this.menuOptions = menuOptions;
            InitializeOriginalMenu();
            Reload();
        }

        public void AddMap(string label, Binding binding)
        {
            string txt = Text.CleanDialog("KEY_CONFIG_" + label);
            Add(new Setting(txt, new global::Celeste.Simulation.Rendering.ControlBindingMenuAdapter(binding),
                controllerMode: false).Pressed(() =>
            {
                remappingText = txt;
                Remap(binding);
            }).AltPressed(delegate { Clear(binding); }));
        }

        public void Remap(Binding binding)
        {
            remapping = true;
            remappingBinding = binding;
            timeout = 5f;
            Focused = false;
        }

        public void AddRemap(Keys key)
        {
            remapping = false;
            inputDelay = 0.25f;
            if (!(remappingBinding.Keyboard.Contains(key)
                    ? ((global::Celeste.Everest.Input.InstalledSourceInputBinding)remappingBinding).Remove(key)
                    : remappingBinding.Add(key)))
            {
                Play("event:/ui/main/button_invalid");
            }

            while (remappingBinding.Keyboard.Count > SourceInput.MaxBindings)
            {
                remappingBinding.Keyboard.RemoveAt(0);
            }

            SourceInput.Initialize();
            CoreSettings.ToggleDebugConsole.ConsumePress();
            CoreSettings.DebugConsole.ConsumePress();
            CoreSettings.ToggleMountainFreeCam.ConsumePress();
        }

        public void Clear(Binding binding)
        {
            if (!((global::Celeste.Everest.Input.InstalledSourceInputBinding)binding).ClearMouse() &
                !binding.ClearKeyboard())
            {
                Play("event:/ui/main/button_invalid");
            }
        }

        public override void Update()
        {
            if (resetHeld)
            {
                resetDelay += engine.DeltaTime;
                resetTime += engine.DeltaTime;
                if (resetTime > 1.5f)
                {
                    resetDelay = 0f;
                    resetHeld = false;
                    _ = Settings;
                    _ = 1;
                    Reset();
                    Play("event:/ui/main/button_select");
                }

                if (!SourceInput.MenuConfirm.Check && resetDelay > 0.3f)
                {
                    Play("event:/ui/main/button_invalid");
                    resetHeld = false;
                }

                if (resetHeld)
                {
                    return;
                }
            }

            base.Update();
            Focused = !closing && inputDelay <= 0f && !remapping;
            if (!closing && SourceInput.MenuCancel.Pressed && !remapping)
            {
                OnCancel();
            }

            if (inputDelay > 0f && !remapping)
            {
                inputDelay -= engine.RawDeltaTime;
            }

            remappingEase = Approach(remappingEase, remapping ? 1 : 0, engine.RawDeltaTime * 4f);
            if (remappingEase >= 0.25f && remapping)
            {
                if (SourceInput.ESC.Pressed || timeout <= 0f)
                {
                    remapping = false;
                    Focused = true;
                }
                else
                {
                    RemapMouse();
                    Keys[] pressedKeys = MInput.Keyboard.CurrentState.GetPressedKeys();
                    if (pressedKeys != null && pressedKeys.Length != 0 && MInput.Keyboard.Pressed(pressedKeys[^1]))
                    {
                        AddRemap(pressedKeys[^1]);
                    }
                }

                timeout -= engine.RawDeltaTime;
            }

            closingDelay -= engine.RawDeltaTime;
            Alpha = Approach(Alpha, (!closing || !(closingDelay <= 0f)) ? 1 : 0, engine.RawDeltaTime * 8f);
            if (closing && Alpha <= 0f)
            {
                Close();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, Color.Black * Ease.CubeOut(Alpha));
            Vector2 vector = new Vector2(1920f, 1080f) * 0.5f;
            base.Render(context);
            if (remappingEase > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                    Color.Black * 0.95f * Ease.CubeInOut(remappingEase));
                Font.Draw(context, this, Text.Dialog.Get("KEY_CONFIG_CHANGING"), vector + new Vector2(0f, -8f),
                    new Vector2(0.5f, 1f), Vector2.One * 0.7f, Color.LightGray * Ease.CubeIn(remappingEase));
                Font.Draw(context, this, remappingText, vector + new Vector2(0f, 8f), new Vector2(0.5f, 0f),
                    Vector2.One * 2f, Color.White * Ease.CubeIn(remappingEase));
            }

            if (resetHeld)
            {
                float num = Ease.CubeInOut(Extrema.Min(1f, resetDelay / 0.2f));
                float num2 = Ease.SineOut(Extrema.Min(1f, resetTime / 1.5f));
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, Color.Black * 0.95f * num);
                float num3 = 480f;
                float x = (1920f - num3) / 2f;
                SourcePrimitiveDrawing.Rect(context, this, x, 530f, num3, 20f, Color.White * 0.25f * num);
                SourcePrimitiveDrawing.Rect(context, this, x, 530f, num3 * num2, 20f, Color.White * num);
            }
        }

        private void InitializeOriginalMenu()
        {
            Add(new Header(Text.CleanDialog("KEY_CONFIG_TITLE")));
            Add(new InputMappingInfoPresentation(engine, controllerMode: false));
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_GAMEPLAY"), true));
            AddMap("LEFT", Settings.Left);
            AddMap("RIGHT", Settings.Right);
            AddMap("UP", Settings.Up);
            AddMap("DOWN", Settings.Down);
            AddMap("JUMP", Settings.Jump);
            AddMap("DASH", Settings.Dash);
            AddMap("GRAB", Settings.Grab);
            AddMap("TALK", Settings.Talk);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MENUS"), true));
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MENU_NOTICE"), topPadding: false));
            AddMap("LEFT", Settings.MenuLeft);
            AddMap("RIGHT", Settings.MenuRight);
            AddMap("UP", Settings.MenuUp);
            AddMap("DOWN", Settings.MenuDown);
            AddMap("CONFIRM", Settings.Confirm);
            AddMap("CANCEL", Settings.Cancel);
            AddMap("JOURNAL", Settings.Journal);
            AddMap("PAUSE", Settings.Pause);
            Add(new SubHeader("", true));
            Button button = new Button(Text.CleanDialog("KEY_CONFIG_RESET"));
            button.IncludeWidthInMeasurement = false;
            button.AlwaysCenter = true;
            button.ConfirmSfx = "event:/ui/main/button_lowkey";
            button.OnPressed = () =>
            {
                resetHeld = true;
                resetTime = 0f;
                resetDelay = 0f;
            };
            Add(button);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_ADVANCED"), true));
            AddMap("QUICKRESTART", Settings.QuickRestart);
            AddMap("DEMO", Settings.DemoDash);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MOVE_ONLY"), true));
            AddMap("LEFT", Settings.LeftMoveOnly);
            AddMap("RIGHT", Settings.RightMoveOnly);
            AddMap("UP", Settings.UpMoveOnly);
            AddMap("DOWN", Settings.DownMoveOnly);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_DASH_ONLY"), true));
            AddMap("LEFT", Settings.LeftDashOnly);
            AddMap("RIGHT", Settings.RightDashOnly);
            AddMap("UP", Settings.UpDashOnly);
            AddMap("DOWN", Settings.DownDashOnly);
            OnESC = (OnCancel = () =>
            {
                menuOptions.UpdateCrouchDashModeVisibility();
                Focused = false;
                closing = true;
            });
            MinWidth = 600f;
            Position = new Vector2(Position.X, base.ScrollTargetY);
            Alpha = 0f;
        }

        /// <summary>
        ///       Gets the label to display on-screen for a mapping.
        ///       </summary>
        /// <param name="mapping">The mapping index</param>
        /// <returns>The key name to display</returns>
        /// <summary>
        ///       Adds a key mapping to the keyboard config screen.
        ///       </summary>
        /// <param name="key">The mapping index</param>
        /// <param name="list">The list of keys currently mapped to it</param>
        /// <summary>
        ///       Adds a key mapping to the keyboard config screen.
        ///       </summary>
        /// <param name="key">The mapping (should be an enum value)</param>
        /// <param name="list">The list of keys currently mapped to it</param>
        /// <summary>
        ///       Forces a key to be bound to an action, in addition to the already bound key.
        ///       </summary>
        /// <param name="defaultKey">The key to force bind</param>
        /// <param name="boundKey">The key already bound</param>
        /// <returns>A list containing both key and defaultKey</returns>
        /// <summary>
        ///       Forces a key to be bound to an action, in addition to already bound keys.
        ///       </summary>
        /// <param name="defaultKey">The key to force bind</param>
        /// <param name="boundKeys">The list of keys already bound</param>
        /// <returns>A list containing both keys in list and defaultKey</returns>
        /// <summary>
        ///       Rebuilds the key mapping menu. Should clear the menu and add back all options.
        ///       </summary>
        /// <param name="index">The index to focus on in the menu</param>
        public virtual void Reload(int index = -1)
        {
            Clear();
            Add(new Header(Text.CleanDialog("KEY_CONFIG_TITLE")));
            Add(new InputMappingInfoPresentation(engine, controllerMode: false));
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_GAMEPLAY")));
            AddMap("LEFT", Settings.Left);
            AddMap("RIGHT", Settings.Right);
            AddMap("UP", Settings.Up);
            AddMap("DOWN", Settings.Down);
            AddMap("JUMP", Settings.Jump);
            AddMap("DASH", Settings.Dash);
            AddMap("GRAB", Settings.Grab);
            AddMap("TALK", Settings.Talk);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MENUS")));
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MENU_NOTICE"), topPadding: false));
            AddMap("LEFT", Settings.MenuLeft);
            AddMap("RIGHT", Settings.MenuRight);
            AddMap("UP", Settings.MenuUp);
            AddMap("DOWN", Settings.MenuDown);
            AddMap("CONFIRM", Settings.Confirm);
            AddMap("CANCEL", Settings.Cancel);
            AddMap("JOURNAL", Settings.Journal);
            AddMap("PAUSE", Settings.Pause);
            Add(new SubHeader(""));
            Add(new Button(Text.CleanDialog("KEY_CONFIG_RESET"))
            {
                IncludeWidthInMeasurement = false,
                AlwaysCenter = true,
                OnPressed = delegate
                {
                    resetHeld = true;
                    resetTime = 0f;
                    resetDelay = 0f;
                },
                ConfirmSfx = "event:/ui/main/button_lowkey"
            });
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_ADVANCED"), true));
            AddMap("QUICKRESTART", Settings.QuickRestart);
            AddMap("DEMO", Settings.DemoDash);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MOVE_ONLY"), true));
            AddMap("LEFT", Settings.LeftMoveOnly);
            AddMap("RIGHT", Settings.RightMoveOnly);
            AddMap("UP", Settings.UpMoveOnly);
            AddMap("DOWN", Settings.DownMoveOnly);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_DASH_ONLY"), true));
            AddMap("LEFT", Settings.LeftDashOnly);
            AddMap("RIGHT", Settings.RightDashOnly);
            AddMap("UP", Settings.UpDashOnly);
            AddMap("DOWN", Settings.DownDashOnly);
            if (index >= 0)
            {
                Selection = index;
            }
        }

        public virtual void ResetPressed()
        {
            resetHeld = true;
            resetTime = 0f;
            resetDelay = 0f;
        }

        public virtual void Reset()
        {
            InstalledSettingsMouseControls.Clear(Settings);
            Settings.SetDefaultKeyboardControls(reset: true);
            SourceInput.Initialize();
        }

        public void AddMapForceLabel(string label, Binding binding)
        {
            Add(new Setting(label, new global::Celeste.Simulation.Rendering.ControlBindingMenuAdapter(binding),
                controllerMode: false).Pressed(delegate
            {
                remappingText = label;
                Remap(binding);
            }).AltPressed(delegate { Clear(binding); }));
        }

        public void RemapMouse()
        {
            for (int i = 0; i < 5; i++)
            {
                if (((global::Celeste.Everest.Input.SourceEverestMouseData)MInput.Mouse).Pressed(
                        (global::Celeste.Everest.Input.SourceEverestMouseData.MouseButtons)i))
                {
                    AddRemap((global::Celeste.Everest.Input.SourceEverestMouseData.MouseButtons)i);
                }
            }
        }

        private void AddRemap(global::Celeste.Everest.Input.SourceEverestMouseData.MouseButtons button)
        {
            while (((global::Celeste.Everest.Input.InstalledSourceInputBinding)remappingBinding).Mouse.Count +
                   remappingBinding.Keyboard.Count >= SourceInput.MaxBindings)
            {
                ((global::Celeste.Everest.Input.InstalledSourceInputBinding)remappingBinding).Mouse.RemoveAt(0);
            }

            remapping = false;
            inputDelay = 0.25f;
            if (!((global::Celeste.Everest.Input.InstalledSourceInputBinding)remappingBinding).Add(button))
            {
                Play("event:/ui/main/button_invalid");
            }

            SourceInput.Initialize();
        }


        /// <summary>
        ///       Determines if the key being set supports multiple bindings.
        ///       If this is the case, Shift+Confirm will allow to add a binding and Confirm will replace existing bindings.
        ///       </summary>
        /// <param name="mapping">The mapping</param>
        /// <returns>true if the key supports multiple bindings, false otherwise</returns>


        /// <summary>
        ///       Returns the list used to remap keys during a remap operation.
        ///       This should be a List&lt;Keys&gt; field in your settings class
        ///       </summary>
        /// <param name="remapping">The int value of the mapping being remapped</param>
        /// <param name="newKey">The new key that the user is attempting to set.</param>
        /// <returns>the field to set keys with, otherwise return null to cancel the operation</returns>
    }
}
