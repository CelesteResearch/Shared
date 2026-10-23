namespace Celeste.Simulation
{
    public readonly struct RoomEntityListItem
    {
        public readonly int Ordinal;
        public readonly string OriginalType;
        public readonly string SourceId;
        public readonly long ActualDepthBits;

        public RoomEntityListItem(int ordinal, string originalType, string sourceId, long actualDepthBits)
        {
            Ordinal = ordinal;
            OriginalType = originalType;
            SourceId = sourceId;
            ActualDepthBits = actualDepthBits;
        }
    }
}
