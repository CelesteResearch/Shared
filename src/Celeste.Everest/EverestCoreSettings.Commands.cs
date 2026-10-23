using Celeste.Everest.Diagnostics.Commands;

namespace Celeste.Everest
{
    public partial class EverestCoreSettings : IEverestCommandsSettings
    {
        IEverestCommandsKeyBinding IEverestCommandsSettings.DebugConsole => DebugConsole;
        IEverestCommandsKeyBinding IEverestCommandsSettings.ToggleDebugConsole => ToggleDebugConsole;
    }
}
