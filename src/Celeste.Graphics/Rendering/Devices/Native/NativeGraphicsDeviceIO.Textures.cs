using System;
using System.Text;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO
    {
        public ISourceTextureIO TextureIO => this;

        public void Image_Free(IntPtr pointer)
        {
            ImageStreams.FreeImage(pointer);
        }

        public IntPtr CreateTexture2D(SourceSurfaceFormat format, int width, int height, int levels, byte renderTarget)
        {
            return CreatePhysicalTexture(format, width, height, 1, levels, 0, renderTarget);
        }

        public IntPtr CreateTexture3D(SourceSurfaceFormat format, int width, int height, int depth, int levels)
        {
            return CreatePhysicalTexture(format, width, height, depth, levels, 1, 0);
        }

        public IntPtr CreateTextureCube(SourceSurfaceFormat format, int size, int levels, byte renderTarget)
        {
            return CreatePhysicalTexture(format, size, size, 1, levels, 2, renderTarget);
        }

        private IntPtr CreatePhysicalTexture(SourceSurfaceFormat format, int width, int height,
            int depth, int levels, uint dimension, byte renderTarget)
        {
            var info = new CelesteGraphicsTextureInfo
            {
                sourceFormat = format, dimension = dimension,
                width = unchecked((uint)width), height = unchecked((uint)height), depth = unchecked((uint)depth),
                levels = unchecked((uint)levels), renderTarget = renderTarget,
            };
            IntPtr texture;
            RequireSuccess(api->CreateTexture(device, &info, &texture));
            SourceFrameDiagnostics.Current?.RecordLoadResource(true, false);
            return texture;
        }

        public void AddDisposeTexture(IntPtr texture)
        {
            SourceFrameDiagnostics.Current?.RecordLoadResource(true, true);
            api->ReleaseTexture(texture);
        }

        public void SetTextureName(IntPtr texture, string name)
        {
            var utf8 = Encoding.UTF8.GetBytes(name);
            fixed (byte* pointer = utf8)
            {
                RequireSuccess(api->SetTextureName(texture, pointer, unchecked((uint)utf8.Length)));
            }
        }

        public void CopyTexture2D(IntPtr source, IntPtr destination)
        {
            var owned = BorrowWriteScope();
            try
            {
                RequireSuccess(api->CopyTexture(packet, source, destination));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetTextureData2D(IntPtr texture, int x, int y, int width, int height,
            int level, IntPtr data, int dataLength)
        {
            WriteTexture(texture, level, 0, x, y, 0, width, height, 1, data, dataLength);
        }

        public void SetTextureData3D(IntPtr texture, int left, int top, int front, int width,
            int height, int depth, int level, IntPtr data, int dataLength)
        {
            WriteTexture(texture, level, 0, left, top, front, width, height, depth, data, dataLength);
        }

        public void SetTextureDataCube(IntPtr texture, int x, int y, int width, int height,
            SourceCubeMapFace face, int level, IntPtr data, int dataLength)
        {
            WriteTexture(texture, level, (int)face, x, y, 0, width, height, 1, data, dataLength);
        }

        private void WriteTexture(IntPtr texture, int level, int layer, int x, int y, int z,
            int width, int height, int depth, IntPtr data, int length)
        {
            var owned = BorrowWriteScope(true);
            SourceFrameDiagnostics.Current?.RecordLoadUpload(true, length);
            try
            {
                var region = TextureRegion(level, layer, x, y, z, width, height, depth);
                RequireSuccess(api->WriteTexture(packet, texture, &region, (void*)data, unchecked((uint)length)));
                textureUploadBytesSinceWait += unchecked((uint)length);
                textureUploadOperationsSinceWait++;
            }
            finally
            {
                CompleteWriteScope(owned, true);
            }
        }

        public void GetTextureData2D(IntPtr texture, int x, int y, int width, int height,
            int level, IntPtr data, int dataLength)
        {
            ReadTexture(texture, level, 0, x, y, 0, width, height, 1, data, dataLength);
        }

        public void GetTextureData3D(IntPtr texture, int left, int top, int front, int width,
            int height, int depth, int level, IntPtr data, int dataLength)
        {
            ReadTexture(texture, level, 0, left, top, front, width, height, depth, data, dataLength);
        }

        public void GetTextureDataCube(IntPtr texture, int x, int y, int width, int height,
            SourceCubeMapFace face, int level, IntPtr data, int dataLength)
        {
            ReadTexture(texture, level, (int)face, x, y, 0, width, height, 1, data, dataLength);
        }

        private void ReadTexture(IntPtr texture, int level, int layer, int x, int y, int z,
            int width, int height, int depth, IntPtr data, int length)
        {
            var owned = BorrowWriteScope();
            var ticket = IntPtr.Zero;
            try
            {
                try
                {
                    var region = TextureRegion(level, layer, x, y, z, width, height, depth);
                    RequireSuccess(api->ReadTexture(packet, texture, &region, &ticket));
                }
                finally
                {
                    CompleteReadScope(owned);
                }

                CopyCompletedReadback(ticket, data, length);
            }
            catch
            {
                AbortUnsubmittedPhysicalPrefix();
                throw;
            }
            finally
            {
                if (ticket != IntPtr.Zero) api->ReleaseReadback(ticket);
            }
        }

        private static CelesteGraphicsTextureRegion TextureRegion(int level, int layer, int x, int y, int z,
            int width, int height, int depth)
        {
            return new()
            {
                level = unchecked((uint)level), layer = unchecked((uint)layer),
                x = unchecked((uint)x), y = unchecked((uint)y), z = unchecked((uint)z),
                width = unchecked((uint)width), height = unchecked((uint)height), depth = unchecked((uint)depth),
            };
        }
    }
}
