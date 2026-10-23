using System.Numerics;

namespace Celeste.Graphics.Effects.Sampling
{
    public readonly struct TextureKernelTap(Vector2 offset, float weight)
    {
        public readonly Vector2 Offset = offset;
        public readonly float Weight = weight;
    }
}
