using System;
using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Movement;

namespace Celeste.Simulation.Gameplay.Player.State
{
    public struct PlayerMotionState
    {
        public NormalMotionState Normal;
        public float JumpGraceTimer, DashAttackTimer, GliderBoostTimer, WallSlideTimer, WallBoostTimer;
        public float LowFrictionStopTimer, ForceMoveXTimer;
        public int ForceMoveX;
        public Vector2 GliderBoostDirection;
        public bool AutoJump, Launched;

        private bool ducking;

        // Celeste.Player.Ducking changes Actor.Collider in its setter, including when
        // OnCollideV toggles it during MoveV. Keep the collision shape synchronized at
        // the assignment itself; waiting for the next movement step shifts nearby
        // entity queries (such as SeekerEffectsController) by one frame.
        public Action DuckingChanged;
        public Func<bool> ReadActualDucking;
        public Action<bool> SetActualDucking;

        public bool Ducking
        {
            get => ReadActualDucking != null ? ReadActualDucking() : ducking;
            set
            {
                if (SetActualDucking != null)
                {
                    SetActualDucking(value);
                    return;
                }

                ducking = value;
                DuckingChanged?.Invoke();
            }
        }
    }
}
