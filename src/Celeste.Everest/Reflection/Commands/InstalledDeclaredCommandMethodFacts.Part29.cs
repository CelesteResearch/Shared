using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart29(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.ObjModelExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677609, "ObjModelExt", "CreateFromStream", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelectIconExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677610, "OuiChapterSelectIconExt", "GetIsHidden", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677611, "OuiChapterSelectIconExt", "GetIsSelected",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.OuiMainMenuExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677612, "OuiMainMenuExt", "GetButtons", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677613, "PlayerExt", "GetCurrentTrailColor", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677614, "PlayerExt", "IsIntroState", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerHairExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677615, "PlayerHairExt", "GetHairTexture", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677616, "PlayerHairExt", "GetHairScale", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677617, "PlayerHairExt", "GetHairColor", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677618, "PlayerHairExt", "GetSprite", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677619, "PlayerHairExt", "GetWave", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.LevelSetStats", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.LevelSetStats+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.LevelSetStats+<>c__DisplayClass15_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.SaveDataExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677656, "SaveDataExt", "GetLevelSets", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677657, "SaveDataExt", "SetLevelSets", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677658, "SaveDataExt", "GetLevelSet", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677659, "SaveDataExt", "GetLevelSetStats", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677660, "SaveDataExt", "GetLevelSetStatsFor", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.TagsExt", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TheoCrystalCollider",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677662, "Everest", "get_VersionCelesteString", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677663, "Everest", "get_Args", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677664, "Everest", "set_Args", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677665, "Everest", "get_Modules", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677666, "Everest", "get_PathGame", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677667, "Everest", "set_PathGame", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677668, "Everest", "get_PathTmp", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677669, "Everest", "set_PathTmp", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677670, "Everest", "get_PathSettings", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677671, "Everest", "get_PathLog", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677672, "Everest", "set_PathLog", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677673, "Everest", "get_XDGPaths", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677674, "Everest", "set_XDGPaths", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677675, "Everest", "get_PathEverest", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677676, "Everest", "set_PathEverest", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677677, "Everest", "get_ShareVanillaSaveFiles", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677678, "Everest", "set_ShareVanillaSaveFiles", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677679, "Everest", "get_CompatibilityMode", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677680, "Everest", "set_CompatibilityMode", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677681, "Everest", "get_InstallationHash", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677682, "Everest", "get_InstallationHashShort", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677683, "Everest", "ComputeHash", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677684, "Everest", "ComputeHash", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677685, "Everest", "GetChecksum", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677686, "Everest", "GetChecksum", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677687, "Everest", "GetChecksum", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677688, "Everest", "InvalidateInstallationHash", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677690, "Everest", "ParseArgs", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677691, "Everest", "Boot", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677692, "Everest", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677693, "Everest", "Shutdown", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677694, "Everest", "Dispose", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677695, "Everest", "Register", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677696, "Everest", "LateInitializeModules", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677697, "Everest", "TriggerModInitMapReload", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677698, "Everest", "CheckDependenciesOfDelayedMods",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677699, "Everest", "checkIfOneOfDependenciesIsDelayedAndCanBeLoaded",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677700, "Everest", "Unregister", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677701, "Everest", "UnloadAssembly", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677702, "Everest", "SaveSettings", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677703, "Everest", "_SaveSettings", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677704, "Everest", "_SaveNoSettings", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677705, "Everest", "QuickFullRestart", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677706, "Everest", "_QuickFullRestart", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677707, "Everest", "SlowFullRestart", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677708, "Everest", "_SlowFullRestart", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677709, "Everest", "GetHookOwner", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677710, "Everest", "LogDetours", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677711, "Everest", "<get_InstallationHash>g__AddStream|58_0",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677712, "Everest", "<Boot>g__RegisterModDetour|69_1",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677713, "Everest", "<Boot>g__UnregisterModDetour|69_2",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677714, "Events", "add_OnCriticalError", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677715, "Events", "remove_OnCriticalError", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677716, "Events", "CriticalError", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+CustomBirdTutorial",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677717, "CustomBirdTutorial", "add_OnParseCommand",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677718, "CustomBirdTutorial", "remove_OnParseCommand",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677719, "CustomBirdTutorial", "ParseCommand", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+CustomBirdTutorial+ParseCommandHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Everest",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677724, "Everest", "add_OnLoadMod", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677725, "Everest", "remove_OnLoadMod", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677726, "Everest", "add_OnRegisterModule", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677727, "Everest", "remove_OnRegisterModule", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677728, "Everest", "LoadMod", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677729, "Everest", "RegisterModule", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Everest+ModLoadedHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Everest+RegisterModuleHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+AssetReload",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677738, "AssetReload", "add_OnBeforeReload", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677739, "AssetReload", "remove_OnBeforeReload",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677740, "AssetReload", "add_OnAfterReload", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677741, "AssetReload", "remove_OnAfterReload",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677742, "AssetReload", "add_OnBeforeNextReload",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677743, "AssetReload", "remove_OnBeforeNextReload",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677744, "AssetReload", "add_OnAfterNextReload",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677745, "AssetReload", "remove_OnAfterNextReload",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677746, "AssetReload", "BeforeReload", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677747, "AssetReload", "AfterReload", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677748, "AssetReload", "ReloadLevel", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677749, "AssetReload", "ReloadAllMaps", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+AssetReload+ReloadHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+AssetReload+ReloadLevelHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+MapMeta",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677758, "MapMeta", "add_OnParseWipe", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677759, "MapMeta", "remove_OnParseWipe", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677760, "MapMeta", "ParseWipe", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+MapMeta+ParseWipeHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+SubHudRenderer",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677765, "SubHudRenderer", "add_OnBeforeRender",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677766, "SubHudRenderer", "remove_OnBeforeRender",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677767, "SubHudRenderer", "BeforeRender", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+SubHudRenderer+BeforeRenderHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+AngryOshiro",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677772, "AngryOshiro", "add_OnRegisterStates",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677773, "AngryOshiro", "remove_OnRegisterStates",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677774, "AngryOshiro", "RegisterStates", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Celeste",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677775, "Celeste", "add_OnExiting", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677776, "Celeste", "remove_OnExiting", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677777, "Celeste", "add_OnShutdown", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677778, "Celeste", "remove_OnShutdown", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677779, "Celeste", "add_OnSceneTransition", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677780, "Celeste", "remove_OnSceneTransition",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677781, "Celeste", "Exiting", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677782, "Celeste", "Shutdown", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677783, "Celeste", "SceneTransition", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Celeste+SceneTransitionHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Decal", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677788, "Decal", "add_OnHandleDecalRegistry", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677789, "Decal", "remove_OnHandleDecalRegistry", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677790, "Decal", "HandleDecalRegistry", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Decal+DecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+EventTrigger",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677795, "EventTrigger", "add_OnEventTrigger", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677796, "EventTrigger", "remove_OnEventTrigger",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677797, "EventTrigger", "TriggerEvent", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+EventTrigger+TriggerEventHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+GameLoader",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677802, "GameLoader", "add_OnLoadThread", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677803, "GameLoader", "remove_OnLoadThread", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677804, "GameLoader", "LoadThread", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Input", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677805, "Input", "add_OnInitialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677806, "Input", "remove_OnInitialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677807, "Input", "add_OnDeregister", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677808, "Input", "remove_OnDeregister", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677809, "Input", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677810, "Input", "Deregister", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677811, "Level", "add_OnPause", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677812, "Level", "remove_OnPause", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677813, "Level", "add_OnUnpause", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677814, "Level", "remove_OnUnpause", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677815, "Level", "add_OnCreatePauseMenuButtons", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677816, "Level", "remove_OnCreatePauseMenuButtons",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677817, "Level", "add_OnTransitionTo", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677818, "Level", "remove_OnTransitionTo", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677819, "Level", "add_OnLoadEntity", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677820, "Level", "remove_OnLoadEntity", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677821, "Level", "add_OnLoadLevel", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677822, "Level", "remove_OnLoadLevel", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677823, "Level", "add_OnComplete", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677824, "Level", "remove_OnComplete", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677825, "Level", "add_OnEnd", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677826, "Level", "remove_OnEnd", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677827, "Level", "add_OnBeforeUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677828, "Level", "remove_OnBeforeUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677829, "Level", "add_OnAfterUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677830, "Level", "remove_OnAfterUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677831, "Level", "add_OnBeforeFreezeFrameUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677832, "Level", "remove_OnBeforeFreezeFrameUpdate",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677833, "Level", "add_OnAfterFreezeFrameUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677834, "Level", "remove_OnAfterFreezeFrameUpdate",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677835, "Level", "add_OnEnter", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677836, "Level", "remove_OnEnter", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677837, "Level", "add_OnExit", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677838, "Level", "remove_OnExit", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677839, "Level", "add_OnLoadBackdrop", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677840, "Level", "remove_OnLoadBackdrop", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677841, "Level", "Pause", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677842, "Level", "Unpause", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677843, "Level", "CreatePauseMenuButtons", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677844, "Level", "TransitionTo", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677845, "Level", "LoadEntity", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677846, "Level", "LoadLevel", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677847, "Level", "Complete", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677848, "Level", "End", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677849, "Level", "BeforeUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677850, "Level", "AfterUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677851, "Level", "BeforeFreezeFrameUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677852, "Level", "AfterFreezeFrameUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677853, "Level", "Enter", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677854, "Level", "Exit", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677855, "Level", "LoadBackdrop", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+PauseHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+UnpauseHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+CreatePauseMenuButtonsHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+TransitionToHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+LoadEntityHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+LoadLevelHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+CompleteHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+EndHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+EnterHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+ExitHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Level+LoadBackdropHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+LevelEnter",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677900, "LevelEnter", "add_OnPlayVignette", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677901, "LevelEnter", "remove_OnPlayVignette",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677902, "LevelEnter", "PlayVignette", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+LevelLoader",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677907, "LevelLoader", "add_OnLoadingThread", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677908, "LevelLoader", "remove_OnLoadingThread",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677909, "LevelLoader", "LoadingThread", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Atlas", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677914, "Atlas", "add_OnGetCustomFallback", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677915, "Atlas", "remove_OnGetCustomFallback", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677916, "Atlas", "GetCustomFallback", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+FileSelectSlot",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677921, "FileSelectSlot", "add_OnCreateButtons",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677922, "FileSelectSlot", "remove_OnCreateButtons",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677923, "FileSelectSlot", "HandleCreateButtons",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+FileSelectSlot+<>c__DisplayClass4_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+OuiJournal",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677930, "OuiJournal", "add_OnCreateButtons", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677931, "OuiJournal", "remove_OnCreateButtons",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+OuiJournal+EnterHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Journal",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677936, "Journal", "add_OnEnter", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677937, "Journal", "remove_OnEnter", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677938, "Journal", "Enter", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Journal+EnterHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+OuiMainMenu",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677943, "OuiMainMenu", "add_OnCreateButtons", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677944, "OuiMainMenu", "remove_OnCreateButtons",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+MainMenu",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677949, "MainMenu", "add_OnCreateButtons", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677950, "MainMenu", "remove_OnCreateButtons", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677951, "MainMenu", "CreateButtons", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Player",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677956, "Player", "add_OnSpawn", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677957, "Player", "remove_OnSpawn", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677958, "Player", "add_OnDie", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677959, "Player", "remove_OnDie", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677960, "Player", "add_OnPauseInGBJ", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677961, "Player", "remove_OnPauseInGBJ", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677962, "Player", "add_OnRegisterStates", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677963, "Player", "remove_OnRegisterStates", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677964, "Player", "add_OnBeforeUpdate", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677965, "Player", "remove_OnBeforeUpdate", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677966, "Player", "add_OnAfterUpdate", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677967, "Player", "remove_OnAfterUpdate", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677968, "Player", "Spawn", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677969, "Player", "Die", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677970, "Player", "PauseInGBJ", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677971, "Player", "RegisterStates", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677972, "Player", "BeforeUpdate", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677973, "Player", "AfterUpdate", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Seeker",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677974, "Seeker", "add_OnRegisterStates", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677975, "Seeker", "remove_OnRegisterStates", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677976, "Seeker", "RegisterStates", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Events+Session",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677977, "Session", "add_OnSliderChanged", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677978, "Session", "remove_OnSliderChanged", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100677979, "Session", "SliderChanged", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Content", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677980, "Content", "get_PathContentOrig", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677981, "Content", "set_PathContentOrig", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677982, "Content", "get_PathDUMP", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677983, "Content", "set_PathDUMP", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677984, "Content", "add_OnGuessType", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677985, "Content", "remove_OnGuessType", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677986, "Content", "add_OnUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677987, "Content", "remove_OnUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677988, "Content", "add_OnProcessLoad", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677989, "Content", "remove_OnProcessLoad", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677990, "Content", "add_OnProcessUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677991, "Content", "remove_OnProcessUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677992, "Content", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677993, "Content", "TryGet", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677994, "Content", "Get", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677995, "Content", "TryGet", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677996, "Content", "Get", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677997, "Content", "TryAdd", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677998, "Content", "Add", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677999, "Content", "GuessType", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678000, "Content", "SpanEqualsAny", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678001, "Content", "SpanEquals", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678002, "Content", "MatchExtension", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678003, "Content", "MatchMultipartExtension", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678004, "Content", "RecrawlMod", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678005, "Content", "Update", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678006, "Content", "Crawl", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678007, "Content", "ProcessLoad", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678008, "Content", "ProcessUpdate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678009, "Content", "refreshEmojis", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678010, "Content", "potentiallyContainsMountainTextures",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678011, "Content", "DumpAll", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678012, "Content", "Dump", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Content+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Content+<>c__DisplayClass39_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Content+<>c__DisplayClass39_1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Content+<>c__DisplayClass39_2",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Content+<>c__DisplayClass39_3",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+Content+<>c__DisplayClass48_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+ModInitializationBatch",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+CompatMode",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DebugRC", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100678043, "DebugRC", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678044, "DebugRC", "Shutdown", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678045, "DebugRC", "HandleRequest", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678046, "DebugRC", "ParseQueryString", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678047, "DebugRC", "WriteHTMLStart", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678048, "DebugRC", "WriteHTMLEnd", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678049, "DebugRC", "Write", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678050, "DebugRC", "SetForegroundWindow", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DebugRC+SessionInfo",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DebugRC+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DebugRC+<>c__DisplayClass13_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Everest+DebugRC+<>c__DisplayClass13_1",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
