using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl209(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.CALLCONV", 67121637, "CC_MPWPASCAL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.ComTypes.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.CALLCONV", 67121638, "CC_MAX", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.ComTypes.CALLCONV", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x09, 0x00, 0x00, 0x00 }), "System.Int32",
            "09000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 33557156, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, "System.Int16", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121639, "value__", SourceMemberKind.Field, 1542,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121640, "FUNCFLAG_FRESTRICTED",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x01, 0x00 }), "System.Int16", "0100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121641, "FUNCFLAG_FSOURCE", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x02, 0x00 }), "System.Int16", "0200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121642, "FUNCFLAG_FBINDABLE", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x04, 0x00 }), "System.Int16", "0400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121643, "FUNCFLAG_FREQUESTEDIT",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x08, 0x00 }), "System.Int16", "0800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121644, "FUNCFLAG_FDISPLAYBIND",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x10, 0x00 }), "System.Int16", "1000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121645, "FUNCFLAG_FDEFAULTBIND",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x20, 0x00 }), "System.Int16", "2000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121646, "FUNCFLAG_FHIDDEN", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x40, 0x00 }), "System.Int16", "4000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121647, "FUNCFLAG_FUSESGETLASTERROR",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x80, 0x00 }), "System.Int16", "8000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121648, "FUNCFLAG_FDEFAULTCOLLELEM",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x01 }), "System.Int16", "0001",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121649, "FUNCFLAG_FUIDEFAULT",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x02 }), "System.Int16", "0002",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121650, "FUNCFLAG_FNONBROWSABLE",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x04 }), "System.Int16", "0004",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121651, "FUNCFLAG_FREPLACEABLE",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x08 }), "System.Int16", "0008",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", 67121652, "FUNCFLAG_FIMMEDIATEBIND",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.FUNCFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x10 }), "System.Int16", "0010",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 33557157, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, "System.Int16", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121653, "value__", SourceMemberKind.Field, 1542,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121654, "VARFLAG_FREADONLY", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x01, 0x00 }), "System.Int16", "0100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121655, "VARFLAG_FSOURCE", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x02, 0x00 }), "System.Int16", "0200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121656, "VARFLAG_FBINDABLE", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x04, 0x00 }), "System.Int16", "0400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121657, "VARFLAG_FREQUESTEDIT",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x08, 0x00 }), "System.Int16", "0800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121658, "VARFLAG_FDISPLAYBIND",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x10, 0x00 }), "System.Int16", "1000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121659, "VARFLAG_FDEFAULTBIND",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x20, 0x00 }), "System.Int16", "2000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121660, "VARFLAG_FHIDDEN", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x40, 0x00 }), "System.Int16", "4000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121661, "VARFLAG_FRESTRICTED", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x80, 0x00 }), "System.Int16", "8000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121662, "VARFLAG_FDEFAULTCOLLELEM",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x01 }), "System.Int16", "0001",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121663, "VARFLAG_FUIDEFAULT", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x02 }), "System.Int16", "0002",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121664, "VARFLAG_FNONBROWSABLE",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x04 }), "System.Int16", "0004",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121665, "VARFLAG_FREPLACEABLE",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x08 }), "System.Int16", "0008",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.VARFLAGS", 67121666, "VARFLAG_FIMMEDIATEBIND",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.VARFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x00, 0x10 }), "System.Int16", "0010",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.ITypeInfo", 33557158, 4257, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x31, 0x2D, 0x30, 0x30, 0x30, 0x30,
                        0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30, 0x30,
                        0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.ITypeLib2", 33557159, 4257, null, null,
            new string[] { "System.Runtime.InteropServices.ComTypes.ITypeLib" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x31, 0x31, 0x2D, 0x30, 0x30, 0x30, 0x30,
                        0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30, 0x30,
                        0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.SYSKIND", 33557160, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.SYSKIND", 67121667, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.SYSKIND", 67121668, "SYS_WIN16", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.ComTypes.SYSKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.SYSKIND", 67121669, "SYS_WIN32", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.ComTypes.SYSKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.SYSKIND", 67121670, "SYS_MAC", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.ComTypes.SYSKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.SYSKIND", 67121671, "SYS_WIN64", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.ComTypes.SYSKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.LIBFLAGS", 33557161, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, "System.Int16", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.LIBFLAGS", 67121672, "value__", SourceMemberKind.Field, 1542,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.LIBFLAGS", 67121673, "LIBFLAG_FRESTRICTED", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.LIBFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x01, 0x00 }), "System.Int16", "0100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.LIBFLAGS", 67121674, "LIBFLAG_FCONTROL", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.LIBFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x02, 0x00 }), "System.Int16", "0200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.LIBFLAGS", 67121675, "LIBFLAG_FHIDDEN", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ComTypes.LIBFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x04, 0x00 }), "System.Int16", "0400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.LIBFLAGS", 67121676, "LIBFLAG_FHASDISKIMAGE",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ComTypes.LIBFLAGS", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int16", new byte[] { 0x08, 0x00 }), "System.Int16", "0800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.TYPELIBATTR", 33557162, 1122569,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.TYPELIBATTR", 67121677, "guid", SourceMemberKind.Field, 6,
            "System.Guid", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.TYPELIBATTR", 67121678, "lcid", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.TYPELIBATTR", 67121679, "syskind", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.ComTypes.SYSKIND", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.TYPELIBATTR", 67121680, "wMajorVerNum", SourceMemberKind.Field, 6,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.TYPELIBATTR", 67121681, "wMinorVerNum", SourceMemberKind.Field, 6,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.TYPELIBATTR", 67121682, "wLibFlags", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.ComTypes.LIBFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.ITypeLib", 33557163, 4257, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x32, 0x2D, 0x30, 0x30, 0x30, 0x30,
                        0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30, 0x30,
                        0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 33557164, 256,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121683, "0392525BCB01691D1F319D89F2C12BF93A478467",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=256", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121684, "0588059ACBD52F7EA2835882F977A9CF72EB9775",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=72", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121685, "0A1ADB22C1D3E1F4B2448EE3F27DF9DE63329C4C",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=84", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121686, "0E171F67DF35B781B61D8F79B0E59EE21F80A595",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=48", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121687, "101E9DD9BE95D87DABF071EC0007923778409A35",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121688, "1072FDC2B3F14476527F9AFDC6A9A3365CDD4520",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=52", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121689, "121EC59E23F7559B28D338D562528F6299C2DE22",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=240", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121690, "12D04472A8285260EA12FD3813CDFA9F2D2B548C",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121691, "13A35EF1A549297C70E2AD46045BBD2ECA17852D",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121692, "1730F09044E91DB8371B849EFF5E6D17BDE4AED0",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121693, "18ABA12DD09EAEC266A410595FF8397550CB69F3",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=2224", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121694, "1A84029C80CB5518379F199F53FF08A7B764F8FD",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121695, "1AEF3D8DF416A46288C91C724CBF7B154D9E5BF3",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=4096", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121696, "1E41C4CD0767AEA21C00DEABA2EA9407F1E6CEA5",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=2048", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121697, "1FE6CE411858B3D864679DE2139FB081F08BFACD",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121698, "211DEF42B95FD6AB230AA0439D7B1B4125F71291",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121699, "235D99572263B22ADFEE10FDA0C25E12F4D94FFC",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121700, "25420D0055076FA8D3E4DD96BC53AE24DE6E619F",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121701, "25CF935D2AE9EDF05DD75BCD47FF84D9255D6F6E",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=1208", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121702, "29C1A61550F0E3260E1953D4FAD71C256218EF40",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=42", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121703, "2B33BEC8C30DFDC49DAFE20D3BDE19487850D717",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121704, "2B6224F32C7F4129F429E6AE11030AB9FA140D91",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121705, "2BA840FF6020B8FF623DBCB7188248CF853FAF4F",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=36", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121706, "2BDE6A90DA8A72A009B639C351305719BFAC31BB",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=6", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121707, "2C840AFA48C27B9C05593E468C1232CA1CC74AFD",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=72", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121708, "2D1DA5BB407F0C11C3B5116196C0C6374D932B20",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121709, "2D3CF0F15AC2DDEC2956EA1B7BBE43FB8B923130",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=14", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121710, "2F71D2DA12F3CD0A6A112F5A5A75B4FDC6FE8547",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=72", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121711, "320B018758ECE3752FFEDBAEB1A6DB67C80B9359",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=64", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121712, "34476C29F6F81C989CFCA42F7C06E84C66236834",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=72", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121713, "35EED060772F2748D13B745DAEC8CD7BD3B87604",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=2382", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121714, "375F9AE9769A3D1DA789E9ACFE81F3A1BB14F0D3",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=38", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121715, "379C06C9E702D31469C29033F0DD63931EB349F5",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=1450", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121716, "399BD13E240F33F808CA7940293D6EC4E6FD5A00",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=10", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121717, "39C9CE73C7B0619D409EF28344F687C1B5C130FE",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=72", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121718, "3D4480E43F2013201B4A95D1AB9224A6A823E283",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=1440", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121719, "3E3442C7396F3F2BB4C7348F4A2074C7DC677D68",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121720, "3E823444D2DFECF0F90B436B88F02A533CB376F1",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121721, "3FE6C283BCF384FD2C8789880DFF59664E2AB4A1",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=72", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121722, "40981BAA39513E58B28DCF0103CC04DE2A0A0444",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=1665", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "<PrivateImplementationDetails>", 67121723, "40E7C49413D261F3F38AD3A870C0AC69C8BDA048",
            SourceMemberKind.Field, 307, "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
