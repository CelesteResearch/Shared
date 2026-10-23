using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMemberMetadata
{
    private static void PublishInstalled166(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread", 67120752, "threads",
            SourceMemberKind.Field, 17, "System.Collections.Generic.List`1<System.Threading.Thread>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Threading.Thread")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread", 67120753,
            "threadTimes", SourceMemberKind.Field, 17, "System.Collections.Generic.List`1<System.DateTime>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        typeIdentity: "System.DateTime")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread", 67120754,
            "threadInfos", SourceMemberKind.Field, 17, "System.Collections.Generic.List`1<System.String>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread", 67120755, "Current",
            SourceMemberKind.Field, 22, "System.WeakReference`1<System.Threading.Thread>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ThreadStaticAttribute",
                    "System.Void System.ThreadStaticAttribute::.ctor()", new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null,
            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.WeakReference`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        typeIdentity: "System.Threading.Thread")
                })));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread+<>c__DisplayClass1_0",
            33556462, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread+<>c__DisplayClass1_0",
            67120756, "method", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread+<>c__DisplayClass4_0",
            33556463, 1048835, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            "System.Object", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread+<>c__DisplayClass4_0",
            67120757, "method", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Action")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 33556464, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120758, "GLOBAL",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[] { 0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00 }), "System.String",
            "6200750073003A002F00", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120759, "MUSIC",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x63, 0x00
                }), "System.String", "6200750073003A002F006D007500730069006300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120760, "GAMEPLAY",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                    0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                    0x78, 0x00
                }), "System.String", "6200750073003A002F00670061006D00650070006C00610079005F00730066007800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120761, "STINGS",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00,
                    0x73, 0x00
                }), "System.String", "6200750073003A002F006D0075007300690063002F007300740069006E0067007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120762, "UI",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x75, 0x00, 0x69, 0x00, 0x5F, 0x00,
                    0x73, 0x00, 0x66, 0x00, 0x78, 0x00
                }), "System.String", "6200750073003A002F00750069005F00730066007800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120763, "AMBIENCE",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                    0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                    0x78, 0x00, 0x2F, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x69, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x63, 0x00, 0x65, 0x00
                }), "System.String",
            "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F0061006D006200690065006E0063006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120764, "CHAR",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                    0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                    0x78, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x68, 0x00, 0x61, 0x00, 0x72, 0x00
                }), "System.String",
            "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F006300680061007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120765, "YES_PAUSE",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                    0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                    0x78, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x2F, 0x00, 0x67, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2F, 0x00, 0x79, 0x00,
                    0x65, 0x00, 0x73, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x61, 0x00, 0x75, 0x00, 0x73, 0x00, 0x65, 0x00
                }), "System.String",
            "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F00670061006D0065002F00670065006E006500720061006C002F007900650073005F0070006100750073006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67120766, "CHAPTERS",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                    0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                    0x78, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x68, 0x00, 0x61, 0x00, 0x70, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00
                }), "System.String",
            "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F00670061006D0065002F0063006800610070007400650072007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 33556465, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 67120767, "MUSIC",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x76, 0x00, 0x63, 0x00, 0x61, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x63, 0x00
                }), "System.String", "7600630061003A002F006D007500730069006300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 67120768, "GAMEPLAY_SFX",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x76, 0x00, 0x63, 0x00, 0x61, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                    0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                    0x78, 0x00
                }), "System.String", "7600630061003A002F00670061006D00650070006C00610079005F00730066007800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 67120769, "UI_SFX",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x76, 0x00, 0x63, 0x00, 0x61, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x75, 0x00, 0x69, 0x00, 0x5F, 0x00,
                    0x73, 0x00, 0x66, 0x00, 0x78, 0x00
                }), "System.String", "7600630061003A002F00750069005F00730066007800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 33556466, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120770,
            "PAUSE_MENU", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x70, 0x00, 0x61, 0x00, 0x75, 0x00, 0x73, 0x00, 0x65, 0x00, 0x5F, 0x00,
                    0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x75, 0x00
                }), "System.String", "73006E0061007000730068006F0074003A002F00700061007500730065005F006D0065006E007500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120771,
            "MAIN_DOWN", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x5F, 0x00,
                    0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x5F, 0x00, 0x6D, 0x00, 0x75, 0x00,
                    0x74, 0x00, 0x65, 0x00
                }), "System.String",
            "73006E0061007000730068006F0074003A002F006D0075007300690063005F006D00610069006E0073005F006D00750074006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120772,
            "UNDERWATER", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x75, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x65, 0x00, 0x72, 0x00, 0x77, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00
                }), "System.String", "73006E0061007000730068006F0074003A002F0075006E0064006500720077006100740065007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120773, "DIALOGUE",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x64, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x67, 0x00,
                    0x75, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x72, 0x00,
                    0x6F, 0x00, 0x67, 0x00, 0x72, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00
                }), "System.String",
            "73006E0061007000730068006F0074003A002F006400690061006C006F006700750065005F0069006E005F00700072006F0067007200650073007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120774,
            "GAME_10_INSIDE_CAFE", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                    0x30, 0x00, 0x5F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x69, 0x00, 0x64, 0x00, 0x65, 0x00,
                    0x5F, 0x00, 0x63, 0x00, 0x61, 0x00, 0x66, 0x00, 0x65, 0x00
                }), "System.String",
            "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F0069006E0073006900640065005F006300610066006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120775,
            "GAME_10_GRANNY_CLOUDS", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                    0x30, 0x00, 0x5F, 0x00, 0x67, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x6E, 0x00, 0x79, 0x00,
                    0x5F, 0x00, 0x63, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x64, 0x00, 0x73, 0x00, 0x5F, 0x00,
                    0x64, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x75, 0x00, 0x65, 0x00
                }), "System.String",
            "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F006700720061006E006E0079005F0063006C006F007500640073005F006400690061006C006F00670075006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120776,
            "GAME_10_GOLDEN_ROOM", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                    0x30, 0x00, 0x5F, 0x00, 0x67, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x5F, 0x00, 0x66, 0x00, 0x6C, 0x00,
                    0x61, 0x00, 0x76, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x72, 0x00
                }), "System.String",
            "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F0067006F006C00640065006E005F0072006F006F006D005F0066006C00610076006F0075007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120777,
            "GAME_10_BIRD_WINGS_SILENCED", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                    0x30, 0x00, 0x5F, 0x00, 0x62, 0x00, 0x69, 0x00, 0x72, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x73, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6C, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F0062006900720064005F00770069006E00670073005F00730069006C0065006E00630065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67120778,
            "DASH_ASSIST_ACTIVE", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x67, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x64, 0x00, 0x61, 0x00, 0x73, 0x00, 0x68, 0x00, 0x5F, 0x00,
                    0x61, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x5F, 0x00, 0x61, 0x00,
                    0x63, 0x00, 0x74, 0x00, 0x69, 0x00, 0x76, 0x00, 0x65, 0x00
                }), "System.String",
            "73006E0061007000730068006F0074003A002F00670061006D0065005F00670065006E005F0064006100730068005F006100730073006900730074005F00610063007400690076006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 33556467, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120779, "NONE",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[] { 0x6E, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x6C, 0x00 }), "System.String", "6E0075006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120780,
            "music_levelselect", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x75, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x5F, 0x00,
                    0x73, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x63, 0x00, 0x74, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F006C006500760065006C005F00730065006C00650063007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120781, "music_credits",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x72, 0x00, 0x65, 0x00, 0x64, 0x00, 0x69, 0x00, 0x74, 0x00,
                    0x73, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F006300720065006400690074007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120782,
            "music_complete_area", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00,
                    0x74, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x61, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F0063006F006D0070006C006500740065005F006100720065006100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120783,
            "music_complete_summit", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00,
                    0x74, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x6D, 0x00, 0x69, 0x00,
                    0x74, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F0063006F006D0070006C006500740065005F00730075006D006D0069007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120784,
            "music_complete_bside", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00,
                    0x74, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x62, 0x00, 0x73, 0x00, 0x69, 0x00, 0x64, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F0063006F006D0070006C006500740065005F0062007300690064006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120785,
            "music_prologue_intro_vignette", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00,
                    0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x2F, 0x00, 0x30, 0x00, 0x30, 0x00, 0x5F, 0x00, 0x70, 0x00,
                    0x72, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x75, 0x00, 0x65, 0x00, 0x2F, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x5F, 0x00, 0x76, 0x00, 0x69, 0x00,
                    0x67, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x74, 0x00, 0x74, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F00670061006D0065002F00300030005F00700072006F006C006F006700750065002F0069006E00740072006F005F007600690067006E006500740074006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120786,
            "music_prologue_beginning", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x30, 0x00, 0x2F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x72, 0x00, 0x6F, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0030002F0069006E00740072006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120787,
            "music_prologue_collapse", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x30, 0x00, 0x2F, 0x00, 0x62, 0x00, 0x72, 0x00, 0x69, 0x00, 0x64, 0x00, 0x67, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0030002F00620072006900640067006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120788,
            "music_prologue_title_ping", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x30, 0x00, 0x2F, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x5F, 0x00,
                    0x70, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0030002F007400690074006C0065005F00700069006E006700",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120789, "music_city",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x31, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0031002F006D00610069006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120790,
            "music_city_theo", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x31, 0x00, 0x2F, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6F, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0031002F007400680065006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120791,
            "music_oldsite_beginning", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x62, 0x00, 0x65, 0x00, 0x67, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x6E, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x67, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0062006500670069006E006E0069006E006700",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120792,
            "music_oldsite_mirror", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x72, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x72, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F006D006900720072006F007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120793,
            "music_oldsite_dreamblock_sting_pt1", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x64, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x62, 0x00,
                    0x6C, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x6B, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x67, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x74, 0x00, 0x31, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0064007200650061006D0062006C006F0063006B005F007300740069006E0067005F00700074003100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120794,
            "music_oldsite_dreamblock_sting_pt2", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x64, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x62, 0x00,
                    0x6C, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x6B, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x67, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x74, 0x00, 0x32, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0064007200650061006D0062006C006F0063006B005F007300740069006E0067005F00700074003200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120795,
            "music_oldsite_evil_maddy", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x65, 0x00, 0x76, 0x00, 0x69, 0x00, 0x6C, 0x00, 0x5F, 0x00, 0x6D, 0x00,
                    0x61, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F006500760069006C005F006D006100640065006C0069006E006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120796,
            "music_oldsite_chase", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x68, 0x00, 0x61, 0x00, 0x73, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0063006800610073006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120797,
            "music_oldsite_payphone_loop", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x70, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00,
                    0x6C, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x70, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F00700068006F006E0065005F006C006F006F007000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120798,
            "music_oldsite_payphone_end", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x70, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x64, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F00700068006F006E0065005F0065006E006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120799,
            "music_oldsite_awake", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x32, 0x00, 0x2F, 0x00, 0x61, 0x00, 0x77, 0x00, 0x61, 0x00, 0x6B, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F006100770061006B006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120800,
            "music_resort_intro", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x33, 0x00, 0x2F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x72, 0x00, 0x6F, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F0069006E00740072006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120801,
            "music_resort_explore", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x33, 0x00, 0x2F, 0x00, 0x65, 0x00, 0x78, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x72, 0x00,
                    0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F006500780070006C006F0072006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120802,
            "music_resort_clean", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x33, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F0063006C00650061006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120803,
            "music_resort_clean_extended", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x33, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x5F, 0x00,
                    0x65, 0x00, 0x78, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F0063006C00650061006E005F0065007800740065006E00640065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120804,
            "music_resort_oshiro_theme", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x33, 0x00, 0x2F, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x68, 0x00, 0x69, 0x00, 0x72, 0x00, 0x6F, 0x00,
                    0x5F, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F006F0073006800690072006F005F007400680065006D006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120805,
            "music_resort_oshiro_chase", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x33, 0x00, 0x2F, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x68, 0x00, 0x69, 0x00, 0x72, 0x00, 0x6F, 0x00,
                    0x5F, 0x00, 0x63, 0x00, 0x68, 0x00, 0x61, 0x00, 0x73, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F006F0073006800690072006F005F0063006800610073006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120806,
            "music_cliffside_main", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x34, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0034002F006D00610069006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120807,
            "music_cliffside_heavywinds", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x34, 0x00, 0x2F, 0x00, 0x68, 0x00, 0x65, 0x00, 0x61, 0x00, 0x76, 0x00, 0x79, 0x00, 0x5F, 0x00,
                    0x77, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x73, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0034002F00680065006100760079005F00770069006E0064007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120808,
            "music_cliffside_panicattack", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x34, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x69, 0x00, 0x67, 0x00, 0x61, 0x00,
                    0x6D, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0034002F006D0069006E006900670061006D006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120809,
            "music_temple_normal", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x35, 0x00, 0x2F, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x6C, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0035002F006E006F0072006D0061006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120810,
            "music_temple_middle", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x35, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x64, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x65, 0x00,
                    0x5F, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0035002F006D006900640064006C0065005F00740065006D0070006C006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120811,
            "music_temple_mirror", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x35, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x72, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x72, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0035002F006D006900720072006F007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120812,
            "music_temple_mirrorcutscene", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x35, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x72, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x72, 0x00,
                    0x5F, 0x00, 0x63, 0x00, 0x75, 0x00, 0x74, 0x00, 0x73, 0x00, 0x63, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0035002F006D006900720072006F0072005F006300750074007300630065006E006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120813,
            "music_reflection_maddietheo", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x74, 0x00,
                    0x68, 0x00, 0x65, 0x00, 0x6F, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F006D006100640065006C0069006E0065005F0061006E0064005F007400680065006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120814,
            "music_reflection_starjump", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x61, 0x00, 0x72, 0x00, 0x6A, 0x00, 0x75, 0x00,
                    0x6D, 0x00, 0x70, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F0073007400610072006A0075006D007000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120815,
            "music_reflection_fall", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x66, 0x00, 0x61, 0x00,
                    0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F007400680065005F00660061006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120816,
            "music_reflection_fight", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x62, 0x00, 0x61, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x66, 0x00, 0x69, 0x00, 0x67, 0x00, 0x68, 0x00, 0x74, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F0062006100640065006C0069006E0065005F0066006900670068007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120817,
            "music_reflection_fight_glitch", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x62, 0x00, 0x61, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x67, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00,
                    0x68, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F0062006100640065006C0069006E0065005F0067006C006900740063006800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120818,
            "music_reflection_fight_finish", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x62, 0x00, 0x61, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x61, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x74, 0x00, 0x69, 0x00, 0x63, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F0062006100640065006C0069006E0065005F00610063006F0075007300740069006300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120819,
            "music_reflection_main", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F006D00610069006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120820,
            "music_reflection_secretroom", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x36, 0x00, 0x2F, 0x00, 0x73, 0x00, 0x65, 0x00, 0x63, 0x00, 0x72, 0x00, 0x65, 0x00, 0x74, 0x00,
                    0x5F, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x6D, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0036002F007300650063007200650074005F0072006F006F006D00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120821,
            "music_summit_main", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x37, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0037002F006D00610069006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120822,
            "music_summit_finalascent", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x37, 0x00, 0x2F, 0x00, 0x66, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x5F, 0x00,
                    0x61, 0x00, 0x73, 0x00, 0x63, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0037002F00660069006E0061006C005F0061007300630065006E007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120823,
            "music_epilogue_main", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x38, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0038002F006D00610069006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120824,
            "music_core_main", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                    0x39, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0039002F006D00610069006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120825,
            "music_farewell_part01", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x70, 0x00,
                    0x61, 0x00, 0x72, 0x00, 0x74, 0x00, 0x30, 0x00, 0x31, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00700061007200740030003100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120826,
            "music_farewell_part02", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x70, 0x00,
                    0x61, 0x00, 0x72, 0x00, 0x74, 0x00, 0x30, 0x00, 0x32, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00700061007200740030003200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120827,
            "music_farewell_part03", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x70, 0x00,
                    0x61, 0x00, 0x72, 0x00, 0x74, 0x00, 0x30, 0x00, 0x33, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00700061007200740030003300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120828,
            "music_farewell_intermission_heartgroove", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x68, 0x00, 0x65, 0x00, 0x61, 0x00, 0x72, 0x00,
                    0x74, 0x00, 0x67, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x76, 0x00, 0x65, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F0069006E007400650072006D0069007300730069006F006E005F0068006500610072007400670072006F006F0076006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120829,
            "music_farewell_intermission_powerpoint", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x6F, 0x00, 0x77, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x70, 0x00, 0x6F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F0069006E007400650072006D0069007300730069006F006E005F0070006F0077006500720070006F0069006E007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120830,
            "music_farewell_reconciliation", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x72, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x69, 0x00, 0x6C, 0x00, 0x69, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F007200650063006F006E00630069006C0069006100740069006F006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120831,
            "music_farewell_cassette", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x61, 0x00, 0x73, 0x00, 0x73, 0x00, 0x65, 0x00, 0x74, 0x00, 0x74, 0x00, 0x65, 0x00, 0x5F, 0x00,
                    0x72, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x73, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00630061007300730065007400740065005F0072006F006F006D007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120832,
            "music_farewell_final_run", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x66, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x5F, 0x00, 0x72, 0x00, 0x75, 0x00, 0x6E, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00660069006E0061006C005F00720075006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120833,
            "music_farewell_end_cinematic", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x64, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00630069006E0065006D0061007400690063002F0065006E006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120834,
            "music_farewell_end_cinematic_intro", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x72, 0x00, 0x6F, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00630069006E0065006D0061007400690063002F0065006E0064005F0069006E00740072006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120835,
            "music_farewell_firstbirdcrash_cinematic", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x62, 0x00, 0x69, 0x00, 0x72, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x72, 0x00,
                    0x61, 0x00, 0x73, 0x00, 0x68, 0x00, 0x5F, 0x00, 0x66, 0x00, 0x69, 0x00, 0x72, 0x00, 0x73, 0x00,
                    0x74, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00630069006E0065006D0061007400690063002F0062006900720064005F00630072006100730068005F0066006900720073007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120836,
            "music_farewell_secondbirdcrash_cinematic", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x62, 0x00, 0x69, 0x00, 0x72, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x72, 0x00,
                    0x61, 0x00, 0x73, 0x00, 0x68, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x65, 0x00, 0x63, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x64, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F00630069006E0065006D0061007400690063002F0062006900720064005F00630072006100730068005F007300650063006F006E006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120837,
            "music_farewell_granny", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x67, 0x00,
                    0x72, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x6E, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x66, 0x00, 0x61, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x77, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F006700720061006E006E0079005F006600610072006500770065006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120838,
            "music_farewell_golden_room", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x77, 0x00, 0x5F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2F, 0x00, 0x67, 0x00,
                    0x6F, 0x00, 0x6C, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x72, 0x00, 0x6F, 0x00,
                    0x6F, 0x00, 0x6D, 0x00
                }), "System.String",
            "6500760065006E0074003A002F006E00650077005F0063006F006E00740065006E0074002F006D0075007300690063002F006C0076006C00310030002F0067006F006C00640065006E005F0072006F006F006D00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120839,
            "music_pico8_title", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x6C, 0x00, 0x61, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x70, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x38, 0x00, 0x5F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x5F, 0x00, 0x30, 0x00, 0x30, 0x00
                }), "System.String",
            "6500760065006E0074003A002F0063006C00610073007300690063002F007000690063006F0038005F006D00750073005F0030003000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120840,
            "music_pico8_area1", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x6C, 0x00, 0x61, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x70, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x38, 0x00, 0x5F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x5F, 0x00, 0x30, 0x00, 0x31, 0x00
                }), "System.String",
            "6500760065006E0074003A002F0063006C00610073007300690063002F007000690063006F0038005F006D00750073005F0030003100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67120841,
            "music_pico8_area2", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x6C, 0x00, 0x61, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x70, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x38, 0x00, 0x5F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x5F, 0x00, 0x30, 0x00, 0x32, 0x00
                }), "System.String",
            "6500760065006E0074003A002F0063006C00610073007300690063002F007000690063006F0038005F006D00750073005F0030003200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String")));
    }
}
