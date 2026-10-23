using System;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceDateTimeReader : SourceContentTypeReader<DateTime>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceDateTimeReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override DateTime Read(SourceContentReader input, DateTime existingInstance)
        {
            var num = input.ReadUInt64();
            const ulong num2 = 13835058055282163712uL;
            var ticks = (long)(num & ~num2);
            var kind = (DateTimeKind)((num >> 62) & 3);
            return new(ticks, kind);
        }
    }
}
