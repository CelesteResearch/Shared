using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishInstalled105(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationSpeedDecalRegistryHandler", 33557232, 100680097,
                "Parse", 198, "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233099),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationSpeedDecalRegistryHandler", 33557232, 100680098,
                "ApplyTo", 198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233100),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 32));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.AnimationSpeedDecalRegistryHandler", 33557232, 100680099,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler", 33557233, 100680100,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler", 33557233, 100680101, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233101),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 50, 150));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler", 33557233, 100680102, "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233102),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 38, 102));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BannerDecalRegistryHandler", 33557233, 100680103, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler", 33557234, 100680104, "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler", 33557234, 100680105, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233103),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 29, 93));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler", 33557234, 100680106, "ApplyTo",
                198,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233104),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 52));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler", 33557234, 100680107, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler", 33557235, 100680108,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler", 33557235, 100680109, "Parse",
                198, "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233105),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler", 33557235, 100680110,
                "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233106),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler", 33557235, 100680111, ".ctor",
                6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680112, "get_Name",
                3526,
                "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680113, "Parse", 1478,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233107),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680114, "ApplyTo", 1478,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233108),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680115, "Get", 134,
                "3001031E0012828D0E1E00", (KeyValuePair<string, string>[])[], "T",
                ["System.Xml.XmlAttributeCollection", "System.String", "T"], 1,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233109),
                    new("attr", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233110),
                    new("def", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler",
                            ownerMethodDefinitionToken: 100680115), 3, 134233111),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler",
                    ownerMethodDefinitionToken: 100680115), true, 69, 211));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680116, "GetBool", 134,
                "20030212828D0E02", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Xml.XmlAttributeCollection", "System.String", "System.Boolean"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233112),
                    new("attr", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233113),
                    new("def", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134233114),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 59, 163));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680117, "GetString",
                134,
                "20030E12828D0E0E", (KeyValuePair<string, string>[])[], "System.String",
                ["System.Xml.XmlAttributeCollection", "System.String", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233115),
                    new("attr", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233116),
                    new("def", 2, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134233117),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 11, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680118, "GetHexColor",
                134,
                "20031180AD12828D0E1180AD", (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color",
                ["System.Xml.XmlAttributeCollection", "System.String", "Microsoft.Xna.Framework.Color"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233118),
                    new("attr", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233119),
                    new("def", 2, 0, "Microsoft.Xna.Framework.Color", false, null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Color"), 3, 134233120),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Color"), true, 12, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680119,
                "GetCSVIntWithTricks", 134, "20031D0812828D0E0E", (KeyValuePair<string, string>[])[],
                "System.Int32[]",
                ["System.Xml.XmlAttributeCollection", "System.String", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233121),
                    new("attr", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233122),
                    new("def", 2, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134233123),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Int32"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 64, 179));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680120, "GetNullable",
                134,
                "30010215118141011E0012828D0E", (KeyValuePair<string, string>[])[], "System.Nullable`1<TParsable>",
                ["System.Xml.XmlAttributeCollection", "System.String"], 1,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233124),
                    new("attr", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233125),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler",
                            ownerMethodDefinitionToken: 100680120),
                    ]), true, 68, 211));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680121, "GetVector2",
                134,
                "20041180A112828D0E0E1180A1", (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                [
                    "System.Xml.XmlAttributeCollection", "System.String", "System.String",
                    "Microsoft.Xna.Framework.Vector2",
                ], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233126),
                    new("attrX", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134233127),
                    new("attrY", 2, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134233128),
                    new("def", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 4, 134233129),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 33557236, 100680122, ".ctor", 6276,
                "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler", 33557237, 100680123, "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler", 33557237, 100680124, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233130),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler", 33557237, 100680125, "ApplyTo",
                198,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233131),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 45));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler", 33557237, 100680126, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler", 33557238, 100680127,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler", 33557238, 100680128, "Parse",
                198, "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233132),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 22, 58));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler", 33557238, 100680129,
                "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233133),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler", 33557238, 100680130, ".ctor",
                6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler", 33557239, 100680131,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler", 33557239, 100680132, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233134),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler", 33557239, 100680133, "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233135),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler", 33557239, 100680134, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler", 33557240, 100680135,
                "get_Name",
                2246, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler", 33557240, 100680136, ".ctor",
                6278,
                "2002010E151285F10212996812828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String", "System.Action`2<Celeste.Decal,System.Xml.XmlAttributeCollection>"], 0,
                [
                    new("propName", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233136),
                    new("callback", 1, 0,
                        "System.Action`2<Celeste.Decal,System.Xml.XmlAttributeCollection>", false, null, [],
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
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Decal"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "System.Xml.XmlAttributeCollection"),
                            ]), 2, 134233137),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler", 33557240, 100680137, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233138),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler", 33557240, 100680138, "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233139),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler", 33557241, 100680139, "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler", 33557241, 100680140, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233140),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 43, 133));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler", 33557241, 100680141, "ApplyTo",
                198,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233141),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 32, 76));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler", 33557241, 100680142, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler", 33557242, 100680143,
                "get_Name", 2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler", 33557242, 100680144,
                "Parse",
                198, "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233142),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 36, 102));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler", 33557242, 100680145,
                "ApplyTo", 198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233143),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 29, 69));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler", 33557242, 100680146,
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler", 33557243, 100680147,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler", 33557243, 100680148, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233144),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler", 33557243, 100680149, "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233145),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 53));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler", 33557243, 100680150, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler", 33557244, 100680151,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler", 33557244, 100680152, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233146),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler", 33557244, 100680153,
                "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233147),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler", 33557244, 100680154, ".ctor",
                6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler", 33557245, 100680155,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler", 33557245, 100680156, "Parse",
                198, "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233148),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler", 33557245, 100680157,
                "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233149),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 37));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler", 33557245, 100680158, ".ctor",
                6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler", 33557246, 100680159,
                "get_Name", 2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler", 33557246, 100680160,
                "Parse", 198, "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233150),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler", 33557246, 100680161,
                "ApplyTo", 198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233151),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler", 33557246, 100680162,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler", 33557247, 100680163, "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler", 33557247, 100680164, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233152),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler", 33557247, 100680165, "ApplyTo",
                198,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233153),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler", 33557247, 100680166, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler", 33557248, 100680167,
                "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler", 33557248, 100680168, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233154),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 59, 181));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler", 33557248, 100680169, "ApplyTo",
                198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233155),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 28, 68));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler", 33557248, 100680170, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler", 33557249, 100680171, "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler", 33557249, 100680172, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233156),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 22, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler", 33557249, 100680173, "ApplyTo",
                198,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233157),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 38));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler", 33557249, 100680174, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler", 33557250, 100680175, "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler", 33557250, 100680176, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233158),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 57, 156));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler", 33557250, 100680177, "ApplyTo",
                198,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233159),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 38, 86));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler", 33557250, 100680178, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler", 33557251, 100680179, "get_Name",
                2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler", 33557251, 100680180, "Parse",
                198,
                "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233160),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler", 33557251, 100680181, "ApplyTo",
                198,
                "200101129968", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233161),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler", 33557251, 100680182, ".ctor",
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
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler", 33557252, 100680183,
                "get_Name", 2246, "20000E", (KeyValuePair<string, string>[])[], "System.String", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler", 33557252, 100680184,
                "Parse",
                198, "20010112828D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Xml.XmlAttributeCollection"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlAttributeCollection", false, null,
                        [],
                        "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml.ReaderWriter, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml.XmlAttributeCollection"), 1, 134233162),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 29, 79));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler", 33557252, 100680185,
                "ApplyTo", 198, "200101129968", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Decal"], 0,
                [
                    new("decal", 0, 0, "Celeste.Decal", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Decal"), 1, 134233163),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 27, 59));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler", 33557252, 100680186,
                ".ctor",
                6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680187, "get_Parent", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680188, "set_Parent", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233164),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680189, "get_Icon", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680190, "set_Icon", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233165),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680191, "get_Interlude", 2182, "2000151181410102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Boolean>", [], 0, [],
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
                            "System.Boolean"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680192, "set_Interlude", 2182, "200101151181410102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Boolean>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Boolean>", false, null,
                        [],
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
                                    "System.Boolean"),
                            ]), 1, 134233166),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680193, "get_CassetteCheckpointIndex", 2182, "2000151181410108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Int32>", [], 0, [],
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
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680194, "set_CassetteCheckpointIndex", 2182, "200101151181410108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Int32>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Int32>", false, null,
                        [],
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
                            ]), 1, 134233167),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680195, "get_TitleBaseColor", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680196, "set_TitleBaseColor", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233168),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680197, "get_TitleAccentColor", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680198, "set_TitleAccentColor", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233169),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680199, "get_TitleTextColor", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680200, "set_TitleTextColor", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233170),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680201, "get_IntroType", 2182, "20001511814101119F28",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<Celeste.Player+IntroTypes>", [], 0,
                [],
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
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player+IntroTypes"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680202, "set_IntroType", 2182, "2001011511814101119F28",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<Celeste.Player+IntroTypes>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<Celeste.Player+IntroTypes>",
                        false, null, [],
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
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player+IntroTypes"),
                            ]), 1, 134233171),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680203, "get_Dreaming", 2182, "2000151181410102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Boolean>", [], 0, [],
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
                            "System.Boolean"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680204, "set_Dreaming", 2182, "200101151181410102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Boolean>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Boolean>", false, null,
                        [],
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
                                    "System.Boolean"),
                            ]), 1, 134233172),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680205, "get_ColorGrade", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680206, "set_ColorGrade", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233173),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680207, "get_Wipe", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680208, "set_Wipe", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233174),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680209, "get_DarknessAlpha", 2182, "200015118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Single>", [], 0, [],
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
                            "System.Single"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680210, "set_DarknessAlpha", 2182, "20010115118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Single>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Single>", false, null,
                        [],
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
                                    "System.Single"),
                            ]), 1, 134233175),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680211, "get_BloomBase", 2182, "200015118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Single>", [], 0, [],
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
                            "System.Single"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680212, "set_BloomBase", 2182, "20010115118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Single>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Single>", false, null,
                        [],
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
                                    "System.Single"),
                            ]), 1, 134233176),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680213, "get_BloomStrength", 2182, "200015118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Single>", [], 0, [],
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
                            "System.Single"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680214, "set_BloomStrength", 2182, "20010115118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Single>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Single>", false, null,
                        [],
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
                                    "System.Single"),
                            ]), 1, 134233177),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680215, "get_Jumpthru", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680216, "set_Jumpthru", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233178),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680217, "get_CoreMode", 2182, "20001511814101119BE0",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<Celeste.Session+CoreModes>", [], 0,
                [],
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
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session+CoreModes"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680218, "set_CoreMode", 2182, "2001011511814101119BE0",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<Celeste.Session+CoreModes>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<Celeste.Session+CoreModes>",
                        false, null, [],
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
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Session+CoreModes"),
                            ]), 1, 134233179),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680219, "get_CassetteNoteColor", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680220, "set_CassetteNoteColor", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233180),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680221, "get_CassetteSong", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680222, "set_CassetteSong", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233181),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680223, "get_PostcardSoundID", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680224, "set_PostcardSoundID", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233182),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680225, "get_ForegroundTiles", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680226, "set_ForegroundTiles", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233183),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680227, "get_BackgroundTiles", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680228, "set_BackgroundTiles", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233184),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680229, "get_AnimatedTiles", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680230, "set_AnimatedTiles", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233185),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680231, "get_Sprites", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680232, "set_Sprites", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233186),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680233, "get_Portraits", 2182, "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680234, "set_Portraits", 2182, "2001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134233187),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680235, "get_OverrideASideMeta", 2182, "2000151181410102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Boolean>", [], 0, [],
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
                            "System.Boolean"),
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680236, "set_OverrideASideMeta", 2182, "200101151181410102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Boolean>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Boolean>", false, null,
                        [],
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
                                    "System.Boolean"),
                            ]), 1, 134233188),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680237, "get_Modes", 2182, "20001D12AC24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Celeste.Mod.Meta.MapMetaModeProperties[]", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.Meta.MapMetaModeProperties"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680238, "set_Modes", 2182, "2001011D12AC24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Meta.MapMetaModeProperties[]"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.Meta.MapMetaModeProperties[]",
                        false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Meta.MapMetaModeProperties"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134233189),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680239, "get_Mountain", 2182, "200012AC38",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Celeste.Mod.Meta.MapMetaMountain", [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Meta.MapMetaMountain"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680240, "set_Mountain", 2182, "20010112AC38",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Meta.MapMetaMountain"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.Meta.MapMetaMountain", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Meta.MapMetaMountain"), 1, 134233190),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680241, "get_CompleteScreen", 2182, "200012AC40",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Celeste.Mod.Meta.MapMetaCompleteScreen", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Meta.MapMetaCompleteScreen"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680242, "set_CompleteScreen", 2182, "20010112AC40",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Meta.MapMetaCompleteScreen"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.Meta.MapMetaCompleteScreen", false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Meta.MapMetaCompleteScreen"), 1, 134233191),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680243, "get_LoadingVignetteScreen", 2182, "200012AC40",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Celeste.Mod.Meta.MapMetaCompleteScreen", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Meta.MapMetaCompleteScreen"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680244, "set_LoadingVignetteScreen", 2182, "20010112AC40",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Meta.MapMetaCompleteScreen"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.Meta.MapMetaCompleteScreen", false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Meta.MapMetaCompleteScreen"), 1, 134233192),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680245, "get_LoadingVignetteText", 2182, "200012AC4C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Celeste.Mod.Meta.MapMetaTextVignette", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Meta.MapMetaTextVignette"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680246, "set_LoadingVignetteText", 2182, "20010112AC4C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Meta.MapMetaTextVignette"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.Meta.MapMetaTextVignette", false,
                        null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Meta.MapMetaTextVignette"), 1, 134233193),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680247, "get_CassetteModifier", 2182, "200012AC50",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Celeste.Mod.Meta.MapMetaCassetteModifier", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Meta.MapMetaCassetteModifier"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680248, "set_CassetteModifier", 2182, "20010112AC50",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Meta.MapMetaCassetteModifier"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.Meta.MapMetaCassetteModifier",
                        false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Meta.MapMetaCassetteModifier"), 1, 134233194),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680249, "get_Postcard", 2182, "200012AC54",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "Celeste.Mod.Meta.MapMetaPostcard", [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Meta.MapMetaPostcard"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680250, "set_Postcard", 2182, "20010112AC54",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Meta.MapMetaPostcard"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.Meta.MapMetaPostcard", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Meta.MapMetaPostcard"), 1, 134233195),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680251, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680252, ".ctor", 6278, "200101129234", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.BinaryPacker+Element"], 0,
                [
                    new("meta", 0, 0, "Celeste.BinaryPacker+Element", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.BinaryPacker+Element"), 1, 134233196),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680253, "Parse", 134, "200101129234", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.BinaryPacker+Element"], 0,
                [
                    new("meta", 0, 0, "Celeste.BinaryPacker+Element", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.BinaryPacker+Element"), 1, 134233197),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 273, 831));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680254, "ApplyTo", 134, "2001011296F4", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.AreaData"], 0,
                [
                    new("area", 0, 0, "Celeste.AreaData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.AreaData"), 1, 134233198),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 568, 1615));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680255, "ApplyToForOverride", 134, "2001011296F4", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Celeste.AreaData"], 0,
                [
                    new("area", 0, 0, "Celeste.AreaData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.AreaData"), 1, 134233199),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 87, 242));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Meta.MapMeta", 33557254,
                100680256, "Convert", 150, "00011D1296F01D12AC24", (KeyValuePair<string, string>[])[],
                "Celeste.ModeProperties[]", ["Celeste.Mod.Meta.MapMetaModeProperties[]"], 0,
                [
                    new("meta", 0, 0, "Celeste.Mod.Meta.MapMetaModeProperties[]", false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Meta.MapMetaModeProperties"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134233200),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.ModeProperties"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 38, 52));
        }
    }
}
