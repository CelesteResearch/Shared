using Celeste.Core.Geometry;
using Celeste.Core.Interop;
using Celeste.Core.Rendering.Resources;
using System.Numerics;
using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Textures
{
    public class SourceTexture3DResource : SourceTextureResource
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Depth { get; private set; }

        public SourceTexture3DResource(ISourceTextureDevice graphicsDevice, int width, int height, int depth,
            bool mipMap,
            SourceSurfaceFormat format)
        {
            if (graphicsDevice == null)
            {
                throw new ArgumentNullException("graphicsDevice");
            }

            base.GraphicsDevice = graphicsDevice;
            Width = width;
            Height = height;
            Depth = depth;
            base.LevelCount = ((!mipMap) ? 1 : SourceTextureResource.CalculateMipLevels(width, height));
            base.Format = format;
            texture = TextureDevice.TextureIO.CreateTexture3D(base.Format, Width, Height, Depth, base.LevelCount);
        }

        public void SetData<T>(T[] data) where T : struct
        {
            SetData(data, 0, data.Length);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            SetData(0, 0, 0, Width, Height, 0, Depth, data, startIndex, elementCount);
        }

        public void SetData<T>(int level, int left, int top, int right, int bottom, int front, int back, T[] data,
            int startIndex, int elementCount) where T : struct
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            int num = SourceMarshalHelper.SizeOf<T>();
            GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            TextureDevice.TextureIO.SetTextureData3D(texture, left, top, front, right - left, bottom - top,
                back - front,
                level, gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount * num);
            gCHandle.Free();
        }

        public void SetDataPointerEXT(int level, int left, int top, int right, int bottom, int front, int back,
            IntPtr data,
            int dataLength)
        {
            if (data == IntPtr.Zero)
            {
                throw new ArgumentNullException("data");
            }

            TextureDevice.TextureIO.SetTextureData3D(texture, left, top, front, right - left, bottom - top,
                back - front,
                level, data, dataLength);
        }

        public void GetData<T>(T[] data) where T : struct
        {
            GetData(data, 0, data.Length);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            GetData(0, 0, 0, Width, Height, 0, Depth, data, startIndex, elementCount);
        }

        public void GetData<T>(int level, int left, int top, int right, int bottom, int front, int back, T[] data,
            int startIndex, int elementCount) where T : struct
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("data cannot be null");
            }

            if (data.Length < startIndex + elementCount)
            {
                throw new ArgumentException("The data passed has a length of " + data.Length + " but " + elementCount +
                                            " pixels have been requested.");
            }

            if (left < 0 || left >= right || top < 0 || top >= bottom || front < 0 || front >= back)
            {
                throw new ArgumentException("Neither box size nor box position can be negative");
            }

            int num = SourceMarshalHelper.SizeOf<T>();
            SourceTextureResource.ValidateGetDataFormat(base.Format, num);
            GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            TextureDevice.TextureIO.GetTextureData3D(texture, left, top, front, right - left, bottom - top,
                back - front,
                level, gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount * num);
            gCHandle.Free();
        }
    }
}
