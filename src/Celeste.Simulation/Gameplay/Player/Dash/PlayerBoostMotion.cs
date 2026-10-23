using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public static class PlayerBoostMotion
    {
        public static Vector2 ApproachPosition(ISourceEngineContext engine, Vector2 exactPosition,
            Vector2 boostTarget, Vector2 colliderCenter, Vector2 scaledAim)
        {
            var target = boostTarget - colliderCenter + scaledAim;
            var maximum = 80f * engine.DeltaTime;
            return ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(exactPosition, target, maximum);
        }

        public static Vector2 ReleasePosition(Vector2 boostTarget, Vector2 colliderCenter)
        {
            var target = boostTarget - colliderCenter;
            return new((float)Math.Floor(target.X), (float)Math.Floor(target.Y));
        }
    }
}
