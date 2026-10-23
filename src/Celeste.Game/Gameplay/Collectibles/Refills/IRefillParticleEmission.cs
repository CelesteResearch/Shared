using System.Numerics;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public interface IRefillParticleEmission
    {
        void Emit(ParticleSystemPresentation particles, ParticleTypePresentation type, int amount,
            Vector2 position, Vector2 range);

        void Emit(ParticleSystemPresentation particles, ParticleTypePresentation type, int amount,
            Vector2 position, Vector2 range, float direction);
    }
}
