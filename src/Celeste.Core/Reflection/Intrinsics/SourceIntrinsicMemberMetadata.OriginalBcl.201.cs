using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl201(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.IDLFLAG", 67121221, "IDLFLAG_FRETVAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.IDLFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x08, 0x00 }), "System.Int16", "0800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.IDLDESC", 33556993, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x69, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x49,
                        0x44, 0x4C, 0x44, 0x45, 0x53, 0x43, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E, 0x20,
                        0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F, 0x73,
                        0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F, 0x3F,
                        0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.IDLDESC", 67121222, "dwReserved", SourceMemberKind.Field, 6, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.IDLDESC", 67121223, "wIDLFlags", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.IDLFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 33556994, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6B, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x50,
                        0x41, 0x52, 0x41, 0x4D, 0x46, 0x4C, 0x41, 0x47, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64,
                        0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72,
                        0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B,
                        0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00,
                        0x00
                    }),
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, "System.Int16", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121224, "value__", SourceMemberKind.Field, 1542,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121225, "PARAMFLAG_NONE", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x00 }), "System.Int16", "0000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121226, "PARAMFLAG_FIN", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x01, 0x00 }), "System.Int16", "0100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121227, "PARAMFLAG_FOUT", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x02, 0x00 }), "System.Int16", "0200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121228, "PARAMFLAG_FLCID", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x04, 0x00 }), "System.Int16", "0400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121229, "PARAMFLAG_FRETVAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x08, 0x00 }), "System.Int16", "0800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121230, "PARAMFLAG_FOPT", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x10, 0x00 }), "System.Int16", "1000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121231, "PARAMFLAG_FHASDEFAULT", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x20, 0x00 }), "System.Int16", "2000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMFLAG", 67121232, "PARAMFLAG_FHASCUSTDATA", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x40, 0x00 }), "System.Int16", "4000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMDESC", 33556995, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6B, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x50,
                        0x41, 0x52, 0x41, 0x4D, 0x44, 0x45, 0x53, 0x43, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64,
                        0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72,
                        0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B,
                        0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00,
                        0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMDESC", 67121233, "lpVarValue", SourceMemberKind.Field, 6,
            "System.IntPtr", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.PARAMDESC", 67121234, "wParamFlags", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.PARAMFLAG", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.TYPEDESC", 33556996, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x54,
                        0x59, 0x50, 0x45, 0x44, 0x45, 0x53, 0x43, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E,
                        0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F,
                        0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F,
                        0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.TYPEDESC", 67121235, "lpValue", SourceMemberKind.Field, 6, "System.IntPtr",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.TYPEDESC", 67121236, "vt", SourceMemberKind.Field, 6, "System.Int16", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ELEMDESC", 33556997, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x45,
                        0x4C, 0x45, 0x4D, 0x44, 0x45, 0x53, 0x43, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E,
                        0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F,
                        0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F,
                        0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ELEMDESC", 67121237, "tdesc", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.TYPEDESC", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ELEMDESC", 67121238, "desc", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.ELEMDESC+DESCUNION", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ELEMDESC+DESCUNION", 33556998, 1114386,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ELEMDESC+DESCUNION", 67121239, "idldesc", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.IDLDESC", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ELEMDESC+DESCUNION", 67121240, "paramdesc", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.PARAMDESC", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC", 33556999, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x69, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x56,
                        0x41, 0x52, 0x44, 0x45, 0x53, 0x43, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E, 0x20,
                        0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F, 0x73,
                        0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F, 0x3F,
                        0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC", 67121241, "memid", SourceMemberKind.Field, 6, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC", 67121242, "lpstrSchema", SourceMemberKind.Field, 6,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC", 67121243, "elemdescVar", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.ELEMDESC", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC", 67121244, "wVarFlags", SourceMemberKind.Field, 6, "System.Int16",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC", 67121245, "varkind", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.VarEnum", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC+DESCUNION", 33557000, 1114386,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC+DESCUNION", 67121246, "oInst", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARDESC+DESCUNION", 67121247, "lpvarValue", SourceMemberKind.Field, 6,
            "System.IntPtr", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.DISPPARAMS", 33557001, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6C, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x44,
                        0x49, 0x53, 0x50, 0x50, 0x41, 0x52, 0x41, 0x4D, 0x53, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61,
                        0x64, 0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63,
                        0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E,
                        0x6B, 0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00,
                        0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.DISPPARAMS", 67121248, "rgvarg", SourceMemberKind.Field, 6, "System.IntPtr",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.DISPPARAMS", 67121249, "rgdispidNamedArgs", SourceMemberKind.Field, 6,
            "System.IntPtr", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.DISPPARAMS", 67121250, "cArgs", SourceMemberKind.Field, 6, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.DISPPARAMS", 67121251, "cNamedArgs", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 33557002, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6B, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x45,
                        0x58, 0x43, 0x45, 0x50, 0x49, 0x4E, 0x46, 0x4F, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64,
                        0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72,
                        0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B,
                        0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00,
                        0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121252, "wCode", SourceMemberKind.Field, 6, "System.Int16",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121253, "wReserved", SourceMemberKind.Field, 6,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121254, "bstrSource", SourceMemberKind.Field, 4102,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121255, "bstrDescription", SourceMemberKind.Field, 4102,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121256, "bstrHelpFile", SourceMemberKind.Field, 4102,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121257, "dwHelpContext", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121258, "pvReserved", SourceMemberKind.Field, 6,
            "System.IntPtr", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.EXCEPINFO", 67121259, "pfnDeferredFillIn", SourceMemberKind.Field, 6,
            "System.IntPtr", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCKIND", 33557003, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x46,
                        0x55, 0x4E, 0x43, 0x4B, 0x49, 0x4E, 0x44, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E,
                        0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F,
                        0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F,
                        0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00
                    })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCKIND", 67121260, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCKIND", 67121261, "FUNC_VIRTUAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCKIND", 67121262, "FUNC_PUREVIRTUAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCKIND", 67121263, "FUNC_NONVIRTUAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCKIND", 67121264, "FUNC_STATIC", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCKIND", 67121265, "FUNC_DISPATCH", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.INVOKEKIND", 33557004, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6C, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x49,
                        0x4E, 0x56, 0x4F, 0x4B, 0x45, 0x4B, 0x49, 0x4E, 0x44, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61,
                        0x64, 0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63,
                        0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E,
                        0x6B, 0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00,
                        0x00, 0x00
                    })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.INVOKEKIND", 67121266, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.INVOKEKIND", 67121267, "INVOKE_FUNC", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.INVOKEKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.INVOKEKIND", 67121268, "INVOKE_PROPERTYGET", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.INVOKEKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.INVOKEKIND", 67121269, "INVOKE_PROPERTYPUT", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.INVOKEKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.INVOKEKIND", 67121270, "INVOKE_PROPERTYPUTREF", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.INVOKEKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 33557005, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x43,
                        0x41, 0x4C, 0x4C, 0x43, 0x4F, 0x4E, 0x56, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E,
                        0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F,
                        0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F,
                        0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00
                    })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121271, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121272, "CC_CDECL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121273, "CC_MSCPASCAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121274, "CC_PASCAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121275, "CC_MACPASCAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121276, "CC_STDCALL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121277, "CC_RESERVED", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x05, 0x00, 0x00, 0x00 }), "System.Int32",
            "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121278, "CC_SYSCALL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x06, 0x00, 0x00, 0x00 }), "System.Int32",
            "06000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121279, "CC_MPWCDECL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x07, 0x00, 0x00, 0x00 }), "System.Int32",
            "07000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121280, "CC_MPWPASCAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.CALLCONV", 67121281, "CC_MAX", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x09, 0x00, 0x00, 0x00 }), "System.Int32",
            "09000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 33557006, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6B, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x46,
                        0x55, 0x4E, 0x43, 0x46, 0x4C, 0x41, 0x47, 0x53, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64,
                        0x2E, 0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72,
                        0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B,
                        0x2F, 0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00,
                        0x00
                    })
            }, "System.Int16", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121282, "value__", SourceMemberKind.Field, 1542,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121283, "FUNCFLAG_FRESTRICTED", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x01, 0x00 }), "System.Int16", "0100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121284, "FUNCFLAG_FSOURCE", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x02, 0x00 }), "System.Int16", "0200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121285, "FUNCFLAG_FBINDABLE", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x04, 0x00 }), "System.Int16", "0400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121286, "FUNCFLAG_FREQUESTEDIT", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x08, 0x00 }), "System.Int16", "0800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121287, "FUNCFLAG_FDISPLAYBIND", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x10, 0x00 }), "System.Int16", "1000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121288, "FUNCFLAG_FDEFAULTBIND", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x20, 0x00 }), "System.Int16", "2000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121289, "FUNCFLAG_FHIDDEN", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x40, 0x00 }), "System.Int16", "4000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121290, "FUNCFLAG_FUSESGETLASTERROR", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x80, 0x00 }), "System.Int16", "8000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121291, "FUNCFLAG_FDEFAULTCOLLELEM", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x01 }), "System.Int16", "0001",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121292, "FUNCFLAG_FUIDEFAULT", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x02 }), "System.Int16", "0002",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121293, "FUNCFLAG_FNONBROWSABLE", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x04 }), "System.Int16", "0004",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121294, "FUNCFLAG_FREPLACEABLE", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x08 }), "System.Int16", "0008",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FUNCFLAGS", 67121295, "FUNCFLAG_FIMMEDIATEBIND", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.FUNCFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x10 }), "System.Int16", "0010",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARFLAGS", 33557007, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6A, 0x55, 0x73, 0x65, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75,
                        0x6E, 0x74, 0x69, 0x6D, 0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72,
                        0x76, 0x69, 0x63, 0x65, 0x73, 0x2E, 0x43, 0x6F, 0x6D, 0x54, 0x79, 0x70, 0x65, 0x73, 0x2E, 0x56,
                        0x41, 0x52, 0x46, 0x4C, 0x41, 0x47, 0x53, 0x20, 0x69, 0x6E, 0x73, 0x74, 0x65, 0x61, 0x64, 0x2E,
                        0x20, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x67, 0x6F, 0x2E, 0x6D, 0x69, 0x63, 0x72, 0x6F,
                        0x73, 0x6F, 0x66, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x66, 0x77, 0x6C, 0x69, 0x6E, 0x6B, 0x2F,
                        0x3F, 0x6C, 0x69, 0x6E, 0x6B, 0x69, 0x64, 0x3D, 0x31, 0x34, 0x32, 0x30, 0x32, 0x00, 0x00, 0x00
                    })
            }, "System.Int16", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARFLAGS", 67121296, "value__", SourceMemberKind.Field, 1542,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARFLAGS", 67121297, "VARFLAG_FREADONLY", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x01, 0x00 }), "System.Int16", "0100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARFLAGS", 67121298, "VARFLAG_FSOURCE", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x02, 0x00 }), "System.Int16", "0200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARFLAGS", 67121299, "VARFLAG_FBINDABLE", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x04, 0x00 }), "System.Int16", "0400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARFLAGS", 67121300, "VARFLAG_FREQUESTEDIT", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x08, 0x00 }), "System.Int16", "0800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.VARFLAGS", 67121301, "VARFLAG_FDISPLAYBIND", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.VARFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x10, 0x00 }), "System.Int16", "1000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
