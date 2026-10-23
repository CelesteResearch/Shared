using FFmpeg.Util;

namespace FFmpeg
{
    public struct int3 : IFixedArray<int>, IFixedArray
    {
        public static readonly int ArrayLength = 3;

        private unsafe fixed int _[3];

        public int Length => 3;

        public unsafe int this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe int[] ToArray()
        {
            int[] array = new int[3];
            for (uint num = 0u; num < 3; num++)
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
                if (num >= 3)
                {
                    break;
                }
            }
        }

        public static implicit operator int[](int3 @struct)
        {
            return @struct.ToArray();
        }
    }
}
