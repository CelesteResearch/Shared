using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Environment.Water;

namespace Celeste.Everest.Gameplay.Environment.Water
{
    public sealed class EverestWaterStatics : IOriginalWaterStatics
    {
        public PackedColor FillColor = PackedColor.LightSkyBlue * 0.3f;
        public PackedColor SurfaceColor = PackedColor.LightSkyBlue * 0.8f;
        public PackedColor RayTopColor = PackedColor.LightSkyBlue * 0.6f;
        public Vector2 RayAngle;

        public EverestWaterStatics(ISourceEngineContext engine)
        {
            RayAngle = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(new Vector2(-4f, 8f));
        }

        PackedColor IOriginalWaterStatics.FillColor => FillColor;
        PackedColor IOriginalWaterStatics.SurfaceColor => SurfaceColor;
        PackedColor IOriginalWaterStatics.RayTopColor => RayTopColor;
        Vector2 IOriginalWaterStatics.RayAngle => RayAngle;
    }
}
