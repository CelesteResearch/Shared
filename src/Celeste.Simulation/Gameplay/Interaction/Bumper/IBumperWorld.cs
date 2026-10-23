using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

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

        void Emit(global::Celeste.Simulation.Gameplay.Interaction.Bumper.BumperParticle kind, int count,
            Vector2 position, Vector2 range, float direction);

        void DirectionalShake(Vector2 direction, float duration);
        void AddBurst(Vector2 position, float duration, float from, float to, float alpha);
    }
}
