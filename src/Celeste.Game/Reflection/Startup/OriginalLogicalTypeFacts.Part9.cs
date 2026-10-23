using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static partial class OriginalLogicalTypeFacts
    {
        private static void RegisterPart9(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.Trigger+PositionModes", "Celeste.Trigger.PositionModes",
                "PositionModes", assemblyIdentity, "Celeste", 33556234, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Trigger.PositionModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Trigger.PositionModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Refill+<RefillRoutine>d__28",
                "Celeste.Refill.<RefillRoutine>d__28",
                "<RefillRoutine>d__28", assemblyIdentity, "Celeste", 33556235, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Refill.<RefillRoutine>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Refill.<RefillRoutine>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spikes+Directions", "Celeste.Spikes.Directions", "Directions",
                assemblyIdentity, "Celeste", 33556236, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spikes.Directions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spikes.Directions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spring+Orientations", "Celeste.Spring.Orientations",
                "Orientations",
                assemblyIdentity, "Celeste", 33556237, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spring.Orientations", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spring.Orientations",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<>c__DisplayClass44_0",
                "Celeste.Strawberry.<>c__DisplayClass44_0", "<>c__DisplayClass44_0", assemblyIdentity, "Celeste",
                33556238,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<>c__DisplayClass44_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<>c__DisplayClass44_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<FlyAwayRoutine>d__46",
                "Celeste.Strawberry.<FlyAwayRoutine>d__46", "<FlyAwayRoutine>d__46", assemblyIdentity, "Celeste",
                33556239,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<FlyAwayRoutine>d__46", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<FlyAwayRoutine>d__46",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<CollectRoutine>d__47",
                "Celeste.Strawberry.<CollectRoutine>d__47", "<CollectRoutine>d__47", assemblyIdentity, "Celeste",
                33556240,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<CollectRoutine>d__47", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<CollectRoutine>d__47",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<>c__DisplayClass48_0",
                "Celeste.Strawberry.<>c__DisplayClass48_0", "<>c__DisplayClass48_0", assemblyIdentity, "Celeste",
                33556241,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<>c__DisplayClass48_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<>c__DisplayClass48_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+Themes", "Celeste.ZipMover.Themes", "Themes",
                assemblyIdentity, "Celeste", 33556242, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.Themes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.Themes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+ZipMoverPathRenderer",
                "Celeste.ZipMover.ZipMoverPathRenderer", "ZipMoverPathRenderer", assemblyIdentity, "Celeste", 33556243,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.ZipMoverPathRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.ZipMoverPathRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+<Sequence>d__24", "Celeste.ZipMover.<Sequence>d__24",
                "<Sequence>d__24", assemblyIdentity, "Celeste", 33556244, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.<Sequence>d__24", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.<Sequence>d__24",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Backdrop+Fader", "Celeste.Backdrop.Fader", "Fader",
                assemblyIdentity,
                "Celeste", 33556245, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Backdrop.Fader", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop.Fader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystal+<Shatter>d__22", "Celeste.TheoCrystal.<Shatter>d__22",
                "<Shatter>d__22", assemblyIdentity, "Celeste", 33556246, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystal.<Shatter>d__22", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystal.<Shatter>d__22",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Input+PrefixMode", "Celeste.Input.PrefixMode", "PrefixMode",
                assemblyIdentity, "Celeste", 33556247, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Input.PrefixMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Input.PrefixMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur+Samples", "Celeste.GaussianBlur.Samples", "Samples",
                assemblyIdentity, "Celeste", 33556248, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur.Samples", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur.Samples",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur+Direction", "Celeste.GaussianBlur.Direction",
                "Direction", assemblyIdentity, "Celeste", 33556249, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur.Direction", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur.Direction",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Hahaha+Ha", "Celeste.Hahaha.Ha", "Ha", assemblyIdentity,
                "Celeste",
                33556250, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Hahaha.Ha", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Hahaha.Ha",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisplacementRenderer+Burst", "Celeste.DisplacementRenderer.Burst",
                "Burst", assemblyIdentity, "Celeste", 33556251, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisplacementRenderer.Burst", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisplacementRenderer.Burst",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackdropRenderer+<GetEach>d__9`1",
                "Celeste.BackdropRenderer.<GetEach>d__9`1", "<GetEach>d__9`1", assemblyIdentity, "Celeste", 33556252,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                    "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackdropRenderer.<GetEach>d__9`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackdropRenderer.<GetEach>d__9`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackdropRenderer+<GetEach>d__10`1",
                "Celeste.BackdropRenderer.<GetEach>d__10`1", "<GetEach>d__10`1", assemblyIdentity, "Celeste", 33556253,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                    "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackdropRenderer.<GetEach>d__10`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackdropRenderer.<GetEach>d__10`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ScreenWipe+<Wait>d__16", "Celeste.ScreenWipe.<Wait>d__16",
                "<Wait>d__16", assemblyIdentity, "Celeste", 33556254, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ScreenWipe.<Wait>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ScreenWipe.<Wait>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snow+Particle", "Celeste.Snow.Particle", "Particle",
                assemblyIdentity,
                "Celeste", 33556255, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snow.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snow.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass39_0",
                "Celeste.VertexLight.<>c__DisplayClass39_0", "<>c__DisplayClass39_0", assemblyIdentity, "Celeste",
                33556256,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass39_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass39_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass40_0",
                "Celeste.VertexLight.<>c__DisplayClass40_0", "<>c__DisplayClass40_0", assemblyIdentity, "Celeste",
                33556257,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass40_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass40_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass41_0",
                "Celeste.VertexLight.<>c__DisplayClass41_0", "<>c__DisplayClass41_0", assemblyIdentity, "Celeste",
                33556258,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass41_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass41_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+CameraLockModes", "Celeste.Level.CameraLockModes",
                "CameraLockModes", assemblyIdentity, "Celeste", 33556259, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.CameraLockModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.CameraLockModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+ConditionBlockModes", "Celeste.Level.ConditionBlockModes",
                "ConditionBlockModes", assemblyIdentity, "Celeste", 33556260, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.ConditionBlockModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.ConditionBlockModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass126_0",
                "Celeste.Level.<>c__DisplayClass126_0",
                "<>c__DisplayClass126_0", assemblyIdentity, "Celeste", 33556261, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass126_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass126_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<TransitionRoutine>d__126",
                "Celeste.Level.<TransitionRoutine>d__126", "<TransitionRoutine>d__126", assemblyIdentity, "Celeste",
                33556262, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<TransitionRoutine>d__126", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<TransitionRoutine>d__126",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<SavingRoutine>d__141",
                "Celeste.Level.<SavingRoutine>d__141",
                "<SavingRoutine>d__141", assemblyIdentity, "Celeste", 33556263, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<SavingRoutine>d__141", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SavingRoutine>d__141",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_0",
                "Celeste.Level.<>c__DisplayClass149_0",
                "<>c__DisplayClass149_0", assemblyIdentity, "Celeste", 33556264, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_1",
                "Celeste.Level.<>c__DisplayClass149_1",
                "<>c__DisplayClass149_1", assemblyIdentity, "Celeste", 33556265, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_2",
                "Celeste.Level.<>c__DisplayClass149_2",
                "<>c__DisplayClass149_2", assemblyIdentity, "Celeste", 33556266, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_2", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_3",
                "Celeste.Level.<>c__DisplayClass149_3",
                "<>c__DisplayClass149_3", assemblyIdentity, "Celeste", 33556267, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_3", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_3",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_4",
                "Celeste.Level.<>c__DisplayClass149_4",
                "<>c__DisplayClass149_4", assemblyIdentity, "Celeste", 33556268, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_4", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_5",
                "Celeste.Level.<>c__DisplayClass149_5",
                "<>c__DisplayClass149_5", assemblyIdentity, "Celeste", 33556269, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_5", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c", "Celeste.Level.<>c", "<>c", assemblyIdentity,
                "Celeste",
                33556270, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass150_0",
                "Celeste.Level.<>c__DisplayClass150_0",
                "<>c__DisplayClass150_0", assemblyIdentity, "Celeste", 33556271, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass150_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass150_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass151_0",
                "Celeste.Level.<>c__DisplayClass151_0",
                "<>c__DisplayClass151_0", assemblyIdentity, "Celeste", 33556272, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass151_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass151_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<SaveFromOptions>d__152",
                "Celeste.Level.<SaveFromOptions>d__152", "<SaveFromOptions>d__152", assemblyIdentity, "Celeste",
                33556273,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<SaveFromOptions>d__152", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SaveFromOptions>d__152",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass153_0",
                "Celeste.Level.<>c__DisplayClass153_0",
                "<>c__DisplayClass153_0", assemblyIdentity, "Celeste", 33556274, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass153_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass153_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass154_0",
                "Celeste.Level.<>c__DisplayClass154_0",
                "<>c__DisplayClass154_0", assemblyIdentity, "Celeste", 33556275, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass154_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass154_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomTo>d__162", "Celeste.Level.<ZoomTo>d__162",
                "<ZoomTo>d__162", assemblyIdentity, "Celeste", 33556276, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomTo>d__162", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomTo>d__162",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomAcross>d__163", "Celeste.Level.<ZoomAcross>d__163",
                "<ZoomAcross>d__163", assemblyIdentity, "Celeste", 33556277, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomAcross>d__163", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomAcross>d__163",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomBack>d__164", "Celeste.Level.<ZoomBack>d__164",
                "<ZoomBack>d__164", assemblyIdentity, "Celeste", 33556278, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomBack>d__164", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomBack>d__164",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<SkipCutsceneRoutine>d__181",
                "Celeste.Level.<SkipCutsceneRoutine>d__181", "<SkipCutsceneRoutine>d__181", assemblyIdentity, "Celeste",
                33556279, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<SkipCutsceneRoutine>d__181", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SkipCutsceneRoutine>d__181",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass183_0",
                "Celeste.Level.<>c__DisplayClass183_0",
                "<>c__DisplayClass183_0", assemblyIdentity, "Celeste", 33556280, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass183_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass183_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+IntroTypes", "Celeste.Player.IntroTypes", "IntroTypes",
                assemblyIdentity, "Celeste", 33556281, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.IntroTypes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.IntroTypes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserStateSound", "Celeste.Player.ChaserStateSound",
                "ChaserStateSound", assemblyIdentity, "Celeste", 33556282, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserStateSound", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserStateSound",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserState", "Celeste.Player.ChaserState", "ChaserState",
                assemblyIdentity, "Celeste", 33556283, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserState", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass344_0",
                "Celeste.Player.<>c__DisplayClass344_0", "<>c__DisplayClass344_0", assemblyIdentity, "Celeste",
                33556284,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass344_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass344_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass344_1",
                "Celeste.Player.<>c__DisplayClass344_1", "<>c__DisplayClass344_1", assemblyIdentity, "Celeste",
                33556285,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass344_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass344_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<DashCoroutine>d__427",
                "Celeste.Player.<DashCoroutine>d__427",
                "<DashCoroutine>d__427", assemblyIdentity, "Celeste", 33556286, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<DashCoroutine>d__427", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DashCoroutine>d__427",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<BoostCoroutine>d__450",
                "Celeste.Player.<BoostCoroutine>d__450", "<BoostCoroutine>d__450", assemblyIdentity, "Celeste",
                33556287,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<BoostCoroutine>d__450", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<BoostCoroutine>d__450",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<RedDashCoroutine>d__454",
                "Celeste.Player.<RedDashCoroutine>d__454", "<RedDashCoroutine>d__454", assemblyIdentity, "Celeste",
                33556288, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<RedDashCoroutine>d__454", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<RedDashCoroutine>d__454",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass472_0",
                "Celeste.Player.<>c__DisplayClass472_0", "<>c__DisplayClass472_0", assemblyIdentity, "Celeste",
                33556289,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass472_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass472_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<PickupCoroutine>d__472",
                "Celeste.Player.<PickupCoroutine>d__472", "<PickupCoroutine>d__472", assemblyIdentity, "Celeste",
                33556290,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<PickupCoroutine>d__472", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<PickupCoroutine>d__472",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<StarFlyCoroutine>d__509",
                "Celeste.Player.<StarFlyCoroutine>d__509", "<StarFlyCoroutine>d__509", assemblyIdentity, "Celeste",
                33556291, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<StarFlyCoroutine>d__509", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<StarFlyCoroutine>d__509",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<FlingBirdCoroutine>d__517",
                "Celeste.Player.<FlingBirdCoroutine>d__517", "<FlingBirdCoroutine>d__517", assemblyIdentity, "Celeste",
                33556292, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<FlingBirdCoroutine>d__517", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<FlingBirdCoroutine>d__517",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<CassetteFlyCoroutine>d__524",
                "Celeste.Player.<CassetteFlyCoroutine>d__524", "<CassetteFlyCoroutine>d__524", assemblyIdentity,
                "Celeste",
                33556293, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<CassetteFlyCoroutine>d__524", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<CassetteFlyCoroutine>d__524",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<DummyWalkTo>d__538", "Celeste.Player.<DummyWalkTo>d__538",
                "<DummyWalkTo>d__538", assemblyIdentity, "Celeste", 33556294, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<DummyWalkTo>d__538", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DummyWalkTo>d__538",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<DummyWalkToExact>d__539",
                "Celeste.Player.<DummyWalkToExact>d__539", "<DummyWalkToExact>d__539", assemblyIdentity, "Celeste",
                33556295, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<DummyWalkToExact>d__539", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DummyWalkToExact>d__539",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<DummyRunTo>d__540", "Celeste.Player.<DummyRunTo>d__540",
                "<DummyRunTo>d__540", assemblyIdentity, "Celeste", 33556296, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<DummyRunTo>d__540", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DummyRunTo>d__540",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<TempleFallCoroutine>d__543",
                "Celeste.Player.<TempleFallCoroutine>d__543", "<TempleFallCoroutine>d__543", assemblyIdentity,
                "Celeste",
                33556297, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<TempleFallCoroutine>d__543", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<TempleFallCoroutine>d__543",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<ReflectionFallCoroutine>d__547",
                "Celeste.Player.<ReflectionFallCoroutine>d__547", "<ReflectionFallCoroutine>d__547", assemblyIdentity,
                "Celeste", 33556298, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<ReflectionFallCoroutine>d__547", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<ReflectionFallCoroutine>d__547",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass548_0",
                "Celeste.Player.<>c__DisplayClass548_0", "<>c__DisplayClass548_0", assemblyIdentity, "Celeste",
                33556299,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass548_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass548_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroWalkCoroutine>d__550",
                "Celeste.Player.<IntroWalkCoroutine>d__550", "<IntroWalkCoroutine>d__550", assemblyIdentity, "Celeste",
                33556300, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroWalkCoroutine>d__550", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroWalkCoroutine>d__550",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroJumpCoroutine>d__551",
                "Celeste.Player.<IntroJumpCoroutine>d__551", "<IntroJumpCoroutine>d__551", assemblyIdentity, "Celeste",
                33556301, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroJumpCoroutine>d__551", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroJumpCoroutine>d__551",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroMoonJumpCoroutine>d__552",
                "Celeste.Player.<IntroMoonJumpCoroutine>d__552", "<IntroMoonJumpCoroutine>d__552", assemblyIdentity,
                "Celeste", 33556302, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroMoonJumpCoroutine>d__552", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroMoonJumpCoroutine>d__552",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<MoonLanding>d__553", "Celeste.Player.<MoonLanding>d__553",
                "<MoonLanding>d__553", assemblyIdentity, "Celeste", 33556303, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<MoonLanding>d__553", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<MoonLanding>d__553",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroWakeUpCoroutine>d__554",
                "Celeste.Player.<IntroWakeUpCoroutine>d__554", "<IntroWakeUpCoroutine>d__554", assemblyIdentity,
                "Celeste",
                33556304, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroWakeUpCoroutine>d__554", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroWakeUpCoroutine>d__554",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass556_0",
                "Celeste.Player.<>c__DisplayClass556_0", "<>c__DisplayClass556_0", assemblyIdentity, "Celeste",
                33556305,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass556_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass556_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<IntroThinkForABitCoroutine>d__558",
                "Celeste.Player.<IntroThinkForABitCoroutine>d__558", "<IntroThinkForABitCoroutine>d__558",
                assemblyIdentity,
                "Celeste", 33556306, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<IntroThinkForABitCoroutine>d__558", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<IntroThinkForABitCoroutine>d__558",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<BirdDashTutorialCoroutine>d__561",
                "Celeste.Player.<BirdDashTutorialCoroutine>d__561", "<BirdDashTutorialCoroutine>d__561",
                assemblyIdentity,
                "Celeste", 33556307, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<BirdDashTutorialCoroutine>d__561", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<BirdDashTutorialCoroutine>d__561",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Celeste+PlayModes", "Celeste.Celeste.PlayModes", "PlayModes",
                assemblyIdentity, "Celeste", 33556308, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Celeste.PlayModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Celeste.PlayModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RunThread+<>c__DisplayClass1_0",
                "Celeste.RunThread.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste", 33556309,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RunThread.<>c__DisplayClass1_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.RunThread.<>c__DisplayClass1_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UserIO+Mode", "Celeste.UserIO.Mode", "Mode", assemblyIdentity,
                "Celeste", 33556310, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UserIO.Mode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.UserIO.Mode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UserIO+<SaveRoutine>d__29", "Celeste.UserIO.<SaveRoutine>d__29",
                "<SaveRoutine>d__29", assemblyIdentity, "Celeste", 33556311, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UserIO.<SaveRoutine>d__29", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.UserIO.<SaveRoutine>d__29",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewDialog+Renderer", "Celeste.PreviewDialog.Renderer",
                "Renderer",
                assemblyIdentity, "Celeste", 33556312, false,
                ["Celeste.HiresRenderer", "Monocle.Renderer", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewDialog.Renderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewDialog.Renderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Editor.MapEditor+MouseModes",
                "Celeste.Editor.MapEditor.MouseModes",
                "MouseModes", assemblyIdentity, "Celeste", 33556313, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Editor.MapEditor.MouseModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Editor.MapEditor.MouseModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+Cloud", "Celeste.Pico8.Classic.Cloud", "Cloud",
                assemblyIdentity, "Celeste", 33556314, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.Cloud", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.Cloud",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+Particle", "Celeste.Pico8.Classic.Particle",
                "Particle",
                assemblyIdentity, "Celeste", 33556315, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.Particle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+DeadParticle", "Celeste.Pico8.Classic.DeadParticle",
                "DeadParticle", assemblyIdentity, "Celeste", 33556316, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.DeadParticle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.DeadParticle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player", "Celeste.Pico8.Classic.player", "player",
                assemblyIdentity, "Celeste", 33556317, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player_hair", "Celeste.Pico8.Classic.player_hair",
                "player_hair", assemblyIdentity, "Celeste", 33556318, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player_hair", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player_hair",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player_spawn", "Celeste.Pico8.Classic.player_spawn",
                "player_spawn", assemblyIdentity, "Celeste", 33556319, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player_spawn", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player_spawn",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+spring", "Celeste.Pico8.Classic.spring", "spring",
                assemblyIdentity, "Celeste", 33556320, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.spring", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.spring",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+balloon", "Celeste.Pico8.Classic.balloon",
                "balloon",
                assemblyIdentity, "Celeste", 33556321, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.balloon", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.balloon",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fall_floor", "Celeste.Pico8.Classic.fall_floor",
                "fall_floor", assemblyIdentity, "Celeste", 33556322, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fall_floor", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fall_floor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+smoke", "Celeste.Pico8.Classic.smoke", "smoke",
                assemblyIdentity, "Celeste", 33556323, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.smoke", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.smoke",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fruit", "Celeste.Pico8.Classic.fruit", "fruit",
                assemblyIdentity, "Celeste", 33556324, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fruit", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fruit",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fly_fruit", "Celeste.Pico8.Classic.fly_fruit",
                "fly_fruit", assemblyIdentity, "Celeste", 33556325, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fly_fruit", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fly_fruit",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+lifeup", "Celeste.Pico8.Classic.lifeup", "lifeup",
                assemblyIdentity, "Celeste", 33556326, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.lifeup", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.lifeup",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+fake_wall", "Celeste.Pico8.Classic.fake_wall",
                "fake_wall", assemblyIdentity, "Celeste", 33556327, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.fake_wall", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.fake_wall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+key", "Celeste.Pico8.Classic.key", "key",
                assemblyIdentity, "Celeste", 33556328, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.key", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.key",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+chest", "Celeste.Pico8.Classic.chest", "chest",
                assemblyIdentity, "Celeste", 33556329, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.chest", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.chest",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+platform", "Celeste.Pico8.Classic.platform",
                "platform",
                assemblyIdentity, "Celeste", 33556330, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.platform", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.platform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+message", "Celeste.Pico8.Classic.message",
                "message",
                assemblyIdentity, "Celeste", 33556331, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.message", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.message",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+big_chest", "Celeste.Pico8.Classic.big_chest",
                "big_chest", assemblyIdentity, "Celeste", 33556332, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.big_chest", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.big_chest",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+orb", "Celeste.Pico8.Classic.orb", "orb",
                assemblyIdentity, "Celeste", 33556333, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.orb", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.orb",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+flag", "Celeste.Pico8.Classic.flag", "flag",
                assemblyIdentity, "Celeste", 33556334, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.flag", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.flag",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+room_title", "Celeste.Pico8.Classic.room_title",
                "room_title", assemblyIdentity, "Celeste", 33556335, false,
                ["Celeste.Pico8.Classic+ClassicObject", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.room_title", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.room_title",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+ClassicObject",
                "Celeste.Pico8.Classic.ClassicObject",
                "ClassicObject", assemblyIdentity, "Celeste", 33556336, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.ClassicObject", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.ClassicObject",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Emulator+<>c__DisplayClass34_0",
                "Celeste.Pico8.Emulator.<>c__DisplayClass34_0", "<>c__DisplayClass34_0", assemblyIdentity, "Celeste",
                33556337, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Emulator.<>c__DisplayClass34_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Emulator.<>c__DisplayClass34_0",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=12", "__StaticArrayInitTypeSize=12",
                assemblyIdentity, "Celeste", 33556338, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=12", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=12",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=16", "__StaticArrayInitTypeSize=16",
                assemblyIdentity, "Celeste", 33556339, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=16", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=16",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=20", "__StaticArrayInitTypeSize=20",
                assemblyIdentity, "Celeste", 33556340, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=20", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=20",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=24", "__StaticArrayInitTypeSize=24",
                assemblyIdentity, "Celeste", 33556341, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=24", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=24",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=40", "__StaticArrayInitTypeSize=40",
                assemblyIdentity, "Celeste", 33556342, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=40", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=40",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=44",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=44", "__StaticArrayInitTypeSize=44",
                assemblyIdentity, "Celeste", 33556343, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=44", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=44",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=56",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=56", "__StaticArrayInitTypeSize=56",
                assemblyIdentity, "Celeste", 33556344, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=56", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=56",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=64",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=64", "__StaticArrayInitTypeSize=64",
                assemblyIdentity, "Celeste", 33556345, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=64", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=64",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=128",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=128", "__StaticArrayInitTypeSize=128",
                assemblyIdentity, "Celeste", 33556346, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=128", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=128",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=160",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=160", "__StaticArrayInitTypeSize=160",
                assemblyIdentity, "Celeste", 33556347, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=160", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=160",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>+__StaticArrayInitTypeSize=512",
                "<PrivateImplementationDetails>.__StaticArrayInitTypeSize=512", "__StaticArrayInitTypeSize=512",
                assemblyIdentity, "Celeste", 33556348, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=512", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>.__StaticArrayInitTypeSize=512",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide+<EaseIn>d__5",
                "Celeste.Cassette.UnlockedBSide.<EaseIn>d__5", "<EaseIn>d__5", assemblyIdentity, "Celeste", 33556349,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide.<EaseIn>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide.<EaseIn>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide+<EaseOut>d__6",
                "Celeste.Cassette.UnlockedBSide.<EaseOut>d__6", "<EaseOut>d__6", assemblyIdentity, "Celeste", 33556350,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide.<EaseOut>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide.<EaseOut>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<EaseIn>d__14",
                "Celeste.CS03_Memo.MemoPage.<EaseIn>d__14", "<EaseIn>d__14", assemblyIdentity, "Celeste", 33556351,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<EaseIn>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<EaseIn>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<Wait>d__15",
                "Celeste.CS03_Memo.MemoPage.<Wait>d__15", "<Wait>d__15", assemblyIdentity, "Celeste", 33556352, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<Wait>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<Wait>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<EaseOut>d__16",
                "Celeste.CS03_Memo.MemoPage.<EaseOut>d__16", "<EaseOut>d__16", assemblyIdentity, "Celeste", 33556353,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<EaseOut>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<EaseOut>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+Bird+<IdleRoutine>d__3",
                "Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3", "<IdleRoutine>d__3", assemblyIdentity, "Celeste",
                33556354,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+Bird+<FlyAwayRoutine>d__4",
                "Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4", "<FlyAwayRoutine>d__4", assemblyIdentity, "Celeste",
                33556355, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal+PoemPage+<EaseIn>d__10",
                "Celeste.CS02_Journal.PoemPage.<EaseIn>d__10", "<EaseIn>d__10", assemblyIdentity, "Celeste", 33556356,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal.PoemPage.<EaseIn>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal.PoemPage.<EaseIn>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal+PoemPage+<EaseOut>d__11",
                "Celeste.CS02_Journal.PoemPage.<EaseOut>d__11", "<EaseOut>d__11", assemblyIdentity, "Celeste", 33556357,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal.PoemPage.<EaseOut>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal.PoemPage.<EaseOut>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+Orb+<FloatRoutine>d__9",
                "Celeste.NPC06_Badeline_Crying.Orb.<FloatRoutine>d__9", "<FloatRoutine>d__9", assemblyIdentity,
                "Celeste",
                33556358, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.Orb.<FloatRoutine>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.Orb.<FloatRoutine>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+Orb+<CircleRoutine>d__10",
                "Celeste.NPC06_Badeline_Crying.Orb.<CircleRoutine>d__10", "<CircleRoutine>d__10", assemblyIdentity,
                "Celeste", 33556359, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.Orb.<CircleRoutine>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.Orb.<CircleRoutine>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+Orb+<AbsorbRoutine>d__11",
                "Celeste.NPC06_Badeline_Crying.Orb.<AbsorbRoutine>d__11", "<AbsorbRoutine>d__11", assemblyIdentity,
                "Celeste", 33556360, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.Orb.<AbsorbRoutine>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.Orb.<AbsorbRoutine>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Streaks+Particle",
                "Celeste.AscendManager.Streaks.Particle", "Particle", assemblyIdentity, "Celeste", 33556361, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Streaks.Particle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Streaks.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Clouds+Particle",
                "Celeste.AscendManager.Clouds.Particle", "Particle", assemblyIdentity, "Celeste", 33556362, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Clouds.Particle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Clouds.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint+ConfettiRenderer+Particle",
                "Celeste.SummitCheckpoint.ConfettiRenderer.Particle", "Particle", assemblyIdentity, "Celeste", 33556363,
                false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint.ConfettiRenderer.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint.ConfettiRenderer.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display+<>c", "Celeste.WaveDashPage05.Display.<>c",
                "<>c", assemblyIdentity, "Celeste", 33556364, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display+<Routine>d__7",
                "Celeste.WaveDashPage05.Display.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33556365,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display.<Routine>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display.<Routine>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02+TitleText+<Stamp>d__6",
                "Celeste.WaveDashPage02.TitleText.<Stamp>d__6", "<Stamp>d__6", assemblyIdentity, "Celeste", 33556366,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02.TitleText.<Stamp>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02.TitleText.<Stamp>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer+Bolt+<Run>d__14",
                "Celeste.LightningRenderer.Bolt.<Run>d__14", "<Run>d__14", assemblyIdentity, "Celeste", 33556367, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer.Bolt.<Run>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer.Bolt.<Run>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+MultiCredit+Section",
                "Celeste.Credits.MultiCredit.Section",
                "Section", assemblyIdentity, "Celeste", 33556368, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.MultiCredit.Section", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.MultiCredit.Section",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<AimlessFlightRoutine>d__12",
                "Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12", "<AimlessFlightRoutine>d__12",
                assemblyIdentity, "Celeste", 33556369, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<DashRoutine>d__13",
                "Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13", "<DashRoutine>d__13", assemblyIdentity,
                "Celeste", 33556370, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<TransformRoutine>d__14",
                "Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14", "<TransformRoutine>d__14",
                assemblyIdentity, "Celeste", 33556371, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<EaseIn>d__10",
                "Celeste.LevelEnter.BSideTitle.<EaseIn>d__10", "<EaseIn>d__10", assemblyIdentity, "Celeste", 33556372,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<EaseIn>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<EaseIn>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<EaseOut>d__11",
                "Celeste.LevelEnter.BSideTitle.<EaseOut>d__11", "<EaseOut>d__11", assemblyIdentity, "Celeste", 33556373,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<EaseOut>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<EaseOut>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<FadeTo>d__12",
                "Celeste.LevelEnter.BSideTitle.<FadeTo>d__12", "<FadeTo>d__12", assemblyIdentity, "Celeste", 33556374,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<FadeTo>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<FadeTo>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS00_Ending+EndingCutsceneDelay+<Routine>d__1",
                "Celeste.CS00_Ending.EndingCutsceneDelay.<Routine>d__1", "<Routine>d__1", assemblyIdentity, "Celeste",
                33556375, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS00_Ending.EndingCutsceneDelay.<Routine>d__1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS00_Ending.EndingCutsceneDelay.<Routine>d__1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Backdrop+Fader+Segment", "Celeste.Backdrop.Fader.Segment",
                "Segment",
                assemblyIdentity, "Celeste", 33556376, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Backdrop.Fader.Segment", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop.Fader.Segment",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserStateSound+Actions",
                "Celeste.Player.ChaserStateSound.Actions", "Actions", assemblyIdentity, "Celeste", 33556377, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserStateSound.Actions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserStateSound.Actions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+player_hair+node",
                "Celeste.Pico8.Classic.player_hair.node", "node", assemblyIdentity, "Celeste", 33556378, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.player_hair.node", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.player_hair.node",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic+big_chest+particle",
                "Celeste.Pico8.Classic.big_chest.particle", "particle", assemblyIdentity, "Celeste", 33556379, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic.big_chest.particle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic.big_chest.particle",
                []);
        }
    }
}
