using Celeste.Everest.Content.Registry;
using System;
using System.IO;
using System.IO.Compression;

namespace Celeste.Everest.Content.Streams
{
    public class SynchronizedZipEntryStream : Stream
    {
        private readonly ZipArchive archive;
        private readonly IEverestContentDiagnostics Diagnostics;

        private readonly ZipArchiveEntry entry;

        private Stream wrappedStream;

        private long position;

        private const int trashbinSize = 8192;

        private static byte[] trashbin = new byte[8192];

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length { get; }

        public override long Position
        {
            get { return position; }
            set { Seek(value, SeekOrigin.Begin); }
        }

        public SynchronizedZipEntryStream(ZipArchiveEntry entry, IEverestContentDiagnostics diagnostics)
        {
            this.entry = entry;
            Diagnostics = diagnostics;
            archive = entry.Archive;
            Length = entry.Length;
            lock (archive)
            {
                reset();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            lock (archive)
            {
                int num = readAsMuchAsPossible(buffer, offset, count);
                position += num;
                return num;
            }
        }

        private void reset()
        {
            wrappedStream?.Close();
            wrappedStream = new BufferedStream(entry.Open());
            position = 0L;
        }

        protected override void Dispose(bool disposing)
        {
            lock (archive)
            {
                wrappedStream.Dispose();
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            lock (archive)
            {
                long num = offset;
                if (origin == SeekOrigin.Current)
                {
                    num += Position;
                }

                if (origin == SeekOrigin.End)
                {
                    num += Length;
                }

                if (num < Position)
                {
                    reset();
                }

                if (num > Position)
                {
                    skip((int)(num - Position));
                }

                if (num != Position)
                {
                    Diagnostics.Warning("SynchronizedZipEntryStream",
                        $"[{entry.FullName}] Couldn't seek to position {num}! Sought to {Position}/{Length}.");
                }

                return Position;
            }
        }

        private int readAsMuchAsPossible(byte[] buffer, int offset, int count)
        {
            int num = count;
            while (num > 0)
            {
                int num2 = wrappedStream.Read(buffer, offset, num);
                if (num2 == 0)
                {
                    break;
                }

                offset += num2;
                num -= num2;
            }

            return count - num;
        }

        private void skip(long count)
        {
            while (count > 0)
            {
                int num = wrappedStream.Read(trashbin, 0, (int)((count > 8192) ? 8192 : count));
                if (num == 0)
                {
                    break;
                }

                position += num;
                count -= num;
            }
        }

        public override void Flush()
        {
            throw new NotSupportedException("Write not supported!");
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("Write not supported!");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("Write not supported!");
        }
    }
}
