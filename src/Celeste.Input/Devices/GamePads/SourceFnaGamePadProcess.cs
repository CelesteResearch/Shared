using Celeste.Core.Display;
using System.Numerics;
using PlayerIndex = Celeste.Input.Devices.GamePads.SourcePlayerIndex;
using Color = Celeste.Core.Display.PackedColor;
using System;

namespace Celeste.Input.Devices.GamePads
{
    public sealed class SourceFnaGamePadProcess
    {
        internal const float LeftDeadZone = 0.23953247f;

        internal const float RightDeadZone = 0.26516724f;

        internal const float TriggerThreshold = 0.11764706f;

        internal readonly int GAMEPAD_COUNT;
        private readonly SourceSDLGamePadPlatform platform;
        public SourceSDLGamePadPlatform Platform => platform;
        private readonly ISourceGamePadEnvironmentDevice environment;

        public SourceFnaGamePadProcess(ISourceSDLGamePadDevice device, ISourceSDLGamePadLog log,
            ISourceGamePadEnvironmentDevice environment, Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic)
        {
            this.environment = environment;
            GAMEPAD_COUNT = DetermineNumGamepads();
            platform = new SourceSDLGamePadPlatform(GAMEPAD_COUNT, device, log, arithmetic);
        }

        private int DetermineNumGamepads()
        {
            string environmentVariable = environment.GetEnvironmentVariable("FNA_GAMEPAD_NUM_GAMEPADS");
            if (!string.IsNullOrEmpty(environmentVariable) && int.TryParse(environmentVariable, out var result) &&
                result >= 0)
            {
                return result;
            }

            return Enum.GetNames(typeof(PlayerIndex)).Length;
        }

        public SourceGamePadCapabilities GetCapabilities(PlayerIndex playerIndex)
        {
            return platform.GetGamePadCapabilities((int)playerIndex);
        }

        public SourceGamePadState GetState(PlayerIndex playerIndex)
        {
            return platform.GetGamePadState((int)playerIndex, SourceGamePadDeadZone.IndependentAxes);
        }

        public SourceGamePadState GetState(PlayerIndex playerIndex, SourceGamePadDeadZone deadZoneMode)
        {
            return platform.GetGamePadState((int)playerIndex, deadZoneMode);
        }

        public bool SetVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            return platform.SetGamePadVibration((int)playerIndex, leftMotor, rightMotor);
        }

        public string GetGUIDEXT(PlayerIndex playerIndex)
        {
            return platform.GetGamePadGUID((int)playerIndex);
        }

        public void SetLightBarEXT(PlayerIndex playerIndex, Color color)
        {
            platform.SetGamePadLightBar((int)playerIndex, color);
        }

        public bool SetTriggerVibrationEXT(PlayerIndex playerIndex, float leftTrigger, float rightTrigger)
        {
            return platform.SetGamePadTriggerVibration((int)playerIndex, leftTrigger, rightTrigger);
        }

        public bool GetGyroEXT(PlayerIndex playerIndex, out Vector3 gyro)
        {
            return platform.GetGamePadGyro((int)playerIndex, out gyro);
        }

        public bool GetAccelerometerEXT(PlayerIndex playerIndex, out Vector3 accel)
        {
            return platform.GetGamePadAccelerometer((int)playerIndex, out accel);
        }
    }
}
