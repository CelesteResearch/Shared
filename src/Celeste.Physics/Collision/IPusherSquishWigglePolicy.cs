namespace Celeste.Physics.Collision
{
    public interface IPusherSquishWigglePolicy
    {
        bool TryHandleSquishWiggle(PixelActor actor, PixelCollision collision, int wiggleX, int wiggleY,
            out bool result);
    }
}
