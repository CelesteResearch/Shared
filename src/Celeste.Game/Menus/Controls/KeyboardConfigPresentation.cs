using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Game.Controls.Source;
using Celeste.Simulation.UI.Menus.Text;
using Color = Celeste.Core.Display.PackedColor;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using Binding = Celeste.Input.Bindings.SourceInputBinding;

namespace Celeste.Game.Menus.Controls
{
    public class KeyboardConfigPresentation : TextMenuPresentation
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
        private ActiveBitmapFont Font => ((ISourceActiveFontScope)engine).ActiveFont;

        private float Approach(float value, float target, float amount) => ScalarMath.Approach(value, target, amount,
            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

        private float Min(float a, float b) => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(a, b);

        private void Play(string path) => ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine)
            .AudioSession.Play(path);

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

        public KeyboardConfigPresentation(ISourceEngineContext engine,
            global::Celeste.Game.Menus.Options.MenuOptionsPresentation menuOptions) : base(engine)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.menuOptions = menuOptions ?? throw new ArgumentNullException(nameof(menuOptions));
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
            Add(new Button(Text.CleanDialog("KEY_CONFIG_RESET"))
            {
                IncludeWidthInMeasurement = false,
                AlwaysCenter = true,
                ConfirmSfx = "event:/ui/main/button_lowkey",
                OnPressed = delegate
                {
                    resetHeld = true;
                    resetTime = 0f;
                    resetDelay = 0f;
                }
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
            OnESC = (OnCancel = delegate
            {
                menuOptions.UpdateCrouchDashModeVisibility();
                Focused = false;
                closing = true;
            });
            MinWidth = 600f;
            Position = new Vector2(Position.X, base.ScrollTargetY);
            Alpha = 0f;
        }

        private void AddMap(string label, Binding binding)
        {
            string txt = Text.CleanDialog("KEY_CONFIG_" + label);
            Add(new Setting(txt, new global::Celeste.Simulation.Rendering.ControlBindingMenuAdapter(binding),
                controllerMode: false).Pressed(delegate
            {
                remappingText = txt;
                Remap(binding);
            }).AltPressed(delegate { Clear(binding); }));
        }

        private void Remap(Binding binding)
        {
            remapping = true;
            remappingBinding = binding;
            timeout = 5f;
            Focused = false;
        }

        private void AddRemap(Keys key)
        {
            while (remappingBinding.Keyboard.Count >= SourceInput.MaxBindings)
            {
                remappingBinding.Keyboard.RemoveAt(0);
            }

            remapping = false;
            inputDelay = 0.25f;
            if (!remappingBinding.Add(key))
            {
                Play("event:/ui/main/button_invalid");
            }

            SourceInput.Initialize();
        }

        private void Clear(Binding binding)
        {
            if (!binding.ClearKeyboard())
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
                    Settings.SetDefaultKeyboardControls(reset: true);
                    SourceInput.Initialize();
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
                    Keys[] pressedKeys = MInput.Keyboard.CurrentState.GetPressedKeys();
                    if (pressedKeys != null && pressedKeys.Length != 0 &&
                        MInput.Keyboard.Pressed(pressedKeys[pressedKeys.Length - 1]))
                    {
                        AddRemap(pressedKeys[pressedKeys.Length - 1]);
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
                float num = Ease.CubeInOut(Min(1f, resetDelay / 0.2f));
                float num2 = Ease.SineOut(Min(1f, resetTime / 1.5f));
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, Color.Black * 0.95f * num);
                float num3 = 480f;
                float x = (1920f - num3) / 2f;
                SourcePrimitiveDrawing.Rect(context, this, x, 530f, num3, 20f, Color.White * 0.25f * num);
                SourcePrimitiveDrawing.Rect(context, this, x, 530f, num3 * num2, 20f, Color.White * num);
            }
        }
    }
}
