using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVComponentDescriptor4 : IFixedArray<AVComponentDescriptor>, IFixedArray
    {
        public static readonly int ArrayLength = 4;

        private AVComponentDescriptor _0;

        private AVComponentDescriptor _1;

        private AVComponentDescriptor _2;

        private AVComponentDescriptor _3;

        public int Length => 4;

        public unsafe AVComponentDescriptor this[uint i]
        {
            get
            {
                if (i >= 4)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVComponentDescriptor* ptr = &_0)
                {
                    return ptr[i];
                }
            }
            set
            {
                if (i >= 4)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVComponentDescriptor* ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe AVComponentDescriptor[] ToArray()
        {
            fixed (AVComponentDescriptor* ptr = &_0)
            {
                AVComponentDescriptor[] array = new AVComponentDescriptor[4];
                for (uint num = 0u; num < 4; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(AVComponentDescriptor[] array)
        {
            fixed (AVComponentDescriptor* ptr = &_0)
            {
                uint num = 0u;
                foreach (AVComponentDescriptor aVComponentDescriptor in array)
                {
                    ptr[num++] = aVComponentDescriptor;
                    if (num >= 4)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVComponentDescriptor[](AVComponentDescriptor4 @struct)
        {
            return @struct.ToArray();
        }
    }
}
