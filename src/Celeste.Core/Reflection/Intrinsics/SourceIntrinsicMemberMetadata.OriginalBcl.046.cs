using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl046(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            67112063, "os", SourceMemberKind.Field, 17, "System.OperatingSystem", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            67112064, "<Platform>k__BackingField", SourceMemberKind.Field, 49, "System.PlatformID", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876691, "IsWindows8OrAbove", SourceMemberKind.Property, 0, "System.Boolean", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876692, "CommandLine", SourceMemberKind.Property, 0, "System.String", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876693, "CurrentDirectory", SourceMemberKind.Property, 0, "System.String", 2198, 2198, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876694, "CurrentManagedThreadId", SourceMemberKind.Property, 0, "System.Int32", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876695, "ExitCode", SourceMemberKind.Property, 0, "System.Int32", 2198, 2198, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876696, "HasShutdownStarted", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876697, "MachineName", SourceMemberKind.Property, 0, "System.String", 18582, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876698, "NewLine", SourceMemberKind.Property, 0, "System.String", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876699, "Platform", SourceMemberKind.Property, 0, "System.PlatformID", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876700, "OSVersion", SourceMemberKind.Property, 0, "System.OperatingSystem", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876701, "StackTrace", SourceMemberKind.Property, 0, "System.String", 18582, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876702, "SystemDirectory", SourceMemberKind.Property, 0, "System.String", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876703, "TickCount", SourceMemberKind.Property, 0, "System.Int32", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876704, "UserDomainName", SourceMemberKind.Property, 0, "System.String", 18582, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876705, "UserInteractive", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x3F, 0x43, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x74, 0x6C, 0x79, 0x20, 0x61, 0x6C, 0x77,
                        0x61, 0x79, 0x73, 0x20, 0x72, 0x65, 0x74, 0x75, 0x72, 0x6E, 0x73, 0x20, 0x66, 0x61, 0x6C, 0x73,
                        0x65, 0x2C, 0x20, 0x72, 0x65, 0x67, 0x61, 0x72, 0x64, 0x6C, 0x65, 0x73, 0x73, 0x20, 0x6F, 0x66,
                        0x20, 0x69, 0x6E, 0x74, 0x65, 0x72, 0x61, 0x63, 0x74, 0x69, 0x76, 0x65, 0x20, 0x73, 0x74, 0x61,
                        0x74, 0x65, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876706, "UserName", SourceMemberKind.Property, 0, "System.String", 18582, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876707, "Version", SourceMemberKind.Property, 0, "System.Version", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876708, "WorkingSet", SourceMemberKind.Property, 0, "System.Int64", 18582, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x1D, 0x43, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x74, 0x6C, 0x79, 0x20, 0x61, 0x6C, 0x77,
                        0x61, 0x79, 0x73, 0x20, 0x72, 0x65, 0x74, 0x75, 0x72, 0x6E, 0x73, 0x20, 0x7A, 0x65, 0x72, 0x6F,
                        0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876709, "Is64BitOperatingSystem", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876710, "SystemPageSize", SourceMemberKind.Property, 0, "System.Int32", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876711, "Is64BitProcess", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876712, "ProcessorCount", SourceMemberKind.Property, 0, "System.Int32", 18582, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876713, "IsRunningOnWindows", SourceMemberKind.Property, 0, "System.Boolean", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876714, "GacPath", SourceMemberKind.Property, 0, "System.String", 2193, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876715, "IsUnix", SourceMemberKind.Property, 0, "System.Boolean", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876716, "IsMacOS", SourceMemberKind.Property, 0, "System.Boolean", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876717, "IsCLRHosted", SourceMemberKind.Property, 0, "System.Boolean", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            385876718, "IsWinRTSupported", SourceMemberKind.Property, 0, "System.Boolean", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 33554929, 258,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112065, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112066, "MyDocuments", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x05, 0x00, 0x00, 0x00 }), "System.Int32",
            "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112067, "Desktop", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112068, "MyComputer", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x11, 0x00, 0x00, 0x00 }), "System.Int32",
            "11000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112069, "Programs", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112070, "Personal", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x05, 0x00, 0x00, 0x00 }), "System.Int32",
            "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112071, "Favorites", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x06, 0x00, 0x00, 0x00 }), "System.Int32",
            "06000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112072, "Startup", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x07, 0x00, 0x00, 0x00 }), "System.Int32",
            "07000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112073, "Recent", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112074, "SendTo", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x09, 0x00, 0x00, 0x00 }), "System.Int32",
            "09000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112075, "StartMenu", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x0B, 0x00, 0x00, 0x00 }), "System.Int32",
            "0B000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112076, "MyMusic", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x0D, 0x00, 0x00, 0x00 }), "System.Int32",
            "0D000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112077, "DesktopDirectory", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x10, 0x00, 0x00, 0x00 }), "System.Int32",
            "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112078, "Templates", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x15, 0x00, 0x00, 0x00 }), "System.Int32",
            "15000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112079, "ApplicationData", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x1A, 0x00, 0x00, 0x00 }), "System.Int32",
            "1A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112080, "LocalApplicationData", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x1C, 0x00, 0x00, 0x00 }), "System.Int32",
            "1C000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112081, "InternetCache", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x00, 0x00, 0x00 }), "System.Int32",
            "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112082, "Cookies", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x21, 0x00, 0x00, 0x00 }), "System.Int32",
            "21000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112083, "History", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x22, 0x00, 0x00, 0x00 }), "System.Int32",
            "22000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112084, "CommonApplicationData", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x23, 0x00, 0x00, 0x00 }), "System.Int32",
            "23000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112085, "System", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x25, 0x00, 0x00, 0x00 }), "System.Int32",
            "25000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112086, "ProgramFiles", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x26, 0x00, 0x00, 0x00 }), "System.Int32",
            "26000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112087, "MyPictures", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x27, 0x00, 0x00, 0x00 }), "System.Int32",
            "27000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112088, "CommonProgramFiles", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x2B, 0x00, 0x00, 0x00 }), "System.Int32",
            "2B000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112089, "MyVideos", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x0E, 0x00, 0x00, 0x00 }), "System.Int32",
            "0E000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112090, "NetworkShortcuts", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x13, 0x00, 0x00, 0x00 }), "System.Int32",
            "13000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112091, "Fonts", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x14, 0x00, 0x00, 0x00 }), "System.Int32",
            "14000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112092, "CommonStartMenu", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x16, 0x00, 0x00, 0x00 }), "System.Int32",
            "16000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112093, "CommonPrograms", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x17, 0x00, 0x00, 0x00 }), "System.Int32",
            "17000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112094, "CommonStartup", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x18, 0x00, 0x00, 0x00 }), "System.Int32",
            "18000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112095, "CommonDesktopDirectory", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x19, 0x00, 0x00, 0x00 }), "System.Int32",
            "19000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112096, "PrinterShortcuts", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x1B, 0x00, 0x00, 0x00 }), "System.Int32",
            "1B000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112097, "Windows", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x24, 0x00, 0x00, 0x00 }), "System.Int32",
            "24000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112098, "UserProfile", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x28, 0x00, 0x00, 0x00 }), "System.Int32",
            "28000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112099, "SystemX86", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x29, 0x00, 0x00, 0x00 }), "System.Int32",
            "29000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112100, "ProgramFilesX86", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x2A, 0x00, 0x00, 0x00 }), "System.Int32",
            "2A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112101, "CommonProgramFilesX86", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x2C, 0x00, 0x00, 0x00 }), "System.Int32",
            "2C000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112102, "CommonTemplates", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x2D, 0x00, 0x00, 0x00 }), "System.Int32",
            "2D000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112103, "CommonDocuments", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x2E, 0x00, 0x00, 0x00 }), "System.Int32",
            "2E000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112104, "CommonAdminTools", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x2F, 0x00, 0x00, 0x00 }), "System.Int32",
            "2F000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112105, "AdminTools", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x30, 0x00, 0x00, 0x00 }), "System.Int32",
            "30000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112106, "CommonMusic", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x35, 0x00, 0x00, 0x00 }), "System.Int32",
            "35000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112107, "CommonPictures", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x36, 0x00, 0x00, 0x00 }), "System.Int32",
            "36000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112108, "CommonVideos", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x37, 0x00, 0x00, 0x00 }), "System.Int32",
            "37000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112109, "Resources", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x38, 0x00, 0x00, 0x00 }), "System.Int32",
            "38000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112110, "LocalizedResources", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x39, 0x00, 0x00, 0x00 }), "System.Int32",
            "39000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112111, "CommonOemLinks", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x3A, 0x00, 0x00, 0x00 }), "System.Int32",
            "3A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolder", 67112112, "CDBurning", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolder", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x3B, 0x00, 0x00, 0x00 }), "System.Int32",
            "3B000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolderOption", 33554930, 258,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolderOption", 67112113, "value__", SourceMemberKind.Field, 1542, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolderOption", 67112114, "None", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolderOption", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolderOption", 67112115, "DoNotVerify", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolderOption", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x40, 0x00, 0x00 }), "System.Int32",
            "00400000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Environment+SpecialFolderOption", 67112116, "Create", SourceMemberKind.Field, 32854,
            "System.Environment+SpecialFolderOption", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x80, 0x00, 0x00 }), "System.Int32",
            "00800000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            33554931, 1048960, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112117, "PrintAsI1", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x40, 0x00, 0x00, 0x00 }), "System.Int32",
            "40000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112118, "PrintAsI2", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x80, 0x00, 0x00, 0x00 }), "System.Int32",
            "80000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112119, "TreatAsUnsigned", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x02, 0x00, 0x00 }), "System.Int32",
            "00020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112120, "TreatAsI1", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x04, 0x00, 0x00 }), "System.Int32",
            "00040000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112121, "TreatAsI2", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x08, 0x00, 0x00 }), "System.Int32",
            "00080000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112122, "IsTight", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x10, 0x00, 0x00 }), "System.Int32",
            "00100000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112123, "NoSpace", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x20, 0x00, 0x00 }), "System.Int32",
            "00200000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112124, "base16MaxOverflowFreeValue", SourceMemberKind.Field, 32849, "System.UInt64", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.UInt64",
                new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00 }), "System.UInt64", "FFFFFFFFFFFFFF00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ParseNumbers",
            67112125, "longMinValue", SourceMemberKind.Field, 32849, "System.UInt64", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.UInt64",
                new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }), "System.UInt64", "0000000000000080",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.IRuntimeMethodInfo",
            33554932, 160, null, null, Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.IRuntimeMethodInfo",
            385876719, "Value", SourceMemberKind.Property, 0, "System.RuntimeMethodHandleInternal", 3526, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
