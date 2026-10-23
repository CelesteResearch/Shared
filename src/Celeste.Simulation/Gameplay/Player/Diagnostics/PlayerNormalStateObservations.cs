using System;

namespace Celeste.Simulation.Gameplay.Player.Diagnostics
{
    // =====================================================================================
    // DIAGNOSTIC SEAM — NOT SHIPPING BEHAVIOUR. Read the whole comment before using it.
    //
    // WHY THIS EXISTS. A TAS flow test (Artifacts/TasFlow/FINDING.md §FF) found the port and the
    // real game running a 1A route identically for 8 frames and then disagreeing at exactly one
    // frame: the original's horizontal velocity flips sign (-119.17) and the port's does not (+211).
    // The port never turns around, and from that frame the routes diverge. Position traces and
    // velocity traces can show THAT a reversal did not happen; neither can show WHY, because the
    // decision is taken inside the normal-state update from inputs and collision queries that no
    // recorded channel carries. This seam exposes exactly that decision and nothing else.
    //
    // HOUSE PATTERN, deliberately. This is the same shape as `RoomPresentation.PacemakerBudget` /
    // `PacemakerTick` (Assets/Runtime/RoomPresentation.cs:569-570) — a static delegate that is null
    // in shipping, written only by a host that wants the data, and invoked only when non-null. It is
    // NOT a log statement and NOT an `#if`. It carries no state, allocates nothing, and cannot
    // change a decision: the observer is called after the values are computed and its result is
    // never read.
    //
    // COST WHEN UNSET. The update path builds one value-type snapshot and makes one null test per
    // observed decision. No allocation, no virtual call, no branch that affects control flow. With
    // `NormalStateObserved == null` the shipping behaviour is bit-identical — the same claim
    // `PacemakerBudget` makes, and it is verified the same way (the reference gates re-run clean).
    //
    // NARROW BY DESIGN. It reports the direction-change decision — the wall-jump probe that decides
    // whether the player turns around — and the handful of inputs that decision reads. It is not
    // general instrumentation of the collision system and should not grow into one.
    //
    // A LATER READER: if you are looking at this during a performance or correctness review and
    // wondering whether it ships, it does — as a null field. Delete it if the `1A` reversal defect
    // is closed and no further differential needs it.
    // =====================================================================================
    public static class PlayerNormalStateObservations
    {
        // One observation of the direction-change decision. Scalars only, deliberately: the live
        // `PlayerState` is mutated in place, so a snapshot that held references would report whatever
        // the state looks like when the observer reads it rather than what the decision saw.
        public readonly struct ReversalDecision
        {
            public readonly int MoveX, Facing, DashCount;
            public readonly float SpeedX, SpeedY, WallSlideTimer, JumpGraceTimer;

            public readonly bool GrabCheck, CanUnDuck;

            // Which side the wall-jump probe found a wall on, and the same probe's two raw answers,
            // so an observer can tell "no wall" from "probe declined".
            public readonly int Wall, WallRight, WallLeft;
            public readonly bool JumpPressed, TurnedAround;

            public ReversalDecision(int moveX, int facing, int dashCount, float speedX, float speedY,
                float wallSlideTimer, float jumpGraceTimer, bool grabCheck, bool canUnDuck,
                int wall, int wallRight, int wallLeft, bool jumpPressed, bool turnedAround)
            {
                MoveX = moveX;
                Facing = facing;
                DashCount = dashCount;
                SpeedX = speedX;
                SpeedY = speedY;
                WallSlideTimer = wallSlideTimer;
                JumpGraceTimer = jumpGraceTimer;
                GrabCheck = grabCheck;
                CanUnDuck = canUnDuck;
                Wall = wall;
                WallRight = wallRight;
                WallLeft = wallLeft;
                JumpPressed = jumpPressed;
                TurnedAround = turnedAround;
            }
        }

        // Null in shipping. A host that wants the observations assigns it; nothing else reads it.
        public static Action<ReversalDecision> NormalStateObserved;

