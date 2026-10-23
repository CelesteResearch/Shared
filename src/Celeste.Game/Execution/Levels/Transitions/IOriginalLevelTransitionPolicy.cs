using System.Collections;
using System.Numerics;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Execution.Levels.Transitions
{
    public interface IOriginalLevelTransitionPolicy
    {
        IEnumerator CreateRoutine(OriginalLevelTransitionSequence sequence, OriginalLevelRoomData next,
            Vector2 direction);

        void Start(OriginalLevelTransitionSequence sequence, OriginalLevelRoomData next, Vector2 direction);
    }
}
