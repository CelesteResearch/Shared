namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningRemovalRenderer
    {
        float Fade { get; set; }
        bool UpdateSeeds { get; set; }
        void StopAmbience();
    }
}
