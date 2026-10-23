using FFmpeg.Util;

namespace FFmpeg
{
    // ReSharper disable once RedundantExtendsListEntry
    public struct byte8 : IFixedArray<byte>, IFixedArray
    {
        public static readonly int ArrayLength = 8;

        private unsafe fixed byte _[8];

        public int Length => 8;

        public unsafe byte this[uint i]
        {
            get => _[i];
            set => _[i] = value;
        }

        public unsafe byte[] ToArray()
        {
            var array = new byte[8];
            for (var num = 0u; num < 8; num++) array[num] = _[num];

            return array;
        }

        public unsafe void UpdateFrom(byte[] array)
        {
            var num = 0u;
            foreach (var b in array)
            {
                _[num++] = b;
                if (num >= 8) break;
            }
        }

        public static implicit operator byte[](byte8 @struct)
        {
            return @struct.ToArray();
        }
    }
}
