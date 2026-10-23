using FFmpeg.Util;

namespace FFmpeg
{
    public struct short2 : IFixedArray<short>, IFixedArray
    {
        public static readonly int ArrayLength = 2;

        private unsafe fixed short _[2];

        public int Length => 2;

        public unsafe short this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe short[] ToArray()
        {
            short[] array = new short[2];
            for (uint num = 0u; num < 2; num++)
            {
                array[num] = _[num];
            }

            return array;
        }

        public unsafe void UpdateFrom(short[] array)
        {
            uint num = 0u;
            foreach (short num2 in array)
            {
                _[num++] = num2;
                if (num >= 2)
                {
                    break;
                }
            }
        }

        public static implicit operator short[](short2 @struct)
        {
            return @struct.ToArray();
        }
    }
}
