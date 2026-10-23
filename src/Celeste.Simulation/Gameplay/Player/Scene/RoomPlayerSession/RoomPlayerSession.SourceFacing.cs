using Celeste.Simulation.Gameplay.Actors.Facing;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public FacingDirection SourceFacing
        {
            get => (FacingDirection)Data.Facing;
            set => Data.Facing = (int)value;
        }
    }
}
