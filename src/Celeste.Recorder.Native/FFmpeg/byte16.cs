using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct byte16 : IFixedArray<byte>, IFixedArray
    {
        public static readonly int ArrayLength = 16;

        private unsafe fixed byte _[16];

        public int Length => 16;

        public unsafe byte this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe byte[] ToArray()
        {
            var array = new byte[16];
            for (var num = 0u; num < 16; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(byte[] array)
        {
            var num = 0u;
            foreach (var b in array)
            {
                _[num++] = b;
                if (num >= 16) break;
            }
        }

        public static implicit operator byte[](byte16 @struct)
        {
            return @struct.ToArray();
        }
    }
}
