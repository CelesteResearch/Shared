using Celeste.Input.Runtime;
using Celeste.Input.Devices.GamePads;
using System;
using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Input.Devices.Mouse
{
    public class SourceMouseData
    {
        private readonly SourceFnaMouse mouse;
        private readonly SourceMInputProcess mInput;
        protected SourceMInputProcess MInput => mInput;

        public SourceMouseState PreviousState;

        public SourceMouseState CurrentState;

        public bool CheckLeftButton => CurrentState.LeftButton == SourceButtonState.Pressed;

        public bool CheckRightButton => CurrentState.RightButton == SourceButtonState.Pressed;

        public bool CheckMiddleButton => CurrentState.MiddleButton == SourceButtonState.Pressed;

        public bool PressedLeftButton
        {
            get
            {
                if (CurrentState.LeftButton == SourceButtonState.Pressed)
                {
                    return PreviousState.LeftButton == SourceButtonState.Released;
                }

                return false;
            }
        }

        public bool PressedRightButton
        {
            get
            {
                if (CurrentState.RightButton == SourceButtonState.Pressed)
                {
                    return PreviousState.RightButton == SourceButtonState.Released;
                }

                return false;
            }
        }

        public bool PressedMiddleButton
        {
            get
            {
                if (CurrentState.MiddleButton == SourceButtonState.Pressed)
                {
                    return PreviousState.MiddleButton == SourceButtonState.Released;
                }

                return false;
            }
        }

        public bool ReleasedLeftButton
        {
            get
            {
                if (CurrentState.LeftButton == SourceButtonState.Released)
                {
                    return PreviousState.LeftButton == SourceButtonState.Pressed;
                }

                return false;
            }
        }

        public bool ReleasedRightButton
        {
            get
            {
                if (CurrentState.RightButton == SourceButtonState.Released)
                {
                    return PreviousState.RightButton == SourceButtonState.Pressed;
                }

                return false;
            }
        }

        public bool ReleasedMiddleButton
        {
            get
            {
                if (CurrentState.MiddleButton == SourceButtonState.Released)
                {
                    return PreviousState.MiddleButton == SourceButtonState.Pressed;
                }

                return false;
            }
        }

        public int Wheel => CurrentState.ScrollWheelValue;

        public int WheelDelta => unchecked(CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue);

        public bool WasMoved
        {
            get
            {
                if (CurrentState.X == PreviousState.X)
                {
                    return CurrentState.Y != PreviousState.Y;
                }

                return true;
            }
        }

        public float X
        {
            get { return Position.X; }
            set { Position = new Vector2(value, Position.Y); }
        }

        public float Y
        {
            get { return Position.Y; }
            set { Position = new Vector2(Position.X, value); }
        }

        public Vector2 Position
        {
            get
            {
                return SourceVector2Math.Transform(new Vector2(CurrentState.X, CurrentState.Y),
                    SourceMatrixMath.Invert(mInput.Engine.ScreenMatrix));
            }
            set
            {
                Vector2 vector = SourceVector2Math.Transform(value, mInput.Engine.ScreenMatrix);
                mouse.SetPosition((int)Math.Round(vector.X), (int)Math.Round(vector.Y));
            }
        }

        public SourceMouseData(SourceFnaMouse mouse, SourceMInputProcess mInput)
        {
            this.mouse = mouse;
            this.mInput = mInput;
            PreviousState = default(SourceMouseState);
            CurrentState = default(SourceMouseState);
        }

        internal void Update()
        {
            PreviousState = CurrentState;
            CurrentState = mouse.GetState();
        }

        internal void UpdateNull()
        {
            PreviousState = CurrentState;
            CurrentState = default(SourceMouseState);
        }
    }
}
