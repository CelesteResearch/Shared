using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace Celeste.Game.Runtime.Physical.Networking
{
    /// RFC1950 header and Adler32 are validated by the official inflater; async input retains cancellation.
    internal sealed class SourceMonoHttpZlibStream : Stream
    {
        private readonly Stream input;
        private readonly Inflater inflater = new(noHeader: false);
        private readonly byte[] compressed = new byte[8192];
        private bool disposed;
        internal SourceMonoHttpZlibStream(Stream input) => this.input = input;
        public override bool CanRead => !disposed && input.CanRead;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush() => throw new NotSupportedException();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        private void Validate(byte[] buffer, int offset, int count)
        {
            if (disposed) throw new ObjectDisposedException(nameof(SourceMonoHttpZlibStream));
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            if (offset < 0 || count < 0 || offset > buffer.Length - count) throw new ArgumentOutOfRangeException();
        }

        private int Inflate(byte[] buffer, int offset, int count)
        {
            try
            {
                return inflater.Inflate(buffer, offset, count);
            }
            catch (SharpZipBaseException exception)
            {
                throw new InvalidDataException("The HTTP zlib stream is invalid.", exception);
            }
        }

        private bool NeedsInput()
        {
            if (inflater.IsNeedingDictionary)
                throw new InvalidDataException("The HTTP zlib stream requires an unsupported dictionary.");
            if (!inflater.IsNeedingInput) throw new InvalidDataException("The HTTP zlib stream cannot progress.");
            return true;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            Validate(buffer, offset, count);
            if (count == 0) return 0;
            while (true)
            {
                int read = Inflate(buffer, offset, count);
                if (read != 0 || inflater.IsFinished) return read;
                if (NeedsInput())
                {
                    int available = input.Read(compressed, 0, compressed.Length);
                    if (available == 0)
                        throw new InvalidDataException("The HTTP zlib stream ended before its checksum.");
                    inflater.SetInput(compressed, 0, available);
                }
            }
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count,
            CancellationToken cancellationToken)
        {
            Validate(buffer, offset, count);
            cancellationToken.ThrowIfCancellationRequested();
            if (count == 0) return 0;
            while (true)
            {
                int read = Inflate(buffer, offset, count);
                if (read != 0 || inflater.IsFinished) return read;
                if (NeedsInput())
                {
                    int available = await input.ReadAsync(compressed, 0, compressed.Length, cancellationToken)
                        .ConfigureAwait(false);
                    if (available == 0)
                        throw new InvalidDataException("The HTTP zlib stream ended before its checksum.");
                    inflater.SetInput(compressed, 0, available);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                disposed = true;
                input.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
