using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Game.Controls.Source
{
    public sealed class OriginalGameInputProcess : Celeste.Input.Gameplay.ISourceGameInput,
        Celeste.Input.Gameplay.Feedback.IRumbleSession, Celeste.Input.Bindings.ISourceMenuInput
    {
        void Celeste.Input.Gameplay.Feedback.IRumbleSession.Rumble(int strength, int length)
            => Rumble((RumbleStrength)strength, (RumbleLength)length);

        void Celeste.Input.Gameplay.Feedback.IRumbleSession.RumbleSpecific(float strength, float time)
            => RumbleSpecific(strength, time);

        void Celeste.Input.Gameplay.Feedback.IRumbleSession.StopRumble()
            => engine.MInput.GamePads[Gamepad].StopRumble();

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

        Vector2 Celeste.Input.Gameplay.ISourceGameInput.LastAim
        {
            get => LastAim;
            set => LastAim = value;
        }

        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.Jump => Jump;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.Dash => Dash;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.CrouchDash => CrouchDash;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.Grab => Grab;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.Talk => Talk;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.ESC => ESC;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.Pause => Pause;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.QuickRestart => QuickRestart;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.MenuLeft => MenuLeft;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.MenuRight => MenuRight;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.MenuUp => MenuUp;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.MenuDown => MenuDown;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.MenuConfirm => MenuConfirm;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.MenuCancel => MenuCancel;
        Celeste.Core.Input.ISourceVirtualButton Celeste.Input.Gameplay.ISourceGameInput.MenuJournal => MenuJournal;
        Celeste.Core.Input.ISourceVirtualIntegerAxis Celeste.Input.Gameplay.ISourceGameInput.MoveX => MoveX;
        Celeste.Core.Input.ISourceVirtualIntegerAxis Celeste.Input.Gameplay.ISourceGameInput.MoveY => MoveY;
        Celeste.Core.Input.ISourceVirtualIntegerAxis Celeste.Input.Gameplay.ISourceGameInput.GliderMoveY => GliderMoveY;
        Celeste.Core.Input.ISourceVirtualJoystick Celeste.Input.Gameplay.ISourceGameInput.Aim => Aim;
        Celeste.Core.Input.ISourceVirtualJoystick Celeste.Input.Gameplay.ISourceGameInput.Feather => Feather;
        Celeste.Core.Input.ISourceVirtualJoystick Celeste.Input.Gameplay.ISourceGameInput.MountainAim => MountainAim;

        public Celeste.Core.Input.ISourceVirtualButton this[Celeste.Input.Gameplay.GameAction action] => action switch
        {
            Celeste.Input.Gameplay.GameAction.Jump => Jump,
            Celeste.Input.Gameplay.GameAction.Dash => Dash,
            Celeste.Input.Gameplay.GameAction.CrouchDash => CrouchDash,
            Celeste.Input.Gameplay.GameAction.Grab => Grab,
            Celeste.Input.Gameplay.GameAction.Talk => Talk,
            Celeste.Input.Gameplay.GameAction.Escape => ESC,
            Celeste.Input.Gameplay.GameAction.Pause => Pause,
            Celeste.Input.Gameplay.GameAction.QuickRestart => QuickRestart,
            Celeste.Input.Gameplay.GameAction.MenuLeft => MenuLeft,
            Celeste.Input.Gameplay.GameAction.MenuRight => MenuRight,
            Celeste.Input.Gameplay.GameAction.MenuUp => MenuUp,
            Celeste.Input.Gameplay.GameAction.MenuDown => MenuDown,
            Celeste.Input.Gameplay.GameAction.MenuConfirm => MenuConfirm,
            Celeste.Input.Gameplay.GameAction.MenuCancel => MenuCancel,
            Celeste.Input.Gameplay.GameAction.MenuJournal => MenuJournal,
            _ => throw new KeyNotFoundException()
        };

        private readonly IOriginalGameInputSourceEnvironment engine;

        public OriginalGameInputProcess(IOriginalGameInputSourceEnvironment engine)
        {
            this.engine = engine;
        }

        public enum PrefixMode
        {
            Latest,
            Attached
        }

        private int gamepad = 0;

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

        private Dictionary<SourceKeys, string> keyNameLookup = new Dictionary<SourceKeys, string>();

        private Dictionary<SourceGamePadButtonFlags, string> buttonNameLookup =
            new Dictionary<SourceGamePadButtonFlags, string>();

        private Dictionary<string, Dictionary<string, string>> guiPathLookup =
            new Dictionary<string, Dictionary<string, string>>();

        private float[] rumbleStrengths = new float[4] { 0.15f, 0.4f, 1f, 0.05f };

        private float[] rumbleLengths = new float[5] { 0.1f, 0.25f, 0.5f, 1f, 2f };

        public int Gamepad
        {
            get { return gamepad; }
            set
            {
                int num = Celeste.Core.Mathematics.ScalarMath.Clamp(value, 0, engine.MInput.GamePads.Length - 1);
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
                CrouchDashModes crouchDashMode = engine.InputSourceSettings.CrouchDashMode;
                if (crouchDashMode == CrouchDashModes.Press || crouchDashMode != CrouchDashModes.Hold)
                {
                    return Dash.Pressed;
                }

                if (Dash.Pressed)
                {
                    return !CrouchDash.Check;
                }

                return false;
            }
        }

        public bool CrouchDashPressed
        {
            get
            {
                CrouchDashModes crouchDashMode = engine.InputSourceSettings.CrouchDashMode;
                if (crouchDashMode == CrouchDashModes.Press || crouchDashMode != CrouchDashModes.Hold)
                {
                    return CrouchDash.Pressed;
                }

                if (Dash.Pressed)
                {
                    return CrouchDash.Check;
                }

                return false;
            }
        }

        public void Initialize()
        {
            bool flag = false;
            if (MoveX != null)
            {
                flag = MoveX.Inverted;
            }

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
            SourceInputBinding binding = new SourceInputBinding();
            binding.Add(SourceKeys.A);
            binding.Add(SourceGamePadButtonFlags.RightThumbstickLeft);
            SourceInputBinding binding2 = new SourceInputBinding();
            binding2.Add(SourceKeys.D);
            binding2.Add(SourceGamePadButtonFlags.RightThumbstickRight);
            SourceInputBinding binding3 = new SourceInputBinding();
            binding3.Add(SourceKeys.W);
            binding3.Add(SourceGamePadButtonFlags.RightThumbstickUp);
            SourceInputBinding binding4 = new SourceInputBinding();
            binding4.Add(SourceKeys.S);
            binding4.Add(SourceGamePadButtonFlags.RightThumbstickDown);
            MountainAim =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateJoystick(
                    engine.MInput,
                    binding3, binding4, binding, binding2, Gamepad, 0.1f);
            SourceInputBinding binding5 = new SourceInputBinding();
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
            if (ESC != null)
            {
                ESC.Deregister();
            }

            if (Pause != null)
            {
                Pause.Deregister();
            }

            if (MenuLeft != null)
            {
                MenuLeft.Deregister();
            }

            if (MenuRight != null)
            {
                MenuRight.Deregister();
            }

            if (MenuUp != null)
            {
                MenuUp.Deregister();
            }

            if (MenuDown != null)
            {
                MenuDown.Deregister();
            }

            if (MenuConfirm != null)
            {
                MenuConfirm.Deregister();
            }

            if (MenuCancel != null)
            {
                MenuCancel.Deregister();
            }

            if (MenuJournal != null)
            {
                MenuJournal.Deregister();
            }

            if (QuickRestart != null)
            {
                QuickRestart.Deregister();
            }

            if (MoveX != null)
            {
                MoveX.Deregister();
            }

            if (MoveY != null)
            {
                MoveY.Deregister();
            }

            if (GliderMoveY != null)
            {
                GliderMoveY.Deregister();
            }

            if (Aim != null)
            {
                Aim.Deregister();
            }

            if (MountainAim != null)
            {
                MountainAim.Deregister();
            }

            if (Jump != null)
            {
                Jump.Deregister();
            }

            if (Dash != null)
            {
                Dash.Deregister();
            }

            if (Grab != null)
            {
                Grab.Deregister();
            }

            if (Talk != null)
            {
                Talk.Deregister();
            }

            if (CrouchDash != null)
            {
                CrouchDash.Deregister();
            }

            ((IOriginalInputLifecycleEnvironment)engine).InputLifecycle.AfterDeregister(this);
        }

        public bool AnyGamepadConfirmPressed(out int gamepadIndex)
        {
            bool result = false;
            gamepadIndex = -1;
            int gamepadIndex2 = MenuConfirm.GamepadIndex;
            for (int i = 0; i < engine.MInput.GamePads.Length; i++)
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
            float num = 1f;
            if (engine.InputSourceSettings.Rumble == RumbleAmount.Half)
            {
                num = 0.5f;
            }

            if (engine.InputSourceSettings.Rumble != RumbleAmount.Off && engine.MInput.GamePads.Length != 0 &&
                !engine.MInput.Disabled)
            {
                engine.MInput.GamePads[Gamepad]
                    .Rumble(rumbleStrengths[(int)strength] * num, rumbleLengths[(int)length]);
            }
        }

        public void RumbleSpecific(float strength, float time)
        {
            float num = 1f;
            if (engine.InputSourceSettings.Rumble == RumbleAmount.Half)
            {
                num = 0.5f;
            }

            if (engine.InputSourceSettings.Rumble != RumbleAmount.Off && engine.MInput.GamePads.Length != 0 &&
                !engine.MInput.Disabled)
            {
                engine.MInput.GamePads[Gamepad].Rumble(strength * num, time);
            }
        }

        public void UpdateGrab()
        {
            if (engine.InputSourceSettings.GrabMode == GrabModes.Toggle && Grab.Pressed)
            {
                grabToggle = !grabToggle;
            }
        }

        public void ResetGrab()
        {
            grabToggle = false;
        }

        public Vector2 GetAimVector(int defaultFacing = 1)
        {
            Vector2 value = Aim.Value;
            if (value == Vector2.Zero)
            {
                if (engine.CurrentSave != null && engine.CurrentSave.Assists.DashAssist)
                {
                    return LastAim;
                }

                LastAim = Vector2.UnitX * (float)defaultFacing;
            }
            else if (engine.CurrentSave != null && engine.CurrentSave.Assists.ThreeSixtyDashing)
            {
                LastAim = engine.VectorArithmetic.SafeNormalize(value);
            }
            else
            {
                float num = (float)Math.Atan2(value.Y, value.X);
                int num2 = ((num < 0f) ? 1 : 0);
                float num3 = (float)Math.PI / 8f - (float)num2 * 0.08726646f;
                if (Celeste.Core.Mathematics.ScalarMath.AbsAngleDiff(num, 0f) < num3)
                {
                    LastAim = new Vector2(1f, 0f);
                }
                else if (Celeste.Core.Mathematics.ScalarMath.AbsAngleDiff(num, (float)Math.PI) < num3)
                {
                    LastAim = new Vector2(-1f, 0f);
                }
                else if (Celeste.Core.Mathematics.ScalarMath.AbsAngleDiff(num, -(float)Math.PI / 2f) < num3)
                {
                    LastAim = new Vector2(0f, -1f);
                }
                else if (Celeste.Core.Mathematics.ScalarMath.AbsAngleDiff(num, (float)Math.PI / 2f) < num3)
                {
                    LastAim = new Vector2(0f, 1f);
                }
                else
                {
                    LastAim = engine.VectorArithmetic.SafeNormalize(new Vector2(Math.Sign(value.X),
                        Math.Sign(value.Y)));
                }
            }

            return LastAim;
        }

        public IOriginalGameInputSourceEnvironment SourceEnvironment => engine;

        public string GuiInputPrefix(PrefixMode mode = PrefixMode.Latest)
            => ((global::Celeste.Game.Input.Gui.IOriginalInputGuiPolicyEnvironment)engine).InputGuiPolicy
                .GuiInputPrefix(this, mode);

        public string OriginalGuiInputPrefix(PrefixMode mode)
        {
            if (!string.IsNullOrEmpty(OverrideInputPrefix))
            {
                return OverrideInputPrefix;
            }
#pragma warning disable CS0219
            bool flag = false;
#pragma warning restore CS0219
            if ((mode != PrefixMode.Latest)
                    ? engine.MInput.GamePads[Gamepad].Attached
                    : engine.MInput.ControllerHasFocus)
            {
                return "xb1";
            }

            return "keyboard";
        }

        public bool GuiInputController(PrefixMode mode = PrefixMode.Latest)
        {
            return !GuiInputPrefix(mode).Equals("keyboard");
        }

        public AtlasEntry GuiButton(SourceVirtualButton button, PrefixMode mode = PrefixMode.Latest,
            string fallback = "controls/keyboard/oemquestion")
            => ((global::Celeste.Game.Input.Gui.IOriginalInputGuiPolicyEnvironment)engine).InputGuiPolicy.GuiButton(
                this, button, mode, fallback);

        public AtlasEntry OriginalGuiButton(SourceVirtualButton button, PrefixMode mode, string fallback)
        {
            string prefix = GuiInputPrefix(mode);
            bool num = GuiInputController(mode);
            string value = "";
            if (num)
            {
                using List<SourceGamePadButtonFlags>.Enumerator enumerator = button.Binding.Controller.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    SourceGamePadButtonFlags current = enumerator.Current;
                    if (!buttonNameLookup.TryGetValue(current, out value))
                    {
                        buttonNameLookup.Add(current, value = current.ToString());
                    }
                }
            }
            else
            {
                SourceKeys key = FirstKey(button);
                if (!keyNameLookup.TryGetValue(key, out value))
                {
                    keyNameLookup.Add(key, value = key.ToString());
                }
            }

            AtlasEntry mTexture = GuiTexture(prefix, value);
            if (mTexture == null && fallback != null)
            {
                return engine.GuiAtlas[fallback];
            }

            return mTexture;
        }

        public AtlasEntry GuiSingleButton(SourceGamePadButtonFlags button, PrefixMode mode = PrefixMode.Latest,
            string fallback = "controls/keyboard/oemquestion")
        {
            string prefix = ((!GuiInputController(mode)) ? "xb1" : GuiInputPrefix(mode));
            string value = "";
            if (!buttonNameLookup.TryGetValue(button, out value))
            {
                buttonNameLookup.Add(button, value = button.ToString());
            }

            AtlasEntry mTexture = GuiTexture(prefix, value);
            if (mTexture == null && fallback != null)
            {
                return engine.GuiAtlas[fallback];
            }

            return mTexture;
        }

        public AtlasEntry GuiKey(SourceKeys key, string fallback = "controls/keyboard/oemquestion")
        {
            if (!keyNameLookup.TryGetValue(key, out var value))
            {
                keyNameLookup.Add(key, value = key.ToString());
            }

            AtlasEntry mTexture = GuiTexture("keyboard", value);
            if (mTexture == null && fallback != null)
            {
                return engine.GuiAtlas[fallback];
            }

            return mTexture;
        }

        public SourceGamePadButtonFlags FirstButton(SourceVirtualButton button)
        {
            using (List<SourceGamePadButtonFlags>.Enumerator enumerator = button.Binding.Controller.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }

            return SourceGamePadButtonFlags.A;
        }

        public SourceKeys FirstKey(SourceVirtualButton button)
        {
            foreach (SourceKeys item in button.Binding.Keyboard)
            {
                if (item != SourceKeys.None)
                {
                    return item;
                }
            }

            return SourceKeys.None;
        }

        public AtlasEntry GuiDirection(Vector2 direction)
        {
            int num = Math.Sign(direction.X);
            int num2 = Math.Sign(direction.Y);
            string input = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NegativeSign == "-"
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
                    _ => "1x1"
                }
                : num + "x" + num2;
            return GuiTexture("directions", input);
        }

        public AtlasEntry GuiTexture(string prefix, string input)
        {
            if (!guiPathLookup.TryGetValue(prefix, out var value))
            {
                guiPathLookup.Add(prefix, value = new Dictionary<string, string>());
            }

            if (!value.TryGetValue(input, out var value2))
            {
                value.Add(input, value2 = "controls/" + prefix + "/" + input);
            }

            if (!engine.GuiAtlas.Has(value2))
            {
                if (prefix != "fallback")
                {
                    return GuiTexture("fallback", input);
                }

                return null;
            }

            return engine.GuiAtlas[value2];
        }

        public void SetLightbarColor(Celeste.Core.Display.PackedColor color)
        {
        }
    }
}
