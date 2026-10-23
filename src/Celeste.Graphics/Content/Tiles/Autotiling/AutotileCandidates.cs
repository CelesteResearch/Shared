using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public class AutotileCandidates
    {
        public List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> Textures =
            new List<global::Celeste.Graphics.Content.Atlas.AtlasEntry>();

        public List<string> OverlapSprites = new List<string>();

        public bool HasOverlays;
    }
}
