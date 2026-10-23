using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata.Sdk.InstalledFna
{
    public static class InstalledFnaVector2Metadata
    {
        public const string SourceAssemblySha256 = "862ce4418709a914c4bc89240026d71379fe06ee5c88d9fcf12d57600fad9cd4";
        public const string SourceModuleMvid = "654542fa-77ba-42c3-8d47-a3387d972081";

        public static void PublishMembersFacts(SourceMemberCatalog members)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            members.RegisterTypeDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                1057033, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ValueType",
                ["System.IEquatable`1<Microsoft.Xna.Framework.Vector2>"],
                [
                    new("System.ComponentModel.TypeConverterAttribute",
                        "System.Void System.ComponentModel.TypeConverterAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x2F, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x58, 0x6E,
                            0x61,
                            0x2E, 0x46, 0x72, 0x61, 0x6D, 0x65, 0x77, 0x6F, 0x72, 0x6B, 0x2E, 0x44, 0x65, 0x73, 0x69,
                            0x67,
                            0x6E, 0x2E, 0x56, 0x65, 0x63, 0x74, 0x6F, 0x72, 0x32, 0x43, 0x6F, 0x6E, 0x76, 0x65, 0x72,
                            0x74,
                            0x65, 0x72, 0x00, 0x00,
                        ]),
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x17, 0x7B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61,
                            0x79,
                            0x53, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x2C, 0x6E, 0x71, 0x7D, 0x00, 0x00,
                        ]),
                ],
                interfaceAssemblyIdentities:
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                genericParameters: [],
                baseTypeReference: new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                interfaceTypeReferences:
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IEquatable`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"),
                        ]),
                ]));
            PublishMembers0(members);
        }

        public static void PublishMethodFacts(SourceAssemblyMethodCatalog methods)
        {
            if (methods == null) throw new ArgumentNullException(nameof(methods));
            PublishMethods0(methods);
            PublishMethods1(methods);
            PublishMethods2(methods);
            PublishMethods3(methods);
            PublishMethods4(methods);
            PublishMethods5(methods);
            PublishMethods6(methods);
        }

        private static void PublishMembers0(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                67111564,
                "X", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                67111565,
                "Y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                67111566,
                "zeroVector", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                67111567,
                "unitVector", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                67111568,
                "unitXVector", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                67111569,
                "unitYVector", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                385876215,
                "Zero", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector2", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                385876216,
                "One", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector2", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                385876217,
                "UnitX", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector2", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                385876218,
                "UnitY", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector2", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                385876219,
                "DebugDisplayString", SourceMemberKind.Property, 0, "System.String", 2179, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
        }

        private static void PublishMethods0(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665724, "get_Zero", 2198, "0000118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665725, "get_One", 2198, "0000118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665726, "get_UnitX", 2198, "0000118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665727, "get_UnitY", 2198, "0000118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665728, "get_DebugDisplayString", 2179, "20000E", (KeyValuePair<string, string>[])[],
                "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 9, 33));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665729, ".ctor", 6278, "2002010C0C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single", "System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134221637),
                    new("y", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134221638),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665730, ".ctor", 6278, "2001010C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134221639),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665731, "Equals", 198, "2001021C", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134221640),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 23));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665732, "Equals", 486, "200102118594", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("other", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221641),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 13, 31));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665733, "GetHashCode", 198, "200008", (KeyValuePair<string, string>[])[], "System.Int32",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 8, 24));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665734, "Length", 134, "20000C", (KeyValuePair<string, string>[])[], "System.Single",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 18, 38));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665735, "LengthSquared", 134, "20000C", (KeyValuePair<string, string>[])[], "System.Single",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 17, 33));
        }

        private static void PublishMethods1(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665736, "Normalize", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 38, 82));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665737, "ToString", 198, "20000E", (KeyValuePair<string, string>[])[], "System.String",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 28, 64));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665738, "CheckForNaNs", 131, "200001",
                (KeyValuePair<string, string>[])
                [
                    new("System.Diagnostics.ConditionalAttribute", "01000544454255470000"),
                ],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 38));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665739, "Add", 150, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221642),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221643),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665740, "Add", 150, "000301101185941011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221644),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221645),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221646),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665741, "Barycentric", 150, "00051185941185941185941185940C0C",
                (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                    "System.Single", "System.Single",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221647),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221648),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134221649),
                    new("amount1", 3, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134221650),
                    new("amount2", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134221651),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 20, 58));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665742, "Barycentric", 150, "0006011011859410118594101185940C0C10118594",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "System.Single", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221652),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221653),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221654),
                    new("amount1", 3, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134221655),
                    new("amount2", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134221656),
                    new("result", 5, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 6, 134221657),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 23, 67));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665743, "CatmullRom", 150, "00051185941185941185941185941185940C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2", "System.Single",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221658),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221659),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134221660),
                    new("value4", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 4, 134221661),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134221662),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 22, 68));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665744, "CatmullRom", 150, "000601101185941011859410118594101185940C10118594",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221663),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221664),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221665),
                    new("value4", 3, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134221666),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134221667),
                    new("result", 5, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 6, 134221668),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 77));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665745, "Clamp", 150, "0003118594118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221669),
                    new("min", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221670),
                    new("max", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134221671),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 52));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665746, "Clamp", 150, "00040110118594101185941011859410118594",
                (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221672),
                    new("min", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221673),
                    new("max", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221674),
                    new("result", 3, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134221675),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 59));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665747, "Distance", 150, "00020C118594118594", (KeyValuePair<string, string>[])[],
                "System.Single",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221676),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221677),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 24, 44));
        }

        private static void PublishMethods2(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665748, "Distance", 150, "0003011011859410118594100C", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single&"],
                0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221678),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221679),
                    new("result", 2, 2, "System.Single&", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134221680),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665749, "DistanceSquared", 150, "00020C118594118594", (KeyValuePair<string, string>[])[],
                "System.Single", ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221681),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221682),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 23, 39));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665750, "DistanceSquared", 150, "0003011011859410118594100C", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single&"],
                0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221683),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221684),
                    new("result", 2, 2, "System.Single&", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134221685),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665751, "Divide", 150, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221686),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221687),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665752, "Divide", 150, "000301101185941011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221688),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221689),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221690),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665753, "Divide", 150, "00021185941185940C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221691),
                    new("divider", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134221692),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 10, 22));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665754, "Divide", 150, "000301101185940C10118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "System.Single", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221693),
                    new("divider", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134221694),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221695),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 29));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665755, "Dot", 150, "00020C118594118594", (KeyValuePair<string, string>[])[], "System.Single",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221696),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221697),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 17, 33));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665756, "Dot", 150, "0003011011859410118594100C", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single&"],
                0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221698),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221699),
                    new("result", 2, 2, "System.Single&", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134221700),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 19, 35));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665757, "Hermite", 150, "00051185941185941185941185941185940C",
                (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2", "System.Single",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221701),
                    new("tangent1", 1, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221702),
                    new("value2", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134221703),
                    new("tangent2", 3, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 4, 134221704),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134221705),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 11, 27));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665758, "Hermite", 150, "000601101185941011859410118594101185940C10118594",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221706),
                    new("tangent1", 1, 0, "Microsoft.Xna.Framework.Vector2&", false,
                        null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221707),
                    new("value2", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221708),
                    new("tangent2", 3, 0, "Microsoft.Xna.Framework.Vector2&", false,
                        null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134221709),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134221710),
                    new("result", 5, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 6, 134221711),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 77));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665759, "Lerp", 150, "00031185941185941185940C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221712),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221713),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134221714),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 42));
        }

        private static void PublishMethods3(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665760, "Lerp", 150, "00040110118594101185940C10118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221715),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221716),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134221717),
                    new("result", 3, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134221718),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 49));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665761, "Max", 150, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221719),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221720),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 22, 62));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665762, "Max", 150, "000301101185941011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221721),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221722),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221723),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 69));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665763, "Min", 150, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221724),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221725),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 22, 62));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665764, "Min", 150, "000301101185941011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221726),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221727),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221728),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 69));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665765, "Multiply", 150, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221729),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221730),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665766, "Multiply", 150, "00021185941185940C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221731),
                    new("scaleFactor", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134221732),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 26));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665767, "Multiply", 150, "000301101185940C10118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "System.Single", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221733),
                    new("scaleFactor", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134221734),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221735),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 29));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665768, "Multiply", 150, "000301101185941011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221736),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221737),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221738),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665769, "Negate", 150, "0001118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221739),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 30));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665770, "Negate", 150, "0002011011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221740),
                    new("result", 1, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221741),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 27));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665771, "Normalize", 150, "0001118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221742),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 4, 9));
        }

        private static void PublishMethods4(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665772, "Normalize", 150, "0002011011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void", ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221743),
                    new("result", 1, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221744),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 19));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665773, "Reflect", 150, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221745),
                    new("normal", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221746),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 34, 80));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665774, "Reflect", 150, "000301101185941011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221747),
                    new("normal", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221748),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221749),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 33, 77));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665775, "SmoothStep", 150, "00031185941185941185940C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221750),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221751),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134221752),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 42));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665776, "SmoothStep", 150, "00040110118594101185940C10118594",
                (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221753),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221754),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134221755),
                    new("result", 3, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134221756),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 49));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665777, "Subtract", 150, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221757),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221758),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665778, "Subtract", 150, "000301101185941011859410118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221759),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134221760),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221761),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665779, "Transform", 150, "0002118594118594118560", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Matrix"], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221762),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Matrix"), 2, 134221763),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 30, 74));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665780, "Transform", 150, "000301101185941011856010118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2&", false,
                        null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221764),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134221765),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221766),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 37, 85));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665781, "Transform", 150, "0002118594118594118578", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Quaternion"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221767),
                    new("rotation", 1, 0, "Microsoft.Xna.Framework.Quaternion", false,
                        null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Quaternion"), 2, 134221768),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 6, 13));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665782, "Transform", 150, "000301101185941011857810118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Quaternion&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221769),
                    new("rotation", 1, 0, "Microsoft.Xna.Framework.Quaternion&", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Quaternion")), 2, 134221770),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221771),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 70, 154));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665783, "Transform", 150, "0003011D118594101185601D118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134221772),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134221773),
                    new("destinationArray", 2, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 3,
                        134221774),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 14));
        }

        private static void PublishMethods5(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665784, "Transform", 150, "0006011D11859408101185601D1185940808",
                (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "System.Int32",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134221775),
                    new("sourceIndex", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134221776),
                    new("matrix", 2, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Matrix")), 3, 134221777),
                    new("destinationArray", 3, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 4,
                        134221778),
                    new("destinationIndex", 4, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 5, 134221779),
                    new("length", 5, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 6, 134221780),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 61, 128));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665785, "Transform", 150, "0003011D118594101185781D118594", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Quaternion&",
                    "Microsoft.Xna.Framework.Vector2[]",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134221781),
                    new("rotation", 1, 0, "Microsoft.Xna.Framework.Quaternion&", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Quaternion")), 2, 134221782),
                    new("destinationArray", 2, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 3,
                        134221783),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 14));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665786, "Transform", 150, "0006011D11859408101185781D1185940808",
                (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "Microsoft.Xna.Framework.Quaternion&",
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "System.Int32",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134221784),
                    new("sourceIndex", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134221785),
                    new("rotation", 2, 0, "Microsoft.Xna.Framework.Quaternion&", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Quaternion")), 3, 134221786),
                    new("destinationArray", 3, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 4,
                        134221787),
                    new("destinationIndex", 4, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 5, 134221788),
                    new("length", 5, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 6, 134221789),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 27, 45));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665787, "TransformNormal", 150, "0002118594118594118560", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Matrix"], 0,
                [
                    new("normal", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221790),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Matrix"), 2, 134221791),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 24, 60));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665788, "TransformNormal", 150, "000301101185941011856010118594",
                (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("normal", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134221792),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134221793),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134221794),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 31, 71));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665789, "TransformNormal", 150, "0003011D118594101185601D118594",
                (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134221795),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134221796),
                    new("destinationArray", 2, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 3,
                        134221797),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 14));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665790, "TransformNormal", 150, "0006011D11859408101185601D1185940808",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "System.Int32",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134221798),
                    new("sourceIndex", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134221799),
                    new("matrix", 2, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Matrix")), 3, 134221800),
                    new("destinationArray", 3, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 4,
                        134221801),
                    new("destinationIndex", 4, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 5, 134221802),
                    new("length", 5, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 6, 134221803),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 49, 103));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665791, "op_UnaryNegation", 2198, "0001118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221804),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 30));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665792, "op_Equality", 2198, "000202118594118594", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221805),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221806),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 13, 31));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665793, "op_Inequality", 2198, "000202118594118594", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221807),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221808),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 11));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665794, "op_Addition", 2198, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221809),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221810),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665795, "op_Subtraction", 2198, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221811),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221812),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
        }

        private static void PublishMethods6(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665796, "op_Multiply", 2198, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221813),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221814),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665797, "op_Multiply", 2198, "00021185941185940C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221815),
                    new("scaleFactor", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134221816),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 26));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665798, "op_Multiply", 2198, "00021185940C118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["System.Single", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("scaleFactor", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134221817),
                    new("value", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221818),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 26));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665799, "op_Division", 2198, "0002118594118594118594", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221819),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134221820),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 36));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665800, "op_Division", 2198, "00021185941185940C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134221821),
                    new("divider", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134221822),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 10, 22));
            methods.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector2",
                33554789,
                100665801, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 81));
        }
    }
}
