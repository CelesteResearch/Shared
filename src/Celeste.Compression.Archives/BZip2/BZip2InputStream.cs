#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#define VECTORIZE_MEMORY_MOVE
#endif

using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
#if VECTORIZE_MEMORY_MOVE
using System.Numerics;
#endif

namespace ICSharpCode.SharpZipLib.BZip2
{
    /// <summary>
    ///     An input stream that decompresses files in the BZip2 format
    /// </summary>
    public class BZip2InputStream : Stream
    {
        /// <summary>
        ///     Construct instance for reading from stream
        /// </summary>
        /// <param name="stream">Data source</param>
        public BZip2InputStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            // init arrays
            for (var i = 0; i < BZip2Constants.GroupCount; ++i)
            {
                _limit[i] = new int[BZip2Constants.MaximumAlphaSize];
                _baseArray[i] = new int[BZip2Constants.MaximumAlphaSize];
                _perm[i] = new int[BZip2Constants.MaximumAlphaSize];
            }

            _baseStream = stream;
            _bsLive = 0;
            _bsBuff = 0;
            Initialize();
            InitBlock();
            SetupBlock();
        }

        /// <summary>
        ///     Get/set flag indicating ownership of underlying stream.
        ///     When the flag is true <see cref="Stream.Dispose()" /> will close the underlying stream also.
        /// </summary>
        public bool IsStreamOwner { get; set; } = true;

        private void MakeMaps()
        {
            _nInUse = 0;
            for (var i = 0; i < 256; ++i)
                if (_inUse[i])
                {
                    _seqToUnseq[_nInUse] = (byte)i;
                    _nInUse++;
                }
        }

        private void Initialize()
        {
            var magic1 = BsGetUChar();
            var magic2 = BsGetUChar();

            var magic3 = BsGetUChar();
            var magic4 = BsGetUChar();

            if (magic1 != 'B' || magic2 != 'Z' || magic3 != 'h' || magic4 < '1' || magic4 > '9')
            {
                _streamEnd = true;
                return;
            }

            SetDecompressStructureSizes(magic4 - '0');
            _computedCombinedCrc = 0;
        }

        private void InitBlock()
        {
            var magic1 = BsGetUChar();
            var magic2 = BsGetUChar();
            var magic3 = BsGetUChar();
            var magic4 = BsGetUChar();
            var magic5 = BsGetUChar();
            var magic6 = BsGetUChar();

            if (magic1 == 0x17 && magic2 == 0x72 && magic3 == 0x45 && magic4 == 0x38 && magic5 == 0x50 &&
                magic6 == 0x90)
            {
                Complete();
                return;
            }

            if (magic1 != 0x31 || magic2 != 0x41 || magic3 != 0x59 || magic4 != 0x26 || magic5 != 0x53 ||
                magic6 != 0x59)
            {
                BadBlockHeader();
                _streamEnd = true;
                return;
            }

            _storedBlockCrc = BsGetInt32();

            _blockRandomised = BsR(1) == 1;

            GetAndMoveToFrontDecode();

            _mCrc.Reset();
            _currentState = StartBlockState;
        }

        private void EndBlock()
        {
            _computedBlockCrc = (int)_mCrc.Value;

            // -- A bad CRC is considered a fatal error. --
            if (_storedBlockCrc != _computedBlockCrc) CrcError();

            // 1528150659
            _computedCombinedCrc = ((_computedCombinedCrc << 1) & 0xFFFFFFFF) | (_computedCombinedCrc >> 31);
            _computedCombinedCrc ^= (uint)_computedBlockCrc;
        }

        private void Complete()
        {
            _storedCombinedCrc = BsGetInt32();
            if (_storedCombinedCrc != (int)_computedCombinedCrc) CrcError();

            _streamEnd = true;
        }

        private void FillBuffer()
        {
            var thech = 0;

            try
            {
                thech = _baseStream.ReadByte();
            }
            catch (Exception)
            {
                CompressedStreamEof();
            }

            if (thech == -1) CompressedStreamEof();

            _bsBuff = (_bsBuff << 8) | (thech & 0xFF);
            _bsLive += 8;
        }

