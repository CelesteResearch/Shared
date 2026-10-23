using System.Numerics;
using Celeste.Core.Mathematics;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles
{
    public static class FinalBossBeamParticles
    {
        public static void Emit<TState>(TState state, Vector2 center, Vector2 along, Vector2 perpendicular,
            float backwardDistance = 0)
            where TState : struct, IFinalBossBeamParticleState
        {
            var min = -perpendicular * 1;
            var max = perpendicular * 1;
            float a = Vector2Geometry.Angle(perpendicular), b = Vector2Geometry.Angle(-perpendicular);

            Vector2 Jitter()
            {
                var random = state.Random;
                return new(min.X + (float)random.NextDouble() * (max.X - min.X),
                    min.Y + (float)random.NextDouble() * (max.Y - min.Y));
            }

            for (var i = 0; i < 200; i += 12)
            for (var j = -1; j <= 1; j += 2)
            {
                state.ParticleSystem.Emit(state.ParticleType, center + along * i + perpendicular * 2 * j + Jitter(), a);
                state.ParticleSystem.Emit(state.ParticleType, center + along * i - perpendicular * 2 * j + Jitter(), b);
                if (i != 0 && i < backwardDistance)
                {
                    state.ParticleSystem.Emit(state.ParticleType, center - along * i + perpendicular * 2 * j + Jitter(),
                        a);
                    state.ParticleSystem.Emit(state.ParticleType, center - along * i - perpendicular * 2 * j + Jitter(),
                        b);
                }
            }
        }
    }
}
