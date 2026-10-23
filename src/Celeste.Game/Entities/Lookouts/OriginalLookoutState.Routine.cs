using System.Collections;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Lookouts
{
    public partial class OriginalLookoutState
    {
        private IEnumerator LookRoutine(RoomPlayerSession player)
        {
            return LookoutInteractionRoutine.Run(this, player);
        }
    }
}