        internal static void Observed(in ReversalDecision decision)
        {
            NormalStateObserved?.Invoke(decision);
        }

        // ---- the dash path, which is where the actual `1A` reversal turned out to live ----------
        //
        // The reversal seam above fires only where a JUMP is pressed, and when it was run over the
        // real route it reported nothing at the frames where the port and the original disagree
        // (Artifacts/TasFlow/FINDING.md §FF: the original's horizontal velocity flips sign at
        // `id=165`, the port's does not). That ruled out a wall jump and pointed at the dash.
        //
        // This observation records the dash direction the port actually resolved and the speed it
        // then set, which is the decision that differs.
        public readonly struct DashDecision
        {
            public readonly float MoveX, MoveY, AimX, AimY, SpeedBeforeX, SpeedBeforeY, SpeedAfterX, SpeedAfterY;
            public readonly int DashCount, Facing;
            public readonly bool DashPressed, OnGround, DuckingOrDown;

            public DashDecision(float moveX, float moveY, float aimX, float aimY,
                float speedBeforeX, float speedBeforeY, float speedAfterX, float speedAfterY,
                int dashCount, int facing, bool dashPressed, bool onGround, bool duckingOrDown)
            {
                MoveX = moveX;
                MoveY = moveY;
                AimX = aimX;
                AimY = aimY;
                SpeedBeforeX = speedBeforeX;
                SpeedBeforeY = speedBeforeY;
                SpeedAfterX = speedAfterX;
                SpeedAfterY = speedAfterY;
                DashCount = dashCount;
                Facing = facing;
                DashPressed = dashPressed;
                OnGround = onGround;
                DuckingOrDown = duckingOrDown;
            }
        }

        public static Action<DashDecision> DashObserved;

        internal static void Observed(in DashDecision decision)
        {
            DashObserved?.Invoke(decision);
        }

        // ---- the wall-slide CONTACT decision, which is the one that actually gates the `1A` route ---
        //
        // The reversal seam above observes the WALL-JUMP check, which uses `reach = 3`
        // (`PlayerContacts.cs:211`). The wall-slide branch does NOT: it tests
        // `world.SolidAt(Vector2.UnitX * data.Facing)` — **reach = 1** — at `PlayerNormalState.cs:120`,
        // and `world.ClimbEdgeBlocked(Facing)` likewise takes offset 1. Conflating the two reach
        // values is what made an earlier map query answer the wrong question, so each conjunct of THIS
        // condition is reported separately.
        //
        // Reported after the values are computed and never read back.
        public readonly struct WallSlideContact
        {
            public readonly bool OnGround, MovingIntoWall, MoveYNotDown;
            public readonly bool SpeedYNonNegative, WallSlideTimerPositive, NotHolding;
            public readonly bool ClimbBoundsOk, SolidAtReach1, NotEdgeBlocked, CanUnDuck;
            public readonly float SpeedY, WallSlideTimer;
            public readonly int MoveX, Facing, WallSlideDirection;

            public readonly bool GrabCheck, WallSlideEntered;

            // The variable-jump clamp's own state. Added because the `1A` divergence is a vertical-only
            // one-gravity-tick-per-frame drift in which the reference holds `Speed.Y` at exactly
            // `varJumpSpeed` (-105) and the port does not. These three together name WHICH defect it is
            // without a behaviour change: timer 0 means the timer is not armed or refreshed (upstream of
            // the clamp); timer > 0 while pre-gravity Speed.Y still climbs means the clamp is not applied
            // despite a live timer (at the application site); JumpHeld false while the file holds jump
            // means input propagation, which a synthetic differential cannot see because it sets the
            // flag as data.
            public readonly float VariableJumpTimer, VariableJumpSpeed;
            public readonly bool JumpHeld;

            public WallSlideContact(bool onGround, bool movingIntoWall, bool moveYNotDown,
                bool speedYNonNegative, bool wallSlideTimerPositive, bool notHolding,
                bool climbBoundsOk, bool solidAtReach1, bool notEdgeBlocked, bool canUnDuck,
                float speedY, float wallSlideTimer, int moveX, int facing, int wallSlideDirection,
                bool grabCheck, bool wallSlideEntered,
                float variableJumpTimer, float variableJumpSpeed, bool jumpHeld)
            {
                OnGround = onGround;
                MovingIntoWall = movingIntoWall;
                MoveYNotDown = moveYNotDown;
                SpeedYNonNegative = speedYNonNegative;
                WallSlideTimerPositive = wallSlideTimerPositive;
                NotHolding = notHolding;
                ClimbBoundsOk = climbBoundsOk;
                SolidAtReach1 = solidAtReach1;
                NotEdgeBlocked = notEdgeBlocked;
                CanUnDuck = canUnDuck;
                SpeedY = speedY;
                WallSlideTimer = wallSlideTimer;
                MoveX = moveX;
                Facing = facing;
                WallSlideDirection = wallSlideDirection;
                GrabCheck = grabCheck;
                WallSlideEntered = wallSlideEntered;
                VariableJumpTimer = variableJumpTimer;
                VariableJumpSpeed = variableJumpSpeed;
                JumpHeld = jumpHeld;
            }
        }

