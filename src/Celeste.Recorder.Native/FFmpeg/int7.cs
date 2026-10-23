using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct int7 : IFixedArray<int>, IFixedArray
    {
        public static readonly int ArrayLength = 7;

        private unsafe fixed int _[7];

        public int Length => 7;

        public unsafe int this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe int[] ToArray()
        {
            var array = new int[7];
            for (var num = 0u; num < 7; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(int[] array)
        {
            var num = 0u;
            foreach (var num2 in array)
            {
                _[num++] = num2;
                if (num >= 7) break;
            }
        }

        public static implicit operator int[](int7 @struct)
        {
            return @struct.ToArray();
        }
    }
}
