using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart10(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.AbsorbOrb", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BigWaterfall", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BigWaterfall+Layers",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CliffsideWindFlag",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CliffsideWindFlag+Segment",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrystalDebris", [
                new SourceCommandMethodFacts(100669225, "CrystalDebris", "Burst", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.FallEffects", [
                new SourceCommandMethodFacts(100669228, "FallEffects", "Show", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.FallEffects+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MoonCreature", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MoonCreature+TrailNode",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SoundSourceEntity",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitCloud", []);
            catalog.PublishDeclaredCommandMethods("Celeste.TempleEye", []);
            catalog.PublishDeclaredCommandMethods("Celeste.TemplePortalTorch",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SpawnableAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SpawnerAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Spawn", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SpawnManager", [
                new SourceCommandMethodFacts(100669264, "SpawnManager", "Init", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BackgroundFadeIn",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BreathingRumbler",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BridgeFixed", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CoreMessage", []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGemDoor", []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGemDoor+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGemDoor+WhiteLine",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGemDoor+<Routine>d__32",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.KevinsPC", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelUpEffect", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OshiroLobbyBell",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ReflectionTentacles",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ReflectionTentacles+Tentacle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ReflectionTentacles+MTextureComparer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ReflectionTentacles+UVSet",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RidgeGate", []);
            catalog.PublishDeclaredCommandMethods("Celeste.RidgeGate+<>c__DisplayClass4_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RidgeGate+<EnterSequence>d__4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarJumpController",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarJumpController+Ray",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarJumpBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager", [
                new SourceCommandMethodFacts(100669372, "AscendManager", "Mod", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager+Streaks",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager+Streaks+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager+Clouds",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager+Clouds+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager+Fader",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager+<Routine>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AscendManager+<FadeTo>d__19",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitCheckpoint",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitCheckpoint+ConfettiRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitCheckpoint+ConfettiRenderer+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitGemManager",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitGemManager+Gem",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitGemManager+<Routine>d__4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TheoPhone", []);
            catalog.PublishDeclaredCommandMethods("Celeste.UnlockEverythingThingy",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.UnlockEverythingThingy+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.UnlockEverythingThingy+<>c__DisplayClass1_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdPathTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BlackholeStrengthTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DetachStrawberryTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DetachStrawberryTrigger+<>c__DisplayClass4_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DetachStrawberryTrigger+<DetatchFollower>d__4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DetachStrawberryTrigger+<DetatchFollower>d__2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleTrigger", [
                new SourceCommandMethodFacts(100669464, "RumbleTrigger", "ManuallyTrigger", [],
                    [], []),
                new SourceCommandMethodFacts(100669466, "RumbleTrigger", "ManuallyTrigger", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleTrigger+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleTrigger+<RumbleRoutine>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SpawnFacingTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GrabbyIcon", []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage03",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage03+<Routine>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage05",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage05+Display",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage05+Display+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage05+Display+<Routine>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage05+<Routine>d__4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage04",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage04+<>c__DisplayClass5_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage04+<Routine>d__6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage06",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaveDashPage06+<Routine>d__2",
                []);
        }
    }
}
