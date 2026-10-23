using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
    /// <summary>
    ///     This is the DeflaterHuffman class.
    ///     This class is <i>not</i> thread safe.  This is inherent in the API, due
    ///     to the split of Deflate and SetInput.
    ///     author of the original java version : Jochen Hoenicke
    /// </summary>
    public class DeflaterHuffman
    {
        private const int Bufsize = 1 << (DeflaterConstants.DEFAULT_MEM_LEVEL + 6);
        private const int LiteralNum = 286;

        // Number of distance codes
        private const int DistNum = 30;

        // Number of codes used to transfer bit lengths
        private const int BitlenNum = 19;

        // repeat previous bit length 3-6 times (2 bits of repeat count)
        private const int Rep36 = 16;

        // repeat a zero length 3-10 times  (3 bits of repeat count)
        private const int Rep310 = 17;

        // repeat a zero length 11-138 times  (7 bits of repeat count)
        private const int Rep11138 = 18;

        private const int EofSymbol = 256;

        // The lengths of the bit length codes are sent in order of decreasing
        // probability, to avoid transmitting the lengths for unused bit length codes.
        private static readonly int[] BlOrder = [16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15];

        private static readonly byte[] Bit4Reverse =
        [
            0,
            8,
            4,
            12,
            2,
            10,
            6,
            14,
            1,
            9,
            5,
            13,
            3,
            11,
            7,
            15,
        ];

        private static readonly short[] StaticLCodes;
        private static readonly byte[] StaticLLength;
        private static readonly short[] StaticDCodes;
        private static readonly byte[] StaticDLength;

        private class Tree
        {
            #region Constructors

            // ReSharper disable once ConvertToPrimaryConstructor
            public Tree(DeflaterHuffman dh, int elems, int minCodes, int maxLength)
            {
                _dh = dh;
                minNumCodes = minCodes;
                _maxLength = maxLength;
                freqs = new short[elems];
                _blCounts = new int[maxLength];
            }

            #endregion Constructors

            /// <summary>
            ///     Resets the internal state of the tree
            /// </summary>
            public void Reset()
            {
                for (var i = 0; i < freqs.Length; i++) freqs[i] = 0;

                _codes = null;
                length = null;
            }

            public void WriteSymbol(int code)
            {
                //				if (DeflaterConstants.DEBUGGING) {
                //					freqs[code]--;
                //					//  	  Console.Write("writeSymbol("+freqs.length+","+code+"): ");
                //				}
                _dh.pending.WriteBits(_codes![code] & 0xffff, length![code]);
            }

            /// <summary>
            ///     Check that all frequencies are zero
            /// </summary>
            /// <exception cref="SharpZipBaseException">
            ///     At least one frequency is non-zero
            /// </exception>
            // ReSharper disable once UnusedMember.Local
            public void CheckEmpty()
            {
                var empty = true;
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var frequency in freqs) empty &= frequency == 0;

                if (!empty) throw new SharpZipBaseException("!Empty");
            }

            /// <summary>
            ///     Set static codes and length
            /// </summary>
            /// <param name="staticCodes">new codes</param>
            /// <param name="staticLengths">length for new codes</param>
            public void SetStaticCodes(short[] staticCodes, byte[] staticLengths)
            {
                _codes = staticCodes;
                length = staticLengths;
            }

            /// <summary>
            ///     Build dynamic codes and lengths
            /// </summary>
            public void BuildCodes()
            {
                var nextCode = new int[_maxLength];
                var code = 0;

                _codes = new short[freqs.Length];

                //				if (DeflaterConstants.DEBUGGING) {
                //					//Console.WriteLine("buildCodes: "+freqs.Length);
                //				}

                for (var bits = 0; bits < _maxLength; bits++)
                {
                    nextCode[bits] = code;
                    code += _blCounts[bits] << (15 - bits);

                    //					if (DeflaterConstants.DEBUGGING) {
                    //						//Console.WriteLine("bits: " + ( bits + 1) + " count: " + bl_counts[bits]
                    //						                  +" nextCode: "+code);
                    //					}
                }

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
                if (DeflaterConstants.DEBUGGING && code != 65536)
                    throw new SharpZipBaseException("Inconsistent bl_counts!");

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
                for (var i = 0; i < numCodes; i++)
                {
                    int bits = length![i];
                    if (!(bits > 0)) continue;

                    //						if (DeflaterConstants.DEBUGGING) {
                    //								//Console.WriteLine("codes["+i+"] = rev(" + nextCode[bits-1]+"),
                    //								                  +bits);
                    //						}

                    _codes![i] = BitReverse(nextCode[bits - 1]);
                    nextCode[bits - 1] += 1 << (16 - bits);
                }
            }

            public void BuildTree()
            {
                var numSymbols = freqs.Length;

                /* heap is a priority queue, sorted by frequency, least frequent
                 * nodes first.  The heap is a binary tree, with the property, that
                 * the parent node is smaller than both child nodes.  This assures
                 * that the smallest node is the first parent.
                 *
                 * The binary tree is encoded in an array:  0 is root node and
                 * the nodes 2*n+1, 2*n+2 are the child nodes of node n.
                 */
                var heap = new int[numSymbols];
                var heapLen = 0;
                var maxCode = 0;
                for (var n = 0; n < numSymbols; n++)
                {
                    int freq = freqs[n];
                    if (freq == 0) continue;

                    // Insert n into heap
                    var pos = heapLen++;
                    int ppos;
                    while (pos > 0 && freqs[heap[ppos = (pos - 1) / 2]] > freq)
                    {
                        heap[pos] = heap[ppos];
                        pos = ppos;
                    }

                    heap[pos] = n;

                    maxCode = n;
                }

                /* We could encode a single literal with 0 bits but then we
                 * don't see the literals.  Therefore we force at least two
                 * literals to avoid this case.  We don't care about order in
                 * this case, both literals get a 1 bit code.
                 */
                while (heapLen < 2)
                {
                    var node = maxCode < 2 ? ++maxCode : 0;
                    heap[heapLen++] = node;
                }

                numCodes = Math.Max(maxCode + 1, minNumCodes);

                var numLeafs = heapLen;
                var childs = new int[4 * heapLen - 2];
                var values = new int[2 * heapLen - 1];
                var numNodes = numLeafs;
                for (var i = 0; i < heapLen; i++)
                {
                    var node = heap[i];
                    childs[2 * i] = node;
                    childs[2 * i + 1] = -1;
                    values[i] = freqs[node] << 8;
                    heap[i] = i;
                }

                /* Construct the Huffman tree by repeatedly combining the least two
                 * frequent nodes.
                 */
                do
                {
                    var first = heap[0];
                    var last = heap[--heapLen];

                    // Propagate the hole to the leafs of the heap
                    var ppos = 0;
                    var path = 1;

                    while (path < heapLen)
                    {
                        if (path + 1 < heapLen && values[heap[path]] > values[heap[path + 1]]) path++;

                        heap[ppos] = heap[path];
                        ppos = path;
                        path = path * 2 + 1;
                    }

                    /* Now propagate the last element down along path.  Normally
                     * it shouldn't go too deep.
                     */
                    var lastVal = values[last];
                    while ((path = ppos) > 0 && values[heap[ppos = (path - 1) / 2]] > lastVal) heap[path] = heap[ppos];

                    heap[path] = last;

                    var second = heap[0];

                    // Create a new node father of first and second
                    last = numNodes++;
                    childs[2 * last] = first;
                    childs[2 * last + 1] = second;
                    var mindepth = Math.Min(values[first] & 0xff, values[second] & 0xff);
                    values[last] = lastVal = values[first] + values[second] - mindepth + 1;

                    // Again, propagate the hole to the leafs
                    ppos = 0;
                    path = 1;

                    while (path < heapLen)
                    {
                        if (path + 1 < heapLen && values[heap[path]] > values[heap[path + 1]]) path++;

                        heap[ppos] = heap[path];
                        ppos = path;
                        path = ppos * 2 + 1;
                    }

                    // Now propagate the new element down along path
                    while ((path = ppos) > 0 && values[heap[ppos = (path - 1) / 2]] > lastVal) heap[path] = heap[ppos];

                    heap[path] = last;
                } while (heapLen > 1);

                if (heap[0] != childs.Length / 2 - 1) throw new SharpZipBaseException("Heap invariant violated");

                BuildLength(childs);
            }

            /// <summary>
            ///     Get encoded length
            /// </summary>
            /// <returns>Encoded length, the sum of frequencies * lengths</returns>
            public int GetEncodedLength()
            {
                var len = 0;
                // ReSharper disable once LoopCanBeConvertedToQuery
                for (var i = 0; i < freqs.Length; i++) len += freqs[i] * length![i];

                return len;
            }

            /// <summary>
            ///     Scan a literal or distance tree to determine the frequencies of the codes
            ///     in the bit length tree.
            /// </summary>
            public void CalcBLFreq(Tree blTree)
            {
                var curlen = -1; /* length of current code */

                var i = 0;
                while (i < numCodes)
                {
                    int maxCount; /* max repeat count */
                    int minCount; /* min repeat count */
                    var count = 1; /* repeat count of the current code */
                    int nextlen = length![i];
                    if (nextlen == 0)
                    {
                        maxCount = 138;
                        minCount = 3;
                    }
                    else
                    {
                        maxCount = 6;
                        minCount = 3;
                        if (curlen != nextlen)
                        {
                            blTree.freqs[nextlen]++;
                            count = 0;
                        }
                    }

                    curlen = nextlen;
                    i++;

                    while (i < numCodes && curlen == length![i])
                    {
                        i++;
                        if (++count >= maxCount) break;
                    }

                    if (count < minCount)
                        blTree.freqs[curlen] += (short)count;
                    else if (curlen != 0)
                        blTree.freqs[Rep36]++;
                    else if (count <= 10)
                        blTree.freqs[Rep310]++;
                    else
                        blTree.freqs[Rep11138]++;
                }
            }

            /// <summary>
            ///     Write tree values
            /// </summary>
            /// <param name="blTree">Tree to write</param>
            public void WriteTree(Tree blTree)
            {
                var curlen = -1; // length of current code

                var i = 0;
                while (i < numCodes)
                {
                    int maxCount; /* max repeat count */
                    int minCount; /* min repeat count */
                    var count = 1; /* repeat count of the current code */
                    int nextlen = length![i];
                    if (nextlen == 0)
                    {
                        maxCount = 138;
                        minCount = 3;
                    }
                    else
                    {
                        maxCount = 6;
                        minCount = 3;
                        if (curlen != nextlen)
                        {
                            blTree.WriteSymbol(nextlen);
                            count = 0;
                        }
                    }

                    curlen = nextlen;
                    i++;

                    while (i < numCodes && curlen == length![i])
                    {
                        i++;
                        if (++count >= maxCount) break;
                    }

                    if (count < minCount)
                    {
                        while (count-- > 0) blTree.WriteSymbol(curlen);
                    }
                    else if (curlen != 0)
                    {
                        blTree.WriteSymbol(Rep36);
                        _dh.pending.WriteBits(count - 3, 2);
                    }
                    else if (count <= 10)
                    {
                        blTree.WriteSymbol(Rep310);
                        _dh.pending.WriteBits(count - 3, 3);
                    }
                    else
                    {
                        blTree.WriteSymbol(Rep11138);
                        _dh.pending.WriteBits(count - 11, 7);
                    }
                }
            }

            private void BuildLength(int[] childs)
            {
                length = new byte[freqs.Length];
                var numNodes = childs.Length / 2;
                var numLeafs = (numNodes + 1) / 2;
                var overflow = 0;

                for (var i = 0; i < _maxLength; i++) _blCounts[i] = 0;

                // First calculate optimal bit lengths
                var lengths = new int[numNodes];
                lengths[numNodes - 1] = 0;

                for (var i = numNodes - 1; i >= 0; i--)
                    if (childs[2 * i + 1] != -1)
                    {
                        var bitLength = lengths[i] + 1;
                        if (bitLength > _maxLength)
                        {
                            bitLength = _maxLength;
                            overflow++;
                        }

                        lengths[childs[2 * i]] = lengths[childs[2 * i + 1]] = bitLength;
                    }
                    else
                    {
                        // A leaf node
                        var bitLength = lengths[i];
                        _blCounts[bitLength - 1]++;
                        length![childs[2 * i]] = (byte)lengths[i];
                    }

                //				if (DeflaterConstants.DEBUGGING) {
                //					//Console.WriteLine("Tree "+freqs.Length+" lengths:");
                //					for (int i=0; i < numLeafs; i++) {
                //						//Console.WriteLine("Node "+childs[2*i]+" freq: "+freqs[childs[2*i]]
                //						                  + " len: "+length[childs[2*i]]);
                //					}
                //				}

                if (overflow == 0) return;

                var incrBitLen = _maxLength - 1;
                do
                {
                    // Find the first bit length which could increase:
                    while (_blCounts[--incrBitLen] == 0)
                    {
                    }

                    // Move this node one down and remove a corresponding
                    // number of overflow nodes.
                    do
                    {
                        _blCounts[incrBitLen]--;
                        _blCounts[++incrBitLen]++;
                        overflow -= 1 << (_maxLength - 1 - incrBitLen);
                    } while (overflow > 0 && incrBitLen < _maxLength - 1);
                } while (overflow > 0);

                /* We may have overshot above.  Move some nodes from maxLength to
                 * maxLength-1 in that case.
                 */
                _blCounts[_maxLength - 1] += overflow;
                _blCounts[_maxLength - 2] -= overflow;

                /* Now recompute all bit lengths, scanning in increasing
                 * frequency.  It is simpler to reconstruct all lengths instead of
                 * fixing only the wrong ones. This idea is taken from 'ar'
                 * written by Haruhiko Okumura.
                 *
                 * The nodes were inserted with decreasing frequency into the childs
                 * array.
                 */
                var nodePtr = 2 * numLeafs;
                for (var bits = _maxLength; bits != 0; bits--)
                {
                    var n = _blCounts[bits - 1];
                    while (n > 0)
                    {
                        var childPtr = 2 * childs[nodePtr++];
                        if (childs[childPtr + 1] != -1) continue;

                        // We found another leaf
                        length![childs[childPtr]] = (byte)bits;
                        n--;
                    }
                }
                //				if (DeflaterConstants.DEBUGGING) {
                //					//Console.WriteLine("*** After overflow elimination. ***");
                //					for (int i=0; i < numLeafs; i++) {
                //						//Console.WriteLine("Node "+childs[2*i]+" freq: "+freqs[childs[2*i]]
                //						                  + " len: "+length[childs[2*i]]);
                //					}
                //				}
            }

            #region Instance Fields

            public readonly short[] freqs;

            public byte[]? length;

            // ReSharper disable once MemberCanBePrivate.Local
            public readonly int minNumCodes;

            public int numCodes;

            private short[]? _codes;
            private readonly int[] _blCounts;
            private readonly int _maxLength;
            private readonly DeflaterHuffman _dh;

            #endregion Instance Fields
        }

        static DeflaterHuffman()
        {
            // See RFC 1951 3.2.6
            // Literal codes
            StaticLCodes = new short[LiteralNum];
            StaticLLength = new byte[LiteralNum];

            var i = 0;
            while (i < 144)
            {
                StaticLCodes[i] = BitReverse((0x030 + i) << 8);
                StaticLLength[i++] = 8;
            }

            while (i < 256)
            {
                StaticLCodes[i] = BitReverse((0x190 - 144 + i) << 7);
                StaticLLength[i++] = 9;
            }

            while (i < 280)
            {
                StaticLCodes[i] = BitReverse((0x000 - 256 + i) << 9);
                StaticLLength[i++] = 7;
            }

            while (i < LiteralNum)
            {
                StaticLCodes[i] = BitReverse((0x0c0 - 280 + i) << 8);
                StaticLLength[i++] = 8;
            }

            // Distance codes
            StaticDCodes = new short[DistNum];
            StaticDLength = new byte[DistNum];
            for (i = 0; i < DistNum; i++)
            {
                StaticDCodes[i] = BitReverse(i << 11);
                StaticDLength[i] = 5;
            }
        }

        /// <summary>
        ///     Construct instance with pending buffer
        /// </summary>
        /// <param name="pending">Pending buffer to use</param>
        public DeflaterHuffman(DeflaterPending pending)
        {
            this.pending = pending;

            _literalTree = new(this, LiteralNum, 257, 15);
            _distTree = new(this, DistNum, 1, 15);
            _blTree = new(this, BitlenNum, 4, 7);

            _dBuf = new short[Bufsize];
            _lBuf = new byte[Bufsize];
        }

        /// <summary>
        ///     Reset internal state
        /// </summary>
        public void Reset()
        {
            _lastLit = 0;
            _extraBits = 0;
            _literalTree.Reset();
            _distTree.Reset();
            _blTree.Reset();
        }

        /// <summary>
        ///     Write all trees to pending buffer
        /// </summary>
        /// <param name="blTreeCodes">The number/rank of treecodes to send.</param>
        public void SendAllTrees(int blTreeCodes)
        {
            _blTree.BuildCodes();
            _literalTree.BuildCodes();
            _distTree.BuildCodes();
            pending.WriteBits(_literalTree.numCodes - 257, 5);
            pending.WriteBits(_distTree.numCodes - 1, 5);
            pending.WriteBits(blTreeCodes - 4, 4);
            for (var rank = 0; rank < blTreeCodes; rank++) pending.WriteBits(_blTree.length![BlOrder[rank]], 3);

            _literalTree.WriteTree(_blTree);
            _distTree.WriteTree(_blTree);

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING) _blTree.CheckEmpty();

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
        }

        /// <summary>
        ///     Compress current buffer writing data to pending buffer
        /// </summary>
        public void CompressBlock()
        {
            for (var i = 0; i < _lastLit; i++)
            {
                var litlen = _lBuf[i] & 0xff;
                int dist = _dBuf[i];
                if (dist-- != 0)
                {
                    //					if (DeflaterConstants.DEBUGGING) {
                    //						Console.Write("["+(dist+1)+","+(litlen+3)+"]: ");
                    //					}

                    var lc = Lcode(litlen);
                    _literalTree.WriteSymbol(lc);

                    var bits = (lc - 261) / 4;
                    if (bits is > 0 and <= 5) pending.WriteBits(litlen & ((1 << bits) - 1), bits);

                    var dc = Dcode(dist);
                    _distTree.WriteSymbol(dc);

                    bits = dc / 2 - 1;
                    if (bits > 0) pending.WriteBits(dist & ((1 << bits) - 1), bits);
                }
                else
                {
                    //					if (DeflaterConstants.DEBUGGING) {
                    //						if (litlen > 32 && litlen < 127) {
                    //							Console.Write("("+(char)litlen+"): ");
                    //						} else {
                    //							Console.Write("{"+litlen+"}: ");
                    //						}
                    //					}
                    _literalTree.WriteSymbol(litlen);
                }
            }

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            if (DeflaterConstants.DEBUGGING) Console.Write("EOF: ");

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
            _literalTree.WriteSymbol(EofSymbol);

#if DebugDeflation
#pragma warning disable CS0162
// ReSharper disable HeuristicUnreachableCode
            // ReSharper disable once InvertIf
            if (DeflaterConstants.DEBUGGING)
            {
                _literalTree.CheckEmpty();
                _distTree.CheckEmpty();
            }

// ReSharper restore HeuristicUnreachableCode
#pragma warning restore CS0162
#endif
        }

        /// <summary>
        ///     Flush block to output with no compression
        /// </summary>
        /// <param name="stored">Data to write</param>
        /// <param name="storedOffset">Index of first byte to write</param>
        /// <param name="storedLength">Count of bytes to write</param>
        /// <param name="lastBlock">True if this is the last block</param>
        public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
        {
#if DebugDeflation
            //			if (DeflaterConstants.DEBUGGING) {
            //				//Console.WriteLine("Flushing stored block "+ storedLength);
            //			}
#endif
            pending.WriteBits(DeflaterConstants.STORED_BLOCK + (lastBlock ? 1 : 0), 3);
            pending.AlignToByte();
            pending.WriteShort(storedLength);
            pending.WriteShort(~storedLength);
            pending.WriteBlock(stored, storedOffset, storedLength);
            Reset();
        }

        /// <summary>
        ///     Flush block to output with compression
        /// </summary>
        /// <param name="stored">Data to flush</param>
        /// <param name="storedOffset">Index of first byte to flush</param>
        /// <param name="storedLength">Count of bytes to flush</param>
        /// <param name="lastBlock">True if this is the last block</param>
        public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
        {
            _literalTree.freqs[EofSymbol]++;

            // Build trees
            _literalTree.BuildTree();
            _distTree.BuildTree();

            // Calculate bitlen frequency
            _literalTree.CalcBLFreq(_blTree);
            _distTree.CalcBLFreq(_blTree);

            // Build bitlen tree
            _blTree.BuildTree();

            var blTreeCodes = 4;
            for (var i = 18; i > blTreeCodes; i--)
                if (_blTree.length![BlOrder[i]] > 0)
                    blTreeCodes = i + 1;

            var optLen = 14 + blTreeCodes * 3 + _blTree.GetEncodedLength() +
                         _literalTree.GetEncodedLength() + _distTree.GetEncodedLength() +
                         _extraBits;

            var staticLen = _extraBits;
            for (var i = 0; i < LiteralNum; i++) staticLen += _literalTree.freqs[i] * StaticLLength[i];

            for (var i = 0; i < DistNum; i++) staticLen += _distTree.freqs[i] * StaticDLength[i];

            if (optLen >= staticLen)
                // Force static trees
                optLen = staticLen;

            if (storedOffset >= 0 && storedLength + 4 < optLen >> 3)
            {
                // Store Block

                //				if (DeflaterConstants.DEBUGGING) {
                //					//Console.WriteLine("Storing, since " + storedLength + " < " + opt_len
                //					                  + " <= " + static_len);
                //				}
                FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
            }
            else if (optLen == staticLen)
            {
                // Encode with static tree
                pending.WriteBits((DeflaterConstants.STATIC_TREES << 1) + (lastBlock ? 1 : 0), 3);
                _literalTree.SetStaticCodes(StaticLCodes, StaticLLength);
                _distTree.SetStaticCodes(StaticDCodes, StaticDLength);
                CompressBlock();
                Reset();
            }
            else
            {
                // Encode with dynamic tree
                pending.WriteBits((DeflaterConstants.DYN_TREES << 1) + (lastBlock ? 1 : 0), 3);
                SendAllTrees(blTreeCodes);
                CompressBlock();
                Reset();
            }
        }

        /// <summary>
        ///     Get value indicating if internal buffer is full
        /// </summary>
        /// <returns>true if buffer is full</returns>
        public bool IsFull()
        {
            return _lastLit >= Bufsize;
        }

        /// <summary>
        ///     Add literal to buffer
        /// </summary>
        /// <param name="literal">Literal value to add to buffer.</param>
        /// <returns>Value indicating internal buffer is full</returns>
        public bool TallyLit(int literal)
        {
            //			if (DeflaterConstants.DEBUGGING) {
            //				if (lit > 32 && lit < 127) {
            //					//Console.WriteLine("("+(char)lit+")");
            //				} else {
            //					//Console.WriteLine("{"+lit+"}");
            //				}
            //			}
            _dBuf[_lastLit] = 0;
            _lBuf[_lastLit++] = (byte)literal;
            _literalTree.freqs[literal]++;
            return IsFull();
        }

        /// <summary>
        ///     Add distance code and length to literal and distance trees
        /// </summary>
        /// <param name="distance">Distance code</param>
        /// <param name="length">Length</param>
        /// <returns>Value indicating if internal buffer is full</returns>
        public bool TallyDist(int distance, int length)
        {
            //			if (DeflaterConstants.DEBUGGING) {
            //				//Console.WriteLine("[" + distance + "," + length + "]");
            //			}

            _dBuf[_lastLit] = (short)distance;
            _lBuf[_lastLit++] = (byte)(length - 3);

            var lc = Lcode(length - 3);
            _literalTree.freqs[lc]++;
            if (lc is >= 265 and < 285) _extraBits += (lc - 261) / 4;

            var dc = Dcode(distance - 1);
            _distTree.freqs[dc]++;
            if (dc >= 4) _extraBits += dc / 2 - 1;

            return IsFull();
        }

        /// <summary>
        ///     Reverse the bits of a 16 bit value.
        /// </summary>
        /// <param name="toReverse">Value to reverse bits</param>
        /// <returns>Value with bits reversed</returns>
        public static short BitReverse(int toReverse)
        {
            return (short)((Bit4Reverse[toReverse & 0xF] << 12) |
                           (Bit4Reverse[(toReverse >> 4) & 0xF] << 8) |
                           (Bit4Reverse[(toReverse >> 8) & 0xF] << 4) |
                           Bit4Reverse[toReverse >> 12]);
        }

        private static int Lcode(int length)
        {
            if (length == 255) return 285;

            var code = 257;
            while (length >= 8)
            {
                code += 4;
                length >>= 1;
            }

            return code + length;
        }

        private static int Dcode(int distance)
        {
            var code = 0;
            while (distance >= 4)
            {
                code += 2;
                distance >>= 1;
            }

            return code + distance;
        }

        #region Instance Fields

        /// <summary>
        ///     Pending buffer to use
        /// </summary>
        public DeflaterPending pending;

        private readonly Tree _literalTree;
        private readonly Tree _distTree;
        private readonly Tree _blTree;

        // Buffer for distances
        private readonly short[] _dBuf;

        private readonly byte[] _lBuf;
        private int _lastLit;
        private int _extraBits;

        #endregion Instance Fields
    }
}
