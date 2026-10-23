using System.Numerics;
using Celeste.Core.Components;

namespace Celeste.Simulation.Gameplay.Interaction.Springs
{
    public interface ISourceSpringEntity : ISourceEntityPosition
    {
        SpringOrientation Orientation { get; }
        Vector2 Center { get; }
        float CenterY { get; }
    }
}
