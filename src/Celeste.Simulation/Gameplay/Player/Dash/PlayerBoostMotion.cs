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
            Vector2 target = boostTarget - colliderCenter + scaledAim;
            float maximum = 80f * engine.DeltaTime;
            return ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(exactPosition, target, maximum);
        }

        public static Vector2 ReleasePosition(Vector2 boostTarget, Vector2 colliderCenter)
        {
            Vector2 target = boostTarget - colliderCenter;
            return new Vector2((float)Math.Floor(target.X), (float)Math.Floor(target.Y));
        }
    }
}
