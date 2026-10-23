using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Input;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Menus.Options;
using Celeste.Game.Settings;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Input.Runtime;
using Celeste.Simulation.Rendering;
using Celeste.Simulation.UI.Menus.Text;
using Color = Celeste.Core.Display.PackedColor;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using Binding = Celeste.Input.Bindings.SourceInputBinding;

namespace Celeste.Everest.UI.Controls
{
    public class EverestButtonConfigPresentation : TextMenuPresentation
    {
        private readonly ISourceEngineContext engine;
        private readonly MenuOptionsPresentation menuOptions;
        private OriginalGameInputProcess SourceInput => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private SourceMInputProcess MInput => ((ISourceMInputEnvironment)engine).MInput;

        private SettingsState Settings =>
            ((ISettingsContext)engine).Settings;

        private OriginalGameTextProcess Text =>
            ((IOriginalGameTextEnvironment)engine).Text;

        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ActiveBitmapFont Font => ((ISourceActiveFontScope)engine).ActiveFont;

        private void Play(string path)
        {
            ((IOriginalGameplayProcess)engine)
                .AudioSession.Play(path);
        }

        private float Approach(float value, float target, float amount)
        {
            return ScalarMath.Approach(value, target, amount, Extrema);
        }

        private EverestCoreSettings CoreSettings => ((IEverestControlConfigEnvironment)engine).CoreSettings;

        private bool remapping;

        private float remappingEase;

        private Binding remappingBinding;

        private string remappingText;

        private float inputDelay;

        private float timeout;

        private bool closing;

        private float closingDelay;

        private bool waitingForController;

        private bool resetHeld;

        private float resetTime;

        private float resetDelay;

        public static string StadiaControllerDisclaimer =
            "No endorsement or affiliation is intended between Stadia and the manufacturers\nof non-Stadia controllers or consoles. STADIA, the Stadia beacon, Google, and related\nmarks and logos are trademarks of Google LLC. All other trademarks are the\nproperty of their respective owners.";

        protected List<Buttons> All { get; } =
        [
            Buttons.A,
            Buttons.B,
            Buttons.X,
            Buttons.Y,
            Buttons.LeftShoulder,
            Buttons.RightShoulder,
            Buttons.LeftTrigger,
            Buttons.RightTrigger,
        ];

        public EverestButtonConfigPresentation(ISourceEngineContext engine,
            MenuOptionsPresentation menuOptions) : base(engine)
        {
            this.engine = engine;
            this.menuOptions = menuOptions;
            InitializeOriginalMenu();
            Reload();
        }

        public void AddMap(string label, Binding binding)
        {
            var txt = Text.CleanDialog("KEY_CONFIG_" + label);
            Add(new Setting(txt, new ControlBindingMenuAdapter(binding),
                true).Pressed(() =>
            {
                remappingText = txt;
                Remap(binding);
            }).AltPressed(delegate { Clear(binding); }));
        }

        public void Remap(Binding binding)
        {
            if (!SourceInput.GuiInputController())
                return;
            remapping = true;
            remappingBinding = binding;
            timeout = 5f;
            Focused = false;
        }

        public void AddRemap(Buttons btn)
        {
            remapping = false;
            inputDelay = 0.25f;
            if (!(remappingBinding.Controller.Contains(btn)
                    ? ((InstalledSourceInputBinding)remappingBinding).Remove(btn)
                    : remappingBinding.Add(btn)))
                Play("event:/ui/main/button_invalid");

            while (remappingBinding.Controller.Count > SourceInput.MaxBindings) remappingBinding.Controller.RemoveAt(0);

            SourceInput.Initialize();
        }

        public void Clear(Binding binding)
        {
            if (!binding.ClearGamepad()) Play("event:/ui/main/button_invalid");
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

                if (resetHeld) return;
            }

