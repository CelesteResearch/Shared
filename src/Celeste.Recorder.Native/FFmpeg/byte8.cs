using FFmpeg.Util;

namespace FFmpeg
{
    public struct byte8 : IFixedArray<byte>, IFixedArray
    {
        public static readonly int ArrayLength = 8;

        private unsafe fixed byte _[8];

        public int Length => 8;

        public unsafe byte this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe byte[] ToArray()
        {
            byte[] array = new byte[8];
            for (uint num = 0u; num < 8; num++)
            {
                array[num] = _[num];
            }

            return array;
        }

        public unsafe void UpdateFrom(byte[] array)
        {
            uint num = 0u;
            foreach (byte b in array)
            {
                _[num++] = b;
                if (num >= 8)
                {
                    break;
                }
            }
        }

        public static implicit operator byte[](byte8 @struct)
        {
            return @struct.ToArray();
        }
    }
}
