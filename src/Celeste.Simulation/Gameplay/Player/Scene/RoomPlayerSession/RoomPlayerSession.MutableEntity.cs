using Celeste.Core.Components;
using Celeste.Simulation.Gameplay.Collision.Blockers;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourceMutableEntityState,
        ISourceMutableEntityPosition,
        ILedgeBlockerPlayer
    {
        public int Facing => Data.Facing;

        bool ISourceMutableEntityState.Active
        {
            get => Active;
            set => Active = value;
        }

        bool ISourceMutableEntityState.Visible
        {
            get => Visible;
            set => Visible = value;
        }
    }
}
