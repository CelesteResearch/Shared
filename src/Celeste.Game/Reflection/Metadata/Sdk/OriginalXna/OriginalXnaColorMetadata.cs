using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata.Sdk.OriginalXna
{
    public static class OriginalXnaColorMetadata
    {
        public const string SourceAssemblySha256 = "38e7093f52d7474bbc6256906519781a1210d7da50a1c667b52716fcf49ca130";
        public const string SourceModuleMvid = "b5670410-a7b6-4100-af8b-64f5878f5c83";

        public static void PublishMembersFacts(SourceMemberCatalog members)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            members.RegisterTypeDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 1057033,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [
                    "Microsoft.Xna.Framework.Graphics.PackedVector.IPackedVector`1<System.UInt32>",
                    "Microsoft.Xna.Framework.Graphics.PackedVector.IPackedVector",
                    "System.IEquatable`1<Microsoft.Xna.Framework.Color>",
                ],
                [
                    new("System.ComponentModel.TypeConverterAttribute",
                        "System.Void System.ComponentModel.TypeConverterAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x2D, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x58, 0x6E,
                            0x61,
                            0x2E, 0x46, 0x72, 0x61, 0x6D, 0x65, 0x77, 0x6F, 0x72, 0x6B, 0x2E, 0x44, 0x65, 0x73, 0x69,
                            0x67,
                            0x6E, 0x2E, 0x43, 0x6F, 0x6C, 0x6F, 0x72, 0x43, 0x6F, 0x6E, 0x76, 0x65, 0x72, 0x74, 0x65,
                            0x72,
                            0x00, 0x00,
                        ]),
                ],
                interfaceAssemblyIdentities:
                [
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], genericParameters: [],
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
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Graphics.PackedVector.IPackedVector`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Graphics.PackedVector.IPackedVector"),
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
                                "Microsoft.Xna.Framework.Color"),
                        ]),
                ]));
            PublishMembers0(members);
            PublishMembers1(members);
            PublishMembers2(members);
            PublishMembers3(members);
            PublishMembers4(members);
            PublishMembers5(members);
            PublishMembers6(members);
            PublishMembers7(members);
            PublishMembers8(members);
            PublishMembers9(members);
            PublishMembers10(members);
            PublishMembers11(members);
            PublishMembers12(members);
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
            PublishMethods7(methods);
            PublishMethods8(methods);
            PublishMethods9(methods);
            PublishMethods10(methods);
            PublishMethods11(methods);
            PublishMethods12(methods);
            PublishMethods13(methods);
            PublishMethods14(methods);
        }

        private static void PublishMembers0(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 67110387, "packedValue", SourceMemberKind.Field, 1, "System.UInt32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876636, "R", SourceMemberKind.Property, 0, "System.Byte", 2182,
                2182, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876637, "G", SourceMemberKind.Property, 0, "System.Byte", 2182,
                2182, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876638, "B", SourceMemberKind.Property, 0, "System.Byte", 2182,
                2182, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876639, "A", SourceMemberKind.Property, 0, "System.Byte", 2182,
                2182, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876640, "PackedValue", SourceMemberKind.Property, 0,
                "System.UInt32",
                2534, 2534, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876641, "Transparent", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876642, "AliceBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876643, "AntiqueWhite", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876644, "Aqua", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876645, "Aquamarine", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876646, "Azure", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers1(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876647, "Beige", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876648, "Bisque", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876649, "Black", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876650, "BlanchedAlmond", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876651, "Blue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876652, "BlueViolet", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876653, "Brown", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876654, "BurlyWood", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876655, "CadetBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876656, "Chartreuse", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876657, "Chocolate", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876658, "Coral", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers2(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876659, "CornflowerBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876660, "Cornsilk", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876661, "Crimson", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876662, "Cyan", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876663, "DarkBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876664, "DarkCyan", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876665, "DarkGoldenrod", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876666, "DarkGray", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876667, "DarkGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876668, "DarkKhaki", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876669, "DarkMagenta", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876670, "DarkOliveGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers3(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876671, "DarkOrange", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876672, "DarkOrchid", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876673, "DarkRed", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876674, "DarkSalmon", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876675, "DarkSeaGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876676, "DarkSlateBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876677, "DarkSlateGray", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876678, "DarkTurquoise", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876679, "DarkViolet", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876680, "DeepPink", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876681, "DeepSkyBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876682, "DimGray", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers4(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876683, "DodgerBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876684, "Firebrick", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876685, "FloralWhite", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876686, "ForestGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876687, "Fuchsia", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876688, "Gainsboro", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876689, "GhostWhite", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876690, "Gold", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876691, "Goldenrod", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876692, "Gray", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876693, "Green", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876694, "GreenYellow", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers5(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876695, "Honeydew", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876696, "HotPink", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876697, "IndianRed", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876698, "Indigo", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876699, "Ivory", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876700, "Khaki", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876701, "Lavender", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876702, "LavenderBlush", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876703, "LawnGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876704, "LemonChiffon", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876705, "LightBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876706, "LightCoral", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers6(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876707, "LightCyan", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876708, "LightGoldenrodYellow", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876709, "LightGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876710, "LightGray", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876711, "LightPink", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876712, "LightSalmon", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876713, "LightSeaGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876714, "LightSkyBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876715, "LightSlateGray", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876716, "LightSteelBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876717, "LightYellow", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876718, "Lime", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers7(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876719, "LimeGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876720, "Linen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876721, "Magenta", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876722, "Maroon", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876723, "MediumAquamarine", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876724, "MediumBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876725, "MediumOrchid", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876726, "MediumPurple", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876727, "MediumSeaGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876728, "MediumSlateBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876729, "MediumSpringGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876730, "MediumTurquoise", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers8(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876731, "MediumVioletRed", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876732, "MidnightBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876733, "MintCream", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876734, "MistyRose", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876735, "Moccasin", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876736, "NavajoWhite", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876737, "Navy", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876738, "OldLace", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876739, "Olive", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876740, "OliveDrab", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876741, "Orange", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876742, "OrangeRed", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers9(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876743, "Orchid", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876744, "PaleGoldenrod", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876745, "PaleGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876746, "PaleTurquoise", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876747, "PaleVioletRed", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876748, "PapayaWhip", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876749, "PeachPuff", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876750, "Peru", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876751, "Pink", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876752, "Plum", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876753, "PowderBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876754, "Purple", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers10(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876755, "Red", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876756, "RosyBrown", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876757, "RoyalBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876758, "SaddleBrown", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876759, "Salmon", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876760, "SandyBrown", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876761, "SeaGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876762, "SeaShell", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876763, "Sienna", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876764, "Silver", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876765, "SkyBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876766, "SlateBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers11(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876767, "SlateGray", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876768, "Snow", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876769, "SpringGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876770, "SteelBlue", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876771, "Tan", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876772, "Teal", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876773, "Thistle", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876774, "Tomato", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876775, "Turquoise", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876776, "Violet", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876777, "Wheat", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876778, "White", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMembers12(SourceMemberCatalog members)
        {
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876779, "WhiteSmoke", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876780, "Yellow", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            members.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 385876781, "YellowGreen", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Color", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
        }

        private static void PublishMethods0(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666176, ".ctor", 6273, "20010109",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.UInt32"], 0,
                [
                    new("packedValue", 0, 0, "System.UInt32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134220330),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666177, ".ctor", 6278, "200301080808",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "System.Int32", "System.Int32"], 0,
                [
                    new("r", 0, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134220331),
                    new("g", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134220332),
                    new("b", 2, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134220333),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 38, 69));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666178, ".ctor", 6278, "20040108080808",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "System.Int32", "System.Int32", "System.Int32"], 0,
                [
                    new("r", 0, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134220334),
                    new("g", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134220335),
                    new("b", 2, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134220336),
                    new("a", 3, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 4, 134220337),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 44, 82));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666179, ".ctor", 6278, "2003010C0C0C",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("r", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134220338),
                    new("g", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220339),
                    new("b", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220340),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666180, ".ctor", 6278, "2004010C0C0C0C",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("r", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134220341),
                    new("g", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220342),
                    new("b", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220343),
                    new("a", 3, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134220344),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666181, ".ctor", 6278, "200101118808",
                (KeyValuePair<string, string>[])[], "System.Void", ["Microsoft.Xna.Framework.Vector3"],
                0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector3", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector3"), 1, 134220345),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 38));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666182, ".ctor", 6278, "20010111880C",
                (KeyValuePair<string, string>[])[], "System.Void", ["Microsoft.Xna.Framework.Vector4"],
                0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector4", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector4"), 1, 134220346),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 40));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666183,
                "Microsoft.Xna.Framework.Graphics.PackedVector.IPackedVector.PackFromVector4", 481, "20010111880C",
                (KeyValuePair<string, string>[])[], "System.Void", ["Microsoft.Xna.Framework.Vector4"],
                0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector4", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector4"), 1, 134220347),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 40));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666184, "FromNonPremultiplied", 150, "00011187E811880C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color",
                ["Microsoft.Xna.Framework.Vector4"], 0,
                [
                    new("vector", 0, 0, "Microsoft.Xna.Framework.Vector4", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Vector4"), 1, 134220348),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 22, 66));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666185, "FromNonPremultiplied", 150, "00041187E808080808",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color",
                ["System.Int32", "System.Int32", "System.Int32", "System.Int32"], 0,
                [
                    new("r", 0, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134220349),
                    new("g", 1, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134220350),
                    new("b", 2, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134220351),
                    new("a", 3, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 4, 134220352),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 56, 98));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666186, "PackHelper", 145, "0004090C0C0C0C",
                (KeyValuePair<string, string>[])[], "System.UInt32",
                ["System.Single", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("vectorX", 0, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134220353),
                    new("vectorY", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220354),
                    new("vectorZ", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220355),
                    new("vectorW", 3, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134220356),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32"), true, 30, 64));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666187, "ClampToByte32", 145, "00010808",
                (KeyValuePair<string, string>[])[], "System.Int32", ["System.Int32"], 0,
                [
                    new("value", 0, 0, "System.Int32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134220357),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 12, 22));
        }

        private static void PublishMethods1(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666188, "ClampToByte64", 145, "0001080A",
                (KeyValuePair<string, string>[])[], "System.Int32", ["System.Int64"], 0,
                [
                    new("value", 0, 0, "System.Int64", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int64"), 1, 134220358),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 15, 25));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666189, "ToVector3", 134, "2000118808",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector3", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3"), true, 24, 76));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666190, "ToVector4", 486, "200011880C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Vector4", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector4"), true, 32, 102));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666191, "get_R", 2182, "200005",
                (KeyValuePair<string, string>[])[], "System.Byte", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte"), true, 4, 8));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666192, "set_R", 2182, "20010105",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Byte"], 0,
                [
                    new("value", 0, 0, "System.Byte", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Byte"), 1, 134220359),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 21));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666193, "get_G", 2182, "200005",
                (KeyValuePair<string, string>[])[], "System.Byte", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte"), true, 6, 10));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666194, "set_G", 2182, "20010105",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Byte"], 0,
                [
                    new("value", 0, 0, "System.Byte", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Byte"), 1, 134220360),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 23));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666195, "get_B", 2182, "200005",
                (KeyValuePair<string, string>[])[], "System.Byte", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte"), true, 6, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666196, "set_B", 2182, "20010105",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Byte"], 0,
                [
                    new("value", 0, 0, "System.Byte", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Byte"), 1, 134220361),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 24));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666197, "get_A", 2182, "200005",
                (KeyValuePair<string, string>[])[], "System.Byte", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Byte"), true, 6, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666198, "set_A", 2182, "20010105",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Byte"], 0,
                [
                    new("value", 0, 0, "System.Byte", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Byte"), 1, 134220362),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 24));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666199, "get_PackedValue", 2534, "200009",
                (KeyValuePair<string, string>[])[], "System.UInt32", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32"), true, 3, 7));
        }

        private static void PublishMethods2(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666200, "set_PackedValue", 2534, "20010109",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.UInt32"], 0,
                [
                    new("value", 0, 0, "System.UInt32", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134220363),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666201, "Lerp", 150, "00031187E81187E81187E80C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color",
                ["Microsoft.Xna.Framework.Color", "Microsoft.Xna.Framework.Color", "System.Single"], 0,
                [
                    new("value1", 0, 0, "Microsoft.Xna.Framework.Color", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134220364),
                    new("value2", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 2, 134220365),
                    new("amount", 2, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134220366),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 103, 162));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666202, "Multiply", 150, "00021187E81187E80C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color",
                ["Microsoft.Xna.Framework.Color", "System.Single"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Color", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134220367),
                    new("scale", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220368),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 101, 188));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666203, "op_Multiply", 2198, "00021187E81187E80C",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color",
                ["Microsoft.Xna.Framework.Color", "System.Single"], 0,
                [
                    new("value", 0, 0, "Microsoft.Xna.Framework.Color", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134220369),
                    new("scale", 1, 0, "System.Single", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134220370),
                ], "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 101, 188));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666204, "ToString", 198, "20000E",
                (KeyValuePair<string, string>[])[], "System.String", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 32, 80));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666205, "GetHashCode", 198, "200008",
                (KeyValuePair<string, string>[])[], "System.Int32", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666206, "Equals", 198, "2001021C",
                (KeyValuePair<string, string>[])[], "System.Boolean", ["System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, null,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134220371),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 23));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666207, "Equals", 486, "2001021187E8",
                (KeyValuePair<string, string>[])[], "System.Boolean", ["Microsoft.Xna.Framework.Color"],
                0,
                [
                    new("other", 0, 0, "Microsoft.Xna.Framework.Color", false, null,
                        null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134220372),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 19));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666208, "op_Equality", 2198, "0002021187E81187E8",
                (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Microsoft.Xna.Framework.Color", "Microsoft.Xna.Framework.Color"], 0,
                [
                    new("a", 0, 0, "Microsoft.Xna.Framework.Color", false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134220373),
                    new("b", 1, 0, "Microsoft.Xna.Framework.Color", false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 2, 134220374),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 4, 9));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666209, "op_Inequality", 2198, "0002021187E81187E8",
                (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Microsoft.Xna.Framework.Color", "Microsoft.Xna.Framework.Color"], 0,
                [
                    new("a", 0, 0, "Microsoft.Xna.Framework.Color", false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 1, 134220375),
                    new("b", 1, 0, "Microsoft.Xna.Framework.Color", false, null, null,
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Color"), 2, 134220376),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 12));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666210, "get_Transparent", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 7));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666211, "get_AliceBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods3(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666212, "get_AntiqueWhite", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666213, "get_Aqua", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666214, "get_Aquamarine", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666215, "get_Azure", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 8));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666216, "get_Beige", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666217, "get_Bisque", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666218, "get_Black", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666219, "get_BlanchedAlmond", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666220, "get_Blue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666221, "get_BlueViolet", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666222, "get_Brown", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666223, "get_BurlyWood", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods4(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666224, "get_CadetBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666225, "get_Chartreuse", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666226, "get_Chocolate", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666227, "get_Coral", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666228, "get_CornflowerBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666229, "get_Cornsilk", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666230, "get_Crimson", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666231, "get_Cyan", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666232, "get_DarkBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666233, "get_DarkCyan", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666234, "get_DarkGoldenrod", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666235, "get_DarkGray", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods5(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666236, "get_DarkGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666237, "get_DarkKhaki", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666238, "get_DarkMagenta", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666239, "get_DarkOliveGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666240, "get_DarkOrange", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666241, "get_DarkOrchid", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666242, "get_DarkRed", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666243, "get_DarkSalmon", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666244, "get_DarkSeaGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666245, "get_DarkSlateBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666246, "get_DarkSlateGray", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666247, "get_DarkTurquoise", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods6(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666248, "get_DarkViolet", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666249, "get_DeepPink", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666250, "get_DeepSkyBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666251, "get_DimGray", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666252, "get_DodgerBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666253, "get_Firebrick", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666254, "get_FloralWhite", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666255, "get_ForestGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666256, "get_Fuchsia", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666257, "get_Gainsboro", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666258, "get_GhostWhite", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666259, "get_Gold", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods7(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666260, "get_Goldenrod", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666261, "get_Gray", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666262, "get_Green", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666263, "get_GreenYellow", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666264, "get_Honeydew", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666265, "get_HotPink", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666266, "get_IndianRed", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666267, "get_Indigo", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666268, "get_Ivory", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666269, "get_Khaki", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666270, "get_Lavender", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666271, "get_LavenderBlush", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods8(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666272, "get_LawnGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666273, "get_LemonChiffon", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666274, "get_LightBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666275, "get_LightCoral", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666276, "get_LightCyan", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 8));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666277, "get_LightGoldenrodYellow", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666278, "get_LightGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666279, "get_LightGray", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666280, "get_LightPink", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666281, "get_LightSalmon", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666282, "get_LightSeaGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666283, "get_LightSkyBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods9(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666284, "get_LightSlateGray", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666285, "get_LightSteelBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666286, "get_LightYellow", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666287, "get_Lime", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666288, "get_LimeGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666289, "get_Linen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666290, "get_Magenta", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666291, "get_Maroon", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666292, "get_MediumAquamarine", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666293, "get_MediumBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666294, "get_MediumOrchid", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666295, "get_MediumPurple", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods10(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666296, "get_MediumSeaGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666297, "get_MediumSlateBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666298, "get_MediumSpringGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666299, "get_MediumTurquoise", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666300, "get_MediumVioletRed", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666301, "get_MidnightBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666302, "get_MintCream", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666303, "get_MistyRose", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666304, "get_Moccasin", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666305, "get_NavajoWhite", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666306, "get_Navy", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666307, "get_OldLace", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods11(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666308, "get_Olive", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666309, "get_OliveDrab", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666310, "get_Orange", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666311, "get_OrangeRed", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666312, "get_Orchid", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666313, "get_PaleGoldenrod", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666314, "get_PaleGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666315, "get_PaleTurquoise", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666316, "get_PaleVioletRed", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666317, "get_PapayaWhip", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666318, "get_PeachPuff", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666319, "get_Peru", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods12(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666320, "get_Pink", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666321, "get_Plum", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666322, "get_PowderBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666323, "get_Purple", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666324, "get_Red", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666325, "get_RosyBrown", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666326, "get_RoyalBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666327, "get_SaddleBrown", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666328, "get_Salmon", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666329, "get_SandyBrown", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666330, "get_SeaGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666331, "get_SeaShell", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods13(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666332, "get_Sienna", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666333, "get_Silver", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666334, "get_SkyBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666335, "get_SlateBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666336, "get_SlateGray", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666337, "get_Snow", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666338, "get_SpringGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666339, "get_SteelBlue", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666340, "get_Tan", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666341, "get_Teal", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666342, "get_Thistle", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666343, "get_Tomato", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }

        private static void PublishMethods14(SourceAssemblyMethodCatalog methods)
        {
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666344, "get_Turquoise", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666345, "get_Violet", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666346, "get_Wheat", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666347, "get_White", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 7));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666348, "get_WhiteSmoke", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666349, "get_Yellow", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
            methods.RegisterDefinition(new(
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Color", 33554938, 100666350, "get_YellowGreen", 2198, "00001187E8",
                (KeyValuePair<string, string>[])[], "Microsoft.Xna.Framework.Color", [], 0,
                [],
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color"), true, 3, 11));
        }
    }
}
