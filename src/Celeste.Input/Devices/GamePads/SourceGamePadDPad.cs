using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using ButtonState = Celeste.Input.Devices.GamePads.SourceButtonState;

namespace Celeste.Input.Devices.GamePads
{
    public struct SourceGamePadDPad
    {
        public ButtonState Down { get; internal set; }

        public ButtonState Left { get; internal set; }

        public ButtonState Right { get; internal set; }

        public ButtonState Up { get; internal set; }

        public SourceGamePadDPad(ButtonState upValue, ButtonState downValue, ButtonState leftValue,
            ButtonState rightValue)
        {
            this = default;
            Up = upValue;
            Down = downValue;
            Left = leftValue;
            Right = rightValue;
        }

        internal static SourceGamePadDPad FromButtonArray(params Buttons[] buttons)
        {
            var upValue = ButtonState.Released;
            var downValue = ButtonState.Released;
            var leftValue = ButtonState.Released;
            var rightValue = ButtonState.Released;
            foreach (var num in buttons)
            {
                if ((num & Buttons.DPadUp) == Buttons.DPadUp) upValue = ButtonState.Pressed;

                if ((num & Buttons.DPadDown) == Buttons.DPadDown) downValue = ButtonState.Pressed;

                if ((num & Buttons.DPadLeft) == Buttons.DPadLeft) leftValue = ButtonState.Pressed;

                if ((num & Buttons.DPadRight) == Buttons.DPadRight) rightValue = ButtonState.Pressed;
            }

            return new(upValue, downValue, leftValue, rightValue);
        }

        public static bool operator ==(SourceGamePadDPad left, SourceGamePadDPad right)
        {
            if (left.Down == right.Down && left.Left == right.Left && left.Right == right.Right)
                return left.Up == right.Up;

            return false;
        }

        public static bool operator !=(SourceGamePadDPad left, SourceGamePadDPad right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is SourceGamePadDPad) return this == (SourceGamePadDPad)obj;

            return false;
        }

        public override int GetHashCode()
        {
            return (Down == ButtonState.Pressed ? 1 : 0) + (Left == ButtonState.Pressed ? 2 : 0) +
                   (Right == ButtonState.Pressed ? 4 : 0) + (Up == ButtonState.Pressed ? 8 : 0);
        }
    }
}
