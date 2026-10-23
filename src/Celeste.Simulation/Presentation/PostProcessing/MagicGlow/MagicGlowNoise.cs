using System;

namespace Celeste.Simulation.Presentation.PostProcessing.MagicGlow
{
    public sealed class MagicGlowNoise
    {
        public const int Width = 128, Height = 128;
        public readonly byte[] Rgba = new byte[Width * Height * 4];

        public MagicGlowNoise(Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            // GFX.Load consumes three NextFloat calls even though alpha is zero.
            for (var i = 0; i < Rgba.Length; i += 4)
            for (var channel = 0; channel < 3; channel++)
                Rgba[i + channel] = (byte)Math.Round((float)random.NextDouble() * 255f);
        }
    }
}
