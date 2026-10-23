using Celeste.Core.Display;
using Celeste.Graphics.Display;
using System.Numerics;

namespace Celeste.Graphics.Animation.Replay
{
    // Recorded character movement, sprite animation and hair presentation at one timestamp.
    public struct CharacterReplayFrame
    {
        public Vector2 Position;
        public float TimeStamp;
        public string Animation;
        public int Facing;

        public bool OnGround;

        // Stored as the original packed bytes: Color is created with `new Color(byte,byte,byte,255)`.
        public PackedColor HairColour;
        public int Depth;
        public Vector2 Scale;
        public Vector2 DashDirection;
    }
}
