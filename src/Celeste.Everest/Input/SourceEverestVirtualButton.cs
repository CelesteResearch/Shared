using System.Collections.Generic;
using Celeste.Input.Bindings;
using Celeste.Input.Runtime;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Everest.Input
{
    public class SourceEverestVirtualButton : SourceVirtualButton
    {
        public abstract class Node : SourceVirtualInputNode
        {
            protected Node(SourceMInputProcess process) : base(process)
            {
            }

            public abstract bool Check { get; }

            public abstract bool Pressed { get; }

            public abstract bool Released { get; }

            public virtual bool Bufferable { get; set; }
        }

        public class KeyboardKey : Node
        {
            public Keys Key;

            public override bool Check => Process.Keyboard.Check(Key);

            public override bool Pressed => Process.Keyboard.Pressed(Key);

            public override bool Released => Process.Keyboard.Released(Key);

            public KeyboardKey(SourceMInputProcess process, Keys key) : base(process)
            {
                Key = key;
            }
        }

        public class PadButton : Node
        {
            public int GamepadIndex;

            public Buttons Button;

            public override bool Check => Process.GamePads[GamepadIndex].Check(Button);

            public override bool Pressed => Process.GamePads[GamepadIndex].Pressed(Button);

            public override bool Released => Process.GamePads[GamepadIndex].Released(Button);

            public PadButton(SourceMInputProcess process, int gamepadIndex, Buttons button) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Button = button;
            }
        }

        public class PadLeftStickRight : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].LeftStickRightCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].LeftStickRightPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].LeftStickRightReleased(Deadzone);

            public PadLeftStickRight(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadLeftStickLeft : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].LeftStickLeftCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].LeftStickLeftPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].LeftStickLeftReleased(Deadzone);

            public PadLeftStickLeft(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadLeftStickUp : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].LeftStickUpCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].LeftStickUpPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].LeftStickUpReleased(Deadzone);

            public PadLeftStickUp(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadLeftStickDown : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].LeftStickDownCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].LeftStickDownPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].LeftStickDownReleased(Deadzone);

            public PadLeftStickDown(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadRightStickRight : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].RightStickRightCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].RightStickRightPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].RightStickRightReleased(Deadzone);

            public PadRightStickRight(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadRightStickLeft : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].RightStickLeftCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].RightStickLeftPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].RightStickLeftReleased(Deadzone);

            public PadRightStickLeft(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadRightStickUp : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].RightStickUpCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].RightStickUpPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].RightStickUpReleased(Deadzone);

            public PadRightStickUp(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadRightStickDown : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override bool Check => Process.GamePads[GamepadIndex].RightStickDownCheck(Deadzone);

            public override bool Pressed => Process.GamePads[GamepadIndex].RightStickDownPressed(Deadzone);

            public override bool Released => Process.GamePads[GamepadIndex].RightStickDownReleased(Deadzone);

            public PadRightStickDown(SourceMInputProcess process, int gamepadindex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadindex;
                Deadzone = deadzone;
            }
        }

        public class PadLeftTrigger : Node
        {
            public int GamepadIndex;

            public float Threshold;

            public override bool Check => Process.GamePads[GamepadIndex].LeftTriggerCheck(Threshold);

            public override bool Pressed => Process.GamePads[GamepadIndex].LeftTriggerPressed(Threshold);

            public override bool Released => Process.GamePads[GamepadIndex].LeftTriggerReleased(Threshold);

            public PadLeftTrigger(SourceMInputProcess process, int gamepadIndex, float threshold) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Threshold = threshold;
            }
        }

        public class PadRightTrigger : Node
        {
            public int GamepadIndex;

            public float Threshold;

            public override bool Check => Process.GamePads[GamepadIndex].RightTriggerCheck(Threshold);

            public override bool Pressed => Process.GamePads[GamepadIndex].RightTriggerPressed(Threshold);

            public override bool Released => Process.GamePads[GamepadIndex].RightTriggerReleased(Threshold);

            public PadRightTrigger(SourceMInputProcess process, int gamepadIndex, float threshold) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Threshold = threshold;
            }
        }

        public class PadDPadRight : Node
        {
            public int GamepadIndex;

            public override bool Check => Process.GamePads[GamepadIndex].DPadRightCheck;

            public override bool Pressed => Process.GamePads[GamepadIndex].DPadRightPressed;

            public override bool Released => Process.GamePads[GamepadIndex].DPadRightReleased;

            public PadDPadRight(SourceMInputProcess process, int gamepadIndex) : base(process)
            {
                GamepadIndex = gamepadIndex;
            }
        }

        public class PadDPadLeft : Node
        {
            public int GamepadIndex;

            public override bool Check => Process.GamePads[GamepadIndex].DPadLeftCheck;

            public override bool Pressed => Process.GamePads[GamepadIndex].DPadLeftPressed;

            public override bool Released => Process.GamePads[GamepadIndex].DPadLeftReleased;

            public PadDPadLeft(SourceMInputProcess process, int gamepadIndex) : base(process)
            {
                GamepadIndex = gamepadIndex;
            }
        }

        public class PadDPadUp : Node
        {
            public int GamepadIndex;

            public override bool Check => Process.GamePads[GamepadIndex].DPadUpCheck;

            public override bool Pressed => Process.GamePads[GamepadIndex].DPadUpPressed;

            public override bool Released => Process.GamePads[GamepadIndex].DPadUpReleased;

            public PadDPadUp(SourceMInputProcess process, int gamepadIndex) : base(process)
            {
                GamepadIndex = gamepadIndex;
            }
        }

        public class PadDPadDown : Node
        {
            public int GamepadIndex;

            public override bool Check => Process.GamePads[GamepadIndex].DPadDownCheck;

            public override bool Pressed => Process.GamePads[GamepadIndex].DPadDownPressed;

            public override bool Released => Process.GamePads[GamepadIndex].DPadDownReleased;

            public PadDPadDown(SourceMInputProcess process, int gamepadIndex) : base(process)
            {
                GamepadIndex = gamepadIndex;
            }
        }

        public class MouseLeftButton : Node
        {
            public MouseLeftButton(SourceMInputProcess process) : base(process)
            {
            }

            public override bool Check => Process.Mouse.CheckLeftButton;

            public override bool Pressed => Process.Mouse.PressedLeftButton;

            public override bool Released => Process.Mouse.ReleasedLeftButton;
        }

        public class MouseRightButton : Node
        {
            public MouseRightButton(SourceMInputProcess process) : base(process)
            {
            }

            public override bool Check => Process.Mouse.CheckRightButton;

            public override bool Pressed => Process.Mouse.PressedRightButton;

            public override bool Released => Process.Mouse.ReleasedRightButton;
        }

        public class MouseMiddleButton : Node
        {
            public MouseMiddleButton(SourceMInputProcess process) : base(process)
            {
            }

            public override bool Check => Process.Mouse.CheckMiddleButton;

            public override bool Pressed => Process.Mouse.PressedMiddleButton;

            public override bool Released => Process.Mouse.ReleasedMiddleButton;
        }

        public class VirtualAxisTrigger : Node
        {
            public enum Modes
            {
                LargerThan,
                LessThan,
                Equals,
            }

            public ThresholdModes Mode;

            public float Threshold;

            private readonly SourceEverestVirtualAxis axis;

            public override bool Check
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan) return axis.Value >= Threshold;

                    if (Mode == ThresholdModes.LessThan) return axis.Value <= Threshold;

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    return axis.Value == Threshold;
                }
            }

            public override bool Pressed
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (axis.Value >= Threshold) return axis.PreviousValue < Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (axis.Value <= Threshold) return axis.PreviousValue > Threshold;

                        return false;
                    }

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (axis.Value == Threshold)
                        return /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                            axis.PreviousValue != Threshold;

                    return false;
                }
            }

            public override bool Released
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (axis.Value < Threshold) return axis.PreviousValue >= Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (axis.Value > Threshold) return axis.PreviousValue <= Threshold;

                        return false;
                    }

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (axis.Value != Threshold)
                        return /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                            axis.PreviousValue == Threshold;

                    return false;
                }
            }

            public VirtualAxisTrigger(SourceMInputProcess process, SourceEverestVirtualAxis axis, ThresholdModes mode,
                float threshold) : base(process)
            {
                this.axis = axis;
                Mode = mode;
                Threshold = threshold;
            }
        }

        public class VirtualIntegerAxisTrigger : Node
        {
            public enum Modes
            {
                LargerThan,
                LessThan,
                Equals,
            }

            public ThresholdModes Mode;

            public int Threshold;

            private readonly SourceVirtualIntegerAxis axis;

            public override bool Check
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan) return axis.Value >= Threshold;

                    if (Mode == ThresholdModes.LessThan) return axis.Value <= Threshold;

                    return axis.Value == Threshold;
                }
            }

            public override bool Pressed
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (axis.Value >= Threshold) return axis.PreviousValue < Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (axis.Value <= Threshold) return axis.PreviousValue > Threshold;

                        return false;
                    }

                    if (axis.Value == Threshold) return axis.PreviousValue != Threshold;

                    return false;
                }
            }

            public override bool Released
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (axis.Value < Threshold) return axis.PreviousValue >= Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (axis.Value > Threshold) return axis.PreviousValue <= Threshold;

                        return false;
                    }

                    if (axis.Value != Threshold) return axis.PreviousValue == Threshold;

                    return false;
                }
            }

            public VirtualIntegerAxisTrigger(SourceMInputProcess process, SourceVirtualIntegerAxis axis,
                ThresholdModes mode, int threshold) : base(process)
            {
                this.axis = axis;
                Mode = mode;
                Threshold = threshold;
            }
        }

        public class VirtualJoystickXTrigger : Node
        {
            public enum Modes
            {
                LargerThan,
                LessThan,
                Equals,
            }

            public ThresholdModes Mode;

            public float Threshold;

            private readonly SourceVirtualJoystick joystick;

            public override bool Check
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan) return joystick.Value.X >= Threshold;

                    if (Mode == ThresholdModes.LessThan) return joystick.Value.X <= Threshold;

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    return joystick.Value.X == Threshold;
                }
            }

            public override bool Pressed
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (joystick.Value.X >= Threshold) return joystick.PreviousValue.X < Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (joystick.Value.X <= Threshold) return joystick.PreviousValue.X > Threshold;

                        return false;
                    }

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (joystick.Value.X == Threshold)
                        return /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                            joystick.PreviousValue.X != Threshold;

                    return false;
                }
            }

            public override bool Released
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (joystick.Value.X < Threshold) return joystick.PreviousValue.X >= Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (joystick.Value.X > Threshold) return joystick.PreviousValue.X <= Threshold;

                        return false;
                    }

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (joystick.Value.X != Threshold)
                        return /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                            joystick.PreviousValue.X == Threshold;

                    return false;
                }
            }

            public VirtualJoystickXTrigger(SourceMInputProcess process, SourceVirtualJoystick joystick,
                ThresholdModes mode,
                float threshold) : base(process)
            {
                this.joystick = joystick;
                Mode = mode;
                Threshold = threshold;
            }
        }

        public class VirtualJoystickYTrigger : Node
        {
            public ThresholdModes Mode;

            public float Threshold;

            private readonly SourceVirtualJoystick joystick;

            public override bool Check
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan) return joystick.Value.X >= Threshold;

                    if (Mode == ThresholdModes.LessThan) return joystick.Value.X <= Threshold;

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    return joystick.Value.X == Threshold;
                }
            }

            public override bool Pressed
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (joystick.Value.X >= Threshold) return joystick.PreviousValue.X < Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (joystick.Value.X <= Threshold) return joystick.PreviousValue.X > Threshold;

                        return false;
                    }

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (joystick.Value.X == Threshold)
                        return /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                            joystick.PreviousValue.X != Threshold;

                    return false;
                }
            }

            public override bool Released
            {
                get
                {
                    if (Mode == ThresholdModes.LargerThan)
                    {
                        if (joystick.Value.X < Threshold) return joystick.PreviousValue.X >= Threshold;

                        return false;
                    }

                    if (Mode == ThresholdModes.LessThan)
                    {
                        if (joystick.Value.X > Threshold) return joystick.PreviousValue.X <= Threshold;

                        return false;
                    }

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (joystick.Value.X != Threshold)
                        return /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                            joystick.PreviousValue.X == Threshold;

                    return false;
                }
            }

            public VirtualJoystickYTrigger(SourceMInputProcess process, SourceVirtualJoystick joystick,
                ThresholdModes mode,
                float threshold) : base(process)
            {
                this.joystick = joystick;
                Mode = mode;
                Threshold = threshold;
            }
        }


        public List<Node> Nodes;
        public bool AutoConsumeBuffer;

        public SourceEverestVirtualButton(SourceMInputProcess process, SourceInputBinding binding, int gamepadIndex,
            float bufferTime, float triggerThreshold) : base(process, binding, gamepadIndex, bufferTime,
            triggerThreshold)
        {
            Nodes = [];
        }

        public SourceEverestVirtualButton(SourceMInputProcess process, SourceInputBinding binding) : base(process)
        {
            Binding = Binding ?? binding;
            Nodes = [];
        }

        public SourceEverestVirtualButton(SourceMInputProcess process) : base(process)
        {
            Binding = Binding ?? new InstalledSourceInputBinding();
            Nodes = [];
        }

        public SourceEverestVirtualButton(SourceMInputProcess process, float bufferTime)
            : this(process, new InstalledSourceInputBinding(), 0, bufferTime, 0f)
        {
        }

        public SourceEverestVirtualButton(SourceMInputProcess process, float bufferTime, params Node[] nodes)
            : this(process, new InstalledSourceInputBinding(), 0, bufferTime, 0f)
        {
            Nodes.AddRange(nodes);
        }

        public SourceEverestVirtualButton(SourceMInputProcess process, params Node[] nodes)
            : this(process, new InstalledSourceInputBinding(), 0, 0f, 0f)
        {
            Nodes.AddRange(nodes);
        }

        public override bool Check
        {
            get
            {
                if (Process.Disabled) return false;

                if (Binding.Check(Process, GamepadIndex, Threshold)) return true;

                foreach (var node in Nodes)
                    if (node.Check)
                        return true;

                return false;
            }
        }

        public override bool Pressed
        {
            get
            {
                if (DebugOverridePressed.HasValue && Process.Keyboard.Check(DebugOverridePressed.Value)) return true;

                if (Process.Disabled) return false;

                if (consumed) return false;

                if (bufferCounter > 0f || Repeating)
                {
                    if (AutoConsumeBuffer) bufferCounter = 0f;

                    return true;
                }

                if (Binding.Pressed(Process, GamepadIndex, Threshold))
                {
                    if (AutoConsumeBuffer) bufferCounter = 0f;

                    return true;
                }

                foreach (var node in Nodes)
                    if (node.Pressed)
                    {
                        if (AutoConsumeBuffer) bufferCounter = 0f;

                        return true;
                    }

                return false;
            }
        }

        public override bool Released
        {
            get
            {
                if (Process.Disabled) return false;

                if (Binding.Released(Process, GamepadIndex, Threshold)) return true;

                foreach (var node in Nodes)
                    if (node.Released)
                        return true;

                return false;
            }
        }

        public override void Update()
        {
            consumed = false;
            bufferCounter -= Process.Engine.DeltaTime;
            var flag = false;
            if (Binding.Pressed(Process, GamepadIndex, Threshold))
            {
                bufferCounter = BufferTime;
                flag = true;
            }
            else if (Binding.Check(Process, GamepadIndex, Threshold))
            {
                flag = true;
            }

            foreach (var node in Nodes)
            {
                node.Update();
                if (node.Pressed)
                {
                    if (node.Bufferable) bufferCounter = BufferTime;

                    flag = true;
                }
                else if (node.Check)
                {
                    flag = true;
                }
            }

            if (!flag)
            {
                Repeating = false;
                repeatCounter = 0f;
                bufferCounter = 0f;
            }
            else
            {
                if (!canRepeat) return;

                Repeating = false;
                if (repeatCounter == 0f)
                {
                    repeatCounter = firstRepeatTime;
                    return;
                }

                repeatCounter -= Process.Engine.DeltaTime;
                if (repeatCounter <= 0f)
                {
                    Repeating = true;
                    repeatCounter = multiRepeatTime;
                }
            }
        }
    }
}
