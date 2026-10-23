using System;
using System.Runtime.CompilerServices;

namespace Celeste.Core.Mathematics.Easing
{
    public static class SourceEasingComposition
    {
        private sealed class Inverted
        {
            private readonly Func<float, float> source;
            public Inverted(Func<float, float> source) => this.source = source;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public float Invoke(float value) => 1f - source(1f - value);
        }

        private sealed class Followed
        {
            private readonly Func<float, float> first, second;

            public Followed(Func<float, float> first, Func<float, float> second)
            {
                this.first = first;
                this.second = second;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public float Invoke(float value) => !(value <= .5f)
                ? second(value * 2f - 1f) / 2f + .5f
                : first(value * 2f) / 2f;
        }

        public static float UpDown(float eased)
        {
            if (eased <= 0.5f) return eased * 2f;
            return 1f - (eased - 0.5f) * 2f;
        }

        public static Func<float, float> Invert(Func<float, float> source) => new Inverted(source).Invoke;

        public static Func<float, float> Follow(Func<float, float> first, Func<float, float> second) =>
            new Followed(first, second).Invoke;
    }
}
