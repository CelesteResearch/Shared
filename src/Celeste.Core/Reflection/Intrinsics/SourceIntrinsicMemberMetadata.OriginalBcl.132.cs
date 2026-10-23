using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl132(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117340, "WinIUserSid", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x3F, 0x00, 0x00, 0x00 }), "System.Int32",
            "3F000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117341, "WinBuiltinCryptoOperatorsSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x40, 0x00, 0x00, 0x00 }), "System.Int32",
            "40000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117342, "WinUntrustedLabelSid", SourceMemberKind.Field,
            32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x41, 0x00, 0x00, 0x00 }), "System.Int32",
            "41000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117343, "WinLowLabelSid", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x42, 0x00, 0x00, 0x00 }), "System.Int32",
            "42000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117344, "WinMediumLabelSid", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x43, 0x00, 0x00, 0x00 }), "System.Int32",
            "43000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117345, "WinHighLabelSid", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x44, 0x00, 0x00, 0x00 }), "System.Int32",
            "44000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117346, "WinSystemLabelSid", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x45, 0x00, 0x00, 0x00 }), "System.Int32",
            "45000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117347, "WinWriteRestrictedCodeSid", SourceMemberKind.Field,
            32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x46, 0x00, 0x00, 0x00 }), "System.Int32",
            "46000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117348, "WinCreatorOwnerRightsSid", SourceMemberKind.Field,
            32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x47, 0x00, 0x00, 0x00 }), "System.Int32",
            "47000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117349, "WinCacheablePrincipalsGroupSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x48, 0x00, 0x00, 0x00 }), "System.Int32",
            "48000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117350, "WinNonCacheablePrincipalsGroupSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x49, 0x00, 0x00, 0x00 }), "System.Int32",
            "49000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117351, "WinEnterpriseReadonlyControllersSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x4A, 0x00, 0x00, 0x00 }), "System.Int32",
            "4A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117352, "WinAccountReadonlyControllersSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x4B, 0x00, 0x00, 0x00 }), "System.Int32",
            "4B000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117353, "WinBuiltinEventLogReadersGroup",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x4C, 0x00, 0x00, 0x00 }), "System.Int32",
            "4C000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117354, "WinNewEnterpriseReadonlyControllersSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x4D, 0x00, 0x00, 0x00 }), "System.Int32",
            "4D000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117355, "WinBuiltinCertSvcDComAccessGroup",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x4E, 0x00, 0x00, 0x00 }), "System.Int32",
            "4E000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117356, "WinMediumPlusLabelSid", SourceMemberKind.Field,
            32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x4F, 0x00, 0x00, 0x00 }), "System.Int32",
            "4F000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117357, "WinLocalLogonSid", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x50, 0x00, 0x00, 0x00 }), "System.Int32",
            "50000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117358, "WinConsoleLogonSid", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x51, 0x00, 0x00, 0x00 }), "System.Int32",
            "51000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117359, "WinThisOrganizationCertificateSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x52, 0x00, 0x00, 0x00 }), "System.Int32",
            "52000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117360, "WinApplicationPackageAuthoritySid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x53, 0x00, 0x00, 0x00 }), "System.Int32",
            "53000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117361, "WinBuiltinAnyPackageSid", SourceMemberKind.Field,
            32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x54, 0x00, 0x00, 0x00 }), "System.Int32",
            "54000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117362, "WinCapabilityInternetClientSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x55, 0x00, 0x00, 0x00 }), "System.Int32",
            "55000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117363, "WinCapabilityInternetClientServerSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x56, 0x00, 0x00, 0x00 }), "System.Int32",
            "56000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117364, "WinCapabilityPrivateNetworkClientServerSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x57, 0x00, 0x00, 0x00 }), "System.Int32",
            "57000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117365, "WinCapabilityPicturesLibrarySid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x58, 0x00, 0x00, 0x00 }), "System.Int32",
            "58000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117366, "WinCapabilityVideosLibrarySid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x59, 0x00, 0x00, 0x00 }), "System.Int32",
            "59000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117367, "WinCapabilityMusicLibrarySid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x5A, 0x00, 0x00, 0x00 }), "System.Int32",
            "5A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117368, "WinCapabilityDocumentsLibrarySid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x5B, 0x00, 0x00, 0x00 }), "System.Int32",
            "5B000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117369, "WinCapabilitySharedUserCertificatesSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x5C, 0x00, 0x00, 0x00 }), "System.Int32",
            "5C000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117370, "WinCapabilityEnterpriseAuthenticationSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x5D, 0x00, 0x00, 0x00 }), "System.Int32",
            "5D000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WellKnownSidType", 67117371, "WinCapabilityRemovableStorageSid",
            SourceMemberKind.Field, 32854, "System.Security.Principal.WellKnownSidType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x5E, 0x00, 0x00, 0x00 }), "System.Int32",
            "5E000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsAccountType", 33555900, 8449,
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
            "System.Security.Principal.WindowsAccountType", 67117372, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsAccountType", 67117373, "Normal", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsAccountType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsAccountType", 67117374, "Guest", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsAccountType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsAccountType", 67117375, "System", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsAccountType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsAccountType", 67117376, "Anonymous", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsAccountType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 33555901, 8449,
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
            "System.Security.Principal.WindowsBuiltInRole", 67117377, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117378, "Administrator", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x02, 0x00, 0x00 }), "System.Int32",
            "20020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117379, "User", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x21, 0x02, 0x00, 0x00 }), "System.Int32",
            "21020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117380, "Guest", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x22, 0x02, 0x00, 0x00 }), "System.Int32",
            "22020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117381, "PowerUser", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x23, 0x02, 0x00, 0x00 }), "System.Int32",
            "23020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117382, "AccountOperator", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x24, 0x02, 0x00, 0x00 }), "System.Int32",
            "24020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117383, "SystemOperator", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x25, 0x02, 0x00, 0x00 }), "System.Int32",
            "25020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117384, "PrintOperator", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x26, 0x02, 0x00, 0x00 }), "System.Int32",
            "26020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117385, "BackupOperator", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x27, 0x02, 0x00, 0x00 }), "System.Int32",
            "27020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsBuiltInRole", 67117386, "Replicator", SourceMemberKind.Field, 32854,
            "System.Security.Principal.WindowsBuiltInRole", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x28, 0x02, 0x00, 0x00 }), "System.Int32",
            "28020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 33555902, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsIdentity",
            new string[]
            {
                "System.Security.Principal.IIdentity", "System.Runtime.Serialization.IDeserializationCallback",
                "System.Runtime.Serialization.ISerializable", "System.IDisposable"
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
            "System.Security.Principal.WindowsIdentity", 67117387, "_token", SourceMemberKind.Field, 1, "System.IntPtr",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 67117388, "_type", SourceMemberKind.Field, 1, "System.String",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 67117389, "_account", SourceMemberKind.Field, 1,
            "System.Security.Principal.WindowsAccountType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 67117390, "_authenticated", SourceMemberKind.Field, 1,
            "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 67117391, "_name", SourceMemberKind.Field, 1, "System.String",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 67117392, "_info", SourceMemberKind.Field, 1,
            "System.Runtime.Serialization.SerializationInfo", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 67117393, "invalidWindows", SourceMemberKind.Field, 17,
            "System.IntPtr", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 67117394, "DefaultIssuer", SourceMemberKind.Field, 32982,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x41, 0x00, 0x44, 0x00, 0x20, 0x00, 0x41, 0x00, 0x55, 0x00, 0x54, 0x00, 0x48, 0x00, 0x4F, 0x00,
                    0x52, 0x00, 0x49, 0x00, 0x54, 0x00, 0x59, 0x00
                }), "System.String", "41004400200041005500540048004F005200490054005900",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878699, "AuthenticationType", SourceMemberKind.Property, 0,
            "System.String", 2278, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878700, "IsAnonymous", SourceMemberKind.Property, 0,
            "System.Boolean", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878701, "IsAuthenticated", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878702, "IsGuest", SourceMemberKind.Property, 0,
            "System.Boolean", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878703, "IsSystem", SourceMemberKind.Property, 0,
            "System.Boolean", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878704, "Name", SourceMemberKind.Property, 0,
            "System.String", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878705, "Token", SourceMemberKind.Property, 0,
            "System.IntPtr", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878706, "Groups", SourceMemberKind.Property, 0,
            "System.Security.Principal.IdentityReferenceCollection", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x6E, 0x6F, 0x74, 0x20, 0x69, 0x6D, 0x70, 0x6C, 0x65, 0x6D, 0x65, 0x6E, 0x74,
                        0x65, 0x64, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878707, "ImpersonationLevel", SourceMemberKind.Property, 0,
            "System.Security.Principal.TokenImpersonationLevel", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x6E, 0x6F, 0x74, 0x20, 0x69, 0x6D, 0x70, 0x6C, 0x65, 0x6D, 0x65, 0x6E, 0x74,
                        0x65, 0x64, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878708, "Owner", SourceMemberKind.Property, 0,
            "System.Security.Principal.SecurityIdentifier", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x6E, 0x6F, 0x74, 0x20, 0x69, 0x6D, 0x70, 0x6C, 0x65, 0x6D, 0x65, 0x6E, 0x74,
                        0x65, 0x64, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878709, "User", SourceMemberKind.Property, 0,
            "System.Security.Principal.SecurityIdentifier", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x6E, 0x6F, 0x74, 0x20, 0x69, 0x6D, 0x70, 0x6C, 0x65, 0x6D, 0x65, 0x6E, 0x74,
                        0x65, 0x64, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsIdentity", 385878710, "AccessToken", SourceMemberKind.Property, 0,
            "Microsoft.Win32.SafeHandles.SafeAccessTokenHandle", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsImpersonationContext", 33555903, 1048577,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.IDisposable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsImpersonationContext", 67117395, "_token", SourceMemberKind.Field, 1,
            "System.IntPtr", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsImpersonationContext", 67117396, "undo", SourceMemberKind.Field, 1,
            "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsPrincipal", 33555904, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.ClaimsPrincipal", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsPrincipal", 67117397, "_identity", SourceMemberKind.Field, 1,
            "System.Security.Principal.WindowsIdentity", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsPrincipal", 67117398, "m_roles", SourceMemberKind.Field, 1,
            "System.String[]", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsPrincipal", 385878711, "Identity", SourceMemberKind.Property, 0,
            "System.Security.Principal.IIdentity", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Principal.WindowsPrincipal", 385878712, "Token", SourceMemberKind.Property, 0,
            "System.IntPtr", 2177, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 33555905, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117399, "m_issuer", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117400, "m_originalIssuer", SourceMemberKind.Field, 1, "System.String",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117401, "m_type", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117402, "m_value", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117403, "m_valueType", SourceMemberKind.Field, 1, "System.String", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117404, "m_userSerializationData", SourceMemberKind.Field, 129,
            "System.Byte[]", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117405, "m_properties", SourceMemberKind.Field, 1,
            "System.Collections.Generic.Dictionary`2<System.String,System.String>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117406, "m_propertyLock", SourceMemberKind.Field, 129, "System.Object",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 67117407, "m_subject", SourceMemberKind.Field, 129,
            "System.Security.Claims.ClaimsIdentity", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878713, "CustomSerializationData", SourceMemberKind.Property, 0,
            "System.Byte[]", 2500, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878714, "Issuer", SourceMemberKind.Property, 0, "System.String", 2182,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878715, "OriginalIssuer", SourceMemberKind.Property, 0, "System.String",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878716, "Properties", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IDictionary`2<System.String,System.String>", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878717, "Subject", SourceMemberKind.Property, 0,
            "System.Security.Claims.ClaimsIdentity", 2182, 2179, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878718, "Type", SourceMemberKind.Property, 0, "System.String", 2182, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878719, "Value", SourceMemberKind.Property, 0, "System.String", 2182, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Security.Claims.Claim", 385878720, "ValueType", SourceMemberKind.Property, 0, "System.String", 2182,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
