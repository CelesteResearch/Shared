using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;

namespace Celeste.Graphics.Display.Colors
{
    public static class SourceColorInterpolation
    {
        public static PackedColor Lerp(PackedColor first, PackedColor second, float amount,
            ISourceScalarArithmetic arithmetic)
        {
            return LerpChannels(first.R, first.G, first.B, first.A, second.R, second.G, second.B,
                second.A, amount, arithmetic);
        }

        // This input form is for stored Color bytes already normalized for a render payload.
        // Preserve the existing channel decoding; actual source Color fields use the packed overload.
        public static Vector4 Lerp(Vector4 first, Vector4 second, float amount,
            ISourceScalarArithmetic arithmetic)
        {
            return LerpChannels(unchecked((int)Math.Round(first.X * 255f)), unchecked((int)Math.Round(first.Y * 255f)),
                unchecked((int)Math.Round(first.Z * 255f)), unchecked((int)Math.Round(first.W * 255f)),
                unchecked((int)Math.Round(second.X * 255f)), unchecked((int)Math.Round(second.Y * 255f)),
                unchecked((int)Math.Round(second.Z * 255f)), unchecked((int)Math.Round(second.W * 255f)),
                amount, arithmetic).ToVector4();
        }

        private static PackedColor LerpChannels(int firstR, int firstG, int firstB, int firstA,
            int secondR, int secondG, int secondB, int secondA, float amount,
            ISourceScalarArithmetic arithmetic)
        {
            amount = ScalarMath.Clamp(amount, 0f, 1f);
            return new(unchecked((int)arithmetic.Lerp(firstR, secondR, amount)),
                unchecked((int)arithmetic.Lerp(firstG, secondG, amount)),
                unchecked((int)arithmetic.Lerp(firstB, secondB, amount)),
                unchecked((int)arithmetic.Lerp(firstA, secondA, amount)));
        }
    }
}
