namespace Celeste.Input
{
    public class VirtualIntegerAxis : VirtualInput
    {
        public IInputBinding Positive;

        public IInputBinding Negative;

        public IInputBinding PositiveAlt;

        public IInputBinding NegativeAlt;

        public float Threshold;

        public int GamepadIndex;

        public OverlapBehaviors OverlapBehavior;

        public bool Inverted;

        public int Value;

        public int PreviousValue;

        private bool turned;

        public VirtualIntegerAxis()
        {
        }

        public VirtualIntegerAxis(IInputBinding negative, IInputBinding positive, int gamepadIndex, float threshold,
            OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer)
        {
            Positive = positive;
            Negative = negative;
            Threshold = threshold;
            GamepadIndex = gamepadIndex;
            OverlapBehavior = overlapBehavior;
        }

        public VirtualIntegerAxis(IInputBinding negative, IInputBinding negativeAlt, IInputBinding positive,
            IInputBinding positiveAlt, int gamepadIndex, float threshold,
            OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer)
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
            if (Context.Disabled)
            {
                return;
            }

            bool flag = Positive.Axis(GamepadIndex, Threshold) > 0f ||
                        (PositiveAlt != null && PositiveAlt.Axis(GamepadIndex, Threshold) > 0f);
            bool flag2 = Negative.Axis(GamepadIndex, Threshold) > 0f ||
                         (NegativeAlt != null && NegativeAlt.Axis(GamepadIndex, Threshold) > 0f);
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

        public static implicit operator float(VirtualIntegerAxis axis)
        {
            return axis.Value;
        }
    }
}
