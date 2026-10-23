using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl206(SourceMemberCatalog catalog)
    {
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.UCOMITypeLib", 33557085, 4257, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute", "System.Void System.ObsoleteAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x32, 0x30, 0x34, 0x30, 0x32, 0x2D, 0x30, 0x30, 0x30, 0x30,
                        0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x63, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30, 0x30,
                        0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DefaultInterfaceAttribute", 33557086, 1048833,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x04, 0x04, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77,
                        0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                        0x72, 0x69, 0x74, 0x65, 0x64, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DefaultInterfaceAttribute", 67121437, "m_defaultInterface",
            SourceMemberKind.Field, 1, "System.Type", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DefaultInterfaceAttribute", 385880521, "DefaultInterface",
            SourceMemberKind.Property, 0, "System.Type", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeImportAttribute", 33557087, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                    "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x1C, 0x14, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65, 0x72,
                        0x69, 0x74, 0x65, 0x64, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 33557088, 1048833,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x04, 0x04, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65, 0x72,
                        0x69, 0x74, 0x65, 0x64, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77, 0x4D, 0x75, 0x6C,
                        0x74, 0x69, 0x70, 0x6C, 0x65, 0x01
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 67121438,
            "m_interfaceType", SourceMemberKind.Field, 1, "System.Type", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 67121439,
            "m_majorVersion", SourceMemberKind.Field, 1, "System.Byte", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 67121440,
            "m_minorVersion", SourceMemberKind.Field, 1, "System.Byte", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 67121441,
            "m_buildVersion", SourceMemberKind.Field, 1, "System.Byte", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 67121442,
            "m_revisionVersion", SourceMemberKind.Field, 1, "System.Byte", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 385880522,
            "InterfaceType", SourceMemberKind.Property, 0, "System.Type", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 385880523,
            "MajorVersion", SourceMemberKind.Property, 0, "System.Byte", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 385880524,
            "MinorVersion", SourceMemberKind.Property, 0, "System.Byte", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 385880525,
            "BuildVersion", SourceMemberKind.Property, 0, "System.Byte", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute", 385880526,
            "RevisionVersion", SourceMemberKind.Property, 0, "System.Byte", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.ReadOnlyArrayAttribute", 33557089, 1048833,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x00, 0x08, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65, 0x72,
                        0x69, 0x74, 0x65, 0x64, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77, 0x4D, 0x75, 0x6C,
                        0x74, 0x69, 0x70, 0x6C, 0x65, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WriteOnlyArrayAttribute", 33557090, 1048833,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x00, 0x08, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65, 0x72,
                        0x69, 0x74, 0x65, 0x64, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77, 0x4D, 0x75, 0x6C,
                        0x74, 0x69, 0x70, 0x6C, 0x65, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.ReturnValueNameAttribute", 33557091, 1048833,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x00, 0x30, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77,
                        0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                        0x72, 0x69, 0x74, 0x65, 0x64, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.ReturnValueNameAttribute", 67121443, "m_Name",
            SourceMemberKind.Field, 1, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.ReturnValueNameAttribute", 385880527, "Name",
            SourceMemberKind.Property, 0, "System.String", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken", 33557092, 1048841,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken", 67121444, "m_value",
            SourceMemberKind.Field, 3, "System.UInt64", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken", 385880528, "Value",
            SourceMemberKind.Property, 0, "System.UInt64", 2179, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable`1", 33557093, 1048833,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704644410, 4, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable`1", 67121445, "m_tokens",
            SourceMemberKind.Field, 1,
            "System.Collections.Generic.Dictionary`2<System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken,T>",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable`1", 67121446, "m_invokeList",
            SourceMemberKind.Field, 1, "T modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable`1", 385880529, "InvocationList",
            SourceMemberKind.Property, 0, "T", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.IActivationFactory", 33557094, 20641, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x33, 0x35, 0x2D, 0x30, 0x30, 0x30, 0x30,
                        0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30, 0x30,
                        0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.IRestrictedErrorInfo", 33557095, 4256, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x38, 0x32, 0x42, 0x41, 0x37, 0x30, 0x39, 0x32, 0x2D, 0x34, 0x43, 0x38, 0x38,
                        0x2D, 0x34, 0x32, 0x37, 0x44, 0x2D, 0x41, 0x37, 0x42, 0x43, 0x2D, 0x31, 0x36, 0x44, 0x44, 0x39,
                        0x33, 0x46, 0x45, 0x42, 0x36, 0x37, 0x45, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal", 33557096, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal", 67121447, "s_haveBlueErrorApis",
            SourceMemberKind.Field, 17, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal", 67121448, "s_iidIErrorInfo",
            SourceMemberKind.Field, 17, "System.Guid", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+EventRegistrationTokenList", 33557097,
            1048845, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+EventRegistrationTokenList", 67121449,
            "firstToken", SourceMemberKind.Field, 1,
            "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+EventRegistrationTokenList", 67121450,
            "restTokens", SourceMemberKind.Field, 1,
            "System.Collections.Generic.List`1<System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken>",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+ManagedEventRegistrationImpl",
            33557098, 1048965, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+ManagedEventRegistrationImpl",
            67121451, "s_eventRegistrations", SourceMemberKind.Field, 19,
            "System.Runtime.CompilerServices.ConditionalWeakTable`2<System.Object,System.Collections.Generic.Dictionary`2<System.Reflection.MethodInfo,System.Collections.Generic.Dictionary`2<System.Object,System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+EventRegistrationTokenList>>> modreq(System.Runtime.CompilerServices.IsVolatile)",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl",
            33557099, 1048965, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl",
            67121452, "s_eventRegistrations", SourceMemberKind.Field, 19,
            "System.Collections.Generic.Dictionary`2<System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKey,System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheEntry> modreq(System.Runtime.CompilerServices.IsVolatile)",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl",
            67121453, "s_eventCacheRWLock", SourceMemberKind.Field, 17,
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock modreq(System.Runtime.CompilerServices.IsVolatile)",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKey",
            33557100, 1048845, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.ValueType", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKey",
            67121454, "target", SourceMemberKind.Field, 3, "System.Object", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKey",
            67121455, "method", SourceMemberKind.Field, 3, "System.Reflection.MethodInfo", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKeyEqualityComparer",
            33557101, 1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEqualityComparer`1<System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKey>"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventRegistrationTokenListWithCount",
            33557102, 1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventRegistrationTokenListWithCount",
            67121456, "_tokenListCount", SourceMemberKind.Field, 1,
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+TokenListCount",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventRegistrationTokenListWithCount",
            67121457, "_tokenList", SourceMemberKind.Field, 1,
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+EventRegistrationTokenList", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+TokenListCount",
            33557103, 1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+TokenListCount",
            67121458, "_count", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+TokenListCount",
            67121459, "_key", SourceMemberKind.Field, 1,
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKey",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+TokenListCount",
            385880530, "Key", SourceMemberKind.Property, 0,
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheKey",
            2179, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheEntry",
            33557104, 1048845, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.ValueType", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheEntry",
            67121460, "registrationTable", SourceMemberKind.Field, 3,
            "System.Runtime.CompilerServices.ConditionalWeakTable`2<System.Object,System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventRegistrationTokenListWithCount>",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+EventCacheEntry",
            67121461, "tokenListCount", SourceMemberKind.Field, 3,
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+TokenListCount",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+ReaderWriterLockTimedOutException",
            33557105, 1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.ApplicationException", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock",
            33557106, 1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock",
            67121462, "myLock", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock",
            67121463, "owners", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock",
            67121464, "numWriteWaiters", SourceMemberKind.Field, 1, "System.UInt32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock",
            67121465, "numReadWaiters", SourceMemberKind.Field, 1, "System.UInt32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock",
            67121466, "writeEvent", SourceMemberKind.Field, 1, "System.Threading.EventWaitHandle", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal+NativeOrStaticEventRegistrationImpl+MyReaderWriterLock",
            67121467, "readEvent", SourceMemberKind.Field, 1, "System.Threading.EventWaitHandle", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DesignerNamespaceResolveEventArgs", 33557107, 1048577,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.EventArgs",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DesignerNamespaceResolveEventArgs", 67121468,
            "<NamespaceName>k__BackingField", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DesignerNamespaceResolveEventArgs", 67121469,
            "<ResolvedAssemblyFiles>k__BackingField", SourceMemberKind.Field, 1,
            "System.Collections.ObjectModel.Collection`1<System.String>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DesignerNamespaceResolveEventArgs", 385880531,
            "NamespaceName", SourceMemberKind.Property, 0, "System.String", 2182, 2177, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.DesignerNamespaceResolveEventArgs", 385880532,
            "ResolvedAssemblyFiles", SourceMemberKind.Property, 0,
            "System.Collections.ObjectModel.Collection`1<System.String>", 2182, 2177, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs", 33557108, 1048577,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.EventArgs",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs", 67121470,
            "<NamespaceName>k__BackingField", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs", 67121471,
            "<RequestingAssembly>k__BackingField", SourceMemberKind.Field, 1, "System.Reflection.Assembly", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs", 67121472,
            "<ResolvedAssemblies>k__BackingField", SourceMemberKind.Field, 1,
            "System.Collections.ObjectModel.Collection`1<System.Reflection.Assembly>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs", 385880533, "NamespaceName",
            SourceMemberKind.Property, 0, "System.String", 2182, 2177, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs", 385880534, "RequestingAssembly",
            SourceMemberKind.Property, 0, "System.Reflection.Assembly", 2182, 2177, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs", 385880535, "ResolvedAssemblies",
            SourceMemberKind.Property, 0, "System.Collections.ObjectModel.Collection`1<System.Reflection.Assembly>",
            2182, 2177, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.UnsafeNativeMethods", 33557109, 1048960,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMetadata", 33557110, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMetadata", 67121473,
            "DesignerNamespaceResolve", SourceMemberKind.Field, 17,
            "System.EventHandler`1<System.Runtime.InteropServices.WindowsRuntime.DesignerNamespaceResolveEventArgs>",
            -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMetadata", 67121474,
            "ReflectionOnlyNamespaceResolve", SourceMemberKind.Field, 17,
            "System.EventHandler`1<System.Runtime.InteropServices.WindowsRuntime.NamespaceResolveEventArgs>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.Expando.IExpando", 33557111, 161, null, null,
            new string[] { "System.Reflection.IReflect" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x41, 0x46, 0x42, 0x46, 0x31, 0x35, 0x45, 0x36, 0x2D, 0x43, 0x33, 0x37, 0x43,
                        0x2D, 0x31, 0x31, 0x64, 0x32, 0x2D, 0x42, 0x38, 0x38, 0x45, 0x2D, 0x30, 0x30, 0x41, 0x30, 0x43,
                        0x39, 0x42, 0x34, 0x37, 0x31, 0x42, 0x38, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.BIND_OPTS", 33557112, 1048841,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.BIND_OPTS", 67121475, "cbStruct", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.BIND_OPTS", 67121476, "grfFlags", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.BIND_OPTS", 67121477, "grfMode", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.BIND_OPTS", 67121478, "dwTickCountDeadline",
            SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IBindCtx", 33557113, 4257, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x65, 0x2D, 0x30, 0x30, 0x30, 0x30,
                        0x2D, 0x30, 0x30, 0x30, 0x30, 0x2D, 0x43, 0x30, 0x30, 0x30, 0x2D, 0x30, 0x30, 0x30, 0x30, 0x30,
                        0x30, 0x30, 0x30, 0x30, 0x30, 0x34, 0x36, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IConnectionPointContainer", 33557114, 4257, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x42, 0x31, 0x39, 0x36, 0x42, 0x32, 0x38, 0x34, 0x2D, 0x42, 0x41, 0x42, 0x34,
                        0x2D, 0x31, 0x30, 0x31, 0x41, 0x2D, 0x42, 0x36, 0x39, 0x43, 0x2D, 0x30, 0x30, 0x41, 0x41, 0x30,
                        0x30, 0x33, 0x34, 0x31, 0x44, 0x30, 0x37, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IConnectionPoint", 33557115, 4257, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x42, 0x31, 0x39, 0x36, 0x42, 0x32, 0x38, 0x36, 0x2D, 0x42, 0x41, 0x42, 0x34,
                        0x2D, 0x31, 0x30, 0x31, 0x41, 0x2D, 0x42, 0x36, 0x39, 0x43, 0x2D, 0x30, 0x30, 0x41, 0x41, 0x30,
                        0x30, 0x33, 0x34, 0x31, 0x44, 0x30, 0x37, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IEnumConnectionPoints", 33557116, 4257, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x42, 0x31, 0x39, 0x36, 0x42, 0x32, 0x38, 0x35, 0x2D, 0x42, 0x41, 0x42, 0x34,
                        0x2D, 0x31, 0x30, 0x31, 0x41, 0x2D, 0x42, 0x36, 0x39, 0x43, 0x2D, 0x30, 0x30, 0x41, 0x41, 0x30,
                        0x30, 0x33, 0x34, 0x31, 0x44, 0x30, 0x37, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.CONNECTDATA", 33557117, 1114377,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.CONNECTDATA", 67121479, "pUnk", SourceMemberKind.Field, 4102,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.CONNECTDATA", 67121480, "dwCookie", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IEnumConnections", 33557118, 4257, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x42, 0x31, 0x39, 0x36, 0x42, 0x32, 0x38, 0x37, 0x2D, 0x42, 0x41, 0x42, 0x34,
                        0x2D, 0x31, 0x30, 0x31, 0x41, 0x2D, 0x42, 0x36, 0x39, 0x43, 0x2D, 0x30, 0x30, 0x41, 0x41, 0x30,
                        0x30, 0x33, 0x34, 0x31, 0x44, 0x30, 0x37, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IEnumerable", 33557119, 160, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x34, 0x39, 0x36, 0x42, 0x30, 0x41, 0x42, 0x45, 0x2D, 0x43, 0x44, 0x45, 0x45,
                        0x2D, 0x31, 0x31, 0x64, 0x33, 0x2D, 0x38, 0x38, 0x45, 0x38, 0x2D, 0x30, 0x30, 0x39, 0x30, 0x32,
                        0x37, 0x35, 0x34, 0x43, 0x34, 0x33, 0x41, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IEnumerator", 33557120, 160, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x34, 0x39, 0x36, 0x42, 0x30, 0x41, 0x42, 0x46, 0x2D, 0x43, 0x44, 0x45, 0x45,
                        0x2D, 0x31, 0x31, 0x64, 0x33, 0x2D, 0x38, 0x38, 0x45, 0x38, 0x2D, 0x30, 0x30, 0x39, 0x30, 0x32,
                        0x37, 0x35, 0x34, 0x43, 0x34, 0x33, 0x41, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ComTypes.IEnumerator", 385880536, "Current", SourceMemberKind.Property, 0,
            "System.Object", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
