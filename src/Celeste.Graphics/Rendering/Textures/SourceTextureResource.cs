using System;
using System.IO;
using System.Threading;
using Celeste.Core.Rendering.Resources;

namespace Celeste.Graphics.Rendering.Textures
{
    public abstract class SourceTextureResource : SourceGraphicsResource
    {
        protected ISourceTextureDevice TextureDevice => (ISourceTextureDevice)GraphicsDevice;
        internal IntPtr texture;

        public SourceSurfaceFormat Format { get; protected set; }

        public int LevelCount { get; protected set; }

        public override string Name
        {
            get => base.Name;
            set
            {
                if (!(value == base.Name))
                {
                    base.Name = value;
                    if (value == null) value = string.Empty;

                    TextureDevice.TextureIO.SetTextureName(texture, value);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                TextureDevice.Textures.RemoveDisposedTexture(this);
                TextureDevice.VertexTextures.RemoveDisposedTexture(this);
                var intPtr = Interlocked.Exchange(ref texture, IntPtr.Zero);
                if (intPtr != IntPtr.Zero) TextureDevice.TextureIO.AddDisposeTexture(intPtr);
            }

            base.Dispose(disposing);
        }

        protected override void GraphicsDeviceResetting()
        {
        }

        public static int GetBlockSizeSquaredEXT(SourceSurfaceFormat format)
        {
            switch (format)
            {
                case SourceSurfaceFormat.Dxt1:
                case SourceSurfaceFormat.Dxt3:
                case SourceSurfaceFormat.Dxt5:
                case SourceSurfaceFormat.Dxt5SrgbEXT:
                case SourceSurfaceFormat.Bc7EXT:
                case SourceSurfaceFormat.Bc7SrgbEXT:
                    return 16;
                case SourceSurfaceFormat.Color:
                case SourceSurfaceFormat.Bgr565:
                case SourceSurfaceFormat.Bgra5551:
                case SourceSurfaceFormat.Bgra4444:
                case SourceSurfaceFormat.NormalizedByte2:
                case SourceSurfaceFormat.NormalizedByte4:
                case SourceSurfaceFormat.Rgba1010102:
                case SourceSurfaceFormat.Rg32:
                case SourceSurfaceFormat.Rgba64:
                case SourceSurfaceFormat.Alpha8:
                case SourceSurfaceFormat.Single:
                case SourceSurfaceFormat.Vector2:
                case SourceSurfaceFormat.Vector4:
                case SourceSurfaceFormat.HalfSingle:
                case SourceSurfaceFormat.HalfVector2:
                case SourceSurfaceFormat.HalfVector4:
                case SourceSurfaceFormat.HdrBlendable:
                case SourceSurfaceFormat.ColorBgraEXT:
                case SourceSurfaceFormat.ColorSrgbEXT:
                    return 1;
                default:
                    throw new ArgumentException("Should be a value defined in SourceSurfaceFormat", "Format");
            }
        }

        public static int GetFormatSizeEXT(SourceSurfaceFormat format)
        {
            switch (format)
            {
                case SourceSurfaceFormat.Dxt1:
                    return 8;
                case SourceSurfaceFormat.Dxt3:
                case SourceSurfaceFormat.Dxt5:
                case SourceSurfaceFormat.Dxt5SrgbEXT:
                case SourceSurfaceFormat.Bc7EXT:
                case SourceSurfaceFormat.Bc7SrgbEXT:
                    return 16;
                case SourceSurfaceFormat.Alpha8:
                    return 1;
                case SourceSurfaceFormat.Bgr565:
                case SourceSurfaceFormat.Bgra5551:
                case SourceSurfaceFormat.Bgra4444:
                case SourceSurfaceFormat.NormalizedByte2:
                case SourceSurfaceFormat.HalfSingle:
                    return 2;
                case SourceSurfaceFormat.Color:
                case SourceSurfaceFormat.NormalizedByte4:
                case SourceSurfaceFormat.Rgba1010102:
                case SourceSurfaceFormat.Rg32:
                case SourceSurfaceFormat.Single:
                case SourceSurfaceFormat.HalfVector2:
                case SourceSurfaceFormat.ColorBgraEXT:
                case SourceSurfaceFormat.ColorSrgbEXT:
                    return 4;
                case SourceSurfaceFormat.Rgba64:
                case SourceSurfaceFormat.Vector2:
                case SourceSurfaceFormat.HalfVector4:
                case SourceSurfaceFormat.HdrBlendable:
                    return 8;
                case SourceSurfaceFormat.Vector4:
                    return 16;
                default:
                    throw new ArgumentException("Should be a value defined in SourceSurfaceFormat", "Format");
            }
        }

        internal static int GetPixelStoreAlignment(SourceSurfaceFormat format)
        {
            return Math.Min(8, GetFormatSizeEXT(format));
        }

        internal static void ValidateGetDataFormat(SourceSurfaceFormat format, int elementSizeInBytes)
        {
            if (GetFormatSizeEXT(format) % elementSizeInBytes != 0)
                throw new ArgumentException(
                    "The type you are using for T in this method is an invalid size for this resource");
        }

        internal static int CalculateMipLevels(int width, int height = 0, int depth = 0)
        {
            var num = 1;
            var num2 = Math.Max(Math.Max(width, height), depth);
            while (num2 > 1)
            {
                num2 /= 2;
                num++;
            }

            return num;
        }

        internal static int CalculateDDSLevelSize(int width, int height, SourceSurfaceFormat format)
        {
            switch (format)
            {
                case SourceSurfaceFormat.ColorBgraEXT:
                    return (width * 32 + 7) / 8 * height;
                case SourceSurfaceFormat.HalfVector4:
                    return (width * 64 + 7) / 8 * height;
                case SourceSurfaceFormat.Vector4:
                    return (width * 128 + 7) / 8 * height;
                default:
                {
                    var num = 16;
                    if (format == SourceSurfaceFormat.Dxt1) num = 8;

                    width = Math.Max(width, 1);
                    height = Math.Max(height, 1);
                    return (width + 3) / 4 * ((height + 3) / 4) * num;
                }
            }
        }

        internal static void ParseDDS(BinaryReader reader, out SourceSurfaceFormat format, out int width,
            out int height,
            out int levels, out bool isCube)
        {
            if (reader.ReadUInt32() != 542327876) throw new NotSupportedException("Not a DDS!");

            if (reader.ReadUInt32() != 124) throw new NotSupportedException("Invalid DDS header!");

            var num = reader.ReadUInt32();
            if ((num & 6) != 6) throw new NotSupportedException("Invalid DDS flags!");

            if ((num & 0x80008) == 524296) throw new NotSupportedException("Invalid DDS flags!");

            height = reader.ReadInt32();
            width = reader.ReadInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
            levels = reader.ReadInt32();
            reader.ReadBytes(44);
            if (reader.ReadUInt32() != 32) throw new NotSupportedException("Bogus PIXFMTSIZE!");

            var num2 = reader.ReadUInt32();
            var num3 = reader.ReadUInt32();
            var num4 = reader.ReadUInt32();
            var num5 = reader.ReadUInt32();
            var num6 = reader.ReadUInt32();
            var num7 = reader.ReadUInt32();
            var num8 = reader.ReadUInt32();
            var num9 = reader.ReadUInt32();
            if ((num9 & 0x1000) == 0) throw new NotSupportedException("Not a texture!");

            isCube = false;
            var num10 = reader.ReadUInt32();
            if (num10 != 0)
            {
                if ((num10 & 0x200) != 512) throw new NotSupportedException("Invalid caps2!");

                isCube = true;
            }

            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
            if ((num9 & 0x400000) != 4194304) levels = 1;

            if ((num2 & 4) == 4)
            {
                switch (num3)
                {
                    case 113u:
                        format = SourceSurfaceFormat.HalfVector4;
                        break;
                    case 116u:
                        format = SourceSurfaceFormat.Vector4;
                        break;
                    case 827611204u:
                        format = SourceSurfaceFormat.Dxt1;
                        break;
                    case 861165636u:
                        format = SourceSurfaceFormat.Dxt3;
                        break;
                    case 894720068u:
                        format = SourceSurfaceFormat.Dxt5;
                        break;
                    case 808540228u:
                    {
                        switch (reader.ReadUInt32())
                        {
                            case 2u:
                                format = SourceSurfaceFormat.Vector4;
                                break;
                            case 10u:
                                format = SourceSurfaceFormat.HalfVector4;
                                break;
                            case 71u:
                                format = SourceSurfaceFormat.Dxt1;
                                break;
                            case 74u:
                                format = SourceSurfaceFormat.Dxt3;
                                break;
                            case 77u:
                                format = SourceSurfaceFormat.Dxt5;
                                break;
                            case 98u:
                                format = SourceSurfaceFormat.Bc7EXT;
                                break;
                            case 99u:
                                format = SourceSurfaceFormat.Bc7SrgbEXT;
                                break;
                            default:
                                throw new NotSupportedException("Unsupported DDS texture format");
                        }

                        var num11 = reader.ReadUInt32();
                        if (num11 <= 1) throw new NotSupportedException("Unsupported DDS texture format");

                        reader.ReadUInt32();
                        if (reader.ReadUInt32() > 1) throw new NotSupportedException("Unsupported DDS texture format");

                        reader.ReadUInt32();
                        break;
                    }
                    default:
                        throw new NotSupportedException("Unsupported DDS texture format");
                }
            }
            else
            {
                if ((num2 & 0x40) != 64) throw new NotSupportedException("Unsupported DDS texture format");

                if (num4 != 32 || num5 != 16711680 || num6 != 65280 || num7 != 255 || num8 != 4278190080u)
                    throw new NotSupportedException("Unsupported DDS texture format");

                format = SourceSurfaceFormat.ColorBgraEXT;
            }
        }
    }
}
