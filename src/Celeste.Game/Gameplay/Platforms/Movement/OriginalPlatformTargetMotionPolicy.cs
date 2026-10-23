using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.Movement
{
    public sealed class OriginalPlatformTargetMotionPolicy : IPlatformTargetMotionPolicy
    {
        public float GetMovement(float target, float position, float remainder)
        {
            return target - (position + remainder);
        }
    }
}
