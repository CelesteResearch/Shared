using System.Collections;
using System.Numerics;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Execution.Levels.Transitions
{
    public sealed class OriginalLevelTransitionPolicy : IOriginalLevelTransitionPolicy
    {
        public IEnumerator CreateRoutine(OriginalLevelTransitionSequence sequence, OriginalLevelRoomData next,
            Vector2 direction)
        {
            return sequence.CreateOriginalRoutine(next, direction);
        }

        public void Start(OriginalLevelTransitionSequence sequence, OriginalLevelRoomData next, Vector2 direction)
        {
            var level = sequence.Level;
            level.Session.CoreMode = level.CoreMode;
            sequence.AssignRoutine(sequence.CreateRoutine(next, direction));
        }
    }
}
