using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct byte_ptr3 : IFixedArray
    {
        public static readonly int ArrayLength = 3;

        private unsafe byte* _0;

        private unsafe byte* _1;

        private unsafe byte* _2;

        public int Length => 3;

        public unsafe byte* this[uint i]
        {
            get
            {
                if (i >= 3) throw new ArgumentOutOfRangeException();

                fixed (byte** ptr = &_0)
                {
                    return ptr[i];
                }
            }
            set
            {
                if (i >= 3) throw new ArgumentOutOfRangeException();

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
                var array = new byte*[3];
                for (var num = 0u; num < 3; num++) array[num] = ptr[num];

                return array;
            }
        }

        public unsafe void UpdateFrom(byte*[] array)
        {
            fixed (byte** ptr = &_0)
            {
                var num = 0u;
                foreach (var ptr2 in array)
                {
                    ptr[num++] = ptr2;
                    if (num >= 3) return;
                }
            }
        }

        public static unsafe implicit operator byte*[](byte_ptr3 @struct)
        {
            return @struct.ToArray();
        }
    }
}
