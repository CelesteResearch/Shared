using System.Numerics;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using ButtonState = Celeste.Input.Devices.GamePads.SourceButtonState;
using MathHelper = Celeste.Core.Mathematics.ScalarMath;
using GamePad = Celeste.Input.Devices.GamePads.SourceGamePadArithmetic;

namespace Celeste.Input.Devices.GamePads
{
    public struct SourceGamePadThumbSticks
    {
        private Vector2 left;

        private Vector2 right;

        public Vector2 Left => left;

        public Vector2 Right => right;

        public SourceGamePadThumbSticks(Vector2 leftPosition, Vector2 rightPosition)
        {
            left = leftPosition;
            right = rightPosition;
            ApplySquareClamp();
        }

        internal SourceGamePadThumbSticks(Vector2 leftPosition, Vector2 rightPosition,
            SourceGamePadDeadZone deadZoneMode,
            Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic)
        {
            left = leftPosition;
            right = rightPosition;
            ApplyDeadZone(deadZoneMode, arithmetic);
            if (deadZoneMode == SourceGamePadDeadZone.Circular)
            {
                ApplyCircularClamp(arithmetic);
            }
            else
            {
                ApplySquareClamp();
            }
        }

        private void ApplyDeadZone(SourceGamePadDeadZone dz,
            Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic)
        {
            switch (dz)
            {
                case SourceGamePadDeadZone.IndependentAxes:
                    left.X = GamePad.ExcludeAxisDeadZone(left.X, 0.23953247f);
                    left.Y = GamePad.ExcludeAxisDeadZone(left.Y, 0.23953247f);
                    right.X = GamePad.ExcludeAxisDeadZone(right.X, 0.26516724f);
                    right.Y = GamePad.ExcludeAxisDeadZone(right.Y, 0.26516724f);
                    break;
                case SourceGamePadDeadZone.Circular:
                    left = ExcludeCircularDeadZone(left, 0.23953247f, arithmetic);
                    right = ExcludeCircularDeadZone(right, 0.26516724f, arithmetic);
                    break;
                case SourceGamePadDeadZone.None:
                    break;
            }
        }

        private void ApplySquareClamp()
        {
            left.X = MathHelper.Clamp(left.X, -1f, 1f);
            left.Y = MathHelper.Clamp(left.Y, -1f, 1f);
            right.X = MathHelper.Clamp(right.X, -1f, 1f);
            right.Y = MathHelper.Clamp(right.Y, -1f, 1f);
        }

        private void ApplyCircularClamp(Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic)
        {
            if (arithmetic.LengthSquared(left) > 1f)
            {
                left = arithmetic.Normalize(left);
            }

            if (arithmetic.LengthSquared(right) > 1f)
            {
                right = arithmetic.Normalize(right);
            }
        }

        private static Vector2 ExcludeCircularDeadZone(Vector2 value, float deadZone,
            Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic)
        {
            float num = arithmetic.Length(value);
            if (num <= deadZone)
            {
                return Vector2.Zero;
            }

            float num2 = (num - deadZone) / (1f - deadZone);
            return value * (num2 / num);
        }

        public static bool operator ==(SourceGamePadThumbSticks left, SourceGamePadThumbSticks right)
        {
            if ((left.left.X == right.left.X && left.left.Y == right.left.Y))
            {
                return (left.right.X == right.right.X && left.right.Y == right.right.Y);
            }

            return false;
        }

        public static bool operator !=(SourceGamePadThumbSticks left, SourceGamePadThumbSticks right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is SourceGamePadThumbSticks)
            {
                return this == (SourceGamePadThumbSticks)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (Left.X.GetHashCode() + Left.Y.GetHashCode()) + 37 * (Right.X.GetHashCode() + Right.Y.GetHashCode());
        }
    }
}
