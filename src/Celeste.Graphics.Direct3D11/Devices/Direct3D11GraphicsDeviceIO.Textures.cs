using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using System;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        public IntPtr CreateTexture2D(SourceSurfaceFormat format, int width, int height,
            int levels, byte renderTarget)
            => CreatePhysicalTexture(format, width, height, 1, levels, 1, 3, renderTarget);

        public IntPtr CreateTexture3D(SourceSurfaceFormat format, int width, int height,
            int depth, int levels)
            => CreatePhysicalTexture(format, width, height, depth, levels, 1, 4, 0);

        public IntPtr CreateTextureCube(SourceSurfaceFormat format, int size, int levels, byte renderTarget)
            => CreatePhysicalTexture(format, size, size, 1, levels, 6, 3, renderTarget);

        private IntPtr CreatePhysicalTexture(SourceSurfaceFormat format, int width, int height,
            int depth, int levels, uint arraySize, uint dimension, byte renderTarget)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuCreateTexture(device,
                    D3D11Conversions.SurfaceFormat(format), unchecked((uint)width),
                    unchecked((uint)height), unchecked((uint)depth), unchecked((uint)levels),
                    arraySize, dimension, renderTarget,
                    D3D11Conversions.TextureBytesPerBlock[(int)format],
                    D3D11Conversions.TextureBlockExtent[(int)format],
                    D3D11Conversions.TextureBlockExtent[(int)format], out IntPtr texture));
            global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current?.RecordLoadResource(true, false);
            return texture;
        }

        public void AddDisposeTexture(IntPtr texture)
        {
            global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current?.RecordLoadResource(true, true);
            Direct3D11GraphicsBindings.SourceGpuAddDisposeTexture(texture);
        }

        public void SetTextureData2D(IntPtr texture, int x, int y, int width, int height,
            int level, IntPtr data, int dataLength)
            => WriteTexture(texture, level, 0, x, y, 0, width, height, 1, data, dataLength);

        public void SetTextureData3D(IntPtr texture, int left, int top, int front, int width,
            int height, int depth, int level, IntPtr data, int dataLength)
            => WriteTexture(texture, level, 0, left, top, front, width, height, depth, data, dataLength);

        public void SetTextureDataCube(IntPtr texture, int x, int y, int width, int height,
            SourceCubeMapFace face, int level, IntPtr data, int dataLength)
            => WriteTexture(texture, level, (int)face, x, y, 0, width, height, 1, data, dataLength);

        private void WriteTexture(IntPtr texture, int level, int slice, int x, int y, int z,
            int width, int height, int depth, IntPtr data, int length)
        {
            uint owned = BorrowWriteScope();
            global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current?.RecordLoadUpload(true, length);
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordTextureData(texture,
                        unchecked((uint)level), unchecked((uint)slice), unchecked((uint)x),
                        unchecked((uint)y), unchecked((uint)z), unchecked((uint)width),
                        unchecked((uint)height), unchecked((uint)depth), data, unchecked((uint)length)));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void GetTextureData2D(IntPtr texture, int x, int y, int width, int height,
            int level, IntPtr data, int dataLength)
            => ReadTexture(texture, level, 0, x, y, 0, width, height, 1, data, dataLength);

        public void GetTextureData3D(IntPtr texture, int left, int top, int front, int width,
            int height, int depth, int level, IntPtr data, int dataLength)
            => ReadTexture(texture, level, 0, left, top, front, width, height, depth, data, dataLength);

        public void GetTextureDataCube(IntPtr texture, int x, int y, int width, int height,
            SourceCubeMapFace face, int level, IntPtr data, int dataLength)
            => ReadTexture(texture, level, (int)face, x, y, 0, width, height, 1, data, dataLength);

        private void ReadTexture(IntPtr texture, int level, int slice, int x, int y, int z,
            int width, int height, int depth, IntPtr data, int length)
        {
            uint owned = BorrowWriteScope();
            IntPtr ticket = IntPtr.Zero;
            try
            {
                try
                {
                    ticket = Direct3D11GraphicsBindings.SourceGpuRecordTextureRead(texture,
                        unchecked((uint)level), unchecked((uint)slice), unchecked((uint)x),
                        unchecked((uint)y), unchecked((uint)z), unchecked((uint)width),
                        unchecked((uint)height), unchecked((uint)depth));
                    if (ticket == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
                }
                finally
                {
                    CompleteReadScope(owned);
                }

                CopyCompletedReadback(ticket, data, length);
            }
            finally
            {
                if (ticket != IntPtr.Zero)
                    Direct3D11GraphicsBindings.SourceGpuReleaseReadback(ticket);
            }
        }
    }
}
