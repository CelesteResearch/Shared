using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.IO;
using Celeste.Core.Mathematics;
using MathHelper = Celeste.Core.Mathematics.ScalarMath;

namespace Celeste.Input.Devices.GamePads
{
    public sealed class SourceSDLGamePadPlatform
    {
        private readonly ISourceSDLGamePadDevice device;
        private readonly ISourceSDLGamePadLog log;
        private readonly int gamePadCount;
        private readonly ISourceVectorArithmetic arithmetic;
        private readonly IntPtr[] INTERNAL_devices;
        private readonly Dictionary<int, int> INTERNAL_instanceList;
        private readonly string[] INTERNAL_guids;
        private readonly SourceGamePadState[] INTERNAL_states;
        private readonly SourceGamePadCapabilities[] INTERNAL_capabilities;
        private readonly SourceGamePadType[] INTERNAL_gamepadType;

        public SourceSDLGamePadPlatform(int gamePadCount, ISourceSDLGamePadDevice device, ISourceSDLGamePadLog log,
            ISourceVectorArithmetic arithmetic)
        {
            this.gamePadCount = gamePadCount;
            this.device = device;
            this.log = log;
            this.arithmetic = arithmetic;
            INTERNAL_devices = new IntPtr[gamePadCount];
            INTERNAL_instanceList = new();
            INTERNAL_guids = GenStringArray();
            INTERNAL_states = new SourceGamePadState[gamePadCount];
            INTERNAL_capabilities = new SourceGamePadCapabilities[gamePadCount];
            INTERNAL_gamepadType =
            [
                SourceGamePadType.Unknown, SourceGamePadType.GamePad, SourceGamePadType.Wheel,
                SourceGamePadType.ArcadeStick, SourceGamePadType.FlightStick, SourceGamePadType.DancePad,
                SourceGamePadType.Guitar, SourceGamePadType.DrumKit, SourceGamePadType.BigButtonPad,
            ];
        }

        public SourceGamePadCapabilities GetGamePadCapabilities(int index)
        {
            if (INTERNAL_devices[index] == IntPtr.Zero) return default;

            return INTERNAL_capabilities[index];
        }

