using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Reflection.Startup
{
    public static partial class OriginalLogicalTypeFacts
    {
        private static void RegisterPart4(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.StaminaDisplay", "Celeste.StaminaDisplay", "StaminaDisplay",
                assemblyIdentity, "Celeste", 33555234, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StaminaDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StaminaDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ExitBlock", "Celeste.ExitBlock", "ExitBlock", assemblyIdentity,
                "Celeste", 33555235, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ExitBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ExitBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MovingPlatform", "Celeste.MovingPlatform", "MovingPlatform",
                assemblyIdentity, "Celeste", 33555236, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MovingPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MovingPlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MovingPlatformLine", "Celeste.MovingPlatformLine",
                "MovingPlatformLine", assemblyIdentity, "Celeste", 33555237, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MovingPlatformLine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MovingPlatformLine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RotatingPlatform", "Celeste.RotatingPlatform", "RotatingPlatform",
                assemblyIdentity, "Celeste", 33555238, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RotatingPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RotatingPlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HangingLamp", "Celeste.HangingLamp", "HangingLamp",
                assemblyIdentity,
                "Celeste", 33555239, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HangingLamp", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HangingLamp",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CameraOffsetTrigger", "Celeste.CameraOffsetTrigger",
                "CameraOffsetTrigger", assemblyIdentity, "Celeste", 33555240, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CameraOffsetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CameraOffsetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CameraTargetTrigger", "Celeste.CameraTargetTrigger",
                "CameraTargetTrigger", assemblyIdentity, "Celeste", 33555241, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CameraTargetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CameraTargetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RespawnTargetTrigger", "Celeste.RespawnTargetTrigger",
                "RespawnTargetTrigger", assemblyIdentity, "Celeste", 33555242, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RespawnTargetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RespawnTargetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustRotateSpinner", "Celeste.DustRotateSpinner",
                "DustRotateSpinner",
                assemblyIdentity, "Celeste", 33555243, false,
                [
                    "Celeste.RotateSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustRotateSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustRotateSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TriggerSpikes", "Celeste.TriggerSpikes", "TriggerSpikes",
                assemblyIdentity, "Celeste", 33555244, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TriggerSpikes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TriggerSpikes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashBlock", "Celeste.DashBlock", "DashBlock", assemblyIdentity,
                "Celeste", 33555245, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.InvisibleBarrier", "Celeste.InvisibleBarrier", "InvisibleBarrier",
                assemblyIdentity, "Celeste", 33555246, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.InvisibleBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.InvisibleBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Key", "Celeste.Key", "Key", assemblyIdentity, "Celeste", 33555247,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Key", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Key",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LockBlock", "Celeste.LockBlock", "LockBlock", assemblyIdentity,
                "Celeste", 33555248, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LockBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LockBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NegaBlock", "Celeste.NegaBlock", "NegaBlock", assemblyIdentity,
                "Celeste", 33555249, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NegaBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NegaBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberrySeed", "Celeste.StrawberrySeed", "StrawberrySeed",
                assemblyIdentity, "Celeste", 33555250, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberrySeed", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberrySeed",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SinkingPlatform", "Celeste.SinkingPlatform", "SinkingPlatform",
                assemblyIdentity, "Celeste", 33555251, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SinkingPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SinkingPlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SinkingPlatformLine", "Celeste.SinkingPlatformLine",
                "SinkingPlatformLine", assemblyIdentity, "Celeste", 33555252, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SinkingPlatformLine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SinkingPlatformLine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ChaserBarrier", "Celeste.ChaserBarrier", "ChaserBarrier",
                assemblyIdentity, "Celeste", 33555253, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ChaserBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ChaserBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BloomPoint", "Celeste.BloomPoint", "BloomPoint", assemblyIdentity,
                "Celeste", 33555254, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BloomPoint", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BloomPoint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EffectCutout", "Celeste.EffectCutout", "EffectCutout",
                assemblyIdentity, "Celeste", 33555255, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EffectCutout", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.EffectCutout",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Follower", "Celeste.Follower", "Follower", assemblyIdentity,
                "Celeste", 33555256, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Follower", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Follower",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Leader", "Celeste.Leader", "Leader", assemblyIdentity, "Celeste",
                33555257, false, ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Leader", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Leader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightOcclude", "Celeste.LightOcclude", "LightOcclude",
                assemblyIdentity, "Celeste", 33555258, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightOcclude", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightOcclude",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StaticMover", "Celeste.StaticMover", "StaticMover",
                assemblyIdentity,
                "Celeste", 33555259, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StaticMover", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StaticMover",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Switch", "Celeste.Switch", "Switch", assemblyIdentity, "Celeste",
                33555260, false, ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Switch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Switch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumblePlatform", "Celeste.CrumblePlatform", "CrumblePlatform",
                assemblyIdentity, "Celeste", 33555261, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumblePlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumblePlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamBlock", "Celeste.DreamBlock", "DreamBlock", assemblyIdentity,
                "Celeste", 33555262, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FakeWall", "Celeste.FakeWall", "FakeWall", assemblyIdentity,
                "Celeste", 33555263, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FakeWall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FakeWall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallingBlock", "Celeste.FallingBlock", "FallingBlock",
                assemblyIdentity, "Celeste", 33555264, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallingBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallingBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdNPC", "Celeste.BirdNPC", "BirdNPC", assemblyIdentity,
                "Celeste",
                33555265, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdNPC", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdNPC",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCar", "Celeste.IntroCar", "IntroCar", assemblyIdentity,
                "Celeste", 33555266, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCar", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCar",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCarBarrier", "Celeste.IntroCarBarrier", "IntroCarBarrier",
                assemblyIdentity, "Celeste", 33555267, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCarBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCarBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroCrusher", "Celeste.IntroCrusher", "IntroCrusher",
                assemblyIdentity, "Celeste", 33555268, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroCrusher", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroCrusher",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroPavement", "Celeste.IntroPavement", "IntroPavement",
                assemblyIdentity, "Celeste", 33555269, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroPavement", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroPavement",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Lamp", "Celeste.Lamp", "Lamp", assemblyIdentity, "Celeste",
                33555270,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Lamp", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Lamp",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Memorial", "Celeste.Memorial", "Memorial", assemblyIdentity,
                "Celeste", 33555271, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Memorial", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Memorial",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MemorialText", "Celeste.MemorialText", "MemorialText",
                assemblyIdentity, "Celeste", 33555272, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MemorialText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MemorialText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Wire", "Celeste.Wire", "Wire", assemblyIdentity, "Celeste",
                33555273,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Wire", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Wire",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SwitchGate", "Celeste.SwitchGate", "SwitchGate", assemblyIdentity,
                "Celeste", 33555274, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SwitchGate", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SwitchGate",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TouchSwitch", "Celeste.TouchSwitch", "TouchSwitch",
                assemblyIdentity,
                "Celeste", 33555275, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TouchSwitch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TouchSwitch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EventTrigger", "Celeste.EventTrigger", "EventTrigger",
                assemblyIdentity, "Celeste", 33555276, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EventTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.EventTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MusicFadeTrigger", "Celeste.MusicFadeTrigger", "MusicFadeTrigger",
                assemblyIdentity, "Celeste", 33555277, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MusicFadeTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MusicFadeTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Trigger", "Celeste.Trigger", "Trigger", assemblyIdentity,
                "Celeste",
                33555278, true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Trigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Trigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerCollider", "Celeste.PlayerCollider", "PlayerCollider",
                assemblyIdentity, "Celeste", 33555279, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Refill", "Celeste.Refill", "Refill", assemblyIdentity, "Celeste",
                33555280, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Refill", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Refill",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Bridge", "Celeste.Bridge", "Bridge", assemblyIdentity, "Celeste",
                33555281, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Bridge", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Bridge",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BridgeTile", "Celeste.BridgeTile", "BridgeTile", assemblyIdentity,
                "Celeste", 33555282, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BridgeTile", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BridgeTile",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spikes", "Celeste.Spikes", "Spikes", assemblyIdentity, "Celeste",
                33555283, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spikes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spikes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spring", "Celeste.Spring", "Spring", assemblyIdentity, "Celeste",
                33555284, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spring", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spring",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Strawberry", "Celeste.Strawberry", "Strawberry", assemblyIdentity,
                "Celeste", 33555285, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Strawberry", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Strawberry",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.JumpthruPlatform", "Celeste.JumpthruPlatform", "JumpthruPlatform",
                assemblyIdentity, "Celeste", 33555286, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.JumpthruPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.JumpthruPlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ZipMover", "Celeste.ZipMover", "ZipMover", assemblyIdentity,
                "Celeste", 33555287, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ZipMover", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ZipMover",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Backdrop", "Celeste.Backdrop", "Backdrop", assemblyIdentity,
                "Celeste", 33555288, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Backdrop", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Backdrop",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackgroundTiles", "Celeste.BackgroundTiles", "BackgroundTiles",
                assemblyIdentity, "Celeste", 33555289, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackgroundTiles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackgroundTiles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystal", "Celeste.TheoCrystal", "TheoCrystal",
                assemblyIdentity,
                "Celeste", 33555290, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GFX", "Celeste.GFX", "GFX", assemblyIdentity, "Celeste", 33555291,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GFX", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GFX",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Input", "Celeste.Input", "Input", assemblyIdentity, "Celeste",
                33555292, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Input", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Input",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleStrength", "Celeste.RumbleStrength", "RumbleStrength",
                assemblyIdentity, "Celeste", 33555293, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleStrength", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleStrength",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleLength", "Celeste.RumbleLength", "RumbleLength",
                assemblyIdentity, "Celeste", 33555294, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleLength", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleLength",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Distort", "Celeste.Distort", "Distort", assemblyIdentity,
                "Celeste",
                33555295, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Distort", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Distort",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GaussianBlur", "Celeste.GaussianBlur", "GaussianBlur",
                assemblyIdentity, "Celeste", 33555296, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GaussianBlur", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GaussianBlur",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Hahaha", "Celeste.Hahaha", "Hahaha", assemblyIdentity, "Celeste",
                33555297, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Hahaha", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Hahaha",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerHair", "Celeste.PlayerHair", "PlayerHair", assemblyIdentity,
                "Celeste", 33555298, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerHair", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerHair",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSpriteMode", "Celeste.PlayerSpriteMode", "PlayerSpriteMode",
                assemblyIdentity, "Celeste", 33555299, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSpriteMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSpriteMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSprite", "Celeste.PlayerSprite", "PlayerSprite",
                assemblyIdentity, "Celeste", 33555300, false,
                [
                    "Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component",
                    "System.Object",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSprite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSprite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerAnimMetadata", "Celeste.PlayerAnimMetadata",
                "PlayerAnimMetadata", assemblyIdentity, "Celeste", 33555301, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerAnimMetadata", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerAnimMetadata",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BloomRenderer", "Celeste.BloomRenderer", "BloomRenderer",
                assemblyIdentity, "Celeste", 33555302, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BloomRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BloomRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisplacementRenderer", "Celeste.DisplacementRenderer",
                "DisplacementRenderer", assemblyIdentity, "Celeste", 33555303, false,
                ["Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisplacementRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisplacementRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackdropRenderer", "Celeste.BackdropRenderer", "BackdropRenderer",
                assemblyIdentity, "Celeste", 33555304, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackdropRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackdropRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ScreenWipe", "Celeste.ScreenWipe", "ScreenWipe", assemblyIdentity,
                "Celeste", 33555305, true, ["Monocle.Renderer", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ScreenWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ScreenWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snow", "Celeste.Snow", "Snow", assemblyIdentity, "Celeste",
                33555306,
                false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snow", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snow",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Parallax", "Celeste.Parallax", "Parallax", assemblyIdentity,
                "Celeste", 33555307, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Parallax", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Parallax",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ChimneySmokeFx", "Celeste.ChimneySmokeFx", "ChimneySmokeFx",
                assemblyIdentity, "Celeste", 33555308, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ChimneySmokeFx", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ChimneySmokeFx",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Dust", "Celeste.Dust", "Dust", assemblyIdentity, "Celeste",
                33555309,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Dust", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Dust",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MapData", "Celeste.MapData", "MapData", assemblyIdentity,
                "Celeste",
                33555310, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MapData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MapData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EntityData", "Celeste.EntityData", "EntityData", assemblyIdentity,
                "Celeste", 33555311, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EntityData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.EntityData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DecalData", "Celeste.DecalData", "DecalData", assemblyIdentity,
                "Celeste", 33555312, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DecalData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DecalData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelData", "Celeste.LevelData", "LevelData", assemblyIdentity,
                "Celeste", 33555313, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VertexLight", "Celeste.VertexLight", "VertexLight",
                assemblyIdentity,
                "Celeste", 33555314, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VertexLight", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.VertexLight",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Level", "Celeste.Level", "Level", assemblyIdentity, "Celeste",
                33555315, false,
                [
                    "Monocle.Scene", "Celeste.IOverlayHandler", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Level", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Level",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Facings", "Celeste.Facings", "Facings", assemblyIdentity,
                "Celeste",
                33555316, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Facings", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Facings",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Collision", "Celeste.Collision", "Collision", assemblyIdentity,
                "Celeste", 33555317, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Collision", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Collision",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CollisionData", "Celeste.CollisionData", "CollisionData",
                assemblyIdentity, "Celeste", 33555318, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CollisionData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CollisionData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Actor",
                typeof(SourceActorEntityState).FullName, "Actor",
                assemblyIdentity, "Celeste",
                33555319, false,
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
                "Celeste", 33555320, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Holdable", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Holdable",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.JumpThru", "Celeste.JumpThru", "JumpThru", assemblyIdentity,
                "Celeste", 33555321, false,
                [
                    "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.JumpThru", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.JumpThru",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashCollisionResults", "Celeste.DashCollisionResults",
                "DashCollisionResults", assemblyIdentity, "Celeste", 33555322, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashCollisionResults", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashCollisionResults",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashCollision", "Celeste.DashCollision", "DashCollision",
                assemblyIdentity, "Celeste", 33555323, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashCollision", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashCollision",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Platform", "Celeste.Platform", "Platform", assemblyIdentity,
                "Celeste", 33555324, true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Platform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Platform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Solid", "Celeste.Solid", "Solid", assemblyIdentity, "Celeste",
                33555325, false,
                [
                    "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Solid", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Solid",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Player",
                typeof(RoomPlayerSession).FullName, "Player", assemblyIdentity, "Celeste",
                33555326, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts(typeof(RoomPlayerSession).FullName, 0, false);
            catalog.PublishDeclaredTrackedAliases(typeof(RoomPlayerSession).FullName,
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Celeste", "Celeste.Celeste", "Celeste", assemblyIdentity,
                "Celeste",
                33555327, false, ["Monocle.Engine", "Microsoft.Xna.Framework.Game"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Celeste", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Celeste",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SolidTiles", "Celeste.SolidTiles", "SolidTiles", assemblyIdentity,
                "Celeste", 33555328, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SolidTiles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SolidTiles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RunLengthEncoding", "Celeste.RunLengthEncoding",
                "RunLengthEncoding",
                assemblyIdentity, "Celeste", 33555329, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RunLengthEncoding", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RunLengthEncoding",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RunThread", "Celeste.RunThread", "RunThread", assemblyIdentity,
                "Celeste", 33555330, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RunThread", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RunThread",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Buses", "Celeste.Buses", "Buses", assemblyIdentity, "Celeste",
                33555331, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Buses", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Buses",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.VCAs", "Celeste.VCAs", "VCAs", assemblyIdentity, "Celeste",
                33555332,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.VCAs", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.VCAs",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snapshots", "Celeste.Snapshots", "Snapshots", assemblyIdentity,
                "Celeste", 33555333, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snapshots", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snapshots",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SFX", "Celeste.SFX", "SFX", assemblyIdentity, "Celeste", 33555334,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SFX", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SFX",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SurfaceIndex", "Celeste.SurfaceIndex", "SurfaceIndex",
                assemblyIdentity, "Celeste", 33555335, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SurfaceIndex", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SurfaceIndex",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MagicGlow", "Celeste.MagicGlow", "MagicGlow", assemblyIdentity,
                "Celeste", 33555336, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MagicGlow", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MagicGlow",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Stat", "Celeste.Stat", "Stat", assemblyIdentity, "Celeste",
                33555337,
                false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Stat", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Stat",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Stats", "Celeste.Stats", "Stats", assemblyIdentity, "Celeste",
                33555338, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Stats", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Stats",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StadiaStat", "Celeste.StadiaStat", "StadiaStat", assemblyIdentity,
                "Celeste", 33555339, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StadiaStat", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StadiaStat",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StatsForStadia", "Celeste.StatsForStadia", "StatsForStadia",
                assemblyIdentity, "Celeste", 33555340, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StatsForStadia", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StatsForStadia",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Tags", "Celeste.Tags", "Tags", assemblyIdentity, "Celeste",
                33555341,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Tags", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Tags",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UserIO", "Celeste.UserIO", "UserIO", assemblyIdentity, "Celeste",
                33555342, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UserIO", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.UserIO",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SlashFx", "Celeste.SlashFx", "SlashFx", assemblyIdentity,
                "Celeste",
                33555343, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SlashFx", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SlashFx",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewDialog", "Celeste.PreviewDialog", "PreviewDialog",
                assemblyIdentity, "Celeste", 33555344, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewDialog", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewDialog",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IceTileOverlay", "Celeste.IceTileOverlay", "IceTileOverlay",
                assemblyIdentity, "Celeste", 33555345, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IceTileOverlay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.IceTileOverlay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Editor.LevelTemplateType", "Celeste.Editor.LevelTemplateType",
                "LevelTemplateType", assemblyIdentity, "Celeste", 33555346, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Editor.LevelTemplateType", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Editor.LevelTemplateType",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Editor.LevelTemplate", "Celeste.Editor.LevelTemplate",
                "LevelTemplate", assemblyIdentity, "Celeste", 33555347, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Editor.LevelTemplate", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Editor.LevelTemplate",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Editor.MapEditor", "Celeste.Editor.MapEditor", "MapEditor",
                assemblyIdentity, "Celeste", 33555348, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Editor.MapEditor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Editor.MapEditor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Classic", "Celeste.Pico8.Classic", "Classic",
                assemblyIdentity,
                "Celeste", 33555349, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Classic", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Classic",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pico8.Emulator", "Celeste.Pico8.Emulator", "Emulator",
                assemblyIdentity, "Celeste", 33555350, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pico8.Emulator", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pico8.Emulator",
                []);
            catalog.RegisterLogicalTypeFacts("<PrivateImplementationDetails>", "<PrivateImplementationDetails>",
                "<PrivateImplementationDetails>", assemblyIdentity, "Celeste", 33555351, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("<PrivateImplementationDetails>", 0, false);
            catalog.PublishDeclaredTrackedAliases("<PrivateImplementationDetails>",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.PixelText+Char", "Monocle.PixelText.Char", "Char",
                assemblyIdentity,
                "Celeste", 33555352, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.PixelText.Char", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.PixelText.Char",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Sprite+Animation", "Monocle.Sprite.Animation", "Animation",
                assemblyIdentity, "Celeste", 33555353, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Sprite.Animation", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Sprite.Animation",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Sprite+<PlayUtil>d__40", "Monocle.Sprite.<PlayUtil>d__40",
                "<PlayUtil>d__40", assemblyIdentity, "Celeste", 33555354, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Sprite.<PlayUtil>d__40", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Sprite.<PlayUtil>d__40",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Spritesheet`1+Animation", "Monocle.Spritesheet`1.Animation",
                "Animation", assemblyIdentity, "Celeste", 33555355, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Spritesheet`1.Animation", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Spritesheet`1.Animation",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Text+HorizontalAlign", "Monocle.Text.HorizontalAlign",
                "HorizontalAlign", assemblyIdentity, "Celeste", 33555356, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Text.HorizontalAlign", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Text.HorizontalAlign",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Text+VerticalAlign", "Monocle.Text.VerticalAlign",
                "VerticalAlign",
                assemblyIdentity, "Celeste", 33555357, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Text.VerticalAlign", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Text.VerticalAlign",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.TimerText+CountModes", "Monocle.TimerText.CountModes",
                "CountModes",
                assemblyIdentity, "Celeste", 33555358, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.TimerText.CountModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.TimerText.CountModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.TimerText+TimerModes", "Monocle.TimerText.TimerModes",
                "TimerModes",
                assemblyIdentity, "Celeste", 33555359, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.TimerText.TimerModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.TimerText.TimerModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Alarm+AlarmMode", "Monocle.Alarm.AlarmMode", "AlarmMode",
                assemblyIdentity, "Celeste", 33555360, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Alarm.AlarmMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Alarm.AlarmMode",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.CoroutineHolder+CoroutineData",
                "Monocle.CoroutineHolder.CoroutineData", "CoroutineData", assemblyIdentity, "Celeste", 33555361, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.CoroutineHolder.CoroutineData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.CoroutineHolder.CoroutineData",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.CoroutineHolder+<WaitForFrames>d__8",
                "Monocle.CoroutineHolder.<WaitForFrames>d__8", "<WaitForFrames>d__8", assemblyIdentity, "Celeste",
                33555362,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.CoroutineHolder.<WaitForFrames>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.CoroutineHolder.<WaitForFrames>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tween+TweenMode", "Monocle.Tween.TweenMode", "TweenMode",
                assemblyIdentity, "Celeste", 33555363, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tween.TweenMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tween.TweenMode",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tween+<>c__DisplayClass35_0",
                "Monocle.Tween.<>c__DisplayClass35_0",
                "<>c__DisplayClass35_0", assemblyIdentity, "Celeste", 33555364, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tween.<>c__DisplayClass35_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tween.<>c__DisplayClass35_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tween+<Wait>d__45", "Monocle.Tween.<Wait>d__45", "<Wait>d__45",
                assemblyIdentity, "Celeste", 33555365, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tween.<Wait>d__45", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tween.<Wait>d__45",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Atlas+AtlasDataFormat", "Monocle.Atlas.AtlasDataFormat",
                "AtlasDataFormat", assemblyIdentity, "Celeste", 33555366, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Atlas.AtlasDataFormat", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Atlas.AtlasDataFormat",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.MInput+KeyboardData", "Monocle.MInput.KeyboardData",
                "KeyboardData",
                assemblyIdentity, "Celeste", 33555367, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.MInput.KeyboardData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.MInput.KeyboardData",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.MInput+MouseData", "Monocle.MInput.MouseData", "MouseData",
                assemblyIdentity, "Celeste", 33555368, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.MInput.MouseData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.MInput.MouseData",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.MInput+GamePadData", "Monocle.MInput.GamePadData", "GamePadData",
                assemblyIdentity, "Celeste", 33555369, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.MInput.GamePadData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.MInput.GamePadData",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualInput+OverlapBehaviors",
                "Monocle.VirtualInput.OverlapBehaviors", "OverlapBehaviors", assemblyIdentity, "Celeste", 33555370,
                false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualInput.OverlapBehaviors", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInput.OverlapBehaviors",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualInput+ThresholdModes",
                "Monocle.VirtualInput.ThresholdModes",
                "ThresholdModes", assemblyIdentity, "Celeste", 33555371, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualInput.ThresholdModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInput.ThresholdModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ComponentList+LockModes", "Monocle.ComponentList.LockModes",
                "LockModes", assemblyIdentity, "Celeste", 33555372, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ComponentList.LockModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ComponentList.LockModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ComponentList+<GetAll>d__36`1",
                "Monocle.ComponentList.<GetAll>d__36`1", "<GetAll>d__36`1", assemblyIdentity, "Celeste", 33555373,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                    "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ComponentList.<GetAll>d__36`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ComponentList.<GetAll>d__36`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.EntityList+<>c", "Monocle.EntityList.<>c", "<>c",
                assemblyIdentity,
                "Celeste", 33555374, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.EntityList.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.EntityList.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ParticleType+ColorModes", "Monocle.ParticleType.ColorModes",
                "ColorModes", assemblyIdentity, "Celeste", 33555375, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ParticleType.ColorModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType.ColorModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ParticleType+FadeModes", "Monocle.ParticleType.FadeModes",
                "FadeModes", assemblyIdentity, "Celeste", 33555376, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ParticleType.FadeModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType.FadeModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ParticleType+RotationModes", "Monocle.ParticleType.RotationModes",
                "RotationModes", assemblyIdentity, "Celeste", 33555377, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ParticleType.RotationModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType.RotationModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Calc+<>c", "Monocle.Calc.<>c", "<>c", assemblyIdentity, "Celeste",
                33555378, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Calc.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Calc.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Calc+<Do>d__246", "Monocle.Calc.<Do>d__246", "<Do>d__246",
                assemblyIdentity, "Celeste", 33555379, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Calc.<Do>d__246", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Calc.<Do>d__246",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ChoiceSet`1+Choice", "Monocle.ChoiceSet`1.Choice", "Choice",
                assemblyIdentity, "Celeste", 33555380, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ChoiceSet`1.Choice", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ChoiceSet`1.Choice",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Chooser`1+Choice", "Monocle.Chooser`1.Choice", "Choice",
                assemblyIdentity, "Celeste", 33555381, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Chooser`1.Choice", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Chooser`1.Choice",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Commands+CommandInfo", "Monocle.Commands.CommandInfo",
                "CommandInfo",
                assemblyIdentity, "Celeste", 33555382, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Commands.CommandInfo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Commands.CommandInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Commands+Line", "Monocle.Commands.Line", "Line", assemblyIdentity,
                "Celeste", 33555383, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Commands.Line", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Commands.Line",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Commands+<>c__DisplayClass38_0",
                "Monocle.Commands.<>c__DisplayClass38_0", "<>c__DisplayClass38_0", assemblyIdentity, "Celeste",
                33555384,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Commands.<>c__DisplayClass38_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<>c__DisplayClass38_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Commands+<>c__DisplayClass38_1",
                "Monocle.Commands.<>c__DisplayClass38_1", "<>c__DisplayClass38_1", assemblyIdentity, "Celeste",
                33555385,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Commands.<>c__DisplayClass38_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<>c__DisplayClass38_1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Ease+Easer", "Monocle.Ease.Easer", "Easer", assemblyIdentity,
                "Celeste", 33555386, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Ease.Easer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Ease.Easer",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Ease+<>c__DisplayClass35_0", "Monocle.Ease.<>c__DisplayClass35_0",
                "<>c__DisplayClass35_0", assemblyIdentity, "Celeste", 33555387, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Ease.<>c__DisplayClass35_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Ease.<>c__DisplayClass35_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Ease+<>c__DisplayClass36_0", "Monocle.Ease.<>c__DisplayClass36_0",
                "<>c__DisplayClass36_0", assemblyIdentity, "Celeste", 33555388, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Ease.<>c__DisplayClass36_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Ease.<>c__DisplayClass36_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Ease+<>c", "Monocle.Ease.<>c", "<>c", assemblyIdentity, "Celeste",
                33555389, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Ease.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Ease.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.PixelFont+<>c", "Monocle.PixelFont.<>c", "<>c", assemblyIdentity,
                "Celeste", 33555390, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.PixelFont.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.PixelFont.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SaveLoad+SerializeModes", "Monocle.SaveLoad.SerializeModes",
                "SerializeModes", assemblyIdentity, "Celeste", 33555391, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SaveLoad.SerializeModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.SaveLoad.SerializeModes",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tiler+EdgeBehavior", "Monocle.Tiler.EdgeBehavior", "EdgeBehavior",
                assemblyIdentity, "Celeste", 33555392, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tiler.EdgeBehavior", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tiler.EdgeBehavior",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker+<EnumerateEntities>d__33`1",
                "Monocle.Tracker.<EnumerateEntities>d__33`1", "<EnumerateEntities>d__33`1", assemblyIdentity, "Celeste",
                33555393, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker.<EnumerateEntities>d__33`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker.<EnumerateEntities>d__33`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker+<EnumerateComponents>d__39`1",
                "Monocle.Tracker.<EnumerateComponents>d__39`1", "<EnumerateComponents>d__39`1", assemblyIdentity,
                "Celeste",
                33555394, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker.<EnumerateComponents>d__39`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker.<EnumerateComponents>d__39`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock+States", "Celeste.BounceBlock.States", "States",
                assemblyIdentity, "Celeste", 33555395, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock.States", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock.States",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock+RespawnDebris", "Celeste.BounceBlock.RespawnDebris",
                "RespawnDebris", assemblyIdentity, "Celeste", 33555396, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock.RespawnDebris", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock.RespawnDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock+BreakDebris", "Celeste.BounceBlock.BreakDebris",
                "BreakDebris", assemblyIdentity, "Celeste", 33555397, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock.BreakDebris", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock.BreakDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlock+Modes", "Celeste.CassetteBlock.Modes", "Modes",
                assemblyIdentity, "Celeste", 33555398, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlock.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlock.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlock+BoxSide", "Celeste.CassetteBlock.BoxSide",
                "BoxSide",
                assemblyIdentity, "Celeste", 33555399, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlock.BoxSide", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlock.BoxSide",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<Cutscene>d__9",
                "Celeste.CS10_Farewell.<Cutscene>d__9",
                "<Cutscene>d__9", assemblyIdentity, "Celeste", 33555400, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<Cutscene>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<Cutscene>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<WaitForGranny>d__10",
                "Celeste.CS10_Farewell.<WaitForGranny>d__10", "<WaitForGranny>d__10", assemblyIdentity, "Celeste",
                33555401,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<WaitForGranny>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<WaitForGranny>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<Laugh>d__11", "Celeste.CS10_Farewell.<Laugh>d__11",
                "<Laugh>d__11", assemblyIdentity, "Celeste", 33555402, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<Laugh>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<Laugh>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<StopLaughing>d__12",
                "Celeste.CS10_Farewell.<StopLaughing>d__12", "<StopLaughing>d__12", assemblyIdentity, "Celeste",
                33555403,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<StopLaughing>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<StopLaughing>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<StepForward>d__13",
                "Celeste.CS10_Farewell.<StepForward>d__13", "<StepForward>d__13", assemblyIdentity, "Celeste", 33555404,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<StepForward>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<StepForward>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<GrannyDisappear>d__14",
                "Celeste.CS10_Farewell.<GrannyDisappear>d__14", "<GrannyDisappear>d__14", assemblyIdentity, "Celeste",
                33555405, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<GrannyDisappear>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<GrannyDisappear>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<FadeToWhite>d__15",
                "Celeste.CS10_Farewell.<FadeToWhite>d__15", "<FadeToWhite>d__15", assemblyIdentity, "Celeste", 33555406,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<FadeToWhite>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<FadeToWhite>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<DoFadeToWhite>d__16",
                "Celeste.CS10_Farewell.<DoFadeToWhite>d__16", "<DoFadeToWhite>d__16", assemblyIdentity, "Celeste",
                33555407,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<DoFadeToWhite>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<DoFadeToWhite>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<Cutscene>d__14",
                "Celeste.CS10_FinalLaunch.<Cutscene>d__14", "<Cutscene>d__14", assemblyIdentity, "Celeste", 33555408,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<Cutscene>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<Cutscene>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<>c__DisplayClass15_0",
                "Celeste.CS10_FinalLaunch.<>c__DisplayClass15_0", "<>c__DisplayClass15_0", assemblyIdentity, "Celeste",
                33555409, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<>c__DisplayClass15_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<>c__DisplayClass15_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<WaveCamera>d__16",
                "Celeste.CS10_FinalLaunch.<WaveCamera>d__16", "<WaveCamera>d__16", assemblyIdentity, "Celeste",
                33555410,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<WaveCamera>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<WaveCamera>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<BirdRoutine>d__17",
                "Celeste.CS10_FinalLaunch.<BirdRoutine>d__17", "<BirdRoutine>d__17", assemblyIdentity, "Celeste",
                33555411,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<BirdRoutine>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<BirdRoutine>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom+<Cutscene>d__5",
                "Celeste.CS10_FinalRoom.<Cutscene>d__5", "<Cutscene>d__5", assemblyIdentity, "Celeste", 33555412, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom.<Cutscene>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom.<Cutscene>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom+<BadelineAppears>d__6",
                "Celeste.CS10_FinalRoom.<BadelineAppears>d__6", "<BadelineAppears>d__6", assemblyIdentity, "Celeste",
                33555413, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom.<BadelineAppears>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom.<BadelineAppears>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom+<BadelineVanishes>d__7",
                "Celeste.CS10_FinalRoom.<BadelineVanishes>d__7", "<BadelineVanishes>d__7", assemblyIdentity, "Celeste",
                33555414, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom.<BadelineVanishes>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom.<BadelineVanishes>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+Axes", "Celeste.CrushBlock.Axes", "Axes",
                assemblyIdentity,
                "Celeste", 33555415, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.Axes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.Axes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+MoveState", "Celeste.CrushBlock.MoveState",
                "MoveState",
                assemblyIdentity, "Celeste", 33555416, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.MoveState", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.MoveState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+<>c__DisplayClass39_0",
                "Celeste.CrushBlock.<>c__DisplayClass39_0", "<>c__DisplayClass39_0", assemblyIdentity, "Celeste",
                33555417,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.<>c__DisplayClass39_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.<>c__DisplayClass39_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+<>c__DisplayClass41_0",
                "Celeste.CrushBlock.<>c__DisplayClass41_0", "<>c__DisplayClass41_0", assemblyIdentity, "Celeste",
                33555418,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.<>c__DisplayClass41_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.<>c__DisplayClass41_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+<AttackSequence>d__41",
                "Celeste.CrushBlock.<AttackSequence>d__41", "<AttackSequence>d__41", assemblyIdentity, "Celeste",
                33555419,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.<AttackSequence>d__41", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.<AttackSequence>d__41",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlock+Line", "Celeste.GlassBlock.Line", "Line",
                assemblyIdentity,
                "Celeste", 33555420, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlock.Line", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlock.Line",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide", "Celeste.Cassette.UnlockedBSide",
                "UnlockedBSide", assemblyIdentity, "Celeste", 33555421, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+<CollectRoutine>d__19",
                "Celeste.Cassette.<CollectRoutine>d__19", "<CollectRoutine>d__19", assemblyIdentity, "Celeste",
                33555422,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.<CollectRoutine>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.<CollectRoutine>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGem+BgFlash", "Celeste.SummitGem.BgFlash", "BgFlash",
                assemblyIdentity, "Celeste", 33555423, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGem.BgFlash", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGem.BgFlash",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGem+<SmashRoutine>d__11",
                "Celeste.SummitGem.<SmashRoutine>d__11", "<SmashRoutine>d__11", assemblyIdentity, "Celeste", 33555424,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGem.<SmashRoutine>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGem.<SmashRoutine>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect+OnlyModes", "Celeste.LavaRect.OnlyModes", "OnlyModes",
                assemblyIdentity, "Celeste", 33555425, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect.OnlyModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect.OnlyModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect+Bubble", "Celeste.LavaRect.Bubble", "Bubble",
                assemblyIdentity, "Celeste", 33555426, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect.Bubble", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect.Bubble",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect+SurfaceBubble", "Celeste.LavaRect.SurfaceBubble",
                "SurfaceBubble", assemblyIdentity, "Celeste", 33555427, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect.SurfaceBubble", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect.SurfaceBubble",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SolidOnInvinciblePlayer+Outline",
                "Celeste.SolidOnInvinciblePlayer.Outline", "Outline", assemblyIdentity, "Celeste", 33555428, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SolidOnInvinciblePlayer.Outline", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SolidOnInvinciblePlayer.Outline",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<>c", "Celeste.CS10_Ending.<>c", "<>c",
                assemblyIdentity,
                "Celeste", 33555429, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<Cutscene>d__30",
                "Celeste.CS10_Ending.<Cutscene>d__30",
                "<Cutscene>d__30", assemblyIdentity, "Celeste", 33555430, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<Cutscene>d__30", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<Cutscene>d__30",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<ShowPicture>d__31",
                "Celeste.CS10_Ending.<ShowPicture>d__31", "<ShowPicture>d__31", assemblyIdentity, "Celeste", 33555431,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<ShowPicture>d__31", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<ShowPicture>d__31",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<EndingRoutine>d__33",
                "Celeste.CS10_Ending.<EndingRoutine>d__33", "<EndingRoutine>d__33", assemblyIdentity, "Celeste",
                33555432,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<EndingRoutine>d__33", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<EndingRoutine>d__33",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<Zoom>d__37", "Celeste.CS10_Ending.<Zoom>d__37",
                "<Zoom>d__37", assemblyIdentity, "Celeste", 33555433, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<Zoom>d__37", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<Zoom>d__37",
                []);
        }
    }
}
