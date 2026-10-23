using Celeste.Game.Chapters;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestMapMetadata
    {
        public static RoomPlayerInventory? GetInventory(string meta)
        {
            if (string.IsNullOrEmpty(meta)) return null;

            switch (meta.Length)
            {
                case 7:
                    switch (meta[0])
                    {
                        case 'D':
                            if (meta != "Default") break;

                            return OriginalInventoryFactory.Default;
                        case 'O':
                            if (meta != "OldSite") break;

                            return OriginalInventoryFactory.OldSite;
                    }

                    break;
                case 8:
                    switch (meta[0])
                    {
                        case 'P':
                            if (meta != "Prologue") break;

                            return OriginalInventoryFactory.Prologue;
                        case 'F':
                            if (meta != "Farewell") break;

                            return OriginalInventoryFactory.Farewell;
                    }

                    break;
                case 6:
                    if (meta != "CH6End") break;

                    return OriginalInventoryFactory.CH6End;
                case 4:
                    if (meta != "Core") break;

                    return OriginalInventoryFactory.Core;
                case 9:
                    if (meta != "TheSummit") break;

                    return OriginalInventoryFactory.TheSummit;
            }

            return null;
        }
    }
}
