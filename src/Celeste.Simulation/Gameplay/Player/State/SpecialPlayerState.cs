using System;
using System.Collections;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.State
{
    public sealed class SpecialPlayerState
    {
        public float HitSquashNoMoveTimer;
        public float? LaunchApproachX;
    }
}
