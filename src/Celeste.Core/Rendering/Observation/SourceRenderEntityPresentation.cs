using System;
using Celeste.Core.Maps;

namespace Celeste.Core.Rendering.Observation
{
    public readonly struct SourceRenderEntityPresentation(
        bool hasDepth,
        double actualDepth,
        bool hasSourceId,
        MapEntityId sourceId,
        string room = null)
    {
        public readonly bool HasDepth = hasDepth;
        public readonly double ActualDepth = actualDepth;
        public readonly bool HasSourceId = hasSourceId;
        public readonly MapEntityId SourceId = sourceId;
        public readonly string Room = room ?? (hasSourceId ? sourceId.Level : null);

        public bool Matches(in SourceRenderEntityPresentation other)
        {
            return HasDepth == other.HasDepth &&
                   BitConverter.DoubleToInt64Bits(ActualDepth) == BitConverter.DoubleToInt64Bits(other.ActualDepth) &&
                   HasSourceId == other.HasSourceId && SourceId.Equals(other.SourceId) && Room == other.Room;
        }
    }
}
