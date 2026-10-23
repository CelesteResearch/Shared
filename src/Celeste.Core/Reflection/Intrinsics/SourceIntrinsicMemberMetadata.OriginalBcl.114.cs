using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl114(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116338, "LongRunning", SourceMemberKind.Field,
                32854,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116339, "AttachedToParent", SourceMemberKind.Field,
                32854, "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]),
                "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116340, "DenyChildAttach", SourceMemberKind.Field,
                32854, "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]),
                "System.Int32",
                "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116341, "HideScheduler", SourceMemberKind.Field,
                32854,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00, 0x00, 0x00]), "System.Int32",
                "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116342, "LazyCancellation", SourceMemberKind.Field,
                32854, "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x20, 0x00, 0x00, 0x00]),
                "System.Int32",
                "20000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116343, "RunContinuationsAsynchronously",
                SourceMemberKind.Field, 32854, "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x40, 0x00, 0x00, 0x00]), "System.Int32",
                "40000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116344, "NotOnRanToCompletion",
                SourceMemberKind.Field,
                32854, "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x01, 0x00]),
                "System.Int32",
                "00000100", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116345, "NotOnFaulted", SourceMemberKind.Field,
                32854,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x02, 0x00]), "System.Int32",
                "00000200", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116346, "NotOnCanceled", SourceMemberKind.Field,
                32854,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x04, 0x00]), "System.Int32",
                "00000400", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116347, "OnlyOnRanToCompletion",
                SourceMemberKind.Field,
                32854, "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x06, 0x00]),
                "System.Int32",
                "00000600", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116348, "OnlyOnFaulted", SourceMemberKind.Field,
                32854,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x05, 0x00]), "System.Int32",
                "00000500", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116349, "OnlyOnCanceled", SourceMemberKind.Field,
                32854,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x03, 0x00]), "System.Int32",
                "00000300", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskContinuationOptions", 67116350, "ExecuteSynchronously",
                SourceMemberKind.Field,
                32854, "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x08, 0x00]),
                "System.Int32",
                "00000800", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.StackGuard", 33555620, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.StackGuard", 67116351, "m_inliningDepth", SourceMemberKind.Field, 1,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.StackGuard", 67116352, "MAX_UNCHECKED_INLINING_DEPTH", SourceMemberKind.Field,
                32849, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x14, 0x00, 0x00, 0x00]), "System.Int32",
                "14000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.VoidTaskResult", 33555621, 1048840,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ITaskCompletionAction", 33555622, 160, null, null, [],
                [], null, [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1", 33555623, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1<TResult>", ["System.Threading.Tasks.ITaskCompletionAction"],
                [], null,
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                [
                    new("TResult", 0, 704643340, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1", 67116353, "STATE_WAITING_ON_OUTER_TASK",
                SourceMemberKind.Field,
                32849, "System.Byte", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x00]),
                "System.Byte", "00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1", 67116354, "STATE_WAITING_ON_INNER_TASK",
                SourceMemberKind.Field,
                32849, "System.Byte", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x01]),
                "System.Byte", "01",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1", 67116355, "STATE_DONE", SourceMemberKind.Field, 32849,
                "System.Byte", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Byte", /* ReSharper disable once UseUtf8StringLiteral */ [0x02]),
                "System.Byte", "02",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1", 67116356, "_state", SourceMemberKind.Field, 1, "System.Byte",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1", 67116357, "_lookForOce", SourceMemberKind.Field, 33,
                "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1+<>c", 33555624, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TResult", 0, 704643341, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1+<>c", 67116358, "<>9", SourceMemberKind.Field, 54,
                "System.Threading.Tasks.UnwrapPromise`1+<>c<TResult>", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnwrapPromise`1+<>c", 67116359, "<>9__8_0", SourceMemberKind.Field, 22,
                "System.Threading.WaitCallback", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 33555625, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 67116360, "s_failFastOnUnobservedException",
                SourceMemberKind.Field, 49, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 67116361, "s_domainUnloadStarted", SourceMemberKind.Field,
                17,
                "System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 67116362, "s_adUnloadEventHandler",
                SourceMemberKind.Field,
                17, "System.EventHandler modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 67116363, "m_task", SourceMemberKind.Field, 33,
                "System.Threading.Tasks.Task", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 67116364, "m_faultExceptions", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List`1<System.Runtime.ExceptionServices.ExceptionDispatchInfo> modreq(System.Runtime.CompilerServices.IsVolatile)",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 67116365, "m_cancellationException",
                SourceMemberKind.Field,
                1, "System.Runtime.ExceptionServices.ExceptionDispatchInfo", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 67116366, "m_isHandled", SourceMemberKind.Field, 1,
                "System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskExceptionHolder", 385878253, "ContainsFaultList", SourceMemberKind.Property,
                0,
                "System.Boolean", 2179, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 33555626, 1310721,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 67116367, "m_defaultCancellationToken", SourceMemberKind.Field, 1,
                "System.Threading.CancellationToken", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 67116368, "m_defaultScheduler", SourceMemberKind.Field, 1,
                "System.Threading.Tasks.TaskScheduler", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 67116369, "m_defaultCreationOptions", SourceMemberKind.Field, 1,
                "System.Threading.Tasks.TaskCreationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 67116370, "m_defaultContinuationOptions", SourceMemberKind.Field,
                1,
                "System.Threading.Tasks.TaskContinuationOptions", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 385878254, "DefaultScheduler", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2177, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 385878255, "CancellationToken", SourceMemberKind.Property, 0,
                "System.Threading.CancellationToken", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 385878256, "Scheduler", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2182, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 385878257, "CreationOptions", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskCreationOptions", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory", 385878258, "ContinuationOptions", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskContinuationOptions", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise", 33555627, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1<System.Threading.Tasks.Task[]>",
                ["System.Threading.Tasks.ITaskCompletionAction"], [],
                null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise", 67116371, "_tasks",
                SourceMemberKind.Field,
                33, "System.Threading.Tasks.Task[]", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise", 67116372, "_count",
                SourceMemberKind.Field,
                1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise", 385878259,
                "ShouldNotifyDebuggerOfWaitCompletion", SourceMemberKind.Property, 0, "System.Boolean", 2755, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise`1", 33555628, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1<System.Threading.Tasks.Task`1<T>[]>",
                ["System.Threading.Tasks.ITaskCompletionAction"], [],
                null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                [
                    new("T", 0, 704643342, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise`1", 67116373, "_tasks",
                SourceMemberKind.Field, 33, "System.Threading.Tasks.Task`1<T>[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise`1", 67116374, "_count",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnCountdownPromise`1", 385878260,
                "ShouldNotifyDebuggerOfWaitCompletion", SourceMemberKind.Property, 0, "System.Boolean", 2755, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnInvokePromise", 33555629, 1048837,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>",
                ["System.Threading.Tasks.ITaskCompletionAction"], [],
                null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnInvokePromise", 67116375, "_tasks",
                SourceMemberKind.Field, 1,
                "System.Collections.Generic.IList`1<System.Threading.Tasks.Task>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskFactory+CompleteOnInvokePromise", 67116376, "m_firstTaskAlreadyCompleted",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 33555630, 1310849,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x07, 0x49, 0x64, 0x3D, 0x7B, 0x49, 0x64, 0x7D, 0x00, 0x00]),
                    new("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x50, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x68, 0x72, 0x65, 0x61,
                            0x64,
                            0x69, 0x6E, 0x67, 0x2E, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x2E, 0x54, 0x61, 0x73, 0x6B, 0x53,
                            0x63,
                            0x68, 0x65, 0x64, 0x75, 0x6C, 0x65, 0x72, 0x2B, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x54,
                            0x68,
                            0x72, 0x65, 0x61, 0x64, 0x69, 0x6E, 0x67, 0x54, 0x61, 0x73, 0x6B, 0x73, 0x5F, 0x54, 0x61,
                            0x73,
                            0x6B, 0x53, 0x63, 0x68, 0x65, 0x64, 0x75, 0x6C, 0x65, 0x72, 0x44, 0x65, 0x62, 0x75, 0x67,
                            0x56,
                            0x69, 0x65, 0x77, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 67116377, "s_activeTaskSchedulers", SourceMemberKind.Field, 17,
                "System.Runtime.CompilerServices.ConditionalWeakTable`2<System.Threading.Tasks.TaskScheduler,System.Object>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 67116378, "s_defaultTaskScheduler", SourceMemberKind.Field, 49,
                "System.Threading.Tasks.TaskScheduler", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 67116379, "s_taskSchedulerIdCounter", SourceMemberKind.Field,
                19,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 67116380, "m_taskSchedulerId", SourceMemberKind.Field, 1,
                "System.Int32 modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 67116381, "_unobservedTaskException", SourceMemberKind.Field,
                17,
                "System.EventHandler`1<System.Threading.Tasks.UnobservedTaskExceptionEventArgs>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 67116382, "_unobservedTaskExceptionLockObject",
                SourceMemberKind.Field, 49, "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 385878261, "MaximumConcurrencyLevel", SourceMemberKind.Property,
                0,
                "System.Int32", 2502, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 385878262, "RequiresAtomicStartTransition",
                SourceMemberKind.Property, 0, "System.Boolean", 3011, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 385878263, "Default", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2198, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 385878264, "Current", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2198, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 385878265, "IsDefault", SourceMemberKind.Property, 0,
                "System.Boolean", 2195, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 385878266, "InternalCurrent", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2195, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", 385878267, "Id", SourceMemberKind.Property, 0, "System.Int32",
                2182,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler+SystemThreadingTasks_TaskSchedulerDebugView", 33555631, 1048837,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler+SystemThreadingTasks_TaskSchedulerDebugView", 67116383,
                "m_taskScheduler", SourceMemberKind.Field, 33, "System.Threading.Tasks.TaskScheduler", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler+SystemThreadingTasks_TaskSchedulerDebugView", 385878268, "Id",
                SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler+SystemThreadingTasks_TaskSchedulerDebugView", 385878269,
                "ScheduledTasks", SourceMemberKind.Property, 0,
                "System.Collections.Generic.IEnumerable`1<System.Threading.Tasks.Task>", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextTaskScheduler", 33555632, 1048832,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskScheduler", [], [],
                null,
                [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextTaskScheduler", 67116384, "m_synchronizationContext",
                SourceMemberKind.Field, 1, "System.Threading.SynchronizationContext", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextTaskScheduler", 67116385, "s_postCallback",
                SourceMemberKind.Field, 17, "System.Threading.SendOrPostCallback", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.SynchronizationContextTaskScheduler", 385878270, "MaximumConcurrencyLevel",
                SourceMemberKind.Property, 0, "System.Int32", 2246, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnobservedTaskExceptionEventArgs", 33555633, 1048577,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.EventArgs",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnobservedTaskExceptionEventArgs", 67116386, "m_exception",
                SourceMemberKind.Field,
                1, "System.AggregateException", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnobservedTaskExceptionEventArgs", 67116387, "m_observed",
                SourceMemberKind.Field,
                3, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnobservedTaskExceptionEventArgs", 385878271, "Observed",
                SourceMemberKind.Property,
                0, "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.UnobservedTaskExceptionEventArgs", 385878272, "Exception",
                SourceMemberKind.Property, 0, "System.AggregateException", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskSchedulerException", 33555634, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Exception",
                [], [], null, [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm", 33555635, 1048960,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 33555636, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.IAsyncResult"], [], null,
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 67116388, "Task", SourceMemberKind.Field, 35,
                "System.Threading.Tasks.Task", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 67116389, "m_state", SourceMemberKind.Field,
                33,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 67116390, "m_completedSynchronously",
                SourceMemberKind.Field, 33, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 385878273, "System.IAsyncResult.AsyncState",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 385878274,
                "System.IAsyncResult.CompletedSynchronously", SourceMemberKind.Property, 0, "System.Boolean", 2529, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 385878275, "System.IAsyncResult.IsCompleted",
                SourceMemberKind.Property, 0, "System.Boolean", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+TaskWrapperAsyncResult", 385878276,
                "System.IAsyncResult.AsyncWaitHandle",
                SourceMemberKind.Property, 0, "System.Threading.WaitHandle", 2529, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+<>c__DisplayClass3_0", 33555637, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.TaskToApm+<>c__DisplayClass3_0", 67116391, "callback", SourceMemberKind.Field,
                6,
                "System.AsyncCallback", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
