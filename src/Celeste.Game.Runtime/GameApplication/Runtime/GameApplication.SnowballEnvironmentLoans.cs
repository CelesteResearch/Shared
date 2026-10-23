using System.Numerics;
using Celeste.Game.Entities.Hazards.Snowballs;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSnowballEnvironment
    {
        void IOriginalSnowballEnvironment.PlaySound(string eventName, Vector2 position)
            => AudioSession.Play(eventName, position, SaveContext);

        void IOriginalSnowballEnvironment.Freeze(float time)
            => global::Celeste.Game.Execution.Engine.Actions.OriginalCelesteFreeze.Freeze(this, time);
    }
}
