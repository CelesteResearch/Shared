using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Everest.Reflection.Startup
{
    public static partial class InstalledLogicalTypeFacts
    {
        private static void RegisterPart9(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.HangingLamp", "Celeste.HangingLamp", "HangingLamp",
                assemblyIdentity,
                "Celeste", 33556234, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HangingLamp", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HangingLamp",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CameraOffsetTrigger", "Celeste.CameraOffsetTrigger",
                "CameraOffsetTrigger", assemblyIdentity, "Celeste", 33556235, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CameraOffsetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CameraOffsetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CameraTargetTrigger", "Celeste.CameraTargetTrigger",
                "CameraTargetTrigger", assemblyIdentity, "Celeste", 33556236, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CameraTargetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CameraTargetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RespawnTargetTrigger", "Celeste.RespawnTargetTrigger",
                "RespawnTargetTrigger", assemblyIdentity, "Celeste", 33556237, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RespawnTargetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RespawnTargetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustRotateSpinner", "Celeste.DustRotateSpinner",
                "DustRotateSpinner",
                assemblyIdentity, "Celeste", 33556238, false,
                [
                    "Celeste.RotateSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustRotateSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustRotateSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TriggerSpikes", "Celeste.TriggerSpikes", "TriggerSpikes",
                assemblyIdentity, "Celeste", 33556239, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TriggerSpikes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TriggerSpikes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TriggerSpikes+Directions", "Celeste.TriggerSpikes.Directions",
                "Directions", assemblyIdentity, "Celeste", 33556240, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TriggerSpikes.Directions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TriggerSpikes.Directions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TriggerSpikes+SpikeInfo", "Celeste.TriggerSpikes.SpikeInfo",
                "SpikeInfo", assemblyIdentity, "Celeste", 33556241, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TriggerSpikes.SpikeInfo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TriggerSpikes.SpikeInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashBlock", "Celeste.DashBlock", "DashBlock", assemblyIdentity,
                "Celeste", 33556242, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashBlock+Modes", "Celeste.DashBlock.Modes", "Modes",
                assemblyIdentity, "Celeste", 33556243, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashBlock.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashBlock.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.InvisibleBarrier", "Celeste.InvisibleBarrier", "InvisibleBarrier",
                assemblyIdentity, "Celeste", 33556244, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.InvisibleBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.InvisibleBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Key", "Celeste.Key", "Key", assemblyIdentity, "Celeste", 33556245,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Key", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Key",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Key+<NodeRoutine>d__26", "Celeste.Key.<NodeRoutine>d__26",
                "<NodeRoutine>d__26", assemblyIdentity, "Celeste", 33556246, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Key.<NodeRoutine>d__26", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Key.<NodeRoutine>d__26",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Key+<>c__DisplayClass28_0", "Celeste.Key.<>c__DisplayClass28_0",
                "<>c__DisplayClass28_0", assemblyIdentity, "Celeste", 33556247, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Key.<>c__DisplayClass28_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Key.<>c__DisplayClass28_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Key+<UseRoutine>d__28", "Celeste.Key.<UseRoutine>d__28",
                "<UseRoutine>d__28", assemblyIdentity, "Celeste", 33556248, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Key.<UseRoutine>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Key.<UseRoutine>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LockBlock", "Celeste.LockBlock", "LockBlock", assemblyIdentity,
                "Celeste", 33556249, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LockBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LockBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LockBlock+<UnlockRoutine>d__12",
                "Celeste.LockBlock.<UnlockRoutine>d__12", "<UnlockRoutine>d__12", assemblyIdentity, "Celeste", 33556250,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LockBlock.<UnlockRoutine>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LockBlock.<UnlockRoutine>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NegaBlock", "Celeste.NegaBlock", "NegaBlock", assemblyIdentity,
                "Celeste", 33556251, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NegaBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NegaBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberrySeed", "Celeste.StrawberrySeed", "StrawberrySeed",
                assemblyIdentity, "Celeste", 33556252, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberrySeed", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberrySeed",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberrySeed+<ReturnRoutine>d__30",
                "Celeste.StrawberrySeed.<ReturnRoutine>d__30", "<ReturnRoutine>d__30", assemblyIdentity, "Celeste",
                33556253, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberrySeed.<ReturnRoutine>d__30", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberrySeed.<ReturnRoutine>d__30",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberrySeed+<>c__DisplayClass32_0",
                "Celeste.StrawberrySeed.<>c__DisplayClass32_0", "<>c__DisplayClass32_0", assemblyIdentity, "Celeste",
                33556254, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberrySeed.<>c__DisplayClass32_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberrySeed.<>c__DisplayClass32_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberrySeed+<>c__DisplayClass33_0",
                "Celeste.StrawberrySeed.<>c__DisplayClass33_0", "<>c__DisplayClass33_0", assemblyIdentity, "Celeste",
                33556255, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberrySeed.<>c__DisplayClass33_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberrySeed.<>c__DisplayClass33_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberrySeed+<>c", "Celeste.StrawberrySeed.<>c", "<>c",
                assemblyIdentity, "Celeste", 33556256, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberrySeed.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberrySeed.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SinkingPlatform", "Celeste.SinkingPlatform", "SinkingPlatform",
                assemblyIdentity, "Celeste", 33556257, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SinkingPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SinkingPlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SinkingPlatformLine", "Celeste.SinkingPlatformLine",
                "SinkingPlatformLine", assemblyIdentity, "Celeste", 33556258, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SinkingPlatformLine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SinkingPlatformLine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ChaserBarrier", "Celeste.ChaserBarrier", "ChaserBarrier",
                assemblyIdentity, "Celeste", 33556259, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ChaserBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ChaserBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BloomPoint", "Celeste.BloomPoint", "BloomPoint", assemblyIdentity,
                "Celeste", 33556260, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BloomPoint", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BloomPoint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EffectCutout", "Celeste.EffectCutout", "EffectCutout",
                assemblyIdentity, "Celeste", 33556261, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EffectCutout", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.EffectCutout",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Follower", "Celeste.Follower", "Follower", assemblyIdentity,
                "Celeste", 33556262, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Follower", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Follower",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Leader", "Celeste.Leader", "Leader", assemblyIdentity, "Celeste",
                33556263, false, ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Leader", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Leader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightOcclude", "Celeste.LightOcclude", "LightOcclude",
                assemblyIdentity, "Celeste", 33556264, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightOcclude", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightOcclude",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StaticMover", "Celeste.StaticMover", "StaticMover",
                assemblyIdentity,
                "Celeste", 33556265, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StaticMover", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StaticMover",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Switch", "Celeste.Switch", "Switch", assemblyIdentity, "Celeste",
                33556266, false, ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Switch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Switch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumblePlatform", "Celeste.CrumblePlatform", "CrumblePlatform",
                assemblyIdentity, "Celeste", 33556267, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumblePlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumblePlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumblePlatform+<Sequence>d__11",
                "Celeste.CrumblePlatform.<Sequence>d__11", "<Sequence>d__11", assemblyIdentity, "Celeste", 33556268,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumblePlatform.<Sequence>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumblePlatform.<Sequence>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumblePlatform+<OutlineFade>d__12",
                "Celeste.CrumblePlatform.<OutlineFade>d__12", "<OutlineFade>d__12", assemblyIdentity, "Celeste",
                33556269,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumblePlatform.<OutlineFade>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumblePlatform.<OutlineFade>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumblePlatform+<TileOut>d__13",
                "Celeste.CrumblePlatform.<TileOut>d__13", "<TileOut>d__13", assemblyIdentity, "Celeste", 33556270,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumblePlatform.<TileOut>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumblePlatform.<TileOut>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumblePlatform+<TileIn>d__14",
                "Celeste.CrumblePlatform.<TileIn>d__14", "<TileIn>d__14", assemblyIdentity, "Celeste", 33556271, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumblePlatform.<TileIn>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumblePlatform.<TileIn>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock", "Celeste.DreamBlock", "DreamBlock", assemblyIdentity,
                "Celeste", 33556272, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock+DreamParticle", "Celeste.DreamBlock.DreamParticle",
                "DreamParticle", assemblyIdentity, "Celeste", 33556273, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock.DreamParticle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock.DreamParticle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock+<>c__DisplayClass22_0",
                "Celeste.DreamBlock.<>c__DisplayClass22_0", "<>c__DisplayClass22_0", assemblyIdentity, "Celeste",
                33556274,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock.<>c__DisplayClass22_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock.<>c__DisplayClass22_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock+<Activate>d__34", "Celeste.DreamBlock.<Activate>d__34",
                "<Activate>d__34", assemblyIdentity, "Celeste", 33556275, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock.<Activate>d__34", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock.<Activate>d__34",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock+<Deactivate>d__15",
                "Celeste.DreamBlock.<Deactivate>d__15",
                "<Deactivate>d__15", assemblyIdentity, "Celeste", 33556276, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock.<Deactivate>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock.<Deactivate>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock+<FastActivate>d__17",
                "Celeste.DreamBlock.<FastActivate>d__17", "<FastActivate>d__17", assemblyIdentity, "Celeste", 33556277,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock.<FastActivate>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock.<FastActivate>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock+<FastDeactivate>d__16",
                "Celeste.DreamBlock.<FastDeactivate>d__16", "<FastDeactivate>d__16", assemblyIdentity, "Celeste",
                33556278,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock.<FastDeactivate>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock.<FastDeactivate>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FakeWall", "Celeste.FakeWall", "FakeWall", assemblyIdentity,
                "Celeste", 33556279, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FakeWall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FakeWall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FakeWall+Modes", "Celeste.FakeWall.Modes", "Modes",
                assemblyIdentity,
                "Celeste", 33556280, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FakeWall.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FakeWall.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallingBlock", "Celeste.FallingBlock", "FallingBlock",
                assemblyIdentity, "Celeste", 33556281, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallingBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallingBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallingBlock+<Sequence>d__21",
                "Celeste.FallingBlock.<Sequence>d__21",
                "<Sequence>d__21", assemblyIdentity, "Celeste", 33556282, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallingBlock.<Sequence>d__21", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallingBlock.<Sequence>d__21",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallingBlock+<HighlightFade>d__22",
                "Celeste.FallingBlock.<HighlightFade>d__22", "<HighlightFade>d__22", assemblyIdentity, "Celeste",
                33556283,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallingBlock.<HighlightFade>d__22", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallingBlock.<HighlightFade>d__22",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC", "Celeste.BirdNPC", "BirdNPC", assemblyIdentity,
                "Celeste",
                33556284, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+Modes", "Celeste.BirdNPC.Modes", "Modes",
                assemblyIdentity,
                "Celeste", 33556285, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<Caw>d__27", "Celeste.BirdNPC.<Caw>d__27", "<Caw>d__27",
                assemblyIdentity, "Celeste", 33556286, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<Caw>d__27", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<Caw>d__27",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<ShowTutorial>d__28",
                "Celeste.BirdNPC.<ShowTutorial>d__28",
                "<ShowTutorial>d__28", assemblyIdentity, "Celeste", 33556287, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<ShowTutorial>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<ShowTutorial>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<HideTutorial>d__29",
                "Celeste.BirdNPC.<HideTutorial>d__29",
                "<HideTutorial>d__29", assemblyIdentity, "Celeste", 33556288, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<HideTutorial>d__29", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<HideTutorial>d__29",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<StartleAndFlyAway>d__30",
                "Celeste.BirdNPC.<StartleAndFlyAway>d__30", "<StartleAndFlyAway>d__30", assemblyIdentity, "Celeste",
                33556289, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<StartleAndFlyAway>d__30", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<StartleAndFlyAway>d__30",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<FlyAway>d__31", "Celeste.BirdNPC.<FlyAway>d__31",
                "<FlyAway>d__31", assemblyIdentity, "Celeste", 33556290, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<FlyAway>d__31", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<FlyAway>d__31",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<ClimbingTutorial>d__32",
                "Celeste.BirdNPC.<ClimbingTutorial>d__32", "<ClimbingTutorial>d__32", assemblyIdentity, "Celeste",
                33556291,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<ClimbingTutorial>d__32", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<ClimbingTutorial>d__32",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<DashingTutorial>d__33",
                "Celeste.BirdNPC.<DashingTutorial>d__33", "<DashingTutorial>d__33", assemblyIdentity, "Celeste",
                33556292,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<DashingTutorial>d__33", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<DashingTutorial>d__33",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<DreamJumpTutorial>d__34",
                "Celeste.BirdNPC.<DreamJumpTutorial>d__34", "<DreamJumpTutorial>d__34", assemblyIdentity, "Celeste",
                33556293, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<DreamJumpTutorial>d__34", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<DreamJumpTutorial>d__34",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<SuperWallJumpTutorial>d__35",
                "Celeste.BirdNPC.<SuperWallJumpTutorial>d__35", "<SuperWallJumpTutorial>d__35", assemblyIdentity,
                "Celeste",
                33556294, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<SuperWallJumpTutorial>d__35", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<SuperWallJumpTutorial>d__35",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<HyperJumpTutorial>d__36",
                "Celeste.BirdNPC.<HyperJumpTutorial>d__36", "<HyperJumpTutorial>d__36", assemblyIdentity, "Celeste",
                33556295, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<HyperJumpTutorial>d__36", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<HyperJumpTutorial>d__36",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<WaitRoutine>d__37", "Celeste.BirdNPC.<WaitRoutine>d__37",
                "<WaitRoutine>d__37", assemblyIdentity, "Celeste", 33556296, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<WaitRoutine>d__37", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<WaitRoutine>d__37",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<>c__DisplayClass38_0",
                "Celeste.BirdNPC.<>c__DisplayClass38_0", "<>c__DisplayClass38_0", assemblyIdentity, "Celeste", 33556297,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<>c__DisplayClass38_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<>c__DisplayClass38_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<Startle>d__38", "Celeste.BirdNPC.<Startle>d__38",
                "<Startle>d__38", assemblyIdentity, "Celeste", 33556298, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<Startle>d__38", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<Startle>d__38",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<FlyTo>d__39", "Celeste.BirdNPC.<FlyTo>d__39",
                "<FlyTo>d__39",
                assemblyIdentity, "Celeste", 33556299, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<FlyTo>d__39", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<FlyTo>d__39",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<MoveToNodesRoutine>d__40",
                "Celeste.BirdNPC.<MoveToNodesRoutine>d__40", "<MoveToNodesRoutine>d__40", assemblyIdentity, "Celeste",
                33556300, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<MoveToNodesRoutine>d__40", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<MoveToNodesRoutine>d__40",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC+<WaitForLightningOffRoutine>d__41",
                "Celeste.BirdNPC.<WaitForLightningOffRoutine>d__41", "<WaitForLightningOffRoutine>d__41",
                assemblyIdentity,
                "Celeste", 33556301, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC.<WaitForLightningOffRoutine>d__41", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC.<WaitForLightningOffRoutine>d__41",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCar", "Celeste.IntroCar", "IntroCar", assemblyIdentity,
                "Celeste", 33556302, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCar", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCar",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCarBarrier", "Celeste.IntroCarBarrier", "IntroCarBarrier",
                assemblyIdentity, "Celeste", 33556303, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCarBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCarBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCrusher", "Celeste.IntroCrusher", "IntroCrusher",
                assemblyIdentity, "Celeste", 33556304, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCrusher", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCrusher",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCrusher+<Sequence>d__9",
                "Celeste.IntroCrusher.<Sequence>d__9",
                "<Sequence>d__9", assemblyIdentity, "Celeste", 33556305, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCrusher.<Sequence>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCrusher.<Sequence>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCrusher+<>c__DisplayClass6_0",
                "Celeste.IntroCrusher.<>c__DisplayClass6_0", "<>c__DisplayClass6_0", assemblyIdentity, "Celeste",
                33556306,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCrusher.<>c__DisplayClass6_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCrusher.<>c__DisplayClass6_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroPavement", "Celeste.IntroPavement", "IntroPavement",
                assemblyIdentity, "Celeste", 33556307, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroPavement", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroPavement",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Lamp", "Celeste.Lamp", "Lamp", assemblyIdentity, "Celeste",
                33556308,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Lamp", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Lamp",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Memorial", "Celeste.Memorial", "Memorial", assemblyIdentity,
                "Celeste", 33556309, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Memorial", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Memorial",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MemorialText", "Celeste.MemorialText", "MemorialText",
                assemblyIdentity, "Celeste", 33556310, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MemorialText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MemorialText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Wire", "Celeste.Wire", "Wire", assemblyIdentity, "Celeste",
                33556311,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Wire", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Wire",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SwitchGate", "Celeste.SwitchGate", "SwitchGate", assemblyIdentity,
                "Celeste", 33556312, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SwitchGate", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SwitchGate",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SwitchGate+<>c__DisplayClass16_0",
                "Celeste.SwitchGate.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity, "Celeste",
                33556313,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SwitchGate.<>c__DisplayClass16_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SwitchGate.<>c__DisplayClass16_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SwitchGate+<>c__DisplayClass16_1",
                "Celeste.SwitchGate.<>c__DisplayClass16_1", "<>c__DisplayClass16_1", assemblyIdentity, "Celeste",
                33556314,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SwitchGate.<>c__DisplayClass16_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SwitchGate.<>c__DisplayClass16_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SwitchGate+<Sequence>d__16", "Celeste.SwitchGate.<Sequence>d__16",
                "<Sequence>d__16", assemblyIdentity, "Celeste", 33556315, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SwitchGate.<Sequence>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SwitchGate.<Sequence>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TouchSwitch", "Celeste.TouchSwitch", "TouchSwitch",
                assemblyIdentity,
                "Celeste", 33556316, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TouchSwitch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TouchSwitch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EventTrigger", "Celeste.EventTrigger", "EventTrigger",
                assemblyIdentity, "Celeste", 33556317, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EventTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.EventTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EventTrigger+<>c__DisplayClass10_0",
                "Celeste.EventTrigger.<>c__DisplayClass10_0", "<>c__DisplayClass10_0", assemblyIdentity, "Celeste",
                33556318, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EventTrigger.<>c__DisplayClass10_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.EventTrigger.<>c__DisplayClass10_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EventTrigger+<Brighten>d__13",
                "Celeste.EventTrigger.<Brighten>d__13",
                "<Brighten>d__13", assemblyIdentity, "Celeste", 33556319, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EventTrigger.<Brighten>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.EventTrigger.<Brighten>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EventTrigger+<Ch9HubTransitionBackgroundToBright>d__14",
                "Celeste.EventTrigger.<Ch9HubTransitionBackgroundToBright>d__14",
                "<Ch9HubTransitionBackgroundToBright>d__14", assemblyIdentity, "Celeste", 33556320, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EventTrigger.<Ch9HubTransitionBackgroundToBright>d__14", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.EventTrigger.<Ch9HubTransitionBackgroundToBright>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EventTrigger+CutsceneLoader",
                "Celeste.EventTrigger.CutsceneLoader",
                "CutsceneLoader", assemblyIdentity, "Celeste", 33556321, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EventTrigger.CutsceneLoader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.EventTrigger.CutsceneLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MusicFadeTrigger", "Celeste.MusicFadeTrigger", "MusicFadeTrigger",
                assemblyIdentity, "Celeste", 33556322, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MusicFadeTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MusicFadeTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Trigger", "Celeste.Trigger", "Trigger", assemblyIdentity,
                "Celeste",
                33556323, true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Trigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Trigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Trigger+PositionModes", "Celeste.Trigger.PositionModes",
                "PositionModes", assemblyIdentity, "Celeste", 33556324, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Trigger.PositionModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Trigger.PositionModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerCollider", "Celeste.PlayerCollider", "PlayerCollider",
                assemblyIdentity, "Celeste", 33556325, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Refill", "Celeste.Refill", "Refill", assemblyIdentity, "Celeste",
                33556326, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Refill", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Refill",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Refill+<RefillRoutine>d__28",
                "Celeste.Refill.<RefillRoutine>d__28",
                "<RefillRoutine>d__28", assemblyIdentity, "Celeste", 33556327, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Refill.<RefillRoutine>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Refill.<RefillRoutine>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Bridge", "Celeste.Bridge", "Bridge", assemblyIdentity, "Celeste",
                33556328, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Bridge", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Bridge",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BridgeTile", "Celeste.BridgeTile", "BridgeTile", assemblyIdentity,
                "Celeste", 33556329, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BridgeTile", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BridgeTile",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spikes", "Celeste.Spikes", "Spikes", assemblyIdentity, "Celeste",
                33556330, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spikes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spikes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spikes+Directions", "Celeste.Spikes.Directions", "Directions",
                assemblyIdentity, "Celeste", 33556331, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spikes.Directions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spikes.Directions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spring", "Celeste.Spring", "Spring", assemblyIdentity, "Celeste",
                33556332, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spring", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spring",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spring+Orientations", "Celeste.Spring.Orientations",
                "Orientations",
                assemblyIdentity, "Celeste", 33556333, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spring.Orientations", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spring.Orientations",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry", "Celeste.Strawberry", "Strawberry", assemblyIdentity,
                "Celeste", 33556334, false,
                [
                    "Monocle.Entity", "Celeste.Mod.IStrawberry", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<>c__DisplayClass44_0",
                "Celeste.Strawberry.<>c__DisplayClass44_0", "<>c__DisplayClass44_0", assemblyIdentity, "Celeste",
                33556335,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<>c__DisplayClass44_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<>c__DisplayClass44_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry+<FlyAwayRoutine>d__46",
                "Celeste.Strawberry.<FlyAwayRoutine>d__46", "<FlyAwayRoutine>d__46", assemblyIdentity, "Celeste",
                33556336,
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
                33556337,
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
                33556338,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry.<>c__DisplayClass48_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry.<>c__DisplayClass48_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.JumpthruPlatform", "Celeste.JumpthruPlatform", "JumpthruPlatform",
                assemblyIdentity, "Celeste", 33556339, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.JumpthruPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.JumpthruPlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover", "Celeste.ZipMover", "ZipMover", assemblyIdentity,
                "Celeste", 33556340, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+Themes", "Celeste.ZipMover.Themes", "Themes",
                assemblyIdentity, "Celeste", 33556341, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.Themes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.Themes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+ZipMoverPathRenderer",
                "Celeste.ZipMover.ZipMoverPathRenderer", "ZipMoverPathRenderer", assemblyIdentity, "Celeste", 33556342,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.ZipMoverPathRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.ZipMoverPathRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover+<Sequence>d__24", "Celeste.ZipMover.<Sequence>d__24",
                "<Sequence>d__24", assemblyIdentity, "Celeste", 33556343, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover.<Sequence>d__24", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover.<Sequence>d__24",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Backdrop", "Celeste.Backdrop", "Backdrop", assemblyIdentity,
                "Celeste", 33556344, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Backdrop", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Backdrop+Fader", "Celeste.Backdrop.Fader", "Fader",
                assemblyIdentity,
                "Celeste", 33556345, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Backdrop.Fader", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop.Fader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Backdrop+Fader+Segment", "Celeste.Backdrop.Fader.Segment",
                "Segment",
                assemblyIdentity, "Celeste", 33556346, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Backdrop.Fader.Segment", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop.Fader.Segment",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackgroundTiles", "Celeste.BackgroundTiles", "BackgroundTiles",
                assemblyIdentity, "Celeste", 33556347, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackgroundTiles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackgroundTiles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystal", "Celeste.TheoCrystal", "TheoCrystal",
                assemblyIdentity,
                "Celeste", 33556348, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystal+<Shatter>d__22", "Celeste.TheoCrystal.<Shatter>d__22",
                "<Shatter>d__22", assemblyIdentity, "Celeste", 33556349, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystal.<Shatter>d__22", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystal.<Shatter>d__22",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GFX", "Celeste.GFX", "GFX", assemblyIdentity, "Celeste", 33556350,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GFX", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GFX",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Input", "Celeste.Input", "Input", assemblyIdentity, "Celeste",
                33556351, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Input", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Input",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Input+PrefixMode", "Celeste.Input.PrefixMode", "PrefixMode",
                assemblyIdentity, "Celeste", 33556352, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Input.PrefixMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Input.PrefixMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleStrength", "Celeste.RumbleStrength", "RumbleStrength",
                assemblyIdentity, "Celeste", 33556353, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleStrength", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleStrength",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleLength", "Celeste.RumbleLength", "RumbleLength",
                assemblyIdentity, "Celeste", 33556354, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleLength", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleLength",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Distort", "Celeste.Distort", "Distort", assemblyIdentity,
                "Celeste",
                33556355, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Distort", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Distort",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur", "Celeste.GaussianBlur", "GaussianBlur",
                assemblyIdentity, "Celeste", 33556356, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur+Samples", "Celeste.GaussianBlur.Samples", "Samples",
                assemblyIdentity, "Celeste", 33556357, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur.Samples", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur.Samples",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur+Direction", "Celeste.GaussianBlur.Direction",
                "Direction", assemblyIdentity, "Celeste", 33556358, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur.Direction", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur.Direction",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Hahaha", "Celeste.Hahaha", "Hahaha", assemblyIdentity, "Celeste",
                33556359, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Hahaha", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Hahaha",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Hahaha+Ha", "Celeste.Hahaha.Ha", "Ha", assemblyIdentity,
                "Celeste",
                33556360, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Hahaha.Ha", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Hahaha.Ha",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerHair", "Celeste.PlayerHair", "PlayerHair", assemblyIdentity,
                "Celeste", 33556361, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerHair", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerHair",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSpriteMode", "Celeste.PlayerSpriteMode", "PlayerSpriteMode",
                assemblyIdentity, "Celeste", 33556362, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSpriteMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSpriteMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSprite", "Celeste.PlayerSprite", "PlayerSprite",
                assemblyIdentity, "Celeste", 33556363, false,
                [
                    "Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component",
                    "System.Object",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSprite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSprite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerAnimMetadata", "Celeste.PlayerAnimMetadata",
                "PlayerAnimMetadata", assemblyIdentity, "Celeste", 33556364, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerAnimMetadata", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerAnimMetadata",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BloomRenderer", "Celeste.BloomRenderer", "BloomRenderer",
                assemblyIdentity, "Celeste", 33556365, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BloomRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BloomRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisplacementRenderer", "Celeste.DisplacementRenderer",
                "DisplacementRenderer", assemblyIdentity, "Celeste", 33556366, false,
                ["Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisplacementRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisplacementRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisplacementRenderer+Burst", "Celeste.DisplacementRenderer.Burst",
                "Burst", assemblyIdentity, "Celeste", 33556367, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisplacementRenderer.Burst", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisplacementRenderer.Burst",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackdropRenderer", "Celeste.BackdropRenderer", "BackdropRenderer",
                assemblyIdentity, "Celeste", 33556368, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackdropRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackdropRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackdropRenderer+<GetEach>d__9`1",
                "Celeste.BackdropRenderer.<GetEach>d__9`1", "<GetEach>d__9`1", assemblyIdentity, "Celeste", 33556369,
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
                "Celeste.BackdropRenderer.<GetEach>d__10`1", "<GetEach>d__10`1", assemblyIdentity, "Celeste", 33556370,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                    "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackdropRenderer.<GetEach>d__10`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackdropRenderer.<GetEach>d__10`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ScreenWipe", "Celeste.ScreenWipe", "ScreenWipe", assemblyIdentity,
                "Celeste", 33556371, true, ["Monocle.Renderer", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ScreenWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ScreenWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ScreenWipe+<Wait>d__16", "Celeste.ScreenWipe.<Wait>d__16",
                "<Wait>d__16", assemblyIdentity, "Celeste", 33556372, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ScreenWipe.<Wait>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ScreenWipe.<Wait>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snow", "Celeste.Snow", "Snow", assemblyIdentity, "Celeste",
                33556373,
                false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snow", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snow",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snow+Particle", "Celeste.Snow.Particle", "Particle",
                assemblyIdentity,
                "Celeste", 33556374, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snow.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snow.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Parallax", "Celeste.Parallax", "Parallax", assemblyIdentity,
                "Celeste", 33556375, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Parallax", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Parallax",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ChimneySmokeFx", "Celeste.ChimneySmokeFx", "ChimneySmokeFx",
                assemblyIdentity, "Celeste", 33556376, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ChimneySmokeFx", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ChimneySmokeFx",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Dust", "Celeste.Dust", "Dust", assemblyIdentity, "Celeste",
                33556377,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Dust", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Dust",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MapData", "Celeste.MapData", "MapData", assemblyIdentity,
                "Celeste",
                33556378, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MapData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MapData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MapData+BackdropLoader", "Celeste.MapData.BackdropLoader",
                "BackdropLoader", assemblyIdentity, "Celeste", 33556379, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MapData.BackdropLoader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MapData.BackdropLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MapData+<>c", "Celeste.MapData.<>c", "<>c", assemblyIdentity,
                "Celeste", 33556380, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MapData.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MapData.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MapData+<>c__DisplayClass12_0",
                "Celeste.MapData.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste", 33556381,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MapData.<>c__DisplayClass12_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MapData.<>c__DisplayClass12_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EntityData", "Celeste.EntityData", "EntityData", assemblyIdentity,
                "Celeste", 33556382, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EntityData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.EntityData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DecalData", "Celeste.DecalData", "DecalData", assemblyIdentity,
                "Celeste", 33556383, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DecalData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DecalData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelData", "Celeste.LevelData", "LevelData", assemblyIdentity,
                "Celeste", 33556384, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight", "Celeste.VertexLight", "VertexLight",
                assemblyIdentity,
                "Celeste", 33556385, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass39_0",
                "Celeste.VertexLight.<>c__DisplayClass39_0", "<>c__DisplayClass39_0", assemblyIdentity, "Celeste",
                33556386,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass39_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass39_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass40_0",
                "Celeste.VertexLight.<>c__DisplayClass40_0", "<>c__DisplayClass40_0", assemblyIdentity, "Celeste",
                33556387,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass40_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass40_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight+<>c__DisplayClass41_0",
                "Celeste.VertexLight.<>c__DisplayClass41_0", "<>c__DisplayClass41_0", assemblyIdentity, "Celeste",
                33556388,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight.<>c__DisplayClass41_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight.<>c__DisplayClass41_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level", "Celeste.Level", "Level", assemblyIdentity, "Celeste",
                33556389, false,
                [
                    "Monocle.Scene", "Celeste.IOverlayHandler", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+CameraLockModes", "Celeste.Level.CameraLockModes",
                "CameraLockModes", assemblyIdentity, "Celeste", 33556390, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.CameraLockModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.CameraLockModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+ConditionBlockModes", "Celeste.Level.ConditionBlockModes",
                "ConditionBlockModes", assemblyIdentity, "Celeste", 33556391, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.ConditionBlockModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.ConditionBlockModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass126_0",
                "Celeste.Level.<>c__DisplayClass126_0",
                "<>c__DisplayClass126_0", assemblyIdentity, "Celeste", 33556392, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass126_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass126_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<TransitionRoutine>d__126",
                "Celeste.Level.<TransitionRoutine>d__126", "<TransitionRoutine>d__126", assemblyIdentity, "Celeste",
                33556393, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<TransitionRoutine>d__126", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<TransitionRoutine>d__126",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<SavingRoutine>d__141",
                "Celeste.Level.<SavingRoutine>d__141",
                "<SavingRoutine>d__141", assemblyIdentity, "Celeste", 33556394, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<SavingRoutine>d__141", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SavingRoutine>d__141",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_0",
                "Celeste.Level.<>c__DisplayClass149_0",
                "<>c__DisplayClass149_0", assemblyIdentity, "Celeste", 33556395, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_1",
                "Celeste.Level.<>c__DisplayClass149_1",
                "<>c__DisplayClass149_1", assemblyIdentity, "Celeste", 33556396, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_2",
                "Celeste.Level.<>c__DisplayClass149_2",
                "<>c__DisplayClass149_2", assemblyIdentity, "Celeste", 33556397, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_2", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_3",
                "Celeste.Level.<>c__DisplayClass149_3",
                "<>c__DisplayClass149_3", assemblyIdentity, "Celeste", 33556398, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_3", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_3",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_4",
                "Celeste.Level.<>c__DisplayClass149_4",
                "<>c__DisplayClass149_4", assemblyIdentity, "Celeste", 33556399, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_4", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass149_5",
                "Celeste.Level.<>c__DisplayClass149_5",
                "<>c__DisplayClass149_5", assemblyIdentity, "Celeste", 33556400, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass149_5", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass149_5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c", "Celeste.Level.<>c", "<>c", assemblyIdentity,
                "Celeste",
                33556401, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass150_0",
                "Celeste.Level.<>c__DisplayClass150_0",
                "<>c__DisplayClass150_0", assemblyIdentity, "Celeste", 33556402, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass150_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass150_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass151_0",
                "Celeste.Level.<>c__DisplayClass151_0",
                "<>c__DisplayClass151_0", assemblyIdentity, "Celeste", 33556403, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass151_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass151_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<SaveFromOptions>d__152",
                "Celeste.Level.<SaveFromOptions>d__152", "<SaveFromOptions>d__152", assemblyIdentity, "Celeste",
                33556404,
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
                "<>c__DisplayClass153_0", assemblyIdentity, "Celeste", 33556405, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass153_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass153_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass154_0",
                "Celeste.Level.<>c__DisplayClass154_0",
                "<>c__DisplayClass154_0", assemblyIdentity, "Celeste", 33556406, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass154_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass154_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomTo>d__162", "Celeste.Level.<ZoomTo>d__162",
                "<ZoomTo>d__162", assemblyIdentity, "Celeste", 33556407, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomTo>d__162", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomTo>d__162",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomAcross>d__163", "Celeste.Level.<ZoomAcross>d__163",
                "<ZoomAcross>d__163", assemblyIdentity, "Celeste", 33556408, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomAcross>d__163", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomAcross>d__163",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<ZoomBack>d__164", "Celeste.Level.<ZoomBack>d__164",
                "<ZoomBack>d__164", assemblyIdentity, "Celeste", 33556409, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<ZoomBack>d__164", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<ZoomBack>d__164",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<SkipCutsceneRoutine>d__181",
                "Celeste.Level.<SkipCutsceneRoutine>d__181", "<SkipCutsceneRoutine>d__181", assemblyIdentity, "Celeste",
                33556410, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<SkipCutsceneRoutine>d__181", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<SkipCutsceneRoutine>d__181",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<>c__DisplayClass183_0",
                "Celeste.Level.<>c__DisplayClass183_0",
                "<>c__DisplayClass183_0", assemblyIdentity, "Celeste", 33556411, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<>c__DisplayClass183_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<>c__DisplayClass183_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+LoadOverride", "Celeste.Level.LoadOverride", "LoadOverride",
                assemblyIdentity, "Celeste", 33556412, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.LoadOverride", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.LoadOverride",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+EntityLoader", "Celeste.Level.EntityLoader", "EntityLoader",
                assemblyIdentity, "Celeste", 33556413, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.EntityLoader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.EntityLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level+<TransitionRoutine>d__37",
                "Celeste.Level.<TransitionRoutine>d__37", "<TransitionRoutine>d__37", assemblyIdentity, "Celeste",
                33556414,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level.<TransitionRoutine>d__37", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level.<TransitionRoutine>d__37",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Facings", "Celeste.Facings", "Facings", assemblyIdentity,
                "Celeste",
                33556415, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Facings", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Facings",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Collision", "Celeste.Collision", "Collision", assemblyIdentity,
                "Celeste", 33556416, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Collision", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Collision",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CollisionData", "Celeste.CollisionData", "CollisionData",
                assemblyIdentity, "Celeste", 33556417, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CollisionData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CollisionData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Actor",
                typeof(SourceActorEntityState).FullName, "Actor",
                assemblyIdentity, "Celeste",
                33556418, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts(
                typeof(SourceActorEntityState).FullName, 0, false);
            catalog.PublishDeclaredTrackedAliases(
                typeof(SourceActorEntityState).FullName,
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Holdable", "Celeste.Holdable", "Holdable", assemblyIdentity,
                "Celeste", 33556419, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Holdable", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Holdable",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.JumpThru", "Celeste.JumpThru", "JumpThru", assemblyIdentity,
                "Celeste", 33556420, false,
                [
                    "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.JumpThru", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.JumpThru",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashCollisionResults", "Celeste.DashCollisionResults",
                "DashCollisionResults", assemblyIdentity, "Celeste", 33556421, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashCollisionResults", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashCollisionResults",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashCollision", "Celeste.DashCollision", "DashCollision",
                assemblyIdentity, "Celeste", 33556422, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashCollision", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashCollision",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Platform", "Celeste.Platform", "Platform", assemblyIdentity,
                "Celeste", 33556423, true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Platform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Platform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Solid", "Celeste.Solid", "Solid", assemblyIdentity, "Celeste",
                33556424, false,
                [
                    "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Solid", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Solid",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player",
                typeof(RoomPlayerSession).FullName, "Player", assemblyIdentity, "Celeste",
                33556425, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts(typeof(RoomPlayerSession).FullName, 0, false);
            catalog.PublishDeclaredTrackedAliases(typeof(RoomPlayerSession).FullName,
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+IntroTypes", "Celeste.Player.IntroTypes", "IntroTypes",
                assemblyIdentity, "Celeste", 33556426, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.IntroTypes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.IntroTypes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserStateSound", "Celeste.Player.ChaserStateSound",
                "ChaserStateSound", assemblyIdentity, "Celeste", 33556427, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserStateSound", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserStateSound",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserStateSound+Actions",
                "Celeste.Player.ChaserStateSound.Actions", "Actions", assemblyIdentity, "Celeste", 33556428, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserStateSound.Actions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserStateSound.Actions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+ChaserState", "Celeste.Player.ChaserState", "ChaserState",
                assemblyIdentity, "Celeste", 33556429, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.ChaserState", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.ChaserState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass344_0",
                "Celeste.Player.<>c__DisplayClass344_0", "<>c__DisplayClass344_0", assemblyIdentity, "Celeste",
                33556430,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass344_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass344_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<>c__DisplayClass344_1",
                "Celeste.Player.<>c__DisplayClass344_1", "<>c__DisplayClass344_1", assemblyIdentity, "Celeste",
                33556431,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<>c__DisplayClass344_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<>c__DisplayClass344_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<DashCoroutine>d__427",
                "Celeste.Player.<DashCoroutine>d__427",
                "<DashCoroutine>d__427", assemblyIdentity, "Celeste", 33556432, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<DashCoroutine>d__427", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<DashCoroutine>d__427",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player+<BoostCoroutine>d__450",
                "Celeste.Player.<BoostCoroutine>d__450", "<BoostCoroutine>d__450", assemblyIdentity, "Celeste",
                33556433,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Player.<BoostCoroutine>d__450", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Player.<BoostCoroutine>d__450",
                []);
        }
    }
}
