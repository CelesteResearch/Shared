using System;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock;

namespace Celeste.Game.Gameplay.Mathematics.Platforms
{
    public sealed class OriginalFloatySpaceArithmetic : IFloatySpaceSinkDistanceArithmetic
    {
        public float GetTargetY(float originalY, float eased, float sine, float dashY, float sinkDistance)
        {
            float y = OriginalScalarArithmetic.EvaluateLerp(originalY, originalY + sinkDistance, eased) + sine;
            return y + dashY;
        }

        public float GetSine(float phase) => (float)Math.Sin(phase) * 4f;

        public float GetTargetY(float originalY, float eased, float sine, float dashY)
        {
            float y = OriginalScalarArithmetic.EvaluateLerp(originalY, originalY + 12f, eased) + sine;
            return y + dashY;
        }
    }
}
