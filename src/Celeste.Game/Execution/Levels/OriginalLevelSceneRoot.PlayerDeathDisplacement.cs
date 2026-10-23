using System.Numerics;
using Celeste.Simulation.Presentation.Player.Death;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerDeathDisplacementScene
    {
        void ISourcePlayerDeathDisplacementScene.AddPlayerDeathDisplacement(Vector2 position, float duration,
            float radiusFrom, float radiusTo)
            => Displacement.AddBurst(position, duration, radiusFrom, radiusTo);
    }
}
