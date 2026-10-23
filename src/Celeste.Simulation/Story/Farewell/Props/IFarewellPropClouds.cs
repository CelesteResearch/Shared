using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Farewell.Props
{
    // AscendManager.Clouds presentation contract (:113-180).
    public interface IFarewellPropClouds
    {
        float Alpha { get; set; }
        bool Active { get; set; }
        bool Visible { get; set; }
        void Added();
        void Removed();
        void Update(float deltaTime, float rawDeltaTime);
        IEnumerable<global::Celeste.Graphics.Display.ImagePlacement> Images(Vector2 cameraPosition);
    }
}
