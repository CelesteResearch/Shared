using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.Textures;

namespace Celeste.Everest.Content.Textures
{
    public sealed partial class EverestVirtualTexture
    {
        public override unsafe void Reload()
        {
            if (Environment.IsHeadless)
            {
                Texture = Environment.TextureFactory.CreateTexture(Name, 1, 1);
                return;
            }

            var queuedLoadLock = _Texture_QueuedLoadLock;
            if (queuedLoadLock != null && !_Texture_Reloading)
            {
                lock (queuedLoadLock)
                {
                    if (_Texture_QueuedLoadLock != queuedLoadLock) return;

                    if (Environment.MainThread.IsMainThread) _Texture_QueuedLoadLock = null;
                }

                if (!Environment.MainThread.IsMainThread)
                {
                    _ = _Texture_QueuedLoad.Result;
                    return;
                }
            }

            if (Environment.FastLoading.Enabled && CanPreload)
            {
                var metadata = Metadata;
                if ((metadata == null || metadata.StreamAsync) && !_Texture_Reloading && !_Texture_Requesting &&
                    Preload(true))
                {
                    Environment.FastLoading.Count(ref _Texture_FTLCount);
                    lock (queuedLoadLock = new())
                    {
                        _Texture_QueuedLoadLock = queuedLoadLock;
                        _Texture_QueuedLoad = new(Task.Run(delegate
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
                                    if (_Texture_QueuedLoadLock == queuedLoadLock) _Texture_QueuedLoadLock = null;

                                    var texture2 = Texture;
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
                    var stream = Metadata.Stream;
                    if (stream != null)
                    {
                        using (stream)
                        {
                            var flag = false;
                            if (Metadata.TryGetMeta<EverestTextureMetadata>(out var meta)) flag = meta.Premultiplied;

                            int w;
                            int h;
                            IntPtr dataPtr;
                            if (flag)
                                dataPtr = ReadImage(stream, false, out w, out h);
                            else
                                dataPtr = ReadImage(stream, true, out w, out h);

                            stream.Dispose();
                            Width = w;
                            Height = h;
                            Load(false, delegate
                            {
                                var texture2D =
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
                    Load(true, delegate
                    {
                        using var stream4 = Metadata.Stream;
                        if (stream4 != null)
                        {
                            var flag3 = false;
                            if (Metadata.TryGetMeta<EverestTextureMetadata>(out var meta2)) flag3 = meta2.Premultiplied;

                            if (flag3) return Environment.TextureFactory.FromStream(stream4);

                            var data2 = ReadImage(stream4, true, out var w3, out var h3);
                            var texture2D = Environment.TextureFactory.CreateTexture(Name, w3, h3);
                            texture2D.SetDataPointerEXT(0, null, data2, w3 * h3 * 4);
                            Environment.ImageCodec.Free(data2);
                            return texture2D;
                        }

                        if (Fallback != null)
                        {
                            Fallback.Reload();
                            return Fallback.TextureSafe;
                        }

                        return null;
                    });
                }
            }
            else if (string.IsNullOrEmpty(Path))
            {
                var data = SourceDataTextureInitialColor.Create(Width, Height, color);
                Load(false, delegate
                {
                    var texture2D = Environment.TextureFactory.CreateTexture(Name, Width, Height);
                    texture2D.SetData(data);
                    data = null;
                    return texture2D;
                });
            }
            else
            {
                var bufferGc = false;
                byte[] buffer = null;
                var bufferPtr = IntPtr.Zero;
                var bufferStolen = false;
                int w2;
                int h2;
                switch (System.IO.Path.GetExtension(Path))
                {
                    case ".data":
                    {
                        using (var fileStream =
                               File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path)))
                        {
                            var array = Environment.Buffers.Bytes;
                            fileStream.Read(array, 0, array.Length);
                            var num2 = 0;
                            w2 = BitConverter.ToInt32(array, num2);
                            h2 = BitConverter.ToInt32(array, num2 + 4);
                            var flag2 = array[num2 + 8] == 1;
                            num2 += 9;
                            Width = w2;
                            Height = h2;
                            var num3 = w2 * h2 * 4;
                            if (num3 == 67108864)
                                lock (Environment.Buffers.BufferLock)
                                {
                                    buffer = Environment.Buffers.Buffer;
                                    Environment.Buffers.Buffer = null;
                                    bufferStolen = true;
                                    bufferGc = true;
                                }

                            if (buffer == null)
                            {
                                if (bufferGc)
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
                                    var ptr4 = bufferGc ? ptr3 : (byte*)bufferPtr;
                                    var ptr5 = (int*)ptr4;
                                    var num4 = 0u;
                                    var num5 = 0u;
                                    if (flag2)
                                        while (num4 < num3)
                                        {
                                            uint num6 = ptr2[num2];
                                            var b = ptr2[num2 + 1];
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
                                                    var num7 = num5 + 1;
                                                    for (var num8 = num5 + num6; num7 < num8; num7++)
                                                        ptr5[num7] = ptr5[num5];
                                                }
                                            }

                                            num5 += num6;
                                            num4 = num5 * 4;
                                            if (num2 > array.Length - 32)
                                            {
                                                var num9 = array.Length - num2;
                                                for (var num10 = 0; num10 < num9; num10++)
                                                    ptr2[num10] = ptr2[num2 + num10];

                                                fileStream.Read(array, num9, array.Length - num9);
                                                num2 = 0;
                                            }
                                        }
                                    else
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
                                                var num12 = num5 + 1;
                                                for (var num13 = num5 + num11; num12 < num13; num12++)
                                                    ptr5[num12] = ptr5[num5];
                                            }

                                            num5 += num11;
                                            num4 = num5 * 4;
                                            if (num2 > 524256)
                                            {
                                                var num14 = array.Length - num2;
                                                for (var num15 = 0; num15 < num14; num15++)
                                                    ptr2[num15] = ptr2[num2 + num15];

                                                fileStream.Read(array, num14, array.Length - num14);
                                                num2 = 0;
                                            }
                                        }
                                }
                            }
                        }

                        Load(false, delegate
                        {
                            var texture2D = Environment.TextureFactory.CreateTexture(Name, w2, h2);
                            if (bufferGc)
                            {
                                texture2D.SetData(buffer);
                                if (bufferStolen) Environment.Buffers.Buffer = buffer;

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
                        using (var stream3 =
                               File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path)))
                        {
                            bufferPtr = ReadImage(stream3, true, out w2, out h2);
                        }

                        Width = w2;
                        Height = h2;
                        Load(false, delegate
                        {
                            var texture2D = Environment.TextureFactory.CreateTexture(Name, w2, h2);
                            texture2D.SetDataPointerEXT(0, null, bufferPtr, w2 * h2 * 4);
                            Environment.ImageCodec.Free(bufferPtr);
                            return texture2D;
                        });
                        break;
                    }
                    case ".xnb":
                        Load(true, () => Environment.TextureFactory.LoadContent(Path.Replace(".xnb", "")));
                        break;
                    default:
                        Load(true, delegate
                        {
                            using var stream4 =
                                File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path));
                            return Environment.TextureFactory.FromStream(stream4);
                        });
                        break;
                }
            }

            var texture = Texture;
            if (texture != null)
            {
                Width = texture.Width;
                Height = texture.Height;
            }

            _Texture_Requesting = false;
        }

        private IntPtr ReadImage(Stream stream, bool premultiply, out int width, out int height)
        {
            var data = Environment.ImageCodec.ReadImageStream(stream, out width, out height, out var byteCount);
            if (premultiply) SourceTexturePremultiplication.PremultiplyPreservingTransparentRgb(data, byteCount);
            return data;
        }
    }
}
