using System;

namespace Celeste.Input.Devices.Mouse
{
    public interface ISourceSDLMouseTouchDevice
    {
        uint GetMouseState(out int x, out int y);
        uint GetGlobalMouseState(out int x, out int y);
        uint GetRelativeMouseState(out int x, out int y);
        int GetRelativeMouseMode();
        int SetRelativeMouseMode(int enabled);
        void GetWindowPosition(IntPtr window, out int x, out int y);
        void WarpMouseInWindow(IntPtr window, int x, int y);
        int GetNumTouchDevices();
        long GetTouchDevice(int index);
        IntPtr GetTouchFinger(long device, int index);
        long ReadFingerId(IntPtr finger);
        float ReadFingerX(IntPtr finger);
        float ReadFingerY(IntPtr finger);
        int GetNumTouchFingers(long device);
    }
}