        private int BsR(int n)
        {
            while (_bsLive < n) FillBuffer();

            var v = (_bsBuff >> (_bsLive - n)) & ((1 << n) - 1);
            _bsLive -= n;
            return v;
        }

        private char BsGetUChar()
        {
            return (char)BsR(8);
        }

        private int BsGetIntVs(int numBits)
        {
            return BsR(numBits);
        }

        private int BsGetInt32()
        {
            var result = BsR(8);
            result = (result << 8) | BsR(8);
            result = (result << 8) | BsR(8);
            result = (result << 8) | BsR(8);
            return result;
        }

        private void RecvDecodingTables()
        {
            var len = new char[BZip2Constants.GroupCount][];
            for (var i = 0; i < BZip2Constants.GroupCount; ++i) len[i] = new char[BZip2Constants.MaximumAlphaSize];

            var inUse16 = new bool[16];

            //--- Receive the mapping table ---
            for (var i = 0; i < 16; i++) inUse16[i] = BsR(1) == 1;

            for (var i = 0; i < 16; i++)
                if (inUse16[i])
                    for (var j = 0; j < 16; j++)
                        _inUse[i * 16 + j] = BsR(1) == 1;
                else
                    for (var j = 0; j < 16; j++)
                        _inUse[i * 16 + j] = false;

            MakeMaps();
            var alphaSize = _nInUse + 2;

            //--- Now the selectors ---
            var nGroups = BsR(3);
            var nSelectors = BsR(15);

            for (var i = 0; i < nSelectors; i++)
            {
                var j = 0;
                while (BsR(1) == 1) j++;

                _selectorMtf[i] = (byte)j;
            }

            //--- Undo the MTF values for the selectors. ---
            var pos = new byte[BZip2Constants.GroupCount];
            for (var v = 0; v < nGroups; v++) pos[v] = (byte)v;

            for (var i = 0; i < nSelectors; i++)
            {
                int v = _selectorMtf[i];
                var tmp = pos[v];
                while (v > 0)
                {
                    pos[v] = pos[v - 1];
                    v--;
                }

                pos[0] = tmp;
                _selector[i] = tmp;
            }

            //--- Now the coding tables ---
            for (var t = 0; t < nGroups; t++)
            {
                var curr = BsR(5);
                for (var i = 0; i < alphaSize; i++)
                {
                    while (BsR(1) == 1)
                        if (BsR(1) == 0)
                            curr++;
                        else
                            curr--;

                    len[t][i] = (char)curr;
                }
            }

            //--- Create the Huffman decoding tables ---
            for (var t = 0; t < nGroups; t++)
            {
                var minLen = 32;
                var maxLen = 0;
                for (var i = 0; i < alphaSize; i++)
                {
                    maxLen = Math.Max(maxLen, len[t][i]);
                    minLen = Math.Min(minLen, len[t][i]);
                }

                HbCreateDecodeTables(_limit[t], _baseArray[t], _perm[t], len[t], minLen, maxLen, alphaSize);
                _minLens[t] = minLen;
            }
        }

