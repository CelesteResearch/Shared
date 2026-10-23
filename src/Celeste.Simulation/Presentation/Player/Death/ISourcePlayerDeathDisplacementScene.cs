using System.Numerics;

namespace Celeste.Simulation.Presentation.Player.Death
{
    public interface ISourcePlayerDeathDisplacementScene
    {
        void AddPlayerDeathDisplacement(Vector2 position, float duration, float radiusFrom, float radiusTo);
    }
}
