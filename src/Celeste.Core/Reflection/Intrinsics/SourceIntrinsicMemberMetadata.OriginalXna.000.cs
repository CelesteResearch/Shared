using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalXna000(SourceMemberCatalog catalog)
    {
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 33554946, 1057033,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[] { "System.IEquatable`1<Microsoft.Xna.Framework.Vector3>" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ComponentModel.TypeConverterAttribute",
                    "System.Void System.ComponentModel.TypeConverterAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x2F, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x58, 0x6E, 0x61,
                        0x2E, 0x46, 0x72, 0x61, 0x6D, 0x65, 0x77, 0x6F, 0x72, 0x6B, 0x2E, 0x44, 0x65, 0x73, 0x69, 0x67,
                        0x6E, 0x2E, 0x56, 0x65, 0x63, 0x74, 0x6F, 0x72, 0x33, 0x43, 0x6F, 0x6E, 0x76, 0x65, 0x72, 0x74,
                        0x65, 0x72, 0x00, 0x00
                    })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110415, "X", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110416, "Y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110417, "Z", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110418, "_zero", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110419, "_one", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110420, "_unitX", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110421, "_unitY", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110422, "_unitZ", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110423, "_up", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110424, "_down", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110425, "_right", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110426, "_left", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110427, "_forward", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 67110428, "_backward", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector3", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876796, "Zero", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876797, "One", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876798, "UnitX", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876799, "UnitY", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876800, "UnitZ", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876801, "Up", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876802, "Down", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876803, "Right", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876804, "Left", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876805, "Forward", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector3", 385876806, "Backward", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector3", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 33554947, 1057033,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[] { "System.IEquatable`1<Microsoft.Xna.Framework.Vector4>" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.ComponentModel.TypeConverterAttribute",
                    "System.Void System.ComponentModel.TypeConverterAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x2F, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x58, 0x6E, 0x61,
                        0x2E, 0x46, 0x72, 0x61, 0x6D, 0x65, 0x77, 0x6F, 0x72, 0x6B, 0x2E, 0x44, 0x65, 0x73, 0x69, 0x67,
                        0x6E, 0x2E, 0x56, 0x65, 0x63, 0x74, 0x6F, 0x72, 0x34, 0x43, 0x6F, 0x6E, 0x76, 0x65, 0x72, 0x74,
                        0x65, 0x72, 0x00, 0x00
                    })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110429, "X", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110430, "Y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110431, "Z", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110432, "W", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                    "System.Void System.Diagnostics.CodeAnalysis.SuppressMessageAttribute::.ctor(System.String,System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x10, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x44, 0x65, 0x73,
                        0x69, 0x67, 0x6E, 0x28, 0x43, 0x41, 0x31, 0x30, 0x35, 0x31, 0x3A, 0x44, 0x6F, 0x4E, 0x6F, 0x74,
                        0x44, 0x65, 0x63, 0x6C, 0x61, 0x72, 0x65, 0x56, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65, 0x49, 0x6E,
                        0x73, 0x74, 0x61, 0x6E, 0x63, 0x65, 0x46, 0x69, 0x65, 0x6C, 0x64, 0x73, 0x00, 0x00
                    })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110433, "_zero", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110434, "_one", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110435, "_unitX", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110436, "_unitY", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110437, "_unitZ", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 67110438, "_unitW", SourceMemberKind.Field, 17,
            "Microsoft.Xna.Framework.Vector4", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 385876807, "Zero", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector4", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 385876808, "One", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector4", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 385876809, "UnitX", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector4", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 385876810, "UnitY", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector4", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 385876811, "UnitZ", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector4", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            "Microsoft.Xna.Framework.Vector4", 385876812, "UnitW", SourceMemberKind.Property, 0,
            "Microsoft.Xna.Framework.Vector4", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"));
    }
}
