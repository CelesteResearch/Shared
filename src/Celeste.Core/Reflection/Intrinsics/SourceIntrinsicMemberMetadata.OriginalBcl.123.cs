using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl123(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAccess", 67116808, "NoAccess", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.RegistryPermissionAccess", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAccess", 67116809, "Read", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.RegistryPermissionAccess", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAccess", 67116810, "Write", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.RegistryPermissionAccess", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAccess", 67116811, "Create", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.RegistryPermissionAccess", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAccess", 67116812, "AllAccess", SourceMemberKind.Field,
            32854, "System.Security.Permissions.RegistryPermissionAccess", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x07, 0x00, 0x00, 0x00 }), "System.Int32",
            "07000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 33555773, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.CodeAccessSecurityAttribute", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6D, 0x00, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77,
                        0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x01, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                        0x72, 0x69, 0x74, 0x65, 0x64, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 67116813, "create", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 67116814, "read", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 67116815, "write", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 67116816, "changeAccessControl",
            SourceMemberKind.Field, 1, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 67116817, "viewAccessControl",
            SourceMemberKind.Field, 1, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 385878494, "All", SourceMemberKind.Property, 0,
            "System.String", 2182, 2182, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x14, 0x75, 0x73, 0x65, 0x20, 0x6E, 0x65, 0x77, 0x65, 0x72, 0x20, 0x70, 0x72, 0x6F,
                        0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 385878495, "Create", SourceMemberKind.Property,
            0, "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 385878496, "Read", SourceMemberKind.Property, 0,
            "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 385878497, "Write", SourceMemberKind.Property, 0,
            "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 385878498, "ChangeAccessControl",
            SourceMemberKind.Property, 0, "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 385878499, "ViewAccessControl",
            SourceMemberKind.Property, 0, "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermissionAttribute", 385878500, "ViewAndModify",
            SourceMemberKind.Property, 0, "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermission", 33555774, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.CodeAccessPermission",
            new string[]
            {
                "System.Security.Permissions.IUnrestrictedPermission", "System.Security.Permissions.IBuiltInPermission"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermission", 67116818, "version", SourceMemberKind.Field, 32849,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermission", 67116819, "_state", SourceMemberKind.Field, 1,
            "System.Security.Permissions.PermissionState", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermission", 67116820, "createList", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermission", 67116821, "readList", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.RegistryPermission", 67116822, "writeList", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 33555775, 8449,
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
            "System.Security.Permissions.SecurityAction", 67116823, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116824, "Demand", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116825, "Assert", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116826, "Deny", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x20, 0x54, 0x68, 0x69, 0x73, 0x20, 0x72, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x73,
                        0x20, 0x73, 0x68, 0x6F, 0x75, 0x6C, 0x64, 0x20, 0x6E, 0x6F, 0x74, 0x20, 0x62, 0x65, 0x20, 0x75,
                        0x73, 0x65, 0x64, 0x00, 0x00
                    })
            }, true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }),
            "System.Int32", "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116827, "PermitOnly", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x05, 0x00, 0x00, 0x00 }), "System.Int32",
            "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116828, "LinkDemand", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x06, 0x00, 0x00, 0x00 }), "System.Int32",
            "06000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116829, "InheritanceDemand", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x07, 0x00, 0x00, 0x00 }), "System.Int32",
            "07000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116830, "RequestMinimum", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x20, 0x54, 0x68, 0x69, 0x73, 0x20, 0x72, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x73,
                        0x20, 0x73, 0x68, 0x6F, 0x75, 0x6C, 0x64, 0x20, 0x6E, 0x6F, 0x74, 0x20, 0x62, 0x65, 0x20, 0x75,
                        0x73, 0x65, 0x64, 0x00, 0x00
                    })
            }, true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }),
            "System.Int32", "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116831, "RequestOptional", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x20, 0x54, 0x68, 0x69, 0x73, 0x20, 0x72, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x73,
                        0x20, 0x73, 0x68, 0x6F, 0x75, 0x6C, 0x64, 0x20, 0x6E, 0x6F, 0x74, 0x20, 0x62, 0x65, 0x20, 0x75,
                        0x73, 0x65, 0x64, 0x00, 0x00
                    })
            }, true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x09, 0x00, 0x00, 0x00 }),
            "System.Int32", "09000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAction", 67116832, "RequestRefuse", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityAction", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x20, 0x54, 0x68, 0x69, 0x73, 0x20, 0x72, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x73,
                        0x20, 0x73, 0x68, 0x6F, 0x75, 0x6C, 0x64, 0x20, 0x6E, 0x6F, 0x74, 0x20, 0x62, 0x65, 0x20, 0x75,
                        0x73, 0x65, 0x64, 0x00, 0x00
                    })
            }, true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x0A, 0x00, 0x00, 0x00 }),
            "System.Int32", "0A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAttribute", 33555776, 1056897,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6D, 0x00, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77,
                        0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x01, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                        0x72, 0x69, 0x74, 0x65, 0x64, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAttribute", 67116833, "m_Action", SourceMemberKind.Field, 1,
            "System.Security.Permissions.SecurityAction", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAttribute", 67116834, "m_Unrestricted", SourceMemberKind.Field, 1,
            "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAttribute", 385878501, "Unrestricted", SourceMemberKind.Property, 0,
            "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityAttribute", 385878502, "Action", SourceMemberKind.Property, 0,
            "System.Security.Permissions.SecurityAction", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 33555777, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.CodeAccessSecurityAttribute", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6D, 0x00, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77,
                        0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x01, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                        0x72, 0x69, 0x74, 0x65, 0x64, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 67116835, "m_Flags", SourceMemberKind.Field, 1,
            "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878503, "Assertion",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878504, "BindingRedirects",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878505, "ControlAppDomain",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878506, "ControlDomainPolicy",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878507, "ControlEvidence",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878508, "ControlPolicy",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878509, "ControlPrincipal",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878510, "ControlThread",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878511, "Execution",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878512, "Infrastructure",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878513, "RemotingConfiguration",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878514, "SerializationFormatter",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878515, "SkipVerification",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878516, "UnmanagedCode",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionAttribute", 385878517, "Flags", SourceMemberKind.Property, 0,
            "System.Security.Permissions.SecurityPermissionFlag", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermission", 33555778, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.CodeAccessPermission",
            new string[]
            {
                "System.Security.Permissions.IUnrestrictedPermission", "System.Security.Permissions.IBuiltInPermission"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermission", 67116836, "version", SourceMemberKind.Field, 32849,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermission", 67116837, "flags", SourceMemberKind.Field, 1,
            "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermission", 385878518, "Flags", SourceMemberKind.Property, 0,
            "System.Security.Permissions.SecurityPermissionFlag", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 33555779, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116838, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116839, "NoFlags", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116840, "Assertion", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116841, "UnmanagedCode", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116842, "SkipVerification", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116843, "Execution", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116844, "ControlThread", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x10, 0x00, 0x00, 0x00 }), "System.Int32",
            "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116845, "ControlEvidence", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x00, 0x00, 0x00 }), "System.Int32",
            "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116846, "ControlPolicy", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x40, 0x00, 0x00, 0x00 }), "System.Int32",
            "40000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116847, "SerializationFormatter",
            SourceMemberKind.Field, 32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x80, 0x00, 0x00, 0x00 }), "System.Int32",
            "80000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116848, "ControlDomainPolicy",
            SourceMemberKind.Field, 32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x01, 0x00, 0x00 }), "System.Int32",
            "00010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116849, "ControlPrincipal", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x02, 0x00, 0x00 }), "System.Int32",
            "00020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116850, "ControlAppDomain", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x04, 0x00, 0x00 }), "System.Int32",
            "00040000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116851, "RemotingConfiguration",
            SourceMemberKind.Field, 32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x08, 0x00, 0x00 }), "System.Int32",
            "00080000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116852, "Infrastructure", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x10, 0x00, 0x00 }), "System.Int32",
            "00100000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116853, "BindingRedirects", SourceMemberKind.Field,
            32854, "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x20, 0x00, 0x00 }), "System.Int32",
            "00200000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SecurityPermissionFlag", 67116854, "AllFlags", SourceMemberKind.Field, 32854,
            "System.Security.Permissions.SecurityPermissionFlag", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0x3F, 0x00, 0x00 }), "System.Int32",
            "FF3F0000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermissionAttribute", 33555780, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.CodeAccessSecurityAttribute", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6D, 0x00, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77,
                        0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x01, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                        0x72, 0x69, 0x74, 0x65, 0x64, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermissionAttribute", 67116855, "site", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermissionAttribute", 385878519, "Site", SourceMemberKind.Property,
            0, "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermission", 33555781, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.CodeAccessPermission", new string[] { "System.Security.Permissions.IBuiltInPermission" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermission", 67116856, "version", SourceMemberKind.Field, 32849,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermission", 67116857, "_site", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermission", 67116858, "valid", SourceMemberKind.Field, 17,
            "System.Boolean[]", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.SiteIdentityPermission", 385878520, "Site", SourceMemberKind.Property, 0,
            "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 33555782, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.CodeAccessPermission", new string[] { "System.Security.Permissions.IBuiltInPermission" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 67116859, "version", SourceMemberKind.Field,
            32849, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 67116860, "defaultVersion",
            SourceMemberKind.Field, 17, "System.Version", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 67116861, "_state", SourceMemberKind.Field, 1,
            "System.Security.Permissions.PermissionState", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 67116862, "_list", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 385878521, "Name", SourceMemberKind.Property, 0,
            "System.String", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 385878522, "PublicKey",
            SourceMemberKind.Property, 0, "System.Security.Permissions.StrongNamePublicKeyBlob", 2182, 2182, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission", 385878523, "Version", SourceMemberKind.Property,
            0, "System.Version", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Permissions.StrongNameIdentityPermission+SNIP", 33555783, 1048843,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
    }
}
