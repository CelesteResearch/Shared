using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using System.Numerics;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Input.Bindings
{
    public class SourceVirtualIntegerAxis : SourceVirtualInput, Celeste.Core.Input.ISourceVirtualIntegerAxis
    {
        int Celeste.Core.Input.ISourceVirtualIntegerAxis.Value
        {
            get => Value;
            set => Value = value;
        }

        int Celeste.Core.Input.ISourceVirtualIntegerAxis.PreviousValue => PreviousValue;

        bool Celeste.Core.Input.ISourceVirtualIntegerAxis.Inverted
        {
            get => Inverted;
            set => Inverted = value;
        }

        public SourceInputBinding Positive;

        public SourceInputBinding Negative;

        public SourceInputBinding PositiveAlt;

        public SourceInputBinding NegativeAlt;

        public float Threshold;

        public int GamepadIndex;

        public OverlapBehaviors OverlapBehavior;

        public bool Inverted;

        public int Value;

        public int PreviousValue;

        private bool turned;

        public SourceVirtualIntegerAxis(SourceMInputProcess process) : base(process)
        {
        }

        public SourceVirtualIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding positive, int gamepadIndex, float threshold,
            OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer) : base(process)
        {
            Positive = positive;
            Negative = negative;
            Threshold = threshold;
            GamepadIndex = gamepadIndex;
            OverlapBehavior = overlapBehavior;
        }

        public SourceVirtualIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding negativeAlt, SourceInputBinding positive, SourceInputBinding positiveAlt,
            int gamepadIndex,
            float threshold, OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer) : base(process)
        {
            Positive = positive;
            Negative = negative;
            PositiveAlt = positiveAlt;
            NegativeAlt = negativeAlt;
            Threshold = threshold;
            GamepadIndex = gamepadIndex;
            OverlapBehavior = overlapBehavior;
        }

        public override void Update()
        {
            PreviousValue = Value;
            if (Process.Disabled)
            {
                return;
            }

            bool flag = Positive.Axis(Process, GamepadIndex, Threshold) > 0f ||
                        (PositiveAlt != null && PositiveAlt.Axis(Process, GamepadIndex, Threshold) > 0f);
            bool flag2 = Negative.Axis(Process, GamepadIndex, Threshold) > 0f ||
                         (NegativeAlt != null && NegativeAlt.Axis(Process, GamepadIndex, Threshold) > 0f);
            if (flag && flag2)
            {
                switch (OverlapBehavior)
                {
                    case OverlapBehaviors.CancelOut:
                        Value = 0;
                        break;
                    case OverlapBehaviors.TakeNewer:
                        if (!turned)
                        {
                            Value *= -1;
                            turned = true;
                        }

                        break;
                    case OverlapBehaviors.TakeOlder:
                        Value = PreviousValue;
                        break;
                }
            }
            else if (flag)
            {
                turned = false;
                Value = 1;
            }
            else if (flag2)
            {
                turned = false;
                Value = -1;
            }
            else
            {
                turned = false;
                Value = 0;
            }

            if (Inverted)
            {
                Value = -Value;
            }
        }

        public static implicit operator float(SourceVirtualIntegerAxis axis)
        {
            return axis.Value;
        }
    }
}
