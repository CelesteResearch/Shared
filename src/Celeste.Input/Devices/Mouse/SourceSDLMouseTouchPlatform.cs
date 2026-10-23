using System;
using System.Numerics;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Touch;

namespace Celeste.Input.Devices.Mouse
{
    public class SourceSDLMouseTouchPlatform
    {
        private readonly ISourceSDLMouseTouchDevice device;
        private readonly bool supportsGlobalMouse;

        public SourceSDLMouseTouchPlatform(ISourceSDLMouseTouchDevice device, bool supportsGlobalMouse)
        {
            this.device = device;
            this.supportsGlobalMouse = supportsGlobalMouse;
        }

        public bool GetRelativeMouseMode()
        {
            return device.GetRelativeMouseMode() == 1;
        }

        public void SetRelativeMouseMode(bool enabled)
        {
            device.SetRelativeMouseMode(enabled ? 1 : 0);
            if (enabled)
            {
                int discarded;
                device.GetRelativeMouseState(out discarded, out discarded);
            }
        }

        public void GetMouseState(IntPtr window, out int x, out int y, out SourceButtonState left,
            out SourceButtonState middle, out SourceButtonState right, out SourceButtonState x1,
            out SourceButtonState x2)
        {
            uint mask;
            if (GetRelativeMouseMode())
            {
                mask = device.GetRelativeMouseState(out x, out y);
            }
            else if (supportsGlobalMouse)
            {
                mask = device.GetGlobalMouseState(out x, out y);
                int windowX = 0, windowY = 0;
                device.GetWindowPosition(window, out windowX, out windowY);
                x = unchecked(x - windowX);
                y = unchecked(y - windowY);
            }
            else
            {
                mask = device.GetMouseState(out x, out y);
            }

            left = (SourceButtonState)(mask & 1);
            middle = (SourceButtonState)((mask & 2) >> 1);
            right = (SourceButtonState)((mask & 4) >> 2);
            x1 = (SourceButtonState)((mask & 8) >> 3);
            x2 = (SourceButtonState)((mask & 16) >> 4);
        }

        public void SetMousePosition(IntPtr window, int x, int y)
        {
            device.WarpMouseInWindow(window, x, y);
        }

        public SourceTouchPanelCapabilities GetTouchCapabilities()
        {
            var connected = device.GetNumTouchDevices() > 0;
            return new(connected, connected ? 4 : 0);
        }

        public void UpdateTouchPanelState(SourceFnaTouchPanel panel)
        {
            var touchDevice = device.GetTouchDevice(0);
            for (var i = 0; i < 8; i++)
            {
                var finger = device.GetTouchFinger(touchDevice, i);
                if (finger == IntPtr.Zero) panel.SetFinger(i, -1, Vector2.Zero);
                else
                    panel.SetFinger(i, unchecked((int)device.ReadFingerId(finger)), new(
                        (float)Math.Round(device.ReadFingerX(finger) * panel.DisplayWidth),
                        (float)Math.Round(device.ReadFingerY(finger) * panel.DisplayHeight)));
            }
        }

        public int GetNumTouchFingers()
        {
            return device.GetNumTouchFingers(device.GetTouchDevice(0));
        }
    }
}
