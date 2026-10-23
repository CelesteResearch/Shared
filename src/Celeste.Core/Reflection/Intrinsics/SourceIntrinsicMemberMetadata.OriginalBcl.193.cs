using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl193(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.Remoting.Messaging.StackBuilderSink", 385880244, "NextSink", SourceMemberKind.Property,
                0,
                "System.Runtime.Remoting.Messaging.IMessageSink", 2534, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.CriticalFinalizerObject", 33556781, 1310849,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.PrePrepareMethodAttribute", 33556782, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x60, 0x00, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Consistency", 33556783, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Consistency", 67120770, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Consistency", 67120771, "MayCorruptProcess",
                SourceMemberKind.Field,
                32854, "System.Runtime.ConstrainedExecution.Consistency", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]),
                "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Consistency", 67120772, "MayCorruptAppDomain",
                SourceMemberKind.Field,
                32854, "System.Runtime.ConstrainedExecution.Consistency", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]),
                "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Consistency", 67120773, "MayCorruptInstance",
                SourceMemberKind.Field,
                32854, "System.Runtime.ConstrainedExecution.Consistency", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]),
                "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Consistency", 67120774, "WillNotCorruptState",
                SourceMemberKind.Field,
                32854, "System.Runtime.ConstrainedExecution.Consistency", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]),
                "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Cer", 33556784, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Cer", 67120775, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Cer", 67120776, "None", SourceMemberKind.Field, 32854,
                "System.Runtime.ConstrainedExecution.Cer", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Cer", 67120777, "MayFail", SourceMemberKind.Field, 32854,
                "System.Runtime.ConstrainedExecution.Cer", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.Cer", 67120778, "Success", SourceMemberKind.Field, 32854,
                "System.Runtime.ConstrainedExecution.Cer", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.ReliabilityContractAttribute", 33556785, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x6D, 0x04, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.ReliabilityContractAttribute", 67120779, "_consistency",
                SourceMemberKind.Field, 1, "System.Runtime.ConstrainedExecution.Consistency", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.ReliabilityContractAttribute", 67120780, "_cer",
                SourceMemberKind.Field, 1, "System.Runtime.ConstrainedExecution.Cer", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.ReliabilityContractAttribute", 385880245, "ConsistencyGuarantee",
                SourceMemberKind.Property, 0, "System.Runtime.ConstrainedExecution.Consistency", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ConstrainedExecution.ReliabilityContractAttribute", 385880246, "Cer",
                SourceMemberKind.Property, 0, "System.Runtime.ConstrainedExecution.Cer", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute", 33556786, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x40, 0x00, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F,
                            0x77,
                            0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68,
                            0x65,
                            0x72, 0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs", 33556787, 1048577,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.EventArgs",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs", 67120781, "m_Exception",
                SourceMemberKind.Field, 1, "System.Exception", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs", 385880247, "Exception",
                SourceMemberKind.Property, 0, "System.Exception", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.ExceptionDispatchInfo", 33556788, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.ExceptionDispatchInfo", 67120782, "m_Exception",
                SourceMemberKind.Field,
                1, "System.Exception", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.ExceptionDispatchInfo", 67120783, "m_stackTrace",
                SourceMemberKind.Field,
                1, "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.ExceptionDispatchInfo", 385880248, "BinaryStackTraceArray",
                SourceMemberKind.Property, 0, "System.Object", 2179, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.ExceptionServices.ExceptionDispatchInfo", 385880249, "SourceException",
                SourceMemberKind.Property, 0, "System.Exception", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.IntrinsicAttribute", 33556789, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x68, 0x01, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.IsByRefLikeAttribute", 33556790, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.IsReadOnlyAttribute", 33556791, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        [
                            0x01, 0x00, 0xFF, 0x7F, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ITuple", 33556792, 161, null, null, [],
                [
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ITuple", 385880250, "Length", SourceMemberKind.Property, 0,
                "System.Int32",
                3526, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ITuple", 385880251, "Item", SourceMemberKind.Property, 0,
                "System.Object",
                3526, -1, 1, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.RuntimeFeature", 33556793, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.RuntimeFeature", 67120784, "PortablePdb", SourceMemberKind.Field,
                32854,
                "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x50, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x74, 0x00, 0x61, 0x00, 0x62, 0x00, 0x6C, 0x00, 0x65, 0x00,
                        0x50, 0x00, 0x64, 0x00, 0x62, 0x00,
                    ]), "System.String", "50006F0072007400610062006C006500500064006200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.TupleElementNamesAttribute", 33556794, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.CLSCompliantAttribute",
                        "System.Void System.CLSCompliantAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        [0x01, 0x00, 0x8C, 0x2B, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.TupleElementNamesAttribute", 67120785, "_transformNames",
                SourceMemberKind.Field, 33, "System.String[]", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.TupleElementNamesAttribute", 385880252, "TransformNames",
                SourceMemberKind.Property, 0, "System.Collections.Generic.IList`1<System.String>", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncMethodBuilderAttribute", 33556795, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1C, 0x14, 0x00, 0x00, 0x02, 0x00, 0x54, 0x02, 0x09, 0x49, 0x6E, 0x68, 0x65,
                            0x72,
                            0x69, 0x74, 0x65, 0x64, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F, 0x77, 0x4D, 0x75,
                            0x6C,
                            0x74, 0x69, 0x70, 0x6C, 0x65, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncMethodBuilderAttribute", 67120786, "<BuilderType>k__BackingField",
                SourceMemberKind.Field, 33, "System.Type", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncMethodBuilderAttribute", 385880253, "BuilderType",
                SourceMemberKind.Property, 0, "System.Type", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder`1", 33556796, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [
                    new("TResult", 0, 704644374, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder`1", 67120787, "_methodBuilder",
                SourceMemberKind.Field, 1, "System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<TResult>", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder`1", 67120788, "_result",
                SourceMemberKind.Field, 1, "TResult", -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder`1", 67120789, "_haveResult",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder`1", 67120790, "_useBuilder",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder`1", 385880254, "Task",
                SourceMemberKind.Property, 0, "System.Threading.Tasks.ValueTask`1<TResult>", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1", 33556797, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [],
                [
                    new("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704644375, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1", 67120791, "_value",
                SourceMemberKind.Field, 33, "System.Threading.Tasks.ValueTask`1<TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1", 67120792,
                "_continueOnCapturedContext",
                SourceMemberKind.Field, 33, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1+ConfiguredValueTaskAwaiter", 33556798,
                1048834, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ValueType",
                [
                    "System.Runtime.CompilerServices.ICriticalNotifyCompletion",
                    "System.Runtime.CompilerServices.INotifyCompletion",
                ],
                [
                    new("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TResult", 0, 704644376, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1+ConfiguredValueTaskAwaiter", 67120793,
                "_value", SourceMemberKind.Field, 33, "System.Threading.Tasks.ValueTask`1<TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1+ConfiguredValueTaskAwaiter", 67120794,
                "_continueOnCapturedContext", SourceMemberKind.Field, 33, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1+ConfiguredValueTaskAwaiter", 385880255,
                "IsCompleted", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ValueTaskAwaiter`1", 33556799, 1048841,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [
                    "System.Runtime.CompilerServices.ICriticalNotifyCompletion",
                    "System.Runtime.CompilerServices.INotifyCompletion",
                ],
                [
                    new("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ],
                [
                    new("TResult", 0, 704644377, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ValueTaskAwaiter`1", 67120795, "_value", SourceMemberKind.Field, 33,
                "System.Threading.Tasks.ValueTask`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ValueTaskAwaiter`1", 385880256, "IsCompleted",
                SourceMemberKind.Property,
                0, "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ContractHelper", 33556800, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ContractHelper", 67120796, "contractFailedEvent",
                SourceMemberKind.Field,
                17,
                "System.EventHandler`1<System.Diagnostics.Contracts.ContractFailedEventArgs> modreq(System.Runtime.CompilerServices.IsVolatile)",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ContractHelper", 67120797, "lockObject", SourceMemberKind.Field, 49,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.ContractHelper", 67120798, "COR_E_CODECONTRACTFAILED",
                SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0x42, 0x15, 0x13, 0x80]), "System.Int32",
                "42151380", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AccessedThroughPropertyAttribute", 33556801, 1048833,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AccessedThroughPropertyAttribute", 67120799, "propertyName",
                SourceMemberKind.Field, 33, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AccessedThroughPropertyAttribute", 385880257, "PropertyName",
                SourceMemberKind.Property, 0, "System.String", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AssemblyAttributesGoHere", 33556802, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                        "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AssemblyAttributesGoHereS", 33556803, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                        "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AssemblyAttributesGoHereM", 33556804, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                        "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AssemblyAttributesGoHereSM", 33556805, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                        "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.LoadHint", 33556806, 8449,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.LoadHint", 67120800, "value__", SourceMemberKind.Field, 1542,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.LoadHint", 67120801, "Default", SourceMemberKind.Field, 32854,
                "System.Runtime.CompilerServices.LoadHint", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.LoadHint", 67120802, "Always", SourceMemberKind.Field, 32854,
                "System.Runtime.CompilerServices.LoadHint", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.LoadHint", 67120803, "Sometimes", SourceMemberKind.Field, 32854,
                "System.Runtime.CompilerServices.LoadHint", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DefaultDependencyAttribute", 33556807, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DefaultDependencyAttribute", 67120804, "loadHint",
                SourceMemberKind.Field,
                1, "System.Runtime.CompilerServices.LoadHint", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DefaultDependencyAttribute", 385880258, "LoadHint",
                SourceMemberKind.Property, 0, "System.Runtime.CompilerServices.LoadHint", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DependencyAttribute", 33556808, 1057025,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [],
                [
                    new("System.AttributeUsageAttribute",
                        "System.Void System.AttributeUsageAttribute::.ctor(System.AttributeTargets)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x54, 0x02, 0x0D, 0x41, 0x6C, 0x6C, 0x6F,
                            0x77,
                            0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x65, 0x01,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DependencyAttribute", 67120805, "dependentAssembly",
                SourceMemberKind.Field, 1, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DependencyAttribute", 67120806, "loadHint", SourceMemberKind.Field, 1,
                "System.Runtime.CompilerServices.LoadHint", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DependencyAttribute", 385880259, "DependentAssembly",
                SourceMemberKind.Property, 0, "System.String", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.DependencyAttribute", 385880260, "LoadHint", SourceMemberKind.Property,
                0,
                "System.Runtime.CompilerServices.LoadHint", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncVoidMethodBuilder", 33556809, 1310985,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncVoidMethodBuilder", 67120807, "m_synchronizationContext",
                SourceMemberKind.Field, 1, "System.Threading.SynchronizationContext", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncVoidMethodBuilder", 67120808, "m_coreState",
                SourceMemberKind.Field,
                1, "System.Runtime.CompilerServices.AsyncMethodBuilderCore", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncVoidMethodBuilder", 67120809, "m_task", SourceMemberKind.Field, 1,
                "System.Threading.Tasks.Task", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncVoidMethodBuilder", 385880261, "Task", SourceMemberKind.Property,
                0,
                "System.Threading.Tasks.Task", 2177, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncVoidMethodBuilder", 385880262, "ObjectIdForDebugger",
                SourceMemberKind.Property, 0, "System.Object", 2177, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder", 33556810, 1310985,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder", 67120810, "s_cachedCompleted",
                SourceMemberKind.Field, 49, "System.Threading.Tasks.Task`1<System.Threading.Tasks.VoidTaskResult>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder", 67120811, "m_builder", SourceMemberKind.Field,
                1,
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Threading.Tasks.VoidTaskResult>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder", 385880263, "Task", SourceMemberKind.Property,
                0,
                "System.Threading.Tasks.Task", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder", 385880264, "ObjectIdForDebugger",
                SourceMemberKind.Property, 0, "System.Object", 2177, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1", 33556811, 1310985,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [
                    new("TResult", 0, 704644382, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1", 67120812, "s_defaultResultTask",
                SourceMemberKind.Field, 51, "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1", 67120813, "m_coreState",
                SourceMemberKind.Field,
                1, "System.Runtime.CompilerServices.AsyncMethodBuilderCore", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
