using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl110(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 33555557, 1048577,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 67116101, "m_scheduler", SourceMemberKind.Field, 1,
                "System.Threading.Tasks.TaskScheduler", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 67116102, "m_maxDegreeOfParallelism", SourceMemberKind.Field,
                1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 67116103, "m_cancellationToken", SourceMemberKind.Field, 1,
                "System.Threading.CancellationToken", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 385878169, "TaskScheduler", SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2182, 2182, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 385878170, "EffectiveTaskScheduler",
                SourceMemberKind.Property, 0,
                "System.Threading.Tasks.TaskScheduler", 2179, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 385878171, "MaxDegreeOfParallelism",
                SourceMemberKind.Property, 0,
                "System.Int32", 2182, 2182, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 385878172, "CancellationToken", SourceMemberKind.Property, 0,
                "System.Threading.CancellationToken", 2182, 2182, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelOptions", 385878173, "EffectiveMaxConcurrencyLevel",
                SourceMemberKind.Property, 0, "System.Int32", 2179, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel", 33555558, 1311105,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel", 67116104, "s_forkJoinContextID", SourceMemberKind.Field, 19,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel", 67116105, "DEFAULT_LOOP_STRIDE", SourceMemberKind.Field, 32851,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00, 0x00, 0x00]), "System.Int32",
                "10000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel", 67116106, "s_defaultParallelOptions", SourceMemberKind.Field, 19,
                "System.Threading.Tasks.ParallelOptions", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+LoopTimer", 33555559, 1048845,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+LoopTimer", 67116107, "s_BaseNotifyPeriodMS", SourceMemberKind.Field,
                32849, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x64, 0x00, 0x00, 0x00]), "System.Int32",
                "64000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+LoopTimer", 67116108, "s_NotifyPeriodIncrementMS",
                SourceMemberKind.Field,
                32849, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x32, 0x00, 0x00, 0x00]), "System.Int32",
                "32000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+LoopTimer", 67116109, "m_timeLimit", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_0", 33555560, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_0", 67116110, "actionsCopy", SourceMemberKind.Field,
                6,
                "System.Action[]", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_0", 67116111, "parallelOptions",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.ParallelOptions", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_1", 33555561, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_1", 67116112, "exceptionQ", SourceMemberKind.Field,
                6,
                "System.Collections.Concurrent.ConcurrentQueue`1<System.Exception>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_1", 67116113, "CS$<>8__locals1",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.Parallel+<>c__DisplayClass4_0", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_2", 33555562, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_2", 67116114, "actionIndex", SourceMemberKind.Field,
                6,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass4_2", 67116115, "CS$<>8__locals2",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.Parallel+<>c__DisplayClass4_1", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c", 33555563, 1057027,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c", 67116116, "<>9", SourceMemberKind.Field, 54,
                "System.Threading.Tasks.Parallel+<>c", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c", 67116117, "<>9__4_1", SourceMemberKind.Field, 22,
                "System.Func`1<System.Collections.Concurrent.ConcurrentQueue`1<System.Exception>>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c", 67116118, "<>9__4_2", SourceMemberKind.Field, 22,
                "System.Func`1<System.Collections.Concurrent.ConcurrentQueue`1<System.Exception>>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 33555564, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TLocal", 0, 704643318, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116119, "sharedPStateFlags",
                SourceMemberKind.Field, 6, "System.Threading.Tasks.ParallelLoopStateFlags32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116120, "oce", SourceMemberKind.Field, 6,
                "System.OperationCanceledException", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116121, "parallelOptions",
                SourceMemberKind.Field, 6, "System.Threading.Tasks.ParallelOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116122, "rootTask", SourceMemberKind.Field,
                6,
                "System.Threading.Tasks.ParallelForReplicatingTask", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116123, "rangeManager",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.RangeManager", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116124, "bodyWithState",
                SourceMemberKind.Field, 6, "System.Action`2<System.Int32,System.Threading.Tasks.ParallelLoopState>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116125, "bodyWithLocal",
                SourceMemberKind.Field, 6,
                "System.Func`4<System.Int32,System.Threading.Tasks.ParallelLoopState,TLocal,TLocal>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116126, "localInit",
                SourceMemberKind.Field, 6,
                "System.Func`1<TLocal>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116127, "body", SourceMemberKind.Field, 6,
                "System.Action`1<System.Int32>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass17_0`1", 67116128, "localFinally",
                SourceMemberKind.Field,
                6, "System.Action`1<TLocal>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 33555565, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TLocal", 0, 704643319, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116129, "sharedPStateFlags",
                SourceMemberKind.Field, 6, "System.Threading.Tasks.ParallelLoopStateFlags64", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116130, "oce", SourceMemberKind.Field, 6,
                "System.OperationCanceledException", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116131, "parallelOptions",
                SourceMemberKind.Field, 6, "System.Threading.Tasks.ParallelOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116132, "rootTask", SourceMemberKind.Field,
                6,
                "System.Threading.Tasks.ParallelForReplicatingTask", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116133, "rangeManager",
                SourceMemberKind.Field,
                6, "System.Threading.Tasks.RangeManager", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116134, "bodyWithState",
                SourceMemberKind.Field, 6, "System.Action`2<System.Int64,System.Threading.Tasks.ParallelLoopState>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116135, "bodyWithLocal",
                SourceMemberKind.Field, 6,
                "System.Func`4<System.Int64,System.Threading.Tasks.ParallelLoopState,TLocal,TLocal>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116136, "localInit",
                SourceMemberKind.Field, 6,
                "System.Func`1<TLocal>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116137, "body", SourceMemberKind.Field, 6,
                "System.Action`1<System.Int64>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass18_0`1", 67116138, "localFinally",
                SourceMemberKind.Field,
                6, "System.Action`1<TLocal>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass30_0`2", 33555566, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TSource", 0, 704643320, 0,
                        [],
                        []),
                    new("TLocal", 1, 704643321, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass30_0`2", 67116139, "body", SourceMemberKind.Field, 6,
                "System.Action`1<TSource>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass30_0`2", 67116140, "array", SourceMemberKind.Field, 6,
                "TSource[]", -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass30_0`2", 67116141, "bodyWithState",
                SourceMemberKind.Field, 6, "System.Action`2<TSource,System.Threading.Tasks.ParallelLoopState>", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass30_0`2", 67116142, "bodyWithStateAndIndex",
                SourceMemberKind.Field, 6,
                "System.Action`3<TSource,System.Threading.Tasks.ParallelLoopState,System.Int64>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass30_0`2", 67116143, "bodyWithStateAndLocal",
                SourceMemberKind.Field, 6,
                "System.Func`4<TSource,System.Threading.Tasks.ParallelLoopState,TLocal,TLocal>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass30_0`2", 67116144, "bodyWithEverything",
                SourceMemberKind.Field, 6,
                "System.Func`5<TSource,System.Threading.Tasks.ParallelLoopState,System.Int64,TLocal,TLocal>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass31_0`2", 33555567, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TSource", 0, 704643322, 0,
                        [],
                        []),
                    new("TLocal", 1, 704643323, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass31_0`2", 67116145, "body", SourceMemberKind.Field, 6,
                "System.Action`1<TSource>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass31_0`2", 67116146, "list", SourceMemberKind.Field, 6,
                "System.Collections.Generic.IList`1<TSource>", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass31_0`2", 67116147, "bodyWithState",
                SourceMemberKind.Field, 6, "System.Action`2<TSource,System.Threading.Tasks.ParallelLoopState>", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass31_0`2", 67116148, "bodyWithStateAndIndex",
                SourceMemberKind.Field, 6,
                "System.Action`3<TSource,System.Threading.Tasks.ParallelLoopState,System.Int64>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass31_0`2", 67116149, "bodyWithStateAndLocal",
                SourceMemberKind.Field, 6,
                "System.Func`4<TSource,System.Threading.Tasks.ParallelLoopState,TLocal,TLocal>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass31_0`2", 67116150, "bodyWithEverything",
                SourceMemberKind.Field, 6,
                "System.Func`5<TSource,System.Threading.Tasks.ParallelLoopState,System.Int64,TLocal,TLocal>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 33555568, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("TSource", 0, 704643324, 0,
                        [],
                        []),
                    new("TLocal", 1, 704643325, 0,
                        [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116151, "sharedPStateFlags",
                SourceMemberKind.Field, 6, "System.Threading.Tasks.ParallelLoopStateFlags64", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116152, "oce", SourceMemberKind.Field, 6,
                "System.OperationCanceledException", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116153, "parallelOptions",
                SourceMemberKind.Field, 6, "System.Threading.Tasks.ParallelOptions", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116154, "bodyWithState",
                SourceMemberKind.Field, 6, "System.Action`2<TSource,System.Threading.Tasks.ParallelLoopState>", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116155, "bodyWithStateAndIndex",
                SourceMemberKind.Field, 6,
                "System.Action`3<TSource,System.Threading.Tasks.ParallelLoopState,System.Int64>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116156, "bodyWithStateAndLocal",
                SourceMemberKind.Field, 6,
                "System.Func`4<TSource,System.Threading.Tasks.ParallelLoopState,TLocal,TLocal>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116157, "bodyWithEverything",
                SourceMemberKind.Field, 6,
                "System.Func`5<TSource,System.Threading.Tasks.ParallelLoopState,System.Int64,TLocal,TLocal>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116158, "localInit",
                SourceMemberKind.Field, 6,
                "System.Func`1<TLocal>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116159, "rootTask", SourceMemberKind.Field,
                6,
                "System.Threading.Tasks.ParallelForReplicatingTask", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116160, "orderedSource",
                SourceMemberKind.Field, 6, "System.Collections.Concurrent.OrderablePartitioner`1<TSource>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116161, "orderablePartitionerSource",
                SourceMemberKind.Field, 6,
                "System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.Int64,TSource>>",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116162, "simpleBody",
                SourceMemberKind.Field,
                6, "System.Action`1<TSource>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116163, "partitionerSource",
                SourceMemberKind.Field, 6, "System.Collections.Generic.IEnumerable`1<TSource>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.Parallel+<>c__DisplayClass42_0`2", 67116164, "localFinally",
                SourceMemberKind.Field,
                6, "System.Action`1<TLocal>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null,
                null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 33555569, 1310721,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x39, 0x53, 0x68, 0x6F, 0x75, 0x6C, 0x64, 0x45, 0x78, 0x69, 0x74, 0x43, 0x75,
                            0x72,
                            0x72, 0x65, 0x6E, 0x74, 0x49, 0x74, 0x65, 0x72, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x20, 0x3D,
                            0x20,
                            0x7B, 0x53, 0x68, 0x6F, 0x75, 0x6C, 0x64, 0x45, 0x78, 0x69, 0x74, 0x43, 0x75, 0x72, 0x72,
                            0x65,
                            0x6E, 0x74, 0x49, 0x74, 0x65, 0x72, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x7D, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 67116165, "m_flagsBase", SourceMemberKind.Field, 1,
                "System.Threading.Tasks.ParallelLoopStateFlags", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 385878174, "InternalShouldExitCurrentIteration",
                SourceMemberKind.Property, 0, "System.Boolean", 3011, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 385878175, "ShouldExitCurrentIteration",
                SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 385878176, "IsStopped", SourceMemberKind.Property, 0,
                "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 385878177, "IsExceptional", SourceMemberKind.Property, 0,
                "System.Boolean", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 385878178, "InternalLowestBreakIteration",
                SourceMemberKind.Property, 0, "System.Nullable`1<System.Int64>", 3011, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", 385878179, "LowestBreakIteration",
                SourceMemberKind.Property, 0,
                "System.Nullable`1<System.Int64>", 2182, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState32", 33555570, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", [],
                [],
                null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState32", 67116166, "m_sharedParallelStateFlags",
                SourceMemberKind.Field, 1, "System.Threading.Tasks.ParallelLoopStateFlags32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState32", 67116167, "m_currentIteration", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState32", 385878180, "CurrentIteration", SourceMemberKind.Property,
                0,
                "System.Int32", 2179, 2179, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState32", 385878181, "InternalShouldExitCurrentIteration",
                SourceMemberKind.Property, 0, "System.Boolean", 2755, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState32", 385878182, "InternalLowestBreakIteration",
                SourceMemberKind.Property, 0, "System.Nullable`1<System.Int64>", 2755, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState64", 33555571, 1048576,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Threading.Tasks.ParallelLoopState", [],
                [],
                null, [], []));
        }
    }
}
