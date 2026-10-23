using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart15(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.BloomFadeTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LightFadeTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustEdge", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Flagline", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Flagline+Cloth",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CutsceneEntity", [
                new SourceCommandMethodFacts(100668327, "CutsceneEntity", "CameraTo", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.CutsceneEntity+<CameraTo>d__20",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<Cutscene>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<Meet>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<RunAlong>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<LaughAndAirQuotes>d__10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<Laugh>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<StopLaughing>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<OminousZoom>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Granny+<PanToMaddy>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Ending", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Ending+EndingCutsceneDelay",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Ending+EndingCutsceneDelay+<Routine>d__1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Ending+<Cutscene>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS00_Ending+<WaitFor>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS01_Ending", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS01_Ending+<Cutscene>d__4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS01_Ending+<EndCityTrigger>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_Ending", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_Ending+<Cutscene>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_BadelineIntro",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_BadelineIntro+<Cutscene>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_BadelineIntro+<TurnAround>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_BadelineIntro+<RevealBadeline>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_BadelineIntro+<StartLaughing>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_BadelineIntro+<StopLaughing>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_Mirror", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_Mirror+<Cutscene>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_Mirror+<ZoomBack>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_DreamingPhonecall",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_DreamingPhonecall+<>c__DisplayClass6_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_DreamingPhonecall+<>c__DisplayClass6_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_DreamingPhonecall+<Cutscene>d__6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_DreamingPhonecall+<ShowShadowMadeline>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS02_DreamingPhonecall+<WireFalls>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending+BgFlash",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending+<Cutscene>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending+<OshiroTurns>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending+<MoveGhostTo>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending+<GhostSmash>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending+<GhostSmash>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_Ending+<RunPlayerRight>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroClutter",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroClutter+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroClutter+<Cutscene>d__6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroClutter+<Collapse>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop+<Cutscene>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop+<MaddyWalkAway>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop+<MaddyTurnAround>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop+<EnterOshiro>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop+<OshiroGetsAngry>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop+<OshiroTransform>d__18",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroRooftop+<AnxietyAndCameraOut>d__19",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<Cutscene>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<Wander>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<AwkwardPause>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<SuiteShadowAppear>d__10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<SuiteShadowDisrupt>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<Collapse>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<Console>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<JumpBack>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroMasterSuite+<SuiteShadowCeiling>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroHallway2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroHallway2+<Cutscene>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroHallway1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroHallway1+<Cutscene>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroLobby",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroLobby+<>c__DisplayClass9_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroLobby+<>c__DisplayClass9_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroLobby+<Cutscene>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS03_OshiroLobby+<ZoomOut>d__10",
                []);
        }
    }
}
