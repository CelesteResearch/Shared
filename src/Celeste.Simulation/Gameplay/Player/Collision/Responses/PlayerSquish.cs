using Celeste.Physics.Collision;
using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Responses
{
    public static class PlayerSquish
    {
        public static bool TrySquishWiggle(PixelActor actor, PixelCollision collision,
            global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform pusher,
            int wiggleX = 3, int wiggleY = 3)
        {
            if (pusher == null) throw new ArgumentNullException(nameof(pusher));
            var policy = collision.Pusher as IPusherSquishWigglePolicy ??
                         pusher.SourceEntityOwner as IPusherSquishWigglePolicy;
            if (policy != null && policy.TryHandleSquishWiggle(actor, collision, wiggleX, wiggleY, out bool result))
                return result;
            pusher.Collidable = true;
            try
            {
                for (int pass = 0; pass < 2; pass++)
                {
                    Vector2 origin = pass == 0 ? actor.Position : collision.TargetPosition;
                    for (int x = 0; x <= wiggleX; x++)
                    for (int y = 0; y <= wiggleY; y++)
                    {
                        if (x == 0 && y == 0) continue;
                        for (int signX = 1; signX >= -1; signX -= 2)
                        for (int signY = 1; signY >= -1; signY -= 2)
                        {
                            var candidate = origin + new Vector2(x * signX, y * signY);
                            if (!actor.World.SolidAt(actor.BoundsAt(candidate)))
                            {
                                actor.Position = candidate;
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            finally
            {
                pusher.Collidable = false;
            }
        }

        public static global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerSquishResult OnSquish(
            global::Celeste.Simulation.Gameplay.Player.Collision.Contacts.PlayerContacts contacts,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            PixelCollision collision, global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform pusher,
            Func<global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest, bool> tryDie)
        {
            if (pusher == null) throw new ArgumentNullException(nameof(pusher));
            var actor = contacts.Body;
            var data = contacts.State;
            bool ducked = false;
            if (!data.Motion.Ducking && machine.State != 1)
            {
                ducked = true;
                data.Motion.Ducking = true;
                contacts.SyncCollider();
                pusher.Collidable = true;
                if (!actor.World.SolidAt(actor.BoundsAt(actor.Position)))
                {
                    pusher.Collidable = false;
                    return global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerSquishResult.Ducked;
                }

                Vector2 position = actor.Position;
                actor.Position = collision.TargetPosition;
                if (!actor.World.SolidAt(actor.BoundsAt(actor.Position)))
                {
                    pusher.Collidable = false;
                    return global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerSquishResult
                        .DuckedAtTarget;
                }

                actor.Position = position;
                pusher.Collidable = false;
            }

            if (!TrySquishWiggle(actor, collision, pusher, 3, 5))
            {
                tryDie?.Invoke(
                    new global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest(Vector2.Zero,
                        pusher.SquishEvenInAssistMode));
                return global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerSquishResult.DeathRequested;
            }

            if (ducked && contacts.CanUnDuck)
            {
                data.Motion.Ducking = false;
                contacts.SyncCollider();
            }

            return global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerSquishResult.Wiggled;
        }
    }
}