        private void GetAndMoveToFrontDecode()
        {
            var yy = new byte[256];

            var limitLast = BZip2Constants.BaseBlockSize * _blockSize100K;
            _origPtr = BsGetIntVs(24);

            RecvDecodingTables();
            var eob = _nInUse + 1;
            var groupNo = -1;

            /*--
            Setting up the unzftab entries here is not strictly
            necessary, but it does save having to do it later
            in a separate pass, and so saves a block's worth of
            cache misses.
            --*/
            for (var i = 0; i <= 255; i++) _unzftab[i] = 0;

            for (var i = 0; i <= 255; i++) yy[i] = (byte)i;

            _last = -1;

            groupNo++;
            var groupPos = BZip2Constants.GroupSize;

            groupPos--;
            int zt = _selector[groupNo];
            var zn = _minLens[zt];
            var zvec = BsR(zn);
            int zj;

            while (zvec > _limit[zt][zn])
            {
                if (zn > 20)
                    // the longest code
                    throw new BZip2Exception("Bzip data error");

                zn++;
                while (_bsLive < 1) FillBuffer();

                zj = (_bsBuff >> (_bsLive - 1)) & 1;
                _bsLive--;
                zvec = (zvec << 1) | zj;
            }

            if (zvec - _baseArray[zt][zn] < 0 || zvec - _baseArray[zt][zn] >= BZip2Constants.MaximumAlphaSize)
                throw new BZip2Exception("Bzip data error");

            var nextSym = _perm[zt][zvec - _baseArray[zt][zn]];

            while (true)
            {
                if (nextSym == eob) break;

                if (nextSym is BZip2Constants.RunA or BZip2Constants.RunB)
                {
                    var s = -1;
                    var n = 1;
                    do
                    {
                        if (nextSym == BZip2Constants.RunA)
                            s += (0 + 1) * n;
                        else s += (1 + 1) * n;

                        n <<= 1;

                        if (groupPos == 0)
                        {
                            groupNo++;
                            groupPos = BZip2Constants.GroupSize;
                        }

                        groupPos--;

                        zt = _selector[groupNo];
                        zn = _minLens[zt];
                        zvec = BsR(zn);

                        while (zvec > _limit[zt][zn])
                        {
                            zn++;
                            while (_bsLive < 1) FillBuffer();

                            zj = (_bsBuff >> (_bsLive - 1)) & 1;
                            _bsLive--;
                            zvec = (zvec << 1) | zj;
                        }

                        nextSym = _perm[zt][zvec - _baseArray[zt][zn]];
                    } while (nextSym is BZip2Constants.RunA or BZip2Constants.RunB);

                    s++;
                    var ch = _seqToUnseq[yy[0]];
                    _unzftab[ch] += s;

                    while (s > 0)
                    {
                        _last++;
                        _ll8[_last] = ch;
                        s--;
                    }

                    if (_last >= limitLast) BlockOverrun();
                }
                else
                {
                    _last++;
                    if (_last >= limitLast) BlockOverrun();

                    var tmp = yy[nextSym - 1];
                    _unzftab[_seqToUnseq[tmp]]++;
                    _ll8[_last] = _seqToUnseq[tmp];

                    var j = nextSym - 1;

#if VECTORIZE_MEMORY_MOVE
                    // This is vectorized memory move. Going from the back, we're taking chunks of array
                    // and write them at the new location shifted by one. Since chunks are VectorSize long,
                    // at the end we have to move "tail" (or head actually) of the array using a plain loop.
                    // If System.Numerics.Vector API is not available, the plain loop is used to do the whole copying.

                    while (j >= VectorSize)
                    {
                        var arrayPart = new Vector<byte>(yy, j - VectorSize);
                        arrayPart.CopyTo(yy, j - VectorSize + 1);
                        j -= VectorSize;
                    }
#endif // VECTORIZE_MEMORY_MOVE

                    while (j > 0) yy[j] = yy[--j];

                    yy[0] = tmp;

                    if (groupPos == 0)
                    {
                        groupNo++;
                        groupPos = BZip2Constants.GroupSize;
                    }

                    groupPos--;
                    zt = _selector[groupNo];
                    zn = _minLens[zt];
                    zvec = BsR(zn);
                    while (zvec > _limit[zt][zn])
                    {
                        zn++;
                        while (_bsLive < 1) FillBuffer();

                        zj = (_bsBuff >> (_bsLive - 1)) & 1;
                        _bsLive--;
                        zvec = (zvec << 1) | zj;
                    }

                    nextSym = _perm[zt][zvec - _baseArray[zt][zn]];
                }
            }
        }

