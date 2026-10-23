using System;
using System.ComponentModel;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Everest.Input
{
    public class SourceEverestKeyboardStateProcess : SourceFnaKeyboardStateProcess
    {
        private readonly bool UseNewInputDriver;

        public SourceEverestKeyboardStateProcess(ISourceKeyboardDevice device) : base(device, false)
        {
            var environmentVariable = device.GetEnvironmentVariable("EVEREST_NEW_KEYBOARD_INPUT");
            if (environmentVariable != null && int.TryParse(environmentVariable, out var result))
                UseNewInputDriver = result == 1;
            Keys = [];
        }

        public override SourceKeyboardState GetState()
        {
            if (!UseNewInputDriver || !device.IsWindows)
                return base.GetState();
            Span<byte> keys = stackalloc byte[256];
            if (!device.ReadWin32KeyboardState(keys))
                throw new Win32Exception("Failed to get Win32 keyboard state");
            var result = default(SourceKeyboardState);
            for (var i = 0; i < 256; i++)
                if ((keys[i] & 0x80) != 0)
                    SetKey(ref result, (SourceKeys)i);
            return result;
        }

        public override SourceKeyboardState GetState(SourcePlayerIndex playerIndex)
        {
            return GetState();
        }
    }
}
