using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Surfaces
{
    public sealed class PlayerCollisionSurface
    {
        public Func<global::Celeste.Simulation.RoomPlayerSession, Vector2,
            global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult> OnDashCollide;

        public Action<Vector2> OnCollide;
        public Func<global::Celeste.Simulation.Gameplay.Player.State.PlayerState, int> GetLandSoundIndex;
        public bool IsDreamBlock;
        public Action<Vector2> FootstepRipple;
    }
}
