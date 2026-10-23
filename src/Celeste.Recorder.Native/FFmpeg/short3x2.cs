using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct short3x2 : IFixedArray<short2>, IFixedArray
    {
        public static readonly int ArrayLength = 3;

        private short2 _0;

        private short2 _1;

        private short2 _2;

        public int Length => 3;

        public unsafe short2 this[uint i]
        {
            get
            {
                if (i >= 3)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (short2* ptr = &_0)
                {
                    return ptr[i];
                }
            }
            set
            {
                if (i >= 3)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (short2* ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe short2[] ToArray()
        {
            fixed (short2* ptr = &_0)
            {
                short2[] array = new short2[3];
                for (uint num = 0u; num < 3; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(short2[] array)
        {
            fixed (short2* ptr = &_0)
            {
                uint num = 0u;
                foreach (short2 short3 in array)
                {
                    ptr[num++] = short3;
                    if (num >= 3)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator short2[](short3x2 @struct)
        {
            return @struct.ToArray();
        }
    }
}
