using System;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup;

public static partial class InstalledLogicalTypeFacts
{
    private static void RegisterPart13(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.QueuedTaskBase", "Celeste.Mod.QueuedTaskBase", "QueuedTaskBase",
            assemblyIdentity, "Celeste", 33557034, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.QueuedTaskBase", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.QueuedTaskBase",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.QueuedTaskBase+<WaitForDelay>d__18",
            "Celeste.Mod.QueuedTaskBase.<WaitForDelay>d__18", "<WaitForDelay>d__18", assemblyIdentity, "Celeste",
            33557035, false, new string[] { "System.ValueType", "System.Runtime.CompilerServices.IAsyncStateMachine" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.QueuedTaskBase.<WaitForDelay>d__18", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.QueuedTaskBase.<WaitForDelay>d__18",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.QueuedTask", "Celeste.Mod.QueuedTask", "QueuedTask",
            assemblyIdentity, "Celeste", 33557036, false,
            new string[] { "Celeste.Mod.QueuedTaskBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.QueuedTask", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.QueuedTask",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.QueuedTask+<Run>d__1", "Celeste.Mod.QueuedTask.<Run>d__1",
            "<Run>d__1", assemblyIdentity, "Celeste", 33557037, false,
            new string[] { "System.ValueType", "System.Runtime.CompilerServices.IAsyncStateMachine" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.QueuedTask.<Run>d__1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.QueuedTask.<Run>d__1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.QueuedTask`1", "Celeste.Mod.QueuedTask`1", "QueuedTask`1",
            assemblyIdentity, "Celeste", 33557038, false,
            new string[] { "Celeste.Mod.QueuedTaskBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.QueuedTask`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.QueuedTask`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.QueuedTask`1+<Run>d__3", "Celeste.Mod.QueuedTask`1.<Run>d__3",
            "<Run>d__3", assemblyIdentity, "Celeste", 33557039, false,
            new string[] { "System.ValueType", "System.Runtime.CompilerServices.IAsyncStateMachine" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.QueuedTask`1.<Run>d__3", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.QueuedTask`1.<Run>d__3",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SafeRoutine", "Celeste.Mod.SafeRoutine", "SafeRoutine",
            assemblyIdentity, "Celeste", 33557040, false,
            new string[] { "System.Object", "System.Collections.IEnumerator" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SafeRoutine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SafeRoutine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.STAThreadHelper", "Celeste.Mod.STAThreadHelper",
            "STAThreadHelper", assemblyIdentity, "Celeste", 33557041, false,
            new string[] { "Microsoft.Xna.Framework.GameComponent" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.STAThreadHelper", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.STAThreadHelper",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.STAThreadHelper+<>c__DisplayClass12_0",
            "Celeste.Mod.STAThreadHelper.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste",
            33557042, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.STAThreadHelper.<>c__DisplayClass12_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.STAThreadHelper.<>c__DisplayClass12_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.STAThreadHelper+<>c__DisplayClass13_0`1",
            "Celeste.Mod.STAThreadHelper.<>c__DisplayClass13_0`1", "<>c__DisplayClass13_0`1", assemblyIdentity,
            "Celeste", 33557043, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.STAThreadHelper.<>c__DisplayClass13_0`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.STAThreadHelper.<>c__DisplayClass13_0`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SwapImmediately", "Celeste.Mod.SwapImmediately",
            "SwapImmediately", assemblyIdentity, "Celeste", 33557044, false,
            new string[] { "System.Object", "System.Collections.IEnumerator" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SwapImmediately", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SwapImmediately",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SwapImmediatelyExtension", "Celeste.Mod.SwapImmediatelyExtension",
            "SwapImmediatelyExtension", assemblyIdentity, "Celeste", 33557045, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SwapImmediatelyExtension", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SwapImmediatelyExtension",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SwapImmediatelyExtension+Flattened",
            "Celeste.Mod.SwapImmediatelyExtension.Flattened", "Flattened", assemblyIdentity, "Celeste", 33557046, false,
            new string[] { "System.ValueType", "System.Collections.IEnumerator" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SwapImmediatelyExtension.Flattened", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SwapImmediatelyExtension.Flattened",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.XXHash64", "Celeste.Mod.XXHash64", "XXHash64", assemblyIdentity,
            "Celeste", 33557047, false, new string[] { "System.Security.Cryptography.HashAlgorithm" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.XXHash64", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.XXHash64",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.YamlHelper", "Celeste.Mod.YamlHelper", "YamlHelper",
            assemblyIdentity, "Celeste", 33557048, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.YamlHelper", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.YamlHelper",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.YamlHelper+<>c__DisplayClass2_0",
            "Celeste.Mod.YamlHelper.<>c__DisplayClass2_0", "<>c__DisplayClass2_0", assemblyIdentity, "Celeste",
            33557049, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.YamlHelper.<>c__DisplayClass2_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.YamlHelper.<>c__DisplayClass2_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestMapDataProcessor", "Celeste.Mod.EverestMapDataProcessor",
            "EverestMapDataProcessor", assemblyIdentity, "Celeste", 33557050, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestMapDataProcessor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestMapDataProcessor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule", "Celeste.Mod.EverestModule", "EverestModule",
            assemblyIdentity, "Celeste", 33557051, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c", "Celeste.Mod.EverestModule.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557052, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass55_0",
            "Celeste.Mod.EverestModule.<>c__DisplayClass55_0", "<>c__DisplayClass55_0", assemblyIdentity, "Celeste",
            33557053, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass55_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass55_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass56_0",
            "Celeste.Mod.EverestModule.<>c__DisplayClass56_0", "<>c__DisplayClass56_0", assemblyIdentity, "Celeste",
            33557054, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass56_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass56_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass57_0",
            "Celeste.Mod.EverestModule.<>c__DisplayClass57_0", "<>c__DisplayClass57_0", assemblyIdentity, "Celeste",
            33557055, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass57_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass57_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass60_0",
            "Celeste.Mod.EverestModule.<>c__DisplayClass60_0", "<>c__DisplayClass60_0", assemblyIdentity, "Celeste",
            33557056, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass60_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass60_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass60_1",
            "Celeste.Mod.EverestModule.<>c__DisplayClass60_1", "<>c__DisplayClass60_1", assemblyIdentity, "Celeste",
            33557057, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass60_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass60_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass60_2",
            "Celeste.Mod.EverestModule.<>c__DisplayClass60_2", "<>c__DisplayClass60_2", assemblyIdentity, "Celeste",
            33557058, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass60_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass60_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass60_3",
            "Celeste.Mod.EverestModule.<>c__DisplayClass60_3", "<>c__DisplayClass60_3", assemblyIdentity, "Celeste",
            33557059, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass60_3", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass60_3",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModule+<>c__DisplayClass60_4",
            "Celeste.Mod.EverestModule.<>c__DisplayClass60_4", "<>c__DisplayClass60_4", assemblyIdentity, "Celeste",
            33557060, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModule.<>c__DisplayClass60_4", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModule.<>c__DisplayClass60_4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext",
            "Celeste.Mod.EverestModuleAssemblyContext", "EverestModuleAssemblyContext", assemblyIdentity, "Celeste",
            33557061, false,
            new string[]
                { "System.Runtime.Loader.AssemblyLoadContext", "Mono.Cecil.IAssemblyResolver", "System.IDisposable" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+AsmChecksums",
            "Celeste.Mod.EverestModuleAssemblyContext.AsmChecksums", "AsmChecksums", assemblyIdentity, "Celeste",
            33557062, false,
            new string[]
                { "System.Object", "System.IEquatable`1<Celeste.Mod.EverestModuleAssemblyContext+AsmChecksums>" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.AsmChecksums", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.AsmChecksums",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+AsmChecksums+<>c__DisplayClass24_0",
            "Celeste.Mod.EverestModuleAssemblyContext.AsmChecksums.<>c__DisplayClass24_0", "<>c__DisplayClass24_0",
            assemblyIdentity, "Celeste", 33557063, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.AsmChecksums.<>c__DisplayClass24_0",
            0, false);
        catalog.PublishDeclaredTrackedAliases(
            "Celeste.Mod.EverestModuleAssemblyContext.AsmChecksums.<>c__DisplayClass24_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+<>c",
            "Celeste.Mod.EverestModuleAssemblyContext.<>c", "<>c", assemblyIdentity, "Celeste", 33557064, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass27_0",
            "Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass27_0", "<>c__DisplayClass27_0", assemblyIdentity,
            "Celeste", 33557065, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass27_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass27_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass31_0",
            "Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass31_0", "<>c__DisplayClass31_0", assemblyIdentity,
            "Celeste", 33557066, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass31_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass31_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass33_0",
            "Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass33_0", "<>c__DisplayClass33_0", assemblyIdentity,
            "Celeste", 33557067, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass33_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass33_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass33_1",
            "Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass33_1", "<>c__DisplayClass33_1", assemblyIdentity,
            "Celeste", 33557068, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass33_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass33_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass34_0",
            "Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass34_0", "<>c__DisplayClass34_0", assemblyIdentity,
            "Celeste", 33557069, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass34_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass34_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleAssemblyContext+<>c__DisplayClass41_0",
            "Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass41_0", "<>c__DisplayClass41_0", assemblyIdentity,
            "Celeste", 33557070, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass41_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleAssemblyContext.<>c__DisplayClass41_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleBinarySaveData",
            "Celeste.Mod.EverestModuleBinarySaveData", "EverestModuleBinarySaveData", assemblyIdentity, "Celeste",
            33557071, true, new string[] { "Celeste.Mod.EverestModuleSaveData", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleBinarySaveData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleBinarySaveData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleBinarySession",
            "Celeste.Mod.EverestModuleBinarySession", "EverestModuleBinarySession", assemblyIdentity, "Celeste",
            33557072, true, new string[] { "Celeste.Mod.EverestModuleSession", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleBinarySession", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleBinarySession",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleBinarySettings",
            "Celeste.Mod.EverestModuleBinarySettings", "EverestModuleBinarySettings", assemblyIdentity, "Celeste",
            33557073, true, new string[] { "Celeste.Mod.EverestModuleSettings", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleBinarySettings", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleBinarySettings",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleMetadata", "Celeste.Mod.EverestModuleMetadata",
            "EverestModuleMetadata", assemblyIdentity, "Celeste", 33557074, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleMetadata", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleMetadata",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleSaveData", "Celeste.Mod.EverestModuleSaveData",
            "EverestModuleSaveData", assemblyIdentity, "Celeste", 33557075, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleSaveData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleSaveData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleSession", "Celeste.Mod.EverestModuleSession",
            "EverestModuleSession", assemblyIdentity, "Celeste", 33557076, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleSession", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleSession",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.EverestModuleSettings", "Celeste.Mod.EverestModuleSettings",
            "EverestModuleSettings", assemblyIdentity, "Celeste", 33557077, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.EverestModuleSettings", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.EverestModuleSettings",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingNameAttribute", "Celeste.Mod.SettingNameAttribute",
            "SettingNameAttribute", assemblyIdentity, "Celeste", 33557078, false, new string[] { "System.Attribute" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingNameAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingNameAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingInGameAttribute", "Celeste.Mod.SettingInGameAttribute",
            "SettingInGameAttribute", assemblyIdentity, "Celeste", 33557079, false, new string[] { "System.Attribute" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingInGameAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingInGameAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingInGameDisableAttribute",
            "Celeste.Mod.SettingInGameDisableAttribute", "SettingInGameDisableAttribute", assemblyIdentity, "Celeste",
            33557080, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingInGameDisableAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingInGameDisableAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingRangeAttribute", "Celeste.Mod.SettingRangeAttribute",
            "SettingRangeAttribute", assemblyIdentity, "Celeste", 33557081, false, new string[] { "System.Attribute" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingRangeAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingRangeAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingMaxLengthAttribute",
            "Celeste.Mod.SettingMaxLengthAttribute", "SettingMaxLengthAttribute", assemblyIdentity, "Celeste", 33557082,
            false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingMaxLengthAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingMaxLengthAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingMinLengthAttribute",
            "Celeste.Mod.SettingMinLengthAttribute", "SettingMinLengthAttribute", assemblyIdentity, "Celeste", 33557083,
            false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingMinLengthAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingMinLengthAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingNumberInputAttribute",
            "Celeste.Mod.SettingNumberInputAttribute", "SettingNumberInputAttribute", assemblyIdentity, "Celeste",
            33557084, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingNumberInputAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingNumberInputAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingNeedsRelaunchAttribute",
            "Celeste.Mod.SettingNeedsRelaunchAttribute", "SettingNeedsRelaunchAttribute", assemblyIdentity, "Celeste",
            33557085, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingNeedsRelaunchAttribute", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingNeedsRelaunchAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingSubTextAttribute", "Celeste.Mod.SettingSubTextAttribute",
            "SettingSubTextAttribute", assemblyIdentity, "Celeste", 33557086, false,
            new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingSubTextAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingSubTextAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingIgnoreAttribute", "Celeste.Mod.SettingIgnoreAttribute",
            "SettingIgnoreAttribute", assemblyIdentity, "Celeste", 33557087, false, new string[] { "System.Attribute" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingIgnoreAttribute", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingIgnoreAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingSubHeaderAttribute",
            "Celeste.Mod.SettingSubHeaderAttribute", "SettingSubHeaderAttribute", assemblyIdentity, "Celeste", 33557088,
            false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingSubHeaderAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingSubHeaderAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.SettingSubMenuAttribute", "Celeste.Mod.SettingSubMenuAttribute",
            "SettingSubMenuAttribute", assemblyIdentity, "Celeste", 33557089, false,
            new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.SettingSubMenuAttribute", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.SettingSubMenuAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.NullModule", "Celeste.Mod.NullModule", "NullModule",
            assemblyIdentity, "Celeste", 33557090, false, new string[] { "Celeste.Mod.EverestModule", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.NullModule", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.NullModule",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry", "Celeste.Mod.DecalRegistry", "DecalRegistry",
            assemblyIdentity, "Celeste", 33557091, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry+DecalInfo", "Celeste.Mod.DecalRegistry.DecalInfo",
            "DecalInfo", assemblyIdentity, "Celeste", 33557092, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry.DecalInfo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry.DecalInfo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry+<>O", "Celeste.Mod.DecalRegistry.<>O", "<>O",
            assemblyIdentity, "Celeste", 33557093, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry.<>O", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry.<>O",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry+<>c", "Celeste.Mod.DecalRegistry.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557094, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry+<>c__8`1", "Celeste.Mod.DecalRegistry.<>c__8`1",
            "<>c__8`1", assemblyIdentity, "Celeste", 33557095, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry.<>c__8`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry.<>c__8`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry+<>c__DisplayClass11_0",
            "Celeste.Mod.DecalRegistry.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity, "Celeste",
            33557096, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry.<>c__DisplayClass11_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry.<>c__DisplayClass11_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry+<>c__DisplayClass18_0",
            "Celeste.Mod.DecalRegistry.<>c__DisplayClass18_0", "<>c__DisplayClass18_0", assemblyIdentity, "Celeste",
            33557097, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry.<>c__DisplayClass18_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry.<>c__DisplayClass18_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.DecalRegistry+<>c__DisplayClass7_0",
            "Celeste.Mod.DecalRegistry.<>c__DisplayClass7_0", "<>c__DisplayClass7_0", assemblyIdentity, "Celeste",
            33557098, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.DecalRegistry.<>c__DisplayClass7_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.DecalRegistry.<>c__DisplayClass7_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.IStrawberry", "Celeste.Mod.IStrawberry", "IStrawberry",
            assemblyIdentity, "Celeste", 33557099, true, Array.Empty<string>(), Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.IStrawberry", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.IStrawberry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.IStrawberrySeeded", "Celeste.Mod.IStrawberrySeeded",
            "IStrawberrySeeded", assemblyIdentity, "Celeste", 33557100, true, Array.Empty<string>(),
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.IStrawberrySeeded", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.IStrawberrySeeded",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.StrawberryRegistry", "Celeste.Mod.StrawberryRegistry",
            "StrawberryRegistry", assemblyIdentity, "Celeste", 33557101, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.StrawberryRegistry", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.StrawberryRegistry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.StrawberryRegistry+RegisteredBerry",
            "Celeste.Mod.StrawberryRegistry.RegisteredBerry", "RegisteredBerry", assemblyIdentity, "Celeste", 33557102,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.StrawberryRegistry.RegisteredBerry", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.StrawberryRegistry.RegisteredBerry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.StrawberryRegistry+<>c", "Celeste.Mod.StrawberryRegistry.<>c",
            "<>c", assemblyIdentity, "Celeste", 33557103, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.StrawberryRegistry.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.StrawberryRegistry.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.StrawberryRegistry+<>c__DisplayClass16_0",
            "Celeste.Mod.StrawberryRegistry.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity,
            "Celeste", 33557104, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.StrawberryRegistry.<>c__DisplayClass16_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.StrawberryRegistry.<>c__DisplayClass16_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsButtonConfigUI",
            "Celeste.Mod.ModuleSettingsButtonConfigUI", "ModuleSettingsButtonConfigUI", assemblyIdentity, "Celeste",
            33557105, false,
            new string[]
            {
                "Celeste.ButtonConfigUI", "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsButtonConfigUI", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsButtonConfigUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsButtonConfigUI+ButtonBindingEntry",
            "Celeste.Mod.ModuleSettingsButtonConfigUI.ButtonBindingEntry", "ButtonBindingEntry", assemblyIdentity,
            "Celeste", 33557106, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsButtonConfigUI.ButtonBindingEntry", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsButtonConfigUI.ButtonBindingEntry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsButtonConfigUI+<>c",
            "Celeste.Mod.ModuleSettingsButtonConfigUI.<>c", "<>c", assemblyIdentity, "Celeste", 33557107, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsButtonConfigUI.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsButtonConfigUI.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsButtonConfigUI+<>c__DisplayClass2_0",
            "Celeste.Mod.ModuleSettingsButtonConfigUI.<>c__DisplayClass2_0", "<>c__DisplayClass2_0", assemblyIdentity,
            "Celeste", 33557108, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsButtonConfigUI.<>c__DisplayClass2_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsButtonConfigUI.<>c__DisplayClass2_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI",
            "Celeste.Mod.ModuleSettingsKeyboardConfigUI", "ModuleSettingsKeyboardConfigUI", assemblyIdentity, "Celeste",
            33557109, false,
            new string[]
            {
                "Celeste.KeyboardConfigUI", "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsKeyboardConfigUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI+ButtonBindingEntry",
            "Celeste.Mod.ModuleSettingsKeyboardConfigUI.ButtonBindingEntry", "ButtonBindingEntry", assemblyIdentity,
            "Celeste", 33557110, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI.ButtonBindingEntry", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsKeyboardConfigUI.ButtonBindingEntry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI+<>c",
            "Celeste.Mod.ModuleSettingsKeyboardConfigUI.<>c", "<>c", assemblyIdentity, "Celeste", 33557111, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsKeyboardConfigUI.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI+<>c__DisplayClass2_0",
            "Celeste.Mod.ModuleSettingsKeyboardConfigUI.<>c__DisplayClass2_0", "<>c__DisplayClass2_0", assemblyIdentity,
            "Celeste", 33557112, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.ModuleSettingsKeyboardConfigUI.<>c__DisplayClass2_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.ModuleSettingsKeyboardConfigUI.<>c__DisplayClass2_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.AutoModUpdater", "Celeste.Mod.UI.AutoModUpdater",
            "AutoModUpdater", assemblyIdentity, "Celeste", 33557113, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.AutoModUpdater", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.AutoModUpdater",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.AutoModUpdater+<>c__DisplayClass14_0",
            "Celeste.Mod.UI.AutoModUpdater.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
            33557114, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.AutoModUpdater.<>c__DisplayClass14_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.AutoModUpdater.<>c__DisplayClass14_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.AutoModUpdater+<>c__DisplayClass15_0",
            "Celeste.Mod.UI.AutoModUpdater.<>c__DisplayClass15_0", "<>c__DisplayClass15_0", assemblyIdentity, "Celeste",
            33557115, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.AutoModUpdater.<>c__DisplayClass15_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.AutoModUpdater.<>c__DisplayClass15_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.AutoModUpdater+<Routine>d__14",
            "Celeste.Mod.UI.AutoModUpdater.<Routine>d__14", "<Routine>d__14", assemblyIdentity, "Celeste", 33557116,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.AutoModUpdater.<Routine>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.AutoModUpdater.<Routine>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.BlackScreen", "Celeste.Mod.UI.BlackScreen", "BlackScreen",
            assemblyIdentity, "Celeste", 33557117, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.BlackScreen", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.BlackScreen",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler", "Celeste.Mod.UI.CriticalErrorHandler",
            "CriticalErrorHandler", assemblyIdentity, "Celeste", 33557118, false,
            new string[]
            {
                "Celeste.Overlay", "System.IDisposable", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+BeforeRenderInterceptor",
            "Celeste.Mod.UI.CriticalErrorHandler.BeforeRenderInterceptor", "BeforeRenderInterceptor", assemblyIdentity,
            "Celeste", 33557119, false, new string[] { "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.BeforeRenderInterceptor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.BeforeRenderInterceptor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+DisplayState",
            "Celeste.Mod.UI.CriticalErrorHandler.DisplayState", "DisplayState", assemblyIdentity, "Celeste", 33557120,
            false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.DisplayState", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.DisplayState",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+UserChoice",
            "Celeste.Mod.UI.CriticalErrorHandler.UserChoice", "UserChoice", assemblyIdentity, "Celeste", 33557121,
            false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.UserChoice", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.UserChoice",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+BeforePlayerRenderHandler",
            "Celeste.Mod.UI.CriticalErrorHandler.BeforePlayerRenderHandler", "BeforePlayerRenderHandler",
            assemblyIdentity, "Celeste", 33557122, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.BeforePlayerRenderHandler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.BeforePlayerRenderHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+<>c",
            "Celeste.Mod.UI.CriticalErrorHandler.<>c", "<>c", assemblyIdentity, "Celeste", 33557123, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass11_0",
            "Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity,
            "Celeste", 33557124, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass11_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass11_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass46_0",
            "Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass46_0", "<>c__DisplayClass46_0", assemblyIdentity,
            "Celeste", 33557125, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass46_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass46_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+<>c__DisplayClass62_0",
            "Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass62_0", "<>c__DisplayClass62_0", assemblyIdentity,
            "Celeste", 33557126, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass62_0", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.<>c__DisplayClass62_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.CriticalErrorHandler+<Routine>d__46",
            "Celeste.Mod.UI.CriticalErrorHandler.<Routine>d__46", "<Routine>d__46", assemblyIdentity, "Celeste",
            33557127, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.CriticalErrorHandler.<Routine>d__46", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.CriticalErrorHandler.<Routine>d__46",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.MainMenuModOptionsButton",
            "Celeste.Mod.UI.MainMenuModOptionsButton", "MainMenuModOptionsButton", assemblyIdentity, "Celeste",
            33557128, false,
            new string[]
            {
                "Celeste.MainMenuSmallButton", "Celeste.MenuButton", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.MainMenuModOptionsButton", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.MainMenuModOptionsButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiDependencyDownloader",
            "Celeste.Mod.UI.OuiDependencyDownloader", "OuiDependencyDownloader", assemblyIdentity, "Celeste", 33557129,
            false,
            new string[]
            {
                "Celeste.Mod.UI.OuiLoggedProgress", "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiDependencyDownloader", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiDependencyDownloader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiDependencyDownloader+<>c",
            "Celeste.Mod.UI.OuiDependencyDownloader.<>c", "<>c", assemblyIdentity, "Celeste", 33557130, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiDependencyDownloader.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiDependencyDownloader.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiDependencyDownloader+<>c__DisplayClass8_0",
            "Celeste.Mod.UI.OuiDependencyDownloader.<>c__DisplayClass8_0", "<>c__DisplayClass8_0", assemblyIdentity,
            "Celeste", 33557131, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiDependencyDownloader.<>c__DisplayClass8_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiDependencyDownloader.<>c__DisplayClass8_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiDependencyDownloader+<>c__DisplayClass9_0",
            "Celeste.Mod.UI.OuiDependencyDownloader.<>c__DisplayClass9_0", "<>c__DisplayClass9_0", assemblyIdentity,
            "Celeste", 33557132, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiDependencyDownloader.<>c__DisplayClass9_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiDependencyDownloader.<>c__DisplayClass9_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker",
            "Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker", "OuiFileSelectSlotLevelSetPicker", assemblyIdentity,
            "Celeste", 33557133, false, new string[] { "Celeste.OuiFileSelectSlot+Button", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker+<>c",
            "Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker.<>c", "<>c", assemblyIdentity, "Celeste", 33557134, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiFileSelectSlotLevelSetPicker.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiFileSelectSlotSubmenu",
            "Celeste.Mod.UI.OuiFileSelectSlotSubmenu", "OuiFileSelectSlotSubmenu", assemblyIdentity, "Celeste",
            33557135, true,
            new string[]
            {
                "Celeste.Mod.UI.OuiGenericMenu", "Celeste.OuiFileSelectSlot+ISubmenu", "Celeste.Oui", "Monocle.Entity",
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiFileSelectSlotSubmenu", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiFileSelectSlotSubmenu",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiFileSelectSlotSubmenu+<>c__0`1",
            "Celeste.Mod.UI.OuiFileSelectSlotSubmenu.<>c__0`1", "<>c__0`1", assemblyIdentity, "Celeste", 33557136,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiFileSelectSlotSubmenu.<>c__0`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiFileSelectSlotSubmenu.<>c__0`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiGenericMenu", "Celeste.Mod.UI.OuiGenericMenu",
            "OuiGenericMenu", assemblyIdentity, "Celeste", 33557137, true,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiGenericMenu", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiGenericMenu",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiGenericMenu+<Enter>d__10",
            "Celeste.Mod.UI.OuiGenericMenu.<Enter>d__10", "<Enter>d__10", assemblyIdentity, "Celeste", 33557138, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiGenericMenu.<Enter>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiGenericMenu.<Enter>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiGenericMenu+<Leave>d__11",
            "Celeste.Mod.UI.OuiGenericMenu.<Leave>d__11", "<Leave>d__11", assemblyIdentity, "Celeste", 33557139, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiGenericMenu.<Leave>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiGenericMenu.<Leave>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet",
            "Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet", "OuiHelper_ChapterSelect_LevelSet", assemblyIdentity,
            "Celeste", 33557140, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet+<Enter>d__2",
            "Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet.<Enter>d__2", "<Enter>d__2", assemblyIdentity, "Celeste",
            33557141, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet.<Enter>d__2", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet.<Enter>d__2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet+<Leave>d__3",
            "Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet.<Leave>d__3", "<Leave>d__3", assemblyIdentity, "Celeste",
            33557142, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet.<Leave>d__3", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet.<Leave>d__3",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiHelper_Shutdown", "Celeste.Mod.UI.OuiHelper_Shutdown",
            "OuiHelper_Shutdown", assemblyIdentity, "Celeste", 33557143, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiHelper_Shutdown", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiHelper_Shutdown",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiHelper_Shutdown+<>c",
            "Celeste.Mod.UI.OuiHelper_Shutdown.<>c", "<>c", assemblyIdentity, "Celeste", 33557144, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiHelper_Shutdown.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiHelper_Shutdown.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiHelper_Shutdown+<Enter>d__1",
            "Celeste.Mod.UI.OuiHelper_Shutdown.<Enter>d__1", "<Enter>d__1", assemblyIdentity, "Celeste", 33557145,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiHelper_Shutdown.<Enter>d__1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiHelper_Shutdown.<Enter>d__1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiHelper_Shutdown+<Leave>d__2",
            "Celeste.Mod.UI.OuiHelper_Shutdown.<Leave>d__2", "<Leave>d__2", assemblyIdentity, "Celeste", 33557146,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiHelper_Shutdown.<Leave>d__2", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiHelper_Shutdown.<Leave>d__2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiLoggedProgress", "Celeste.Mod.UI.OuiLoggedProgress",
            "OuiLoggedProgress", assemblyIdentity, "Celeste", 33557147, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiLoggedProgress", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiLoggedProgress",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiLoggedProgress+<Enter>d__21",
            "Celeste.Mod.UI.OuiLoggedProgress.<Enter>d__21", "<Enter>d__21", assemblyIdentity, "Celeste", 33557148,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiLoggedProgress.<Enter>d__21", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiLoggedProgress.<Enter>d__21",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiLoggedProgress+<Leave>d__22",
            "Celeste.Mod.UI.OuiLoggedProgress.<Leave>d__22", "<Leave>d__22", assemblyIdentity, "Celeste", 33557149,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiLoggedProgress.<Leave>d__22", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiLoggedProgress.<Leave>d__22",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapList", "Celeste.Mod.UI.OuiMapList", "OuiMapList",
            assemblyIdentity, "Celeste", 33557150, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapList", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapList+<>c", "Celeste.Mod.UI.OuiMapList.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557151, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapList.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapList.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapList+<>c__DisplayClass12_0",
            "Celeste.Mod.UI.OuiMapList.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste",
            33557152, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapList.<>c__DisplayClass12_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapList.<>c__DisplayClass12_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapList+<Enter>d__15",
            "Celeste.Mod.UI.OuiMapList.<Enter>d__15", "<Enter>d__15", assemblyIdentity, "Celeste", 33557153, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapList.<Enter>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapList.<Enter>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapList+<FadeIn>d__13",
            "Celeste.Mod.UI.OuiMapList.<FadeIn>d__13", "<FadeIn>d__13", assemblyIdentity, "Celeste", 33557154, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapList.<FadeIn>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapList.<FadeIn>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapList+<Leave>d__16",
            "Celeste.Mod.UI.OuiMapList.<Leave>d__16", "<Leave>d__16", assemblyIdentity, "Celeste", 33557155, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapList.<Leave>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapList.<Leave>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapList+<StartRoutine>d__21",
            "Celeste.Mod.UI.OuiMapList.<StartRoutine>d__21", "<StartRoutine>d__21", assemblyIdentity, "Celeste",
            33557156, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapList.<StartRoutine>d__21", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapList.<StartRoutine>d__21",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch", "Celeste.Mod.UI.OuiMapSearch", "OuiMapSearch",
            assemblyIdentity, "Celeste", 33557157, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+SearchMenu",
            "Celeste.Mod.UI.OuiMapSearch.SearchMenu", "SearchMenu", assemblyIdentity, "Celeste", 33557158, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.SearchMenu", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.SearchMenu",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+<>c", "Celeste.Mod.UI.OuiMapSearch.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557159, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+<>c__DisplayClass29_0",
            "Celeste.Mod.UI.OuiMapSearch.<>c__DisplayClass29_0", "<>c__DisplayClass29_0", assemblyIdentity, "Celeste",
            33557160, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.<>c__DisplayClass29_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.<>c__DisplayClass29_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+<>c__DisplayClass29_1",
            "Celeste.Mod.UI.OuiMapSearch.<>c__DisplayClass29_1", "<>c__DisplayClass29_1", assemblyIdentity, "Celeste",
            33557161, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.<>c__DisplayClass29_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.<>c__DisplayClass29_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+<Enter>d__32",
            "Celeste.Mod.UI.OuiMapSearch.<Enter>d__32", "<Enter>d__32", assemblyIdentity, "Celeste", 33557162, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.<Enter>d__32", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.<Enter>d__32",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+<FadeIn>d__30",
            "Celeste.Mod.UI.OuiMapSearch.<FadeIn>d__30", "<FadeIn>d__30", assemblyIdentity, "Celeste", 33557163, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.<FadeIn>d__30", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.<FadeIn>d__30",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+<Leave>d__33",
            "Celeste.Mod.UI.OuiMapSearch.<Leave>d__33", "<Leave>d__33", assemblyIdentity, "Celeste", 33557164, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.<Leave>d__33", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.<Leave>d__33",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiMapSearch+<StartRoutine>d__40",
            "Celeste.Mod.UI.OuiMapSearch.<StartRoutine>d__40", "<StartRoutine>d__40", assemblyIdentity, "Celeste",
            33557165, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiMapSearch.<StartRoutine>d__40", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiMapSearch.<StartRoutine>d__40",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions", "Celeste.Mod.UI.OuiModOptions",
            "OuiModOptions", assemblyIdentity, "Celeste", 33557166, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+ISubmenu",
            "Celeste.Mod.UI.OuiModOptions.ISubmenu", "ISubmenu", assemblyIdentity, "Celeste", 33557167, true,
            Array.Empty<string>(), Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.ISubmenu", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.ISubmenu",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<>c", "Celeste.Mod.UI.OuiModOptions.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557168, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<>c__DisplayClass12_0",
            "Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste",
            33557169, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<>c__DisplayClass12_1",
            "Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_1", "<>c__DisplayClass12_1", assemblyIdentity, "Celeste",
            33557170, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<>c__DisplayClass12_2",
            "Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_2", "<>c__DisplayClass12_2", assemblyIdentity, "Celeste",
            33557171, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass12_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<>c__DisplayClass9_0",
            "Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_0", "<>c__DisplayClass9_0", assemblyIdentity, "Celeste",
            33557172, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<>c__DisplayClass9_1",
            "Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_1", "<>c__DisplayClass9_1", assemblyIdentity, "Celeste",
            33557173, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<>c__DisplayClass9_2",
            "Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_2", "<>c__DisplayClass9_2", assemblyIdentity, "Celeste",
            33557174, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<>c__DisplayClass9_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<Enter>d__13",
            "Celeste.Mod.UI.OuiModOptions.<Enter>d__13", "<Enter>d__13", assemblyIdentity, "Celeste", 33557175, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<Enter>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<Enter>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptions+<Leave>d__14",
            "Celeste.Mod.UI.OuiModOptions.<Leave>d__14", "<Leave>d__14", assemblyIdentity, "Celeste", 33557176, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptions.<Leave>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptions.<Leave>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiTextEntry", "Celeste.Mod.UI.OuiTextEntry", "OuiTextEntry",
            assemblyIdentity, "Celeste", 33557177, false,
            new string[]
            {
                "Celeste.Mod.UI.OuiModOptionString", "Celeste.Oui", "Celeste.Mod.UI.OuiModOptions+ISubmenu",
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiTextEntry", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiTextEntry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptionString", "Celeste.Mod.UI.OuiModOptionString",
            "OuiModOptionString", assemblyIdentity, "Celeste", 33557178, false,
            new string[]
            {
                "Celeste.Oui", "Celeste.Mod.UI.OuiModOptions+ISubmenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptionString", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptionString",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptionString+<>c__DisplayClass51_0`1",
            "Celeste.Mod.UI.OuiModOptionString.<>c__DisplayClass51_0`1", "<>c__DisplayClass51_0`1", assemblyIdentity,
            "Celeste", 33557179, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptionString.<>c__DisplayClass51_0`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptionString.<>c__DisplayClass51_0`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptionString+<Enter>d__53",
            "Celeste.Mod.UI.OuiModOptionString.<Enter>d__53", "<Enter>d__53", assemblyIdentity, "Celeste", 33557180,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptionString.<Enter>d__53", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptionString.<Enter>d__53",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModOptionString+<Leave>d__54",
            "Celeste.Mod.UI.OuiModOptionString.<Leave>d__54", "<Leave>d__54", assemblyIdentity, "Celeste", 33557181,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModOptionString.<Leave>d__54", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModOptionString.<Leave>d__54",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler", "Celeste.Mod.UI.OuiModToggler",
            "OuiModToggler", assemblyIdentity, "Celeste", 33557182, false,
            new string[]
            {
                "Celeste.Mod.UI.OuiGenericMenu", "Celeste.Mod.UI.OuiModOptions+ISubmenu", "Celeste.Oui",
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c", "Celeste.Mod.UI.OuiModToggler.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557183, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass17_0",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_0", "<>c__DisplayClass17_0", assemblyIdentity, "Celeste",
            33557184, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass17_1",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_1", "<>c__DisplayClass17_1", assemblyIdentity, "Celeste",
            33557185, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass17_2",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_2", "<>c__DisplayClass17_2", assemblyIdentity, "Celeste",
            33557186, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass17_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass21_0",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_0", "<>c__DisplayClass21_0", assemblyIdentity, "Celeste",
            33557187, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass21_1",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_1", "<>c__DisplayClass21_1", assemblyIdentity, "Celeste",
            33557188, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass21_2",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_2", "<>c__DisplayClass21_2", assemblyIdentity, "Celeste",
            33557189, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass21_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass22_0",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_0", "<>c__DisplayClass22_0", assemblyIdentity, "Celeste",
            33557190, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass22_1",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_1", "<>c__DisplayClass22_1", assemblyIdentity, "Celeste",
            33557191, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass22_2",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_2", "<>c__DisplayClass22_2", assemblyIdentity, "Celeste",
            33557192, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass22_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass23_0",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass23_0", "<>c__DisplayClass23_0", assemblyIdentity, "Celeste",
            33557193, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass23_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass23_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass27_0",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass27_0", "<>c__DisplayClass27_0", assemblyIdentity, "Celeste",
            33557194, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass27_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass27_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass35_0",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass35_0", "<>c__DisplayClass35_0", assemblyIdentity, "Celeste",
            33557195, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass35_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass35_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<>c__DisplayClass35_1",
            "Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass35_1", "<>c__DisplayClass35_1", assemblyIdentity, "Celeste",
            33557196, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass35_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<>c__DisplayClass35_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModToggler+<Leave>d__37",
            "Celeste.Mod.UI.OuiModToggler.<Leave>d__37", "<Leave>d__37", assemblyIdentity, "Celeste", 33557197, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModToggler.<Leave>d__37", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModToggler.<Leave>d__37",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList", "Celeste.Mod.UI.OuiModUpdateList",
            "OuiModUpdateList", assemblyIdentity, "Celeste", 33557198, false,
            new string[]
            {
                "Celeste.Oui", "Celeste.Mod.UI.OuiModOptions+ISubmenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+ModUpdateHolder",
            "Celeste.Mod.UI.OuiModUpdateList.ModUpdateHolder", "ModUpdateHolder", assemblyIdentity, "Celeste", 33557199,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.ModUpdateHolder", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.ModUpdateHolder",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+<>c", "Celeste.Mod.UI.OuiModUpdateList.<>c",
            "<>c", assemblyIdentity, "Celeste", 33557200, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+<>c__DisplayClass20_0",
            "Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass20_0", "<>c__DisplayClass20_0", assemblyIdentity,
            "Celeste", 33557201, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass20_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass20_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+<>c__DisplayClass20_1",
            "Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass20_1", "<>c__DisplayClass20_1", assemblyIdentity,
            "Celeste", 33557202, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass20_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass20_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+<>c__DisplayClass21_0",
            "Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass21_0", "<>c__DisplayClass21_0", assemblyIdentity,
            "Celeste", 33557203, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass21_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass21_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+<>c__DisplayClass23_0",
            "Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass23_0", "<>c__DisplayClass23_0", assemblyIdentity,
            "Celeste", 33557204, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass23_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.<>c__DisplayClass23_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+<Enter>d__15",
            "Celeste.Mod.UI.OuiModUpdateList.<Enter>d__15", "<Enter>d__15", assemblyIdentity, "Celeste", 33557205,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.<Enter>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.<Enter>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiModUpdateList+<Leave>d__16",
            "Celeste.Mod.UI.OuiModUpdateList.<Leave>d__16", "<Leave>d__16", assemblyIdentity, "Celeste", 33557206,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiModUpdateList.<Leave>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiModUpdateList.<Leave>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiNumberEntry", "Celeste.Mod.UI.OuiNumberEntry",
            "OuiNumberEntry", assemblyIdentity, "Celeste", 33557207, false,
            new string[]
            {
                "Celeste.Oui", "Celeste.Mod.UI.OuiModOptions+ISubmenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiNumberEntry", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiNumberEntry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiNumberEntry+<Enter>d__48",
            "Celeste.Mod.UI.OuiNumberEntry.<Enter>d__48", "<Enter>d__48", assemblyIdentity, "Celeste", 33557208, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiNumberEntry.<Enter>d__48", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiNumberEntry.<Enter>d__48",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiNumberEntry+<Leave>d__49",
            "Celeste.Mod.UI.OuiNumberEntry.<Leave>d__49", "<Leave>d__49", assemblyIdentity, "Celeste", 33557209, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiNumberEntry.<Leave>d__49", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiNumberEntry.<Leave>d__49",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiOOBE", "Celeste.Mod.UI.OuiOOBE", "OuiOOBE",
            assemblyIdentity, "Celeste", 33557210, false,
            new string[]
            {
                "Celeste.Oui", "Celeste.Mod.UI.OuiModOptions+ISubmenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiOOBE", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiOOBE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiOOBE+<>c", "Celeste.Mod.UI.OuiOOBE.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557211, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiOOBE.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiOOBE.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiOOBE+<>c__DisplayClass12_0",
            "Celeste.Mod.UI.OuiOOBE.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste",
            33557212, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiOOBE.<>c__DisplayClass12_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiOOBE.<>c__DisplayClass12_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiOOBE+<Enter>d__16", "Celeste.Mod.UI.OuiOOBE.<Enter>d__16",
            "<Enter>d__16", assemblyIdentity, "Celeste", 33557213, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiOOBE.<Enter>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiOOBE.<Enter>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiOOBE+<FadeBgTo>d__18",
            "Celeste.Mod.UI.OuiOOBE.<FadeBgTo>d__18", "<FadeBgTo>d__18", assemblyIdentity, "Celeste", 33557214, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiOOBE.<FadeBgTo>d__18", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiOOBE.<FadeBgTo>d__18",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiOOBE+<GotoTransition>d__14",
            "Celeste.Mod.UI.OuiOOBE.<GotoTransition>d__14", "<GotoTransition>d__14", assemblyIdentity, "Celeste",
            33557215, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiOOBE.<GotoTransition>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiOOBE.<GotoTransition>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiOOBE+<Leave>d__17", "Celeste.Mod.UI.OuiOOBE.<Leave>d__17",
            "<Leave>d__17", assemblyIdentity, "Celeste", 33557216, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiOOBE.<Leave>d__17", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiOOBE.<Leave>d__17",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiPropertiesAttribute",
            "Celeste.Mod.UI.OuiPropertiesAttribute", "OuiPropertiesAttribute", assemblyIdentity, "Celeste", 33557217,
            false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiPropertiesAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiPropertiesAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiSoundTest", "Celeste.Mod.UI.OuiSoundTest", "OuiSoundTest",
            assemblyIdentity, "Celeste", 33557218, false,
            new string[]
            {
                "Celeste.Oui", "Celeste.Mod.UI.OuiModOptions+ISubmenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiSoundTest", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiSoundTest",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiSoundTest+<>c", "Celeste.Mod.UI.OuiSoundTest.<>c", "<>c",
            assemblyIdentity, "Celeste", 33557219, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiSoundTest.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiSoundTest.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiSoundTest+<>c__DisplayClass30_0",
            "Celeste.Mod.UI.OuiSoundTest.<>c__DisplayClass30_0", "<>c__DisplayClass30_0", assemblyIdentity, "Celeste",
            33557220, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiSoundTest.<>c__DisplayClass30_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiSoundTest.<>c__DisplayClass30_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiSoundTest+<Enter>d__24",
            "Celeste.Mod.UI.OuiSoundTest.<Enter>d__24", "<Enter>d__24", assemblyIdentity, "Celeste", 33557221, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiSoundTest.<Enter>d__24", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiSoundTest.<Enter>d__24",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiSoundTest+<Leave>d__25",
            "Celeste.Mod.UI.OuiSoundTest.<Leave>d__25", "<Leave>d__25", assemblyIdentity, "Celeste", 33557222, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiSoundTest.<Leave>d__25", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiSoundTest.<Leave>d__25",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiVersionList", "Celeste.Mod.UI.OuiVersionList",
            "OuiVersionList", assemblyIdentity, "Celeste", 33557223, false,
            new string[]
            {
                "Celeste.Oui", "Celeste.Mod.UI.OuiModOptions+ISubmenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiVersionList", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiVersionList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiVersionList+<>c__DisplayClass10_0",
            "Celeste.Mod.UI.OuiVersionList.<>c__DisplayClass10_0", "<>c__DisplayClass10_0", assemblyIdentity, "Celeste",
            33557224, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiVersionList.<>c__DisplayClass10_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiVersionList.<>c__DisplayClass10_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiVersionList+<Enter>d__13",
            "Celeste.Mod.UI.OuiVersionList.<Enter>d__13", "<Enter>d__13", assemblyIdentity, "Celeste", 33557225, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiVersionList.<Enter>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiVersionList.<Enter>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiVersionList+<FadeIn>d__11",
            "Celeste.Mod.UI.OuiVersionList.<FadeIn>d__11", "<FadeIn>d__11", assemblyIdentity, "Celeste", 33557226,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiVersionList.<FadeIn>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiVersionList.<FadeIn>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.OuiVersionList+<Leave>d__14",
            "Celeste.Mod.UI.OuiVersionList.<Leave>d__14", "<Leave>d__14", assemblyIdentity, "Celeste", 33557227, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.OuiVersionList.<Leave>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.OuiVersionList.<Leave>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.UI.SubHudRenderer", "Celeste.Mod.UI.SubHudRenderer",
            "SubHudRenderer", assemblyIdentity, "Celeste", 33557228, false,
            new string[] { "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.UI.SubHudRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.UI.SubHudRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.EntityRegistry", "Celeste.Mod.Registry.EntityRegistry",
            "EntityRegistry", assemblyIdentity, "Celeste", 33557229, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.EntityRegistry", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Registry.EntityRegistry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.EntityRegistry+<>c__DisplayClass7_0",
            "Celeste.Mod.Registry.EntityRegistry.<>c__DisplayClass7_0", "<>c__DisplayClass7_0", assemblyIdentity,
            "Celeste", 33557230, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.EntityRegistry.<>c__DisplayClass7_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Registry.EntityRegistry.<>c__DisplayClass7_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.AnimationDecalRegistryHandler",
            "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationDecalRegistryHandler", "AnimationDecalRegistryHandler",
            assemblyIdentity, "Celeste", 33557231, false,
            new string[] { "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.AnimationDecalRegistryHandler", 0,
            true);
        catalog.PublishDeclaredTrackedAliases(
            "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationDecalRegistryHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts(
            "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationSpeedDecalRegistryHandler",
            "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationSpeedDecalRegistryHandler",
            "AnimationSpeedDecalRegistryHandler", assemblyIdentity, "Celeste", 33557232, false,
            new string[] { "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts(
            "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationSpeedDecalRegistryHandler", 0, true);
        catalog.PublishDeclaredTrackedAliases(
            "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationSpeedDecalRegistryHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler",
            "Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler", "BannerDecalRegistryHandler",
            assemblyIdentity, "Celeste", 33557233, false,
            new string[] { "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler", 0,
            true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
