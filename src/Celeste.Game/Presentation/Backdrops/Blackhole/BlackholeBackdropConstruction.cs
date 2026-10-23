using System.Collections.Generic;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Backdrops.Blackhole
{
    public readonly struct BlackholeBackdropConstruction
    {
        public PackedColor[] MildColors { get; }
        public List<AtlasEntry> StreamTextures { get; }

        public BlackholeBackdropConstruction(PackedColor[] mildColors, List<AtlasEntry> streamTextures = null)
        {
            MildColors = mildColors;
            StreamTextures = streamTextures;
        }
    }
}
