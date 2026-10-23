using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl155(SourceMemberCatalog catalog)
    {
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryKeyCollectionDebugView`2", 33556181, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TKey", 0, 704643493, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TValue", 1, 704643494, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryKeyCollectionDebugView`2", 67118668, "collection",
            SourceMemberKind.Field, 1, "System.Collections.Generic.ICollection`1<TKey>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryKeyCollectionDebugView`2", 385879298, "Items",
            SourceMemberKind.Property, 0, "TKey[]", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                    "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                    new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryValueCollectionDebugView`2", 33556182, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TKey", 0, 704643496, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TValue", 1, 704643497, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryValueCollectionDebugView`2", 67118669, "collection",
            SourceMemberKind.Field, 1, "System.Collections.Generic.ICollection`1<TValue>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryValueCollectionDebugView`2", 385879299, "Items",
            SourceMemberKind.Property, 0, "TValue[]", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                    "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                    new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryDebugView`2", 33556183, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("K", 0, 704643498, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("V", 1, 704643499, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryDebugView`2", 67118670, "dict", SourceMemberKind.Field, 1,
            "System.Collections.Generic.IDictionary`2<K,V>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_DictionaryDebugView`2", 385879300, "Items", SourceMemberKind.Property,
            0, "System.Collections.Generic.KeyValuePair`2<K,V>[]", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                    "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                    new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_KeyedCollectionDebugView`2", 33556184, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("K", 0, 704643500, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("T", 1, 704643501, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_KeyedCollectionDebugView`2", 67118671, "kc", SourceMemberKind.Field, 1,
            "System.Collections.ObjectModel.KeyedCollection`2<K,T>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.Mscorlib_KeyedCollectionDebugView`2", 385879301, "Items",
            SourceMemberKind.Property, 0, "T[]", 2182, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerBrowsableAttribute",
                    "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                    new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1", 33556185, 1056897,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
                { "System.Collections.IEqualityComparer", "System.Collections.Generic.IEqualityComparer`1<T>" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeDependencyAttribute",
                    "System.Void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x33, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x4F, 0x62,
                        0x6A, 0x65, 0x63, 0x74, 0x45, 0x71, 0x75, 0x61, 0x6C, 0x69, 0x74, 0x79, 0x43, 0x6F, 0x6D, 0x70,
                        0x61, 0x72, 0x65, 0x72, 0x60, 0x31, 0x00, 0x00
                    })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643502, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1", 67118672, "defaultComparer", SourceMemberKind.Field, 17,
            "System.Collections.Generic.EqualityComparer`1<T> modreq(System.Runtime.CompilerServices.IsVolatile)", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1", 385879302, "Default", SourceMemberKind.Property, 0,
            "System.Collections.Generic.EqualityComparer`1<T>", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.GenericEqualityComparer`1", 33556186, 1056768,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1<T>", Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643503, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[]
                    {
                        new SourceGenericParameterConstraint("System.IEquatable`1<T>",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.NullableEqualityComparer`1", 33556187, 1056768,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1<System.Nullable`1<T>>", Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643504, 24, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[]
                    {
                        new SourceGenericParameterConstraint("System.IEquatable`1<T>",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
                        new SourceGenericParameterConstraint("System.ValueType",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.ObjectEqualityComparer`1", 33556188, 1056768,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1<T>", Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643505, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.ByteEqualityComparer", 33556189, 1056768,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1<System.Byte>", Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EnumEqualityComparer`1", 33556190, 1056768,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1<T>",
            new string[] { "System.Runtime.Serialization.ISerializable" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643506, 24, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[]
                    {
                        new SourceGenericParameterConstraint("System.ValueType",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.SByteEnumEqualityComparer`1", 33556191, 1057024,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EnumEqualityComparer`1<T>",
            new string[] { "System.Runtime.Serialization.ISerializable" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643507, 24, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[]
                    {
                        new SourceGenericParameterConstraint("System.ValueType",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.ShortEnumEqualityComparer`1", 33556192, 1057024,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EnumEqualityComparer`1<T>",
            new string[] { "System.Runtime.Serialization.ISerializable" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643508, 24, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[]
                    {
                        new SourceGenericParameterConstraint("System.ValueType",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.LongEnumEqualityComparer`1", 33556193, 1057024,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1<T>",
            new string[] { "System.Runtime.Serialization.ISerializable" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643509, 24, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[]
                    {
                        new SourceGenericParameterConstraint("System.ValueType",
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.InternalStringComparer", 33556194, 1057024,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.EqualityComparer`1<System.String>", Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.ICollection`1", 33556195, 161, null, null,
            new string[] { "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeDependencyAttribute",
                    "System.Void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x14, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x53, 0x5A, 0x41, 0x72, 0x72, 0x61,
                        0x79, 0x48, 0x65, 0x6C, 0x70, 0x65, 0x72, 0x00, 0x00
                    })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643510, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.ICollection`1", 385879303, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.ICollection`1", 385879304, "IsReadOnly", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IComparer`1", 33556196, 161, null, null, Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643511, 2, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IDictionary`2", 33556197, 161, null, null,
            new string[]
            {
                "System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                "System.Collections.IEnumerable"
            },
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
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TKey", 0, 704643512, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TValue", 1, 704643513, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IDictionary`2", 385879305, "Item", SourceMemberKind.Property, 0, "TValue", 3526,
            3526, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IDictionary`2", 385879306, "Keys", SourceMemberKind.Property, 0,
            "System.Collections.Generic.ICollection`1<TKey>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IDictionary`2", 385879307, "Values", SourceMemberKind.Property, 0,
            "System.Collections.Generic.ICollection`1<TValue>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IEnumerable`1", 33556198, 161, null, null,
            new string[] { "System.Collections.IEnumerable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeDependencyAttribute",
                    "System.Void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x14, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x53, 0x5A, 0x41, 0x72, 0x72, 0x61,
                        0x79, 0x48, 0x65, 0x6C, 0x70, 0x65, 0x72, 0x00, 0x00
                    })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643514, 1, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IEnumerator`1", 33556199, 161, null, null,
            new string[] { "System.IDisposable", "System.Collections.IEnumerator" },
            Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643515, 1, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IEnumerator`1", 385879308, "Current", SourceMemberKind.Property, 0, "T", 3526,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IEqualityComparer`1", 33556200, 161, null, null, Array.Empty<string>(),
            Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643516, 2, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IList`1", 33556201, 161, null, null,
            new string[]
            {
                "System.Collections.Generic.ICollection`1<T>", "System.Collections.Generic.IEnumerable`1<T>",
                "System.Collections.IEnumerable"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeDependencyAttribute",
                    "System.Void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x14, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x53, 0x5A, 0x41, 0x72, 0x72, 0x61,
                        0x79, 0x48, 0x65, 0x6C, 0x70, 0x65, 0x72, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643517, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IList`1", 385879309, "Item", SourceMemberKind.Property, 0, "T", 3526, 3526, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyCollection`1", 33556202, 161, null, null,
            new string[] { "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeDependencyAttribute",
                    "System.Void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x14, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x53, 0x5A, 0x41, 0x72, 0x72, 0x61,
                        0x79, 0x48, 0x65, 0x6C, 0x70, 0x65, 0x72, 0x00, 0x00
                    })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643518, 1, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyCollection`1", 385879310, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyDictionary`2", 33556203, 161, null, null,
            new string[]
            {
                "System.Collections.Generic.IReadOnlyCollection`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey,TValue>>",
                "System.Collections.IEnumerable"
            },
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
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TKey", 0, 704643519, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { }),
                new SourceGenericParameterDefinition("TValue", 1, 704643520, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyDictionary`2", 385879311, "Item", SourceMemberKind.Property, 0,
            "TValue", 3526, -1, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyDictionary`2", 385879312, "Keys", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<TKey>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyDictionary`2", 385879313, "Values", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<TValue>", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyList`1", 33556204, 161, null, null,
            new string[]
            {
                "System.Collections.Generic.IReadOnlyCollection`1<T>", "System.Collections.Generic.IEnumerable`1<T>",
                "System.Collections.IEnumerable"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.TypeDependencyAttribute",
                    "System.Void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x14, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x53, 0x5A, 0x41, 0x72, 0x72, 0x61,
                        0x79, 0x48, 0x65, 0x6C, 0x70, 0x65, 0x72, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643521, 1, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.IReadOnlyList`1", 385879314, "Item", SourceMemberKind.Property, 0, "T", 3526,
            -1, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.KeyNotFoundException", 33556205, 1056769,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
            new string[] { "System.Runtime.Serialization.ISerializable" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 33556206, 1056769,
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
                new SourceDeclaredAttribute("System.Reflection.DefaultMemberAttribute",
                    "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                    new byte[] { 0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00 }),
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
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643522, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 67118673, "_defaultCapacity", SourceMemberKind.Field, 32849,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 67118674, "_items", SourceMemberKind.Field, 1, "T[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 67118675, "_size", SourceMemberKind.Field, 1, "System.Int32", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 67118676, "_version", SourceMemberKind.Field, 1, "System.Int32", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 67118677, "_syncRoot", SourceMemberKind.Field, 129, "System.Object",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 67118678, "_emptyArray", SourceMemberKind.Field, 49, "T[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879315, "Capacity", SourceMemberKind.Property, 0, "System.Int32",
            2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879316, "Count", SourceMemberKind.Property, 0, "System.Int32", 2534,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879317, "System.Collections.IList.IsFixedSize",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879318, "System.Collections.Generic.ICollection<T>.IsReadOnly",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879319, "System.Collections.IList.IsReadOnly",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879320, "System.Collections.ICollection.IsSynchronized",
            SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879321, "System.Collections.ICollection.SyncRoot",
            SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879322, "Item", SourceMemberKind.Property, 0, "T", 2534, 2534, 1,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1", 385879323, "System.Collections.IList.Item", SourceMemberKind.Property,
            0, "System.Object", 2529, 2529, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+SynchronizedList", 33556207, 1056773,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.IList`1<T>", "System.Collections.Generic.ICollection`1<T>",
                "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable"
            },
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
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643523, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+SynchronizedList", 67118679, "_list", SourceMemberKind.Field, 1,
            "System.Collections.Generic.List`1<T>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+SynchronizedList", 67118680, "_root", SourceMemberKind.Field, 1,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+SynchronizedList", 385879324, "Count", SourceMemberKind.Property, 0,
            "System.Int32", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+SynchronizedList", 385879325, "IsReadOnly", SourceMemberKind.Property, 0,
            "System.Boolean", 2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+SynchronizedList", 385879326, "Item", SourceMemberKind.Property, 0, "T",
            2534, 2534, 1, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+Enumerator", 33556208, 1057034,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[]
            {
                "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable", "System.Collections.IEnumerator"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643524, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+Enumerator", 67118681, "list", SourceMemberKind.Field, 1,
            "System.Collections.Generic.List`1<T>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+Enumerator", 67118682, "index", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+Enumerator", 67118683, "version", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+Enumerator", 67118684, "current", SourceMemberKind.Field, 1, "T", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+Enumerator", 385879327, "Current", SourceMemberKind.Property, 0, "T",
            2534, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Collections.Generic.List`1+Enumerator", 385879328, "System.Collections.IEnumerator.Current",
            SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Buffers.IRetainable",
            33556209, 161, null, null, Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.MemoryHandle", 33556210, 1048841,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[] { "System.IDisposable" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.MemoryHandle", 67118685, "_retainable", SourceMemberKind.Field, 1,
            "System.Buffers.IRetainable", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.MemoryHandle", 67118686, "_pointer", SourceMemberKind.Field, 1, "System.Void*", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.MemoryHandle", 67118687, "_handle", SourceMemberKind.Field, 1,
            "System.Runtime.InteropServices.GCHandle", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.MemoryHandle", 385879329, "Pointer", SourceMemberKind.Property, 0, "System.Void*", 2182, -1,
            0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.CLSCompliantAttribute",
                    "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.MemoryHandle", 385879330, "HasPointer", SourceMemberKind.Property, 0, "System.Boolean",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OwnedMemory`1", 33556211, 1048705,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.IDisposable", "System.Buffers.IRetainable" }, Array.Empty<SourceDeclaredAttribute>(),
            null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("T", 0, 704643525, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OwnedMemory`1", 385879331, "Length", SourceMemberKind.Property, 0, "System.Int32", 3526, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OwnedMemory`1", 385879332, "Span", SourceMemberKind.Property, 0, "System.Span`1<T>", 3526,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OwnedMemory`1", 385879333, "Memory", SourceMemberKind.Property, 0, "System.Memory`1<T>",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OwnedMemory`1", 385879334, "IsRetained", SourceMemberKind.Property, 0, "System.Boolean",
            3524, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OwnedMemory`1", 385879335, "IsDisposed", SourceMemberKind.Property, 0, "System.Boolean",
            3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OperationStatus", 33556212, 257,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OperationStatus", 67118688, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OperationStatus", 67118689, "Done", SourceMemberKind.Field, 32854,
            "System.Buffers.OperationStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OperationStatus", 67118690, "DestinationTooSmall", SourceMemberKind.Field, 32854,
            "System.Buffers.OperationStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OperationStatus", 67118691, "NeedMoreData", SourceMemberKind.Field, 32854,
            "System.Buffers.OperationStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.OperationStatus", 67118692, "InvalidData", SourceMemberKind.Field, 32854,
            "System.Buffers.OperationStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Buffers.StandardFormat", 33556213, 1048841,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[] { "System.IEquatable`1<System.Buffers.StandardFormat>" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                    "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
    }
}
