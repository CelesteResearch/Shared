using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVRational2 : IFixedArray<AVRational>, IFixedArray
    {
        public static readonly int ArrayLength = 2;

        private AVRational _0;

        private AVRational _1;

        public int Length => 2;

        public unsafe AVRational this[uint i]
        {
            get
            {
                if (i >= 2)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVRational* ptr = &_0)
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

                fixed (AVRational* ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe AVRational[] ToArray()
        {
            fixed (AVRational* ptr = &_0)
            {
                AVRational[] array = new AVRational[2];
                for (uint num = 0u; num < 2; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(AVRational[] array)
        {
            fixed (AVRational* ptr = &_0)
            {
                uint num = 0u;
                foreach (AVRational aVRational in array)
                {
                    ptr[num++] = aVRational;
                    if (num >= 2)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVRational[](AVRational2 @struct)
        {
            return @struct.ToArray();
        }
    }
}
