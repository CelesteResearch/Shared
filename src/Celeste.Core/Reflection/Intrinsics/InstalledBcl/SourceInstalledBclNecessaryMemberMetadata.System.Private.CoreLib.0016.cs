using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

// ReSharper disable once CheckNamespace
namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceInstalledBclNecessaryMemberMetadata
    {
        private static void PublishSystem_Private_CoreLib0016(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881018, "Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.Dictionary`2+KeyCollection<TKey,TValue>", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte[])",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.Dictionary`2+KeyCollection"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                    ])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881019,
                "System.Collections.Generic.IDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TKey>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.ICollection`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                    ])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881020,
                "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TKey>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                    ])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881021, "Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.Dictionary`2+ValueCollection<TKey,TValue>", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte[])",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.Dictionary`2+ValueCollection"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                    ])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881022,
                "System.Collections.Generic.IDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TValue>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.ICollection`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                    ])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881023,
                "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TValue>", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                    ])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881024, "Item", SourceMemberKind.Property, 0, "TValue",
                2534,
                2534, 1, (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881025,
                "System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881026, "System.Collections.ICollection.IsSynchronized",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881027, "System.Collections.ICollection.SyncRoot",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881028, "System.Collections.IDictionary.IsFixedSize",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881029, "System.Collections.IDictionary.IsReadOnly",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881030, "System.Collections.IDictionary.Keys",
                SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Collections.ICollection")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881031, "System.Collections.IDictionary.Values",
                SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Collections.ICollection")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881032, "System.Collections.IDictionary.Item",
                SourceMemberKind.Property, 0, "System.Object", 2529, 2529, 1,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                ], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.ICollection`1", 33556897, 1048737, null, null,
                ["System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable"],
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null,
                [
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                ],
                [
                    new("T", 0, 704643965, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ], null,
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IEnumerable`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.ICollection`1"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.ICollection`1", 385881057, "Count", SourceMemberKind.Property, 0,
                "System.Int32", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.ICollection`1", 385881058, "IsReadOnly", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 33556900, 1048737, null, null,
                [
                    "System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.IEnumerable",
                ],
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                ], null,
                [
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                ],
                [
                    new("TKey", 0, 704643968, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                    new("TValue", 1, 704643969, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ], null,
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.ICollection`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericInstance,
                                elementType: new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments:
                                [
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                                ]),
                        ]),
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IEnumerable`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericInstance,
                                elementType: new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments:
                                [
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                                ]),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 385881060, "Item", SourceMemberKind.Property, 0, "TValue",
                3526,
                3526, 1, (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IDictionary`2")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 385881061, "Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TKey>", 3526, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.ICollection`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                    ])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 385881062, "Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TValue>", 3526, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.ICollection`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IEnumerable`1", 33556904, 1048737, null, null,
                ["System.Collections.IEnumerable"], [], null,
                ["System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"],
                [
                    new("T", 0, 704643976, 1,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ], null,
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                ]));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IEnumerator`1", 33556905, 1048737, null, null,
                ["System.IDisposable", "System.Collections.IEnumerator"],
                [], null,
                [
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                ],
                [
                    new("T", 0, 704643977, 1,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ], null,
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IEnumerator`1", 385881066, "Current", SourceMemberKind.Property, 0, "T",
                3526,
                -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IEnumerator`1")));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IList`1", 33556908, 1048737, null, null,
                [
                    "System.Collections.Generic.ICollection`1<T>", "System.Collections.Generic.IEnumerable`1<T>",
                    "System.Collections.IEnumerable",
                ],
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                ], null,
                [
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                ],
                [
                    new("T", 0, 704643979, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ], null,
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.ICollection`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.IList`1"),
                        ]),
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IEnumerable`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.IList`1"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IList`1", 385881067, "Item", SourceMemberKind.Property, 0, "T", 3526, 3526,
                1,
                (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IList`1")));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyCollection`1", 33556910, 1048737, null, null,
                ["System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable"],
                [], null,
                [
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                ],
                [
                    new("T", 0, 704643980, 1,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ], null,
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IEnumerable`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.IReadOnlyCollection`1"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyCollection`1", 385881068, "Count", SourceMemberKind.Property, 0,
                "System.Int32", 3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Int32")));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 33556911, 1048737, null, null,
                [
                    "System.Collections.Generic.IReadOnlyCollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.IEnumerable",
                ],
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                ], null,
                [
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                ],
                [
                    new("TKey", 0, 704643981, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                    new("TValue", 1, 704643982, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ], null,
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IReadOnlyCollection`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericInstance,
                                elementType: new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments:
                                [
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                                ]),
                        ]),
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IEnumerable`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericInstance,
                                elementType: new(
                                    SourceTypeReferenceKind.Named,
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments:
                                [
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                                    new(
                                        SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                                ]),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 385881069, "Item", SourceMemberKind.Property, 0,
                "TValue", 3526, -1, 1, (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 385881070, "Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TKey>", 3526, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                    ])));
        }
    }
}
