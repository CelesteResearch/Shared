using System;

namespace Celeste.Input.Devices.GamePads
{
    public interface ISourceSDLGamePadDevice : Celeste.Core.IO.ISourceSDLMemoryDevice
    {
        short GetAxis(IntPtr controller, SourceSDLGamePadAxis axis);
        byte GetButton(IntPtr controller, SourceSDLGamePadButton button);
        int Rumble(IntPtr controller, ushort left, ushort right, uint duration);
        int RumbleTriggers(IntPtr controller, ushort left, ushort right, uint duration);
        int SetLED(IntPtr controller, byte red, byte green, byte blue);
        int IsSensorEnabled(IntPtr controller, SourceSDLGamePadSensor sensor);
        int SetSensorEnabled(IntPtr controller, SourceSDLGamePadSensor sensor, int enabled);
        int GetSensorData(IntPtr controller, SourceSDLGamePadSensor sensor, IntPtr data, int count);
        void ClearError();
        IntPtr Open(int deviceIndex);
        IntPtr GetJoystick(IntPtr controller);
        int GetJoystickInstanceID(IntPtr joystick);
        int GetJoystickType(IntPtr joystick);
        int GetButtonBindingType(IntPtr controller, SourceSDLGamePadButton button);
        int GetAxisBindingType(IntPtr controller, SourceSDLGamePadAxis axis);
        int HasLED(IntPtr controller);
        int HasSensor(IntPtr controller, SourceSDLGamePadSensor sensor);
        ushort GetJoystickVendor(IntPtr joystick);
        ushort GetJoystickProduct(IntPtr joystick);
        SourceSDLGamePadControllerType GetControllerType(IntPtr controller);
        IntPtr GetMappingPointer(IntPtr controller);
        IntPtr GetNamePointer(IntPtr controller);
        void Close(IntPtr controller);
    }
}
