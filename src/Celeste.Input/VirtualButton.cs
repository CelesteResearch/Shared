using System;

namespace Celeste.Input
{
    public class VirtualButton : VirtualInput
    {
        public IInputBinding Binding;

        public float Threshold;

        public float BufferTime;

        public int GamepadIndex;

        public Func<bool> DebugOverridePressed;

        // Everest's ButtonBinding virtual buttons consume a buffered press when read.
        // Vanilla buttons retain the original false default.
        public bool AutoConsumeBuffer;

        private float firstRepeatTime;

        private float multiRepeatTime;

        private float bufferCounter;

        private float repeatCounter;

        private bool canRepeat;

        private bool consumed;

        public bool Repeating { get; private set; }

        public bool Check
        {
            get
            {
                if (Context.Disabled) return false;

                return Binding.Check(GamepadIndex, Threshold);
            }
        }

        public bool Pressed
        {
            get
            {
                if (!Context.Disabled && DebugOverridePressed != null && DebugOverridePressed()) return true;

                if (Context.Disabled) return false;

                if (consumed) return false;

                if (bufferCounter > 0f || Repeating)
                {
                    if (AutoConsumeBuffer) bufferCounter = 0f;
                    return true;
                }

                if (!Binding.Pressed(GamepadIndex, Threshold)) return false;
                if (AutoConsumeBuffer) bufferCounter = 0f;
                return true;
            }
        }

        public bool Released
        {
            get
            {
                if (Context.Disabled) return false;

                return Binding.Released(GamepadIndex, Threshold);
            }
        }

        public VirtualButton(IInputBinding binding, int gamepadIndex, float bufferTime, float triggerThreshold)
        {
            Binding = binding;
            GamepadIndex = gamepadIndex;
            BufferTime = bufferTime;
            Threshold = triggerThreshold;
        }

        public VirtualButton()
        {
        }

        public void SetRepeat(float repeatTime)
        {
            SetRepeat(repeatTime, repeatTime);
        }

        public void SetRepeat(float firstRepeatTime, float multiRepeatTime)
        {
            this.firstRepeatTime = firstRepeatTime;
            this.multiRepeatTime = multiRepeatTime;
            canRepeat = this.firstRepeatTime > 0f;
            if (!canRepeat) Repeating = false;
        }

        public override void Update()
        {
            consumed = false;
            bufferCounter -= Context.DeltaTime;
            var flag = false;
            if (!Context.Disabled && Binding.Pressed(GamepadIndex, Threshold))
            {
                bufferCounter = BufferTime;
                flag = true;
            }
            else if (!Context.Disabled && Binding.Check(GamepadIndex, Threshold))
            {
                flag = true;
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

                repeatCounter -= Context.DeltaTime;
                if (repeatCounter <= 0f)
                {
                    Repeating = true;
                    repeatCounter = multiRepeatTime;
                }
            }
        }

        public void ConsumeBuffer()
        {
            bufferCounter = 0f;
        }

        public void ConsumePress()
        {
            bufferCounter = 0f;
            consumed = true;
        }

        public static implicit operator bool(VirtualButton button)
        {
            return button.Check;
        }
    }
}
