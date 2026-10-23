using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata.Sdk.OriginalXna
{
    public static class OriginalXnaVector2Metadata
    {
        public const string SourceAssemblySha256 = "38e7093f52d7474bbc6256906519781a1210d7da50a1c667b52716fcf49ca130";
        public const string SourceModuleMvid = "b5670410-a7b6-4100-af8b-64f5878f5c83";

        public static void PublishMembersFacts(SourceMemberCatalog members)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            members.RegisterTypeDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 1057033,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
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
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
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
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 67110409, "X", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                        "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65,
                            0x73,
                            0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F,
                            0x74,
                            0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49,
                            0x6E,
                            0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00,
                        ]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 67110410, "Y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                        "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65,
                            0x73,
                            0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F,
                            0x74,
                            0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49,
                            0x6E,
                            0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00,
                        ]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 67110411, "_zero", SourceMemberKind.Field, 17,
                "Microsoft.Xna.Framework.Vector2", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 67110412, "_one", SourceMemberKind.Field, 17,
                "Microsoft.Xna.Framework.Vector2", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 67110413, "_unitX", SourceMemberKind.Field, 17,
                "Microsoft.Xna.Framework.Vector2", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 67110414, "_unitY", SourceMemberKind.Field, 17,
                "Microsoft.Xna.Framework.Vector2", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 385876792, "Zero", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Vector2", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 385876793, "One", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Vector2", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 385876794, "UnitX", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Vector2", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 385876795, "UnitY", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Vector2", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
        }

        private static void PublishMethods0(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666485, "get_Zero", 2198, "0000118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666486, "get_One", 2198, "0000118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666487, "get_UnitX", 2198, "0000118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666488, "get_UnitY", 2198, "0000118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 2, 6));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666489, ".ctor", 6278, "2002010C0C",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Single", "System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134220584),
                    new("y", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220585),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 15));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666490, ".ctor", 6278, "2001010C",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Single"], 0,
                [
                    new("value", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134220586),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 17));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666491, "ToString", 198, "20000E",
                (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 24, 56));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666492, "Equals", 486, "200102118804",
                (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("other", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220587),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 13, 33));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666493, "Equals", 198, "2001021C",
                (KeyValuePair<string, string>[])[], "System.Boolean", ["System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134220588),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 12, 25));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666494, "GetHashCode", 198, "200008",
                (KeyValuePair<string, string>[])[], "System.Int32", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 8, 24));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666495, "Length", 134, "20000C",
                (KeyValuePair<string, string>[])[], "System.Single", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 17, 37));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666496, "LengthSquared", 134, "20000C",
                (KeyValuePair<string, string>[])[], "System.Single", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 12, 28));
        }

        private static void PublishMethods1(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666497, "Distance", 150, "00020C118804118804",
                (KeyValuePair<string, string>[])[], "System.Single",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220589),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220590),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 25, 49));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666498, "Distance", 150, "0003011011880410118804100C",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single&"],
                0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220591),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220592),
                    new("result", 2, 2, "System.Single&", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134220593),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 27, 47));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666499, "DistanceSquared", 150, "00020C118804118804",
                (KeyValuePair<string, string>[])[], "System.Single",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220594),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220595),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 20, 40));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666500, "DistanceSquared", 150,
                "0003011011880410118804100C", (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single&"],
                0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220596),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220597),
                    new("result", 2, 2, "System.Single&", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134220598),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 22, 38));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666501, "Dot", 150, "00020C118804118804",
                (KeyValuePair<string, string>[])[], "System.Single",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220599),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220600),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 12, 32));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666502, "Dot", 150, "0003011011880410118804100C",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single&"],
                0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220601),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220602),
                    new("result", 2, 2, "System.Single&", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134220603),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 30));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666503, "Normalize", 134, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 32, 72));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666504, "Normalize", 150, "0001118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220604),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 33, 81));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666505, "Normalize", 150, "0002011011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220605),
                    new("result", 1, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220606),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 32, 72));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666506, "Reflect", 150, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220607),
                    new("normal", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220608),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 36, 94));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666507, "Reflect", 150,
                "000301101188041011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220609),
                    new("normal", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220610),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220611),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 35, 83));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666508, "Min", 150, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220612),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220613),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 26, 80));
        }

        private static void PublishMethods2(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666509, "Min", 150, "000301101188041011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220614),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220615),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220616),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 69));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666510, "Max", 150, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220617),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220618),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 26, 80));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666511, "Max", 150, "000301101188041011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220619),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220620),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220621),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 69));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666512, "Clamp", 150, "0003118804118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220622),
                    new("min", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220623),
                    new("max", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134220624),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 50, 118));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666513, "Clamp", 150,
                "00040110118804101188041011880410118804", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220625),
                    new("min", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220626),
                    new("max", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220627),
                    new("result", 3, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134220628),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 49, 105));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666514, "Lerp", 150, "00031188041188041188040C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220629),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220630),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220631),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 26, 66));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666515, "Lerp", 150, "00040110118804101188040C10118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220632),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220633),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220634),
                    new("result", 3, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134220635),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 57));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666516, "Barycentric", 150,
                "00051188041188041188041188040C0C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                    "System.Single", "System.Single",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220636),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220637),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134220638),
                    new("amount1", 3, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134220639),
                    new("amount2", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134220640),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 42, 104));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666517, "Barycentric", 150,
                "0006011011880410118804101188040C0C10118804", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "System.Single", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220641),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220642),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220643),
                    new("amount1", 3, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134220644),
                    new("amount2", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134220645),
                    new("result", 5, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 6, 134220646),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 41, 93));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666518, "SmoothStep", 150, "00031188041188041188040C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220647),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220648),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220649),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 48, 118));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666519, "SmoothStep", 150,
                "00040110118804101188040C10118804", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220650),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220651),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220652),
                    new("result", 3, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134220653),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 47, 109));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666520, "CatmullRom", 150,
                "00051188041188041188041188041188040C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2", "System.Single",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220654),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220655),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134220656),
                    new("value4", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 4, 134220657),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134220658),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 122, 303));
        }

        private static void PublishMethods3(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666521, "CatmullRom", 150,
                "000601101188041011880410118804101188040C10118804", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220659),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220660),
                    new("value3", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220661),
                    new("value4", 3, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134220662),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134220663),
                    new("result", 5, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 6, 134220664),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 121, 280));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666522, "Hermite", 150,
                "00051188041188041188041188041188040C", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2",
                [
                    "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2",
                    "Microsoft.Xna.Framework.Vector2", "System.Single",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220665),
                    new("tangent1", 1, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220666),
                    new("value2", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134220667),
                    new("tangent2", 3, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 4, 134220668),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134220669),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 82, 167));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666523, "Hermite", 150,
                "000601101188041011880410118804101188040C10118804", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&", "System.Single",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220670),
                    new("tangent1", 1, 0, "Microsoft.Xna.Framework.Vector2&", false,
                        null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220671),
                    new("value2", 2, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220672),
                    new("tangent2", 3, 0, "Microsoft.Xna.Framework.Vector2&", false,
                        null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 4, 134220673),
                    new("amount", 4, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134220674),
                    new("result", 5, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 6, 134220675),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 81, 157));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666524, "Transform", 150, "00021188041188041187DC",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Matrix"], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220676),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Matrix"), 2, 134220677),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 38, 98));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666525, "Transform", 150,
                "00030110118804101187DC10118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("position", 0, 0, "Microsoft.Xna.Framework.Vector2&", false,
                        null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220678),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134220679),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220680),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 37, 85));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666526, "TransformNormal", 150,
                "00021188041188041187DC",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Matrix"], 0,
                [
                    new("normal", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220681),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Matrix"), 2, 134220682),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 32, 82));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666527, "TransformNormal", 150,
                "00030110118804101187DC10118804", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("normal", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220683),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134220684),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220685),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 31, 71));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666528, "Transform", 150, "00021188041188041187F8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Quaternion"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220686),
                    new("rotation", 1, 0, "Microsoft.Xna.Framework.Quaternion", false,
                        null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Quaternion"), 2, 134220687),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 83, 190));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666529, "Transform", 150,
                "00030110118804101187F810118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Quaternion&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220688),
                    new("rotation", 1, 0, "Microsoft.Xna.Framework.Quaternion&", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Quaternion")), 2, 134220689),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220690),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 82, 171));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666530, "Transform", 150,
                "0003011D118804101187DC1D118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134220691),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134220692),
                    new("destinationArray", 2, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 3,
                        134220693),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 75, 160));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666531, "Transform", 150,
                "0006011D11880408101187DC1D1188040808",
                (KeyValuePair<string, string>[])
                [
                    new("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                        "01000F4D6963726F736F66742E5573616765064341323233330000"),
                ], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "System.Int32",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134220694),
                    new("sourceIndex", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134220695),
                    new("matrix", 2, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Matrix")), 3, 134220696),
                    new("destinationArray", 3, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 4,
                        134220697),
                    new("destinationIndex", 4, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 5, 134220698),
                    new("length", 5, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 6, 134220699),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 94, 201));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666532, "TransformNormal", 150,
                "0003011D118804101187DC1D118804", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134220700),
                    new("matrix", 1, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Matrix")), 2, 134220701),
                    new("destinationArray", 2, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 3,
                        134220702),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 69, 146));
        }

        private static void PublishMethods4(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666533, "TransformNormal", 150,
                "0006011D11880408101187DC1D1188040808",
                (KeyValuePair<string, string>[])
                [
                    new("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                        "01000F4D6963726F736F66742E5573616765064341323233330000"),
                ], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "Microsoft.Xna.Framework.Matrix&",
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "System.Int32",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134220703),
                    new("sourceIndex", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134220704),
                    new("matrix", 2, 0, "Microsoft.Xna.Framework.Matrix&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Matrix")), 3, 134220705),
                    new("destinationArray", 3, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 4,
                        134220706),
                    new("destinationIndex", 4, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 5, 134220707),
                    new("length", 5, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 6, 134220708),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 88, 184));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666534, "Transform", 150,
                "0003011D118804101187F81D118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "Microsoft.Xna.Framework.Quaternion&",
                    "Microsoft.Xna.Framework.Vector2[]",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134220709),
                    new("rotation", 1, 0, "Microsoft.Xna.Framework.Quaternion&", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Quaternion")), 2, 134220710),
                    new("destinationArray", 2, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 3,
                        134220711),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 128, 267));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666535, "Transform", 150,
                "0006011D11880408101187F81D1188040808",
                (KeyValuePair<string, string>[])
                [
                    new("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                        "01000F4D6963726F736F66742E5573616765064341323233330000"),
                ], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "Microsoft.Xna.Framework.Quaternion&",
                    "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "System.Int32",
                ], 0,
                [
                    new("sourceArray", 0, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134220712),
                    new("sourceIndex", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134220713),
                    new("rotation", 2, 0, "Microsoft.Xna.Framework.Quaternion&", false,
                        null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Quaternion")), 3, 134220714),
                    new("destinationArray", 3, 0, "Microsoft.Xna.Framework.Vector2[]",
                        false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 4,
                        134220715),
                    new("destinationIndex", 4, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 5, 134220716),
                    new("length", 5, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 6, 134220717),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 148, 304));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666536, "Negate", 150, "0001118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220718),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 32));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666537, "Negate", 150, "0002011011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220719),
                    new("result", 1, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220720),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 27));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666538, "Add", 150, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220721),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220722),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666539, "Add", 150, "000301101188041011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220723),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220724),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220725),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666540, "Subtract", 150, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220726),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220727),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666541, "Subtract", 150,
                "000301101188041011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220728),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220729),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220730),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666542, "Multiply", 150, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220731),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220732),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666543, "Multiply", 150,
                "000301101188041011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220733),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220734),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220735),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666544, "Multiply", 150, "00021188041188040C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220736),
                    new("scaleFactor", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220737),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 34));
        }

        private static void PublishMethods5(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666545, "Multiply", 150, "000301101188040C10118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "System.Single", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220738),
                    new("scaleFactor", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220739),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220740),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 29));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666546, "Divide", 150, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220741),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220742),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666547, "Divide", 150, "000301101188041011880410118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Microsoft.Xna.Framework.Vector2&", "Microsoft.Xna.Framework.Vector2&",
                    "Microsoft.Xna.Framework.Vector2&",
                ], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220743),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 2, 134220744),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220745),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 39));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666548, "Divide", 150, "00021188041188040C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220746),
                    new("divider", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220747),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 42));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666549, "Divide", 150, "000301101188040C10118804",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Microsoft.Xna.Framework.Vector2&", "System.Single", "Microsoft.Xna.Framework.Vector2&"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 1, 134220748),
                    new("divider", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220749),
                    new("result", 2, 2, "Microsoft.Xna.Framework.Vector2&", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                "Microsoft.Xna.Framework.Vector2")), 3, 134220750),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 37));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666550, "op_UnaryNegation", 2198, "0001118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220751),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 12, 32));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666551, "op_Equality", 2198, "000202118804118804",
                (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220752),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220753),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 13, 35));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666552, "op_Inequality", 2198, "000202118804118804",
                (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220754),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220755),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 15, 38));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666553, "op_Addition", 2198, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220756),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220757),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666554, "op_Subtraction", 2198,
                "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220758),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220759),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666555, "op_Multiply", 2198, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220760),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220761),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666556, "op_Multiply", 2198, "00021188041188040C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220762),
                    new("scaleFactor", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220763),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 34));
        }

        private static void PublishMethods6(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666557, "op_Multiply", 2198, "00021188040C118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["System.Single", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("scaleFactor", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134220764),
                    new("value", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220765),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 14, 34));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666558, "op_Division", 2198, "0002118804118804118804",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220766),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 2, 134220767),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 16, 46));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666559, "op_Division", 2198, "00021188041188040C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector2",
                ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134220768),
                    new("divider", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220769),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2"), true, 18, 42));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2", 33554945, 100666560, ".cctor", 6289, "000001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 15, 72));
        }
    }
}
