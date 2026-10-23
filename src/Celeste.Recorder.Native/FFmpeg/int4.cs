using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct int4 : IFixedArray<int>, IFixedArray
    {
        public static readonly int ArrayLength = 4;

        private unsafe fixed int _[4];

        public int Length => 4;

        public unsafe int this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe int[] ToArray()
        {
            var array = new int[4];
            for (var num = 0u; num < 4; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(int[] array)
        {
            var num = 0u;
            foreach (var num2 in array)
            {
                _[num++] = num2;
                if (num >= 4) break;
            }
        }

        public static implicit operator int[](int4 @struct)
        {
            return @struct.ToArray();
        }
    }
}
