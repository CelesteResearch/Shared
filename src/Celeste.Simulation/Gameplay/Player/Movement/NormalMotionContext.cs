using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public struct NormalMotionContext
    {
        public int MoveX, MoveY, GliderMoveY;
        public bool OnGround, Ducking, JumpHeld, AutoJump;
        public bool Cold, InSpace, LowFriction;
        public bool HoldingSlowRun, HoldingSlowFall, WindMovedUp;
        public float LowFrictionStopTimer, ForceMoveXTimer;
        public bool WallSliding;
        public float WallSlideTimer;
    }
}
