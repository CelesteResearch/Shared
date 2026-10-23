using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Simulation.Gameplay.Player.Scene.Particles
{
    public interface ISourcePlayerDashParticleScene
    {
        void EmitPlayerDashParticle(ParticleTypePresentation type, RoomPlayerSession actualPlayer);
    }
}
