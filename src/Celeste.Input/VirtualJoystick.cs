using System.Numerics;

namespace Celeste.Input
{
    public class VirtualJoystick : VirtualInput
    {
        public IInputBinding Up;

        public IInputBinding Down;

        public IInputBinding Left;

        public IInputBinding Right;

        public IInputBinding UpAlt;

        public IInputBinding DownAlt;

        public IInputBinding LeftAlt;

        public IInputBinding RightAlt;

        public float Threshold;

        public int GamepadIndex;

        public OverlapBehaviors OverlapBehavior;

        public bool InvertedX;

        public bool InvertedY;

        private Vector2 value;

        private Vector2 previousValue;

        private bool hTurned;

        private bool vTurned;

        public Vector2 Value { get; private set; }

        public Vector2 PreviousValue { get; private set; }

        public VirtualJoystick(IInputBinding up, IInputBinding down, IInputBinding left, IInputBinding right,
            int gamepadIndex, float threshold, OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
            GamepadIndex = gamepadIndex;
            Threshold = threshold;
            OverlapBehavior = overlapBehavior;
        }

        public VirtualJoystick(IInputBinding up, IInputBinding upAlt, IInputBinding down, IInputBinding downAlt,
            IInputBinding left, IInputBinding leftAlt, IInputBinding right, IInputBinding rightAlt, int gamepadIndex,
            float threshold, OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
            UpAlt = upAlt;
            DownAlt = downAlt;
            LeftAlt = leftAlt;
            RightAlt = rightAlt;
            GamepadIndex = gamepadIndex;
            Threshold = threshold;
            OverlapBehavior = overlapBehavior;
        }

        public override void Update()
        {
            previousValue = value;
            if (!Context.Disabled)
            {
                Vector2 zero = value;
                float num = Right.Axis(GamepadIndex, 0f);
                float num2 = Left.Axis(GamepadIndex, 0f);
                float num3 = Down.Axis(GamepadIndex, 0f);
                float num4 = Up.Axis(GamepadIndex, 0f);
                if (num == 0f && RightAlt != null)
                {
                    num = RightAlt.Axis(GamepadIndex, 0f);
                }

                if (num2 == 0f && LeftAlt != null)
                {
                    num2 = LeftAlt.Axis(GamepadIndex, 0f);
                }

                if (num3 == 0f && DownAlt != null)
                {
                    num3 = DownAlt.Axis(GamepadIndex, 0f);
                }

                if (num4 == 0f && UpAlt != null)
                {
                    num4 = UpAlt.Axis(GamepadIndex, 0f);
                }

                if (num > num2)
                {
                    num2 = 0f;
                }
                else if (num2 > num)
                {
                    num = 0f;
                }

                if (num3 > num4)
                {
                    num4 = 0f;
                }
                else if (num4 > num3)
                {
                    num3 = 0f;
                }

                if (num != 0f && num2 != 0f)
                {
                    switch (OverlapBehavior)
                    {
                        case OverlapBehaviors.CancelOut:
                            zero.X = 0f;
                            break;
                        case OverlapBehaviors.TakeNewer:
                            if (!hTurned)
                            {
                                if (zero.X > 0f)
                                {
                                    zero.X = 0f - num2;
                                }
                                else if (zero.X < 0f)
                                {
                                    zero.X = num;
                                }

                                hTurned = true;
                            }
                            else if (zero.X > 0f)
                            {
                                zero.X = num;
                            }
                            else if (zero.X < 0f)
                            {
                                zero.X = 0f - num2;
                            }

                            break;
                        case OverlapBehaviors.TakeOlder:
                            if (zero.X > 0f)
                            {
                                zero.X = num;
                            }
                            else if (zero.X < 0f)
                            {
                                zero.X = num2;
                            }

                            break;
                    }
                }
                else if (num != 0f)
                {
                    hTurned = false;
                    zero.X = num;
                }
                else if (num2 != 0f)
                {
                    hTurned = false;
                    zero.X = 0f - num2;
                }
                else
                {
                    hTurned = false;
                    zero.X = 0f;
                }

                if (num3 != 0f && num4 != 0f)
                {
                    switch (OverlapBehavior)
                    {
                        case OverlapBehaviors.CancelOut:
                            zero.Y = 0f;
                            break;
                        case OverlapBehaviors.TakeNewer:
                            if (!vTurned)
                            {
                                if (zero.Y > 0f)
                                {
                                    zero.Y = 0f - num4;
                                }
                                else if (zero.Y < 0f)
                                {
                                    zero.Y = num3;
                                }

                                vTurned = true;
                            }
                            else if (zero.Y > 0f)
                            {
                                zero.Y = num3;
                            }
                            else if (zero.Y < 0f)
                            {
                                zero.Y = 0f - num4;
                            }

                            break;
                        case OverlapBehaviors.TakeOlder:
                            if (zero.Y > 0f)
                            {
                                zero.Y = num3;
                            }
                            else if (zero.Y < 0f)
                            {
                                zero.Y = 0f - num4;
                            }

                            break;
                    }
                }
                else if (num3 != 0f)
                {
                    vTurned = false;
                    zero.Y = num3;
                }
                else if (num4 != 0f)
                {
                    vTurned = false;
                    zero.Y = 0f - num4;
                }
                else
                {
                    vTurned = false;
                    zero.Y = 0f;
                }

                if ((float)System.Math.Sqrt((double)zero.X * zero.X + (double)zero.Y * zero.Y) < Threshold)
                {
                    zero = Vector2.Zero;
                }

                value = zero;
            }

            Value = new Vector2(InvertedX ? (value.X * -1f) : value.X, InvertedY ? (value.Y * -1f) : value.Y);
            PreviousValue = new Vector2(InvertedX ? (previousValue.X * -1f) : previousValue.X,
                InvertedY ? (previousValue.Y * -1f) : previousValue.Y);
        }

        public static implicit operator Vector2(VirtualJoystick joystick)
        {
            return joystick.Value;
        }
    }
}
