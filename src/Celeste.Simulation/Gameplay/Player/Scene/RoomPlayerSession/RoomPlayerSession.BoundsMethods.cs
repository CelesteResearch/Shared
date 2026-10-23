namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        // Original Player.cs2310 is intentionally empty.
        public void BeforeSideTransition()
        {
        }

        public void BeforeUpTransition()
        {
            if (!((global::Celeste.Simulation.Gameplay.Player.Runtime.ISourcePlayerRuntimeEnvironment)engineContext)
                    .PlayerRuntimePolicy.PreserveRedDashHorizontalSpeedBeforeUpTransition || Machine.State != 5)
                Data.Motion.Normal.Speed.X = 0f;
            if (Machine.State != 5 && Machine.State != 18 && Machine.State != 19)
            {
                Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y = -105f;
                if (Machine.State == 10) Machine.State = 13;
                else Machine.State = 0;
                Data.Motion.AutoJump = true;
                Data.AutoJumpTimer = 0f;
                Data.Motion.Normal.VariableJumpTimer = .2f;
            }

            Data.CooldownTimer = .2f;
        }

        public void OnBoundsH()
        {
            Data.Motion.Normal.Speed.X = 0f;
            if (Machine.State == 5) Machine.State = 0;
        }

        public void OnBoundsV()
        {
            Data.Motion.Normal.Speed.Y = 0f;
            if (Machine.State == 5) Machine.State = 0;
        }
    }
}
