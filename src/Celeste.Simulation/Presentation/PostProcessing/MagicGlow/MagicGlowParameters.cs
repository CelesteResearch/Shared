using System.Numerics;

namespace Celeste.Simulation.Presentation.PostProcessing.MagicGlow
{
    public readonly struct MagicGlowParameters
    {
        public readonly Vector2 Pixel;
        public readonly float NoiseEase, Direction;

        public MagicGlowParameters(int width, int height, float noiseEase, float direction)
        {
            Pixel = new Vector2(1f / width, 1f / height) * 3f;
            NoiseEase = noiseEase * .05f;
            Direction = -direction;
        }
    }
}
