using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct byte61440 : IFixedArray<byte>, IFixedArray
    {
        public static readonly int ArrayLength = 61440;

        private unsafe fixed byte _[61440];

        public int Length => 61440;

        public unsafe byte this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe byte[] ToArray()
        {
            var array = new byte[61440];
            for (var num = 0u; num < 61440; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(byte[] array)
        {
            var num = 0u;
            foreach (var b in array)
            {
                _[num++] = b;
                if (num >= 61440) break;
            }
        }

        public static implicit operator byte[](byte61440 @struct)
        {
            return @struct.ToArray();
        }
    }
}
