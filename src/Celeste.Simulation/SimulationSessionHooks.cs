using System;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Simulation
{
    // Optional module instrumentation for Session.SetFlag. No game/tool module is required.
    public static class SimulationSessionHooks
    {
        public static
            Action<ChapterCompletionSession,
                ChapterCompletionSession.Slider, float?> SliderChanged;
    }
}
