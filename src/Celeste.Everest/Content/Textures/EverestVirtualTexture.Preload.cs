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
        private bool Preload(bool force = false)
        {
            if (!Environment.Settings.LazyLoading && !force)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(Path))
            {
                string extension = System.IO.Path.GetExtension(Path);
                if (extension == ".data")
                {
                    using (FileStream input =
                           File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path)))
                    {
                        using BinaryReader binaryReader = new BinaryReader(input);
                        base.Width = binaryReader.ReadInt32();
                        base.Height = binaryReader.ReadInt32();
                    }

                    return true;
                }

                if (extension == ".png")
                {
                    using (FileStream stream =
                           File.OpenRead(ContentFilePath.Resolve(Environment.ContentDirectory, Path)))
                    {
                        return PreloadSizeFromPNG(stream, Path);
                    }
                }

                return false;
            }

            if (Metadata != null)
            {
                if (Metadata.Format == "png")
                {
                    using (Stream stream2 = Metadata.Stream)
                    {
                        return PreloadSizeFromPNG(stream2,
                            Metadata.PathVirtual + " (mod " + (Metadata.Source.Mod?.Name ?? "*unknown*") + ")");
                    }
                }

                return false;
            }

            return false;
        }

        private bool PreloadSizeFromPNG(Stream stream, string path)
        {
            using BinaryReader binaryReader = new BinaryReader(stream);
            ulong magic = binaryReader.ReadUInt64();
            if (magic != 727905341920923785UL)
            {
                Environment.Diagnostics.InvalidPngMagic(magic, path);
                return false;
            }

            uint length = binaryReader.ReadUInt32();
            if (length != 218103808)
            {
                Environment.Diagnostics.InvalidPngFirstChunkLength(length, path);
                return false;
            }

            uint marker = binaryReader.ReadUInt32();
            if (marker != 1380206665)
            {
                Environment.Diagnostics.InvalidPngHeaderMarker(marker, path);
                return false;
            }

            Width = SwapEndian(binaryReader.ReadInt32());
            Height = SwapEndian(binaryReader.ReadInt32());
            return true;
        }

        private static int SwapEndian(int data)
        {
            return ((data & 0xFF) << 24) | (((data >> 8) & 0xFF) << 16) | (((data >> 16) & 0xFF) << 8) |
                   ((data >> 24) & 0xFF);
        }
    }
}
