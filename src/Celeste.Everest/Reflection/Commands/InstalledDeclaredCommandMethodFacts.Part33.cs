using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart33(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleMetadata",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleSaveData",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleSession",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleSettings",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingNameAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingInGameAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingInGameDisableAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingRangeAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingMaxLengthAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingMinLengthAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingNumberInputAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingNeedsRelaunchAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingSubTextAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingIgnoreAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingSubHeaderAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingSubMenuAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.NullModule",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry", [
                new SourceCommandMethodFacts(100679303, "DecalRegistry", "get_PropertyHandlerFactories",
                    [], [], []),
                new SourceCommandMethodFacts(100679304, "DecalRegistry", "AddPropertyHandler", [],
                    [], []),
                new SourceCommandMethodFacts(100679305, "DecalRegistry", "AddPropertyHandler", [],
                    [], []),
                new SourceCommandMethodFacts(100679306, "DecalRegistry", "ScheduleHotReloadIfNeeded",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679307, "DecalRegistry", "CreateHandlerOrNull", [],
                    [], []),
                new SourceCommandMethodFacts(100679308, "DecalRegistry", "LogConflict", [],
                    [], []),
                new SourceCommandMethodFacts(100679309, "DecalRegistry", "GetScaledOffset", [],
                    [], []),
                new SourceCommandMethodFacts(100679310, "DecalRegistry", "GetScaledRadius", [],
                    [], []),
                new SourceCommandMethodFacts(100679311, "DecalRegistry", "ScaleRectangle", [],
                    [], []),
                new SourceCommandMethodFacts(100679312, "DecalRegistry", "ScaleRectangle", [],
                    [], []),
                new SourceCommandMethodFacts(100679313, "DecalRegistry", "LoadDecalRegistry", [],
                    [], []),
                new SourceCommandMethodFacts(100679314, "DecalRegistry", "RegisterEverestHandlers",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679315, "DecalRegistry", "LoadModDecalRegistry", [],
                    [], []),
                new SourceCommandMethodFacts(100679316, "DecalRegistry", "ReadDecalRegistryXml", [],
                    [], []),
                new SourceCommandMethodFacts(100679317, "DecalRegistry", "RegisterDecal", [],
                    [], []),
                new SourceCommandMethodFacts(100679319, "DecalRegistry", "<ScheduleHotReloadIfNeeded>g__DoReload|9_1",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+DecalInfo",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>O",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__8`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__DisplayClass11_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__DisplayClass18_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__DisplayClass7_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.IStrawberry",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.IStrawberrySeeded",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry", [
                new SourceCommandMethodFacts(100679342, "StrawberryRegistry", "GetRegisteredBerries",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679343, "StrawberryRegistry", "GetTrackableBerries",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679344, "StrawberryRegistry", "GetBerryTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100679345, "StrawberryRegistry", "GetBerryNames", [],
                    [], []),
                new SourceCommandMethodFacts(100679346, "StrawberryRegistry", "Register", [],
                    [], []),
                new SourceCommandMethodFacts(100679347, "StrawberryRegistry", "Register", [],
                    [], []),
                new SourceCommandMethodFacts(100679348, "StrawberryRegistry", "TrackableContains",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679349, "StrawberryRegistry", "TrackableContains",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679350, "StrawberryRegistry", "IsRegisteredBerry",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679351, "StrawberryRegistry", "IsFirstStrawberry",
                    [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry+RegisteredBerry",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry+<>c__DisplayClass16_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI+ButtonBindingEntry",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI+<>c__DisplayClass2_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI+ButtonBindingEntry",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI+<>c__DisplayClass2_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater+<>c__DisplayClass14_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater+<>c__DisplayClass15_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater+<Routine>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.BlackScreen",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler",
            [
                new SourceCommandMethodFacts(100679403, "CriticalErrorHandler", "get_CurrentHandler",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679404, "CriticalErrorHandler", "set_CurrentHandler",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679412, "CriticalErrorHandler", "add_OnBeforePlayerRender",
                    [], [], []),
                new SourceCommandMethodFacts(100679413, "CriticalErrorHandler", "remove_OnBeforePlayerRender",
                    [], [], []),
                new SourceCommandMethodFacts(100679414, "CriticalErrorHandler", "add_OnAfterPlayerRender",
                    [], [], []),
                new SourceCommandMethodFacts(100679415, "CriticalErrorHandler", "remove_OnAfterPlayerRender",
                    [], [], []),
                new SourceCommandMethodFacts(100679416, "CriticalErrorHandler", "HandleCriticalError",
                    [], [], []),
                new SourceCommandMethodFacts(100679417, "CriticalErrorHandler", "ResetErrorHandler",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679418, "CriticalErrorHandler", "BackupLogFile",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679419, "CriticalErrorHandler", "AmendLogFile",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100679433, "CriticalErrorHandler",
                    "<HandleCriticalError>g__DoImmediateSceneSwitch|9_0", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100679434, "CriticalErrorHandler", "<BackupLogFile>g__EvalSafe|11_0",
                    [], [], []),
                new SourceCommandMethodFacts(100679435, "CriticalErrorHandler",
                    "<BackupLogFile>g__FormatByteCount|11_1",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+BeforeRenderInterceptor",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+DisplayState",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+UserChoice",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+BeforePlayerRenderHandler",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass11_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass46_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass62_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<Routine>d__46",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.MainMenuModOptionsButton",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader",
            [
                new SourceCommandMethodFacts(100679475, "OuiDependencyDownloader", "addTransitiveDependencies",
                    [], [], []),
                new SourceCommandMethodFacts(100679476, "OuiDependencyDownloader", "tryUnblacklist",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader+<>c__DisplayClass8_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader+<>c__DisplayClass9_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotSubmenu",
            [
                new SourceCommandMethodFacts(100679507, "OuiFileSelectSlotSubmenu", "Goto", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotSubmenu+<>c__0`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiGenericMenu", [
                new SourceCommandMethodFacts(100679520, "OuiGenericMenu", "Goto", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiGenericMenu+<Enter>d__10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiGenericMenu+<Leave>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet+<Enter>d__2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet+<Leave>d__3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown+<Enter>d__1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown+<Leave>d__2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiLoggedProgress",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiLoggedProgress+<Enter>d__21",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiLoggedProgress+<Leave>d__22",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList+<>c__DisplayClass12_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList+<Enter>d__15",
                []);
        }
    }
}
