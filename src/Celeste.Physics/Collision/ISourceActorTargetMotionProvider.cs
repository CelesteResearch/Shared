namespace Celeste.Physics.Collision
{
    public interface ISourceActorTargetMotionProvider
    {
        float GetTargetMovement(float target, float position, float remainder);
    }
}
