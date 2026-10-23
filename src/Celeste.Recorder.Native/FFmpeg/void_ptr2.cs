using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct void_ptr2 : IFixedArray
    {
        public static readonly int ArrayLength = 2;

        private unsafe void* _0;

        private unsafe void* _1;

        public int Length => 2;

        public unsafe void* this[uint i]
        {
            get
            {
                if (i >= 2)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (void** ptr = &_0)
                {
                    return ptr[i];
                }
            }
            set
            {
                if (i >= 2)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (void** ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe void*[] ToArray()
        {
            fixed (void** ptr = &_0)
            {
                void*[] array = new void*[2];
                for (uint num = 0u; num < 2; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(void*[] array)
        {
            fixed (void** ptr = &_0)
            {
                uint num = 0u;
                foreach (void* ptr2 in array)
                {
                    ptr[num++] = ptr2;
                    if (num >= 2)
                    {
                        return;
                    }
                }
            }
        }

        public unsafe static implicit operator void*[](void_ptr2 @struct)
        {
            return @struct.ToArray();
        }
    }
}
