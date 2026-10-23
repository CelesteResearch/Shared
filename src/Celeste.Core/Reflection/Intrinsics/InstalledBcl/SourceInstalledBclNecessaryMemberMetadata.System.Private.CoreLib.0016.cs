using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceInstalledBclNecessaryMemberMetadata
    {
        private static void PublishSystem_Private_CoreLib0016(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881018, "Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.Dictionary`2+KeyCollection<TKey,TValue>", 2182, -1, 0,
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte[])",
                        new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 })
                }, false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.Generic.Dictionary`2+KeyCollection"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881019,
                "System.Collections.Generic.IDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TKey>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881020,
                "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TKey>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
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
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881021, "Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.Dictionary`2+ValueCollection<TKey,TValue>", 2182, -1, 0,
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte[])",
                        new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 })
                }, false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.Generic.Dictionary`2+ValueCollection"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2"),
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881022,
                "System.Collections.Generic.IDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TValue>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881023,
                "System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TValue>", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
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
                            ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881024, "Item", SourceMemberKind.Property, 0, "TValue",
                2534,
                2534, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.Dictionary`2")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881025,
                "System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly",
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
                "System.Collections.Generic.Dictionary`2", 385881026, "System.Collections.ICollection.IsSynchronized",
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
                "System.Collections.Generic.Dictionary`2", 385881027, "System.Collections.ICollection.SyncRoot",
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
                "System.Collections.Generic.Dictionary`2", 385881028, "System.Collections.IDictionary.IsFixedSize",
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
                "System.Collections.Generic.Dictionary`2", 385881029, "System.Collections.IDictionary.IsReadOnly",
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
                "System.Collections.Generic.Dictionary`2", 385881030, "System.Collections.IDictionary.Keys",
                SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Collections.ICollection")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881031, "System.Collections.IDictionary.Values",
                SourceMemberKind.Property, 0, "System.Collections.ICollection", 2529, -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Collections.ICollection")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.Dictionary`2", 385881032, "System.Collections.IDictionary.Item",
                SourceMemberKind.Property, 0, "System.Object", 2529, 2529, 1,
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
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.ICollection`1", 33556897, 1048737, null, null,
                new string[] { "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable" },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null,
                new string[]
                {
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("T", 0, 704643965, 0,
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
                                ownerTypeIdentity: "System.Collections.Generic.ICollection`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.ICollection`1", 385881057, "Count", SourceMemberKind.Property, 0,
                "System.Int32", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.ICollection`1", 385881058, "IsReadOnly", SourceMemberKind.Property, 0,
                "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 33556900, 1048737, null, null,
                new string[]
                {
                    "System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
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
                    new SourceGenericParameterDefinition("TKey", 0, 704643968, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TValue", 1, 704643969, 0,
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
                            typeIdentity: "System.Collections.Generic.ICollection`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                    assemblyIdentity:
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    typeIdentity: "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                {
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2")
                                })
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
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                    assemblyIdentity:
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    typeIdentity: "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                {
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2"),
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IDictionary`2")
                                })
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 385881060, "Item", SourceMemberKind.Property, 0, "TValue",
                3526,
                3526, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IDictionary`2")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 385881061, "Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TKey>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.IDictionary`2")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IDictionary`2", 385881062, "Values", SourceMemberKind.Property, 0,
                "System.Collections.Generic.ICollection`1<TValue>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                            genericParameterPosition: 1,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.IDictionary`2")
                    })));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IEnumerable`1", 33556904, 1048737, null, null,
                new string[] { "System.Collections.IEnumerable" }, Array.Empty<SourceDeclaredAttribute>(), null,
                new string[]
                    { "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e" },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("T", 0, 704643976, 1,
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
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable")
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IEnumerator`1", 33556905, 1048737, null, null,
                new string[] { "System.IDisposable", "System.Collections.IEnumerator" },
                Array.Empty<SourceDeclaredAttribute>(), null,
                new string[]
                {
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("T", 0, 704643977, 1,
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
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IDisposable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerator")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IEnumerator`1", 385881066, "Current", SourceMemberKind.Property, 0, "T",
                3526,
                -1, 0,
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IEnumerator`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IList`1", 33556908, 1048737, null, null,
                new string[]
                {
                    "System.Collections.Generic.ICollection`1<T>", "System.Collections.Generic.IEnumerable`1<T>",
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
                    new SourceGenericParameterDefinition("T", 0, 704643979, 0,
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
                                ownerTypeIdentity: "System.Collections.Generic.IList`1")
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
                                ownerTypeIdentity: "System.Collections.Generic.IList`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IList`1", 385881067, "Item", SourceMemberKind.Property, 0, "T", 3526, 3526,
                1,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IList`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyCollection`1", 33556910, 1048737, null, null,
                new string[] { "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable" },
                Array.Empty<SourceDeclaredAttribute>(), null,
                new string[]
                {
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("T", 0, 704643980, 1,
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
                                ownerTypeIdentity: "System.Collections.Generic.IReadOnlyCollection`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyCollection`1", 385881068, "Count", SourceMemberKind.Property, 0,
                "System.Int32", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 33556911, 1048737, null, null,
                new string[]
                {
                    "System.Collections.Generic.IReadOnlyCollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                    "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
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
                    new SourceGenericParameterDefinition("TKey", 0, 704643981, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TValue", 1, 704643982, 0,
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
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                    assemblyIdentity:
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    typeIdentity: "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                {
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2")
                                })
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
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                    assemblyIdentity:
                                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                    typeIdentity: "System.Collections.Generic.KeyValuePair`2"),
                                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                {
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 0,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2"),
                                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                        genericParameterPosition: 1,
                                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                            .SourceGenericParameterOwnerKind.Type,
                                        ownerAssemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2")
                                })
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.Collections.IEnumerable")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 385881069, "Item", SourceMemberKind.Property, 0,
                "TValue", 3526, -1, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Collections.Generic.IReadOnlyDictionary`2", 385881070, "Keys", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<TKey>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
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
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind
                                .Type,
                            ownerAssemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            ownerTypeIdentity: "System.Collections.Generic.IReadOnlyDictionary`2")
                    })));
        }
    }
}
