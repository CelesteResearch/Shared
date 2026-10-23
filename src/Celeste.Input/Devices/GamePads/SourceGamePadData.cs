using System;
using System.Numerics;
using Celeste.Input.Runtime;
using Calc = Celeste.Core.Mathematics.ScalarMath;
using PlayerIndex = Celeste.Input.Devices.GamePads.SourcePlayerIndex;
using GamePadState = Celeste.Input.Devices.GamePads.SourceGamePadState;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using ButtonState = Celeste.Input.Devices.GamePads.SourceButtonState;

namespace Celeste.Input.Devices.GamePads
{
    public class SourceGamePadData
    {
        private readonly SourceFnaGamePadProcess gamepads;
        private readonly SourceMInputProcess process;
        public readonly PlayerIndex PlayerIndex;

        public GamePadState PreviousState;

        public GamePadState CurrentState;

        public bool Attached;

        public bool HadInputThisFrame;

        private float rumbleStrength;

        private float rumbleTime;

        public int DPadHorizontal
        {
            get
            {
                if (CurrentState.DPad.Right != ButtonState.Pressed)
                {
                    if (CurrentState.DPad.Left != ButtonState.Pressed) return 0;

                    return -1;
                }

                return 1;
            }
        }

        public int DPadVertical
        {
            get
            {
                if (CurrentState.DPad.Down != ButtonState.Pressed)
                {
                    if (CurrentState.DPad.Up != ButtonState.Pressed) return 0;

                    return -1;
                }

                return 1;
            }
        }

        public Vector2 DPad => new(DPadHorizontal, DPadVertical);

        public bool DPadLeftCheck => CurrentState.DPad.Left == ButtonState.Pressed;

        public bool DPadLeftPressed
        {
            get
            {
                if (CurrentState.DPad.Left == ButtonState.Pressed)
                    return PreviousState.DPad.Left == ButtonState.Released;

                return false;
            }
        }

        public bool DPadLeftReleased
        {
            get
            {
                if (CurrentState.DPad.Left == ButtonState.Released)
                    return PreviousState.DPad.Left == ButtonState.Pressed;

                return false;
            }
        }

        public bool DPadRightCheck => CurrentState.DPad.Right == ButtonState.Pressed;

        public bool DPadRightPressed
        {
            get
            {
                if (CurrentState.DPad.Right == ButtonState.Pressed)
                    return PreviousState.DPad.Right == ButtonState.Released;

                return false;
            }
        }

        public bool DPadRightReleased
        {
            get
            {
                if (CurrentState.DPad.Right == ButtonState.Released)
                    return PreviousState.DPad.Right == ButtonState.Pressed;

                return false;
            }
        }

        public bool DPadUpCheck => CurrentState.DPad.Up == ButtonState.Pressed;

        public bool DPadUpPressed
        {
            get
            {
                if (CurrentState.DPad.Up == ButtonState.Pressed) return PreviousState.DPad.Up == ButtonState.Released;

                return false;
            }
        }

        public bool DPadUpReleased
        {
            get
            {
                if (CurrentState.DPad.Up == ButtonState.Released) return PreviousState.DPad.Up == ButtonState.Pressed;

                return false;
            }
        }

        public bool DPadDownCheck => CurrentState.DPad.Down == ButtonState.Pressed;

        public bool DPadDownPressed
        {
            get
            {
                if (CurrentState.DPad.Down == ButtonState.Pressed)
                    return PreviousState.DPad.Down == ButtonState.Released;

                return false;
            }
        }

        public bool DPadDownReleased
        {
            get
            {
                if (CurrentState.DPad.Down == ButtonState.Released)
                    return PreviousState.DPad.Down == ButtonState.Pressed;

                return false;
            }
        }

        public SourceGamePadData(int playerIndex, SourceFnaGamePadProcess gamepads, SourceMInputProcess process)
        {
            this.gamepads = gamepads;
            this.process = process;
            PlayerIndex = (PlayerIndex)Calc.Clamp(playerIndex, 0, 3);
        }

