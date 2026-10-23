using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public SourceSolidEntityState SourceClimbHopSolid
        {
            get
            {
                var solid = Data.ClimbHopSolid;
                return solid == null ? null : (SourceSolidEntityState)((CollisionPlatform)solid).SourceEntityOwner;
            }
            set => Data.ClimbHopSolid = value?.Platform;
        }
    }
}
