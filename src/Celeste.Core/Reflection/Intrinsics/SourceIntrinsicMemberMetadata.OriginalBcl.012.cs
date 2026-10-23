using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl012(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Xml.SmallXmlParser",
            67109965, "nameBuffer", SourceMemberKind.Field, 1, "System.Char[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Xml.SmallXmlParser",
            67109966, "isWhitespace", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Xml.SmallXmlParser",
            67109967, "attributes", SourceMemberKind.Field, 1, "Mono.Xml.SmallXmlParser+AttrListImpl", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Xml.SmallXmlParser",
            67109968, "line", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Xml.SmallXmlParser",
            67109969, "column", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Xml.SmallXmlParser",
            67109970, "resetColumn", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+IContentHandler", 33554471, 162, null, null, Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+IAttrList", 33554472, 162, null, null, Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+IAttrList", 385875983, "Length", SourceMemberKind.Property, 0, "System.Int32",
            3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+IAttrList", 385875984, "IsEmpty", SourceMemberKind.Property, 0, "System.Boolean",
            3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+IAttrList", 385875985, "Names", SourceMemberKind.Property, 0, "System.String[]",
            3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+IAttrList", 385875986, "Values", SourceMemberKind.Property, 0, "System.String[]",
            3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+AttrListImpl", 33554473, 1048579,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "Mono.Xml.SmallXmlParser+IAttrList" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+AttrListImpl", 67109971, "attrNames", SourceMemberKind.Field, 1,
            "System.Collections.Generic.List`1<System.String>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+AttrListImpl", 67109972, "attrValues", SourceMemberKind.Field, 1,
            "System.Collections.Generic.List`1<System.String>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+AttrListImpl", 385875987, "Length", SourceMemberKind.Property, 0, "System.Int32",
            2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+AttrListImpl", 385875988, "IsEmpty", SourceMemberKind.Property, 0,
            "System.Boolean", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+AttrListImpl", 385875989, "Names", SourceMemberKind.Property, 0, "System.String[]",
            2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParser+AttrListImpl", 385875990, "Values", SourceMemberKind.Property, 0,
            "System.String[]", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParserException", 33554474, 1048576,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParserException", 67109973, "line", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParserException", 67109974, "column", SourceMemberKind.Field, 1, "System.Int32", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParserException", 385875991, "Line", SourceMemberKind.Property, 0, "System.Int32", 2182,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Xml.SmallXmlParserException", 385875992, "Column", SourceMemberKind.Property, 0, "System.Int32", 2182,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            33554475, 1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            67109975, "length", SourceMemberKind.Field, 1, "System.UInt32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            67109976, "data", SourceMemberKind.Field, 1, "System.UInt32[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            67109977, "DEFAULT_LEN", SourceMemberKind.Field, 32849, "System.UInt32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.UInt32", new byte[] { 0x14, 0x00, 0x00, 0x00 }), "System.UInt32",
            "14000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            67109978, "smallPrimes", SourceMemberKind.Field, 51, "System.UInt32[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            67109979, "WouldReturnNegVal", SourceMemberKind.Field, 32849, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x4F, 0x00, 0x70, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00,
                    0x6E, 0x00, 0x20, 0x00, 0x77, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x64, 0x00, 0x20, 0x00,
                    0x72, 0x00, 0x65, 0x00, 0x74, 0x00, 0x75, 0x00, 0x72, 0x00, 0x6E, 0x00, 0x20, 0x00, 0x61, 0x00,
                    0x20, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x67, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x76, 0x00,
                    0x65, 0x00, 0x20, 0x00, 0x76, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x75, 0x00, 0x65, 0x00
                }), "System.String",
            "4F007000650072006100740069006F006E00200077006F0075006C0064002000720065007400750072006E002000610020006E0065006700610074006900760065002000760061006C0075006500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            67109980, "rng", SourceMemberKind.Field, 17, "System.Security.Cryptography.RandomNumberGenerator", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger",
            385875993, "Rng", SourceMemberKind.Property, 0, "System.Security.Cryptography.RandomNumberGenerator", 2193,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger+Sign",
            33554476, 258, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger+Sign",
            67109981, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger+Sign",
            67109982, "Negative", SourceMemberKind.Field, 32854, "Mono.Math.BigInteger+Sign", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }), "System.Int32",
            "FFFFFFFF", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger+Sign",
            67109983, "Zero", SourceMemberKind.Field, 32854, "Mono.Math.BigInteger+Sign", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Math.BigInteger+Sign",
            67109984, "Positive", SourceMemberKind.Field, 32854, "Mono.Math.BigInteger+Sign", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.BigInteger+ModulusRing", 33554477, 1048837,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.BigInteger+ModulusRing", 67109985, "mod", SourceMemberKind.Field, 1, "Mono.Math.BigInteger", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.BigInteger+ModulusRing", 67109986, "constant", SourceMemberKind.Field, 1, "Mono.Math.BigInteger",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.BigInteger+Kernel", 33554478, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 33554479, 256,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 67109987, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 67109988, "ExtraLow", SourceMemberKind.Field, 32854,
            "Mono.Math.Prime.ConfidenceFactor", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 67109989, "Low", SourceMemberKind.Field, 32854,
            "Mono.Math.Prime.ConfidenceFactor", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 67109990, "Medium", SourceMemberKind.Field, 32854,
            "Mono.Math.Prime.ConfidenceFactor", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 67109991, "High", SourceMemberKind.Field, 32854,
            "Mono.Math.Prime.ConfidenceFactor", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 67109992, "ExtraHigh", SourceMemberKind.Field, 32854,
            "Mono.Math.Prime.ConfidenceFactor", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.ConfidenceFactor", 67109993, "Provable", SourceMemberKind.Field, 32854,
            "Mono.Math.Prime.ConfidenceFactor", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x05, 0x00, 0x00, 0x00 }), "System.Int32",
            "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.PrimalityTest", 33554480, 256,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.MulticastDelegate",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.PrimalityTests", 33554481, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.NextPrimeFinder", 33554482, 1048576,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.SequentialSearchPrimeGeneratorBase", Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.PrimeGeneratorBase", 33554483, 1048704,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.PrimeGeneratorBase", 385875994, "Confidence", SourceMemberKind.Property, 0,
            "Mono.Math.Prime.ConfidenceFactor", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.PrimeGeneratorBase", 385875995, "PrimalityTest", SourceMemberKind.Property, 0,
            "Mono.Math.Prime.PrimalityTest", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.PrimeGeneratorBase", 385875996, "TrialDivisionBounds", SourceMemberKind.Property,
            0, "System.Int32", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.SequentialSearchPrimeGeneratorBase", 33554484, 1048576,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Math.Prime.Generator.PrimeGeneratorBase", Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1Convert",
            33554485, 1048960, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            33554486, 1048576, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            67109994, "m_nTag", SourceMemberKind.Field, 1, "System.Byte", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            67109995, "m_aValue", SourceMemberKind.Field, 1, "System.Byte[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            67109996, "elist", SourceMemberKind.Field, 1, "System.Collections.ArrayList", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            385875997, "Count", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            385875998, "Tag", SourceMemberKind.Property, 0, "System.Byte", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            385875999, "Length", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            385876000, "Value", SourceMemberKind.Property, 0, "System.Byte[]", 2182, 2182, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.ASN1",
            385876001, "Item", SourceMemberKind.Property, 0, "Mono.Security.ASN1", 2182, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.BitConverterLE", 33554487, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7",
            33554488, 1048832, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            33554489, 1048578, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67109997, "rsaEncryption", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x31, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0031002E003100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67109998, "data", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x37, 0x00, 0x2E, 0x00, 0x31, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0037002E003100",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67109999, "signedData", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x37, 0x00, 0x2E, 0x00, 0x32, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0037002E003200",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110000, "envelopedData", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x37, 0x00, 0x2E, 0x00, 0x33, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0037002E003300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110001, "signedAndEnvelopedData", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x37, 0x00, 0x2E, 0x00, 0x34, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0037002E003400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110002, "digestedData", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x37, 0x00, 0x2E, 0x00, 0x35, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0037002E003500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110003, "encryptedData", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x37, 0x00, 0x2E, 0x00, 0x36, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0037002E003600",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110004, "contentType", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x33, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E003300",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110005, "messageDigest", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x34, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E003400",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110006, "signingTime", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x35, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E003500",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Mono.Security.PKCS7+Oid",
            67110007, "countersignature", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.String",
                new byte[]
                {
                    0x31, 0x00, 0x2E, 0x00, 0x32, 0x00, 0x2E, 0x00, 0x38, 0x00, 0x34, 0x00, 0x30, 0x00, 0x2E, 0x00,
                    0x31, 0x00, 0x31, 0x00, 0x33, 0x00, 0x35, 0x00, 0x34, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x31, 0x00,
                    0x2E, 0x00, 0x39, 0x00, 0x2E, 0x00, 0x36, 0x00
                }), "System.String", "31002E0032002E003800340030002E003100310033003500340039002E0031002E0039002E003600",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+ContentInfo", 33554490, 1048578,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+ContentInfo", 67110008, "contentType", SourceMemberKind.Field, 1, "System.String", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+ContentInfo", 67110009, "content", SourceMemberKind.Field, 1, "Mono.Security.ASN1", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+ContentInfo", 385876002, "ASN1", SourceMemberKind.Property, 0, "Mono.Security.ASN1",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+ContentInfo", 385876003, "Content", SourceMemberKind.Property, 0, "Mono.Security.ASN1",
            2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+ContentInfo", 385876004, "ContentType", SourceMemberKind.Property, 0, "System.String",
            2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 33554491, 1048578,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 67110010, "_version", SourceMemberKind.Field, 1, "System.Byte", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 67110011, "_content", SourceMemberKind.Field, 1,
            "Mono.Security.PKCS7+ContentInfo", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 67110012, "_encryptionAlgorithm", SourceMemberKind.Field, 1,
            "Mono.Security.PKCS7+ContentInfo", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 67110013, "_encrypted", SourceMemberKind.Field, 1, "System.Byte[]", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 385876005, "ASN1", SourceMemberKind.Property, 0, "Mono.Security.ASN1",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 385876006, "ContentInfo", SourceMemberKind.Property, 0,
            "Mono.Security.PKCS7+ContentInfo", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 385876007, "EncryptionAlgorithm", SourceMemberKind.Property, 0,
            "Mono.Security.PKCS7+ContentInfo", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "Mono.Security.PKCS7+EncryptedData", 385876008, "EncryptedContent", SourceMemberKind.Property, 0,
            "System.Byte[]", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
