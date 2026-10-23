using FFmpeg.Util;

namespace FFmpeg
{
    public struct int7 : IFixedArray<int>, IFixedArray
    {
        public static readonly int ArrayLength = 7;

        private unsafe fixed int _[7];

        public int Length => 7;

        public unsafe int this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe int[] ToArray()
        {
            int[] array = new int[7];
            for (uint num = 0u; num < 7; num++)
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
                if (num >= 7)
                {
                    break;
                }
            }
        }

        public static implicit operator int[](int7 @struct)
        {
            return @struct.ToArray();
        }
    }
}
