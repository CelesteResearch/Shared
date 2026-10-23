using System;

namespace Celeste.Everest.Menus.Overworld
{
// Required actual CLR identities for the five installed source typeof constants.
// This capability supplies no type universe, UI list, ordering or constructor.
    public interface IInstalledOverworldUITypeEnvironment
    {
        Type ChapterSelectUIType { get; }
        Type ChapterPanelUIType { get; }
        Type MapListUIType { get; }
        Type MapSearchUIType { get; }
        Type JournalUIType { get; }
    }
}
