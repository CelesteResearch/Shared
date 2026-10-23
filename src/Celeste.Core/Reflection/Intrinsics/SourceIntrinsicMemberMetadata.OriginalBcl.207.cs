using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl207(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IEnumMoniker", 33557121, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x32, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IEnumString", 33557122, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IEnumVARIANT", 33557123, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x34, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IExpando", 33557124, 160, null, null,
                ["System.Runtime.InteropServices.ComTypes.IReflect"],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x41, 0x46, 0x42, 0x46, 0x31, 0x35, 0x45, 0x36, 0x2D, 0x43, 0x33, 0x37,
                            0x43,
                            0x2D, 0x31, 0x31, 0x64, 0x32, 0x2D, 0x42, 0x38, 0x38, 0x45, 0x2D, 0x30, 0x30, 0x41, 0x30,
                            0x43,
                            0x39, 0x42, 0x34, 0x37, 0x31, 0x42, 0x38, 0x00, 0x00,
                        ]),
                ], null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.FILETIME", 33557125, 1048841,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.FILETIME", 67121481, "dwLowDateTime", SourceMemberKind.Field,
                6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.FILETIME", 67121482, "dwHighDateTime", SourceMemberKind.Field,
                6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IMoniker", 33557126, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x66, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IPersistFile", 33557127, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x62, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IReflect", 33557128, 160, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x41, 0x46, 0x42, 0x46, 0x31, 0x35, 0x45, 0x35, 0x2D, 0x43, 0x33, 0x37,
                            0x43,
                            0x2D, 0x31, 0x31, 0x64, 0x32, 0x2D, 0x42, 0x38, 0x38, 0x45, 0x2D, 0x30, 0x30, 0x41, 0x30,
                            0x43,
                            0x39, 0x42, 0x34, 0x37, 0x31, 0x42, 0x38, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IReflect", 385880537, "UnderlyingSystemType",
                SourceMemberKind.Property, 0, "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IRunningObjectTable", 33557129, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 33557130, 1114377,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121483, "pwcsName", SourceMemberKind.Field, 6,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121484, "type", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121485, "cbSize", SourceMemberKind.Field, 6,
                "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121486, "mtime", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ComTypes.FILETIME", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121487, "ctime", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ComTypes.FILETIME", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121488, "atime", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ComTypes.FILETIME", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121489, "grfMode", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121490, "grfLocksSupported",
                SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121491, "clsid", SourceMemberKind.Field, 6,
                "System.Guid", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121492, "grfStateBits", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.STATSTG", 67121493, "reserved", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IStream", 33557131, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x63, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 33557132, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 67121494, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 67121495, "DESCKIND_NONE", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.DESCKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 67121496, "DESCKIND_FUNCDESC",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.DESCKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 67121497, "DESCKIND_VARDESC",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.DESCKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 67121498, "DESCKIND_TYPECOMP",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.DESCKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 67121499, "DESCKIND_IMPLICITAPPOBJ",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.DESCKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.DESCKIND", 67121500, "DESCKIND_MAX", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.ComTypes.DESCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.BINDPTR", 33557133, 1114385,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.BINDPTR", 67121501, "lpfuncdesc", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.BINDPTR", 67121502, "lpvardesc", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.BINDPTR", 67121503, "lptcomp", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.ITypeComp", 33557134, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x33, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.ITypeInfo2", 33557135, 4257, null, null,
                ["System.Runtime.InteropServices.ComTypes.ITypeInfo"],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x31, 0x32, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                ], null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 33557136, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121504, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121505, "TKIND_ENUM", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121506, "TKIND_RECORD", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121507, "TKIND_MODULE", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121508, "TKIND_INTERFACE", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121509, "TKIND_DISPATCH", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121510, "TKIND_COCLASS", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121511, "TKIND_ALIAS", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x06, 0x00, 0x00, 0x00]), "System.Int32",
                "06000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121512, "TKIND_UNION", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x07, 0x00, 0x00, 0x00]), "System.Int32",
                "07000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", 67121513, "TKIND_MAX", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]), "System.Int32",
                "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 33557137, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], "System.Int16", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121514, "value__", SourceMemberKind.Field, 1542,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121515, "TYPEFLAG_FAPPOBJECT",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00]), "System.Int16", "0100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121516, "TYPEFLAG_FCANCREATE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00]), "System.Int16", "0200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121517, "TYPEFLAG_FLICENSED",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00]), "System.Int16", "0400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121518, "TYPEFLAG_FPREDECLID",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00]), "System.Int16", "0800",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121519, "TYPEFLAG_FHIDDEN",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00]), "System.Int16", "1000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121520, "TYPEFLAG_FCONTROL",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x20, 0x00]), "System.Int16", "2000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121521, "TYPEFLAG_FDUAL", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x40, 0x00]), "System.Int16", "4000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121522, "TYPEFLAG_FNONEXTENSIBLE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", [0x80, 0x00]), "System.Int16", "8000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121523, "TYPEFLAG_FOLEAUTOMATION",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x01]), "System.Int16", "0001",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121524, "TYPEFLAG_FRESTRICTED",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x02]), "System.Int16", "0002",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121525, "TYPEFLAG_FAGGREGATABLE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x04]), "System.Int16", "0004",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121526, "TYPEFLAG_FREPLACEABLE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x08]), "System.Int16", "0008",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121527, "TYPEFLAG_FDISPATCHABLE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x10]), "System.Int16", "0010",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121528, "TYPEFLAG_FREVERSEBIND",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x20]), "System.Int16", "0020",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", 67121529, "TYPEFLAG_FPROXY",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x40]), "System.Int16", "0040",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", 33557138, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", 67121530, "value__", SourceMemberKind.Field,
                1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", 67121531, "IMPLTYPEFLAG_FDEFAULT",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", 67121532, "IMPLTYPEFLAG_FSOURCE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", 67121533, "IMPLTYPEFLAG_FRESTRICTED",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", 67121534, "IMPLTYPEFLAG_FDEFAULTVTABLE",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]), "System.Int32",
                "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 33557139, 1114377,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121535, "MEMBER_ID_NIL", SourceMemberKind.Field,
                32854, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xFF, 0xFF, 0xFF, 0xFF]), "System.Int32",
                "FFFFFFFF", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121536, "guid", SourceMemberKind.Field, 6,
                "System.Guid", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121537, "lcid", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121538, "dwReserved", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121539, "memidConstructor",
                SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121540, "memidDestructor", SourceMemberKind.Field,
                6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121541, "lpstrSchema", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121542, "cbSizeInstance", SourceMemberKind.Field,
                6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121543, "typekind", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ComTypes.TYPEKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121544, "cFuncs", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121545, "cVars", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121546, "cImplTypes", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121547, "cbSizeVft", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121548, "cbAlignment", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121549, "wTypeFlags", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ComTypes.TYPEFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121550, "wMajorVerNum", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121551, "wMinorVerNum", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121552, "tdescAlias", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ComTypes.TYPEDESC", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.TYPEATTR", 67121553, "idldescType", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.ComTypes.IDLDESC", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.FUNCDESC", 33557140, 1048841,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.FUNCDESC", 67121554, "memid", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComTypes.FUNCDESC", 67121555, "lprgscode", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
