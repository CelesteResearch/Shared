using Celeste.Simulation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Stories.Temple
{
    public interface ITempleTheoMirrorPlayer : INpcPlayer
    {
        float X { get; set; }
        Vector2 Speed { get; set; }
        IEnumerator DummyWalkTo(float x);
        void MoveV(float amount);
    }
}
