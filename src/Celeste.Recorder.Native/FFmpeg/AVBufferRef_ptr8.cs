using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVBufferRef_ptr8 : IFixedArray
    {
        public static readonly int ArrayLength = 8;

        private unsafe AVBufferRef* _0;

        private unsafe AVBufferRef* _1;

        private unsafe AVBufferRef* _2;

        private unsafe AVBufferRef* _3;

        private unsafe AVBufferRef* _4;

        private unsafe AVBufferRef* _5;

        private unsafe AVBufferRef* _6;

        private unsafe AVBufferRef* _7;

        public int Length => 8;

        public unsafe AVBufferRef* this[uint i]
        {
            get
            {
                if (i >= 8)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVBufferRef** ptr = &_0)
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

                fixed (AVBufferRef** ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe AVBufferRef*[] ToArray()
        {
            fixed (AVBufferRef** ptr = &_0)
            {
                AVBufferRef*[] array = new AVBufferRef*[8];
                for (uint num = 0u; num < 8; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(AVBufferRef*[] array)
        {
            fixed (AVBufferRef** ptr = &_0)
            {
                uint num = 0u;
                foreach (AVBufferRef* ptr2 in array)
                {
                    ptr[num++] = ptr2;
                    if (num >= 8)
                    {
                        return;
                    }
                }
            }
        }

        public unsafe static implicit operator AVBufferRef*[](AVBufferRef_ptr8 @struct)
        {
            return @struct.ToArray();
        }
    }
}
