using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup
{
    public static partial class InstalledLogicalTypeFacts
    {
        private static void RegisterPart4(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.AbsorbOrb", "Celeste.AbsorbOrb", "AbsorbOrb", assemblyIdentity,
                "Celeste", 33555234, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AbsorbOrb", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AbsorbOrb",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BigWaterfall", "Celeste.BigWaterfall", "BigWaterfall",
                assemblyIdentity, "Celeste", 33555235, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BigWaterfall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BigWaterfall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BigWaterfall+Layers", "Celeste.BigWaterfall.Layers", "Layers",
                assemblyIdentity, "Celeste", 33555236, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BigWaterfall.Layers", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BigWaterfall.Layers",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CliffsideWindFlag", "Celeste.CliffsideWindFlag",
                "CliffsideWindFlag",
                assemblyIdentity, "Celeste", 33555237, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CliffsideWindFlag", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CliffsideWindFlag",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CliffsideWindFlag+Segment", "Celeste.CliffsideWindFlag.Segment",
                "Segment", assemblyIdentity, "Celeste", 33555238, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CliffsideWindFlag.Segment", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CliffsideWindFlag.Segment",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrystalDebris", "Celeste.CrystalDebris", "CrystalDebris",
                assemblyIdentity, "Celeste", 33555239, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrystalDebris", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrystalDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallEffects", "Celeste.FallEffects", "FallEffects",
                assemblyIdentity,
                "Celeste", 33555240, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallEffects", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallEffects",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallEffects+Particle", "Celeste.FallEffects.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555241, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallEffects.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallEffects.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonCreature", "Celeste.MoonCreature", "MoonCreature",
                assemblyIdentity, "Celeste", 33555242, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonCreature", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonCreature",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonCreature+TrailNode", "Celeste.MoonCreature.TrailNode",
                "TrailNode", assemblyIdentity, "Celeste", 33555243, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonCreature.TrailNode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonCreature.TrailNode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SoundSourceEntity", "Celeste.SoundSourceEntity",
                "SoundSourceEntity",
                assemblyIdentity, "Celeste", 33555244, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SoundSourceEntity", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SoundSourceEntity",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitCloud", "Celeste.SummitCloud", "SummitCloud",
                assemblyIdentity,
                "Celeste", 33555245, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitCloud", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitCloud",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleEye", "Celeste.TempleEye", "TempleEye", assemblyIdentity,
                "Celeste", 33555246, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleEye", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleEye",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TemplePortalTorch", "Celeste.TemplePortalTorch",
                "TemplePortalTorch",
                assemblyIdentity, "Celeste", 33555247, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TemplePortalTorch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TemplePortalTorch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnableAttribute", "Celeste.SpawnableAttribute",
                "SpawnableAttribute", assemblyIdentity, "Celeste", 33555248, false, ["System.Attribute"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnableAttribute", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnableAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnerAttribute", "Celeste.SpawnerAttribute", "SpawnerAttribute",
                assemblyIdentity, "Celeste", 33555249, false, ["System.Attribute"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnerAttribute", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnerAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spawn", "Celeste.Spawn", "Spawn", assemblyIdentity, "Celeste",
                33555250, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spawn", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spawn",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnManager", "Celeste.SpawnManager", "SpawnManager",
                assemblyIdentity, "Celeste", 33555251, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackgroundFadeIn", "Celeste.BackgroundFadeIn", "BackgroundFadeIn",
                assemblyIdentity, "Celeste", 33555252, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackgroundFadeIn", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackgroundFadeIn",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingRumbler", "Celeste.BreathingRumbler", "BreathingRumbler",
                assemblyIdentity, "Celeste", 33555253, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingRumbler", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingRumbler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BridgeFixed", "Celeste.BridgeFixed", "BridgeFixed",
                assemblyIdentity,
                "Celeste", 33555254, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BridgeFixed", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BridgeFixed",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreMessage", "Celeste.CoreMessage", "CoreMessage",
                assemblyIdentity,
                "Celeste", 33555255, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreMessage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreMessage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor", "Celeste.HeartGemDoor", "HeartGemDoor",
                assemblyIdentity, "Celeste", 33555256, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor+Particle", "Celeste.HeartGemDoor.Particle",
                "Particle",
                assemblyIdentity, "Celeste", 33555257, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor+WhiteLine", "Celeste.HeartGemDoor.WhiteLine",
                "WhiteLine", assemblyIdentity, "Celeste", 33555258, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor.WhiteLine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor.WhiteLine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor+<Routine>d__32",
                "Celeste.HeartGemDoor.<Routine>d__32",
                "<Routine>d__32", assemblyIdentity, "Celeste", 33555259, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor.<Routine>d__32", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor.<Routine>d__32",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KevinsPC", "Celeste.KevinsPC", "KevinsPC", assemblyIdentity,
                "Celeste", 33555260, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KevinsPC", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.KevinsPC",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelUpEffect", "Celeste.LevelUpEffect", "LevelUpEffect",
                assemblyIdentity, "Celeste", 33555261, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelUpEffect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelUpEffect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OshiroLobbyBell", "Celeste.OshiroLobbyBell", "OshiroLobbyBell",
                assemblyIdentity, "Celeste", 33555262, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OshiroLobbyBell", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OshiroLobbyBell",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionTentacles", "Celeste.ReflectionTentacles",
                "ReflectionTentacles", assemblyIdentity, "Celeste", 33555263, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionTentacles", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionTentacles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionTentacles+Tentacle",
                "Celeste.ReflectionTentacles.Tentacle",
                "Tentacle", assemblyIdentity, "Celeste", 33555264, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionTentacles.Tentacle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionTentacles.Tentacle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionTentacles+MTextureComparer",
                "Celeste.ReflectionTentacles.MTextureComparer", "MTextureComparer", assemblyIdentity, "Celeste",
                33555265,
                false,
                ["System.ValueType", "System.Collections.Generic.IEqualityComparer`1<Monocle.MTexture>"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionTentacles.MTextureComparer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionTentacles.MTextureComparer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionTentacles+UVSet", "Celeste.ReflectionTentacles.UVSet",
                "UVSet", assemblyIdentity, "Celeste", 33555266, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionTentacles.UVSet", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionTentacles.UVSet",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RidgeGate", "Celeste.RidgeGate", "RidgeGate", assemblyIdentity,
                "Celeste", 33555267, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RidgeGate", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RidgeGate",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RidgeGate+<>c__DisplayClass4_0",
                "Celeste.RidgeGate.<>c__DisplayClass4_0", "<>c__DisplayClass4_0", assemblyIdentity, "Celeste", 33555268,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RidgeGate.<>c__DisplayClass4_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.RidgeGate.<>c__DisplayClass4_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RidgeGate+<EnterSequence>d__4",
                "Celeste.RidgeGate.<EnterSequence>d__4", "<EnterSequence>d__4", assemblyIdentity, "Celeste", 33555269,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RidgeGate.<EnterSequence>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RidgeGate.<EnterSequence>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarJumpController", "Celeste.StarJumpController",
                "StarJumpController", assemblyIdentity, "Celeste", 33555270, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarJumpController", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarJumpController+Ray", "Celeste.StarJumpController.Ray", "Ray",
                assemblyIdentity, "Celeste", 33555271, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarJumpController.Ray", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpController.Ray",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarJumpBlock", "Celeste.StarJumpBlock", "StarJumpBlock",
                assemblyIdentity, "Celeste", 33555272, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarJumpBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager", "Celeste.AscendManager", "AscendManager",
                assemblyIdentity, "Celeste", 33555273, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Streaks", "Celeste.AscendManager.Streaks",
                "Streaks",
                assemblyIdentity, "Celeste", 33555274, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Streaks", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Streaks",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Streaks+Particle",
                "Celeste.AscendManager.Streaks.Particle", "Particle", assemblyIdentity, "Celeste", 33555275, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Streaks.Particle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Streaks.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Clouds", "Celeste.AscendManager.Clouds", "Clouds",
                assemblyIdentity, "Celeste", 33555276, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Clouds", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Clouds",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Clouds+Particle",
                "Celeste.AscendManager.Clouds.Particle", "Particle", assemblyIdentity, "Celeste", 33555277, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Clouds.Particle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Clouds.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Fader", "Celeste.AscendManager.Fader", "Fader",
                assemblyIdentity, "Celeste", 33555278, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Fader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Fader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+<Routine>d__15",
                "Celeste.AscendManager.<Routine>d__15",
                "<Routine>d__15", assemblyIdentity, "Celeste", 33555279, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.<Routine>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.<Routine>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+<FadeTo>d__19",
                "Celeste.AscendManager.<FadeTo>d__19",
                "<FadeTo>d__19", assemblyIdentity, "Celeste", 33555280, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.<FadeTo>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.<FadeTo>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint", "Celeste.SummitCheckpoint", "SummitCheckpoint",
                assemblyIdentity, "Celeste", 33555281, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint+ConfettiRenderer",
                "Celeste.SummitCheckpoint.ConfettiRenderer", "ConfettiRenderer", assemblyIdentity, "Celeste", 33555282,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint.ConfettiRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint.ConfettiRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint+ConfettiRenderer+Particle",
                "Celeste.SummitCheckpoint.ConfettiRenderer.Particle", "Particle", assemblyIdentity, "Celeste", 33555283,
                false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint.ConfettiRenderer.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint.ConfettiRenderer.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGemManager", "Celeste.SummitGemManager", "SummitGemManager",
                assemblyIdentity, "Celeste", 33555284, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGemManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGemManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGemManager+Gem", "Celeste.SummitGemManager.Gem", "Gem",
                assemblyIdentity, "Celeste", 33555285, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGemManager.Gem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGemManager.Gem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGemManager+<Routine>d__4",
                "Celeste.SummitGemManager.<Routine>d__4", "<Routine>d__4", assemblyIdentity, "Celeste", 33555286, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGemManager.<Routine>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGemManager.<Routine>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoPhone", "Celeste.TheoPhone", "TheoPhone", assemblyIdentity,
                "Celeste", 33555287, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoPhone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoPhone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockEverythingThingy", "Celeste.UnlockEverythingThingy",
                "UnlockEverythingThingy", assemblyIdentity, "Celeste", 33555288, false,
                [
                    "Monocle.CheatListener", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockEverythingThingy", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockEverythingThingy",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockEverythingThingy+<>c", "Celeste.UnlockEverythingThingy.<>c",
                "<>c", assemblyIdentity, "Celeste", 33555289, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockEverythingThingy.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockEverythingThingy.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockEverythingThingy+<>c__DisplayClass1_0",
                "Celeste.UnlockEverythingThingy.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity,
                "Celeste",
                33555290, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockEverythingThingy.<>c__DisplayClass1_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockEverythingThingy.<>c__DisplayClass1_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdPathTrigger", "Celeste.BirdPathTrigger", "BirdPathTrigger",
                assemblyIdentity, "Celeste", 33555291, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdPathTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdPathTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeStrengthTrigger", "Celeste.BlackholeStrengthTrigger",
                "BlackholeStrengthTrigger", assemblyIdentity, "Celeste", 33555292, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeStrengthTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeStrengthTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger", "Celeste.DetachStrawberryTrigger",
                "DetachStrawberryTrigger", assemblyIdentity, "Celeste", 33555293, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger+<>c__DisplayClass4_0",
                "Celeste.DetachStrawberryTrigger.<>c__DisplayClass4_0", "<>c__DisplayClass4_0", assemblyIdentity,
                "Celeste",
                33555294, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger.<>c__DisplayClass4_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger.<>c__DisplayClass4_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger+<DetatchFollower>d__4",
                "Celeste.DetachStrawberryTrigger.<DetatchFollower>d__4", "<DetatchFollower>d__4", assemblyIdentity,
                "Celeste", 33555295, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger.<DetatchFollower>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger.<DetatchFollower>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger+<DetatchFollower>d__2",
                "Celeste.DetachStrawberryTrigger.<DetatchFollower>d__2", "<DetatchFollower>d__2", assemblyIdentity,
                "Celeste", 33555296, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger.<DetatchFollower>d__2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger.<DetatchFollower>d__2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleTrigger", "Celeste.RumbleTrigger", "RumbleTrigger",
                assemblyIdentity, "Celeste", 33555297, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleTrigger+<>c", "Celeste.RumbleTrigger.<>c", "<>c",
                assemblyIdentity, "Celeste", 33555298, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleTrigger.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleTrigger.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleTrigger+<RumbleRoutine>d__13",
                "Celeste.RumbleTrigger.<RumbleRoutine>d__13", "<RumbleRoutine>d__13", assemblyIdentity, "Celeste",
                33555299,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleTrigger.<RumbleRoutine>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleTrigger.<RumbleRoutine>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnFacingTrigger", "Celeste.SpawnFacingTrigger",
                "SpawnFacingTrigger", assemblyIdentity, "Celeste", 33555300, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnFacingTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnFacingTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GrabbyIcon", "Celeste.GrabbyIcon", "GrabbyIcon", assemblyIdentity,
                "Celeste", 33555301, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GrabbyIcon", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GrabbyIcon",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage03", "Celeste.WaveDashPage03", "WaveDashPage03",
                assemblyIdentity, "Celeste", 33555302, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage03", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage03",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage03+<Routine>d__8",
                "Celeste.WaveDashPage03.<Routine>d__8",
                "<Routine>d__8", assemblyIdentity, "Celeste", 33555303, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage03.<Routine>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage03.<Routine>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05", "Celeste.WaveDashPage05", "WaveDashPage05",
                assemblyIdentity, "Celeste", 33555304, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display", "Celeste.WaveDashPage05.Display",
                "Display",
                assemblyIdentity, "Celeste", 33555305, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display+<>c", "Celeste.WaveDashPage05.Display.<>c",
                "<>c", assemblyIdentity, "Celeste", 33555306, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display+<Routine>d__7",
                "Celeste.WaveDashPage05.Display.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33555307,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display.<Routine>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display.<Routine>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+<Routine>d__4",
                "Celeste.WaveDashPage05.<Routine>d__4",
                "<Routine>d__4", assemblyIdentity, "Celeste", 33555308, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.<Routine>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.<Routine>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage04", "Celeste.WaveDashPage04", "WaveDashPage04",
                assemblyIdentity, "Celeste", 33555309, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage04", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage04",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage04+<>c__DisplayClass5_0",
                "Celeste.WaveDashPage04.<>c__DisplayClass5_0", "<>c__DisplayClass5_0", assemblyIdentity, "Celeste",
                33555310, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage04.<>c__DisplayClass5_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage04.<>c__DisplayClass5_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage04+<Routine>d__6",
                "Celeste.WaveDashPage04.<Routine>d__6",
                "<Routine>d__6", assemblyIdentity, "Celeste", 33555311, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage04.<Routine>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage04.<Routine>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage06", "Celeste.WaveDashPage06", "WaveDashPage06",
                assemblyIdentity, "Celeste", 33555312, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage06", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage06",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage06+<Routine>d__2",
                "Celeste.WaveDashPage06.<Routine>d__2",
                "<Routine>d__2", assemblyIdentity, "Celeste", 33555313, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage06.<Routine>d__2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage06.<Routine>d__2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02", "Celeste.WaveDashPage02", "WaveDashPage02",
                assemblyIdentity, "Celeste", 33555314, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02+TitleText", "Celeste.WaveDashPage02.TitleText",
                "TitleText", assemblyIdentity, "Celeste", 33555315, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02.TitleText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02.TitleText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02+TitleText+<Stamp>d__6",
                "Celeste.WaveDashPage02.TitleText.<Stamp>d__6", "<Stamp>d__6", assemblyIdentity, "Celeste", 33555316,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02.TitleText.<Stamp>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02.TitleText.<Stamp>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02+<Routine>d__7",
                "Celeste.WaveDashPage02.<Routine>d__7",
                "<Routine>d__7", assemblyIdentity, "Celeste", 33555317, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02.<Routine>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02.<Routine>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage01", "Celeste.WaveDashPage01", "WaveDashPage01",
                assemblyIdentity, "Celeste", 33555318, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage01", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage01",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage01+<Routine>d__4",
                "Celeste.WaveDashPage01.<Routine>d__4",
                "<Routine>d__4", assemblyIdentity, "Celeste", 33555319, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage01.<Routine>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage01.<Routine>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage00", "Celeste.WaveDashPage00", "WaveDashPage00",
                assemblyIdentity, "Celeste", 33555320, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage00", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage00",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage00+<Routine>d__6",
                "Celeste.WaveDashPage00.<Routine>d__6",
                "<Routine>d__6", assemblyIdentity, "Celeste", 33555321, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage00.<Routine>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage00.<Routine>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage00+<MoveCursor>d__7",
                "Celeste.WaveDashPage00.<MoveCursor>d__7", "<MoveCursor>d__7", assemblyIdentity, "Celeste", 33555322,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage00.<MoveCursor>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage00.<MoveCursor>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage", "Celeste.WaveDashPage", "WaveDashPage",
                assemblyIdentity, "Celeste", 33555323, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage+Transitions", "Celeste.WaveDashPage.Transitions",
                "Transitions", assemblyIdentity, "Celeste", 33555324, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage.Transitions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage.Transitions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage+<PressButton>d__14",
                "Celeste.WaveDashPage.<PressButton>d__14", "<PressButton>d__14", assemblyIdentity, "Celeste", 33555325,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage.<PressButton>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage.<PressButton>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPlaybackTutorial", "Celeste.WaveDashPlaybackTutorial",
                "WaveDashPlaybackTutorial", assemblyIdentity, "Celeste", 33555326, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPlaybackTutorial", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPlaybackTutorial",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPresentation", "Celeste.WaveDashPresentation",
                "WaveDashPresentation", assemblyIdentity, "Celeste", 33555327, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPresentation", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPresentation",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPresentation+<Routine>d__33",
                "Celeste.WaveDashPresentation.<Routine>d__33", "<Routine>d__33", assemblyIdentity, "Celeste", 33555328,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPresentation.<Routine>d__33", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPresentation.<Routine>d__33",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPresentation+<TurnPage>d__34",
                "Celeste.WaveDashPresentation.<TurnPage>d__34", "<TurnPage>d__34", assemblyIdentity, "Celeste",
                33555329,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPresentation.<TurnPage>d__34", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPresentation.<TurnPage>d__34",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashTutorialMachine", "Celeste.WaveDashTutorialMachine",
                "WaveDashTutorialMachine", assemblyIdentity, "Celeste", 33555330, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashTutorialMachine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashTutorialMachine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashTutorialMachine+<InteractRoutine>d__24",
                "Celeste.WaveDashTutorialMachine.<InteractRoutine>d__24", "<InteractRoutine>d__24", assemblyIdentity,
                "Celeste", 33555331, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashTutorialMachine.<InteractRoutine>d__24", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashTutorialMachine.<InteractRoutine>d__24",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpeedRing", "Celeste.SpeedRing", "SpeedRing", assemblyIdentity,
                "Celeste", 33555332, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpeedRing", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpeedRing",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AmbienceParamTrigger", "Celeste.AmbienceParamTrigger",
                "AmbienceParamTrigger", assemblyIdentity, "Celeste", 33555333, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AmbienceParamTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AmbienceParamTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CameraAdvanceTargetTrigger", "Celeste.CameraAdvanceTargetTrigger",
                "CameraAdvanceTargetTrigger", assemblyIdentity, "Celeste", 33555334, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CameraAdvanceTargetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CameraAdvanceTargetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CheckpointBlockerTrigger", "Celeste.CheckpointBlockerTrigger",
                "CheckpointBlockerTrigger", assemblyIdentity, "Celeste", 33555335, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CheckpointBlockerTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CheckpointBlockerTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CreditsTrigger", "Celeste.CreditsTrigger", "CreditsTrigger",
                assemblyIdentity, "Celeste", 33555336, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CreditsTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CreditsTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GoldBerryCollectTrigger", "Celeste.GoldBerryCollectTrigger",
                "GoldBerryCollectTrigger", assemblyIdentity, "Celeste", 33555337, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GoldBerryCollectTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GoldBerryCollectTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.InteractTrigger", "Celeste.InteractTrigger", "InteractTrigger",
                assemblyIdentity, "Celeste", 33555338, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.InteractTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.InteractTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LookoutBlocker", "Celeste.LookoutBlocker", "LookoutBlocker",
                assemblyIdentity, "Celeste", 33555339, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LookoutBlocker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LookoutBlocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger",
                "Celeste.MoonGlitchBackgroundTrigger",
                "MoonGlitchBackgroundTrigger", assemblyIdentity, "Celeste", 33555340, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger+Duration",
                "Celeste.MoonGlitchBackgroundTrigger.Duration", "Duration", assemblyIdentity, "Celeste", 33555341,
                false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger.Duration", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger.Duration",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger+<InternalGlitchRoutine>d__9",
                "Celeste.MoonGlitchBackgroundTrigger.<InternalGlitchRoutine>d__9", "<InternalGlitchRoutine>d__9",
                assemblyIdentity, "Celeste", 33555342, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger.<InternalGlitchRoutine>d__9", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger.<InternalGlitchRoutine>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger+<GlitchRoutine>d__12",
                "Celeste.MoonGlitchBackgroundTrigger.<GlitchRoutine>d__12", "<GlitchRoutine>d__12", assemblyIdentity,
                "Celeste", 33555343, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger.<GlitchRoutine>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger.<GlitchRoutine>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NoRefillTrigger", "Celeste.NoRefillTrigger", "NoRefillTrigger",
                assemblyIdentity, "Celeste", 33555344, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NoRefillTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NoRefillTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OshiroTrigger", "Celeste.OshiroTrigger", "OshiroTrigger",
                assemblyIdentity, "Celeste", 33555345, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OshiroTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OshiroTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StopBoostTrigger", "Celeste.StopBoostTrigger", "StopBoostTrigger",
                assemblyIdentity, "Celeste", 33555346, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StopBoostTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StopBoostTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameplayStats", "Celeste.GameplayStats", "GameplayStats",
                assemblyIdentity, "Celeste", 33555347, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameplayStats", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameplayStats",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeightDisplay", "Celeste.HeightDisplay", "HeightDisplay",
                assemblyIdentity, "Celeste", 33555348, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeightDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeightDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeightDisplay+<Routine>d__19",
                "Celeste.HeightDisplay.<Routine>d__19",
                "<Routine>d__19", assemblyIdentity, "Celeste", 33555349, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeightDisplay.<Routine>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeightDisplay.<Routine>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeightDisplay+<CameraUp>d__20",
                "Celeste.HeightDisplay.<CameraUp>d__20", "<CameraUp>d__20", assemblyIdentity, "Celeste", 33555350,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeightDisplay.<CameraUp>d__20", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeightDisplay.<CameraUp>d__20",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReturnMapHint", "Celeste.ReturnMapHint", "ReturnMapHint",
                assemblyIdentity, "Celeste", 33555351, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReturnMapHint", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReturnMapHint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.QuickResetHint", "Celeste.QuickResetHint", "QuickResetHint",
                assemblyIdentity, "Celeste", 33555352, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.QuickResetHint", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.QuickResetHint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AutoSplitterInfo", "Celeste.AutoSplitterInfo", "AutoSplitterInfo",
                assemblyIdentity, "Celeste", 33555353, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AutoSplitterInfo", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AutoSplitterInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG", "Celeste.BlackholeBG", "BlackholeBG",
                assemblyIdentity,
                "Celeste", 33555354, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+Strengths", "Celeste.BlackholeBG.Strengths",
                "Strengths",
                assemblyIdentity, "Celeste", 33555355, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.Strengths", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.Strengths",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+StreamParticle", "Celeste.BlackholeBG.StreamParticle",
                "StreamParticle", assemblyIdentity, "Celeste", 33555356, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.StreamParticle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.StreamParticle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+Particle", "Celeste.BlackholeBG.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555357, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+SpiralDebris", "Celeste.BlackholeBG.SpiralDebris",
                "SpiralDebris", assemblyIdentity, "Celeste", 33555358, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.SpiralDebris", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.SpiralDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Planets", "Celeste.Planets", "Planets", assemblyIdentity,
                "Celeste",
                33555359, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Planets", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Planets",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Planets+Planet", "Celeste.Planets.Planet", "Planet",
                assemblyIdentity,
                "Celeste", 33555360, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Planets.Planet", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Planets.Planet",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RainFG", "Celeste.RainFG", "RainFG", assemblyIdentity, "Celeste",
                33555361, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RainFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.RainFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RainFG+Particle", "Celeste.RainFG.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555362, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RainFG.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RainFG.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StardustFG", "Celeste.StardustFG", "StardustFG", assemblyIdentity,
                "Celeste", 33555363, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StardustFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StardustFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StardustFG+Particle", "Celeste.StardustFG.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555364, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StardustFG.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StardustFG.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Starfield", "Celeste.Starfield", "Starfield", assemblyIdentity,
                "Celeste", 33555365, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Starfield", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Starfield",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Starfield+Star", "Celeste.Starfield.Star", "Star",
                assemblyIdentity,
                "Celeste", 33555366, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Starfield.Star", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Starfield.Star",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisperseImage", "Celeste.DisperseImage", "DisperseImage",
                assemblyIdentity, "Celeste", 33555367, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisperseImage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisperseImage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisperseImage+Particle", "Celeste.DisperseImage.Particle",
                "Particle",
                assemblyIdentity, "Celeste", 33555368, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisperseImage.Particle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisperseImage.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlockBg", "Celeste.GlassBlockBg", "GlassBlockBg",
                assemblyIdentity, "Celeste", 33555369, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlockBg", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlockBg",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlockBg+Star", "Celeste.GlassBlockBg.Star", "Star",
                assemblyIdentity, "Celeste", 33555370, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlockBg.Star", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlockBg.Star",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlockBg+Ray", "Celeste.GlassBlockBg.Ray", "Ray",
                assemblyIdentity, "Celeste", 33555371, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlockBg.Ray", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlockBg.Ray",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer", "Celeste.LightningRenderer",
                "LightningRenderer",
                assemblyIdentity, "Celeste", 33555372, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer+Bolt", "Celeste.LightningRenderer.Bolt", "Bolt",
                assemblyIdentity, "Celeste", 33555373, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer.Bolt", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer.Bolt",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer+Bolt+<Run>d__14",
                "Celeste.LightningRenderer.Bolt.<Run>d__14", "<Run>d__14", assemblyIdentity, "Celeste", 33555374, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer.Bolt.<Run>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer.Bolt.<Run>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer+Edge", "Celeste.LightningRenderer.Edge", "Edge",
                assemblyIdentity, "Celeste", 33555375, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer.Edge", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer.Edge",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningStrike", "Celeste.LightningStrike", "LightningStrike",
                assemblyIdentity, "Celeste", 33555376, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningStrike", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningStrike",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningStrike+Node", "Celeste.LightningStrike.Node", "Node",
                assemblyIdentity, "Celeste", 33555377, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningStrike.Node", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningStrike.Node",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningStrike+<Routine>d__7",
                "Celeste.LightningStrike.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33555378, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningStrike.<Routine>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningStrike.<Routine>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrierRenderer", "Celeste.SeekerBarrierRenderer",
                "SeekerBarrierRenderer", assemblyIdentity, "Celeste", 33555379, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrierRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrierRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrierRenderer+Edge", "Celeste.SeekerBarrierRenderer.Edge",
                "Edge", assemblyIdentity, "Celeste", 33555380, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrierRenderer.Edge", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrierRenderer.Edge",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.InputMappingInfo", "Celeste.InputMappingInfo", "InputMappingInfo",
                assemblyIdentity, "Celeste", 33555381, false, ["Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.InputMappingInfo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.InputMappingInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ButtonConfigUI", "Celeste.ButtonConfigUI", "ButtonConfigUI",
                assemblyIdentity, "Celeste", 33555382, false,
                [
                    "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ButtonConfigUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ButtonConfigUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ButtonConfigUI+<>c__DisplayClass14_0",
                "Celeste.ButtonConfigUI.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
                33555383, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ButtonConfigUI.<>c__DisplayClass14_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ButtonConfigUI.<>c__DisplayClass14_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ButtonConfigUI+<>c__DisplayClass16_0",
                "Celeste.ButtonConfigUI.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity, "Celeste",
                33555384, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ButtonConfigUI.<>c__DisplayClass16_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ButtonConfigUI.<>c__DisplayClass16_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ButtonConfigUI+<>c__DisplayClass24_0",
                "Celeste.ButtonConfigUI.<>c__DisplayClass24_0", "<>c__DisplayClass24_0", assemblyIdentity, "Celeste",
                33555385, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ButtonConfigUI.<>c__DisplayClass24_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ButtonConfigUI.<>c__DisplayClass24_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LanguageSelectUI", "Celeste.LanguageSelectUI", "LanguageSelectUI",
                assemblyIdentity, "Celeste", 33555386, false,
                [
                    "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LanguageSelectUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.LanguageSelectUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LanguageSelectUI+LanguageOption",
                "Celeste.LanguageSelectUI.LanguageOption", "LanguageOption", assemblyIdentity, "Celeste", 33555387,
                false,
                ["Celeste.TextMenu+Item", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LanguageSelectUI.LanguageOption", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LanguageSelectUI.LanguageOption",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LanguageSelectUI+<>c__DisplayClass1_0",
                "Celeste.LanguageSelectUI.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste",
                33555388, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LanguageSelectUI.<>c__DisplayClass1_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.LanguageSelectUI.<>c__DisplayClass1_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PrologueEndingText", "Celeste.PrologueEndingText",
                "PrologueEndingText", assemblyIdentity, "Celeste", 33555389, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PrologueEndingText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PrologueEndingText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PrologueEndingText+<Routine>d__2",
                "Celeste.PrologueEndingText.<Routine>d__2", "<Routine>d__2", assemblyIdentity, "Celeste", 33555390,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PrologueEndingText.<Routine>d__2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PrologueEndingText.<Routine>d__2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockedPico8Message", "Celeste.UnlockedPico8Message",
                "UnlockedPico8Message", assemblyIdentity, "Celeste", 33555391, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockedPico8Message", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedPico8Message",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockedPico8Message+<Routine>d__7",
                "Celeste.UnlockedPico8Message.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33555392,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockedPico8Message.<Routine>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedPico8Message.<Routine>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockedRemixDisplay", "Celeste.UnlockedRemixDisplay",
                "UnlockedRemixDisplay", assemblyIdentity, "Celeste", 33555393, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockedRemixDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedRemixDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockedRemixDisplay+<DisplayRoutine>d__17",
                "Celeste.UnlockedRemixDisplay.<DisplayRoutine>d__17", "<DisplayRoutine>d__17", assemblyIdentity,
                "Celeste",
                33555394, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockedRemixDisplay.<DisplayRoutine>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedRemixDisplay.<DisplayRoutine>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SoundEmitter", "Celeste.SoundEmitter", "SoundEmitter",
                assemblyIdentity, "Celeste", 33555395, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SoundEmitter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SoundEmitter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame", "Celeste.BreathingMinigame",
                "BreathingMinigame",
                assemblyIdentity, "Celeste", 33555396, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+Particle", "Celeste.BreathingMinigame.Particle",
                "Particle", assemblyIdentity, "Celeste", 33555397, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<Routine>d__56",
                "Celeste.BreathingMinigame.<Routine>d__56", "<Routine>d__56", assemblyIdentity, "Celeste", 33555398,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<Routine>d__56", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<Routine>d__56",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<ShowText>d__57",
                "Celeste.BreathingMinigame.<ShowText>d__57", "<ShowText>d__57", assemblyIdentity, "Celeste", 33555399,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<ShowText>d__57", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<ShowText>d__57",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<FadeGameIn>d__58",
                "Celeste.BreathingMinigame.<FadeGameIn>d__58", "<FadeGameIn>d__58", assemblyIdentity, "Celeste",
                33555400,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<FadeGameIn>d__58", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<FadeGameIn>d__58",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<FadeBoxIn>d__59",
                "Celeste.BreathingMinigame.<FadeBoxIn>d__59", "<FadeBoxIn>d__59", assemblyIdentity, "Celeste", 33555401,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<FadeBoxIn>d__59", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<FadeBoxIn>d__59",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<FadeTextTo>d__60",
                "Celeste.BreathingMinigame.<FadeTextTo>d__60", "<FadeTextTo>d__60", assemblyIdentity, "Celeste",
                33555402,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<FadeTextTo>d__60", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<FadeTextTo>d__60",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<PopFeather>d__61",
                "Celeste.BreathingMinigame.<PopFeather>d__61", "<PopFeather>d__61", assemblyIdentity, "Celeste",
                33555403,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<PopFeather>d__61", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<PopFeather>d__61",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Plateau", "Celeste.Plateau", "Plateau", assemblyIdentity,
                "Celeste",
                33555404, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Plateau", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Plateau",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball", "Celeste.TempleBigEyeball", "TempleBigEyeball",
                assemblyIdentity, "Celeste", 33555405, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+Fader", "Celeste.TempleBigEyeball.Fader",
                "Fader",
                assemblyIdentity, "Celeste", 33555406, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.Fader", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.Fader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+<>c", "Celeste.TempleBigEyeball.<>c", "<>c",
                assemblyIdentity, "Celeste", 33555407, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+<>c__DisplayClass14_0",
                "Celeste.TempleBigEyeball.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
                33555408, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.<>c__DisplayClass14_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.<>c__DisplayClass14_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+<Burst>d__14",
                "Celeste.TempleBigEyeball.<Burst>d__14", "<Burst>d__14", assemblyIdentity, "Celeste", 33555409, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.<Burst>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.<Burst>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker", "Celeste.PlayerSeeker", "PlayerSeeker",
                assemblyIdentity, "Celeste", 33555410, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker+<>c__DisplayClass11_0",
                "Celeste.PlayerSeeker.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity, "Celeste",
                33555411, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker.<>c__DisplayClass11_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker.<>c__DisplayClass11_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker+<IntroSequence>d__11",
                "Celeste.PlayerSeeker.<IntroSequence>d__11", "<IntroSequence>d__11", assemblyIdentity, "Celeste",
                33555412,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker.<IntroSequence>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker.<IntroSequence>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker+<>c__DisplayClass14_0",
                "Celeste.PlayerSeeker.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
                33555413, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker.<>c__DisplayClass14_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker.<>c__DisplayClass14_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionHeartStatue", "Celeste.ReflectionHeartStatue",
                "ReflectionHeartStatue", assemblyIdentity, "Celeste", 33555414, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionHeartStatue", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionHeartStatue",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionHeartStatue+Torch",
                "Celeste.ReflectionHeartStatue.Torch",
                "Torch", assemblyIdentity, "Celeste", 33555415, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionHeartStatue.Torch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionHeartStatue.Torch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionHeartStatue+<ActivateRoutine>d__14",
                "Celeste.ReflectionHeartStatue.<ActivateRoutine>d__14", "<ActivateRoutine>d__14", assemblyIdentity,
                "Celeste", 33555416, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionHeartStatue.<ActivateRoutine>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionHeartStatue.<ActivateRoutine>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleEndingMusicHandler", "Celeste.TempleEndingMusicHandler",
                "TempleEndingMusicHandler", assemblyIdentity, "Celeste", 33555417, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleEndingMusicHandler", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleEndingMusicHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystalPedestal", "Celeste.TheoCrystalPedestal",
                "TheoCrystalPedestal", assemblyIdentity, "Celeste", 33555418, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystalPedestal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystalPedestal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MiniTextboxTrigger", "Celeste.MiniTextboxTrigger",
                "MiniTextboxTrigger", assemblyIdentity, "Celeste", 33555419, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MiniTextboxTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextboxTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MiniTextboxTrigger+Modes", "Celeste.MiniTextboxTrigger.Modes",
                "Modes", assemblyIdentity, "Celeste", 33555420, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MiniTextboxTrigger.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextboxTrigger.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MiniTextbox", "Celeste.MiniTextbox", "MiniTextbox",
                assemblyIdentity,
                "Celeste", 33555421, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MiniTextbox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextbox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MiniTextbox+<Routine>d__18", "Celeste.MiniTextbox.<Routine>d__18",
                "<Routine>d__18", assemblyIdentity, "Celeste", 33555422, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MiniTextbox.<Routine>d__18", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextbox.<Routine>d__18",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MiniTextbox+<Close>d__19", "Celeste.MiniTextbox.<Close>d__19",
                "<Close>d__19", assemblyIdentity, "Celeste", 33555423, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MiniTextbox.<Close>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextbox.<Close>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTilesBank", "Celeste.AnimatedTilesBank",
                "AnimatedTilesBank",
                assemblyIdentity, "Celeste", 33555424, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTilesBank", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTilesBank",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTilesBank+Animation",
                "Celeste.AnimatedTilesBank.Animation",
                "Animation", assemblyIdentity, "Celeste", 33555425, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTilesBank.Animation", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTilesBank.Animation",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTiles", "Celeste.AnimatedTiles", "AnimatedTiles",
                assemblyIdentity, "Celeste", 33555426, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTiles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTiles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTiles+Tile", "Celeste.AnimatedTiles.Tile", "Tile",
                assemblyIdentity, "Celeste", 33555427, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTiles.Tile", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTiles.Tile",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FinalBossStarfield", "Celeste.FinalBossStarfield",
                "FinalBossStarfield", assemblyIdentity, "Celeste", 33555428, false,
                ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FinalBossStarfield", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossStarfield",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FinalBossStarfield+Particle",
                "Celeste.FinalBossStarfield.Particle",
                "Particle", assemblyIdentity, "Celeste", 33555429, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FinalBossStarfield.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossStarfield.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Godrays", "Celeste.Godrays", "Godrays", assemblyIdentity,
                "Celeste",
                33555430, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Godrays", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Godrays",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Godrays+Ray", "Celeste.Godrays.Ray", "Ray", assemblyIdentity,
                "Celeste", 33555431, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Godrays.Ray", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Godrays.Ray",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeatWave", "Celeste.HeatWave", "HeatWave", assemblyIdentity,
                "Celeste", 33555432, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeatWave", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeatWave",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeatWave+Particle", "Celeste.HeatWave.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555433, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeatWave.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeatWave.Particle",
                []);
        }
    }
}
