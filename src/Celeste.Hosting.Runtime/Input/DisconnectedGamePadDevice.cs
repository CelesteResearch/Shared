using System;
using Celeste.Input.Devices.GamePads;

namespace Celeste.Hosting.Runtime.Input
{
    public sealed class DisconnectedGamePadDevice : ISourceSDLGamePadDevice
    {
        public IntPtr Open(int deviceIndex)
        {
            return IntPtr.Zero;
        }

        public IntPtr GetJoystick(IntPtr controller)
        {
            return IntPtr.Zero;
        }

        public int GetJoystickInstanceID(IntPtr joystick)
        {
            return -1;
        }

        public int GetJoystickType(IntPtr joystick)
        {
            return 0;
        }

        public short GetAxis(IntPtr controller, SourceSDLGamePadAxis axis)
        {
            return 0;
        }

        public byte GetButton(IntPtr controller, SourceSDLGamePadButton button)
        {
            return 0;
        }

        public int GetButtonBindingType(IntPtr controller, SourceSDLGamePadButton button)
        {
            return 0;
        }

        public int GetAxisBindingType(IntPtr controller, SourceSDLGamePadAxis axis)
        {
            return 0;
        }

        public int Rumble(IntPtr controller, ushort left, ushort right, uint duration)
        {
            return -1;
        }

        public int RumbleTriggers(IntPtr controller, ushort left, ushort right, uint duration)
        {
            return -1;
        }

        public int SetLED(IntPtr controller, byte red, byte green, byte blue)
        {
            return -1;
        }

        public int HasLED(IntPtr controller)
        {
            return 0;
        }

        public int HasSensor(IntPtr controller, SourceSDLGamePadSensor sensor)
        {
            return 0;
        }

        public int IsSensorEnabled(IntPtr controller, SourceSDLGamePadSensor sensor)
        {
            return 0;
        }

        public int SetSensorEnabled(IntPtr controller, SourceSDLGamePadSensor sensor, int enabled)
        {
            return -1;
        }

        public int GetSensorData(IntPtr controller, SourceSDLGamePadSensor sensor, IntPtr data, int count)
        {
            return -1;
        }

        public ushort GetJoystickVendor(IntPtr joystick)
        {
            return 0;
        }

        public ushort GetJoystickProduct(IntPtr joystick)
        {
            return 0;
        }

        public SourceSDLGamePadControllerType GetControllerType(IntPtr controller)
        {
            return SourceSDLGamePadControllerType.UNKNOWN;
        }

        public IntPtr GetMappingPointer(IntPtr controller)
        {
            return IntPtr.Zero;
        }

        public IntPtr GetNamePointer(IntPtr controller)
        {
            return IntPtr.Zero;
        }

        public void ClearError()
        {
        }

        public void Close(IntPtr controller)
        {
        }

        public void Free(IntPtr pointer)
        {
        }
    }
}
