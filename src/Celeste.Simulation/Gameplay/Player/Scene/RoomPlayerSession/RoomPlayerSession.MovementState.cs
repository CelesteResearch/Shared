using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public Vector2 Speed
        {
            get => Data.Motion.Normal.Speed;
            set => Data.Motion.Normal.Speed = value;
        }

        public void StartJumpGraceTime() => Data.Motion.JumpGraceTimer = .1f;
    }
}
