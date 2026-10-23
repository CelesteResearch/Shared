using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.Movement
{
    public sealed class EverestPlatformTargetMotionPolicy : IPlatformTargetMotionPolicy
    {
        public float GetMovement(float target, float position, float remainder)
        {
            return (float)((double)target - position - remainder);
        }
    }
}
