using System.Numerics;

namespace Celeste.Graphics.Rendering.Effects
{
    public interface ISourceEffectFog
    {
        Vector3 FogColor { get; set; }

        bool FogEnabled { get; set; }

        float FogEnd { get; set; }

        float FogStart { get; set; }
    }
}
