using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl150(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Collections.Stack",
            67118444, "_defaultCapacity", SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x0A, 0x00, 0x00, 0x00 }), "System.Int32",
            "0A000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Collections.Stack",
            385879126, "Count", SourceMemberKind.Property, 0, "System.Int32", 2502, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Collections.Stack",
            385879127, "IsSynchronized", SourceMemberKind.Property, 0, "System.Boolean", 2502, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Collections.Stack",
            385879128, "SyncRoot", SourceMemberKind.Property, 0, "System.Object", 2502, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+SyncStack", 33556097, 1056771,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Collections.Stack",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+SyncStack", 67118445, "_s", SourceMemberKind.Field, 1, "System.Collections.Stack",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+SyncStack", 67118446, "_root", SourceMemberKind.Field, 1, "System.Object", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+SyncStack", 385879129, "IsSynchronized", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+SyncStack", 385879130, "SyncRoot", SourceMemberKind.Property, 0, "System.Object",
            2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+SyncStack", 385879131, "Count", SourceMemberKind.Property, 0, "System.Int32",
            2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackEnumerator", 33556098, 1056771,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IEnumerator", "System.ICloneable" },
            Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackEnumerator", 67118447, "_stack", SourceMemberKind.Field, 1,
            "System.Collections.Stack", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackEnumerator", 67118448, "_index", SourceMemberKind.Field, 1, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackEnumerator", 67118449, "_version", SourceMemberKind.Field, 1, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackEnumerator", 67118450, "currentElement", SourceMemberKind.Field, 1,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackEnumerator", 385879132, "Current", SourceMemberKind.Property, 0,
            "System.Object", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackDebugView", 33556099, 1048581,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackDebugView", 67118451, "stack", SourceMemberKind.Field, 1,
            "System.Collections.Stack", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Stack+StackDebugView", 385879133, "Items", SourceMemberKind.Property, 0,
            "System.Object[]", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                    "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                    new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.StructuralComparisons", 33556100, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.StructuralComparisons", 67118452, "s_StructuralComparer", SourceMemberKind.Field, 17,
            "System.Collections.IComparer modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.StructuralComparisons", 67118453, "s_StructuralEqualityComparer",
            SourceMemberKind.Field, 17,
            "System.Collections.IEqualityComparer modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.StructuralComparisons", 385879134, "StructuralComparer", SourceMemberKind.Property, 0,
            "System.Collections.IComparer", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.StructuralComparisons", 385879135, "StructuralEqualityComparer",
            SourceMemberKind.Property, 0, "System.Collections.IEqualityComparer", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.StructuralEqualityComparer", 33556101, 1056768,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IEqualityComparer" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.StructuralComparer", 33556102, 1056768,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IComparer" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 33556103, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.IList`1<T>", "System.Collections.Generic.ICollection`1<T>",
                "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                "System.Collections.IList", "System.Collections.ICollection",
                "System.Collections.Generic.IReadOnlyList`1<T>", "System.Collections.Generic.IReadOnlyCollection`1<T>"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x39, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x4D, 0x73,
                        0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x5F, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F,
                        0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60, 0x31, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75, 0x6E,
                        0x74, 0x7D, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643353, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 67118454, "items", SourceMemberKind.Field, 1,
            "System.Collections.Generic.IList`1<T>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 67118455, "_syncRoot", SourceMemberKind.Field, 129,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879136, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879137, "Items", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IList`1<T>", 2180, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879138, "Item", SourceMemberKind.Property, 0, "T", 2534,
            2534, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879139,
            "System.Collections.Generic.ICollection<T>.IsReadOnly", SourceMemberKind.Property, 0, "System.Boolean",
            2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879140, "System.Collections.ICollection.IsSynchronized",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879141, "System.Collections.ICollection.SyncRoot",
            SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879142, "System.Collections.IList.Item",
            SourceMemberKind.Property, 0, "System.Object", 2529, 2529, 1, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879143, "System.Collections.IList.IsReadOnly",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1", 385879144, "System.Collections.IList.IsFixedSize",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 33556104, 1056897,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.Collection`1<TItem>", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75, 0x6E,
                        0x74, 0x7D, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x3E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x4D, 0x73,
                        0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x5F, 0x4B, 0x65, 0x79, 0x65, 0x64, 0x43, 0x6F, 0x6C, 0x6C,
                        0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60,
                        0x32, 0x00, 0x00
                    })
            }, null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TKey", 0, 704643354, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TItem", 1, 704643355, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 67118456, "defaultThreshold", SourceMemberKind.Field,
            32849, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 67118457, "comparer", SourceMemberKind.Field, 1,
            "System.Collections.Generic.IEqualityComparer`1<TKey>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 67118458, "dict", SourceMemberKind.Field, 1,
            "System.Collections.Generic.Dictionary`2<TKey,TItem>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 67118459, "keyCount", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 67118460, "threshold", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 385879145, "Comparer", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEqualityComparer`1<TKey>", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 385879146, "Item", SourceMemberKind.Property, 0,
            "TItem", 2182, -1, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.KeyedCollection`2", 385879147, "Dictionary", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IDictionary`2<TKey,TItem>", 2180, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 33556105, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.IList`1<T>", "System.Collections.Generic.ICollection`1<T>",
                "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                "System.Collections.IList", "System.Collections.ICollection",
                "System.Collections.Generic.IReadOnlyList`1<T>", "System.Collections.Generic.IReadOnlyCollection`1<T>"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x39, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x4D, 0x73,
                        0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x5F, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F,
                        0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60, 0x31, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75, 0x6E,
                        0x74, 0x7D, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643356, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 67118461, "list", SourceMemberKind.Field, 1,
            "System.Collections.Generic.IList`1<T>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 67118462, "_syncRoot", SourceMemberKind.Field, 129,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879148, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879149, "Item", SourceMemberKind.Property, 0, "T",
            2534, -1, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879150, "Items", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IList`1<T>", 2180, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879151,
            "System.Collections.Generic.ICollection<T>.IsReadOnly", SourceMemberKind.Property, 0, "System.Boolean",
            2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879152,
            "System.Collections.Generic.IList<T>.Item", SourceMemberKind.Property, 0, "T", 2529, 2529, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879153,
            "System.Collections.ICollection.IsSynchronized", SourceMemberKind.Property, 0, "System.Boolean", 2529, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879154, "System.Collections.ICollection.SyncRoot",
            SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879155, "System.Collections.IList.IsFixedSize",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879156, "System.Collections.IList.IsReadOnly",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyCollection`1", 385879157, "System.Collections.IList.Item",
            SourceMemberKind.Property, 0, "System.Object", 2529, 2529, 1, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 33556106, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.IDictionary`2<TKey,TValue>",
                "System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                "System.Collections.IEnumerable", "System.Collections.IDictionary", "System.Collections.ICollection",
                "System.Collections.Generic.IReadOnlyDictionary`2<TKey,TValue>",
                "System.Collections.Generic.IReadOnlyCollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75, 0x6E,
                        0x74, 0x7D, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x39, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x4D, 0x73,
                        0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x5F, 0x44, 0x69, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x61, 0x72,
                        0x79, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60, 0x32, 0x00, 0x00
                    })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TKey", 0, 704643357, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TValue", 1, 704643358, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 67118463, "m_dictionary", SourceMemberKind.Field, 33,
            "System.Collections.Generic.IDictionary`2<TKey,TValue>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 67118464, "m_syncRoot", SourceMemberKind.Field, 129,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 67118465, "m_keys", SourceMemberKind.Field, 129,
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection<TKey,TValue>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 67118466, "m_values", SourceMemberKind.Field, 129,
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+ValueCollection<TKey,TValue>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879158, "Dictionary", SourceMemberKind.Property,
            0, "System.Collections.Generic.IDictionary`2<TKey,TValue>", 2180, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879159, "Keys", SourceMemberKind.Property, 0,
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection<TKey,TValue>", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879160, "Values", SourceMemberKind.Property, 0,
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+ValueCollection<TKey,TValue>", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879161,
            "System.Collections.Generic.IDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
            "System.Collections.Generic.ICollection`1<TKey>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879162,
            "System.Collections.Generic.IDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
            "System.Collections.Generic.ICollection`1<TValue>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879163, "Item", SourceMemberKind.Property, 0,
            "TValue", 2534, -1, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879164,
            "System.Collections.Generic.IDictionary<TKey,TValue>.Item", SourceMemberKind.Property, 0, "TValue", 2529,
            2529, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879165, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879166,
            "System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879167,
            "System.Collections.IDictionary.IsFixedSize", SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879168,
            "System.Collections.IDictionary.IsReadOnly", SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879169, "System.Collections.IDictionary.Keys",
            SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879170, "System.Collections.IDictionary.Values",
            SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879171, "System.Collections.IDictionary.Item",
            SourceMemberKind.Property, 0, "System.Object", 2529, 2529, 1, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879172,
            "System.Collections.ICollection.IsSynchronized", SourceMemberKind.Property, 0, "System.Boolean", 2529, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879173, "System.Collections.ICollection.SyncRoot",
            SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879174,
            "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<TKey>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2", 385879175,
            "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<TValue>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+DictionaryEnumerator", 33556107, 1057035,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[] { "System.Collections.IDictionaryEnumerator", "System.Collections.IEnumerator" },
            Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TKey", 0, 704643359, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TValue", 1, 704643360, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+DictionaryEnumerator", 67118467, "m_dictionary",
            SourceMemberKind.Field, 33, "System.Collections.Generic.IDictionary`2<TKey,TValue>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+DictionaryEnumerator", 67118468, "m_enumerator",
            SourceMemberKind.Field, 1,
            "System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+DictionaryEnumerator", 385879176, "Entry",
            SourceMemberKind.Property, 0, "System.Collections.DictionaryEntry", 2534, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+DictionaryEnumerator", 385879177, "Key",
            SourceMemberKind.Property, 0, "System.Object", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+DictionaryEnumerator", 385879178, "Value",
            SourceMemberKind.Property, 0, "System.Object", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+DictionaryEnumerator", 385879179, "Current",
            SourceMemberKind.Property, 0, "System.Object", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection", 33556108, 1057026,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.ICollection`1<TKey>", "System.Collections.Generic.IEnumerable`1<TKey>",
                "System.Collections.IEnumerable", "System.Collections.ICollection",
                "System.Collections.Generic.IReadOnlyCollection`1<TKey>"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x39, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x4D, 0x73,
                        0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x5F, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F,
                        0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60, 0x31, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75, 0x6E,
                        0x74, 0x7D, 0x00, 0x00
                    })
            }, null,
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
                new SourceGenericParameterDefinition("TKey", 0, 704643361, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TValue", 1, 704643362, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection", 67118469, "m_collection",
            SourceMemberKind.Field, 33, "System.Collections.Generic.ICollection`1<TKey>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection", 67118470, "m_syncRoot",
            SourceMemberKind.Field, 129, "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection", 385879180, "Count",
            SourceMemberKind.Property, 0, "System.Int32", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection", 385879181,
            "System.Collections.Generic.ICollection<TKey>.IsReadOnly", SourceMemberKind.Property, 0, "System.Boolean",
            2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ObjectModel.ReadOnlyDictionary`2+KeyCollection", 385879182,
            "System.Collections.ICollection.IsSynchronized", SourceMemberKind.Property, 0, "System.Boolean", 2529, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
