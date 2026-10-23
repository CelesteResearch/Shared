using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Celeste.Graphics.Rendering.Effects
{
    // The owner disposes this with its effect. Parameter views retain it; it never owns a GPU resource.
    public sealed class SourceEffectValueBuffer : IDisposable
    {
        private readonly byte[] managedValues;
        private readonly IntPtr address;
        private IntPtr pin;
        private bool disposed;
        public int Length { get; }

        public SourceEffectValueBuffer(byte[] values)
        {
            managedValues = values ?? throw new ArgumentNullException(nameof(values));
            Length = values.Length;
            var handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            pin = GCHandle.ToIntPtr(handle);
            address = handle.AddrOfPinnedObject();
        }

        // Borrowed storage remains owned by its native effect, including all external writes.
        public SourceEffectValueBuffer(IntPtr values, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            if (values == IntPtr.Zero && length != 0) throw new ArgumentNullException(nameof(values));
            address = values;
            Length = length;
        }

        public unsafe Span<byte> Values
        {
            get
            {
                if (disposed) throw new ObjectDisposedException(nameof(SourceEffectValueBuffer));
                return managedValues != null ? managedValues.AsSpan() : new((void*)address, Length);
            }
        }

        internal IntPtr GetAddress(int offset, int length)
        {
            if (disposed) throw new ObjectDisposedException(nameof(SourceEffectValueBuffer));
            if ((uint)offset > (uint)Length || (uint)length > (uint)(Length - offset))
                throw new ArgumentOutOfRangeException(nameof(offset));
            return IntPtr.Add(address, offset);
        }

        public SourceEffectValueBuffer Clone()
        {
            return new( /* ReSharper disable once UseCollectionExpression */ Values.ToArray());
        }

        ~SourceEffectValueBuffer()
        {
            Release();
        }

        public void Dispose()
        {
            Release();
            GC.SuppressFinalize(this);
        }

        private void Release()
        {
            disposed = true;
            var ownedPin = Interlocked.Exchange(ref pin, IntPtr.Zero);
            if (ownedPin != IntPtr.Zero) GCHandle.FromIntPtr(ownedPin).Free();
        }
    }
}
