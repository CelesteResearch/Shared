using System;

namespace Celeste.Input.Devices.Keyboard
{
    public interface ISourceKeyboardDevice
    {
        string GetEnvironmentVariable(string name);
        bool IsWindows { get; }
        bool ReadWin32KeyboardState(Span<byte> keys);
        SourceKeys GetKeyFromScancode(SourceKeys scancode);
    }
}
