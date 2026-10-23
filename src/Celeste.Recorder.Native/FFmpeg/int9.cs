using FFmpeg.Util;

namespace FFmpeg
{
    public struct int9 : IFixedArray<int>, IFixedArray
    {
        public static readonly int ArrayLength = 9;

        private unsafe fixed int _[9];

        public int Length => 9;

        public unsafe int this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe int[] ToArray()
        {
            int[] array = new int[9];
            for (uint num = 0u; num < 9; num++)
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
                if (num >= 9)
                {
                    break;
                }
            }
        }

        public static implicit operator int[](int9 @struct)
        {
            return @struct.ToArray();
        }
    }
}
