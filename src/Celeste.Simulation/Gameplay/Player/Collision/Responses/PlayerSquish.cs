using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Player.Collision.Contacts;
using Celeste.Simulation.Gameplay.Player.Death;

namespace Celeste.Simulation.Gameplay.Player.Collision.Responses
{
    public static class PlayerSquish
    {
        public static bool TrySquishWiggle(PixelActor actor, PixelCollision collision,
            CollisionPlatform pusher,
            int wiggleX = 3, int wiggleY = 3)
        {
            if (pusher == null) throw new ArgumentNullException(nameof(pusher));
            var policy = collision.Pusher as IPusherSquishWigglePolicy ??
                         pusher.SourceEntityOwner as IPusherSquishWigglePolicy;
            if (policy != null && policy.TryHandleSquishWiggle(actor, collision, wiggleX, wiggleY, out var result))
                return result;
            pusher.Collidable = true;
            try
            {
                for (var pass = 0; pass < 2; pass++)
                {
                    var origin = pass == 0 ? actor.Position : collision.TargetPosition;
                    for (var x = 0; x <= wiggleX; x++)
                    for (var y = 0; y <= wiggleY; y++)
                    {
                        if (x == 0 && y == 0) continue;
                        for (var signX = 1; signX >= -1; signX -= 2)
                        for (var signY = 1; signY >= -1; signY -= 2)
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

        public static PlayerSquishResult OnSquish(
            PlayerContacts contacts,
            SimulationStateMachine machine,
            PixelCollision collision, CollisionPlatform pusher,
            Func<PlayerDeathRequest, bool> tryDie)
        {
            if (pusher == null) throw new ArgumentNullException(nameof(pusher));
            var actor = contacts.Body;
            var data = contacts.State;
            var ducked = false;
            if (!data.Motion.Ducking && machine.State != 1)
            {
                ducked = true;
                data.Motion.Ducking = true;
                contacts.SyncCollider();
                pusher.Collidable = true;
                if (!actor.World.SolidAt(actor.BoundsAt(actor.Position)))
                {
                    pusher.Collidable = false;
                    return PlayerSquishResult.Ducked;
                }

                var position = actor.Position;
                actor.Position = collision.TargetPosition;
                if (!actor.World.SolidAt(actor.BoundsAt(actor.Position)))
                {
                    pusher.Collidable = false;
                    return PlayerSquishResult
                        .DuckedAtTarget;
                }

                actor.Position = position;
                pusher.Collidable = false;
            }

            if (!TrySquishWiggle(actor, collision, pusher, 3, 5))
            {
                tryDie?.Invoke(
                    new(Vector2.Zero,
                        pusher.SquishEvenInAssistMode));
                return PlayerSquishResult.DeathRequested;
            }

            if (ducked && contacts.CanUnDuck)
            {
                data.Motion.Ducking = false;
                contacts.SyncCollider();
            }

            return PlayerSquishResult.Wiggled;
        }
    }
}
