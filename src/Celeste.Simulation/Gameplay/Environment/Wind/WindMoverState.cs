using System;
using System.Numerics;
using Celeste.Core.Components;

namespace Celeste.Simulation.Gameplay.Environment.Wind
{
    // Actual Celeste.WindMover component, inactive and invisible from its constructor.
    public sealed class WindMoverState : SourceComponentState
    {
        public Action<Vector2> Move;

        public WindMoverState(Action<Vector2> move) : base(false, false)
        {
            Move = move;
        }
    }
}
