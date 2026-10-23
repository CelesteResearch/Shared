using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
    /// <summary>
    ///     This class is general purpose class for writing data to a buffer.
    ///     It allows you to write bits as well as bytes
    ///     Based on DeflaterPending.java
    ///     author of the original java version : Jochen Hoenicke
    /// </summary>
    public class PendingBuffer
    {
        /// <summary>
        ///     Clear internal state/buffers
        /// </summary>
        public void Reset()
        {
            _start = _end = _bitCount = 0;
        }

        /// <summary>
        ///     Write a byte to buffer
        /// </summary>
        /// <param name="value">
        ///     The value to write
        /// </param>
        public void WriteByte(int value)
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _start != 0) throw new SharpZipBaseException("Debug check: start != 0");
// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            _buffer[_end++] = unchecked((byte)value);
        }

        /// <summary>
        ///     Write a short value to buffer LSB first
        /// </summary>
        /// <param name="value">
        ///     The value to write.
        /// </param>
        public void WriteShort(int value)
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _start != 0) throw new SharpZipBaseException("Debug check: start != 0");
// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            _buffer[_end++] = unchecked((byte)value);
            _buffer[_end++] = unchecked((byte)(value >> 8));
        }

        /// <summary>
        ///     write an integer LSB first
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteInt(int value)
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _start != 0) throw new SharpZipBaseException("Debug check: start != 0");
// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            _buffer[_end++] = unchecked((byte)value);
            _buffer[_end++] = unchecked((byte)(value >> 8));
            _buffer[_end++] = unchecked((byte)(value >> 16));
            _buffer[_end++] = unchecked((byte)(value >> 24));
        }

        /// <summary>
        ///     Write a block of data to buffer
        /// </summary>
        /// <param name="block">data to write</param>
        /// <param name="offset">offset of first byte to write</param>
        /// <param name="length">number of bytes to write</param>
        public void WriteBlock(byte[] block, int offset, int length)
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _start != 0) throw new SharpZipBaseException("Debug check: start != 0");
// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            Array.Copy(block, offset, _buffer, _end, length);
            _end += length;
        }

        /// <summary>
        ///     The number of bits written to the buffer
        /// </summary>
        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int BitCount => _bitCount;

        /// <summary>
        ///     Align internal buffer on a byte boundary
        /// </summary>
        public void AlignToByte()
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _start != 0) throw new SharpZipBaseException("Debug check: start != 0");
// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            if (BitCount > 0)
            {
                _buffer[_end++] = unchecked((byte)_bits);
                if (BitCount > 8) _buffer[_end++] = unchecked((byte)(_bits >> 8));
            }

            _bits = 0;
            _bitCount = 0;
        }

        /// <summary>
        ///     Write bits to internal buffer
        /// </summary>
        /// <param name="b">source of bits</param>
        /// <param name="count">number of bits to write</param>
        public void WriteBits(int b, int count)
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _start != 0) throw new SharpZipBaseException("Debug check: start != 0");
// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162

            //			if (DeflaterConstants.DEBUGGING) {
            //				//Console.WriteLine("writeBits("+b+","+count+")");
            //			}
#endif
            _bits |= (uint)(b << BitCount);
            _bitCount += count;
            if (!(BitCount >= 16)) return;

            _buffer[_end++] = unchecked((byte)_bits);
            _buffer[_end++] = unchecked((byte)(_bits >> 8));
            _bits >>= 16;
            _bitCount -= 16;
        }

        /// <summary>
        ///     Write a short value to internal buffer most significant byte first
        /// </summary>
        /// <param name="s">value to write</param>
        public void WriteShortMSB(int s)
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _start != 0) throw new SharpZipBaseException("Debug check: start != 0");
// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            _buffer[_end++] = unchecked((byte)(s >> 8));
            _buffer[_end++] = unchecked((byte)s);
        }

        /// <summary>
        ///     Indicates if buffer has been flushed
        /// </summary>
        public bool IsFlushed => _end == 0;

        /// <summary>
        ///     Flushes the pending buffer into the given output array.  If the
        ///     output array is to small, only a partial flush is done.
        /// </summary>
        /// <param name="output">The output array.</param>
        /// <param name="offset">The offset into output array.</param>
        /// <param name="length">The maximum number of bytes to store.</param>
        /// <returns>The number of bytes flushed.</returns>
        public int Flush(byte[] output, int offset, int length)
        {
            if (BitCount >= 8)
            {
                _buffer[_end++] = unchecked((byte)_bits);
                _bits >>= 8;
                _bitCount -= 8;
            }

            if (length > _end - _start)
            {
                length = _end - _start;
                Array.Copy(_buffer, _start, output, offset, length);
                _start = 0;
                _end = 0;
            }
            else
            {
                Array.Copy(_buffer, _start, output, offset, length);
                _start += length;
            }

            return length;
        }

        /// <summary>
        ///     Convert internal buffer to byte array.
        ///     Buffer is empty on completion
        /// </summary>
        /// <returns>
        ///     The internal buffer contents converted to a byte array.
        /// </returns>
        public byte[] ToByteArray()
        {
            AlignToByte();

            var result = new byte[_end - _start];
            Array.Copy(_buffer, _start, result, 0, result.Length);
            _start = 0;
            _end = 0;
            return result;
        }

        #region Instance Fields

        /// <summary>
        ///     Internal work buffer
        /// </summary>
        private readonly byte[] _buffer;

        private int _start;
        private int _end;

        private uint _bits;
        private int _bitCount;

        #endregion Instance Fields

        #region Constructors

        /// <summary>
        ///     construct instance using default buffer size of 4096
        /// </summary>
        public PendingBuffer() : this(4096)
        {
        }

        /// <summary>
        ///     construct instance using specified buffer size
        /// </summary>
        /// <param name="bufferSize">
        ///     size to use for internal buffer
        /// </param>
        public PendingBuffer(int bufferSize)
        {
            _buffer = new byte[bufferSize];
        }

        #endregion Constructors
    }
}
