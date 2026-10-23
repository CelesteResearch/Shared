using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart32(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.LuaTypeBuilder+<>c__DisplayClass3_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.LuaTypeBuilder+<>c__DisplayClass5_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModAsset", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModAsset+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModAsset`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModAssetBranch",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.FileSystemModAsset",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MapBinsInModsModAsset",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssemblyModAsset",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ZipModAsset",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.ModSaveData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.TextInput", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100678859, "TextInput", "get_Initialized", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678860, "TextInput", "set_Initialized", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678861, "TextInput", "add__OnInput", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678862, "TextInput", "remove__OnInput", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678863, "TextInput", "add_OnInput", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678864, "TextInput", "remove_OnInput", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678865, "TextInput", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678866, "TextInput", "Shutdown", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678867, "TextInput", "ReceiveTextInput", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678868, "TextInput", "CheckTextStatus", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678869, "TextInput", "GetClipboardText", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678870, "TextInput", "SetClipboardText", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.TextInput+<>O",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100678871, "AssetReloadHelper", "get_IsReloading", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678872, "AssetReloadHelper", "get_ReturnToScene", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678873, "AssetReloadHelper", "set_ReturnToScene", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678875, "AssetReloadHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678876, "AssetReloadHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678877, "AssetReloadHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678878, "AssetReloadHelper", "DelayReloadUntilAfterCrash",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678879, "AssetReloadHelper", "ReloadLevel", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678880, "AssetReloadHelper", "ReloadLevel", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678881, "AssetReloadHelper", "ReloadAllMaps", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678882, "AssetReloadHelper", "DoImmediateSceneSwitch",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678883, "AssetReloadHelper", "StartReloadScene", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678884, "AssetReloadHelper", "EndReloadScene", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>O",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass11_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass11_0+<<ReloadLevel>b__1>d",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass5_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0+<<Do>b__0>d",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0+<<Do>b__1>d",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass7_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<>c__DisplayClass7_1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.AssetReloadHelper+<StartReloadScene>d__24",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.LuaCoroutine",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MainThreadHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100678927, "MainThreadHelper", "get_MainThread", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678928, "MainThreadHelper", "set_MainThread", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678929, "MainThreadHelper", "get_UpdatedOnce", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678930, "MainThreadHelper", "set_UpdatedOnce", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678931, "MainThreadHelper", "get_IsMainThread", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678932, "MainThreadHelper", "get_TaskTimeSlice", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678935, "MainThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678936, "MainThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678937, "MainThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678938, "MainThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678939, "MainThreadHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678940, "MainThreadHelper", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678941, "MainThreadHelper", "GetForceQueue", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678942, "MainThreadHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678943, "MainThreadHelper", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678944, "MainThreadHelper", "GetForceQueue", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MainThreadHelper+MainThreadTaskScheduler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MainThreadHelper+YieldFrameAwaitable",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MainThreadHelper+YieldFrameAwaitable+YieldFrameAwaiter",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MaybeAwaitable`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.MapDataFixup",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100678979, "QueuedTaskHelper", "Cancel", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678980, "QueuedTaskHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678981, "QueuedTaskHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678982, "QueuedTaskHelper", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678983, "QueuedTaskHelper", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskHelper+<>c__DisplayClass5_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskHelper+<>c__DisplayClass5_0+<<Do>b__0>d",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskHelper+<>c__DisplayClass7_0`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskHelper+<>c__DisplayClass7_0`1+<<Get>b__0>d",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskHelperV2", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100678993, "QueuedTaskHelperV2", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678994, "QueuedTaskHelperV2", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678995, "QueuedTaskHelperV2", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678996, "QueuedTaskHelperV2", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678997, "QueuedTaskHelperV2", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100678998, "QueuedTaskHelperV2", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskBase",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTaskBase+<WaitForDelay>d__18",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTask",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTask+<Run>d__1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTask`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.QueuedTask`1+<Run>d__3",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SafeRoutine",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.STAThreadHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100679028, "STAThreadHelper", "get_InstanceSafe", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679029, "STAThreadHelper", "get_IsWorkerThread", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679032, "STAThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679033, "STAThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679034, "STAThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679035, "STAThreadHelper", "Schedule", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679036, "STAThreadHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679037, "STAThreadHelper", "Do", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679038, "STAThreadHelper", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679039, "STAThreadHelper", "Get", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.STAThreadHelper+<>c__DisplayClass12_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.STAThreadHelper+<>c__DisplayClass13_0`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SwapImmediately",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SwapImmediatelyExtension",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100679049, "SwapImmediatelyExtension", "SafeEnumerate",
                        Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.SwapImmediatelyExtension+Flattened",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.XXHash64", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100679054, "XXHash64", "Create", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679055, "XXHash64", "Create", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679061, "XXHash64", "<ProcessStripe>g__rot31|17_0",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679062, "XXHash64", "<HashFinal>g__rot01|18_0", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679063, "XXHash64", "<HashFinal>g__rot07|18_1", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679064, "XXHash64", "<HashFinal>g__rot12|18_2", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679065, "XXHash64", "<HashFinal>g__rot18|18_3", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679066, "XXHash64", "<HashFinal>g__rot31|18_4", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679067, "XXHash64", "<HashFinal>g__round|18_5", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100679068, "XXHash64", "<HashFinal>g__merge|18_6", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.YamlHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100679069, "YamlHelper", "DeserializerUsing", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.YamlHelper+<>c__DisplayClass2_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestMapDataProcessor",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass55_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass56_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass57_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass60_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass60_1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass60_2",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass60_3",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModule+<>c__DisplayClass60_4",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100679167, "EverestModuleAssemblyContext", "get_AssemblyLoadBlackList",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679190, "EverestModuleAssemblyContext",
                        "<Dispose>g__GetAssemblyName|27_0", Array.Empty<string>(), Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679191, "EverestModuleAssemblyContext",
                        "<CalcAssemblyCacheChecksums>g__FillChecksums|31_0", Array.Empty<string>(),
                        Array.Empty<string>(),
                        Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+AsmChecksums",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100679205, "AsmChecksums", "ReadFromFile", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679209, "AsmChecksums", "op_Inequality", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679210, "AsmChecksums", "op_Equality", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679218, "AsmChecksums", "<WriteToFile>g__WriteAsLines|24_0",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                    new SourceCommandMethodFacts(100679219, "AsmChecksums", "<IsValidWith>g__Check|26_0",
                        Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods(
                "Celeste.Mod.EverestModuleAssemblyContext+AsmChecksums+<>c__DisplayClass24_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass27_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass31_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass33_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass33_1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass34_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass41_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleBinarySaveData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleBinarySession",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Mod.EverestModuleBinarySettings",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
