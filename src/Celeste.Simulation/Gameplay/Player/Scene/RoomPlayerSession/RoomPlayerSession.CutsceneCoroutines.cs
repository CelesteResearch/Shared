using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Scheduling;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public IEnumerable<SimulationCoroutine> CutsceneCoroutines
        {
            get
            {
                foreach (var entry in Components)
                    if (entry is SimulationCoroutine routine)
                        yield return routine;
            }
        }

        public SimulationCoroutine AddCutsceneCoroutine(IEnumerator routine)
        {
            var coroutine = new SimulationCoroutine(EngineContext, routine);
            Components.Add(coroutine);
            return coroutine;
        }
    }
}
