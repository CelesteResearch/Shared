using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart21(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.InvisibleBarrier",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key+<NodeRoutine>d__26",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key+<>c__DisplayClass28_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key+<UseRoutine>d__28",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LockBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LockBlock+<UnlockRoutine>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.NegaBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed+<ReturnRoutine>d__30",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed+<>c__DisplayClass32_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed+<>c__DisplayClass33_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SinkingPlatform",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SinkingPlatformLine",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ChaserBarrier", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BloomPoint", []);
            catalog.PublishDeclaredCommandMethods("Celeste.EffectCutout", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Follower", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Leader", [
                new SourceCommandMethodFacts(100669916, "Leader", "StoreStrawberries", [],
                    [], []),
                new SourceCommandMethodFacts(100669917, "Leader", "RestoreStrawberries", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.LightOcclude", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StaticMover", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Switch", [
                new SourceCommandMethodFacts(100669950, "Switch", "Check", [], [],
                    []),
                new SourceCommandMethodFacts(100669951, "Switch", "FinishedCheck", [],
                    [], []),
                new SourceCommandMethodFacts(100669952, "Switch", "CheckLevelFlag", [],
                    [], []),
                new SourceCommandMethodFacts(100669953, "Switch", "SetLevelFlag", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<Sequence>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<OutlineFade>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<TileOut>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<TileIn>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DreamBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DreamBlock+DreamParticle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DreamBlock+<>c__DisplayClass22_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DreamBlock+<Activate>d__34",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.FakeWall", []);
            catalog.PublishDeclaredCommandMethods("Celeste.FakeWall+Modes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.FallingBlock", [
                new SourceCommandMethodFacts(100669993, "FallingBlock", "CreateFinalBossBlock", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.FallingBlock+<Sequence>d__21",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.FallingBlock+<HighlightFade>d__22",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC", [
                new SourceCommandMethodFacts(100670029, "BirdNPC", "FlapSfxCheck", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+Modes", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<Caw>d__27",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<ShowTutorial>d__28",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<HideTutorial>d__29",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<StartleAndFlyAway>d__30",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<FlyAway>d__31",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<ClimbingTutorial>d__32",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<DashingTutorial>d__33",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<DreamJumpTutorial>d__34",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<SuperWallJumpTutorial>d__35",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<HyperJumpTutorial>d__36",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<WaitRoutine>d__37",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<>c__DisplayClass38_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<Startle>d__38",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<FlyTo>d__39",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<MoveToNodesRoutine>d__40",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdNPC+<WaitForLightningOffRoutine>d__41",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroCar", []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroCarBarrier",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroCrusher", []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroCrusher+<Sequence>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroPavement", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Lamp", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Memorial", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MemorialText", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Wire", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SwitchGate", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SwitchGate+<>c__DisplayClass16_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SwitchGate+<>c__DisplayClass16_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SwitchGate+<Sequence>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TouchSwitch", []);
            catalog.PublishDeclaredCommandMethods("Celeste.EventTrigger", []);
            catalog.PublishDeclaredCommandMethods("Celeste.EventTrigger+<>c__DisplayClass10_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.EventTrigger+<Brighten>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.EventTrigger+<Ch9HubTransitionBackgroundToBright>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MusicFadeTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Trigger", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Trigger+PositionModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerCollider",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Refill", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Refill+<RefillRoutine>d__28",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Bridge", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BridgeTile", []);
        }
    }
}
