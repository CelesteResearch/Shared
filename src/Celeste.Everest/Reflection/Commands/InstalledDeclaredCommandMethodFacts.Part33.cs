using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart33(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleMetadata",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleSaveData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleSession",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleSettings",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingNameAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingInGameAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingInGameDisableAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingRangeAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingMaxLengthAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingMinLengthAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingNumberInputAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingNeedsRelaunchAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingSubTextAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingIgnoreAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingSubHeaderAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SettingSubMenuAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.NullModule",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100679303, "DecalRegistry", "get_PropertyHandlerFactories",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679304, "DecalRegistry", "AddPropertyHandler", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679305, "DecalRegistry", "AddPropertyHandler", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679306, "DecalRegistry", "ScheduleHotReloadIfNeeded",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679307, "DecalRegistry", "CreateHandlerOrNull", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679308, "DecalRegistry", "LogConflict", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679309, "DecalRegistry", "GetScaledOffset", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679310, "DecalRegistry", "GetScaledRadius", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679311, "DecalRegistry", "ScaleRectangle", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679312, "DecalRegistry", "ScaleRectangle", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679313, "DecalRegistry", "LoadDecalRegistry", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679314, "DecalRegistry", "RegisterEverestHandlers",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679315, "DecalRegistry", "LoadModDecalRegistry", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679316, "DecalRegistry", "ReadDecalRegistryXml", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679317, "DecalRegistry", "RegisterDecal", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679319, "DecalRegistry", "<ScheduleHotReloadIfNeeded>g__DoReload|9_1",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+DecalInfo",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>O",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__8`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__DisplayClass11_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__DisplayClass18_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.DecalRegistry+<>c__DisplayClass7_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.IStrawberry",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.IStrawberrySeeded",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100679342, "StrawberryRegistry", "GetRegisteredBerries",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679343, "StrawberryRegistry", "GetTrackableBerries",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679344, "StrawberryRegistry", "GetBerryTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679345, "StrawberryRegistry", "GetBerryNames", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679346, "StrawberryRegistry", "Register", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679347, "StrawberryRegistry", "Register", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679348, "StrawberryRegistry", "TrackableContains",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679349, "StrawberryRegistry", "TrackableContains",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679350, "StrawberryRegistry", "IsRegisteredBerry",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679351, "StrawberryRegistry", "IsFirstStrawberry",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry+RegisteredBerry",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.StrawberryRegistry+<>c__DisplayClass16_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI+ButtonBindingEntry",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsButtonConfigUI+<>c__DisplayClass2_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI+ButtonBindingEntry",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModuleSettingsKeyboardConfigUI+<>c__DisplayClass2_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater+<>c__DisplayClass14_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater+<>c__DisplayClass15_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.AutoModUpdater+<Routine>d__14",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.BlackScreen",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100679403, "CriticalErrorHandler", "get_CurrentHandler",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679404, "CriticalErrorHandler", "set_CurrentHandler",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679412, "CriticalErrorHandler", "add_OnBeforePlayerRender",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679413, "CriticalErrorHandler", "remove_OnBeforePlayerRender",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679414, "CriticalErrorHandler", "add_OnAfterPlayerRender",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679415, "CriticalErrorHandler", "remove_OnAfterPlayerRender",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679416, "CriticalErrorHandler", "HandleCriticalError",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679417, "CriticalErrorHandler", "ResetErrorHandler",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679418, "CriticalErrorHandler", "BackupLogFile",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679419, "CriticalErrorHandler", "AmendLogFile",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679433, "CriticalErrorHandler",
                        "<HandleCriticalError>g__DoImmediateSceneSwitch|9_0", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679434, "CriticalErrorHandler", "<BackupLogFile>g__EvalSafe|11_0",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679435, "CriticalErrorHandler",
                        "<BackupLogFile>g__FormatByteCount|11_1",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+BeforeRenderInterceptor",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+DisplayState",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+UserChoice",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+BeforePlayerRenderHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass11_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass46_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass62_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.CriticalErrorHandler+<Routine>d__46",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.MainMenuModOptionsButton",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100679475, "OuiDependencyDownloader", "addTransitiveDependencies",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679476, "OuiDependencyDownloader", "tryUnblacklist",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader+<>c__DisplayClass8_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiDependencyDownloader+<>c__DisplayClass9_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotSubmenu",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100679507, "OuiFileSelectSlotSubmenu", "Goto", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiFileSelectSlotSubmenu+<>c__0`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiGenericMenu", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100679520, "OuiGenericMenu", "Goto", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiGenericMenu+<Enter>d__10",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiGenericMenu+<Leave>d__11",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet+<Enter>d__2",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet+<Leave>d__3",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown+<Enter>d__1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiHelper_Shutdown+<Leave>d__2",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiLoggedProgress",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiLoggedProgress+<Enter>d__21",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiLoggedProgress+<Leave>d__22",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList+<>c__DisplayClass12_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.UI.OuiMapList+<Enter>d__15",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
