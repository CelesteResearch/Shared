using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVRational25x25 : IFixedArray<AVRational25>, IFixedArray
    {
        public static readonly int ArrayLength = 25;

        private AVRational25 _0;

        private AVRational25 _1;

        private AVRational25 _2;

        private AVRational25 _3;

        private AVRational25 _4;

        private AVRational25 _5;

        private AVRational25 _6;

        private AVRational25 _7;

        private AVRational25 _8;

        private AVRational25 _9;

        private AVRational25 _10;

        private AVRational25 _11;

        private AVRational25 _12;

        private AVRational25 _13;

        private AVRational25 _14;

        private AVRational25 _15;

        private AVRational25 _16;

        private AVRational25 _17;

        private AVRational25 _18;

        private AVRational25 _19;

        private AVRational25 _20;

        private AVRational25 _21;

        private AVRational25 _22;

        private AVRational25 _23;

        private AVRational25 _24;

        public int Length => 25;

        public unsafe AVRational25 this[uint i]
        {
            get
            {
                if (i >= 25)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVRational25* ptr = &_0)
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

                fixed (AVRational25* ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe AVRational25[] ToArray()
        {
            fixed (AVRational25* ptr = &_0)
            {
                AVRational25[] array = new AVRational25[25];
                for (uint num = 0u; num < 25; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(AVRational25[] array)
        {
            fixed (AVRational25* ptr = &_0)
            {
                uint num = 0u;
                foreach (AVRational25 aVRational in array)
                {
                    ptr[num++] = aVRational;
                    if (num >= 25)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVRational25[](AVRational25x25 @struct)
        {
            return @struct.ToArray();
        }
    }
}
