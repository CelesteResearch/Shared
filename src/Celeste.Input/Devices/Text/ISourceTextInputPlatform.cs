using System;
using Celeste.Core.Geometry;

namespace Celeste.Input.Devices.Text
{
    public interface ISourceTextInputPlatform
    {
        bool IsTextInputActive();
        bool IsScreenKeyboardShown(IntPtr window);
        void StartTextInput();
        void StopTextInput();
        void SetTextInputRectangle(IntRect rectangle);
    }
}
