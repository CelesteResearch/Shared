using Celeste.Simulation.Gameplay.Player.Inventory;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public RoomPlayerInventory Inventory
        {
            get
            {
                if (Level != null && ((ISourcePlayerInventoryScene)Level).HasInventorySession)
                    return ((ISourcePlayerInventoryScene)Level).Inventory;
                return RoomPlayerInventory.Default;
            }
        }
    }
}
