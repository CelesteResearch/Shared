using System.Numerics;

namespace Celeste.Graphics.Rendering.Effects
{
    public interface ISourceEffectMatrices
    {
        Matrix4x4 Projection { get; set; }

        Matrix4x4 View { get; set; }

        Matrix4x4 World { get; set; }
    }
}
