using Celeste.Simulation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Stories.Epilogue.Ending
{
    public interface IEpilogueEndingPlayer
    {
        Vector2 Position { get; set; }
        Vector2 Center { get; }
        Vector2 Speed { get; set; }
        int State { get; set; }
        int Facing { get; set; }
        int Dashes { get; set; }
        IEnumerator DummyWalkToExact(int target);
    }
}
