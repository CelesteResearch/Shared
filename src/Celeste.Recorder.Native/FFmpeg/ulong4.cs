using FFmpeg.Util;

namespace FFmpeg
{
    public struct ulong4 : IFixedArray<ulong>, IFixedArray
    {
        public static readonly int ArrayLength = 4;

        private unsafe fixed ulong _[4];

        public int Length => 4;

        public unsafe ulong this[uint i]
        {
            get { return _[i]; }
            set { _[i] = value; }
        }

        public unsafe ulong[] ToArray()
        {
            ulong[] array = new ulong[4];
            for (uint num = 0u; num < 4; num++)
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
                if (num >= 4)
                {
                    break;
                }
            }
        }

        public static implicit operator ulong[](ulong4 @struct)
        {
            return @struct.ToArray();
        }
    }
}
