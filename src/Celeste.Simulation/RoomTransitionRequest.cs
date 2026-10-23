using System;
using System.Linq;
using System.Numerics;

namespace Celeste.Simulation
{
    public readonly struct RoomTransitionRequest
    {
        public readonly global::Celeste.Core.Maps.MapElement TargetRoom;
        public readonly Vector2 At, Direction;

        public RoomTransitionRequest(global::Celeste.Core.Maps.MapElement targetRoom, Vector2 at, Vector2 direction)
        {
            TargetRoom = targetRoom;
            At = at;
            Direction = direction;
        }
    }
}
