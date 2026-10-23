using System.Numerics;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using ButtonState = Celeste.Input.Devices.GamePads.SourceButtonState;
using MathHelper = Celeste.Core.Mathematics.ScalarMath;
using GamePad = Celeste.Input.Devices.GamePads.SourceGamePadArithmetic;

namespace Celeste.Input.Devices.GamePads
{
    public struct SourceGamePadButtons
    {
        internal Buttons buttons;

        public ButtonState A
        {
            get
            {
                if ((buttons & Buttons.A) != Buttons.A)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState B
        {
            get
            {
                if ((buttons & Buttons.B) != Buttons.B)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState Back
        {
            get
            {
                if ((buttons & Buttons.Back) != Buttons.Back)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState X
        {
            get
            {
                if ((buttons & Buttons.X) != Buttons.X)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState Y
        {
            get
            {
                if ((buttons & Buttons.Y) != Buttons.Y)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState Start
        {
            get
            {
                if ((buttons & Buttons.Start) != Buttons.Start)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState LeftShoulder
        {
            get
            {
                if ((buttons & Buttons.LeftShoulder) != Buttons.LeftShoulder)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState LeftStick
        {
            get
            {
                if ((buttons & Buttons.LeftStick) != Buttons.LeftStick)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState RightShoulder
        {
            get
            {
                if ((buttons & Buttons.RightShoulder) != Buttons.RightShoulder)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState RightStick
        {
            get
            {
                if ((buttons & Buttons.RightStick) != Buttons.RightStick)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public ButtonState BigButton
        {
            get
            {
                if ((buttons & Buttons.BigButton) != Buttons.BigButton)
                {
                    return ButtonState.Released;
                }

                return ButtonState.Pressed;
            }
        }

        public SourceGamePadButtons(Buttons buttons)
        {
            this.buttons = buttons;
        }

        internal static SourceGamePadButtons FromButtonArray(params Buttons[] buttons)
        {
            Buttons buttons2 = (Buttons)0;
            foreach (Buttons buttons3 in buttons)
            {
                buttons2 |= buttons3;
            }

            return new SourceGamePadButtons(buttons2);
        }

        public static bool operator ==(SourceGamePadButtons left, SourceGamePadButtons right)
        {
            return left.buttons == right.buttons;
        }

        public static bool operator !=(SourceGamePadButtons left, SourceGamePadButtons right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is SourceGamePadButtons)
            {
                return this == (SourceGamePadButtons)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)buttons;
        }
    }
}
