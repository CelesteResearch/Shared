using System.Numerics;

namespace Celeste.Physics.Collision
{
// Original Actor queries preserve its actual Collider shape and normal at-position checks.
    public interface ISourceActorCollisionWorld
    {
        PixelPlatform FirstSolidAt(PixelActor actor, Vector2 at);
        PixelPlatform FirstJumpThruAt(PixelActor actor, Vector2 at);
        PixelPlatform FirstJumpThruOutside(PixelActor actor, Vector2 at);
    }
}
