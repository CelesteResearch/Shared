using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public readonly struct RoomLoadEvent
    {
        public readonly RoomLoadEventKind Kind;
        public readonly int Ordinal;
        public readonly string OriginalType;
        public readonly string SourceId;

        public RoomLoadEvent(RoomLoadEventKind kind, int ordinal, string originalType, string sourceId)
        {
            Kind = kind;
            Ordinal = ordinal;
            OriginalType = originalType;
            SourceId = sourceId;
        }
    }
}
