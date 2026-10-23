using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Effects.Falling
{
    public interface IFallEffectsScene
    {
        global::Celeste.Simulation.Presentation.Effects.Falling.FallEffectsPresentation First { get; }
        global::Celeste.Simulation.Presentation.Effects.Falling.FallEffectsPresentation Create();
        void Add(global::Celeste.Simulation.Presentation.Effects.Falling.FallEffectsPresentation effects);
    }
}
