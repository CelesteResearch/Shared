using System.Numerics;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using ButtonState = Celeste.Input.Devices.GamePads.SourceButtonState;
using MathHelper = Celeste.Core.Mathematics.ScalarMath;
using GamePad = Celeste.Input.Devices.GamePads.SourceGamePadArithmetic;

namespace Celeste.Input.Devices.GamePads
{
    public struct SourceGamePadState
    {
        public bool IsConnected { get; internal set; }

        public int PacketNumber { get; internal set; }

        public SourceGamePadButtons Buttons { get; internal set; }

        public SourceGamePadDPad DPad { get; internal set; }

        public SourceGamePadThumbSticks ThumbSticks { get; internal set; }

        public SourceGamePadTriggers Triggers { get; internal set; }

        public SourceGamePadState(SourceGamePadThumbSticks thumbSticks, SourceGamePadTriggers triggers,
            SourceGamePadButtons buttons, SourceGamePadDPad dPad)
        {
            this = default(SourceGamePadState);
            if (triggers.Left > 0.11764706f)
            {
                buttons.buttons |= SourceGamePadButtonFlags.LeftTrigger;
            }

            if (triggers.Right > 0.11764706f)
            {
                buttons.buttons |= SourceGamePadButtonFlags.RightTrigger;
            }

            buttons.buttons |= StickToButtons(thumbSticks.Left, SourceGamePadButtonFlags.LeftThumbstickLeft,
                SourceGamePadButtonFlags.LeftThumbstickRight, SourceGamePadButtonFlags.LeftThumbstickUp,
                SourceGamePadButtonFlags.LeftThumbstickDown, 0.23953247f);
            buttons.buttons |= StickToButtons(thumbSticks.Right, SourceGamePadButtonFlags.RightThumbstickLeft,
                SourceGamePadButtonFlags.RightThumbstickRight, SourceGamePadButtonFlags.RightThumbstickUp,
                SourceGamePadButtonFlags.RightThumbstickDown, 0.26516724f);
            ThumbSticks = thumbSticks;
            Triggers = triggers;
            Buttons = buttons;
            DPad = dPad;
            IsConnected = true;
            PacketNumber = 0;
        }

        public SourceGamePadState(Vector2 leftThumbStick, Vector2 rightThumbStick, float leftTrigger,
            float rightTrigger,
            params Buttons[] buttons)
            : this(new SourceGamePadThumbSticks(leftThumbStick, rightThumbStick),
                new SourceGamePadTriggers(leftTrigger, rightTrigger), SourceGamePadButtons.FromButtonArray(buttons),
                SourceGamePadDPad.FromButtonArray(buttons))
        {
        }

        public bool IsButtonDown(Buttons button)
        {
            return (Buttons.buttons & button) == button;
        }

        public bool IsButtonUp(Buttons button)
        {
            return (Buttons.buttons & button) != button;
        }

        private static Buttons StickToButtons(Vector2 stick, Buttons left, Buttons right, Buttons up, Buttons down,
            float DeadZoneSize)
        {
            Buttons buttons = (Buttons)0;
            if (stick.X > DeadZoneSize)
            {
                buttons |= right;
            }

            if (stick.X < 0f - DeadZoneSize)
            {
                buttons |= left;
            }

            if (stick.Y > DeadZoneSize)
            {
                buttons |= up;
            }

            if (stick.Y < 0f - DeadZoneSize)
            {
                buttons |= down;
            }

            return buttons;
        }

        public static bool operator ==(SourceGamePadState left, SourceGamePadState right)
        {
            if (left.IsConnected == right.IsConnected && left.PacketNumber == right.PacketNumber &&
                left.Buttons == right.Buttons && left.DPad == right.DPad && left.ThumbSticks == right.ThumbSticks)
            {
                return left.Triggers == right.Triggers;
            }

            return false;
        }

        public static bool operator !=(SourceGamePadState left, SourceGamePadState right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is SourceGamePadState)
            {
                return this == (SourceGamePadState)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
