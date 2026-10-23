using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public class AutotileMaskRule
    {
        public byte[] Mask = new byte[9];

        public AutotileCandidates Tiles = new AutotileCandidates();
    }
}
