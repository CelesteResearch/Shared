using System;
using System.IO;
using System.Threading;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public class VirtualTexture : VirtualAsset
    {
        private const int ByteArraySize = 524288;

        private const int ByteArrayCheckSize = 524256;


        protected readonly VirtualContent Owner;

        private SourceTexture2DResource texture;
        private readonly bool registeredMetadata;
        private bool disposed;
        internal bool ReloadWithOwner { get; private set; } = true;
        private static long resourceRevision;

        public static long ResourceRevision => Volatile.Read(ref resourceRevision);

        public SourceTexture2DResource Texture
        {
            get => texture ?? ReadMissingTexture();
            set
            {
                if (ReferenceEquals(texture, value)) return;
                texture = value;
                if (value != null) ReloadWithOwner = true;
                Interlocked.Increment(ref resourceRevision);
            }
        }

        protected PackedColor color;

        public string Path { get; protected set; }

        public virtual bool IsDisposed
        {
            get
            {
                if (texture != null && !texture.IsDisposed) return texture.GraphicsDevice.IsDisposed;

                return true;
            }
        }

        public virtual SourceTexture2DResource TextureSafe
        {
            get => Texture;
            set => Texture = value;
        }

        protected VirtualTexture(VirtualContent owner)
        {
            Owner = owner;
        }

        internal VirtualTexture(VirtualContent owner, string path)
        {
            Owner = owner;
            _ = owner.TextureData;
            Name = Path = path;
            Reload();
        }

        internal VirtualTexture(VirtualContent owner, string path, int width, int height)
        {
            Owner = owner;
            Name = Path = path;
            Width = width;
            Height = height;
            registeredMetadata = true;
            ReloadWithOwner = false;
        }

        private SourceTexture2DResource ReadMissingTexture()
        {
            if (registeredMetadata)
            {
                if (!disposed && Owner.TryReloadTextureOnRead(this)) return texture;
                throw new InvalidOperationException("The texture payload is not ready: " + Path);
            }

            return null;
        }

        internal VirtualTexture(VirtualContent owner, string name, int width, int height, PackedColor color)
        {
            Owner = owner;
            _ = owner.TextureData;
            Name = name;
            Width = width;
            Height = height;
            this.color = color;
            Reload();
        }

        public override void Unload()
        {
            if (texture != null && !texture.IsDisposed) texture.Dispose();

            Texture = null;
        }

        public override void Reload()
        {
            ReloadWithOwner = true;
            if (!registeredMetadata)
            {
                ReloadPayload();
                return;
            }

            try
            {
                ReloadPayload();
            }
            catch
            {
                var failed = texture;
                Texture = null;
                if (failed != null && !failed.IsDisposed) failed.Dispose();
                throw;
            }
        }

        private unsafe void ReloadPayload()
        {
            Unload();
            var bytes = Owner.TextureData.Bytes;
            var buffer = Owner.TextureData.Buffer;
            if (string.IsNullOrEmpty(Path))
            {
                Texture = Owner.Environment.TextureFactory.CreateTexture(Name, Width, Height);
                Texture.SetData(SourceDataTextureInitialColor.Create(Width, Height, color));
                return;
            }

            switch (System.IO.Path.GetExtension(Path))
            {
                case ".data":
                {
                    using (var fileStream =
                           Owner.Environment.ContentFiles.OpenTitleStream(
                               System.IO.Path.Combine(Owner.Environment.ContentDirectory, Path)))
                    {
                        ReadTextureData(fileStream, bytes, 0, ByteArraySize);
                        var num2 = 0;
                        var num3 = BitConverter.ToInt32(bytes, num2);
                        var num4 = BitConverter.ToInt32(bytes, num2 + 4);
                        var flag = bytes[num2 + 8] == 1;
                        num2 += 9;
                        var num5 = num3 * num4 * 4;
                        var num6 = 0;
                        fixed (byte* ptr3 = bytes)
                        {
                            fixed (byte* ptr4 = buffer)
                            {
                                while (num6 < num5)
                                {
                                    var num7 = ptr3[num2] * 4;
                                    if (flag)
                                    {
                                        var b = ptr3[num2 + 1];
                                        if (b > 0)
                                        {
                                            ptr4[num6] = ptr3[num2 + 4];
                                            ptr4[num6 + 1] = ptr3[num2 + 3];
                                            ptr4[num6 + 2] = ptr3[num2 + 2];
                                            ptr4[num6 + 3] = b;
                                            num2 += 5;
                                        }
                                        else
                                        {
                                            ptr4[num6] = 0;
                                            ptr4[num6 + 1] = 0;
                                            ptr4[num6 + 2] = 0;
                                            ptr4[num6 + 3] = 0;
                                            num2 += 2;
                                        }
                                    }
                                    else
                                    {
                                        ptr4[num6] = ptr3[num2 + 3];
                                        ptr4[num6 + 1] = ptr3[num2 + 2];
                                        ptr4[num6 + 2] = ptr3[num2 + 1];
                                        ptr4[num6 + 3] = byte.MaxValue;
                                        num2 += 4;
                                    }

                                    if (num7 > 4)
                                    {
                                        var k = num6 + 4;
                                        for (var num8 = num6 + num7; k < num8; k += 4)
                                        {
                                            ptr4[k] = ptr4[num6];
                                            ptr4[k + 1] = ptr4[num6 + 1];
                                            ptr4[k + 2] = ptr4[num6 + 2];
                                            ptr4[k + 3] = ptr4[num6 + 3];
                                        }
                                    }

                                    num6 += num7;
                                    if (num2 > ByteArrayCheckSize)
                                    {
                                        var num9 = ByteArraySize - num2;
                                        for (var l = 0; l < num9; l++) ptr3[l] = ptr3[num2 + l];

                                        ReadTextureData(fileStream, bytes, num9, ByteArraySize - num9);
                                        num2 = 0;
                                    }
                                }
                            }
                        }

                        Texture = Owner.Environment.TextureFactory.CreateTexture(Name, num3, num4);
                        Texture.SetData(buffer, 0, num5);
                    }

                    break;
                }
                case ".png":
                {
                    using (var stream2 =
                           Owner.Environment.ContentFiles.OpenTitleStream(
                               System.IO.Path.Combine(Owner.Environment.ContentDirectory, Path)))
                    {
                        Texture = Owner.Environment.TextureFactory.FromStream(stream2, true);
                    }

                    break;
                }
                case ".xnb":
                {
                    var assetName = Path.Replace(".xnb", "");
                    Texture = Owner.Environment.TextureFactory.LoadContent(assetName);
                    break;
                }
                default:
                {
                    using (var stream =
                           Owner.Environment.ContentFiles.OpenTitleStream(
                               System.IO.Path.Combine(Owner.Environment.ContentDirectory, Path)))
                    {
                        Texture = Owner.Environment.TextureFactory.FromStream(stream);
                    }

                    break;
                }
            }

            if (registeredMetadata && (Texture.Width != Width || Texture.Height != Height))
                throw new InvalidDataException("The texture payload dimensions do not match registered metadata: " +
                                               Path + " (expected " + Width + "x" + Height + ", actual " +
                                               Texture.Width + "x" + Texture.Height + ")");

            Width = Texture.Width;
            Height = Texture.Height;
        }

        private static void ReadTextureData(Stream stream, byte[] bytes, int offset, int count)
        {
            while (count != 0)
            {
                var read = stream.Read(bytes, offset, count);
                if (read == 0) break;
                offset += read;
                count -= read;
            }
        }

        public override void Dispose()
        {
            disposed = true;
            Unload();
            Texture = null;
            Owner.Remove(this);
        }
    }
}
