using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishInstalled214(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 385878597, "DetourConfig",
                SourceMemberKind.Property, 0, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 385878598, "HookConfig",
                SourceMemberKind.Property,
                0, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 385878599, "ILHookConfig",
                SourceMemberKind.Property, 0, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 385878600, "IsValid",
                SourceMemberKind.Property, 0,
                "System.Boolean", 2179, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+ReorgContext", 33557332, 1048835,
                "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                "MonoMod.RuntimeDetour.DetourContext", [], [],
                null,
                [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.RuntimeDetour.DetourContext"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+ReorgContext", 67123882, "LegacyDetourContext",
                SourceMemberKind.Field, 38, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 33557333, 1057027,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 67123883, "<>9", SourceMemberKind.Field,
                54,
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 67123884, "<>9__8_0",
                SourceMemberKind.Field,
                22, "System.Predicate`1<Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Predicate`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 67123885, "<>9__28_1",
                SourceMemberKind.Field,
                22, "System.Func`2<System.Reflection.MethodBase,System.Boolean>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c__DisplayClass28_0", 33557334, 1048835,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c__DisplayClass28_0", 67123886, "stack",
                SourceMemberKind.Field, 6, "System.Diagnostics.StackTrace", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Diagnostics.StackTrace")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 1048961,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute",
                        "System.Void System.Runtime.CompilerServices.ExtensionAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x22, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72,
                            0x48,
                            0x65, 0x6C, 0x70, 0x65, 0x72, 0x00, 0x00,
                        ]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 67123887, "Exception_ctor",
                SourceMemberKind.Field,
                49, "System.Reflection.ConstructorInfo", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.ConstructorInfo")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 33557336, 1048843,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.ValueType"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 67123888, "_Trackers",
                SourceMemberKind.Field, 49,
                "System.Collections.Concurrent.ConcurrentDictionary`2<System.Reflection.MethodBase,Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Concurrent.ConcurrentDictionary`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 67123889, "LOCK",
                SourceMemberKind.Field, 33, "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 67123890, "Method",
                SourceMemberKind.Field, 38, "System.Reflection.MethodBase", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 67123891, "pinCount",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 67123892, "pinDisposable",
                SourceMemberKind.Field, 1, "System.IDisposable", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IDisposable")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c", 33557337, 1057027,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c", 67123893, "<>9",
                SourceMemberKind.Field, 54, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c", 67123894, "<>9__1_0",
                SourceMemberKind.Field, 22,
                "System.Func`2<System.Reflection.MethodBase,Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker>",
                -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte[])",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 33557338, 1048960,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 67123895, "DynamicData_Cache",
                SourceMemberKind.Field, 49, "System.Type", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Type")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 67123896, "Cache_Setters",
                SourceMemberKind.Field, 49, "System.Reflection.FieldInfo", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.FieldInfo")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 67123897, "cacheCtorHook",
                SourceMemberKind.Field, 17, "MonoMod.RuntimeDetour.Hook", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.RuntimeDetour.Hook")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 33557339, 1057027,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 67123898, "<>9",
                SourceMemberKind.Field, 54, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 67123899, "<>9__6_0",
                SourceMemberKind.Field, 22, "System.Func`2<System.Diagnostics.StackFrame,System.Reflection.MethodBase>",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.StackFrame"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 67123900, "<>9__6_1",
                SourceMemberKind.Field, 22, "System.Func`2<System.Reflection.MethodBase,System.Boolean>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_0", 33557340,
                1048835,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_0", 67123901,
                "field",
                SourceMemberKind.Field, 6, "System.Reflection.FieldInfo", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.FieldInfo")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_0", 67123902,
                "setter",
                SourceMemberKind.Field, 6, "System.Action`2<System.Object,System.Object>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Action`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_1", 33557341,
                1048835,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_1", 67123903, "prop",
                SourceMemberKind.Field, 6, "System.Reflection.PropertyInfo", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.PropertyInfo")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_1", 67123904,
                "setter",
                SourceMemberKind.Field, 6, "System.Action`2<System.Object,System.Object>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Action`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate", 33557342, 257,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.MulticastDelegate", [],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x55, 0x74, 0x69, 0x6C,
                            0x73,
                            0x2E, 0x46, 0x61, 0x73, 0x74, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E,
                            0x44,
                            0x65, 0x6C, 0x65, 0x67, 0x61, 0x74, 0x65, 0x00, 0x00,
                        ]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.MulticastDelegate"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 33557343, 1048961,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute",
                        "System.Void System.Runtime.CompilerServices.ExtensionAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x22, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x55, 0x74, 0x69, 0x6C,
                            0x73,
                            0x2E, 0x46, 0x61, 0x73, 0x74, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E,
                            0x48,
                            0x65, 0x6C, 0x70, 0x65, 0x72, 0x00, 0x00,
                        ]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 67123905, "_DynamicMethodDelegateArgs",
                SourceMemberKind.Field, 49, "System.Type[]", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Type"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 67123906, "_MethodCache",
                SourceMemberKind.Field, 49,
                "System.Collections.Generic.Dictionary`2<System.Reflection.MethodInfo,Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.Dictionary`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 33557344, 1048841,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ValueType",
                [],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x20, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x48, 0x6F, 0x6F, 0x6B, 0x43, 0x6F,
                            0x6E,
                            0x66, 0x69, 0x67, 0x00, 0x00,
                        ]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.ValueType"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 67123907, "ManualApply", SourceMemberKind.Field,
                6,
                "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 67123908, "Priority", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 67123909, "ID", SourceMemberKind.Field, 6,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 67123910, "Before", SourceMemberKind.Field, 6,
                "System.Collections.Generic.IEnumerable`1<System.String>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 67123911, "After", SourceMemberKind.Field, 6,
                "System.Collections.Generic.IEnumerable`1<System.String>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 1048577,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                ["Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable"],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1A, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x48, 0x6F, 0x6F, 0x6B, 0x00, 0x00,
                        ]),
                ], null,
                [
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123912, "OnDetour", SourceMemberKind.Field, 22,
                "System.Func`5<Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook,System.Reflection.MethodBase,System.Reflection.MethodBase,System.Object,System.Boolean>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`5"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123913, "OnUndo", SourceMemberKind.Field, 22,
                "System.Func`2<Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook,System.Boolean>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123914, "OnGenerateTrampoline",
                SourceMemberKind.Field,
                22,
                "System.Func`3<Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook,System.Reflection.MethodBase,System.Reflection.MethodBase>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`3"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123915, "Method", SourceMemberKind.Field, 38,
                "System.Reflection.MethodBase", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123916, "Target", SourceMemberKind.Field, 38,
                "System.Reflection.MethodBase", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123917, "TargetReal", SourceMemberKind.Field, 38,
                "System.Reflection.MethodBase", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123918, "DelegateTarget", SourceMemberKind.Field, 38,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123919, "_Detour", SourceMemberKind.Field, 1,
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123920, "_OrigDelegateType", SourceMemberKind.Field,
                33,
                "System.Type", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Type")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123921, "_OrigDelegateInvoke", SourceMemberKind.Field,
                33,
                "System.Reflection.MethodInfo", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodInfo")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123922, "_RefTargetCell", SourceMemberKind.Field, 1,
                "System.Nullable`1<MonoMod.Utils.DataScope`1<MonoMod.Utils.DynamicReferenceCell>>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                                "MonoMod.Utils.DataScope`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                                    "MonoMod.Utils.DynamicReferenceCell"),
                            ]),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123923, "_RefTrampolineCell", SourceMemberKind.Field,
                1,
                "System.Nullable`1<MonoMod.Utils.DataScope`1<MonoMod.Utils.DynamicReferenceCell>>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                                "MonoMod.Utils.DataScope`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                                    "MonoMod.Utils.DynamicReferenceCell"),
                            ]),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 67123924, "_RefTrampolineTmpCell",
                SourceMemberKind.Field,
                1, "System.Nullable`1<MonoMod.Utils.DataScope`1<MonoMod.Utils.DynamicReferenceCell>>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                                "MonoMod.Utils.DataScope`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                                    "MonoMod.Utils.DynamicReferenceCell"),
                            ]),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 385878601, "IsValid", SourceMemberKind.Property, 0,
                "System.Boolean", 2534, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 385878602, "IsApplied", SourceMemberKind.Property, 0,
                "System.Boolean", 2534, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 385878603, "Detour", SourceMemberKind.Property, 0,
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 385878604, "_RefTarget", SourceMemberKind.Property, 0,
                "System.Nullable`1<System.Int32>", 2177, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 385878605, "_RefTrampoline", SourceMemberKind.Property,
                0,
                "System.Nullable`1<System.Int32>", 2177, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 385878606, "_RefTrampolineTmp",
                SourceMemberKind.Property,
                0, "System.Nullable`1<System.Int32>", 2177, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", [],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1C, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x48, 0x6F, 0x6F, 0x6B, 0x60, 0x31,
                            0x00,
                            0x00,
                        ]),
                ], null, [],
                [
                    new("T", 0, 704643519, 0, [],
                        []),
                ],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 33557347, 1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", [],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1C, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x48, 0x6F, 0x6F, 0x6B, 0x60, 0x32,
                            0x00,
                            0x00,
                        ]),
                ], null, [],
                [
                    new("TFrom", 0, 704643520, 0,
                        [],
                        []),
                    new("TTo", 1, 704643521, 0, [],
                        []),
                ],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 1048961,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x31, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x48, 0x6F, 0x6F, 0x6B, 0x47, 0x65,
                            0x6E,
                            0x2E, 0x48, 0x6F, 0x6F, 0x6B, 0x45, 0x6E, 0x64, 0x70, 0x6F, 0x69, 0x6E, 0x74, 0x4D, 0x61,
                            0x6E,
                            0x61, 0x67, 0x65, 0x72, 0x00, 0x00,
                        ]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 67123925, "Hooks",
                SourceMemberKind.Field,
                17,
                "System.Collections.Concurrent.ConcurrentDictionary`2<System.ValueTuple`2<System.Reflection.MethodBase,System.Delegate>,MonoMod.RuntimeDetour.Hook>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Concurrent.ConcurrentDictionary`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ValueTuple`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Reflection.MethodBase"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Delegate"),
                            ]),
                        new(
                            SourceTypeReferenceKind.Named,
                            "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.RuntimeDetour.Hook"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 67123926, "ILHooks",
                SourceMemberKind.Field,
                17,
                "System.Collections.Concurrent.ConcurrentDictionary`2<System.ValueTuple`2<System.Reflection.MethodBase,System.Delegate>,MonoMod.RuntimeDetour.ILHook>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Concurrent.ConcurrentDictionary`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ValueTuple`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Reflection.MethodBase"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Delegate"),
                            ]),
                        new(
                            SourceTypeReferenceKind.Named,
                            "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.RuntimeDetour.ILHook"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c", 33557349, 1057027,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c", 67123927, "<>9",
                SourceMemberKind.Field,
                54, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c", 67123928, "<>9__3_0",
                SourceMemberKind.Field, 22, "System.Func`2<System.Reflection.CustomAttributeData,System.Boolean>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.CustomAttributeData"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 1048737, null, null,
                ["System.IDisposable"],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1D, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x49, 0x44, 0x65, 0x74, 0x6F, 0x75,
                            0x72,
                            0x00, 0x00,
                        ]),
                ], null,
                ["System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"],
                [], null,
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 385878607, "IsValid", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 385878608, "IsApplied", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 33557351, 1048737, null, null,
                ["Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable"],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x25, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x49, 0x53, 0x6F, 0x72, 0x74, 0x61,
                            0x62,
                            0x6C, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x00, 0x00,
                        ]),
                ], null,
                [
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                ], [], null,
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 385878609, "GlobalIndex",
                SourceMemberKind.Property, 0, "System.UInt32", 3526, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 385878610, "Priority",
                SourceMemberKind.Property,
                0, "System.Int32", 3526, 3526, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 385878611, "ID", SourceMemberKind.Property,
                0,
                "System.String", 3526, 3526, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 385878612, "Before",
                SourceMemberKind.Property,
                0, "System.Collections.Generic.IEnumerable`1<System.String>", 3526, 3526, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 385878613, "After",
                SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<System.String>", 3526, 3526, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 33557352, 1048841,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ValueType",
                [],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x22, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x49, 0x4C, 0x48, 0x6F, 0x6F, 0x6B,
                            0x43,
                            0x6F, 0x6E, 0x66, 0x69, 0x67, 0x00, 0x00,
                        ]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.ValueType"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 67123929, "ManualApply", SourceMemberKind.Field,
                6,
                "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 67123930, "Priority", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 67123931, "ID", SourceMemberKind.Field, 6,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 67123932, "Before", SourceMemberKind.Field, 6,
                "System.Collections.Generic.IEnumerable`1<System.String>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 67123933, "After", SourceMemberKind.Field, 6,
                "System.Collections.Generic.IEnumerable`1<System.String>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", 33557353, 1048577,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour",
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable",
                ],
                [
                    new("MonoMod.RelinkLegacyMonoMod",
                        "System.Void MonoMod.RelinkLegacyMonoMod::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1C, 0x4D, 0x6F, 0x6E, 0x6F, 0x4D, 0x6F, 0x64, 0x2E, 0x52, 0x75, 0x6E, 0x74,
                            0x69,
                            0x6D, 0x65, 0x44, 0x65, 0x74, 0x6F, 0x75, 0x72, 0x2E, 0x49, 0x4C, 0x48, 0x6F, 0x6F, 0x6B,
                            0x00,
                            0x00,
                        ]),
                ], null,
                [
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", 67123934, "OnDetour", SourceMemberKind.Field, 22,
                "System.Func`4<Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook,System.Reflection.MethodBase,MonoMod.Cil.ILContext+Manipulator,System.Boolean>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`4"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.Cil.ILContext+Manipulator"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", 67123935, "OnUndo", SourceMemberKind.Field, 22,
                "System.Func`2<Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook,System.Boolean>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Func`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", 67123936, "ILDetourConfig", SourceMemberKind.Field,
                17,
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", 67123937, "_GlobalIndexNext", SourceMemberKind.Field,
                17,
                "System.UInt32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", 67123938, "actualHook", SourceMemberKind.Field, 1,
                "MonoMod.RuntimeDetour.ILHook", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.RuntimeDetour.ILHook")));
        }
    }
}
