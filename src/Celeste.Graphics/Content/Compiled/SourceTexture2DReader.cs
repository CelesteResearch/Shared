using System;
using System.IO;
using System.Runtime.CompilerServices;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceTexture2DReader : SourceContentTypeReader<SourceTexture2DResource>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceTexture2DReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceTexture2DResource Read(SourceContentReader reader,
            SourceTexture2DResource existingInstance)
        {
            SourceTexture2DResource texture2D = null;
            var surfaceFormat = reader.version >= 5
                ? (SourceSurfaceFormat)reader.ReadInt32()
                : reader.ReadInt32() switch
                {
                    1 => SourceSurfaceFormat.ColorBgraEXT,
                    28 => SourceSurfaceFormat.Dxt1,
                    30 => SourceSurfaceFormat.Dxt3,
                    32 => SourceSurfaceFormat.Dxt5,
                    _ => throw new NotSupportedException("Unsupported legacy surface format."),
                };
            var num = reader.ReadInt32();
            var num2 = reader.ReadInt32();
            var num3 = reader.ReadInt32();
            var num4 = num3;
            var graphicsDevice = reader.ContentManager.GetGraphicsDevice();
            var surfaceFormat2 = surfaceFormat;
            if (surfaceFormat == SourceSurfaceFormat.Dxt1 && graphicsDevice.TextureIO.SupportsDXT1() == 0)
                surfaceFormat2 = SourceSurfaceFormat.Color;
            else if ((surfaceFormat == SourceSurfaceFormat.Dxt3 || surfaceFormat == SourceSurfaceFormat.Dxt5) &&
                     graphicsDevice.TextureIO.SupportsS3TC() == 0)
                surfaceFormat2 = SourceSurfaceFormat.Color;

            texture2D = existingInstance != null
                ? existingInstance
                : new(graphicsDevice, num, num2, num4 > 1, surfaceFormat2);
            for (var i = 0; i < num3; i++)
            {
                var num5 = reader.ReadInt32();
                byte[] buffer = null;
                var width = num >> i;
                var height = num2 >> i;
                if (i >= num4) continue;

                if (reader.platform == 'x')
                    switch (surfaceFormat)
                    {
                        case SourceSurfaceFormat.Color:
                        case SourceSurfaceFormat.ColorBgraEXT:
                            buffer = SourceX360TexUtil.SwapColor(reader.ReadBytes(num5));
                            num5 = buffer.Length;
                            break;
                        case SourceSurfaceFormat.Dxt1:
                            buffer = SourceX360TexUtil.SwapDxt1(reader.ReadBytes(num5), width, height);
                            num5 = buffer.Length;
                            break;
                        case SourceSurfaceFormat.Dxt3:
                            buffer = SourceX360TexUtil.SwapDxt3(reader.ReadBytes(num5), width, height);
                            num5 = buffer.Length;
                            break;
                        case SourceSurfaceFormat.Dxt5:
                            buffer = SourceX360TexUtil.SwapDxt5(reader.ReadBytes(num5), width, height);
                            num5 = buffer.Length;
                            break;
                    }

                if (surfaceFormat2 != surfaceFormat)
                {
                    if (buffer == null) buffer = reader.ReadBytes(num5);

                    switch (surfaceFormat)
                    {
                        case SourceSurfaceFormat.Dxt1:
                            buffer = SourceDxtUtil.DecompressDxt1(buffer, width, height);
                            break;
                        case SourceSurfaceFormat.Dxt3:
                            buffer = SourceDxtUtil.DecompressDxt3(buffer, width, height);
                            break;
                        case SourceSurfaceFormat.Dxt5:
                            buffer = SourceDxtUtil.DecompressDxt5(buffer, width, height);
                            break;
                    }

                    num5 = buffer.Length;
                }

                var startIndex = 0;
                if (buffer == null)
                {
                    if (reader.BaseStream is MemoryStream &&
                        ((MemoryStream)reader.BaseStream).TryGetBuffer(out buffer))
                    {
                        startIndex = (int)reader.BaseStream.Seek(0L, SeekOrigin.Current);
                        reader.BaseStream.Seek(num5, SeekOrigin.Current);
                    }
                    else
                    {
                        buffer = reader.ReadBytes(num5);
                    }
                }

                texture2D.SetData(i, null, buffer, startIndex, num5);
            }

            return texture2D;
        }
    }
}
