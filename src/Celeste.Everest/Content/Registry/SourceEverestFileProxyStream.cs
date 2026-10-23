using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest.Content.Registry
{
    public sealed class SourceEverestFileProxyStream : FileStream
    {
        public readonly Stream Inner;

        public override bool CanRead => Inner.CanRead;

        public override bool CanSeek => Inner.CanSeek;

        public override bool CanWrite => Inner.CanWrite;

        public override long Length => Inner.Length;

        public override long Position
        {
            get => Inner.Position;
            set => Inner.Position = value;
        }

        public SourceEverestFileProxyStream(string dummy, Stream inner)
            : base(dummy, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite | FileShare.Delete)
        {
            Close();
            Inner = inner;
        }

        public override void Flush()
        {
            Inner.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Inner.Read(buffer, offset, count);
        }

        public override int Read(Span<byte> buffer)
        {
            return Inner.Read(buffer);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Inner.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Inner.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Inner.Write(buffer, offset, count);
        }

        public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback callback,
            object state)
        {
            return Inner.BeginRead(array, offset, count, callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return Inner.EndRead(asyncResult);
        }

        public override int ReadByte()
        {
            return Inner.ReadByte();
        }

        public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback callback,
            object state)
        {
            return Inner.BeginWrite(array, offset, count, callback, state);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            Inner.EndWrite(asyncResult);
        }

        public override void WriteByte(byte value)
        {
            Inner.WriteByte(value);
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return Inner.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return Inner.WriteAsync(buffer, offset, count, cancellationToken);
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Inner.FlushAsync(cancellationToken);
        }

        protected override void Dispose(bool disposing)
        {
            if (Inner == null)
                base.Dispose(disposing);
            else
                Inner.Dispose();
        }
    }
}
