using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl203(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ExtensibleClassFactory", 67121333, "hashtable", SourceMemberKind.Field, 49,
            "System.Collections.Hashtable", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldBuilder", 33557030, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x43, 0x45, 0x31, 0x41, 0x33, 0x42, 0x46, 0x35, 0x2D, 0x39, 0x37, 0x35, 0x45,
                        0x2D, 0x33, 0x30, 0x43, 0x43, 0x2D, 0x39, 0x37, 0x43, 0x39, 0x2D, 0x31, 0x45, 0x46, 0x37, 0x30,
                        0x46, 0x38, 0x46, 0x33, 0x39, 0x39, 0x33, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.CLSCompliantAttribute",
                    "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                    "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x23, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x42,
                        0x75, 0x69, 0x6C, 0x64, 0x65, 0x72, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 33557031, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                    "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x1B, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x49, 0x6E, 0x66, 0x6F, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.CLSCompliantAttribute",
                    "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x38, 0x41, 0x37, 0x43, 0x31, 0x34, 0x34, 0x32, 0x2D, 0x41, 0x39, 0x46, 0x42,
                        0x2D, 0x33, 0x36, 0x36, 0x42, 0x2D, 0x38, 0x30, 0x44, 0x38, 0x2D, 0x34, 0x39, 0x33, 0x39, 0x46,
                        0x46, 0x41, 0x36, 0x44, 0x42, 0x45, 0x30, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880392, "Attributes", SourceMemberKind.Property, 0,
            "System.Reflection.FieldAttributes", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880393, "DeclaringType", SourceMemberKind.Property, 0,
            "System.Type", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880394, "FieldHandle", SourceMemberKind.Property, 0,
            "System.RuntimeFieldHandle", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880395, "FieldType", SourceMemberKind.Property, 0,
            "System.Type", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880396, "IsAssembly", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880397, "IsFamily", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880398, "IsFamilyAndAssembly", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880399, "IsFamilyOrAssembly", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880400, "IsInitOnly", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880401, "IsLiteral", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880402, "IsNotSerialized", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880403, "IsPinvokeImpl", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880404, "IsPrivate", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880405, "IsPublic", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880406, "IsSpecialName", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880407, "IsStatic", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880408, "MemberType", SourceMemberKind.Property, 0,
            "System.Reflection.MemberTypes", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880409, "Name", SourceMemberKind.Property, 0,
            "System.String", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._FieldInfo", 385880410, "ReflectedType", SourceMemberKind.Property, 0,
            "System.Type", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FILETIME", 33557032, 1048841,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute", "System.Void System.ObsoleteAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FILETIME", 67121334, "dwLowDateTime", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.FILETIME", 67121335, "dwHighDateTime", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandle", 33557033, 1048841,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.MonoTODOAttribute",
                    "System.Void System.MonoTODOAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x5E, 0x53, 0x74, 0x72, 0x75, 0x63, 0x74, 0x20, 0x73, 0x68, 0x6F, 0x75, 0x6C, 0x64,
                        0x20, 0x62, 0x65, 0x20, 0x5B, 0x53, 0x74, 0x72, 0x75, 0x63, 0x74, 0x4C, 0x61, 0x79, 0x6F, 0x75,
                        0x74, 0x28, 0x4C, 0x61, 0x79, 0x6F, 0x75, 0x74, 0x4B, 0x69, 0x6E, 0x64, 0x2E, 0x53, 0x65, 0x71,
                        0x75, 0x65, 0x6E, 0x74, 0x69, 0x61, 0x6C, 0x29, 0x5D, 0x20, 0x62, 0x75, 0x74, 0x20, 0x77, 0x69,
                        0x6C, 0x6C, 0x20, 0x6E, 0x65, 0x65, 0x64, 0x20, 0x74, 0x6F, 0x20, 0x62, 0x65, 0x20, 0x72, 0x65,
                        0x6F, 0x72, 0x64, 0x65, 0x72, 0x65, 0x64, 0x20, 0x66, 0x6F, 0x72, 0x20, 0x74, 0x68, 0x61, 0x74,
                        0x2E, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandle", 67121336, "handle", SourceMemberKind.Field, 1, "System.Int32",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandle", 385880411, "IsAllocated", SourceMemberKind.Property, 0,
            "System.Boolean", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandle", 385880412, "Target", SourceMemberKind.Property, 0,
            "System.Object", 2182, 2182, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandleType", 33557034, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandleType", 67121337, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandleType", 67121338, "Weak", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.GCHandleType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandleType", 67121339, "WeakTrackResurrection", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.GCHandleType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandleType", 67121340, "Normal", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.GCHandleType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.GCHandleType", 67121341, "Pinned", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.GCHandleType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.IErrorInfo", 33557035, 266400, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x31, 0x43, 0x46, 0x32, 0x42, 0x31, 0x32, 0x30, 0x2D, 0x35, 0x34, 0x37, 0x44,
                        0x2D, 0x31, 0x30, 0x31, 0x42, 0x2D, 0x38, 0x45, 0x36, 0x35, 0x2D, 0x30, 0x38, 0x30, 0x30, 0x32,
                        0x42, 0x32, 0x42, 0x44, 0x31, 0x31, 0x39, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Security.SuppressUnmanagedCodeSecurityAttribute",
                    "System.Void System.Security.SuppressUnmanagedCodeSecurityAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._ILGenerator", 33557036, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.CLSCompliantAttribute",
                    "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x41, 0x34, 0x39, 0x32, 0x34, 0x42, 0x32, 0x37, 0x2D, 0x36, 0x45, 0x33, 0x42,
                        0x2D, 0x33, 0x37, 0x46, 0x37, 0x2D, 0x39, 0x42, 0x38, 0x33, 0x2D, 0x41, 0x34, 0x35, 0x30, 0x31,
                        0x39, 0x35, 0x35, 0x45, 0x36, 0x41, 0x37, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                    "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x22, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x49, 0x4C, 0x47, 0x65, 0x6E, 0x65,
                        0x72, 0x61, 0x74, 0x6F, 0x72, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ImporterEventKind", 33557037, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ImporterEventKind", 67121342, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ImporterEventKind", 67121343, "NOTIF_TYPECONVERTED", SourceMemberKind.Field,
            32854, "System.Runtime.InteropServices.ImporterEventKind", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ImporterEventKind", 67121344, "NOTIF_CONVERTWARNING",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ImporterEventKind", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ImporterEventKind", 67121345, "ERROR_REFTOINVALIDTYPELIB",
            SourceMemberKind.Field, 32854, "System.Runtime.InteropServices.ImporterEventKind", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ITypeLibConverter", 33557038, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x46, 0x31, 0x43, 0x33, 0x42, 0x46, 0x37, 0x38, 0x2D, 0x43, 0x33, 0x45, 0x34,
                        0x2D, 0x31, 0x31, 0x44, 0x33, 0x2D, 0x38, 0x38, 0x45, 0x37, 0x2D, 0x30, 0x30, 0x39, 0x30, 0x32,
                        0x37, 0x35, 0x34, 0x43, 0x34, 0x33, 0x41, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ITypeLibExporterNameProvider", 33557039, 161, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x66, 0x61, 0x31, 0x66, 0x33, 0x36, 0x31, 0x35, 0x2D, 0x61, 0x63, 0x62, 0x39,
                        0x2D, 0x34, 0x38, 0x36, 0x64, 0x2D, 0x39, 0x65, 0x61, 0x63, 0x2D, 0x31, 0x62, 0x65, 0x66, 0x38,
                        0x37, 0x65, 0x33, 0x36, 0x62, 0x30, 0x39, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ITypeLibExporterNotifySink", 33557040, 161, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x66, 0x31, 0x63, 0x33, 0x62, 0x66, 0x37, 0x37, 0x2D, 0x63, 0x33, 0x65, 0x34,
                        0x2D, 0x31, 0x31, 0x64, 0x33, 0x2D, 0x38, 0x38, 0x65, 0x37, 0x2D, 0x30, 0x30, 0x39, 0x30, 0x32,
                        0x37, 0x35, 0x34, 0x63, 0x34, 0x33, 0x61, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ITypeLibImporterNotifySink", 33557041, 161, null, null,
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x66, 0x31, 0x63, 0x33, 0x62, 0x66, 0x37, 0x36, 0x2D, 0x63, 0x33, 0x65, 0x34,
                        0x2D, 0x31, 0x31, 0x64, 0x33, 0x2D, 0x38, 0x38, 0x65, 0x37, 0x2D, 0x30, 0x30, 0x39, 0x30, 0x32,
                        0x37, 0x35, 0x34, 0x63, 0x34, 0x33, 0x61, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.LIBFLAGS", 33557042, 8449,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ObsoleteAttribute", "System.Void System.ObsoleteAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.LIBFLAGS", 67121346, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.LIBFLAGS", 67121347, "LIBFLAG_FRESTRICTED", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.LIBFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.LIBFLAGS", 67121348, "LIBFLAG_FCONTROL", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.LIBFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.LIBFLAGS", 67121349, "LIBFLAG_FHIDDEN", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.LIBFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.LIBFLAGS", 67121350, "LIBFLAG_FHASDISKIMAGE", SourceMemberKind.Field, 32854,
            "System.Runtime.InteropServices.LIBFLAGS", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x08, 0x00, 0x00, 0x00 }), "System.Int32",
            "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._LocalBuilder", 33557043, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x34, 0x45, 0x36, 0x33, 0x35, 0x30, 0x44, 0x31, 0x2D, 0x41, 0x30, 0x38, 0x42,
                        0x2D, 0x33, 0x44, 0x45, 0x43, 0x2D, 0x39, 0x41, 0x33, 0x45, 0x2D, 0x43, 0x34, 0x36, 0x35, 0x46,
                        0x39, 0x41, 0x45, 0x45, 0x43, 0x30, 0x43, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.CLSCompliantAttribute",
                    "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                    "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x23, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x45, 0x6D, 0x69, 0x74, 0x2E, 0x4C, 0x6F, 0x63, 0x61, 0x6C, 0x42,
                        0x75, 0x69, 0x6C, 0x64, 0x65, 0x72, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ManagedErrorInfo", 33557044, 1048576,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Runtime.InteropServices.IErrorInfo" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ManagedErrorInfo", 67121351, "m_Exception", SourceMemberKind.Field, 1,
            "System.Exception", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.ManagedErrorInfo", 385880413, "Exception", SourceMemberKind.Property, 0,
            "System.Exception", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 33557045, 1048841,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.AttributeUsageAttribute",
                    "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                    new byte[]
                    {
                        0x01, 0x00, 0x00, 0x29, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65, 0x72,
                        0x69, 0x74, 0x65, 0x64, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121352, "MarshalCookie", SourceMemberKind.Field, 6,
            "System.String", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121353, "MarshalType", SourceMemberKind.Field, 6,
            "System.String", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121354, "MarshalTypeRef", SourceMemberKind.Field, 6,
            "System.Type", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121355, "SafeArrayUserDefinedSubType",
            SourceMemberKind.Field, 6, "System.Type", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121356, "utype", SourceMemberKind.Field, 1,
            "System.Runtime.InteropServices.UnmanagedType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121357, "ArraySubType", SourceMemberKind.Field, 6,
            "System.Runtime.InteropServices.UnmanagedType", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121358, "SafeArraySubType", SourceMemberKind.Field,
            6, "System.Runtime.InteropServices.VarEnum", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121359, "SizeConst", SourceMemberKind.Field, 6,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121360, "IidParameterIndex", SourceMemberKind.Field,
            6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 67121361, "SizeParamIndex", SourceMemberKind.Field, 6,
            "System.Int16", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.MarshalAsAttribute", 385880414, "Value", SourceMemberKind.Property, 0,
            "System.Runtime.InteropServices.UnmanagedType", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.Marshal", 33557046, 1048961,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.Marshal", 67121362, "SystemMaxDBCSCharSize", SourceMemberKind.Field, 54,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.Marshal", 67121363, "SystemDefaultCharSize", SourceMemberKind.Field, 54,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.Marshal", 67121364, "SetErrorInfoNotAvailable", SourceMemberKind.Field, 17,
            "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices.Marshal", 67121365, "GetErrorInfoNotAvailable", SourceMemberKind.Field, 17,
            "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MemberInfo", 33557047, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x66, 0x37, 0x31, 0x30, 0x32, 0x66, 0x61, 0x39, 0x2D, 0x63, 0x61, 0x62, 0x62,
                        0x2D, 0x33, 0x61, 0x37, 0x34, 0x2D, 0x61, 0x36, 0x64, 0x61, 0x2D, 0x62, 0x34, 0x35, 0x36, 0x37,
                        0x65, 0x66, 0x31, 0x62, 0x30, 0x37, 0x39, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                    "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x1C, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x4D, 0x65, 0x6D, 0x62, 0x65, 0x72, 0x49, 0x6E, 0x66, 0x6F, 0x00,
                        0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.CLSCompliantAttribute",
                    "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MemberInfo", 385880415, "DeclaringType", SourceMemberKind.Property, 0,
            "System.Type", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MemberInfo", 385880416, "MemberType", SourceMemberKind.Property, 0,
            "System.Reflection.MemberTypes", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MemberInfo", 385880417, "Name", SourceMemberKind.Property, 0,
            "System.String", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MemberInfo", 385880418, "ReflectedType", SourceMemberKind.Property, 0,
            "System.Type", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 33557048, 161, null, null, Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.InteropServices.ComVisibleAttribute",
                    "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.CLSCompliantAttribute",
                    "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.InterfaceTypeAttribute",
                    "System.Void System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(System.Runtime.InteropServices.ComInterfaceType)",
                    new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.TypeLibImportClassAttribute",
                    "System.Void System.Runtime.InteropServices.TypeLibImportClassAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x1C, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x65, 0x66, 0x6C, 0x65, 0x63,
                        0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x4D, 0x65, 0x74, 0x68, 0x6F, 0x64, 0x42, 0x61, 0x73, 0x65, 0x00,
                        0x00
                    }),
                new SourceDeclaredAttribute("System.Runtime.InteropServices.GuidAttribute",
                    "System.Void System.Runtime.InteropServices.GuidAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x24, 0x36, 0x32, 0x34, 0x30, 0x38, 0x33, 0x37, 0x41, 0x2D, 0x37, 0x30, 0x37, 0x46,
                        0x2D, 0x33, 0x31, 0x38, 0x31, 0x2D, 0x38, 0x45, 0x39, 0x38, 0x2D, 0x41, 0x33, 0x36, 0x41, 0x45,
                        0x30, 0x38, 0x36, 0x37, 0x36, 0x36, 0x42, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880419, "Attributes", SourceMemberKind.Property, 0,
            "System.Reflection.MethodAttributes", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880420, "CallingConvention", SourceMemberKind.Property, 0,
            "System.Reflection.CallingConventions", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880421, "DeclaringType", SourceMemberKind.Property, 0,
            "System.Type", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880422, "IsAbstract", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880423, "IsAssembly", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880424, "IsConstructor", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880425, "IsFamily", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880426, "IsFamilyAndAssembly", SourceMemberKind.Property,
            0, "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880427, "IsFamilyOrAssembly", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880428, "IsFinal", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880429, "IsHideBySig", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880430, "IsPrivate", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880431, "IsPublic", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880432, "IsSpecialName", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880433, "IsStatic", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880434, "IsVirtual", SourceMemberKind.Property, 0,
            "System.Boolean", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Runtime.InteropServices._MethodBase", 385880435, "MemberType", SourceMemberKind.Property, 0,
            "System.Reflection.MemberTypes", 3526, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
