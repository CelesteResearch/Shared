using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishInstalledFna000(SourceMemberCatalog catalog)
    {
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 33554790,
            1057033, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
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
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x17, 0x7B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79,
                        0x53, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x2C, 0x6E, 0x71, 0x7D, 0x00, 0x00
                    })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111570,
            "zero", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111571,
            "one", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111572,
            "unitX", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111573,
            "unitY", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111574,
            "unitZ", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111575,
            "up", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111576,
            "down", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111577,
            "right", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111578,
            "left", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111579,
            "forward", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111580,
            "backward", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111581,
            "X", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111582,
            "Y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 67111583,
            "Z", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876220,
            "Zero", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876221,
            "One", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876222,
            "UnitX", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876223,
            "UnitY", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876224,
            "UnitZ", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876225,
            "Up", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876226,
            "Down", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876227,
            "Right", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876228,
            "Left", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876229,
            "Forward", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876230,
            "Backward", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector3", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector3", 385876231,
            "DebugDisplayString", SourceMemberKind.Property, 0, "System.String", 2179, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 33554791,
            1057033, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
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
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x17, 0x7B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79,
                        0x53, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x2C, 0x6E, 0x71, 0x7D, 0x00, 0x00
                    })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111584,
            "X", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111585,
            "Y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111586,
            "Z", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111587,
            "W", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111588,
            "zero", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector4", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111589,
            "unit", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector4", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111590,
            "unitX", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector4", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111591,
            "unitY", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector4", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111592,
            "unitZ", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector4", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 67111593,
            "unitW", SourceMemberKind.Field, 17, "Microsoft.Xna.Framework.Vector4", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 385876232,
            "Zero", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector4", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 385876233,
            "One", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector4", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 385876234,
            "UnitX", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector4", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 385876235,
            "UnitY", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector4", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 385876236,
            "UnitZ", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector4", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 385876237,
            "UnitW", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector4", 2198, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Vector4", 385876238,
            "DebugDisplayString", SourceMemberKind.Property, 0, "System.String", 2179, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
