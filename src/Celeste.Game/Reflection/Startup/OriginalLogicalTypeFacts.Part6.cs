using System;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup;

public static partial class OriginalLogicalTypeFacts
{
    private static void RegisterPart6(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("Celeste.FinalBossShot+ShotPatterns", "Celeste.FinalBossShot.ShotPatterns",
            "ShotPatterns", assemblyIdentity, "Celeste", 33555634, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FinalBossShot.ShotPatterns", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossShot.ShotPatterns",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+Orb", "Celeste.NPC06_Badeline_Crying.Orb",
            "Orb", assemblyIdentity, "Celeste", 33555635, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.Orb", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.Orb",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+<TurnWhite>d__10",
            "Celeste.NPC06_Badeline_Crying.<TurnWhite>d__10", "<TurnWhite>d__10", assemblyIdentity, "Celeste", 33555636,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.<TurnWhite>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.<TurnWhite>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC06_Badeline_Crying+<Disperse>d__11",
            "Celeste.NPC06_Badeline_Crying.<Disperse>d__11", "<Disperse>d__11", assemblyIdentity, "Celeste", 33555637,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC06_Badeline_Crying.<Disperse>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC06_Badeline_Crying.<Disperse>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBird+States", "Celeste.FlingBird.States", "States",
            assemblyIdentity, "Celeste", 33555638, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBird.States", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird.States",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBird+<>c", "Celeste.FlingBird.<>c", "<>c", assemblyIdentity,
            "Celeste", 33555639, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBird.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBird+<DoFlingRoutine>d__23",
            "Celeste.FlingBird.<DoFlingRoutine>d__23", "<DoFlingRoutine>d__23", assemblyIdentity, "Celeste", 33555640,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBird.<DoFlingRoutine>d__23", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird.<DoFlingRoutine>d__23",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBird+<MoveRoutine>d__24", "Celeste.FlingBird.<MoveRoutine>d__24",
            "<MoveRoutine>d__24", assemblyIdentity, "Celeste", 33555641, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBird.<MoveRoutine>d__24", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird.<MoveRoutine>d__24",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBird+<LeaveRoutine>d__25",
            "Celeste.FlingBird.<LeaveRoutine>d__25", "<LeaveRoutine>d__25", assemblyIdentity, "Celeste", 33555642,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBird.<LeaveRoutine>d__25", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird.<LeaveRoutine>d__25",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBird+<MoveOnCurve>d__26", "Celeste.FlingBird.<MoveOnCurve>d__26",
            "<MoveOnCurve>d__26", assemblyIdentity, "Celeste", 33555643, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBird.<MoveOnCurve>d__26", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBird.<MoveOnCurve>d__26",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Puffer+States", "Celeste.Puffer.States", "States", assemblyIdentity,
            "Celeste", 33555644, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Puffer.States", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Puffer.States",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlyFeather+<CollectRoutine>d__26",
            "Celeste.FlyFeather.<CollectRoutine>d__26", "<CollectRoutine>d__26", assemblyIdentity, "Celeste", 33555645,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlyFeather.<CollectRoutine>d__26", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlyFeather.<CollectRoutine>d__26",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Glider+<DestroyAnimationRoutine>d__38",
            "Celeste.Glider.<DestroyAnimationRoutine>d__38", "<DestroyAnimationRoutine>d__38", assemblyIdentity,
            "Celeste", 33555646, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Glider.<DestroyAnimationRoutine>d__38", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Glider.<DestroyAnimationRoutine>d__38",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BigWaterfall+Layers", "Celeste.BigWaterfall.Layers", "Layers",
            assemblyIdentity, "Celeste", 33555647, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BigWaterfall.Layers", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BigWaterfall.Layers",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CliffsideWindFlag+Segment", "Celeste.CliffsideWindFlag.Segment",
            "Segment", assemblyIdentity, "Celeste", 33555648, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CliffsideWindFlag.Segment", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CliffsideWindFlag.Segment",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FallEffects+Particle", "Celeste.FallEffects.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555649, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FallEffects.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FallEffects.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonCreature+TrailNode", "Celeste.MoonCreature.TrailNode",
            "TrailNode", assemblyIdentity, "Celeste", 33555650, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonCreature.TrailNode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonCreature.TrailNode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor+Particle", "Celeste.HeartGemDoor.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555651, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor+WhiteLine", "Celeste.HeartGemDoor.WhiteLine",
            "WhiteLine", assemblyIdentity, "Celeste", 33555652, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor.WhiteLine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor.WhiteLine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDoor+<Routine>d__32", "Celeste.HeartGemDoor.<Routine>d__32",
            "<Routine>d__32", assemblyIdentity, "Celeste", 33555653, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDoor.<Routine>d__32", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDoor.<Routine>d__32",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReflectionTentacles+Tentacle", "Celeste.ReflectionTentacles.Tentacle",
            "Tentacle", assemblyIdentity, "Celeste", 33555654, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReflectionTentacles.Tentacle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionTentacles.Tentacle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RidgeGate+<>c__DisplayClass4_0",
            "Celeste.RidgeGate.<>c__DisplayClass4_0", "<>c__DisplayClass4_0", assemblyIdentity, "Celeste", 33555655,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RidgeGate.<>c__DisplayClass4_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.RidgeGate.<>c__DisplayClass4_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RidgeGate+<EnterSequence>d__4",
            "Celeste.RidgeGate.<EnterSequence>d__4", "<EnterSequence>d__4", assemblyIdentity, "Celeste", 33555656,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RidgeGate.<EnterSequence>d__4", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RidgeGate.<EnterSequence>d__4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarJumpController+Ray", "Celeste.StarJumpController.Ray", "Ray",
            assemblyIdentity, "Celeste", 33555657, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarJumpController.Ray", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarJumpController.Ray",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Streaks", "Celeste.AscendManager.Streaks", "Streaks",
            assemblyIdentity, "Celeste", 33555658, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Streaks", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Streaks",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Clouds", "Celeste.AscendManager.Clouds", "Clouds",
            assemblyIdentity, "Celeste", 33555659, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Clouds", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Clouds",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+Fader", "Celeste.AscendManager.Fader", "Fader",
            assemblyIdentity, "Celeste", 33555660, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.Fader", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.Fader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+<Routine>d__15", "Celeste.AscendManager.<Routine>d__15",
            "<Routine>d__15", assemblyIdentity, "Celeste", 33555661, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.<Routine>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.<Routine>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AscendManager+<FadeTo>d__19", "Celeste.AscendManager.<FadeTo>d__19",
            "<FadeTo>d__19", assemblyIdentity, "Celeste", 33555662, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AscendManager.<FadeTo>d__19", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AscendManager.<FadeTo>d__19",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitCheckpoint+ConfettiRenderer",
            "Celeste.SummitCheckpoint.ConfettiRenderer", "ConfettiRenderer", assemblyIdentity, "Celeste", 33555663,
            false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitCheckpoint.ConfettiRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitCheckpoint.ConfettiRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitGemManager+Gem", "Celeste.SummitGemManager.Gem", "Gem",
            assemblyIdentity, "Celeste", 33555664, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitGemManager.Gem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitGemManager.Gem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitGemManager+<Routine>d__4",
            "Celeste.SummitGemManager.<Routine>d__4", "<Routine>d__4", assemblyIdentity, "Celeste", 33555665, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitGemManager.<Routine>d__4", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitGemManager.<Routine>d__4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UnlockEverythingThingy+<>c", "Celeste.UnlockEverythingThingy.<>c",
            "<>c", assemblyIdentity, "Celeste", 33555666, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UnlockEverythingThingy.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.UnlockEverythingThingy.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UnlockEverythingThingy+<>c__DisplayClass1_0",
            "Celeste.UnlockEverythingThingy.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste",
            33555667, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UnlockEverythingThingy.<>c__DisplayClass1_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.UnlockEverythingThingy.<>c__DisplayClass1_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger+<>c__DisplayClass4_0",
            "Celeste.DetachStrawberryTrigger.<>c__DisplayClass4_0", "<>c__DisplayClass4_0", assemblyIdentity, "Celeste",
            33555668, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger.<>c__DisplayClass4_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger.<>c__DisplayClass4_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DetachStrawberryTrigger+<DetatchFollower>d__4",
            "Celeste.DetachStrawberryTrigger.<DetatchFollower>d__4", "<DetatchFollower>d__4", assemblyIdentity,
            "Celeste", 33555669, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DetachStrawberryTrigger.<DetatchFollower>d__4", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DetachStrawberryTrigger.<DetatchFollower>d__4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RumbleTrigger+<>c", "Celeste.RumbleTrigger.<>c", "<>c",
            assemblyIdentity, "Celeste", 33555670, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RumbleTrigger.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.RumbleTrigger.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RumbleTrigger+<RumbleRoutine>d__13",
            "Celeste.RumbleTrigger.<RumbleRoutine>d__13", "<RumbleRoutine>d__13", assemblyIdentity, "Celeste", 33555671,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RumbleTrigger.<RumbleRoutine>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RumbleTrigger.<RumbleRoutine>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage03+<Routine>d__8", "Celeste.WaveDashPage03.<Routine>d__8",
            "<Routine>d__8", assemblyIdentity, "Celeste", 33555672, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage03.<Routine>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage03.<Routine>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+Display", "Celeste.WaveDashPage05.Display", "Display",
            assemblyIdentity, "Celeste", 33555673, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.Display", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.Display",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage05+<Routine>d__4", "Celeste.WaveDashPage05.<Routine>d__4",
            "<Routine>d__4", assemblyIdentity, "Celeste", 33555674, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage05.<Routine>d__4", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage05.<Routine>d__4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage04+<>c__DisplayClass5_0",
            "Celeste.WaveDashPage04.<>c__DisplayClass5_0", "<>c__DisplayClass5_0", assemblyIdentity, "Celeste",
            33555675, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage04.<>c__DisplayClass5_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage04.<>c__DisplayClass5_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage04+<Routine>d__6", "Celeste.WaveDashPage04.<Routine>d__6",
            "<Routine>d__6", assemblyIdentity, "Celeste", 33555676, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage04.<Routine>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage04.<Routine>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage06+<Routine>d__2", "Celeste.WaveDashPage06.<Routine>d__2",
            "<Routine>d__2", assemblyIdentity, "Celeste", 33555677, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage06.<Routine>d__2", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage06.<Routine>d__2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02+TitleText", "Celeste.WaveDashPage02.TitleText",
            "TitleText", assemblyIdentity, "Celeste", 33555678, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02.TitleText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02.TitleText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage02+<Routine>d__7", "Celeste.WaveDashPage02.<Routine>d__7",
            "<Routine>d__7", assemblyIdentity, "Celeste", 33555679, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage02.<Routine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage02.<Routine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage01+<Routine>d__4", "Celeste.WaveDashPage01.<Routine>d__4",
            "<Routine>d__4", assemblyIdentity, "Celeste", 33555680, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage01.<Routine>d__4", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage01.<Routine>d__4",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage00+<Routine>d__6", "Celeste.WaveDashPage00.<Routine>d__6",
            "<Routine>d__6", assemblyIdentity, "Celeste", 33555681, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage00.<Routine>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage00.<Routine>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage00+<MoveCursor>d__7",
            "Celeste.WaveDashPage00.<MoveCursor>d__7", "<MoveCursor>d__7", assemblyIdentity, "Celeste", 33555682, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage00.<MoveCursor>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage00.<MoveCursor>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage+Transitions", "Celeste.WaveDashPage.Transitions",
            "Transitions", assemblyIdentity, "Celeste", 33555683, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage.Transitions", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage.Transitions",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPage+<PressButton>d__14",
            "Celeste.WaveDashPage.<PressButton>d__14", "<PressButton>d__14", assemblyIdentity, "Celeste", 33555684,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPage.<PressButton>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPage.<PressButton>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPresentation+<Routine>d__33",
            "Celeste.WaveDashPresentation.<Routine>d__33", "<Routine>d__33", assemblyIdentity, "Celeste", 33555685,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPresentation.<Routine>d__33", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPresentation.<Routine>d__33",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashPresentation+<TurnPage>d__34",
            "Celeste.WaveDashPresentation.<TurnPage>d__34", "<TurnPage>d__34", assemblyIdentity, "Celeste", 33555686,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashPresentation.<TurnPage>d__34", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashPresentation.<TurnPage>d__34",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaveDashTutorialMachine+<InteractRoutine>d__24",
            "Celeste.WaveDashTutorialMachine.<InteractRoutine>d__24", "<InteractRoutine>d__24", assemblyIdentity,
            "Celeste", 33555687, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaveDashTutorialMachine.<InteractRoutine>d__24", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaveDashTutorialMachine.<InteractRoutine>d__24",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger+Duration",
            "Celeste.MoonGlitchBackgroundTrigger.Duration", "Duration", assemblyIdentity, "Celeste", 33555688, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger.Duration", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger.Duration",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger+<InternalGlitchRoutine>d__9",
            "Celeste.MoonGlitchBackgroundTrigger.<InternalGlitchRoutine>d__9", "<InternalGlitchRoutine>d__9",
            assemblyIdentity, "Celeste", 33555689, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger.<InternalGlitchRoutine>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger.<InternalGlitchRoutine>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonGlitchBackgroundTrigger+<GlitchRoutine>d__12",
            "Celeste.MoonGlitchBackgroundTrigger.<GlitchRoutine>d__12", "<GlitchRoutine>d__12", assemblyIdentity,
            "Celeste", 33555690, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonGlitchBackgroundTrigger.<GlitchRoutine>d__12", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonGlitchBackgroundTrigger.<GlitchRoutine>d__12",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeightDisplay+<Routine>d__19", "Celeste.HeightDisplay.<Routine>d__19",
            "<Routine>d__19", assemblyIdentity, "Celeste", 33555691, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeightDisplay.<Routine>d__19", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeightDisplay.<Routine>d__19",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeightDisplay+<CameraUp>d__20",
            "Celeste.HeightDisplay.<CameraUp>d__20", "<CameraUp>d__20", assemblyIdentity, "Celeste", 33555692, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeightDisplay.<CameraUp>d__20", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeightDisplay.<CameraUp>d__20",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+Strengths", "Celeste.BlackholeBG.Strengths", "Strengths",
            assemblyIdentity, "Celeste", 33555693, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.Strengths", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.Strengths",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+StreamParticle", "Celeste.BlackholeBG.StreamParticle",
            "StreamParticle", assemblyIdentity, "Celeste", 33555694, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.StreamParticle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.StreamParticle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+Particle", "Celeste.BlackholeBG.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555695, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlackholeBG+SpiralDebris", "Celeste.BlackholeBG.SpiralDebris",
            "SpiralDebris", assemblyIdentity, "Celeste", 33555696, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlackholeBG.SpiralDebris", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlackholeBG.SpiralDebris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Planets+Planet", "Celeste.Planets.Planet", "Planet", assemblyIdentity,
            "Celeste", 33555697, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Planets.Planet", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Planets.Planet",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RainFG+Particle", "Celeste.RainFG.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555698, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RainFG.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RainFG.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StardustFG+Particle", "Celeste.StardustFG.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555699, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StardustFG.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StardustFG.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Starfield+Star", "Celeste.Starfield.Star", "Star", assemblyIdentity,
            "Celeste", 33555700, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Starfield.Star", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Starfield.Star",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DisperseImage+Particle", "Celeste.DisperseImage.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555701, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DisperseImage.Particle", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DisperseImage.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GlassBlockBg+Star", "Celeste.GlassBlockBg.Star", "Star",
            assemblyIdentity, "Celeste", 33555702, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GlassBlockBg.Star", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlockBg.Star",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GlassBlockBg+Ray", "Celeste.GlassBlockBg.Ray", "Ray",
            assemblyIdentity, "Celeste", 33555703, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GlassBlockBg.Ray", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlockBg.Ray",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer+Bolt", "Celeste.LightningRenderer.Bolt", "Bolt",
            assemblyIdentity, "Celeste", 33555704, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer.Bolt", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer.Bolt",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningRenderer+Edge", "Celeste.LightningRenderer.Edge", "Edge",
            assemblyIdentity, "Celeste", 33555705, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningRenderer.Edge", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningRenderer.Edge",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningStrike+Node", "Celeste.LightningStrike.Node", "Node",
            assemblyIdentity, "Celeste", 33555706, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningStrike.Node", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningStrike.Node",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningStrike+<Routine>d__7",
            "Celeste.LightningStrike.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33555707, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningStrike.<Routine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningStrike.<Routine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrierRenderer+Edge", "Celeste.SeekerBarrierRenderer.Edge",
            "Edge", assemblyIdentity, "Celeste", 33555708, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrierRenderer.Edge", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrierRenderer.Edge",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ButtonConfigUI+<>c__DisplayClass14_0",
            "Celeste.ButtonConfigUI.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
            33555709, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ButtonConfigUI.<>c__DisplayClass14_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ButtonConfigUI.<>c__DisplayClass14_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LanguageSelectUI+LanguageOption",
            "Celeste.LanguageSelectUI.LanguageOption", "LanguageOption", assemblyIdentity, "Celeste", 33555710, false,
            new string[] { "Celeste.TextMenu+Item", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LanguageSelectUI.LanguageOption", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LanguageSelectUI.LanguageOption",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LanguageSelectUI+<>c__DisplayClass1_0",
            "Celeste.LanguageSelectUI.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste",
            33555711, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LanguageSelectUI.<>c__DisplayClass1_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.LanguageSelectUI.<>c__DisplayClass1_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PrologueEndingText+<Routine>d__2",
            "Celeste.PrologueEndingText.<Routine>d__2", "<Routine>d__2", assemblyIdentity, "Celeste", 33555712, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PrologueEndingText.<Routine>d__2", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PrologueEndingText.<Routine>d__2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UnlockedPico8Message+<Routine>d__7",
            "Celeste.UnlockedPico8Message.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33555713, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UnlockedPico8Message.<Routine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedPico8Message.<Routine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.UnlockedRemixDisplay+<DisplayRoutine>d__17",
            "Celeste.UnlockedRemixDisplay.<DisplayRoutine>d__17", "<DisplayRoutine>d__17", assemblyIdentity, "Celeste",
            33555714, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.UnlockedRemixDisplay.<DisplayRoutine>d__17", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.UnlockedRemixDisplay.<DisplayRoutine>d__17",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+Particle", "Celeste.BreathingMinigame.Particle",
            "Particle", assemblyIdentity, "Celeste", 33555715, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<Routine>d__56",
            "Celeste.BreathingMinigame.<Routine>d__56", "<Routine>d__56", assemblyIdentity, "Celeste", 33555716, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<Routine>d__56", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<Routine>d__56",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<ShowText>d__57",
            "Celeste.BreathingMinigame.<ShowText>d__57", "<ShowText>d__57", assemblyIdentity, "Celeste", 33555717,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<ShowText>d__57", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<ShowText>d__57",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<FadeGameIn>d__58",
            "Celeste.BreathingMinigame.<FadeGameIn>d__58", "<FadeGameIn>d__58", assemblyIdentity, "Celeste", 33555718,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<FadeGameIn>d__58", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<FadeGameIn>d__58",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<FadeBoxIn>d__59",
            "Celeste.BreathingMinigame.<FadeBoxIn>d__59", "<FadeBoxIn>d__59", assemblyIdentity, "Celeste", 33555719,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<FadeBoxIn>d__59", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<FadeBoxIn>d__59",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<FadeTextTo>d__60",
            "Celeste.BreathingMinigame.<FadeTextTo>d__60", "<FadeTextTo>d__60", assemblyIdentity, "Celeste", 33555720,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<FadeTextTo>d__60", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<FadeTextTo>d__60",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BreathingMinigame+<PopFeather>d__61",
            "Celeste.BreathingMinigame.<PopFeather>d__61", "<PopFeather>d__61", assemblyIdentity, "Celeste", 33555721,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BreathingMinigame.<PopFeather>d__61", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BreathingMinigame.<PopFeather>d__61",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+Fader", "Celeste.TempleBigEyeball.Fader", "Fader",
            assemblyIdentity, "Celeste", 33555722, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.Fader", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.Fader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+<>c", "Celeste.TempleBigEyeball.<>c", "<>c",
            assemblyIdentity, "Celeste", 33555723, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+<>c__DisplayClass14_0",
            "Celeste.TempleBigEyeball.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
            33555724, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.<>c__DisplayClass14_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.<>c__DisplayClass14_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeball+<Burst>d__14",
            "Celeste.TempleBigEyeball.<Burst>d__14", "<Burst>d__14", assemblyIdentity, "Celeste", 33555725, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeball.<Burst>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeball.<Burst>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker+<>c__DisplayClass11_0",
            "Celeste.PlayerSeeker.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity, "Celeste",
            33555726, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker.<>c__DisplayClass11_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker.<>c__DisplayClass11_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker+<IntroSequence>d__11",
            "Celeste.PlayerSeeker.<IntroSequence>d__11", "<IntroSequence>d__11", assemblyIdentity, "Celeste", 33555727,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker.<IntroSequence>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker.<IntroSequence>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerSeeker+<>c__DisplayClass14_0",
            "Celeste.PlayerSeeker.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
            33555728, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerSeeker.<>c__DisplayClass14_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerSeeker.<>c__DisplayClass14_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReflectionHeartStatue+Torch", "Celeste.ReflectionHeartStatue.Torch",
            "Torch", assemblyIdentity, "Celeste", 33555729, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReflectionHeartStatue.Torch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionHeartStatue.Torch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReflectionHeartStatue+<ActivateRoutine>d__14",
            "Celeste.ReflectionHeartStatue.<ActivateRoutine>d__14", "<ActivateRoutine>d__14", assemblyIdentity,
            "Celeste", 33555730, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReflectionHeartStatue.<ActivateRoutine>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionHeartStatue.<ActivateRoutine>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MiniTextboxTrigger+Modes", "Celeste.MiniTextboxTrigger.Modes",
            "Modes", assemblyIdentity, "Celeste", 33555731, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MiniTextboxTrigger.Modes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextboxTrigger.Modes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MiniTextbox+<Routine>d__18", "Celeste.MiniTextbox.<Routine>d__18",
            "<Routine>d__18", assemblyIdentity, "Celeste", 33555732, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MiniTextbox.<Routine>d__18", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextbox.<Routine>d__18",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MiniTextbox+<Close>d__19", "Celeste.MiniTextbox.<Close>d__19",
            "<Close>d__19", assemblyIdentity, "Celeste", 33555733, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MiniTextbox.<Close>d__19", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MiniTextbox.<Close>d__19",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTilesBank+Animation", "Celeste.AnimatedTilesBank.Animation",
            "Animation", assemblyIdentity, "Celeste", 33555734, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTilesBank.Animation", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTilesBank.Animation",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AnimatedTiles+Tile", "Celeste.AnimatedTiles.Tile", "Tile",
            assemblyIdentity, "Celeste", 33555735, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AnimatedTiles.Tile", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AnimatedTiles.Tile",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FinalBossStarfield+Particle", "Celeste.FinalBossStarfield.Particle",
            "Particle", assemblyIdentity, "Celeste", 33555736, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FinalBossStarfield.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FinalBossStarfield.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Godrays+Ray", "Celeste.Godrays.Ray", "Ray", assemblyIdentity,
            "Celeste", 33555737, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Godrays.Ray", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Godrays.Ray",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeatWave+Particle", "Celeste.HeatWave.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555738, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeatWave.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeatWave.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights+Strand", "Celeste.NorthernLights.Strand", "Strand",
            assemblyIdentity, "Celeste", 33555739, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights.Strand", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights.Strand",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights+Node", "Celeste.NorthernLights.Node", "Node",
            assemblyIdentity, "Celeste", 33555740, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights.Node", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights.Node",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights+Particle", "Celeste.NorthernLights.Particle",
            "Particle", assemblyIdentity, "Celeste", 33555741, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Petals+Particle", "Celeste.Petals.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555742, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Petals.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Petals.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreStarsFG+Particle", "Celeste.CoreStarsFG.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555743, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreStarsFG.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreStarsFG.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ReflectionFG+Particle", "Celeste.ReflectionFG.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555744, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ReflectionFG.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionFG.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MirrorFG+Particle", "Celeste.MirrorFG.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555745, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MirrorFG.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MirrorFG.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Tentacles+Side", "Celeste.Tentacles.Side", "Side", assemblyIdentity,
            "Celeste", 33555746, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Tentacles.Side", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Tentacles.Side",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Tentacles+Tentacle", "Celeste.Tentacles.Tentacle", "Tentacle",
            assemblyIdentity, "Celeste", 33555747, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Tentacles.Tentacle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Tentacles.Tentacle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay+Error", "Celeste.FileErrorOverlay.Error", "Error",
            assemblyIdentity, "Celeste", 33555748, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay.Error", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay.Error",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay+<>c__DisplayClass16_0",
            "Celeste.FileErrorOverlay.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity, "Celeste",
            33555749, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay.<>c__DisplayClass16_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay.<>c__DisplayClass16_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay+<Routine>d__16",
            "Celeste.FileErrorOverlay.<Routine>d__16", "<Routine>d__16", assemblyIdentity, "Celeste", 33555750, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay.<Routine>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay.<Routine>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Overlay+<FadeIn>d__5", "Celeste.Overlay.<FadeIn>d__5", "<FadeIn>d__5",
            assemblyIdentity, "Celeste", 33555751, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Overlay.<FadeIn>d__5", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Overlay.<FadeIn>d__5",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Overlay+<FadeOut>d__6", "Celeste.Overlay.<FadeOut>d__6",
            "<FadeOut>d__6", assemblyIdentity, "Celeste", 33555752, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Overlay.<FadeOut>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Overlay.<FadeOut>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TrailManager+Snapshot", "Celeste.TrailManager.Snapshot", "Snapshot",
            assemblyIdentity, "Celeste", 33555753, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TrailManager.Snapshot", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TrailManager.Snapshot",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+CreditNode", "Celeste.Credits.CreditNode", "CreditNode",
            assemblyIdentity, "Celeste", 33555754, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.CreditNode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.CreditNode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+Role", "Celeste.Credits.Role", "Role", assemblyIdentity,
            "Celeste", 33555755, false, new string[] { "Celeste.Credits+CreditNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.Role", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Role",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+Team", "Celeste.Credits.Team", "Team", assemblyIdentity,
            "Celeste", 33555756, false, new string[] { "Celeste.Credits+CreditNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.Team", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Team",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+Thanks", "Celeste.Credits.Thanks", "Thanks", assemblyIdentity,
            "Celeste", 33555757, false, new string[] { "Celeste.Credits+CreditNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.Thanks", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Thanks",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+MultiCredit", "Celeste.Credits.MultiCredit", "MultiCredit",
            assemblyIdentity, "Celeste", 33555758, false,
            new string[] { "Celeste.Credits+CreditNode", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.MultiCredit", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.MultiCredit",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+Ending", "Celeste.Credits.Ending", "Ending", assemblyIdentity,
            "Celeste", 33555759, false, new string[] { "Celeste.Credits+CreditNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+Image", "Celeste.Credits.Image", "Image", assemblyIdentity,
            "Celeste", 33555760, false, new string[] { "Celeste.Credits+CreditNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.Image", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Image",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+ImageRow", "Celeste.Credits.ImageRow", "ImageRow",
            assemblyIdentity, "Celeste", 33555761, false,
            new string[] { "Celeste.Credits+CreditNode", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.ImageRow", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.ImageRow",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Credits+Break", "Celeste.Credits.Break", "Break", assemblyIdentity,
            "Celeste", 33555762, false, new string[] { "Celeste.Credits+CreditNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Credits.Break", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Break",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SaveTheo+<Cutscene>d__7", "Celeste.CS05_SaveTheo.<Cutscene>d__7",
            "<Cutscene>d__7", assemblyIdentity, "Celeste", 33555763, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SaveTheo.<Cutscene>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SaveTheo.<Cutscene>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SaveTheo+<TryToBreakCrystal>d__8",
            "Celeste.CS05_SaveTheo.<TryToBreakCrystal>d__8", "<TryToBreakCrystal>d__8", assemblyIdentity, "Celeste",
            33555764, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SaveTheo.<TryToBreakCrystal>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SaveTheo.<TryToBreakCrystal>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<Cutscene>d__7", "Celeste.CS05_SeeTheo.<Cutscene>d__7",
            "<Cutscene>d__7", assemblyIdentity, "Celeste", 33555765, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<Cutscene>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<Cutscene>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<ZoomIn>d__8", "Celeste.CS05_SeeTheo.<ZoomIn>d__8",
            "<ZoomIn>d__8", assemblyIdentity, "Celeste", 33555766, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<ZoomIn>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<ZoomIn>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<MadelineTurnsAround>d__9",
            "Celeste.CS05_SeeTheo.<MadelineTurnsAround>d__9", "<MadelineTurnsAround>d__9", assemblyIdentity, "Celeste",
            33555767, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<MadelineTurnsAround>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<MadelineTurnsAround>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<WaitABit>d__10", "Celeste.CS05_SeeTheo.<WaitABit>d__10",
            "<WaitABit>d__10", assemblyIdentity, "Celeste", 33555768, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<WaitABit>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<WaitABit>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<MadelineTurnsBackAndBrighten>d__11",
            "Celeste.CS05_SeeTheo.<MadelineTurnsBackAndBrighten>d__11", "<MadelineTurnsBackAndBrighten>d__11",
            assemblyIdentity, "Celeste", 33555769, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<MadelineTurnsBackAndBrighten>d__11", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<MadelineTurnsBackAndBrighten>d__11",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<Brighten>d__12", "Celeste.CS05_SeeTheo.<Brighten>d__12",
            "<Brighten>d__12", assemblyIdentity, "Celeste", 33555770, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<Brighten>d__12", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<Brighten>d__12",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoInMirror+<Cutscene>d__6",
            "Celeste.CS05_TheoInMirror.<Cutscene>d__6", "<Cutscene>d__6", assemblyIdentity, "Celeste", 33555771, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoInMirror.<Cutscene>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoInMirror.<Cutscene>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<Cutscene>d__6", "Celeste.CS05_Entrance.<Cutscene>d__6",
            "<Cutscene>d__6", assemblyIdentity, "Celeste", 33555772, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<Cutscene>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<Cutscene>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<MaddyTurnsRight>d__7",
            "Celeste.CS05_Entrance.<MaddyTurnsRight>d__7", "<MaddyTurnsRight>d__7", assemblyIdentity, "Celeste",
            33555773, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<MaddyTurnsRight>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<MaddyTurnsRight>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<TheoTurns>d__8",
            "Celeste.CS05_Entrance.<TheoTurns>d__8", "<TheoTurns>d__8", assemblyIdentity, "Celeste", 33555774, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<TheoTurns>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<TheoTurns>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<TheoLeaves>d__9",
            "Celeste.CS05_Entrance.<TheoLeaves>d__9", "<TheoLeaves>d__9", assemblyIdentity, "Celeste", 33555775, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<TheoLeaves>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<TheoLeaves>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Slider+Surfaces", "Celeste.Slider.Surfaces", "Surfaces",
            assemblyIdentity, "Celeste", 33555776, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Slider.Surfaces", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Slider.Surfaces",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline+<FirstScene>d__9",
            "Celeste.NPC05_Badeline.<FirstScene>d__9", "<FirstScene>d__9", assemblyIdentity, "Celeste", 33555777, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline.<FirstScene>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline.<FirstScene>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline+<SecondScene>d__10",
            "Celeste.NPC05_Badeline.<SecondScene>d__10", "<SecondScene>d__10", assemblyIdentity, "Celeste", 33555778,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline.<SecondScene>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline.<SecondScene>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline+<>c__DisplayClass11_0",
            "Celeste.NPC05_Badeline.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity, "Celeste",
            33555779, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline.<>c__DisplayClass11_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline.<>c__DisplayClass11_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirror+Frame", "Celeste.TempleMirror.Frame", "Frame",
            assemblyIdentity, "Celeste", 33555780, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirror.Frame", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirror.Frame",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird",
            "Celeste.ForsakenCitySatellite.CodeBird", "CodeBird", assemblyIdentity, "Celeste", 33555781, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+<PulseRoutine>d__28",
            "Celeste.ForsakenCitySatellite.<PulseRoutine>d__28", "<PulseRoutine>d__28", assemblyIdentity, "Celeste",
            33555782, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.<PulseRoutine>d__28", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.<PulseRoutine>d__28",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+<UnlockGem>d__29",
            "Celeste.ForsakenCitySatellite.<UnlockGem>d__29", "<UnlockGem>d__29", assemblyIdentity, "Celeste", 33555783,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.<UnlockGem>d__29", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.<UnlockGem>d__29",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+Blackness", "Celeste.GondolaDarkness.Blackness",
            "Blackness", assemblyIdentity, "Celeste", 33555784, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.Blackness", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.Blackness",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+<Appear>d__7", "Celeste.GondolaDarkness.<Appear>d__7",
            "<Appear>d__7", assemblyIdentity, "Celeste", 33555785, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.<Appear>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.<Appear>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+<Expand>d__8", "Celeste.GondolaDarkness.<Expand>d__8",
            "<Expand>d__8", assemblyIdentity, "Celeste", 33555786, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.<Expand>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.<Expand>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+<Reach>d__9", "Celeste.GondolaDarkness.<Reach>d__9",
            "<Reach>d__9", assemblyIdentity, "Celeste", 33555787, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.<Reach>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.<Reach>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustStyles+DustStyle", "Celeste.DustStyles.DustStyle", "DustStyle",
            assemblyIdentity, "Celeste", 33555788, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustStyles.DustStyle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustStyles.DustStyle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MirrorSurfaces+<>c", "Celeste.MirrorSurfaces.<>c", "<>c",
            assemblyIdentity, "Celeste", 33555789, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MirrorSurfaces.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MirrorSurfaces.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ObjModel+Mesh", "Celeste.ObjModel.Mesh", "Mesh", assemblyIdentity,
            "Celeste", 33555790, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ObjModel.Mesh", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ObjModel.Mesh",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+Layer", "Celeste.CompleteRenderer.Layer", "Layer",
            assemblyIdentity, "Celeste", 33555791, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.Layer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.Layer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+UILayer", "Celeste.CompleteRenderer.UILayer",
            "UILayer", assemblyIdentity, "Celeste", 33555792, false,
            new string[] { "Celeste.CompleteRenderer+Layer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.UILayer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.UILayer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+ImageLayer", "Celeste.CompleteRenderer.ImageLayer",
            "ImageLayer", assemblyIdentity, "Celeste", 33555793, false,
            new string[] { "Celeste.CompleteRenderer+Layer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.ImageLayer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.ImageLayer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+<SlideRoutine>d__23",
            "Celeste.CompleteRenderer.<SlideRoutine>d__23", "<SlideRoutine>d__23", assemblyIdentity, "Celeste",
            33555794, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.<SlideRoutine>d__23", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.<SlideRoutine>d__23",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HiresSnow+Particle", "Celeste.HiresSnow.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555795, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HiresSnow.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HiresSnow.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.KeyboardConfigUI+<>c__DisplayClass12_0",
            "Celeste.KeyboardConfigUI.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste",
            33555796, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.KeyboardConfigUI.<>c__DisplayClass12_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.KeyboardConfigUI.<>c__DisplayClass12_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<DisplayRoutine>d__13",
            "Celeste.Postcard.<DisplayRoutine>d__13", "<DisplayRoutine>d__13", assemblyIdentity, "Celeste", 33555797,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<DisplayRoutine>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<DisplayRoutine>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<EaseIn>d__14", "Celeste.Postcard.<EaseIn>d__14",
            "<EaseIn>d__14", assemblyIdentity, "Celeste", 33555798, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<EaseIn>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<EaseIn>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<EaseButtinIn>d__15", "Celeste.Postcard.<EaseButtinIn>d__15",
            "<EaseButtinIn>d__15", assemblyIdentity, "Celeste", 33555799, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<EaseButtinIn>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<EaseButtinIn>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<EaseOut>d__16", "Celeste.Postcard.<EaseOut>d__16",
            "<EaseOut>d__16", assemblyIdentity, "Celeste", 33555800, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<EaseOut>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<EaseOut>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SaveLoadIcon+<Routine>d__9", "Celeste.SaveLoadIcon.<Routine>d__9",
            "<Routine>d__9", assemblyIdentity, "Celeste", 33555801, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SaveLoadIcon.<Routine>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SaveLoadIcon.<Routine>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+InnerContentMode", "Celeste.TextMenu.InnerContentMode",
            "InnerContentMode", assemblyIdentity, "Celeste", 33555802, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.InnerContentMode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.InnerContentMode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Item", "Celeste.TextMenu.Item", "Item", assemblyIdentity,
            "Celeste", 33555803, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Item", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Item",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Header", "Celeste.TextMenu.Header", "Header",
            assemblyIdentity, "Celeste", 33555804, false, new string[] { "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Header", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Header",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+SubHeader", "Celeste.TextMenu.SubHeader", "SubHeader",
            assemblyIdentity, "Celeste", 33555805, false, new string[] { "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.SubHeader", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.SubHeader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Option`1", "Celeste.TextMenu.Option`1", "Option`1",
            assemblyIdentity, "Celeste", 33555806, false, new string[] { "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Option`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Option`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Slider", "Celeste.TextMenu.Slider", "Slider",
            assemblyIdentity, "Celeste", 33555807, false,
            new string[] { "Celeste.TextMenu+Option`1<System.Int32>", "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Slider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Slider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+OnOff", "Celeste.TextMenu.OnOff", "OnOff", assemblyIdentity,
            "Celeste", 33555808, false,
            new string[] { "Celeste.TextMenu+Option`1<System.Boolean>", "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.OnOff", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.OnOff",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Setting", "Celeste.TextMenu.Setting", "Setting",
            assemblyIdentity, "Celeste", 33555809, false, new string[] { "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Setting", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Setting",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Button", "Celeste.TextMenu.Button", "Button",
            assemblyIdentity, "Celeste", 33555810, false, new string[] { "Celeste.TextMenu+Item", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Button", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Button",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+LanguageButton", "Celeste.TextMenu.LanguageButton",
            "LanguageButton", assemblyIdentity, "Celeste", 33555811, false,
            new string[] { "Celeste.TextMenu+Item", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.LanguageButton", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.LanguageButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+<CloseAndRunRoutine>d__54",
            "Celeste.TextMenu.<CloseAndRunRoutine>d__54", "<CloseAndRunRoutine>d__54", assemblyIdentity, "Celeste",
            33555812, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.<CloseAndRunRoutine>d__54", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.<CloseAndRunRoutine>d__54",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightingRenderer+VertexPositionColorMaskTexture",
            "Celeste.LightingRenderer.VertexPositionColorMaskTexture", "VertexPositionColorMaskTexture",
            assemblyIdentity, "Celeste", 33555813, false,
            new string[] { "System.ValueType", "Microsoft.Xna.Framework.Graphics.IVertexType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightingRenderer.VertexPositionColorMaskTexture", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightingRenderer.VertexPositionColorMaskTexture",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarfieldWipe+Star", "Celeste.StarfieldWipe.Star", "Star",
            assemblyIdentity, "Celeste", 33555814, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarfieldWipe.Star", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarfieldWipe.Star",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PreviewPostcard+<Routine>d__2",
            "Celeste.PreviewPostcard.<Routine>d__2", "<Routine>d__2", assemblyIdentity, "Celeste", 33555815, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PreviewPostcard.<Routine>d__2", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPostcard.<Routine>d__2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GameLoader+<IntroRoutine>d__16",
            "Celeste.GameLoader.<IntroRoutine>d__16", "<IntroRoutine>d__16", assemblyIdentity, "Celeste", 33555816,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GameLoader.<IntroRoutine>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader.<IntroRoutine>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GameLoader+<FadeInOut>d__17", "Celeste.GameLoader.<FadeInOut>d__17",
            "<FadeInOut>d__17", assemblyIdentity, "Celeste", 33555817, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GameLoader.<FadeInOut>d__17", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader.<FadeInOut>d__17",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoonParticle3D+Particle", "Celeste.MoonParticle3D.Particle",
            "Particle", assemblyIdentity, "Celeste", 33555818, false,
            new string[] { "Celeste.Billboard", "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoonParticle3D.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoonParticle3D.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Snow3D+Particle", "Celeste.Snow3D.Particle", "Particle",
            assemblyIdentity, "Celeste", 33555819, false,
            new string[] { "Celeste.Billboard", "Monocle.Component", "System.Object" }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Snow3D.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Snow3D.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+Page", "Celeste.OuiAssistMode.Page", "Page",
            assemblyIdentity, "Celeste", 33555820, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.Page", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.Page",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+<Enter>d__16", "Celeste.OuiAssistMode.<Enter>d__16",
            "<Enter>d__16", assemblyIdentity, "Celeste", 33555821, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.<Enter>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.<Enter>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+<Leave>d__17", "Celeste.OuiAssistMode.<Leave>d__17",
            "<Leave>d__17", assemblyIdentity, "Celeste", 33555822, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.<Leave>d__17", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.<Leave>d__17",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+<InputRoutine>d__18",
            "Celeste.OuiAssistMode.<InputRoutine>d__18", "<InputRoutine>d__18", assemblyIdentity, "Celeste", 33555823,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.<InputRoutine>d__18", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.<InputRoutine>d__18",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreVignette+<TextSequence>d__15",
            "Celeste.CoreVignette.<TextSequence>d__15", "<TextSequence>d__15", assemblyIdentity, "Celeste", 33555824,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreVignette.<TextSequence>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreVignette.<TextSequence>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreVignette+<>c__DisplayClass20_0",
            "Celeste.CoreVignette.<>c__DisplayClass20_0", "<>c__DisplayClass20_0", assemblyIdentity, "Celeste",
            33555825, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreVignette.<>c__DisplayClass20_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreVignette.<>c__DisplayClass20_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BinaryPacker+Element", "Celeste.BinaryPacker.Element", "Element",
            assemblyIdentity, "Celeste", 33555826, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BinaryPacker.Element", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.BinaryPacker.Element",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle", "Celeste.LevelEnter.BSideTitle", "BSideTitle",
            assemblyIdentity, "Celeste", 33555827, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+<Routine>d__5", "Celeste.LevelEnter.<Routine>d__5",
            "<Routine>d__5", assemblyIdentity, "Celeste", 33555828, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.<Routine>d__5", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.<Routine>d__5",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OverworldLoader+<Routine>d__12",
            "Celeste.OverworldLoader.<Routine>d__12", "<Routine>d__12", assemblyIdentity, "Celeste", 33555829, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OverworldLoader.<Routine>d__12", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OverworldLoader.<Routine>d__12",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OverworldReflectionsFall+<Routine>d__7",
            "Celeste.OverworldReflectionsFall.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste", 33555830,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OverworldReflectionsFall.<Routine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OverworldReflectionsFall.<Routine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OverworldReflectionsFall+<MaddyFall>d__8",
            "Celeste.OverworldReflectionsFall.<MaddyFall>d__8", "<MaddyFall>d__8", assemblyIdentity, "Celeste",
            33555831, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OverworldReflectionsFall.<MaddyFall>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OverworldReflectionsFall.<MaddyFall>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelExit+Mode", "Celeste.LevelExit.Mode", "Mode", assemblyIdentity,
            "Celeste", 33555832, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelExit.Mode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelExit.Mode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelExit+<Routine>d__14", "Celeste.LevelExit.<Routine>d__14",
            "<Routine>d__14", assemblyIdentity, "Celeste", 33555833, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelExit.<Routine>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelExit.<Routine>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
