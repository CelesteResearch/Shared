using System;
using System.Runtime.CompilerServices;
using Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock;

namespace Celeste.Everest.Gameplay.Mathematics.Platforms
{
    public sealed class EverestFloatySpaceArithmetic : IFloatySpaceSinkDistanceArithmetic
    {
        public float GetSine(float phase) => (float)((double)JITBarrier(4f) * Math.Sin((double)phase));

        public float GetTargetY(float originalY, float eased, float sine, float dashY)
        {
            double y = (double)originalY + (double)JITBarrier(12f) * (double)eased + (double)sine;
            return (float)(y + (double)dashY);
        }

        public float GetTargetY(float originalY, float eased, float sine, float dashY, float sinkDistance)
        {
            double y = (double)originalY + (double)JITBarrier(sinkDistance) * (double)eased + (double)sine;
            return (float)(y + (double)dashY);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static float JITBarrier(float value) => value;
    }
}
