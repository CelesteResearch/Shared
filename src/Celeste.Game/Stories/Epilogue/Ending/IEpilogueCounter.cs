using Celeste.Simulation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Stories.Epilogue.Ending
{
    public interface IEpilogueCounter
    {
        Vector2 Position { get; set; }
        void Update(float dt, float raw);
        void Render(Vector2 entityPosition);
    }
}
