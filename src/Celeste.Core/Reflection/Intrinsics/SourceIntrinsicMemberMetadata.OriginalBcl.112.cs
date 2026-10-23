using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl112(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuation", 33555594, 1048704,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.StandardTaskContinuation", 33555595, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuation", [],
                [],
                null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.StandardTaskContinuation", 67116221, "m_task", SourceMemberKind.Field, 35,
                "System.Threading.Tasks.Task", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.StandardTaskContinuation", 67116222, "m_options", SourceMemberKind.Field, 35,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.StandardTaskContinuation", 67116223, "m_taskScheduler", SourceMemberKind.Field,
                33,
                "System.Threading.Tasks.TaskScheduler", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation", 33555596, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation", [],
                [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation", 67116224, "s_postCallback",
                SourceMemberKind.Field, 49, "System.Threading.SendOrPostCallback", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation", 67116225, "s_postActionCallback",
                SourceMemberKind.Field, 17, "System.Threading.ContextCallback", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Security.SecurityCriticalAttribute",
                        "System.Void System.Security.SecurityCriticalAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation", 67116226, "m_syncContext",
                SourceMemberKind.Field, 33, "System.Threading.SynchronizationContext", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation+<>c", 33555597, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation+<>c", 67116227, "<>9",
                SourceMemberKind.Field, 54, "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation+<>c",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskSchedulerAwaitTaskContinuation", 33555598, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation", [],
                [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskSchedulerAwaitTaskContinuation", 67116228, "m_scheduler",
                SourceMemberKind.Field, 33, "System.Threading.Tasks.TaskScheduler", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskSchedulerAwaitTaskContinuation+<>c", 33555599, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskSchedulerAwaitTaskContinuation+<>c", 67116229, "<>9",
                SourceMemberKind.Field,
                54, "System.Threading.Tasks.TaskSchedulerAwaitTaskContinuation+<>c", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskSchedulerAwaitTaskContinuation+<>c", 67116230, "<>9__2_0",
                SourceMemberKind.Field, 22, "System.Action`1<System.Object>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation", 33555600, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuation", ["System.Threading.IThreadPoolWorkItem"],
                [], null,
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation", 67116231, "m_capturedContext", SourceMemberKind.Field,
                33,
                "System.Threading.ExecutionContext", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation", 67116232, "m_action", SourceMemberKind.Field, 36,
                "System.Action", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation", 67116233, "s_invokeActionCallback",
                SourceMemberKind.Field,
                17, "System.Threading.ContextCallback", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Security.SecurityCriticalAttribute",
                        "System.Void System.Security.SecurityCriticalAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation", 385878204, "IsValidLocationForInlining",
                SourceMemberKind.Property, 0, "System.Boolean", 2195, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation+<>c", 33555601, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation+<>c", 67116234, "<>9", SourceMemberKind.Field, 54,
                "System.Threading.Tasks.AwaitTaskContinuation+<>c", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.AwaitTaskContinuation+<>c", 67116235, "<>9__17_0", SourceMemberKind.Field, 22,
                "System.Threading.WaitCallback", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Shared`1", 33555602, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("T", 0, 704643338, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Shared`1", 67116236, "Value", SourceMemberKind.Field, 3, "T", -1, -1, 0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 33555603, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116237, "value__", SourceMemberKind.Field, 1542, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116238, "Created", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116239, "WaitingForActivation", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116240, "WaitingToRun", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116241, "Running", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116242, "WaitingForChildrenToComplete", SourceMemberKind.Field,
                32854, "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116243, "RanToCompletion", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116244, "Canceled", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x06, 0x00, 0x00, 0x00]), "System.Int32",
                "06000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskStatus", 67116245, "Faulted", SourceMemberKind.Field, 32854,
                "System.Threading.Tasks.TaskStatus", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x07, 0x00, 0x00, 0x00]), "System.Int32",
                "07000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 33555604, 1310721,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.Threading.IThreadPoolWorkItem", "System.IAsyncResult", "System.IDisposable"],
                [
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x49, 0x49, 0x64, 0x20, 0x3D, 0x20, 0x7B, 0x49, 0x64, 0x7D, 0x2C, 0x20, 0x53,
                            0x74,
                            0x61, 0x74, 0x75, 0x73, 0x20, 0x3D, 0x20, 0x7B, 0x53, 0x74, 0x61, 0x74, 0x75, 0x73, 0x7D,
                            0x2C,
                            0x20, 0x4D, 0x65, 0x74, 0x68, 0x6F, 0x64, 0x20, 0x3D, 0x20, 0x7B, 0x44, 0x65, 0x62, 0x75,
                            0x67,
                            0x67, 0x65, 0x72, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4D, 0x65, 0x74, 0x68, 0x6F,
                            0x64,
                            0x44, 0x65, 0x73, 0x63, 0x72, 0x69, 0x70, 0x74, 0x69, 0x6F, 0x6E, 0x7D, 0x00, 0x00,
                        ]),
                    new("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x39, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x68, 0x72, 0x65, 0x61,
                            0x64,
                            0x69, 0x6E, 0x67, 0x2E, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x2E, 0x53, 0x79, 0x73, 0x74, 0x65,
                            0x6D,
                            0x54, 0x68, 0x72, 0x65, 0x61, 0x64, 0x69, 0x6E, 0x67, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x5F,
                            0x54,
                            0x61, 0x73, 0x6B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x00, 0x00,
                        ]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116246, "t_currentTask", SourceMemberKind.Field, 19,
                "System.Threading.Tasks.Task", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.ThreadStaticAttribute",
                        "System.Void System.ThreadStaticAttribute::.ctor()", /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116247, "t_stackGuard", SourceMemberKind.Field, 17,
                "System.Threading.Tasks.StackGuard", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.ThreadStaticAttribute",
                        "System.Void System.ThreadStaticAttribute::.ctor()", /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116248, "s_taskIdCounter", SourceMemberKind.Field, 19, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116249, "s_factory", SourceMemberKind.Field, 49,
                "System.Threading.Tasks.TaskFactory", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116250, "m_taskId", SourceMemberKind.Field, 1,
                "System.Int32 modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116251, "m_action", SourceMemberKind.Field, 3, "System.Object", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116252, "m_stateObject", SourceMemberKind.Field, 3, "System.Object",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116253, "m_taskScheduler", SourceMemberKind.Field, 3,
                "System.Threading.Tasks.TaskScheduler", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116254, "m_parent", SourceMemberKind.Field, 35,
                "System.Threading.Tasks.Task", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116255, "m_stateFlags", SourceMemberKind.Field, 3,
                "System.Int32 modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116256, "OptionsMask", SourceMemberKind.Field, 32849, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xFF, 0xFF, 0x00, 0x00]), "System.Int32",
                "FFFF0000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116257, "TASK_STATE_STARTED", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x01, 0x00]), "System.Int32",
                "00000100", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116258, "TASK_STATE_DELEGATE_INVOKED", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x02, 0x00]), "System.Int32",
                "00000200", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116259, "TASK_STATE_DISPOSED", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x04, 0x00]), "System.Int32",
                "00000400", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116260, "TASK_STATE_EXCEPTIONOBSERVEDBYPARENT", SourceMemberKind.Field,
                32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x08, 0x00]), "System.Int32",
                "00000800", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116261, "TASK_STATE_CANCELLATIONACKNOWLEDGED", SourceMemberKind.Field,
                32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x10, 0x00]), "System.Int32",
                "00001000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116262, "TASK_STATE_FAULTED", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x20, 0x00]), "System.Int32",
                "00002000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116263, "TASK_STATE_CANCELED", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x40, 0x00]), "System.Int32",
                "00004000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116264, "TASK_STATE_WAITING_ON_CHILDREN", SourceMemberKind.Field,
                32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0x00, 0x00, 0x80, 0x00]), "System.Int32",
                "00008000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116265, "TASK_STATE_RAN_TO_COMPLETION", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x01]), "System.Int32",
                "00000001", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116266, "TASK_STATE_WAITINGFORACTIVATION", SourceMemberKind.Field,
                32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x02]), "System.Int32",
                "00000002", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116267, "TASK_STATE_COMPLETION_RESERVED", SourceMemberKind.Field,
                32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x04]), "System.Int32",
                "00000004", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116268, "TASK_STATE_THREAD_WAS_ABORTED", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x08]), "System.Int32",
                "00000008", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116269, "TASK_STATE_WAIT_COMPLETION_NOTIFICATION",
                SourceMemberKind.Field,
                32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x10]), "System.Int32",
                "00000010", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116270, "TASK_STATE_EXECUTIONCONTEXT_IS_NULL", SourceMemberKind.Field,
                32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x20]), "System.Int32",
                "00000020", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116271, "TASK_STATE_TASKSCHEDULED_WAS_FIRED", SourceMemberKind.Field,
                32851, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x40]), "System.Int32",
                "00000040", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116272, "TASK_STATE_COMPLETED_MASK", SourceMemberKind.Field, 32849,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x60, 0x01]), "System.Int32",
                "00006001", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116273, "CANCELLATION_REQUESTED", SourceMemberKind.Field, 32849,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116274, "m_continuationObject", SourceMemberKind.Field, 1,
                "System.Object modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116275, "s_taskCompletionSentinel", SourceMemberKind.Field, 49,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116276, "s_asyncDebuggingEnabled", SourceMemberKind.Field, 19,
                "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.FriendAccessAllowedAttribute",
                        "System.Void System.Runtime.CompilerServices.FriendAccessAllowedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116277, "s_currentActiveTasks", SourceMemberKind.Field, 49,
                "System.Collections.Generic.Dictionary`2<System.Int32,System.Threading.Tasks.Task>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116278, "s_activeTasksLock", SourceMemberKind.Field, 49,
                "System.Object",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116279, "m_contingentProperties", SourceMemberKind.Field, 3,
                "System.Threading.Tasks.Task+ContingentProperties modreq(System.Runtime.CompilerServices.IsVolatile)",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116280, "s_taskCancelCallback", SourceMemberKind.Field, 49,
                "System.Action`1<System.Object>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116281, "s_createContingentProperties", SourceMemberKind.Field, 49,
                "System.Func`1<System.Threading.Tasks.Task+ContingentProperties>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116282, "s_completedTask", SourceMemberKind.Field, 17,
                "System.Threading.Tasks.Task", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116283, "s_IsExceptionObservedByParentPredicate",
                SourceMemberKind.Field,
                49, "System.Predicate`1<System.Threading.Tasks.Task>", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116284, "s_ecCallback", SourceMemberKind.Field, 17,
                "System.Threading.ContextCallback", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Security.SecurityCriticalAttribute",
                        "System.Void System.Security.SecurityCriticalAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 67116285, "s_IsTaskContinuationNullPredicate", SourceMemberKind.Field,
                49,
                "System.Predicate`1<System.Object>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878205, "DebuggerDisplayMethodDescription", SourceMemberKind.Property,
                0,
                "System.String", 2177, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878206, "Options", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskCreationOptions", 2179, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878207, "IsWaitNotificationEnabledOrNotRanToCompletion",
                SourceMemberKind.Property, 0, "System.Boolean", 2179, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878208, "ShouldNotifyDebuggerOfWaitCompletion",
                SourceMemberKind.Property,
                0, "System.Boolean", 3011, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878209, "IsWaitNotificationEnabled", SourceMemberKind.Property, 0,
                "System.Boolean", 2179, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878210, "Id", SourceMemberKind.Property, 0, "System.Int32", 2182, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878211, "CurrentId", SourceMemberKind.Property, 0,
                "System.Nullable`1<System.Int32>", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878212, "InternalCurrent", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.Task", 2195, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878213, "CurrentStackGuard", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.StackGuard", 2195, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878214, "Exception", SourceMemberKind.Property, 0,
                "System.AggregateException", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878215, "Status", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskStatus", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878216, "IsCanceled", SourceMemberKind.Property, 0, "System.Boolean",
                2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878217, "IsCancellationRequested", SourceMemberKind.Property, 0,
                "System.Boolean", 2179, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878218, "CancellationToken", SourceMemberKind.Property, 0,
                "System.Threading.CancellationToken", 2179, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878219, "IsCancellationAcknowledged", SourceMemberKind.Property, 0,
                "System.Boolean", 2179, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878220, "IsCompleted", SourceMemberKind.Property, 0, "System.Boolean",
                2534, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878221, "IsCompletedSuccessfully", SourceMemberKind.Property, 0,
                "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878222, "IsRanToCompletion", SourceMemberKind.Property, 0,
                "System.Boolean", 2179, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task", 385878223, "CreationOptions", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskCreationOptions", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
