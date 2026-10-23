using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Interaction.Talking
{
    public sealed class TalkUIRenderContext
    {
        public Vector2 CameraPosition;
        public bool MirrorMode, ControllerInput;
        public global::Celeste.Graphics.Content.Tiles.TileRegion Button;
        public string KeyName = "X";
    }
}
