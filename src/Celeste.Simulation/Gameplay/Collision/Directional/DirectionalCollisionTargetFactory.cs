using System;
using System.Numerics;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;

namespace Celeste.Simulation.Gameplay.Collision.Directional
{
    public static class DirectionalCollisionTargetFactory
    {
        public static SourceSolidEntityState Create(ISourceSolidWorldFactory worlds,
            Func<RoomPlayerSession, Vector2, DashCollisionResult> onDashCollide = null)
        {
            return new(Vector2.Zero, 0, 0, false, worlds.Create(Vector2.Zero, false))
            {
                OnDashCollide = onDashCollide,
            };
        }
    }
}
