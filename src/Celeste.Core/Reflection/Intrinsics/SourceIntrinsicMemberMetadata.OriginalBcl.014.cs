using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl014(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongName+StrongNameOptions", 67110057, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongName+StrongNameOptions", 67110058, "Metadata", SourceMemberKind.Field, 32854,
                "Mono.Security.StrongName+StrongNameOptions", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongName+StrongNameOptions", 67110059, "Signature", SourceMemberKind.Field, 32854,
                "Mono.Security.StrongName+StrongNameOptions", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongNameManager", 33554500, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongNameManager", 67110060, "mappings", SourceMemberKind.Field, 17,
                "System.Collections.Hashtable", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongNameManager", 67110061, "tokens", SourceMemberKind.Field, 17,
                "System.Collections.Hashtable", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongNameManager+Element", 33554501, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.StrongNameManager+Element", 67110062, "assemblies", SourceMemberKind.Field, 3,
                "System.Collections.Hashtable", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.UriPartial",
                33554502, 256, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.UriPartial",
                67110063, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.UriPartial",
                67110064, "Scheme", SourceMemberKind.Field, 32854, "Mono.Security.UriPartial", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.UriPartial",
                67110065, "Authority", SourceMemberKind.Field, 32854, "Mono.Security.UriPartial", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.UriPartial",
                67110066, "Path", SourceMemberKind.Field, 32854, "Mono.Security.UriPartial", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                33554503, 1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110067, "isUnixFilePath", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110068, "source", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110069, "scheme", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110070, "host", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110071, "port", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110072, "path", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110073, "query", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110074, "fragment", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110075, "userinfo", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110076, "isUnc", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110077, "isOpaquePart", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110078, "segments", SourceMemberKind.Field, 1, "System.String[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110079, "userEscaped", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110080, "cachedAbsoluteUri", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110081, "cachedToString", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110082, "cachedLocalPath", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110083, "cachedHashCode", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110084, "reduce", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110085, "hexUpperChars", SourceMemberKind.Field, 49, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110086, "SchemeDelimiter", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110087, "UriSchemeFile", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110088, "UriSchemeFtp", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110089, "UriSchemeGopher", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110090, "UriSchemeHttp", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110091, "UriSchemeHttps", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110092, "UriSchemeMailto", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110093, "UriSchemeNews", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110094, "UriSchemeNntp", SourceMemberKind.Field, 54, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                67110095, "schemes", SourceMemberKind.Field, 17, "Mono.Security.Uri+UriScheme[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876054, "AbsolutePath", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876055, "AbsoluteUri", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876056, "Authority", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876057, "Fragment", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876058, "Host", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876059, "IsDefaultPort", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876060, "IsFile", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876061, "IsLoopback", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876062, "IsUnc", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876063, "LocalPath", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876064, "PathAndQuery", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876065, "Port", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876066, "Query", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876067, "Scheme", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876068, "Segments", SourceMemberKind.Property, 0, "System.String[]", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876069, "UserEscaped", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.Uri",
                385876070, "UserInfo", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.Uri+UriScheme", 33554504, 1048843,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.Uri+UriScheme", 67110096, "scheme", SourceMemberKind.Field, 6, "System.String", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.Uri+UriScheme", 67110097, "delimiter", SourceMemberKind.Field, 6, "System.String", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.Uri+UriScheme", 67110098, "defaultPort", SourceMemberKind.Field, 6, "System.Int32", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS5",
                33554505, 1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS5",
                67110099, "pbeWithMD2AndDESCBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x35, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0035002E003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS5",
                67110100, "pbeWithMD5AndDESCBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x35, 0x00, 0x2E, 0x00, 0x33, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0035002E003300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS5",
                67110101, "pbeWithMD2AndRC2CBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x35, 0x00, 0x2E, 0x00, 0x34, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0035002E003400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS5",
                67110102, "pbeWithMD5AndRC2CBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x35, 0x00, 0x2E, 0x00, 0x36, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0035002E003600",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS5",
                67110103, "pbeWithSHA1AndDESCBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x35, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x30, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0035002E0031003000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS5",
                67110104, "pbeWithSHA1AndRC2CBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x35, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0035002E0031003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS9",
                33554506, 1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS9",
                67110105, "friendlyName", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x30, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E0032003000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS9",
                67110106, "localKeyId", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E0032003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.SafeBag",
                33554507, 1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.SafeBag",
                67110107, "_bagOID", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.SafeBag",
                67110108, "_asn1", SourceMemberKind.Field, 1, "Mono.Security.ASN1", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.SafeBag",
                385876071, "BagOID", SourceMemberKind.Property, 0, "System.String", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.SafeBag",
                385876072, "ASN1", SourceMemberKind.Property, 0, "Mono.Security.ASN1", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                33554508, 1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", ["System.ICloneable"], [], null,
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110109, "pbeWithSHAAnd128BitRC4", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E0031002E003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110110, "pbeWithSHAAnd40BitRC4", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x32, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E0031002E003200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110111, "pbeWithSHAAnd3KeyTripleDESCBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x33, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E0031002E003300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110112, "pbeWithSHAAnd2KeyTripleDESCBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x34, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E0031002E003400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110113, "pbeWithSHAAnd128BitRC2CBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x35, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E0031002E003500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110114, "pbeWithSHAAnd40BitRC2CBC", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x36, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E0031002E003600",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110115, "keyBag", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E00310030002E0031002E003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110116, "pkcs8ShroudedKeyBag", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x32, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E00310030002E0031002E003200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110117, "certBag", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x33, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E00310030002E0031002E003300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110118, "crlBag", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x34, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E00310030002E0031002E003400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110119, "secretBag", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x35, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E00310030002E0031002E003500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110120, "safeContentsBag", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x31, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00, 0x30, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x36, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E00310032002E00310030002E0031002E003600",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110121, "x509Certificate", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E00320032002E003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110122, "sdsiCertificate", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x32, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E00320032002E003200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110123, "x509Crl", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                        0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                        0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x33, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E00320033002E003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "Mono.Security.X509.PKCS12",
                67110124, "recommendedIterationCount", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xD0, 0x07, 0x00, 0x00]), "System.Int32",
                "D0070000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
