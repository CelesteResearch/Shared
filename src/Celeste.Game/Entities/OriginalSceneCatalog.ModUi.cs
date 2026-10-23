using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModUiTypes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.ModuleSettingsButtonConfigUI",
                    (string[])
                    [
                        "Celeste.ButtonConfigUI", "Celeste.TextMenu",
                        typeof(SceneEntityState).FullName,
                    ], (string[])[]));
            result.Register(
                new("Celeste.Mod.ModuleSettingsKeyboardConfigUI",
                    (string[])
                    [
                        "Celeste.KeyboardConfigUI", "Celeste.TextMenu",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.CriticalErrorHandler",
                    (string[])["Celeste.Overlay", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.MainMenuModOptionsButton",
                    (string[])
                    [
                        "Celeste.MainMenuSmallButton", "Celeste.MenuButton",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.MenuButton"]));
            result.Register(
                new("Celeste.Mod.UI.OuiDependencyDownloader",
                    (string[])
                    [
                        "Celeste.Mod.UI.OuiLoggedProgress", "Celeste.Oui",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiFileSelectSlotSubmenu",
                    (string[])
                    [
                        "Celeste.Mod.UI.OuiGenericMenu", "Celeste.Oui",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiGenericMenu",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiHelper_Shutdown",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiLoggedProgress",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiMapList",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiMapSearch",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiMapSearch.SearchMenu",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiModOptions",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiModOptionString",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiModToggler",
                    (string[])
                    [
                        "Celeste.Mod.UI.OuiGenericMenu", "Celeste.Oui",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiModUpdateList",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiNumberEntry",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiOOBE",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiSoundTest",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiTextEntry",
                    (string[])
                    [
                        "Celeste.Mod.UI.OuiModOptionString", "Celeste.Oui",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.UI.OuiVersionList",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
