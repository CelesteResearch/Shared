using JetBrains.Annotations;
using MathHelper = Celeste.Core.Mathematics.ScalarMath;
using GamePad = Celeste.Input.Devices.GamePads.SourceGamePadArithmetic;

namespace Celeste.Input.Devices.GamePads
{
    public struct SourceGamePadTriggers
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float left;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float right;

        public float Left => left;

        public float Right => right;

        public SourceGamePadTriggers(float leftTrigger, float rightTrigger)
        {
            left = MathHelper.Clamp(leftTrigger, 0f, 1f);
            right = MathHelper.Clamp(rightTrigger, 0f, 1f);
        }

        internal SourceGamePadTriggers(float leftTrigger, float rightTrigger, SourceGamePadDeadZone deadZoneMode)
        {
            if (deadZoneMode == SourceGamePadDeadZone.None)
            {
                left = MathHelper.Clamp(leftTrigger, 0f, 1f);
                right = MathHelper.Clamp(rightTrigger, 0f, 1f);
            }
            else
            {
                left = MathHelper.Clamp(GamePad.ExcludeAxisDeadZone(leftTrigger, 0.11764706f), 0f, 1f);
                right = MathHelper.Clamp(GamePad.ExcludeAxisDeadZone(rightTrigger, 0.11764706f), 0f, 1f);
            }
        }

        public static bool operator ==(SourceGamePadTriggers left, SourceGamePadTriggers right)
        {
            if (SourceGamePadArithmetic.WithinEpsilon(left.left, right.left))
                return SourceGamePadArithmetic.WithinEpsilon(left.right, right.right);

            return false;
        }

        public static bool operator !=(SourceGamePadTriggers left, SourceGamePadTriggers right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is SourceGamePadTriggers) return this == (SourceGamePadTriggers)obj;

            return false;
        }

        public override int GetHashCode()
        {
            return Left.GetHashCode() + Right.GetHashCode();
        }
    }
}
