using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVRational3x2 : IFixedArray<AVRational2>, IFixedArray
    {
        public static readonly int ArrayLength = 3;

        private AVRational2 _0;

        private AVRational2 _1;

        private AVRational2 _2;

        public int Length => 3;

        public unsafe AVRational2 this[uint i]
        {
            get
            {
                if (i >= 3)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVRational2* ptr = &_0)
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

                fixed (AVRational2* ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe AVRational2[] ToArray()
        {
            fixed (AVRational2* ptr = &_0)
            {
                AVRational2[] array = new AVRational2[3];
                for (uint num = 0u; num < 3; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(AVRational2[] array)
        {
            fixed (AVRational2* ptr = &_0)
            {
                uint num = 0u;
                foreach (AVRational2 aVRational in array)
                {
                    ptr[num++] = aVRational;
                    if (num >= 3)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVRational2[](AVRational3x2 @struct)
        {
            return @struct.ToArray();
        }
    }
}
