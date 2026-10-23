using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceInstalledBclNecessaryMemberMetadata
    {
        private static void PublishSystem_Private_CoreLib0012(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.UIntPtr", 385878024,
                "System.Numerics.IMultiplicativeIdentity<nuint,nuint>.MultiplicativeIdentity",
                SourceMemberKind.Property, 0, "System.UIntPtr", 2193, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
                false,
                null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.UIntPtr")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.UIntPtr", 385878025, "System.Numerics.INumberBase<nuint>.One", SourceMemberKind.Property, 0,
                "System.UIntPtr", 2193, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.UIntPtr")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.UIntPtr", 385878026, "System.Numerics.INumberBase<nuint>.Radix", SourceMemberKind.Property, 0,
                "System.Int32", 2193, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.UIntPtr", 385878027, "System.Numerics.INumberBase<nuint>.Zero", SourceMemberKind.Property, 0,
                "System.UIntPtr", 2193, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.UIntPtr")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Void",
                33554941, 1048841,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.ValueType", new string[] { }, Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
                new SourceGenericParameterDefinition[] { },
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.ValueType"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.IParsable`1", 33554953, 1048737, null, null, new string[] { },
                Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643492, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.IParsable`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.IParsable`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.IParsable`1")
                                    }))
                        })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.ISpanParsable`1", 33554954, 1048737, null, null, new string[] { "System.IParsable`1<TSelf>" },
                Array.Empty<SourceDeclaredAttribute>(), null,
                new string[]
                    { "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e" },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643493, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.ISpanParsable`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.ISpanParsable`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.ISpanParsable`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.ISpanParsable`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IAdditionOperators`3", 33554975, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643499, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IAdditionOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IAdditionOperators`3"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IAdditionOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IAdditionOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IAdditionOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643500, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643501, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IAdditiveIdentity`2", 33554976, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643502, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IAdditiveIdentity`2<TSelf,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IAdditiveIdentity`2")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TResult", 1, 704643503, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IAdditiveIdentity`2", 385878125, "AdditiveIdentity", SourceMemberKind.Property, 0,
                "TResult", 3286, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IAdditiveIdentity`2")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IBinaryFloatingPointIeee754`1", 33554977, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.IBinaryNumber`1<TSelf>", "System.Numerics.IBitwiseOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.INumber`1<TSelf>", "System.IComparable", "System.IComparable`1<TSelf>",
                    "System.Numerics.IComparisonOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IModulusOperators`3<TSelf,TSelf,TSelf>", "System.Numerics.INumberBase`1<TSelf>",
                    "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>", "System.Numerics.IFloatingPointIeee754`1<TSelf>",
                    "System.Numerics.IExponentialFunctions`1<TSelf>",
                    "System.Numerics.IFloatingPointConstants`1<TSelf>",
                    "System.Numerics.IFloatingPoint`1<TSelf>", "System.Numerics.ISignedNumber`1<TSelf>",
                    "System.Numerics.IHyperbolicFunctions`1<TSelf>", "System.Numerics.ILogarithmicFunctions`1<TSelf>",
                    "System.Numerics.IPowerFunctions`1<TSelf>", "System.Numerics.IRootFunctions`1<TSelf>",
                    "System.Numerics.ITrigonometricFunctions`1<TSelf>"
                }, Array.Empty<SourceDeclaredAttribute>(), null,
                new string[]
                {
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643504, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IBinaryFloatingPointIeee754`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IBinaryNumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IBitwiseOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IComparable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IComparable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IComparisonOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IModulusOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IExponentialFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPoint`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISignedNumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IPowerFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IRootFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryFloatingPointIeee754`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IBinaryInteger`1", 33554978, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.IBinaryNumber`1<TSelf>", "System.Numerics.IBitwiseOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.INumber`1<TSelf>", "System.IComparable", "System.IComparable`1<TSelf>",
                    "System.Numerics.IComparisonOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IModulusOperators`3<TSelf,TSelf,TSelf>", "System.Numerics.INumberBase`1<TSelf>",
                    "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>", "System.Numerics.IShiftOperators`3<TSelf,System.Int32,TSelf>"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643505, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IBinaryInteger`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IBinaryInteger`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IBinaryNumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IBitwiseOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IComparable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IComparable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IComparisonOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IModulusOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IShiftOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Int32"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryInteger`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IBinaryNumber`1", 33554979, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.IBitwiseOperators`3<TSelf,TSelf,TSelf>", "System.Numerics.INumber`1<TSelf>",
                    "System.IComparable", "System.IComparable`1<TSelf>",
                    "System.Numerics.IComparisonOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IModulusOperators`3<TSelf,TSelf,TSelf>", "System.Numerics.INumberBase`1<TSelf>",
                    "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>"
                }, Array.Empty<SourceDeclaredAttribute>(), null,
                new string[]
                {
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643506, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IBinaryNumber`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IBinaryNumber`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IBitwiseOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IComparable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IComparable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IComparisonOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IModulusOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")
                        })
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IBinaryNumber`1", 385878126, "AllBitsSet", SourceMemberKind.Property, 0, "TSelf", 2262,
                -1,
                0,
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
                    ownerTypeIdentity: "System.Numerics.IBinaryNumber`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IBitwiseOperators`3", 33554980, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643507, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IBitwiseOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IBitwiseOperators`3"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IBitwiseOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IBitwiseOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IBitwiseOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643508, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643509, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IComparisonOperators`3", 33554981, 1048737, null, null,
                new string[] { "System.Numerics.IEqualityOperators`3<TSelf,TOther,TResult>" },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null,
                new string[]
                    { "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e" },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643510, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IComparisonOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IComparisonOperators`3"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IComparisonOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IComparisonOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IComparisonOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643511, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643512, 0,
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
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IComparisonOperators`3"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 1,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IComparisonOperators`3"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 2,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IComparisonOperators`3")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IDecrementOperators`1", 33554982, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643513, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IDecrementOperators`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IDecrementOperators`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IDecrementOperators`1")
                                    }))
                        })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IDivisionOperators`3", 33554983, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643514, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IDivisionOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IDivisionOperators`3"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IDivisionOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IDivisionOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IDivisionOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643515, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643516, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IEqualityOperators`3", 33554984, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643517, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IEqualityOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IEqualityOperators`3"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IEqualityOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IEqualityOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IEqualityOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643518, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643519, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IExponentialFunctions`1", 33554985, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.IFloatingPointConstants`1<TSelf>", "System.Numerics.INumberBase`1<TSelf>",
                    "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643520, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IExponentialFunctions`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IExponentialFunctions`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IExponentialFunctions`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPoint`1", 33554986, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.IFloatingPointConstants`1<TSelf>", "System.Numerics.INumberBase`1<TSelf>",
                    "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>", "System.Numerics.INumber`1<TSelf>", "System.IComparable",
                    "System.IComparable`1<TSelf>", "System.Numerics.IComparisonOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IModulusOperators`3<TSelf,TSelf,TSelf>", "System.Numerics.ISignedNumber`1<TSelf>"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643521, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IFloatingPoint`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IFloatingPoint`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IComparable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IComparable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IComparisonOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IModulusOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISignedNumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPoint`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointConstants`1", 33554987, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.INumberBase`1<TSelf>", "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643522, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IFloatingPointConstants`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")
                        })
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointConstants`1", 385878127, "E", SourceMemberKind.Property, 0, "TSelf",
                3286,
                -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointConstants`1", 385878128, "Pi", SourceMemberKind.Property, 0, "TSelf",
                3286,
                -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointConstants`1", 385878129, "Tau", SourceMemberKind.Property, 0, "TSelf",
                3286,
                -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointConstants`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointIeee754`1", 33554988, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.IExponentialFunctions`1<TSelf>",
                    "System.Numerics.IFloatingPointConstants`1<TSelf>",
                    "System.Numerics.INumberBase`1<TSelf>", "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>", "System.Numerics.IFloatingPoint`1<TSelf>",
                    "System.Numerics.INumber`1<TSelf>", "System.IComparable", "System.IComparable`1<TSelf>",
                    "System.Numerics.IComparisonOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IModulusOperators`3<TSelf,TSelf,TSelf>", "System.Numerics.ISignedNumber`1<TSelf>",
                    "System.Numerics.IHyperbolicFunctions`1<TSelf>", "System.Numerics.ILogarithmicFunctions`1<TSelf>",
                    "System.Numerics.IPowerFunctions`1<TSelf>", "System.Numerics.IRootFunctions`1<TSelf>",
                    "System.Numerics.ITrigonometricFunctions`1<TSelf>"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643523, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IFloatingPointIeee754`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IExponentialFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPoint`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IComparable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IComparable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IComparisonOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IModulusOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISignedNumber`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IPowerFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IRootFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")
                        })
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointIeee754`1", 385878130, "Epsilon", SourceMemberKind.Property, 0, "TSelf",
                3286, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointIeee754`1", 385878131, "NaN", SourceMemberKind.Property, 0, "TSelf",
                3286,
                -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointIeee754`1", 385878132, "NegativeInfinity", SourceMemberKind.Property, 0,
                "TSelf", 3286, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointIeee754`1", 385878133, "NegativeZero", SourceMemberKind.Property, 0,
                "TSelf",
                3286, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IFloatingPointIeee754`1", 385878134, "PositiveInfinity", SourceMemberKind.Property, 0,
                "TSelf", 3286, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IFloatingPointIeee754`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IHyperbolicFunctions`1", 33554989, 1048737, null, null,
                new string[]
                {
                    "System.Numerics.IFloatingPointConstants`1<TSelf>", "System.Numerics.INumberBase`1<TSelf>",
                    "System.Numerics.IAdditionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IAdditiveIdentity`2<TSelf,TSelf>", "System.Numerics.IDecrementOperators`1<TSelf>",
                    "System.Numerics.IDivisionOperators`3<TSelf,TSelf,TSelf>", "System.IEquatable`1<TSelf>",
                    "System.Numerics.IEqualityOperators`3<TSelf,TSelf,System.Boolean>",
                    "System.Numerics.IIncrementOperators`1<TSelf>",
                    "System.Numerics.IMultiplicativeIdentity`2<TSelf,TSelf>",
                    "System.Numerics.IMultiplyOperators`3<TSelf,TSelf,TSelf>", "System.ISpanFormattable",
                    "System.IFormattable", "System.ISpanParsable`1<TSelf>", "System.IParsable`1<TSelf>",
                    "System.Numerics.ISubtractionOperators`3<TSelf,TSelf,TSelf>",
                    "System.Numerics.IUnaryPlusOperators`2<TSelf,TSelf>",
                    "System.Numerics.IUnaryNegationOperators`2<TSelf,TSelf>", "System.IUtf8SpanFormattable",
                    "System.IUtf8SpanParsable`1<TSelf>"
                },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643524, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IHyperbolicFunctions`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                                    {
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IFloatingPointConstants`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.INumberBase`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IAdditiveIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDecrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IDivisionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IEquatable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IEqualityOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                typeIdentity: "System.Boolean")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IIncrementOperators`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IMultiplyOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.ISpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.ISpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.ISubtractionOperators`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        }),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        typeIdentity: "System.IUtf8SpanFormattable"),
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            typeIdentity: "System.IUtf8SpanParsable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IHyperbolicFunctions`1")
                        })
                }));
        }
    }
}
