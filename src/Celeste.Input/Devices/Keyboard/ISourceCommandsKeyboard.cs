using System;

namespace Celeste.Input.Devices.Keyboard
{
    public interface ISourceCommandsKeyboard
    {
        SourceKeyboardState CurrentState { get; set; }
        bool Pressed(SourceKeys key);
        bool Pressed(SourceKeys keyA, SourceKeys keyB);
    }
}
