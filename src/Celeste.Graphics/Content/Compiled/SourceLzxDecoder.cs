using System.IO;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceLzxDecoder
    {
        private class BitBuffer
        {
            private uint buffer;

            private byte bitsleft;

            private readonly Stream byteStream;

            public BitBuffer(Stream stream)
            {
                byteStream = stream;
                InitBitStream();
            }

            public void InitBitStream()
            {
                buffer = 0u;
                bitsleft = 0;
            }

            public void EnsureBits(byte bits)
            {
                while (bitsleft < bits)
                {
                    int num = (byte)byteStream.ReadByte();
                    int num2 = (byte)byteStream.ReadByte();
                    buffer |= (uint)(((num2 << 8) | num) << (16 - bitsleft));
                    bitsleft += 16;
                }
            }

            public uint PeekBits(byte bits)
            {
                return buffer >> (32 - bits);
            }

            public void RemoveBits(byte bits)
            {
                buffer <<= bits;
                bitsleft -= bits;
            }

            public uint ReadBits(byte bits)
            {
                var result = 0u;
                if (bits > 0)
                {
                    EnsureBits(bits);
                    result = PeekBits(bits);
                    RemoveBits(bits);
                }

                return result;
            }

            public uint GetBuffer()
            {
                return buffer;
            }

            public byte GetBitsLeft()
            {
                return bitsleft;
            }
        }

        private struct LzxState
        {
            public uint R0;

            public uint R1;

            public uint R2;

            public ushort main_elements;

            public int header_read;

            public SourceLzxConstants.BLOCKTYPE block_type;

            public uint block_length;

            public uint block_remaining;

            public uint frames_read;

            public int intel_filesize;

            public int intel_curpos;

            public int intel_started;

            public ushort[] PRETREE_table;

            public byte[] PRETREE_len;

            public ushort[] MAINTREE_table;

            public byte[] MAINTREE_len;

            public ushort[] LENGTH_table;

            public byte[] LENGTH_len;

            public ushort[] ALIGNED_table;

            public byte[] ALIGNED_len;

            public uint actual_size;

            public byte[] window;

            public uint window_size;

            public uint window_posn;
        }

        private readonly SourceContentProcessState process;

        private uint[] position_base
        {
            get => process.LzxPositionBase;
            set => process.LzxPositionBase = value;
        }

        private byte[] extra_bits
        {
            get => process.LzxExtraBits;
            set => process.LzxExtraBits = value;
        }

        private LzxState m_state;

        public SourceLzxDecoder(int window, SourceContentProcessState actualProcess)
        {
            process = actualProcess;
            var num = (uint)(1 << window);
            if (window < 15 || window > 21) throw new SourceUnsupportedWindowSizeRange();

            m_state = default;
            m_state.actual_size = 0u;
            m_state.window = new byte[num];
            for (var i = 0; i < num; i++) m_state.window[i] = 220;

            m_state.actual_size = num;
            m_state.window_size = num;
            m_state.window_posn = 0u;
            if (extra_bits == null)
            {
                extra_bits = new byte[52];
                var j = 0;
                var num2 = 0;
                for (; j <= 50; j += 2)
                {
                    extra_bits[j] = extra_bits[j + 1] = (byte)num2;
                    if (j != 0 && num2 < 17) num2++;
                }
            }

            if (position_base == null)
            {
                position_base = new uint[51];
                var k = 0;
                var num3 = 0;
                for (; k <= 50; k++)
                {
                    position_base[k] = (uint)num3;
                    num3 += 1 << extra_bits[k];
                }
            }

            var num4 = window switch
            {
                20 => 42,
                21 => 50,
                _ => window << 1,
            };
            m_state.R0 = m_state.R1 = m_state.R2 = 1u;
            m_state.main_elements = (ushort)(256 + (num4 << 3));
            m_state.header_read = 0;
            m_state.frames_read = 0u;
            m_state.block_remaining = 0u;
            m_state.block_type = SourceLzxConstants.BLOCKTYPE.INVALID;
            m_state.intel_curpos = 0;
            m_state.intel_started = 0;
            m_state.PRETREE_table = new ushort[104];
            m_state.PRETREE_len = new byte[84];
            m_state.MAINTREE_table = new ushort[5408];
            m_state.MAINTREE_len = new byte[720];
            m_state.LENGTH_table = new ushort[4596];
            m_state.LENGTH_len = new byte[314];
            m_state.ALIGNED_table = new ushort[144];
            m_state.ALIGNED_len = new byte[72];
            for (var l = 0; l < 656; l++) m_state.MAINTREE_len[l] = 0;

            for (var m = 0; m < 250; m++) m_state.LENGTH_len[m] = 0;
        }

        public int Decompress(Stream inData, int inLen, Stream outData, int outLen)
        {
            var bitBuffer = new BitBuffer(inData);
            var position = inData.Position;
            var num = inData.Position + inLen;
            var window = m_state.window;
            var num2 = m_state.window_posn;
            var windowSize = m_state.window_size;
            var num3 = m_state.R0;
            var num4 = m_state.R1;
            var num5 = m_state.R2;
            var num6 = outLen;
            bitBuffer.InitBitStream();
            if (m_state.header_read == 0)
            {
                if (bitBuffer.ReadBits(1) != 0)
                {
                    var num7 = bitBuffer.ReadBits(16);
                    var num8 = bitBuffer.ReadBits(16);
                    m_state.intel_filesize = (int)((num7 << 16) | num8);
                }

                m_state.header_read = 1;
            }

            while (num6 > 0)
            {
                if (m_state.block_remaining == 0)
                {
                    if (m_state.block_type == SourceLzxConstants.BLOCKTYPE.UNCOMPRESSED)
                    {
                        if ((m_state.block_length & 1) == 1) inData.ReadByte();

                        bitBuffer.InitBitStream();
                    }

                    m_state.block_type = (SourceLzxConstants.BLOCKTYPE)bitBuffer.ReadBits(3);
                    var num7 = bitBuffer.ReadBits(16);
                    var num8 = bitBuffer.ReadBits(8);
                    m_state.block_remaining = m_state.block_length = (num7 << 8) | num8;
                    switch (m_state.block_type)
                    {
                        case SourceLzxConstants.BLOCKTYPE.ALIGNED:
                            num7 = 0u;
                            num8 = 0u;
                            for (; num7 < 8; num7++)
                            {
                                num8 = bitBuffer.ReadBits(3);
                                m_state.ALIGNED_len[num7] = (byte)num8;
                            }

                            MakeDecodeTable(8u, 7u, m_state.ALIGNED_len, m_state.ALIGNED_table);
                            goto case SourceLzxConstants.BLOCKTYPE.VERBATIM;
                        case SourceLzxConstants.BLOCKTYPE.VERBATIM:
                            ReadLengths(m_state.MAINTREE_len, 0u, 256u, bitBuffer);
                            ReadLengths(m_state.MAINTREE_len, 256u, m_state.main_elements, bitBuffer);
                            MakeDecodeTable(656u, 12u, m_state.MAINTREE_len, m_state.MAINTREE_table);
                            if (m_state.MAINTREE_len[232] != 0) m_state.intel_started = 1;

                            ReadLengths(m_state.LENGTH_len, 0u, 249u, bitBuffer);
                            MakeDecodeTable(250u, 12u, m_state.LENGTH_len, m_state.LENGTH_table);
                            break;
                        case SourceLzxConstants.BLOCKTYPE.UNCOMPRESSED:
                        {
                            m_state.intel_started = 1;
                            bitBuffer.EnsureBits(16);
                            if (bitBuffer.GetBitsLeft() > 16) inData.Seek(-2L, SeekOrigin.Current);

                            var num9 = (byte)inData.ReadByte();
                            var b = (byte)inData.ReadByte();
                            var b2 = (byte)inData.ReadByte();
                            var b3 = (byte)inData.ReadByte();
                            num3 = (uint)(num9 | (b << 8) | (b2 << 16) | (b3 << 24));
                            var num10 = (byte)inData.ReadByte();
                            b = (byte)inData.ReadByte();
                            b2 = (byte)inData.ReadByte();
                            b3 = (byte)inData.ReadByte();
                            num4 = (uint)(num10 | (b << 8) | (b2 << 16) | (b3 << 24));
                            var num11 = (byte)inData.ReadByte();
                            b = (byte)inData.ReadByte();
                            b2 = (byte)inData.ReadByte();
                            b3 = (byte)inData.ReadByte();
                            num5 = (uint)(num11 | (b << 8) | (b2 << 16) | (b3 << 24));
                            break;
                        }
                        default:
                            return -1;
                    }
                }

                if (inData.Position > position + inLen &&
                    (inData.Position > position + inLen + 2 || bitBuffer.GetBitsLeft() < 16))
                    return -1;

                int num12;
                while ((num12 = (int)m_state.block_remaining) > 0 && num6 > 0)
                {
                    if (num12 > num6) num12 = num6;

                    num6 -= num12;
                    m_state.block_remaining -= (uint)num12;
                    num2 &= windowSize - 1;
                    if (num2 + num12 > windowSize) return -1;

                    switch (m_state.block_type)
                    {
                        case SourceLzxConstants.BLOCKTYPE.VERBATIM:
                            while (num12 > 0)
                            {
                                var num13 = (int)ReadHuffSym(m_state.MAINTREE_table, m_state.MAINTREE_len, 656u, 12u,
                                    bitBuffer);
                                if (num13 < 256)
                                {
                                    window[num2++] = (byte)num13;
                                    num12--;
                                    continue;
                                }

                                num13 -= 256;
                                var num14 = num13 & 7;
                                if (num14 == 7)
                                {
                                    var num15 = (int)ReadHuffSym(m_state.LENGTH_table, m_state.LENGTH_len, 250u, 12u,
                                        bitBuffer);
                                    num14 += num15;
                                }

                                num14 += 2;
                                var num16 = num13 >> 3;
                                if (num16 > 2)
                                {
                                    if (num16 != 3)
                                    {
                                        int num17 = extra_bits[num16];
                                        var num18 = (int)bitBuffer.ReadBits((byte)num17);
                                        num16 = (int)(position_base[num16] - 2) + num18;
                                    }
                                    else
                                    {
                                        num16 = 1;
                                    }

                                    num5 = num4;
                                    num4 = num3;
                                    num3 = (uint)num16;
                                }
                                else
                                {
                                    switch (num16)
                                    {
                                        case 0:
                                            num16 = (int)num3;
                                            break;
                                        case 1:
                                            num16 = (int)num4;
                                            num4 = num3;
                                            num3 = (uint)num16;
                                            break;
                                        default:
                                            num16 = (int)num5;
                                            num5 = num3;
                                            num3 = (uint)num16;
                                            break;
                                    }
                                }

                                var num20 = (int)num2;
                                num12 -= num14;
                                int num21;
                                if (num2 >= num16)
                                {
                                    num21 = num20 - num16;
                                }
                                else
                                {
                                    num21 = num20 + ((int)windowSize - num16);
                                    var num22 = num16 - (int)num2;
                                    if (num22 < num14)
                                    {
                                        num14 -= num22;
                                        num2 += (uint)num22;
                                        while (num22-- > 0) window[num20++] = window[num21++];

                                        num21 = 0;
                                    }
                                }

                                num2 += (uint)num14;
                                while (num14-- > 0) window[num20++] = window[num21++];
                            }

                            break;
                        case SourceLzxConstants.BLOCKTYPE.ALIGNED:
                            while (num12 > 0)
                            {
                                var num13 = (int)ReadHuffSym(m_state.MAINTREE_table, m_state.MAINTREE_len, 656u, 12u,
                                    bitBuffer);
                                if (num13 < 256)
                                {
                                    window[num2++] = (byte)num13;
                                    num12--;
                                    continue;
                                }

                                num13 -= 256;
                                var num14 = num13 & 7;
                                if (num14 == 7)
                                {
                                    var num15 = (int)ReadHuffSym(m_state.LENGTH_table, m_state.LENGTH_len, 250u, 12u,
                                        bitBuffer);
                                    num14 += num15;
                                }

                                num14 += 2;
                                var num16 = num13 >> 3;
                                if (num16 > 2)
                                {
                                    int num17 = extra_bits[num16];
                                    num16 = (int)(position_base[num16] - 2);
                                    if (num17 > 3)
                                    {
                                        num17 -= 3;
                                        var num18 = (int)bitBuffer.ReadBits((byte)num17);
                                        num16 += num18 << 3;
                                        var num19 = (int)ReadHuffSym(m_state.ALIGNED_table, m_state.ALIGNED_len, 8u, 7u,
                                            bitBuffer);
                                        num16 += num19;
                                    }
                                    else if (num17 == 3)
                                    {
                                        var num19 = (int)ReadHuffSym(m_state.ALIGNED_table, m_state.ALIGNED_len, 8u, 7u,
                                            bitBuffer);
                                        num16 += num19;
                                    }
                                    else if (num17 > 0)
                                    {
                                        var num18 = (int)bitBuffer.ReadBits((byte)num17);
                                        num16 += num18;
                                    }
                                    else
                                    {
                                        num16 = 1;
                                    }

                                    num5 = num4;
                                    num4 = num3;
                                    num3 = (uint)num16;
                                }
                                else
                                {
                                    switch (num16)
                                    {
                                        case 0:
                                            num16 = (int)num3;
                                            break;
                                        case 1:
                                            num16 = (int)num4;
                                            num4 = num3;
                                            num3 = (uint)num16;
                                            break;
                                        default:
                                            num16 = (int)num5;
                                            num5 = num3;
                                            num3 = (uint)num16;
                                            break;
                                    }
                                }

                                var num20 = (int)num2;
                                num12 -= num14;
                                int num21;
                                if (num2 >= num16)
                                {
                                    num21 = num20 - num16;
                                }
                                else
                                {
                                    num21 = num20 + ((int)windowSize - num16);
                                    var num22 = num16 - (int)num2;
                                    if (num22 < num14)
                                    {
                                        num14 -= num22;
                                        num2 += (uint)num22;
                                        while (num22-- > 0) window[num20++] = window[num21++];

                                        num21 = 0;
                                    }
                                }

                                num2 += (uint)num14;
                                while (num14-- > 0) window[num20++] = window[num21++];
                            }

                            break;
                        case SourceLzxConstants.BLOCKTYPE.UNCOMPRESSED:
                        {
                            if (inData.Position + num12 > num) return -1;

                            var array = new byte[num12];
                            inData.Read(array, 0, num12);
                            array.CopyTo(window, (int)num2);
                            num2 += (uint)num12;
                            break;
                        }
                        default:
                            return -1;
                    }
                }
            }

            if (num6 != 0) return -1;

            var num23 = (int)num2;
            if (num23 == 0) num23 = (int)windowSize;

            num23 -= outLen;
            outData.Write(window, num23, outLen);
            m_state.window_posn = num2;
            m_state.R0 = num3;
            m_state.R1 = num4;
            m_state.R2 = num5;
            if (m_state.frames_read++ < 32768 && m_state.intel_filesize != 0)
            {
                if (outLen <= 6 || m_state.intel_started == 0)
                {
                    m_state.intel_curpos += outLen;
                }
                else
                {
                    var num24 = outLen - 10;
                    var num25 = (uint)m_state.intel_curpos;
                    m_state.intel_curpos = (int)num25 + outLen;
                    while (outData.Position < num24)
                        if (outData.ReadByte() != 232)
                            num25++;
                }

                return -1;
            }

            return 0;
        }

        private int MakeDecodeTable(uint nsyms, uint nbits, byte[] length, ushort[] table)
        {
            byte b = 1;
            var num = 0u;
            var num2 = (uint)(1 << (int)nbits);
            var num3 = num2 >> 1;
            var num4 = num3;
            while (b <= nbits)
            {
                for (ushort num5 = 0; num5 < nsyms; num5++)
                    if (length[num5] == b)
                    {
                        var num6 = num;
                        if ((num += num3) > num2) return 1;

                        var num7 = num3;
                        while (num7-- != 0) table[num6++] = num5;
                    }

                num3 >>= 1;
                b++;
            }

            if (num != num2)
            {
                for (var num5 = (ushort)num; num5 < num2; num5++) table[num5] = 0;

                num <<= 16;
                num2 <<= 16;
                num3 = 32768u;
                while (b <= 16)
                {
                    for (ushort num5 = 0; num5 < nsyms; num5++)
                        if (length[num5] == b)
                        {
                            var num6 = num >> 16;
                            for (var num7 = 0u; num7 < b - nbits; num7++)
                            {
                                if (table[num6] == 0)
                                {
                                    table[num4 << 1] = 0;
                                    table[(num4 << 1) + 1] = 0;
                                    table[num6] = (ushort)num4++;
                                }

                                num6 = (uint)(table[num6] << 1);
                                if (((num >> (int)(15 - num7)) & 1) == 1) num6++;
                            }

                            table[num6] = num5;
                            if ((num += num3) > num2) return 1;
                        }

                    num3 >>= 1;
                    b++;
                }
            }

            if (num == num2) return 0;

            for (ushort num5 = 0; num5 < nsyms; num5++)
                if (length[num5] != 0)
                    return 1;

            return 0;
        }

        private void ReadLengths(byte[] lens, uint first, uint last, BitBuffer bitbuf)
        {
            uint num;
            for (num = 0u; num < 20; num++)
            {
                var num2 = bitbuf.ReadBits(4);
                m_state.PRETREE_len[num] = (byte)num2;
            }

            MakeDecodeTable(20u, 6u, m_state.PRETREE_len, m_state.PRETREE_table);
            num = first;
            while (num < last)
            {
                var num3 = (int)ReadHuffSym(m_state.PRETREE_table, m_state.PRETREE_len, 20u, 6u, bitbuf);
                switch (num3)
                {
                    case 17:
                    {
                        var num2 = bitbuf.ReadBits(4);
                        num2 += 4;
                        while (num2-- != 0) lens[num++] = 0;

                        break;
                    }
                    case 18:
                    {
                        var num2 = bitbuf.ReadBits(5);
                        num2 += 20;
                        while (num2-- != 0) lens[num++] = 0;

                        break;
                    }
                    case 19:
                    {
                        var num2 = bitbuf.ReadBits(1);
                        num2 += 4;
                        num3 = (int)ReadHuffSym(m_state.PRETREE_table, m_state.PRETREE_len, 20u, 6u, bitbuf);
                        num3 = lens[num] - num3;
                        if (num3 < 0) num3 += 17;

                        while (num2-- != 0) lens[num++] = (byte)num3;

                        break;
                    }
                    default:
                        num3 = lens[num] - num3;
                        if (num3 < 0) num3 += 17;

                        lens[num++] = (byte)num3;
                        break;
                }
            }
        }

        private uint ReadHuffSym(ushort[] table, byte[] lengths, uint nsyms, uint nbits, BitBuffer bitbuf)
        {
            bitbuf.EnsureBits(16);
            uint num;
            uint num2;
            if ((num = table[bitbuf.PeekBits((byte)nbits)]) >= nsyms)
            {
                num2 = (uint)(1 << (int)(32 - nbits));
                do
                {
                    num2 >>= 1;
                    num <<= 1;
                    num |= (bitbuf.GetBuffer() & num2) != 0 ? 1u : 0u;
                    if (num2 == 0) return 0u;
                } while ((num = table[num]) >= nsyms);
            }

            num2 = lengths[num];
            bitbuf.RemoveBits((byte)num2);
            return num;
        }
    }
}
