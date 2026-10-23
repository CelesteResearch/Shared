using System;
using System.Collections.Generic;
using System.Xml;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class AnimatedTileDefinition
    {
        public string Name;
        public float Delay, OffsetX, OffsetY, OriginX, OriginY;
        public List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> Frames;
    }
}
