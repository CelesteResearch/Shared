using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishInstalled212(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ILCursorExtensions",
                67123763, "NextBestFitLogID", SourceMemberKind.Field, 32849, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x49, 0x00, 0x4C, 0x00, 0x43, 0x00, 0x75, 0x00, 0x72, 0x00, 0x73, 0x00, 0x6F, 0x00, 0x72, 0x00,
                        0x45, 0x00, 0x78, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                        0x6E, 0x00, 0x73, 0x00, 0x2F, 0x00, 0x4E, 0x00, 0x65, 0x00, 0x78, 0x00, 0x74, 0x00, 0x42, 0x00,
                        0x65, 0x00, 0x73, 0x00, 0x74, 0x00, 0x46, 0x00, 0x69, 0x00, 0x74, 0x00,
                    ]), "System.String",
                "49004C0043007500720073006F00720045007800740065006E00730069006F006E0073002F004E006500780074004200650073007400460069007400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ILCursorExtensions",
                67123764, "PrevBestFitLogID", SourceMemberKind.Field, 32849, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x49, 0x00, 0x4C, 0x00, 0x43, 0x00, 0x75, 0x00, 0x72, 0x00, 0x73, 0x00, 0x6F, 0x00, 0x72, 0x00,
                        0x45, 0x00, 0x78, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                        0x6E, 0x00, 0x73, 0x00, 0x2F, 0x00, 0x50, 0x00, 0x72, 0x00, 0x65, 0x00, 0x76, 0x00, 0x42, 0x00,
                        0x65, 0x00, 0x73, 0x00, 0x74, 0x00, 0x46, 0x00, 0x69, 0x00, 0x74, 0x00,
                    ]), "System.String",
                "49004C0043007500720073006F00720045007800740065006E00730069006F006E0073002F0050007200650076004200650073007400460069007400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.InternHelper",
                33557300, 1048961, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.InternHelper",
                67123765, "True", SourceMemberKind.Field, 49, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.InternHelper",
                67123766, "False", SourceMemberKind.Field, 49, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.InternHelper`1",
                33557301, 1048960, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [], [], null, [],
                [
                    new("T", 0, 704643511, 0, [],
                        []),
                ],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.InternHelper`1",
                67123767, "Cache", SourceMemberKind.Field, 49,
                "System.Collections.Concurrent.ConcurrentDictionary`2<T,System.Object>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Concurrent.ConcurrentDictionary`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.InternHelper`1"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.InternHelper`1+<>c",
                33557302, 1057027, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("T", 0, 704643512, 0, [],
                        []),
                ],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.InternHelper`1+<>c",
                67123768, "<>9", SourceMemberKind.Field, 54, "Celeste.Mod.Helpers.InternHelper`1+<>c<T>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.Helpers.InternHelper`1+<>c"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.InternHelper`1+<>c"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.InternHelper`1+<>c",
                67123769, "<>9__1_0", SourceMemberKind.Field, 22, "System.Func`2<T,System.Object>", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte[])",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
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
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Celeste.Mod.Helpers.InternHelper`1+<>c"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LoggedMonoModder",
                33557303, 1048577, "MonoMod.Patcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
                "MonoMod.MonoModder", [], [], null,
                [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "MonoMod.Patcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.MonoModder"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LogRotationHelper",
                33557304, 1048961, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LogRotationHelper+OldestFirst", 33557305, 1048578,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                ["System.Collections.Generic.IComparer`1<System.String>"],
                [], null,
                ["System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Generic.IComparer`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String"),
                        ]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LogRotationHelper+<>c", 33557306, 1057027,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LogRotationHelper+<>c", 67123770, "<>9", SourceMemberKind.Field, 54,
                "Celeste.Mod.Helpers.LogRotationHelper+<>c", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LogRotationHelper+<>c")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.LogRotationHelper+<>c", 67123771, "<>9__1_0", SourceMemberKind.Field, 22,
                "System.Func`2<System.String,System.UInt64>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
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
                            "System.String"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.LogWriter",
                33557307,
                1048577, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", ["System.IDisposable"], [], null,
                ["System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.LogWriter",
                67123772,
                "STDOUT", SourceMemberKind.Field, 6, "Celeste.Mod.Helpers.OutputStreamCapture", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.OutputStreamCapture")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.LogWriter",
                67123773,
                "STDERR", SourceMemberKind.Field, 6, "Celeste.Mod.Helpers.OutputStreamCapture", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.OutputStreamCapture")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.LogWriter",
                67123774,
                "File", SourceMemberKind.Field, 6, "System.IO.TextWriter", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.TextWriter")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.LogWriter",
                67123775,
                "captureStarted", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.LogWriter",
                385878556, "Encoding", SourceMemberKind.Property, 0, "System.Text.Encoding", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.Encoding")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.OutputStreamCapture",
                33557308, 1048577, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.IO.TextWriter", [], [], null,
                [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.TextWriter"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.OutputStreamCapture",
                67123776, "Stream", SourceMemberKind.Field, 6, "System.IO.TextWriter", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.TextWriter")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.OutputStreamCapture",
                67123777, "Writer", SourceMemberKind.Field, 6, "Celeste.Mod.Helpers.LogWriter", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.LogWriter")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.OutputStreamCapture",
                385878557, "Encoding", SourceMemberKind.Property, 0, "System.Text.Encoding", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.Encoding")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                33557309, 1048577, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                67123778, "<Name>k__BackingField", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                67123779, "<Version>k__BackingField", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                67123780, "<LastUpdate>k__BackingField", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                67123781, "<URL>k__BackingField", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                67123782, "<xxHash>k__BackingField", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List`1<System.String>", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                67123783, "<GameBananaType>k__BackingField", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                67123784, "<GameBananaId>k__BackingField", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                385878558, "Name", SourceMemberKind.Property, 0, "System.String", 2502, 2502, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                385878559, "Version", SourceMemberKind.Property, 0, "System.String", 2502, 2502, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                385878560, "LastUpdate", SourceMemberKind.Property, 0, "System.Int32", 2502, 2502, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                385878561, "URL", SourceMemberKind.Property, 0, "System.String", 2502, 2502, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                385878562, "xxHash", SourceMemberKind.Property, 0, "System.Collections.Generic.List`1<System.String>",
                2502,
                2502, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                385878563, "GameBananaType", SourceMemberKind.Property, 0, "System.String", 2502, 2502, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ModUpdateInfo",
                385878564, "GameBananaId", SourceMemberKind.Property, 0, "System.Int32", 2502, 2502, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper",
                33557310, 1048577, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper",
                67123785, "updateCheckTask", SourceMemberKind.Field, 17, "System.Threading.Tasks.Task", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Task")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper",
                67123786, "availableUpdates", SourceMemberKind.Field, 17,
                "System.Collections.Generic.SortedDictionary`2<Celeste.Mod.Helpers.ModUpdateInfo,Celeste.Mod.EverestModuleMetadata>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.SortedDictionary`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.ModUpdateInfo"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.EverestModuleMetadata"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+MostRecentUpdatedFirst", 33557311, 1048579,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                ["System.Collections.Generic.IComparer`1<Celeste.Mod.Helpers.ModUpdateInfo>"],
                [], null,
                ["System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Generic.IComparer`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.Helpers.ModUpdateInfo"),
                        ]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry", 33557312, 1048579,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry", 67123787, "<Dependencies>k__BackingField",
                SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<Celeste.Mod.Helpers.ModUpdateInfo>", -1,
                -1,
                0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.ModUpdateInfo"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry", 67123788,
                "<OptionalDependencies>k__BackingField", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List`1<Celeste.Mod.Helpers.ModUpdateInfo>", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.ModUpdateInfo"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry", 385878565, "Dependencies",
                SourceMemberKind.Property, 0, "System.Collections.Generic.List`1<Celeste.Mod.Helpers.ModUpdateInfo>",
                2182,
                2182, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.ModUpdateInfo"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry", 385878566, "OptionalDependencies",
                SourceMemberKind.Property, 0, "System.Collections.Generic.List`1<Celeste.Mod.Helpers.ModUpdateInfo>",
                2182,
                2182, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.ModUpdateInfo"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass11_0", 33557313, 1048835,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass11_0", 67123789, "excludeBlacklist",
                SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass4_0", 33557314, 1048835,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass4_0", 67123790, "metadata",
                SourceMemberKind.Field,
                6, "Celeste.Mod.EverestModuleMetadata", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.EverestModuleMetadata")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 33557315, 1048835,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [
                    "System.Collections.Generic.IEnumerable`1<System.String>", "System.Collections.IEnumerable",
                    "System.Collections.Generic.IEnumerator`1<System.String>", "System.Collections.IEnumerator",
                    "System.IDisposable",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
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
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.IEnumerable"),
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.IEnumerator"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123791, "<>1__state",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123792, "<>2__current",
                SourceMemberKind.Field, 1, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123793, "<>l__initialThreadId",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123794, "url", SourceMemberKind.Field,
                1,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123795, "<>3__url",
                SourceMemberKind.Field, 6, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123796, "<gbid>5__2",
                SourceMemberKind.Field, 1, "System.UInt32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.UInt32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123797, "<>7__wrap2",
                SourceMemberKind.Field, 1, "System.String[]", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte[])",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.String"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 67123798, "<>7__wrap3",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 385878567,
                "System.Collections.Generic.IEnumerator<System.String>.Current", SourceMemberKind.Property, 0,
                "System.String", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16", 385878568,
                "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ScopeFinalizer",
                33557316, 1048833, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", ["System.IDisposable"], [], null,
                ["System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Helpers.ScopeFinalizer",
                67123799, "onExit", SourceMemberKind.Field, 1, "System.Action", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Action")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 33557317, 1048577,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.IO.Stream",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.Stream"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 67123800, "archive", SourceMemberKind.Field, 33,
                "System.IO.Compression.ZipArchive", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IO.Compression.ZipArchive")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 67123801, "entry", SourceMemberKind.Field, 33,
                "System.IO.Compression.ZipArchiveEntry", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IO.Compression.ZipArchiveEntry")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 67123802, "wrappedStream", SourceMemberKind.Field, 1,
                "System.IO.Stream", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.Stream")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 67123803, "position", SourceMemberKind.Field, 1,
                "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int64")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 67123804, "<Length>k__BackingField",
                SourceMemberKind.Field, 33, "System.Int64", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int64")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 67123805, "trashbinSize", SourceMemberKind.Field,
                32849,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x20, 0x00, 0x00]), "System.Int32",
                "00200000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 67123806, "trashbin", SourceMemberKind.Field, 17,
                "System.Byte[]", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Byte"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 385878569, "CanRead", SourceMemberKind.Property, 0,
                "System.Boolean", 2246, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 385878570, "CanSeek", SourceMemberKind.Property, 0,
                "System.Boolean", 2246, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 385878571, "CanWrite", SourceMemberKind.Property, 0,
                "System.Boolean", 2246, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 385878572, "Length", SourceMemberKind.Property, 0,
                "System.Int64", 2246, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int64")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", 385878573, "Position", SourceMemberKind.Property, 0,
                "System.Int64", 2246, 2246, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int64")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UndisposableStream",
                33557318, 1048833, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.IO.Stream", [], [], null,
                [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.Stream"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UndisposableStream",
                67123807, "Inner", SourceMemberKind.Field, 38, "System.IO.Stream", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IO.Stream")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UndisposableStream",
                385878574, "CanRead", SourceMemberKind.Property, 0, "System.Boolean", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UndisposableStream",
                385878575, "CanSeek", SourceMemberKind.Property, 0, "System.Boolean", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UndisposableStream",
                385878576, "CanWrite", SourceMemberKind.Property, 0, "System.Boolean", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UndisposableStream",
                385878577, "Length", SourceMemberKind.Property, 0, "System.Int64", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int64")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UndisposableStream",
                385878578, "Position", SourceMemberKind.Property, 0, "System.Int64", 2246, 2246, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int64")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper",
                33557319, 1048961, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper",
                67123808, "cacher", SourceMemberKind.Field, 49, "Celeste.Mod.Helpers.UnicodeStringHelper+Cacher", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.UnicodeStringHelper+Cacher")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper+ListInt", 33557320, 1048578,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.RequiredMemberAttribute",
                        "System.Void System.Runtime.CompilerServices.RequiredMemberAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper+ListInt", 67123809, "Elements", SourceMemberKind.Field, 6,
                "System.Int32[]", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.RequiredMemberAttribute",
                        "System.Void System.Runtime.CompilerServices.RequiredMemberAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Int32"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper+ListInt", 385878579, "Count", SourceMemberKind.Property, 0,
                "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper+ListInt", 385878580, "Item", SourceMemberKind.Property, 0,
                "System.Int32", 2182, -1, 1, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper+Cacher", 33557321, 1048579,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.CacheHelper`2<System.String,Celeste.Mod.Helpers.UnicodeStringHelper+ListInt>",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.Mod.Helpers.CacheHelper`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Helpers.UnicodeStringHelper+ListInt"),
                    ]), []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper+Cacher+<>c", 33557322, 1057027,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Helpers.UnicodeStringHelper+Cacher+<>c", 67123810, "<>9", SourceMemberKind.Field, 54,
                "Celeste.Mod.Helpers.UnicodeStringHelper+Cacher+<>c", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.Helpers.UnicodeStringHelper+Cacher+<>c")));
        }
    }
}
