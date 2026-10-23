namespace Celeste.Everest.Diagnostics.Commands
{
    public interface IEverestCommandsSettings
    {
        int ExtraCommandHistoryLines { get; }
        IEverestCommandsKeyBinding DebugConsole { get; }
        IEverestCommandsKeyBinding ToggleDebugConsole { get; }
    }
}
