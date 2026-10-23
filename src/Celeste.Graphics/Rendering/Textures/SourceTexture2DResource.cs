using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Celeste.Core.Geometry;
using Celeste.Core.Interop;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Content.Textures;

namespace Celeste.Graphics.Rendering.Textures
{
    public partial class SourceTexture2DResource : SourceTextureResource
    {
        private long contentRevision;

        public long ContentRevision => Volatile.Read(ref contentRevision);

        public bool IsRenderTargetResource => this is ISourceRenderTarget;

        private void MarkContentWritten()
        {
            Interlocked.Increment(ref contentRevision);
        }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int Width { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int Height { get; private set; }

        public IntRect Bounds => new(0, 0, Width, Height);

        public SourceTexture2DResource(ISourceTextureDevice graphicsDevice, int width, int height)
            : this(graphicsDevice, width, height, false, SourceSurfaceFormat.Color)
        {
        }

        public SourceTexture2DResource(ISourceTextureDevice graphicsDevice, int width, int height, bool mipMap,
            SourceSurfaceFormat format)
        {
            if (graphicsDevice == null) throw new ArgumentNullException("graphicsDevice");

            GraphicsDevice = graphicsDevice;
            Width = width;
            Height = height;
            LevelCount = !mipMap ? 1 : CalculateMipLevels(width, height);
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

            texture = TextureDevice.TextureIO.CreateTexture2D(Format, Width, Height, LevelCount,
                this is ISourceRenderTarget ? (byte)1 : (byte)0);
        }

        public void SetData<T>(T[] data) where T : struct
        {
            SetData(0, null, data, 0, data.Length);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            SetData(0, null, data, startIndex, elementCount);
        }

        public void SetData<T>(int level, IntRect? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            if (data == null) throw new ArgumentNullException("data");

            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");

            if (data.Length < elementCount + startIndex) throw new ArgumentOutOfRangeException("elementCount");

            int x;
            int y;
            int num;
            int num2;
            if (rect.HasValue)
            {
                x = rect.Value.X;
                y = rect.Value.Y;
                num = rect.Value.Width;
                num2 = rect.Value.Height;
            }
            else
            {
                x = 0;
                y = 0;
                num = Math.Max(Width >> level, 1);
                num2 = Math.Max(Height >> level, 1);
            }

            var num3 = SourceMarshalHelper.SizeOf<T>();
            var num4 = num * num2 * GetFormatSizeEXT(Format) /
                       GetBlockSizeSquaredEXT(Format);
            var num5 = elementCount * num3;
            if (num4 > num5)
                throw new ArgumentOutOfRangeException("rect",
                    "The region you are trying to upload is larger than the amount of data you provided.");

            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            TextureDevice.TextureIO.SetTextureData2D(texture, x, y, num, num2, level,
                gCHandle.AddrOfPinnedObject() + startIndex * num3, elementCount * num3);
            MarkContentWritten();
            gCHandle.Free();
        }

        public void SetDataPointerEXT(int level, IntRect? rect, IntPtr data, int dataLength)
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
                w = Math.Max(Width >> level, 1);
                h = Math.Max(Height >> level, 1);
            }

            TextureDevice.TextureIO.SetTextureData2D(texture, x, y, w, h, level, data, dataLength);
            MarkContentWritten();
        }

        public void GetData<T>(T[] data) where T : struct
        {
            GetData(0, null, data, 0, data.Length);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            GetData(0, null, data, startIndex, elementCount);
        }

