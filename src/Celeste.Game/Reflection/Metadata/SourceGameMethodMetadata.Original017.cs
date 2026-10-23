using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishOriginal017(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665875,
                "InnerFloat", 150, "00010C128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Single", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222512),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665876,
                "InnerBool", 150, "000102128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Boolean", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222513),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665877,
                "InnerEnum", 150, "1001011E00128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["System.Xml.XmlElement"], 1,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222514),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665877), true, 16, 61));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665878,
                "InnerHexColor", 150, "000111808D128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Color", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222515),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665879,
                "HasChild", 150, "0002021281110E",
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
                            "System.Xml.XmlElement"), 1, 134222516),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222517),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665880,
                "ChildText", 150, "00020E1281110E",
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
                            "System.Xml.XmlElement"), 1, 134222518),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222519),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665881,
                "ChildText", 150, "00030E1281110E0E",
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
                            "System.Xml.XmlElement"), 1, 134222520),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222521),
                    new("defaultValue", 2, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134222522),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 11, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665882,
                "ChildInt", 150, "0002081281110E",
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
                            "System.Xml.XmlElement"), 1, 134222523),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222524),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665883,
                "ChildInt", 150, "0003081281110E08",
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
                            "System.Xml.XmlElement"), 1, 134222525),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222526),
                    new("defaultValue", 2, 0, "System.Int32", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134222527),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 11, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665884,
                "ChildFloat", 150, "00020C1281110E",
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
                            "System.Xml.XmlElement"), 1, 134222528),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222529),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665885,
                "ChildFloat", 150, "00030C1281110E0C",
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
                            "System.Xml.XmlElement"), 1, 134222530),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222531),
                    new("defaultValue", 2, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222532),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 11, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665886,
                "ChildBool", 150, "0002021281110E",
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
                            "System.Xml.XmlElement"), 1, 134222533),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222534),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665887,
                "ChildBool", 150, "0003021281110E02",
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
                            "System.Xml.XmlElement"), 1, 134222535),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222536),
                    new("defaultValue", 2, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134222537),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 11, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665888,
                "ChildEnum", 150, "1001021E001281110E",
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
                            "System.Xml.XmlElement"), 1, 134222538),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222539),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665888), true, 20, 73));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665889,
                "ChildEnum", 150, "1001031E001281110E1E00",
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
                            "System.Xml.XmlElement"), 1, 134222540),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222541),
                    new("defaultValue", 2, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665889), 3, 134222542),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665889), true, 26, 84));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665890,
                "ChildHexColor", 150, "000211808D1281110E",
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
                            "System.Xml.XmlElement"), 1, 134222543),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222544),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665891,
                "ChildHexColor", 150, "000311808D1281110E11808D",
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
                            "System.Xml.XmlElement"), 1, 134222545),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222546),
                    new("defaultValue", 2, 0, "Microsoft.Xna.Framework.Color", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 3, 134222547),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 12, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665892,
                "ChildHexColor", 150, "000311808D1281110E0E",
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
                            "System.Xml.XmlElement"), 1, 134222548),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222549),
                    new("defaultValue", 2, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134222550),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 13, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665893,
                "ChildPosition", 150, "00021180851281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222551),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222552),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665894,
                "ChildPosition", 150, "00031180851281110E118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2",
                ["System.Xml.XmlElement", "System.String", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222553),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222554),
                    new("defaultValue", 2, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null, [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134222555),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665895,
                "FirstNode", 150, "0001118085128111",
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
                            "System.Xml.XmlElement"), 1, 134222556),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 22, 71));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665896,
                "FirstNodeNullable", 150, "00011511808901118085128111",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Nullable`1<Microsoft.Xna.Framework.Vector2>", ["System.Xml.XmlElement"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222557),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"),
                    ]), true, 25, 80));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665897,
                "FirstNodeNullable", 150, "00021511808901118085128111118085",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Nullable`1<Microsoft.Xna.Framework.Vector2>",
                ["System.Xml.XmlElement", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222558),
                    new("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222559),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"),
                    ]), true, 27, 86));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665898,
                "Nodes", 150, "00021D11808512811102",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2[]", ["System.Xml.XmlElement", "System.Boolean"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222560),
                    new("includePosition", 1, 4112, "System.Boolean", true,
                        "System.Boolean", /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134222561),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 107, 283));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665899,
                "Nodes", 150, "00031D11808512811111808502",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2[]",
                ["System.Xml.XmlElement", "Microsoft.Xna.Framework.Vector2", "System.Boolean"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222562),
                    new("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134222563),
                    new("includePosition", 2, 4112, "System.Boolean", true,
                        "System.Boolean", /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134222564),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 26, 48));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665900,
                "GetNode", 150, "000211808512811108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector2", ["System.Xml.XmlElement", "System.Int32"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222565),
                    new("nodeNum", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222566),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665901,
                "GetNodeNullable", 150, "0002151180890111808512811108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Nullable`1<Microsoft.Xna.Framework.Vector2>",
                ["System.Xml.XmlElement", "System.Int32"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222567),
                    new("nodeNum", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222568),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Nullable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"),
                    ]), true, 18, 41));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665902,
                "SetAttr", 150, "0003011281110E1C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Xml.XmlElement", "System.String", "System.Object"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222569),
                    new("attributeName", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222570),
                    new("setTo", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134222571),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 63));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665903,
                "SetChild", 150, "0003011281110E1C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Void", ["System.Xml.XmlElement", "System.String", "System.Object"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222572),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222573),
                    new("setTo", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134222574),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 26, 60));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665904,
                "CreateChild", 150, "000212811112811D0E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Xml.XmlElement", ["System.Xml.XmlDocument", "System.String"], 0,
                [
                    new("doc", 0, 0, "System.Xml.XmlDocument", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlDocument"), 1, 134222575),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222576),
                ], "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Xml.XmlElement"), true, 13, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665905,
                "CreateChild", 150, "00021281111281110E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.Xml.XmlElement", ["System.Xml.XmlElement", "System.String"], 0,
                [
                    new("xml", 0, 0, "System.Xml.XmlElement", false, null,
                        [],
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml.XmlElement"), 1, 134222577),
                    new("childName", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222578),
                ], "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Xml.XmlElement"), true, 14, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665906,
                "SortLeftToRight", 150, "000208128418128418", (KeyValuePair<string, string>[])[], "System.Int32",
                ["Monocle.Entity", "Monocle.Entity"], 0,
                [
                    new("a", 0, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 1, 134222579),
                    new("b", 1, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 2, 134222580),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665907,
                "SortRightToLeft", 150, "000208128418128418", (KeyValuePair<string, string>[])[], "System.Int32",
                ["Monocle.Entity", "Monocle.Entity"], 0,
                [
                    new("a", 0, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 1, 134222581),
                    new("b", 1, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 2, 134222582),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665908,
                "SortTopToBottom", 150, "000208128418128418", (KeyValuePair<string, string>[])[], "System.Int32",
                ["Monocle.Entity", "Monocle.Entity"], 0,
                [
                    new("a", 0, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 1, 134222583),
                    new("b", 1, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 2, 134222584),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665909,
                "SortBottomToTop", 150, "000208128418128418", (KeyValuePair<string, string>[])[], "System.Int32",
                ["Monocle.Entity", "Monocle.Entity"], 0,
                [
                    new("a", 0, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 1, 134222585),
                    new("b", 1, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 2, 134222586),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665910,
                "SortByDepth", 150, "000208128418128418", (KeyValuePair<string, string>[])[], "System.Int32",
                ["Monocle.Entity", "Monocle.Entity"], 0,
                [
                    new("a", 0, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 1, 134222587),
                    new("b", 1, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 2, 134222588),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665911,
                "SortByDepthReversed", 150, "000208128418128418", (KeyValuePair<string, string>[])[],
                "System.Int32",
                ["Monocle.Entity", "Monocle.Entity"], 0,
                [
                    new("a", 0, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 1, 134222589),
                    new("b", 1, 0, "Monocle.Entity", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Entity"), 2, 134222590),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665912,
                "Log", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665913,
                "TimeLog", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665914,
                "Log", 150, "0001011D1C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object[]"], 0,
                [
                    new("obj", 0, 0, "System.Object[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222591),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665915,
                "TimeLog", 150, "0001011C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134222592),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665916,
                "LogEach", 150, "1001010115128095011E00", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Collections.Generic.IEnumerable`1<T>"], 1,
                [
                    new("collection", 0, 0,
                        "System.Collections.Generic.IEnumerable`1<T>",
                        false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.Generic.IEnumerable`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.GenericParameter,
                                    genericParameterPosition: 0,
                                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                    ownerAssemblyIdentity:
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665916),
                            ]), 1, 134222593),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 37));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665917,
                "Dissect", 150, "0001011C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134222594),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 21, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665918,
                "StartTimer", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665919,
                "EndTimer", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 42, 117));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665920,
                "GetMethod", 150, "10010212816D1C0E", (KeyValuePair<string, string>[])[], "System.Delegate",
                ["System.Object", "System.String"], 1,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134222595),
                    new("method", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134222596),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Delegate"), true, 16, 42));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665921,
                "At",
                150, "1001021E00141E0002000200001184C0",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "T", ["T[0...,0...]", "Monocle.Pnt"], 1,
                [
                    new("arr", 0, 0, "T[0...,0...]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.Array,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665921), arrayRank: 2,
                            arrayDimensions:
                            [
                                new(0, null),
                                new(0, null),
                            ]), 1, 134222597),
                    new("at", 1, 0, "Monocle.Pnt", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Pnt"), 2, 134222598),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Method,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Calc", ownerMethodDefinitionToken: 100665921), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665922,
                "ConvertPath", 150, "00010E0E", (KeyValuePair<string, string>[])[], "System.String",
                ["System.String"], 0,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222599),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 8, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665923,
                "ReadNullTerminatedString", 150, "00010E128119",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "System.String", ["System.IO.BinaryReader"], 0,
                [
                    new("stream", 0, 0, "System.IO.BinaryReader", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IO.BinaryReader"), 1, 134222600),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 15, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665924,
                "Do",
                150, "00011280B51D1280B5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "0100174D6F6E6F636C652E43616C632B3C446F3E645F5F3234360000"),
                ], "System.Collections.IEnumerator", ["System.Collections.IEnumerator[]"], 0,
                [
                    new("numerators", 0, 0, "System.Collections.IEnumerator[]", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Collections.IEnumerator"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222601),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665925,
                "ClampTo", 150, "0002118091118091118091",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Rectangle",
                ["Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle"], 0,
                [
                    new("rect", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Rectangle"), 1, 134222602),
                    new("clamp", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Rectangle"), 2, 134222603),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Rectangle"), true, 66, 178));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc", 33554721, 100665926,
                ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 43));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<>c", 33555378,
                100671133,
                ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<>c", 33555378,
                100671134,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<>c", 33555378,
                100671135,
                "<GetBitData>b__152_0", 131, "20010203", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Char"], 0,
                [
                    new("c", 0, 0, "System.Char", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 1, 134227494),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 4, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<Do>d__246", 33555379,
                100671136, ".ctor", 6278, "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134227495),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<Do>d__246", 33555379,
                100671137, "System.IDisposable.Dispose", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<Do>d__246", 33555379,
                100671138, "MoveNext", 481, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 107, 249));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<Do>d__246", 33555379,
                100671139, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<Do>d__246", 33555379,
                100671140, "System.Collections.IEnumerator.Reset", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Calc+<Do>d__246", 33555379,
                100671141, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.QuaternionExt", 33554722,
                100665927, "Conjugated", 150, "0001118159118159",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Quaternion", ["Microsoft.Xna.Framework.Quaternion"], 0,
                [
                    new("q", 0, 0, "Microsoft.Xna.Framework.Quaternion", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Quaternion"), 1, 134222604),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Quaternion"), true, 6, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.QuaternionExt", 33554722,
                100665928, "LookAt", 150, "0004118159118159118155118155118155",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Quaternion",
                [
                    "Microsoft.Xna.Framework.Quaternion", "Microsoft.Xna.Framework.Vector3",
                    "Microsoft.Xna.Framework.Vector3", "Microsoft.Xna.Framework.Vector3",
                ], 0,
                [
                    new("q", 0, 0, "Microsoft.Xna.Framework.Quaternion", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Quaternion"), 1, 134222605),
                    new("from", 1, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 2, 134222606),
                    new("to", 2, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 3, 134222607),
                    new("up", 3, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 4, 134222608),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Quaternion"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.QuaternionExt", 33554722,
                100665929, "LookAt", 150, "0003118159118159118155118155",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Quaternion",
                [
                    "Microsoft.Xna.Framework.Quaternion", "Microsoft.Xna.Framework.Vector3",
                    "Microsoft.Xna.Framework.Vector3",
                ], 0,
                [
                    new("q", 0, 0, "Microsoft.Xna.Framework.Quaternion", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Quaternion"), 1, 134222609),
                    new("direction", 1, 0, "Microsoft.Xna.Framework.Vector3", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 2, 134222610),
                    new("up", 2, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 3, 134222611),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Quaternion"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.QuaternionExt", 33554722,
                100665930, "Forward", 150, "0001118155118159",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector3", ["Microsoft.Xna.Framework.Quaternion"], 0,
                [
                    new("q", 0, 0, "Microsoft.Xna.Framework.Quaternion", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Quaternion"), 1, 134222612),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.QuaternionExt", 33554722,
                100665931, "Left", 150, "0001118155118159",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector3", ["Microsoft.Xna.Framework.Quaternion"], 0,
                [
                    new("q", 0, 0, "Microsoft.Xna.Framework.Quaternion", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Quaternion"), 1, 134222613),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.QuaternionExt", 33554722,
                100665932, "Up", 150, "0001118155118159",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute", "01000000"),
                ],
                "Microsoft.Xna.Framework.Vector3", ["Microsoft.Xna.Framework.Quaternion"], 0,
                [
                    new("q", 0, 0, "Microsoft.Xna.Framework.Quaternion", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Quaternion"), 1, 134222614),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665933,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 31, 112));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665934,
                ".ctor", 6278, "2002010808", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "System.Int32"], 0,
                [
                    new("width", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222615),
                    new("height", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222616),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 31, 104));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665935,
                "ToString", 198, "20000E", (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 124, 318));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665936,
                "UpdateMatrices", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 61, 209));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665937,
                "CopyFrom", 134, "20010112848C", (KeyValuePair<string, string>[])[], "System.Void",
                ["Monocle.Camera"], 0,
                [
                    new("other", 0, 0, "Monocle.Camera", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Camera"), 1, 134222617),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 56));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665938,
                "get_Matrix", 2182, "20001180FD", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Matrix",
                [], 0, [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Matrix"), true, 8, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665939,
                "get_Inverse", 2182, "20001180FD", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Matrix",
                [], 0, [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Matrix"), true, 8, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665940,
                "get_Position", 2182, "2000118085", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665941,
                "set_Position", 2182, "200101118085", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222618),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665942,
                "get_Origin", 2182, "2000118085", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [], 0, [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665943,
                "set_Origin", 2182, "200101118085", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222619),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665944,
                "get_X", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665945,
                "set_X", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222620),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665946,
                "get_Y", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665947,
                "set_Y", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222621),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665948,
                "get_Zoom", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665949,
                "set_Zoom", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222622),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665950,
                "get_Angle", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665951,
                "set_Angle", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222623),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665952,
                "get_Left", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 11, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665953,
                "set_Left", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222624),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 48));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665954,
                "get_Right", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 16, 53));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665955,
                "set_Right", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222625),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665956,
                "get_Top", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 11, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665957,
                "set_Top", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222626),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 48));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665958,
                "get_Bottom", 2182, "20000C", (KeyValuePair<string, string>[])[], "System.Single", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 16, 53));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665959,
                "set_Bottom", 2182, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222627),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665960,
                "CenterOrigin", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665961,
                "RoundPosition", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 22, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665962,
                "ScreenToCamera", 134, "2001118085118085", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222628),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665963,
                "CameraToScreen", 134, "2001118085118085", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222629),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665964,
                "Approach", 134, "2002011180850C", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222630),
                    new("ease", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222631),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Camera", 33554723, 100665965,
                "Approach", 134, "2003011180850C0C", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single"], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134222632),
                    new("ease", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222633),
                    new("maxDistance", 2, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134222634),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 28, 78));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.CheatListener", 33554724,
                100665966, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 47));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.CheatListener", 33554724,
                100665967, "Update", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 115, 340));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.CheatListener", 33554724,
                100665968, "AddCheat", 134, "2002010E1280D5", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String", "System.Action"], 0,
                [
                    new("code", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222635),
                    new("onEntered", 1, 4112, "System.Action", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Action"), 2, 134222636),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 42));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.CheatListener", 33554724,
                100665969, "AddInput", 134, "20020103151280E50102", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Char", "System.Func`1<System.Boolean>"], 0,
                [
                    new("id", 0, 0, "System.Char", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"), 1, 134222637),
                    new("checker", 1, 0, "System.Func`1<System.Boolean>", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Func`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                            ]), 2, 134222638),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665970, "get_TotalWeight", 2182, "200008",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Int32", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665971, "set_TotalWeight", 2177, "20010108",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Int32"], 0,
                [
                    new("value", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222639),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665972, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665973, "Set", 134, "200201130008", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.Int32"], 0,
                [
                    new("choice", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.ChoiceSet`1"), 1, 134222640),
                    new("weight", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222641),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 40, 91));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665974, "get_Item", 2182, "2001081300", (KeyValuePair<string, string>[])[], "System.Int32",
                ["T"], 0,
                [
                    new("choice", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.ChoiceSet`1"), 1, 134222642),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 10, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665975, "set_Item", 2182, "200201130008", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.Int32"], 0,
                [
                    new("choice", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.ChoiceSet`1"), 1, 134222643),
                    new("value", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134222644),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665976, "Set", 134, "20020113000C", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.Single"], 0,
                [
                    new("choice", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.ChoiceSet`1"), 1, 134222645),
                    new("chance", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222646),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 59, 128));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665977, "SetMany", 134, "2002010C1D1300", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single", "T[]"], 0,
                [
                    new("totalChance", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222647),
                    new("choices", 1, 0, "T[]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.ChoiceSet`1"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134222648),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 138, 238));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665978, "Get", 134, "2001130012814D", (KeyValuePair<string, string>[])[], "T",
                ["System.Random"], 0,
                [
                    new("random", 0, 0, "System.Random", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Random"), 1, 134222649),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.ChoiceSet`1"), true, 39, 103));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1", 33554725,
                100665979, "Get", 134, "20001300", (KeyValuePair<string, string>[])[], "T", [], 0,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.ChoiceSet`1"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ChoiceSet`1+Choice",
                33555380,
                100671142, ".ctor", 6278, "200201130008", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.Int32"], 0,
                [
                    new("data", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.ChoiceSet`1+Choice"), 1, 134227496),
                    new("weight", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134227497),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665980,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665981,
                ".ctor", 6278, "20020113000C", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.Single"], 0,
                [
                    new("firstChoice", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Chooser`1"), 1, 134222650),
                    new("weight", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222651),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665982,
                ".ctor", 6278, "2001011D1300", (KeyValuePair<string, string>[])[], "System.Void",
                ["T[]"], 0,
                [
                    new("choices", 0, 0, "T[]", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                ownerTypeIdentity: "Monocle.Chooser`1"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222652),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 26, 44));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665983,
                "get_Count", 2182, "200008", (KeyValuePair<string, string>[])[], "System.Int32", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665984,
                "get_Item", 2182, "2001130008", (KeyValuePair<string, string>[])[], "T",
                ["System.Int32"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222653),
                ], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Chooser`1"), true, 15, 37));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665985,
                "set_Item", 2182, "200201081300", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "T"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222654),
                    new("value", 1, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Chooser`1"), 2, 134222655),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 16, 38));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665986,
                "Add", 134, "20021512849801130013000C", (KeyValuePair<string, string>[])[], "Monocle.Chooser`1<T>",
                ["T", "System.Single"], 0,
                [
                    new("choice", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Chooser`1"), 1, 134222656),
                    new("weight", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134222657),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Monocle.Chooser`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Chooser`1"),
                    ]), true, 18, 47));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665987,
                "Choose", 134, "20001300", (KeyValuePair<string, string>[])[], "T", [], 0,
                [], null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                    ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.Chooser`1"), true, 70, 177));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665988,
                "get_TotalWeight", 2182, "20000C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Single", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665989,
                "set_TotalWeight", 2177, "2001010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134222658),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665990,
                "get_CanChoose", 2182, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1", 33554726,
                100665991,
                "FromString", 150, "10010115128498011E000E", (KeyValuePair<string, string>[])[],
                "Monocle.Chooser`1<TT>", ["System.String"], 1,
                [
                    new("data", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222659),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Monocle.Chooser`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Method,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Chooser`1", ownerMethodDefinitionToken: 100665991),
                    ]), true, 99, 235));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Chooser`1+Choice", 33555381,
                100671143, ".ctor", 6278, "20020113000C", (KeyValuePair<string, string>[])[], "System.Void",
                ["T", "System.Single"], 0,
                [
                    new("value", 0, 0, "T", false, null, [], null,
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.Chooser`1+Choice"), 1, 134227498),
                    new("weight", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134227499),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665992,
                "get_FunctionKeyActions", 2182, "20001D1280D5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Action[]", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Action"), arrayRank: 1,
                    arrayDimensions: [new(null, null)]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665993,
                "set_FunctionKeyActions", 2177, "2001011D1280D5",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action[]"], 0,
                [
                    new("value", 0, 0, "System.Action[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Action"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134222660),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665994,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 33, 102));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665995,
                "Log", 134, "2002011C11808D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "Microsoft.Xna.Framework.Color"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134222661),
                    new("color", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 2, 134222662),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 132, 319));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665996,
                "Log", 134, "2001011C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134222663),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665997,
                "UpdateClosed", 131, "200001", (KeyValuePair<string, string>[])[], "System.Void", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 41, 100));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665998,
                "UpdateOpen", 131, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 98, 262));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100665999,
                "HandleKey", 129, "2001011171", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Input.Keys"], 0,
                [
                    new("key", 0, 0, "Microsoft.Xna.Framework.Input.Keys", false, null,
                        [],
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Input.Keys"), 1, 134222664),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 858, 2795));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666000,
                "EnterCommand", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 82, 180));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666001,
                "FindFirstTab", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 30, 74));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666002,
                "FindLastTab", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 29, 73));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666003,
                "Render", 131, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 121, 355));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666004,
                "ExecuteCommand", 134, "2002010E1D0E", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String", "System.String[]"], 0,
                [
                    new("command", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222665),
                    new("args", 1, 0, "System.String[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134222666),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 21, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666005,
                "ExecuteFunctionKeyAction", 134, "20010108", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32"], 0,
                [
                    new("num", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222667),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666006,
                "BuildCommandsList", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 105, 205));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666007,
                "ProcessMethod", 129, "20010112817D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodInfo"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodInfo", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Reflection.MethodInfo"), 1, 134222668),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 268, 806));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666008,
                "InvokeMethod", 129, "20020112817D1D1C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Reflection.MethodInfo", "System.Object[]"], 0,
                [
                    new("method", 0, 0, "System.Reflection.MethodInfo", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Reflection.MethodInfo"), 1, 134222669),
                    new("param", 1, 4112, "System.Object[]", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134222670),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 58));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666009,
                "LogStackTrace", 129, "2001010E", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String"], 0,
                [
                    new("stackTrace", 0, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222671),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 108, 238));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666010,
                "ArgString", 145, "00010E0E", (KeyValuePair<string, string>[])[], "System.String",
                ["System.String"], 0,
                [
                    new("arg", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222672),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 6, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666011,
                "ArgBool", 145, "0001020E", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.String"], 0,
                [
                    new("arg", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222673),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 22, 58));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666012,
                "ArgInt", 145, "0001080E", (KeyValuePair<string, string>[])[], "System.Int32",
                ["System.String"], 0,
                [
                    new("arg", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222674),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 10, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666013,
                "ArgFloat", 145, "00010C0E", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.String"], 0,
                [
                    new("arg", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222675),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 11, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666014,
                "Clear", 150, "000001",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "010005636C65617213436C6561727320746865207465726D696E616C0000"),
                ], "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666015,
                "Exit", 145, "000001",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "010004657869740E4578697473207468652067616D650000"),
                ], "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666016,
                "Vsync", 145, "00010102",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "0100057673796E6321456E61626C6573206F722064697361626C657320766572746963616C2073796E630000"),
                ], "System.Void", ["System.Boolean"], 0,
                [
                    new("enabled", 0, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134222676),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 57));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666017,
                "Count", 145, "00010108",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "010005636F756E745A4C6F677320616D6F756E74206F6620456E74697469657320696E20746865205363656E652E2050617373206120746167496E64657820746F20636F756E74206F6E6C7920456E74697469657320776974682074686174207461670000"),
                ], "System.Void", ["System.Int32"], 0,
                [
                    new("tagIndex", 0, 4112, "System.Int32", true, "System.Int32",
                        [0xFF, 0xFF, 0xFF, 0xFF],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222677),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 29, 101));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666018,
                "Tracker", 145, "0001010E",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "010007747261636B6572644C6F677320616C6C20747261636B6564206F626A6563747320696E20746865207363656E652E20536574206D6F646520746F2027652720666F72206A75737420656E7469746965732C206F722027632720666F72206A75737420636F6D706F6E656E74730000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("mode", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222678),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 35, 142));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666019,
                "Pooler", 145, "000001",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "010006706F6F6C65721D4C6F67732074686520706F6F6C656420456E7469747920636F756E74730000"),
                ], "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666020,
                "Fullscreen", 145, "000001",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "01000A66756C6C73637265656E1B537769746368657320746F2066756C6C73637265656E206D6F64650000"),
                ], "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666021,
                "Window", 145, "00010108",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "01000677696E646F7717537769746368657320746F2077696E646F77206D6F64650000"),
                ], "System.Void", ["System.Int32"], 0,
                [
                    new("scale", 0, 4112, "System.Int32", true, "System.Int32",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134222679),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands", 33554727,
                100666022,
                "Help", 145, "0001010E",
                (KeyValuePair<string, string>[])
                [
                    new("Monocle.Command",
                        "01000468656C702453686F77732075736167652068656C7020666F72206120676976656E20636F6D6D616E640000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("command", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134222680),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 71, 241));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Commands+Line", 33555383,
                100671144, ".ctor", 6278, "2001010E", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String"], 0,
                [
                    new("text", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134227500),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
        }
    }
}
