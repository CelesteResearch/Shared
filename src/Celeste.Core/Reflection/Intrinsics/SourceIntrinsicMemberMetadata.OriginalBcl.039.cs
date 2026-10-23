using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl039(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111642,
            "Argument_BadPersistableModuleInTransientAssembly", SourceMemberKind.Field, 32851, "System.String", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x41, 0x00, 0x72, 0x00, 0x67, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x5F, 0x00, 0x42, 0x00, 0x61, 0x00, 0x64, 0x00, 0x50, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00,
                    0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x61, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x4D, 0x00,
                    0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x54, 0x00,
                    0x72, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x69, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x41, 0x00, 0x73, 0x00, 0x73, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x79, 0x00
                }), "System.String",
            "41007200670075006D0065006E0074005F004200610064005000650072007300690073007400610062006C0065004D006F00640075006C00650049006E005400720061006E007300690065006E00740041007300730065006D0062006C007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111643,
            "Argument_HasToBeArrayClass", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x41, 0x00, 0x72, 0x00, 0x67, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x5F, 0x00, 0x48, 0x00, 0x61, 0x00, 0x73, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x42, 0x00, 0x65, 0x00,
                    0x41, 0x00, 0x72, 0x00, 0x72, 0x00, 0x61, 0x00, 0x79, 0x00, 0x43, 0x00, 0x6C, 0x00, 0x61, 0x00,
                    0x73, 0x00, 0x73, 0x00
                }), "System.String",
            "41007200670075006D0065006E0074005F0048006100730054006F00420065004100720072006100790043006C00610073007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111644,
            "Argument_InvalidDirectory", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x41, 0x00, 0x72, 0x00, 0x67, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x5F, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00,
                    0x44, 0x00, 0x69, 0x00, 0x72, 0x00, 0x65, 0x00, 0x63, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x72, 0x00,
                    0x79, 0x00
                }), "System.String",
            "41007200670075006D0065006E0074005F0049006E00760061006C00690064004400690072006500630074006F0072007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111645,
            "MissingType", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x54, 0x00,
                    0x79, 0x00, 0x70, 0x00, 0x65, 0x00
                }), "System.String", "4D0069007300730069006E0067005400790070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111646,
            "MissingModule", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x4D, 0x00,
                    0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x65, 0x00
                }), "System.String", "4D0069007300730069006E0067004D006F00640075006C006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111647,
            "ArgumentOutOfRange_Index", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x41, 0x00, 0x72, 0x00, 0x67, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x4F, 0x00, 0x75, 0x00, 0x74, 0x00, 0x4F, 0x00, 0x66, 0x00, 0x52, 0x00, 0x61, 0x00, 0x6E, 0x00,
                    0x67, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x65, 0x00, 0x78, 0x00
                }), "System.String",
            "41007200670075006D0065006E0074004F00750074004F006600520061006E00670065005F0049006E00640065007800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111648,
            "ArgumentOutOfRange_Range", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x41, 0x00, 0x72, 0x00, 0x67, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x4F, 0x00, 0x75, 0x00, 0x74, 0x00, 0x4F, 0x00, 0x66, 0x00, 0x52, 0x00, 0x61, 0x00, 0x6E, 0x00,
                    0x67, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x52, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x65, 0x00
                }), "System.String",
            "41007200670075006D0065006E0074004F00750074004F006600520061006E00670065005F00520061006E0067006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111649,
            "ExecutionEngine_YoureHosed", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x45, 0x00, 0x78, 0x00, 0x65, 0x00, 0x63, 0x00, 0x75, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x45, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00,
                    0x59, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x72, 0x00, 0x65, 0x00, 0x48, 0x00, 0x6F, 0x00, 0x73, 0x00,
                    0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "45007800650063007500740069006F006E0045006E00670069006E0065005F0059006F0075007200650048006F00730065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111650,
            "Format_NeedSingleChar", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x46, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x5F, 0x00, 0x4E, 0x00,
                    0x65, 0x00, 0x65, 0x00, 0x64, 0x00, 0x53, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x6C, 0x00,
                    0x65, 0x00, 0x43, 0x00, 0x68, 0x00, 0x61, 0x00, 0x72, 0x00
                }), "System.String",
            "46006F0072006D00610074005F004E00650065006400530069006E0067006C0065004300680061007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111651,
            "Format_StringZeroLength", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x46, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x74, 0x00, 0x5F, 0x00, 0x53, 0x00,
                    0x74, 0x00, 0x72, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x5A, 0x00, 0x65, 0x00, 0x72, 0x00,
                    0x6F, 0x00, 0x4C, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x74, 0x00, 0x68, 0x00
                }), "System.String",
            "46006F0072006D00610074005F0053007400720069006E0067005A00650072006F004C0065006E00670074006800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111652,
            "InvalidOperation_EnumEnded", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x45, 0x00, 0x6E, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x45, 0x00, 0x6E, 0x00, 0x64, 0x00,
                    0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F0045006E0075006D0045006E00640065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111653,
            "InvalidOperation_EnumFailedVersion", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x45, 0x00, 0x6E, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x46, 0x00, 0x61, 0x00, 0x69, 0x00,
                    0x6C, 0x00, 0x65, 0x00, 0x64, 0x00, 0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00,
                    0x6F, 0x00, 0x6E, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F0045006E0075006D004600610069006C0065006400560065007200730069006F006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111654,
            "InvalidOperation_EnumNotStarted", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x45, 0x00, 0x6E, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x53, 0x00, 0x74, 0x00, 0x61, 0x00, 0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F0045006E0075006D004E006F0074005300740061007200740065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111655,
            "InvalidOperation_EnumOpCantHappen", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x45, 0x00, 0x6E, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x4F, 0x00, 0x70, 0x00, 0x43, 0x00,
                    0x61, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x48, 0x00, 0x61, 0x00, 0x70, 0x00, 0x70, 0x00, 0x65, 0x00,
                    0x6E, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F0045006E0075006D004F007000430061006E007400480061007000700065006E00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111656,
            "InvalidOperation_InternalState", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x6E, 0x00, 0x61, 0x00,
                    0x6C, 0x00, 0x53, 0x00, 0x74, 0x00, 0x61, 0x00, 0x74, 0x00, 0x65, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F0049006E007400650072006E0061006C0053007400610074006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111657,
            "InvalidOperation_ModifyRONumFmtInfo", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x4D, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x69, 0x00, 0x66, 0x00, 0x79, 0x00, 0x52, 0x00,
                    0x4F, 0x00, 0x4E, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x46, 0x00, 0x6D, 0x00, 0x74, 0x00, 0x49, 0x00,
                    0x6E, 0x00, 0x66, 0x00, 0x6F, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F004D006F00640069006600790052004F004E0075006D0046006D00740049006E0066006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111658,
            "InvalidOperation_MethodBaked", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x4D, 0x00, 0x65, 0x00, 0x74, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x42, 0x00,
                    0x61, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F004D006500740068006F006400420061006B0065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111659,
            "InvalidOperation_NotADebugModule", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x41, 0x00, 0x44, 0x00, 0x65, 0x00, 0x62, 0x00,
                    0x75, 0x00, 0x67, 0x00, 0x4D, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x65, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F004E006F0074004100440065006200750067004D006F00640075006C006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111660,
            "InvalidOperation_MethodHasBody", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x4D, 0x00, 0x65, 0x00, 0x74, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x48, 0x00,
                    0x61, 0x00, 0x73, 0x00, 0x42, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x79, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F004D006500740068006F00640048006100730042006F0064007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111661,
            "InvalidOperation_OpenLocalVariableScope", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x4F, 0x00, 0x70, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x4C, 0x00, 0x6F, 0x00, 0x63, 0x00,
                    0x61, 0x00, 0x6C, 0x00, 0x56, 0x00, 0x61, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x62, 0x00,
                    0x6C, 0x00, 0x65, 0x00, 0x53, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x70, 0x00, 0x65, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F004F00700065006E004C006F00630061006C005600610072006900610062006C006500530063006F0070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111662,
            "InvalidOperation_TypeHasBeenCreated", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x54, 0x00, 0x79, 0x00, 0x70, 0x00, 0x65, 0x00, 0x48, 0x00, 0x61, 0x00, 0x73, 0x00,
                    0x42, 0x00, 0x65, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x43, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00,
                    0x74, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F0054007900700065004800610073004200650065006E004300720065006100740065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111663,
            "InvalidOperation_RefedAssemblyNotSaved", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x52, 0x00, 0x65, 0x00, 0x66, 0x00, 0x65, 0x00, 0x64, 0x00, 0x41, 0x00, 0x73, 0x00,
                    0x73, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x79, 0x00, 0x4E, 0x00, 0x6F, 0x00,
                    0x74, 0x00, 0x53, 0x00, 0x61, 0x00, 0x76, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F005200650066006500640041007300730065006D0062006C0079004E006F00740053006100760065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111664,
            "InvalidOperation_AssemblyHasBeenSaved", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x41, 0x00, 0x73, 0x00, 0x73, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x6C, 0x00,
                    0x79, 0x00, 0x48, 0x00, 0x61, 0x00, 0x73, 0x00, 0x42, 0x00, 0x65, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x53, 0x00, 0x61, 0x00, 0x76, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F0041007300730065006D0062006C0079004800610073004200650065006E0053006100760065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111665,
            "InvalidOperation_ModuleHasBeenSaved", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x4D, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x48, 0x00,
                    0x61, 0x00, 0x73, 0x00, 0x42, 0x00, 0x65, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x53, 0x00, 0x61, 0x00,
                    0x76, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F004D006F00640075006C0065004800610073004200650065006E0053006100760065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111666,
            "InvalidOperation_CannotAlterAssembly", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x4F, 0x00,
                    0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x5F, 0x00, 0x43, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x41, 0x00,
                    0x6C, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x41, 0x00, 0x73, 0x00, 0x73, 0x00, 0x65, 0x00,
                    0x6D, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x79, 0x00
                }), "System.String",
            "49006E00760061006C00690064004F007000650072006100740069006F006E005F00430061006E006E006F00740041006C0074006500720041007300730065006D0062006C007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111667,
            "NotSupported_CannotSaveModuleIndividually", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x43, 0x00, 0x61, 0x00, 0x6E, 0x00,
                    0x6E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x61, 0x00, 0x76, 0x00, 0x65, 0x00, 0x4D, 0x00,
                    0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x64, 0x00,
                    0x69, 0x00, 0x76, 0x00, 0x69, 0x00, 0x64, 0x00, 0x75, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x6C, 0x00,
                    0x79, 0x00
                }), "System.String",
            "4E006F00740053007500700070006F0072007400650064005F00430061006E006E006F00740053006100760065004D006F00640075006C00650049006E0064006900760069006400750061006C006C007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111668,
            "NotSupported_Constructor", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x43, 0x00, 0x6F, 0x00, 0x6E, 0x00,
                    0x73, 0x00, 0x74, 0x00, 0x72, 0x00, 0x75, 0x00, 0x63, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x72, 0x00
                }), "System.String",
            "4E006F00740053007500700070006F0072007400650064005F0043006F006E007300740072007500630074006F007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111669,
            "NotSupported_Method", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x4D, 0x00, 0x65, 0x00, 0x74, 0x00,
                    0x68, 0x00, 0x6F, 0x00, 0x64, 0x00
                }), "System.String", "4E006F00740053007500700070006F0072007400650064005F004D006500740068006F006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111670,
            "NotSupported_NYI", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x59, 0x00, 0x49, 0x00
                }), "System.String", "4E006F00740053007500700070006F0072007400650064005F004E0059004900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111671,
            "NotSupported_DynamicModule", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x44, 0x00, 0x79, 0x00, 0x6E, 0x00,
                    0x61, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x63, 0x00, 0x4D, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x75, 0x00,
                    0x6C, 0x00, 0x65, 0x00
                }), "System.String",
            "4E006F00740053007500700070006F0072007400650064005F00440079006E0061006D00690063004D006F00640075006C006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111672,
            "NotSupported_NotDynamicModule", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x44, 0x00, 0x79, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x63, 0x00, 0x4D, 0x00,
                    0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x65, 0x00
                }), "System.String",
            "4E006F00740053007500700070006F0072007400650064005F004E006F007400440079006E0061006D00690063004D006F00640075006C006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111673,
            "NotSupported_NotAllTypesAreBaked", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00,
                    0x41, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x54, 0x00, 0x79, 0x00, 0x70, 0x00, 0x65, 0x00, 0x73, 0x00,
                    0x41, 0x00, 0x72, 0x00, 0x65, 0x00, 0x42, 0x00, 0x61, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x64, 0x00
                }), "System.String",
            "4E006F00740053007500700070006F0072007400650064005F004E006F00740041006C006C0054007900700065007300410072006500420061006B0065006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111674,
            "NotSupported_SortedListNestedWrite", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x53, 0x00, 0x75, 0x00, 0x70, 0x00, 0x70, 0x00, 0x6F, 0x00,
                    0x72, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x53, 0x00, 0x6F, 0x00, 0x72, 0x00,
                    0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x4C, 0x00, 0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x4E, 0x00,
                    0x65, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x64, 0x00, 0x57, 0x00, 0x72, 0x00, 0x69, 0x00,
                    0x74, 0x00, 0x65, 0x00
                }), "System.String",
            "4E006F00740053007500700070006F0072007400650064005F0053006F0072007400650064004C006900730074004E006500730074006500640057007200690074006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111675,
            "Serialization_ArrayInvalidLength", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x41, 0x00, 0x72, 0x00,
                    0x72, 0x00, 0x61, 0x00, 0x79, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00,
                    0x69, 0x00, 0x64, 0x00, 0x4C, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x74, 0x00, 0x68, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F004100720072006100790049006E00760061006C00690064004C0065006E00670074006800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111676,
            "Serialization_ArrayNoLength", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x41, 0x00, 0x72, 0x00,
                    0x72, 0x00, 0x61, 0x00, 0x79, 0x00, 0x4E, 0x00, 0x6F, 0x00, 0x4C, 0x00, 0x65, 0x00, 0x6E, 0x00,
                    0x67, 0x00, 0x74, 0x00, 0x68, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F00410072007200610079004E006F004C0065006E00670074006800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111677,
            "Serialization_CannotGetType", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x43, 0x00, 0x61, 0x00,
                    0x6E, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x74, 0x00, 0x47, 0x00, 0x65, 0x00, 0x74, 0x00, 0x54, 0x00,
                    0x79, 0x00, 0x70, 0x00, 0x65, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F00430061006E006E006F0074004700650074005400790070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111678,
            "Serialization_InsufficientState", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x49, 0x00, 0x6E, 0x00,
                    0x73, 0x00, 0x75, 0x00, 0x66, 0x00, 0x66, 0x00, 0x69, 0x00, 0x63, 0x00, 0x69, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x53, 0x00, 0x74, 0x00, 0x61, 0x00, 0x74, 0x00, 0x65, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F0049006E00730075006600660069006300690065006E00740053007400610074006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111679,
            "Serialization_InvalidID", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x49, 0x00, 0x6E, 0x00,
                    0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x49, 0x00, 0x44, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F0049006E00760061006C006900640049004400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111680,
            "Serialization_MalformedArray", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x4D, 0x00, 0x61, 0x00,
                    0x6C, 0x00, 0x66, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x64, 0x00, 0x41, 0x00,
                    0x72, 0x00, 0x72, 0x00, 0x61, 0x00, 0x79, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F004D0061006C0066006F0072006D006500640041007200720061007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111681,
            "Serialization_MultipleMembers", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x4D, 0x00, 0x75, 0x00,
                    0x6C, 0x00, 0x74, 0x00, 0x69, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x4D, 0x00, 0x65, 0x00,
                    0x6D, 0x00, 0x62, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F004D0075006C007400690070006C0065004D0065006D006200650072007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111682,
            "Serialization_NoID", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00,
                    0x49, 0x00, 0x44, 0x00
                }), "System.String", "530065007200690061006C0069007A006100740069006F006E005F004E006F0049004400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111683,
            "Serialization_NoType", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00,
                    0x54, 0x00, 0x79, 0x00, 0x70, 0x00, 0x65, 0x00
                }), "System.String", "530065007200690061006C0069007A006100740069006F006E005F004E006F005400790070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111684,
            "Serialization_NoBaseType", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00,
                    0x42, 0x00, 0x61, 0x00, 0x73, 0x00, 0x65, 0x00, 0x54, 0x00, 0x79, 0x00, 0x70, 0x00, 0x65, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F004E006F0042006100730065005400790070006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111685,
            "Serialization_NullSignature", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x75, 0x00,
                    0x6C, 0x00, 0x6C, 0x00, 0x53, 0x00, 0x69, 0x00, 0x67, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x74, 0x00,
                    0x75, 0x00, 0x72, 0x00, 0x65, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F004E0075006C006C005300690067006E0061007400750072006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111686,
            "Serialization_UnknownMember", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x55, 0x00, 0x6E, 0x00,
                    0x6B, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x77, 0x00, 0x6E, 0x00, 0x4D, 0x00, 0x65, 0x00, 0x6D, 0x00,
                    0x62, 0x00, 0x65, 0x00, 0x72, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F0055006E006B006E006F0077006E004D0065006D00620065007200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111687,
            "Serialization_BadParameterInfo", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x42, 0x00, 0x61, 0x00,
                    0x64, 0x00, 0x50, 0x00, 0x61, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x74, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x66, 0x00, 0x6F, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F0042006100640050006100720061006D00650074006500720049006E0066006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111688,
            "Serialization_NoParameterInfo", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00,
                    0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00,
                    0x50, 0x00, 0x61, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x74, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x49, 0x00, 0x6E, 0x00, 0x66, 0x00, 0x6F, 0x00
                }), "System.String",
            "530065007200690061006C0069007A006100740069006F006E005F004E006F0050006100720061006D00650074006500720049006E0066006F00",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111689,
            "WeakReference_NoLongerValid", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x57, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6B, 0x00, 0x52, 0x00, 0x65, 0x00, 0x66, 0x00, 0x65, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x4E, 0x00, 0x6F, 0x00,
                    0x4C, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x65, 0x00, 0x72, 0x00, 0x56, 0x00, 0x61, 0x00,
                    0x6C, 0x00, 0x69, 0x00, 0x64, 0x00
                }), "System.String",
            "5700650061006B005200650066006500720065006E00630065005F004E006F004C006F006E00670065007200560061006C0069006400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ResId", 67111690,
            "Loader_InvalidPath", SourceMemberKind.Field, 32851, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4C, 0x00, 0x6F, 0x00, 0x61, 0x00, 0x64, 0x00, 0x65, 0x00, 0x72, 0x00, 0x5F, 0x00, 0x49, 0x00,
                    0x6E, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x64, 0x00, 0x50, 0x00, 0x61, 0x00,
                    0x74, 0x00, 0x68, 0x00
                }), "System.String", "4C006F0061006400650072005F0049006E00760061006C00690064005000610074006800",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.CtorDelegate",
            33554866, 256, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.MulticastDelegate", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            33554867, 256, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111691, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111692, "FormatBasic", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111693, "FormatNamespace", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111694, "FormatFullInst", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111695, "FormatAssembly", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111696, "FormatSignature", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111697, "FormatNoVersion", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x10, 0x00, 0x00, 0x00 }), "System.Int32",
            "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111698, "FormatAngleBrackets", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x40, 0x00, 0x00, 0x00 }), "System.Int32",
            "40000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111699, "FormatStubInfo", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x80, 0x00, 0x00, 0x00 }), "System.Int32",
            "80000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111700, "FormatGenericParam", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x01, 0x00, 0x00 }), "System.Int32",
            "00010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameFormatFlags",
            67111701, "FormatSerialization", SourceMemberKind.Field, 32854, "System.TypeNameFormatFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x01, 0x00, 0x00 }), "System.Int32",
            "03010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameKind",
            33554868, 256, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameKind",
            67111702, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameKind",
            67111703, "Name", SourceMemberKind.Field, 32854, "System.TypeNameKind", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameKind",
            67111704, "ToString", SourceMemberKind.Field, 32854, "System.TypeNameKind", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameKind",
            67111705, "SerializationName", SourceMemberKind.Field, 32854, "System.TypeNameKind", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.TypeNameKind",
            67111706, "FullName", SourceMemberKind.Field, 32854, "System.TypeNameKind", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            33554869, 1056776, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Reflection.TypeInfo",
            new string[] { "System.Runtime.Serialization.ISerializable", "System.ICloneable" },
            Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111707, "ValueType", SourceMemberKind.Field, 51, "System.RuntimeType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111708, "EnumType", SourceMemberKind.Field, 51, "System.RuntimeType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111709, "ObjectType", SourceMemberKind.Field, 49, "System.RuntimeType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111710, "StringType", SourceMemberKind.Field, 49, "System.RuntimeType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111711, "DelegateType", SourceMemberKind.Field, 49, "System.RuntimeType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111712, "s_SICtorParamTypes", SourceMemberKind.Field, 17, "System.Type[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111713, "MemberBindingMask", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0x00, 0x00, 0x00 }), "System.Int32",
            "FF000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111714, "InvocationMask", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0xFF, 0x00, 0x00 }), "System.Int32",
            "00FF0000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111715, "BinderNonCreateInstance", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x3D, 0x00, 0x00 }), "System.Int32",
            "003D0000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111716, "BinderGetSetProperty", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x30, 0x00, 0x00 }), "System.Int32",
            "00300000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111717, "BinderSetInvokeProperty", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x21, 0x00, 0x00 }), "System.Int32",
            "00210000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111718, "BinderGetSetField", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x0C, 0x00, 0x00 }), "System.Int32",
            "000C0000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111719, "BinderSetInvokeField", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x09, 0x00, 0x00 }), "System.Int32",
            "00090000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111720, "BinderNonFieldGetSet", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0xF3, 0xFF, 0x00 }), "System.Int32",
            "00F3FF00", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111721, "ClassicBindingMask", SourceMemberKind.Field, 32849, "System.Reflection.BindingFlags", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0xF1, 0x00, 0x00 }), "System.Int32",
            "00F10000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111722, "s_typedRef", SourceMemberKind.Field, 17, "System.RuntimeType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111723, "type_info", SourceMemberKind.Field, 129, "System.MonoTypeInfo", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111724, "GenericCache", SourceMemberKind.Field, 3, "System.Object", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111725, "m_serializationCtor", SourceMemberKind.Field, 1, "System.Reflection.RuntimeConstructorInfo", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111726, "clsid_types", SourceMemberKind.Field, 17,
            "System.Collections.Generic.Dictionary`2<System.Guid,System.Type>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            67111727, "clsid_assemblybuilder", SourceMemberKind.Field, 17, "System.Reflection.Emit.AssemblyBuilder", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            385876503, "Module", SourceMemberKind.Property, 0, "System.Reflection.Module", 2246, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            385876504, "Assembly", SourceMemberKind.Property, 0, "System.Reflection.Assembly", 2246, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            385876505, "TypeHandle", SourceMemberKind.Property, 0, "System.RuntimeTypeHandle", 2246, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            385876506, "BaseType", SourceMemberKind.Property, 0, "System.Type", 2246, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            385876507, "UnderlyingSystemType", SourceMemberKind.Property, 0, "System.Type", 2246, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.RuntimeType",
            385876508, "IsEnum", SourceMemberKind.Property, 0, "System.Boolean", 2246, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
