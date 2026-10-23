using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Simulation.Presentation.Backdrops.WindDust
{
    public interface IWindDustState<TColor> where TColor : struct
    {
        WindDustParticle<TColor>[] Particles { get; }
        ISourceRandom Random { get; }
        float DeltaTime { get; }
        Vector2 Wind { get; }
        ISourceVectorArithmetic VectorArithmetic { get; }
        TColor NextColor();
        bool Visible { get; }
        float Fade { get; }
        float FadeAlphaMultiplier { get; }
        Vector2 Scale { get; }
        CameraState Camera { get; }
        PackedColor ResolveColor(TColor color);
    }
}
