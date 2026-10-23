using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using System.Numerics;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Input.Bindings
{
    public class SourceVirtualButton : SourceVirtualInput, Celeste.Core.Input.ISourceVirtualButton
    {
        float Celeste.Core.Input.ISourceVirtualButton.BufferTime
        {
            get => BufferTime;
            set => BufferTime = value;
        }

        public SourceInputBinding Binding;

        public float Threshold;

        public float BufferTime;

        public int GamepadIndex;

        public Keys? DebugOverridePressed;

        protected float firstRepeatTime;

        protected float multiRepeatTime;

        protected float bufferCounter;

        protected float repeatCounter;

        protected bool canRepeat;

        protected bool consumed;

        public bool Repeating { get; protected set; }

        public virtual bool Check
        {
            get
            {
                if (Process.Disabled)
                {
                    return false;
                }

                return Binding.Check(Process, GamepadIndex, Threshold);
            }
        }

        public virtual bool Pressed
        {
            get
            {
                if (DebugOverridePressed.HasValue && Process.Keyboard.Check(DebugOverridePressed.Value))
                {
                    return true;
                }

                if (Process.Disabled)
                {
                    return false;
                }

                if (consumed)
                {
                    return false;
                }

                if (bufferCounter > 0f || Repeating)
                {
                    return true;
                }

                return Binding.Pressed(Process, GamepadIndex, Threshold);
            }
        }

        public virtual bool Released
        {
            get
            {
                if (Process.Disabled)
                {
                    return false;
                }

                return Binding.Released(Process, GamepadIndex, Threshold);
            }
        }

        public SourceVirtualButton(SourceMInputProcess process, SourceInputBinding binding, int gamepadIndex,
            float bufferTime, float triggerThreshold) : base(process)
        {
            Binding = binding;
            GamepadIndex = gamepadIndex;
            BufferTime = bufferTime;
            Threshold = triggerThreshold;
        }

        public SourceVirtualButton(SourceMInputProcess process) : base(process)
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
            if (!canRepeat)
            {
                Repeating = false;
            }
        }

        public override void Update()
        {
            consumed = false;
            bufferCounter -= Process.Engine.DeltaTime;
            bool flag = false;
            if (Binding.Pressed(Process, GamepadIndex, Threshold))
            {
                bufferCounter = BufferTime;
                flag = true;
            }
            else if (Binding.Check(Process, GamepadIndex, Threshold))
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
                if (!canRepeat)
                {
                    return;
                }

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

        public void ConsumeBuffer()
        {
            bufferCounter = 0f;
        }

        public void ConsumePress()
        {
            bufferCounter = 0f;
            consumed = true;
        }

        public static implicit operator bool(SourceVirtualButton button)
        {
            return button.Check;
        }
    }
}
