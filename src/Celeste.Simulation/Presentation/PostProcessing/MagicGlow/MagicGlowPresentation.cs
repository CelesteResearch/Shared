using System;
using System.Numerics;

namespace Celeste.Simulation.Presentation.PostProcessing.MagicGlow
{
    public static class MagicGlowPresentation
    {
        // Installed MagicGlow.xnb ps_2_0 accumulation order, including all
        // seventeen taps and RGB noise whose alpha is intentionally zero.
        static readonly float[] weights =
            { .94f, .88f, .82f, .76f, .70f, .64f, .58f, .52f, .46f, .40f, .34f, .28f, .22f, .16f, .10f, .04f };

        public static Vector4 Evaluate(Vector2 uv,
            global::Celeste.Simulation.Presentation.PostProcessing.MagicGlow.MagicGlowParameters p,
            Func<Vector2, Vector4> linearClampSource, Func<Vector2, Vector4> linearWrapNoise)
        {
            var noise = linearWrapNoise(new Vector2(uv.X, uv.Y * .5f + p.NoiseEase));
            var point = new Vector2((noise.Y - .5f) * p.Pixel.X * 2f + uv.X,
                (noise.Z - .5f) * p.Pixel.Y * 2f + uv.Y);
            float distance = p.Pixel.Y * p.Direction;
            var result = linearClampSource(point);
            for (int i = 0; i < weights.Length; i++)
                result = linearClampSource(point + new Vector2(0, distance * (i + 1))) * weights[i] + result;
            return result * noise.X * .5f;
        }
    }
}
