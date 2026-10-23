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
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.IMeta",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMeta", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680256, "MapMeta", "Convert", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680257, "MapMeta", "Convert", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680258, "MapMeta", "GetInventory", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMeta+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMeta+<>c__DisplayClass131_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaModeProperties",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaModeProperties+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaAudioState",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCheckpointData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCheckpointData+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaMountain",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaMountainCamera",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCompleteScreen",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCompleteScreenLayer",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCompleteScreenTitle",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaTextVignette",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaCassetteModifier",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MapMetaPostcard",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.IMTextureMeta",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.MTextureMeta",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.ITextureMeta",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Meta.TextureMeta",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CacheHelper`2",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CacheHelper`2+ValueNode",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.Commands", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680539, "Commands", "Hide", new string[] { "q" },
                    new string[] { "hides the command line" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680540, "Commands", "WipeDebug", new string[] { "wipedebug" },
                    new string[] { "wipes the debug save" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680541, "Commands", "LogDetours", new string[] { "logdetours" },
                    new string[] { "log all detours / hooks to output" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680542, "Commands", "SetLogLevel", new string[] { "setloglevel" },
                    new string[] { "sets the minimum log level for a tag prefix (use * to match all)" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("tagPrefix", "System.String", DBNull.Value),
                        new SourceCommandParameter("minimumLevel", "System.String", "Verbose")
                    }),
                new SourceCommandMethodFacts(100680543, "Commands", "ToggleShowModOptions",
                    new string[] { "modoptions" },
                    new string[] { "toggles Everest's 'Show Mod Options in Game' setting" },
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680544, "Commands", "OpenSoundTest", new string[] { "soundtest" },
                    new string[] { "opens Everest's 'Sound Test'" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680545, "Commands", "Save", new string[] { "save" },
                    new string[] { "saves the game" },
                    new SourceCommandParameter[] { new SourceCommandParameter("whatToSave", "System.String", "all") })
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.Commands+WhatToSave",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.OverworldLoaderToSoundTest",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CompressedHttpClient",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CompressedHttpClient+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CompressedHttpClient+<>c+<<-cctor>b__2_0>d",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.CullHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680555, "CullHelper", "IsRectangleVisible", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680556, "CullHelper", "IsCurveVisible", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.DirectoryProxy",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100680557, "DirectoryProxy", "GetFiles", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.DirectoryProxy+<>c__DisplayClass0_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.DisposeActionStream",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.EverestContentManager",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.EverestBuild6580",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680588, "ExceptionExt", "TypeInStacktrace", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680589, "ExceptionExt", "MethodInStacktrace", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680590, "ExceptionExt", "LogDetailed", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt+<>c__DisplayClass0_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ExceptionExt+<>c__DisplayClass1_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.AutotilerException",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.EndUserException",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.FakeAssembly", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680616, "FakeAssembly", "GetFakeEntryAssembly", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.FileProxyStream",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100680666, "FileProxyStream", "DeleteDummy", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.FileProxy", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680668, "FileProxy", "_Modize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680669, "FileProxy", "Exists", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680670, "FileProxy", "OpenRead", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680671, "FileProxy", "ReadAllBytes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.HookUtils", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680672, "HookUtils", "TryDisableInlining", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680673, "HookUtils", "EnsureLegalHook", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680675, "HookUtils", "<EnsureLegalHook>g__GetFullMethodName|2_0",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.IConst`1", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680676, "IConst`1", "get_Value", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ILCursorExtensions",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100680677, "ILCursorExtensions", "GotoNextBestFit",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680678, "ILCursorExtensions", "GotoNextBestFit",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680679, "ILCursorExtensions", "TryGotoNextBestFit",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680680, "ILCursorExtensions", "TryGotoNextBestFit",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680681, "ILCursorExtensions", "GotoPrevBestFit",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680682, "ILCursorExtensions", "GotoPrevBestFit",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680683, "ILCursorExtensions", "TryGotoPrevBestFit",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680684, "ILCursorExtensions", "TryGotoPrevBestFit",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680685, "ILCursorExtensions", "GetIndexFromMatch",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.InternHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100680686, "InternHelper", "Intern", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680687, "InternHelper", "Intern", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680688, "InternHelper", "Intern", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100680689, "InternHelper", "TryIntern", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.InternHelper`1",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100680691, "InternHelper`1", "Intern", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.InternHelper`1+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LoggedMonoModder",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogRotationHelper",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100680699, "LogRotationHelper", "GetFileNameByDate",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680700, "LogRotationHelper", "TryParse", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogRotationHelper+OldestFirst",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogRotationHelper+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.LogWriter",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.OutputStreamCapture",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdateInfo",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100680734, "ModUpdaterHelper", "DownloadModUpdateList",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680735, "ModUpdaterHelper", "DownloadModDependencyGraph",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680736, "ModUpdaterHelper", "ListAvailableUpdates",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680737, "ModUpdaterHelper", "VerifyChecksum", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680738, "ModUpdaterHelper", "InstallModUpdate",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680739, "ModUpdaterHelper", "TryDelete", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680740, "ModUpdaterHelper", "getModUpdaterDatabaseUrl",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680741, "ModUpdaterHelper", "RunAsyncCheckForModUpdates",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680742, "ModUpdaterHelper", "IsAsyncUpdateCheckingDone",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680743, "ModUpdaterHelper", "GetAsyncLoadedModUpdates",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680744, "ModUpdaterHelper", "FormatModName", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680745, "ModUpdaterHelper", "GetAllMirrorUrls",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100680746, "ModUpdaterHelper", "getAllMirrorUrls",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper+MostRecentUpdatedFirst",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass11_0",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
