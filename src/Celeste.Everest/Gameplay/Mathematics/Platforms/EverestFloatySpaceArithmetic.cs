using System;
using System.Runtime.CompilerServices;
using Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock;

namespace Celeste.Everest.Gameplay.Mathematics.Platforms
{
    public sealed class EverestFloatySpaceArithmetic : IFloatySpaceSinkDistanceArithmetic
    {
        public float GetSine(float phase)
        {
            return (float)(JITBarrier(4f) * Math.Sin(phase));
        }

        public float GetTargetY(float originalY, float eased, float sine, float dashY)
        {
            var y = originalY + JITBarrier(12f) * (double)eased + sine;
            return (float)(y + dashY);
        }

        public float GetTargetY(float originalY, float eased, float sine, float dashY, float sinkDistance)
        {
            var y = originalY + JITBarrier(sinkDistance) * (double)eased + sine;
            return (float)(y + dashY);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static float JITBarrier(float value)
        {
            return value;
        }
    }
}
