using System;
using Celeste.Everest.Modules.Runtime;
using Celeste.Simulation;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.Events.Session
{
    public static class EverestSessionEvents
    {
        public static event
            Action<ChapterCompletionSession,
                ChapterCompletionSession.Slider, float?> OnSliderChanged
            {
                add
                {
                    SimulationSessionHooks.SliderChanged += value;
                    EverestModuleLifetime.Track(() =>
                        SimulationSessionHooks.SliderChanged -= value);
                }
                remove => SimulationSessionHooks.SliderChanged -= value;
            }
    }
}
