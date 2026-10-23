using System;
using FFmpeg.Util;

namespace FFmpeg
{
    public struct AVHDRPlusColorTransformParams3 : IFixedArray<AVHDRPlusColorTransformParams>, IFixedArray
    {
        public static readonly int ArrayLength = 3;

        private AVHDRPlusColorTransformParams _0;

        private AVHDRPlusColorTransformParams _1;

        private AVHDRPlusColorTransformParams _2;

        public int Length => 3;

        public unsafe AVHDRPlusColorTransformParams this[uint i]
        {
            get
            {
                if (i >= 3)
                {
                    throw new ArgumentOutOfRangeException();
                }

                fixed (AVHDRPlusColorTransformParams* ptr = &_0)
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

                fixed (AVHDRPlusColorTransformParams* ptr = &_0)
                {
                    ptr[i] = value;
                }
            }
        }

        public unsafe AVHDRPlusColorTransformParams[] ToArray()
        {
            fixed (AVHDRPlusColorTransformParams* ptr = &_0)
            {
                AVHDRPlusColorTransformParams[] array = new AVHDRPlusColorTransformParams[3];
                for (uint num = 0u; num < 3; num++)
                {
                    array[num] = ptr[num];
                }

                return array;
            }
        }

        public unsafe void UpdateFrom(AVHDRPlusColorTransformParams[] array)
        {
            fixed (AVHDRPlusColorTransformParams* ptr = &_0)
            {
                uint num = 0u;
                foreach (AVHDRPlusColorTransformParams aVHDRPlusColorTransformParams in array)
                {
                    ptr[num++] = aVHDRPlusColorTransformParams;
                    if (num >= 3)
                    {
                        return;
                    }
                }
            }
        }

        public static implicit operator AVHDRPlusColorTransformParams[](AVHDRPlusColorTransformParams3 @struct)
        {
            return @struct.ToArray();
        }
    }
}
