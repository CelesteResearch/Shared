using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class AnimatedTileDefinition
    {
        public string Name;
        public float Delay, OffsetX, OffsetY, OriginX, OriginY;
        public List<AtlasEntry> Frames;
    }
}
