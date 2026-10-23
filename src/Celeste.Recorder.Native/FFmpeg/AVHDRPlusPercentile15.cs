using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVHDRPlusPercentile15 : IFixedArray<AVHDRPlusPercentile>, IFixedArray
    {
        public static readonly int ArrayLength = 15;

        private AVHDRPlusPercentile _0;

        private AVHDRPlusPercentile _1;

        private AVHDRPlusPercentile _2;

        private AVHDRPlusPercentile _3;

        private AVHDRPlusPercentile _4;

        private AVHDRPlusPercentile _5;

        private AVHDRPlusPercentile _6;

        private AVHDRPlusPercentile _7;

        private AVHDRPlusPercentile _8;

        private AVHDRPlusPercentile _9;

        private AVHDRPlusPercentile _10;

        private AVHDRPlusPercentile _11;

        private AVHDRPlusPercentile _12;

        private AVHDRPlusPercentile _13;

        private AVHDRPlusPercentile _14;

        public int Length => 15;

        public unsafe AVHDRPlusPercentile this[uint i]
        {
            get
            {
                if (i >= 15)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVHDRPlusPercentile* ptr = &_0)
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

                fixed (AVHDRPlusPercentile* ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe AVHDRPlusPercentile[] ToArray()
        {
            fixed (AVHDRPlusPercentile* ptr = &_0)
            {
                AVHDRPlusPercentile[] array = new AVHDRPlusPercentile[15];
                for (uint num = 0u; num < 15; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(AVHDRPlusPercentile[] array)
        {
            fixed (AVHDRPlusPercentile* ptr = &_0)
            {
                uint num = 0u;
                foreach (AVHDRPlusPercentile aVHDRPlusPercentile in array)
                {
                    ptr[num++] = aVHDRPlusPercentile;
                    if (num >= 15)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVHDRPlusPercentile[](AVHDRPlusPercentile15 @struct)
        {
            return @struct.ToArray();
        }
    }
}
