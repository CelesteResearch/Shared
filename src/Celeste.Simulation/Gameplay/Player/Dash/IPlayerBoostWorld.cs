using System;
using System.Collections;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public interface IPlayerBoostWorld : global::Celeste.Simulation.Gameplay.Player.Dash.IDashWorld
    {
        bool RefillDash();
        void Drop();
        void SyncCollider();
        void RedDashDust(float direction, int count);
        void RedDashDisplacement();
        void RedDashCorrectJumpThrus();
    }
}
