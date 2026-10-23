using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;

namespace Celeste.Game.Runtime.Physical.Networking
{
    /// Matches the .NET 8 HTTP deflate heuristic: first nibble 8 selects RFC1950, otherwise RFC1951.
    internal sealed class SourceMonoHttpDeflateStream : Stream
    {
        private Stream input;
        private Stream decoder;

        internal SourceMonoHttpDeflateStream(Stream input)
        {
            this.input = input;
        }

        public override bool CanRead => input?.CanRead == true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        private void ValidateRead(byte[] buffer, int offset, int count)
        {
            if (input == null) throw new ObjectDisposedException(nameof(SourceMonoHttpDeflateStream));
            ValidateBuffer(buffer, offset, count);
        }

        private static void ValidateBuffer(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (buffer.Length - offset < count)
                throw new ArgumentException("Offset and count exceed the buffer bounds.");
        }

        private Stream CreateDecoder(int first)
        {
            var replay = new ReplayFirstByteStream(input, first);
            return first >= 0 && (first & 0x0f) == 8
                ? new SourceMonoHttpZlibStream(replay)
                : new DeflateStream(replay, CompressionMode.Decompress);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            ValidateRead(buffer, offset, count);
            decoder ??= CreateDecoder(input.ReadByte());
            try
            {
                return decoder.Read(buffer, offset, count);
            }
            catch (SharpZipBaseException exception)
            {
                throw new InvalidDataException("The HTTP zlib stream is invalid.", exception);
            }
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            ValidateRead(buffer, offset, count);
            return ReadAsyncCore(buffer, offset, count, cancellationToken);
        }

        private async Task<int> ReadAsyncCore(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (decoder == null)
            {
                var first = new byte[1];
                var read = await input.ReadAsync(first, 0, 1, cancellationToken).ConfigureAwait(false);
                decoder = CreateDecoder(read == 0 ? -1 : first[0]);
            }

            try
            {
                return await decoder.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            catch (SharpZipBaseException exception)
            {
                throw new InvalidDataException("The HTTP zlib stream is invalid.", exception);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (decoder != null) decoder.Dispose();
                else input?.Dispose();
                decoder = null;
                input = null;
            }

            base.Dispose(disposing);
        }

        private sealed class ReplayFirstByteStream : Stream
        {
            private readonly Stream stream;
            private int first;
            private bool disposed;

            internal ReplayFirstByteStream(Stream stream, int first)
            {
                this.stream = stream;
                this.first = first;
            }

            public override bool CanRead => !disposed && stream.CanRead;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();

            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public override void Flush()
            {
                throw new NotSupportedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (disposed) throw new ObjectDisposedException(nameof(ReplayFirstByteStream));
                ValidateBuffer(buffer, offset, count);
                if (!(first >= 0))
                    return stream.Read(buffer, offset, count);
                if (count == 0) return 0;
                buffer[offset] = (byte)first;
                first = -1;
                return 1;
            }

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count,
                CancellationToken cancellationToken)
            {
                if (disposed) throw new ObjectDisposedException(nameof(ReplayFirstByteStream));
                ValidateBuffer(buffer, offset, count);
                cancellationToken.ThrowIfCancellationRequested();
                if (!(first >= 0))
                    return stream.ReadAsync(buffer, offset, count, cancellationToken);
                if (count == 0) return Task.FromResult(0);
                buffer[offset] = (byte)first;
                first = -1;
                return Task.FromResult(1);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing && !disposed)
                {
                    disposed = true;
                    stream.Dispose();
                }

                base.Dispose(disposing);
            }
        }
    }
}
