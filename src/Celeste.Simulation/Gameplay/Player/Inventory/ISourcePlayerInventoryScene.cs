namespace Celeste.Simulation.Gameplay.Player.Inventory
{
    public interface ISourcePlayerInventoryScene
    {
        bool HasInventorySession { get; }
        RoomPlayerInventory Inventory { get; set; }
    }
}