        public bool HasAnyInput()
        {
            if (!PreviousState.IsConnected && CurrentState.IsConnected) return true;

            if (PreviousState.Buttons != CurrentState.Buttons) return true;

            if (PreviousState.DPad != CurrentState.DPad) return true;

            if (CurrentState.Triggers.Left > 0.01f || CurrentState.Triggers.Right > 0.01f) return true;

            if (process.Engine.VectorArithmetic.Length(CurrentState.ThumbSticks.Left) > 0.01f ||
                process.Engine.VectorArithmetic.Length(CurrentState.ThumbSticks.Right) > 0.01f)
                return true;

            return false;
        }

        public void Update()
        {
            PreviousState = CurrentState;
            CurrentState = gamepads.GetState(PlayerIndex);
            if (!Attached && CurrentState.IsConnected) process.IsControllerFocused = true;

            Attached = CurrentState.IsConnected;
            if (rumbleTime > 0f)
            {
                rumbleTime -= process.Engine.DeltaTime;
                if (rumbleTime <= 0f) gamepads.SetVibration(PlayerIndex, 0f, 0f);
            }
        }

        public void UpdateNull()
        {
            PreviousState = CurrentState;
            CurrentState = default;
            Attached = gamepads.GetState(PlayerIndex).IsConnected;
            if (rumbleTime > 0f) rumbleTime -= process.Engine.DeltaTime;

            gamepads.SetVibration(PlayerIndex, 0f, 0f);
        }

        public void Rumble(float strength, float time)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (rumbleTime <= 0f || strength > rumbleStrength || (strength == rumbleStrength && time > rumbleTime))
            {
                gamepads.SetVibration(PlayerIndex, strength, strength);
                rumbleStrength = strength;
                rumbleTime = time;
            }
        }

        public void StopRumble()
        {
            gamepads.SetVibration(PlayerIndex, 0f, 0f);
            rumbleTime = 0f;
        }

        public bool Check(Buttons button)
        {
            if (process.Disabled) return false;

            return CurrentState.IsButtonDown(button);
        }

        public bool Pressed(Buttons button)
        {
            if (process.Disabled) return false;

            if (CurrentState.IsButtonDown(button)) return PreviousState.IsButtonUp(button);

            return false;
        }

        public bool Released(Buttons button)
        {
            if (process.Disabled) return false;

            if (CurrentState.IsButtonUp(button)) return PreviousState.IsButtonDown(button);

            return false;
        }

        public bool Check(Buttons buttonA, Buttons buttonB)
        {
            if (!Check(buttonA)) return Check(buttonB);

            return true;
        }

        public bool Pressed(Buttons buttonA, Buttons buttonB)
        {
            if (!Pressed(buttonA)) return Pressed(buttonB);

            return true;
        }

        public bool Released(Buttons buttonA, Buttons buttonB)
        {
            if (!Released(buttonA)) return Released(buttonB);

            return true;
        }

        public bool Check(Buttons buttonA, Buttons buttonB, Buttons buttonC)
        {
            if (!Check(buttonA) && !Check(buttonB)) return Check(buttonC);

            return true;
        }

        public bool Pressed(Buttons buttonA, Buttons buttonB, Buttons buttonC)
        {
            if (!Pressed(buttonA) && !Pressed(buttonB)) return Check(buttonC);

            return true;
        }

        public bool Released(Buttons buttonA, Buttons buttonB, Buttons buttonC)
        {
            if (!Released(buttonA) && !Released(buttonB)) return Check(buttonC);

            return true;
        }

        public Vector2 GetLeftStick()
        {
            var left = CurrentState.ThumbSticks.Left;
            left.Y = 0f - left.Y;
            return left;
        }

        public Vector2 GetLeftStick(float deadzone)
        {
            var result = CurrentState.ThumbSticks.Left;
            if (result.LengthSquared() < deadzone * deadzone)
                result = Vector2.Zero;
            else
                result.Y = 0f - result.Y;

            return result;
        }

        public Vector2 GetRightStick()
        {
            var right = CurrentState.ThumbSticks.Right;
            right.Y = 0f - right.Y;
            return right;
        }

        public Vector2 GetRightStick(float deadzone)
        {
            var result = CurrentState.ThumbSticks.Right;
            if (result.LengthSquared() < deadzone * deadzone)
                result = Vector2.Zero;
            else
                result.Y = 0f - result.Y;

            return result;
        }

