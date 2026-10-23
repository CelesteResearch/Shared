using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        protected override void OnSquish(PixelCollision data)
        {
            bool flag = false;
            if (!Data.Motion.Ducking && Machine.State != 1)
            {
                flag = true;
                Data.Motion.Ducking = true;
                var pusher = (ISourceMutableEntityState)data.Pusher;
                pusher.Collidable = true;
                if (!Body.CollideSolidAt(Position))
                {
                    pusher.Collidable = false;
                    return;
                }

                Vector2 position = Position;
                Position = data.TargetPosition;
                if (!Body.CollideSolidAt(Position))
                {
                    pusher.Collidable = false;
                    return;
                }

                Position = position;
                pusher.Collidable = false;
            }

            if (!SourceActorSquish.TryWiggle(Body, data, 3, 5))
            {
                bool evenIfInvincible = false;
                if (data.Pusher != null && ((SourceSolidEntityState)data.Pusher).SquishEvenInAssistMode)
                    evenIfInvincible = true;
                Die(Vector2.Zero, evenIfInvincible);
            }
            else if (flag && World.Contacts.CanUnDuck)
                Data.Motion.Ducking = false;
        }
    }
}
