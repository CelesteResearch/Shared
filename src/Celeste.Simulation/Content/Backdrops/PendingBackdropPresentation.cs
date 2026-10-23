using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Content.Backdrops
{
    public sealed class
        PendingBackdropPresentation : global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation
    {
        public PendingBackdropPresentation(string name)
        {
            Name = name;
        }
    }
}
