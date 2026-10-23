using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Input;
using Celeste.Core.Mathematics;
using Celeste.Game.Input.Gui;
using Celeste.Graphics.Content.Atlas;
using Celeste.Input.Bindings;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using JetBrains.Annotations;

namespace Celeste.Game.Controls.Source
{
    public sealed class OriginalGameInputProcess : ISourceGameInput,
        IRumbleSession, ISourceMenuInput
    {
        void IRumbleSession.Rumble(int strength, int length)
        {
            Rumble((RumbleStrength)strength, (RumbleLength)length);
        }

        void IRumbleSession.RumbleSpecific(float strength, float time)
        {
            RumbleSpecific(strength, time);
        }

        void IRumbleSession.StopRumble()
        {
            engine.MInput.GamePads[Gamepad].StopRumble();
        }

        SourceVirtualButton ISourceMenuInput.MenuDown => MenuDown;
        SourceVirtualButton ISourceMenuInput.MenuUp => MenuUp;
        SourceVirtualButton ISourceMenuInput.MenuLeft => MenuLeft;
        SourceVirtualButton ISourceMenuInput.MenuRight => MenuRight;
        SourceVirtualButton ISourceMenuInput.MenuConfirm => MenuConfirm;
        SourceVirtualButton ISourceMenuInput.MenuCancel => MenuCancel;
        SourceVirtualButton ISourceMenuInput.MenuJournal => MenuJournal;
        SourceVirtualButton ISourceMenuInput.Pause => Pause;
        SourceVirtualButton ISourceMenuInput.ESC => ESC;

        public float DeltaTime => engine.MInput.Engine.DeltaTime;

        Vector2 ISourceGameInput.LastAim
        {
            get => LastAim;
            set => LastAim = value;
        }

        ISourceVirtualButton ISourceGameInput.Jump => Jump;
        ISourceVirtualButton ISourceGameInput.Dash => Dash;
        ISourceVirtualButton ISourceGameInput.CrouchDash => CrouchDash;
        ISourceVirtualButton ISourceGameInput.Grab => Grab;
        ISourceVirtualButton ISourceGameInput.Talk => Talk;
        ISourceVirtualButton ISourceGameInput.ESC => ESC;
        ISourceVirtualButton ISourceGameInput.Pause => Pause;
        ISourceVirtualButton ISourceGameInput.QuickRestart => QuickRestart;
        ISourceVirtualButton ISourceGameInput.MenuLeft => MenuLeft;
        ISourceVirtualButton ISourceGameInput.MenuRight => MenuRight;
        ISourceVirtualButton ISourceGameInput.MenuUp => MenuUp;
        ISourceVirtualButton ISourceGameInput.MenuDown => MenuDown;
        ISourceVirtualButton ISourceGameInput.MenuConfirm => MenuConfirm;
        ISourceVirtualButton ISourceGameInput.MenuCancel => MenuCancel;
        ISourceVirtualButton ISourceGameInput.MenuJournal => MenuJournal;
        ISourceVirtualIntegerAxis ISourceGameInput.MoveX => MoveX;
        ISourceVirtualIntegerAxis ISourceGameInput.MoveY => MoveY;
        ISourceVirtualIntegerAxis ISourceGameInput.GliderMoveY => GliderMoveY;
        ISourceVirtualJoystick ISourceGameInput.Aim => Aim;
        ISourceVirtualJoystick ISourceGameInput.Feather => Feather;
        ISourceVirtualJoystick ISourceGameInput.MountainAim => MountainAim;

        public ISourceVirtualButton this[GameAction action] => action switch
        {
            GameAction.Jump => Jump,
            GameAction.Dash => Dash,
            GameAction.CrouchDash => CrouchDash,
            GameAction.Grab => Grab,
            GameAction.Talk => Talk,
            GameAction.Escape => ESC,
            GameAction.Pause => Pause,
            GameAction.QuickRestart => QuickRestart,
            GameAction.MenuLeft => MenuLeft,
            GameAction.MenuRight => MenuRight,
            GameAction.MenuUp => MenuUp,
            GameAction.MenuDown => MenuDown,
            GameAction.MenuConfirm => MenuConfirm,
            GameAction.MenuCancel => MenuCancel,
            GameAction.MenuJournal => MenuJournal,
            _ => throw new KeyNotFoundException(),
        };

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly IOriginalGameInputSourceEnvironment engine;

        public OriginalGameInputProcess(IOriginalGameInputSourceEnvironment engine)
        {
            this.engine = engine;
        }

        public enum PrefixMode
        {
            Latest,
            Attached,
        }

        private int gamepad;

        public readonly int MaxBindings = 8;

        public SourceVirtualButton ESC;

        public SourceVirtualButton Pause;

        public SourceVirtualButton MenuLeft;

        public SourceVirtualButton MenuRight;

        public SourceVirtualButton MenuUp;

        public SourceVirtualButton MenuDown;

        public SourceVirtualButton MenuConfirm;

        public SourceVirtualButton MenuCancel;

        public SourceVirtualButton MenuJournal;

        public SourceVirtualButton QuickRestart;

        public SourceVirtualIntegerAxis MoveX;

        public SourceVirtualIntegerAxis MoveY;

        public SourceVirtualIntegerAxis GliderMoveY;

        public SourceVirtualJoystick Aim;

        public SourceVirtualJoystick Feather;

        public SourceVirtualJoystick MountainAim;

        public SourceVirtualButton Jump;

        public SourceVirtualButton Dash;

        public SourceVirtualButton Grab;

        public SourceVirtualButton Talk;

        public SourceVirtualButton CrouchDash;

        private bool grabToggle;

        public Vector2 LastAim;

        public string OverrideInputPrefix = null;

        private readonly Dictionary<SourceKeys, string> keyNameLookup = new();

        private readonly Dictionary<SourceGamePadButtonFlags, string> buttonNameLookup = new();

        private readonly Dictionary<string, Dictionary<string, string>> guiPathLookup = new();

        private readonly float[] rumbleStrengths = [0.15f, 0.4f, 1f, 0.05f];

        private readonly float[] rumbleLengths = [0.1f, 0.25f, 0.5f, 1f, 2f];

        public int Gamepad
        {
            get => gamepad;
            set
            {
                var num = ScalarMath.Clamp(value, 0, engine.MInput.GamePads.Length - 1);
                if (gamepad != num)
                {
                    gamepad = num;
                    Initialize();
                }
            }
        }

        public bool GrabCheck => engine.InputSourceSettings.GrabMode switch
        {
            GrabModes.Invert => !Grab.Check,
            GrabModes.Toggle => grabToggle,
            _ => Grab.Check,
        };

        public bool DashPressed
        {
            get
            {
                var crouchDashMode = engine.InputSourceSettings.CrouchDashMode;
                if (crouchDashMode == CrouchDashModes.Press || crouchDashMode != CrouchDashModes.Hold)
                    return Dash.Pressed;

                if (Dash.Pressed) return !CrouchDash.Check;

                return false;
            }
        }

        public bool CrouchDashPressed
        {
            get
            {
                var crouchDashMode = engine.InputSourceSettings.CrouchDashMode;
                if (crouchDashMode == CrouchDashModes.Press || crouchDashMode != CrouchDashModes.Hold)
                    return CrouchDash.Pressed;

                return Dash.Pressed ? CrouchDash.Check : false;
            }
        }

        public void Initialize()
        {
            var flag = false;
            if (MoveX != null) flag = MoveX.Inverted;

            Deregister();
            MoveX = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateIntegerAxis(
                engine.MInput, engine.InputSourceSettings.Left, engine.InputSourceSettings.LeftMoveOnly,
                engine.InputSourceSettings.Right, engine.InputSourceSettings.RightMoveOnly, Gamepad, 0.3f);
            MoveX.Inverted = flag;
            MoveY = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateIntegerAxis(
                engine.MInput, engine.InputSourceSettings.Up, engine.InputSourceSettings.UpMoveOnly,
                engine.InputSourceSettings.Down, engine.InputSourceSettings.DownMoveOnly, Gamepad, 0.7f);
            GliderMoveY = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction
                .CreateIntegerAxis(
                    engine.MInput, engine.InputSourceSettings.Up, engine.InputSourceSettings.UpMoveOnly,
                    engine.InputSourceSettings.Down, engine.InputSourceSettings.DownMoveOnly, Gamepad, 0.3f);
            Aim = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateJoystick(
                engine.MInput, engine.InputSourceSettings.Up, engine.InputSourceSettings.UpDashOnly,
                engine.InputSourceSettings.Down, engine.InputSourceSettings.DownDashOnly,
                engine.InputSourceSettings.Left,
                engine.InputSourceSettings.LeftDashOnly, engine.InputSourceSettings.Right,
                engine.InputSourceSettings.RightDashOnly, Gamepad, 0.25f);
            Aim.InvertedX = flag;
            Feather = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateJoystick(
                engine.MInput, engine.InputSourceSettings.Up, engine.InputSourceSettings.UpMoveOnly,
                engine.InputSourceSettings.Down, engine.InputSourceSettings.DownMoveOnly,
                engine.InputSourceSettings.Left,
                engine.InputSourceSettings.LeftMoveOnly, engine.InputSourceSettings.Right,
                engine.InputSourceSettings.RightMoveOnly, Gamepad, 0.25f);
            Feather.InvertedX = flag;
            Jump = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput,
                engine.InputSourceSettings.Jump, Gamepad, 0.08f, 0.2f);
            Dash = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput,
                engine.InputSourceSettings.Dash, Gamepad, 0.08f, 0.2f);
            Talk = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput,
                engine.InputSourceSettings.Talk, Gamepad, 0.08f, 0.2f);
            Grab = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput,
                engine.InputSourceSettings.Grab, Gamepad, 0f, 0.2f);
            CrouchDash =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                    engine.MInput,
                    engine.InputSourceSettings.DemoDash, Gamepad, 0.08f, 0.2f);
            var binding = new SourceInputBinding();
            binding.Add(SourceKeys.A);
            binding.Add(SourceGamePadButtonFlags.RightThumbstickLeft);
            var binding2 = new SourceInputBinding();
            binding2.Add(SourceKeys.D);
            binding2.Add(SourceGamePadButtonFlags.RightThumbstickRight);
            var binding3 = new SourceInputBinding();
            binding3.Add(SourceKeys.W);
            binding3.Add(SourceGamePadButtonFlags.RightThumbstickUp);
            var binding4 = new SourceInputBinding();
            binding4.Add(SourceKeys.S);
            binding4.Add(SourceGamePadButtonFlags.RightThumbstickDown);
            MountainAim =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateJoystick(
                    engine.MInput,
                    binding3, binding4, binding, binding2, Gamepad, 0.1f);
            var binding5 = new SourceInputBinding();
            binding5.Add(SourceKeys.Escape);
            ESC = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput,
                binding5, Gamepad, 0.1f, 0.2f);
            Pause = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput, engine.InputSourceSettings.Pause, Gamepad, 0.1f, 0.2f);
            QuickRestart =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                    engine.MInput,
                    engine.InputSourceSettings.QuickRestart, Gamepad, 0.1f, 0.2f);
            MenuLeft = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput, engine.InputSourceSettings.MenuLeft, Gamepad, 0f, 0.4f);
            MenuLeft.SetRepeat(0.4f, 0.1f);
            MenuRight = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput, engine.InputSourceSettings.MenuRight, Gamepad, 0f, 0.4f);
            MenuRight.SetRepeat(0.4f, 0.1f);
            MenuUp = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput, engine.InputSourceSettings.MenuUp, Gamepad, 0f, 0.4f);
            MenuUp.SetRepeat(0.4f, 0.1f);
            MenuDown = ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                engine.MInput, engine.InputSourceSettings.MenuDown, Gamepad, 0f, 0.4f);
            MenuDown.SetRepeat(0.4f, 0.1f);
            MenuJournal =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                    engine.MInput,
                    engine.InputSourceSettings.Journal, Gamepad, 0f, 0.2f);
            MenuConfirm =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                    engine.MInput,
                    engine.InputSourceSettings.Confirm, Gamepad, 0f, 0.2f);
            MenuCancel =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateButton(
                    engine.MInput,
                    engine.InputSourceSettings.Cancel, Gamepad, 0f, 0.2f);
            ((IOriginalInputLifecycleEnvironment)engine).InputLifecycle.AfterInitialize(this);
        }

        public void Deregister()
        {
            if (ESC != null) ESC.Deregister();

            if (Pause != null) Pause.Deregister();

            if (MenuLeft != null) MenuLeft.Deregister();

            if (MenuRight != null) MenuRight.Deregister();

            if (MenuUp != null) MenuUp.Deregister();

            if (MenuDown != null) MenuDown.Deregister();

            if (MenuConfirm != null) MenuConfirm.Deregister();

            if (MenuCancel != null) MenuCancel.Deregister();

            if (MenuJournal != null) MenuJournal.Deregister();

            if (QuickRestart != null) QuickRestart.Deregister();

            if (MoveX != null) MoveX.Deregister();

            if (MoveY != null) MoveY.Deregister();

            if (GliderMoveY != null) GliderMoveY.Deregister();

            if (Aim != null) Aim.Deregister();

            if (MountainAim != null) MountainAim.Deregister();

            if (Jump != null) Jump.Deregister();

            if (Dash != null) Dash.Deregister();

            if (Grab != null) Grab.Deregister();

            if (Talk != null) Talk.Deregister();

            if (CrouchDash != null) CrouchDash.Deregister();

            ((IOriginalInputLifecycleEnvironment)engine).InputLifecycle.AfterDeregister(this);
        }

        public bool AnyGamepadConfirmPressed(out int gamepadIndex)
        {
            var result = false;
            gamepadIndex = -1;
            var gamepadIndex2 = MenuConfirm.GamepadIndex;
            for (var i = 0; i < engine.MInput.GamePads.Length; i++)
            {
                MenuConfirm.GamepadIndex = i;
                if (MenuConfirm.Pressed)
                {
                    result = true;
                    gamepadIndex = i;
                    break;
                }
            }

            MenuConfirm.GamepadIndex = gamepadIndex2;
            return result;
        }

        public void Rumble(RumbleStrength strength, RumbleLength length)
        {
            var num = 1f;
            if (engine.InputSourceSettings.Rumble == RumbleAmount.Half) num = 0.5f;

            if (engine.InputSourceSettings.Rumble != RumbleAmount.Off && engine.MInput.GamePads.Length != 0 &&
                !engine.MInput.Disabled)
                engine.MInput.GamePads[Gamepad]
                    .Rumble(rumbleStrengths[(int)strength] * num, rumbleLengths[(int)length]);
        }

        public void RumbleSpecific(float strength, float time)
        {
            var num = 1f;
            if (engine.InputSourceSettings.Rumble == RumbleAmount.Half) num = 0.5f;

            if (engine.InputSourceSettings.Rumble != RumbleAmount.Off && engine.MInput.GamePads.Length != 0 &&
                !engine.MInput.Disabled)
                engine.MInput.GamePads[Gamepad].Rumble(strength * num, time);
        }

        public void UpdateGrab()
        {
            if (engine.InputSourceSettings.GrabMode == GrabModes.Toggle && Grab.Pressed) grabToggle = !grabToggle;
        }

        public void ResetGrab()
        {
            grabToggle = false;
        }

        public Vector2 GetAimVector(int defaultFacing = 1)
        {
            var value = Aim.Value;
            if (value == Vector2.Zero)
            {
                if (engine.CurrentSave != null && engine.CurrentSave.Assists.DashAssist) return LastAim;

                LastAim = Vector2.UnitX * defaultFacing;
            }
            else if (engine.CurrentSave != null && engine.CurrentSave.Assists.ThreeSixtyDashing)
            {
                LastAim = engine.VectorArithmetic.SafeNormalize(value);
            }
            else
            {
                var num = (float)Math.Atan2(value.Y, value.X);
                var num2 = num < 0f ? 1 : 0;
                var num3 = (float)Math.PI / 8f - num2 * 0.08726646f;
                if (ScalarMath.AbsAngleDiff(num, 0f) < num3)
                    LastAim = new(1f, 0f);
                else if (ScalarMath.AbsAngleDiff(num, (float)Math.PI) < num3)
                    LastAim = new(-1f, 0f);
                else if (ScalarMath.AbsAngleDiff(num, -(float)Math.PI / 2f) < num3)
                    LastAim = new(0f, -1f);
                else if (ScalarMath.AbsAngleDiff(num, (float)Math.PI / 2f) < num3)
                    LastAim = new(0f, 1f);
                else
                    LastAim = engine.VectorArithmetic.SafeNormalize(new Vector2(Math.Sign(value.X),
                        Math.Sign(value.Y)));
            }

            return LastAim;
        }

        public IOriginalGameInputSourceEnvironment SourceEnvironment => engine;

        public string GuiInputPrefix(PrefixMode mode = PrefixMode.Latest)
        {
            return ((IOriginalInputGuiPolicyEnvironment)engine).InputGuiPolicy
                .GuiInputPrefix(this, mode);
        }

        public string OriginalGuiInputPrefix(PrefixMode mode)
        {
            if (!string.IsNullOrEmpty(OverrideInputPrefix)) return OverrideInputPrefix;
#pragma warning disable CS0219
            var flag = false;
#pragma warning restore CS0219
            if (mode != PrefixMode.Latest
                    ? engine.MInput.GamePads[Gamepad].Attached
                    : engine.MInput.ControllerHasFocus)
                return "xb1";

            return "keyboard";
        }

        public bool GuiInputController(PrefixMode mode = PrefixMode.Latest)
        {
            return !GuiInputPrefix(mode).Equals("keyboard");
        }

        public AtlasEntry GuiButton(SourceVirtualButton button, PrefixMode mode = PrefixMode.Latest,
            string fallback = "controls/keyboard/oemquestion")
        {
            return ((IOriginalInputGuiPolicyEnvironment)engine).InputGuiPolicy.GuiButton(
                this, button, mode, fallback);
        }

        public AtlasEntry OriginalGuiButton(SourceVirtualButton button, PrefixMode mode, string fallback)
        {
            var prefix = GuiInputPrefix(mode);
            var num = GuiInputController(mode);
            var value = "";
            if (num)
            {
                using var enumerator = button.Binding.Controller.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (!buttonNameLookup.TryGetValue(current, out value))
                        buttonNameLookup.Add(current, value = current.ToString());
                }
            }
            else
            {
                var key = FirstKey(button);
                if (!keyNameLookup.TryGetValue(key, out value)) keyNameLookup.Add(key, value = key.ToString());
            }

            var mTexture = GuiTexture(prefix, value);
            if (mTexture == null && fallback != null) return engine.GuiAtlas[fallback];

            return mTexture;
        }

        public AtlasEntry GuiSingleButton(SourceGamePadButtonFlags button, PrefixMode mode = PrefixMode.Latest,
            string fallback = "controls/keyboard/oemquestion")
        {
            var prefix = !GuiInputController(mode) ? "xb1" : GuiInputPrefix(mode);
            var value = "";
            if (!buttonNameLookup.TryGetValue(button, out value))
                buttonNameLookup.Add(button, value = button.ToString());

            var mTexture = GuiTexture(prefix, value);
            if (mTexture == null && fallback != null) return engine.GuiAtlas[fallback];

            return mTexture;
        }

        public AtlasEntry GuiKey(SourceKeys key, string fallback = "controls/keyboard/oemquestion")
        {
            if (!keyNameLookup.TryGetValue(key, out var value)) keyNameLookup.Add(key, value = key.ToString());

            var mTexture = GuiTexture("keyboard", value);
            if (mTexture == null && fallback != null) return engine.GuiAtlas[fallback];

            return mTexture;
        }

        public SourceGamePadButtonFlags FirstButton(SourceVirtualButton button)
        {
            using (var enumerator = button.Binding.Controller.GetEnumerator())
            {
                if (enumerator.MoveNext()) return enumerator.Current;
            }

            return SourceGamePadButtonFlags.A;
        }

        public SourceKeys FirstKey(SourceVirtualButton button)
        {
            foreach (var item in button.Binding.Keyboard)
                if (item != SourceKeys.None)
                    return item;

            return SourceKeys.None;
        }

        public AtlasEntry GuiDirection(Vector2 direction)
        {
            var num = Math.Sign(direction.X);
            var num2 = Math.Sign(direction.Y);
            var input = CultureInfo.CurrentCulture.NumberFormat.NegativeSign == "-"
                ? (num, num2) switch
                {
                    (-1, -1) => "-1x-1",
                    (-1, 0) => "-1x0",
                    (-1, 1) => "-1x1",
                    (0, -1) => "0x-1",
                    (0, 0) => "0x0",
                    (0, 1) => "0x1",
                    (1, -1) => "1x-1",
                    (1, 0) => "1x0",
                    _ => "1x1",
                }
                : num + "x" + num2;
            return GuiTexture("directions", input);
        }

        public AtlasEntry GuiTexture(string prefix, string input)
        {
            if (!guiPathLookup.TryGetValue(prefix, out var value)) guiPathLookup.Add(prefix, value = new());

            if (!value.TryGetValue(input, out var value2))
                value.Add(input, value2 = "controls/" + prefix + "/" + input);

            if (!engine.GuiAtlas.Has(value2)) return prefix != "fallback" ? GuiTexture("fallback", input) : null;

            return engine.GuiAtlas[value2];
        }

        public void SetLightbarColor(PackedColor color)
        {
        }
    }
}
