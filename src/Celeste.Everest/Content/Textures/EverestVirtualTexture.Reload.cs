using Celeste.Graphics.Rendering.Textures;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Runtime.Threading;

namespace Celeste.Everest.Content.Textures
{
    public sealed partial class EverestVirtualTexture
    {
        public unsafe override void Reload()
        {
            if (Environment.IsHeadless)
            {
                Texture = Environment.TextureFactory.CreateTexture(Name, 1, 1);
                return;
            }

            object queuedLoadLock = _Texture_QueuedLoadLock;
            if (queuedLoadLock != null && !_Texture_Reloading)
            {
                lock (queuedLoadLock)
                {
                    if (_Texture_QueuedLoadLock != queuedLoadLock)
                    {
                        return;
                    }

                    if (Environment.MainThread.IsMainThread)
                    {
                        _Texture_QueuedLoadLock = null;
                    }
                }

                if (!Environment.MainThread.IsMainThread)
                {
                    _ = _Texture_QueuedLoad.Result;
                    return;
                }
            }

            if (Environment.FastLoading.Enabled && CanPreload)
            {
                EverestContentAsset metadata = Metadata;
                if ((metadata == null || metadata.StreamAsync) && !_Texture_Reloading && !_Texture_Requesting &&
                    Preload(force: true))
                {
                    Environment.FastLoading.Count(ref _Texture_FTLCount);
                    lock (queuedLoadLock = new object())
                    {
                        _Texture_QueuedLoadLock = queuedLoadLock;
                        _Texture_QueuedLoad = new ValueTask<SourceTexture2DResource>(Task.Run(delegate
                        {
                            try
                            {
                                lock (queuedLoadLock)
                                {
                                    if (_Texture_QueuedLoadLock != queuedLoadLock)
                                    {
                                        Environment.FastLoading.Free(ref _Texture_FTLCount, ref _Texture_FTLLoading,
                                            ref _Texture_FTLSize);
                                        return Texture;
                                    }

                                    Environment.FastLoading.Grab(Width, Height, Name, ref _Texture_FTLLoading,
                                        ref _Texture_FTLSize);
                                    _Texture_Reloading = true;
                                    Reload();
                                    if (_Texture_QueuedLoadLock == queuedLoadLock)
                                    {
                                        _Texture_QueuedLoadLock = null;
                                    }

                                    SourceTexture2DResource texture2 = Texture;
                                    if (_Texture_UnloadAfterReload)
                                    {
                                        texture2?.Dispose();
                                        texture2 = Texture;
                                        Texture = null;
                                        texture2?.Dispose();
                                        _Texture_UnloadAfterReload = false;
                                    }

                                    return texture2;
                                }
                            }
                            catch (Exception e)
                            {
                                Environment.Failures.CriticalFailure(e);
                                throw;
                            }
                        }));
                        return;
                    }
                }
            }

            _Texture_Reloading = false;
            if (Metadata != null)
            {
                if (Metadata.StreamAsync || Environment.MainThread.IsMainThread)
                {
                    Stream stream = Metadata.Stream;
                    if (stream != null)
                    {
                        using (stream)
                        {
                            bool flag = false;
                            if (Metadata.TryGetMeta<EverestTextureMetadata>(out var meta))
                            {
                                flag = meta.Premultiplied;
                            }

                            int w;
                            int h;
                            IntPtr dataPtr;
                            if (flag)
                            {
                                dataPtr = ReadImage(stream, false, out w, out h);
                            }
                            else
                            {
                                dataPtr = ReadImage(stream, true, out w, out h);
                            }

                            stream.Dispose();
                            base.Width = w;
                            base.Height = h;
                            Load(wait: false, delegate
                            {
                                SourceTexture2DResource texture2D =
                                    Environment.TextureFactory.CreateTexture(Name, w, h);
                                texture2D.SetDataPointerEXT(0, null, dataPtr, w * h * 4);
                                Environment.ImageCodec.Free(dataPtr);
                                return texture2D;
                            });
                        }
                    }
                    else if (Fallback != null)
                    {
                        Fallback.Reload();
                        Texture = Fallback.TextureSafe;
                    }
                }
                else
                {
                    Load(wait: true, delegate
                    {
                        using Stream stream4 = Metadata.Stream;
                        if (stream4 != null)
                        {
                            bool flag3 = false;
                            if (Metadata.TryGetMeta<EverestTextureMetadata>(out var meta2))
                            {
                                flag3 = meta2.Premultiplied;
                            }

                            if (flag3)
                            {
                                return Environment.TextureFactory.FromStream(stream4);
                            }

                            IntPtr data2 = ReadImage(stream4, true, out int w3, out int h3);
                            SourceTexture2DResource texture2D = Environment.TextureFactory.CreateTexture(Name, w3, h3);
                            texture2D.SetDataPointerEXT(0, null, data2, w3 * h3 * 4);
                            Environment.ImageCodec.Free(data2);
                            return texture2D;
                        }

                        if (Fallback != null)
                        {
                            Fallback.Reload();
                            return Fallback.TextureSafe;
                        }

                        return (SourceTexture2DResource)null;
                    });
                }
            }
            else if (string.IsNullOrEmpty(Path))
            {
                byte[] data = SourceDataTextureInitialColor.Create(Width, Height, color);
                Load(wait: false, delegate
                {
                    SourceTexture2DResource texture2D = Environment.TextureFactory.CreateTexture(Name, Width, Height);
                    texture2D.SetData(data);
                    data = null;
                    return texture2D;
                });
            }
            else
            {
                bool bufferGC = false;
                byte[] buffer = null;
                IntPtr bufferPtr = IntPtr.Zero;
                bool bufferStolen = false;
                int w2;
                int h2;
                switch (System.IO.Path.GetExtension(Path))
                {
                    case ".data":
                    {
                        using (FileStream fileStream =
                               File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path)))
                        {
                            byte[] array = Environment.Buffers.Bytes;
                            fileStream.Read(array, 0, array.Length);
                            int num2 = 0;
                            w2 = BitConverter.ToInt32(array, num2);
                            h2 = BitConverter.ToInt32(array, num2 + 4);
                            bool flag2 = array[num2 + 8] == 1;
                            num2 += 9;
                            base.Width = w2;
                            base.Height = h2;
                            int num3 = w2 * h2 * 4;
                            if (num3 == 67108864)
                            {
                                lock (Environment.Buffers.BufferLock)
                                {
                                    buffer = Environment.Buffers.Buffer;
                                    Environment.Buffers.Buffer = null;
                                    bufferStolen = true;
                                    bufferGC = true;
                                }
                            }

                            if (buffer == null)
                            {
                                if (bufferGC)
                                {
                                    buffer = new byte[num3];
                                }
                                else
                                {
                                    buffer = null;
                                    bufferPtr = Marshal.AllocHGlobal(num3);
                                }

                                bufferStolen = false;
                            }

                            fixed (byte* ptr2 = array)
                            {
                                fixed (byte* ptr3 = buffer)
                                {
                                    byte* ptr4 = (bufferGC ? ptr3 : ((byte*)bufferPtr));
                                    int* ptr5 = (int*)ptr4;
                                    uint num4 = 0u;
                                    uint num5 = 0u;
                                    if (flag2)
                                    {
                                        while (num4 < num3)
                                        {
                                            uint num6 = ptr2[num2];
                                            byte b = ptr2[num2 + 1];
                                            if (b > 0)
                                            {
                                                ptr4[num4] = ptr2[num2 + 4];
                                                ptr4[num4 + 1] = ptr2[num2 + 3];
                                                ptr4[num4 + 2] = ptr2[num2 + 2];
                                                ptr4[num4 + 3] = b;
                                                num2 += 5;
                                            }
                                            else
                                            {
                                                ptr5[num5] = 0;
                                                num2 += 2;
                                            }

                                            if (num6 > 1)
                                            {
                                                if (b == 0)
                                                {
                                                    // IL initblk instruction
                                                    new Span<byte>(ptr4 + num4 + 4, (int)(num6 * 4 - 4)).Clear();
                                                }
                                                else
                                                {
                                                    uint num7 = num5 + 1;
                                                    for (uint num8 = num5 + num6; num7 < num8; num7++)
                                                    {
                                                        ptr5[num7] = ptr5[num5];
                                                    }
                                                }
                                            }

                                            num5 += num6;
                                            num4 = num5 * 4;
                                            if (num2 > array.Length - 32)
                                            {
                                                int num9 = array.Length - num2;
                                                for (int num10 = 0; num10 < num9; num10++)
                                                {
                                                    ptr2[num10] = ptr2[num2 + num10];
                                                }

                                                fileStream.Read(array, num9, array.Length - num9);
                                                num2 = 0;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        while (num4 < num3)
                                        {
                                            uint num11 = ptr2[num2];
                                            ptr4[num4] = ptr2[num2 + 3];
                                            ptr4[num4 + 1] = ptr2[num2 + 2];
                                            ptr4[num4 + 2] = ptr2[num2 + 1];
                                            ptr4[num4 + 3] = byte.MaxValue;
                                            num2 += 4;
                                            if (num11 > 1)
                                            {
                                                uint num12 = num5 + 1;
                                                for (uint num13 = num5 + num11; num12 < num13; num12++)
                                                {
                                                    ptr5[num12] = ptr5[num5];
                                                }
                                            }

                                            num5 += num11;
                                            num4 = num5 * 4;
                                            if (num2 > 524256)
                                            {
                                                int num14 = array.Length - num2;
                                                for (int num15 = 0; num15 < num14; num15++)
                                                {
                                                    ptr2[num15] = ptr2[num2 + num15];
                                                }

                                                fileStream.Read(array, num14, array.Length - num14);
                                                num2 = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        Load(wait: false, delegate
                        {
                            SourceTexture2DResource texture2D = Environment.TextureFactory.CreateTexture(Name, w2, h2);
                            if (bufferGC)
                            {
                                texture2D.SetData(buffer);
                                if (bufferStolen)
                                {
                                    Environment.Buffers.Buffer = buffer;
                                }

                                buffer = null;
                            }
                            else
                            {
                                texture2D.SetDataPointerEXT(0, null, bufferPtr, w2 * h2 * 4);
                                Marshal.FreeHGlobal(bufferPtr);
                            }

                            return texture2D;
                        });
                        break;
                    }
                    case ".png":
                    {
                        using (FileStream stream3 =
                               File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path)))
                        {
                            bufferPtr = ReadImage(stream3, true, out w2, out h2);
                        }

                        base.Width = w2;
                        base.Height = h2;
                        Load(wait: false, delegate
                        {
                            SourceTexture2DResource texture2D = Environment.TextureFactory.CreateTexture(Name, w2, h2);
                            texture2D.SetDataPointerEXT(0, null, bufferPtr, w2 * h2 * 4);
                            Environment.ImageCodec.Free(bufferPtr);
                            return texture2D;
                        });
                        break;
                    }
                    case ".xnb":
                        Load(wait: true, () => Environment.TextureFactory.LoadContent(Path.Replace(".xnb", "")));
                        break;
                    default:
                        Load(wait: true, delegate
                        {
                            using FileStream stream4 =
                                File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path));
                            return Environment.TextureFactory.FromStream(stream4);
                        });
                        break;
                }
            }

            SourceTexture2DResource texture = Texture;
            if (texture != null)
            {
                base.Width = texture.Width;
                base.Height = texture.Height;
            }

            _Texture_Requesting = false;
        }

        private IntPtr ReadImage(Stream stream, bool premultiply, out int width, out int height)
        {
            IntPtr data = Environment.ImageCodec.ReadImageStream(stream, out width, out height, out int byteCount);
            if (premultiply) SourceTexturePremultiplication.PremultiplyPreservingTransparentRgb(data, byteCount);
            return data;
        }
    }
}
