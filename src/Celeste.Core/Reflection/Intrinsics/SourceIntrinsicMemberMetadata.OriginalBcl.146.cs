using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl146(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+FixedSizeArrayList", 385878948, "SyncRoot", SourceMemberKind.Property, 0,
            "System.Object", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+FixedSizeArrayList", 385878949, "Capacity", SourceMemberKind.Property, 0,
            "System.Int32", 2246, 2246, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 33556044, 1056771,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
                { "System.Collections.IList", "System.Collections.ICollection", "System.Collections.IEnumerable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 67118291, "_list", SourceMemberKind.Field, 1,
            "System.Collections.IList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 385878950, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 385878951, "IsReadOnly", SourceMemberKind.Property, 0,
            "System.Boolean", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 385878952, "IsFixedSize", SourceMemberKind.Property, 0,
            "System.Boolean", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 385878953, "IsSynchronized", SourceMemberKind.Property, 0,
            "System.Boolean", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 385878954, "Item", SourceMemberKind.Property, 0,
            "System.Object", 2502, 2502, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyList", 385878955, "SyncRoot", SourceMemberKind.Property, 0,
            "System.Object", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 33556045, 1056771,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 67118292, "_list", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 385878956, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 385878957, "IsReadOnly", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 385878958, "IsFixedSize", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 385878959, "IsSynchronized", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 385878960, "Item", SourceMemberKind.Property, 0,
            "System.Object", 2246, 2246, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 385878961, "SyncRoot", SourceMemberKind.Property, 0,
            "System.Object", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ReadOnlyArrayList", 385878962, "Capacity", SourceMemberKind.Property, 0,
            "System.Int32", 2246, 2246, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumerator", 33556046, 1057027,
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
            "System.Collections.ArrayList+ArrayListEnumerator", 67118293, "list", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumerator", 67118294, "index", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumerator", 67118295, "endIndex", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumerator", 67118296, "version", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumerator", 67118297, "currentElement", SourceMemberKind.Field, 1,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumerator", 67118298, "startIndex", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumerator", 385878963, "Current", SourceMemberKind.Property, 0,
            "System.Object", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 33556047, 1056771,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 67118299, "_baseList", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 67118300, "_baseIndex", SourceMemberKind.Field, 1, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 67118301, "_baseSize", SourceMemberKind.Field, 1, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 67118302, "_baseVersion", SourceMemberKind.Field, 1, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 385878964, "Capacity", SourceMemberKind.Property, 0, "System.Int32",
            2246, 2246, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 385878965, "Count", SourceMemberKind.Property, 0, "System.Int32",
            2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 385878966, "IsReadOnly", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 385878967, "IsFixedSize", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 385878968, "IsSynchronized", SourceMemberKind.Property, 0,
            "System.Boolean", 2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 385878969, "SyncRoot", SourceMemberKind.Property, 0, "System.Object",
            2246, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+Range", 385878970, "Item", SourceMemberKind.Property, 0, "System.Object",
            2246, 2246, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 33556048, 1057027,
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
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 67118303, "list", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 67118304, "index", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 67118305, "version", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 67118306, "currentElement",
            SourceMemberKind.Field, 1, "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 67118307, "isArrayList", SourceMemberKind.Field,
            129, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 67118308, "dummyObject", SourceMemberKind.Field,
            17, "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListEnumeratorSimple", 385878971, "Current", SourceMemberKind.Property,
            0, "System.Object", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListDebugView", 33556049, 1048581,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListDebugView", 67118309, "arrayList", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.ArrayList+ArrayListDebugView", 385878972, "Items", SourceMemberKind.Property, 0,
            "System.Object[]", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                    "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                    new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 33556050, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.ICollection", "System.Collections.IEnumerable", "System.ICloneable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118310, "BitsPerInt32", SourceMemberKind.Field, 32849, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x20, 0x00, 0x00, 0x00 }), "System.Int32",
            "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118311, "BytesPerInt32", SourceMemberKind.Field, 32849, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118312, "BitsPerByte", SourceMemberKind.Field, 32849, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118313, "m_array", SourceMemberKind.Field, 1, "System.Int32[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118314, "m_length", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118315, "_version", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118316, "_syncRoot", SourceMemberKind.Field, 129, "System.Object", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 67118317, "_ShrinkThreshold", SourceMemberKind.Field, 32849, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x01, 0x00, 0x00 }), "System.Int32",
            "00010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 385878973, "Item", SourceMemberKind.Property, 0, "System.Boolean", 2182,
            2182, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 385878974, "Length", SourceMemberKind.Property, 0, "System.Int32", 2182,
            2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 385878975, "Count", SourceMemberKind.Property, 0, "System.Int32", 2534, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 385878976, "SyncRoot", SourceMemberKind.Property, 0, "System.Object", 2534,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 385878977, "IsReadOnly", SourceMemberKind.Property, 0, "System.Boolean",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray", 385878978, "IsSynchronized", SourceMemberKind.Property, 0, "System.Boolean",
            2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray+BitArrayEnumeratorSimple", 33556051, 1056771,
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
            "System.Collections.BitArray+BitArrayEnumeratorSimple", 67118318, "bitarray", SourceMemberKind.Field, 1,
            "System.Collections.BitArray", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray+BitArrayEnumeratorSimple", 67118319, "index", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray+BitArrayEnumeratorSimple", 67118320, "version", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray+BitArrayEnumeratorSimple", 67118321, "currentElement", SourceMemberKind.Field,
            1, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.BitArray+BitArrayEnumeratorSimple", 385878979, "Current", SourceMemberKind.Property, 0,
            "System.Object", 2502, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveComparer", 33556052, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IComparer" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveComparer", 67118322, "m_compareInfo", SourceMemberKind.Field, 1,
            "System.Globalization.CompareInfo", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveComparer", 67118323, "m_InvariantCaseInsensitiveComparer",
            SourceMemberKind.Field, 17,
            "System.Collections.CaseInsensitiveComparer modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveComparer", 385878980, "Default", SourceMemberKind.Property, 0,
            "System.Collections.CaseInsensitiveComparer", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveComparer", 385878981, "DefaultInvariant", SourceMemberKind.Property, 0,
            "System.Collections.CaseInsensitiveComparer", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveHashCodeProvider", 33556053, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IHashCodeProvider" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.ObsoleteAttribute",
                    "System.Void System.ObsoleteAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x22, 0x50, 0x6C, 0x65, 0x61, 0x73, 0x65, 0x20, 0x75, 0x73, 0x65, 0x20, 0x53, 0x74,
                        0x72, 0x69, 0x6E, 0x67, 0x43, 0x6F, 0x6D, 0x70, 0x61, 0x72, 0x65, 0x72, 0x20, 0x69, 0x6E, 0x73,
                        0x74, 0x65, 0x61, 0x64, 0x2E, 0x00, 0x00
                    })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveHashCodeProvider", 67118324, "m_text", SourceMemberKind.Field, 1,
            "System.Globalization.TextInfo", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveHashCodeProvider", 67118325,
            "m_InvariantCaseInsensitiveHashCodeProvider", SourceMemberKind.Field, 17,
            "System.Collections.CaseInsensitiveHashCodeProvider modreq(System.Runtime.CompilerServices.IsVolatile)", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveHashCodeProvider", 385878982, "Default", SourceMemberKind.Property, 0,
            "System.Collections.CaseInsensitiveHashCodeProvider", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CaseInsensitiveHashCodeProvider", 385878983, "DefaultInvariant",
            SourceMemberKind.Property, 0, "System.Collections.CaseInsensitiveHashCodeProvider", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 33556054, 1056897,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
                { "System.Collections.IList", "System.Collections.ICollection", "System.Collections.IEnumerable" },
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
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 67118326, "list", SourceMemberKind.Field, 1,
            "System.Collections.ArrayList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878984, "InnerList", SourceMemberKind.Property, 0,
            "System.Collections.ArrayList", 2180, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878985, "List", SourceMemberKind.Property, 0,
            "System.Collections.IList", 2180, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878986, "Capacity", SourceMemberKind.Property, 0, "System.Int32",
            2182, 2182, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878987, "Count", SourceMemberKind.Property, 0, "System.Int32", 2534,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878988, "System.Collections.IList.IsReadOnly",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878989, "System.Collections.IList.IsFixedSize",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878990, "System.Collections.ICollection.IsSynchronized",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878991, "System.Collections.ICollection.SyncRoot",
            SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.CollectionBase", 385878992, "System.Collections.IList.Item", SourceMemberKind.Property,
            0, "System.Object", 2529, 2529, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Comparer", 33556055, 1057025,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IComparer", "System.Runtime.Serialization.ISerializable" },
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
            "System.Collections.Comparer", 67118327, "m_compareInfo", SourceMemberKind.Field, 1,
            "System.Globalization.CompareInfo", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Comparer", 67118328, "Default", SourceMemberKind.Field, 54,
            "System.Collections.Comparer", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Comparer", 67118329, "DefaultInvariant", SourceMemberKind.Field, 54,
            "System.Collections.Comparer", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
