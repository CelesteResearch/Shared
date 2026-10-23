using System.Collections;
using Celeste.Core.Gameplay.FlingBirds;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private ISourceFlingBird flingBird;

        private void BindFlingBird()
        {
            Machine.SetCallbacks(24, UpdateFlingBird, FlingBirdCoroutine, BeginFlingBird, EndFlingBird);
        }

        public bool DoFlingBird(ISourceFlingBird bird)
        {
            if (Dead || Machine.State == 24) return false;
            flingBird = bird;
            Machine.State = 24;
            if (Holding.Holding != null) Drop();
            return true;
        }

        public void FinishFlingBird()
        {
            Machine.State = 0;
            Data.Motion.AutoJump = true;
            Data.Motion.ForceMoveX = 1;
            Data.Motion.ForceMoveXTimer = .2f;
            Data.Motion.Normal.Speed = ((ISourceFlingBirdEnvironment)EngineContext).FlingBirdStatics.FlingSpeed;
            Data.Motion.Normal.VariableJumpTimer = .2f;
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
            Data.Motion.Launched = true;
        }

        private void BeginFlingBird()
        {
            RefillDash();
            RefillStamina();
        }

        private void EndFlingBird()
        {
        }

        private int UpdateFlingBird()
        {
            MoveTowardsX(flingBird.Position.X, 250f * EngineContext.DeltaTime);
            MoveTowardsY(flingBird.Position.Y + 8f + Collider.Height, 250f * EngineContext.DeltaTime);
            return 24;
        }

        private IEnumerator FlingBirdCoroutine()
        {
            yield break;
        }
    }
}
