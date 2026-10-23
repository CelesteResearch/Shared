using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct long4 : IFixedArray<long>, IFixedArray
    {
        public static readonly int ArrayLength = 4;

        private unsafe fixed long _[4];

        public int Length => 4;

        public unsafe long this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe long[] ToArray()
        {
            var array = new long[4];
            for (var num = 0u; num < 4; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(long[] array)
        {
            var num = 0u;
            foreach (var num2 in array)
            {
                _[num++] = num2;
                if (num >= 4) break;
            }
        }

        public static implicit operator long[](long4 @struct)
        {
            return @struct.ToArray();
        }
    }
}
