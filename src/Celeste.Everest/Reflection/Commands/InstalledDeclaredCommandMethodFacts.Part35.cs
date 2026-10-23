using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart35(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.IMeta",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMeta", [
                new SourceCommandMethodFacts(100680256, "MapMeta", "Convert", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100680257, "MapMeta", "Convert", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100680258, "MapMeta", "GetInventory", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMeta+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMeta+<>c__DisplayClass131_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaModeProperties",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaModeProperties+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaAudioState",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCheckpointData",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCheckpointData+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaMountain",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaMountainCamera",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCompleteScreen",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCompleteScreenLayer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCompleteScreenTitle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaTextVignette",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCassetteModifier",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaPostcard",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.IMTextureMeta",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MTextureMeta",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.ITextureMeta",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.TextureMeta",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CacheHelper`2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CacheHelper`2+ValueNode",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.Commands", [
                new SourceCommandMethodFacts(100680539, "Commands", "Hide", ["q"],
                    ["hides the command line"], []),
                new SourceCommandMethodFacts(100680540, "Commands", "WipeDebug", ["wipedebug"],
                    ["wipes the debug save"], []),
                new SourceCommandMethodFacts(100680541, "Commands", "LogDetours", ["logdetours"],
                    ["log all detours / hooks to output"], []),
                new SourceCommandMethodFacts(100680542, "Commands", "SetLogLevel", ["setloglevel"],
                    ["sets the minimum log level for a tag prefix (use * to match all)"],
                    [
                        new("tagPrefix", "System.String", DBNull.Value),
                        new("minimumLevel", "System.String", "Verbose"),
                    ]),
                new SourceCommandMethodFacts(100680543, "Commands", "ToggleShowModOptions",
                    ["modoptions"],
                    ["toggles Everest's 'Show Mod Options in Game' setting"],
                    []),
                new SourceCommandMethodFacts(100680544, "Commands", "OpenSoundTest", ["soundtest"],
                    ["opens Everest's 'Sound Test'"], []),
                new SourceCommandMethodFacts(100680545, "Commands", "Save", ["save"],
                    ["saves the game"],
                    [new("whatToSave", "System.String", "all")]),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.Commands+WhatToSave",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.OverworldLoaderToSoundTest",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CompressedHttpClient",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CompressedHttpClient+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CompressedHttpClient+<>c+<<-cctor>b__2_0>d",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CullHelper", [
                new SourceCommandMethodFacts(100680555, "CullHelper", "IsRectangleVisible", [],
                    [], []),
                new SourceCommandMethodFacts(100680556, "CullHelper", "IsCurveVisible", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.DirectoryProxy",
            [
                new SourceCommandMethodFacts(100680557, "DirectoryProxy", "GetFiles", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.DirectoryProxy+<>c__DisplayClass0_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.DisposeActionStream",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.EverestContentManager",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.EverestBuild6580",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt", [
                new SourceCommandMethodFacts(100680588, "ExceptionExt", "TypeInStacktrace", [],
                    [], []),
                new SourceCommandMethodFacts(100680589, "ExceptionExt", "MethodInStacktrace", [],
                    [], []),
                new SourceCommandMethodFacts(100680590, "ExceptionExt", "LogDetailed", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt+<>c__DisplayClass0_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt+<>c__DisplayClass1_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.AutotilerException",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.EndUserException",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.FakeAssembly", [
                new SourceCommandMethodFacts(100680616, "FakeAssembly", "GetFakeEntryAssembly", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.FileProxyStream",
            [
                new SourceCommandMethodFacts(100680666, "FileProxyStream", "DeleteDummy", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.FileProxy", [
                new SourceCommandMethodFacts(100680668, "FileProxy", "_Modize", [],
                    [], []),
                new SourceCommandMethodFacts(100680669, "FileProxy", "Exists", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100680670, "FileProxy", "OpenRead", [],
                    [], []),
                new SourceCommandMethodFacts(100680671, "FileProxy", "ReadAllBytes", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.HookUtils", [
                new SourceCommandMethodFacts(100680672, "HookUtils", "TryDisableInlining", [],
                    [], []),
                new SourceCommandMethodFacts(100680673, "HookUtils", "EnsureLegalHook", [],
                    [], []),
                new SourceCommandMethodFacts(100680675, "HookUtils", "<EnsureLegalHook>g__GetFullMethodName|2_0",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.IConst`1", [
                new SourceCommandMethodFacts(100680676, "IConst`1", "get_Value", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ILCursorExtensions",
            [
                new SourceCommandMethodFacts(100680677, "ILCursorExtensions", "GotoNextBestFit",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680678, "ILCursorExtensions", "GotoNextBestFit",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680679, "ILCursorExtensions", "TryGotoNextBestFit",
                    [], [], []),
                new SourceCommandMethodFacts(100680680, "ILCursorExtensions", "TryGotoNextBestFit",
                    [], [], []),
                new SourceCommandMethodFacts(100680681, "ILCursorExtensions", "GotoPrevBestFit",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680682, "ILCursorExtensions", "GotoPrevBestFit",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680683, "ILCursorExtensions", "TryGotoPrevBestFit",
                    [], [], []),
                new SourceCommandMethodFacts(100680684, "ILCursorExtensions", "TryGotoPrevBestFit",
                    [], [], []),
                new SourceCommandMethodFacts(100680685, "ILCursorExtensions", "GetIndexFromMatch",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.InternHelper", [
                new SourceCommandMethodFacts(100680686, "InternHelper", "Intern", [],
                    [], []),
                new SourceCommandMethodFacts(100680687, "InternHelper", "Intern", [],
                    [], []),
                new SourceCommandMethodFacts(100680688, "InternHelper", "Intern", [],
                    [], []),
                new SourceCommandMethodFacts(100680689, "InternHelper", "TryIntern", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.InternHelper`1",
            [
                new SourceCommandMethodFacts(100680691, "InternHelper`1", "Intern", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.InternHelper`1+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LoggedMonoModder",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogRotationHelper",
            [
                new SourceCommandMethodFacts(100680699, "LogRotationHelper", "GetFileNameByDate",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680700, "LogRotationHelper", "TryParse", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogRotationHelper+OldestFirst",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogRotationHelper+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogWriter",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.OutputStreamCapture",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdateInfo",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper",
            [
                new SourceCommandMethodFacts(100680734, "ModUpdaterHelper", "DownloadModUpdateList",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680735, "ModUpdaterHelper", "DownloadModDependencyGraph",
                    [], [], []),
                new SourceCommandMethodFacts(100680736, "ModUpdaterHelper", "ListAvailableUpdates",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680737, "ModUpdaterHelper", "VerifyChecksum", [],
                    [], []),
                new SourceCommandMethodFacts(100680738, "ModUpdaterHelper", "InstallModUpdate",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680739, "ModUpdaterHelper", "TryDelete", [],
                    [], []),
                new SourceCommandMethodFacts(100680740, "ModUpdaterHelper", "getModUpdaterDatabaseUrl",
                    [], [], []),
                new SourceCommandMethodFacts(100680741, "ModUpdaterHelper", "RunAsyncCheckForModUpdates",
                    [], [], []),
                new SourceCommandMethodFacts(100680742, "ModUpdaterHelper", "IsAsyncUpdateCheckingDone",
                    [], [], []),
                new SourceCommandMethodFacts(100680743, "ModUpdaterHelper", "GetAsyncLoadedModUpdates",
                    [], [], []),
                new SourceCommandMethodFacts(100680744, "ModUpdaterHelper", "FormatModName", [],
                    [], []),
                new SourceCommandMethodFacts(100680745, "ModUpdaterHelper", "GetAllMirrorUrls",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100680746, "ModUpdaterHelper", "getAllMirrorUrls",
                    [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper+MostRecentUpdatedFirst",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass11_0",
                []);
        }
    }
}
