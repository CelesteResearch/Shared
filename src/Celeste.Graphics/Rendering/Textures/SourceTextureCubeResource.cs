using System;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Core.Geometry;
using Celeste.Core.Interop;
using Celeste.Graphics.Content.Compiled;

namespace Celeste.Graphics.Rendering.Textures
{
    public class SourceTextureCubeResource : SourceTextureResource
    {
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int Size { get; private set; }

        public SourceTextureCubeResource(ISourceTextureDevice graphicsDevice, int size, bool mipMap,
            SourceSurfaceFormat format)
        {
            if (graphicsDevice == null) throw new ArgumentNullException("graphicsDevice");

            GraphicsDevice = graphicsDevice;
            Size = size;
            LevelCount = !mipMap ? 1 : CalculateMipLevels(size);
            if (this is ISourceRenderTarget)
                switch (format)
                {
                    case SourceSurfaceFormat.ColorSrgbEXT:
                        if (TextureDevice.TextureIO.SupportsSRGBRenderTargets() == 0)
                            Format = SourceSurfaceFormat.Color;
                        else
                            Format = format;

                        break;
                    default:
                        Format = SourceSurfaceFormat.Color;
                        break;
                    case SourceSurfaceFormat.Color:
                    case SourceSurfaceFormat.Rgba1010102:
                    case SourceSurfaceFormat.Rg32:
                    case SourceSurfaceFormat.Rgba64:
                    case SourceSurfaceFormat.Single:
                    case SourceSurfaceFormat.Vector2:
                    case SourceSurfaceFormat.Vector4:
                    case SourceSurfaceFormat.HalfSingle:
                    case SourceSurfaceFormat.HalfVector2:
                    case SourceSurfaceFormat.HalfVector4:
                    case SourceSurfaceFormat.HdrBlendable:
                        Format = format;
                        break;
                }
            else
                Format = format;

            texture = TextureDevice.TextureIO.CreateTextureCube(Format, Size, LevelCount,
                this is ISourceRenderTarget ? (byte)1 : (byte)0);
        }

        public void SetData<T>(SourceCubeMapFace cubeMapFace, T[] data) where T : struct
        {
            SetData(cubeMapFace, 0, null, data, 0, data.Length);
        }

        public void SetData<T>(SourceCubeMapFace cubeMapFace, T[] data, int startIndex, int elementCount)
            where T : struct
        {
            SetData(cubeMapFace, 0, null, data, startIndex, elementCount);
        }

        public void SetData<T>(SourceCubeMapFace cubeMapFace, int level, IntRect? rect, T[] data, int startIndex,
            int elementCount) where T : struct
        {
            if (data == null) throw new ArgumentNullException("data");

            int x;
            int y;
            int w;
            int h;
            if (rect.HasValue)
            {
                x = rect.Value.X;
                y = rect.Value.Y;
                w = rect.Value.Width;
                h = rect.Value.Height;
            }
            else
            {
                x = 0;
                y = 0;
                w = Math.Max(1, Size >> level);
                h = Math.Max(1, Size >> level);
            }

            var num = SourceMarshalHelper.SizeOf<T>();
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            TextureDevice.TextureIO.SetTextureDataCube(texture, x, y, w, h, cubeMapFace, level,
                gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount * num);
            gCHandle.Free();
        }

        public void SetDataPointerEXT(SourceCubeMapFace cubeMapFace, int level, IntRect? rect, IntPtr data,
            int dataLength)
        {
            if (data == IntPtr.Zero) throw new ArgumentNullException("data");

            int x;
            int y;
            int w;
            int h;
            if (rect.HasValue)
            {
                x = rect.Value.X;
                y = rect.Value.Y;
                w = rect.Value.Width;
                h = rect.Value.Height;
            }
            else
            {
                x = 0;
                y = 0;
                w = Math.Max(1, Size >> level);
                h = Math.Max(1, Size >> level);
            }

            TextureDevice.TextureIO.SetTextureDataCube(texture, x, y, w, h, cubeMapFace, level, data, dataLength);
        }

        public void GetData<T>(SourceCubeMapFace cubeMapFace, T[] data) where T : struct
        {
            GetData(cubeMapFace, 0, null, data, 0, data.Length);
        }

        public void GetData<T>(SourceCubeMapFace cubeMapFace, T[] data, int startIndex, int elementCount)
            where T : struct
        {
            GetData(cubeMapFace, 0, null, data, startIndex, elementCount);
        }

        public void GetData<T>(SourceCubeMapFace cubeMapFace, int level, IntRect? rect, T[] data, int startIndex,
            int elementCount) where T : struct
        {
            if (data == null || data.Length == 0) throw new ArgumentException("data cannot be null");

            if (data.Length < startIndex + elementCount)
                throw new ArgumentException("The data passed has a length of " + data.Length + " but " + elementCount +
                                            " pixels have been requested.");

            int x;
            int y;
            int w;
            int h;
            if (!rect.HasValue)
            {
                x = 0;
                y = 0;
                w = Size >> level;
                h = Size >> level;
            }
            else
            {
                x = rect.Value.X;
                y = rect.Value.Y;
                w = rect.Value.Width;
                h = rect.Value.Height;
            }

            var num = SourceMarshalHelper.SizeOf<T>();
            ValidateGetDataFormat(Format, num);
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            TextureDevice.TextureIO.GetTextureDataCube(texture, x, y, w, h, cubeMapFace, level,
                gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount * num);
            gCHandle.Free();
        }

        public static SourceTextureCubeResource DDSFromStreamEXT(ISourceTextureDevice graphicsDevice, Stream stream)
        {
            SourceTextureCubeResource textureCube;
            using (var binaryReader = new BinaryReader(stream))
            {
                ParseDDS(binaryReader, out var format, out var width, out _, out var levels,
                    out var isCube);
                if (!isCube) throw new FormatException("This file does not contain cube data!");

                textureCube = new(graphicsDevice, width, levels > 1, format);
                byte[] buffer = null;
                if (stream is MemoryStream &&
                    ((MemoryStream)stream).TryGetBuffer(out buffer))
                    for (var i = 0; i < 6; i++)
                    for (var j = 0; j < levels; j++)
                    {
                        var num = CalculateDDSLevelSize(width >> j, width >> j, format);
                        textureCube.SetData((SourceCubeMapFace)i, j, null, buffer,
                            (int)stream.Seek(0L, SeekOrigin.Current), num);
                        stream.Seek(num, SeekOrigin.Current);
                    }
                else
                    for (var k = 0; k < 6; k++)
                    for (var l = 0; l < levels; l++)
                    {
                        buffer = binaryReader.ReadBytes(
                            CalculateDDSLevelSize(width >> l, width >> l, format));
                        textureCube.SetData((SourceCubeMapFace)k, l, null, buffer, 0, buffer.Length);
                    }
            }

            return textureCube;
        }
    }
}
