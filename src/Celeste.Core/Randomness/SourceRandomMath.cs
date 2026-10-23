using System;
using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Core.Randomness
{
    public static class SourceRandomMath
    {
        public static float NextFloat(ISourceRandom random)
        {
            return (float)random.NextDouble();
        }

        public static float NextFloat(ISourceRandom random, float maximum)
        {
            return NextFloat(random) * maximum;
        }

        public static int Range(ISourceRandom random, int minimum, int maximum)
        {
            return unchecked(minimum + random.Next(unchecked(maximum - minimum)));
        }

        public static float Range(ISourceRandom random, float minimum, float maximum)
        {
            return minimum + NextFloat(random, maximum - minimum);
        }

        public static Vector2 Range(ISourceRandom random, Vector2 minimum, Vector2 maximum)
        {
            return SourceVector2Math.Add(minimum, new(NextFloat(random, maximum.X - minimum.X),
                NextFloat(random, maximum.Y - minimum.Y)));
        }

        public static float NextAngle(ISourceRandom random)
        {
            return NextFloat(random) * ((float)Math.PI * 2f);
        }
    }
}
