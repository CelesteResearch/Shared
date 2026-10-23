using System.Numerics;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void TransitionTo(OriginalLevelRoomData next, Vector2 direction)
        {
            TransitionSequence.Start(next, direction);
        }
    }
}
