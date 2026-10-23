using System.Numerics;
using Celeste.Graphics.Content.Textures;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public interface IDustEdgesRenderDevice
    {
        object DustEffect { get; }
        void SetTarget(object target);
        void Clear(Vector4 color);
        void SetNoiseTextures(ISourceDataTextureResource from, ISourceDataTextureResource to);

        void ConfigureDustEffect(Vector3[] colors, float noiseEase, Vector2 fromPosition,
            Vector2 toPosition, Vector2 pixel);
    }
}
