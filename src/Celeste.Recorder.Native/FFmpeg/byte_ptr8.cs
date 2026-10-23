using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct byte_ptr8 : IFixedArray
    {
        public static readonly int ArrayLength = 8;

        private unsafe byte* _0;

        private unsafe byte* _1;

        private unsafe byte* _2;

        private unsafe byte* _3;

        private unsafe byte* _4;

        private unsafe byte* _5;

        private unsafe byte* _6;

        private unsafe byte* _7;

        public int Length => 8;

        public unsafe byte* this[uint i]
        {
            get
            {
                if (i >= 8)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (byte** ptr = &_0)
                {
                    return ptr[i];
                }
            }
            set
            {
                if (i >= 8)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (byte** ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe byte*[] ToArray()
        {
            fixed (byte** ptr = &_0)
            {
                byte*[] array = new byte*[8];
                for (uint num = 0u; num < 8; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(byte*[] array)
        {
            fixed (byte** ptr = &_0)
            {
                uint num = 0u;
                foreach (byte* ptr2 in array)
                {
                    ptr[num++] = ptr2;
                    if (num >= 8)
                    {
                        return;
                    }
                }
            }
        }

        public unsafe static implicit operator byte*[](byte_ptr8 @struct)
        {
            return @struct.ToArray();
        }
    }
}
