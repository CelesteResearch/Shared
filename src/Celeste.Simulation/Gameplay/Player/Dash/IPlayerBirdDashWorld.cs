using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public interface IPlayerBirdDashWorld
    {
        bool OnGround();
        bool SolidAt(Vector2 offset);
        float LevelBottom { get; }
        void PlaySprite(string animation);
        void PlaySound(string sound);
        void CreateTrail();
        void AddTrailAlarm(float delay);
        void DirectionalShake(Vector2 direction, float duration);

        void Slash(Vector2 position, float direction);

        // Sample center +/- range, then emit one P_DashA, preserving random order.
        void EmitDashParticle(Vector2 center, Vector2 range, float direction);
        bool OnInterval(float interval);
        void DustBurst(Vector2 position, float direction, int count);
        void CancelCutscene();
        void Die(Vector2 direction);
    }
}
