using System;
using System.Collections;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    // The host supplies live collision queries and the game's jump/effect handlers.
    // Callbacks can mutate player state, just like native DashListeners and Pickup.
    public interface IDashWorld
    {
        bool CanUnDuck { get; }
        bool InWater { get; }
        bool DreamDashIntoBlock { get; }
        bool PlayerOverTalk { get; }
        bool Chapter9BoosterBusy { get; }
        bool ParticleInterval { get; }
        bool TryPickup();
        void CorrectJumpThrus();
        bool WallJumpCheck(int direction);
        bool ClimbBlocked(int direction);
        void Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump kind, int direction);

        bool MatchingSwapBlockAhead(int direction);

        // One per unaffected axis; zero only when a colliding, swapping block matches its direction.
        Vector2 SwapCancel(Vector2 direction);
        void Freeze(float duration);
        void Emit(global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect effect);
    }
}
