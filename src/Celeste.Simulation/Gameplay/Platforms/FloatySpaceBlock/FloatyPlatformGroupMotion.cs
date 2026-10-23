using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock
{
    public static class FloatyPlatformGroupMotion
    {
        public static void Move<TTarget>(ref Dictionary<SourcePlatformEntityState, Vector2> moves, float sine,
            Vector2 displacement, TTarget target) where TTarget : struct, IFloatyPlatformTarget
        {
            for (int i = 0; i < 2; i++)
                foreach (KeyValuePair<SourcePlatformEntityState, Vector2> move in moves)
                {
                    SourcePlatformEntityState platform = move.Key;
                    bool hasPlayer = false;
                    SourceJumpThruEntityState jumpThru = platform as SourceJumpThruEntityState;
                    SourceSolidEntityState solid = platform as SourceSolidEntityState;
                    if ((jumpThru != null && jumpThru.HasRider()) || (solid != null && solid.HasRider()))
                        hasPlayer = true;
                    if ((hasPlayer || i != 0) && (!hasPlayer || i != 1))
                    {
                        Vector2 value = move.Value;
                        float y = target.GetTargetY(value.Y, sine, displacement.Y);
                        platform.MoveToY(y);
                        platform.MoveToX(value.X + displacement.X);
                    }
                }
        }
    }
}
