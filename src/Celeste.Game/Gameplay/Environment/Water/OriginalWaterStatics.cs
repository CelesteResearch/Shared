using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public sealed class OriginalWaterStatics : IOriginalWaterStatics
    {
        public readonly PackedColor FillColor = PackedColor.LightSkyBlue * 0.3f;
        public readonly PackedColor SurfaceColor = PackedColor.LightSkyBlue * 0.8f;
        public readonly PackedColor RayTopColor = PackedColor.LightSkyBlue * 0.6f;
        public readonly Vector2 RayAngle;

        public OriginalWaterStatics(ISourceEngineContext engine)
        {
            RayAngle = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(new Vector2(-4f, 8f));
        }

        PackedColor IOriginalWaterStatics.FillColor => FillColor;
        PackedColor IOriginalWaterStatics.SurfaceColor => SurfaceColor;
        PackedColor IOriginalWaterStatics.RayTopColor => RayTopColor;
        Vector2 IOriginalWaterStatics.RayAngle => RayAngle;
    }
}
