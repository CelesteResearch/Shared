using System.IO;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Images
{
    internal static class SourceX360TexUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapColor(byte[] imageData)
        {
            using var imageStream = new MemoryStream(imageData);
            return SwapColor(imageStream, imageData.Length);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapColor(Stream imageStream, int imageLength)
        {
            var array = new byte[imageLength];
            using var binaryReader = new BinaryReader(imageStream);
            for (var i = 0; i < imageLength; i += 4)
            {
                var num = binaryReader.ReadUInt32();
                array[i] = (byte)((num >> 24) & 0xFF);
                array[i + 1] = (byte)((num >> 16) & 0xFF);
                array[i + 2] = (byte)((num >> 8) & 0xFF);
                array[i + 3] = (byte)(num & 0xFF);
            }

            return array;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapDxt1(byte[] imageData, int width, int height)
        {
            using var imageStream = new MemoryStream(imageData);
            return SwapDxt1(imageStream, imageData.Length, width, height);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapDxt1(Stream imageStream, int imageLength, int width, int height)
        {
            var array = new byte[imageLength];
            using var output = new MemoryStream(array);
            using var imageWriter = new BinaryWriter(output);
            using var imageReader = new BinaryReader(imageStream);
            var num = (width + 3) / 4;
            var num2 = (height + 3) / 4;
            for (var i = 0; i < num2; i++)
            for (var j = 0; j < num; j++)
                SwapDxt1Block(imageReader, imageWriter);

            return array;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapDxt3(byte[] imageData, int width, int height)
        {
            using var imageStream = new MemoryStream(imageData);
            return SwapDxt3(imageStream, imageData.Length, width, height);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapDxt3(Stream imageStream, int imageLength, int width, int height)
        {
            var array = new byte[imageLength];
            using var output = new MemoryStream(array);
            using var imageWriter = new BinaryWriter(output);
            using var imageReader = new BinaryReader(imageStream);
            var num = (width + 3) / 4;
            var num2 = (height + 3) / 4;
            for (var i = 0; i < num2; i++)
            for (var j = 0; j < num; j++)
                SwapDxt3Block(imageReader, imageWriter);

            return array;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapDxt5(byte[] imageData, int width, int height)
        {
            using var imageStream = new MemoryStream(imageData);
            return SwapDxt5(imageStream, imageData.Length, width, height);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] SwapDxt5(Stream imageStream, int imageLength, int width, int height)
        {
            var array = new byte[imageLength];
            using var output = new MemoryStream(array);
            using var imageWriter = new BinaryWriter(output);
            using var imageReader = new BinaryReader(imageStream);
            var num = (width + 3) / 4;
            var num2 = (height + 3) / 4;
            for (var i = 0; i < num2; i++)
            for (var j = 0; j < num; j++)
                SwapDxt5Block(imageReader, imageWriter);

            return array;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ushort SwapEndian(ushort data)
        {
            return (ushort)((ushort)((data & 0xFF) << 8) | (ushort)((data >> 8) & 0xFF));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void SwapDxt1Block(BinaryReader imageReader, BinaryWriter imageWriter)
        {
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void SwapDxt3Block(BinaryReader imageReader, BinaryWriter imageWriter)
        {
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            SwapDxt1Block(imageReader, imageWriter);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void SwapDxt5Block(BinaryReader imageReader, BinaryWriter imageWriter)
        {
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            imageWriter.Write(SwapEndian(imageReader.ReadUInt16()));
            SwapDxt1Block(imageReader, imageWriter);
        }
    }
}
