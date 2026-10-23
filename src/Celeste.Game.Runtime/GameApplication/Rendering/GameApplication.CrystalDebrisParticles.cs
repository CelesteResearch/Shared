using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ICrystalDebrisParticleEnvironment
    {
        ParticleTypePresentation ICrystalDebrisParticleEnvironment.Dust => ParticleTypes.CrystalDebris.P_Dust;
    }
}
