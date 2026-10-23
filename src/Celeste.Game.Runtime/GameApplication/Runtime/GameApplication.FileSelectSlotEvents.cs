using Celeste.Everest.UI.Menus.Files;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestFileSelectSlotEventsEnvironment
    {
        EverestFileSelectSlotEvents IEverestFileSelectSlotEventsEnvironment.FileSelectSlotEvents =>
            GameEvents.FileSelectSlotEvents;
    }
}
