namespace Celeste.Simulation.Presentation.Particles.Definitions
{
    public interface ISourceParticleTypeConstruction
    {
        ParticleTypePresentation Create();
        ParticleTypePresentation Clone(ParticleTypePresentation source);
    }
}
