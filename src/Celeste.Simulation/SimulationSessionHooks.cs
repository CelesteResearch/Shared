using System;

namespace Celeste.Simulation
{
    // Optional module instrumentation for Session.SetFlag. No game/tool module is required.
    public static class SimulationSessionHooks
    {
        public static
            Action<global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession,
                global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession.Slider, float?> SliderChanged;
    }
}
