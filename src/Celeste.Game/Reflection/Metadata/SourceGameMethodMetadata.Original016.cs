using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishOriginal016(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665715,
                "GiveMe", 150, "1001051E00081E001E001E001E00", (KeyValuePair<string, string>[])[], "T",
                ["System.Int32", "T", "T", "T", "T"], 1,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222166),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665715), 2, 134222167),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665715), 3, 134222168),
                    new("c", 3, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665715), 4, 134222169),
                    new("d", 4, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665715), 5, 134222170),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665715), true, 13, 42));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665716,
                "GiveMe", 150, "1001061E00081E001E001E001E001E00", (KeyValuePair<string, string>[])[], "T",
                ["System.Int32", "T", "T", "T", "T", "T"], 1,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222171),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665716), 2, 134222172),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665716), 3, 134222173),
                    new("c", 3, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665716), 4, 134222174),
                    new("d", 4, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665716), 5, 134222175),
                    new("e", 5, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665716), 6, 134222176),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665716), true, 15, 49));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665717,
                "GiveMe", 150, "1001071E00081E001E001E001E001E001E00", (KeyValuePair<string, string>[])[], "T",
                ["System.Int32", "T", "T", "T", "T", "T", "T"], 1,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222177),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665717), 2, 134222178),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665717), 3, 134222179),
                    new("c", 3, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665717), 4, 134222180),
                    new("d", 4, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665717), 5, 134222181),
                    new("e", 5, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665717), 6, 134222182),
                    new("f", 6, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665717), 7, 134222183),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665717), true, 17, 56));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665718,
                "PushRandom", 150, "00010108", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32"], 0,
                [
                    new("newSeed", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222184),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665719,
                "PushRandom", 150, "00010112814D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Random"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222185),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665720,
                "PushRandom", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665721,
                "PopRandom", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665722,
                "Choose", 150, "1001031E0012814D1E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Random", "T", "T"], 1,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222186),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665722), 2, 134222187),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665722), 3, 134222188),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665722), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665723,
                "Choose", 150, "1001041E0012814D1E001E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Random", "T", "T", "T"], 1,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222189),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665723), 2, 134222190),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665723), 3, 134222191),
                    new("c", 3, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665723), 4, 134222192),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665723), true, 8, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665724,
                "Choose", 150, "1001051E0012814D1E001E001E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Random", "T", "T", "T", "T"], 1,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222193),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665724), 2, 134222194),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665724), 3, 134222195),
                    new("c", 3, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665724), 4, 134222196),
                    new("d", 4, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665724), 5, 134222197),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665724), true, 9, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665725,
                "Choose", 150, "1001061E0012814D1E001E001E001E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Random", "T", "T", "T", "T", "T"], 1,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222198),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665725), 2, 134222199),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665725), 3, 134222200),
                    new("c", 3, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665725), 4, 134222201),
                    new("d", 4, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665725), 5, 134222202),
                    new("e", 5, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665725), 6, 134222203),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665725), true, 10, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665726,
                "Choose", 150, "1001071E0012814D1E001E001E001E001E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Random", "T", "T", "T", "T", "T", "T"], 1,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222204),
                    new("a", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665726), 2, 134222205),
                    new("b", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665726), 3, 134222206),
                    new("c", 3, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665726), 4, 134222207),
                    new("d", 4, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665726), 5, 134222208),
                    new("e", 5, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665726), 6, 134222209),
                    new("f", 6, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665726), 7, 134222210),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665726), true, 11, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665727,
                "Choose", 150, "1001021E0012814D1D1E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Random", "T[]"], 1,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222211),
                    new("choices", 1, 0, "T[]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665727), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134222212),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665727), true, 8, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665728,
                "Choose", 150, "1001021E0012814D15126D011E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Random", "System.Collections.Generic.List`1<T>"], 1,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222213),
                    new("choices", 1, 0, "System.Collections.Generic.List`1<T>", false,
                        null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665728),
                            ]), 2, 134222214),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665728), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665729,
                "Range", 150, "00030812814D0808",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Random", "System.Int32", "System.Int32"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222215),
                    new("min", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222216),
                    new("max", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222217),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 8, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665730,
                "Range", 150, "00030C12814D0C0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Random", "System.Single", "System.Single"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222218),
                    new("min", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222219),
                    new("max", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222220),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 8, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665731,
                "Range", 150, "000311808512814D118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["System.Random", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222221),
                    new("min", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222222),
                    new("max", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134222223),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 50));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665732,
                "Facing", 150, "00010812814D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Random"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222224),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665733,
                "Chance", 150, "00020212814D0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["System.Random", "System.Single"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222225),
                    new("chance", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222226),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 10));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665734,
                "NextFloat", 150, "00010C12814D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Random"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222227),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665735,
                "NextFloat", 150, "00020C12814D0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Random", "System.Single"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222228),
                    new("max", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222229),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665736,
                "NextAngle", 150, "00010C12814D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Random"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222230),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665737,
                "ShakeVector", 150, "000111808512814D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["System.Random"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222231),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 10, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665738,
                "ClosestTo", 150, "000211808515126D01118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "System.Collections.Generic.List`1<Microsoft.Xna.Framework.Vector2>",
                    "Microsoft.Xna.Framework.Vector2",
                ], 0,
                [
                    new("list", 0, 0,
                        "System.Collections.Generic.List`1<Microsoft.Xna.Framework.Vector2>", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                    "Microsoft.Xna.Framework.Vector2"),
                            ]), 1, 134222232),
                    new("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222233),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 38, 69));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665739,
                "ClosestTo", 150, "00021180851D118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("list", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222234),
                    new("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222235),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 39, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665740,
                "ClosestTo", 150, "00031180851D1180851180851008",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Vector2", "System.Int32&"], 0,
                [
                    new("list", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222236),
                    new("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222237),
                    new("index", 2, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 3, 134222238),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 45, 72));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665741,
                "Shuffle", 150, "1001020115126D011E0012814D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Collections.Generic.List`1<T>", "System.Random"], 1,
                [
                    new("list", 0, 0, "System.Collections.Generic.List`1<T>", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665741),
                            ]), 1, 134222239),
                    new("random", 1, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 2, 134222240),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 32, 58));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665742,
                "Shuffle", 150, "1001010115126D011E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Collections.Generic.List`1<T>"], 1,
                [
                    new("list", 0, 0, "System.Collections.Generic.List`1<T>", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665742),
                            ]), 1, 134222241),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665743,
                "ShuffleSetFirst", 150, "1001030115126D011E0012814D1E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Collections.Generic.List`1<T>", "System.Random", "T"], 1,
                [
                    new("list", 0, 0, "System.Collections.Generic.List`1<T>", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665743),
                            ]), 1, 134222242),
                    new("random", 1, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 2, 134222243),
                    new("first", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665743), 3, 134222244),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 33, 53));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665744,
                "ShuffleSetFirst", 150, "1001020115126D011E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Collections.Generic.List`1<T>", "T"], 1,
                [
                    new("list", 0, 0, "System.Collections.Generic.List`1<T>", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665744),
                            ]), 1, 134222245),
                    new("first", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665744), 2, 134222246),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665745,
                "ShuffleNotFirst", 150, "1001030115126D011E0012814D1E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Collections.Generic.List`1<T>", "System.Random", "T"], 1,
                [
                    new("list", 0, 0, "System.Collections.Generic.List`1<T>", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665745),
                            ]), 1, 134222247),
                    new("random", 1, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 2, 134222248),
                    new("notFirst", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665745), 3, 134222249),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 40, 68));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665746,
                "ShuffleNotFirst", 150, "1001020115126D011E001E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Collections.Generic.List`1<T>", "T"], 1,
                [
                    new("list", 0, 0, "System.Collections.Generic.List`1<T>", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665746),
                            ]), 1, 134222250),
                    new("notFirst", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665746), 2, 134222251),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665747,
                "Invert", 150, "000111808D11808D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Color", ["Microsoft.Xna.Framework.Color"], 0,
                [
                    new("color", 0, 0, "Microsoft.Xna.Framework.Color", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134222252),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 16, 52));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665748,
                "HexToColor", 150, "000111808D0E", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Color",
                ["System.String"], 0,
                [
                    new("hex", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222253),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 88, 189));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665749,
                "HexToColor", 150, "000111808D08", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Color",
                ["System.Int32"], 0,
                [
                    new("hex", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222254),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 23, 54));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665750,
                "HsvToColor", 150, "000311808D0C0C0C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Color", ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("hue", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222255),
                    new("s", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222256),
                    new("v", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222257),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 96, 163));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665751,
                "ShortGameplayFormat", 150, "00010E1180F5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.String", ["System.TimeSpan"], 0,
                [
                    new("time", 0, 0, "System.TimeSpan", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.TimeSpan"), 1, 134222258),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 18, 67));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665752,
                "LongGameplayFormat", 150, "00010E1180F5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.String", ["System.TimeSpan"], 0,
                [
                    new("time", 0, 0, "System.TimeSpan", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.TimeSpan"), 1, 134222259),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 48, 142));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665753,
                "Digits", 150, "00010808",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Int32"], 0,
                [
                    new("num", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222260),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 18, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665754,
                "HexToByte", 150, "00010503", (KeyValuePair<string, string>[])[], "System.Byte",
                ["System.Char"], 0,
                [
                    new("c", 0, 0, "System.Char", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 1, 134222261),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665755,
                "Percent", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("num", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222262),
                    new("zeroAt", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222263),
                    new("oneAt", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222264),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 11, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665756,
                "SignThreshold", 150, "00020C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222265),
                    new("threshold", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222266),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 10, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665757,
                "Min", 150, "00010C1D0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single[]"], 0,
                [
                    new("values", 0, 0, "System.Single[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222267),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 24, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665758,
                "Max", 150, "00010C1D0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single[]"], 0,
                [
                    new("values", 0, 0, "System.Single[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222268),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 24, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665759,
                "Max", 150, "00040808080808", (KeyValuePair<string, string>[])[], "System.Int32",
                ["System.Int32", "System.Int32", "System.Int32", "System.Int32"], 0,
                [
                    new("a", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222269),
                    new("b", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222270),
                    new("c", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222271),
                    new("d", 3, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 4, 134222272),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665760,
                "ToRad", 150, "00010C0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Single"], 0,
                [
                    new("f", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222273),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665761,
                "ToDeg", 150, "00010C0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Single"], 0,
                [
                    new("f", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222274),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665762,
                "Axis", 150, "000308020208", (KeyValuePair<string, string>[])[], "System.Int32",
                ["System.Boolean", "System.Boolean", "System.Int32"], 0,
                [
                    new("negative", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134222275),
                    new("positive", 1, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134222276),
                    new("both", 2, 4112, "System.Int32", true, "System.Int32",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222277),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 14, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665763,
                "Clamp", 150, "000308080808", (KeyValuePair<string, string>[])[], "System.Int32",
                ["System.Int32", "System.Int32", "System.Int32"], 0,
                [
                    new("value", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222278),
                    new("min", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222279),
                    new("max", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222280),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665764,
                "Clamp", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222281),
                    new("min", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222282),
                    new("max", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222283),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665765,
                "YoYo", 150, "00010C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222284),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 15, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665766,
                "Map", 150, "00050C0C0C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("val", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222285),
                    new("min", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222286),
                    new("max", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222287),
                    new("newMin", 3, 4112, "System.Single", true, "System.Single",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134222288),
                    new("newMax", 4, 4112, "System.Single", true, "System.Single",
                        [0x00, 0x00, 0x80, 0x3F],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134222289),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 14, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665767,
                "SineMap", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("counter", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222290),
                    new("newMin", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222291),
                    new("newMax", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222292),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 10, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665768,
                "ClampedMap", 150, "00050C0C0C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("val", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222293),
                    new("min", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222294),
                    new("max", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222295),
                    new("newMin", 3, 4112, "System.Single", true, "System.Single",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134222296),
                    new("newMax", 4, 4112, "System.Single", true, "System.Single",
                        [0x00, 0x00, 0x80, 0x3F],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134222297),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 17, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665769,
                "LerpSnap", 150, "00040C0C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("value1", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222298),
                    new("value2", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222299),
                    new("amount", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222300),
                    new("snapThreshold", 3, 4112, "System.Single", true,
                        "System.Single",
                        [0xCD, 0xCC, 0xCC, 0x3D],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134222301),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 15, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665770,
                "LerpClamp", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("value1", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222302),
                    new("value2", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222303),
                    new("lerp", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222304),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 8, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665771,
                "LerpSnap", 150, "00041180851180851180850C0C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single",
                    "System.Single",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222305),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222306),
                    new("amount", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222307),
                    new("snapThresholdSq", 3, 4112, "System.Single", true,
                        "System.Single",
                        [0xCD, 0xCC, 0xCC, 0x3D],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134222308),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 17, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665772,
                "Sign", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222309),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 10, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665773,
                "SafeNormalize", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222310),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665774,
                "SafeNormalize", 150, "00021180851180850C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222311),
                    new("length", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222312),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665775,
                "SafeNormalize", 150, "0002118085118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222313),
                    new("ifZero", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222314),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 10, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665776,
                "SafeNormalize", 150, "00031180851180851180850C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222315),
                    new("ifZero", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222316),
                    new("length", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222317),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665777,
                "TurnRight", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222318),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665778,
                "ReflectAngle", 150, "00020C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single"], 0,
                [
                    new("angle", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222319),
                    new("axis", 1, 4112, "System.Single", true, "System.Single",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222320),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 7, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665779,
                "ReflectAngle", 150, "00020C0C118085", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("angleRadians", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222321),
                    new("axis", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222322),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665780,
                "ClosestPointOnLine", 150, "0003118085118085118085118085", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                ], 0,
                [
                    new("lineA", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222323),
                    new("lineB", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222324),
                    new("closestTo", 2, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134222325),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 25, 61));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665781,
                "Round", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222326),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 32));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665782,
                "Snap", 150, "00020C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222327),
                    new("increment", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222328),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 9, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665783,
                "Snap", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222329),
                    new("increment", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222330),
                    new("offset", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222331),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 13, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665784,
                "WrapAngleDeg", 150, "00010C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single"], 0,
                [
                    new("angleDegrees", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222332),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 16, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665785,
                "WrapAngle", 150, "00010C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single"], 0,
                [
                    new("angleRadians", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222333),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 16, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665786,
                "AngleToVector", 150, "00021180850C0C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["System.Single", "System.Single"], 0,
                [
                    new("angleRadians", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222334),
                    new("length", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222335),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665787,
                "AngleApproach", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("val", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222336),
                    new("target", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222337),
                    new("maxMove", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222338),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 18, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665788,
                "AngleLerp", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("startAngle", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222339),
                    new("endAngle", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222340),
                    new("percent", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222341),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 8, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665789,
                "Approach", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("val", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222342),
                    new("target", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222343),
                    new("maxMove", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222344),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 15, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665790,
                "AngleDiff", 150, "00020C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single"], 0,
                [
                    new("radiansA", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222345),
                    new("radiansB", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222346),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 22, 42));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665791,
                "AbsAngleDiff", 150, "00020C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single"], 0,
                [
                    new("radiansA", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222347),
                    new("radiansB", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222348),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665792,
                "SignAngleDiff", 150, "0002080C0C", (KeyValuePair<string, string>[])[], "System.Int32",
                ["System.Single", "System.Single"], 0,
                [
                    new("radiansA", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222349),
                    new("radiansB", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222350),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665793,
                "Angle", 150, "00020C118085118085", (KeyValuePair<string, string>[])[], "System.Single",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("from", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222351),
                    new("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222352),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 15, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665794,
                "ToggleColors", 150, "000311808D11808D11808D11808D", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Color",
                [
                    "Microsoft.Xna.Framework.Color", "Microsoft.Xna.Framework.Color", "Microsoft.Xna.Framework.Color",
                ],
                0,
                [
                    new("current", 0, 0, "Microsoft.Xna.Framework.Color", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134222353),
                    new("a", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 2, 134222354),
                    new("b", 2, 0, "Microsoft.Xna.Framework.Color", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 3, 134222355),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 8, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665795,
                "ShorterAngleDifference", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("currentAngle", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222356),
                    new("angleA", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222357),
                    new("angleB", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222358),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 13, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665796,
                "ShorterAngleDifference", 150, "00040C0C0C0C0C", (KeyValuePair<string, string>[])[],
                "System.Single",
                ["System.Single", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("currentAngle", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222359),
                    new("angleA", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222360),
                    new("angleB", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222361),
                    new("angleC", 3, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134222362),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 19, 44));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665797,
                "IsInRange", 150, "100102021D1E0008",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["T[]", "System.Int32"], 1,
                [
                    new("array", 0, 0, "T[]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665797), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222363),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222364),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 11, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665798,
                "IsInRange", 150, "1001020215126D011E0008",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["System.Collections.Generic.List`1<T>", "System.Int32"], 1,
                [
                    new("list", 0, 0, "System.Collections.Generic.List`1<T>", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665798),
                            ]), 1, 134222365),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222366),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665799,
                "Array", 150, "1001011D1E001D1E00", (KeyValuePair<string, string>[])[], "T[]", ["T[]"],
                1,
                [
                    new("items", 0, 0, "T[]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665799), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222367),
                ], null,
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: SourceGenericParameterOwnerKind
                            .Method,
                        ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665799), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 2, 2));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665800,
                "VerifyLength", 150, "1001021D1E001D1E0008",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T[]", ["T[]", "System.Int32"], 1,
                [
                    new("array", 0, 0, "T[]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665800), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222368),
                    new("length", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222369),
                ], null,
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: SourceGenericParameterOwnerKind
                            .Method,
                        ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665800), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 37, 61));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665801,
                "VerifyLength", 150, "1001031D1D1E001D1D1E000808",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T[][]", ["T[][]", "System.Int32", "System.Int32"], 1,
                [
                    new("array", 0, 0, "T[][]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.SzArray,
                                elementType: new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665801),
                                arrayRank: 1,
                                arrayDimensions: [new(null, null)]),
                            arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222370),
                    new("length0", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222371),
                    new("length1", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222372),
                ], null,
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.SzArray,
                        elementType: new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665801), arrayRank: 1,
                        arrayDimensions: [new(null, null)]), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 26, 37));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665802,
                "BetweenInterval", 150, "0002020C0C", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Single", "System.Single"], 0,
                [
                    new("val", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222373),
                    new("interval", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222374),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 8, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665803,
                "OnInterval", 150, "0003020C0C0C", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("val", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222375),
                    new("prevVal", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222376),
                    new("interval", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222377),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 12, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665804,
                "Toward", 150, "00031180851180851180850C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("from", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222378),
                    new("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222379),
                    new("length", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222380),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665805,
                "Toward", 150, "00031180851284181284180C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Monocle.Entity", "Monocle.Entity", "System.Single"], 0,
                [
                    new("from", 0, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 1, 134222381),
                    new("to", 1, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 2, 134222382),
                    new("length", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222383),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665806,
                "Perpendicular", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222384),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665807,
                "Angle", 150, "00010C118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222385),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665808,
                "Clamp", 150, "00051180851180850C0C0C0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single", "System.Single",
                    "System.Single",
                ], 0,
                [
                    new("val", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222386),
                    new("minX", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222387),
                    new("minY", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222388),
                    new("maxX", 3, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134222389),
                    new("maxY", 4, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134222390),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665809,
                "Floor", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("val", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222391),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665810,
                "Ceiling", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("val", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222392),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665811,
                "Abs", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("val", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222393),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 8, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665812,
                "Approach", 150, "00031180851180851180850C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("val", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222394),
                    new("target", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222395),
                    new("maxMove", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222396),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 27, 60));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665813,
                "FourWayNormal", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222397),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 52, 166));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665814,
                "EightWayNormal", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222398),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 39, 126));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665815,
                "SnappedNormal", 150, "00021180851180850C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222399),
                    new("slices", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222400),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 20, 44));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665816,
                "Snapped", 150, "00021180851180850C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222401),
                    new("slices", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222402),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 21, 46));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665817,
                "XComp", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222403),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665818,
                "YComp", 150, "0001118085118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222404),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665819,
                "ParseVector2List", 150, "00021D1180850E03", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2[]", ["System.String", "System.Char"], 0,
                [
                    new("list", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222405),
                    new("seperator", 1, 4112, "System.Char", true, "System.Char",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x7C, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 2, 134222406),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 53, 92));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665820,
                "Rotate", 150, "00021180851180850C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222407),
                    new("angleRadians", 1, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222408),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 8, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665821,
                "RotateTowards", 150, "00031180851180850C0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single"], 0,
                [
                    new("vec", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222409),
                    new("targetAngleRadians", 1, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222410),
                    new("maxMoveRadians", 2, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222411),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 9, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665822,
                "RotateTowards", 150, "00031181551181551181550C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector3",
                ["Microsoft.Xna.Framework.Vector3", "Microsoft.Xna.Framework.Vector3", "System.Single"], 0,
                [
                    new("from", 0, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 1, 134222412),
                    new("target", 1, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 2, 134222413),
                    new("maxRotationRadians", 2, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222414),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 48, 106));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665823,
                "XZ",
                150, "0001118085118155",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector3"], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 1, 134222415),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665824,
                "Approach", 150, "00031181551181551181550C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector3",
                ["Microsoft.Xna.Framework.Vector3", "Microsoft.Xna.Framework.Vector3", "System.Single"], 0,
                [
                    new("v", 0, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 1, 134222416),
                    new("target", 1, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 2, 134222417),
                    new("amount", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222418),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 19, 45));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665825,
                "SafeNormalize", 150, "0001118155118155",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector3", ["Microsoft.Xna.Framework.Vector3"], 0,
                [
                    new("v", 0, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 1, 134222419),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 12, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665826,
                "ReadCSVIntGrid", 150, "0003140802000200000E0808", (KeyValuePair<string, string>[])[],
                "System.Int32[0...,0...]", ["System.String", "System.Int32", "System.Int32"], 0,
                [
                    new("csv", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222420),
                    new("width", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222421),
                    new("height", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222422),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Array,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Int32"), arrayRank: 2,
                    arrayDimensions:
                    [
                        new(0, null),
                        new(0, null),
                    ]), true, 90, 151));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665827,
                "ReadCSVInt", 150, "00011D080E", (KeyValuePair<string, string>[])[], "System.Int32[]",
                ["System.String"], 0,
                [
                    new("csv", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222423),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Int32"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 43, 79));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665828,
                "ReadCSVIntWithTricks", 150, "00011D080E", (KeyValuePair<string, string>[])[], "System.Int32[]",
                ["System.String"], 0,
                [
                    new("csv", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222424),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Int32"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 119, 253));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665829,
                "ReadCSV", 150, "00011D0E0E", (KeyValuePair<string, string>[])[], "System.String[]",
                ["System.String"], 0,
                [
                    new("csv", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222425),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.String"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 37, 65));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665830,
                "IntGridToCSV", 150, "00010E14080200020000", (KeyValuePair<string, string>[])[], "System.String",
                ["System.Int32[0...,0...]"], 0,
                [
                    new("data", 0, 0, "System.Int32[0...,0...]", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Array,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32"), arrayRank: 2,
                            arrayDimensions:
                            [
                                new(0, null),
                                new(0, null),
                            ]), 1, 134222426),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 99, 196));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665831,
                "GetBitData", 150, "0002140202000200000E03", (KeyValuePair<string, string>[])[],
                "System.Boolean[0...,0...]", ["System.String", "System.Char"], 0,
                [
                    new("data", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222427),
                    new("rowSep", 1, 4112, "System.Char", true, "System.Char",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x0A, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 2, 134222428),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Array,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Boolean"), arrayRank: 2,
                    arrayDimensions:
                    [
                        new(0, null),
                        new(0, null),
                    ]), true, 107, 208));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665832,
                "CombineBitData", 150, "000301140202000200000E03", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Boolean[0...,0...]", "System.String", "System.Char"], 0,
                [
                    new("combineInto", 0, 0, "System.Boolean[0...,0...]", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Array,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean"), arrayRank: 2,
                            arrayDimensions:
                            [
                                new(0, null),
                                new(0, null),
                            ]), 1, 134222429),
                    new("data", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222430),
                    new("rowSep", 2, 4112, "System.Char", true, "System.Char",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x0A, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 3, 134222431),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 50, 72));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665833,
                "CombineBitData", 150, "0002011402020002000014020200020000", (KeyValuePair<string, string>[])[],
                "System.Void", ["System.Boolean[0...,0...]", "System.Boolean[0...,0...]"], 0,
                [
                    new("combineInto", 0, 0, "System.Boolean[0...,0...]", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Array,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean"), arrayRank: 2,
                            arrayDimensions:
                            [
                                new(0, null),
                                new(0, null),
                            ]), 1, 134222432),
                    new("data", 1, 0, "System.Boolean[0...,0...]", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Array,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean"), arrayRank: 2,
                            arrayDimensions:
                            [
                                new(0, null),
                                new(0, null),
                            ]), 2, 134222433),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 35, 56));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665834,
                "ConvertStringArrayToIntArray", 150, "00011D081D0E", (KeyValuePair<string, string>[])[],
                "System.Int32[]", ["System.String[]"], 0,
                [
                    new("strings", 0, 0, "System.String[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222434),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Int32"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 26, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665835,
                "ConvertStringArrayToFloatArray", 150, "00011D0C1D0E", (KeyValuePair<string, string>[])[],
                "System.Single[]", ["System.String[]"], 0,
                [
                    new("strings", 0, 0, "System.String[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222435),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Single"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 27, 41));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665836,
                "FileExists", 150, "0001020E", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.String"], 0,
                [
                    new("filename", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222436),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665837,
                "SaveFile", 150, "100102021E000E", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["T", "System.String"], 1,
                [
                    new("obj", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665837), 1, 134222437),
                    new("filename", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222438),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 26, 60));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665838,
                "LoadFile", 150, "100102020E101E00", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.String", "T&"], 1,
                [
                    new("filename", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222439),
                    new("data", 1, 0, "T&", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665838)), 2,
                        134222440),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 29, 67));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665839,
                "LoadContentXML", 150, "000112811D0E", (KeyValuePair<string, string>[])[], "System.Xml.XmlDocument",
                ["System.String"], 0,
                [
                    new("filename", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222441),
                ], "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Xml.XmlDocument"), true, 20, 54));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665840,
                "LoadXML", 150, "000112811D0E", (KeyValuePair<string, string>[])[], "System.Xml.XmlDocument",
                ["System.String"], 0,
                [
                    new("filename", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222442),
                ], "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Xml.XmlDocument"), true, 16, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665841,
                "ContentXMLExists", 150, "0001020E", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.String"], 0,
                [
                    new("filename", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222443),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665842,
                "XMLExists", 150, "0001020E", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.String"], 0,
                [
                    new("filename", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222444),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665843,
                "HasAttr", 150, "0002021281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222445),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222446),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 7, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665844,
                "Attr", 150, "00020E1281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.String", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222447),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222448),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665845,
                "Attr", 150, "00030E1281110E0E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.String", ["System.Xml.XmlElement", "System.String", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222449),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222450),
                    new("defaultValue", 2, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134222451),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 12, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665846,
                "AttrInt", 150, "0002081281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222452),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222453),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 7, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665847,
                "AttrInt", 150, "0003081281110E08",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement", "System.String", "System.Int32"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222454),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222455),
                    new("defaultValue", 2, 0, "System.Int32", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222456),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 13, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665848,
                "AttrFloat", 150, "00020C1281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222457),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222458),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 8, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665849,
                "AttrFloat", 150, "00030C1281110E0C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Xml.XmlElement", "System.String", "System.Single"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222459),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222460),
                    new("defaultValue", 2, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222461),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 14, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665850,
                "AttrVector3", 150, "00021181551281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector3", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222462),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222463),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 35, 88));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665851,
                "AttrVector2", 150, "00031180851281110E0E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["System.Xml.XmlElement", "System.String", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222464),
                    new("xAttributeName", 1, 0, "System.String", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222465),
                    new("yAttributeName", 2, 0, "System.String", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134222466),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665852,
                "AttrVector2", 150, "00041180851281110E0E118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["System.Xml.XmlElement", "System.String", "System.String", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222467),
                    new("xAttributeName", 1, 0, "System.String", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222468),
                    new("yAttributeName", 2, 0, "System.String", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134222469),
                    new("defaultValue", 3, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null, [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 4, 134222470),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 32));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665853,
                "AttrBool", 150, "0002021281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222471),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222472),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 7, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665854,
                "AttrBool", 150, "0003021281110E02",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["System.Xml.XmlElement", "System.String", "System.Boolean"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222473),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222474),
                    new("defaultValue", 2, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134222475),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665855,
                "AttrChar", 150, "0002031281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Char", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222476),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222477),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Char"), true, 7, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665856,
                "AttrChar", 150, "0003031281110E03",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Char", ["System.Xml.XmlElement", "System.String", "System.Char"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222478),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222479),
                    new("defaultValue", 2, 0, "System.Char", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 3, 134222480),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Char"), true, 10, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665857,
                "AttrEnum", 150, "1001021E001281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Xml.XmlElement", "System.String"], 1,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222481),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222482),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665857), true, 22, 83));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665858,
                "AttrEnum", 150, "1001031E001281110E1E00",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Xml.XmlElement", "System.String", "T"], 1,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222483),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222484),
                    new("defaultValue", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665858), 3, 134222485),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665858), true, 10, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665859,
                "AttrHexColor", 150, "000211808D1281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Color", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222486),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222487),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665860,
                "AttrHexColor", 150, "000311808D1281110E11808D",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Color",
                ["System.Xml.XmlElement", "System.String", "Microsoft.Xna.Framework.Color"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222488),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222489),
                    new("defaultValue", 2, 0, "Microsoft.Xna.Framework.Color", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 3, 134222490),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 10, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665861,
                "AttrHexColor", 150, "000311808D1281110E0E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Color", ["System.Xml.XmlElement", "System.String", "System.String"],
                0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222491),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222492),
                    new("defaultValue", 2, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134222493),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 11, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665862,
                "Position", 150, "0001118085128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222494),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 8, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665863,
                "Position", 150, "0002118085128111118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["System.Xml.XmlElement", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222495),
                    new("defaultPosition", 1, 0, "Microsoft.Xna.Framework.Vector2",
                        false,
                        null, [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222496),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 40));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665864,
                "X",
                150, "000108128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222497),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665865,
                "X",
                150, "00020812811108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement", "System.Int32"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222498),
                    new("defaultX", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222499),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665866,
                "Y",
                150, "000108128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222500),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665867,
                "Y",
                150, "00020812811108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement", "System.Int32"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222501),
                    new("defaultY", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222502),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665868,
                "Width", 150, "000108128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222503),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665869,
                "Width", 150, "00020812811108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement", "System.Int32"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222504),
                    new("defaultWidth", 1, 0, "System.Int32", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222505),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665870,
                "Height", 150, "000108128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222506),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665871,
                "Height", 150, "00020812811108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement", "System.Int32"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222507),
                    new("defaultHeight", 1, 0, "System.Int32", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222508),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665872,
                "Rect", 150, "0001118091128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Rectangle", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222509),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Rectangle"), true, 10, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665873,
                "ID",
                150, "000108128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222510),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665874,
                "InnerInt", 150, "000108128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Int32", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222511),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
        }
    }
}
