using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceInstalledBclNecessaryMemberMetadata
    {
        private static void PublishSystem_Private_CoreLib0013(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IIncrementOperators`1", 33554990, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643525, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IIncrementOperators`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IIncrementOperators`1")
                                    }))
                        })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.ILogarithmicFunctions`1", 33554991, 1048737, null, null,
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643526, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.ILogarithmicFunctions`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ILogarithmicFunctions`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IMinMaxValue`1", 33554992, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643527, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IMinMaxValue`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IMinMaxValue`1"),
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
                                            ownerTypeIdentity: "System.Numerics.IMinMaxValue`1")
                                    }))
                        })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IMinMaxValue`1", 385878135, "MinValue", SourceMemberKind.Property, 0, "TSelf", 3286,
                -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IMinMaxValue`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IMinMaxValue`1", 385878136, "MaxValue", SourceMemberKind.Property, 0, "TSelf", 3286,
                -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IMinMaxValue`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IModulusOperators`3", 33554993, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643528, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IModulusOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IModulusOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IModulusOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IModulusOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643529, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643530, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IMultiplicativeIdentity`2", 33554994, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643531, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IMultiplicativeIdentity`2<TSelf,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IMultiplicativeIdentity`2"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IMultiplicativeIdentity`2")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TResult", 1, 704643532, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IMultiplicativeIdentity`2", 385878137, "MultiplicativeIdentity",
                SourceMemberKind.Property,
                0, "TResult", 3286, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 1,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.IMultiplicativeIdentity`2")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IMultiplyOperators`3", 33554995, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643533, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IMultiplyOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IMultiplyOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IMultiplyOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IMultiplyOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643534, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643535, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.INumber`1", 33554996, 1048737, null, null,
                new string[]
                {
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643536, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.INumber`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.INumber`1")
                                    }))
                        })
                }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumber`1")
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
                                ownerTypeIdentity: "System.Numerics.INumber`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.INumberBase`1", 33554997, 1048737, null, null,
                new string[]
                {
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643537, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.INumberBase`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
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
                                ownerTypeIdentity: "System.Numerics.INumberBase`1")
                        })
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.INumberBase`1", 385878138, "One", SourceMemberKind.Property, 0, "TSelf", 3286, -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.INumberBase`1")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.INumberBase`1", 385878139, "Radix", SourceMemberKind.Property, 0, "System.Int32", 3286,
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
                "System.Numerics.INumberBase`1", 385878140, "Zero", SourceMemberKind.Property, 0, "TSelf", 3286, -1, 0,
                Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type,
                    ownerAssemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    ownerTypeIdentity: "System.Numerics.INumberBase`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IPowerFunctions`1", 33554998, 1048737, null, null,
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643538, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IPowerFunctions`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IPowerFunctions`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IRootFunctions`1", 33554999, 1048737, null, null,
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643539, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IRootFunctions`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.IRootFunctions`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IShiftOperators`3", 33555000, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643540, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IShiftOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IShiftOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IShiftOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IShiftOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643541, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643542, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.ISignedNumber`1", 33555001, 1048737, null, null,
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643543, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.ISignedNumber`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.ISignedNumber`1")
                        })
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.ISignedNumber`1", 385878141, "NegativeOne", SourceMemberKind.Property, 0, "TSelf",
                3286,
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
                    ownerTypeIdentity: "System.Numerics.ISignedNumber`1")));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.ISubtractionOperators`3", 33555002, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643544, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.ISubtractionOperators`3<TSelf,TOther,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.ISubtractionOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.ISubtractionOperators`3"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 2,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.ISubtractionOperators`3")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TOther", 1, 704643545, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { }),
                    new SourceGenericParameterDefinition("TResult", 2, 704643546, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.ITrigonometricFunctions`1", 33555003, 1048737, null, null,
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
                    new SourceGenericParameterDefinition("TSelf", 0, 704643547, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.ITrigonometricFunctions`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
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
                                ownerTypeIdentity: "System.Numerics.ITrigonometricFunctions`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IUnaryNegationOperators`2", 33555004, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643548, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
                        },
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint(
                                "System.Numerics.IUnaryNegationOperators`2<TSelf,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IUnaryNegationOperators`2"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IUnaryNegationOperators`2")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TResult", 1, 704643549, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IUnaryPlusOperators`2", 33555005, 1048737, null, null, new string[] { },
                Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643550, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IUnaryPlusOperators`2<TSelf,TResult>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
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
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 0,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IUnaryPlusOperators`2"),
                                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind
                                                .GenericParameter,
                                            genericParameterPosition: 1,
                                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                                .SourceGenericParameterOwnerKind.Type,
                                            ownerAssemblyIdentity:
                                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                            ownerTypeIdentity: "System.Numerics.IUnaryPlusOperators`2")
                                    }))
                        }),
                    new SourceGenericParameterDefinition("TResult", 1, 704643551, 0,
                        new SourceDeclaredAttribute[]
                        {
                            new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableAttribute",
                                "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                                new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                        }, new SourceGenericParameterConstraint[] { })
                }, null, new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Numerics.IUnsignedNumber`1", 33555006, 1048737, null, null,
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
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                },
                new SourceGenericParameterDefinition[]
                {
                    new SourceGenericParameterDefinition("TSelf", 0, 704643552, 0,
                        Array.Empty<SourceDeclaredAttribute>(),
                        new SourceGenericParameterConstraint[]
                        {
                            new SourceGenericParameterConstraint("System.Numerics.IUnsignedNumber`1<TSelf>",
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                        assemblyIdentity:
                                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                        typeIdentity: "System.Numerics.IUnsignedNumber`1"),
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
                                            ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                                genericParameterPosition: 0,
                                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                    .SourceGenericParameterOwnerKind.Type,
                                ownerAssemblyIdentity:
                                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
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
                                ownerTypeIdentity: "System.Numerics.IUnsignedNumber`1")
                        })
                }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.Serialization.IDeserializationCallback", 33555655, 1048737, null, null,
                new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x02, 0x00, 0x00 })
                }, null, new string[] { }, new SourceGenericParameterDefinition[] { }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.Serialization.ISerializable", 33555659, 1048737, null, null, new string[] { },
                new SourceDeclaredAttribute[]
                {
                    new SourceDeclaredAttribute("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
                }, null, new string[] { }, new SourceGenericParameterDefinition[] { }, null,
                new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.InteropServices.UnmanagedType", 33555898, 257,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Enum",
                new string[] { }, Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
                new SourceGenericParameterDefinition[] { },
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Enum"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.InteropServices.UnmanagedType", 67113608, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.InteropServices.UnmanagedType", 67113609, "Bool", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.UnmanagedType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
                SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
                "02000000", "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Runtime.InteropServices.UnmanagedType")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.InteropServices.UnmanagedType", 67113610, "I1", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.UnmanagedType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
                SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
                "03000000", "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Runtime.InteropServices.UnmanagedType")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.InteropServices.UnmanagedType", 67113611, "U1", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.UnmanagedType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
                SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
                "04000000", "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Runtime.InteropServices.UnmanagedType")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "System.Runtime.InteropServices.UnmanagedType", 67113612, "I2", SourceMemberKind.Field, 32854,
                "System.Runtime.InteropServices.UnmanagedType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
                SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x05, 0x00, 0x00, 0x00 }), "System.Int32",
                "05000000", "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                    typeIdentity: "System.Runtime.InteropServices.UnmanagedType")));
        }
    }
}
