using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Clutter
{
    public interface IClutterAbsorbEffect
    {
        void FlyClutter(Vector2 position, global::Celeste.Graphics.Content.Atlas.AtlasEntry texture, bool shake,
            float delay);

        void CloseCabinets();
    }
}
