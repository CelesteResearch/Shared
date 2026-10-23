using Celeste.Simulation.Gameplay.Player.Runtime;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        // Player.cs:1362's predicate. `Data.OnGround` is this port's `onGround`
        // (PlayerFrameMotion.cs:70-75), `Machine.State` is `StateMachine.State`.
        public bool InvisibleMotionActive => Settings.InvisibleMotion
                                             && PlayerFrameMotion
                                                 .InControl(Machine.State)
                                             && ((!Data.OnGround && Machine.State != 1 && Machine.State != 3)
                                                 || Data.Motion.Normal.Speed.LengthSquared() > 800f);
    }
}
