using System;
using System.Buffers.Binary;
using System.Security.Cryptography;

namespace Celeste.Everest
{
    public sealed class XXHash64 : HashAlgorithm
    {
        private const ulong PRIME1 = 11400714785074694791uL;

        private const ulong PRIME2 = 14029467366897019727uL;

        private const ulong PRIME3 = 1609587929392839161uL;

        private const ulong PRIME4 = 9650029242287828579uL;

        private const ulong PRIME5 = 2870177450012600261uL;

        private ulong acc1;

        private ulong acc2;

        private ulong acc3;

        private ulong acc4;

        private ulong inLength;

        private readonly byte[] stripeBuf = new byte[32];

        private int stripeFillSize;

        public new static XXHash64 Create()
        {
            return new();
        }

        public new static XXHash64 Create(string name)
        {
            throw new NotSupportedException();
        }

        public XXHash64()
        {
            if (!BitConverter.IsLittleEndian)
                throw new PlatformNotSupportedException("Big-Endian platforms not supported!");

            Initialize();
        }

        public override void Initialize()
        {
            acc1 = 6983438078262162902uL;
            acc2 = 14029467366897019727uL;
            acc3 = 0uL;
            acc4 = 7046029288634856825uL;
            inLength = 0uL;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            inLength += (ulong)cbSize;
            if (stripeFillSize > 0)
            {
                var num = cbSize < 32 - stripeFillSize ? cbSize : 32 - stripeFillSize;
                Buffer.BlockCopy(array, ibStart, stripeBuf, stripeFillSize, num);
                if ((stripeFillSize += num) < 32) return;

                ProcessStripe(stripeBuf, 0);
                ibStart += num;
                cbSize -= stripeFillSize;
            }

            while (cbSize >= 32)
            {
                ProcessStripe(array, ibStart);
                ibStart += 32;
                cbSize -= 32;
            }

            Buffer.BlockCopy(array, ibStart, stripeBuf, 0, cbSize);
            stripeFillSize = cbSize;
        }

        private void ProcessStripe(byte[] buf, int off)
        {
            acc1 = Rot(acc1 + (ulong)((long)BinaryPrimitives.ReadUInt64LittleEndian(buf.AsSpan(off)) *
                                      -4417276706812531889L)) * 11400714785074694791uL;
            acc2 = Rot(acc2 + (ulong)((long)BinaryPrimitives.ReadUInt64LittleEndian(buf.AsSpan(off + 8)) *
                                      -4417276706812531889L)) * 11400714785074694791uL;
            acc3 = Rot(acc3 + (ulong)((long)BinaryPrimitives.ReadUInt64LittleEndian(buf.AsSpan(off + 16)) *
                                      -4417276706812531889L)) * 11400714785074694791uL;
            acc4 = Rot(acc4 + (ulong)((long)BinaryPrimitives.ReadUInt64LittleEndian(buf.AsSpan(off + 24)) *
                                      -4417276706812531889L)) * 11400714785074694791uL;

            static ulong Rot(ulong v)
            {
                return (v << 31) | (v >> 33);
            }
        }

        protected override byte[] HashFinal()
        {
            var acc = Rot(acc1) + Rot7(acc2) + Rot12(acc3) + Rot18(acc4);
            acc = Merge(acc, acc1);
            acc = Merge(acc, acc2);
            acc = Merge(acc, acc3);
            acc = Merge(acc, acc4);
            acc += inLength;
            var num = 0;
            while (stripeFillSize >= 8)
            {
                acc ^= Round(0uL, BinaryPrimitives.ReadUInt64LittleEndian(stripeBuf.AsSpan(num)));
                acc = (ulong)((long)((acc << 27) | (acc >> 37)) * -7046029288634856825L + -8796714831421723037L);
                num += 8;
                stripeFillSize -= 8;
            }

            while (stripeFillSize >= 4)
            {
                acc ^= (ulong)(BinaryPrimitives.ReadUInt32LittleEndian(stripeBuf.AsSpan(num)) * -7046029288634856825L);
                acc = (ulong)((long)((acc << 23) | (acc >> 41)) * -4417276706812531889L + 1609587929392839161L);
                num += 4;
                stripeFillSize -= 4;
            }

            while (stripeFillSize >= 1)
            {
                acc ^= (ulong)(stripeBuf[num] * 2870177450012600261L);
                acc = ((acc << 11) | (acc >> 53)) * 11400714785074694791uL;
                num++;
                stripeFillSize--;
            }

            acc ^= acc >> 33;
            acc *= 14029467366897019727uL;
            acc ^= acc >> 29;
            acc *= 1609587929392839161L;
            acc ^= acc >> 32;
            return
            [
                (byte)(acc >> 56),
                (byte)(acc >> 48),
                (byte)(acc >> 40),
                (byte)(acc >> 32),
                (byte)(acc >> 24),
                (byte)(acc >> 16),
                (byte)(acc >> 8),
                (byte)acc,
            ];

            static ulong Merge(ulong num2, ulong accN)
            {
                return (ulong)((long)(num2 ^ Round(0uL, accN)) * -7046029288634856825L + -8796714831421723037L);
            }

            static ulong Rot(ulong v)
            {
                return (v << 1) | (v >> 63);
            }

            static ulong Rot12(ulong v)
            {
                return (v << 12) | (v >> 52);
            }

            static ulong Rot18(ulong v)
            {
                return (v << 18) | (v >> 46);
            }

            static ulong Rot31(ulong v)
            {
                return (v << 31) | (v >> 33);
            }

            static ulong Rot7(ulong v)
            {
                return (v << 7) | (v >> 57);
            }

            static ulong Round(ulong a, ulong l)
            {
                return Rot31(a + (ulong)((long)l * -4417276706812531889L)) * 11400714785074694791uL;
            }
        }
    }
}
