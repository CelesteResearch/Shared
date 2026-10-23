using Celeste.Simulation.Gameplay.Player.Scene.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Runtime
{
    public partial class GameApplication : ISourcePlayerDashParticleEnvironment
    {
        ParticleTypePresentation ISourcePlayerDashParticleEnvironment.DashA =>
            ParticleTypes.Player.P_DashA;

        ParticleTypePresentation ISourcePlayerDashParticleEnvironment.DashB =>
            ParticleTypes.Player.P_DashB;

        ParticleTypePresentation ISourcePlayerDashParticleEnvironment.DashBadB =>
            ParticleTypes.Player.P_DashBadB;
    }
}
