using System.Numerics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Gameplay.Interaction.Talking
{
    public sealed class TalkHoverDisplay
    {
        public AtlasEntry Texture;
        public Vector2 InputPosition;
        public string SfxIn = "event:/ui/game/hotspot_main_in", SfxOut = "event:/ui/game/hotspot_main_out";
    }
}
