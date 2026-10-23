using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    // Everything the command table can read in one shot. Kept as one snapshot member so the seam
    // stays small; the Unity host fills it from its own state, a probe from whatever it drives.
    public struct DebugConsoleSnapshot
    {
        public bool InLevel, DebugMode;
        public string Map, Room, RoomName;
        public int AreaId, AreaMode;
        public float PlayerX, PlayerY, PlayerSpeedX, PlayerSpeedY;
        public float CameraX, CameraY, Zoom, ScreenPadding;
        public float TimeRate, Stamina;
        public int Dashes, MaxDashes, EntityCount, PendingEntityCount, Deaths;
        public bool Invincible, DreamDash, NoRefills;
        public long SceneFrame;
        public string[] Rooms, EntityCounts, SessionFlags, SaveFlags, LevelFlags;
    }
}
