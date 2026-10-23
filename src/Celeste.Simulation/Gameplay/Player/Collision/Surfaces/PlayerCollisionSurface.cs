using System;
using System.Numerics;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Collision.Surfaces
{
    public sealed class PlayerCollisionSurface
    {
        public Func<RoomPlayerSession, Vector2,
            DashCollisionResult> OnDashCollide;

        public Action<Vector2> OnCollide;
        public Func<PlayerState, int> GetLandSoundIndex;
        public bool IsDreamBlock;
        public Action<Vector2> FootstepRipple;
    }
}
