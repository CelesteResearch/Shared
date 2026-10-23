using System;
using Celeste.Simulation;
using Celeste.Everest;

namespace Celeste.Everest.Runtime.Events.Session
{
    public static class EverestSessionEvents
    {
        public static event
            Action<global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession,
                global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession.Slider, float?> OnSliderChanged
            {
                add
                {
                    SimulationSessionHooks.SliderChanged += value;
                    global::Celeste.Everest.Modules.Runtime.EverestModuleLifetime.Track(() =>
                        SimulationSessionHooks.SliderChanged -= value);
                }
                remove { SimulationSessionHooks.SliderChanged -= value; }
            }
    }
}
