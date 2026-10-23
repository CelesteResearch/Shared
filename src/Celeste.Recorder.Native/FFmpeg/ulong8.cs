using FFmpeg.Util;

namespace FFmpeg
{
    public struct ulong8 : IFixedArray<ulong>, IFixedArray
    {
        public static readonly int ArrayLength = 8;

        private unsafe fixed ulong _[8];

        public int Length => 8;

        public unsafe ulong this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe ulong[] ToArray()
        {
            ulong[] array = new ulong[8];
            for (uint num = 0u; num < 8; num++)
            {
                array[num] = _[num];
            }

            return array;
        }

        public unsafe void UpdateFrom(ulong[] array)
        {
            uint num = 0u;
            foreach (ulong num2 in array)
            {
                _[num++] = num2;
                if (num >= 8)
                {
                    break;
                }
            }
        }

        public static implicit operator ulong[](ulong8 @struct)
        {
            return @struct.ToArray();
        }
    }
}
