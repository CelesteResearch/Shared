using System;
using ICSharpCode.SharpZipLib.Checksum;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
    /// <summary>
    ///     Strategies for deflater
    /// </summary>
    public enum DeflateStrategy
    {
        /// <summary>
        ///     The default strategy
        /// </summary>
        Default = 0,

        /// <summary>
        ///     This strategy will only allow longer string repetitions.  It is
        ///     useful for random data with a small character set.
        /// </summary>
        Filtered = 1,

        /// <summary>
        ///     This strategy will not look for string repetitions at all.  It
        ///     only encodes with Huffman trees (which means, that more common
        ///     characters get a smaller encoding.
        /// </summary>
        HuffmanOnly = 2,
    }

    // DEFLATE ALGORITHM:
    //
    // The uncompressed stream is inserted into the window array.  When
    // the window array is full the first half is thrown away and the
    // second half is copied to the beginning.
    //
    // The head array is a hash table.  Three characters build a hash value
    // and they the value points to the corresponding index in window of
    // the last string with this hash.  The prev array implements a
    // linked list of matches with the same hash: prev[index & WMASK] points
    // to the previous index with the same hash.
    //

    /// <summary>
    ///     Low level compression engine for deflate algorithm which uses a 32K sliding window
    ///     with secondary compression from Huffman/Shannon-Fano codes.
    /// </summary>
    public class DeflaterEngine
    {
        #region Constants

        private const int TooFar = 4096;

        #endregion Constants

        /// <summary>
        ///     Deflate drives actual compression of data
        /// </summary>
        /// <param name="flush">True to flush input buffers</param>
        /// <param name="finish">Finish deflation with the current input.</param>
        /// <returns>Returns true if progress has been made.</returns>
        public bool Deflate(bool flush, bool finish)
        {
            bool progress;
            do
            {
                FillWindow();
                var canFlush = flush && _inputOff == _inputEnd;

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
                if (DeflaterConstants.DEBUGGING)
                    Console.WriteLine("window: [" + _blockStart + "," + _strstart + ","
                                      + _lookahead + "], " + _compressionFunction + "," + canFlush);

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
                progress = _compressionFunction switch
                {
                    DeflaterConstants.DEFLATE_STORED => DeflateStored(canFlush, finish),
                    DeflaterConstants.DEFLATE_FAST => DeflateFast(canFlush, finish),
                    DeflaterConstants.DEFLATE_SLOW => DeflateSlow(canFlush, finish),
                    _ => throw new InvalidOperationException("unknown compressionFunction"),
                };
            } while (_pending.IsFlushed && progress); // repeat while we have no pending output and progress was made

            return progress;
        }

        /// <summary>
        ///     Sets input data to be deflated.  Should only be called when <code>NeedsInput()</code>
        ///     returns true
        /// </summary>
        /// <param name="buffer">The buffer containing input data.</param>
        /// <param name="offset">The offset of the first byte of data.</param>
        /// <param name="count">The number of bytes of data to use as input.</param>
        public void SetInput(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));

            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));

            if (_inputOff < _inputEnd) throw new InvalidOperationException("Old input was not completely processed");

            var end = offset + count;

            /* We want to throw an ArrayIndexOutOfBoundsException early.  The
             * check is very tricky: it also handles integer wrap around.
             */
            if (offset > end || end > buffer.Length) throw new ArgumentOutOfRangeException(nameof(count));

            _inputBuf = buffer;
            _inputOff = offset;
            _inputEnd = end;
        }

        /// <summary>
        ///     Determines if more <see cref="SetInput">input</see> is needed.
        /// </summary>
        /// <returns>Return true if input is needed via <see cref="SetInput">SetInput</see></returns>
        public bool NeedsInput()
        {
            return _inputEnd == _inputOff;
        }

        /// <summary>
        ///     Set compression dictionary
        /// </summary>
        /// <param name="buffer">The buffer containing the dictionary data</param>
        /// <param name="offset">The offset in the buffer for the first byte of data</param>
        /// <param name="length">The length of the dictionary data.</param>
        public void SetDictionary(byte[] buffer, int offset, int length)
        {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING && _strstart != 1) throw new InvalidOperationException("strstart not 1");

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            _adler?.Update(new ArraySegment<byte>(buffer, offset, length));
            switch (length)
            {
                case < DeflaterConstants.MIN_MATCH:
                    return;
                case > DeflaterConstants.MAX_DIST:
                    offset += length - DeflaterConstants.MAX_DIST;
                    length = DeflaterConstants.MAX_DIST;
                    break;
            }

            Array.Copy(buffer, offset, _window, _strstart, length);

            UpdateHash();
            --length;
            while (--length > 0)
            {
                InsertString();
                _strstart++;
            }

            _strstart += 2;
            _blockStart = _strstart;
        }

        /// <summary>
        ///     Reset internal state
        /// </summary>
        public void Reset()
        {
            _huffman.Reset();
            _adler?.Reset();
            _blockStart = _strstart = 1;
            _lookahead = 0;
            _totalIn = 0;
            _prevAvailable = false;
            _matchLen = DeflaterConstants.MIN_MATCH - 1;

            for (var i = 0; i < DeflaterConstants.HASH_SIZE; i++) _head[i] = 0;

            for (var i = 0; i < DeflaterConstants.WSIZE; i++) _prev[i] = 0;
        }

        /// <summary>
        ///     Reset Adler checksum
        /// </summary>
        public void ResetAdler()
        {
            _adler?.Reset();
        }

        /// <summary>
        ///     Get current value of Adler checksum
        /// </summary>
        public int Adler => _adler != null ? unchecked((int)_adler.Value) : 0;

        /// <summary>
        ///     Total data processed
        /// </summary>
        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public long TotalIn => _totalIn;

        /// <summary>
        ///     Get/set the <see cref="DeflateStrategy">deflate strategy</see>
        /// </summary>
        public DeflateStrategy Strategy { get; set; }

        /// <summary>
        ///     Set the deflate level (0-9)
        /// </summary>
        /// <param name="level">The value to set the level to.</param>
        public void SetLevel(int level)
        {
            if (level is < 0 or > 9) throw new ArgumentOutOfRangeException(nameof(level));

            _goodLength = DeflaterConstants.GOOD_LENGTH[level];
            _maxLazy = DeflaterConstants.MAX_LAZY[level];
            _niceLength = DeflaterConstants.NICE_LENGTH[level];
            _maxChain = DeflaterConstants.MAX_CHAIN[level];

            if (DeflaterConstants.COMPR_FUNC[level] == _compressionFunction) return;

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING)
                Console.WriteLine("Change from " + _compressionFunction + " to "
                                  + DeflaterConstants.COMPR_FUNC[level]);

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            switch (_compressionFunction)
            {
                case DeflaterConstants.DEFLATE_STORED:
                    if (_strstart > _blockStart)
                    {
                        _huffman.FlushStoredBlock(_window, _blockStart,
                            _strstart - _blockStart, false);
                        _blockStart = _strstart;
                    }

                    UpdateHash();
                    break;

                case DeflaterConstants.DEFLATE_FAST:
                    if (_strstart > _blockStart)
                    {
                        _huffman.FlushBlock(_window, _blockStart, _strstart - _blockStart,
                            false);
                        _blockStart = _strstart;
                    }

                    break;

                case DeflaterConstants.DEFLATE_SLOW:
                    if (_prevAvailable) _huffman.TallyLit(_window[_strstart - 1] & 0xff);

                    if (_strstart > _blockStart)
                    {
                        _huffman.FlushBlock(_window, _blockStart, _strstart - _blockStart, false);
                        _blockStart = _strstart;
                    }

                    _prevAvailable = false;
                    _matchLen = DeflaterConstants.MIN_MATCH - 1;
                    break;
            }

            _compressionFunction = DeflaterConstants.COMPR_FUNC[level];
        }

        /// <summary>
        ///     Fill the window
        /// </summary>
        public void FillWindow()
        {
            /* If the window is almost full and there is insufficient lookahead,
             * move the upper half to the lower one to make room in the upper half.
             */
            if (_strstart >= DeflaterConstants.WSIZE + DeflaterConstants.MAX_DIST) SlideWindow();

            /* If there is not enough lookahead, but still some input left,
             * read in the input
             */
            if (_lookahead < DeflaterConstants.MIN_LOOKAHEAD && _inputOff < _inputEnd)
            {
                var more = 2 * DeflaterConstants.WSIZE - _lookahead - _strstart;

                if (more > _inputEnd - _inputOff) more = _inputEnd - _inputOff;

                Array.Copy(_inputBuf, _inputOff, _window, _strstart + _lookahead, more);
                _adler?.Update(new ArraySegment<byte>(_inputBuf, _inputOff, more));

                _inputOff += more;
                _totalIn += more;
                _lookahead += more;
            }

            if (_lookahead >= DeflaterConstants.MIN_MATCH) UpdateHash();
        }

        private void UpdateHash()
        {
            /*
                        if (DEBUGGING) {
                            Console.WriteLine("updateHash: "+strstart);
                        }
            */
            _insH = (_window[_strstart] << DeflaterConstants.HASH_SHIFT) ^ _window[_strstart + 1];
        }

        /// <summary>
        ///     Inserts the current string in the head hash and returns the previous
        ///     value for this hash.
        /// </summary>
        /// <returns>The previous hash value</returns>
        private int InsertString()
        {
            short match;
            var hash =
                ((_insH << DeflaterConstants.HASH_SHIFT) ^ _window[_strstart + (DeflaterConstants.MIN_MATCH - 1)]) &
                DeflaterConstants.HASH_MASK;

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING)
                if (hash != (((_window[_strstart] << (2 * DeflaterConstants.HASH_SHIFT)) ^
                              (_window[_strstart + 1] << DeflaterConstants.HASH_SHIFT) ^
                              _window[_strstart + 2]) & DeflaterConstants.HASH_MASK))
                    throw new SharpZipBaseException("hash inconsistent: " + hash + "/"
                                                    + _window[_strstart] + ","
                                                    + _window[_strstart + 1] + ","
                                                    + _window[_strstart + 2] + "," + DeflaterConstants.HASH_SHIFT);

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            _prev[_strstart & DeflaterConstants.WMASK] = match = _head[hash];
            _head[hash] = unchecked((short)_strstart);
            _insH = hash;
            return match & 0xffff;
        }

        private void SlideWindow()
        {
            Array.Copy(_window, DeflaterConstants.WSIZE, _window, 0, DeflaterConstants.WSIZE);
            _matchStart -= DeflaterConstants.WSIZE;
            _strstart -= DeflaterConstants.WSIZE;
            _blockStart -= DeflaterConstants.WSIZE;

            // Slide the hash table (could be avoided with 32 bit values
            // at the expense of memory usage).
            for (var i = 0; i < DeflaterConstants.HASH_SIZE; ++i)
            {
                var m = _head[i] & 0xffff;
                _head[i] = (short)(m >= DeflaterConstants.WSIZE ? m - DeflaterConstants.WSIZE : 0);
            }

            // Slide the prev table.
            for (var i = 0; i < DeflaterConstants.WSIZE; i++)
            {
                var m = _prev[i] & 0xffff;
                _prev[i] = (short)(m >= DeflaterConstants.WSIZE ? m - DeflaterConstants.WSIZE : 0);
            }
        }

        /// <summary>
        ///     Find the best (longest) string in the window matching the
        ///     string starting at strstart.
        ///     Preconditions:
        ///     <code>
        /// strstart + DeflaterConstants.MAX_MATCH &lt;= window.length.</code>
        /// </summary>
        /// <param name="curMatch"></param>
        /// <returns>True if a match greater than the minimum length is found</returns>
        private bool FindLongestMatch(int curMatch)
        {
            var scan = _strstart;
            // scanMax is the highest position that we can look at
            var scanMax = scan + Math.Min(DeflaterConstants.MAX_MATCH, _lookahead) - 1;
            var limit = Math.Max(scan - DeflaterConstants.MAX_DIST, 0);

            var window = _window;
            var prev = _prev;
            var chainLength = _maxChain;
            var niceLength = Math.Min(_niceLength, _lookahead);

            _matchLen = Math.Max(_matchLen, DeflaterConstants.MIN_MATCH - 1);

            if (scan + _matchLen > scanMax) return false;

            var scanEnd1 = window[scan + _matchLen - 1];
            var scanEnd = window[scan + _matchLen];

            // Do not waste too much time if we already have a good match:
            if (_matchLen >= _goodLength) chainLength >>= 2;

            do
            {
                var match = curMatch;
                scan = _strstart;

                if (window[match + _matchLen] != scanEnd
                    || window[match + _matchLen - 1] != scanEnd1
                    || window[match] != window[scan]
                    || window[++match] != window[++scan])
                    continue;

                // scan is set to strstart+1 and the comparison passed, so
                // scanMax - scan is the maximum number of bytes we can compare.
                // below we compare 8 bytes at a time, so first we compare
                // (scanMax - scan) % 8 bytes, so the remainder is a multiple of 8

                _ = ((scanMax - scan) % 8) switch
                {
                    1 => window[++scan] == window[++match],
                    2 => window[++scan] == window[++match]
                         && window[++scan] == window[++match],
                    3 => window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match],
                    4 => window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match],
                    5 => window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match],
                    6 => window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match],
                    7 => window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match]
                         && window[++scan] == window[++match],
                    _ => true,
                };

                if (window[scan] == window[match])
                    /* We check for insufficient lookahead only every 8th comparison;
                     * the 256th check will be made at strstart + 258 unless lookahead is
                     * exhausted first.
                     */
                    do
                    {
                        if (scan != scanMax) continue;

                        ++scan; // advance to first position not matched
                        ++match;

                        break;
                    } while (window[++scan] == window[++match]
                             && window[++scan] == window[++match]
                             && window[++scan] == window[++match]
                             && window[++scan] == window[++match]
                             && window[++scan] == window[++match]
                             && window[++scan] == window[++match]
                             && window[++scan] == window[++match]
                             && window[++scan] == window[++match]);

                if (!(scan - _strstart > _matchLen)) continue;

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
                if (DeflaterConstants.DEBUGGING && _insH == 0)
                    Console.Error.WriteLine("Found match: " + curMatch + "-" + (scan - _strstart));

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif

                _matchStart = curMatch;
                _matchLen = scan - _strstart;

                if (_matchLen >= niceLength)
                    break;

                scanEnd1 = window[scan - 1];
                scanEnd = window[scan];
            } while ((curMatch = prev[curMatch & DeflaterConstants.WMASK] & 0xffff) > limit && 0 != --chainLength);

            return _matchLen >= DeflaterConstants.MIN_MATCH;
        }

        private bool DeflateStored(bool flush, bool finish)
        {
            if (!flush && _lookahead == 0) return false;

            _strstart += _lookahead;
            _lookahead = 0;

            var storedLength = _strstart - _blockStart;

            if (!(storedLength >= DeflaterConstants.MAX_BLOCK_SIZE || // Block is full
                  (_blockStart < DeflaterConstants.WSIZE &&
                   storedLength >= DeflaterConstants.MAX_DIST) || // Block may move out of window
                  flush)) return true;

            var lastBlock = finish;
            if (storedLength > DeflaterConstants.MAX_BLOCK_SIZE)
            {
                storedLength = DeflaterConstants.MAX_BLOCK_SIZE;
                lastBlock = false;
            }

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING)
                Console.WriteLine("storedBlock[" + storedLength + "," + lastBlock + "]");

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif

            _huffman.FlushStoredBlock(_window, _blockStart, storedLength, lastBlock);
            _blockStart += storedLength;
            return !(lastBlock || storedLength == 0);
        }

        private bool DeflateFast(bool flush, bool finish)
        {
            if (_lookahead < DeflaterConstants.MIN_LOOKAHEAD && !flush) return false;

            while (_lookahead >= DeflaterConstants.MIN_LOOKAHEAD || flush)
            {
                if (_lookahead == 0)
                {
                    // We are flushing everything
                    _huffman.FlushBlock(_window, _blockStart, _strstart - _blockStart, finish);
                    _blockStart = _strstart;
                    return false;
                }

                if (_strstart > 2 * DeflaterConstants.WSIZE - DeflaterConstants.MIN_LOOKAHEAD)
                    /* slide window, as FindLongestMatch needs this.
                     * This should only happen when flushing and the window
                     * is almost full.
                     */
                    SlideWindow();

                int hashHead;
                if (_lookahead >= DeflaterConstants.MIN_MATCH &&
                    (hashHead = InsertString()) != 0 &&
                    Strategy != DeflateStrategy.HuffmanOnly &&
                    _strstart - hashHead <= DeflaterConstants.MAX_DIST &&
                    FindLongestMatch(hashHead))
                {
                    // longestMatch sets matchStart and matchLen
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
                    if (DeflaterConstants.DEBUGGING)
                        for (var i = 0; i < _matchLen; i++)
                            if (_window[_strstart + i] != _window[_matchStart + i])
                                throw new SharpZipBaseException("Match failure");

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif

                    var full = _huffman.TallyDist(_strstart - _matchStart, _matchLen);

                    _lookahead -= _matchLen;
                    if (_matchLen <= _maxLazy && _lookahead >= DeflaterConstants.MIN_MATCH)
                    {
                        while (--_matchLen > 0)
                        {
                            ++_strstart;
                            InsertString();
                        }

                        ++_strstart;
                    }
                    else
                    {
                        _strstart += _matchLen;
                        if (_lookahead >= DeflaterConstants.MIN_MATCH - 1) UpdateHash();
                    }

                    _matchLen = DeflaterConstants.MIN_MATCH - 1;
                    if (!full) continue;
                }
                else
                {
                    // No match found
                    _huffman.TallyLit(_window[_strstart] & 0xff);
                    ++_strstart;
                    --_lookahead;
                }

                if (!_huffman.IsFull()) continue;

                var lastBlock = finish && _lookahead == 0;
                _huffman.FlushBlock(_window, _blockStart, _strstart - _blockStart, lastBlock);
                _blockStart = _strstart;
                return !lastBlock;
            }

            return true;
        }

        private bool DeflateSlow(bool flush, bool finish)
        {
            if (_lookahead < DeflaterConstants.MIN_LOOKAHEAD && !flush) return false;

            while (_lookahead >= DeflaterConstants.MIN_LOOKAHEAD || flush)
            {
                if (_lookahead == 0)
                {
                    if (_prevAvailable) _huffman.TallyLit(_window[_strstart - 1] & 0xff);

                    _prevAvailable = false;

                    // We are flushing everything
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
                    if (DeflaterConstants.DEBUGGING && !flush)
                        throw new SharpZipBaseException("Not flushing, but no lookahead");

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
                    _huffman.FlushBlock(_window, _blockStart, _strstart - _blockStart,
                        finish);
                    _blockStart = _strstart;
                    return false;
                }

                if (_strstart >= 2 * DeflaterConstants.WSIZE - DeflaterConstants.MIN_LOOKAHEAD)
                    /* slide window, as FindLongestMatch needs this.
                     * This should only happen when flushing and the window
                     * is almost full.
                     */
                    SlideWindow();

                var prevMatch = _matchStart;
                var prevLen = _matchLen;
                if (_lookahead >= DeflaterConstants.MIN_MATCH)
                {
                    var hashHead = InsertString();

                    if (Strategy != DeflateStrategy.HuffmanOnly &&
                        hashHead != 0 &&
                        _strstart - hashHead <= DeflaterConstants.MAX_DIST &&
                        FindLongestMatch(hashHead))
                        // longestMatch sets matchStart and matchLen
                        // Discard match if too small and too far away
                        if (_matchLen <= 5 && (Strategy == DeflateStrategy.Filtered ||
                                               (_matchLen == DeflaterConstants.MIN_MATCH &&
                                                _strstart - _matchStart > TooFar)))
                            _matchLen = DeflaterConstants.MIN_MATCH - 1;
                }

                // previous match was better
                if (prevLen >= DeflaterConstants.MIN_MATCH && _matchLen <= prevLen)
                {
#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
                    if (DeflaterConstants.DEBUGGING)
                        for (var i = 0; i < _matchLen; i++)
                            if (_window[_strstart - 1 + i] != _window[prevMatch + i])
                                throw new SharpZipBaseException();

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
                    _huffman.TallyDist(_strstart - 1 - prevMatch, prevLen);
                    prevLen -= 2;
                    do
                    {
                        _strstart++;
                        _lookahead--;
                        if (_lookahead >= DeflaterConstants.MIN_MATCH) InsertString();
                    } while (--prevLen > 0);

                    _strstart++;
                    _lookahead--;
                    _prevAvailable = false;
                    _matchLen = DeflaterConstants.MIN_MATCH - 1;
                }
                else
                {
                    if (_prevAvailable) _huffman.TallyLit(_window[_strstart - 1] & 0xff);

                    _prevAvailable = true;
                    _strstart++;
                    _lookahead--;
                }

                if (!_huffman.IsFull()) continue;

                var len = _strstart - _blockStart;
                if (_prevAvailable) len--;

                var lastBlock = finish && _lookahead == 0 && !_prevAvailable;
                _huffman.FlushBlock(_window, _blockStart, len, lastBlock);
                _blockStart += len;
                return !lastBlock;
            }

            return true;
        }

        #region Constructors

        /// <summary>
        ///     Construct instance with pending buffer
        ///     Adler calculation will be performed
        /// </summary>
        /// <param name="pending">
        ///     Pending buffer to use
        /// </param>
        public DeflaterEngine(DeflaterPending pending)
            : this(pending,
// ReSharper disable once IntroduceOptionalParameters.Global
                false)
        {
        }


        /// <summary>
        ///     Construct instance with pending buffer
        /// </summary>
        /// <param name="pending">
        ///     Pending buffer to use
        /// </param>
        /// <param name="noAdlerCalculation">
        ///     If no adler calculation should be performed
        /// </param>
        public DeflaterEngine(DeflaterPending pending, bool noAdlerCalculation)
        {
            _pending = pending;
            _huffman = new(pending);
            if (!noAdlerCalculation)
                _adler = new();

            _window = new byte[2 * DeflaterConstants.WSIZE];
            _head = new short[DeflaterConstants.HASH_SIZE];
            _prev = new short[DeflaterConstants.WSIZE];

            // We start at index 1, to avoid an implementation deficiency, that
            // we cannot build a repeat pattern at index 0.
            _blockStart = _strstart = 1;
        }

        #endregion Constructors

        #region Instance Fields

        // Hash index of string to be inserted
        private int _insH;

        /// <summary>
        ///     Hashtable, hashing three characters to an index for window, so
        ///     that window[index]..window[index+2] have this hash code.
        ///     Note that the array should really be unsigned short, so you need
        ///     to and the values with 0xffff.
        /// </summary>
        private readonly short[] _head;

        /// <summary>
        ///     <code>prev[index &amp; WMASK]</code> points to the previous index that has the
        ///     same hash code as the string starting at index.  This way
        ///     entries with the same hash code are in a linked list.
        ///     Note that the array should really be unsigned short, so you need
        ///     to and the values with 0xffff.
        /// </summary>
        private readonly short[] _prev;

        private int _matchStart;

        // Length of best match
        private int _matchLen;

        // Set if previous match exists
        private bool _prevAvailable;

        private int _blockStart;

        /// <summary>
        ///     Points to the current character in the window.
        /// </summary>
        private int _strstart;

        /// <summary>
        ///     lookahead is the number of characters starting at strstart in
        ///     window that are valid.
        ///     So window[strstart] until window[strstart+lookahead-1] are valid
        ///     characters.
        /// </summary>
        private int _lookahead;

        /// <summary>
        ///     This array contains the part of the uncompressed stream that
        ///     is of relevance.  The current character is indexed by strstart.
        /// </summary>
        private readonly byte[] _window;

        private int _maxChain, _maxLazy, _niceLength, _goodLength;

        /// <summary>
        ///     The current compression function.
        /// </summary>
        private int _compressionFunction;

        /// <summary>
        ///     The input data for compression.
        /// </summary>
        private byte[] _inputBuf = null!;

        /// <summary>
        ///     The total bytes of input read.
        /// </summary>
        private long _totalIn;

        /// <summary>
        ///     The offset into inputBuf, where input data starts.
        /// </summary>
        private int _inputOff;

        /// <summary>
        ///     The end offset of the input data.
        /// </summary>
        private int _inputEnd;

        private readonly DeflaterPending _pending;
        private readonly DeflaterHuffman _huffman;

        /// <summary>
        ///     The adler checksum
        /// </summary>
        private readonly Adler32? _adler;

        #endregion Instance Fields
    }
}
