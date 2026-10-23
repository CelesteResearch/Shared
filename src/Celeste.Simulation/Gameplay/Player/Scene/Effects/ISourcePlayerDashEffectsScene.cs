using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Scene.Effects
{
    public interface ISourcePlayerDashEffectsScene
    {
        void AddPlayerDashBurst(Vector2 center, float duration, float radiusFrom, float radiusTo, float alpha);
        void CreatePlayerDashSlash(Vector2 position, float direction);
        void EmitPlayerBirdDashParticle(Vector2 center, Vector2 range, float direction);
        void BurstPlayerDashDust(Vector2 position, float direction, int count);
    }
}
