using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishInstalled110(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680897, "get_ID", 2182, "20000E",
                (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680898, "set_ID", 2182,
                "2001010E",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233763),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680899, "get_DetourConfig", 2182,
                "200011AD40", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig"), true, 20, 62));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680900, "get_HookConfig", 2182,
                "200011AD80", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), true, 20, 62));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680901, "get_ILHookConfig", 2182,
                "200011ADA0", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig"), true, 20, 62));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680902, "get_IsValid", 2179,
                "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 39, 80));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680903, "GetCurrentDetourConfig",
                150,
                "0002128B550202", (KeyValuePair<string, string>[])[], "MonoMod.RuntimeDetour.DetourConfig",
                ["System.Boolean", "System.Boolean"], 0,
                [
                    new("forILHook", 0, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134233764),
                    new("legacyDefault", 1, 0, "System.Boolean", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134233765),
                ], "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.RuntimeDetour.DetourConfig"), true, 59, 159));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680904,
                "CreateLegacyDetourConfig",
                147, "0006128B550E081512808D010E1512808D010E0902", (KeyValuePair<string, string>[])[],
                "MonoMod.RuntimeDetour.DetourConfig",
                [
                    "System.String", "System.Int32", "System.Collections.Generic.IEnumerable`1<System.String>",
                    "System.Collections.Generic.IEnumerable`1<System.String>", "System.UInt32", "System.Boolean",
                ], 0,
                [
                    new("id", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233766),
                    new("prio", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134233767),
                    new("before", 2, 0,
                        "System.Collections.Generic.IEnumerable`1<System.String>", false, null, [],
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
                            ]), 3, 134233768),
                    new("after", 3, 0,
                        "System.Collections.Generic.IEnumerable`1<System.String>", false, null, [],
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
                            ]), 4, 134233769),
                    new("globalIdx", 4, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 5, 134233770),
                    new("flipOrder", 5, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 6, 134233771),
                ], "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.RuntimeDetour.DetourConfig"), true, 85, 217));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680905, ".ctor", 6278,
                "200201080E",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Int32", "System.String"], 0,
                [
                    new("prio", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134233772),
                    new("id", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233773),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 91, 255));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680906, ".ctor", 6278, "2001010E",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.String"], 0,
                [
                    new("id", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233774),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680907, ".ctor", 6278, "20010108",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Int32"], 0,
                [
                    new("priority", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134233775),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680908, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 33557331, 100680909, "Dispose", 486, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 24, 59));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+ReorgContext", 33557332, 100680910, ".ctor",
                6278,
                "20010112AD4C", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext"], 0,
                [
                    new("legacyDetourCtx", 0, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext"), 1, 134233776),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+ReorgContext", 33557332, 100680911,
                "GetLegacyDetourConfig", 134, "2002128B550902", (KeyValuePair<string, string>[])[],
                "MonoMod.RuntimeDetour.DetourConfig", ["System.UInt32", "System.Boolean"], 0,
                [
                    new("globalIdx", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134233777),
                    new("flipOrder", 1, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134233778),
                ], "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.RuntimeDetour.DetourConfig"), true, 16, 52));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+ReorgContext", 33557332, 100680912,
                "TryGetConfig",
                196, "20010210128B55", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["MonoMod.RuntimeDetour.DetourConfig&"], 0,
                [
                    new("config", 0, 2, "MonoMod.RuntimeDetour.DetourConfig&", false,
                        null,
                        [], "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                                "MonoMod.RuntimeDetour.DetourConfig")), 1, 134233779),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 8, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+ReorgContext", 33557332, 100680913,
                "TryGetFactory",
                196, "20010210128B5D", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["MonoMod.Core.IDetourFactory&"], 0,
                [
                    new("factory", 0, 2, "MonoMod.Core.IDetourFactory&", false, null,
                        [], "MonoMod.Core, Version=1.3.1.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "MonoMod.Core, Version=1.3.1.0, Culture=neutral, PublicKeyToken=null",
                                "MonoMod.Core.IDetourFactory")), 1, 134233780),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 5));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 33557333, 100680914, ".cctor", 6289,
                "000001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 33557333, 100680915, ".ctor", 6278,
                "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 33557333, 100680916, "<get_Current>b__8_0",
                131, "20010212AD4C", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext"], 0,
                [
                    new("ctx", 0, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext"), 1, 134233781),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c", 33557333, 100680917, "<.ctor>b__28_1", 131,
                "2001021281F5", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("m", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233782),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c__DisplayClass28_0", 33557334, 100680918,
                ".ctor",
                6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c__DisplayClass28_0", 33557334, 100680919,
                "<.ctor>b__0", 131, "20011281F508", (KeyValuePair<string, string>[])[],
                "System.Reflection.MethodBase",
                ["System.Int32"], 0,
                [
                    new("i", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134233783),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680920, "Write", 150,
                "00030118100805",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.IntPtr", "System.Int32&", "System.Byte"], 0,
                [
                    new("to", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134233784),
                    new("offs", 1, 0, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134233785),
                    new("value", 2, 0, "System.Byte", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Byte"), 3, 134233786),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 23, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680921, "Write", 150,
                "00030118100807",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.IntPtr", "System.Int32&", "System.UInt16"], 0,
                [
                    new("to", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134233787),
                    new("offs", 1, 0, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134233788),
                    new("value", 2, 0, "System.UInt16", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt16"), 3, 134233789),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680922, "Write", 150,
                "00030118100809",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.IntPtr", "System.Int32&", "System.UInt32"], 0,
                [
                    new("to", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134233790),
                    new("offs", 1, 0, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134233791),
                    new("value", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134233792),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680923, "Write", 150,
                "0003011810080B",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.IntPtr", "System.Int32&", "System.UInt64"], 0,
                [
                    new("to", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134233793),
                    new("offs", 1, 0, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134233794),
                    new("value", 2, 0, "System.UInt64", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"), 3, 134233795),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680924, "GetIdentifiable", 150,
                "00011281F51281F5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Reflection.MethodBase", ["System.Reflection.MethodBase"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233796),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680925, "GetNativeStart", 150,
                "0001181281F5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.IntPtr", ["System.Reflection.MethodBase"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233797),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680926, "GetNativeStart", 150,
                "000118128229",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.IntPtr", ["System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233798),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680927, "GetNativeStart", 150,
                "000118128B49",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.IntPtr", ["System.Linq.Expressions.Expression"], 0,
                [
                    new("method", 0, 0, "System.Linq.Expressions.Expression", false,
                        null,
                        [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions.Expression"), 1, 134233799),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680928, "CreateILCopy", 150,
                "00011281A51281F5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Reflection.MethodInfo", ["System.Reflection.MethodBase"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233800),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodInfo"), true, 15, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680929, "TryCreateILCopy", 150,
                "0002021281F5101281A5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["System.Reflection.MethodBase", "System.Reflection.MethodInfo&"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233801),
                    new("dm", 1, 2, "System.Reflection.MethodInfo&", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Reflection.MethodInfo")), 2, 134233802),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 34, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680930, "Pin", 150,
                "1001011E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["T"], 1,
                [
                    new("method", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper",
                            ownerMethodDefinitionToken: 100680930), 1, 134233803),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper",
                    ownerMethodDefinitionToken: 100680930), true, 8, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680931, "Unpin", 150,
                "1001011E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["T"], 1,
                [
                    new("method", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper",
                            ownerMethodDefinitionToken: 100680931), 1, 134233804),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper",
                    ownerMethodDefinitionToken: 100680931), true, 8, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680932, "GenerateNativeProxy", 150,
                "00021281A5181281F5", (KeyValuePair<string, string>[])[], "System.Reflection.MethodInfo",
                ["System.IntPtr", "System.Reflection.MethodBase"], 0,
                [
                    new("target", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134233805),
                    new("signature", 1, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 2, 134233806),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodInfo"), true, 80, 193));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680933, "StubCriticalDetour", 150,
                "0001128889128889",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "MonoMod.Utils.DynamicMethodDefinition", ["MonoMod.Utils.DynamicMethodDefinition"], 0,
                [
                    new("dmd", 0, 0, "MonoMod.Utils.DynamicMethodDefinition", false,
                        null,
                        [], "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.Utils.DynamicMethodDefinition"), 1, 134233807),
                ], "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.Utils.DynamicMethodDefinition"), true, 40, 115));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 33557335, 100680934, ".cctor", 6289, "000001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 50));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 33557336, 100680935,
                "GetTracker",
                150, "000111AD601281F5", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233808),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker"), true, 13, 43));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 33557336, 100680936, ".ctor",
                6273,
                "2001011281F5", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233809),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 33557336, 100680937, "Pin",
                134,
                "20001281F5", (KeyValuePair<string, string>[])[], "System.Reflection.MethodBase", [],
                0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase"), true, 34, 82));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 33557336, 100680938, "Unpin",
                134,
                "20001281F5", (KeyValuePair<string, string>[])[], "System.Reflection.MethodBase", [],
                0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase"), true, 55, 141));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker", 33557336, 100680939, ".cctor",
                6289, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c", 33557337, 100680940,
                ".cctor",
                6289, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c", 33557337, 100680941,
                ".ctor",
                6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c", 33557337, 100680942,
                "<GetTracker>b__1_0", 131, "200111AD601281F5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "0100010000"),
                ], "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("m", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233810),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 33557338, 100680943, "InstallHook",
                150,
                "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 62));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 33557338, 100680944, "UninstallHook",
                150,
                "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 33557338, 100680945, "CacheCtorHook",
                145,
                "000301151285F1021C1280D11C1280D1", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Action`2<System.Object,System.Type>", "System.Object", "System.Type"], 0,
                [
                    new("orig", 0, 0, "System.Action`2<System.Object,System.Type>",
                        false,
                        null, [],
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
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Type"),
                            ]), 1, 134233811),
                    new("cache", 1, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 2, 134233812),
                    new("targetType", 2, 0, "System.Type", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Type"), 3, 134233813),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 105, 272));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 33557338, 100680946,
                "CheckTypeMismatch",
                145, "00031C1C1280D112838D", (KeyValuePair<string, string>[])[], "System.Object",
                ["System.Object", "System.Type", "System.Reflection.MemberInfo"], 0,
                [
                    new("val", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134233814),
                    new("valType", 1, 0, "System.Type", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Type"), 2, 134233815),
                    new("memb", 2, 0, "System.Reflection.MemberInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MemberInfo"), 3, 134233816),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 104, 310));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 33557338, 100680947, ".cctor", 6289,
                "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 48));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 33557339, 100680948, ".cctor",
                6289,
                "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 33557339, 100680949, ".ctor",
                6278,
                "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 33557339, 100680950,
                "<CheckTypeMismatch>b__6_0", 131, "20011281F5128761", (KeyValuePair<string, string>[])[],
                "System.Reflection.MethodBase", ["System.Diagnostics.StackFrame"], 0,
                [
                    new("f", 0, 0, "System.Diagnostics.StackFrame", false, null,
                        [],
                        "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.StackFrame"), 1, 134233817),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c", 33557339, 100680951,
                "<CheckTypeMismatch>b__6_1", 131, "2001021281F5", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("m", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233818),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_0", 33557340,
                100680952,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_0", 33557340,
                100680953,
                "<CacheCtorHook>b__0", 131, "2002011C1C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134233819),
                    new("val", 1, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 2, 134233820),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_1", 33557341,
                100680954,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_1", 33557341,
                100680955,
                "<CacheCtorHook>b__1", 131, "2002011C1C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134233821),
                    new("val", 1, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 2, 134233822),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate", 33557342, 100680956, ".ctor", 6278,
                "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134233823),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233824),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate", 33557342, 100680957, "Invoke", 454,
                "20021C1C1D1C", (KeyValuePair<string, string>[])[], "System.Object",
                ["System.Object", "System.Object[]"], 0,
                [
                    new("target", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134233825),
                    new("args", 1, 0, "System.Object[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134233826),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate", 33557342, 100680958, "BeginInvoke",
                454,
                "20041286311C1D1C1286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["System.Object", "System.Object[]", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("target", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134233827),
                    new("args", 1, 0, "System.Object[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134233828),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134233829),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134233830),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate", 33557342, 100680959, "EndInvoke", 454,
                "20011C128631", (KeyValuePair<string, string>[])[], "System.Object",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134233831),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 33557343, 100680960,
                "_CreateFastDelegate",
                145, "000212AD781281F502", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate",
                ["System.Reflection.MethodBase", "System.Boolean"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233832),
                    new("directBoxValueAccess", 1, 4112, "System.Boolean", true,
                        "System.Boolean", /* ReSharper disable once UseUtf8StringLiteral */ [0x01],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134233833),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate"), true, 215, 665));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 33557343, 100680961,
                "CreateFastDelegate",
                150, "000212AD781281A502",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate",
                ["System.Reflection.MethodInfo", "System.Boolean"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 1, 134233834),
                    new("directBoxValueAccess", 1, 4112, "System.Boolean", true,
                        "System.Boolean", /* ReSharper disable once UseUtf8StringLiteral */ [0x01],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134233835),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 33557343, 100680962, "GetFastDelegate",
                150,
                "000212AD781281A502",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate",
                ["System.Reflection.MethodInfo", "System.Boolean"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 1, 134233836),
                    new("directBoxValueAccess", 1, 4112, "System.Boolean", true,
                        "System.Boolean", /* ReSharper disable once UseUtf8StringLiteral */ [0x01],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134233837),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate"), true, 17, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 33557343, 100680963, ".cctor", 6289,
                "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 16, 48));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680964, "get_IsValid", 2534, "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680965, "get_IsApplied", 2534, "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680966, "get_Detour", 2182, "200012AD44",
                (KeyValuePair<string, string>[])[], "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour",
                [],
                0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680967, "get__RefTarget", 2177,
                "2000151181410108", (KeyValuePair<string, string>[])[], "System.Nullable`1<System.Int32>",
                [], 0, [],
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
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"),
                    ]), true, 19, 52));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680968, "get__RefTrampoline", 2177,
                "2000151181410108", (KeyValuePair<string, string>[])[], "System.Nullable`1<System.Int32>",
                [], 0, [],
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
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"),
                    ]), true, 19, 52));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680969, "get__RefTrampolineTmp", 2177,
                "2000151181410108", (KeyValuePair<string, string>[])[], "System.Nullable`1<System.Int32>",
                [], 0, [],
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
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"),
                    ]), true, 19, 52));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680970, ".ctor", 6278,
                "2004011281F51281A51C1011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.Reflection.MethodInfo", "System.Object",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233838),
                    new("to", 1, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 2, 134233839),
                    new("target", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134233840),
                    new("config", 3, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 4, 134233841),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 580, 1524));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680971, ".ctor", 6278,
                "2004011281F51281A51C11AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.Reflection.MethodInfo", "System.Object",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233842),
                    new("to", 1, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 2, 134233843),
                    new("target", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134233844),
                    new("config", 3, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 4, 134233845),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680972, ".ctor", 6278,
                "2003011281F51281A51C",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Reflection.MethodInfo", "System.Object"], 0,
                [
                    new("from", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233846),
                    new("to", 1, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 2, 134233847),
                    new("target", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134233848),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680973, ".ctor", 6278,
                "2003011281F51281A51011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.Reflection.MethodInfo",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233849),
                    new("to", 1, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 2, 134233850),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233851),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680974, ".ctor", 6278,
                "2003011281F51281A511AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.Reflection.MethodInfo",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233852),
                    new("to", 1, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 2, 134233853),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233854),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680975, ".ctor", 6278,
                "2002011281F51281A5",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Reflection.MethodInfo"], 0,
                [
                    new("from", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233855),
                    new("to", 1, 0, "System.Reflection.MethodInfo", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodInfo"), 2, 134233856),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 10));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680976, ".ctor", 6278,
                "2003011281F5181011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233857),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233858),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233859),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680977, ".ctor", 6278,
                "2003011281F51811AD80",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233860),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233861),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233862),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680978, ".ctor", 6278, "2002011281F518",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.IntPtr"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233863),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233864),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680979, ".ctor", 6278,
                "2003011281F51282291011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233865),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233866),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233867),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680980, ".ctor", 6278,
                "2003011281F512822911AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Reflection.MethodBase", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233868),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233869),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233870),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680981, ".ctor", 6278,
                "2002011281F5128229",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233871),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233872),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680982, ".ctor", 6278,
                "200301128229181011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Delegate", "System.IntPtr", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&"],
                0,
                [
                    new("from", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233873),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233874),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233875),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680983, ".ctor", 6278,
                "2003011282291811AD80",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Delegate", "System.IntPtr", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"],
                0,
                [
                    new("from", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233876),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233877),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233878),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680984, ".ctor", 6278, "20020112822918",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Delegate", "System.IntPtr"],
                0,
                [
                    new("from", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233879),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233880),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680985, ".ctor", 6278,
                "2003011282291282291011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Delegate", "System.Delegate", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&"], 0,
                [
                    new("from", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233881),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233882),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233883),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680986, ".ctor", 6278,
                "20030112822912822911AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Delegate", "System.Delegate", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"],
                0,
                [
                    new("from", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233884),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233885),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233886),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680987, ".ctor", 6278,
                "200201128229128229",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Delegate", "System.Delegate"], 0,
                [
                    new("from", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233887),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233888),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680988, ".ctor", 6278,
                "200301128B49181011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0, "System.Linq.Expressions.Expression", false, null,
                        [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions.Expression"), 1, 134233889),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233890),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233891),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680989, ".ctor", 6278,
                "200301128B491811AD80",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0, "System.Linq.Expressions.Expression", false, null,
                        [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions.Expression"), 1, 134233892),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233893),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233894),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680990, ".ctor", 6278, "200201128B4918",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression", "System.IntPtr"], 0,
                [
                    new("from", 0, 0, "System.Linq.Expressions.Expression", false, null,
                        [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions.Expression"), 1, 134233895),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233896),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680991, ".ctor", 6278,
                "200301128B491282291011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0, "System.Linq.Expressions.Expression", false, null,
                        [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions.Expression"), 1, 134233897),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233898),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233899),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680992, ".ctor", 6278,
                "200301128B4912822911AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0, "System.Linq.Expressions.Expression", false, null,
                        [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions.Expression"), 1, 134233900),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233901),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233902),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680993, ".ctor", 6278,
                "200201128B49128229",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression", "System.Delegate"], 0,
                [
                    new("from", 0, 0, "System.Linq.Expressions.Expression", false, null,
                        [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions.Expression"), 1, 134233903),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233904),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680994, ".ctor", 6278,
                "20030115128B5101128149181011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Action>", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233905),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233906),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233907),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680995, ".ctor", 6278,
                "20030115128B51011281491811AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Action>", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233908),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233909),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233910),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680996, ".ctor", 6278,
                "20020115128B510112814918", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression`1<System.Action>", "System.IntPtr"], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233911),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233912),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680997, ".ctor", 6278,
                "20030115128B51011281491282291011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Action>", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233913),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233914),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233915),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680998, ".ctor", 6278,
                "20030115128B510112814912822911AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Action>", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233916),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233917),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233918),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100680999, ".ctor", 6278,
                "20020115128B5101128149128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression`1<System.Action>", "System.Delegate"], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233919),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233920),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681000, "Dispose", 486, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681001, "Apply", 486, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 43, 96));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681002, "Undo", 486, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 33, 83));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681003, "Free", 486, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681004, "_Free", 129, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 34, 90));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681005, "GenerateTrampoline", 486,
                "20011281F51281F5", (KeyValuePair<string, string>[])[], "System.Reflection.MethodBase",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("signature", 0, 4112, "System.Reflection.MethodBase", true,
                        null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233921),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase"), true, 29, 56));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681006, "GenerateTrampoline", 486,
                "3001001E00", (KeyValuePair<string, string>[])[], "T", [], 1,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook",
                    ownerMethodDefinitionToken: 100681006), true, 36, 143));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 33557345, 100681007, "_UpdateOrig", 131, "2001011281F5",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Reflection.MethodBase"], 0,
                [
                    new("invoke", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233922),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 35, 97));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681008, ".ctor", 6278,
                "20030115128B510112814913001011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Action>", "T",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233923),
                    new("to", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 2, 134233924),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233925),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681009, ".ctor", 6278,
                "20030115128B5101128149130011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Action>", "T",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233926),
                    new("to", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 2, 134233927),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233928),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681010, ".ctor", 6278,
                "20020115128B51011281491300", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression`1<System.Action>", "T"], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Action>",
                        false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Action"),
                            ]), 1, 134233929),
                    new("to", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 2, 134233930),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681011, ".ctor", 6278,
                "20030115128B510115128175011300181011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Func`1<T>>", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<T>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"),
                                    ]),
                            ]), 1, 134233931),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233932),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233933),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681012, ".ctor", 6278,
                "20030115128B5101151281750113001811AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Func`1<T>>", "System.IntPtr",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<T>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"),
                                    ]),
                            ]), 1, 134233934),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233935),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233936),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681013, ".ctor", 6278,
                "20020115128B51011512817501130018", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression`1<System.Func`1<T>>", "System.IntPtr"], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<T>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"),
                                    ]),
                            ]), 1, 134233937),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233938),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681014, ".ctor", 6278,
                "20030115128B5101151281750113001282291011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Func`1<T>>", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<T>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"),
                                    ]),
                            ]), 1, 134233939),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233940),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233941),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681015, ".ctor", 6278,
                "20030115128B51011512817501130012822911AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Func`1<T>>", "System.Delegate",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<T>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"),
                                    ]),
                            ]), 1, 134233942),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233943),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233944),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681016, ".ctor", 6278,
                "20020115128B510115128175011300128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression`1<System.Func`1<T>>", "System.Delegate"], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<T>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"),
                                    ]),
                            ]), 1, 134233945),
                    new("to", 1, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233946),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681017, ".ctor", 6278,
                "2003011300181011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.IntPtr", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&"], 0,
                [
                    new("from", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 1, 134233947),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233948),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233949),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681018, ".ctor", 6278,
                "20030113001811AD80",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.IntPtr", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"], 0,
                [
                    new("from", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 1, 134233950),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233951),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233952),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681019, ".ctor", 6278, "200201130018",
                (KeyValuePair<string, string>[])[], "System.Void", ["T", "System.IntPtr"], 0,
                [
                    new("from", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 1, 134233953),
                    new("to", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134233954),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681020, ".ctor", 6278,
                "200301130013001011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "T", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&"], 0,
                [
                    new("from", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 1, 134233955),
                    new("to", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 2, 134233956),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233957),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681021, ".ctor", 6278,
                "2003011300130011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "T", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"], 0,
                [
                    new("from", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 1, 134233958),
                    new("to", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 2, 134233959),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233960),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 33557346, 100681022, ".ctor", 6278, "20020113001300",
                (KeyValuePair<string, string>[])[], "System.Void", ["T", "T"], 0,
                [
                    new("from", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 1, 134233961),
                    new("to", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1"), 2, 134233962),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 33557347, 100681023, ".ctor", 6278,
                "20030115128B51011512817501130013011011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Func`1<TFrom>>", "TTo",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<TFrom>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"),
                                    ]),
                            ]), 1, 134233963),
                    new("to", 1, 0, "TTo", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 2, 134233964),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233965),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 33557347, 100681024, ".ctor", 6278,
                "20030115128B510115128175011300130111AD80", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Linq.Expressions.Expression`1<System.Func`1<TFrom>>", "TTo",
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                ], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<TFrom>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"),
                                    ]),
                            ]), 1, 134233966),
                    new("to", 1, 0, "TTo", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 2, 134233967),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233968),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 33557347, 100681025, ".ctor", 6278,
                "20020115128B5101151281750113001301", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Linq.Expressions.Expression`1<System.Func`1<TFrom>>", "TTo"], 0,
                [
                    new("from", 0, 0,
                        "System.Linq.Expressions.Expression`1<System.Func`1<TFrom>>", false, null, [],
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Linq.Expressions.Expression`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Func`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"),
                                    ]),
                            ]), 1, 134233969),
                    new("to", 1, 0, "TTo", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 2, 134233970),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 33557347, 100681026, ".ctor", 6278,
                "200301130013011011AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["TFrom", "TTo", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&"], 0,
                [
                    new("from", 0, 0, "TFrom", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 1, 134233971),
                    new("to", 1, 0, "TTo", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 2, 134233972),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig")), 3, 134233973),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 33557347, 100681027, ".ctor", 6278,
                "2003011300130111AD80", (KeyValuePair<string, string>[])[], "System.Void",
                ["TFrom", "TTo", "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"], 0,
                [
                    new("from", 0, 0, "TFrom", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 1, 134233974),
                    new("to", 1, 0, "TTo", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 2, 134233975),
                    new("config", 2, 0,
                        "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig"), 3, 134233976),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 33557347, 100681028, ".ctor", 6278, "20020113001301",
                (KeyValuePair<string, string>[])[], "System.Void", ["TFrom", "TTo"], 0,
                [
                    new("from", 0, 0, "TFrom", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 1, 134233977),
                    new("to", 1, 0, "TTo", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2"), 2, 134233978),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681029,
                "IsEverestInternalMethod", 145, "0001021281F5", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233979),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 20, 47));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681030, "IsLegacyMMCaller",
                145,
                "000102128229", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233980),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 44, 109));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681031, "IsCoreModCaller",
                145,
                "000102128229", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Delegate", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 1, 134233981),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 29, 63));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681032, "Add", 150,
                "100102011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 1,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233982),
                    new("hookDelegate", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233983),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681033, "Add", 150,
                "0002011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233984),
                    new("hookDelegate", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233985),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 53, 160));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681034, "Remove", 150,
                "100102011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 1,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233986),
                    new("hookDelegate", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233987),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681035, "Remove", 150,
                "0002011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233988),
                    new("hookDelegate", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233989),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681036, "Modify", 150,
                "100102011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 1,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233990),
                    new("callback", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233991),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681037, "Modify", 150,
                "0002011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233992),
                    new("callback", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233993),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 52, 159));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681038, "Unmodify", 150,
                "100102011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 1,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233994),
                    new("callback", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233995),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681039, "Unmodify", 150,
                "0002011281F5128229", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodBase", "System.Delegate"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodBase", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233996),
                    new("callback", 1, 0, "System.Delegate", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Delegate"), 2, 134233997),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681040, "Clear", 150,
                "000001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 39, 119));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 33557348, 100681041, ".cctor", 6289,
                "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c", 33557349, 100681042, ".cctor", 6289,
                "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c", 33557349, 100681043, ".ctor", 6278,
                "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c", 33557349, 100681044,
                "<IsLegacyMMCaller>b__3_0", 131, "200102128B9D", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["System.Reflection.CustomAttributeData"], 0,
                [
                    new("attr", 0, 0, "System.Reflection.CustomAttributeData", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.CustomAttributeData"), 1, 134233998),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 100681045, "get_IsValid", 3526, "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 100681046, "get_IsApplied", 3526, "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 100681047, "Apply", 1478, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 100681048, "Undo", 1478, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 100681049, "Free", 1478, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 100681050, "GenerateTrampoline", 1478,
                "20011281F51281F5", (KeyValuePair<string, string>[])[], "System.Reflection.MethodBase",
                ["System.Reflection.MethodBase"], 0,
                [
                    new("signature", 0, 4112, "System.Reflection.MethodBase", true,
                        null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.MethodBase"), 1, 134233999),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.MethodBase"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 33557350, 100681051, "GenerateTrampoline", 1478,
                "3001001E00", (KeyValuePair<string, string>[])[], "T", [], 1,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour",
                    ownerMethodDefinitionToken: 100681051), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 33557351, 100681052, "get_GlobalIndex", 3526,
                "200009", (KeyValuePair<string, string>[])[], "System.UInt32", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 33557351, 100681053, "get_Priority", 3526,
                "200008", (KeyValuePair<string, string>[])[], "System.Int32", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 33557351, 100681054, "set_Priority", 3526,
                "20010108", (KeyValuePair<string, string>[])[], "System.Void", ["System.Int32"], 0,
                [
                    new("value", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134234000),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 33557351, 100681055, "get_ID", 3526,
                "20000E",
                (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 33557351, 100681056, "set_ID", 3526,
                "2001010E",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134234001),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
        }
    }
}
