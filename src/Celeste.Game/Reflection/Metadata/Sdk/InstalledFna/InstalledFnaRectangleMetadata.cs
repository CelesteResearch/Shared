using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Game.Reflection.Metadata.Sdk.InstalledFna;

public static class InstalledFnaRectangleMetadata
{
    public const string SourceAssemblySha256 = "862ce4418709a914c4bc89240026d71379fe06ee5c88d9fcf12d57600fad9cd4";
    public const string SourceModuleMvid = "654542fa-77ba-42c3-8d47-a3387d972081";

    public static void PublishMembersFacts(SourceMemberCatalog members)
    {
        if (members == null) throw new ArgumentNullException(nameof(members));
        members.RegisterTypeDefinition(new SourceTypeDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 1057033, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.ValueType", new string[] { "System.IEquatable`1<Microsoft.Xna.Framework.Rectangle>" },
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
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x17, 0x7B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79,
                        0x53, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x2C, 0x6E, 0x71, 0x7D, 0x00, 0x00
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
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
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
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            67111558, "X", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, new SourceDeclaredAttribute[] { },
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            67111559, "Y", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, new SourceDeclaredAttribute[] { },
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            67111560, "Width", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, new SourceDeclaredAttribute[] { },
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            67111561, "Height", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, new SourceDeclaredAttribute[] { },
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            67111562, "emptyRectangle", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Rectangle", -1, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876205, "Left", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876206, "Right", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876207, "Top", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876208, "Bottom", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876209, "Location", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Point", 2182, 2182, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Point")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876210, "Center", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Point", 2182, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Point")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876211, "IsEmpty", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
    }

    private static void PublishMembers1(SourceMemberCatalog members)
    {
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876212, "Empty", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Rectangle", 2198, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle")));
        members.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            385876213, "DebugDisplayString", SourceMemberKind.Property, 0, "System.String", 2179, -1, 0,
            new SourceDeclaredAttribute[] { }, false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
    }

    private static void PublishMethods0(SourceAssemblyMethodCatalog methods)
    {
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665685, "get_Left", 2182, "200008", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 3, 7));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665686, "get_Right", 2182, "200008", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 6, 14));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665687, "get_Top", 2182, "200008", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 3, 7));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665688, "get_Bottom", 2182, "200008", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 6, 14));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665689, "get_Location", 2182, "2000118570", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Point", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Point"), true, 6, 18));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665690, "set_Location", 2182, "200101118570", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Microsoft.Xna.Framework.Point" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Point", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Point"), 1, 134221594)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 25));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665691, "get_Center", 2182, "2000118570", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Point", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Point"), true, 16, 36));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665692, "get_IsEmpty", 2182, "200002", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 16, 36));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665693, "get_Empty", 2198, "0000118580", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Rectangle", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle"), true, 2, 6));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665694, "get_DebugDisplayString", 2179, "20000E", new KeyValuePair<string, string>[] { },
            "System.String", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 40, 92));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665695, ".ctor", 6278, "20040108080808", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32", "System.Int32", "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134221595),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134221596),
                new SourceMethodParameterDefinition("width", 2, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134221597),
                new SourceMethodParameterDefinition("height", 3, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134221598)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 30));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665696, "Contains", 134, "2002020808", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134221599),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134221600)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 25, 53));
    }

    private static void PublishMethods1(SourceAssemblyMethodCatalog methods)
    {
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665697, "Contains", 134, "200102118570", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Point" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Point", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Point"), 1, 134221601)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 29, 73));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665698, "Contains", 134, "200102118580", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134221602)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 37, 90));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665699, "Contains", 134, "200201101185701002", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Microsoft.Xna.Framework.Point&", "System.Boolean&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Point&", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Point")), 1, 134221603),
                new SourceMethodParameterDefinition("result", 1, 2, "System.Boolean&", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Boolean")), 2, 134221604)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 31, 76));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665700, "Contains", 134, "200201101185801002", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Microsoft.Xna.Framework.Rectangle&", "System.Boolean&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134221605),
                new SourceMethodParameterDefinition("result", 1, 2, "System.Boolean&", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Boolean")), 2, 134221606)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 39, 93));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665701, "Offset", 134, "200101118570", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Point" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("offset", 0, 0, "Microsoft.Xna.Framework.Point", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Point"), 1, 134221607)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 39));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665702, "Offset", 134, "2002010808", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("offsetX", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134221608),
                new SourceMethodParameterDefinition("offsetY", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134221609)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 29));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665703, "Inflate", 134, "2002010808", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("horizontalValue", 0, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134221610),
                new SourceMethodParameterDefinition("verticalValue", 1, 0, "System.Int32", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134221611)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 29, 61));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665704, "Equals", 486, "200102118580", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("other", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134221612)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 13));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665705, "Equals", 198, "2001021C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Object" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("obj", 0, 0, "System.Object", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Object"), 1, 134221613)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 11, 28));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665706, "ToString", 198, "20000E", new KeyValuePair<string, string>[] { }, "System.String",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 48, 109));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665707, "GetHashCode", 198, "200008", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 12, 28));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665708, "Intersects", 134, "200102118580", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134221614)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 23, 63));
    }

    private static void PublishMethods2(SourceAssemblyMethodCatalog methods)
    {
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665709, "Intersects", 134, "200201101185801002", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Microsoft.Xna.Framework.Rectangle&", "System.Boolean&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134221615),
                new SourceMethodParameterDefinition("result", 1, 2, "System.Boolean&", false, null, null,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Boolean")), 2, 134221616)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 25, 62));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665710, "op_Equality", 2198, "000202118580118580", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134221617),
                new SourceMethodParameterDefinition("b", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134221618)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 23, 59));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665711, "op_Inequality", 2198, "000202118580118580", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134221619),
                new SourceMethodParameterDefinition("b", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null, null,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134221620)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 6, 11));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665712, "Intersect", 150, "0002118580118580118580", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Rectangle",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134221621),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134221622)
            }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle"), true, 6, 13));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665713, "Intersect", 150, "000301101185801011858010118580",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Rectangle&", "Microsoft.Xna.Framework.Rectangle&",
                "Microsoft.Xna.Framework.Rectangle&"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134221623),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 2, 134221624),
                new SourceMethodParameterDefinition("result", 2, 2, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 3, 134221625)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 61, 150));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665714, "Union", 150, "0002118580118580118580", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Rectangle",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134221626),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134221627)
            }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle"), true, 30, 86));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665715, "Union", 150, "000301101185801011858010118580", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Rectangle&", "Microsoft.Xna.Framework.Rectangle&",
                "Microsoft.Xna.Framework.Rectangle&"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value1", 0, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 1, 134221628),
                new SourceMethodParameterDefinition("value2", 1, 0, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 2, 134221629),
                new SourceMethodParameterDefinition("result", 2, 2, "Microsoft.Xna.Framework.Rectangle&", false, null,
                    null, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Rectangle")), 3, 134221630)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 35, 107));
        methods.RegisterDefinition(new SourceMethodDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Rectangle",
            33554784, 100665716, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
    }
}
