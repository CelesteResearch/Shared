using System;

namespace Celeste.Core.Campaigns.Collectibles
{
    public sealed class CheckpointCollectibleCatalog
    {
        public int InitialCount;
        public int TotalCount;
        public string[,] IdsByCheckpoint;
        public string[] SpecialIds = Array.Empty<string>();
    }
}
