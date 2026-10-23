using System.Numerics;

namespace Celeste.Simulation
{
    public interface IRoomTransitionPlayer
    {
        Vector2 Position { get; set; }
        void CleanUpTriggers();
        bool TransitionTo(Vector2 target, Vector2 direction, float deltaTime);
        void OnTransition();
    }
}
