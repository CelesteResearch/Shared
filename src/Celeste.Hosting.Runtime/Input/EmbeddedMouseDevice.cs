using System;
using Celeste.Input.Devices.Mouse;

namespace Celeste.Hosting.Runtime.Input
{
    public sealed class EmbeddedMouseDevice : ISourceSDLMouseTouchDevice
    {
        private int x;
        private int y;
        private uint buttons;
        public int WheelDelta { get; private set; }
        public event Action<int, int>? WarpRequested;

        public void Advance(int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused)
        {
            x = mouseX;
            y = mouseY;
            buttons = focused ? mouseButtons & 31u : 0u;
            WheelDelta = focused ? wheelDelta : 0;
        }

        public uint GetMouseState(out int mouseX, out int mouseY)
        {
            mouseX = x;
            mouseY = y;
            return buttons;
        }

        // This endpoint's global space is the embedded surface space, with origin zero.
        // Construct SourceFnaInputProcess with supportsGlobalMouse=false.
        public uint GetGlobalMouseState(out int mouseX, out int mouseY) => GetMouseState(out mouseX, out mouseY);

        public uint GetRelativeMouseState(out int mouseX, out int mouseY)
        {
            mouseX = mouseY = 0;
            return buttons;
        }

        public int GetRelativeMouseMode() => 0;
        public int SetRelativeMouseMode(int enabled) => enabled == 0 ? 0 : -1;

        public void GetWindowPosition(IntPtr window, out int windowX, out int windowY)
        {
            windowX = windowY = 0;
        }

        public void WarpMouseInWindow(IntPtr window, int mouseX, int mouseY) => WarpRequested?.Invoke(mouseX, mouseY);
        public int GetNumTouchDevices() => 0;
        public long GetTouchDevice(int index) => -1;
        public IntPtr GetTouchFinger(long device, int index) => IntPtr.Zero;
        public long ReadFingerId(IntPtr finger) => -1;
        public float ReadFingerX(IntPtr finger) => 0;
        public float ReadFingerY(IntPtr finger) => 0;
        public int GetNumTouchFingers(long device) => 0;
    }
}
