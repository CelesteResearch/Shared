using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Input.Bindings;
using Celeste.Input.Runtime;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;

namespace Celeste.Everest.Input
{
    public class SourceEverestVirtualJoystick : SourceVirtualJoystick
    {
        public abstract class Node : SourceVirtualInputNode
        {
            protected Node(SourceMInputProcess process) : base(process)
            {
            }

            public abstract Vector2 Value { get; }
        }

        public class PadLeftStick : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override Vector2 Value => Process.GamePads[GamepadIndex].GetLeftStick(Deadzone);

            public PadLeftStick(SourceMInputProcess process, int gamepadIndex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Deadzone = deadzone;
            }
        }

        public class PadRightStick : Node
        {
            public int GamepadIndex;

            public float Deadzone;

            public override Vector2 Value => Process.GamePads[GamepadIndex].GetRightStick(Deadzone);

            public PadRightStick(SourceMInputProcess process, int gamepadIndex, float deadzone) : base(process)
            {
                GamepadIndex = gamepadIndex;
                Deadzone = deadzone;
            }
        }

        public class PadDpad : Node
        {
            public int GamepadIndex;

            public override Vector2 Value
            {
                get
                {
                    var result = default(Vector2);
                    if (Process.GamePads[GamepadIndex].DPadRightCheck)
                        result.X = 1f;
                    else if (Process.GamePads[GamepadIndex].DPadLeftCheck) result.X = -1f;

                    if (Process.GamePads[GamepadIndex].DPadDownCheck)
                        result.Y = 1f;
                    else if (Process.GamePads[GamepadIndex].DPadUpCheck) result.Y = -1f;

                    return result;
                }
            }

            public PadDpad(SourceMInputProcess process, int gamepadIndex) : base(process)
            {
                GamepadIndex = gamepadIndex;
            }
        }

        public class KeyboardKeys : Node
        {
            public OverlapBehaviors OverlapBehavior;

            public Keys Left;

            public Keys Right;

            public Keys Up;

            public Keys Down;

            private bool turnedX;

            private bool turnedY;

            private Vector2 value;

            public override Vector2 Value => value;

            public KeyboardKeys(SourceMInputProcess process, OverlapBehaviors overlapBehavior, Keys left, Keys right,
                Keys up, Keys down) : base(process)
            {
                OverlapBehavior = overlapBehavior;
                Left = left;
                Right = right;
                Up = up;
                Down = down;
            }

            public override void Update()
            {
                if (Process.Keyboard.Check(Left))
                {
                    if (Process.Keyboard.Check(Right))
                    {
                        switch (OverlapBehavior)
                        {
                            default:
                                value.X = 0f;
                                break;
                            case OverlapBehaviors.TakeNewer:
                                if (!turnedX)
                                {
                                    value.X *= -1f;
                                    turnedX = true;
                                }

                                break;
                            case OverlapBehaviors.TakeOlder:
                                break;
                        }
                    }
                    else
                    {
                        turnedX = false;
                        value.X = -1f;
                    }
                }
                else if (Process.Keyboard.Check(Right))
                {
                    turnedX = false;
                    value.X = 1f;
                }
                else
                {
                    turnedX = false;
                    value.X = 0f;
                }

                if (Process.Keyboard.Check(Up))
                {
                    if (Process.Keyboard.Check(Down))
                    {
                        switch (OverlapBehavior)
                        {
                            default:
                                value.Y = 0f;
                                break;
                            case OverlapBehaviors.TakeNewer:
                                if (!turnedY)
                                {
                                    value.Y *= -1f;
                                    turnedY = true;
                                }

                                break;
                            case OverlapBehaviors.TakeOlder:
                                break;
                        }
                    }
                    else
                    {
                        turnedY = false;
                        value.Y = -1f;
                    }
                }
                else if (Process.Keyboard.Check(Down))
                {
                    turnedY = false;
                    value.Y = 1f;
                }
                else
                {
                    turnedY = false;
                    value.Y = 0f;
                }
            }
        }


        public List<Node> Nodes;
        public bool Normalized;
        public float? SnapSlices;

        public SourceEverestVirtualJoystick(SourceMInputProcess process, SourceInputBinding up, SourceInputBinding down,
            SourceInputBinding left, SourceInputBinding right, int gamepadIndex, float threshold,
            OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer) : base(process, up, down, left, right,
            gamepadIndex, threshold, overlapBehavior)
        {
            Nodes = [];
        }

        public SourceEverestVirtualJoystick(SourceMInputProcess process, SourceInputBinding up,
            SourceInputBinding upAlt,
            SourceInputBinding down, SourceInputBinding downAlt, SourceInputBinding left, SourceInputBinding leftAlt,
            SourceInputBinding right, SourceInputBinding rightAlt, int gamepadIndex, float threshold,
            OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer) : base(process, up, upAlt, down, downAlt,
            left,
            leftAlt, right, rightAlt, gamepadIndex, threshold, overlapBehavior)
        {
            Nodes = [];
        }

        private Vector2 Snapped(Vector2 vector, float slices, bool normalized)
        {
            var num = (float)Math.PI * 2f / slices;
            var angle = (float)Math.Floor(((float)Math.Atan2(vector.Y, vector.X) + num / 2f) / num) * num;
            var length = normalized ? 1f : Process.Engine.VectorArithmetic.Length(vector);
            return new((float)Math.Cos(angle) * length, (float)Math.Sin(angle) * length);
        }

        public override void Update()
        {
            foreach (var node in Nodes) node.Update();

            base.Update();
            if (Process.Disabled) return;

            foreach (var node2 in Nodes)
            {
                var vector = node2.Value;
                if (!(vector != default)) continue;

                if (Normalized)
                {
                    if (SnapSlices.HasValue)
                        vector = Snapped(vector, SnapSlices.Value, true);
                    else
                        vector = Process.Engine.VectorArithmetic.Normalize(vector);
                }
                else if (SnapSlices.HasValue)
                {
                    vector = Snapped(vector, SnapSlices.Value, false);
                }

                if (InvertedX) vector.X *= -1f;

                if (InvertedY) vector.Y *= -1f;

                Value = vector;
                break;
            }
        }
    }
}
