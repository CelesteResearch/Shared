using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl024(SourceMemberCatalog catalog)
    {
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.MemoryDebugView`1",
            33554640, 1048832, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643077, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.MemoryDebugView`1",
            67110667, "_memory", SourceMemberKind.Field, 33, "System.ReadOnlyMemory`1<T>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.MemoryDebugView`1",
            385876264, "Items", SourceMemberKind.Property, 0, "T[]", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                    "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                    new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            33554641, 1048841, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.ValueType", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x14, 0x7B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x67, 0x65, 0x72, 0x44, 0x69, 0x73, 0x70,
                        0x6C, 0x61, 0x79, 0x2C, 0x6E, 0x71, 0x7D, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                    "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x18, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x4D, 0x65, 0x6D, 0x6F, 0x72, 0x79,
                        0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60, 0x31, 0x00, 0x00
                    })
            }, null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643078, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            67110668, "_object", SourceMemberKind.Field, 33, "System.Object", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            67110669, "_index", SourceMemberKind.Field, 33, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            67110670, "_length", SourceMemberKind.Field, 33, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            67110671, "RemoveOwnedFlagBitMask", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0xFF, 0xFF, 0x7F }), "System.Int32",
            "FFFFFF7F", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            385876265, "DebuggerDisplay", SourceMemberKind.Property, 0, "System.String", 2177, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            385876266, "Empty", SourceMemberKind.Property, 0, "System.ReadOnlyMemory`1<T>", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            385876267, "Length", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            385876268, "IsEmpty", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ReadOnlyMemory`1",
            385876269, "Span", SourceMemberKind.Property, 0, "System.ReadOnlySpan`1<T>", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ITupleInternal",
            33554642, 160, null, null, new string[] { "System.Runtime.CompilerServices.ITuple" },
            Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple", 33554643,
            1048961, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`1", 33554644,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643079, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`1", 67110672,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`1", 385876270,
            "Item1", SourceMemberKind.Property, 0, "T1", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`1", 385876271,
            "System.Runtime.CompilerServices.ITuple.Length", SourceMemberKind.Property, 0, "System.Int32", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`1", 385876272,
            "System.Runtime.CompilerServices.ITuple.Item", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`2", 33554645,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643080, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T2", 1, 704643081, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`2", 67110673,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`2", 67110674,
            "m_Item2", SourceMemberKind.Field, 33, "T2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`2", 385876273,
            "Item1", SourceMemberKind.Property, 0, "T1", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`2", 385876274,
            "Item2", SourceMemberKind.Property, 0, "T2", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`2", 385876275,
            "System.Runtime.CompilerServices.ITuple.Length", SourceMemberKind.Property, 0, "System.Int32", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`2", 385876276,
            "System.Runtime.CompilerServices.ITuple.Item", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 33554646,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643082, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T2", 1, 704643083, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T3", 2, 704643084, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 67110675,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 67110676,
            "m_Item2", SourceMemberKind.Field, 33, "T2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 67110677,
            "m_Item3", SourceMemberKind.Field, 33, "T3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 385876277,
            "Item1", SourceMemberKind.Property, 0, "T1", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 385876278,
            "Item2", SourceMemberKind.Property, 0, "T2", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 385876279,
            "Item3", SourceMemberKind.Property, 0, "T3", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 385876280,
            "System.Runtime.CompilerServices.ITuple.Length", SourceMemberKind.Property, 0, "System.Int32", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`3", 385876281,
            "System.Runtime.CompilerServices.ITuple.Item", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 33554647,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643085, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T2", 1, 704643086, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T3", 2, 704643087, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T4", 3, 704643088, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 67110678,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 67110679,
            "m_Item2", SourceMemberKind.Field, 33, "T2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 67110680,
            "m_Item3", SourceMemberKind.Field, 33, "T3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 67110681,
            "m_Item4", SourceMemberKind.Field, 33, "T4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 385876282,
            "Item1", SourceMemberKind.Property, 0, "T1", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 385876283,
            "Item2", SourceMemberKind.Property, 0, "T2", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 385876284,
            "Item3", SourceMemberKind.Property, 0, "T3", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 385876285,
            "Item4", SourceMemberKind.Property, 0, "T4", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 385876286,
            "System.Runtime.CompilerServices.ITuple.Length", SourceMemberKind.Property, 0, "System.Int32", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`4", 385876287,
            "System.Runtime.CompilerServices.ITuple.Item", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 33554648,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643089, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T2", 1, 704643090, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T3", 2, 704643091, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T4", 3, 704643092, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T5", 4, 704643093, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 67110682,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 67110683,
            "m_Item2", SourceMemberKind.Field, 33, "T2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 67110684,
            "m_Item3", SourceMemberKind.Field, 33, "T3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 67110685,
            "m_Item4", SourceMemberKind.Field, 33, "T4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 67110686,
            "m_Item5", SourceMemberKind.Field, 33, "T5", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 385876288,
            "Item1", SourceMemberKind.Property, 0, "T1", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 385876289,
            "Item2", SourceMemberKind.Property, 0, "T2", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 385876290,
            "Item3", SourceMemberKind.Property, 0, "T3", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 385876291,
            "Item4", SourceMemberKind.Property, 0, "T4", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 385876292,
            "Item5", SourceMemberKind.Property, 0, "T5", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 385876293,
            "System.Runtime.CompilerServices.ITuple.Length", SourceMemberKind.Property, 0, "System.Int32", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`5", 385876294,
            "System.Runtime.CompilerServices.ITuple.Item", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 33554649,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643094, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T2", 1, 704643095, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T3", 2, 704643096, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T4", 3, 704643097, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T5", 4, 704643098, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T6", 5, 704643099, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 67110687,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 67110688,
            "m_Item2", SourceMemberKind.Field, 33, "T2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 67110689,
            "m_Item3", SourceMemberKind.Field, 33, "T3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 67110690,
            "m_Item4", SourceMemberKind.Field, 33, "T4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 67110691,
            "m_Item5", SourceMemberKind.Field, 33, "T5", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 67110692,
            "m_Item6", SourceMemberKind.Field, 33, "T6", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876295,
            "Item1", SourceMemberKind.Property, 0, "T1", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876296,
            "Item2", SourceMemberKind.Property, 0, "T2", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876297,
            "Item3", SourceMemberKind.Property, 0, "T3", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876298,
            "Item4", SourceMemberKind.Property, 0, "T4", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876299,
            "Item5", SourceMemberKind.Property, 0, "T5", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876300,
            "Item6", SourceMemberKind.Property, 0, "T6", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876301,
            "System.Runtime.CompilerServices.ITuple.Length", SourceMemberKind.Property, 0, "System.Int32", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`6", 385876302,
            "System.Runtime.CompilerServices.ITuple.Item", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 33554650,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643100, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T2", 1, 704643101, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T3", 2, 704643102, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T4", 3, 704643103, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T5", 4, 704643104, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T6", 5, 704643105, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T7", 6, 704643106, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 67110693,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 67110694,
            "m_Item2", SourceMemberKind.Field, 33, "T2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 67110695,
            "m_Item3", SourceMemberKind.Field, 33, "T3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 67110696,
            "m_Item4", SourceMemberKind.Field, 33, "T4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 67110697,
            "m_Item5", SourceMemberKind.Field, 33, "T5", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 67110698,
            "m_Item6", SourceMemberKind.Field, 33, "T6", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 67110699,
            "m_Item7", SourceMemberKind.Field, 33, "T7", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876303,
            "Item1", SourceMemberKind.Property, 0, "T1", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876304,
            "Item2", SourceMemberKind.Property, 0, "T2", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876305,
            "Item3", SourceMemberKind.Property, 0, "T3", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876306,
            "Item4", SourceMemberKind.Property, 0, "T4", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876307,
            "Item5", SourceMemberKind.Property, 0, "T5", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876308,
            "Item6", SourceMemberKind.Property, 0, "T6", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876309,
            "Item7", SourceMemberKind.Property, 0, "T7", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876310,
            "System.Runtime.CompilerServices.ITuple.Length", SourceMemberKind.Property, 0, "System.Int32", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`7", 385876311,
            "System.Runtime.CompilerServices.ITuple.Item", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`8", 33554651,
            1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.IStructuralEquatable", "System.Collections.IStructuralComparable",
                "System.IComparable", "System.ITupleInternal", "System.Runtime.CompilerServices.ITuple"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T1", 0, 704643107, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T2", 1, 704643108, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T3", 2, 704643109, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T4", 3, 704643110, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T5", 4, 704643111, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T6", 5, 704643112, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T7", 6, 704643113, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TRest", 7, 704643114, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`8", 67110700,
            "m_Item1", SourceMemberKind.Field, 33, "T1", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`8", 67110701,
            "m_Item2", SourceMemberKind.Field, 33, "T2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Tuple`8", 67110702,
            "m_Item3", SourceMemberKind.Field, 33, "T3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, null));
    }
}
