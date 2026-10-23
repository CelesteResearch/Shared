using System.Collections;
using System.Collections.Generic;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public IEnumerable<global::Celeste.Core.Scheduling.SimulationCoroutine> CutsceneCoroutines
        {
            get
            {
                foreach (var entry in Components)
                    if (entry is global::Celeste.Core.Scheduling.SimulationCoroutine routine)
                        yield return routine;
            }
        }

        public global::Celeste.Core.Scheduling.SimulationCoroutine AddCutsceneCoroutine(IEnumerator routine)
        {
            var coroutine = new global::Celeste.Core.Scheduling.SimulationCoroutine(engineContext, routine);
            Components.Add(coroutine);
            return coroutine;
        }
    }
}
