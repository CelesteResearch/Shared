using Celeste.Core.Mathematics;

namespace Celeste.Input.Devices.GamePads
{
    public static class SourceGamePadArithmetic
    {
        public static float ExcludeAxisDeadZone(float value, float deadZone)
        {
            if (value < 0f - deadZone)
            {
                value += deadZone;
            }
            else
            {
                if (!(value > deadZone)) return 0f;
                value -= deadZone;
            }

            return value / (1f - deadZone);
        }

        public static bool WithinEpsilon(float a, float b)
        {
            return SourceFloatEqualityArithmetic.WithinEpsilon(a, b);
        }
    }
}