        private void SetupBlock()
        {
            var cftab = new int[257];

            cftab[0] = 0;
            Array.Copy(_unzftab, 0, cftab, 1, 256);

            for (var i = 1; i <= 256; i++) cftab[i] += cftab[i - 1];

            for (var i = 0; i <= _last; i++)
            {
                var ch = _ll8[i];
                _tt[cftab[ch]] = i;
                cftab[ch]++;
            }


            _tPos = _tt[_origPtr];

            _count = 0;
            _i2 = 0;
            _ch2 = 256; /*-- not a char and not EOF --*/

            if (_blockRandomised)
            {
                _rNToGo = 0;
                _rTPos = 0;
                SetupRandPartA();
            }
            else
            {
                SetupNoRandPartA();
            }
        }

        private void SetupRandPartA()
        {
            if (_i2 <= _last)
            {
                _chPrev = _ch2;
                _ch2 = _ll8[_tPos];
                _tPos = _tt[_tPos];
                if (_rNToGo == 0)
                {
                    _rNToGo = BZip2Constants.RandomNumbers[_rTPos];
                    _rTPos++;
                    if (_rTPos == 512) _rTPos = 0;
                }

                _rNToGo--;
                _ch2 ^= _rNToGo == 1 ? 1 : 0;
                _i2++;

                _currentChar = _ch2;
                _currentState = RandPartBState;
                _mCrc.Update(_ch2);
            }
            else
            {
                EndBlock();
                InitBlock();
                SetupBlock();
            }
        }

        private void SetupNoRandPartA()
        {
            if (_i2 <= _last)
            {
                _chPrev = _ch2;
                _ch2 = _ll8[_tPos];
                _tPos = _tt[_tPos];
                _i2++;

                _currentChar = _ch2;
                _currentState = NoRandPartBState;
                _mCrc.Update(_ch2);
            }
            else
            {
                EndBlock();
                InitBlock();
                SetupBlock();
            }
        }

        private void SetupRandPartB()
        {
            if (_ch2 != _chPrev)
            {
                _currentState = RandPartAState;
                _count = 1;
                SetupRandPartA();
            }
            else
            {
                _count++;
                if (_count >= 4)
                {
                    _z = _ll8[_tPos];
                    _tPos = _tt[_tPos];
                    if (_rNToGo == 0)
                    {
                        _rNToGo = BZip2Constants.RandomNumbers[_rTPos];
                        _rTPos++;
                        if (_rTPos == 512) _rTPos = 0;
                    }

                    _rNToGo--;
                    _z ^= (byte)(_rNToGo == 1 ? 1 : 0);
                    _j2 = 0;
                    _currentState = RandPartCState;
                    SetupRandPartC();
                }
                else
                {
                    _currentState = RandPartAState;
                    SetupRandPartA();
                }
            }
        }

        private void SetupRandPartC()
        {
            if (_j2 < _z)
            {
                _currentChar = _ch2;
                _mCrc.Update(_ch2);
                _j2++;
            }
            else
            {
                _currentState = RandPartAState;
                _i2++;
                _count = 0;
                SetupRandPartA();
            }
        }

        private void SetupNoRandPartB()
        {
            if (_ch2 != _chPrev)
            {
                _currentState = NoRandPartAState;
                _count = 1;
                SetupNoRandPartA();
            }
            else
            {
                _count++;
                if (_count >= 4)
                {
                    _z = _ll8[_tPos];
                    _tPos = _tt[_tPos];
                    _currentState = NoRandPartCState;
                    _j2 = 0;
                    SetupNoRandPartC();
                }
                else
                {
                    _currentState = NoRandPartAState;
                    SetupNoRandPartA();
                }
            }
        }

        private void SetupNoRandPartC()
        {
            if (_j2 < _z)
            {
                _currentChar = _ch2;
                _mCrc.Update(_ch2);
                _j2++;
            }
            else
            {
                _currentState = NoRandPartAState;
                _i2++;
                _count = 0;
                SetupNoRandPartA();
            }
        }

        private void SetDecompressStructureSizes(int newSize100k)
        {
            if (!(newSize100k is >= 0 and <= 9 && _blockSize100K is >= 0 and <= 9))
                throw new BZip2Exception("Invalid block size");

            _blockSize100K = newSize100k;

            if (newSize100k == 0) return;

            var n = BZip2Constants.BaseBlockSize * newSize100k;
            _ll8 = new byte[n];
            _tt = new int[n];
        }

