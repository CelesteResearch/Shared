namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public interface IPlatformTargetMotionPolicy
    {
        float GetMovement(float target, float position, float remainder);
    }
}
