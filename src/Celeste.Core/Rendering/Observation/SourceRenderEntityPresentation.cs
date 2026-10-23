using System;
using Celeste.Core.Maps;

namespace Celeste.Core.Rendering.Observation
{
    public readonly struct SourceRenderEntityPresentation
    {
        public readonly bool HasDepth;
        public readonly double ActualDepth;
        public readonly bool HasSourceId;
        public readonly MapEntityId SourceId;
        public readonly string Room;

        public SourceRenderEntityPresentation(bool hasDepth, double actualDepth, bool hasSourceId, MapEntityId sourceId,
            string room = null)
        {
            HasDepth = hasDepth;
            ActualDepth = actualDepth;
            HasSourceId = hasSourceId;
            SourceId = sourceId;
            Room = room ?? (hasSourceId ? sourceId.Level : null);
        }

        public bool Matches(in SourceRenderEntityPresentation other)
            => HasDepth == other.HasDepth && BitConverter.DoubleToInt64Bits(ActualDepth) ==
                                          BitConverter.DoubleToInt64Bits(other.ActualDepth)
                                          && HasSourceId == other.HasSourceId && SourceId.Equals(other.SourceId) &&
                                          Room == other.Room;
    }
}
