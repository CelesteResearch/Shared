using Celeste.Input.Devices.GamePads;
using System.Numerics;

namespace Celeste.Input.Devices.Mouse
{
    public struct SourceMouseState
    {
        public int X { get; internal set; }

        public int Y { get; internal set; }

        public SourceButtonState LeftButton { get; internal set; }

        public SourceButtonState RightButton { get; internal set; }

        public SourceButtonState MiddleButton { get; internal set; }

        public SourceButtonState XButton1 { get; internal set; }

        public SourceButtonState XButton2 { get; internal set; }

        public int ScrollWheelValue { get; internal set; }

        public SourceMouseState(int x, int y, int scrollWheel, SourceButtonState leftButton,
            SourceButtonState middleButton,
            SourceButtonState rightButton, SourceButtonState xButton1, SourceButtonState xButton2)
        {
            this = default(SourceMouseState);
            X = x;
            Y = y;
            ScrollWheelValue = scrollWheel;
            LeftButton = leftButton;
            MiddleButton = middleButton;
            RightButton = rightButton;
            XButton1 = xButton1;
            XButton2 = xButton2;
        }

        public static bool operator ==(SourceMouseState left, SourceMouseState right)
        {
            if (left.X == right.X && left.Y == right.Y && left.LeftButton == right.LeftButton &&
                left.MiddleButton == right.MiddleButton && left.RightButton == right.RightButton)
            {
                return left.ScrollWheelValue == right.ScrollWheelValue;
            }

            return false;
        }

        public static bool operator !=(SourceMouseState left, SourceMouseState right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is SourceMouseState)
            {
                return this == (SourceMouseState)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string text = string.Empty;
            if (LeftButton == SourceButtonState.Pressed)
            {
                text = "Left";
            }

            if (RightButton == SourceButtonState.Pressed)
            {
                if (text.Length > 0)
                {
                    text += " ";
                }

                text += "Right";
            }

            if (MiddleButton == SourceButtonState.Pressed)
            {
                if (text.Length > 0)
                {
                    text += " ";
                }

                text += "Middle";
            }

            if (XButton1 == SourceButtonState.Pressed)
            {
                if (text.Length > 0)
                {
                    text += " ";
                }

                text += "XButton1";
            }

            if (XButton2 == SourceButtonState.Pressed)
            {
                if (text.Length > 0)
                {
                    text += " ";
                }

                text += "XButton2";
            }

            if (string.IsNullOrEmpty(text))
            {
                text = "None";
            }

            return string.Format("[MouseState X={0}, Y={1}, Buttons={2}, Wheel={3}]",
                new object[] { X, Y, text, ScrollWheelValue });
        }
    }
}
