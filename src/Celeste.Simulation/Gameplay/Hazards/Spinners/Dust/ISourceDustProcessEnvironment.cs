namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public interface ISourceDustProcessEnvironment
    {
        SourceDustProcessState DustProcess { get; }
        bool Invincible { get; }
    }
}
