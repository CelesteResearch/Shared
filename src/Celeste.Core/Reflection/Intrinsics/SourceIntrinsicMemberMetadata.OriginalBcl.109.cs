using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl109(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+DebugView", 385878151, "TargetScheduler",
                SourceMemberKind.Property, 0, "System.Threading.Tasks.TaskScheduler", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", 33555538, 259,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], "System.Byte", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", 67116042, "value__",
                SourceMemberKind.Field, 1542, "System.Byte", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", 67116043,
                "NotCurrentlyProcessing", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x00]),
                "System.Byte", "00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", 67116044,
                "ProcessingExclusiveTask", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x01]),
                "System.Byte", "01",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", 67116045,
                "ProcessingConcurrentTasks", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x02]),
                "System.Byte", "02",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", 67116046, "Completing",
                SourceMemberKind.Field, 32854, "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x04]),
                "System.Byte", "04",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode", 67116047, "Completed",
                SourceMemberKind.Field, 32854, "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+ProcessingMode",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x08]),
                "System.Byte", "08",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+<>c", 33555539, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+<>c", 67116048, "<>9", SourceMemberKind.Field,
                54,
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+<>c", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+<>c", 67116049, "<>9__22_0",
                SourceMemberKind.Field, 22,
                "System.Func`1<System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+CompletionState>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+<>c", 67116050, "<>9__29_0",
                SourceMemberKind.Field, 22, "System.Threading.WaitCallback", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+<>c", 67116051, "<>9__39_0",
                SourceMemberKind.Field, 22, "System.Action`1<System.Object>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ConcurrentExclusiveSchedulerPair+<>c", 67116052, "<>9__39_1",
                SourceMemberKind.Field, 22, "System.Action`1<System.Object>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 33555540, 1310721,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", [],
                [
                    new("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x3D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x68, 0x72, 0x65, 0x61,
                            0x64,
                            0x69, 0x6E, 0x67, 0x2E, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x2E, 0x53, 0x79, 0x73, 0x74, 0x65,
                            0x6D,
                            0x54, 0x68, 0x72, 0x65, 0x61, 0x64, 0x69, 0x6E, 0x67, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x5F,
                            0x46,
                            0x75, 0x74, 0x75, 0x72, 0x65, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60,
                            0x31,
                            0x00, 0x00,
                        ]),
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x76, 0x49, 0x64, 0x20, 0x3D, 0x20, 0x7B, 0x49, 0x64, 0x7D, 0x2C, 0x20, 0x53,
                            0x74,
                            0x61, 0x74, 0x75, 0x73, 0x20, 0x3D, 0x20, 0x7B, 0x53, 0x74, 0x61, 0x74, 0x75, 0x73, 0x7D,
                            0x2C,
                            0x20, 0x4D, 0x65, 0x74, 0x68, 0x6F, 0x64, 0x20, 0x3D, 0x20, 0x7B, 0x44, 0x65, 0x62, 0x75,
                            0x67,
                            0x67, 0x65, 0x72, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4D, 0x65, 0x74, 0x68, 0x6F,
                            0x64,
                            0x44, 0x65, 0x73, 0x63, 0x72, 0x69, 0x70, 0x74, 0x69, 0x6F, 0x6E, 0x7D, 0x2C, 0x20, 0x52,
                            0x65,
                            0x73, 0x75, 0x6C, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x67, 0x65,
                            0x72,
                            0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x52, 0x65, 0x73, 0x75, 0x6C, 0x74, 0x44, 0x65,
                            0x73,
                            0x63, 0x72, 0x69, 0x70, 0x74, 0x69, 0x6F, 0x6E, 0x7D, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("TResult", 0, 704643286, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 67116053, "m_result", SourceMemberKind.Field, 3, "TResult", -1, -1, 0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 67116054, "s_Factory", SourceMemberKind.Field, 49,
                "System.Threading.Tasks.TaskFactory`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 67116055, "TaskWhenAnyCast", SourceMemberKind.Field, 51,
                "System.Func`2<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>,System.Threading.Tasks.Task`1<TResult>>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 385878152, "DebuggerDisplayResultDescription",
                SourceMemberKind.Property,
                0, "System.String", 2177, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 385878153, "DebuggerDisplayMethodDescription",
                SourceMemberKind.Property,
                0, "System.String", 2177, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 385878154, "Result", SourceMemberKind.Property, 0, "TResult", 2182, -1,
                0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 385878155, "ResultOnSuccess", SourceMemberKind.Property, 0, "TResult",
                2179, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1", 385878156, "Factory", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskFactory`1<TResult>", 2198, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1+<>c", 33555541, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643287, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1+<>c", 67116056, "<>9", SourceMemberKind.Field, 54,
                "System.Threading.Tasks.Task`1+<>c<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 33555542, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("TResult", 0, 704643288, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 67116057, "m_task",
                SourceMemberKind.Field,
                1, "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 385878157, "Result",
                SourceMemberKind.Property, 0, "TResult", 2182, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 385878158, "AsyncState",
                SourceMemberKind.Property, 0, "System.Object", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 385878159, "CreationOptions",
                SourceMemberKind.Property, 0, "System.Threading.Tasks.TaskCreationOptions", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 385878160, "Exception",
                SourceMemberKind.Property, 0, "System.Exception", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 385878161, "Id",
                SourceMemberKind.Property,
                0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 385878162, "CancellationPending",
                SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SystemThreadingTasks_FutureDebugView`1", 385878163, "Status",
                SourceMemberKind.Property, 0, "System.Threading.Tasks.TaskStatus", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 33555543, 1310721,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("TResult", 0, 704643289, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 67116058, "m_defaultCancellationToken", SourceMemberKind.Field,
                1,
                "System.Threading.CancellationToken", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 67116059, "m_defaultScheduler", SourceMemberKind.Field, 1,
                "System.Threading.Tasks.TaskScheduler", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 67116060, "m_defaultCreationOptions", SourceMemberKind.Field, 1,
                "System.Threading.Tasks.TaskCreationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 67116061, "m_defaultContinuationOptions",
                SourceMemberKind.Field, 1,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 385878164, "DefaultScheduler", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2177, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 385878165, "CancellationToken", SourceMemberKind.Property, 0,
                "System.Threading.CancellationToken", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 385878166, "Scheduler", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 385878167, "CreationOptions", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskCreationOptions", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1", 385878168, "ContinuationOptions", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskContinuationOptions", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+FromAsyncTrimPromise`1", 33555544, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1<TResult>", [], [],
                null, [],
                [
                    new("TResult", 0, 704643290, 0,
                        [],
                        []),
                    new("TInstance", 1, 704643291, 4,
                        [], []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+FromAsyncTrimPromise`1", 67116062, "s_completeFromAsyncResult",
                SourceMemberKind.Field, 51, "System.AsyncCallback", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+FromAsyncTrimPromise`1", 67116063, "m_thisRef",
                SourceMemberKind.Field, 1, "TInstance", -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+FromAsyncTrimPromise`1", 67116064, "m_endMethod",
                SourceMemberKind.Field, 1, "System.Func`3<TInstance,System.IAsyncResult,TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass32_0", 33555545, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643292, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass32_0", 67116065, "asyncResult",
                SourceMemberKind.Field, 6, "System.IAsyncResult", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass32_0", 67116066, "endFunction",
                SourceMemberKind.Field, 6, "System.Func`2<System.IAsyncResult,TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass32_0", 67116067, "endAction",
                SourceMemberKind.Field,
                6, "System.Action`1<System.IAsyncResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass32_0", 67116068, "promise",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass32_0", 67116069, "t", SourceMemberKind.Field, 6,
                "System.Threading.Tasks.Task", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass32_0", 67116070, "scheduler",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.TaskScheduler", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_0", 33555546, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643293, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_0", 67116071, "endFunction",
                SourceMemberKind.Field, 6, "System.Func`2<System.IAsyncResult,TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_0", 67116072, "endAction",
                SourceMemberKind.Field,
                6, "System.Action`1<System.IAsyncResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_0", 67116073, "promise",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_1", 33555547, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643294, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_1", 67116074, "invoked",
                SourceMemberKind.Field,
                6, "System.Threading.AtomicBoolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_1", 67116075, "CS$<>8__locals1",
                SourceMemberKind.Field, 6, "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass35_0<TResult>", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_0`1", 33555548, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643295, 0,
                        [],
                        []),
                    new("TArg1", 1, 704643296, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_0`1", 67116076, "endFunction",
                SourceMemberKind.Field, 6, "System.Func`2<System.IAsyncResult,TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_0`1", 67116077, "endAction",
                SourceMemberKind.Field, 6, "System.Action`1<System.IAsyncResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_0`1", 67116078, "promise",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_1`1", 33555549, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643297, 0,
                        [],
                        []),
                    new("TArg1", 1, 704643298, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_1`1", 67116079, "invoked",
                SourceMemberKind.Field,
                6, "System.Threading.AtomicBoolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_1`1", 67116080, "CS$<>8__locals1",
                SourceMemberKind.Field, 6,
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass38_0`1<TResult,TArg1>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_0`2", 33555550, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643299, 0,
                        [],
                        []),
                    new("TArg1", 1, 704643300, 0,
                        [],
                        []),
                    new("TArg2", 2, 704643301, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_0`2", 67116081, "endFunction",
                SourceMemberKind.Field, 6, "System.Func`2<System.IAsyncResult,TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_0`2", 67116082, "endAction",
                SourceMemberKind.Field, 6, "System.Action`1<System.IAsyncResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_0`2", 67116083, "promise",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_1`2", 33555551, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643302, 0,
                        [],
                        []),
                    new("TArg1", 1, 704643303, 0,
                        [],
                        []),
                    new("TArg2", 2, 704643304, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_1`2", 67116084, "invoked",
                SourceMemberKind.Field,
                6, "System.Threading.AtomicBoolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_1`2", 67116085, "CS$<>8__locals1",
                SourceMemberKind.Field, 6,
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass41_0`2<TResult,TArg1,TArg2>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_0`3", 33555552, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643305, 0,
                        [],
                        []),
                    new("TArg1", 1, 704643306, 0,
                        [],
                        []),
                    new("TArg2", 2, 704643307, 0,
                        [],
                        []),
                    new("TArg3", 3, 704643308, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_0`3", 67116086, "endFunction",
                SourceMemberKind.Field, 6, "System.Func`2<System.IAsyncResult,TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_0`3", 67116087, "endAction",
                SourceMemberKind.Field, 6, "System.Action`1<System.IAsyncResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_0`3", 67116088, "promise",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.Task`1<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_1`3", 33555553, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643309, 0,
                        [],
                        []),
                    new("TArg1", 1, 704643310, 0,
                        [],
                        []),
                    new("TArg2", 2, 704643311, 0,
                        [],
                        []),
                    new("TArg3", 3, 704643312, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_1`3", 67116089, "invoked",
                SourceMemberKind.Field,
                6, "System.Threading.AtomicBoolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_1`3", 67116090, "CS$<>8__locals1",
                SourceMemberKind.Field, 6,
                "System.Threading.Tasks.TaskFactory`1+<>c__DisplayClass44_0`3<TResult,TArg1,TArg2,TArg3>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c", 33555554, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643313, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c", 67116091, "<>9", SourceMemberKind.Field, 54,
                "System.Threading.Tasks.TaskFactory`1+<>c<TResult>", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c", 67116092, "<>9__57_0", SourceMemberKind.Field, 22,
                "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task[]>,System.Object,TResult>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c", 67116093, "<>9__57_1", SourceMemberKind.Field, 22,
                "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task[]>,System.Object,TResult>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c", 67116094, "<>9__66_0", SourceMemberKind.Field, 22,
                "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>,System.Object,TResult>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory`1+<>c", 67116095, "<>9__66_1", SourceMemberKind.Field, 22,
                "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>,System.Object,TResult>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.GenericDelegateCache`2", 33555555, 1048960,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("TAntecedentResult", 0, 704643314, 0,
                        [], []),
                    new("TResult", 1, 704643315, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.GenericDelegateCache`2", 67116096, "CWAnyFuncDelegate", SourceMemberKind.Field,
                19,
                "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>,System.Object,TResult>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.GenericDelegateCache`2", 67116097, "CWAnyActionDelegate",
                SourceMemberKind.Field,
                19, "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>,System.Object,TResult>",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.GenericDelegateCache`2", 67116098, "CWAllFuncDelegate", SourceMemberKind.Field,
                19,
                "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task`1<TAntecedentResult>[]>,System.Object,TResult>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.GenericDelegateCache`2", 67116099, "CWAllActionDelegate",
                SourceMemberKind.Field,
                19,
                "System.Func`3<System.Threading.Tasks.Task`1<System.Threading.Tasks.Task`1<TAntecedentResult>[]>,System.Object,TResult>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.GenericDelegateCache`2+<>c", 33555556, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TAntecedentResult", 0, 704643316, 0,
                        [], []),
                    new("TResult", 1, 704643317, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.GenericDelegateCache`2+<>c", 67116100, "<>9", SourceMemberKind.Field, 54,
                "System.Threading.Tasks.GenericDelegateCache`2+<>c<TAntecedentResult,TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
