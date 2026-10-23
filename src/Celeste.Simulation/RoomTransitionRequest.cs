using System.Numerics;
using Celeste.Core.Maps;

namespace Celeste.Simulation
{
    public readonly struct RoomTransitionRequest
    {
        public readonly MapElement TargetRoom;
        public readonly Vector2 At, Direction;

        public RoomTransitionRequest(MapElement targetRoom, Vector2 at, Vector2 direction)
        {
            TargetRoom = targetRoom;
            At = at;
            Direction = direction;
        }
    }
}
