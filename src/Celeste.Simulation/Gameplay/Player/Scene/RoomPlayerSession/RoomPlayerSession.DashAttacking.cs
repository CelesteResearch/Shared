// ReSharper disable once CheckNamespace

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool DashAttacking
        {
            get
            {
                if (!(Data.Motion.DashAttackTimer > 0f))
                    return Machine.State == 5;
                return true;
            }
        }
    }
}
