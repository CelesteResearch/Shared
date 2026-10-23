using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct ulong8 : IFixedArray<ulong>, IFixedArray
    {
        public static readonly int ArrayLength = 8;

        private unsafe fixed ulong _[8];

        public int Length => 8;

        public unsafe ulong this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe ulong[] ToArray()
        {
            var array = new ulong[8];
            for (var num = 0u; num < 8; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(ulong[] array)
        {
            var num = 0u;
            foreach (var num2 in array)
            {
                _[num++] = num2;
                if (num >= 8) break;
            }
        }

        public static implicit operator ulong[](ulong8 @struct)
        {
            return @struct.ToArray();
        }
    }
}
