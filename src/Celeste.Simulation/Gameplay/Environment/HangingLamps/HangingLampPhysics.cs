using System;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Gameplay.Environment.HangingLamps
{
    public static class HangingLampPhysics
    {
        public static void Advance(ref float speed, ref float rotation, ref float soundDelay,
            ISourceEngineContext engine,
            bool touchingPlayer, float playerSpeedX, float playerRelativeY, int length, float? inverseWeight,
            ISourceExtremaArithmetic extrema, Action playSound)
        {
            ApplyContact(ref speed, ref soundDelay, touchingPlayer, playerSpeedX, playerRelativeY, length,
                inverseWeight, playSound);
            AdvanceSwing(ref speed, ref rotation, ref soundDelay, engine, extrema, playSound);
        }

        public static bool AdvanceWhenMoving(ref float speed, ref float rotation, ref float soundDelay,
            ISourceEngineContext engine,
            bool touchingPlayer, float playerSpeedX, float playerRelativeY, int length, float? inverseWeight,
            ISourceExtremaArithmetic extrema, Action playSound)
        {
            ApplyContact(ref speed, ref soundDelay, touchingPlayer, playerSpeedX, playerRelativeY, length,
                inverseWeight, playSound);
            if (rotation == 0f && speed == 0f) return false;
            AdvanceSwing(ref speed, ref rotation, ref soundDelay, engine, extrema, playSound);
            return true;
        }

        private static void ApplyContact(ref float speed, ref float soundDelay, bool touchingPlayer,
            float playerSpeedX, float playerRelativeY, int length, float? inverseWeight, Action playSound)
        {
            if (touchingPlayer)
            {
                speed = (0f - playerSpeedX) * .005f * (playerRelativeY / length);
                if (inverseWeight.HasValue) speed *= inverseWeight.Value;
                if (Math.Abs(speed) < .1f)
                {
                    speed = 0f;
                }
                else if (soundDelay <= 0f)
                {
                    playSound();
                    soundDelay = .25f;
                }
            }
        }

        private static void AdvanceSwing(ref float speed, ref float rotation, ref float soundDelay,
            ISourceEngineContext engine, ISourceExtremaArithmetic extrema, Action playSound)
        {
            var acceleration = Math.Sign(rotation) == Math.Sign(speed) ? 8f : 6f;
            if (Math.Abs(rotation) < .5f) acceleration *= .5f;
            if (Math.Abs(rotation) < .25f) acceleration *= .5f;
            var previousRotation = rotation;
            speed += -Math.Sign(rotation) * acceleration * engine.DeltaTime;
            rotation += speed * engine.DeltaTime;
            rotation = ScalarMath.Clamp(rotation, -.4f, .4f, extrema);
            if (Math.Abs(rotation) < .02f && Math.Abs(speed) < .2f)
            {
                rotation = speed = 0f;
            }
            else if (Math.Sign(rotation) != Math.Sign(previousRotation) && soundDelay <= 0f && Math.Abs(speed) > .5f)
            {
                playSound();
                soundDelay = .25f;
            }
        }
    }
}
