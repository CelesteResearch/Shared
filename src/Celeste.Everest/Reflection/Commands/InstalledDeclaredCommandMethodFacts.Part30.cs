using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart30(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DebugRC+<>c__DisplayClass3_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DiscordSDK", [
                new SourceCommandMethodFacts(100678093, "DiscordSDK", "get_Instance", [],
                    [], []),
                new SourceCommandMethodFacts(100678094, "DiscordSDK", "set_Instance", [],
                    [], []),
                new SourceCommandMethodFacts(100678095, "DiscordSDK", "LoadRichPresenceIcons", [],
                    [], []),
                new SourceCommandMethodFacts(100678096, "DiscordSDK", "CreateInstance", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DiscordSDK+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Flags", [
                new SourceCommandMethodFacts(100678118, "Flags", "get_IsXNA", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678119, "Flags", "get_IsFNA", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678120, "Flags", "get_VanillaIsXNA", [],
                    [], []),
                new SourceCommandMethodFacts(100678121, "Flags", "set_VanillaIsXNA", [],
                    [], []),
                new SourceCommandMethodFacts(100678122, "Flags", "get_VanillaIsFNA", [],
                    [], []),
                new SourceCommandMethodFacts(100678123, "Flags", "set_VanillaIsFNA", [],
                    [], []),
                new SourceCommandMethodFacts(100678124, "Flags", "get_IsHeadless", [],
                    [], []),
                new SourceCommandMethodFacts(100678125, "Flags", "set_IsHeadless", [],
                    [], []),
                new SourceCommandMethodFacts(100678126, "Flags", "get_IsMono", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678127, "Flags", "get_AvoidRenderTargets", [],
                    [], []),
                new SourceCommandMethodFacts(100678128, "Flags", "get_PreferLazyLoading", [],
                    [], []),
                new SourceCommandMethodFacts(100678129, "Flags", "get_PreferThreadedGL", [],
                    [], []),
                new SourceCommandMethodFacts(100678130, "Flags", "get_SupportRuntimeMods", [],
                    [], []),
                new SourceCommandMethodFacts(100678131, "Flags", "get_SupportUpdatingEverest", [],
                    [], []),
                new SourceCommandMethodFacts(100678132, "Flags", "Initialize", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Flags+<>c__DisplayClass28_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader", [
                new SourceCommandMethodFacts(100678135, "Loader", "get_PathMods", [],
                    [], []),
                new SourceCommandMethodFacts(100678136, "Loader", "set_PathMods", [],
                    [], []),
                new SourceCommandMethodFacts(100678137, "Loader", "get_PathCache", [],
                    [], []),
                new SourceCommandMethodFacts(100678138, "Loader", "set_PathCache", [],
                    [], []),
                new SourceCommandMethodFacts(100678139, "Loader", "get_PathBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678140, "Loader", "set_PathBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678141, "Loader", "get_Blacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678142, "Loader", "get_PathFavorites", [],
                    [], []),
                new SourceCommandMethodFacts(100678143, "Loader", "set_PathFavorites", [],
                    [], []),
                new SourceCommandMethodFacts(100678144, "Loader", "get_PathTemporaryBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678145, "Loader", "set_PathTemporaryBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678146, "Loader", "get_TemporaryBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678147, "Loader", "get_PathWhitelist", [],
                    [], []),
                new SourceCommandMethodFacts(100678148, "Loader", "set_PathWhitelist", [],
                    [], []),
                new SourceCommandMethodFacts(100678149, "Loader", "get_Whitelist", [],
                    [], []),
                new SourceCommandMethodFacts(100678150, "Loader", "get_PathModOptionsOrder", [],
                    [], []),
                new SourceCommandMethodFacts(100678151, "Loader", "set_PathModOptionsOrder", [],
                    [], []),
                new SourceCommandMethodFacts(100678152, "Loader", "get_ModOptionsOrder", [],
                    [], []),
                new SourceCommandMethodFacts(100678153, "Loader", "get_PathUpdaterBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678154, "Loader", "set_PathUpdaterBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678155, "Loader", "get_UpdaterBlacklist", [],
                    [], []),
                new SourceCommandMethodFacts(100678156, "Loader", "get_AutoLoadNewMods", [],
                    [], []),
                new SourceCommandMethodFacts(100678157, "Loader", "set_AutoLoadNewMods", [],
                    [], []),
                new SourceCommandMethodFacts(100678158, "Loader", "add_OnCrawlMod", [],
                    [], []),
                new SourceCommandMethodFacts(100678159, "Loader", "remove_OnCrawlMod", [],
                    [], []),
                new SourceCommandMethodFacts(100678160, "Loader", "ShouldLoadFile", [],
                    [], []),
                new SourceCommandMethodFacts(100678161, "Loader", "LoadAuto", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678162, "Loader", "LoadAutoUpdated", [],
                    [], []),
                new SourceCommandMethodFacts(100678163, "Loader", "WatcherError", [],
                    [], []),
                new SourceCommandMethodFacts(100678164, "Loader", "LoadZip", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678165, "Loader", "LoadDir", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678166, "Loader", "LoadModDelayed", [],
                    [], []),
                new SourceCommandMethodFacts(100678167, "Loader", "LoadMod", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678168, "Loader", "LoadModAssembly", [],
                    [], []),
                new SourceCommandMethodFacts(100678169, "Loader", "ProcessAssembly", [],
                    [], []),
                new SourceCommandMethodFacts(100678170, "Loader", "ReloadMod", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678171, "Loader", "DependenciesLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100678172, "Loader", "DependencyLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100678173, "Loader", "TryGetDependency", [],
                    [], []),
                new SourceCommandMethodFacts(100678174, "Loader", "VersionSatisfiesDependency", [],
                    [], []),
                new SourceCommandMethodFacts(100678175, "Loader", "ApplyModHackfixes", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>O",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass67_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass69_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass70_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass71_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass71_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass72_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass74_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass74_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass74_2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass74_3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass75_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass75_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Loader+<>c__DisplayClass76_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader", [
                new SourceCommandMethodFacts(100678230, "LuaLoader", "get_Context", [],
                    [], []),
                new SourceCommandMethodFacts(100678231, "LuaLoader", "set_Context", [],
                    [], []),
                new SourceCommandMethodFacts(100678232, "LuaLoader", "get_IsDebug", [],
                    [], []),
                new SourceCommandMethodFacts(100678233, "LuaLoader", "set_IsDebug", [],
                    [], []),
                new SourceCommandMethodFacts(100678234, "LuaLoader", "Initialize", [],
                    [], []),
                new SourceCommandMethodFacts(100678235, "LuaLoader", "Run", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678236, "LuaLoader", "Precache", [],
                    [], []),
                new SourceCommandMethodFacts(100678237, "LuaLoader", "ReadText", [],
                    [], []),
                new SourceCommandMethodFacts(100678238, "LuaLoader", "Require", [],
                    [], []),
                new SourceCommandMethodFacts(100678239, "LuaLoader", "Symbol", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678241, "LuaLoader", "<Precache>g__PrecacheType|19_0",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+CachedNamespace",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+CachedType",
            [
                new SourceCommandMethodFacts(100678253, "CachedType", "NewTable", [],
                    [], []),
                new SourceCommandMethodFacts(100678254, "CachedType", "InsertIntoTable", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper",
            [
                new SourceCommandMethodFacts(100678256, "HookHelper", "GetDelegateType", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Action`16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+Func`17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+HookHelper+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+<>c__DisplayClass15_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+<>c__DisplayClass15_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+<>c__DisplayClass15_2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+LuaLoader+<>c__DisplayClass15_3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Relinker", [
                new SourceCommandMethodFacts(100678413, "Relinker", "get_GameChecksum", [],
                    [], []),
                new SourceCommandMethodFacts(100678414, "Relinker", "get_SharedRelinkModuleMap", [],
                    [], []),
                new SourceCommandMethodFacts(100678415, "Relinker", "get_SharedRelinkMap", [],
                    [], []),
                new SourceCommandMethodFacts(100678416, "Relinker", "GetRelinkedAssembly", [],
                    [], []),
                new SourceCommandMethodFacts(100678417, "Relinker", "TryLoadCachedAssembly", [],
                    [], []),
                new SourceCommandMethodFacts(100678418, "Relinker", "RelinkAssembly", [],
                    [], []),
                new SourceCommandMethodFacts(100678419, "Relinker", "LoadRuntimeRulesModule", [],
                    [], []),
                new SourceCommandMethodFacts(100678420, "Relinker", "GetCachedPath", [],
                    [], []),
                new SourceCommandMethodFacts(100678421, "Relinker", "ChecksumsEqual", [],
                    [], []),
                new SourceCommandMethodFacts(100678422, "Relinker", "EnsureStreamIsSeekable", [],
                    [], []),
                new SourceCommandMethodFacts(100678423, "Relinker", "InitMMFlags", [],
                    [], []),
                new SourceCommandMethodFacts(100678424, "Relinker", "SetMMFlag", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater", [
                new SourceCommandMethodFacts(100678426, "Updater", "get_Newest", [],
                    [], []),
                new SourceCommandMethodFacts(100678427, "Updater", "set_Newest", [],
                    [], []),
                new SourceCommandMethodFacts(100678428, "Updater", "get_HasUpdate", [],
                    [], []),
                new SourceCommandMethodFacts(100678429, "Updater", "get_UpdateFailed", [],
                    [], []),
                new SourceCommandMethodFacts(100678430, "Updater", "set_UpdateFailed", [],
                    [], []),
                new SourceCommandMethodFacts(100678431, "Updater", "RequestAll", [],
                    [], []),
                new SourceCommandMethodFacts(100678432, "Updater", "GetEverestUpdaterDatabaseURL",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100678433, "Updater", "CommonLineParser", [],
                    [], []),
                new SourceCommandMethodFacts(100678434, "Updater", "UpdateListParser", [],
                    [], []),
                new SourceCommandMethodFacts(100678435, "Updater", "AzureBuildsParser", [],
                    [], []),
                new SourceCommandMethodFacts(100678436, "Updater", "GitHubReleasesParser", [],
                    [], []),
                new SourceCommandMethodFacts(100678437, "Updater", "CheckForUpdateFailure", [],
                    [], []),
                new SourceCommandMethodFacts(100678438, "Updater", "Update", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678439, "Updater", "UpdateLegacyRef", [],
                    [], []),
                new SourceCommandMethodFacts(100678440, "Updater", "DoUpdate", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100678441, "Updater", "DownloadFileWithProgress", [],
                    [], []),
                new SourceCommandMethodFacts(100678443, "Updater", "<UpdateLegacyRef>g__CopyInstallDir|27_1",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+UpdatePriority",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+Entry",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+StringLocker",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+Source",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c__DisplayClass11_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c__DisplayClass12_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c__DisplayClass13_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c__DisplayClass14_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c__DisplayClass26_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c__DisplayClass27_0",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Everest+Updater+<>c__DisplayClass27_0+<<UpdateLegacyRef>b__0>d",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Updater+<>c__DisplayClass28_0",
                []);
        }
    }
}
