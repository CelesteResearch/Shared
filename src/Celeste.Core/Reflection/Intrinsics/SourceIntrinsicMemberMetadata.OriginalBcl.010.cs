using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl010(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "SR", 67109820,
            "Argument_GWithPrecisionNotSupported", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x54, 0x00, 0x68, 0x00, 0x65, 0x00, 0x20, 0x00, 0x27, 0x00, 0x47, 0x00, 0x27, 0x00, 0x20, 0x00,
                    0x66, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x20, 0x00, 0x63, 0x00,
                    0x6F, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x64, 0x00, 0x20, 0x00,
                    0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x68, 0x00, 0x20, 0x00, 0x61, 0x00, 0x20, 0x00, 0x70, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x63, 0x00, 0x69, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x20, 0x00, 0x69, 0x00, 0x73, 0x00, 0x20, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x20, 0x00,
                    0x73, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x64, 0x00, 0x2E, 0x00
                }), "System.String",
            "5400680065002000270047002700200066006F0072006D0061007400200063006F006D00620069006E00650064002000770069007400680020006100200070007200650063006900730069006F006E0020006900730020006E006F007400200073007500700070006F0072007400650064002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "SR", 67109821,
            "Argument_CannotParsePrecision", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x43, 0x00, 0x68, 0x00, 0x61, 0x00, 0x72, 0x00, 0x61, 0x00, 0x63, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x73, 0x00, 0x20, 0x00, 0x66, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F, 0x00,
                    0x77, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x20, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00,
                    0x20, 0x00, 0x66, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x20, 0x00,
                    0x73, 0x00, 0x79, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x20, 0x00, 0x6D, 0x00,
                    0x75, 0x00, 0x73, 0x00, 0x74, 0x00, 0x20, 0x00, 0x62, 0x00, 0x65, 0x00, 0x20, 0x00, 0x61, 0x00,
                    0x20, 0x00, 0x6E, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x65, 0x00, 0x72, 0x00, 0x20, 0x00,
                    0x6F, 0x00, 0x66, 0x00, 0x20, 0x00, 0x7B, 0x00, 0x30, 0x00, 0x7D, 0x00, 0x20, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x20, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00, 0x2E, 0x00
                }), "System.String",
            "4300680061007200610063007400650072007300200066006F006C006C006F00770069006E0067002000740068006500200066006F0072006D00610074002000730079006D0062006F006C0020006D007500730074002000620065002000610020006E0075006D0062006500720020006F00660020007B0030007D0020006F00720020006C006500730073002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "SR", 67109822,
            "Argument_PrecisionTooLarge", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x50, 0x00, 0x72, 0x00, 0x65, 0x00, 0x63, 0x00, 0x69, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x20, 0x00, 0x63, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x20, 0x00, 0x62, 0x00, 0x65, 0x00, 0x20, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x72, 0x00, 0x67, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x20, 0x00, 0x74, 0x00, 0x68, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x20, 0x00,
                    0x7B, 0x00, 0x30, 0x00, 0x7D, 0x00, 0x2E, 0x00
                }), "System.String",
            "50007200650063006900730069006F006E002000630061006E006E006F00740020006200650020006C006100720067006500720020007400680061006E0020007B0030007D002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "SR", 67109823,
            "Argument_OverlapAlignmentMismatch", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4F, 0x00, 0x76, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x70, 0x00, 0x70, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x20, 0x00, 0x73, 0x00, 0x70, 0x00, 0x61, 0x00, 0x6E, 0x00,
                    0x73, 0x00, 0x20, 0x00, 0x68, 0x00, 0x61, 0x00, 0x76, 0x00, 0x65, 0x00, 0x20, 0x00, 0x6D, 0x00,
                    0x69, 0x00, 0x73, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x69, 0x00,
                    0x6E, 0x00, 0x67, 0x00, 0x20, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x67, 0x00, 0x6E, 0x00,
                    0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x2E, 0x00
                }), "System.String",
            "4F007600650072006C0061007000700069006E00670020007300700061006E0073002000680061007600650020006D00690073006D00610074006300680069006E006700200061006C00690067006E006D0065006E0074002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "SR", 67109824,
            "Argument_EmptyValue", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x56, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x75, 0x00, 0x65, 0x00, 0x20, 0x00, 0x63, 0x00, 0x61, 0x00,
                    0x6E, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x20, 0x00, 0x62, 0x00, 0x65, 0x00, 0x20, 0x00,
                    0x65, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00
                }), "System.String",
            "560061006C00750065002000630061006E006E006F007400200062006500200065006D007000740079002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "SR", 67109825,
            "PlatformNotSupported_RuntimeInformation", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x52, 0x00, 0x75, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x49, 0x00,
                    0x6E, 0x00, 0x66, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00,
                    0x6F, 0x00, 0x6E, 0x00, 0x20, 0x00, 0x69, 0x00, 0x73, 0x00, 0x20, 0x00, 0x6E, 0x00, 0x6F, 0x00,
                    0x74, 0x00, 0x20, 0x00, 0x73, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00, 0x72, 0x00,
                    0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x20, 0x00, 0x66, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x20, 0x00,
                    0x50, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x74, 0x00, 0x61, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x65, 0x00,
                    0x20, 0x00, 0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x73, 0x00, 0x73, 0x00, 0x20, 0x00, 0x4C, 0x00,
                    0x69, 0x00, 0x62, 0x00, 0x72, 0x00, 0x61, 0x00, 0x72, 0x00, 0x69, 0x00, 0x65, 0x00, 0x73, 0x00,
                    0x2E, 0x00
                }), "System.String",
            "520075006E00740069006D00650049006E0066006F0072006D006100740069006F006E0020006900730020006E006F007400200073007500700070006F007200740065006400200066006F007200200050006F0072007400610062006C006500200043006C0061007300730020004C00690062007200610072006900650073002E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop", 33554438, 1048960,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+mincore", 33554439,
            389, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            33554440, 1048965, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109826, "CoreLibNative", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x50, 0x00,
                    0x72, 0x00, 0x69, 0x00, 0x76, 0x00, 0x61, 0x00, 0x74, 0x00, 0x65, 0x00, 0x2E, 0x00, 0x43, 0x00,
                    0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x4C, 0x00, 0x69, 0x00, 0x62, 0x00, 0x2E, 0x00, 0x4E, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x76, 0x00, 0x65, 0x00
                }), "System.String",
            "530079007300740065006D002E0050007200690076006100740065002E0043006F00720065004C00690062002E004E0061007400690076006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109827, "CoreFile_L1", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x66, 0x00, 0x69, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00,
                    0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D00660069006C0065002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109828, "CoreFile_L1_2", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x66, 0x00, 0x69, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00,
                    0x32, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D00660069006C0065002D006C0031002D0032002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109829, "CoreFile_L2", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x66, 0x00, 0x69, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x32, 0x00, 0x2D, 0x00,
                    0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D00660069006C0065002D006C0032002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109830, "ErrorHandling", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x68, 0x00, 0x61, 0x00, 0x6E, 0x00,
                    0x64, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00,
                    0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D006500720072006F007200680061006E0064006C0069006E0067002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109831, "Handle", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x68, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x2D, 0x00, 0x6C, 0x00,
                    0x31, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00,
                    0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D00680061006E0064006C0065002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109832, "IO", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x69, 0x00, 0x6F, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00,
                    0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D0069006F002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109833, "Memory", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x6D, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x79, 0x00, 0x2D, 0x00, 0x6C, 0x00,
                    0x31, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00,
                    0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D006D0065006D006F00720079002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109834, "ProcessEnvironment", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x70, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x76, 0x00, 0x69, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x6D, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00,
                    0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D00700072006F00630065007300730065006E007600690072006F006E006D0065006E0074002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109835, "ProcessThreads", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x70, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00, 0x74, 0x00,
                    0x68, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x64, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x6C, 0x00,
                    0x31, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00,
                    0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D00700072006F00630065007300730074006800720065006100640073002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109836, "RealTime", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x65, 0x00,
                    0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D007200650061006C00740069006D0065002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109837, "SysInfo", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x73, 0x00, 0x79, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x66, 0x00, 0x6F, 0x00, 0x2D, 0x00,
                    0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x32, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x64, 0x00,
                    0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D0073007900730069006E0066006F002D006C0031002D0032002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109838, "Registry_L1", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x67, 0x00, 0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x72, 0x00, 0x79, 0x00,
                    0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D00720065006700690073007400720079002D006C0031002D0031002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109839, "ThreadPool", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x74, 0x00, 0x68, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x64, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x6F, 0x00, 0x6C, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00, 0x32, 0x00, 0x2D, 0x00,
                    0x30, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D0074006800720065006100640070006F006F006C002D006C0031002D0032002D0030002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109840, "Localization", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x61, 0x00, 0x70, 0x00, 0x69, 0x00, 0x2D, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x2D, 0x00, 0x77, 0x00,
                    0x69, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x65, 0x00, 0x2D, 0x00,
                    0x6C, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00, 0x61, 0x00,
                    0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x2D, 0x00, 0x6C, 0x00, 0x31, 0x00, 0x2D, 0x00,
                    0x32, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String",
            "6100700069002D006D0073002D00770069006E002D0063006F00720065002D006C006F00630061006C0069007A006100740069006F006E002D006C0031002D0032002D0031002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109841, "BCrypt", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x42, 0x00, 0x43, 0x00, 0x72, 0x00, 0x79, 0x00, 0x70, 0x00, 0x74, 0x00, 0x2E, 0x00, 0x64, 0x00,
                    0x6C, 0x00, 0x6C, 0x00
                }), "System.String", "4200430072007900700074002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109842, "Crypt32", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x63, 0x00, 0x72, 0x00, 0x79, 0x00, 0x70, 0x00, 0x74, 0x00, 0x33, 0x00, 0x32, 0x00, 0x2E, 0x00,
                    0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String", "63007200790070007400330032002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109843, "Kernel32", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x6B, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x33, 0x00, 0x32, 0x00,
                    0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String", "6B00650072006E0065006C00330032002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109844, "Ole32", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x6F, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x33, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00,
                    0x6C, 0x00
                }), "System.String", "6F006C006500330032002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109845, "OleAut32", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x6F, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x61, 0x00, 0x75, 0x00, 0x74, 0x00, 0x33, 0x00, 0x32, 0x00,
                    0x2E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x6C, 0x00
                }), "System.String", "6F006C006500610075007400330032002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Libraries",
            67109846, "User32", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x75, 0x00, 0x73, 0x00, 0x65, 0x00, 0x72, 0x00, 0x33, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x64, 0x00,
                    0x6C, 0x00, 0x6C, 0x00
                }), "System.String", "7500730065007200330032002E0064006C006C00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Sys", 33554441,
            1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Interop+NativeIoCompletionCallback", 33554442, 261,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.MulticastDelegate",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 33554443,
            1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109847,
            "ERROR_SUCCESS", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109848,
            "ERROR_FILE_NOT_FOUND", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109849,
            "ERROR_PATH_NOT_FOUND", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109850,
            "ERROR_ACCESS_DENIED", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x05, 0x00, 0x00, 0x00 }), "System.Int32",
            "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109851,
            "ERROR_INVALID_HANDLE", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x06, 0x00, 0x00, 0x00 }), "System.Int32",
            "06000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109852,
            "ERROR_NOT_ENOUGH_MEMORY", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109853,
            "ERROR_INVALID_DRIVE", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x0F, 0x00, 0x00, 0x00 }), "System.Int32",
            "0F000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109854,
            "ERROR_NO_MORE_FILES", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x12, 0x00, 0x00, 0x00 }), "System.Int32",
            "12000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109855,
            "ERROR_NOT_READY", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x15, 0x00, 0x00, 0x00 }), "System.Int32",
            "15000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109856,
            "ERROR_SHARING_VIOLATION", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x00, 0x00, 0x00 }), "System.Int32",
            "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109857,
            "ERROR_HANDLE_EOF", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x26, 0x00, 0x00, 0x00 }), "System.Int32",
            "26000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109858,
            "ERROR_FILE_EXISTS", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x50, 0x00, 0x00, 0x00 }), "System.Int32",
            "50000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109859,
            "ERROR_INVALID_PARAMETER", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x57, 0x00, 0x00, 0x00 }), "System.Int32",
            "57000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109860,
            "ERROR_BROKEN_PIPE", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x6D, 0x00, 0x00, 0x00 }), "System.Int32",
            "6D000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109861,
            "ERROR_INSUFFICIENT_BUFFER", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x7A, 0x00, 0x00, 0x00 }), "System.Int32",
            "7A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109862,
            "ERROR_INVALID_NAME", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x7B, 0x00, 0x00, 0x00 }), "System.Int32",
            "7B000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109863,
            "ERROR_BAD_PATHNAME", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xA1, 0x00, 0x00, 0x00 }), "System.Int32",
            "A1000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109864,
            "ERROR_ALREADY_EXISTS", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xB7, 0x00, 0x00, 0x00 }), "System.Int32",
            "B7000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109865,
            "ERROR_ENVVAR_NOT_FOUND", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xCB, 0x00, 0x00, 0x00 }), "System.Int32",
            "CB000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109866,
            "ERROR_FILENAME_EXCED_RANGE", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xCE, 0x00, 0x00, 0x00 }), "System.Int32",
            "CE000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109867,
            "ERROR_NO_DATA", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xE8, 0x00, 0x00, 0x00 }), "System.Int32",
            "E8000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109868,
            "ERROR_MORE_DATA", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xEA, 0x00, 0x00, 0x00 }), "System.Int32",
            "EA000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109869,
            "ERROR_NO_MORE_ITEMS", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x01, 0x00, 0x00 }), "System.Int32",
            "03010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109870,
            "ERROR_NOT_OWNER", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x01, 0x00, 0x00 }), "System.Int32",
            "20010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109871,
            "ERROR_TOO_MANY_POSTS", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x2A, 0x01, 0x00, 0x00 }), "System.Int32",
            "2A010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109872,
            "ERROR_ARITHMETIC_OVERFLOW", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x16, 0x02, 0x00, 0x00 }), "System.Int32",
            "16020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109873,
            "ERROR_MUTANT_LIMIT_EXCEEDED", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x4B, 0x02, 0x00, 0x00 }), "System.Int32",
            "4B020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109874,
            "ERROR_OPERATION_ABORTED", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xE3, 0x03, 0x00, 0x00 }), "System.Int32",
            "E3030000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109875,
            "ERROR_IO_PENDING", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xE5, 0x03, 0x00, 0x00 }), "System.Int32",
            "E5030000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109876,
            "ERROR_NO_UNICODE_TRANSLATION", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x59, 0x04, 0x00, 0x00 }), "System.Int32",
            "59040000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109877,
            "ERROR_NOT_FOUND", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x90, 0x04, 0x00, 0x00 }), "System.Int32",
            "90040000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109878,
            "ERROR_BAD_IMPERSONATION_LEVEL", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x42, 0x05, 0x00, 0x00 }), "System.Int32",
            "42050000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109879,
            "E_FILENOTFOUND", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x07, 0x80 }), "System.Int32",
            "02000780", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Errors", 67109880,
            "ERROR_TIMEOUT", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xB4, 0x05, 0x00, 0x00 }), "System.Int32",
            "B4050000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 33554444,
            1048581, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109881,
            "FORMAT_MESSAGE_IGNORE_INSERTS", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x02, 0x00, 0x00 }), "System.Int32",
            "00020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109882,
            "FORMAT_MESSAGE_FROM_HMODULE", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x08, 0x00, 0x00 }), "System.Int32",
            "00080000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109883,
            "FORMAT_MESSAGE_FROM_SYSTEM", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x10, 0x00, 0x00 }), "System.Int32",
            "00100000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109884,
            "FORMAT_MESSAGE_ARGUMENT_ARRAY", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x20, 0x00, 0x00 }), "System.Int32",
            "00200000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109885,
            "ERROR_INSUFFICIENT_BUFFER", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x7A, 0x00, 0x00, 0x00 }), "System.Int32",
            "7A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109886,
            "InitialBufferSize", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x01, 0x00, 0x00 }), "System.Int32",
            "00010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109887,
            "BufferSizeIncreaseFactor", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Interop+Kernel32", 67109888,
            "MaxAllowedBufferSize", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x04, 0x01, 0x00 }), "System.Int32",
            "00040100", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            33554445, 1048704, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            67109889, "SwapConv", SourceMemberKind.Field, 49, "Mono.DataConverter", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            67109890, "CopyConv", SourceMemberKind.Field, 49, "Mono.DataConverter", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            67109891, "IsLittleEndian", SourceMemberKind.Field, 54, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            385875969, "LittleEndian", SourceMemberKind.Property, 0, "Mono.DataConverter", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            385875970, "BigEndian", SourceMemberKind.Property, 0, "Mono.DataConverter", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            385875971, "Native", SourceMemberKind.Property, 0, "Mono.DataConverter", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 33554446, 1048579,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 67109892, "buffer", SourceMemberKind.Field, 6, "System.Byte[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 67109893, "next", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 67109894, "description", SourceMemberKind.Field, 6, "System.String", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 67109895, "i", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 67109896, "conv", SourceMemberKind.Field, 6, "Mono.DataConverter", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 67109897, "repeat", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+PackContext", 67109898, "align", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+CopyConverter", 33554447, 1048579,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.DataConverter+SwapConverter", 33554448, 1048579,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.DataConverter",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Runtime", 33554449,
            1048960, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.RuntimeClassHandle",
            33554450, 1048840, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.ValueType", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.RuntimeClassHandle",
            67109899, "value", SourceMemberKind.Field, 1, "Mono.RuntimeStructs+MonoClass*", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
