using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl118(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.CodeGroup", 385878358, "Children", SourceMemberKind.Property, 0,
            "System.Collections.IList", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.CodeGroup", 385878359, "AttributeString", SourceMemberKind.Property, 0,
            "System.String", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.CodeGroup", 385878360, "PermissionSetName", SourceMemberKind.Property, 0,
            "System.String", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 33555695, 1048960,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116542, "DnsPermissionClass", SourceMemberKind.Field, 32849,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x4E, 0x00,
                    0x65, 0x00, 0x74, 0x00, 0x2E, 0x00, 0x44, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x50, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x3D, 0x00, 0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x30, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00,
                    0x61, 0x00, 0x6C, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x62, 0x00, 0x37, 0x00, 0x37, 0x00, 0x61, 0x00, 0x35, 0x00,
                    0x63, 0x00, 0x35, 0x00, 0x36, 0x00, 0x31, 0x00, 0x39, 0x00, 0x33, 0x00, 0x34, 0x00, 0x65, 0x00,
                    0x30, 0x00, 0x38, 0x00, 0x39, 0x00
                }), "System.String",
            "530079007300740065006D002E004E00650074002E0044006E0073005000650072006D0069007300730069006F006E002C002000530079007300740065006D002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200370037006100350063003500360031003900330034006500300038003900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116543, "EventLogPermissionClass", SourceMemberKind.Field,
            32849, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00,
                    0x69, 0x00, 0x61, 0x00, 0x67, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00,
                    0x63, 0x00, 0x73, 0x00, 0x2E, 0x00, 0x45, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x4C, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x50, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00,
                    0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x56, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x34, 0x00,
                    0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2C, 0x00, 0x20, 0x00,
                    0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00, 0x65, 0x00, 0x3D, 0x00,
                    0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2C, 0x00,
                    0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x63, 0x00, 0x4B, 0x00,
                    0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x3D, 0x00,
                    0x62, 0x00, 0x37, 0x00, 0x37, 0x00, 0x61, 0x00, 0x35, 0x00, 0x63, 0x00, 0x35, 0x00, 0x36, 0x00,
                    0x31, 0x00, 0x39, 0x00, 0x33, 0x00, 0x34, 0x00, 0x65, 0x00, 0x30, 0x00, 0x38, 0x00, 0x39, 0x00
                }), "System.String",
            "530079007300740065006D002E0044006900610067006E006F00730074006900630073002E004500760065006E0074004C006F0067005000650072006D0069007300730069006F006E002C002000530079007300740065006D002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200370037006100350063003500360031003900330034006500300038003900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116544, "PrintingPermissionClass", SourceMemberKind.Field,
            32849, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00,
                    0x72, 0x00, 0x61, 0x00, 0x77, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x2E, 0x00, 0x50, 0x00,
                    0x72, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x2E, 0x00,
                    0x50, 0x00, 0x72, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00,
                    0x50, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00,
                    0x6F, 0x00, 0x6E, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00,
                    0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00, 0x72, 0x00, 0x61, 0x00, 0x77, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x67, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00,
                    0x74, 0x00, 0x75, 0x00, 0x72, 0x00, 0x65, 0x00, 0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00,
                    0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00,
                    0x62, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x63, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00,
                    0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x62, 0x00, 0x30, 0x00, 0x33, 0x00,
                    0x66, 0x00, 0x35, 0x00, 0x66, 0x00, 0x37, 0x00, 0x66, 0x00, 0x31, 0x00, 0x31, 0x00, 0x64, 0x00,
                    0x35, 0x00, 0x30, 0x00, 0x61, 0x00, 0x33, 0x00, 0x61, 0x00
                }), "System.String",
            "530079007300740065006D002E00440072006100770069006E0067002E005000720069006E00740069006E0067002E005000720069006E00740069006E0067005000650072006D0069007300730069006F006E002C002000530079007300740065006D002E00440072006100770069006E0067002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200300033006600350066003700660031003100640035003000610033006100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116545, "SocketPermissionClass", SourceMemberKind.Field, 32849,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x4E, 0x00,
                    0x65, 0x00, 0x74, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x6B, 0x00, 0x65, 0x00,
                    0x74, 0x00, 0x50, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00,
                    0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00,
                    0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x34, 0x00, 0x2E, 0x00, 0x30, 0x00,
                    0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x43, 0x00, 0x75, 0x00,
                    0x6C, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00, 0x65, 0x00, 0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00,
                    0x75, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x50, 0x00,
                    0x75, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x63, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00,
                    0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x62, 0x00, 0x37, 0x00,
                    0x37, 0x00, 0x61, 0x00, 0x35, 0x00, 0x63, 0x00, 0x35, 0x00, 0x36, 0x00, 0x31, 0x00, 0x39, 0x00,
                    0x33, 0x00, 0x34, 0x00, 0x65, 0x00, 0x30, 0x00, 0x38, 0x00, 0x39, 0x00
                }), "System.String",
            "530079007300740065006D002E004E00650074002E0053006F0063006B00650074005000650072006D0069007300730069006F006E002C002000530079007300740065006D002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200370037006100350063003500360031003900330034006500300038003900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116546, "WebPermissionClass", SourceMemberKind.Field, 32849,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x4E, 0x00,
                    0x65, 0x00, 0x74, 0x00, 0x2E, 0x00, 0x57, 0x00, 0x65, 0x00, 0x62, 0x00, 0x50, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x3D, 0x00, 0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x30, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00,
                    0x61, 0x00, 0x6C, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x62, 0x00, 0x37, 0x00, 0x37, 0x00, 0x61, 0x00, 0x35, 0x00,
                    0x63, 0x00, 0x35, 0x00, 0x36, 0x00, 0x31, 0x00, 0x39, 0x00, 0x33, 0x00, 0x34, 0x00, 0x65, 0x00,
                    0x30, 0x00, 0x38, 0x00, 0x39, 0x00
                }), "System.String",
            "530079007300740065006D002E004E00650074002E005700650062005000650072006D0069007300730069006F006E002C002000530079007300740065006D002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200370037006100350063003500360031003900330034006500300038003900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116547, "PerformanceCounterPermissionClass",
            SourceMemberKind.Field, 32849, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00,
                    0x69, 0x00, 0x61, 0x00, 0x67, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00,
                    0x63, 0x00, 0x73, 0x00, 0x2E, 0x00, 0x50, 0x00, 0x65, 0x00, 0x72, 0x00, 0x66, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x65, 0x00, 0x43, 0x00, 0x6F, 0x00,
                    0x75, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x50, 0x00, 0x65, 0x00, 0x72, 0x00,
                    0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x2C, 0x00,
                    0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2C, 0x00,
                    0x20, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x3D, 0x00, 0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00,
                    0x65, 0x00, 0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00,
                    0x6C, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x69, 0x00,
                    0x63, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x3D, 0x00, 0x62, 0x00, 0x37, 0x00, 0x37, 0x00, 0x61, 0x00, 0x35, 0x00, 0x63, 0x00,
                    0x35, 0x00, 0x36, 0x00, 0x31, 0x00, 0x39, 0x00, 0x33, 0x00, 0x34, 0x00, 0x65, 0x00, 0x30, 0x00,
                    0x38, 0x00, 0x39, 0x00
                }), "System.String",
            "530079007300740065006D002E0044006900610067006E006F00730074006900630073002E0050006500720066006F0072006D0061006E006300650043006F0075006E007400650072005000650072006D0069007300730069006F006E002C002000530079007300740065006D002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200370037006100350063003500360031003900330034006500300038003900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116548, "DirectoryServicesPermissionClass",
            SourceMemberKind.Field, 32849, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00,
                    0x69, 0x00, 0x72, 0x00, 0x65, 0x00, 0x63, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x79, 0x00,
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x76, 0x00, 0x69, 0x00, 0x63, 0x00, 0x65, 0x00, 0x73, 0x00,
                    0x2E, 0x00, 0x44, 0x00, 0x69, 0x00, 0x72, 0x00, 0x65, 0x00, 0x63, 0x00, 0x74, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x79, 0x00, 0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x76, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x65, 0x00, 0x73, 0x00, 0x50, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00,
                    0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00,
                    0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00, 0x69, 0x00, 0x72, 0x00,
                    0x65, 0x00, 0x63, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x79, 0x00, 0x53, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x76, 0x00, 0x69, 0x00, 0x63, 0x00, 0x65, 0x00, 0x73, 0x00, 0x2C, 0x00, 0x20, 0x00,
                    0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x3D, 0x00,
                    0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2C, 0x00,
                    0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00, 0x65, 0x00,
                    0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x3D, 0x00, 0x62, 0x00, 0x30, 0x00, 0x33, 0x00, 0x66, 0x00, 0x35, 0x00, 0x66, 0x00, 0x37, 0x00,
                    0x66, 0x00, 0x31, 0x00, 0x31, 0x00, 0x64, 0x00, 0x35, 0x00, 0x30, 0x00, 0x61, 0x00, 0x33, 0x00,
                    0x61, 0x00
                }), "System.String",
            "530079007300740065006D002E004400690072006500630074006F0072007900530065007200760069006300650073002E004400690072006500630074006F0072007900530065007200760069006300650073005000650072006D0069007300730069006F006E002C002000530079007300740065006D002E004400690072006500630074006F0072007900530065007200760069006300650073002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200300033006600350066003700660031003100640035003000610033006100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116549, "MessageQueuePermissionClass", SourceMemberKind.Field,
            32849, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x4D, 0x00,
                    0x65, 0x00, 0x73, 0x00, 0x73, 0x00, 0x61, 0x00, 0x67, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00,
                    0x2E, 0x00, 0x4D, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00, 0x61, 0x00, 0x67, 0x00, 0x65, 0x00,
                    0x51, 0x00, 0x75, 0x00, 0x65, 0x00, 0x75, 0x00, 0x65, 0x00, 0x50, 0x00, 0x65, 0x00, 0x72, 0x00,
                    0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x2C, 0x00,
                    0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00,
                    0x4D, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00, 0x61, 0x00, 0x67, 0x00, 0x69, 0x00, 0x6E, 0x00,
                    0x67, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00,
                    0x6F, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00,
                    0x2E, 0x00, 0x30, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00,
                    0x75, 0x00, 0x72, 0x00, 0x65, 0x00, 0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00,
                    0x72, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00,
                    0x6C, 0x00, 0x69, 0x00, 0x63, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00,
                    0x6B, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x62, 0x00, 0x30, 0x00, 0x33, 0x00, 0x66, 0x00,
                    0x35, 0x00, 0x66, 0x00, 0x37, 0x00, 0x66, 0x00, 0x31, 0x00, 0x31, 0x00, 0x64, 0x00, 0x35, 0x00,
                    0x30, 0x00, 0x61, 0x00, 0x33, 0x00, 0x61, 0x00
                }), "System.String",
            "530079007300740065006D002E004D006500730073006100670069006E0067002E004D00650073007300610067006500510075006500750065005000650072006D0069007300730069006F006E002C002000530079007300740065006D002E004D006500730073006100670069006E0067002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200300033006600350066003700660031003100640035003000610033006100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116550, "ServiceControllerPermissionClass",
            SourceMemberKind.Field, 32849, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x76, 0x00, 0x69, 0x00, 0x63, 0x00, 0x65, 0x00, 0x50, 0x00, 0x72, 0x00,
                    0x6F, 0x00, 0x63, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x76, 0x00, 0x69, 0x00, 0x63, 0x00, 0x65, 0x00, 0x43, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x74, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x72, 0x00, 0x50, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x76, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x65, 0x00, 0x50, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x3D, 0x00, 0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x30, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00,
                    0x61, 0x00, 0x6C, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00,
                    0x69, 0x00, 0x63, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x3D, 0x00, 0x62, 0x00, 0x30, 0x00, 0x33, 0x00, 0x66, 0x00, 0x35, 0x00,
                    0x66, 0x00, 0x37, 0x00, 0x66, 0x00, 0x31, 0x00, 0x31, 0x00, 0x64, 0x00, 0x35, 0x00, 0x30, 0x00,
                    0x61, 0x00, 0x33, 0x00, 0x61, 0x00
                }), "System.String",
            "530079007300740065006D002E005300650072007600690063006500500072006F0063006500730073002E00530065007200760069006300650043006F006E00740072006F006C006C00650072005000650072006D0069007300730069006F006E002C002000530079007300740065006D002E005300650072007600690063006500500072006F0063006500730073002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200300033006600350066003700660031003100640035003000610033006100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116551, "OleDbPermissionClass", SourceMemberKind.Field, 32849,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x61, 0x00, 0x2E, 0x00, 0x4F, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x44, 0x00,
                    0x62, 0x00, 0x2E, 0x00, 0x4F, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x44, 0x00, 0x62, 0x00, 0x50, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00, 0x61, 0x00, 0x74, 0x00, 0x61, 0x00, 0x2C, 0x00, 0x20, 0x00,
                    0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x3D, 0x00,
                    0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2C, 0x00,
                    0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00, 0x65, 0x00,
                    0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x3D, 0x00, 0x62, 0x00, 0x37, 0x00, 0x37, 0x00, 0x61, 0x00, 0x35, 0x00, 0x63, 0x00, 0x35, 0x00,
                    0x36, 0x00, 0x31, 0x00, 0x39, 0x00, 0x33, 0x00, 0x34, 0x00, 0x65, 0x00, 0x30, 0x00, 0x38, 0x00,
                    0x39, 0x00
                }), "System.String",
            "530079007300740065006D002E0044006100740061002E004F006C006500440062002E004F006C006500440062005000650072006D0069007300730069006F006E002C002000530079007300740065006D002E0044006100740061002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200370037006100350063003500360031003900330034006500300038003900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116552, "SqlClientPermissionClass", SourceMemberKind.Field,
            32849, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x61, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x71, 0x00, 0x6C, 0x00, 0x43, 0x00,
                    0x6C, 0x00, 0x69, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x71, 0x00,
                    0x6C, 0x00, 0x43, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x50, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x2C, 0x00, 0x20, 0x00, 0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00, 0x61, 0x00, 0x74, 0x00, 0x61, 0x00, 0x2C, 0x00, 0x20, 0x00,
                    0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x3D, 0x00,
                    0x34, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x2C, 0x00,
                    0x20, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00, 0x65, 0x00,
                    0x3D, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x75, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00,
                    0x2C, 0x00, 0x20, 0x00, 0x50, 0x00, 0x75, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x3D, 0x00, 0x62, 0x00, 0x37, 0x00, 0x37, 0x00, 0x61, 0x00, 0x35, 0x00, 0x63, 0x00, 0x35, 0x00,
                    0x36, 0x00, 0x31, 0x00, 0x39, 0x00, 0x33, 0x00, 0x34, 0x00, 0x65, 0x00, 0x30, 0x00, 0x38, 0x00,
                    0x39, 0x00
                }), "System.String",
            "530079007300740065006D002E0044006100740061002E00530071006C0043006C00690065006E0074002E00530071006C0043006C00690065006E0074005000650072006D0069007300730069006F006E002C002000530079007300740065006D002E0044006100740061002C002000560065007200730069006F006E003D0034002E0030002E0030002E0030002C002000430075006C0074007500720065003D006E00650075007400720061006C002C0020005000750062006C00690063004B006500790054006F006B0065006E003D006200370037006100350063003500360031003900330034006500300038003900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116553, "_fxVersion", SourceMemberKind.Field, 17,
            "System.Version", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116554, "_ecmaKey", SourceMemberKind.Field, 17, "System.Byte[]",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116555, "_ecma", SourceMemberKind.Field, 17,
            "System.Security.Permissions.StrongNamePublicKeyBlob", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116556, "_msFinalKey", SourceMemberKind.Field, 17,
            "System.Byte[]", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116557, "_msFinal", SourceMemberKind.Field, 17,
            "System.Security.Permissions.StrongNamePublicKeyBlob", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116558, "_fullTrust", SourceMemberKind.Field, 17,
            "System.Security.NamedPermissionSet", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116559, "_localIntranet", SourceMemberKind.Field, 17,
            "System.Security.NamedPermissionSet", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116560, "_internet", SourceMemberKind.Field, 17,
            "System.Security.NamedPermissionSet", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116561, "_skipVerification", SourceMemberKind.Field, 17,
            "System.Security.NamedPermissionSet", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116562, "_execution", SourceMemberKind.Field, 17,
            "System.Security.NamedPermissionSet", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116563, "_nothing", SourceMemberKind.Field, 17,
            "System.Security.NamedPermissionSet", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 67116564, "_everything", SourceMemberKind.Field, 17,
            "System.Security.NamedPermissionSet", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 385878361, "FullTrust", SourceMemberKind.Property, 0,
            "System.Security.PermissionSet", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 385878362, "LocalIntranet", SourceMemberKind.Property, 0,
            "System.Security.PermissionSet", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 385878363, "Internet", SourceMemberKind.Property, 0,
            "System.Security.PermissionSet", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 385878364, "SkipVerification", SourceMemberKind.Property, 0,
            "System.Security.PermissionSet", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 385878365, "Execution", SourceMemberKind.Property, 0,
            "System.Security.PermissionSet", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 385878366, "Nothing", SourceMemberKind.Property, 0,
            "System.Security.PermissionSet", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies", 385878367, "Everything", SourceMemberKind.Property, 0,
            "System.Security.PermissionSet", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 33555696, 1048962,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 67116565, "FullTrust", SourceMemberKind.Field,
            32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x46, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x54, 0x00, 0x72, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x74, 0x00
                }), "System.String", "460075006C006C0054007200750073007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 67116566, "LocalIntranet", SourceMemberKind.Field,
            32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4C, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x72, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x74, 0x00
                }), "System.String", "4C006F00630061006C0049006E007400720061006E0065007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 67116567, "Internet", SourceMemberKind.Field, 32854,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x74, 0x00
                }), "System.String", "49006E007400650072006E0065007400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 67116568, "SkipVerification",
            SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x6B, 0x00, 0x69, 0x00, 0x70, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00,
                    0x66, 0x00, 0x69, 0x00, 0x63, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00
                }), "System.String", "53006B006900700056006500720069006600690063006100740069006F006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 67116569, "Execution", SourceMemberKind.Field,
            32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x45, 0x00, 0x78, 0x00, 0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00
                }), "System.String", "45007800650063007500740069006F006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 67116570, "Nothing", SourceMemberKind.Field, 32854,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[] { 0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x68, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00 }),
            "System.String", "4E006F007400680069006E006700",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+ReservedNames", 67116571, "Everything", SourceMemberKind.Field,
            32854, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x45, 0x00, 0x76, 0x00, 0x65, 0x00, 0x72, 0x00, 0x79, 0x00, 0x74, 0x00, 0x68, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x67, 0x00
                }), "System.String", "450076006500720079007400680069006E006700",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+Key", 33555697, 258,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+Key", 67116572, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+Key", 67116573, "Ecma", SourceMemberKind.Field, 32854,
            "System.Security.Policy.DefaultPolicies+Key", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.DefaultPolicies+Key", 67116574, "MsFinal", SourceMemberKind.Field, 32854,
            "System.Security.Policy.DefaultPolicies+Key", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.EvidenceBase", 33555698, 1319041,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 33555699, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.ICollection", "System.Collections.IEnumerable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x2D, 0x53, 0x65, 0x72, 0x69, 0x61, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E,
                        0x20, 0x66, 0x6F, 0x72, 0x6D, 0x61, 0x74, 0x20, 0x6E, 0x6F, 0x74, 0x20, 0x63, 0x6F, 0x6D, 0x70,
                        0x61, 0x74, 0x69, 0x62, 0x6C, 0x65, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x2E, 0x4E, 0x45, 0x54,
                        0x00, 0x00
                    }),
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
            "System.Security.Policy.Evidence", 67116575, "_locked", SourceMemberKind.Field, 1, "System.Boolean", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 67116576, "hostEvidenceList", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 67116577, "assemblyEvidenceList", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 385878368, "Count", SourceMemberKind.Property, 0, "System.Int32", 2534,
            -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute", "System.Void System.ObsoleteAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 385878369, "IsReadOnly", SourceMemberKind.Property, 0, "System.Boolean",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 385878370, "IsSynchronized", SourceMemberKind.Property, 0,
            "System.Boolean", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 385878371, "Locked", SourceMemberKind.Property, 0, "System.Boolean",
            2182, 18566, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 385878372, "SyncRoot", SourceMemberKind.Property, 0, "System.Object",
            2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 385878373, "HostEvidenceList", SourceMemberKind.Property, 0,
            "System.Collections.ArrayList", 2179, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence", 385878374, "AssemblyEvidenceList", SourceMemberKind.Property, 0,
            "System.Collections.ArrayList", 2179, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence+EvidenceEnumerator", 33555700, 1048579,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IEnumerator" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence+EvidenceEnumerator", 67116578, "currentEnum", SourceMemberKind.Field, 1,
            "System.Collections.IEnumerator", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence+EvidenceEnumerator", 67116579, "hostEnum", SourceMemberKind.Field, 1,
            "System.Collections.IEnumerator", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence+EvidenceEnumerator", 67116580, "assemblyEnum", SourceMemberKind.Field, 1,
            "System.Collections.IEnumerator", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Evidence+EvidenceEnumerator", 385878375, "Current", SourceMemberKind.Property, 0,
            "System.Object", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.FileCodeGroup", 33555701, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.CodeGroup", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.FileCodeGroup", 67116581, "m_access", SourceMemberKind.Field, 1,
            "System.Security.Permissions.FileIOPermissionAccess", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.FileCodeGroup", 385878376, "MergeLogic", SourceMemberKind.Property, 0,
            "System.String", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.FileCodeGroup", 385878377, "AttributeString", SourceMemberKind.Property, 0,
            "System.String", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.FileCodeGroup", 385878378, "PermissionSetName", SourceMemberKind.Property, 0,
            "System.String", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.FirstMatchCodeGroup", 33555702, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.CodeGroup", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.FirstMatchCodeGroup", 385878379, "MergeLogic", SourceMemberKind.Property, 0,
            "System.String", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.GacInstalled", 33555703, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.EvidenceBase",
            new string[]
                { "System.Security.Policy.IIdentityPermissionFactory", "System.Security.Policy.IBuiltInEvidence" },
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
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.GacMembershipCondition", 33555704, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Security.Policy.IMembershipCondition", "System.Security.ISecurityEncodable",
                "System.Security.ISecurityPolicyEncodable", "System.Security.Policy.IConstantMembershipCondition"
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
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.GacMembershipCondition", 67116582, "version", SourceMemberKind.Field, 33,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Hash", 33555705, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.EvidenceBase",
            new string[] { "System.Runtime.Serialization.ISerializable", "System.Security.Policy.IBuiltInEvidence" },
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
            "System.Security.Policy.Hash", 67116583, "assembly", SourceMemberKind.Field, 1,
            "System.Reflection.Assembly", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Hash", 67116584, "data", SourceMemberKind.Field, 1, "System.Byte[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Hash", 67116585, "_md5", SourceMemberKind.Field, 3, "System.Byte[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Hash", 67116586, "_sha1", SourceMemberKind.Field, 3, "System.Byte[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Hash", 385878380, "MD5", SourceMemberKind.Property, 0, "System.Byte[]", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.Hash", 385878381, "SHA1", SourceMemberKind.Property, 0, "System.Byte[]", 2182, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.HashMembershipCondition", 33555706, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Security.Policy.IMembershipCondition", "System.Security.ISecurityEncodable",
                "System.Security.ISecurityPolicyEncodable", "System.Runtime.Serialization.IDeserializationCallback",
                "System.Runtime.Serialization.ISerializable"
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
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.HashMembershipCondition", 67116587, "version", SourceMemberKind.Field, 33,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.HashMembershipCondition", 67116588, "hash_algorithm", SourceMemberKind.Field, 1,
            "System.Security.Cryptography.HashAlgorithm", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.HashMembershipCondition", 67116589, "hash_value", SourceMemberKind.Field, 1,
            "System.Byte[]", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.HashMembershipCondition", 385878382, "HashAlgorithm", SourceMemberKind.Property, 0,
            "System.Security.Cryptography.HashAlgorithm", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.HashMembershipCondition", 385878383, "HashValue", SourceMemberKind.Property, 0,
            "System.Byte[]", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.IApplicationTrustManager", 33555707, 161, null, null,
            new string[] { "System.Security.ISecurityEncodable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.IBuiltInEvidence", 33555708, 160, null, null, Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.IConstantMembershipCondition", 33555709, 160, null, null, Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.IIdentityPermissionFactory", 33555710, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.IMembershipCondition", 33555711, 161, null, null,
            new string[] { "System.Security.ISecurityEncodable", "System.Security.ISecurityPolicyEncodable" },
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
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.MembershipConditionHelper", 33555712, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.MembershipConditionHelper", 67116590, "XmlTag", SourceMemberKind.Field, 49,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.MonoTrustManager", 33555713, 1048576,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Security.Policy.IApplicationTrustManager", "System.Security.ISecurityEncodable" },
            Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.MonoTrustManager", 67116591, "tag", SourceMemberKind.Field, 32849, "System.String",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x41, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x63, 0x00, 0x61, 0x00,
                    0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x54, 0x00, 0x72, 0x00, 0x75, 0x00, 0x73, 0x00,
                    0x74, 0x00, 0x4D, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x67, 0x00, 0x65, 0x00, 0x72, 0x00
                }), "System.String",
            "49004100700070006C00690063006100740069006F006E00540072007500730074004D0061006E006100670065007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.NetCodeGroup", 33555714, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Policy.CodeGroup", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
    }
}
