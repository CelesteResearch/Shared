using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public class AutotileCandidates
    {
        public List<AtlasEntry> Textures = [];

        public List<string> OverlapSprites = [];

        public bool HasOverlays;
    }
}