        public static Action<WallSlideContact> WallSlideContactObserved;

        internal static void Observed(in WallSlideContact decision)
        {
            WallSlideContactObserved?.Invoke(decision);
        }

        // ---- the WALL-JUMP CONTACT decision, evaluated EVERY FRAME ------------------------------
        //
        // WHY THIS ONE. `Wall-R` / `Wall-L` in the reference's own HUD are literally
        // `player.WallJumpCheck(1)` / `WallJumpCheck(-1)` — see
        // Artifacts/Reference/CelesteTAS/CelesteTAS-EverestInterop/Source/TAS/GameInfo.cs:277-278 —
        // and the HUD evaluates them once per frame. The port calls `WallJumpCheck` only inside the
        // jump-press branch (`PlayerNormalState.cs:155-162`), so on frames with no jump press it never
        // asks the question at all. This observation asks it unconditionally, so a differential can
        // separate "the predicate disagrees" from "the port never evaluated it".
        //
        // Reach is 3, NOT the 1 the wall-slide test uses — conflating the two is what made an earlier
        // investigation measure the wrong predicate entirely.
        //
        // Pure reads only: `ClimbBoundsCheck`, `ClimbEdgeBlocked` and `SolidAt` query the collision
        // world and mutate nothing. Reported after the values are computed and never read back.
        public readonly struct WallJumpContact
        {
            public readonly int Facing;
            public readonly bool ClimbBoundsOk, NotEdgeBlocked, SolidAtReach3;
            public readonly bool ClimbBoundsOkL, NotEdgeBlockedL, SolidAtReach3L;
            public readonly float SpeedX, SpeedY;
            public readonly int MoveX;
            public readonly bool OnGround, JumpPressed;

            public WallJumpContact(int facing, bool climbBoundsOk, bool notEdgeBlocked, bool solidAtReach3,
                bool climbBoundsOkL, bool notEdgeBlockedL, bool solidAtReach3L,
                float speedX, float speedY, int moveX, bool onGround, bool jumpPressed)
            {
                Facing = facing;
                ClimbBoundsOk = climbBoundsOk;
                NotEdgeBlocked = notEdgeBlocked;
                SolidAtReach3 = solidAtReach3;
                ClimbBoundsOkL = climbBoundsOkL;
                NotEdgeBlockedL = notEdgeBlockedL;
                SolidAtReach3L = solidAtReach3L;
                SpeedX = speedX;
                SpeedY = speedY;
                MoveX = moveX;
                OnGround = onGround;
                JumpPressed = jumpPressed;
            }

            // The three-part test the reference's HUD evaluates, for the right-hand direction.
            public bool WallRight => ClimbBoundsOk && NotEdgeBlocked && SolidAtReach3;
        }

        public static Action<WallJumpContact> WallJumpContactObserved;

        internal static void Observed(in WallJumpContact decision)
        {
            WallJumpContactObserved?.Invoke(decision);
        }
    }
}
