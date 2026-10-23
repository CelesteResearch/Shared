using System.Numerics;
using Celeste.Game.Entities.Decoration.Resort;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalResortFixtureEnvironment
    {
        void IOriginalResortFixtureEnvironment.PlaySound(string eventName, Vector2 position)
        {
            AudioSession.Play(eventName, position, SaveContext);
        }
    }
}