        private static void CompressedStreamEof()
        {
            throw new EndOfStreamException("BZip2 input stream end of compressed stream");
        }

        private static void BlockOverrun()
        {
            throw new BZip2Exception("BZip2 input stream block overrun");
        }

        private static void BadBlockHeader()
        {
            throw new BZip2Exception("BZip2 input stream bad block header");
        }

        private static void CrcError()
        {
            throw new BZip2Exception("BZip2 input stream crc error");
        }

        private static void HbCreateDecodeTables(int[] limit, int[] baseArray, int[] perm, char[] length, int minLen,
            int maxLen, int alphaSize)
        {
            var pp = 0;

            for (var i = minLen; i <= maxLen; ++i)
            for (var j = 0; j < alphaSize; ++j)
                if (length[j] == i)
                {
                    perm[pp] = j;
                    ++pp;
                }

            for (var i = 0; i < BZip2Constants.MaximumCodeLength; i++) baseArray[i] = 0;

            for (var i = 0; i < alphaSize; i++) ++baseArray[length[i] + 1];

            for (var i = 1; i < BZip2Constants.MaximumCodeLength; i++) baseArray[i] += baseArray[i - 1];

            for (var i = 0; i < BZip2Constants.MaximumCodeLength; i++) limit[i] = 0;

            var vec = 0;

            for (var i = minLen; i <= maxLen; i++)
            {
                vec += baseArray[i + 1] - baseArray[i];
                limit[i] = vec - 1;
                vec <<= 1;
            }

            for (var i = minLen + 1; i <= maxLen; i++) baseArray[i] = ((limit[i - 1] + 1) << 1) - baseArray[i];
        }

        #region Constants

        private const int StartBlockState = 1;
        private const int RandPartAState = 2;
        private const int RandPartBState = 3;
        private const int RandPartCState = 4;
        private const int NoRandPartAState = 5;
        private const int NoRandPartBState = 6;
        private const int NoRandPartCState = 7;

#if VECTORIZE_MEMORY_MOVE
        private static readonly int VectorSize = Vector<byte>.Count;
#endif // VECTORIZE_MEMORY_MOVE

        #endregion Constants

        #region Instance Fields

        /*--
        index of the last char in the block, so
        the block size == last + 1.
        --*/
        private int _last;

        /*--
        index in zptr[] of original string after sorting.
        --*/
        private int _origPtr;

        /*--
        always: in the range 0 .. 9.
        The current block size is 100000 * this number.
        --*/
        private int _blockSize100K;

        private bool _blockRandomised;

        private int _bsBuff;
        private int _bsLive;
        private readonly IChecksum _mCrc = new BZip2Crc();

        private readonly bool[] _inUse = new bool[256];
        private int _nInUse;

        private readonly byte[] _seqToUnseq = new byte[256];

        private readonly byte[] _selector = new byte[BZip2Constants.MaximumSelectors];
        private readonly byte[] _selectorMtf = new byte[BZip2Constants.MaximumSelectors];

        private int[] _tt = null!;
        private byte[] _ll8 = null!;

        /*--
        freq table collected to save a pass over the data
        during decompression.
        --*/
        private readonly int[] _unzftab = new int[256];

        private readonly int[][] _limit = new int[BZip2Constants.GroupCount][];
        private readonly int[][] _baseArray = new int[BZip2Constants.GroupCount][];
        private readonly int[][] _perm = new int[BZip2Constants.GroupCount][];
        private readonly int[] _minLens = new int[BZip2Constants.GroupCount];

        private readonly Stream _baseStream;
        private bool _streamEnd;

        private int _currentChar = -1;

        private int _currentState = StartBlockState;

        private int _storedBlockCrc, _storedCombinedCrc;
        private int _computedBlockCrc;
        private uint _computedCombinedCrc;

        private int _count, _chPrev, _ch2;
        private int _tPos;
        private int _rNToGo;
        private int _rTPos;
        private int _i2, _j2;
        private byte _z;

