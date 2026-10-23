using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl154(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879256, "Comparer", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEqualityComparer`1<TKey>", 2182, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879257, "Count", SourceMemberKind.Property, 0,
                "System.Int32",
                2534, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879258, "Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.Dictionary`2+KeyCollection<TKey,TValue>", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879259,
                "System.Collections.Generic.IDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TKey>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879260,
                "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TKey>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879261, "Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.Dictionary`2+ValueCollection<TKey,TValue>", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879262,
                "System.Collections.Generic.IDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TValue>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879263,
                "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TValue>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879264, "Item", SourceMemberKind.Property, 0, "TValue",
                2534,
                2534, 1, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879265,
                "System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879266, "System.Collections.ICollection.IsSynchronized",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879267, "System.Collections.ICollection.SyncRoot",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879268, "System.Collections.IDictionary.IsFixedSize",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879269, "System.Collections.IDictionary.IsReadOnly",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879270, "System.Collections.IDictionary.Keys",
                SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879271, "System.Collections.IDictionary.Values",
                SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 385879272, "System.Collections.IDictionary.Item",
                SourceMemberKind.Property, 0, "System.Object", 2529, 2529, 1, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Entry", 33556159, 1048843,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [
                    new("TKey", 0, 704643448, 0,
                        [],
                        []),
                    new("TValue", 1, 704643449, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Entry", 67118636, "hashCode", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Entry", 67118637, "next", SourceMemberKind.Field, 6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Entry", 67118638, "key", SourceMemberKind.Field, 6, "TKey", -1,
                -1,
                0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Entry", 67118639, "value", SourceMemberKind.Field, 6, "TValue",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 33556160, 1057034,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.IDisposable", "System.Collections.IEnumerator", "System.Collections.IDictionaryEnumerator",
                ], [], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TKey", 0, 704643451, 0,
                        [],
                        []),
                    new("TValue", 1, 704643452, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 67118640, "_dictionary", SourceMemberKind.Field,
                1,
                "System.Collections.Generic.Dictionary`2<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 67118641, "_version", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 67118642, "_index", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 67118643, "_current", SourceMemberKind.Field, 1,
                "System.Collections.Generic.KeyValuePair`2<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 67118644, "_getEnumeratorRetType",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 67118645, "DictEntry", SourceMemberKind.Field,
                32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 67118646, "KeyValuePair", SourceMemberKind.Field,
                32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 385879273, "Current", SourceMemberKind.Property,
                0,
                "System.Collections.Generic.KeyValuePair`2<TKey,TValue>", 2534, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 385879274,
                "System.Collections.IEnumerator.Current",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 385879275,
                "System.Collections.IDictionaryEnumerator.Entry", SourceMemberKind.Property, 0,
                "System.Collections.DictionaryEntry", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 385879276,
                "System.Collections.IDictionaryEnumerator.Key", SourceMemberKind.Property, 0, "System.Object", 2529, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+Enumerator", 385879277,
                "System.Collections.IDictionaryEnumerator.Value", SourceMemberKind.Property, 0, "System.Object", 2529,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection", 33556161, 1057026,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.ICollection`1<TKey>", "System.Collections.Generic.IEnumerable`1<TKey>",
                    "System.Collections.IEnumerable", "System.Collections.ICollection",
                    "System.Collections.Generic.IReadOnlyCollection`1<TKey>",
                ],
                [
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75,
                            0x6E,
                            0x74, 0x7D, 0x00, 0x00,
                        ]),
                    new("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x3D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x44,
                            0x69,
                            0x63, 0x74, 0x69, 0x6F, 0x6E, 0x61, 0x72, 0x79, 0x4B, 0x65, 0x79, 0x43, 0x6F, 0x6C, 0x6C,
                            0x65,
                            0x63, 0x74, 0x69, 0x6F, 0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60,
                            0x32,
                            0x00, 0x00,
                        ]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TKey", 0, 704643454, 0,
                        [],
                        []),
                    new("TValue", 1, 704643455, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection", 67118647, "_dictionary",
                SourceMemberKind.Field, 1,
                "System.Collections.Generic.Dictionary`2<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection", 385879278, "Count", SourceMemberKind.Property,
                0,
                "System.Int32", 2534, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection", 385879279,
                "System.Collections.Generic.ICollection<TKey>.IsReadOnly", SourceMemberKind.Property, 0,
                "System.Boolean",
                2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection", 385879280,
                "System.Collections.ICollection.IsSynchronized", SourceMemberKind.Property, 0, "System.Boolean", 2529,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection", 385879281,
                "System.Collections.ICollection.SyncRoot", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection+Enumerator", 33556162, 1057034,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [
                    "System.Collections.Generic.IEnumerator`1<TKey>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TKey", 0, 704643457, 0,
                        [],
                        []),
                    new("TValue", 1, 704643458, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection+Enumerator", 67118648, "_dictionary",
                SourceMemberKind.Field, 1, "System.Collections.Generic.Dictionary`2<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection+Enumerator", 67118649, "_index",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection+Enumerator", 67118650, "_version",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection+Enumerator", 67118651, "_currentKey",
                SourceMemberKind.Field, 1, "TKey", -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection+Enumerator", 385879282, "Current",
                SourceMemberKind.Property, 0, "TKey", 2534, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+KeyCollection+Enumerator", 385879283,
                "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection", 33556163, 1057026,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.ICollection`1<TValue>",
                    "System.Collections.Generic.IEnumerable`1<TValue>",
                    "System.Collections.IEnumerable", "System.Collections.ICollection",
                    "System.Collections.Generic.IReadOnlyCollection`1<TValue>",
                ],
                [
                    new("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x3F, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x44,
                            0x69,
                            0x63, 0x74, 0x69, 0x6F, 0x6E, 0x61, 0x72, 0x79, 0x56, 0x61, 0x6C, 0x75, 0x65, 0x43, 0x6F,
                            0x6C,
                            0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65,
                            0x77,
                            0x60, 0x32, 0x00, 0x00,
                        ]),
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75,
                            0x6E,
                            0x74, 0x7D, 0x00, 0x00,
                        ]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TKey", 0, 704643460, 0,
                        [],
                        []),
                    new("TValue", 1, 704643461, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection", 67118652, "_dictionary",
                SourceMemberKind.Field,
                1, "System.Collections.Generic.Dictionary`2<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection", 385879284, "Count",
                SourceMemberKind.Property, 0,
                "System.Int32", 2534, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection", 385879285,
                "System.Collections.Generic.ICollection<TValue>.IsReadOnly", SourceMemberKind.Property, 0,
                "System.Boolean",
                2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection", 385879286,
                "System.Collections.ICollection.IsSynchronized", SourceMemberKind.Property, 0, "System.Boolean", 2529,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection", 385879287,
                "System.Collections.ICollection.SyncRoot", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator", 33556164, 1057034,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [
                    "System.Collections.Generic.IEnumerator`1<TValue>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TKey", 0, 704643462, 0,
                        [],
                        []),
                    new("TValue", 1, 704643463, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator", 67118653, "_dictionary",
                SourceMemberKind.Field, 1, "System.Collections.Generic.Dictionary`2<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator", 67118654, "_index",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator", 67118655, "_version",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator", 67118656, "_currentValue",
                SourceMemberKind.Field, 1, "TValue", -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator", 385879288, "Current",
                SourceMemberKind.Property, 0, "TValue", 2534, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator", 385879289,
                "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.IDictionaryDebugView`2", 33556165, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("K", 0, 704643464, 0, [],
                        []),
                    new("V", 1, 704643465, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.IDictionaryDebugView`2", 67118657, "_dict", SourceMemberKind.Field, 33,
                "System.Collections.Generic.IDictionary`2<K,V>", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.IDictionaryDebugView`2", 385879290, "Items", SourceMemberKind.Property, 0,
                "System.Collections.Generic.KeyValuePair`2<K,V>[]", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.DictionaryKeyCollectionDebugView`2", 33556166, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("TKey", 0, 704643466, 0,
                        [],
                        []),
                    new("TValue", 1, 704643467, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.DictionaryKeyCollectionDebugView`2", 67118658, "_collection",
                SourceMemberKind.Field, 33, "System.Collections.Generic.ICollection`1<TKey>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.DictionaryKeyCollectionDebugView`2", 385879291, "Items",
                SourceMemberKind.Property, 0, "TKey[]", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.DictionaryValueCollectionDebugView`2", 33556167, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("TKey", 0, 704643468, 0,
                        [],
                        []),
                    new("TValue", 1, 704643469, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.DictionaryValueCollectionDebugView`2", 67118659, "_collection",
                SourceMemberKind.Field, 33, "System.Collections.Generic.ICollection`1<TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.DictionaryValueCollectionDebugView`2", 385879292, "Items",
                SourceMemberKind.Property, 0, "TValue[]", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.KeyValuePair", 33556168, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.KeyValuePair`2", 33556169, 1057033,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TKey", 0, 704643471, 0,
                        [],
                        []),
                    new("TValue", 1, 704643472, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.KeyValuePair`2", 67118660, "key", SourceMemberKind.Field, 33, "TKey", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.KeyValuePair`2", 67118661, "value", SourceMemberKind.Field, 33, "TValue",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.KeyValuePair`2", 385879293, "Key", SourceMemberKind.Property, 0, "TKey",
                2182,
                -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.KeyValuePair`2", 385879294, "Value", SourceMemberKind.Property, 0, "TValue",
                2182, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ReferenceEqualityComparer`1", 33556170, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.Collections.Generic.IEqualityComparer`1<T>"],
                [], null,
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                [
                    new("T", 0, 704643474, 4, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ReferenceEqualityComparer`1", 67118662, "Instance", SourceMemberKind.Field,
                51,
                "System.Collections.Generic.ReferenceEqualityComparer`1<T>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.CollectionExtensions", 33556171, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute",
                        "System.Void System.Runtime.CompilerServices.ExtensionAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.IntrospectiveSortUtilities", 33556172, 1048960,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.IntrospectiveSortUtilities", 67118663, "IntrosortSizeThreshold",
                SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00, 0x00, 0x00]), "System.Int32",
                "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ArraySortHelper`1", 33556173, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("T", 0, 704643478, 0, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ArraySortHelper`2", 33556174, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("TKey", 0, 704643480, 0,
                        [],
                        []),
                    new("TValue", 1, 704643481, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ArraySortHelper`2", 67118664, "s_defaultArraySortHelper",
                SourceMemberKind.Field, 17,
                "System.Collections.Generic.ArraySortHelper`2<TKey,TValue> modreq(System.Runtime.CompilerServices.IsVolatile)",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ArraySortHelper`2", 385879295, "Default", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ArraySortHelper`2<TKey,TValue>", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Comparer`1", 33556175, 1056897,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.Collections.IComparer", "System.Collections.Generic.IComparer`1<T>"],
                [
                    new("System.Runtime.CompilerServices.TypeDependencyAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x2B, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x4F,
                            0x62,
                            0x6A, 0x65, 0x63, 0x74, 0x43, 0x6F, 0x6D, 0x70, 0x61, 0x72, 0x65, 0x72, 0x60, 0x31, 0x00,
                            0x00,
                        ]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("T", 0, 704643482, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Comparer`1", 67118665, "defaultComparer", SourceMemberKind.Field, 17,
                "System.Collections.Generic.Comparer`1<T> modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Comparer`1", 385879296, "Default", SourceMemberKind.Property, 0,
                "System.Collections.Generic.Comparer`1<T>", 2198, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.GenericComparer`1", 33556176, 1056768,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Comparer`1<T>", [],
                [],
                null, [],
                [
                    new("T", 0, 704643484, 0, [],
                    [
                        new("System.IComparable`1<T>",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
                    ]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.NullableComparer`1", 33556177, 1056768,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Comparer`1<System.Nullable`1<T>>", [],
                [], null, [],
                [
                    new("T", 0, 704643485, 24, [],
                    [
                        new("System.IComparable`1<T>",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
                        new("System.ValueType",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
                    ]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ObjectComparer`1", 33556178, 1056768,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Comparer`1<T>", [],
                [],
                null, [],
                [
                    new("T", 0, 704643487, 0, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ComparisonComparer`1", 33556179, 1056768,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Comparer`1<T>", [],
                [],
                null, [],
                [
                    new("T", 0, 704643489, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.ComparisonComparer`1", 67118666, "_comparison", SourceMemberKind.Field, 33,
                "System.Comparison`1<T>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Mscorlib_CollectionDebugView`1", 33556180, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("T", 0, 704643491, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Mscorlib_CollectionDebugView`1", 67118667, "collection",
                SourceMemberKind.Field,
                1, "System.Collections.Generic.ICollection`1<T>", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Mscorlib_CollectionDebugView`1", 385879297, "Items",
                SourceMemberKind.Property,
                0, "T[]", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ]));
        }
    }
}
