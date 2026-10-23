using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Game.Reflection.Metadata.Sdk.OriginalXna;

public static class OriginalXnaRectangleMetadata
{
    public const string SourceAssemblySha256 = "38e7093f52d7474bbc6256906519781a1210d7da50a1c667b52716fcf49ca130";
    public const string SourceModuleMvid = "b5670410-a7b6-4100-af8b-64f5878f5c83";

    public static void PublishMembersFacts(SourceMemberCatalog members)
    {
        if (members == null) throw new ArgumentNullException(nameof(members));
        members.RegisterTypeDefinition(new SourceTypeDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 1057033,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[] { "System.IEquatable`1<Microsoft.Xna.Framework.Rectangle>" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ComponentModel.TypeConverterAttribute",
                    "System.Void System.ComponentModel.TypeConverterAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x31, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x58, 0x6E, 0x61,
                        0x2E, 0x46, 0x72, 0x61, 0x6D, 0x65, 0x77, 0x6F, 0x72, 0x6B, 0x2E, 0x44, 0x65, 0x73, 0x69, 0x67,
                        0x6E, 0x2E, 0x52, 0x65, 0x63, 0x74, 0x61, 0x6E, 0x67, 0x6C, 0x65, 0x43, 0x6F, 0x6E, 0x76, 0x65,
                        0x72, 0x74, 0x65, 0x72, 0x00, 0x00
                    })
            },
            interfaceAssemblyIdentities: new string[]
                { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            genericParameters: Array.Empty<SourceGenericParameterDefinition>(),
            baseTypeReference: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.ValueType"),
            interfaceTypeReferences: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
            {
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IEquatable`1"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")
                    })
            }));
        PublishMembers0(members);
        PublishMembers1(members);
    }

    public static void PublishMethodFacts(SourceAssemblyMethodCatalog methods)
    {
        if (methods == null) throw new ArgumentNullException(nameof(methods));
        PublishMethods0(methods);
        PublishMethods1(methods);
        PublishMethods2(methods);
    }

    private static void PublishMembers0(SourceMemberCatalog members)
    {
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 67110404, "X", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 67110405, "Y", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 67110406, "Width", SourceMemberKind.Field, 6, "System.Int32", -1, -1,
            0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 67110407, "Height", SourceMemberKind.Field, 6, "System.Int32", -1, -1,
            0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 67110408, "_empty", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Rectangle", -1, -1, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876784, "Left", SourceMemberKind.Property, 0, "System.Int32", 2182,
            -1, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876785, "Right", SourceMemberKind.Property, 0, "System.Int32", 2182,
            -1, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876786, "Top", SourceMemberKind.Property, 0, "System.Int32", 2182,
            -1, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876787, "Bottom", SourceMemberKind.Property, 0, "System.Int32",
            2182, -1, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876788, "Location", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Point", 2182, 2182, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Point")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876789, "Center", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Point", 2182, -1, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Point")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876790, "Empty", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Rectangle", 2198, -1, 0, new SourceDeclaredAttribute[] { }, false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle")));
    }

    private static void PublishMembers1(SourceMemberCatalog members)
    {
        members.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 385876791, "IsEmpty", SourceMemberKind.Property, 0, "System.Boolean",
            2182, -1, 0, new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
    }

    private static void PublishMethods0(SourceAssemblyMethodCatalog methods)
    {
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666454, "get_Left", 2182, "200008",
            new KeyValuePair<string, string>[] { }, "System.Int32", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 3, 7));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666455, "get_Right", 2182, "200008",
            new KeyValuePair<string, string>[] { }, "System.Int32", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 6, 14));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666456, "get_Top", 2182, "200008",
            new KeyValuePair<string, string>[] { }, "System.Int32", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 3, 7));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666457, "get_Bottom", 2182, "200008",
            new KeyValuePair<string, string>[] { }, "System.Int32", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 6, 14));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666458, "get_Location", 2182, "20001187F4",
            new KeyValuePair<string, string>[] { }, "Microsoft.Xna.Framework.Point", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Point"), true, 6, 18));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666459, "set_Location", 2182, "2001011187F4",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "Microsoft.Xna.Framework.Point" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Point", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Point"), 1, 134220547)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 27));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666460, "get_Center", 2182, "20001187F4",
            new KeyValuePair<string, string>[] { }, "Microsoft.Xna.Framework.Point", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Point"), true, 16, 36));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666461, "get_Empty", 2198, "0000118800",
            new KeyValuePair<string, string>[] { }, "Microsoft.Xna.Framework.Rectangle", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle"), true, 2, 6));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666462, "get_IsEmpty", 2182, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 16, 36));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666463, ".ctor", 6278, "20040108080808",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32", "System.Int32", "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220548),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134220549),
                new SourceMethodParameterDefinition("width", 2, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134220550),
                new SourceMethodParameterDefinition("height", 3, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134220551)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 30));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666464, "Offset", 134, "2001011187F4",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "Microsoft.Xna.Framework.Point" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("amount", 0, 0, "Microsoft.Xna.Framework.Point", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Point"), 1, 134220552)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 41));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666465, "Offset", 134, "2002010808",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("offsetX", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220553),
                new SourceMethodParameterDefinition("offsetY", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134220554)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 29));
    }

    private static void PublishMethods1(SourceAssemblyMethodCatalog methods)
    {
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666466, "Inflate", 134, "2002010808",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("horizontalAmount", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220555),
                new SourceMethodParameterDefinition("verticalAmount", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134220556)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 29, 61));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666467, "Contains", 134, "2002020808",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { "System.Int32", "System.Int32" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220557),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134220558)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 25, 53));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666468, "Contains", 134, "2001021187F4",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { "Microsoft.Xna.Framework.Point" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Point", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Point"), 1, 134220559)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 29, 77));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666469, "Contains", 134, "200201101187F41002",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Point&", "System.Boolean&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Point&", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Point")), 1, 134220560),
                new SourceMethodParameterDefinition("result", 1, 2, "System.Boolean&", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Boolean")), 2, 134220561)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 31, 76));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666470, "Contains", 134, "200102118800",
            new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220562)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 37, 96));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666471, "Contains", 134, "200201101188001002",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Rectangle&", "System.Boolean&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134220563),
                new SourceMethodParameterDefinition("result", 1, 2, "System.Boolean&", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Boolean")), 2, 134220564)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 39, 93));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666472, "Intersects", 134, "200102118800",
            new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220565)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 35, 93));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666473, "Intersects", 134, "200201101188001002",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Rectangle&", "System.Boolean&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134220566),
                new SourceMethodParameterDefinition("result", 1, 2, "System.Boolean&", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Boolean")), 2, 134220567)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 37, 90));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666474, "Intersect", 150, "0002118800118800118800",
            new KeyValuePair<string, string>[] { }, "Microsoft.Xna.Framework.Rectangle",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220568),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134220569)
            }, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle"), true, 97, 241));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666475, "Intersect", 150,
            "000301101188001011880010118800", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Rectangle&", "Microsoft.Xna.Framework.Rectangle&",
                "Microsoft.Xna.Framework.Rectangle&"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134220570),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 2, 134220571),
                new SourceMethodParameterDefinition("result", 2, 2, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 3, 134220572)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 96, 214));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666476, "Union", 150, "0002118800118800118800",
            new KeyValuePair<string, string>[] { }, "Microsoft.Xna.Framework.Rectangle",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220573),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134220574)
            }, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle"), true, 78, 197));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666477, "Union", 150, "000301101188001011880010118800",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Rectangle&", "Microsoft.Xna.Framework.Rectangle&",
                "Microsoft.Xna.Framework.Rectangle&"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134220575),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 2, 134220576),
                new SourceMethodParameterDefinition("result", 2, 2, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 3, 134220577)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 77, 175));
    }

    private static void PublishMethods2(SourceAssemblyMethodCatalog methods)
    {
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666478, "Equals", 486, "200102118800",
            new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("other", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220578)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 23, 63));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666479, "Equals", 198, "2001021C",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { "System.Object" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("obj", 0, 0, "System.Object", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Object"), 1, 134220579)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 12, 25));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666480, "ToString", 198, "20000E",
            new KeyValuePair<string, string>[] { }, "System.String", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 38, 86));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666481, "GetHashCode", 198, "200008",
            new KeyValuePair<string, string>[] { }, "System.Int32", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 16, 48));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666482, "op_Equality", 2198, "000202118800118800",
            new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220580),
                new SourceMethodParameterDefinition("b", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134220581)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 23, 67));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666483, "op_Inequality", 2198, "000202118800118800",
            new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220582),
                new SourceMethodParameterDefinition("b", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134220583)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 25, 70));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Rectangle", 33554944, 100666484, ".cctor", 6289, "000001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 12));
    }
}
