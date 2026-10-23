using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

// ReSharper disable once CheckNamespace
namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceInstalledBclNecessaryMemberMetadata
    {
        private static void PublishSystem_Private_CoreLib0017(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 385881071, "Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TValue>", 3526, -1, 0, (SourceDeclaredAttribute[])[],
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
                            ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyList`1", 33556912, 1048737, null, null,
                [
                    "System.Collections.Generic.IReadOnlyCollection`1<T>",
                    "System.Collections.Generic.IEnumerable`1<T>",
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
                    new("T", 0, 704643983, 1,
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
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.IReadOnlyList`1"),
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
                                ownerTypeIdentity: "System.Collections.Generic.IReadOnlyList`1"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyList`1", 385881072, "Item", SourceMemberKind.Property, 0, "T",
                3526,
                -1, 1, (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IReadOnlyList`1")));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 33556917, 1057033,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.ValueType", [],
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4B, 0x6D, 0x73, 0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x2C, 0x20, 0x56, 0x65,
                            0x72,
                            0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x34, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x30, 0x2C, 0x20, 0x43,
                            0x75,
                            0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x6E, 0x65, 0x75, 0x74, 0x72, 0x61, 0x6C, 0x2C, 0x20,
                            0x50,
                            0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x3D, 0x62,
                            0x37,
                            0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30, 0x38, 0x39, 0x00,
                            0x00,
                        ]),
                ], null, [],
                [
                    new("TKey", 0, 704643986, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                    new("TValue", 1, 704643987, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.ValueType"),
                []));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 67117676, "key", SourceMemberKind.Field, 33, "TKey", -1,
                -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 67117677, "value", SourceMemberKind.Field, 33, "TValue",
                -1,
                -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 385881073, "Key", SourceMemberKind.Property, 0, "TKey",
                2182,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 385881074, "Value", SourceMemberKind.Property, 0, "TValue",
                2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterTypeDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 33556918, 1056769,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Object",
                [
                    "System.Collections.Generic.IList`1<T>", "System.Collections.Generic.ICollection`1<T>",
                    "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                    "System.Collections.IList", "System.Collections.ICollection",
                    "System.Collections.Generic.IReadOnlyList`1<T>",
                    "System.Collections.Generic.IReadOnlyCollection`1<T>",
                ],
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                    new("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x31, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x49,
                            0x43,
                            0x6F, 0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56,
                            0x69,
                            0x65, 0x77, 0x60, 0x31, 0x00, 0x00,
                        ]),
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75,
                            0x6E,
                            0x74, 0x7D, 0x00, 0x00,
                        ]),
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4B, 0x6D, 0x73, 0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x2C, 0x20, 0x56, 0x65,
                            0x72,
                            0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x34, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x30, 0x2C, 0x20, 0x43,
                            0x75,
                            0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x6E, 0x65, 0x75, 0x74, 0x72, 0x61, 0x6C, 0x2C, 0x20,
                            0x50,
                            0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x3D, 0x62,
                            0x37,
                            0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30, 0x38, 0x39, 0x00,
                            0x00,
                        ]),
                ], null,
                [
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                ],
                [
                    new("T", 0, 704643988, 0,
                    [
                        new("System.Runtime.CompilerServices.NullableAttribute",
                            "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                            /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x02, 0x00, 0x00]),
                    ], []),
                ],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IList`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1"),
                        ]),
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
                                ownerTypeIdentity: "System.Collections.Generic.List`1"),
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
                                ownerTypeIdentity: "System.Collections.Generic.List`1"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IEnumerable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.IList"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "System.Collections.ICollection"),
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IReadOnlyList`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1"),
                        ]),
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Generic.IReadOnlyCollection`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1"),
                        ]),
                ]));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117678, "_items", SourceMemberKind.Field, 3, "T[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        ownerTypeIdentity: "System.Collections.Generic.List`1"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117679, "_size", SourceMemberKind.Field, 3, "System.Int32", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117680, "_version", SourceMemberKind.Field, 3, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117681, "s_emptyArray", SourceMemberKind.Field, 49, "T[]", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        ownerTypeIdentity: "System.Collections.Generic.List`1"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881075, "Capacity", SourceMemberKind.Property, 0,
                "System.Int32",
                2182, 2182, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881076, "Count", SourceMemberKind.Property, 0, "System.Int32",
                2534,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881077, "System.Collections.IList.IsFixedSize",
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
                "System.Collections.Generic.List`1", 385881078, "System.Collections.Generic.ICollection<T>.IsReadOnly",
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
                "System.Collections.Generic.List`1", 385881079, "System.Collections.IList.IsReadOnly",
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
                "System.Collections.Generic.List`1", 385881080, "System.Collections.ICollection.IsSynchronized",
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
                "System.Collections.Generic.List`1", 385881081, "System.Collections.ICollection.SyncRoot",
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
                "System.Collections.Generic.List`1", 385881082, "Item", SourceMemberKind.Property, 0, "T", 2534, 2534,
                1,
                (SourceDeclaredAttribute[])[], false, null, null, null, null,
                new(
                    SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.List`1")));
            catalog.RegisterDefinition(new(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881083, "System.Collections.IList.Item",
                SourceMemberKind.Property,
                0, "System.Object", 2529, 2529, 1,
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
        }
    }
}
