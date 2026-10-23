using System.Collections.Generic;

namespace Celeste.Core.Randomness
{
    public static class RandomSelection
    {
        public static T Choose<T>(this ISourceRandom random, T first, T second)
        {
            var index = random.Next(2);
            if (index == 0) return first;
            if (index == 1) return second;
            throw new("Index was out of range!");
        }

        public static T Choose<T>(this ISourceRandom random, List<T> values)
        {
            return values[random.Next(values.Count)];
        }

        public static T Choose<T>(this ISourceRandom random, params T[] choices)
        {
            return choices[random.Next(choices.Length)];
        }

        public static void Shuffle<T>(this List<T> list, ISourceRandom random)
        {
            var count = list.Count;
            while (--count > 0)
            {
                var value = list[count];
                int index;
                list[count] = list[index = random.Next(count + 1)];
                list[index] = value;
            }
        }
    }
}
