using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl153(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIEnumerable`1+InternalPartitionEnumerator",
                385879237, "Current", SourceMemberKind.Property, 0,
                "System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIndexRange_Abstract`2", 33556138,
                1048707,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.OrderablePartitioner`1<TSource>", [],
                [], null, [],
                [
                    new("TSource", 0, 704643407, 0,
                        [],
                        []),
                    new("TCollection", 1, 704643408, 0,
                        [], []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIndexRange_Abstract`2", 67118580,
                "_data",
                SourceMemberKind.Field, 1, "TCollection", -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIndexRange_Abstract`2", 385879238,
                "SupportsDynamicPartitions", SourceMemberKind.Property, 0, "System.Boolean", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionEnumeratorForIndexRange_Abstract`2",
                33556139,
                1048707, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionEnumerator_Abstract`2<TSource,TSourceReader>",
                [], [], null, [],
                [
                    new("TSource", 0, 704643409, 0,
                        [],
                        []),
                    new("TSourceReader", 1, 704643410, 0,
                        [], []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionEnumeratorForIndexRange_Abstract`2",
                67118581,
                "_startIndex", SourceMemberKind.Field, 4, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionEnumeratorForIndexRange_Abstract`2",
                385879239,
                "SourceCount", SourceMemberKind.Property, 0, "System.Int32", 3524, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionEnumeratorForIndexRange_Abstract`2",
                385879240,
                "HasNoElementsLeft", SourceMemberKind.Property, 0, "System.Boolean", 2244, 2244, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIList`1", 33556140, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIndexRange_Abstract`2<TSource,System.Collections.Generic.IList`1<TSource>>",
                [], [], null, [],
                [
                    new("TSource", 0, 704643411, 0,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIList`1+InternalPartitionEnumerable",
                33556141, 1048579, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>>",
                    "System.Collections.IEnumerable",
                ], [], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TSource", 0, 704643412, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIList`1+InternalPartitionEnumerable",
                67118582, "_sharedReader", SourceMemberKind.Field, 33, "System.Collections.Generic.IList`1<TSource>",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIList`1+InternalPartitionEnumerable",
                67118583, "_sharedIndex", SourceMemberKind.Field, 1,
                "System.Collections.Concurrent.Partitioner+SharedLong",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIList`1+InternalPartitionEnumerator",
                33556142, 1048579, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionEnumeratorForIndexRange_Abstract`2<TSource,System.Collections.Generic.IList`1<TSource>>",
                [], [], null, [],
                [
                    new("TSource", 0, 704643414, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIList`1+InternalPartitionEnumerator",
                385879241, "SourceCount", SourceMemberKind.Property, 0, "System.Int32", 2244, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIList`1+InternalPartitionEnumerator",
                385879242, "Current", SourceMemberKind.Property, 0,
                "System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForArray`1", 33556143, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForIndexRange_Abstract`2<TSource,TSource[]>",
                [], [], null, [],
                [
                    new("TSource", 0, 704643416, 0,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForArray`1+InternalPartitionEnumerable",
                33556144, 1048579, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>>",
                    "System.Collections.IEnumerable",
                ], [], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TSource", 0, 704643418, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForArray`1+InternalPartitionEnumerable",
                67118584, "_sharedReader", SourceMemberKind.Field, 33, "TSource[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForArray`1+InternalPartitionEnumerable",
                67118585, "_sharedIndex", SourceMemberKind.Field, 1,
                "System.Collections.Concurrent.Partitioner+SharedLong",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForArray`1+InternalPartitionEnumerator",
                33556145, 1048579, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionEnumeratorForIndexRange_Abstract`2<TSource,TSource[]>",
                [], [], null, [],
                [
                    new("TSource", 0, 704643420, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForArray`1+InternalPartitionEnumerator",
                385879243, "SourceCount", SourceMemberKind.Property, 0, "System.Int32", 2244, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+DynamicPartitionerForArray`1+InternalPartitionEnumerator",
                385879244, "Current", SourceMemberKind.Property, 0,
                "System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>", 2246, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitioner`2", 33556146, 1048707,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.OrderablePartitioner`1<TSource>", [],
                [], null, [],
                [
                    new("TSource", 0, 704643422, 0,
                        [],
                        []),
                    new("TCollection", 1, 704643423, 0,
                        [], []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitioner`2", 385879245, "SourceCount",
                SourceMemberKind.Property, 0, "System.Int32", 3524, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1", 33556147, 1048707,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>>",
                    "System.IDisposable", "System.Collections.IEnumerator",
                ], [], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TSource", 0, 704643426, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1", 67118586, "_startIndex",
                SourceMemberKind.Field, 36, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1", 67118587, "_endIndex",
                SourceMemberKind.Field, 36, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1", 67118588, "_offset",
                SourceMemberKind.Field, 4, "System.Int32 modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1", 385879246, "Current",
                SourceMemberKind.Property, 0, "System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>", 3526,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1", 385879247,
                "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionerForIList`1", 33556148, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitioner`2<TSource,System.Collections.Generic.IList`1<TSource>>",
                [], [], null, [],
                [
                    new("TSource", 0, 704643429, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionerForIList`1", 67118589, "_list",
                SourceMemberKind.Field, 1, "System.Collections.Generic.IList`1<TSource>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionerForIList`1", 385879248,
                "SourceCount",
                SourceMemberKind.Property, 0, "System.Int32", 2244, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionForIList`1", 33556149, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1<TSource>", [],
                [], null, [],
                [
                    new("TSource", 0, 704643432, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionForIList`1", 67118590, "_list",
                SourceMemberKind.Field, 1,
                "System.Collections.Generic.IList`1<TSource> modreq(System.Runtime.CompilerServices.IsVolatile)", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionForIList`1", 385879249, "Current",
                SourceMemberKind.Property, 0, "System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>", 2246,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionerForArray`1", 33556150, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitioner`2<TSource,TSource[]>",
                [], [], null, [],
                [
                    new("TSource", 0, 704643435, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionerForArray`1", 67118591, "_array",
                SourceMemberKind.Field, 1, "TSource[]", -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionerForArray`1", 385879250,
                "SourceCount",
                SourceMemberKind.Property, 0, "System.Int32", 2244, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionForArray`1", 33556151, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartition`1<TSource>", [],
                [], null, [],
                [
                    new("TSource", 0, 704643437, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionForArray`1", 67118592, "_array",
                SourceMemberKind.Field, 1, "TSource[] modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+StaticIndexRangePartitionForArray`1", 385879251, "Current",
                SourceMemberKind.Property, 0, "System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>", 2246,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+SharedInt", 33556152, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+SharedInt", 67118593, "Value", SourceMemberKind.Field, 3,
                "System.Int32 modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+SharedBool", 33556153, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+SharedBool", 67118594, "Value", SourceMemberKind.Field, 3,
                "System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+SharedLong", 33556154, 1048579,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+SharedLong", 67118595, "Value", SourceMemberKind.Field, 3,
                "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 33556155, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.IEnumerable`1<System.Tuple`2<System.Int64,System.Int64>>",
                    "System.Collections.IEnumerable",
                    "System.Collections.Generic.IEnumerator`1<System.Tuple`2<System.Int64,System.Int64>>",
                    "System.IDisposable", "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118596, "<>1__state",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118597, "<>2__current",
                SourceMemberKind.Field, 1, "System.Tuple`2<System.Int64,System.Int64>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118598, "<>l__initialThreadId",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118599, "fromInclusive",
                SourceMemberKind.Field, 1, "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118600, "<>3__fromInclusive",
                SourceMemberKind.Field, 6, "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118601, "rangeSize",
                SourceMemberKind.Field, 1, "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118602, "<>3__rangeSize",
                SourceMemberKind.Field, 6, "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118603, "toExclusive",
                SourceMemberKind.Field, 1, "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118604, "<>3__toExclusive",
                SourceMemberKind.Field, 6, "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118605, "<i>5__1",
                SourceMemberKind.Field,
                1, "System.Int64", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 67118606, "<shouldQuit>5__2",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 385879252,
                "System.Collections.Generic.IEnumerator<System.Tuple<System.Int64,System.Int64>>.Current",
                SourceMemberKind.Property, 0, "System.Tuple`2<System.Int64,System.Int64>", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__6", 385879253,
                "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 33556156, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.IEnumerable`1<System.Tuple`2<System.Int32,System.Int32>>",
                    "System.Collections.IEnumerable",
                    "System.Collections.Generic.IEnumerator`1<System.Tuple`2<System.Int32,System.Int32>>",
                    "System.IDisposable", "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118607, "<>1__state",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118608, "<>2__current",
                SourceMemberKind.Field, 1, "System.Tuple`2<System.Int32,System.Int32>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118609, "<>l__initialThreadId",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118610, "fromInclusive",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118611, "<>3__fromInclusive",
                SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118612, "rangeSize",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118613, "<>3__rangeSize",
                SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118614, "toExclusive",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118615, "<>3__toExclusive",
                SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118616, "<i>5__1",
                SourceMemberKind.Field,
                1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 67118617, "<shouldQuit>5__2",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 385879254,
                "System.Collections.Generic.IEnumerator<System.Tuple<System.Int32,System.Int32>>.Current",
                SourceMemberKind.Property, 0, "System.Tuple`2<System.Int32,System.Int32>", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Concurrent.Partitioner+<CreateRanges>d__9", 385879255,
                "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.InsertionBehavior", 33556157, 256,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Byte", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.InsertionBehavior", 67118618, "value__", SourceMemberKind.Field, 1542,
                "System.Byte", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.InsertionBehavior", 67118619, "None", SourceMemberKind.Field, 32854,
                "System.Collections.Generic.InsertionBehavior", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x00]),
                "System.Byte", "00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.InsertionBehavior", 67118620, "OverwriteExisting", SourceMemberKind.Field,
                32854, "System.Collections.Generic.InsertionBehavior", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x01]),
                "System.Byte", "01",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.InsertionBehavior", 67118621, "ThrowOnExisting", SourceMemberKind.Field,
                32854,
                "System.Collections.Generic.InsertionBehavior", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x02]),
                "System.Byte", "02",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 33556158, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.IDictionary`2<TKey,TValue>",
                    "System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.IEnumerable", "System.Collections.IDictionary",
                    "System.Collections.ICollection",
                    "System.Collections.Generic.IReadOnlyDictionary`2<TKey,TValue>",
                    "System.Collections.Generic.IReadOnlyCollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Runtime.Serialization.ISerializable",
                    "System.Runtime.Serialization.IDeserializationCallback",
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
                            0x01, 0x00, 0x31, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x49,
                            0x44,
                            0x69, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x61, 0x72, 0x79, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56,
                            0x69,
                            0x65, 0x77, 0x60, 0x32, 0x00, 0x00,
                        ]),
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TKey", 0, 704643445, 0,
                        [],
                        []),
                    new("TValue", 1, 704643446, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118622, "_buckets", SourceMemberKind.Field, 1,
                "System.Int32[]", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118623, "_entries", SourceMemberKind.Field, 1,
                "System.Collections.Generic.Dictionary`2+Entry<TKey,TValue>[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118624, "_count", SourceMemberKind.Field, 1,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118625, "_freeList", SourceMemberKind.Field, 1,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118626, "_freeCount", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118627, "_version", SourceMemberKind.Field, 1,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118628, "_comparer", SourceMemberKind.Field, 1,
                "System.Collections.Generic.IEqualityComparer`1<TKey>", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118629, "_keys", SourceMemberKind.Field, 1,
                "System.Collections.Generic.Dictionary`2+KeyCollection<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118630, "_values", SourceMemberKind.Field, 1,
                "System.Collections.Generic.Dictionary`2+ValueCollection<TKey,TValue>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118631, "_syncRoot", SourceMemberKind.Field, 1,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118632, "VersionName", SourceMemberKind.Field, 32849,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */
                    [0x56, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00]),
                "System.String", "560065007200730069006F006E00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118633, "HashSizeName", SourceMemberKind.Field, 32849,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x48, 0x00, 0x61, 0x00, 0x73, 0x00, 0x68, 0x00, 0x53, 0x00, 0x69, 0x00, 0x7A, 0x00, 0x65, 0x00,
                    ]), "System.String", "4800610073006800530069007A006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118634, "KeyValuePairsName", SourceMemberKind.Field, 32849,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x4B, 0x00, 0x65, 0x00, 0x79, 0x00, 0x56, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x75, 0x00, 0x65, 0x00,
                        0x50, 0x00, 0x61, 0x00, 0x69, 0x00, 0x72, 0x00, 0x73, 0x00,
                    ]), "System.String", "4B0065007900560061006C007500650050006100690072007300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Collections.Generic.Dictionary`2", 67118635, "ComparerName", SourceMemberKind.Field, 32849,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x43, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x61, 0x00, 0x72, 0x00, 0x65, 0x00, 0x72, 0x00,
                    ]), "System.String", "43006F006D0070006100720065007200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
