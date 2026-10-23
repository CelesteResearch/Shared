using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl045(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Version", 385876662,
            "Build", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Version", 385876663,
            "Revision", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Version", 385876664,
            "MajorRevision", SourceMemberKind.Property, 0, "System.Int16", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Version", 385876665,
            "MinorRevision", SourceMemberKind.Property, 0, "System.Int16", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+ParseFailureKind", 33554917, 261,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+ParseFailureKind", 67112008, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+ParseFailureKind", 67112009, "ArgumentNullException", SourceMemberKind.Field, 32854,
            "System.Version+ParseFailureKind", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+ParseFailureKind", 67112010, "ArgumentException", SourceMemberKind.Field, 32854,
            "System.Version+ParseFailureKind", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+ParseFailureKind", 67112011, "ArgumentOutOfRangeException", SourceMemberKind.Field, 32854,
            "System.Version+ParseFailureKind", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+ParseFailureKind", 67112012, "FormatException", SourceMemberKind.Field, 32854,
            "System.Version+ParseFailureKind", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+VersionResult", 33554918, 1048845,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+VersionResult", 67112013, "m_parsedVersion", SourceMemberKind.Field, 3, "System.Version",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+VersionResult", 67112014, "m_failure", SourceMemberKind.Field, 3,
            "System.Version+ParseFailureKind", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+VersionResult", 67112015, "m_exceptionArgument", SourceMemberKind.Field, 3, "System.String",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+VersionResult", 67112016, "m_argumentName", SourceMemberKind.Field, 3, "System.String", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Version+VersionResult", 67112017, "m_canThrow", SourceMemberKind.Field, 3, "System.Boolean", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 33554919, 1048960,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 67112018, "SwitchNoAsyncCurrentCulture", SourceMemberKind.Field, 32851,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x47, 0x00, 0x6C, 0x00,
                    0x6F, 0x00, 0x62, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x7A, 0x00, 0x61, 0x00, 0x74, 0x00,
                    0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x2E, 0x00, 0x4E, 0x00, 0x6F, 0x00, 0x41, 0x00, 0x73, 0x00,
                    0x79, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x43, 0x00, 0x75, 0x00, 0x72, 0x00, 0x72, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x43, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00,
                    0x65, 0x00
                }), "System.String",
            "5300770069007400630068002E00530079007300740065006D002E0047006C006F00620061006C0069007A006100740069006F006E002E004E006F004100730079006E006300430075007200720065006E007400430075006C007400750072006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 67112019, "SwitchThrowExceptionIfDisposedCancellationTokenSource",
            SourceMemberKind.Field, 32851, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x54, 0x00, 0x68, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x64, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x2E, 0x00,
                    0x54, 0x00, 0x68, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x77, 0x00, 0x45, 0x00, 0x78, 0x00, 0x63, 0x00,
                    0x65, 0x00, 0x70, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x49, 0x00, 0x66, 0x00,
                    0x44, 0x00, 0x69, 0x00, 0x73, 0x00, 0x70, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x65, 0x00, 0x64, 0x00,
                    0x43, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x61, 0x00,
                    0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x54, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x53, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x72, 0x00, 0x63, 0x00, 0x65, 0x00
                }), "System.String",
            "5300770069007400630068002E00530079007300740065006D002E0054006800720065006100640069006E0067002E005400680072006F00770045007800630065007000740069006F006E004900660044006900730070006F00730065006400430061006E00630065006C006C006100740069006F006E0054006F006B0065006E0053006F007500720063006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 67112020, "SwitchPreserveEventListnerObjectIdentity",
            SourceMemberKind.Field, 32851, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x44, 0x00, 0x69, 0x00,
                    0x61, 0x00, 0x67, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00, 0x63, 0x00,
                    0x73, 0x00, 0x2E, 0x00, 0x45, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x53, 0x00,
                    0x6F, 0x00, 0x75, 0x00, 0x72, 0x00, 0x63, 0x00, 0x65, 0x00, 0x2E, 0x00, 0x50, 0x00, 0x72, 0x00,
                    0x65, 0x00, 0x73, 0x00, 0x65, 0x00, 0x72, 0x00, 0x76, 0x00, 0x65, 0x00, 0x45, 0x00, 0x76, 0x00,
                    0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x4C, 0x00, 0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x6E, 0x00,
                    0x65, 0x00, 0x72, 0x00, 0x4F, 0x00, 0x62, 0x00, 0x6A, 0x00, 0x65, 0x00, 0x63, 0x00, 0x74, 0x00,
                    0x49, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00
                }), "System.String",
            "5300770069007400630068002E00530079007300740065006D002E0044006900610067006E006F00730074006900630073002E004500760065006E00740053006F0075007200630065002E00500072006500730065007200760065004500760065006E0074004C006900730074006E00650072004F0062006A006500630074004900640065006E007400690074007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 67112021, "SwitchUseLegacyPathHandling", SourceMemberKind.Field, 32851,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x49, 0x00, 0x4F, 0x00,
                    0x2E, 0x00, 0x55, 0x00, 0x73, 0x00, 0x65, 0x00, 0x4C, 0x00, 0x65, 0x00, 0x67, 0x00, 0x61, 0x00,
                    0x63, 0x00, 0x79, 0x00, 0x50, 0x00, 0x61, 0x00, 0x74, 0x00, 0x68, 0x00, 0x48, 0x00, 0x61, 0x00,
                    0x6E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00
                }), "System.String",
            "5300770069007400630068002E00530079007300740065006D002E0049004F002E005500730065004C00650067006100630079005000610074006800480061006E0064006C0069006E006700",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 67112022, "SwitchBlockLongPaths", SourceMemberKind.Field, 32851,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x49, 0x00, 0x4F, 0x00,
                    0x2E, 0x00, 0x42, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x6B, 0x00, 0x4C, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x67, 0x00, 0x50, 0x00, 0x61, 0x00, 0x74, 0x00, 0x68, 0x00, 0x73, 0x00
                }), "System.String",
            "5300770069007400630068002E00530079007300740065006D002E0049004F002E0042006C006F0063006B004C006F006E00670050006100740068007300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 67112023, "SwitchDoNotAddrOfCspParentWindowHandle",
            SourceMemberKind.Field, 32851, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x65, 0x00,
                    0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x43, 0x00,
                    0x72, 0x00, 0x79, 0x00, 0x70, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x72, 0x00, 0x61, 0x00,
                    0x70, 0x00, 0x68, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x44, 0x00, 0x6F, 0x00, 0x4E, 0x00, 0x6F, 0x00,
                    0x74, 0x00, 0x41, 0x00, 0x64, 0x00, 0x64, 0x00, 0x72, 0x00, 0x4F, 0x00, 0x66, 0x00, 0x43, 0x00,
                    0x73, 0x00, 0x70, 0x00, 0x50, 0x00, 0x61, 0x00, 0x72, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00,
                    0x57, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x6F, 0x00, 0x77, 0x00, 0x48, 0x00, 0x61, 0x00,
                    0x6E, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x65, 0x00
                }), "System.String",
            "5300770069007400630068002E00530079007300740065006D002E00530065006300750072006900740079002E00430072007900700074006F006700720061007000680079002E0044006F004E006F00740041006400640072004F00660043007300700050006100720065006E007400570069006E0064006F007700480061006E0064006C006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppContextDefaultValues", 67112024, "SwitchSetActorAsReferenceWhenCopyingClaimsIdentity",
            SourceMemberKind.Field, 32851, "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x53, 0x00, 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x2E, 0x00, 0x53, 0x00,
                    0x79, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x65, 0x00,
                    0x63, 0x00, 0x75, 0x00, 0x72, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x43, 0x00,
                    0x6C, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00, 0x65, 0x00,
                    0x6E, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x79, 0x00, 0x2E, 0x00, 0x53, 0x00, 0x65, 0x00,
                    0x74, 0x00, 0x41, 0x00, 0x63, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x41, 0x00, 0x73, 0x00,
                    0x52, 0x00, 0x65, 0x00, 0x66, 0x00, 0x65, 0x00, 0x72, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x63, 0x00,
                    0x65, 0x00, 0x57, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x43, 0x00, 0x6F, 0x00, 0x70, 0x00,
                    0x79, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x43, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x69, 0x00,
                    0x6D, 0x00, 0x73, 0x00, 0x49, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x69, 0x00,
                    0x74, 0x00, 0x79, 0x00
                }), "System.String",
            "5300770069007400630068002E00530079007300740065006D002E00530065006300750072006900740079002E0043006C00610069006D0073004900640065006E0074006900740079002E005300650074004100630074006F007200410073005200650066006500720065006E00630065005700680065006E0043006F007000790069006E00670043006C00610069006D0073004900640065006E007400690074007900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 33554920,
            1048841, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.MarshalByRefObject", new string[] { "System._AppDomain", "System.Security.IEvidenceFactory" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComDefaultInterfaceAttribute",
                    "System.Void System.Runtime.InteropServices.ComDefaultInterfaceAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x11, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x5F, 0x41, 0x70, 0x70, 0x44, 0x6F,
                        0x6D, 0x61, 0x69, 0x6E, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ClassInterfaceAttribute",
                    "System.Void System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(System.Runtime.InteropServices.ClassInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112025,
            "_mono_app_domain", SourceMemberKind.Field, 1, "System.IntPtr", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112026,
            "_process_guid", SourceMemberKind.Field, 17, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112027,
            "type_resolve_in_progress", SourceMemberKind.Field, 17,
            "System.Collections.Generic.Dictionary`2<System.String,System.Object>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ThreadStaticAttribute",
                    "System.Void System.ThreadStaticAttribute::.ctor()", new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112028,
            "assembly_resolve_in_progress", SourceMemberKind.Field, 17,
            "System.Collections.Generic.Dictionary`2<System.String,System.Object>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ThreadStaticAttribute",
                    "System.Void System.ThreadStaticAttribute::.ctor()", new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112029,
            "assembly_resolve_in_progress_refonly", SourceMemberKind.Field, 17,
            "System.Collections.Generic.Dictionary`2<System.String,System.Object>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ThreadStaticAttribute",
                    "System.Void System.ThreadStaticAttribute::.ctor()", new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112030,
            "_evidence", SourceMemberKind.Field, 1, "System.Security.Policy.Evidence", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112031,
            "_granted", SourceMemberKind.Field, 1, "System.Security.PermissionSet", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112032,
            "_principalPolicy", SourceMemberKind.Field, 1, "System.Security.Principal.PrincipalPolicy", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112033,
            "_principal", SourceMemberKind.Field, 17, "System.Security.Principal.IPrincipal", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ThreadStaticAttribute",
                    "System.Void System.ThreadStaticAttribute::.ctor()", new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112034,
            "default_domain", SourceMemberKind.Field, 17, "System.AppDomain", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112035,
            "AssemblyLoad", SourceMemberKind.Field, 1, "System.AssemblyLoadEventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112036,
            "AssemblyResolve", SourceMemberKind.Field, 1, "System.ResolveEventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112037,
            "DomainUnload", SourceMemberKind.Field, 1, "System.EventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112038,
            "ProcessExit", SourceMemberKind.Field, 1, "System.EventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112039,
            "ResourceResolve", SourceMemberKind.Field, 1, "System.ResolveEventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112040,
            "TypeResolve", SourceMemberKind.Field, 1, "System.ResolveEventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112041,
            "UnhandledException", SourceMemberKind.Field, 1, "System.UnhandledExceptionEventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112042,
            "FirstChanceException", SourceMemberKind.Field, 1,
            "System.EventHandler`1<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112043,
            "_domain_manager", SourceMemberKind.Field, 1, "System.AppDomainManager", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112044,
            "ReflectionOnlyAssemblyResolve", SourceMemberKind.Field, 1, "System.ResolveEventHandler", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112045,
            "_activation", SourceMemberKind.Field, 1, "System.ActivationContext", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112046,
            "_applicationIdentity", SourceMemberKind.Field, 1, "System.ApplicationIdentity", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain", 67112047,
            "compatibility_switch", SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<System.String>", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876666, "SetupInformationNoCopy", SourceMemberKind.Property, 0, "System.AppDomainSetup", 2177, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876667, "SetupInformation", SourceMemberKind.Property, 0, "System.AppDomainSetup", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876668, "ApplicationTrust", SourceMemberKind.Property, 0, "System.Security.Policy.ApplicationTrust",
            2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876669, "BaseDirectory", SourceMemberKind.Property, 0, "System.String", 2534, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876670, "RelativeSearchPath", SourceMemberKind.Property, 0, "System.String", 2534, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876671, "DynamicDirectory", SourceMemberKind.Property, 0, "System.String", 2534, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876672, "ShadowCopyFiles", SourceMemberKind.Property, 0, "System.Boolean", 2534, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876673, "FriendlyName", SourceMemberKind.Property, 0, "System.String", 2534, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876674, "Evidence", SourceMemberKind.Property, 0, "System.Security.Policy.Evidence", 2534, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876675, "DefaultPrincipal", SourceMemberKind.Property, 0, "System.Security.Principal.IPrincipal", 2179,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876676, "GrantedPermissionSet", SourceMemberKind.Property, 0, "System.Security.PermissionSet", 2179, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876677, "PermissionSet", SourceMemberKind.Property, 0, "System.Security.PermissionSet", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876678, "CurrentDomain", SourceMemberKind.Property, 0, "System.AppDomain", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876679, "DefaultDomain", SourceMemberKind.Property, 0, "System.AppDomain", 2195, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876680, "IsHomogenous", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876681, "IsFullyTrusted", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876682, "DomainManager", SourceMemberKind.Property, 0, "System.AppDomainManager", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876683, "ActivationContext", SourceMemberKind.Property, 0, "System.ActivationContext", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876684, "ApplicationIdentity", SourceMemberKind.Property, 0, "System.ApplicationIdentity", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876685, "Id", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876686, "MonitoringIsEnabled", SourceMemberKind.Property, 0, "System.Boolean", 2198, 2198, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x1E, 0x43, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x74, 0x6C, 0x79, 0x20, 0x61, 0x6C, 0x77,
                        0x61, 0x79, 0x73, 0x20, 0x72, 0x65, 0x74, 0x75, 0x72, 0x6E, 0x73, 0x20, 0x66, 0x61, 0x6C, 0x73,
                        0x65, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876687, "MonitoringSurvivedMemorySize", SourceMemberKind.Property, 0, "System.Int64", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876688, "MonitoringSurvivedProcessMemorySize", SourceMemberKind.Property, 0, "System.Int64", 2198, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876689, "MonitoringTotalAllocatedMemorySize", SourceMemberKind.Property, 0, "System.Int64", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain",
            385876690, "MonitoringTotalProcessorTime", SourceMemberKind.Property, 0, "System.TimeSpan", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute", "System.Void System.MonoTODOAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain+Loader",
            33554921, 1056771, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppDomain+Loader",
            67112048, "assembly", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppDomain+Initializer", 33554922, 1056771,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppDomain+Initializer", 67112049, "initializer", SourceMemberKind.Field, 1,
            "System.AppDomainInitializer", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.AppDomain+Initializer", 67112050, "arguments", SourceMemberKind.Field, 1, "System.String[]", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Array_ReferenceSources", 33554923, 1048960,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Array_ReferenceSources", 67112051, "MaxArrayLength", SourceMemberKind.Field, 32851, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0xFF, 0xEF, 0x7F }), "System.Int32",
            "FFFFEF7F", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Array_ReferenceSources", 67112052, "MaxByteArrayLength", SourceMemberKind.Field, 32851,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xC7, 0xFF, 0xFF, 0x7F }), "System.Int32",
            "C7FFFF7F", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.LogLevel", 33554924,
            256, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.LogLevel", 67112053,
            "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.LogLevel", 67112054,
            "Trace", SourceMemberKind.Field, 32854, "System.LogLevel", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.LogLevel", 67112055,
            "Status", SourceMemberKind.Field, 32854, "System.LogLevel", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x14, 0x00, 0x00, 0x00 }), "System.Int32",
            "14000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.LogLevel", 67112056,
            "Warning", SourceMemberKind.Field, 32854, "System.LogLevel", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x28, 0x00, 0x00, 0x00 }), "System.Int32",
            "28000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.LogLevel", 67112057,
            "Error", SourceMemberKind.Field, 32854, "System.LogLevel", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x32, 0x00, 0x00, 0x00 }), "System.Int32",
            "32000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.LogLevel", 67112058,
            "Panic", SourceMemberKind.Field, 32854, "System.LogLevel", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x64, 0x00, 0x00, 0x00 }), "System.Int32",
            "64000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.BCLDebug", 33554925,
            1048960, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.CLRConfig", 33554926,
            1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                    "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.CompatibilitySwitches", 33554927, 1048960,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.CompatibilitySwitches", 67112059, "IsAppEarlierThanSilverlight4", SourceMemberKind.Field, 54,
            "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.CompatibilitySwitches", 67112060, "IsAppEarlierThanWindowsPhone8", SourceMemberKind.Field, 54,
            "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            33554928, 1048961, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            67112061, "mono_corlib_version", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x0A, 0xA8, 0x3E }), "System.Int32",
            "020AA83E", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Environment",
            67112062, "nl", SourceMemberKind.Field, 17, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
