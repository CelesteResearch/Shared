using FFmpeg.Util;

namespace FFmpeg
{
    public struct int8 : IFixedArray<int>, IFixedArray
    {
        public static readonly int ArrayLength = 8;

        private unsafe fixed int _[8];

        public int Length => 8;

        public unsafe int this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe int[] ToArray()
        {
            int[] array = new int[8];
            for (uint num = 0u; num < 8; num++)
            {
                array[num] = _[num];
            }

            return array;
        }

        public unsafe void UpdateFrom(int[] array)
        {
            uint num = 0u;
            foreach (int num2 in array)
            {
                _[num++] = num2;
                if (num >= 8)
                {
                    break;
                }
            }
        }

        public static implicit operator int[](int8 @struct)
        {
            return @struct.ToArray();
        }
    }
}