            base.Update();
            Focused = !closing && inputDelay <= 0f && !waitingForController && !remapping;
            if (!closing)
            {
                if (!MInput.GamePads[SourceInput.Gamepad].Attached)
                    waitingForController = true;
                else if (waitingForController) waitingForController = false;

                if (SourceInput.MenuCancel.Pressed && !remapping) OnCancel();
            }

            if (inputDelay > 0f && !remapping) inputDelay -= engine.RawDeltaTime;

            remappingEase = Approach(remappingEase, remapping ? 1 : 0, engine.RawDeltaTime * 4f);
            if (remappingEase >= 0.25f && remapping)
            {
                if (SourceInput.ESC.Pressed || timeout <= 0f ||
                    !SourceInput.GuiInputController())
                {
                    remapping = false;
                    Focused = true;
                }
                else
                {
                    var gamePadData = MInput.GamePads[SourceInput.Gamepad];
                    var num = 0.25f;
                    if (gamePadData.LeftStickLeftPressed(num))
                        AddRemap(Buttons.LeftThumbstickLeft);
                    else if (gamePadData.LeftStickRightPressed(num))
                        AddRemap(Buttons.LeftThumbstickRight);
                    else if (gamePadData.LeftStickUpPressed(num))
                        AddRemap(Buttons.LeftThumbstickUp);
                    else if (gamePadData.LeftStickDownPressed(num))
                        AddRemap(Buttons.LeftThumbstickDown);
                    else if (gamePadData.RightStickLeftPressed(num))
                        AddRemap(Buttons.RightThumbstickLeft);
                    else if (gamePadData.RightStickRightPressed(num))
                        AddRemap(Buttons.RightThumbstickRight);
                    else if (gamePadData.RightStickDownPressed(num))
                        AddRemap(Buttons.RightThumbstickDown);
                    else if (gamePadData.RightStickUpPressed(num))
                        AddRemap(Buttons.RightThumbstickUp);
                    else if (gamePadData.LeftTriggerPressed(num))
                        AddRemap(Buttons.LeftTrigger);
                    else if (gamePadData.RightTriggerPressed(num))
                        AddRemap(Buttons.RightTrigger);
                    else if (gamePadData.Pressed(Buttons.DPadLeft))
                        AddRemap(Buttons.DPadLeft);
                    else if (gamePadData.Pressed(Buttons.DPadRight))
                        AddRemap(Buttons.DPadRight);
                    else if (gamePadData.Pressed(Buttons.DPadUp))
                        AddRemap(Buttons.DPadUp);
                    else if (gamePadData.Pressed(Buttons.DPadDown))
                        AddRemap(Buttons.DPadDown);
                    else if (gamePadData.Pressed(Buttons.A))
                        AddRemap(Buttons.A);
                    else if (gamePadData.Pressed(Buttons.B))
                        AddRemap(Buttons.B);
                    else if (gamePadData.Pressed(Buttons.X))
                        AddRemap(Buttons.X);
                    else if (gamePadData.Pressed(Buttons.Y))
                        AddRemap(Buttons.Y);
                    else if (gamePadData.Pressed(Buttons.Start))
                        AddRemap(Buttons.Start);
                    else if (gamePadData.Pressed(Buttons.Back))
                        AddRemap(Buttons.Back);
                    else if (gamePadData.Pressed(Buttons.LeftShoulder))
                        AddRemap(Buttons.LeftShoulder);
                    else if (gamePadData.Pressed(Buttons.RightShoulder))
                        AddRemap(Buttons.RightShoulder);
                    else if (gamePadData.Pressed(Buttons.LeftStick))
                        AddRemap(Buttons.LeftStick);
                    else if (gamePadData.Pressed(Buttons.RightStick)) AddRemap(Buttons.RightStick);
                }

                timeout -= engine.RawDeltaTime;
            }

