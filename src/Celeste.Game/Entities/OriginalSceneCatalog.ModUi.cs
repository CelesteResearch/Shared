using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModUiTypes(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.ModuleSettingsButtonConfigUI",
                    new string[]
                    {
                        "Celeste.ButtonConfigUI", "Celeste.TextMenu",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.Mod.ModuleSettingsKeyboardConfigUI",
                    new string[]
                    {
                        "Celeste.KeyboardConfigUI", "Celeste.TextMenu",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.CriticalErrorHandler",
                    new string[]
                        { "Celeste.Overlay", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.MainMenuModOptionsButton",
                    new string[]
                    {
                        "Celeste.MainMenuSmallButton", "Celeste.MenuButton",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.MenuButton" }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiDependencyDownloader",
                    new string[]
                    {
                        "Celeste.Mod.UI.OuiLoggedProgress", "Celeste.Oui",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiFileSelectSlotSubmenu",
                    new string[]
                    {
                        "Celeste.Mod.UI.OuiGenericMenu", "Celeste.Oui",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiGenericMenu",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiHelper_Shutdown",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiLoggedProgress",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiMapList",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiMapSearch",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiMapSearch.SearchMenu",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiModOptions",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiModOptionString",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiModToggler",
                    new string[]
                    {
                        "Celeste.Mod.UI.OuiGenericMenu", "Celeste.Oui",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiModUpdateList",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiNumberEntry",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiOOBE",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiSoundTest",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiTextEntry",
                    new string[]
                    {
                        "Celeste.Mod.UI.OuiModOptionString", "Celeste.Oui",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.UI.OuiVersionList",
                    new string[] { "Celeste.Oui", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
