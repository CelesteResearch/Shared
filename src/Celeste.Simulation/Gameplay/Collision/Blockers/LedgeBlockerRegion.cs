using System;
using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Player.Collision.Contacts;

namespace Celeste.Simulation.Gameplay.Collision.Blockers
{
    public sealed class LedgeBlockerRegion
    {
        public Bounds Bounds;
        public bool Blocking = true, Collidable = true;

        public Func<PlayerContacts, bool>
            BlockChecker;

        public Func<Bounds, bool> CheckCollision;

        public bool Intersects(Bounds query)
        {
            return CheckCollision != null ? CheckCollision(query) : query.Intersects(Bounds);
        }
    }
}
