using System;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup;

public static partial class OriginalLogicalTypeFacts
{
    private static void RegisterPart9(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("Celeste.Trigger+PositionModes", "Celeste.Trigger.PositionModes",
            "PositionModes", assemblyIdentity, "Celeste", 33556234, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Trigger.PositionModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Trigger.PositionModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Refill+<RefillRoutine>d__28", "Celeste.Refill.<RefillRoutine>d__28",
            "<RefillRoutine>d__28", assemblyIdentity, "Celeste", 33556235, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Refill.<RefillRoutine>d__28", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Refill.<RefillRoutine>d__28",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Spikes+Directions", "Celeste.Spikes.Directions", "Directions",
            assemblyIdentity, "Celeste", 33556236, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Spikes.Directions", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Spikes.Directions",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Spring+Orientations", "Celeste.Spring.Orientations", "Orientations",
            assemblyIdentity, "Celeste", 33556237, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Spring.Orientations", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Spring.Orientations",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<>c__DisplayClass44_0",
            "Celeste.Strawberry.<>c__DisplayClass44_0", "<>c__DisplayClass44_0", assemblyIdentity, "Celeste", 33556238,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<>c__DisplayClass44_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<>c__DisplayClass44_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<FlyAwayRoutine>d__46",
            "Celeste.Strawberry.<FlyAwayRoutine>d__46", "<FlyAwayRoutine>d__46", assemblyIdentity, "Celeste", 33556239,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<FlyAwayRoutine>d__46", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<FlyAwayRoutine>d__46",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<CollectRoutine>d__47",
            "Celeste.Strawberry.<CollectRoutine>d__47", "<CollectRoutine>d__47", assemblyIdentity, "Celeste", 33556240,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<CollectRoutine>d__47", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<CollectRoutine>d__47",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<>c__DisplayClass48_0",
            "Celeste.Strawberry.<>c__DisplayClass48_0", "<>c__DisplayClass48_0", assemblyIdentity, "Celeste", 33556241,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<>c__DisplayClass48_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<>c__DisplayClass48_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+Themes", "Celeste.ZipMover.Themes", "Themes",
            assemblyIdentity, "Celeste", 33556242, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.Themes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.Themes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+ZipMoverPathRenderer",
            "Celeste.ZipMover.ZipMoverPathRenderer", "ZipMoverPathRenderer", assemblyIdentity, "Celeste", 33556243,
            false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.ZipMoverPathRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.ZipMoverPathRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+<Sequence>d__24", "Celeste.ZipMover.<Sequence>d__24",
            "<Sequence>d__24", assemblyIdentity, "Celeste", 33556244, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.<Sequence>d__24", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.<Sequence>d__24",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Backdrop+Fader", "Celeste.Backdrop.Fader", "Fader", assemblyIdentity,
            "Celeste", 33556245, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Backdrop.Fader", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop.Fader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystal+<Shatter>d__22", "Celeste.TheoCrystal.<Shatter>d__22",
            "<Shatter>d__22", assemblyIdentity, "Celeste", 33556246, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystal.<Shatter>d__22", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystal.<Shatter>d__22",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Input+PrefixMode", "Celeste.Input.PrefixMode", "PrefixMode",
            assemblyIdentity, "Celeste", 33556247, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Input.PrefixMode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Input.PrefixMode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur+Samples", "Celeste.GaussianBlur.Samples", "Samples",
            assemblyIdentity, "Celeste", 33556248, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur.Samples", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur.Samples",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur+Direction", "Celeste.GaussianBlur.Direction",
            "Direction", assemblyIdentity, "Celeste", 33556249, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur.Direction", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur.Direction",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Hahaha+Ha", "Celeste.Hahaha.Ha", "Ha", assemblyIdentity, "Celeste",
            33556250, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Hahaha.Ha", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Hahaha.Ha",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DisplacementRenderer+Burst", "Celeste.DisplacementRenderer.Burst",
            "Burst", assemblyIdentity, "Celeste", 33556251, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DisplacementRenderer.Burst", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DisplacementRenderer.Burst",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BackdropRenderer+<GetEach>d__9`1",
            "Celeste.BackdropRenderer.<GetEach>d__9`1", "<GetEach>d__9`1", assemblyIdentity, "Celeste", 33556252, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable", "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BackdropRenderer.<GetEach>d__9`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BackdropRenderer.<GetEach>d__9`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BackdropRenderer+<GetEach>d__10`1",
            "Celeste.BackdropRenderer.<GetEach>d__10`1", "<GetEach>d__10`1", assemblyIdentity, "Celeste", 33556253,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable", "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BackdropRenderer.<GetEach>d__10`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BackdropRenderer.<GetEach>d__10`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ScreenWipe+<Wait>d__16", "Celeste.ScreenWipe.<Wait>d__16",
            "<Wait>d__16", assemblyIdentity, "Celeste", 33556254, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ScreenWipe.<Wait>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ScreenWipe.<Wait>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Snow+Particle", "Celeste.Snow.Particle", "Particle", assemblyIdentity,
            "Celeste", 33556255, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Snow.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Snow.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass39_0",
            "Celeste.VertexLight.<>c__DisplayClass39_0", "<>c__DisplayClass39_0", assemblyIdentity, "Celeste", 33556256,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass39_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass39_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass40_0",
            "Celeste.VertexLight.<>c__DisplayClass40_0", "<>c__DisplayClass40_0", assemblyIdentity, "Celeste", 33556257,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass40_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass40_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass41_0",
            "Celeste.VertexLight.<>c__DisplayClass41_0", "<>c__DisplayClass41_0", assemblyIdentity, "Celeste", 33556258,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass41_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass41_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+CameraLockModes", "Celeste.Level.CameraLockModes",
            "CameraLockModes", assemblyIdentity, "Celeste", 33556259, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.CameraLockModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.CameraLockModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+ConditionBlockModes", "Celeste.Level.ConditionBlockModes",
            "ConditionBlockModes", assemblyIdentity, "Celeste", 33556260, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.ConditionBlockModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.ConditionBlockModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass126_0", "Celeste.Level.<>c__DisplayClass126_0",
            "<>c__DisplayClass126_0", assemblyIdentity, "Celeste", 33556261, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass126_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass126_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<TransitionRoutine>d__126",
            "Celeste.Level.<TransitionRoutine>d__126", "<TransitionRoutine>d__126", assemblyIdentity, "Celeste",
            33556262, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<TransitionRoutine>d__126", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<TransitionRoutine>d__126",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<SavingRoutine>d__141", "Celeste.Level.<SavingRoutine>d__141",
            "<SavingRoutine>d__141", assemblyIdentity, "Celeste", 33556263, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<SavingRoutine>d__141", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SavingRoutine>d__141",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_0", "Celeste.Level.<>c__DisplayClass149_0",
            "<>c__DisplayClass149_0", assemblyIdentity, "Celeste", 33556264, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_1", "Celeste.Level.<>c__DisplayClass149_1",
            "<>c__DisplayClass149_1", assemblyIdentity, "Celeste", 33556265, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_2", "Celeste.Level.<>c__DisplayClass149_2",
            "<>c__DisplayClass149_2", assemblyIdentity, "Celeste", 33556266, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_3", "Celeste.Level.<>c__DisplayClass149_3",
            "<>c__DisplayClass149_3", assemblyIdentity, "Celeste", 33556267, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_3", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_3",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_4", "Celeste.Level.<>c__DisplayClass149_4",
            "<>c__DisplayClass149_4", assemblyIdentity, "Celeste", 33556268, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_4", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_5", "Celeste.Level.<>c__DisplayClass149_5",
            "<>c__DisplayClass149_5", assemblyIdentity, "Celeste", 33556269, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_5", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_5",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c", "Celeste.Level.<>c", "<>c", assemblyIdentity, "Celeste",
            33556270, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass150_0", "Celeste.Level.<>c__DisplayClass150_0",
            "<>c__DisplayClass150_0", assemblyIdentity, "Celeste", 33556271, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass150_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass150_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass151_0", "Celeste.Level.<>c__DisplayClass151_0",
            "<>c__DisplayClass151_0", assemblyIdentity, "Celeste", 33556272, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass151_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass151_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<SaveFromOptions>d__152",
            "Celeste.Level.<SaveFromOptions>d__152", "<SaveFromOptions>d__152", assemblyIdentity, "Celeste", 33556273,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<SaveFromOptions>d__152", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SaveFromOptions>d__152",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass153_0", "Celeste.Level.<>c__DisplayClass153_0",
            "<>c__DisplayClass153_0", assemblyIdentity, "Celeste", 33556274, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass153_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass153_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass154_0", "Celeste.Level.<>c__DisplayClass154_0",
            "<>c__DisplayClass154_0", assemblyIdentity, "Celeste", 33556275, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass154_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass154_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomTo>d__162", "Celeste.Level.<ZoomTo>d__162",
            "<ZoomTo>d__162", assemblyIdentity, "Celeste", 33556276, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomTo>d__162", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomTo>d__162",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomAcross>d__163", "Celeste.Level.<ZoomAcross>d__163",
            "<ZoomAcross>d__163", assemblyIdentity, "Celeste", 33556277, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomAcross>d__163", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomAcross>d__163",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomBack>d__164", "Celeste.Level.<ZoomBack>d__164",
            "<ZoomBack>d__164", assemblyIdentity, "Celeste", 33556278, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomBack>d__164", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomBack>d__164",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<SkipCutsceneRoutine>d__181",
            "Celeste.Level.<SkipCutsceneRoutine>d__181", "<SkipCutsceneRoutine>d__181", assemblyIdentity, "Celeste",
            33556279, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<SkipCutsceneRoutine>d__181", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SkipCutsceneRoutine>d__181",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass183_0", "Celeste.Level.<>c__DisplayClass183_0",
            "<>c__DisplayClass183_0", assemblyIdentity, "Celeste", 33556280, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass183_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass183_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+IntroTypes", "Celeste.Player.IntroTypes", "IntroTypes",
            assemblyIdentity, "Celeste", 33556281, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.IntroTypes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.IntroTypes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserStateSound", "Celeste.Player.ChaserStateSound",
            "ChaserStateSound", assemblyIdentity, "Celeste", 33556282, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserStateSound", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserStateSound",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserState", "Celeste.Player.ChaserState", "ChaserState",
            assemblyIdentity, "Celeste", 33556283, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserState", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserState",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass344_0",
            "Celeste.Player.<>c__DisplayClass344_0", "<>c__DisplayClass344_0", assemblyIdentity, "Celeste", 33556284,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass344_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass344_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass344_1",
            "Celeste.Player.<>c__DisplayClass344_1", "<>c__DisplayClass344_1", assemblyIdentity, "Celeste", 33556285,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass344_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass344_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<DashCoroutine>d__427", "Celeste.Player.<DashCoroutine>d__427",
            "<DashCoroutine>d__427", assemblyIdentity, "Celeste", 33556286, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<DashCoroutine>d__427", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DashCoroutine>d__427",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<BoostCoroutine>d__450",
            "Celeste.Player.<BoostCoroutine>d__450", "<BoostCoroutine>d__450", assemblyIdentity, "Celeste", 33556287,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<BoostCoroutine>d__450", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<BoostCoroutine>d__450",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<RedDashCoroutine>d__454",
            "Celeste.Player.<RedDashCoroutine>d__454", "<RedDashCoroutine>d__454", assemblyIdentity, "Celeste",
            33556288, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<RedDashCoroutine>d__454", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<RedDashCoroutine>d__454",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass472_0",
            "Celeste.Player.<>c__DisplayClass472_0", "<>c__DisplayClass472_0", assemblyIdentity, "Celeste", 33556289,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass472_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass472_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<PickupCoroutine>d__472",
            "Celeste.Player.<PickupCoroutine>d__472", "<PickupCoroutine>d__472", assemblyIdentity, "Celeste", 33556290,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<PickupCoroutine>d__472", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<PickupCoroutine>d__472",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<StarFlyCoroutine>d__509",
            "Celeste.Player.<StarFlyCoroutine>d__509", "<StarFlyCoroutine>d__509", assemblyIdentity, "Celeste",
            33556291, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<StarFlyCoroutine>d__509", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<StarFlyCoroutine>d__509",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<FlingBirdCoroutine>d__517",
            "Celeste.Player.<FlingBirdCoroutine>d__517", "<FlingBirdCoroutine>d__517", assemblyIdentity, "Celeste",
            33556292, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<FlingBirdCoroutine>d__517", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<FlingBirdCoroutine>d__517",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<CassetteFlyCoroutine>d__524",
            "Celeste.Player.<CassetteFlyCoroutine>d__524", "<CassetteFlyCoroutine>d__524", assemblyIdentity, "Celeste",
            33556293, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<CassetteFlyCoroutine>d__524", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<CassetteFlyCoroutine>d__524",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<DummyWalkTo>d__538", "Celeste.Player.<DummyWalkTo>d__538",
            "<DummyWalkTo>d__538", assemblyIdentity, "Celeste", 33556294, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<DummyWalkTo>d__538", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DummyWalkTo>d__538",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<DummyWalkToExact>d__539",
            "Celeste.Player.<DummyWalkToExact>d__539", "<DummyWalkToExact>d__539", assemblyIdentity, "Celeste",
            33556295, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<DummyWalkToExact>d__539", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DummyWalkToExact>d__539",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<DummyRunTo>d__540", "Celeste.Player.<DummyRunTo>d__540",
            "<DummyRunTo>d__540", assemblyIdentity, "Celeste", 33556296, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<DummyRunTo>d__540", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DummyRunTo>d__540",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<TempleFallCoroutine>d__543",
            "Celeste.Player.<TempleFallCoroutine>d__543", "<TempleFallCoroutine>d__543", assemblyIdentity, "Celeste",
            33556297, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<TempleFallCoroutine>d__543", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<TempleFallCoroutine>d__543",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<ReflectionFallCoroutine>d__547",
            "Celeste.Player.<ReflectionFallCoroutine>d__547", "<ReflectionFallCoroutine>d__547", assemblyIdentity,
            "Celeste", 33556298, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<ReflectionFallCoroutine>d__547", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<ReflectionFallCoroutine>d__547",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass548_0",
            "Celeste.Player.<>c__DisplayClass548_0", "<>c__DisplayClass548_0", assemblyIdentity, "Celeste", 33556299,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass548_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass548_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroWalkCoroutine>d__550",
            "Celeste.Player.<IntroWalkCoroutine>d__550", "<IntroWalkCoroutine>d__550", assemblyIdentity, "Celeste",
            33556300, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroWalkCoroutine>d__550", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroWalkCoroutine>d__550",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroJumpCoroutine>d__551",
            "Celeste.Player.<IntroJumpCoroutine>d__551", "<IntroJumpCoroutine>d__551", assemblyIdentity, "Celeste",
            33556301, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroJumpCoroutine>d__551", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroJumpCoroutine>d__551",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroMoonJumpCoroutine>d__552",
            "Celeste.Player.<IntroMoonJumpCoroutine>d__552", "<IntroMoonJumpCoroutine>d__552", assemblyIdentity,
            "Celeste", 33556302, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroMoonJumpCoroutine>d__552", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroMoonJumpCoroutine>d__552",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<MoonLanding>d__553", "Celeste.Player.<MoonLanding>d__553",
            "<MoonLanding>d__553", assemblyIdentity, "Celeste", 33556303, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<MoonLanding>d__553", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<MoonLanding>d__553",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroWakeUpCoroutine>d__554",
            "Celeste.Player.<IntroWakeUpCoroutine>d__554", "<IntroWakeUpCoroutine>d__554", assemblyIdentity, "Celeste",
            33556304, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroWakeUpCoroutine>d__554", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroWakeUpCoroutine>d__554",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass556_0",
            "Celeste.Player.<>c__DisplayClass556_0", "<>c__DisplayClass556_0", assemblyIdentity, "Celeste", 33556305,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass556_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass556_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroThinkForABitCoroutine>d__558",
            "Celeste.Player.<IntroThinkForABitCoroutine>d__558", "<IntroThinkForABitCoroutine>d__558", assemblyIdentity,
            "Celeste", 33556306, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroThinkForABitCoroutine>d__558", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroThinkForABitCoroutine>d__558",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+<BirdDashTutorialCoroutine>d__561",
            "Celeste.Player.<BirdDashTutorialCoroutine>d__561", "<BirdDashTutorialCoroutine>d__561", assemblyIdentity,
            "Celeste", 33556307, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.<BirdDashTutorialCoroutine>d__561", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.<BirdDashTutorialCoroutine>d__561",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Celeste+PlayModes", "Celeste.Celeste.PlayModes", "PlayModes",
            assemblyIdentity, "Celeste", 33556308, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Celeste.PlayModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Celeste.PlayModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RunThread+<>c__DisplayClass1_0",
            "Celeste.RunThread.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste", 33556309,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RunThread.<>c__DisplayClass1_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.RunThread.<>c__DisplayClass1_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UserIO+Mode", "Celeste.UserIO.Mode", "Mode", assemblyIdentity,
            "Celeste", 33556310, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UserIO.Mode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.UserIO.Mode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UserIO+<SaveRoutine>d__29", "Celeste.UserIO.<SaveRoutine>d__29",
            "<SaveRoutine>d__29", assemblyIdentity, "Celeste", 33556311, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UserIO.<SaveRoutine>d__29", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.UserIO.<SaveRoutine>d__29",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PreviewDialog+Renderer", "Celeste.PreviewDialog.Renderer", "Renderer",
            assemblyIdentity, "Celeste", 33556312, false,
            new string[] { "Celeste.HiresRenderer", "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PreviewDialog.Renderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PreviewDialog.Renderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Editor.MapEditor+MouseModes", "Celeste.Editor.MapEditor.MouseModes",
            "MouseModes", assemblyIdentity, "Celeste", 33556313, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Editor.MapEditor.MouseModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Editor.MapEditor.MouseModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+Cloud", "Celeste.Pico8.Classic.Cloud", "Cloud",
            assemblyIdentity, "Celeste", 33556314, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.Cloud", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.Cloud",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+Particle", "Celeste.Pico8.Classic.Particle", "Particle",
            assemblyIdentity, "Celeste", 33556315, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.Particle", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+DeadParticle", "Celeste.Pico8.Classic.DeadParticle",
            "DeadParticle", assemblyIdentity, "Celeste", 33556316, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.DeadParticle", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.DeadParticle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player", "Celeste.Pico8.Classic.player", "player",
            assemblyIdentity, "Celeste", 33556317, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player_hair", "Celeste.Pico8.Classic.player_hair",
            "player_hair", assemblyIdentity, "Celeste", 33556318, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player_hair", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player_hair",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player_spawn", "Celeste.Pico8.Classic.player_spawn",
            "player_spawn", assemblyIdentity, "Celeste", 33556319, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player_spawn", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player_spawn",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+spring", "Celeste.Pico8.Classic.spring", "spring",
            assemblyIdentity, "Celeste", 33556320, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.spring", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.spring",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+balloon", "Celeste.Pico8.Classic.balloon", "balloon",
            assemblyIdentity, "Celeste", 33556321, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.balloon", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.balloon",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fall_floor", "Celeste.Pico8.Classic.fall_floor",
            "fall_floor", assemblyIdentity, "Celeste", 33556322, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fall_floor", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fall_floor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+smoke", "Celeste.Pico8.Classic.smoke", "smoke",
            assemblyIdentity, "Celeste", 33556323, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.smoke", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.smoke",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fruit", "Celeste.Pico8.Classic.fruit", "fruit",
            assemblyIdentity, "Celeste", 33556324, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fruit", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fruit",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fly_fruit", "Celeste.Pico8.Classic.fly_fruit",
            "fly_fruit", assemblyIdentity, "Celeste", 33556325, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fly_fruit", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fly_fruit",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+lifeup", "Celeste.Pico8.Classic.lifeup", "lifeup",
            assemblyIdentity, "Celeste", 33556326, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.lifeup", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.lifeup",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fake_wall", "Celeste.Pico8.Classic.fake_wall",
            "fake_wall", assemblyIdentity, "Celeste", 33556327, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fake_wall", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fake_wall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+key", "Celeste.Pico8.Classic.key", "key",
            assemblyIdentity, "Celeste", 33556328, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.key", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.key",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+chest", "Celeste.Pico8.Classic.chest", "chest",
            assemblyIdentity, "Celeste", 33556329, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.chest", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.chest",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+platform", "Celeste.Pico8.Classic.platform", "platform",
            assemblyIdentity, "Celeste", 33556330, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.platform", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.platform",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+message", "Celeste.Pico8.Classic.message", "message",
            assemblyIdentity, "Celeste", 33556331, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.message", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.message",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+big_chest", "Celeste.Pico8.Classic.big_chest",
            "big_chest", assemblyIdentity, "Celeste", 33556332, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.big_chest", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.big_chest",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+orb", "Celeste.Pico8.Classic.orb", "orb",
            assemblyIdentity, "Celeste", 33556333, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.orb", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.orb",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+flag", "Celeste.Pico8.Classic.flag", "flag",
            assemblyIdentity, "Celeste", 33556334, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.flag", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.flag",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+room_title", "Celeste.Pico8.Classic.room_title",
            "room_title", assemblyIdentity, "Celeste", 33556335, false,
            new string[] { "Celeste.Pico8.Classic+ClassicObject", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.room_title", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.room_title",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+ClassicObject", "Celeste.Pico8.Classic.ClassicObject",
            "ClassicObject", assemblyIdentity, "Celeste", 33556336, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.ClassicObject", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.ClassicObject",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Emulator+<>c__DisplayClass34_0",
            "Celeste.Pico8.Emulator.<>c__DisplayClass34_0", "<>c__DisplayClass34_0", assemblyIdentity, "Celeste",
            33556337, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Emulator.<>c__DisplayClass34_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Emulator.<>c__DisplayClass34_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=12", "__StaticArrayInitTypeSize=12",
            assemblyIdentity, "Celeste", 33556338, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=12", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=12",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=16", "__StaticArrayInitTypeSize=16",
            assemblyIdentity, "Celeste", 33556339, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=16", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=20", "__StaticArrayInitTypeSize=20",
            assemblyIdentity, "Celeste", 33556340, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=20", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=20",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=24", "__StaticArrayInitTypeSize=24",
            assemblyIdentity, "Celeste", 33556341, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=24", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=24",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=40", "__StaticArrayInitTypeSize=40",
            assemblyIdentity, "Celeste", 33556342, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=40", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=40",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=44",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=44", "__StaticArrayInitTypeSize=44",
            assemblyIdentity, "Celeste", 33556343, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=44", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=44",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=56",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=56", "__StaticArrayInitTypeSize=56",
            assemblyIdentity, "Celeste", 33556344, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=56", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=56",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=64",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=64", "__StaticArrayInitTypeSize=64",
            assemblyIdentity, "Celeste", 33556345, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=64", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=64",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=128",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=128", "__StaticArrayInitTypeSize=128",
            assemblyIdentity, "Celeste", 33556346, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=128", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=128",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=160",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=160", "__StaticArrayInitTypeSize=160",
            assemblyIdentity, "Celeste", 33556347, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=160", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=160",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=512",
            "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=512", "__StaticArrayInitTypeSize=512",
            assemblyIdentity, "Celeste", 33556348, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=512", 0, false);
        catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=512",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide+<EaseIn>d__5",
            "Celeste.Cassette.UnlockedBSide.<EaseIn>d__5", "<EaseIn>d__5", assemblyIdentity, "Celeste", 33556349, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide.<EaseIn>d__5", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide.<EaseIn>d__5",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide+<EaseOut>d__6",
            "Celeste.Cassette.UnlockedBSide.<EaseOut>d__6", "<EaseOut>d__6", assemblyIdentity, "Celeste", 33556350,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide.<EaseOut>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide.<EaseOut>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<EaseIn>d__14",
            "Celeste.CS03_Memo.MemoPage.<EaseIn>d__14", "<EaseIn>d__14", assemblyIdentity, "Celeste", 33556351, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<EaseIn>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<EaseIn>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<Wait>d__15",
            "Celeste.CS03_Memo.MemoPage.<Wait>d__15", "<Wait>d__15", assemblyIdentity, "Celeste", 33556352, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<Wait>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<Wait>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<EaseOut>d__16",
            "Celeste.CS03_Memo.MemoPage.<EaseOut>d__16", "<EaseOut>d__16", assemblyIdentity, "Celeste", 33556353, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<EaseOut>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<EaseOut>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+Bird+<IdleRoutine>d__3",
            "Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3", "<IdleRoutine>d__3", assemblyIdentity, "Celeste", 33556354,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+Bird+<FlyAwayRoutine>d__4",
            "Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4", "<FlyAwayRoutine>d__4", assemblyIdentity, "Celeste",
            33556355, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal+PoemPage+<EaseIn>d__10",
            "Celeste.CS02_Journal.PoemPage.<EaseIn>d__10", "<EaseIn>d__10", assemblyIdentity, "Celeste", 33556356,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal.PoemPage.<EaseIn>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal.PoemPage.<EaseIn>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal+PoemPage+<EaseOut>d__11",
            "Celeste.CS02_Journal.PoemPage.<EaseOut>d__11", "<EaseOut>d__11", assemblyIdentity, "Celeste", 33556357,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal.PoemPage.<EaseOut>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal.PoemPage.<EaseOut>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+Orb+<FloatRoutine>d__9",
            "Celeste.NPC06_Badeline_Crying.Orb.<FloatRoutine>d__9", "<FloatRoutine>d__9", assemblyIdentity, "Celeste",
            33556358, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.Orb.<FloatRoutine>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.Orb.<FloatRoutine>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+Orb+<CircleRoutine>d__10",
            "Celeste.NPC06_Badeline_Crying.Orb.<CircleRoutine>d__10", "<CircleRoutine>d__10", assemblyIdentity,
            "Celeste", 33556359, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.Orb.<CircleRoutine>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.Orb.<CircleRoutine>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+Orb+<AbsorbRoutine>d__11",
            "Celeste.NPC06_Badeline_Crying.Orb.<AbsorbRoutine>d__11", "<AbsorbRoutine>d__11", assemblyIdentity,
            "Celeste", 33556360, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.Orb.<AbsorbRoutine>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.Orb.<AbsorbRoutine>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Streaks+Particle",
            "Celeste.AscendManager.Streaks.Particle", "Particle", assemblyIdentity, "Celeste", 33556361, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Streaks.Particle", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Streaks.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Clouds+Particle",
            "Celeste.AscendManager.Clouds.Particle", "Particle", assemblyIdentity, "Celeste", 33556362, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Clouds.Particle", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Clouds.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint+ConfettiRenderer+Particle",
            "Celeste.SummitCheckpoint.ConfettiRenderer.Particle", "Particle", assemblyIdentity, "Celeste", 33556363,
            false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint.ConfettiRenderer.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint.ConfettiRenderer.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display+<>c", "Celeste.WaveDashPage05.Display.<>c",
            "<>c", assemblyIdentity, "Celeste", 33556364, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display+<Routine>d__7",
            "Celeste.WaveDashPage05.Display.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33556365,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display.<Routine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display.<Routine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02+TitleText+<Stamp>d__6",
            "Celeste.WaveDashPage02.TitleText.<Stamp>d__6", "<Stamp>d__6", assemblyIdentity, "Celeste", 33556366, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02.TitleText.<Stamp>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02.TitleText.<Stamp>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer+Bolt+<Run>d__14",
            "Celeste.LightningRenderer.Bolt.<Run>d__14", "<Run>d__14", assemblyIdentity, "Celeste", 33556367, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer.Bolt.<Run>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer.Bolt.<Run>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+MultiCredit+Section", "Celeste.Credits.MultiCredit.Section",
            "Section", assemblyIdentity, "Celeste", 33556368, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.MultiCredit.Section", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.MultiCredit.Section",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<AimlessFlightRoutine>d__12",
            "Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12", "<AimlessFlightRoutine>d__12",
            assemblyIdentity, "Celeste", 33556369, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12", 0,
            false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<DashRoutine>d__13",
            "Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13", "<DashRoutine>d__13", assemblyIdentity,
            "Celeste", 33556370, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<TransformRoutine>d__14",
            "Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14", "<TransformRoutine>d__14",
            assemblyIdentity, "Celeste", 33556371, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<EaseIn>d__10",
            "Celeste.LevelEnter.BSideTitle.<EaseIn>d__10", "<EaseIn>d__10", assemblyIdentity, "Celeste", 33556372,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<EaseIn>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<EaseIn>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<EaseOut>d__11",
            "Celeste.LevelEnter.BSideTitle.<EaseOut>d__11", "<EaseOut>d__11", assemblyIdentity, "Celeste", 33556373,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<EaseOut>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<EaseOut>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<FadeTo>d__12",
            "Celeste.LevelEnter.BSideTitle.<FadeTo>d__12", "<FadeTo>d__12", assemblyIdentity, "Celeste", 33556374,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<FadeTo>d__12", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<FadeTo>d__12",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS00_Ending+EndingCutsceneDelay+<Routine>d__1",
            "Celeste.CS00_Ending.EndingCutsceneDelay.<Routine>d__1", "<Routine>d__1", assemblyIdentity, "Celeste",
            33556375, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS00_Ending.EndingCutsceneDelay.<Routine>d__1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS00_Ending.EndingCutsceneDelay.<Routine>d__1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Backdrop+Fader+Segment", "Celeste.Backdrop.Fader.Segment", "Segment",
            assemblyIdentity, "Celeste", 33556376, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Backdrop.Fader.Segment", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop.Fader.Segment",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserStateSound+Actions",
            "Celeste.Player.ChaserStateSound.Actions", "Actions", assemblyIdentity, "Celeste", 33556377, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserStateSound.Actions", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserStateSound.Actions",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player_hair+node",
            "Celeste.Pico8.Classic.player_hair.node", "node", assemblyIdentity, "Celeste", 33556378, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player_hair.node", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player_hair.node",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+big_chest+particle",
            "Celeste.Pico8.Classic.big_chest.particle", "particle", assemblyIdentity, "Celeste", 33556379, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.big_chest.particle", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.big_chest.particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
