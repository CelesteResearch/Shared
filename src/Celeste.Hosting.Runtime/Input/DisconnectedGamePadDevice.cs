using System;
using Celeste.Input.Devices.GamePads;

namespace Celeste.Hosting.Runtime.Input
{
    public sealed class DisconnectedGamePadDevice : ISourceSDLGamePadDevice
    {
        public IntPtr Open(int deviceIndex) => IntPtr.Zero;
        public IntPtr GetJoystick(IntPtr controller) => IntPtr.Zero;
        public int GetJoystickInstanceID(IntPtr joystick) => -1;
        public int GetJoystickType(IntPtr joystick) => 0;
        public short GetAxis(IntPtr controller, SourceSDLGamePadAxis axis) => 0;
        public byte GetButton(IntPtr controller, SourceSDLGamePadButton button) => 0;
        public int GetButtonBindingType(IntPtr controller, SourceSDLGamePadButton button) => 0;
        public int GetAxisBindingType(IntPtr controller, SourceSDLGamePadAxis axis) => 0;
        public int Rumble(IntPtr controller, ushort left, ushort right, uint duration) => -1;
        public int RumbleTriggers(IntPtr controller, ushort left, ushort right, uint duration) => -1;
        public int SetLED(IntPtr controller, byte red, byte green, byte blue) => -1;
        public int HasLED(IntPtr controller) => 0;
        public int HasSensor(IntPtr controller, SourceSDLGamePadSensor sensor) => 0;
        public int IsSensorEnabled(IntPtr controller, SourceSDLGamePadSensor sensor) => 0;
        public int SetSensorEnabled(IntPtr controller, SourceSDLGamePadSensor sensor, int enabled) => -1;
        public int GetSensorData(IntPtr controller, SourceSDLGamePadSensor sensor, IntPtr data, int count) => -1;
        public ushort GetJoystickVendor(IntPtr joystick) => 0;
        public ushort GetJoystickProduct(IntPtr joystick) => 0;

        public SourceSDLGamePadControllerType GetControllerType(IntPtr controller) =>
            SourceSDLGamePadControllerType.UNKNOWN;

        public IntPtr GetMappingPointer(IntPtr controller) => IntPtr.Zero;
        public IntPtr GetNamePointer(IntPtr controller) => IntPtr.Zero;

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
