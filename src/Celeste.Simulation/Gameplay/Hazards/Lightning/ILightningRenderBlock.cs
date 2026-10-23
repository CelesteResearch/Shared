using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningRenderBlock
    {
        Vector2 Position { get; }
        float X { get; }
        float Y { get; }
        float Right { get; }
        float Bottom { get; }
        int VisualWidth { get; }
        int VisualHeight { get; }
        bool Visible { get; }
    }
}
