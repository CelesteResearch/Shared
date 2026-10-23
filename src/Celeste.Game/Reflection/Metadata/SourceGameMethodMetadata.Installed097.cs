using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishInstalled097(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LogLevelConstTypes+Warn",
                33556991, 100678817, "get_Value", 2198, "000011A7E4", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.LogLevel", [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.LogLevel"), true, 2, 2));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.LogLevelConstTypes+Error",
                33556992, 100678818, "get_Value", 2198, "000011A7E4", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.LogLevel", [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.LogLevel"), true, 2, 2));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaTypeBuilder",
                33556993,
                100678819, "Initialize", 147, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 74, 225));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaTypeBuilder",
                33556993,
                100678820, "Build", 150, "00011280D11C", (KeyValuePair<string, string>[])[], "System.Type",
                ["System.Object"], 0,
                [
                    new("rulesOrCB", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134232228),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Type"), true, 240, 749));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaTypeBuilder",
                33556993,
                100678821, "GetType", 145, "00011280D11C", (KeyValuePair<string, string>[])[], "System.Type",
                ["System.Object"], 0,
                [
                    new("raw", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134232229),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Type"), true, 44, 109));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaTypeBuilder",
                33556993,
                100678822, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.LuaTypeBuilder+<>c__DisplayClass3_0", 33556994, 100678823, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.LuaTypeBuilder+<>c__DisplayClass3_0", 33556994, 100678824, "<Initialize>b__0", 131,
                "200112886D128869", (KeyValuePair<string, string>[])[], "NLua.LuaTable",
                ["NLua.LuaFunction"], 0,
                [
                    new("cb", 0, 0, "NLua.LuaFunction", false, null, [],
                        "NLua, Version=1.4.1.0, Culture=neutral, PublicKeyToken=6a194c04b9c89217",
                        new(
                            SourceTypeReferenceKind.Named,
                            "NLua, Version=1.4.1.0, Culture=neutral, PublicKeyToken=6a194c04b9c89217",
                            "NLua.LuaFunction"), 1, 134232230),
                ], "NLua, Version=1.4.1.0, Culture=neutral, PublicKeyToken=6a194c04b9c89217",
                new(
                    SourceTypeReferenceKind.Named,
                    "NLua, Version=1.4.1.0, Culture=neutral, PublicKeyToken=6a194c04b9c89217",
                    "NLua.LuaTable"), true, 17, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.LuaTypeBuilder+<>c__DisplayClass5_0", 33556995, 100678825, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.LuaTypeBuilder+<>c__DisplayClass5_0", 33556995, 100678826, "<Build>b__0", 131,
                "200212840D1C12872D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "0100020000"),
                ], "System.Reflection.Assembly", ["System.Object", "System.ResolveEventArgs"], 0,
                [
                    new("s", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134232231),
                    new("e", 1, 0, "System.ResolveEventArgs", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ResolveEventArgs"), 2, 134232232),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Reflection.Assembly"), true, 12, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678827, "get_Stream", 2502, "2000128255", (KeyValuePair<string, string>[])[], "System.IO.Stream",
                [], 0, [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.Stream"), true, 6, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678828, "get_StreamAsync", 2502, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 2, 2));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678829, "get_Data", 2502, "20001D05", (KeyValuePair<string, string>[])[], "System.Byte[]",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Byte"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 35, 72));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678830, ".ctor", 6276, "20010112A798", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.ModContent"], 0,
                [
                    new("source", 0, 0, "Celeste.Mod.ModContent", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModContent"), 1, 134232233),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678831, "Open", 1476, "200201101282551002", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IO.Stream&", "System.Boolean&"], 0,
                [
                    new("stream", 0, 2, "System.IO.Stream&", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.IO.Stream")), 1, 134232234),
                    new("isSection", 1, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134232235),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678832, "TryDeserialize", 134, "30010102101E00", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["T&"], 1,
                [
                    new("result", 0, 2, "T&", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Celeste.Mod.ModAsset", ownerMethodDefinitionToken: 100678832)), 1,
                        134232236),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 36, 91));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678833, "Deserialize", 134, "3001001E00", (KeyValuePair<string, string>[])[], "T",
                [],
                1, [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.ModAsset", ownerMethodDefinitionToken: 100678833), true, 6, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678834, "TryGetMeta", 134, "30010102101E00", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["T&"], 1,
                [
                    new("meta", 0, 2, "T&", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Celeste.Mod.ModAsset", ownerMethodDefinitionToken: 100678834)), 1,
                        134232237),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 18, 46));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678835, "GetMeta", 134, "3001001E00", (KeyValuePair<string, string>[])[], "T", [],
                1,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.ModAsset", ownerMethodDefinitionToken: 100678835), true, 6, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678836, "GetCachedPath", 454, "20000E", (KeyValuePair<string, string>[])[], "System.String",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 84, 233));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset", 33556996,
                100678837, "WriteCache", 452, "2001010E", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String"], 0,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134232238),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 21, 44));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset+<>c", 33556997,
                100678838, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset+<>c", 33556997,
                100678839, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset+<>c", 33556997,
                100678840, "<GetCachedPath>b__18_0", 131, "20010212A948", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["Celeste.Mod.EverestModuleMetadata"], 0,
                [
                    new("meta", 0, 0, "Celeste.Mod.EverestModuleMetadata", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.EverestModuleMetadata"), 1, 134232239),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 10));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset`1", 33556998,
                100678841, "get_Source", 2182, "20001300", (KeyValuePair<string, string>[])[], "T",
                [], 0,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.ModAsset`1"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAsset`1", 33556998,
                100678842, ".ctor", 6276, "2001011300", (KeyValuePair<string, string>[])[], "System.Void",
                ["T"], 0,
                [
                    new("source", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.ModAsset`1"), 1, 134232240),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAssetBranch",
                33556999,
                100678843, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModAssetBranch",
                33556999,
                100678844, "Open", 196, "200201101282551002", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IO.Stream&", "System.Boolean&"], 0,
                [
                    new("stream", 0, 2, "System.IO.Stream&", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.IO.Stream")), 1, 134232241),
                    new("isSection", 1, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134232242),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.FileSystemModAsset",
                33557000, 100678845, ".ctor", 6278, "20020112A79C0E", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Celeste.Mod.FileSystemModContent", "System.String"], 0,
                [
                    new("source", 0, 0, "Celeste.Mod.FileSystemModContent", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.FileSystemModContent"), 1, 134232243),
                    new("path", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134232244),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.FileSystemModAsset",
                33557000, 100678846, "Open", 196, "200201101282551002", (KeyValuePair<string, string>[])[],
                "System.Void", ["System.IO.Stream&", "System.Boolean&"], 0,
                [
                    new("stream", 0, 2, "System.IO.Stream&", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.IO.Stream")), 1, 134232245),
                    new("isSection", 1, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134232246),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 37));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.FileSystemModAsset",
                33557000, 100678847, "GetCachedPath", 198, "20000E", (KeyValuePair<string, string>[])[],
                "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MapBinsInModsModAsset",
                33557001, 100678848, ".ctor", 6278, "20020112A7A80E", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Celeste.Mod.MapBinsInModsModContent", "System.String"], 0,
                [
                    new("source", 0, 0, "Celeste.Mod.MapBinsInModsModContent", false,
                        null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.MapBinsInModsModContent"), 1, 134232247),
                    new("path", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134232248),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MapBinsInModsModAsset",
                33557001, 100678849, "Open", 196, "200201101282551002", (KeyValuePair<string, string>[])[],
                "System.Void", ["System.IO.Stream&", "System.Boolean&"], 0,
                [
                    new("stream", 0, 2, "System.IO.Stream&", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.IO.Stream")), 1, 134232249),
                    new("isSection", 1, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134232250),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 37));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MapBinsInModsModAsset",
                33557001, 100678850, "GetCachedPath", 198, "20000E", (KeyValuePair<string, string>[])[],
                "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssemblyModAsset",
                33557002,
                100678851, ".ctor", 6278, "20020112A7AC0E", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.AssemblyModContent", "System.String"], 0,
                [
                    new("source", 0, 0, "Celeste.Mod.AssemblyModContent", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.AssemblyModContent"), 1, 134232251),
                    new("resourceName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134232252),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssemblyModAsset",
                33557002,
                100678852, "Open", 196, "200201101282551002", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IO.Stream&", "System.Boolean&"], 0,
                [
                    new("stream", 0, 2, "System.IO.Stream&", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.IO.Stream")), 1, 134232253),
                    new("isSection", 1, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134232254),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ZipModAsset", 33557003,
                100678853, "get_Data", 2246, "20001D05", (KeyValuePair<string, string>[])[], "System.Byte[]",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Byte"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 27, 62));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ZipModAsset", 33557003,
                100678854, ".ctor", 6278, "20020112A7B00E", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.ZipModContent", "System.String"], 0,
                [
                    new("source", 0, 0, "Celeste.Mod.ZipModContent", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ZipModContent"), 1, 134232255),
                    new("path", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134232256),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ZipModAsset", 33557003,
                100678855, "Open", 196, "200201101282551002", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IO.Stream&", "System.Boolean&"], 0,
                [
                    new("stream", 0, 2, "System.IO.Stream&", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.IO.Stream")), 1, 134232257),
                    new("isSection", 1, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134232258),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModSaveData", 33557004,
                100678856, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModSaveData", 33557004,
                100678857, ".ctor", 6278, "200101129BB0", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.SaveData"], 0,
                [
                    new("data", 0, 0, "Celeste.SaveData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.SaveData"), 1, 134232259),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 77));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.ModSaveData", 33557004,
                100678858, "CopyToCelesteSaveData", 134, "200101129BB0", (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.SaveData"], 0,
                [
                    new("data", 0, 0, "Celeste.SaveData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.SaveData"), 1, 134232260),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 49));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678859, "get_Initialized", 2198, "000002",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Boolean", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678860, "set_Initialized", 2193, "00010102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Boolean"], 0,
                [
                    new("value", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232261),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678861, "add__OnInput", 2193, "0001011512814D0103",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<System.Char>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<System.Char>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134232262),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678862, "remove__OnInput", 2193, "0001011512814D0103",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<System.Char>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<System.Char>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134232263),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678863, "add_OnInput", 2198, "0001011512814D0103", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Action`1<System.Char>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<System.Char>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134232264),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678864, "remove_OnInput", 2198, "0001011512814D0103", (KeyValuePair<string, string>[])[],
                "System.Void", ["System.Action`1<System.Char>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<System.Char>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134232265),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678865, "Initialize", 147, "000101128185", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Game"], 0,
                [
                    new("game", 0, 0, "Microsoft.Xna.Framework.Game", false, null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Game"), 1, 134232266),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 52));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678866, "Shutdown", 147, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 53));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678867, "ReceiveTextInput", 147, "00010103", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Char"], 0,
                [
                    new("c", 0, 0, "System.Char", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 1, 134232267),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678868, "CheckTextStatus", 145, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 38, 114));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678869, "GetClipboardText", 150, "00000E", (KeyValuePair<string, string>[])[], "System.String",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.TextInput", 33557005,
                100678870, "SetClipboardText", 150, "0001010E", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134232268),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678871, "get_IsReloading", 2198, "000002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678872, "get_ReturnToScene", 2198, "0000128588",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Monocle.Scene", [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678873, "set_ReturnToScene", 2198, "000101128588",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Monocle.Scene"], 0,
                [
                    new("value", 0, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 1, 134232269),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678874, "get_CancellationToken", 2182, "2000118A15", (KeyValuePair<string, string>[])[],
                "System.Threading.CancellationToken", [], 0, [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.CancellationToken"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678875, "Do", 150, "0003010E128149128149", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String", "System.Action", "System.Action"], 0,
                [
                    new("text", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134232270),
                    new("reload", 1, 4112, "System.Action", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 2, 134232271),
                    new("done", 2, 4112, "System.Action", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 3, 134232272),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 10));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678876, "Do", 150, "000401020E128149128149", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Boolean", "System.String", "System.Action", "System.Action"], 0,
                [
                    new("silent", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232273),
                    new("text", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134232274),
                    new("reload", 2, 4112, "System.Action", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 3, 134232275),
                    new("done", 3, 4112, "System.Action", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 4, 134232276),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 50));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678877, "Do", 150, "00041284350E1512809102021284350202", (KeyValuePair<string, string>[])[],
                "System.Threading.Tasks.Task",
                [
                    "System.String", "System.Func`2<System.Boolean,System.Threading.Tasks.Task>", "System.Boolean",
                    "System.Boolean",
                ], 0,
                [
                    new("text", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134232277),
                    new("action", 1, 0,
                        "System.Func`2<System.Boolean,System.Threading.Tasks.Task>", false, null, [],
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
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Threading.Tasks.Task"),
                            ]), 2, 134232278),
                    new("silent", 2, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134232279),
                    new("useWorkerThread", 3, 4112, "System.Boolean", true,
                        "System.Boolean", /* ReSharper disable once UseUtf8StringLiteral */ [0x01],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 4, 134232280),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 143, 405));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678878, "DelayReloadUntilAfterCrash", 145, "0004128435020E15128091020212843502",
                (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task",
                [
                    "System.Boolean", "System.String", "System.Func`2<System.Boolean,System.Threading.Tasks.Task>",
                    "System.Boolean",
                ], 0,
                [
                    new("silent", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232281),
                    new("text", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134232282),
                    new("action", 2, 0,
                        "System.Func`2<System.Boolean,System.Threading.Tasks.Task>", false, null, [],
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
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Threading.Tasks.Task"),
                            ]), 3, 134232283),
                    new("useWorkerThread", 3, 0, "System.Boolean", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 4, 134232284),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 75, 223));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678879, "ReloadLevel", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678880, "ReloadLevel", 150, "000112843502", (KeyValuePair<string, string>[])[],
                "System.Threading.Tasks.Task", ["System.Boolean"], 0,
                [
                    new("forceReload", 0, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232285),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 50, 133));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678881, "ReloadAllMaps", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 125, 351));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678882, "DoImmediateSceneSwitch", 145, "000101128588", (KeyValuePair<string, string>[])[],
                "System.Void", ["Monocle.Scene"], 0,
                [
                    new("newScene", 0, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 1, 134232286),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678883, "StartReloadScene", 145, "0000151284390112A83C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.AsyncStateMachineAttribute",
                        "01003543656C657374652E4D6F642E417373657452656C6F616448656C7065722B3C537461727452656C6F61645363656E653E645F5F32340000"),
                ], "System.Threading.Tasks.Task`1<Celeste.Mod.AssetReloadHelper>", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Threading.Tasks.Task`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.AssetReloadHelper"),
                    ]), true, 14, 47));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678884, "EndReloadScene", 145, "00010112A83C", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.AssetReloadHelper"], 0,
                [
                    new("helper", 0, 0, "Celeste.Mod.AssetReloadHelper", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.AssetReloadHelper"), 1, 134232287),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 59, 178));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678885, ".ctor", 6273, "200101128588", (KeyValuePair<string, string>[])[], "System.Void",
                ["Monocle.Scene"], 0,
                [
                    new("origScene", 0, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 1, 134232288),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 24, 72));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678886, "Dispose", 486, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 22, 51));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678887, "End", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 24, 86));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678888, "Update", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 289, 841));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678889, "BeforeRender", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 27, 93));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678890, "Render", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 32, 129));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678891, "CaptureSnapshots", 129, "200101128588", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Monocle.Scene"], 0,
                [
                    new("scene", 0, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 1, 134232289),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 149, 389));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678892, "RenderContent", 129, "20010102", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Boolean"], 0,
                [
                    new("toHiresBuffer", 0, 0, "System.Boolean", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232290),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 272, 878));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper",
                33557007,
                100678893, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 57, 211));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper+<>c",
                33557009, 100678894, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper+<>c",
                33557009, 100678895, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.AssetReloadHelper+<>c",
                33557009, 100678896, "<ReloadLevel>b__11_0", 131, "2000128435", (KeyValuePair<string, string>[])[],
                "System.Threading.Tasks.Task", [], 0, [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 36, 124));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass11_0", 33557010, 100678897, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass11_0", 33557010, 100678898, "<ReloadLevel>b__1", 131,
                "200112843502",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.AsyncStateMachineAttribute",
                        "01004843656C657374652E4D6F642E417373657452656C6F616448656C7065722B3C3E635F5F446973706C6179436C61737331315F302B3C3C52656C6F61644C6576656C3E625F5F313E640000"),
                ], "System.Threading.Tasks.Task", ["System.Boolean"], 0,
                [
                    new("_", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232291),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 17, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass11_0+<<ReloadLevel>b__1>d", 33557011, 100678899,
                "MoveNext",
                481, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 334, 1019));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass11_0+<<ReloadLevel>b__1>d", 33557011, 100678900,
                "SetStateMachine", 481, "20010112892D",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Runtime.CompilerServices.IAsyncStateMachine"], 0,
                [
                    new("stateMachine", 0, 0,
                        "System.Runtime.CompilerServices.IAsyncStateMachine", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.CompilerServices.IAsyncStateMachine"), 1, 134232292),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass5_0", 33557012, 100678901, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass5_0", 33557012, 100678902, "<Do>b__0", 131,
                "200112843502",
                (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task", ["System.Boolean"], 0,
                [
                    new("silent", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232293),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 31, 78));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0", 33557013, 100678903, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0", 33557013, 100678904, "<Do>b__0", 131,
                "2000128435",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.AsyncStateMachineAttribute",
                        "01003E43656C657374652E4D6F642E417373657452656C6F616448656C7065722B3C3E635F5F446973706C6179436C617373365F302B3C3C446F3E625F5F303E640000"),
                ], "System.Threading.Tasks.Task", [], 0, [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 17, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0", 33557013, 100678905, "<Do>b__1", 131,
                "20001512843901128435",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.AsyncStateMachineAttribute",
                        "01003E43656C657374652E4D6F642E417373657452656C6F616448656C7065722B3C3E635F5F446973706C6179436C617373365F302B3C3C446F3E625F5F313E640000"),
                ], "System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Threading.Tasks.Task`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Tasks.Task"),
                    ]), true, 17, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0", 33557013, 100678906, "<Do>b__2", 131,
                "2001128435151284390112A83C", (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task",
                ["System.Threading.Tasks.Task`1<Celeste.Mod.AssetReloadHelper>"], 0,
                [
                    new("t", 0, 0,
                        "System.Threading.Tasks.Task`1<Celeste.Mod.AssetReloadHelper>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Threading.Tasks.Task`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Mod.AssetReloadHelper"),
                            ]), 1, 134232294),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 83, 255));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0", 33557013, 100678907, "<Do>b__6", 131,
                "2000128435",
                (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0", 33557013, 100678908, "<Do>b__4", 131,
                "2000128435",
                (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0+<<Do>b__0>d", 33557014, 100678909, "MoveNext", 481,
                "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 154, 410));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0+<<Do>b__0>d", 33557014, 100678910,
                "SetStateMachine",
                481, "20010112892D",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Runtime.CompilerServices.IAsyncStateMachine"], 0,
                [
                    new("stateMachine", 0, 0,
                        "System.Runtime.CompilerServices.IAsyncStateMachine", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.CompilerServices.IAsyncStateMachine"), 1, 134232295),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0+<<Do>b__1>d", 33557015, 100678911, "MoveNext", 481,
                "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 73, 190));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_0+<<Do>b__1>d", 33557015, 100678912,
                "SetStateMachine",
                481, "20010112892D",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Runtime.CompilerServices.IAsyncStateMachine"], 0,
                [
                    new("stateMachine", 0, 0,
                        "System.Runtime.CompilerServices.IAsyncStateMachine", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.CompilerServices.IAsyncStateMachine"), 1, 134232296),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_1", 33557016, 100678913, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_1", 33557016, 100678914, "<Do>b__3", 131,
                "2000128435",
                (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 22, 68));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass6_1", 33557016, 100678915, "<Do>b__5", 131,
                "2000128435",
                (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 13, 37));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass7_0", 33557017, 100678916, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass7_0", 33557017, 100678917,
                "<DelayReloadUntilAfterCrash>b__0", 131, "200001", (KeyValuePair<string, string>[])[],
                "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 31, 90));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass7_0", 33557017, 100678918,
                "<DelayReloadUntilAfterCrash>b__2", 131, "200001", (KeyValuePair<string, string>[])[],
                "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 41));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass7_1", 33557018, 100678919, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<>c__DisplayClass7_1", 33557018, 100678920,
                "<DelayReloadUntilAfterCrash>b__1", 131, "200001", (KeyValuePair<string, string>[])[],
                "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 47));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<StartReloadScene>d__24", 33557019, 100678921, "MoveNext", 481, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 81, 241));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.AssetReloadHelper+<StartReloadScene>d__24", 33557019, 100678922, "SetStateMachine", 481,
                "20010112892D",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Runtime.CompilerServices.IAsyncStateMachine"], 0,
                [
                    new("stateMachine", 0, 0,
                        "System.Runtime.CompilerServices.IAsyncStateMachine", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.CompilerServices.IAsyncStateMachine"), 1, 134232297),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaCoroutine", 33557020,
                100678923, "get_Current", 2534, "20001C", (KeyValuePair<string, string>[])[], "System.Object",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 8, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaCoroutine", 33557020,
                100678924, ".ctor", 6278, "20010112886D", (KeyValuePair<string, string>[])[], "System.Void",
                ["NLua.LuaTable"], 0,
                [
                    new("proxy", 0, 0, "NLua.LuaTable", false, null, [],
                        "NLua, Version=1.4.1.0, Culture=neutral, PublicKeyToken=6a194c04b9c89217",
                        new(
                            SourceTypeReferenceKind.Named,
                            "NLua, Version=1.4.1.0, Culture=neutral, PublicKeyToken=6a194c04b9c89217",
                            "NLua.LuaTable"), 1, 134232298),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaCoroutine", 33557020,
                100678925, "MoveNext", 486, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 55, 112));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.LuaCoroutine", 33557020,
                100678926, "Reset", 486, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678927, "get_MainThread", 2198, "000012858D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Threading.Thread", [], 0, [],
                "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Thread"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678928, "set_MainThread", 2193, "00010112858D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Threading.Thread"], 0,
                [
                    new("value", 0, 0, "System.Threading.Thread", false, null,
                        [],
                        "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread"), 1, 134232299),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678929, "get_UpdatedOnce", 2198, "000002",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Boolean", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678930, "set_UpdatedOnce", 2193, "00010102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Boolean"], 0,
                [
                    new("value", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134232300),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678931, "get_IsMainThread", 2198, "000002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 4, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678932, "get_TaskTimeSlice", 2193, "000008", (KeyValuePair<string, string>[])[], "System.Int32",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 6, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678933, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 49));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678934, ".ctor", 6278, "200101128185", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Game"], 0,
                [
                    new("game", 0, 0, "Microsoft.Xna.Framework.Game", false, null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Game"), 1, 134232301),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678935, "Schedule", 150, "000211843112814902", (KeyValuePair<string, string>[])[],
                "System.Threading.Tasks.ValueTask", ["System.Action", "System.Boolean"], 0,
                [
                    new("act", 0, 0, "System.Action", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 1, 134232302),
                    new("forceQueue", 1, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134232303),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.ValueTask"), true, 29, 81));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678936, "Schedule", 150, "10010215118429011E0015128175011E0002",
                (KeyValuePair<string, string>[])[],
                "System.Threading.Tasks.ValueTask`1<T>", ["System.Func`1<T>", "System.Boolean"], 1,
                [
                    new("act", 0, 0, "System.Func`1<T>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
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
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MainThreadHelper",
                                    ownerMethodDefinitionToken: 100678936),
                            ]), 1, 134232304),
                    new("forceQueue", 1, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134232305),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Threading.Tasks.ValueTask`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MainThreadHelper", ownerMethodDefinitionToken: 100678936),
                    ]), true, 29, 81));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678937, "Schedule", 150, "0002128435151281750112843502", (KeyValuePair<string, string>[])[],
                "System.Threading.Tasks.Task",
                ["System.Func`1<System.Threading.Tasks.Task>", "System.Boolean"], 0,
                [
                    new("act", 0, 0, "System.Func`1<System.Threading.Tasks.Task>",
                        false,
                        null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Func`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Threading.Tasks.Task"),
                            ]), 1, 134232306),
                    new("forceQueue", 1, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134232307),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task"), true, 28, 76));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678938, "Schedule", 150, "10010215128439011E00151281750115128439011E0002",
                (KeyValuePair<string, string>[])[], "System.Threading.Tasks.Task`1<T>",
                ["System.Func`1<System.Threading.Tasks.Task`1<T>>", "System.Boolean"], 1,
                [
                    new("act", 0, 0, "System.Func`1<System.Threading.Tasks.Task`1<T>>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Func`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Threading.Tasks.Task`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                            ownerAssemblyIdentity:
                                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                            ownerTypeIdentity: "Celeste.Mod.MainThreadHelper",
                                            ownerMethodDefinitionToken: 100678938),
                                    ]),
                            ]), 1, 134232308),
                    new("forceQueue", 1, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134232309),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Threading.Tasks.Task`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MainThreadHelper", ownerMethodDefinitionToken: 100678938),
                    ]), true, 28, 76));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678939, "Do", 150, "000101128149",
                (KeyValuePair<string, string>[])
                [
                    new("System.ObsoleteAttribute",
                        "010014557365205363686564756C6520696E73746561640000"),
                ], "System.Void", ["System.Action"], 0,
                [
                    new("a", 0, 0, "System.Action", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 1, 134232310),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678940, "Get", 150, "1001011511A884011E0015128175011E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.ObsoleteAttribute",
                        "010014557365205363686564756C6520696E73746561640000"),
                ], "Celeste.Mod.MaybeAwaitable`1<T>", ["System.Func`1<T>"], 1,
                [
                    new("f", 0, 0, "System.Func`1<T>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
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
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MainThreadHelper",
                                    ownerMethodDefinitionToken: 100678940),
                            ]), 1, 134232311),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.MaybeAwaitable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MainThreadHelper", ownerMethodDefinitionToken: 100678940),
                    ]), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678941, "GetForceQueue", 150, "1001011511A884011E0015128175011E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.ObsoleteAttribute",
                        "010014557365205363686564756C6520696E73746561640000"),
                ], "Celeste.Mod.MaybeAwaitable`1<T>", ["System.Func`1<T>"], 1,
                [
                    new("f", 0, 0, "System.Func`1<T>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
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
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MainThreadHelper",
                                    ownerMethodDefinitionToken: 100678941),
                            ]), 1, 134232312),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.MaybeAwaitable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MainThreadHelper", ownerMethodDefinitionToken: 100678941),
                    ]), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678942, "Do", 150, "0002011C128149",
                (KeyValuePair<string, string>[])
                [
                    new("System.ObsoleteAttribute",
                        "010014557365205363686564756C6520696E73746561640000"),
                ], "System.Void", ["System.Object", "System.Action"], 0,
                [
                    new("key", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134232313),
                    new("act", 1, 0, "System.Action", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 2, 134232314),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 46, 118));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678943, "Get", 150, "1001021511A884011E001C15128175011E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.ObsoleteAttribute",
                        "010014557365205363686564756C6520696E73746561640000"),
                ], "Celeste.Mod.MaybeAwaitable`1<T>", ["System.Object", "System.Func`1<T>"], 1,
                [
                    new("key", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134232315),
                    new("act", 1, 0, "System.Func`1<T>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
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
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MainThreadHelper",
                                    ownerMethodDefinitionToken: 100678943),
                            ]), 2, 134232316),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.MaybeAwaitable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MainThreadHelper", ownerMethodDefinitionToken: 100678943),
                    ]), true, 51, 138));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678944, "GetForceQueue", 150, "1001021511A884011E001C15128175011E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.ObsoleteAttribute",
                        "010014557365205363686564756C6520696E73746561640000"),
                ], "Celeste.Mod.MaybeAwaitable`1<T>", ["System.Object", "System.Func`1<T>"], 1,
                [
                    new("key", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134232317),
                    new("act", 1, 0, "System.Func`1<T>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
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
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MainThreadHelper",
                                    ownerMethodDefinitionToken: 100678944),
                            ]), 2, 134232318),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.MaybeAwaitable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MainThreadHelper", ownerMethodDefinitionToken: 100678944),
                    ]), true, 51, 138));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MainThreadHelper",
                33557021,
                100678945, "Update", 198, "2001011281DD", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.GameTime"], 0,
                [
                    new("gameTime", 0, 0, "Microsoft.Xna.Framework.GameTime", false,
                        null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.GameTime"), 1, 134232319),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+MainThreadTaskScheduler", 33557022, 100678946,
                "get_MaximumConcurrencyLevel",
                2246, "200008", (KeyValuePair<string, string>[])[], "System.Int32", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 2, 2));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+MainThreadTaskScheduler", 33557022, 100678947, "GetScheduledTasks", 196,
                "20001512808D01128435", (KeyValuePair<string, string>[])[],
                "System.Collections.Generic.IEnumerable`1<System.Threading.Tasks.Task>", [], 0,
                [],
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
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Tasks.Task"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+MainThreadTaskScheduler", 33557022, 100678948, "QueueTask", 196,
                "200101128435", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Threading.Tasks.Task"], 0,
                [
                    new("task", 0, 0, "System.Threading.Tasks.Task", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Tasks.Task"), 1, 134232320),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+MainThreadTaskScheduler", 33557022, 100678949, "TryExecuteTaskInline",
                196,
                "20020212843502", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Threading.Tasks.Task", "System.Boolean"], 0,
                [
                    new("task", 0, 0, "System.Threading.Tasks.Task", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Tasks.Task"), 1, 134232321),
                    new("taskWasPreviouslyQueued", 1, 0, "System.Boolean", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134232322),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 13, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+MainThreadTaskScheduler", 33557022, 100678950, "ExecuteTasksFor", 134,
                "20010108", (KeyValuePair<string, string>[])[], "System.Void", ["System.Int32"], 0,
                [
                    new("timeSlice", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134232323),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 26, 67));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+MainThreadTaskScheduler", 33557022, 100678951, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+YieldFrameAwaitable", 33557023, 100678952, "GetAwaiter", 134,
                "200011A880",
                (KeyValuePair<string, string>[])[],
                "Celeste.Mod.MainThreadHelper+YieldFrameAwaitable+YieldFrameAwaiter", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.MainThreadHelper+YieldFrameAwaitable+YieldFrameAwaiter"), true, 4, 10));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+YieldFrameAwaitable+YieldFrameAwaiter", 33557024, 100678953,
                "get_IsCompleted", 2182, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 2, 2));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+YieldFrameAwaitable+YieldFrameAwaiter", 33557024, 100678954, "GetResult",
                134,
                "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MainThreadHelper+YieldFrameAwaitable+YieldFrameAwaiter", 33557024, 100678955,
                "OnCompleted",
                486, "200101128149", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Action"], 0,
                [
                    new("continuation", 0, 0, "System.Action", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 1, 134232324),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678956, ".ctor", 6278, "2001011300", (KeyValuePair<string, string>[])[], "System.Void",
                ["T"], 0,
                [
                    new("result", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1"), 1, 134232325),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678957, ".ctor", 6278, "20010115118931011300", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Runtime.CompilerServices.TaskAwaiter`1<T>"], 0,
                [
                    new("task", 0, 0,
                        "System.Runtime.CompilerServices.TaskAwaiter`1<T>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Runtime.CompilerServices.TaskAwaiter`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1"),
                            ]), 1, 134232326),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678958, ".ctor", 6278, "200101151281750102", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Func`1<System.Boolean>"], 0,
                [
                    new("canGetResult", 0, 0, "System.Func`1<System.Boolean>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Func`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                            ]), 1, 134232327),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 32));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678959, ".ctor", 6278, "20020115118931011300151281750102", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Runtime.CompilerServices.TaskAwaiter`1<T>", "System.Func`1<System.Boolean>"], 0,
                [
                    new("task", 0, 0,
                        "System.Runtime.CompilerServices.TaskAwaiter`1<T>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Runtime.CompilerServices.TaskAwaiter`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1"),
                            ]), 1, 134232328),
                    new("canGetResult", 1, 0, "System.Func`1<System.Boolean>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Func`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                            ]), 2, 134232329),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678960, ".ctor", 6275, "20010115118429011300", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Threading.Tasks.ValueTask`1<T>"], 0,
                [
                    new("task", 0, 0, "System.Threading.Tasks.ValueTask`1<T>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Threading.Tasks.ValueTask`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1"),
                            ]), 1, 134232330),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 59));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678961, "GetAwaiter", 134, "20001511A888011300", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter<T>", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678962, "GetResult", 134, "20001300", (KeyValuePair<string, string>[])[], "T", [],
                0,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MaybeAwaitable`1",
                33557025,
                100678963, "SetResult", 134, "2001011300", (KeyValuePair<string, string>[])[], "System.Void",
                ["T"], 0,
                [
                    new("result", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1"), 1, 134232331),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678964, "get_TaskAwaiter", 2177,
                "200015118931011300", (KeyValuePair<string, string>[])[],
                "System.Runtime.CompilerServices.TaskAwaiter`1<T>", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Runtime.CompilerServices.TaskAwaiter`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter"),
                    ]), true, 21, 58));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678965, "get_CompletionSource", 2177,
                "200015128A1D011300", (KeyValuePair<string, string>[])[],
                "System.Threading.Tasks.TaskCompletionSource`1<T>", [], 0,
                [],
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Threading.Tasks.TaskCompletionSource`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter"),
                    ]), true, 12, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678966, "get_IsCompleted", 2182, "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 11, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678967, ".ctor", 6275, "2001011300",
                (KeyValuePair<string, string>[])[], "System.Void", ["T"], 0,
                [
                    new("result", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter"), 1, 134232332),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 48));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678968, ".ctor", 6275, "20010115118931011300",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Runtime.CompilerServices.TaskAwaiter`1<T>"], 0,
                [
                    new("task", 0, 0,
                        "System.Runtime.CompilerServices.TaskAwaiter`1<T>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Runtime.CompilerServices.TaskAwaiter`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter"),
                            ]), 1, 134232333),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 53));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678969, "GetResult", 134, "20001300",
                (KeyValuePair<string, string>[])[], "T", [], 0,
                [],
                null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter"), true, 26, 64));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678970, "SetResult", 134, "2001011300",
                (KeyValuePair<string, string>[])[], "System.Void", ["T"], 0,
                [
                    new("result", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter"), 1, 134232334),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 40));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678971, "OnCompleted", 486, "200101128149",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Action"], 0,
                [
                    new("continuation", 0, 0, "System.Action", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 1, 134232335),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.MaybeAwaitable`1+MaybeAwaiter", 33557026, 100678972, "UnsafeOnCompleted", 486,
                "200101128149",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Action"], 0,
                [
                    new("continuation", 0, 0, "System.Action", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Action"), 1, 134232336),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MapDataFixup", 33557027,
                100678973, ".ctor", 6278, "200101129E68", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.MapData"], 0,
                [
                    new("map", 0, 0, "Celeste.MapData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.MapData"), 1, 134232337),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 89, 255));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MapDataFixup", 33557027,
                100678974, "Add", 134, "30010001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                1, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MapDataFixup", 33557027,
                100678975, "Add", 134, "300101011E00", (KeyValuePair<string, string>[])[], "System.Void",
                ["T"], 1,
                [
                    new("p", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.MapDataFixup", ownerMethodDefinitionToken: 100678975), 1,
                        134232338),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.MapDataFixup", 33557027,
                100678976, "Get", 134, "3001001E00", (KeyValuePair<string, string>[])[], "T", [], 1,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.MapDataFixup", ownerMethodDefinitionToken: 100678976), true, 29,
                76));
        }
    }
}
