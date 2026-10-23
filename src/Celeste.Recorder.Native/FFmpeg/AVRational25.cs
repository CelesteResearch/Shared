using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVRational25 : IFixedArray<AVRational>, IFixedArray
    {
        public static readonly int ArrayLength = 25;

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

        private AVRational _15;

        private AVRational _16;

        private AVRational _17;

        private AVRational _18;

        private AVRational _19;

        private AVRational _20;

        private AVRational _21;

        private AVRational _22;

        private AVRational _23;

        private AVRational _24;

        public int Length => 25;

        public unsafe AVRational this[uint i]
        {
            get
            {
                if (i >= 25)
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
                if (i >= 25)
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
                AVRational[] array = new AVRational[25];
                for (uint num = 0u; num < 25; num++)
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
                    if (num >= 25)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVRational[](AVRational25 @struct)
        {
            return @struct.ToArray();
        }
    }
}
