using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : global::Celeste.Core.Components.ISourceMutableEntityState,
        global::Celeste.Core.Components.ISourceMutableEntityPosition,
        global::Celeste.Simulation.Gameplay.Collision.Blockers.ILedgeBlockerPlayer
    {
        public int Facing => Data.Facing;

        bool global::Celeste.Core.Components.ISourceMutableEntityState.Active
        {
            get => Active;
            set => Active = value;
        }

        bool global::Celeste.Core.Components.ISourceMutableEntityState.Visible
        {
            get => Visible;
            set => Visible = value;
        }
    }
}
