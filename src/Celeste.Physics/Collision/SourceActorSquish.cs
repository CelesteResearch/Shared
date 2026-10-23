using System.Numerics;
using Celeste.Core.Components;

namespace Celeste.Physics.Collision
{
    public static class SourceActorSquish
    {
        public static bool TryWiggle(PixelActor body, PixelCollision data, int wiggleX = 3, int wiggleY = 3)
        {
            if (data.Pusher is IPusherSquishWigglePolicy policy &&
                policy.TryHandleSquishWiggle(body, data, wiggleX, wiggleY, out var result)) return result;
            var pusher = (ISourceMutableEntityState)data.Pusher;
            pusher.Collidable = true;
            for (var i = 0; i <= wiggleX; i++)
            for (var j = 0; j <= wiggleY; j++)
            {
                if (i == 0 && j == 0) continue;
                for (var signX = 1; signX >= -1; signX -= 2)
                for (var signY = 1; signY >= -1; signY -= 2)
                {
                    var offset = new Vector2(i * signX, j * signY);
                    if (!body.CollideSolidAt(body.Position + offset))
                    {
                        body.Position += offset;
                        pusher.Collidable = false;
                        return true;
                    }
                }
            }

            for (var i = 0; i <= wiggleX; i++)
            for (var j = 0; j <= wiggleY; j++)
            {
                if (i == 0 && j == 0) continue;
                for (var signX = 1; signX >= -1; signX -= 2)
                for (var signY = 1; signY >= -1; signY -= 2)
                {
                    var offset = new Vector2(i * signX, j * signY);
                    if (!body.CollideSolidAt(data.TargetPosition + offset))
                    {
                        body.Position = data.TargetPosition + offset;
                        pusher.Collidable = false;
                        return true;
                    }
                }
            }

            pusher.Collidable = false;
            return false;
        }
    }
}
