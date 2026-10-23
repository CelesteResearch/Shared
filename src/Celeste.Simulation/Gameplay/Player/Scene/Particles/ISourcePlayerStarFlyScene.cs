using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Scene.Particles
{
    public interface ISourcePlayerStarFlyScene
    {
        void EmitStarFlyParticles(bool boost, int count, Vector2 position, Vector2 range, float direction);
        void AddStarFlyBurst(Vector2 position);
    }
}
