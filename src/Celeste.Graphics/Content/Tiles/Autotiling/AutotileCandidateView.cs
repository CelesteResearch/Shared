using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public readonly struct AutotileCandidateView(
        List<AtlasEntry> textures,
        List<string> overlapSprites,
        bool hasOverlays)
    {
        public readonly List<AtlasEntry> Textures = textures;
        public readonly List<string> OverlapSprites = overlapSprites;
        public readonly bool HasOverlays = hasOverlays;
        public bool HasCandidates => Textures != null;
    }
}
