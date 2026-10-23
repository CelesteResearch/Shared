using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries.Points
{
    public interface IOriginalStrawberryPointsScene : IOriginalStrawberryScene
    {
        bool Frozen { get; }
        ISourceCameraBounds Camera { get; }

        DisplacementBurst AddStrawberryPointsBurst(Vector2 position, float duration,
            float radiusFrom, float radiusTo, float alpha);
    }
}
