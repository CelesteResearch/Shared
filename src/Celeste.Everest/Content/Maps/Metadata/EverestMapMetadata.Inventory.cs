namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestMapMetadata
    {
        public static Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory? GetInventory(string meta)
        {
            if (string.IsNullOrEmpty(meta))
            {
                return null;
            }

            switch (meta.Length)
            {
                case 7:
                    switch (meta[0])
                    {
                        case 'D':
                            if (!(meta == "Default"))
                            {
                                break;
                            }

                            return Celeste.Game.Chapters.OriginalInventoryFactory.Default;
                        case 'O':
                            if (!(meta == "OldSite"))
                            {
                                break;
                            }

                            return Celeste.Game.Chapters.OriginalInventoryFactory.OldSite;
                    }

                    break;
                case 8:
                    switch (meta[0])
                    {
                        case 'P':
                            if (!(meta == "Prologue"))
                            {
                                break;
                            }

                            return Celeste.Game.Chapters.OriginalInventoryFactory.Prologue;
                        case 'F':
                            if (!(meta == "Farewell"))
                            {
                                break;
                            }

                            return Celeste.Game.Chapters.OriginalInventoryFactory.Farewell;
                    }

                    break;
                case 6:
                    if (!(meta == "CH6End"))
                    {
                        break;
                    }

                    return Celeste.Game.Chapters.OriginalInventoryFactory.CH6End;
                case 4:
                    if (!(meta == "Core"))
                    {
                        break;
                    }

                    return Celeste.Game.Chapters.OriginalInventoryFactory.Core;
                case 9:
                    if (!(meta == "TheSummit"))
                    {
                        break;
                    }

                    return Celeste.Game.Chapters.OriginalInventoryFactory.TheSummit;
            }

            return null;
        }
    }
}