        public bool LeftStickLeftCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X <= 0f - deadzone;
        }

        public bool LeftStickLeftPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.X <= 0f - deadzone)
                return PreviousState.ThumbSticks.Left.X > 0f - deadzone;

            return false;
        }

        public bool LeftStickLeftReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.X > 0f - deadzone)
                return PreviousState.ThumbSticks.Left.X <= 0f - deadzone;

            return false;
        }

        public bool LeftStickRightCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X >= deadzone;
        }

        public bool LeftStickRightPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.X >= deadzone) return PreviousState.ThumbSticks.Left.X < deadzone;

            return false;
        }

        public bool LeftStickRightReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.X < deadzone) return PreviousState.ThumbSticks.Left.X >= deadzone;

            return false;
        }

        public bool LeftStickDownCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y <= 0f - deadzone;
        }

        public bool LeftStickDownPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.Y <= 0f - deadzone)
                return PreviousState.ThumbSticks.Left.Y > 0f - deadzone;

            return false;
        }

        public bool LeftStickDownReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.Y > 0f - deadzone)
                return PreviousState.ThumbSticks.Left.Y <= 0f - deadzone;

            return false;
        }

        public bool LeftStickUpCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y >= deadzone;
        }

        public bool LeftStickUpPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.Y >= deadzone) return PreviousState.ThumbSticks.Left.Y < deadzone;

            return false;
        }

        public bool LeftStickUpReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Left.Y < deadzone) return PreviousState.ThumbSticks.Left.Y >= deadzone;

            return false;
        }

        public float LeftStickHorizontal(float deadzone)
        {
            var x = CurrentState.ThumbSticks.Left.X;
            if (Math.Abs(x) < deadzone) return 0f;

            return x;
        }

        public float LeftStickVertical(float deadzone)
        {
            var y = CurrentState.ThumbSticks.Left.Y;
            if (Math.Abs(y) < deadzone) return 0f;

            return 0f - y;
        }

        public bool RightStickLeftCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X <= 0f - deadzone;
        }

        public bool RightStickLeftPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.X <= 0f - deadzone)
                return PreviousState.ThumbSticks.Right.X > 0f - deadzone;

            return false;
        }

        public bool RightStickLeftReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.X > 0f - deadzone)
                return PreviousState.ThumbSticks.Right.X <= 0f - deadzone;

            return false;
        }

        public bool RightStickRightCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X >= deadzone;
        }

        public bool RightStickRightPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.X >= deadzone) return PreviousState.ThumbSticks.Right.X < deadzone;

            return false;
        }

        public bool RightStickRightReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.X < deadzone) return PreviousState.ThumbSticks.Right.X >= deadzone;

            return false;
        }

        public bool RightStickDownCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y <= 0f - deadzone;
        }

        public bool RightStickDownPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.Y <= 0f - deadzone)
                return PreviousState.ThumbSticks.Right.Y > 0f - deadzone;

            return false;
        }

        public bool RightStickDownReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.Y > 0f - deadzone)
                return PreviousState.ThumbSticks.Right.Y <= 0f - deadzone;

            return false;
        }

        public bool RightStickUpCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y >= deadzone;
        }

        public bool RightStickUpPressed(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.Y >= deadzone) return PreviousState.ThumbSticks.Right.Y < deadzone;

            return false;
        }

        public bool RightStickUpReleased(float deadzone)
        {
            if (CurrentState.ThumbSticks.Right.Y < deadzone) return PreviousState.ThumbSticks.Right.Y >= deadzone;

            return false;
        }

        public float RightStickHorizontal(float deadzone)
        {
            var x = CurrentState.ThumbSticks.Right.X;
            if (Math.Abs(x) < deadzone) return 0f;

            return x;
        }

        public float RightStickVertical(float deadzone)
        {
            var y = CurrentState.ThumbSticks.Right.Y;
            if (Math.Abs(y) < deadzone) return 0f;

            return 0f - y;
        }

        public bool LeftTriggerCheck(float threshold)
        {
            if (process.Disabled) return false;

            return CurrentState.Triggers.Left >= threshold;
        }

        public bool LeftTriggerPressed(float threshold)
        {
            if (process.Disabled) return false;

            if (CurrentState.Triggers.Left >= threshold) return PreviousState.Triggers.Left < threshold;

            return false;
        }

        public bool LeftTriggerReleased(float threshold)
        {
            if (process.Disabled) return false;

            if (CurrentState.Triggers.Left < threshold) return PreviousState.Triggers.Left >= threshold;

            return false;
        }

        public bool RightTriggerCheck(float threshold)
        {
            if (process.Disabled) return false;

            return CurrentState.Triggers.Right >= threshold;
        }

        public bool RightTriggerPressed(float threshold)
        {
            if (process.Disabled) return false;

            if (CurrentState.Triggers.Right >= threshold) return PreviousState.Triggers.Right < threshold;

            return false;
        }

        public bool RightTriggerReleased(float threshold)
        {
            if (process.Disabled) return false;

            if (CurrentState.Triggers.Right < threshold) return PreviousState.Triggers.Right >= threshold;

            return false;
        }

        public float Axis(Buttons button, float threshold)
        {
            if (process.Disabled) return 0f;

            switch (button)
            {
                case Buttons.DPadUp:
                case Buttons.DPadDown:
                case Buttons.DPadLeft:
                case Buttons.DPadRight:
                case Buttons.Start:
                case Buttons.Back:
                case Buttons.LeftStick:
                case Buttons.RightStick:
                case Buttons.LeftShoulder:
                case Buttons.RightShoulder:
                case Buttons.A:
                case Buttons.B:
                case Buttons.X:
                case Buttons.Y:
                    if (Check(button)) return 1f;

                    break;
                case Buttons.RightTrigger:
                    if (CurrentState.Triggers.Right >= threshold) return CurrentState.Triggers.Right;

                    break;
                case Buttons.LeftTrigger:
                    if (CurrentState.Triggers.Left >= threshold) return CurrentState.Triggers.Left;

                    break;
                case Buttons.LeftThumbstickUp:
                    if (CurrentState.ThumbSticks.Left.Y >= threshold) return CurrentState.ThumbSticks.Left.Y;

                    break;
                case Buttons.LeftThumbstickDown:
                    if (CurrentState.ThumbSticks.Left.Y <= 0f - threshold) return 0f - CurrentState.ThumbSticks.Left.Y;

                    break;
                case Buttons.LeftThumbstickRight:
                    if (CurrentState.ThumbSticks.Left.X >= threshold) return CurrentState.ThumbSticks.Left.X;

                    break;
                case Buttons.LeftThumbstickLeft:
                    if (CurrentState.ThumbSticks.Left.X <= 0f - threshold) return 0f - CurrentState.ThumbSticks.Left.X;

                    break;
                case Buttons.RightThumbstickUp:
                    if (CurrentState.ThumbSticks.Right.Y >= threshold) return CurrentState.ThumbSticks.Right.Y;

                    break;
                case Buttons.RightThumbstickDown:
                    if (CurrentState.ThumbSticks.Right.Y <= 0f - threshold)
                        return 0f - CurrentState.ThumbSticks.Right.Y;

                    break;
                case Buttons.RightThumbstickRight:
                    if (CurrentState.ThumbSticks.Right.X >= threshold) return CurrentState.ThumbSticks.Right.X;

                    break;
                case Buttons.RightThumbstickLeft:
                    if (CurrentState.ThumbSticks.Right.X <= 0f - threshold)
                        return 0f - CurrentState.ThumbSticks.Right.X;

                    break;
            }

            return 0f;
        }

        public bool Check(Buttons button, float threshold)
        {
            if (process.Disabled) return false;

            switch (button)
            {
                case Buttons.DPadUp:
                case Buttons.DPadDown:
                case Buttons.DPadLeft:
                case Buttons.DPadRight:
                case Buttons.Start:
                case Buttons.Back:
                case Buttons.LeftStick:
                case Buttons.RightStick:
                case Buttons.LeftShoulder:
                case Buttons.RightShoulder:
                case Buttons.A:
                case Buttons.B:
                case Buttons.X:
                case Buttons.Y:
                    if (Check(button)) return true;

                    break;
                case Buttons.RightTrigger:
                    if (RightTriggerCheck(threshold)) return true;

                    break;
                case Buttons.LeftTrigger:
                    if (LeftTriggerCheck(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickUp:
                    if (LeftStickUpCheck(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickDown:
                    if (LeftStickDownCheck(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickRight:
                    if (LeftStickRightCheck(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickLeft:
                    if (LeftStickLeftCheck(threshold)) return true;

                    break;
                case Buttons.RightThumbstickUp:
                    if (RightStickUpCheck(threshold)) return true;

                    break;
                case Buttons.RightThumbstickDown:
                    if (RightStickDownCheck(threshold)) return true;

                    break;
                case Buttons.RightThumbstickRight:
                    if (RightStickRightCheck(threshold)) return true;

                    break;
                case Buttons.RightThumbstickLeft:
                    if (RightStickLeftCheck(threshold)) return true;

                    break;
            }

            return false;
        }

        public bool Pressed(Buttons button, float threshold)
        {
            if (process.Disabled) return false;

            switch (button)
            {
                case Buttons.DPadUp:
                case Buttons.DPadDown:
                case Buttons.DPadLeft:
                case Buttons.DPadRight:
                case Buttons.Start:
                case Buttons.Back:
                case Buttons.LeftStick:
                case Buttons.RightStick:
                case Buttons.LeftShoulder:
                case Buttons.RightShoulder:
                case Buttons.A:
                case Buttons.B:
                case Buttons.X:
                case Buttons.Y:
                    if (Pressed(button)) return true;

                    break;
                case Buttons.RightTrigger:
                    if (RightTriggerPressed(threshold)) return true;

                    break;
                case Buttons.LeftTrigger:
                    if (LeftTriggerPressed(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickUp:
                    if (LeftStickUpPressed(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickDown:
                    if (LeftStickDownPressed(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickRight:
                    if (LeftStickRightPressed(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickLeft:
                    if (LeftStickLeftPressed(threshold)) return true;

                    break;
                case Buttons.RightThumbstickUp:
                    if (RightStickUpPressed(threshold)) return true;

                    break;
                case Buttons.RightThumbstickDown:
                    if (RightStickDownPressed(threshold)) return true;

                    break;
                case Buttons.RightThumbstickRight:
                    if (RightStickRightPressed(threshold)) return true;

                    break;
                case Buttons.RightThumbstickLeft:
                    if (RightStickLeftPressed(threshold)) return true;

                    break;
            }

            return false;
        }

        public bool Released(Buttons button, float threshold)
        {
            if (process.Disabled) return false;

            switch (button)
            {
                case Buttons.DPadUp:
                case Buttons.DPadDown:
                case Buttons.DPadLeft:
                case Buttons.DPadRight:
                case Buttons.Start:
                case Buttons.Back:
                case Buttons.LeftStick:
                case Buttons.RightStick:
                case Buttons.LeftShoulder:
                case Buttons.RightShoulder:
                case Buttons.A:
                case Buttons.B:
                case Buttons.X:
                case Buttons.Y:
                    if (Released(button)) return true;

                    break;
                case Buttons.RightTrigger:
                    if (RightTriggerReleased(threshold)) return true;

                    break;
                case Buttons.LeftTrigger:
                    if (LeftTriggerReleased(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickUp:
                    if (LeftStickUpReleased(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickDown:
                    if (LeftStickDownReleased(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickRight:
                    if (LeftStickRightReleased(threshold)) return true;

                    break;
                case Buttons.LeftThumbstickLeft:
                    if (LeftStickLeftReleased(threshold)) return true;

                    break;
                case Buttons.RightThumbstickUp:
                    if (RightStickUpReleased(threshold)) return true;

                    break;
                case Buttons.RightThumbstickDown:
                    if (RightStickDownReleased(threshold)) return true;

                    break;
                case Buttons.RightThumbstickRight:
                    if (RightStickRightReleased(threshold)) return true;

                    break;
                case Buttons.RightThumbstickLeft:
                    if (RightStickLeftReleased(threshold)) return true;

                    break;
            }

            return false;
        }
    }
}
