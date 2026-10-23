using System;
using System.Runtime.CompilerServices;

namespace Celeste.Core.Mathematics.Easing
{
    public static class SourceEasingComposition
    {
        private sealed class Inverted(Func<float, float> source)
        {
            // ReSharper disable once ReplaceWithPrimaryConstructorParameter
            private readonly Func<float, float> _source = source;


            [MethodImpl(MethodImplOptions.NoInlining)]
            public float Invoke(float value)
            {
                return 1f - _source(1f - value);
            }
        }

        private sealed class Followed(Func<float, float> first, Func<float, float> second)
        {
            // ReSharper disable once ReplaceWithPrimaryConstructorParameter
            private readonly Func<float, float> _first = first;

            // ReSharper disable once ReplaceWithPrimaryConstructorParameter
            private readonly Func<float, float> _second = second;


            [MethodImpl(MethodImplOptions.NoInlining)]
            public float Invoke(float value)
            {
                return !(value <= .5f)
                    ? _second(value * 2f - 1f) / 2f + .5f
                    : _first(value * 2f) / 2f;
            }
        }

        public static float UpDown(float eased)
        {
            if (eased <= 0.5f) return eased * 2f;
            return 1f - (eased - 0.5f) * 2f;
        }

        public static Func<float, float> Invert(Func<float, float> source)
        {
            return new Inverted(source).Invoke;
        }

        public static Func<float, float> Follow(Func<float, float> first, Func<float, float> second)
        {
            return new Followed(first, second).Invoke;
        }
    }
}
