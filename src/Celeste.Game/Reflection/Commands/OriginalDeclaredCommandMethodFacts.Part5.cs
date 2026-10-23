using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart5(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.GoldenBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.IceBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LightningBreakerBox",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Cassette", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Cassette+UnlockedBSide",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Cassette+UnlockedBSide+<EaseIn>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Cassette+UnlockedBSide+<EaseOut>d__6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Cassette+<CollectRoutine>d__19",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberryPoints",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitGem", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitGem+BgFlash",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SummitGem+<SmashRoutine>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BadelineAutoAnimator",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClimbBlocker", [
                new SourceCommandMethodFacts(100666453, "ClimbBlocker", "Check", [],
                    [], []),
                new SourceCommandMethodFacts(100666454, "ClimbBlocker", "Check", [],
                    [], []),
                new SourceCommandMethodFacts(100666455, "ClimbBlocker", "EdgeCheck", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.CoreModeListener",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DeathEffect", [
                new SourceCommandMethodFacts(100666460, "DeathEffect", "Draw", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GrannyLaughSfx",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LavaRect", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LavaRect+OnlyModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LavaRect+Bubble",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LavaRect+SurfaceBubble",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEndingHook",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PostUpdateHook",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PufferCollider",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SeekerCollider",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SolidOnInvinciblePlayer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SolidOnInvinciblePlayer+Outline",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WaterInteraction",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<Cutscene>d__30",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<ShowPicture>d__31",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<EndingRoutine>d__33",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<Zoom>d__37",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<Play>d__39",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<Loop>d__40",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Ending+<Fade>d__41",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_MissTheBird",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_MissTheBird+<Cutscene>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_MissTheBird+<StandUpFaceLeft>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_MissTheBird+<TakeStepLeft>d__10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_MissTheBird+<TakeStepRight>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_MissTheBird+<FlickerBlackhole>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_MissTheBird+<OpenBlackhole>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FreeBird", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FreeBird+<Cutscene>d__2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Gravestone",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Gravestone+<Cutscene>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Gravestone+<StepForward>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Gravestone+<BadelineAppears>d__10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Gravestone+<SitDown>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Gravestone+<BirdStuff>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Gravestone+<BadelineRejoin>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Diary", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Diary+<Routine>d__3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Guestbook",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Guestbook+<Routine>d__3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Memo", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Memo+MemoPage",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Memo+MemoPage+<EaseIn>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Memo+MemoPage+<Wait>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Memo+MemoPage+<EaseOut>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Memo+<Routine>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS05_TheoPhone",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS05_TheoPhone+<Routine>d__4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS05_TheoPhone+<WalkToPhone>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS05_TheoPhone+<StandBackUp>d__6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+Fill",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<>c__DisplayClass24_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<Routine>d__24",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<SetupLevel>d__25",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<WaitForPlayer>d__26",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<>c__DisplayClass27_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<NextLevel>d__27",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<FadeTo>d__28",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<BadelineApproachWalking>d__29",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<DustyRoutine>d__30",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<BadelineAround>d__31",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS07_Credits+<DoEvent>d__32",
                []);
        }
    }
}
