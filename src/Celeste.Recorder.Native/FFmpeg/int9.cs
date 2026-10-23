using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct int9 : IFixedArray<int>, IFixedArray
    {
        public static readonly int ArrayLength = 9;

        private unsafe fixed int _[9];

        public int Length => 9;

        public unsafe int this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe int[] ToArray()
        {
            var array = new int[9];
            for (var num = 0u; num < 9; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(int[] array)
        {
            var num = 0u;
            foreach (var num2 in array)
            {
                _[num++] = num2;
                if (num >= 9) break;
            }
        }

        public static implicit operator int[](int9 @struct)
        {
            return @struct.ToArray();
        }
    }
}
