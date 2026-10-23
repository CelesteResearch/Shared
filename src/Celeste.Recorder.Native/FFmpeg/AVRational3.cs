using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVRational3 : IFixedArray<AVRational>, IFixedArray
    {
        public static readonly int ArrayLength = 3;

        private AVRational _0;

        private AVRational _1;

        private AVRational _2;

        public int Length => 3;

        public unsafe AVRational this[uint i]
        {
            get
            {
                if (i >= 3)
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
                if (i >= 3)
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
                AVRational[] array = new AVRational[3];
                for (uint num = 0u; num < 3; num++)
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
                    if (num >= 3)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVRational[](AVRational3 @struct)
        {
            return @struct.ToArray();
        }
    }
}
