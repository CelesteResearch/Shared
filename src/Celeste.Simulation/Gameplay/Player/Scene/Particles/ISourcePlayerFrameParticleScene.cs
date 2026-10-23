using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Scene.Particles
{
    public interface ISourcePlayerFrameParticleScene
    {
        void BurstPlayerForegroundDust(Vector2 position, float direction, int count, float range);
    }
}
