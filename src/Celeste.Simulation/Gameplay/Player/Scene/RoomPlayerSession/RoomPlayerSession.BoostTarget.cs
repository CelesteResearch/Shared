using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public Vector2 BoostTarget
        {
            get => boostSequence.BoostTarget;
            set => boostSequence.BoostTarget = value;
        }
    }
}
