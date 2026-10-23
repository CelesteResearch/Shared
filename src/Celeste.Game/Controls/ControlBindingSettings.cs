using System;
using System.Collections.Generic;
using Celeste.Input.Gameplay.Bindings;

namespace Celeste.Game.Controls
{
    public sealed class ControlBindingSettings
    {
        public ControlBindingState Left = new();
        public ControlBindingState Right = new();
        public ControlBindingState Up = new();
        public ControlBindingState Down = new();
        public ControlBindingState Jump = new();
        public ControlBindingState Dash = new();
        public ControlBindingState Grab = new();
        public ControlBindingState Talk = new();
        public ControlBindingState MenuLeft = new();
        public ControlBindingState MenuRight = new();
        public ControlBindingState MenuUp = new();
        public ControlBindingState MenuDown = new();
        public ControlBindingState Confirm = new();
        public ControlBindingState Cancel = new();
        public ControlBindingState Journal = new();
        public ControlBindingState Pause = new();
        public ControlBindingState QuickRestart = new();
        public ControlBindingState DemoDash = new();
        public ControlBindingState LeftMoveOnly = new();
        public ControlBindingState RightMoveOnly = new();
        public ControlBindingState UpMoveOnly = new();
        public ControlBindingState DownMoveOnly = new();
        public ControlBindingState LeftDashOnly = new();
        public ControlBindingState RightDashOnly = new();
        public ControlBindingState UpDashOnly = new();

        public ControlBindingState DownDashOnly = new();

        // Run after import: bindings are shared by settings, menu rows,
        // and live virtual input; rebuilding input must not replace these objects.
        public void AfterLoad()
        {
            ControlBindingState.SetExclusive(MenuLeft, MenuRight, MenuUp, MenuDown, Confirm, Cancel, Journal, Pause);
            SetDefaultKeyboardControls(false);
            SetDefaultButtonControls(false);
        }

        public IReadOnlyList<ControlBindingState> All => (ControlBindingState[])
        [
            Left, Right, Up, Down, Jump, Dash, Grab, Talk, MenuLeft, MenuRight, MenuUp, MenuDown, Confirm, Cancel,
            Journal, Pause, QuickRestart, DemoDash, LeftMoveOnly, RightMoveOnly, UpMoveOnly, DownMoveOnly, LeftDashOnly,
            RightDashOnly, UpDashOnly, DownDashOnly,
        ];

        public static ControlBindingValue Key(string name)
        {
            if (name.Length == 1 && name[0] >= 'A' && name[0] <= 'Z') return new(name[0], name);
            int code;
            switch (name)
            {
                case "None": code = 0; break;
                case "Back": code = 8; break;
                case "Tab": code = 9; break;
                case "Enter": code = 13; break;
                case "Escape": code = 27; break;
                case "Space": code = 32; break;
                case "Left": code = 37; break;
                case "Up": code = 38; break;
                case "Right": code = 39; break;
                case "Down": code = 40; break;
                case "LeftShift": code = 160; break;
                default: throw new ArgumentOutOfRangeException(nameof(name));
            }

            return new(code, name);
        }

        public static ControlBindingValue Button(string name)
        {
            int code;
            switch (name)
            {
                case "DPadUp": code = 1; break;
                case "DPadDown": code = 2; break;
                case "DPadLeft": code = 4; break;
                case "DPadRight": code = 8; break;
                case "Start": code = 16; break;
                case "Back": code = 32; break;
                case "LeftStick": code = 64; break;
                case "RightStick": code = 128; break;
                case "LeftShoulder": code = 256; break;
                case "RightShoulder": code = 512; break;
                case "BigButton": code = 2048; break;
                case "A": code = 4096; break;
                case "B": code = 8192; break;
                case "X": code = 16384; break;
                case "Y": code = 32768; break;
                case "LeftThumbstickLeft": code = 2097152; break;
                case "RightTrigger": code = 4194304; break;
                case "LeftTrigger": code = 8388608; break;
                case "RightThumbstickUp": code = 16777216; break;
                case "RightThumbstickDown": code = 33554432; break;
                case "RightThumbstickRight": code = 67108864; break;
                case "RightThumbstickLeft": code = 134217728; break;
                case "LeftThumbstickUp": code = 268435456; break;
                case "LeftThumbstickDown": code = 536870912; break;
                case "LeftThumbstickRight": code = 1073741824; break;
                default: throw new ArgumentOutOfRangeException(nameof(name));
            }

            return new(code, name);
        }

