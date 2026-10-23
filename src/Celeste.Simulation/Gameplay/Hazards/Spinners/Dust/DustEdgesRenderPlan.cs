using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public sealed class DustEdgesRenderPlan
    {
        public readonly List<ImagePlacement> Dust = [];

        public DustNoiseTexture NoiseFrom, NoiseTo;
        public Vector3[] Colors;
        public float NoiseEase;
        public Vector2 NoiseFromPosition, NoiseToPosition;

        public readonly Vector2 Pixel = new(.003125f, 1f / 180f);
        // Clear TempA; PointClamp/AlphaBlend/Camera; draw Dust in order; End.
        // Clear ResortDust; textures 1/2; FxDust; PointClamp/AlphaBlend/Identity; draw TempA; End.
    }
}