            closingDelay -= engine.RawDeltaTime;
            Alpha = Approach(Alpha, !closing || !(closingDelay <= 0f) ? 1 : 0, engine.RawDeltaTime * 8f);
            if (closing && Alpha <= 0f) Close();
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, Color.Black * Ease.CubeOut(Alpha));
            var vector = new Vector2(1920f, 1080f) * 0.5f;
            if (MInput.GamePads[SourceInput.Gamepad].Attached)
            {
                base.Render(context);
                if (remappingEase > 0f)
                {
                    SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                        Color.Black * 0.95f * Ease.CubeInOut(remappingEase));
                    Font.Draw(context, this, Text.Dialog.Get("BTN_CONFIG_CHANGING"), vector + new Vector2(0f, -8f),
                        new(0.5f, 1f), Vector2.One * 0.7f, Color.LightGray * Ease.CubeIn(remappingEase));
                    Font.Draw(context, this, remappingText, vector + new Vector2(0f, 8f), new(0.5f, 0f),
                        Vector2.One * 2f, Color.White * Ease.CubeIn(remappingEase));
                }
            }
            else
            {
                Font.Draw(context, this, Text.CleanDialog("BTN_CONFIG_NOCONTROLLER"), vector, new(0.5f, 0.5f),
                    Vector2.One, Color.White * Ease.CubeOut(Alpha));
            }

            if (!resetHeld)
                return;
            var num = Ease.CubeInOut(Extrema.Min(1f, resetDelay / 0.2f));
            var num2 = Ease.SineOut(Extrema.Min(1f, resetTime / 1.5f));
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, Color.Black * 0.95f * num);
            var num3 = 480f;
            var x = (1920f - num3) / 2f;
            SourcePrimitiveDrawing.Rect(context, this, x, 530f, num3, 20f, Color.White * 0.25f * num);
            SourcePrimitiveDrawing.Rect(context, this, x, 530f, num3 * num2, 20f, Color.White * num);
        }

        private void InitializeOriginalMenu()
        {
            Add(new Header(Text.CleanDialog("BTN_CONFIG_TITLE")));
            Add(new InputMappingInfoPresentation(engine, true));
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
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MENU_NOTICE"), false));
            AddMap("LEFT", Settings.MenuLeft);
            AddMap("RIGHT", Settings.MenuRight);
            AddMap("UP", Settings.MenuUp);
            AddMap("DOWN", Settings.MenuDown);
            AddMap("CONFIRM", Settings.Confirm);
            AddMap("CANCEL", Settings.Cancel);
            AddMap("JOURNAL", Settings.Journal);
            AddMap("PAUSE", Settings.Pause);
            Add(new SubHeader(""));
            var button = new Button(Text.CleanDialog("KEY_CONFIG_RESET"));
            button.IncludeWidthInMeasurement = false;
            button.AlwaysCenter = true;
            button.OnPressed = () =>
            {
                resetHeld = true;
                resetTime = 0f;
                resetDelay = 0f;
            };
            button.ConfirmSfx = "event:/ui/main/button_lowkey";
            Add(button);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_ADVANCED")));
            AddMap("QUICKRESTART", Settings.QuickRestart);
            AddMap("DEMO", Settings.DemoDash);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MOVE_ONLY")));
            AddMap("LEFT", Settings.LeftMoveOnly);
            AddMap("RIGHT", Settings.RightMoveOnly);
            AddMap("UP", Settings.UpMoveOnly);
            AddMap("DOWN", Settings.DownMoveOnly);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_DASH_ONLY")));
            AddMap("LEFT", Settings.LeftDashOnly);
            AddMap("RIGHT", Settings.RightDashOnly);
            AddMap("UP", Settings.UpDashOnly);
            AddMap("DOWN", Settings.DownDashOnly);
            OnESC = OnCancel = () =>
            {
                menuOptions.UpdateCrouchDashModeVisibility();
                Focused = false;
                closing = true;
            };
            MinWidth = 600f;
            Position = new(Position.X, ScrollTargetY);
            Alpha = 0f;
        }

        /// <summary>
        ///     ForceRemap all important mappings which are fully unassigned and require mappings when leaving the menu.
        /// </summary>
        /// <summary>
        ///     Gets the label to display on-screen for a mapping.
        /// </summary>
        /// <param name="mapping">The mapping index</param>
        /// <returns>The button name to display</returns>
        /// <summary>
        ///     Adds a button mapping to the button config screen.
        /// </summary>
        /// <param name="btn">The mapping index</param>
        /// <param name="list">The list of buttons currently mapped to it</param>
        /// <summary>
        ///     Adds a button mapping to the button config screen.
        /// </summary>
        /// <param name="btn">The mapping (should be an enum value)</param>
        /// <param name="list">The list of buttons currently mapped to it</param>
        /// <summary>
        ///     Forces a button to be bound to an action, in addition to the already bound buttons.
        /// </summary>
        /// <param name="defaultBtn">The button to force bind</param>
        /// <param name="boundBtn">The button already bound</param>
        /// <returns>A list containing both button and defaultBtn</returns>
        /// <summary>
        ///     Forces a button to be bound to an action, in addition to already bound buttons.
        /// </summary>
        /// <param name="defaultBtn">The button to force bind</param>
        /// <param name="boundBtns">The list of buttons already bound</param>
        /// <returns>A list containing both buttons in list and defaultBtn</returns>
        /// <summary>
        ///     Rebuilds the button mapping menu. Should clear the menu and add back all options.
        /// </summary>
        /// <param name="index">The index to focus on in the menu</param>
        public virtual void Reload(int index = -1)
        {
            Clear();
            Add(new Header(Text.CleanDialog("BTN_CONFIG_TITLE")));
            Add(new InputMappingInfoPresentation(engine, true));
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
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MENU_NOTICE"), false));
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
                OnPressed = delegate { ResetPressed(); },
                ConfirmSfx = "event:/ui/main/button_lowkey",
            });
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_ADVANCED")));
            AddMap("QUICKRESTART", Settings.QuickRestart);
            AddMap("DEMO", Settings.DemoDash);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_MOVE_ONLY")));
            AddMap("LEFT", Settings.LeftMoveOnly);
            AddMap("RIGHT", Settings.RightMoveOnly);
            AddMap("UP", Settings.UpMoveOnly);
            AddMap("DOWN", Settings.DownMoveOnly);
            Add(new SubHeader(Text.CleanDialog("KEY_CONFIG_DASH_ONLY")));
            AddMap("LEFT", Settings.LeftDashOnly);
            AddMap("RIGHT", Settings.RightDashOnly);
            AddMap("UP", Settings.UpDashOnly);
            AddMap("DOWN", Settings.DownDashOnly);
            if (index >= 0) Selection = index;
        }

        public virtual void ResetPressed()
        {
            resetHeld = true;
            resetTime = 0f;
            resetDelay = 0f;
        }

        public virtual void Reset()
        {
            Settings.SetDefaultButtonControls(true);
            SourceInput.Initialize();
        }

        public void AddMapForceLabel(string label, Binding binding)
        {
            Add(new Setting(label, new ControlBindingMenuAdapter(binding),
                true).Pressed(delegate
            {
                remappingText = label;
                Remap(binding);
            }).AltPressed(delegate { Clear(binding); }));
        }


        /// <summary>
        ///       Removes the button from all lists other than the current remapping list if needed.
        ///       </summary>
        /// <param name="remapping">The int value of the mapping being remapped</param>
        /// <param name="list">The list that newBtn has been added to</param>
        /// <param name="btn">The new button that the user is attempting to set.</param>


        /// <summary>
        ///       Forcibly gives all important mappings some default button values.
        ///       </summary>
        /// <param name="mapping">The int value of the mapping being remapped</param>


        /// <summary>
        ///       Returns the list used to remap buttons during a remap operation.
        ///       This should be the a List&lt;Buttons&gt; field in your settings class
        ///       </summary>
        /// <param name="remapping">The int value of the mapping being remapped</param>
        /// <param name="newBtn">The new button that the user is attempting to set.</param>
        /// <returns>the field to set buttons with, otherwise return null to cancel the operation</returns>
    }
}
