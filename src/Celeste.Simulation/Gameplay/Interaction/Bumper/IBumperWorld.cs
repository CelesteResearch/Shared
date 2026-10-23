using System;
using System.Numerics;

namespace Celeste.Simulation.Gameplay.Interaction.Bumper
{
    public interface IBumperWorld
    {
        Random Random { get; }
        bool CoreHot { get; }
        bool Invincible { get; }
        int AreaId { get; }
        bool OnInterval(float interval);
        void PlaySound(string name, Vector2 position);

        void Emit(BumperParticle kind, int count,
            Vector2 position, Vector2 range, float direction);

        void DirectionalShake(Vector2 direction, float duration);
        void AddBurst(Vector2 position, float duration, float from, float to, float alpha);
    }
}
