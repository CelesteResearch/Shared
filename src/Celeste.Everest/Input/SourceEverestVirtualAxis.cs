using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;
using System.Collections.Generic;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Everest.Input
{
    public class SourceEverestVirtualAxis : SourceVirtualInput
    {
        public abstract class Node : SourceVirtualInputNode
        {
            protected Node(SourceMInputProcess process) : base(process)
            {
            }

            public abstract float Value { get; }
        }

        public class PadLeftStickX : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override float Value => SignThreshold(Process.GamePads[GamepadIndex].GetLeftStick().X, Deadzone);

            public PadLeftStickX(SourceMInputProcess process, int gamepadIndex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Deadzone = deadzone;
            }
        }

        public class PadLeftStickY : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override float Value => SignThreshold(Process.GamePads[GamepadIndex].GetLeftStick().Y, Deadzone);

            public PadLeftStickY(SourceMInputProcess process, int gamepadIndex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Deadzone = deadzone;
            }
        }

        public class PadRightStickX : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override float Value => SignThreshold(Process.GamePads[GamepadIndex].GetRightStick().X, Deadzone);

            public PadRightStickX(SourceMInputProcess process, int gamepadIndex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Deadzone = deadzone;
            }
        }

        public class PadRightStickY : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override float Value => SignThreshold(Process.GamePads[GamepadIndex].GetRightStick().Y, Deadzone);

            public PadRightStickY(SourceMInputProcess process, int gamepadIndex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Deadzone = deadzone;
            }
        }

        public class PadDpadLeftRight : Node
        {
            public int GamepadIndex;

            public override float Value
            {
                get
                {
                    if (Process.GamePads[GamepadIndex].DPadRightCheck)
                    {
                        return 1f;
                    }

                    if (Process.GamePads[GamepadIndex].DPadLeftCheck)
                    {
                        return -1f;
                    }

                    return 0f;
                }
            }

            public PadDpadLeftRight(SourceMInputProcess process, int gamepadIndex) : base(process)
            {
                GamepadIndex = gamepadIndex;
            }
        }

        public class PadDpadUpDown : Node
        {
            public int GamepadIndex;

            public override float Value
            {
                get
                {
                    if (Process.GamePads[GamepadIndex].DPadDownCheck)
                    {
                        return 1f;
                    }

                    if (Process.GamePads[GamepadIndex].DPadUpCheck)
                    {
                        return -1f;
                    }

                    return 0f;
                }
            }

            public PadDpadUpDown(SourceMInputProcess process, int gamepadIndex) : base(process)
            {
                GamepadIndex = gamepadIndex;
            }
        }

        public class KeyboardKeys : Node
        {
            public OverlapBehaviors OverlapBehavior;

            public Keys Positive;

            public Keys Negative;

            private float value;

            private bool turned;

            public override float Value => value;

            public KeyboardKeys(SourceMInputProcess process, OverlapBehaviors overlapBehavior, Keys negative,
                Keys positive) : base(process)
            {
                OverlapBehavior = overlapBehavior;
                Negative = negative;
                Positive = positive;
            }

            public override void Update()
            {
                if (Process.Keyboard.Check(Positive))
                {
                    if (Process.Keyboard.Check(Negative))
                    {
                        switch (OverlapBehavior)
                        {
                            default:
                                value = 0f;
                                break;
                            case OverlapBehaviors.TakeNewer:
                                if (!turned)
                                {
                                    value *= -1f;
                                    turned = true;
                                }

                                break;
                            case OverlapBehaviors.TakeOlder:
                                break;
                        }
                    }
                    else
                    {
                        turned = false;
                        value = 1f;
                    }
                }
                else if (Process.Keyboard.Check(Negative))
                {
                    turned = false;
                    value = -1f;
                }
                else
                {
                    turned = false;
                    value = 0f;
                }
            }
        }

        private static float SignThreshold(float value, float threshold)
        {
            if (Math.Abs(value) >= threshold) return Math.Sign(value);
            return 0f;
        }

        public List<Node> Nodes;

        public float Value { get; private set; }

        public float PreviousValue { get; private set; }

        public SourceEverestVirtualAxis(SourceMInputProcess process) : base(process)
        {
            Nodes = new List<Node>();
        }

        public SourceEverestVirtualAxis(SourceMInputProcess process, params Node[] nodes) : base(process)
        {
            Nodes = new List<Node>(nodes);
        }

        public override void Update()
        {
            foreach (Node node in Nodes)
            {
                node.Update();
            }

            PreviousValue = Value;
            Value = 0f;
            if (Process.Disabled)
            {
                return;
            }

            foreach (Node node2 in Nodes)
            {
                float value = node2.Value;
                if (value != 0f)
                {
                    Value = value;
                    break;
                }
            }
        }

        public static implicit operator float(SourceEverestVirtualAxis axis)
        {
            return axis.Value;
        }
    }
}
