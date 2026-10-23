using System;

namespace Celeste.Core.Mathematics
{
    public static class SourceFloatEqualityArithmetic
    {
        internal static readonly float MachineEpsilonFloat = GetMachineEpsilonFloat();

        public static bool WithinEpsilon(float floatA, float floatB)
        {
            return Math.Abs(floatA - floatB) < MachineEpsilonFloat;
        }

        private static float GetMachineEpsilonFloat()
        {
            var num = 1f;
            float num2;
            do
            {
                num *= 0.5f;
                num2 = 1f + num;
            } while (num2 > 1f);

            return num;
        }
    }
}