        #endregion Instance Fields

        #region Stream Overrides

        /// <summary>
        ///     Gets a value indicating if the stream supports reading
        /// </summary>
        public override bool CanRead => _baseStream.CanRead;

        /// <summary>
        ///     Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        public override bool CanSeek => false;

        /// <summary>
        ///     Gets a value indicating whether the current stream supports writing.
        ///     This property always returns false
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        ///     Gets the length in bytes of the stream.
        /// </summary>
        public override long Length => _baseStream.Length;

        /// <summary>
        ///     Gets the current position of the stream.
        ///     Setting the position is not supported and will throw a NotSupportException.
        /// </summary>
        /// <exception cref="NotSupportedException">Any attempt to set the position.</exception>
        public override long Position
        {
            get => _baseStream.Position;
            set => throw new NotSupportedException("BZip2InputStream position cannot be set");
        }

        /// <summary>
        ///     Flushes the stream.
        /// </summary>
        public override void Flush()
        {
            _baseStream.Flush();
        }

        /// <summary>
        ///     Set the streams position.  This operation is not supported and will throw a NotSupportedException
        /// </summary>
        /// <param name="offset">A byte offset relative to the <paramref name="origin" /> parameter.</param>
        /// <param name="origin">
        ///     A value of type <see cref="SeekOrigin" /> indicating the reference point used to obtain the new
        ///     position.
        /// </param>
        /// <returns>The new position of the stream.</returns>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("BZip2InputStream Seek not supported");
        }

        /// <summary>
        ///     Sets the length of this stream to the given value.
        ///     This operation is not supported and will throw a NotSupportedExceptionortedException
        /// </summary>
        /// <param name="value">The new length for the stream.</param>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override void SetLength(long value)
        {
            throw new NotSupportedException("BZip2InputStream SetLength not supported");
        }

        /// <summary>
        ///     Writes a block of bytes to this stream using data from a buffer.
        ///     This operation is not supported and will throw a NotSupportedException
        /// </summary>
        /// <param name="buffer">The buffer to source data from.</param>
        /// <param name="offset">The offset to start obtaining data from.</param>
        /// <param name="count">The number of bytes of data to write.</param>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("BZip2InputStream Write not supported");
        }

        /// <summary>
        ///     Writes a byte to the current position in the file stream.
        ///     This operation is not supported and will throw a NotSupportedException
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override void WriteByte(byte value)
        {
            throw new NotSupportedException("BZip2InputStream WriteByte not supported");
        }

        /// <summary>
        ///     Read a sequence of bytes and advances the read position by one byte.
        /// </summary>
        /// <param name="buffer">Array of bytes to store values in</param>
        /// <param name="offset">Offset in array to begin storing data</param>
        /// <param name="count">The maximum number of bytes to read</param>
        /// <returns>
        ///     The total number of bytes read into the buffer. This might be less
        ///     than the number of bytes requested if that number of bytes are not
        ///     currently available or zero if the end of the stream is reached.
        /// </returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));

            for (var i = 0; i < count; ++i)
            {
                var rb = ReadByte();
                if (rb == -1) return i;

                buffer[offset + i] = (byte)rb;
            }

            return count;
        }

        /// <summary>
        ///     Closes the stream, releasing any associated resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && IsStreamOwner) _baseStream.Dispose();
        }

        /// <summary>
        ///     Read a byte from stream advancing position
        /// </summary>
        /// <returns>byte read or -1 on end of stream</returns>
        public override int ReadByte()
        {
            if (_streamEnd) return -1; // ok

            var retChar = _currentChar;
            switch (_currentState)
            {
                case RandPartBState:
                    SetupRandPartB();
                    break;

                case RandPartCState:
                    SetupRandPartC();
                    break;

                case NoRandPartBState:
                    SetupNoRandPartB();
                    break;

                case NoRandPartCState:
                    SetupNoRandPartC();
                    break;

                case StartBlockState:
                case NoRandPartAState:
                case RandPartAState:
                    break;
            }

            return retChar;
        }

        #endregion Stream Overrides
    }
}
