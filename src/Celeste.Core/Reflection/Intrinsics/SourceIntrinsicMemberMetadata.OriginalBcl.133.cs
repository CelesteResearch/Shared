using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl133(SourceMemberCatalog catalog)
    {
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 33555906, 259,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117408, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117409, "None", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117410, "NameClaimType", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117411, "RoleClaimType", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117412, "StringType", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117413, "Issuer", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117414, "OriginalIssuerEqualsIssuer",
            SourceMemberKind.Field, 32854, "System.Security.Claims.Claim+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x10, 0x00, 0x00, 0x00 }), "System.Int32",
            "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117415, "OriginalIssuer", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x00, 0x00, 0x00 }), "System.Int32",
            "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117416, "HasProperties", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x40, 0x00, 0x00, 0x00 }), "System.Int32",
            "40000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim+SerializationMask", 67117417, "UserData", SourceMemberKind.Field, 32854,
            "System.Security.Claims.Claim+SerializationMask", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x80, 0x00, 0x00, 0x00 }), "System.Int32",
            "80000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 33555907, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Security.Principal.IIdentity" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117418, "m_userSerializationData", SourceMemberKind.Field, 129,
            "System.Byte[]", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117419, "PreFix", SourceMemberKind.Field, 32977, "System.String",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117420, "ActorKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x61, 0x00,
                    0x63, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x72, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E006100630074006F007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117421, "AuthenticationTypeKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x61, 0x00,
                    0x75, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x54, 0x00, 0x79, 0x00, 0x70, 0x00,
                    0x65, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E00610075007400680065006E007400690063006100740069006F006E005400790070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117422, "BootstrapContextKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x62, 0x00,
                    0x6F, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x73, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x70, 0x00,
                    0x43, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00, 0x78, 0x00, 0x74, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E0062006F006F0074007300740072006100700043006F006E007400650078007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117423, "ClaimsKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x63, 0x00,
                    0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E0063006C00610069006D007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117424, "LabelKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x6C, 0x00,
                    0x61, 0x00, 0x62, 0x00, 0x65, 0x00, 0x6C, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E006C006100620065006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117425, "NameClaimTypeKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x6E, 0x00,
                    0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00,
                    0x54, 0x00, 0x79, 0x00, 0x70, 0x00, 0x65, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E006E0061006D00650043006C00610069006D005400790070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117426, "RoleClaimTypeKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x72, 0x00,
                    0x6F, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00,
                    0x54, 0x00, 0x79, 0x00, 0x70, 0x00, 0x65, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E0072006F006C00650043006C00610069006D005400790070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117427, "VersionKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x76, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E00760065007200730069006F006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117428, "DefaultIssuer", SourceMemberKind.Field, 32982,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4C, 0x00, 0x4F, 0x00, 0x43, 0x00, 0x41, 0x00, 0x4C, 0x00, 0x20, 0x00, 0x41, 0x00, 0x55, 0x00,
                    0x54, 0x00, 0x48, 0x00, 0x4F, 0x00, 0x52, 0x00, 0x49, 0x00, 0x54, 0x00, 0x59, 0x00
                }), "System.String", "4C004F00430041004C00200041005500540048004F005200490054005900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117429, "DefaultNameClaimType", SourceMemberKind.Field, 32982,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x68, 0x00, 0x74, 0x00, 0x74, 0x00, 0x70, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x2F, 0x00, 0x73, 0x00,
                    0x63, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x73, 0x00, 0x2E, 0x00, 0x78, 0x00,
                    0x6D, 0x00, 0x6C, 0x00, 0x73, 0x00, 0x6F, 0x00, 0x61, 0x00, 0x70, 0x00, 0x2E, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x67, 0x00, 0x2F, 0x00, 0x77, 0x00, 0x73, 0x00, 0x2F, 0x00, 0x32, 0x00, 0x30, 0x00,
                    0x30, 0x00, 0x35, 0x00, 0x2F, 0x00, 0x30, 0x00, 0x35, 0x00, 0x2F, 0x00, 0x69, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2F, 0x00, 0x63, 0x00,
                    0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2F, 0x00, 0x6E, 0x00, 0x61, 0x00,
                    0x6D, 0x00, 0x65, 0x00
                }), "System.String",
            "68007400740070003A002F002F0073006300680065006D00610073002E0078006D006C0073006F00610070002E006F00720067002F00770073002F0032003000300035002F00300035002F006900640065006E0074006900740079002F0063006C00610069006D0073002F006E0061006D006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117430, "DefaultRoleClaimType", SourceMemberKind.Field, 32982,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x68, 0x00, 0x74, 0x00, 0x74, 0x00, 0x70, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x2F, 0x00, 0x73, 0x00,
                    0x63, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x73, 0x00, 0x2E, 0x00, 0x6D, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x6F, 0x00, 0x66, 0x00, 0x74, 0x00,
                    0x2E, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x2F, 0x00, 0x77, 0x00, 0x73, 0x00, 0x2F, 0x00,
                    0x32, 0x00, 0x30, 0x00, 0x30, 0x00, 0x38, 0x00, 0x2F, 0x00, 0x30, 0x00, 0x36, 0x00, 0x2F, 0x00,
                    0x69, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00,
                    0x2F, 0x00, 0x63, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2F, 0x00,
                    0x72, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x65, 0x00
                }), "System.String",
            "68007400740070003A002F002F0073006300680065006D00610073002E006D006900630072006F0073006F00660074002E0063006F006D002F00770073002F0032003000300038002F00300036002F006900640065006E0074006900740079002F0063006C00610069006D0073002F0072006F006C006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117431, "m_instanceClaims", SourceMemberKind.Field, 129,
            "System.Collections.Generic.List`1<System.Security.Claims.Claim>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117432, "m_externalClaims", SourceMemberKind.Field, 129,
            "System.Collections.ObjectModel.Collection`1<System.Collections.Generic.IEnumerable`1<System.Security.Claims.Claim>>",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117433, "m_nameType", SourceMemberKind.Field, 129,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117434, "m_roleType", SourceMemberKind.Field, 129,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117435, "m_version", SourceMemberKind.Field, 1, "System.String",
            -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117436, "m_actor", SourceMemberKind.Field, 1,
            "System.Security.Claims.ClaimsIdentity", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117437, "m_authenticationType", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117438, "m_bootstrapContext", SourceMemberKind.Field, 1,
            "System.Object", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117439, "m_label", SourceMemberKind.Field, 1, "System.String",
            -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117440, "m_serializedNameType", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117441, "m_serializedRoleType", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 67117442, "m_serializedClaims", SourceMemberKind.Field, 1,
            "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878721, "AuthenticationType", SourceMemberKind.Property, 0,
            "System.String", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878722, "IsAuthenticated", SourceMemberKind.Property, 0,
            "System.Boolean", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878723, "Actor", SourceMemberKind.Property, 0,
            "System.Security.Claims.ClaimsIdentity", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878724, "BootstrapContext", SourceMemberKind.Property, 0,
            "System.Object", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878725, "Claims", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<System.Security.Claims.Claim>", 2502, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878726, "CustomSerializationData", SourceMemberKind.Property, 0,
            "System.Byte[]", 2500, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878727, "ExternalClaims", SourceMemberKind.Property, 0,
            "System.Collections.ObjectModel.Collection`1<System.Collections.Generic.IEnumerable`1<System.Security.Claims.Claim>>",
            2179, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878728, "Label", SourceMemberKind.Property, 0, "System.String",
            2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878729, "Name", SourceMemberKind.Property, 0, "System.String",
            2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878730, "NameClaimType", SourceMemberKind.Property, 0,
            "System.String", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity", 385878731, "RoleClaimType", SourceMemberKind.Property, 0,
            "System.String", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 33555908, 259,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117443, "value__", SourceMemberKind.Field,
            1542, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117444, "None", SourceMemberKind.Field, 32854,
            "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117445, "AuthenticationType",
            SourceMemberKind.Field, 32854, "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117446, "BootstrapConext",
            SourceMemberKind.Field, 32854, "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117447, "NameClaimType",
            SourceMemberKind.Field, 32854, "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117448, "RoleClaimType",
            SourceMemberKind.Field, 32854, "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117449, "HasClaims", SourceMemberKind.Field,
            32854, "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x10, 0x00, 0x00, 0x00 }), "System.Int32",
            "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117450, "HasLabel", SourceMemberKind.Field,
            32854, "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x00, 0x00, 0x00 }), "System.Int32",
            "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117451, "Actor", SourceMemberKind.Field, 32854,
            "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x40, 0x00, 0x00, 0x00 }), "System.Int32",
            "40000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+SerializationMask", 67117452, "UserData", SourceMemberKind.Field,
            32854, "System.Security.Claims.ClaimsIdentity+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x80, 0x00, 0x00, 0x00 }), "System.Int32",
            "80000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 33555909, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEnumerable`1<System.Security.Claims.Claim>",
                "System.Collections.IEnumerable",
                "System.Collections.Generic.IEnumerator`1<System.Security.Claims.Claim>", "System.IDisposable",
                "System.Collections.IEnumerator"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 67117453, "<>1__state", SourceMemberKind.Field,
            1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 67117454, "<>2__current", SourceMemberKind.Field,
            1, "System.Security.Claims.Claim", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 67117455, "<>l__initialThreadId",
            SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 67117456, "<>4__this", SourceMemberKind.Field, 6,
            "System.Security.Claims.ClaimsIdentity", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 67117457, "<i>5__1", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 67117458, "<j>5__2", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 67117459, "<>7__wrap1", SourceMemberKind.Field,
            1, "System.Collections.Generic.IEnumerator`1<System.Security.Claims.Claim>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 385878732,
            "System.Collections.Generic.IEnumerator<System.Security.Claims.Claim>.Current", SourceMemberKind.Property,
            0, "System.Security.Claims.Claim", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity+<get_Claims>d__51", 385878733,
            "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 33555910, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Security.Principal.IPrincipal" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117460, "m_userSerializationData", SourceMemberKind.Field, 129,
            "System.Byte[]", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117461, "PreFix", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x50, 0x00, 0x72, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x69, 0x00, 0x70, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2E, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073005000720069006E0063006900700061006C002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117462, "IdentitiesKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x50, 0x00, 0x72, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x69, 0x00, 0x70, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2E, 0x00,
                    0x49, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x69, 0x00,
                    0x65, 0x00, 0x73, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073005000720069006E0063006900700061006C002E004900640065006E00740069007400690065007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117463, "VersionKey", SourceMemberKind.Field, 32977,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00,
                    0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x50, 0x00, 0x72, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x69, 0x00, 0x70, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2E, 0x00,
                    0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00
                }), "System.String",
            "530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073005000720069006E0063006900700061006C002E00560065007200730069006F006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117464, "m_version", SourceMemberKind.Field, 1, "System.String",
            -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117465, "m_serializedClaimsIdentities", SourceMemberKind.Field,
            1, "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.Serialization.OptionalFieldAttribute",
                    "System.Void System.Runtime.Serialization.OptionalFieldAttribute::.ctor()",
                    new byte[]
                    {
                        0x01, 0x00, 0x01, 0x00, 0x54, 0x08, 0x0C, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x41, 0x64,
                        0x64, 0x65, 0x64, 0x02, 0x00, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117466, "m_identities", SourceMemberKind.Field, 129,
            "System.Collections.Generic.List`1<System.Security.Claims.ClaimsIdentity>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117467, "s_identitySelector", SourceMemberKind.Field, 145,
            "System.Func`2<System.Collections.Generic.IEnumerable`1<System.Security.Claims.ClaimsIdentity>,System.Security.Claims.ClaimsIdentity>",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 67117468, "s_principalSelector", SourceMemberKind.Field, 145,
            "System.Func`1<System.Security.Claims.ClaimsPrincipal>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 385878734, "PrimaryIdentitySelector", SourceMemberKind.Property,
            0,
            "System.Func`2<System.Collections.Generic.IEnumerable`1<System.Security.Claims.ClaimsIdentity>,System.Security.Claims.ClaimsIdentity>",
            2198, 2198, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 385878735, "ClaimsPrincipalSelector", SourceMemberKind.Property,
            0, "System.Func`1<System.Security.Claims.ClaimsPrincipal>", 2198, 2198, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 385878736, "CustomSerializationData", SourceMemberKind.Property,
            0, "System.Byte[]", 2500, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 385878737, "Claims", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<System.Security.Claims.Claim>", 2502, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 385878738, "Current", SourceMemberKind.Property, 0,
            "System.Security.Claims.ClaimsPrincipal", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 385878739, "Identities", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<System.Security.Claims.ClaimsIdentity>", 2502, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", 385878740, "Identity", SourceMemberKind.Property, 0,
            "System.Security.Principal.IIdentity", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+SerializationMask", 33555911, 259,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+SerializationMask", 67117469, "value__", SourceMemberKind.Field,
            1542, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+SerializationMask", 67117470, "None", SourceMemberKind.Field, 32854,
            "System.Security.Claims.ClaimsPrincipal+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+SerializationMask", 67117471, "HasIdentities",
            SourceMemberKind.Field, 32854, "System.Security.Claims.ClaimsPrincipal+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+SerializationMask", 67117472, "UserData", SourceMemberKind.Field,
            32854, "System.Security.Claims.ClaimsPrincipal+SerializationMask", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+<get_Claims>d__37", 33555912, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEnumerable`1<System.Security.Claims.Claim>",
                "System.Collections.IEnumerable",
                "System.Collections.Generic.IEnumerator`1<System.Security.Claims.Claim>", "System.IDisposable",
                "System.Collections.IEnumerator"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+<get_Claims>d__37", 67117473, "<>1__state", SourceMemberKind.Field,
            1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+<get_Claims>d__37", 67117474, "<>2__current",
            SourceMemberKind.Field, 1, "System.Security.Claims.Claim", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+<get_Claims>d__37", 67117475, "<>l__initialThreadId",
            SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal+<get_Claims>d__37", 67117476, "<>4__this", SourceMemberKind.Field,
            6, "System.Security.Claims.ClaimsPrincipal", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
