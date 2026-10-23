using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl205(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SYSKIND", 67121406, "value__", SourceMemberKind.Field, 1542,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SYSKIND", 67121407, "SYS_WIN16", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.SYSKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SYSKIND", 67121408, "SYS_WIN32", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.SYSKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SYSKIND", 67121409, "SYS_MAC", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.SYSKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Thread", 33557066, 161, null, null, [],
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
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x17, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x68, 0x72, 0x65, 0x61,
                            0x64,
                            0x69, 0x6E, 0x67, 0x2E, 0x54, 0x68, 0x72, 0x65, 0x61, 0x64, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x43, 0x32, 0x38, 0x31, 0x43, 0x37, 0x46, 0x31, 0x2D, 0x34, 0x41, 0x41,
                            0x39,
                            0x2D, 0x33, 0x35, 0x31, 0x37, 0x2D, 0x39, 0x36, 0x31, 0x41, 0x2D, 0x34, 0x36, 0x33, 0x43,
                            0x46,
                            0x45, 0x44, 0x35, 0x37, 0x45, 0x37, 0x35, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._TypeBuilder", 33557067, 161, null, null, [],
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
                            0x01, 0x00, 0x24, 0x37, 0x45, 0x35, 0x36, 0x37, 0x38, 0x45, 0x45, 0x2D, 0x34, 0x38, 0x42,
                            0x33,
                            0x2D, 0x33, 0x46, 0x38, 0x33, 0x2D, 0x42, 0x30, 0x37, 0x36, 0x2D, 0x43, 0x35, 0x38, 0x35,
                            0x34,
                            0x33, 0x34, 0x39, 0x38, 0x41, 0x35, 0x38, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x22, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x54, 0x79, 0x70, 0x65, 0x42,
                            0x75,
                            0x69, 0x6C, 0x64, 0x65, 0x72, 0x00, 0x00,
                        ]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 33557068, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x42, 0x43, 0x41, 0x38, 0x42, 0x34, 0x34, 0x44, 0x2D, 0x41, 0x41, 0x44,
                            0x36,
                            0x2D, 0x33, 0x41, 0x38, 0x36, 0x2D, 0x38, 0x41, 0x42, 0x37, 0x2D, 0x30, 0x33, 0x33, 0x34,
                            0x39,
                            0x46, 0x34, 0x46, 0x32, 0x44, 0x41, 0x32, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                        "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x0B, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x79, 0x70, 0x65, 0x00,
                            0x00,
                        ]),
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880475, "Assembly", SourceMemberKind.Property, 0,
                "System.Reflection.Assembly", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880476, "AssemblyQualifiedName", SourceMemberKind.Property,
                0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880477, "Attributes", SourceMemberKind.Property, 0,
                "System.Reflection.TypeAttributes", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880478, "BaseType", SourceMemberKind.Property, 0,
                "System.Type",
                3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880479, "DeclaringType", SourceMemberKind.Property, 0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880480, "FullName", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880481, "GUID", SourceMemberKind.Property, 0, "System.Guid",
                3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880482, "HasElementType", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880483, "IsAbstract", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880484, "IsAnsiClass", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880485, "IsArray", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880486, "IsAutoClass", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880487, "IsAutoLayout", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880488, "IsByRef", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880489, "IsClass", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880490, "IsCOMObject", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880491, "IsContextful", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880492, "IsEnum", SourceMemberKind.Property, 0,
                "System.Boolean",
                3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880493, "IsExplicitLayout", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880494, "IsImport", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880495, "IsInterface", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880496, "IsLayoutSequential", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880497, "IsMarshalByRef", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880498, "IsNestedAssembly", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880499, "IsNestedFamANDAssem", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880500, "IsNestedFamily", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880501, "IsNestedFamORAssem", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880502, "IsNestedPrivate", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880503, "IsNestedPublic", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880504, "IsNotPublic", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880505, "IsPointer", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880506, "IsPrimitive", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880507, "IsPublic", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880508, "IsSealed", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880509, "IsSerializable", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880510, "IsSpecialName", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880511, "IsUnicodeClass", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880512, "IsValueType", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880513, "MemberType", SourceMemberKind.Property, 0,
                "System.Reflection.MemberTypes", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880514, "Module", SourceMemberKind.Property, 0,
                "System.Reflection.Module", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880515, "Name", SourceMemberKind.Property, 0,
                "System.String",
                3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880516, "Namespace", SourceMemberKind.Property, 0,
                "System.String", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880517, "ReflectedType", SourceMemberKind.Property, 0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880518, "TypeHandle", SourceMemberKind.Property, 0,
                "System.RuntimeTypeHandle", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880519, "TypeInitializer", SourceMemberKind.Property, 0,
                "System.Reflection.ConstructorInfo", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices._Type", 385880520, "UnderlyingSystemType", SourceMemberKind.Property, 0,
                "System.Type", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPELIBATTR", 33557069, 1122569,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPELIBATTR", 67121410, "guid", SourceMemberKind.Field, 6,
                "System.Guid",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPELIBATTR", 67121411, "lcid", SourceMemberKind.Field, 6,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPELIBATTR", 67121412, "syskind", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.SYSKIND", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPELIBATTR", 67121413, "wMajorVerNum", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPELIBATTR", 67121414, "wMinorVerNum", SourceMemberKind.Field, 6,
                "System.Int16", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TYPELIBATTR", 67121415, "wLibFlags", SourceMemberKind.Field, 6,
                "System.Runtime.InteropServices.LIBFLAGS", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibConverter", 33557070, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.Runtime.InteropServices.ITypeLibConverter"],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x66, 0x31, 0x63, 0x33, 0x62, 0x66, 0x37, 0x39, 0x2D, 0x63, 0x33, 0x65,
                            0x34,
                            0x2D, 0x31, 0x31, 0x64, 0x33, 0x2D, 0x38, 0x38, 0x65, 0x37, 0x2D, 0x30, 0x30, 0x39, 0x30,
                            0x32,
                            0x37, 0x35, 0x34, 0x63, 0x34, 0x33, 0x61, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.ClassInterfaceAttribute",
                        "System.Void System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(System.Runtime.InteropServices.ClassInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 33557071, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 67121416, "value__", SourceMemberKind.Field,
                1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 67121417, "OnlyReferenceRegistered",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibExporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 67121418, "None", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TypeLibExporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]),
                "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 67121419, "CallerResolvedReferences",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibExporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 67121420, "OldNames", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.TypeLibExporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]),
                "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 67121421, "ExportAs32Bit",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TypeLibExporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00, 0x00, 0x00]), "System.Int32",
                "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibExporterFlags", 67121422, "ExportAs64Bit",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TypeLibExporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x20, 0x00, 0x00, 0x00]), "System.Int32",
                "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 33557072, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121423, "value__", SourceMemberKind.Field,
                1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121424, "PrimaryInteropAssembly",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121425, "UnsafeInterfaces",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121426, "SafeArrayAsSystemArray",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121427, "TransformDispRetVals",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]), "System.Int32",
                "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121428, "None", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]),
                "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121429, "PreventClassMembers",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00, 0x00, 0x00]), "System.Int32",
                "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121430, "ImportAsAgnostic",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x08, 0x00, 0x00]), "System.Int32",
                "00080000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121431, "ImportAsItanium",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x04, 0x00, 0x00]), "System.Int32",
                "00040000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121432, "ImportAsX64", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x02, 0x00, 0x00]), "System.Int32",
                "00020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121433, "ImportAsX86", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x01, 0x00, 0x00]), "System.Int32",
                "00010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121434, "ReflectionOnlyLoading",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x10, 0x00, 0x00]), "System.Int32",
                "00100000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121435, "SerializableValueClasses",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x20, 0x00, 0x00, 0x00]), "System.Int32",
                "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibImporterFlags", 67121436, "NoDefineVersionResource",
                SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.TypeLibImporterFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x20, 0x00, 0x00]), "System.Int32",
                "00200000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIBindCtx", 33557073, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x65, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIConnectionPointContainer", 33557074, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x62, 0x31, 0x39, 0x36, 0x62, 0x32, 0x38, 0x34, 0x2D, 0x62, 0x61, 0x62,
                            0x34,
                            0x2D, 0x31, 0x30, 0x31, 0x61, 0x2D, 0x62, 0x36, 0x39, 0x63, 0x2D, 0x30, 0x30, 0x61, 0x61,
                            0x30,
                            0x30, 0x33, 0x34, 0x31, 0x64, 0x30, 0x37, 0x00, 0x00,
                        ]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIConnectionPoint", 33557075, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x62, 0x31, 0x39, 0x36, 0x62, 0x32, 0x38, 0x36, 0x2D, 0x62, 0x61, 0x62,
                            0x34,
                            0x2D, 0x31, 0x30, 0x31, 0x61, 0x2D, 0x62, 0x36, 0x39, 0x63, 0x2D, 0x30, 0x30, 0x61, 0x61,
                            0x30,
                            0x30, 0x33, 0x34, 0x31, 0x64, 0x30, 0x37, 0x00, 0x00,
                        ]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIEnumConnectionPoints", 33557076, 4257, null, null,
                [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x62, 0x31, 0x39, 0x36, 0x62, 0x32, 0x38, 0x35, 0x2D, 0x62, 0x61, 0x62,
                            0x34,
                            0x2D, 0x31, 0x30, 0x31, 0x61, 0x2D, 0x62, 0x36, 0x39, 0x63, 0x2D, 0x30, 0x30, 0x61, 0x61,
                            0x30,
                            0x30, 0x33, 0x34, 0x31, 0x64, 0x30, 0x37, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIEnumMoniker", 33557077, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x32, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIEnumString", 33557078, 4257, null, null, [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
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
                "System.Runtime.InteropServices.UCOMIEnumVARIANT", 33557079, 4257, null, null, [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x34, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIMoniker", 33557080, 4257, null, null, [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x66, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
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
                "System.Runtime.InteropServices.UCOMIPersistFile", 33557081, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x62, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIRunningObjectTable", 33557082, 4257, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMIStream", 33557083, 4257, null, null, [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x63, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.UCOMITypeComp", 33557084, 4257, null, null, [],
                [
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x33, 0x2D, 0x30, 0x30, 0x30,
                            0x30,
                            0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30,
                            0x30,
                            0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.InterfaceTypeAttribute",
                        "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
        }
    }
}
