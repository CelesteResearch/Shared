using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl202(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121302, "VARFLAG_FDEFAULTBIND", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x20, 0x00]), "System.Int16", "2000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121303, "VARFLAG_FHIDDEN", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x40, 0x00]), "System.Int16", "4000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121304, "VARFLAG_FRESTRICTED", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", [0x80, 0x00]), "System.Int16", "8000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121305, "VARFLAG_FDEFAULTCOLLELEM", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x01]), "System.Int16", "0001",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121306, "VARFLAG_FUIDEFAULT", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x02]), "System.Int16", "0002",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121307, "VARFLAG_FNONBROWSABLE", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x04]), "System.Int16", "0004",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121308, "VARFLAG_FREPLACEABLE", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x08]), "System.Int16", "0008",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VARFLAGS", 67121309, "VARFLAG_FIMMEDIATEBIND", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int16", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x10]), "System.Int16", "0010",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMITypeInfo", 33557008, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x31, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6B, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52,
                            0x75,
                            0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65,
                            0x72,
                            0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E,
                            0x49,
                            0x54, 0x79, 0x70, 0x65, 0x49, 0x6E, 0x66, 0x6F, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61,
                            0x64,
                            0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63,
                            0x72,
                            0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E,
                            0x6B,
                            0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00,
                            0x00,
                            0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UnknownWrapper", 33557009, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UnknownWrapper", 67121310, "m_WrappedObject", SourceMemberKind.Field, 1,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UnknownWrapper", 385880349, "WrappedObject", SourceMemberKind.Property,
                0,
                "System.Object", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VariantWrapper", 33557010, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VariantWrapper", 67121311, "m_WrappedObject", SourceMemberKind.Field, 1,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.VariantWrapper", 385880350, "WrappedObject", SourceMemberKind.Property,
                0,
                "System.Object", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Activator", 33557011, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x10, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x41, 0x63, 0x74, 0x69, 0x76,
                            0x61,
                            0x74, 0x6F, 0x72, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x33, 0x39, 0x37, 0x33, 0x35, 0x35, 0x31, 0x2D, 0x35, 0x37, 0x41,
                            0x31,
                            0x2D, 0x33, 0x39, 0x30, 0x30, 0x2D, 0x41, 0x32, 0x42, 0x35, 0x2D, 0x39, 0x30, 0x38, 0x33,
                            0x45,
                            0x33, 0x46, 0x46, 0x32, 0x39, 0x34, 0x33, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._AssemblyBuilder", 33557012, 161, null, null, [],
                [
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x26, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x41, 0x73, 0x73, 0x65, 0x6D,
                            0x62,
                            0x6C, 0x79, 0x42, 0x75, 0x69, 0x6C, 0x64, 0x65, 0x72, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x42, 0x45, 0x42, 0x42, 0x32, 0x35, 0x30, 0x35, 0x2D, 0x38, 0x42, 0x35,
                            0x34,
                            0x2D, 0x33, 0x34, 0x34, 0x33, 0x2D, 0x41, 0x45, 0x41, 0x44, 0x2D, 0x31, 0x34, 0x32, 0x41,
                            0x31,
                            0x36, 0x44, 0x44, 0x39, 0x43, 0x43, 0x37, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 33557013, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1A, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x41, 0x73, 0x73, 0x65, 0x6D, 0x62, 0x6C, 0x79, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x31, 0x37, 0x31, 0x35, 0x36, 0x33, 0x36, 0x30, 0x2D, 0x32, 0x46, 0x31,
                            0x41,
                            0x2D, 0x33, 0x38, 0x34, 0x41, 0x2D, 0x42, 0x43, 0x35, 0x32, 0x2D, 0x46, 0x44, 0x45, 0x39,
                            0x33,
                            0x43, 0x32, 0x31, 0x35, 0x43, 0x35, 0x42, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 385880351, "CodeBase", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 385880352, "EscapedCodeBase", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 385880353, "FullName", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 385880354, "EntryPoint", SourceMemberKind.Property, 0,
                "System.Reflection.MethodInfo", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 385880355, "Location", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 385880356, "Evidence", SourceMemberKind.Property, 0,
                "System.Security.Policy.Evidence", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Assembly", 385880357, "GlobalAssemblyCache", SourceMemberKind.Property,
                0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._AssemblyName", 33557014, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x41, 0x73, 0x73, 0x65, 0x6D, 0x62, 0x6C, 0x79, 0x4E, 0x61,
                            0x6D,
                            0x65, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x42, 0x34, 0x32, 0x42, 0x36, 0x41, 0x41, 0x43, 0x2D, 0x33, 0x31, 0x37,
                            0x45,
                            0x2D, 0x33, 0x34, 0x44, 0x35, 0x2D, 0x39, 0x46, 0x41, 0x39, 0x2D, 0x30, 0x39, 0x33, 0x42,
                            0x42,
                            0x34, 0x31, 0x36, 0x30, 0x43, 0x35, 0x30, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Attribute", 33557015, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x39, 0x31, 0x37, 0x42, 0x31, 0x34, 0x44, 0x30, 0x2D, 0x32, 0x44, 0x39,
                            0x45,
                            0x2D, 0x33, 0x38, 0x42, 0x38, 0x2D, 0x39, 0x32, 0x41, 0x39, 0x2D, 0x33, 0x38, 0x31, 0x41,
                            0x43,
                            0x46, 0x35, 0x32, 0x46, 0x37, 0x43, 0x30, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x10, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x41, 0x74, 0x74, 0x72, 0x69,
                            0x62,
                            0x75, 0x74, 0x65, 0x00, 0x00,
                        ]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BIND_OPTS", 33557016, 1048841,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BIND_OPTS", 67121312, "cbStruct", SourceMemberKind.Field, 6,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BIND_OPTS", 67121313, "grfFlags", SourceMemberKind.Field, 6,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BIND_OPTS", 67121314, "grfMode", SourceMemberKind.Field, 6,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BIND_OPTS", 67121315, "dwTickCountDeadline", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BINDPTR", 33557017, 1114385,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BINDPTR", 67121316, "lpfuncdesc", SourceMemberKind.Field, 6,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BINDPTR", 67121317, "lptcomp", SourceMemberKind.Field, 6,
                "System.IntPtr",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BINDPTR", 67121318, "lpvardesc", SourceMemberKind.Field, 6,
                "System.IntPtr",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComEventsHelper", 33557018, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorBuilder", 33557019, 161, null, null, [],
                [
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x45, 0x44, 0x33, 0x45, 0x34, 0x33, 0x38, 0x34, 0x2D, 0x44, 0x37, 0x45,
                            0x32,
                            0x2D, 0x33, 0x46, 0x41, 0x37, 0x2D, 0x38, 0x46, 0x46, 0x44, 0x2D, 0x38, 0x39, 0x34, 0x30,
                            0x44,
                            0x33, 0x33, 0x30, 0x35, 0x31, 0x39, 0x41, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x29, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x43, 0x6F, 0x6E, 0x73, 0x74,
                            0x72,
                            0x75, 0x63, 0x74, 0x6F, 0x72, 0x42, 0x75, 0x69, 0x6C, 0x64, 0x65, 0x72, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 33557020, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x21, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x43, 0x6F, 0x6E, 0x73, 0x74, 0x72, 0x75, 0x63, 0x74, 0x6F,
                            0x72,
                            0x49, 0x6E, 0x66, 0x6F, 0x00, 0x00,
                        ]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x45, 0x39, 0x41, 0x31, 0x39, 0x34, 0x37, 0x38, 0x2D, 0x39, 0x36, 0x34,
                            0x36,
                            0x2D, 0x33, 0x36, 0x37, 0x39, 0x2D, 0x39, 0x42, 0x31, 0x30, 0x2D, 0x38, 0x34, 0x31, 0x31,
                            0x41,
                            0x45, 0x31, 0x46, 0x44, 0x35, 0x37, 0x44, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880358, "Attributes", SourceMemberKind.Property,
                0,
                "System.Reflection.MethodAttributes", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880359, "CallingConvention",
                SourceMemberKind.Property, 0, "System.Reflection.CallingConventions", 3526, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880360, "DeclaringType",
                SourceMemberKind.Property, 0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880361, "IsAbstract", SourceMemberKind.Property,
                0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880362, "IsAssembly", SourceMemberKind.Property,
                0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880363, "IsConstructor",
                SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880364, "IsFamily", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880365, "IsFamilyAndAssembly",
                SourceMemberKind.Property, 0, "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880366, "IsFamilyOrAssembly",
                SourceMemberKind.Property, 0, "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880367, "IsFinal", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880368, "IsHideBySig", SourceMemberKind.Property,
                0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880369, "IsPrivate", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880370, "IsPublic", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880371, "IsSpecialName",
                SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880372, "IsStatic", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880373, "IsVirtual", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880374, "MemberType", SourceMemberKind.Property,
                0,
                "System.Reflection.MemberTypes", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880375, "MethodHandle", SourceMemberKind.Property,
                0,
                "System.RuntimeMethodHandle", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880376, "Name", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._ConstructorInfo", 385880377, "ReflectedType",
                SourceMemberKind.Property, 0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._CustomAttributeBuilder", 33557021, 161, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x42, 0x45, 0x39, 0x41, 0x43, 0x43, 0x45, 0x38, 0x2D, 0x41, 0x41, 0x46,
                            0x46,
                            0x2D, 0x33, 0x42, 0x39, 0x31, 0x2D, 0x38, 0x31, 0x41, 0x45, 0x2D, 0x38, 0x32, 0x31, 0x31,
                            0x36,
                            0x36, 0x33, 0x46, 0x35, 0x43, 0x41, 0x44, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x2D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x43, 0x75, 0x73, 0x74, 0x6F,
                            0x6D,
                            0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0x42, 0x75, 0x69, 0x6C, 0x64, 0x65,
                            0x72,
                            0x00, 0x00,
                        ]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceMode", 33557022, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceMode", 67121319, "value__", SourceMemberKind.Field,
                1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceMode", 67121320, "Allow", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.CustomQueryInterfaceMode", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceMode", 67121321, "Ignore", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.CustomQueryInterfaceMode", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 33557023, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 67121322, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 67121323, "DESCKIND_NONE", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.DESCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 67121324, "DESCKIND_FUNCDESC", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.DESCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 67121325, "DESCKIND_VARDESC", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.DESCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 67121326, "DESCKIND_TYPECOMP", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.DESCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 67121327, "DESCKIND_IMPLICITAPPOBJ", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.DESCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DESCKIND", 67121328, "DESCKIND_MAX", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.DESCKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EnumBuilder", 33557024, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x43, 0x37, 0x42, 0x44, 0x37, 0x33, 0x44, 0x45, 0x2D, 0x39, 0x46, 0x38,
                            0x35,
                            0x2D, 0x33, 0x32, 0x39, 0x30, 0x2D, 0x38, 0x38, 0x45, 0x45, 0x2D, 0x30, 0x39, 0x30, 0x42,
                            0x38,
                            0x42, 0x44, 0x46, 0x45, 0x32, 0x44, 0x46, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x22, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x45, 0x6E, 0x75, 0x6D, 0x42,
                            0x75,
                            0x69, 0x6C, 0x64, 0x65, 0x72, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventBuilder", 33557025, 161, null, null, [],
                [
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x41, 0x41, 0x44, 0x41, 0x42, 0x41, 0x39, 0x39, 0x2D, 0x38, 0x39, 0x35,
                            0x44,
                            0x2D, 0x33, 0x44, 0x36, 0x35, 0x2D, 0x39, 0x37, 0x36, 0x30, 0x2D, 0x42, 0x31, 0x46, 0x31,
                            0x32,
                            0x36, 0x32, 0x31, 0x46, 0x41, 0x45, 0x38, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x23, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x45, 0x76, 0x65, 0x6E, 0x74,
                            0x42,
                            0x75, 0x69, 0x6C, 0x64, 0x65, 0x72, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 33557026, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x39, 0x44, 0x45, 0x35, 0x39, 0x43, 0x36, 0x34, 0x2D, 0x44, 0x38, 0x38,
                            0x39,
                            0x2D, 0x33, 0x35, 0x41, 0x31, 0x2D, 0x42, 0x38, 0x39, 0x37, 0x2D, 0x35, 0x38, 0x37, 0x44,
                            0x37,
                            0x34, 0x34, 0x36, 0x39, 0x45, 0x35, 0x42, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1B, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x76, 0x65, 0x6E, 0x74, 0x49, 0x6E, 0x66, 0x6F, 0x00,
                            0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880378, "Attributes", SourceMemberKind.Property, 0,
                "System.Reflection.EventAttributes", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880379, "DeclaringType", SourceMemberKind.Property, 0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880380, "EventHandlerType", SourceMemberKind.Property,
                0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880381, "IsMulticast", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880382, "IsSpecialName", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880383, "MemberType", SourceMemberKind.Property, 0,
                "System.Reflection.MemberTypes", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880384, "Name", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._EventInfo", 385880385, "ReflectedType", SourceMemberKind.Property, 0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Exception", 33557027, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x62, 0x33, 0x36, 0x62, 0x35, 0x63, 0x36, 0x33, 0x2D, 0x34, 0x32, 0x65,
                            0x66,
                            0x2D, 0x33, 0x38, 0x62, 0x63, 0x2D, 0x61, 0x30, 0x37, 0x65, 0x2D, 0x30, 0x62, 0x33, 0x34,
                            0x63,
                            0x39, 0x38, 0x66, 0x31, 0x36, 0x34, 0x61, 0x00, 0x00,
                        ]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Exception", 385880386, "HelpLink", SourceMemberKind.Property, 0,
                "System.String", 3526, 3526, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Exception", 385880387, "InnerException", SourceMemberKind.Property, 0,
                "System.Exception", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Exception", 385880388, "Message", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Exception", 385880389, "Source", SourceMemberKind.Property, 0,
                "System.String", 3526, 3526, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Exception", 385880390, "StackTrace", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Exception", 385880391, "TargetSite", SourceMemberKind.Property, 0,
                "System.Reflection.MethodBase", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExporterEventKind", 33557028, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExporterEventKind", 67121329, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExporterEventKind", 67121330, "NOTIF_TYPECONVERTED",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.ExporterEventKind", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExporterEventKind", 67121331, "NOTIF_CONVERTWARNING",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ExporterEventKind", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExporterEventKind", 67121332, "ERROR_REFTOINVALIDASSEMBLY",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ExporterEventKind", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExtensibleClassFactory", 33557029, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
        }
    }
}
