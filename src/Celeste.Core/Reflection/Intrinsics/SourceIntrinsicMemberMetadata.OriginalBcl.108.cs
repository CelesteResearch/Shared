using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics;

public static partial class SourceIntrinsicMemberMetadata
{
    private static void PublishOriginalBcl108(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Threading.Timer",
            67115989, "next_run", SourceMemberKind.Field, 1, "System.Int64", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Threading.Timer",
            67115990, "disposed", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Threading.Timer",
            67115991, "MaxValue", SourceMemberKind.Field, 32849, "System.Int64", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int64",
                new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00 }), "System.Int64", "FEFFFFFF00000000",
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Timer+TimerComparer", 33555522, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[] { "System.Collections.IComparer" }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Timer+Scheduler", 33555523, 259,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Timer+Scheduler", 67115992, "instance", SourceMemberKind.Field, 17,
            "System.Threading.Timer+Scheduler", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Timer+Scheduler", 67115993, "list", SourceMemberKind.Field, 1,
            "System.Collections.SortedList", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Timer+Scheduler", 67115994, "changed", SourceMemberKind.Field, 1,
            "System.Threading.ManualResetEvent", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Timer+Scheduler", 385878124, "Instance", SourceMemberKind.Property, 0,
            "System.Threading.Timer+Scheduler", 2198, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Threading.Volatile",
            33555524, 1048961, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 33555525, 1048833,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
            new string[] { "System.IEquatable`1<System.Threading.Tasks.ValueTask`1<TResult>>" },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                    "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 }),
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.AsyncMethodBuilderAttribute",
                    "System.Void System.Runtime.CompilerServices.AsyncMethodBuilderAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x3D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75, 0x6E, 0x74, 0x69, 0x6D,
                        0x65, 0x2E, 0x43, 0x6F, 0x6D, 0x70, 0x69, 0x6C, 0x65, 0x72, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63,
                        0x65, 0x73, 0x2E, 0x41, 0x73, 0x79, 0x6E, 0x63, 0x56, 0x61, 0x6C, 0x75, 0x65, 0x54, 0x61, 0x73,
                        0x6B, 0x4D, 0x65, 0x74, 0x68, 0x6F, 0x64, 0x42, 0x75, 0x69, 0x6C, 0x64, 0x65, 0x72, 0x60, 0x31,
                        0x00, 0x00
                    })
            }, null, new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
            new SourceGenericParameterDefinition[]
            {
                new SourceGenericParameterDefinition("TResult", 0, 704643285, 0, Array.Empty<SourceDeclaredAttribute>(),
                    new SourceGenericParameterConstraint[] { })
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 67115995, "_task", SourceMemberKind.Field, 35,
            "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 67115996, "_result", SourceMemberKind.Field, 35, "TResult", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 385878125, "IsCompleted", SourceMemberKind.Property, 0,
            "System.Boolean", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 385878126, "IsCompletedSuccessfully", SourceMemberKind.Property, 0,
            "System.Boolean", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 385878127, "IsFaulted", SourceMemberKind.Property, 0,
            "System.Boolean", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 385878128, "IsCanceled", SourceMemberKind.Property, 0,
            "System.Boolean", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ValueTask`1", 385878129, "Result", SourceMemberKind.Property, 0, "TResult", 2182,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null, null));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityTraceLevel", 33555526, 256,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                    "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityTraceLevel", 67115997, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityTraceLevel", 67115998, "Required", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityTraceLevel", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityTraceLevel", 67115999, "Important", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityTraceLevel", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityTraceLevel", 67116000, "Verbose", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityTraceLevel", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityStatus", 33555527, 256,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                    "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, "System.Int32", new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityStatus", 67116001, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityStatus", 67116002, "Started", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.AsyncCausalityStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityStatus", 67116003, "Completed", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.AsyncCausalityStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityStatus", 67116004, "Canceled", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.AsyncCausalityStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityStatus", 67116005, "Error", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.AsyncCausalityStatus", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityRelation", 33555528, 256,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityRelation", 67116006, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityRelation", 67116007, "AssignDelegate", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityRelation", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityRelation", 67116008, "Join", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityRelation", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityRelation", 67116009, "Choice", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityRelation", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityRelation", 67116010, "Cancel", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityRelation", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x03, 0x00, 0x00, 0x00 }), "System.Int32",
            "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalityRelation", 67116011, "Error", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalityRelation", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x04, 0x00, 0x00, 0x00 }), "System.Int32",
            "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalitySynchronousWork", 33555529, 256,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), "System.Int32", new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalitySynchronousWork", 67116012, "value__", SourceMemberKind.Field, 1542,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalitySynchronousWork", 67116013, "CompletionNotification",
            SourceMemberKind.Field, 32854, "System.Threading.Tasks.CausalitySynchronousWork", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x00, 0x00, 0x00, 0x00 }), "System.Int32",
            "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalitySynchronousWork", 67116014, "ProgressNotification", SourceMemberKind.Field,
            32854, "System.Threading.Tasks.CausalitySynchronousWork", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            true, SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x01, 0x00, 0x00, 0x00 }), "System.Int32",
            "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.CausalitySynchronousWork", 67116015, "Execution", SourceMemberKind.Field, 32854,
            "System.Threading.Tasks.CausalitySynchronousWork", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0x02, 0x00, 0x00, 0x00 }), "System.Int32",
            "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityTracer", 33555530, 1048960,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                    "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.AsyncCausalityTracer", 385878130, "LoggingOn", SourceMemberKind.Property, 0,
            "System.Boolean", 2195, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                    "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter", 33555531, 1048832,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Runtime.CompilerServices.ICriticalNotifyCompletion",
                "System.Runtime.CompilerServices.INotifyCompletion"
            }, Array.Empty<SourceDeclaredAttribute>(), null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter", 67116016, "CALLBACK_RAN", SourceMemberKind.Field, 49,
            "System.Action", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter", 67116017, "_asyncResult", SourceMemberKind.Field, 1,
            "System.IAsyncResult", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter", 67116018, "_continuation", SourceMemberKind.Field, 1,
            "System.Action", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter", 67116019, "Callback", SourceMemberKind.Field, 54,
            "System.AsyncCallback", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter", 385878131, "IsCompleted", SourceMemberKind.Property, 0,
            "System.Boolean", 2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter+<>c", 33555532, 1057027,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.BeginEndAwaitableAdapter+<>c", 67116020, "<>9", SourceMemberKind.Field, 54,
            "System.Threading.Tasks.BeginEndAwaitableAdapter+<>c", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 33555533, 1310721,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x6E, 0x43, 0x6F, 0x6E, 0x63, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x74, 0x3D, 0x7B, 0x43,
                        0x6F, 0x6E, 0x63, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x74, 0x54, 0x61, 0x73, 0x6B, 0x43, 0x6F, 0x75,
                        0x6E, 0x74, 0x46, 0x6F, 0x72, 0x44, 0x65, 0x62, 0x75, 0x67, 0x67, 0x65, 0x72, 0x7D, 0x2C, 0x20,
                        0x45, 0x78, 0x63, 0x6C, 0x75, 0x73, 0x69, 0x76, 0x65, 0x3D, 0x7B, 0x45, 0x78, 0x63, 0x6C, 0x75,
                        0x73, 0x69, 0x76, 0x65, 0x54, 0x61, 0x73, 0x6B, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x46, 0x6F, 0x72,
                        0x44, 0x65, 0x62, 0x75, 0x67, 0x67, 0x65, 0x72, 0x7D, 0x2C, 0x20, 0x4D, 0x6F, 0x64, 0x65, 0x3D,
                        0x7B, 0x4D, 0x6F, 0x64, 0x65, 0x46, 0x6F, 0x72, 0x44, 0x65, 0x62, 0x75, 0x67, 0x67, 0x65, 0x72,
                        0x7D, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x41, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x68, 0x72, 0x65, 0x61, 0x64,
                        0x69, 0x6E, 0x67, 0x2E, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x2E, 0x43, 0x6F, 0x6E, 0x63, 0x75, 0x72,
                        0x72, 0x65, 0x6E, 0x74, 0x45, 0x78, 0x63, 0x6C, 0x75, 0x73, 0x69, 0x76, 0x65, 0x53, 0x63, 0x68,
                        0x65, 0x64, 0x75, 0x6C, 0x65, 0x72, 0x50, 0x61, 0x69, 0x72, 0x2B, 0x44, 0x65, 0x62, 0x75, 0x67,
                        0x56, 0x69, 0x65, 0x77, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116021, "m_threadProcessingMapping",
            SourceMemberKind.Field, 33,
            "System.Collections.Concurrent.ConcurrentDictionary`2<System.Int32,System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode>",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116022, "m_concurrentTaskScheduler",
            SourceMemberKind.Field, 33,
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116023, "m_exclusiveTaskScheduler",
            SourceMemberKind.Field, 33,
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116024, "m_underlyingTaskScheduler",
            SourceMemberKind.Field, 33, "System.Threading.Tasks.TaskScheduler", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116025, "m_maxConcurrencyLevel",
            SourceMemberKind.Field, 33, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116026, "m_maxItemsPerTask",
            SourceMemberKind.Field, 33, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116027, "m_processingCount",
            SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116028, "m_completionState",
            SourceMemberKind.Field, 1, "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+CompletionState", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116029, "UNLIMITED_PROCESSING",
            SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }), "System.Int32",
            "FFFFFFFF", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116030, "EXCLUSIVE_PROCESSING_SENTINEL",
            SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }), "System.Int32",
            "FFFFFFFF", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 67116031, "DEFAULT_MAXITEMSPERTASK",
            SourceMemberKind.Field, 32849, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), true,
            SourceMetadataConstant.Decode("System.Int32", new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }), "System.Int32",
            "FFFFFFFF", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878132, "DefaultMaxConcurrencyLevel",
            SourceMemberKind.Property, 0, "System.Int32", 2193, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878133, "ValueLock",
            SourceMemberKind.Property, 0, "System.Object", 2177, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878134, "Completion",
            SourceMemberKind.Property, 0, "System.Threading.Tasks.Task", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878135, "CompletionRequested",
            SourceMemberKind.Property, 0, "System.Boolean", 2177, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878136, "ReadyToComplete",
            SourceMemberKind.Property, 0, "System.Boolean", 2177, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878137, "ConcurrentScheduler",
            SourceMemberKind.Property, 0, "System.Threading.Tasks.TaskScheduler", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878138, "ExclusiveScheduler",
            SourceMemberKind.Property, 0, "System.Threading.Tasks.TaskScheduler", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878139, "ConcurrentTaskCountForDebugger",
            SourceMemberKind.Property, 0, "System.Int32", 2177, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878140, "ExclusiveTaskCountForDebugger",
            SourceMemberKind.Property, 0, "System.Int32", 2177, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 385878141, "ModeForDebugger",
            SourceMemberKind.Property, 0, "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode",
            2177, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+CompletionState", 33555534, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.TaskCompletionSource`1<System.Threading.Tasks.VoidTaskResult>",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+CompletionState", 67116032,
            "m_completionRequested", SourceMemberKind.Field, 3, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+CompletionState", 67116033, "m_completionQueued",
            SourceMemberKind.Field, 3, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+CompletionState", 67116034, "m_exceptions",
            SourceMemberKind.Field, 3, "System.Collections.Generic.List`1<System.Exception>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 33555535,
            1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.TaskScheduler", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerDisplayAttribute",
                    "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                    new byte[]
                    {
                        0x01, 0x00, 0x4E, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x3D, 0x7B, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x46,
                        0x6F, 0x72, 0x44, 0x65, 0x62, 0x75, 0x67, 0x67, 0x65, 0x72, 0x7D, 0x2C, 0x20, 0x4D, 0x61, 0x78,
                        0x43, 0x6F, 0x6E, 0x63, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x63, 0x79, 0x4C, 0x65, 0x76, 0x65, 0x6C,
                        0x3D, 0x7B, 0x6D, 0x5F, 0x6D, 0x61, 0x78, 0x43, 0x6F, 0x6E, 0x63, 0x75, 0x72, 0x72, 0x65, 0x6E,
                        0x63, 0x79, 0x4C, 0x65, 0x76, 0x65, 0x6C, 0x7D, 0x2C, 0x20, 0x49, 0x64, 0x3D, 0x7B, 0x49, 0x64,
                        0x7D, 0x00, 0x00
                    }),
                new SourceDeclaredAttribute("System.Diagnostics.DebuggerTypeProxyAttribute",
                    "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                    new byte[]
                    {
                        0x01, 0x00, 0x62, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x68, 0x72, 0x65, 0x61, 0x64,
                        0x69, 0x6E, 0x67, 0x2E, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x2E, 0x43, 0x6F, 0x6E, 0x63, 0x75, 0x72,
                        0x72, 0x65, 0x6E, 0x74, 0x45, 0x78, 0x63, 0x6C, 0x75, 0x73, 0x69, 0x76, 0x65, 0x53, 0x63, 0x68,
                        0x65, 0x64, 0x75, 0x6C, 0x65, 0x72, 0x50, 0x61, 0x69, 0x72, 0x2B, 0x43, 0x6F, 0x6E, 0x63, 0x75,
                        0x72, 0x72, 0x65, 0x6E, 0x74, 0x45, 0x78, 0x63, 0x6C, 0x75, 0x73, 0x69, 0x76, 0x65, 0x54, 0x61,
                        0x73, 0x6B, 0x53, 0x63, 0x68, 0x65, 0x64, 0x75, 0x6C, 0x65, 0x72, 0x2B, 0x44, 0x65, 0x62, 0x75,
                        0x67, 0x56, 0x69, 0x65, 0x77, 0x00, 0x00
                    })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 67116035,
            "s_tryExecuteTaskShim", SourceMemberKind.Field, 49, "System.Func`2<System.Object,System.Boolean>", -1, -1,
            0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 67116036,
            "m_pair", SourceMemberKind.Field, 33, "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 67116037,
            "m_maxConcurrencyLevel", SourceMemberKind.Field, 33, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 67116038,
            "m_processingMode", SourceMemberKind.Field, 33,
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 67116039,
            "m_tasks", SourceMemberKind.Field, 35,
            "System.Threading.Tasks.IProducerConsumerQueue`1<System.Threading.Tasks.Task>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 385878142,
            "MaximumConcurrencyLevel", SourceMemberKind.Property, 0, "System.Int32", 2246, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", 385878143,
            "CountForDebugger", SourceMemberKind.Property, 0, "System.Int32", 2177, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler+DebugView",
            33555536, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler+DebugView",
            67116040, "m_taskScheduler", SourceMemberKind.Field, 33,
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler+DebugView",
            385878144, "MaximumConcurrencyLevel", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler+DebugView",
            385878145, "ScheduledTasks", SourceMemberKind.Property, 0,
            "System.Collections.Generic.IEnumerable`1<System.Threading.Tasks.Task>", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ConcurrentExclusiveTaskScheduler+DebugView",
            385878146, "SchedulerPair", SourceMemberKind.Property, 0,
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+DebugView", 33555537, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>()));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+DebugView", 67116041, "m_pair",
            SourceMemberKind.Field, 33, "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+DebugView", 385878147, "Mode",
            SourceMemberKind.Property, 0, "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode",
            2182, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+DebugView", 385878148, "ScheduledExclusive",
            SourceMemberKind.Property, 0, "System.Collections.Generic.IEnumerable`1<System.Threading.Tasks.Task>", 2182,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+DebugView", 385878149, "ScheduledConcurrent",
            SourceMemberKind.Property, 0, "System.Collections.Generic.IEnumerable`1<System.Threading.Tasks.Task>", 2182,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+DebugView", 385878150,
            "CurrentlyExecutingTaskCount", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    }
}
