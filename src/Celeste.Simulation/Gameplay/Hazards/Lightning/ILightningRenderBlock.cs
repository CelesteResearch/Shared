using System.Numerics;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningRenderBlock
    {
        Vector2 Position { get; }
        float X { get; }
        float Y { get; }
        float Right { get; }
        float Bottom { get; }
        int VisualWidth { get; }
        int VisualHeight { get; }
        bool Visible { get; }
    }
}
