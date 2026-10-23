using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public static class CarryableActorMotion
    {
        public static void AdvanceSpeed(SourceActorEntityState actor, ISourceEngineContext engine,
            HoldableState hold, ref Vector2 speed, ref Vector2 previousLiftSpeed, ref float gravityDelay)
        {
            if (actor.OnGround())
                CarryableActorMotionSteps.AdvanceGroundSpeed(actor, engine, ref speed, ref previousLiftSpeed,
                    ref gravityDelay);
            else if (hold.ShouldHaveGravity)
                CarryableActorMotionSteps.AdvanceAirSpeed(engine, ref speed, ref gravityDelay);
        }
    }
}
