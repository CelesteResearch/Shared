using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVRational15 : IFixedArray<AVRational>, IFixedArray
    {
        public static readonly int ArrayLength = 15;

        private AVRational _0;

        private AVRational _1;

        private AVRational _2;

        private AVRational _3;

        private AVRational _4;

        private AVRational _5;

        private AVRational _6;

        private AVRational _7;

        private AVRational _8;

        private AVRational _9;

        private AVRational _10;

        private AVRational _11;

        private AVRational _12;

        private AVRational _13;

        private AVRational _14;

        public int Length => 15;

        public unsafe AVRational this[uint i]
        {
            get
            {
                if (i >= 15)
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
                if (i >= 15)
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
                AVRational[] array = new AVRational[15];
                for (uint num = 0u; num < 15; num++)
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
                    if (num >= 15)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVRational[](AVRational15 @struct)
        {
            return @struct.ToArray();
        }
    }
}
