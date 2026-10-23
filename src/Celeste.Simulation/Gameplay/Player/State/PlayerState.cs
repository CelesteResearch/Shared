using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.State
{
    public sealed class PlayerState
    {
        // Player.cs:509 `private float wallSlideTimer = 1.2f;` - the only non-zero initialiser in that block
        // of the original's Player fields, which is why it is easy to drop: a fresh player must start with
        // 1.2f, and `PlayerNormalState.cs:125` / `PlayerFrameMotion.cs:88` then gate on `WallSlideTimer > 0f`
        // / `> .6f`. Starting at 0 makes the first airborne frames fall instead of wall-sliding (20 px/s vs
        // up to 160). Every other assignment to this field in the port is one of the original's explicit
        // ones: DashSequence.cs:70, EntityInteractions.cs:44, PlayerClimbState.cs:42,
        // PlayerCollisionResponse.cs:208/:216, PlayerFrameMotion.cs:99, PlayerTransition.cs:39.
        public global::Celeste.Simulation.Gameplay.Player.State.PlayerMotionState Motion =
            new global::Celeste.Simulation.Gameplay.Player.State.PlayerMotionState { WallSlideTimer = 1.2f };

        public Vector2 BeforeDashSpeed, Direction, LastAim;
        public Vector2? OverrideDirection;
        public int Dashes = 1, Facing = 1, TrailCounter;
        public float CooldownTimer, RefillCooldownTimer, TrailTimer, AutoJumpTimer, Stamina = 110f;
        public bool OnGround, StartedDashing, StartedOnGround, WasDashB, DemoDashed, CalledEvents, CanCurve;
        private global::Celeste.Simulation.Gameplay.Holdables.PlayerHoldingController holdingOwner;

        private bool standaloneHolding;

        // Offline motion instances have no source entity; actual Player binds once during construction.
        public bool Holding
        {
            get => holdingOwner == null ? standaloneHolding : holdingOwner.Holding != null;
            set => standaloneHolding = value;
        }

        internal void BindActualHolding(global::Celeste.Simulation.Gameplay.Holdables.PlayerHoldingController owner)
        {
            if (holdingOwner != null) throw new System.InvalidOperationException("Holding owner is already bound.");
            holdingOwner = owner ?? throw new System.ArgumentNullException(nameof(owner));
        }

        public bool WasOnGround, WindMovedUp, DreamJump;
        public int MoveX, WallSlideDirection, ClimbTriggerDirection, HopWaitX, WallBoostDirection;
        public float MinHoldTimer, WallSpeedRetentionTimer;
        public float ClimbNoMoveTimer, HopWaitXSpeed, FootstepOnLandTimer, NoWindTimer;
        public int LastClimbMove;
        public bool WallBoosting, FastJump;
        public global::Celeste.Simulation.Gameplay.Platforms.Movement.IMovingSolid ClimbHopSolid;
        public Vector2 ClimbHopSolidPosition;
        public Vector2 PreviousPosition;
        public float WallSpeedRetained, ExplodeLaunchBoostTimer, ExplodeLaunchBoostSpeed, HighestAirY, LaunchedTimer;

        public bool OnSafeGround;

        // Original Player's previous visual/rumble observations. They are updated
        // at their original Player.Update sites, independently of current state.
        public bool WasDucking, WasTired;
        public float StarFlyTimer;
        public bool MuffleLanding;
        public bool DashAttacking(int state) => Motion.DashAttackTimer > 0f || state == 5;
        public bool IsTired => (Motion.WallBoostTimer > 0f ? Stamina + 27.5f : Stamina) < 20f;
        public bool SuperWallJumpAngle => System.Math.Abs(Direction.X) <= .2f && Direction.Y <= -.75f;
    }
}
