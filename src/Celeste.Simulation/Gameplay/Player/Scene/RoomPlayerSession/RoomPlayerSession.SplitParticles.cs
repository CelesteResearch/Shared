using Celeste.Simulation.Gameplay.Player.Scene.Particles;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public void CreateSplitParticles()
            => ((ISourcePlayerSplitParticleScene)Level).CreateSplitParticles(this);
    }
}
