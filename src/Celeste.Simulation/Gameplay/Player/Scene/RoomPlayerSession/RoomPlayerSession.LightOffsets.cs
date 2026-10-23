using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public Vector2 NormalLightOffset = new(0, -8);
        public Vector2 DuckingLightOffset = new(0, -3);
    }
}
