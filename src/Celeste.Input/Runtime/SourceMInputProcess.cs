using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;
using System.Collections.Generic;

namespace Celeste.Input.Runtime
{
    public sealed class SourceMInputProcess : ISourceKeyboardDisabledEnvironment
    {
        private readonly ISourceMInputEngine engine;
        public ISourceMInputEngine Engine => engine;
        private readonly SourceFnaKeyboardStateProcess physicalKeyboard;
        private readonly SourceFnaMouse mouse;
        public SourceFnaMouse PhysicalMouse => mouse;
        private readonly SourceFnaGamePadProcess gamepads;
        private readonly ISourceMInputKeyboardConstruction keyboardConstruction;
        private readonly ISourceMInputMouseConstruction mouseConstruction;
        public readonly ISourceVirtualInputPolicy VirtualInputPolicy;
        bool ISourceKeyboardDisabledEnvironment.Disabled => Disabled;

        public SourceMInputProcess(ISourceMInputEngine engine, SourceFnaKeyboardStateProcess physicalKeyboard,
            SourceFnaMouse mouse, SourceFnaGamePadProcess gamepads,
            ISourceMInputKeyboardConstruction keyboardConstruction,
            ISourceVirtualInputPolicy virtualInputPolicy, ISourceMInputMouseConstruction mouseConstruction)
        {
            this.engine = engine;
            this.physicalKeyboard = physicalKeyboard;
            this.mouse = mouse;
            this.gamepads = gamepads;
            this.keyboardConstruction = keyboardConstruction;
            this.mouseConstruction = mouseConstruction;
            VirtualInputPolicy = virtualInputPolicy;
        }

        internal List<SourceVirtualInput> VirtualInputs;
        public List<SourceVirtualInput> GetVirtualInputsForSynchronization() => VirtualInputs;

        public bool Active = true;

        public bool Disabled = false;

        public bool ControllerHasFocus = false;

        public bool IsControllerFocused = false;

        public SourceKeyboardData Keyboard { get; private set; }

        public SourceMouseData Mouse { get; private set; }

        public SourceGamePadData[] GamePads { get; private set; }

        public void Initialize()
        {
            Keyboard = keyboardConstruction.CreateKeyboard(physicalKeyboard, this);
            Mouse = mouseConstruction.CreateMouse(mouse, this);
            GamePads = new SourceGamePadData[4];
            for (int i = 0; i < 4; i++)
            {
                GamePads[i] = new SourceGamePadData(i, gamepads, this);
            }

            VirtualInputs = new List<SourceVirtualInput>();
        }

        public void Shutdown()
        {
            SourceGamePadData[] gamePads = GamePads;
            for (int i = 0; i < gamePads.Length; i++)
            {
                gamePads[i].StopRumble();
            }
        }

        public void Update()
        {
            if (engine.IsActive && Active)
            {
                if (engine.IsCommandConsoleOpen)
                {
                    Keyboard.UpdateNull();
                    Mouse.UpdateNull();
                }
                else
                {
                    Keyboard.Update();
                    Mouse.Update();
                }

                bool flag = false;
                bool flag2 = false;
                for (int i = 0; i < 4; i++)
                {
                    GamePads[i].Update();
                    if (GamePads[i].HasAnyInput())
                    {
                        ControllerHasFocus = true;
                        flag = true;
                    }

                    if (GamePads[i].Attached)
                    {
                        flag2 = true;
                    }
                }

                if (!flag2 || (!flag && Keyboard.HasAnyInput()))
                {
                    ControllerHasFocus = false;
                }
            }
            else
            {
                Keyboard.UpdateNull();
                Mouse.UpdateNull();
                for (int j = 0; j < 4; j++)
                {
                    GamePads[j].UpdateNull();
                }
            }

            UpdateVirtualInputs();
        }

        public void UpdateNull()
        {
            Keyboard.UpdateNull();
            Mouse.UpdateNull();
            for (int i = 0; i < 4; i++)
            {
                GamePads[i].UpdateNull();
            }

            UpdateVirtualInputs();
        }

        public void UpdateVirtualInputs() => VirtualInputPolicy.Update(this);

        public void RegisterVirtualInputCore(SourceVirtualInput input) => VirtualInputs.Add(input);
        public void DeregisterVirtualInputCore(SourceVirtualInput input) => VirtualInputs.Remove(input);

        public void UpdateVirtualInputsCore()
        {
            foreach (SourceVirtualInput virtualInput in VirtualInputs)
            {
                virtualInput.Update();
            }
        }

        public void RumbleFirst(float strength, float time)
        {
            GamePads[0].Rumble(strength, time);
        }

        public int Axis(bool negative, bool positive, int bothValue)
        {
            if (negative)
            {
                if (positive)
                {
                    return bothValue;
                }

                return -1;
            }

            if (positive)
            {
                return 1;
            }

            return 0;
        }

        public int Axis(float axisValue, float deadzone)
        {
            if (Math.Abs(axisValue) >= deadzone)
            {
                return Math.Sign(axisValue);
            }

            return 0;
        }

        public int Axis(bool negative, bool positive, int bothValue, float axisValue, float deadzone)
        {
            int num = Axis(axisValue, deadzone);
            if (num == 0)
            {
                num = Axis(negative, positive, bothValue);
            }

            return num;
        }
    }
}
