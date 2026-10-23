using System.Numerics;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Simulation.Gameplay.Interaction.Talking
{
    public sealed class TalkUIRenderContext
    {
        public Vector2 CameraPosition;
        public bool MirrorMode, ControllerInput;
        public TileRegion Button;
        public string KeyName = "X";
    }
}
