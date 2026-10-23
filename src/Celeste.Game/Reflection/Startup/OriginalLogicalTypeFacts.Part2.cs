using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static partial class OriginalLogicalTypeFacts
    {
        private static void RegisterPart2(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_Ending", "Celeste.CS06_Ending", "CS06_Ending",
                assemblyIdentity,
                "Celeste", 33554834, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_Campfire", "Celeste.CS06_Campfire", "CS06_Campfire",
                assemblyIdentity, "Celeste", 33554835, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_Campfire", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Campfire",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_BossIntro", "Celeste.CS06_BossIntro", "CS06_BossIntro",
                assemblyIdentity, "Celeste", 33554836, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_BossIntro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_BossIntro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_Granny", "Celeste.CS06_Granny", "CS06_Granny",
                assemblyIdentity,
                "Celeste", 33554837, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_Granny", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Granny",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_BossEnd", "Celeste.CS06_BossEnd", "CS06_BossEnd",
                assemblyIdentity, "Celeste", 33554838, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_BossEnd", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_BossEnd",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BladeRotateSpinner", "Celeste.BladeRotateSpinner",
                "BladeRotateSpinner", assemblyIdentity, "Celeste", 33554839, false,
                [
                    "Celeste.RotateSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BladeRotateSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BladeRotateSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RotateSpinner", "Celeste.RotateSpinner", "RotateSpinner",
                assemblyIdentity, "Celeste", 33554840, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RotateSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RotateSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerStatue", "Celeste.SeekerStatue", "SeekerStatue",
                assemblyIdentity, "Celeste", 33554841, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerStatue", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerStatue",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrystalColor", "Celeste.CrystalColor", "CrystalColor",
                assemblyIdentity, "Celeste", 33554842, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrystalColor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrystalColor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrystalStaticSpinner", "Celeste.CrystalStaticSpinner",
                "CrystalStaticSpinner", assemblyIdentity, "Celeste", 33554843, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrystalStaticSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrystalStaticSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TrackSpinner", "Celeste.TrackSpinner", "TrackSpinner",
                assemblyIdentity, "Celeste", 33554844, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TrackSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TrackSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FinalBoss", "Celeste.FinalBoss", "FinalBoss", assemblyIdentity,
                "Celeste", 33554845, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FinalBoss", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FinalBoss",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FinalBossBeam", "Celeste.FinalBossBeam", "FinalBossBeam",
                assemblyIdentity, "Celeste", 33554846, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FinalBossBeam", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossBeam",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FinalBossMovingBlock", "Celeste.FinalBossMovingBlock",
                "FinalBossMovingBlock", assemblyIdentity, "Celeste", 33554847, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FinalBossMovingBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossMovingBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FinalBossShot", "Celeste.FinalBossShot", "FinalBossShot",
                assemblyIdentity, "Celeste", 33554848, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FinalBossShot", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossShot",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BladeTrackSpinner", "Celeste.BladeTrackSpinner",
                "BladeTrackSpinner",
                assemblyIdentity, "Celeste", 33554849, false,
                [
                    "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BladeTrackSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BladeTrackSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying", "Celeste.NPC06_Badeline_Crying",
                "NPC06_Badeline_Crying", assemblyIdentity, "Celeste", 33554850, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Granny_Ending", "Celeste.NPC06_Granny_Ending",
                "NPC06_Granny_Ending", assemblyIdentity, "Celeste", 33554851, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Granny_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Granny_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Granny", "Celeste.NPC06_Granny", "NPC06_Granny",
                assemblyIdentity, "Celeste", 33554852, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Granny", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Granny",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Theo_Ending", "Celeste.NPC06_Theo_Ending",
                "NPC06_Theo_Ending",
                assemblyIdentity, "Celeste", 33554853, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Theo_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Theo_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Theo_Plateau", "Celeste.NPC06_Theo_Plateau",
                "NPC06_Theo_Plateau", assemblyIdentity, "Celeste", 33554854, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Theo_Plateau", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Theo_Plateau",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreModeToggle", "Celeste.CoreModeToggle", "CoreModeToggle",
                assemblyIdentity, "Celeste", 33554855, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreModeToggle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreModeToggle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FlingBird", "Celeste.FlingBird", "FlingBird", assemblyIdentity,
                "Celeste", 33554856, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FlingBird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Puffer", "Celeste.Puffer", "Puffer", assemblyIdentity, "Celeste",
                33554857, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Puffer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Puffer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FlyFeather", "Celeste.FlyFeather", "FlyFeather", assemblyIdentity,
                "Celeste", 33554858, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FlyFeather", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FlyFeather",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FakeHeart", "Celeste.FakeHeart", "FakeHeart", assemblyIdentity,
                "Celeste", 33554859, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FakeHeart", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FakeHeart",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Glider", "Celeste.Glider", "Glider", assemblyIdentity, "Celeste",
                33554860, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Glider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Glider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpaceController", "Celeste.SpaceController", "SpaceController",
                assemblyIdentity, "Celeste", 33554861, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpaceController", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpaceController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WallBooster", "Celeste.WallBooster", "WallBooster",
                assemblyIdentity,
                "Celeste", 33554862, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WallBooster", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WallBooster",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerPlayback", "Celeste.PlayerPlayback", "PlayerPlayback",
                assemblyIdentity, "Celeste", 33554863, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerPlayback", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerPlayback",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AbsorbOrb", "Celeste.AbsorbOrb", "AbsorbOrb", assemblyIdentity,
                "Celeste", 33554864, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AbsorbOrb", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AbsorbOrb",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BigWaterfall", "Celeste.BigWaterfall", "BigWaterfall",
                assemblyIdentity, "Celeste", 33554865, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BigWaterfall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BigWaterfall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CliffsideWindFlag", "Celeste.CliffsideWindFlag",
                "CliffsideWindFlag",
                assemblyIdentity, "Celeste", 33554866, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CliffsideWindFlag", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CliffsideWindFlag",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrystalDebris", "Celeste.CrystalDebris", "CrystalDebris",
                assemblyIdentity, "Celeste", 33554867, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrystalDebris", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrystalDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallEffects", "Celeste.FallEffects", "FallEffects",
                assemblyIdentity,
                "Celeste", 33554868, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallEffects", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallEffects",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonCreature", "Celeste.MoonCreature", "MoonCreature",
                assemblyIdentity, "Celeste", 33554869, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonCreature", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonCreature",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SoundSourceEntity", "Celeste.SoundSourceEntity",
                "SoundSourceEntity",
                assemblyIdentity, "Celeste", 33554870, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SoundSourceEntity", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SoundSourceEntity",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitCloud", "Celeste.SummitCloud", "SummitCloud",
                assemblyIdentity,
                "Celeste", 33554871, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitCloud", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitCloud",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleEye", "Celeste.TempleEye", "TempleEye", assemblyIdentity,
                "Celeste", 33554872, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleEye", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleEye",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TemplePortalTorch", "Celeste.TemplePortalTorch",
                "TemplePortalTorch",
                assemblyIdentity, "Celeste", 33554873, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TemplePortalTorch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TemplePortalTorch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnableAttribute", "Celeste.SpawnableAttribute",
                "SpawnableAttribute", assemblyIdentity, "Celeste", 33554874, false, ["System.Attribute"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnableAttribute", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnableAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnerAttribute", "Celeste.SpawnerAttribute", "SpawnerAttribute",
                assemblyIdentity, "Celeste", 33554875, false, ["System.Attribute"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnerAttribute", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnerAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Spawn", "Celeste.Spawn", "Spawn", assemblyIdentity, "Celeste",
                33554876, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Spawn", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Spawn",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnManager", "Celeste.SpawnManager", "SpawnManager",
                assemblyIdentity, "Celeste", 33554877, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BackgroundFadeIn", "Celeste.BackgroundFadeIn", "BackgroundFadeIn",
                assemblyIdentity, "Celeste", 33554878, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BackgroundFadeIn", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BackgroundFadeIn",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingRumbler", "Celeste.BreathingRumbler", "BreathingRumbler",
                assemblyIdentity, "Celeste", 33554879, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingRumbler", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingRumbler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BridgeFixed", "Celeste.BridgeFixed", "BridgeFixed",
                assemblyIdentity,
                "Celeste", 33554880, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BridgeFixed", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BridgeFixed",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreMessage", "Celeste.CoreMessage", "CoreMessage",
                assemblyIdentity,
                "Celeste", 33554881, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreMessage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreMessage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor", "Celeste.HeartGemDoor", "HeartGemDoor",
                assemblyIdentity, "Celeste", 33554882, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KevinsPC", "Celeste.KevinsPC", "KevinsPC", assemblyIdentity,
                "Celeste", 33554883, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KevinsPC", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.KevinsPC",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelUpEffect", "Celeste.LevelUpEffect", "LevelUpEffect",
                assemblyIdentity, "Celeste", 33554884, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelUpEffect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelUpEffect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OshiroLobbyBell", "Celeste.OshiroLobbyBell", "OshiroLobbyBell",
                assemblyIdentity, "Celeste", 33554885, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OshiroLobbyBell", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OshiroLobbyBell",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionTentacles", "Celeste.ReflectionTentacles",
                "ReflectionTentacles", assemblyIdentity, "Celeste", 33554886, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionTentacles", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionTentacles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RidgeGate", "Celeste.RidgeGate", "RidgeGate", assemblyIdentity,
                "Celeste", 33554887, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RidgeGate", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RidgeGate",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarJumpController", "Celeste.StarJumpController",
                "StarJumpController", assemblyIdentity, "Celeste", 33554888, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarJumpController", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarJumpBlock", "Celeste.StarJumpBlock", "StarJumpBlock",
                assemblyIdentity, "Celeste", 33554889, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarJumpBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AscendManager", "Celeste.AscendManager", "AscendManager",
                assemblyIdentity, "Celeste", 33554890, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AscendManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint", "Celeste.SummitCheckpoint", "SummitCheckpoint",
                assemblyIdentity, "Celeste", 33554891, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGemManager", "Celeste.SummitGemManager", "SummitGemManager",
                assemblyIdentity, "Celeste", 33554892, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGemManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGemManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoPhone", "Celeste.TheoPhone", "TheoPhone", assemblyIdentity,
                "Celeste", 33554893, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoPhone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoPhone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockEverythingThingy", "Celeste.UnlockEverythingThingy",
                "UnlockEverythingThingy", assemblyIdentity, "Celeste", 33554894, false,
                [
                    "Monocle.CheatListener", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockEverythingThingy", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockEverythingThingy",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdPathTrigger", "Celeste.BirdPathTrigger", "BirdPathTrigger",
                assemblyIdentity, "Celeste", 33554895, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdPathTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdPathTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeStrengthTrigger", "Celeste.BlackholeStrengthTrigger",
                "BlackholeStrengthTrigger", assemblyIdentity, "Celeste", 33554896, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeStrengthTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeStrengthTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger", "Celeste.DetachStrawberryTrigger",
                "DetachStrawberryTrigger", assemblyIdentity, "Celeste", 33554897, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleTrigger", "Celeste.RumbleTrigger", "RumbleTrigger",
                assemblyIdentity, "Celeste", 33554898, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpawnFacingTrigger", "Celeste.SpawnFacingTrigger",
                "SpawnFacingTrigger", assemblyIdentity, "Celeste", 33554899, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpawnFacingTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpawnFacingTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GrabbyIcon", "Celeste.GrabbyIcon", "GrabbyIcon", assemblyIdentity,
                "Celeste", 33554900, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GrabbyIcon", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GrabbyIcon",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage03", "Celeste.WaveDashPage03", "WaveDashPage03",
                assemblyIdentity, "Celeste", 33554901, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage03", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage03",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05", "Celeste.WaveDashPage05", "WaveDashPage05",
                assemblyIdentity, "Celeste", 33554902, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage04", "Celeste.WaveDashPage04", "WaveDashPage04",
                assemblyIdentity, "Celeste", 33554903, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage04", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage04",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage06", "Celeste.WaveDashPage06", "WaveDashPage06",
                assemblyIdentity, "Celeste", 33554904, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage06", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage06",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02", "Celeste.WaveDashPage02", "WaveDashPage02",
                assemblyIdentity, "Celeste", 33554905, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage01", "Celeste.WaveDashPage01", "WaveDashPage01",
                assemblyIdentity, "Celeste", 33554906, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage01", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage01",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage00", "Celeste.WaveDashPage00", "WaveDashPage00",
                assemblyIdentity, "Celeste", 33554907, false, ["Celeste.WaveDashPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage00", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage00",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage", "Celeste.WaveDashPage", "WaveDashPage",
                assemblyIdentity, "Celeste", 33554908, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPlaybackTutorial", "Celeste.WaveDashPlaybackTutorial",
                "WaveDashPlaybackTutorial", assemblyIdentity, "Celeste", 33554909, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPlaybackTutorial", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPlaybackTutorial",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPresentation", "Celeste.WaveDashPresentation",
                "WaveDashPresentation", assemblyIdentity, "Celeste", 33554910, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPresentation", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPresentation",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaveDashTutorialMachine", "Celeste.WaveDashTutorialMachine",
                "WaveDashTutorialMachine", assemblyIdentity, "Celeste", 33554911, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaveDashTutorialMachine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashTutorialMachine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpeedRing", "Celeste.SpeedRing", "SpeedRing", assemblyIdentity,
                "Celeste", 33554912, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpeedRing", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpeedRing",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AmbienceParamTrigger", "Celeste.AmbienceParamTrigger",
                "AmbienceParamTrigger", assemblyIdentity, "Celeste", 33554913, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AmbienceParamTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AmbienceParamTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CameraAdvanceTargetTrigger", "Celeste.CameraAdvanceTargetTrigger",
                "CameraAdvanceTargetTrigger", assemblyIdentity, "Celeste", 33554914, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CameraAdvanceTargetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CameraAdvanceTargetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CheckpointBlockerTrigger", "Celeste.CheckpointBlockerTrigger",
                "CheckpointBlockerTrigger", assemblyIdentity, "Celeste", 33554915, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CheckpointBlockerTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CheckpointBlockerTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CreditsTrigger", "Celeste.CreditsTrigger", "CreditsTrigger",
                assemblyIdentity, "Celeste", 33554916, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CreditsTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CreditsTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GoldBerryCollectTrigger", "Celeste.GoldBerryCollectTrigger",
                "GoldBerryCollectTrigger", assemblyIdentity, "Celeste", 33554917, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GoldBerryCollectTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GoldBerryCollectTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.InteractTrigger", "Celeste.InteractTrigger", "InteractTrigger",
                assemblyIdentity, "Celeste", 33554918, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.InteractTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.InteractTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LookoutBlocker", "Celeste.LookoutBlocker", "LookoutBlocker",
                assemblyIdentity, "Celeste", 33554919, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LookoutBlocker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LookoutBlocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger",
                "Celeste.MoonGlitchBackgroundTrigger",
                "MoonGlitchBackgroundTrigger", assemblyIdentity, "Celeste", 33554920, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NoRefillTrigger", "Celeste.NoRefillTrigger", "NoRefillTrigger",
                assemblyIdentity, "Celeste", 33554921, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NoRefillTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NoRefillTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OshiroTrigger", "Celeste.OshiroTrigger", "OshiroTrigger",
                assemblyIdentity, "Celeste", 33554922, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OshiroTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OshiroTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StopBoostTrigger", "Celeste.StopBoostTrigger", "StopBoostTrigger",
                assemblyIdentity, "Celeste", 33554923, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StopBoostTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StopBoostTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameplayStats", "Celeste.GameplayStats", "GameplayStats",
                assemblyIdentity, "Celeste", 33554924, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameplayStats", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameplayStats",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeightDisplay", "Celeste.HeightDisplay", "HeightDisplay",
                assemblyIdentity, "Celeste", 33554925, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeightDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeightDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReturnMapHint", "Celeste.ReturnMapHint", "ReturnMapHint",
                assemblyIdentity, "Celeste", 33554926, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReturnMapHint", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReturnMapHint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.QuickResetHint", "Celeste.QuickResetHint", "QuickResetHint",
                assemblyIdentity, "Celeste", 33554927, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.QuickResetHint", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.QuickResetHint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AutoSplitterInfo", "Celeste.AutoSplitterInfo", "AutoSplitterInfo",
                assemblyIdentity, "Celeste", 33554928, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AutoSplitterInfo", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AutoSplitterInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG", "Celeste.BlackholeBG", "BlackholeBG",
                assemblyIdentity,
                "Celeste", 33554929, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Planets", "Celeste.Planets", "Planets", assemblyIdentity,
                "Celeste",
                33554930, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Planets", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Planets",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RainFG", "Celeste.RainFG", "RainFG", assemblyIdentity, "Celeste",
                33554931, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RainFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.RainFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StardustFG", "Celeste.StardustFG", "StardustFG", assemblyIdentity,
                "Celeste", 33554932, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StardustFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StardustFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Starfield", "Celeste.Starfield", "Starfield", assemblyIdentity,
                "Celeste", 33554933, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Starfield", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Starfield",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisperseImage", "Celeste.DisperseImage", "DisperseImage",
                assemblyIdentity, "Celeste", 33554934, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisperseImage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisperseImage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlockBg", "Celeste.GlassBlockBg", "GlassBlockBg",
                assemblyIdentity, "Celeste", 33554935, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlockBg", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlockBg",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer", "Celeste.LightningRenderer",
                "LightningRenderer",
                assemblyIdentity, "Celeste", 33554936, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningStrike", "Celeste.LightningStrike", "LightningStrike",
                assemblyIdentity, "Celeste", 33554937, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningStrike", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningStrike",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrierRenderer", "Celeste.SeekerBarrierRenderer",
                "SeekerBarrierRenderer", assemblyIdentity, "Celeste", 33554938, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrierRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrierRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.InputMappingInfo", "Celeste.InputMappingInfo", "InputMappingInfo",
                assemblyIdentity, "Celeste", 33554939, false, ["Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.InputMappingInfo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.InputMappingInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ButtonConfigUI", "Celeste.ButtonConfigUI", "ButtonConfigUI",
                assemblyIdentity, "Celeste", 33554940, false,
                [
                    "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ButtonConfigUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ButtonConfigUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LanguageSelectUI", "Celeste.LanguageSelectUI", "LanguageSelectUI",
                assemblyIdentity, "Celeste", 33554941, false,
                [
                    "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LanguageSelectUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.LanguageSelectUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PrologueEndingText", "Celeste.PrologueEndingText",
                "PrologueEndingText", assemblyIdentity, "Celeste", 33554942, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PrologueEndingText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PrologueEndingText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockedPico8Message", "Celeste.UnlockedPico8Message",
                "UnlockedPico8Message", assemblyIdentity, "Celeste", 33554943, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockedPico8Message", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedPico8Message",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.UnlockedRemixDisplay", "Celeste.UnlockedRemixDisplay",
                "UnlockedRemixDisplay", assemblyIdentity, "Celeste", 33554944, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.UnlockedRemixDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedRemixDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SoundEmitter", "Celeste.SoundEmitter", "SoundEmitter",
                assemblyIdentity, "Celeste", 33554945, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SoundEmitter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SoundEmitter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame", "Celeste.BreathingMinigame",
                "BreathingMinigame",
                assemblyIdentity, "Celeste", 33554946, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Plateau", "Celeste.Plateau", "Plateau", assemblyIdentity,
                "Celeste",
                33554947, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Plateau", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Plateau",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball", "Celeste.TempleBigEyeball", "TempleBigEyeball",
                assemblyIdentity, "Celeste", 33554948, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker", "Celeste.PlayerSeeker", "PlayerSeeker",
                assemblyIdentity, "Celeste", 33554949, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionHeartStatue", "Celeste.ReflectionHeartStatue",
                "ReflectionHeartStatue", assemblyIdentity, "Celeste", 33554950, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionHeartStatue", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionHeartStatue",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleEndingMusicHandler", "Celeste.TempleEndingMusicHandler",
                "TempleEndingMusicHandler", assemblyIdentity, "Celeste", 33554951, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleEndingMusicHandler", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleEndingMusicHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystalPedestal", "Celeste.TheoCrystalPedestal",
                "TheoCrystalPedestal", assemblyIdentity, "Celeste", 33554952, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystalPedestal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystalPedestal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MiniTextboxTrigger", "Celeste.MiniTextboxTrigger",
                "MiniTextboxTrigger", assemblyIdentity, "Celeste", 33554953, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MiniTextboxTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextboxTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MiniTextbox", "Celeste.MiniTextbox", "MiniTextbox",
                assemblyIdentity,
                "Celeste", 33554954, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MiniTextbox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextbox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTilesBank", "Celeste.AnimatedTilesBank",
                "AnimatedTilesBank",
                assemblyIdentity, "Celeste", 33554955, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTilesBank", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTilesBank",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTiles", "Celeste.AnimatedTiles", "AnimatedTiles",
                assemblyIdentity, "Celeste", 33554956, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTiles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTiles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FinalBossStarfield", "Celeste.FinalBossStarfield",
                "FinalBossStarfield", assemblyIdentity, "Celeste", 33554957, false,
                ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FinalBossStarfield", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossStarfield",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Godrays", "Celeste.Godrays", "Godrays", assemblyIdentity,
                "Celeste",
                33554958, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Godrays", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Godrays",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeatWave", "Celeste.HeatWave", "HeatWave", assemblyIdentity,
                "Celeste", 33554959, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeatWave", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeatWave",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights", "Celeste.NorthernLights", "NorthernLights",
                assemblyIdentity, "Celeste", 33554960, false, ["Celeste.Backdrop", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Petals", "Celeste.Petals", "Petals", assemblyIdentity, "Celeste",
                33554961, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Petals", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Petals",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreStarsFG", "Celeste.CoreStarsFG", "CoreStarsFG",
                assemblyIdentity,
                "Celeste", 33554962, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreStarsFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreStarsFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionFG", "Celeste.ReflectionFG", "ReflectionFG",
                assemblyIdentity, "Celeste", 33554963, false, ["Celeste.Backdrop", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorFG", "Celeste.MirrorFG", "MirrorFG", assemblyIdentity,
                "Celeste", 33554964, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Tentacles", "Celeste.Tentacles", "Tentacles", assemblyIdentity,
                "Celeste", 33554965, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Tentacles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Tentacles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay", "Celeste.FileErrorOverlay", "FileErrorOverlay",
                assemblyIdentity, "Celeste", 33554966, false,
                [
                    "Celeste.Overlay", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overlay", "Celeste.Overlay", "Overlay", assemblyIdentity,
                "Celeste",
                33554967, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overlay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overlay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HiresRenderer", "Celeste.HiresRenderer", "HiresRenderer",
                assemblyIdentity, "Celeste", 33554968, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HiresRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HiresRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TrailManager", "Celeste.TrailManager", "TrailManager",
                assemblyIdentity, "Celeste", 33554969, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TrailManager", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TrailManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ButtonUI", "Celeste.ButtonUI", "ButtonUI", assemblyIdentity,
                "Celeste", 33554970, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ButtonUI", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ButtonUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits", "Celeste.Credits", "Credits", assemblyIdentity,
                "Celeste",
                33554971, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CustomSpriteEffect", "Celeste.CustomSpriteEffect",
                "CustomSpriteEffect", assemblyIdentity, "Celeste", 33554972, false,
                ["Microsoft.Xna.Framework.Graphics.Effect"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CustomSpriteEffect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CustomSpriteEffect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorReflection", "Celeste.MirrorReflection", "MirrorReflection",
                assemblyIdentity, "Celeste", 33554973, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorReflection", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorReflection",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HoldableCollider", "Celeste.HoldableCollider", "HoldableCollider",
                assemblyIdentity, "Celeste", 33554974, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HoldableCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HoldableCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SaveTheo", "Celeste.CS05_SaveTheo", "CS05_SaveTheo",
                assemblyIdentity, "Celeste", 33554975, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SaveTheo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SaveTheo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo", "Celeste.CS05_SeeTheo", "CS05_SeeTheo",
                assemblyIdentity, "Celeste", 33554976, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoInMirror", "Celeste.CS05_TheoInMirror",
                "CS05_TheoInMirror",
                assemblyIdentity, "Celeste", 33554977, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoInMirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoInMirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance", "Celeste.CS05_Entrance", "CS05_Entrance",
                assemblyIdentity, "Celeste", 33554978, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Slider", "Celeste.Slider", "Slider", assemblyIdentity, "Celeste",
                33554979, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Slider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Slider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline", "Celeste.NPC05_Badeline", "NPC05_Badeline",
                assemblyIdentity, "Celeste", 33554980, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Theo_Mirror", "Celeste.NPC05_Theo_Mirror",
                "NPC05_Theo_Mirror",
                assemblyIdentity, "Celeste", 33554981, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Theo_Mirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Theo_Mirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Theo_Entrance", "Celeste.NPC05_Theo_Entrance",
                "NPC05_Theo_Entrance", assemblyIdentity, "Celeste", 33554982, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Theo_Entrance", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Theo_Entrance",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleMirror", "Celeste.TempleMirror", "TempleMirror",
                assemblyIdentity, "Celeste", 33554983, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleMirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerEffectsController", "Celeste.SeekerEffectsController",
                "SeekerEffectsController", assemblyIdentity, "Celeste", 33554984, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerEffectsController", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerEffectsController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite", "Celeste.ForsakenCitySatellite",
                "ForsakenCitySatellite", assemblyIdentity, "Celeste", 33554985, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness", "Celeste.GondolaDarkness", "GondolaDarkness",
                assemblyIdentity, "Celeste", 33554986, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WhiteBlock", "Celeste.WhiteBlock", "WhiteBlock", assemblyIdentity,
                "Celeste", 33554987, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WhiteBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WhiteBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ChangeRespawnTrigger", "Celeste.ChangeRespawnTrigger",
                "ChangeRespawnTrigger", assemblyIdentity, "Celeste", 33554988, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ChangeRespawnTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ChangeRespawnTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustStyles", "Celeste.DustStyles", "DustStyles", assemblyIdentity,
                "Celeste", 33554989, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustStyles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustStyles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FormationBackdrop", "Celeste.FormationBackdrop",
                "FormationBackdrop",
                assemblyIdentity, "Celeste", 33554990, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FormationBackdrop", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FormationBackdrop",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorSurfaces", "Celeste.MirrorSurfaces", "MirrorSurfaces",
                assemblyIdentity, "Celeste", 33554991, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorSurfaces", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorSurfaces",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ObjModel", "Celeste.ObjModel", "ObjModel", assemblyIdentity,
                "Celeste", 33554992, false, ["System.Object", "System.IDisposable"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ObjModel", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ObjModel",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AutoSavingNotice", "Celeste.AutoSavingNotice", "AutoSavingNotice",
                assemblyIdentity, "Celeste", 33554993, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AutoSavingNotice", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AutoSavingNotice",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer", "Celeste.CompleteRenderer", "CompleteRenderer",
                assemblyIdentity, "Celeste", 33554994, false,
                ["Celeste.HiresRenderer", "System.IDisposable", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HiresSnow", "Celeste.HiresSnow", "HiresSnow", assemblyIdentity,
                "Celeste", 33554995, false, ["Monocle.Renderer", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HiresSnow", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HiresSnow",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KeyboardConfigUI", "Celeste.KeyboardConfigUI", "KeyboardConfigUI",
                assemblyIdentity, "Celeste", 33554996, false,
                [
                    "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KeyboardConfigUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.KeyboardConfigUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Postcard", "Celeste.Postcard", "Postcard", assemblyIdentity,
                "Celeste", 33554997, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Postcard", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Postcard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveLoadIcon", "Celeste.SaveLoadIcon", "SaveLoadIcon",
                assemblyIdentity, "Celeste", 33554998, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveLoadIcon", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveLoadIcon",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu", "Celeste.TextMenu", "TextMenu", assemblyIdentity,
                "Celeste", 33554999, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ViewportAdjustmentUI", "Celeste.ViewportAdjustmentUI",
                "ViewportAdjustmentUI", assemblyIdentity, "Celeste", 33555000, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ViewportAdjustmentUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ViewportAdjustmentUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartWipe", "Celeste.HeartWipe", "HeartWipe", assemblyIdentity,
                "Celeste", 33555001, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KeyDoorWipe", "Celeste.KeyDoorWipe", "KeyDoorWipe",
                assemblyIdentity,
                "Celeste", 33555002, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KeyDoorWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.KeyDoorWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallWipe", "Celeste.FallWipe", "FallWipe", assemblyIdentity,
                "Celeste", 33555003, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainWipe", "Celeste.MountainWipe", "MountainWipe",
                assemblyIdentity, "Celeste", 33555004, false,
                ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AngledWipe", "Celeste.AngledWipe", "AngledWipe", assemblyIdentity,
                "Celeste", 33555005, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AngledWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AngledWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DropWipe", "Celeste.DropWipe", "DropWipe", assemblyIdentity,
                "Celeste", 33555006, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DropWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DropWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightingRenderer", "Celeste.LightingRenderer", "LightingRenderer",
                assemblyIdentity, "Celeste", 33555007, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightingRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightingRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarfieldWipe", "Celeste.StarfieldWipe", "StarfieldWipe",
                assemblyIdentity, "Celeste", 33555008, false,
                ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarfieldWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarfieldWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OVR", "Celeste.OVR", "OVR", assemblyIdentity, "Celeste", 33555009,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OVR", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OVR",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewPostcard", "Celeste.PreviewPostcard", "PreviewPostcard",
                assemblyIdentity, "Celeste", 33555010, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewPostcard", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPostcard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewRecording", "Celeste.PreviewRecording", "PreviewRecording",
                assemblyIdentity, "Celeste", 33555011, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewRecording", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewRecording",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameLoader", "Celeste.GameLoader", "GameLoader", assemblyIdentity,
                "Celeste", 33555012, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameLoader", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IOverlayHandler", "Celeste.IOverlayHandler", "IOverlayHandler",
                assemblyIdentity, "Celeste", 33555013, true, [], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IOverlayHandler", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IOverlayHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Maddy3D", "Celeste.Maddy3D", "Maddy3D", assemblyIdentity,
                "Celeste",
                33555014, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Maddy3D", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Maddy3D",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonParticle3D", "Celeste.MoonParticle3D", "MoonParticle3D",
                assemblyIdentity, "Celeste", 33555015, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonParticle3D", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonParticle3D",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snow3D", "Celeste.Snow3D", "Snow3D", assemblyIdentity, "Celeste",
                33555016, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snow3D", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snow3D",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalGlobal", "Celeste.OuiJournalGlobal", "OuiJournalGlobal",
                assemblyIdentity, "Celeste", 33555017, false, ["Celeste.OuiJournalPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalGlobal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalGlobal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode", "Celeste.OuiAssistMode", "OuiAssistMode",
                assemblyIdentity, "Celeste", 33555018, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreVignette", "Celeste.CoreVignette", "CoreVignette",
                assemblyIdentity, "Celeste", 33555019, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreVignette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Achievement", "Celeste.Achievement", "Achievement",
                assemblyIdentity,
                "Celeste", 33555020, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Achievement", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Achievement",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Achievements", "Celeste.Achievements", "Achievements",
                assemblyIdentity, "Celeste", 33555021, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Achievements", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Achievements",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BinaryPacker", "Celeste.BinaryPacker", "BinaryPacker",
                assemblyIdentity, "Celeste", 33555022, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BinaryPacker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BinaryPacker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter", "Celeste.LevelEnter", "LevelEnter", assemblyIdentity,
                "Celeste", 33555023, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainCamera", "Celeste.MountainCamera", "MountainCamera",
                assemblyIdentity, "Celeste", 33555024, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainCamera", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainCamera",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainState", "Celeste.MountainState", "MountainState",
                assemblyIdentity, "Celeste", 33555025, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainState", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Skybox", "Celeste.Skybox", "Skybox", assemblyIdentity, "Celeste",
                33555026, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Skybox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Skybox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Ring", "Celeste.Ring", "Ring", assemblyIdentity, "Celeste",
                33555027,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Ring", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Ring",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainModel", "Celeste.MountainModel", "MountainModel",
                assemblyIdentity, "Celeste", 33555028, false, ["System.Object", "System.IDisposable"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainModel", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainModel",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OverworldLoader", "Celeste.OverworldLoader", "OverworldLoader",
                assemblyIdentity, "Celeste", 33555029, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OverworldLoader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OverworldLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OverworldReflectionsFall", "Celeste.OverworldReflectionsFall",
                "OverworldReflectionsFall", assemblyIdentity, "Celeste", 33555030, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OverworldReflectionsFall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OverworldReflectionsFall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalDeaths", "Celeste.OuiJournalDeaths", "OuiJournalDeaths",
                assemblyIdentity, "Celeste", 33555031, false, ["Celeste.OuiJournalPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalDeaths", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalDeaths",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TestBreathingGame", "Celeste.TestBreathingGame",
                "TestBreathingGame",
                assemblyIdentity, "Celeste", 33555032, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TestBreathingGame", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TestBreathingGame",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelExit", "Celeste.LevelExit", "LevelExit", assemblyIdentity,
                "Celeste", 33555033, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelExit", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelExit",
                []);
        }
    }
}
