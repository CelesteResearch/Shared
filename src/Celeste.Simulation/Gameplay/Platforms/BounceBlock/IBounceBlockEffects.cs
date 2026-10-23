using System.Numerics;

namespace Celeste.Simulation.Gameplay.Platforms.BounceBlock
{
    public interface IBounceBlockEffects
    {
        void Rumble(bool medium);
        void PlaySound(string path, Vector2 position);
        void Emit(BounceBlockParticle kind, Vector2 position, float direction);
    }
}