        public void SetDefaultKeyboardControls(bool reset)
        {
            if (reset || Left.Keyboard.Count <= 0)
            {
                Left.Keyboard.Clear();
                Left.AddKeyboard(Key("Left"));
            }

            if (reset || Right.Keyboard.Count <= 0)
            {
                Right.Keyboard.Clear();
                Right.AddKeyboard(Key("Right"));
            }

            if (reset || Down.Keyboard.Count <= 0)
            {
                Down.Keyboard.Clear();
                Down.AddKeyboard(Key("Down"));
            }

            if (reset || Up.Keyboard.Count <= 0)
            {
                Up.Keyboard.Clear();
                Up.AddKeyboard(Key("Up"));
            }

            if (reset || MenuLeft.Keyboard.Count <= 0)
            {
                MenuLeft.Keyboard.Clear();
                MenuLeft.AddKeyboard(Key("Left"));
            }

            if (reset || MenuRight.Keyboard.Count <= 0)
            {
                MenuRight.Keyboard.Clear();
                MenuRight.AddKeyboard(Key("Right"));
            }

            if (reset || MenuDown.Keyboard.Count <= 0)
            {
                MenuDown.Keyboard.Clear();
                MenuDown.AddKeyboard(Key("Down"));
            }

            if (reset || MenuUp.Keyboard.Count <= 0)
            {
                MenuUp.Keyboard.Clear();
                MenuUp.AddKeyboard(Key("Up"));
            }

            if (reset || Grab.Keyboard.Count <= 0)
            {
                Grab.Keyboard.Clear();
                Grab.AddKeyboard(Key("Z"), Key("V"), Key("LeftShift"));
            }

            if (reset || Jump.Keyboard.Count <= 0)
            {
                Jump.Keyboard.Clear();
                Jump.AddKeyboard(Key("C"));
            }

            if (reset || Dash.Keyboard.Count <= 0)
            {
                Dash.Keyboard.Clear();
                Dash.AddKeyboard(Key("X"));
            }

            if (reset || Talk.Keyboard.Count <= 0)
            {
                Talk.Keyboard.Clear();
                Talk.AddKeyboard(Key("X"));
            }

            if (reset || Pause.Keyboard.Count <= 0)
            {
                Pause.Keyboard.Clear();
                Pause.AddKeyboard(Key("Enter"));
            }

            if (reset || Confirm.Keyboard.Count <= 0)
            {
                Confirm.Keyboard.Clear();
                Confirm.AddKeyboard(Key("C"));
            }

            if (reset || Cancel.Keyboard.Count <= 0)
            {
                Cancel.Keyboard.Clear();
                Cancel.AddKeyboard(Key("X"), Key("Back"));
            }

            if (reset || Journal.Keyboard.Count <= 0)
            {
                Journal.Keyboard.Clear();
                Journal.AddKeyboard(Key("Tab"));
            }

            if (reset || QuickRestart.Keyboard.Count <= 0)
            {
                QuickRestart.Keyboard.Clear();
                QuickRestart.AddKeyboard(Key("R"));
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
                Left.AddController(Button("LeftThumbstickLeft"), Button("DPadLeft"));
            }

            if (reset || Right.Controller.Count <= 0)
            {
                Right.Controller.Clear();
                Right.AddController(Button("LeftThumbstickRight"), Button("DPadRight"));
            }

            if (reset || Down.Controller.Count <= 0)
            {
                Down.Controller.Clear();
                Down.AddController(Button("LeftThumbstickDown"), Button("DPadDown"));
            }

            if (reset || Up.Controller.Count <= 0)
            {
                Up.Controller.Clear();
                Up.AddController(Button("LeftThumbstickUp"), Button("DPadUp"));
            }

            if (reset || MenuLeft.Controller.Count <= 0)
            {
                MenuLeft.Controller.Clear();
                MenuLeft.AddController(Button("LeftThumbstickLeft"), Button("DPadLeft"));
            }

            if (reset || MenuRight.Controller.Count <= 0)
            {
                MenuRight.Controller.Clear();
                MenuRight.AddController(Button("LeftThumbstickRight"), Button("DPadRight"));
            }

            if (reset || MenuDown.Controller.Count <= 0)
            {
                MenuDown.Controller.Clear();
                MenuDown.AddController(Button("LeftThumbstickDown"), Button("DPadDown"));
            }

            if (reset || MenuUp.Controller.Count <= 0)
            {
                MenuUp.Controller.Clear();
                MenuUp.AddController(Button("LeftThumbstickUp"), Button("DPadUp"));
            }

            if (reset || Grab.Controller.Count <= 0)
            {
                Grab.Controller.Clear();
                Grab.AddController(Button("LeftTrigger"), Button("RightTrigger"), Button("LeftShoulder"),
                    Button("RightShoulder"));
            }

            if (reset || Jump.Controller.Count <= 0)
            {
                Jump.Controller.Clear();
                Jump.AddController(Button("A"), Button("Y"));
            }

            if (reset || Dash.Controller.Count <= 0)
            {
                Dash.Controller.Clear();
                Dash.AddController(Button("X"), Button("B"));
            }

            if (reset || Talk.Controller.Count <= 0)
            {
                Talk.Controller.Clear();
                Talk.AddController(Button("B"));
            }

            if (reset || Pause.Controller.Count <= 0)
            {
                Pause.Controller.Clear();
                Pause.AddController(Button("Start"));
            }

            if (reset || Confirm.Controller.Count <= 0)
            {
                Confirm.Controller.Clear();
                Confirm.AddController(Button("A"));
            }

            if (reset || Cancel.Controller.Count <= 0)
            {
                Cancel.Controller.Clear();
                Cancel.AddController(Button("B"), Button("X"));
            }

            if (reset || Journal.Controller.Count <= 0)
            {
                Journal.Controller.Clear();
                Journal.AddController(Button("LeftTrigger"));
            }

            if (reset || QuickRestart.Controller.Count <= 0) QuickRestart.Controller.Clear();

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
    }
}
