using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Responses
{
    public interface IPlayerCollisionWorld
    {
        Vector2 Position { get; }
        bool InventoryDreamDash { get; }
        bool SolidAt(Vector2 offset);
        bool DuckFreeAt(Vector2 offset);
        bool GroundAt(Vector2 offset);
        bool DashCorrectBlocked(Vector2 offset);
        global::Celeste.Simulation.Gameplay.Platforms.DreamBlock.ISourceDreamBlock FirstDreamBlockAt(Vector2 offset);
        bool SolidExceptDreamBlockAt(Vector2 offset);
        void MoveHExact(int amount);
        void MoveVExact(int amount);
        void NudgePosition(Vector2 amount);
        global::Celeste.Simulation.Gameplay.Platforms.Audio.SourceSurfaceSoundSelection LandingSurface();
        void PlayLanding(bool footstep, int surfaceIndex);
        void LandingDust(int surfaceIndex);
        void Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect effect);
    }
}
