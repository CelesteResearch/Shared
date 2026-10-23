using System;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup;

public static partial class OriginalLogicalTypeFacts
{
    private static void RegisterPart2(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_Ending", "Celeste.CS06_Ending", "CS06_Ending", assemblyIdentity,
            "Celeste", 33554834, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_Campfire", "Celeste.CS06_Campfire", "CS06_Campfire",
            assemblyIdentity, "Celeste", 33554835, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_Campfire", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Campfire",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_BossIntro", "Celeste.CS06_BossIntro", "CS06_BossIntro",
            assemblyIdentity, "Celeste", 33554836, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_BossIntro", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_BossIntro",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_Granny", "Celeste.CS06_Granny", "CS06_Granny", assemblyIdentity,
            "Celeste", 33554837, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_Granny", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Granny",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_BossEnd", "Celeste.CS06_BossEnd", "CS06_BossEnd",
            assemblyIdentity, "Celeste", 33554838, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_BossEnd", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_BossEnd",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BladeRotateSpinner", "Celeste.BladeRotateSpinner",
            "BladeRotateSpinner", assemblyIdentity, "Celeste", 33554839, false,
            new string[]
            {
                "Celeste.RotateSpinner", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BladeRotateSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BladeRotateSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RotateSpinner", "Celeste.RotateSpinner", "RotateSpinner",
            assemblyIdentity, "Celeste", 33554840, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RotateSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RotateSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SeekerStatue", "Celeste.SeekerStatue", "SeekerStatue",
            assemblyIdentity, "Celeste", 33554841, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SeekerStatue", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SeekerStatue",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CrystalColor", "Celeste.CrystalColor", "CrystalColor",
            assemblyIdentity, "Celeste", 33554842, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CrystalColor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CrystalColor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CrystalStaticSpinner", "Celeste.CrystalStaticSpinner",
            "CrystalStaticSpinner", assemblyIdentity, "Celeste", 33554843, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CrystalStaticSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CrystalStaticSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TrackSpinner", "Celeste.TrackSpinner", "TrackSpinner",
            assemblyIdentity, "Celeste", 33554844, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TrackSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TrackSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FinalBoss", "Celeste.FinalBoss", "FinalBoss", assemblyIdentity,
            "Celeste", 33554845, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FinalBoss", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FinalBoss",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FinalBossBeam", "Celeste.FinalBossBeam", "FinalBossBeam",
            assemblyIdentity, "Celeste", 33554846, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FinalBossBeam", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossBeam",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FinalBossMovingBlock", "Celeste.FinalBossMovingBlock",
            "FinalBossMovingBlock", assemblyIdentity, "Celeste", 33554847, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FinalBossMovingBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossMovingBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FinalBossShot", "Celeste.FinalBossShot", "FinalBossShot",
            assemblyIdentity, "Celeste", 33554848, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FinalBossShot", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossShot",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BladeTrackSpinner", "Celeste.BladeTrackSpinner", "BladeTrackSpinner",
            assemblyIdentity, "Celeste", 33554849, false,
            new string[]
            {
                "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BladeTrackSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BladeTrackSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying", "Celeste.NPC06_Badeline_Crying",
            "NPC06_Badeline_Crying", assemblyIdentity, "Celeste", 33554850, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Granny_Ending", "Celeste.NPC06_Granny_Ending",
            "NPC06_Granny_Ending", assemblyIdentity, "Celeste", 33554851, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Granny_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Granny_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Granny", "Celeste.NPC06_Granny", "NPC06_Granny",
            assemblyIdentity, "Celeste", 33554852, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Granny", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Granny",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Theo_Ending", "Celeste.NPC06_Theo_Ending", "NPC06_Theo_Ending",
            assemblyIdentity, "Celeste", 33554853, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Theo_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Theo_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Theo_Plateau", "Celeste.NPC06_Theo_Plateau",
            "NPC06_Theo_Plateau", assemblyIdentity, "Celeste", 33554854, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Theo_Plateau", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Theo_Plateau",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreModeToggle", "Celeste.CoreModeToggle", "CoreModeToggle",
            assemblyIdentity, "Celeste", 33554855, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreModeToggle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreModeToggle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBird", "Celeste.FlingBird", "FlingBird", assemblyIdentity,
            "Celeste", 33554856, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBird", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Puffer", "Celeste.Puffer", "Puffer", assemblyIdentity, "Celeste",
            33554857, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Puffer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Puffer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlyFeather", "Celeste.FlyFeather", "FlyFeather", assemblyIdentity,
            "Celeste", 33554858, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlyFeather", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlyFeather",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FakeHeart", "Celeste.FakeHeart", "FakeHeart", assemblyIdentity,
            "Celeste", 33554859, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FakeHeart", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FakeHeart",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Glider", "Celeste.Glider", "Glider", assemblyIdentity, "Celeste",
            33554860, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Glider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Glider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpaceController", "Celeste.SpaceController", "SpaceController",
            assemblyIdentity, "Celeste", 33554861, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpaceController", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpaceController",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WallBooster", "Celeste.WallBooster", "WallBooster", assemblyIdentity,
            "Celeste", 33554862, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WallBooster", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WallBooster",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerPlayback", "Celeste.PlayerPlayback", "PlayerPlayback",
            assemblyIdentity, "Celeste", 33554863, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerPlayback", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerPlayback",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AbsorbOrb", "Celeste.AbsorbOrb", "AbsorbOrb", assemblyIdentity,
            "Celeste", 33554864, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AbsorbOrb", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AbsorbOrb",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BigWaterfall", "Celeste.BigWaterfall", "BigWaterfall",
            assemblyIdentity, "Celeste", 33554865, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BigWaterfall", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BigWaterfall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CliffsideWindFlag", "Celeste.CliffsideWindFlag", "CliffsideWindFlag",
            assemblyIdentity, "Celeste", 33554866, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CliffsideWindFlag", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CliffsideWindFlag",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CrystalDebris", "Celeste.CrystalDebris", "CrystalDebris",
            assemblyIdentity, "Celeste", 33554867, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CrystalDebris", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CrystalDebris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FallEffects", "Celeste.FallEffects", "FallEffects", assemblyIdentity,
            "Celeste", 33554868, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FallEffects", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.FallEffects",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonCreature", "Celeste.MoonCreature", "MoonCreature",
            assemblyIdentity, "Celeste", 33554869, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonCreature", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonCreature",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SoundSourceEntity", "Celeste.SoundSourceEntity", "SoundSourceEntity",
            assemblyIdentity, "Celeste", 33554870, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SoundSourceEntity", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SoundSourceEntity",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitCloud", "Celeste.SummitCloud", "SummitCloud", assemblyIdentity,
            "Celeste", 33554871, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitCloud", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitCloud",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleEye", "Celeste.TempleEye", "TempleEye", assemblyIdentity,
            "Celeste", 33554872, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleEye", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleEye",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TemplePortalTorch", "Celeste.TemplePortalTorch", "TemplePortalTorch",
            assemblyIdentity, "Celeste", 33554873, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TemplePortalTorch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TemplePortalTorch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpawnableAttribute", "Celeste.SpawnableAttribute",
            "SpawnableAttribute", assemblyIdentity, "Celeste", 33554874, false, new string[] { "System.Attribute" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpawnableAttribute", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpawnableAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpawnerAttribute", "Celeste.SpawnerAttribute", "SpawnerAttribute",
            assemblyIdentity, "Celeste", 33554875, false, new string[] { "System.Attribute" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpawnerAttribute", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpawnerAttribute",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Spawn", "Celeste.Spawn", "Spawn", assemblyIdentity, "Celeste",
            33554876, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Spawn", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Spawn",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpawnManager", "Celeste.SpawnManager", "SpawnManager",
            assemblyIdentity, "Celeste", 33554877, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpawnManager", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpawnManager",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BackgroundFadeIn", "Celeste.BackgroundFadeIn", "BackgroundFadeIn",
            assemblyIdentity, "Celeste", 33554878, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BackgroundFadeIn", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BackgroundFadeIn",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingRumbler", "Celeste.BreathingRumbler", "BreathingRumbler",
            assemblyIdentity, "Celeste", 33554879, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingRumbler", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingRumbler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BridgeFixed", "Celeste.BridgeFixed", "BridgeFixed", assemblyIdentity,
            "Celeste", 33554880, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BridgeFixed", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BridgeFixed",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreMessage", "Celeste.CoreMessage", "CoreMessage", assemblyIdentity,
            "Celeste", 33554881, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreMessage", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreMessage",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor", "Celeste.HeartGemDoor", "HeartGemDoor",
            assemblyIdentity, "Celeste", 33554882, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.KevinsPC", "Celeste.KevinsPC", "KevinsPC", assemblyIdentity,
            "Celeste", 33554883, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.KevinsPC", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.KevinsPC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelUpEffect", "Celeste.LevelUpEffect", "LevelUpEffect",
            assemblyIdentity, "Celeste", 33554884, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelUpEffect", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelUpEffect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OshiroLobbyBell", "Celeste.OshiroLobbyBell", "OshiroLobbyBell",
            assemblyIdentity, "Celeste", 33554885, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OshiroLobbyBell", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OshiroLobbyBell",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReflectionTentacles", "Celeste.ReflectionTentacles",
            "ReflectionTentacles", assemblyIdentity, "Celeste", 33554886, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReflectionTentacles", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionTentacles",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RidgeGate", "Celeste.RidgeGate", "RidgeGate", assemblyIdentity,
            "Celeste", 33554887, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RidgeGate", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RidgeGate",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarJumpController", "Celeste.StarJumpController",
            "StarJumpController", assemblyIdentity, "Celeste", 33554888, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarJumpController", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpController",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarJumpBlock", "Celeste.StarJumpBlock", "StarJumpBlock",
            assemblyIdentity, "Celeste", 33554889, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarJumpBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager", "Celeste.AscendManager", "AscendManager",
            assemblyIdentity, "Celeste", 33554890, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint", "Celeste.SummitCheckpoint", "SummitCheckpoint",
            assemblyIdentity, "Celeste", 33554891, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitGemManager", "Celeste.SummitGemManager", "SummitGemManager",
            assemblyIdentity, "Celeste", 33554892, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitGemManager", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitGemManager",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TheoPhone", "Celeste.TheoPhone", "TheoPhone", assemblyIdentity,
            "Celeste", 33554893, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TheoPhone", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TheoPhone",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UnlockEverythingThingy", "Celeste.UnlockEverythingThingy",
            "UnlockEverythingThingy", assemblyIdentity, "Celeste", 33554894, false,
            new string[]
            {
                "Monocle.CheatListener", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UnlockEverythingThingy", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.UnlockEverythingThingy",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BirdPathTrigger", "Celeste.BirdPathTrigger", "BirdPathTrigger",
            assemblyIdentity, "Celeste", 33554895, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BirdPathTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BirdPathTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlackholeStrengthTrigger", "Celeste.BlackholeStrengthTrigger",
            "BlackholeStrengthTrigger", assemblyIdentity, "Celeste", 33554896, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlackholeStrengthTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeStrengthTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger", "Celeste.DetachStrawberryTrigger",
            "DetachStrawberryTrigger", assemblyIdentity, "Celeste", 33554897, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RumbleTrigger", "Celeste.RumbleTrigger", "RumbleTrigger",
            assemblyIdentity, "Celeste", 33554898, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RumbleTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RumbleTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpawnFacingTrigger", "Celeste.SpawnFacingTrigger",
            "SpawnFacingTrigger", assemblyIdentity, "Celeste", 33554899, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpawnFacingTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpawnFacingTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GrabbyIcon", "Celeste.GrabbyIcon", "GrabbyIcon", assemblyIdentity,
            "Celeste", 33554900, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GrabbyIcon", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.GrabbyIcon",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage03", "Celeste.WaveDashPage03", "WaveDashPage03",
            assemblyIdentity, "Celeste", 33554901, false, new string[] { "Celeste.WaveDashPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage03", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage03",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05", "Celeste.WaveDashPage05", "WaveDashPage05",
            assemblyIdentity, "Celeste", 33554902, false, new string[] { "Celeste.WaveDashPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage04", "Celeste.WaveDashPage04", "WaveDashPage04",
            assemblyIdentity, "Celeste", 33554903, false, new string[] { "Celeste.WaveDashPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage04", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage04",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage06", "Celeste.WaveDashPage06", "WaveDashPage06",
            assemblyIdentity, "Celeste", 33554904, false, new string[] { "Celeste.WaveDashPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage06", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage06",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02", "Celeste.WaveDashPage02", "WaveDashPage02",
            assemblyIdentity, "Celeste", 33554905, false, new string[] { "Celeste.WaveDashPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage01", "Celeste.WaveDashPage01", "WaveDashPage01",
            assemblyIdentity, "Celeste", 33554906, false, new string[] { "Celeste.WaveDashPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage01", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage01",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage00", "Celeste.WaveDashPage00", "WaveDashPage00",
            assemblyIdentity, "Celeste", 33554907, false, new string[] { "Celeste.WaveDashPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage00", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage00",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage", "Celeste.WaveDashPage", "WaveDashPage",
            assemblyIdentity, "Celeste", 33554908, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPlaybackTutorial", "Celeste.WaveDashPlaybackTutorial",
            "WaveDashPlaybackTutorial", assemblyIdentity, "Celeste", 33554909, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPlaybackTutorial", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPlaybackTutorial",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPresentation", "Celeste.WaveDashPresentation",
            "WaveDashPresentation", assemblyIdentity, "Celeste", 33554910, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPresentation", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPresentation",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashTutorialMachine", "Celeste.WaveDashTutorialMachine",
            "WaveDashTutorialMachine", assemblyIdentity, "Celeste", 33554911, false,
            new string[]
            {
                "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashTutorialMachine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashTutorialMachine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpeedRing", "Celeste.SpeedRing", "SpeedRing", assemblyIdentity,
            "Celeste", 33554912, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpeedRing", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpeedRing",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AmbienceParamTrigger", "Celeste.AmbienceParamTrigger",
            "AmbienceParamTrigger", assemblyIdentity, "Celeste", 33554913, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AmbienceParamTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AmbienceParamTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CameraAdvanceTargetTrigger", "Celeste.CameraAdvanceTargetTrigger",
            "CameraAdvanceTargetTrigger", assemblyIdentity, "Celeste", 33554914, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CameraAdvanceTargetTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CameraAdvanceTargetTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CheckpointBlockerTrigger", "Celeste.CheckpointBlockerTrigger",
            "CheckpointBlockerTrigger", assemblyIdentity, "Celeste", 33554915, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CheckpointBlockerTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CheckpointBlockerTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CreditsTrigger", "Celeste.CreditsTrigger", "CreditsTrigger",
            assemblyIdentity, "Celeste", 33554916, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CreditsTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CreditsTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GoldBerryCollectTrigger", "Celeste.GoldBerryCollectTrigger",
            "GoldBerryCollectTrigger", assemblyIdentity, "Celeste", 33554917, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GoldBerryCollectTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GoldBerryCollectTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.InteractTrigger", "Celeste.InteractTrigger", "InteractTrigger",
            assemblyIdentity, "Celeste", 33554918, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.InteractTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.InteractTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LookoutBlocker", "Celeste.LookoutBlocker", "LookoutBlocker",
            assemblyIdentity, "Celeste", 33554919, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LookoutBlocker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LookoutBlocker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger", "Celeste.MoonGlitchBackgroundTrigger",
            "MoonGlitchBackgroundTrigger", assemblyIdentity, "Celeste", 33554920, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NoRefillTrigger", "Celeste.NoRefillTrigger", "NoRefillTrigger",
            assemblyIdentity, "Celeste", 33554921, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NoRefillTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NoRefillTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OshiroTrigger", "Celeste.OshiroTrigger", "OshiroTrigger",
            assemblyIdentity, "Celeste", 33554922, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OshiroTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OshiroTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StopBoostTrigger", "Celeste.StopBoostTrigger", "StopBoostTrigger",
            assemblyIdentity, "Celeste", 33554923, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StopBoostTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StopBoostTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GameplayStats", "Celeste.GameplayStats", "GameplayStats",
            assemblyIdentity, "Celeste", 33554924, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GameplayStats", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.GameplayStats",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeightDisplay", "Celeste.HeightDisplay", "HeightDisplay",
            assemblyIdentity, "Celeste", 33554925, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeightDisplay", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeightDisplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReturnMapHint", "Celeste.ReturnMapHint", "ReturnMapHint",
            assemblyIdentity, "Celeste", 33554926, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReturnMapHint", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReturnMapHint",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.QuickResetHint", "Celeste.QuickResetHint", "QuickResetHint",
            assemblyIdentity, "Celeste", 33554927, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.QuickResetHint", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.QuickResetHint",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AutoSplitterInfo", "Celeste.AutoSplitterInfo", "AutoSplitterInfo",
            assemblyIdentity, "Celeste", 33554928, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AutoSplitterInfo", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AutoSplitterInfo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG", "Celeste.BlackholeBG", "BlackholeBG", assemblyIdentity,
            "Celeste", 33554929, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Planets", "Celeste.Planets", "Planets", assemblyIdentity, "Celeste",
            33554930, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Planets", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Planets",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RainFG", "Celeste.RainFG", "RainFG", assemblyIdentity, "Celeste",
            33554931, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RainFG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.RainFG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StardustFG", "Celeste.StardustFG", "StardustFG", assemblyIdentity,
            "Celeste", 33554932, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StardustFG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.StardustFG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Starfield", "Celeste.Starfield", "Starfield", assemblyIdentity,
            "Celeste", 33554933, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Starfield", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Starfield",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DisperseImage", "Celeste.DisperseImage", "DisperseImage",
            assemblyIdentity, "Celeste", 33554934, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DisperseImage", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DisperseImage",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GlassBlockBg", "Celeste.GlassBlockBg", "GlassBlockBg",
            assemblyIdentity, "Celeste", 33554935, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GlassBlockBg", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlockBg",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer", "Celeste.LightningRenderer", "LightningRenderer",
            assemblyIdentity, "Celeste", 33554936, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningStrike", "Celeste.LightningStrike", "LightningStrike",
            assemblyIdentity, "Celeste", 33554937, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningStrike", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningStrike",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrierRenderer", "Celeste.SeekerBarrierRenderer",
            "SeekerBarrierRenderer", assemblyIdentity, "Celeste", 33554938, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrierRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrierRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.InputMappingInfo", "Celeste.InputMappingInfo", "InputMappingInfo",
            assemblyIdentity, "Celeste", 33554939, false, new string[] { "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.InputMappingInfo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.InputMappingInfo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ButtonConfigUI", "Celeste.ButtonConfigUI", "ButtonConfigUI",
            assemblyIdentity, "Celeste", 33554940, false,
            new string[]
            {
                "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ButtonConfigUI", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ButtonConfigUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LanguageSelectUI", "Celeste.LanguageSelectUI", "LanguageSelectUI",
            assemblyIdentity, "Celeste", 33554941, false,
            new string[]
            {
                "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LanguageSelectUI", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.LanguageSelectUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PrologueEndingText", "Celeste.PrologueEndingText",
            "PrologueEndingText", assemblyIdentity, "Celeste", 33554942, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PrologueEndingText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PrologueEndingText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UnlockedPico8Message", "Celeste.UnlockedPico8Message",
            "UnlockedPico8Message", assemblyIdentity, "Celeste", 33554943, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UnlockedPico8Message", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedPico8Message",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UnlockedRemixDisplay", "Celeste.UnlockedRemixDisplay",
            "UnlockedRemixDisplay", assemblyIdentity, "Celeste", 33554944, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UnlockedRemixDisplay", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedRemixDisplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SoundEmitter", "Celeste.SoundEmitter", "SoundEmitter",
            assemblyIdentity, "Celeste", 33554945, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SoundEmitter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SoundEmitter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame", "Celeste.BreathingMinigame", "BreathingMinigame",
            assemblyIdentity, "Celeste", 33554946, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Plateau", "Celeste.Plateau", "Plateau", assemblyIdentity, "Celeste",
            33554947, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Plateau", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Plateau",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball", "Celeste.TempleBigEyeball", "TempleBigEyeball",
            assemblyIdentity, "Celeste", 33554948, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker", "Celeste.PlayerSeeker", "PlayerSeeker",
            assemblyIdentity, "Celeste", 33554949, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReflectionHeartStatue", "Celeste.ReflectionHeartStatue",
            "ReflectionHeartStatue", assemblyIdentity, "Celeste", 33554950, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReflectionHeartStatue", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionHeartStatue",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleEndingMusicHandler", "Celeste.TempleEndingMusicHandler",
            "TempleEndingMusicHandler", assemblyIdentity, "Celeste", 33554951, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleEndingMusicHandler", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleEndingMusicHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TheoCrystalPedestal", "Celeste.TheoCrystalPedestal",
            "TheoCrystalPedestal", assemblyIdentity, "Celeste", 33554952, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TheoCrystalPedestal", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TheoCrystalPedestal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MiniTextboxTrigger", "Celeste.MiniTextboxTrigger",
            "MiniTextboxTrigger", assemblyIdentity, "Celeste", 33554953, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MiniTextboxTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextboxTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MiniTextbox", "Celeste.MiniTextbox", "MiniTextbox", assemblyIdentity,
            "Celeste", 33554954, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MiniTextbox", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextbox",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTilesBank", "Celeste.AnimatedTilesBank", "AnimatedTilesBank",
            assemblyIdentity, "Celeste", 33554955, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTilesBank", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTilesBank",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTiles", "Celeste.AnimatedTiles", "AnimatedTiles",
            assemblyIdentity, "Celeste", 33554956, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTiles", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTiles",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FinalBossStarfield", "Celeste.FinalBossStarfield",
            "FinalBossStarfield", assemblyIdentity, "Celeste", 33554957, false,
            new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FinalBossStarfield", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossStarfield",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Godrays", "Celeste.Godrays", "Godrays", assemblyIdentity, "Celeste",
            33554958, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Godrays", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Godrays",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeatWave", "Celeste.HeatWave", "HeatWave", assemblyIdentity,
            "Celeste", 33554959, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeatWave", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeatWave",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights", "Celeste.NorthernLights", "NorthernLights",
            assemblyIdentity, "Celeste", 33554960, false, new string[] { "Celeste.Backdrop", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Petals", "Celeste.Petals", "Petals", assemblyIdentity, "Celeste",
            33554961, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Petals", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Petals",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreStarsFG", "Celeste.CoreStarsFG", "CoreStarsFG", assemblyIdentity,
            "Celeste", 33554962, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreStarsFG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreStarsFG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReflectionFG", "Celeste.ReflectionFG", "ReflectionFG",
            assemblyIdentity, "Celeste", 33554963, false, new string[] { "Celeste.Backdrop", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReflectionFG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionFG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MirrorFG", "Celeste.MirrorFG", "MirrorFG", assemblyIdentity,
            "Celeste", 33554964, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MirrorFG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MirrorFG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Tentacles", "Celeste.Tentacles", "Tentacles", assemblyIdentity,
            "Celeste", 33554965, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Tentacles", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Tentacles",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay", "Celeste.FileErrorOverlay", "FileErrorOverlay",
            assemblyIdentity, "Celeste", 33554966, false,
            new string[]
            {
                "Celeste.Overlay", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Overlay", "Celeste.Overlay", "Overlay", assemblyIdentity, "Celeste",
            33554967, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Overlay", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Overlay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HiresRenderer", "Celeste.HiresRenderer", "HiresRenderer",
            assemblyIdentity, "Celeste", 33554968, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HiresRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.HiresRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TrailManager", "Celeste.TrailManager", "TrailManager",
            assemblyIdentity, "Celeste", 33554969, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TrailManager", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TrailManager",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ButtonUI", "Celeste.ButtonUI", "ButtonUI", assemblyIdentity,
            "Celeste", 33554970, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ButtonUI", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ButtonUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits", "Celeste.Credits", "Credits", assemblyIdentity, "Celeste",
            33554971, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CustomSpriteEffect", "Celeste.CustomSpriteEffect",
            "CustomSpriteEffect", assemblyIdentity, "Celeste", 33554972, false,
            new string[] { "Microsoft.Xna.Framework.Graphics.Effect" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CustomSpriteEffect", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CustomSpriteEffect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MirrorReflection", "Celeste.MirrorReflection", "MirrorReflection",
            assemblyIdentity, "Celeste", 33554973, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MirrorReflection", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MirrorReflection",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HoldableCollider", "Celeste.HoldableCollider", "HoldableCollider",
            assemblyIdentity, "Celeste", 33554974, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HoldableCollider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HoldableCollider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SaveTheo", "Celeste.CS05_SaveTheo", "CS05_SaveTheo",
            assemblyIdentity, "Celeste", 33554975, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SaveTheo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SaveTheo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo", "Celeste.CS05_SeeTheo", "CS05_SeeTheo",
            assemblyIdentity, "Celeste", 33554976, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoInMirror", "Celeste.CS05_TheoInMirror", "CS05_TheoInMirror",
            assemblyIdentity, "Celeste", 33554977, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoInMirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoInMirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance", "Celeste.CS05_Entrance", "CS05_Entrance",
            assemblyIdentity, "Celeste", 33554978, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Slider", "Celeste.Slider", "Slider", assemblyIdentity, "Celeste",
            33554979, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Slider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Slider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline", "Celeste.NPC05_Badeline", "NPC05_Badeline",
            assemblyIdentity, "Celeste", 33554980, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Theo_Mirror", "Celeste.NPC05_Theo_Mirror", "NPC05_Theo_Mirror",
            assemblyIdentity, "Celeste", 33554981, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Theo_Mirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Theo_Mirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Theo_Entrance", "Celeste.NPC05_Theo_Entrance",
            "NPC05_Theo_Entrance", assemblyIdentity, "Celeste", 33554982, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Theo_Entrance", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Theo_Entrance",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirror", "Celeste.TempleMirror", "TempleMirror",
            assemblyIdentity, "Celeste", 33554983, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SeekerEffectsController", "Celeste.SeekerEffectsController",
            "SeekerEffectsController", assemblyIdentity, "Celeste", 33554984, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SeekerEffectsController", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SeekerEffectsController",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite", "Celeste.ForsakenCitySatellite",
            "ForsakenCitySatellite", assemblyIdentity, "Celeste", 33554985, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness", "Celeste.GondolaDarkness", "GondolaDarkness",
            assemblyIdentity, "Celeste", 33554986, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WhiteBlock", "Celeste.WhiteBlock", "WhiteBlock", assemblyIdentity,
            "Celeste", 33554987, false,
            new string[]
            {
                "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WhiteBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WhiteBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ChangeRespawnTrigger", "Celeste.ChangeRespawnTrigger",
            "ChangeRespawnTrigger", assemblyIdentity, "Celeste", 33554988, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ChangeRespawnTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ChangeRespawnTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustStyles", "Celeste.DustStyles", "DustStyles", assemblyIdentity,
            "Celeste", 33554989, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustStyles", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustStyles",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FormationBackdrop", "Celeste.FormationBackdrop", "FormationBackdrop",
            assemblyIdentity, "Celeste", 33554990, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FormationBackdrop", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.FormationBackdrop",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MirrorSurfaces", "Celeste.MirrorSurfaces", "MirrorSurfaces",
            assemblyIdentity, "Celeste", 33554991, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MirrorSurfaces", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MirrorSurfaces",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ObjModel", "Celeste.ObjModel", "ObjModel", assemblyIdentity,
            "Celeste", 33554992, false, new string[] { "System.Object", "System.IDisposable" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ObjModel", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ObjModel",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AutoSavingNotice", "Celeste.AutoSavingNotice", "AutoSavingNotice",
            assemblyIdentity, "Celeste", 33554993, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AutoSavingNotice", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AutoSavingNotice",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer", "Celeste.CompleteRenderer", "CompleteRenderer",
            assemblyIdentity, "Celeste", 33554994, false,
            new string[] { "Celeste.HiresRenderer", "System.IDisposable", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HiresSnow", "Celeste.HiresSnow", "HiresSnow", assemblyIdentity,
            "Celeste", 33554995, false, new string[] { "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HiresSnow", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HiresSnow",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.KeyboardConfigUI", "Celeste.KeyboardConfigUI", "KeyboardConfigUI",
            assemblyIdentity, "Celeste", 33554996, false,
            new string[]
            {
                "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.KeyboardConfigUI", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.KeyboardConfigUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Postcard", "Celeste.Postcard", "Postcard", assemblyIdentity,
            "Celeste", 33554997, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Postcard", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Postcard",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SaveLoadIcon", "Celeste.SaveLoadIcon", "SaveLoadIcon",
            assemblyIdentity, "Celeste", 33554998, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SaveLoadIcon", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SaveLoadIcon",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu", "Celeste.TextMenu", "TextMenu", assemblyIdentity,
            "Celeste", 33554999, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ViewportAdjustmentUI", "Celeste.ViewportAdjustmentUI",
            "ViewportAdjustmentUI", assemblyIdentity, "Celeste", 33555000, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ViewportAdjustmentUI", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ViewportAdjustmentUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeartWipe", "Celeste.HeartWipe", "HeartWipe", assemblyIdentity,
            "Celeste", 33555001, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeartWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeartWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.KeyDoorWipe", "Celeste.KeyDoorWipe", "KeyDoorWipe", assemblyIdentity,
            "Celeste", 33555002, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.KeyDoorWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.KeyDoorWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FallWipe", "Celeste.FallWipe", "FallWipe", assemblyIdentity,
            "Celeste", 33555003, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FallWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FallWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MountainWipe", "Celeste.MountainWipe", "MountainWipe",
            assemblyIdentity, "Celeste", 33555004, false,
            new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MountainWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MountainWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AngledWipe", "Celeste.AngledWipe", "AngledWipe", assemblyIdentity,
            "Celeste", 33555005, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AngledWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AngledWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DropWipe", "Celeste.DropWipe", "DropWipe", assemblyIdentity,
            "Celeste", 33555006, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DropWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DropWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightingRenderer", "Celeste.LightingRenderer", "LightingRenderer",
            assemblyIdentity, "Celeste", 33555007, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightingRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightingRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarfieldWipe", "Celeste.StarfieldWipe", "StarfieldWipe",
            assemblyIdentity, "Celeste", 33555008, false,
            new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarfieldWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarfieldWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OVR", "Celeste.OVR", "OVR", assemblyIdentity, "Celeste", 33555009,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OVR", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OVR",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PreviewPostcard", "Celeste.PreviewPostcard", "PreviewPostcard",
            assemblyIdentity, "Celeste", 33555010, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PreviewPostcard", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPostcard",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PreviewRecording", "Celeste.PreviewRecording", "PreviewRecording",
            assemblyIdentity, "Celeste", 33555011, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PreviewRecording", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PreviewRecording",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GameLoader", "Celeste.GameLoader", "GameLoader", assemblyIdentity,
            "Celeste", 33555012, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GameLoader", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.IOverlayHandler", "Celeste.IOverlayHandler", "IOverlayHandler",
            assemblyIdentity, "Celeste", 33555013, true, Array.Empty<string>(), Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.IOverlayHandler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.IOverlayHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Maddy3D", "Celeste.Maddy3D", "Maddy3D", assemblyIdentity, "Celeste",
            33555014, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Maddy3D", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Maddy3D",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonParticle3D", "Celeste.MoonParticle3D", "MoonParticle3D",
            assemblyIdentity, "Celeste", 33555015, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonParticle3D", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonParticle3D",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Snow3D", "Celeste.Snow3D", "Snow3D", assemblyIdentity, "Celeste",
            33555016, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Snow3D", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Snow3D",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalGlobal", "Celeste.OuiJournalGlobal", "OuiJournalGlobal",
            assemblyIdentity, "Celeste", 33555017, false, new string[] { "Celeste.OuiJournalPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalGlobal", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalGlobal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode", "Celeste.OuiAssistMode", "OuiAssistMode",
            assemblyIdentity, "Celeste", 33555018, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreVignette", "Celeste.CoreVignette", "CoreVignette",
            assemblyIdentity, "Celeste", 33555019, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreVignette", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreVignette",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Achievement", "Celeste.Achievement", "Achievement", assemblyIdentity,
            "Celeste", 33555020, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Achievement", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Achievement",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Achievements", "Celeste.Achievements", "Achievements",
            assemblyIdentity, "Celeste", 33555021, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Achievements", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Achievements",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BinaryPacker", "Celeste.BinaryPacker", "BinaryPacker",
            assemblyIdentity, "Celeste", 33555022, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BinaryPacker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BinaryPacker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter", "Celeste.LevelEnter", "LevelEnter", assemblyIdentity,
            "Celeste", 33555023, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MountainCamera", "Celeste.MountainCamera", "MountainCamera",
            assemblyIdentity, "Celeste", 33555024, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MountainCamera", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MountainCamera",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MountainState", "Celeste.MountainState", "MountainState",
            assemblyIdentity, "Celeste", 33555025, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MountainState", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MountainState",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Skybox", "Celeste.Skybox", "Skybox", assemblyIdentity, "Celeste",
            33555026, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Skybox", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Skybox",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Ring", "Celeste.Ring", "Ring", assemblyIdentity, "Celeste", 33555027,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Ring", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Ring",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MountainModel", "Celeste.MountainModel", "MountainModel",
            assemblyIdentity, "Celeste", 33555028, false, new string[] { "System.Object", "System.IDisposable" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MountainModel", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MountainModel",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OverworldLoader", "Celeste.OverworldLoader", "OverworldLoader",
            assemblyIdentity, "Celeste", 33555029, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OverworldLoader", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OverworldLoader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OverworldReflectionsFall", "Celeste.OverworldReflectionsFall",
            "OverworldReflectionsFall", assemblyIdentity, "Celeste", 33555030, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OverworldReflectionsFall", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OverworldReflectionsFall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalDeaths", "Celeste.OuiJournalDeaths", "OuiJournalDeaths",
            assemblyIdentity, "Celeste", 33555031, false, new string[] { "Celeste.OuiJournalPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalDeaths", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalDeaths",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TestBreathingGame", "Celeste.TestBreathingGame", "TestBreathingGame",
            assemblyIdentity, "Celeste", 33555032, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TestBreathingGame", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TestBreathingGame",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelExit", "Celeste.LevelExit", "LevelExit", assemblyIdentity,
            "Celeste", 33555033, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelExit", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelExit",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
