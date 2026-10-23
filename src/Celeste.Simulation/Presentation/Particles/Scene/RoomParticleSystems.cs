namespace Celeste.Simulation.Presentation.Particles.Scene
{
    public sealed class RoomParticleSystems
    {
        public ParticleSystemPresentation Particles { get; }
        public ParticleSystemPresentation Background { get; private set; }
        public ParticleSystemPresentation Foreground { get; private set; }

        public RoomParticleSystems(ParticleSystemPresentation particles)
        {
            Particles = particles;
        }

        public void PublishBackground(ParticleSystemPresentation background)
        {
            Background = background;
        }

        public void PublishForeground(ParticleSystemPresentation foreground)
        {
            Foreground = foreground;
        }
    }
}
