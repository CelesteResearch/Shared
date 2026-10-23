using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl199(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComEventInterfaceAttribute", 67121096, "_SourceInterface",
                SourceMemberKind.Field, 3, "System.Type", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComEventInterfaceAttribute", 67121097, "_EventProvider",
                SourceMemberKind.Field, 3, "System.Type", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComEventInterfaceAttribute", 385880325, "SourceInterface",
                SourceMemberKind.Property, 0, "System.Type", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComEventInterfaceAttribute", 385880326, "EventProvider",
                SourceMemberKind.Property, 0, "System.Type", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibVersionAttribute", 33556950, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibVersionAttribute", 67121098, "_major", SourceMemberKind.Field, 3,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibVersionAttribute", 67121099, "_minor", SourceMemberKind.Field, 3,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibVersionAttribute", 385880327, "MajorVersion",
                SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.TypeLibVersionAttribute", 385880328, "MinorVersion",
                SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 33556951, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 67121100, "_major",
                SourceMemberKind.Field,
                3, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 67121101, "_minor",
                SourceMemberKind.Field,
                3, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 67121102, "_build",
                SourceMemberKind.Field,
                3, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 67121103, "_revision",
                SourceMemberKind.Field, 3, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 385880329, "MajorVersion",
                SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 385880330, "MinorVersion",
                SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 385880331, "BuildNumber",
                SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComCompatibleVersionAttribute", 385880332, "RevisionNumber",
                SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BestFitMappingAttribute", 33556952, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x0D, 0x04, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BestFitMappingAttribute", 67121104, "_bestFitMapping",
                SourceMemberKind.Field, 3, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BestFitMappingAttribute", 67121105, "ThrowOnUnmappableChar",
                SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BestFitMappingAttribute", 385880333, "BestFitMapping",
                SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DefaultCharSetAttribute", 33556953, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x02, 0x00, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DefaultCharSetAttribute", 67121106, "_CharSet", SourceMemberKind.Field,
                3,
                "System.Runtime.InteropServices.CharSet", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DefaultCharSetAttribute", 385880334, "CharSet",
                SourceMemberKind.Property,
                0, "System.Runtime.InteropServices.CharSet", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.SetWin32ContextInIDispatchAttribute", 33556954, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x7C, 0x54, 0x68, 0x69, 0x73, 0x20, 0x61, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75,
                            0x74,
                            0x65, 0x20, 0x68, 0x61, 0x73, 0x20, 0x62, 0x65, 0x65, 0x6E, 0x20, 0x64, 0x65, 0x70, 0x72,
                            0x65,
                            0x63, 0x61, 0x74, 0x65, 0x64, 0x2E, 0x20, 0x20, 0x41, 0x70, 0x70, 0x6C, 0x69, 0x63, 0x61,
                            0x74,
                            0x69, 0x6F, 0x6E, 0x20, 0x44, 0x6F, 0x6D, 0x61, 0x69, 0x6E, 0x73, 0x20, 0x6E, 0x6F, 0x20,
                            0x6C,
                            0x6F, 0x6E, 0x67, 0x65, 0x72, 0x20, 0x72, 0x65, 0x73, 0x70, 0x65, 0x63, 0x74, 0x20, 0x41,
                            0x63,
                            0x74, 0x69, 0x76, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x20, 0x43, 0x6F, 0x6E, 0x74, 0x65, 0x78,
                            0x74,
                            0x20, 0x62, 0x6F, 0x75, 0x6E, 0x64, 0x61, 0x72, 0x69, 0x65, 0x73, 0x20, 0x69, 0x6E, 0x20,
                            0x49,
                            0x44, 0x69, 0x73, 0x70, 0x61, 0x74, 0x63, 0x68, 0x20, 0x63, 0x61, 0x6C, 0x6C, 0x73, 0x2E,
                            0x00,
                            0x00, 0x00,
                        ]),
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ManagedToNativeComInteropStubAttribute", 33556955, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x40, 0x00, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77, 0x4D, 0x75,
                            0x6C,
                            0x74, 0x69, 0x70, 0x6C, 0x65, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ManagedToNativeComInteropStubAttribute", 67121107, "_classType",
                SourceMemberKind.Field, 3, "System.Type", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ManagedToNativeComInteropStubAttribute", 67121108, "_methodName",
                SourceMemberKind.Field, 3, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ManagedToNativeComInteropStubAttribute", 385880335, "ClassType",
                SourceMemberKind.Property, 0, "System.Type", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ManagedToNativeComInteropStubAttribute", 385880336, "MethodName",
                SourceMemberKind.Property, 0, "System.String", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BStrWrapper", 33556956, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BStrWrapper", 67121109, "m_WrappedObject", SourceMemberKind.Field, 1,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.BStrWrapper", 385880337, "WrappedObject", SourceMemberKind.Property, 0,
                "System.String", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CallingConvention", 33556957, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CallingConvention", 67121110, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CallingConvention", 67121111, "Winapi", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CallingConvention", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CallingConvention", 67121112, "Cdecl", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CallingConvention", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CallingConvention", 67121113, "StdCall", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CallingConvention", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CallingConvention", 67121114, "ThisCall", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CallingConvention", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CallingConvention", 67121115, "FastCall", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CallingConvention", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CharSet", 33556958, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CharSet", 67121116, "value__", SourceMemberKind.Field, 1542,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CharSet", 67121117, "None", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CharSet", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CharSet", 67121118, "Ansi", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CharSet", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CharSet", 67121119, "Unicode", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CharSet", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CharSet", 67121120, "Auto", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.CharSet", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.COMException", 33556959, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExternalException", [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComMemberType", 33556960, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComMemberType", 67121121, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComMemberType", 67121122, "Method", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.ComMemberType", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComMemberType", 67121123, "PropGet", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.ComMemberType", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ComMemberType", 67121124, "PropSet", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.ComMemberType", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CriticalHandle", 33556961, 1310849,
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
                "System.Runtime.InteropServices.CriticalHandle", 67121125, "handle", SourceMemberKind.Field, 4,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CriticalHandle", 67121126, "_isClosed", SourceMemberKind.Field, 1,
                "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CriticalHandle", 385880338, "IsClosed", SourceMemberKind.Property, 0,
                "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CriticalHandle", 385880339, "IsInvalid", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CurrencyWrapper", 33556962, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CurrencyWrapper", 67121127, "m_WrappedObject", SourceMemberKind.Field,
                1,
                "System.Decimal", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CurrencyWrapper", 385880340, "WrappedObject", SourceMemberKind.Property,
                0,
                "System.Decimal", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DispatchWrapper", 33556963, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DispatchWrapper", 67121128, "m_WrappedObject", SourceMemberKind.Field,
                1,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.DispatchWrapper", 385880341, "WrappedObject", SourceMemberKind.Property,
                0,
                "System.Object", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ErrorWrapper", 33556964, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ErrorWrapper", 67121129, "m_ErrorCode", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ErrorWrapper", 385880342, "ErrorCode", SourceMemberKind.Property, 0,
                "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExternalException", 33556965, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ExternalException", 385880343, "ErrorCode", SourceMemberKind.Property,
                0,
                "System.Int32", 2502, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.HandleRef", 33556966, 1048841,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.HandleRef", 67121130, "m_wrapper", SourceMemberKind.Field, 3,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.HandleRef", 67121131, "m_handle", SourceMemberKind.Field, 3,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.HandleRef", 385880344, "Wrapper", SourceMemberKind.Property, 0,
                "System.Object", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.HandleRef", 385880345, "Handle", SourceMemberKind.Property, 0,
                "System.IntPtr", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ICustomAdapter", 33556967, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ICustomFactory", 33556968, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ICustomMarshaler", 33556969, 161, null, null, [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceResult", 33556970, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceResult", 67121132, "value__",
                SourceMemberKind.Field,
                1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceResult", 67121133, "Handled",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.CustomQueryInterfaceResult", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceResult", 67121134, "NotHandled",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.CustomQueryInterfaceResult", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.CustomQueryInterfaceResult", 67121135, "Failed", SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.CustomQueryInterfaceResult", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.ICustomQueryInterface", 33556971, 161, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.InvalidComObjectException", 33556972, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.InvalidOleVariantTypeException", 33556973, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.AssemblyRegistrationFlags", 33556974, 257,
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
                "System.Runtime.InteropServices.AssemblyRegistrationFlags", 67121136, "value__", SourceMemberKind.Field,
                1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.AssemblyRegistrationFlags", 67121137, "None", SourceMemberKind.Field,
                32854,
                "System.Runtime.InteropServices.AssemblyRegistrationFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.AssemblyRegistrationFlags", 67121138, "SetCodeBase",
                SourceMemberKind.Field,
                32854, "System.Runtime.InteropServices.AssemblyRegistrationFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.IRegistrationServices", 33556975, 161, null, null,
                [],
                [
                    new("System.Runtime.InteropServices.GuidAttribute",
                        "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x24, 0x43, 0x43, 0x42, 0x44, 0x36, 0x38, 0x32, 0x43, 0x2D, 0x37, 0x33, 0x41,
                            0x35,
                            0x2D, 0x34, 0x35, 0x36, 0x38, 0x2D, 0x42, 0x38, 0x42, 0x30, 0x2D, 0x43, 0x37, 0x30, 0x30,
                            0x37,
                            0x45, 0x31, 0x31, 0x41, 0x42, 0x41, 0x32, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.LayoutKind", 33556976, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.LayoutKind", 67121139, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.LayoutKind", 67121140, "Sequential", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.LayoutKind", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.LayoutKind", 67121141, "Explicit", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.LayoutKind", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.LayoutKind", 67121142, "Auto", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.LayoutKind", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.InteropServices.MarshalDirectiveException", 33556977, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
        }
    }
}
