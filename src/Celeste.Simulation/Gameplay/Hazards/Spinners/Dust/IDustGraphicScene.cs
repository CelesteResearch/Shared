using Celeste.Scene.Scheduling;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public interface IDustGraphicScene
    {
        DustEdgesPresentation DustEdges { get; }
        SceneClock Clock { get; }
        int DustAreaID { get; }
    }
}
