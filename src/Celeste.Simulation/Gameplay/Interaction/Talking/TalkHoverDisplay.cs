using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Interaction.Talking
{
    public sealed class TalkHoverDisplay
    {
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Texture;
        public Vector2 InputPosition;
        public string SfxIn = "event:/ui/game/hotspot_main_in", SfxOut = "event:/ui/game/hotspot_main_out";
    }
}
