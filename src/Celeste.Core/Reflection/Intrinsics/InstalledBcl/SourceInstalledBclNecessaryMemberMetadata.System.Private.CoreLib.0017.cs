using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceInstalledBclNecessaryMemberMetadata
    {
        private static void PublishSystem_Private_CoreLib0017(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 385881071, "Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TValue>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2")
                    })));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyList`1", 33556912, 1048737, null, null,
                new string[]
                {
                    "System.Collections.Generic.IReadOnlyCollection`1<T>",
                    "System.Collections.Generic.IEnumerable`1<T>",
                    "System.Collections.IEnumerable"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                    new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
                }, null,
                new string[]
                {
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("T", 0, 704643983, 1,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Collections.Generic.IReadOnlyCollection`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.IReadOnlyList`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.IReadOnlyList`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyList`1", 385881072, "Item", SourceMemberKind.Property, 0, "T",
                3526,
                -1, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IReadOnlyList`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 33556917, 1057033,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.ValueType", new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        new byte[]
                        {
                            0x01, 0x00, 0x4B, 0x6D, 0x73, 0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x2C, 0x20, 0x56, 0x65,
                            0x72,
                            0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x34, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x30, 0x2C, 0x20, 0x43,
                            0x75,
                            0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x6E, 0x65, 0x75, 0x74, 0x72, 0x61, 0x6C, 0x2C, 0x20,
                            0x50,
                            0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x3D, 0x62,
                            0x37,
                            0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30, 0x38, 0x39, 0x00,
                            0x00
                        })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TKey", 0, 704643986, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TValue", 1, 704643987, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                },
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.ValueType"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 67117676, "key", SourceMemberKind.Field, 33, "TKey", -1,
                -1, 0,
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 })
                }, false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 67117677, "value", SourceMemberKind.Field, 33, "TValue",
                -1,
                -1, 0,
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 })
                }, false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 385881073, "Key", SourceMemberKind.Property, 0, "TKey",
                2182,
                -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.KeyValuePair`2", 385881074, "Value", SourceMemberKind.Property, 0, "TValue",
                2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.KeyValuePair`2")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 33556918, 1056769,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Object",
                new string[]
                {
                    "System.Collections.Generic.IList`1<T>", "System.Collections.Generic.ICollection`1<T>",
                    "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                    "System.Collections.IList", "System.Collections.ICollection",
                    "System.Collections.Generic.IReadOnlyList`1<T>",
                    "System.Collections.Generic.IReadOnlyCollection`1<T>"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                    new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 }),
                    new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        new byte[]
                        {
                            0x01, 0x00, 0x31, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65,
                            0x63,
                            0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x49,
                            0x43,
                            0x6F, 0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56,
                            0x69,
                            0x65, 0x77, 0x60, 0x31, 0x00, 0x00
                        }),
                    new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        new byte[]
                        {
                            0x01, 0x00, 0x0F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x43, 0x6F, 0x75,
                            0x6E,
                            0x74, 0x7D, 0x00, 0x00
                        }),
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        new byte[]
                        {
                            0x01, 0x00, 0x4B, 0x6D, 0x73, 0x63, 0x6F, 0x72, 0x6C, 0x69, 0x62, 0x2C, 0x20, 0x56, 0x65,
                            0x72,
                            0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x34, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x30, 0x2C, 0x20, 0x43,
                            0x75,
                            0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x6E, 0x65, 0x75, 0x74, 0x72, 0x61, 0x6C, 0x2C, 0x20,
                            0x50,
                            0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x3D, 0x62,
                            0x37,
                            0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30, 0x38, 0x39, 0x00,
                            0x00
                        })
                }, null,
                new string[]
                {
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("T", 0, 704643988, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                },
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Object"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Collections.Generic.IList`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Collections.Generic.ICollection`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IList"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.ICollection"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Collections.Generic.IReadOnlyList`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Collections.Generic.IReadOnlyCollection`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Collections.Generic.List`1")
                        })
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117678, "_items", SourceMemberKind.Field, 3, "T[]", -1, -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        ownerTypeIdentity: "System.Collections.Generic.List`1"), arrayRank: 1,
                    arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                        { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117679, "_size", SourceMemberKind.Field, 3, "System.Int32", -1,
                -1,
                0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117680, "_version", SourceMemberKind.Field, 3, "System.Int32",
                -1,
                -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 67117681, "s_emptyArray", SourceMemberKind.Field, 49, "T[]", -1,
                -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        ownerTypeIdentity: "System.Collections.Generic.List`1"), arrayRank: 1,
                    arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                        { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881075, "Capacity", SourceMemberKind.Property, 0,
                "System.Int32",
                2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881076, "Count", SourceMemberKind.Property, 0, "System.Int32",
                2534,
                -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881077, "System.Collections.IList.IsFixedSize",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881078, "System.Collections.Generic.ICollection<T>.IsReadOnly",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881079, "System.Collections.IList.IsReadOnly",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881080, "System.Collections.ICollection.IsSynchronized",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881081, "System.Collections.ICollection.SyncRoot",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Object")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881082, "Item", SourceMemberKind.Property, 0, "T", 2534, 2534,
                1,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.List`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.List`1", 385881083, "System.Collections.IList.Item",
                SourceMemberKind.Property,
                0, "System.Object", 2529, 2529, 1,
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                }, false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Object")));
        }
    }
}
