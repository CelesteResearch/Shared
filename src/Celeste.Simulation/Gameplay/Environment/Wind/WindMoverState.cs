using System;
using System.Numerics;

namespace Celeste.Simulation.Gameplay.Environment.Wind
{
    // Actual Celeste.WindMover component, inactive and invisible from its constructor.
    public sealed class WindMoverState : global::Celeste.Core.Components.SourceComponentState
    {
        public Action<Vector2> Move;

        public WindMoverState(Action<Vector2> move) : base(false, false)
        {
            Move = move;
        }
    }
}
