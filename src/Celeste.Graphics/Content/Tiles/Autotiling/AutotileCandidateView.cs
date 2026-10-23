using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public readonly struct AutotileCandidateView
    {
        public readonly List<AtlasEntry> Textures;
        public readonly List<string> OverlapSprites;
        public readonly bool HasOverlays;
        public bool HasCandidates => Textures != null;

        public AutotileCandidateView(List<AtlasEntry> textures, List<string> overlapSprites, bool hasOverlays)
        {
            Textures = textures;
            OverlapSprites = overlapSprites;
            HasOverlays = hasOverlays;
        }
    }
}