        public SourceGamePadState GetGamePadState(int index, SourceGamePadDeadZone deadZoneMode)
        {
            var intPtr = INTERNAL_devices[index];
            if (intPtr == IntPtr.Zero) return default;

            var leftPosition = new Vector2(device.GetAxis(intPtr, SourceSDLGamePadAxis.LEFTX) / 32767f,
                device.GetAxis(intPtr, SourceSDLGamePadAxis.LEFTY) / -32767f);
            var rightPosition = new Vector2(device.GetAxis(intPtr, SourceSDLGamePadAxis.RIGHTX) / 32767f,
                device.GetAxis(intPtr, SourceSDLGamePadAxis.RIGHTY) / -32767f);
            var leftTrigger = device.GetAxis(intPtr, SourceSDLGamePadAxis.TRIGGERLEFT) / 32767f;
            var rightTrigger = device.GetAxis(intPtr, SourceSDLGamePadAxis.TRIGGERRIGHT) / 32767f;
            var buttons = (SourceGamePadButtonFlags)0;
            if (device.GetButton(intPtr, SourceSDLGamePadButton.A) != 0) buttons |= SourceGamePadButtonFlags.A;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.B) != 0) buttons |= SourceGamePadButtonFlags.B;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.X) != 0) buttons |= SourceGamePadButtonFlags.X;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.Y) != 0) buttons |= SourceGamePadButtonFlags.Y;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.BACK) != 0) buttons |= SourceGamePadButtonFlags.Back;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.GUIDE) != 0)
                buttons |= SourceGamePadButtonFlags.BigButton;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.START) != 0) buttons |= SourceGamePadButtonFlags.Start;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.LEFTSTICK) != 0)
                buttons |= SourceGamePadButtonFlags.LeftStick;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.RIGHTSTICK) != 0)
                buttons |= SourceGamePadButtonFlags.RightStick;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.LEFTSHOULDER) != 0)
                buttons |= SourceGamePadButtonFlags.LeftShoulder;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.RIGHTSHOULDER) != 0)
                buttons |= SourceGamePadButtonFlags.RightShoulder;

            var upValue = SourceButtonState.Released;
            var downValue = SourceButtonState.Released;
            var leftValue = SourceButtonState.Released;
            var rightValue = SourceButtonState.Released;
            if (device.GetButton(intPtr, SourceSDLGamePadButton.DPAD_UP) != 0)
            {
                buttons |= SourceGamePadButtonFlags.DPadUp;
                upValue = SourceButtonState.Pressed;
            }

            if (device.GetButton(intPtr, SourceSDLGamePadButton.DPAD_DOWN) != 0)
            {
                buttons |= SourceGamePadButtonFlags.DPadDown;
                downValue = SourceButtonState.Pressed;
            }

            if (device.GetButton(intPtr, SourceSDLGamePadButton.DPAD_LEFT) != 0)
            {
                buttons |= SourceGamePadButtonFlags.DPadLeft;
                leftValue = SourceButtonState.Pressed;
            }

            if (device.GetButton(intPtr, SourceSDLGamePadButton.DPAD_RIGHT) != 0)
            {
                buttons |= SourceGamePadButtonFlags.DPadRight;
                rightValue = SourceButtonState.Pressed;
            }

            if (device.GetButton(intPtr, SourceSDLGamePadButton.MISC1) != 0)
                buttons |= SourceGamePadButtonFlags.Misc1EXT;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.PADDLE1) != 0)
                buttons |= SourceGamePadButtonFlags.Paddle1EXT;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.PADDLE2) != 0)
                buttons |= SourceGamePadButtonFlags.Paddle2EXT;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.PADDLE3) != 0)
                buttons |= SourceGamePadButtonFlags.Paddle3EXT;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.PADDLE4) != 0)
                buttons |= SourceGamePadButtonFlags.Paddle4EXT;

            if (device.GetButton(intPtr, SourceSDLGamePadButton.TOUCHPAD) != 0)
                buttons |= SourceGamePadButtonFlags.TouchPadEXT;

            var gamePadState = new SourceGamePadState(
                new(leftPosition, rightPosition, deadZoneMode, arithmetic),
                new(leftTrigger, rightTrigger, deadZoneMode), new(buttons),
                new SourceGamePadDPad(upValue, downValue, leftValue, rightValue));
            gamePadState.IsConnected = true;
            gamePadState.PacketNumber = INTERNAL_states[index].PacketNumber;
            if (gamePadState != INTERNAL_states[index])
            {
                gamePadState.PacketNumber++;
                INTERNAL_states[index] = gamePadState;
            }

            return gamePadState;
        }

        public bool SetGamePadVibration(int index, float leftMotor, float rightMotor)
        {
            var intPtr = INTERNAL_devices[index];
            if (intPtr == IntPtr.Zero) return false;

            return device.Rumble(intPtr, (ushort)(MathHelper.Clamp(leftMotor, 0f, 1f) * 65535f),
                (ushort)(MathHelper.Clamp(rightMotor, 0f, 1f) * 65535f), 0u) == 0;
        }

        public bool SetGamePadTriggerVibration(int index, float leftTrigger, float rightTrigger)
        {
            var intPtr = INTERNAL_devices[index];
            if (intPtr == IntPtr.Zero) return false;

            return device.RumbleTriggers(intPtr, (ushort)(MathHelper.Clamp(leftTrigger, 0f, 1f) * 65535f),
                (ushort)(MathHelper.Clamp(rightTrigger, 0f, 1f) * 65535f), 0u) == 0;
        }

        public string GetGamePadGUID(int index)
        {
            return INTERNAL_guids[index];
        }

        public void SetGamePadLightBar(int index, PackedColor color)
        {
            var intPtr = INTERNAL_devices[index];
            if (!(intPtr == IntPtr.Zero)) device.SetLED(intPtr, color.R, color.G, color.B);
        }

        public unsafe bool GetGamePadGyro(int index, out Vector3 gyro)
        {
            var intPtr = INTERNAL_devices[index];
            if (intPtr == IntPtr.Zero)
            {
                gyro = Vector3.Zero;
                return false;
            }

            if (device.IsSensorEnabled(intPtr, SourceSDLGamePadSensor.GYRO) == 0)
                device.SetSensorEnabled(intPtr, SourceSDLGamePadSensor.GYRO, 1);

            var ptr = stackalloc float[3];
            if (device.GetSensorData(intPtr, SourceSDLGamePadSensor.GYRO, (IntPtr)ptr, 3) < 0)
            {
                gyro = Vector3.Zero;
                return false;
            }

            gyro.X = *ptr;
            gyro.Y = ptr[1];
            gyro.Z = ptr[2];
            return true;
        }

        public unsafe bool GetGamePadAccelerometer(int index, out Vector3 accel)
        {
            var intPtr = INTERNAL_devices[index];
            if (intPtr == IntPtr.Zero)
            {
                accel = Vector3.Zero;
                return false;
            }

            if (device.IsSensorEnabled(intPtr, SourceSDLGamePadSensor.ACCEL) == 0)
                device.SetSensorEnabled(intPtr, SourceSDLGamePadSensor.ACCEL, 1);

            var ptr = stackalloc float[3];
            if (device.GetSensorData(intPtr, SourceSDLGamePadSensor.ACCEL, (IntPtr)ptr, 3) < 0)
            {
                accel = Vector3.Zero;
                return false;
            }

            accel.X = *ptr;
            accel.Y = ptr[1];
            accel.Z = ptr[2];
            return true;
        }

        public void AddInstance(int dev)
        {
            var num = -1;
            for (var i = 0; i < INTERNAL_devices.Length; i++)
                if (INTERNAL_devices[i] == IntPtr.Zero)
                {
                    num = i;
                    break;
                }

            if (num == -1) return;

            device.ClearError();
            INTERNAL_devices[num] = device.Open(dev);
            var joystick = device.GetJoystick(INTERNAL_devices[num]);
            var key = device.GetJoystickInstanceID(joystick);
            if (INTERNAL_instanceList.ContainsKey(key))
            {
                INTERNAL_devices[num] = IntPtr.Zero;
                return;
            }

            INTERNAL_instanceList.Add(key, num);
            INTERNAL_states[num] = default;
            INTERNAL_states[num].IsConnected = true;
            var flag = device.Rumble(INTERNAL_devices[num], 0, 0, 0u) == 0;
            var hasTriggerVibrationMotorsExt = device.RumbleTriggers(INTERNAL_devices[num], 0, 0, 0u) == 0;
            var gamePadCapabilities = new SourceGamePadCapabilities
            {
                IsConnected = true,
                GamePadType = INTERNAL_gamepadType[device.GetJoystickType(joystick)],
                HasAButton = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.A) != 0,
                HasBButton = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.B) != 0,
                HasXButton = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.X) != 0,
                HasYButton = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.Y) != 0,
                HasBackButton = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.BACK) != 0,
                HasBigButton = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.GUIDE) != 0,
                HasStartButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.START) != 0,
                HasLeftStickButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.LEFTSTICK) != 0,
                HasRightStickButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.RIGHTSTICK) != 0,
                HasLeftShoulderButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.LEFTSHOULDER) != 0,
                HasRightShoulderButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.RIGHTSHOULDER) != 0,
                HasDPadUpButton = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.DPAD_UP) !=
                                  0,
                HasDPadDownButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.DPAD_DOWN) !=
                    0,
                HasDPadLeftButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.DPAD_LEFT) !=
                    0,
                HasDPadRightButton =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.DPAD_RIGHT) != 0,
                HasLeftXThumbStick =
                    device.GetAxisBindingType(INTERNAL_devices[num], SourceSDLGamePadAxis.LEFTX) != 0,
                HasLeftYThumbStick =
                    device.GetAxisBindingType(INTERNAL_devices[num], SourceSDLGamePadAxis.LEFTY) != 0,
                HasRightXThumbStick =
                    device.GetAxisBindingType(INTERNAL_devices[num], SourceSDLGamePadAxis.RIGHTX) != 0,
                HasRightYThumbStick =
                    device.GetAxisBindingType(INTERNAL_devices[num], SourceSDLGamePadAxis.RIGHTY) != 0,
                HasLeftTrigger = device.GetAxisBindingType(INTERNAL_devices[num], SourceSDLGamePadAxis.TRIGGERLEFT) !=
                                 0,
                HasRightTrigger =
                    device.GetAxisBindingType(INTERNAL_devices[num], SourceSDLGamePadAxis.TRIGGERRIGHT) != 0,
                HasLeftVibrationMotor = flag,
                HasRightVibrationMotor = flag,
                HasVoiceSupport = false,
                HasLightBarEXT = device.HasLED(INTERNAL_devices[num]) == 1,
                HasTriggerVibrationMotorsEXT = hasTriggerVibrationMotorsExt,
                HasMisc1EXT = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.MISC1) != 0,
                HasPaddle1EXT =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.PADDLE1) != 0,
                HasPaddle2EXT =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.PADDLE2) != 0,
                HasPaddle3EXT =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.PADDLE3) != 0,
                HasPaddle4EXT =
                    device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.PADDLE4) != 0,
                HasTouchPadEXT = device.GetButtonBindingType(INTERNAL_devices[num], SourceSDLGamePadButton.TOUCHPAD) !=
                                 0,
                HasGyroEXT = device.HasSensor(INTERNAL_devices[num], SourceSDLGamePadSensor.GYRO) == 1,
                HasAccelerometerEXT = device.HasSensor(INTERNAL_devices[num], SourceSDLGamePadSensor.ACCEL) == 1,
            };
            INTERNAL_capabilities[num] = gamePadCapabilities;
            var num2 = device.GetJoystickVendor(joystick);
            var num3 = device.GetJoystickProduct(joystick);
            if (num2 == 0 && num3 == 0)
                INTERNAL_guids[num] = "xinput";
            else
                INTERNAL_guids[num] = $"{num2 & 0xFF:x2}{num2 >> 8:x2}{num3 & 0xFF:x2}{num3 >> 8:x2}";

            if (num2 == 10462)
                switch (device.GetControllerType(INTERNAL_devices[num]))
                {
                    case SourceSDLGamePadControllerType.XBOX360:
                    case SourceSDLGamePadControllerType.XBOXONE:
                        INTERNAL_guids[num] = "xinput";
                        break;
                    case SourceSDLGamePadControllerType.PS4:
                        INTERNAL_guids[num] = "4c05c405";
                        break;
                    case SourceSDLGamePadControllerType.PS5:
                        INTERNAL_guids[num] = "4c05e60c";
                        break;
                }

            var text =
                SourceSDLUtf8Marshalling.Read(device.GetMappingPointer(INTERNAL_devices[num]), true,
                    device);
            var text2 = !string.IsNullOrEmpty(text) ? "Mapping: " + text : "Mapping not found";
            log.LogInfo("Controller " + num + ": " +
                        SourceSDLUtf8Marshalling.Read(device.GetNamePointer(INTERNAL_devices[num]),
                            false,
                            device) + ", GUID: " + INTERNAL_guids[num] + ", " + text2);
        }

        public bool TryGetPlayerIndex(int instanceId, out int playerIndex)
        {
            return INTERNAL_instanceList.TryGetValue(instanceId, out playerIndex);
        }

        public void RemoveInstance(int dev)
        {
            if (INTERNAL_instanceList.TryGetValue(dev, out var value))
            {
                INTERNAL_instanceList.Remove(dev);
                device.Close(INTERNAL_devices[value]);
                INTERNAL_devices[value] = IntPtr.Zero;
                INTERNAL_states[value] = default;
                INTERNAL_guids[value] = string.Empty;
                device.ClearError();
                log.LogInfo("Removed device, player: " + value);
            }
        }

        private string[] GenStringArray()
        {
            var array = new string[gamePadCount];
            for (var i = 0; i < array.Length; i++) array[i] = string.Empty;

            return array;
        }
    }
}
