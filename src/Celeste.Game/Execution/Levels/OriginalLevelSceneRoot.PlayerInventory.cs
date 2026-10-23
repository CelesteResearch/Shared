using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerInventoryScene
    {
        bool ISourcePlayerInventoryScene.HasInventorySession => Session != null;

        RoomPlayerInventory ISourcePlayerInventoryScene.Inventory
        {
            get => Session.Inventory;
            set => Session.Inventory = value;
        }
    }
}
