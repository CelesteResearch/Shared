using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl200(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ObjectCreationDelegate", 33556978, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.RuntimeEnvironment", 33556979, 1048577,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.RuntimeEnvironment", 385880346, "SystemConfigurationFile",
                SourceMemberKind.Property, 0, "System.String", 2198, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeArrayRankMismatchException", 33556980, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeArrayTypeMismatchException", 33556981, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 33556982, 1310857,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.CriticalFinalizerObject", ["System.IDisposable"],
                [
                    new("System.Security.SecurityCriticalAttribute",
                        "System.Void System.Security.SecurityCriticalAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 67121143, "handle", SourceMemberKind.Field, 4,
                "System.IntPtr",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 67121144, "_state", SourceMemberKind.Field, 1,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 67121145, "_ownsHandle", SourceMemberKind.Field, 1,
                "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 67121146, "_fullyInitialized", SourceMemberKind.Field, 1,
                "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 67121147, "RefCount_Mask", SourceMemberKind.Field, 32849,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xFC, 0xFF, 0xFF, 0x7F]), "System.Int32",
                "FCFFFF7F", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 67121148, "RefCount_One", SourceMemberKind.Field, 32849,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 385880347, "IsClosed", SourceMemberKind.Property, 0,
                "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle", 385880348, "IsInvalid", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle+State", 33556983, 259,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle+State", 67121149, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle+State", 67121150, "Closed", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.SafeHandle+State", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SafeHandle+State", 67121151, "Disposed", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.SafeHandle+State", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SEHException", 33556984, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExternalException", [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CONNECTDATA", 33556985, 1114377,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6D, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x43,
                            0x4F, 0x4E, 0x4E, 0x45, 0x43, 0x54, 0x44, 0x41, 0x54, 0x41, 0x20, 0x69, 0x6E, 0x73, 0x74,
                            0x65,
                            0x61, 0x64, 0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D,
                            0x69,
                            0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C,
                            0x69,
                            0x6E, 0x6B, 0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30,
                            0x32,
                            0x00, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CONNECTDATA", 67121152, "pUnk", SourceMemberKind.Field, 4102,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CONNECTDATA", 67121153, "dwCookie", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIEnumConnections", 33556986, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x42, 0x31, 0x39, 0x36, 0x42, 0x32, 0x38, 0x37, 0x2D, 0x42, 0x41, 0x42,
                            0x34,
                            0x2D, 0x31, 0x30, 0x31, 0x41, 0x2D, 0x42, 0x36, 0x39, 0x43, 0x2D, 0x30, 0x30, 0x41, 0x41,
                            0x30,
                            0x30, 0x33, 0x34, 0x31, 0x44, 0x30, 0x37, 0x00, 0x00,
                        ]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x72, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x49,
                            0x45, 0x6E, 0x75, 0x6D, 0x43, 0x6F, 0x6E, 0x6E, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x73,
                            0x20,
                            0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F,
                            0x2F,
                            0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F,
                            0x6D,
                            0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64,
                            0x3D,
                            0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 33556987, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x54,
                            0x59, 0x50, 0x45, 0x4B, 0x49, 0x4E, 0x44, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64,
                            0x2E,
                            0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72,
                            0x6F,
                            0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B,
                            0x2F,
                            0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00,
                            0x00,
                        ]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121154, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121155, "TKIND_ENUM", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121156, "TKIND_RECORD", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121157, "TKIND_MODULE", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121158, "TKIND_INTERFACE", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121159, "TKIND_DISPATCH", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121160, "TKIND_COCLASS", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121161, "TKIND_ALIAS", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x06, 0x00, 0x00, 0x00]), "System.Int32",
                "06000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121162, "TKIND_UNION", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x07, 0x00, 0x00, 0x00]), "System.Int32",
                "07000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEKIND", 67121163, "TKIND_MAX", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]), "System.Int32",
                "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 33556988, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6B, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x54,
                            0x59, 0x50, 0x45, 0x46, 0x4C, 0x41, 0x47, 0x53, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61,
                            0x64,
                            0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63,
                            0x72,
                            0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E,
                            0x6B,
                            0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00,
                            0x00,
                            0x00,
                        ]),
                ], "System.Int16", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121164, "value__", SourceMemberKind.Field, 1542,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121165, "TYPEFLAG_FAPPOBJECT", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00]), "System.Int16", "0100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121166, "TYPEFLAG_FCANCREATE", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00]), "System.Int16", "0200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121167, "TYPEFLAG_FLICENSED", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00]), "System.Int16", "0400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121168, "TYPEFLAG_FPREDECLID", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00]), "System.Int16", "0800",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121169, "TYPEFLAG_FHIDDEN", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00]), "System.Int16", "1000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121170, "TYPEFLAG_FCONTROL", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x20, 0x00]), "System.Int16", "2000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121171, "TYPEFLAG_FDUAL", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x40, 0x00]), "System.Int16", "4000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121172, "TYPEFLAG_FNONEXTENSIBLE", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", [0x80, 0x00]), "System.Int16", "8000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121173, "TYPEFLAG_FOLEAUTOMATION", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x01]), "System.Int16", "0001",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121174, "TYPEFLAG_FRESTRICTED", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x02]), "System.Int16", "0002",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121175, "TYPEFLAG_FAGGREGATABLE", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x04]), "System.Int16", "0004",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121176, "TYPEFLAG_FREPLACEABLE", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x08]), "System.Int16", "0008",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121177, "TYPEFLAG_FDISPATCHABLE", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x10]), "System.Int16", "0010",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121178, "TYPEFLAG_FREVERSEBIND", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x20]), "System.Int16", "0020",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEFLAGS", 67121179, "TYPEFLAG_FPROXY", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x40]), "System.Int16", "0040",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IMPLTYPEFLAGS", 33556989, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6F, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x49,
                            0x4D, 0x50, 0x4C, 0x54, 0x59, 0x50, 0x45, 0x46, 0x4C, 0x41, 0x47, 0x53, 0x20, 0x69, 0x6E,
                            0x73,
                            0x74, 0x65, 0x61, 0x64, 0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F,
                            0x2E,
                            0x6D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66,
                            0x77,
                            0x6C, 0x69, 0x6E, 0x6B, 0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34,
                            0x32,
                            0x30, 0x32, 0x00, 0x00, 0x00,
                        ]),
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IMPLTYPEFLAGS", 67121180, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IMPLTYPEFLAGS", 67121181, "IMPLTYPEFLAG_FDEFAULT",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]),
                "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IMPLTYPEFLAGS", 67121182, "IMPLTYPEFLAG_FSOURCE",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]),
                "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IMPLTYPEFLAGS", 67121183, "IMPLTYPEFLAG_FRESTRICTED",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IMPLTYPEFLAGS", 67121184, "IMPLTYPEFLAG_FDEFAULTVTABLE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]), "System.Int32",
                "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 33556990, 1114377,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x54,
                            0x59, 0x50, 0x45, 0x41, 0x54, 0x54, 0x52, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64,
                            0x2E,
                            0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72,
                            0x6F,
                            0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B,
                            0x2F,
                            0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00,
                            0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121185, "MEMBER_ID_NIL", SourceMemberKind.Field, 32854,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xFF, 0xFF, 0xFF, 0xFF]), "System.Int32",
                "FFFFFFFF", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121186, "guid", SourceMemberKind.Field, 6, "System.Guid",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121187, "lcid", SourceMemberKind.Field, 6, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121188, "dwReserved", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121189, "memidConstructor", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121190, "memidDestructor", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121191, "lpstrSchema", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121192, "cbSizeInstance", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121193, "typekind", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121194, "cFuncs", SourceMemberKind.Field, 6,
                "System.Int16",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121195, "cVars", SourceMemberKind.Field, 6, "System.Int16",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121196, "cImplTypes", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121197, "cbSizeVft", SourceMemberKind.Field, 6,
                "System.Int16",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121198, "cbAlignment", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121199, "wTypeFlags", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121200, "wMajorVerNum", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121201, "wMinorVerNum", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121202, "tdescAlias", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.TYPEDESC", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPEATTR", 67121203, "idldescType", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.IDLDESC", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 33556991, 1048841,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x46,
                            0x55, 0x4E, 0x43, 0x44, 0x45, 0x53, 0x43, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64,
                            0x2E,
                            0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72,
                            0x6F,
                            0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B,
                            0x2F,
                            0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00,
                            0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121204, "memid", SourceMemberKind.Field, 6, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121205, "lprgscode", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121206, "lprgelemdescParam", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121207, "funckind", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.FUNCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121208, "invkind", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.INVOKEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121209, "callconv", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121210, "cParams", SourceMemberKind.Field, 6,
                "System.Int16",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121211, "cParamsOpt", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121212, "oVft", SourceMemberKind.Field, 6, "System.Int16",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121213, "cScodes", SourceMemberKind.Field, 6,
                "System.Int16",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121214, "elemdescFunc", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ELEMDESC", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.FUNCDESC", 67121215, "wFuncFlags", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IDLFLAG", 33556992, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x69, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x49,
                            0x44, 0x4C, 0x46, 0x4C, 0x41, 0x47, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E,
                            0x20,
                            0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F,
                            0x73,
                            0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F,
                            0x3F,
                            0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00,
                        ]),
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], "System.Int16", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IDLFLAG", 67121216, "value__", SourceMemberKind.Field, 1542,
                "System.Int16",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IDLFLAG", 67121217, "IDLFLAG_NONE", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.IDLFLAG", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00]), "System.Int16", "0000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IDLFLAG", 67121218, "IDLFLAG_FIN", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.IDLFLAG", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00]), "System.Int16", "0100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IDLFLAG", 67121219, "IDLFLAG_FOUT", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.IDLFLAG", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00]), "System.Int16", "0200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IDLFLAG", 67121220, "IDLFLAG_FLCID", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.IDLFLAG", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00]), "System.Int16", "0400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
