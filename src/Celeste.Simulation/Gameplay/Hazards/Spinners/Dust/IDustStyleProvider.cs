namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public interface IDustStyleProvider
    {
        DustStylePresentation GetStyle(int areaId);
        bool ShouldRenderEyes { get; }
    }
}
