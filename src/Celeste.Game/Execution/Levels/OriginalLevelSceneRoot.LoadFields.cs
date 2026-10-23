using System.Numerics;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public PlayerIntroType LastIntroType;
        public bool TimerStopped;
        public bool PauseLock;
        public RoomCameraLockMode CameraLockMode;
        public Vector2 CameraOffset;
        public float CameraUpwardMaxY;
        public bool SaveQuitDisabled;
        public bool Raining;
        public bool DarkRoom;
        public bool NewLevel;
        public bool InSpace;
    }
}