        public void GetData<T>(int level, IntRect? rect, T[] data, int startIndex, int elementCount) where T : struct
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
                w = Width >> level;
                h = Height >> level;
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
            TextureDevice.TextureIO.GetTextureData2D(texture, x, y, w, h, level,
                gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount * num);
            gCHandle.Free();
        }

        public void SaveAsJpeg(Stream stream, int width, int height)
        {
            var environmentVariable = System.Environment.GetEnvironmentVariable("FNA_GRAPHICS_JPEG_SAVE_QUALITY");
            if (string.IsNullOrEmpty(environmentVariable) || !int.TryParse(environmentVariable, out var result))
                result = 100;

            var num = Width * Height * GetFormatSizeEXT(Format);
            var intPtr = TextureDevice.TextureIO.Allocate(num);
            TextureDevice.TextureIO.GetTextureData2D(texture, 0, 0, Width, Height, 0, intPtr, num);
            TextureDevice.TextureIO.ImageStreams.WriteJPGStream(stream, Width, Height, width, height, intPtr, result);
            TextureDevice.TextureIO.Free(intPtr);
        }

        public void SaveAsPng(Stream stream, int width, int height)
        {
            var num = Width * Height * GetFormatSizeEXT(Format);
            var intPtr = TextureDevice.TextureIO.Allocate(num);
            TextureDevice.TextureIO.GetTextureData2D(texture, 0, 0, Width, Height, 0, intPtr, num);
            TextureDevice.TextureIO.ImageStreams.WritePNGStream(stream, Width, Height, width, height, intPtr);
            TextureDevice.TextureIO.Free(intPtr);
        }

        public static SourceTexture2DResource FromStream(ISourceTextureDevice graphicsDevice, Stream stream)
        {
            return FromStream(graphicsDevice, stream, false);
        }

        public static SourceTexture2DResource FromStream(ISourceTextureDevice graphicsDevice, Stream stream,
            bool premultiply)
        {
            if (stream.CanSeek && stream.Position == stream.Length) stream.Seek(0L, SeekOrigin.Begin);

            int width;
            int height;
            int len;
            var intPtr =
                graphicsDevice.TextureIO.ImageStreams.ReadImageStream(stream, out width, out height, out len);
            SourceTexture2DResource texture2D = null;
            try
            {
                try
                {
                    if (premultiply)
                        SourceTexturePremultiplication.PremultiplyRgba(intPtr, width * height);
                    texture2D = new(graphicsDevice, width, height);
                    texture2D.SetDataPointerEXT(0, null, intPtr, len);
                }
                finally
                {
                    graphicsDevice.TextureIO.Image_Free(intPtr);
                }

                return texture2D;
            }
            catch
            {
                texture2D?.Dispose();
                throw;
            }
        }

        public static SourceTexture2DResource FromStream(ISourceTextureDevice graphicsDevice, Stream stream, int width,
            int height, bool zoom)
        {
            if (stream.CanSeek && stream.Position == stream.Length) stream.Seek(0L, SeekOrigin.Begin);

            int width2;
            int height2;
            int len;
            var intPtr =
                graphicsDevice.TextureIO.ImageStreams.ReadImageStream(stream, out width2, out height2, out len, width,
                    height, zoom);
            var texture2D = new SourceTexture2DResource(graphicsDevice, width2, height2);
            texture2D.SetDataPointerEXT(0, null, intPtr, len);
            graphicsDevice.TextureIO.Image_Free(intPtr);
            return texture2D;
        }

        public static void TextureDataFromStreamEXT(ISourceTextureIO textureIO, Stream stream, out int width,
            out int height, out byte[] pixels, int requestedWidth = -1, int requestedHeight = -1, bool zoom = false)
        {
            if (stream.CanSeek && stream.Position == stream.Length) stream.Seek(0L, SeekOrigin.Begin);

            int len;
            var intPtr = textureIO.ImageStreams.ReadImageStream(stream, out width, out height, out len,
                requestedWidth,
                requestedHeight, zoom);
            pixels = new byte[len];
            Marshal.Copy(intPtr, pixels, 0, len);
            textureIO.Image_Free(intPtr);
        }

        public static SourceTexture2DResource DDSFromStreamEXT(ISourceTextureDevice graphicsDevice, Stream stream)
        {
            SourceTexture2DResource texture2D;
            using (var binaryReader = new BinaryReader(stream))
            {
                ParseDDS(binaryReader, out var format, out var width, out var height,
                    out var levels,
                    out var isCube);
                if (isCube) throw new FormatException("This file contains cube map data!");

                texture2D = new(graphicsDevice, width, height, levels > 1, format);
                byte[] buffer = null;
                if (stream is MemoryStream &&
                    ((MemoryStream)stream).TryGetBuffer(out buffer))
                    for (var i = 0; i < levels; i++)
                    {
                        var num = CalculateDDSLevelSize(width >> i, height >> i, format);
                        texture2D.SetData(i, null, buffer, (int)stream.Seek(0L, SeekOrigin.Current), num);
                        stream.Seek(num, SeekOrigin.Current);
                    }
                else
                    for (var j = 0; j < levels; j++)
                    {
                        buffer = binaryReader.ReadBytes(
                            CalculateDDSLevelSize(width >> j, height >> j, format));
                        texture2D.SetData(j, null, buffer, 0, buffer.Length);
                    }
            }

            return texture2D;
        }
    }
}
