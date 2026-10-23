using System.Numerics;
using Celeste.Core.Geometry;
using System;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceDateTimeReader : SourceContentTypeReader<DateTime>
    {
        internal SourceDateTimeReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override DateTime Read(SourceContentReader input, DateTime existingInstance)
        {
            ulong num = input.ReadUInt64();
            ulong num2 = 13835058055282163712uL;
            long ticks = (long)(num & ~num2);
            DateTimeKind kind = (DateTimeKind)((num >> 62) & 3);
            return new DateTime(ticks, kind);
        }
    }
}
