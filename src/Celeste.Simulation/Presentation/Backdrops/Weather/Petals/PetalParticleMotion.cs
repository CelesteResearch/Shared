using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;

namespace Celeste.Simulation.Presentation.Backdrops.Weather.Petals
{
    public static class PetalParticleMotion
    {
        public static void InitializeMotion(ISourceRandom random, out Vector2 position, out float speed, out float spin)
        {
            position = new(SourceRandomMath.Range(random, 0, 352), SourceRandomMath.Range(random, 0, 212));
            speed = SourceRandomMath.Range(random, 6f, 16f);
            spin = SourceRandomMath.Range(random, 8f, 12f) * .2f;
        }

        public static void InitializeRotation(ISourceRandom random, out float rotationCounter, out float maxRotate)
        {
            rotationCounter = SourceRandomMath.NextAngle(random);
            maxRotate = SourceRandomMath.Range(random, .3f, .6f) * ((float)Math.PI / 2f);
        }

        public static void AdvancePosition(ref Vector2 position, float speed, float deltaTime)
        {
            position.Y += speed * deltaTime;
        }

        public static void AdvanceRotation(ref float rotationCounter, float spin, float deltaTime)
        {
            rotationCounter += spin * deltaTime;
        }

        public static Vector2 DrawPosition(Vector2 position, Vector2 camera, float rotationCounter, float maxRotate,
            out float rotation)
        {
            var result = new Vector2(-16f + ScalarMath.Mod(position.X - camera.X, 352f),
                -16f + ScalarMath.Mod(position.Y - camera.Y, 212f));
            rotation = (float)(1.5707963705062866 + Math.Sin(rotationCounter * maxRotate) * 1.0);
            return result + Vector2Geometry.AngleToVector(rotation, 4f);
        }
    }
}
