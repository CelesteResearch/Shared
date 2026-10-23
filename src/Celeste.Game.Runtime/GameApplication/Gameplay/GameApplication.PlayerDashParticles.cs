using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Runtime
{
    public partial class GameApplication : ISourcePlayerDashParticleEnvironment
    {
        ParticleTypePresentation ISourcePlayerDashParticleEnvironment.DashA =>
            ((IOriginalGameplayProcess)this).ParticleTypes.Player.P_DashA;

        ParticleTypePresentation ISourcePlayerDashParticleEnvironment.DashB =>
            ((IOriginalGameplayProcess)this).ParticleTypes.Player.P_DashB;

        ParticleTypePresentation ISourcePlayerDashParticleEnvironment.DashBadB =>
            ((IOriginalGameplayProcess)this).ParticleTypes.Player.P_DashBadB;
    }
}
