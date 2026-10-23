using System;
using System.Numerics;
using Celeste.Core.Components;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public class DashListenerState : SourceComponentState
    {
        public Action<Vector2> OnDash;
        public Action OnSet;

        public DashListenerState() : base(false, false)
        {
        }
    }
}
