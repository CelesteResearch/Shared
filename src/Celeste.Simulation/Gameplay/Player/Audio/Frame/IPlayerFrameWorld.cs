using System;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Audio.Frame
{
    public interface IPlayerFrameWorld
    {
        Vector2 Position { get; }
        void FlushSpriteReset();
        void UpdateHiccups(float deltaTime);
        void UpdateIdleBookkeeping(float deltaTime);
        bool OnInterval(float interval);
        void ToggleFlash();
        bool InCutscene { get; }
        bool NoRefills { get; }

        int InventoryDashes { get; }

        // Solid first, then a jump-through not already intersecting the player.
        bool GroundAtOnePixel(out bool safe);

        bool SafeGroundBlocked();

        // Excludes NegaBlock, but includes jump-throughs outside the current bounds.
        bool RefillGroundAtOnePixel();
        bool TouchingSpikes();
        bool SolidAt(Vector2 offset);
        void MoveHExact(int amount);
        void MoveVExact(int amount);
        void ResetSweat();
        void SpeedRing();
    }
}
