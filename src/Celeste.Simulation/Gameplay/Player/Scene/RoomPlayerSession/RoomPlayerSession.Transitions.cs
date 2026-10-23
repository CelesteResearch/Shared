using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public void OnTransition()
        {
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.ForceMoveXTimer = 0f;
            ChaseHistory.States.Clear();
            World.RefillDash();
            RefillStamina();
            Leader.TransferFollowers();
        }

        public bool TransitionTo(Vector2 target, Vector2 direction)
        {
            MoveTowardsX(target.X, 60f * EngineContext.DeltaTime);
            MoveTowardsY(target.Y, 60f * EngineContext.DeltaTime);
            UpdateHair(false);
            Holding.UpdateCarry();
            if (Position == target)
            {
                ZeroRemainderX();
                ZeroRemainderY();
                Data.Motion.Normal.Speed.X = (int)Math.Round(Data.Motion.Normal.Speed.X);
                Data.Motion.Normal.Speed.Y = (int)Math.Round(Data.Motion.Normal.Speed.Y);
                return true;
            }

            return false;
        }
    }
}
