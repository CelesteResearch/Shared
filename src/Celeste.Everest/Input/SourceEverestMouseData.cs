using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Mouse;
using Celeste.Input.Runtime;

namespace Celeste.Everest.Input
{
    public class SourceEverestMouseData : SourceMouseData
    {
        public enum MouseButtons
        {
            Left = 0,
            Right = 1,
            Middle = 2,
            XButton1 = 3,
            XButton2 = 4,
        }

        public SourceEverestMouseData(SourceFnaMouse mouse, SourceMInputProcess process) : base(mouse, process)
        {
        }

        public bool Check(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left: return MInput.Mouse.CheckLeftButton;
                case MouseButtons.Right: return MInput.Mouse.CheckRightButton;
                case MouseButtons.Middle: return MInput.Mouse.CheckMiddleButton;
                case MouseButtons.XButton1: return MInput.Mouse.CurrentState.XButton1 == SourceButtonState.Pressed;
                case MouseButtons.XButton2: return MInput.Mouse.CurrentState.XButton2 == SourceButtonState.Pressed;
                default: return false;
            }
        }

        public bool Pressed(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left: return MInput.Mouse.PressedLeftButton;
                case MouseButtons.Right: return MInput.Mouse.PressedRightButton;
                case MouseButtons.Middle: return MInput.Mouse.PressedMiddleButton;
                case MouseButtons.XButton1:
                    return MInput.Mouse.CurrentState.XButton1 == SourceButtonState.Pressed &&
                           MInput.Mouse.PreviousState.XButton1 == SourceButtonState.Released;
                case MouseButtons.XButton2:
                    return MInput.Mouse.CurrentState.XButton2 == SourceButtonState.Pressed &&
                           MInput.Mouse.PreviousState.XButton2 == SourceButtonState.Released;
                default: return false;
            }
        }

        public bool Released(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left: return MInput.Mouse.ReleasedLeftButton;
                case MouseButtons.Right: return MInput.Mouse.ReleasedRightButton;
                case MouseButtons.Middle: return MInput.Mouse.ReleasedMiddleButton;
                case MouseButtons.XButton1:
                    return MInput.Mouse.CurrentState.XButton1 == SourceButtonState.Released &&
                           MInput.Mouse.PreviousState.XButton1 == SourceButtonState.Pressed;
                case MouseButtons.XButton2:
                    return MInput.Mouse.CurrentState.XButton2 == SourceButtonState.Released &&
                           MInput.Mouse.PreviousState.XButton2 == SourceButtonState.Pressed;
                default: return false;
            }
        }
    }
}
