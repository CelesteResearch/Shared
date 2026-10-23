using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Collision.Blockers
{
    public sealed class LedgeBlockerRegion
    {
        public global::Celeste.Core.Geometry.Bounds Bounds;
        public bool Blocking = true, Collidable = true;

        public System.Func<global::Celeste.Simulation.Gameplay.Player.Collision.Contacts.PlayerContacts, bool>
            BlockChecker;

        public System.Func<global::Celeste.Core.Geometry.Bounds, bool> CheckCollision;

        public bool Intersects(global::Celeste.Core.Geometry.Bounds query) =>
            CheckCollision != null ? CheckCollision(query) : query.Intersects(Bounds);
    }
}
