using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart19(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.Autotiler+Masked",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Autotiler+Tiles",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Autotiler+Generated",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Autotiler+Behaviour",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Autotiler+<>c", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarsBG", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarsBG+Star", []);
            catalog.PublishDeclaredCommandMethods("Celeste.WindSnowFG", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdTutorialGui", [
                new SourceCommandMethodFacts(100669156, "BirdTutorialGui", "ButtonPromptToVirtualButton",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BirdTutorialGui+ButtonPrompt",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+Banner", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+DecalImage",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+FinalFlagDecalImage",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+CoreSwapImage",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+<>c__DisplayClass24_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+<>c__DisplayClass24_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+<>c__DisplayClass25_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+<>c__DisplayClass25_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Decal+<>c__DisplayClass26_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LightBeam", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustEdges", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Textbox", [
                new SourceCommandMethodFacts(100669217, "Textbox", "Say", [], [],
                    []),
                new SourceCommandMethodFacts(100669218, "Textbox", "SayWhileFrozen", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Textbox+<RunRoutine>d__67",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Textbox+<EaseOpen>d__72",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Textbox+<EaseClose>d__73",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Textbox+<SkipDialog>d__74",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Textbox+<Say>d__83",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Textbox+<SayWhileFrozen>d__84",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BestTimeDisplay",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BestTimeDisplay+Modes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DeathsCounter", []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGemDisplay",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGemDisplay+<>c__DisplayClass8_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGemDisplay+<AppearSequence>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SpeedrunTimerDisplay", [
                new SourceCommandMethodFacts(100669251, "SpeedrunTimerDisplay", "CalculateBaseSizes",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100669254, "SpeedrunTimerDisplay", "DrawTime", [],
                    [], []),
                new SourceCommandMethodFacts(100669255, "SpeedrunTimerDisplay", "GetTimeWidth", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberriesCounter",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.FadeWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.WindWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CurtainWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SpotlightWipe", [
                new SourceCommandMethodFacts(100669281, "SpotlightWipe", "DrawSpotlight", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaComplete", [
                new SourceCommandMethodFacts(100669287, "AreaComplete", "Info", [],
                    [], []),
                new SourceCommandMethodFacts(100669288, "AreaComplete", "VersionNumberAndVariants",
                    [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaComplete+<>c__DisplayClass14_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewPortrait",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Billboard", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Overworld", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Overworld+StartMode",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Overworld+InputEntity",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Overworld+<GotoRoutine>d__31",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel", [
                new SourceCommandMethodFacts(100669362, "OuiChapterPanel", "GetCheckpointPreviewName",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+Option",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+<Enter>d__49",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+<Leave>d__53",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+<EaseOut>d__54",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+<StartRoutine>d__56",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+<SwapRoutine>d__58",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+<IncrementStatsDisplay>d__65",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterPanel+<IncrementStats>d__66",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<Enter>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<Leave>d__18",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<EaseOut>d__19",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<AutoAdvanceRoutine>d__21",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<>c__DisplayClass25_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<PerformCh8Unlock>d__25",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<SetupCh9Unlock>d__26",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<>c__DisplayClass27_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiChapterSelect+<PerformCh9Unlock>d__27",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiFileNaming", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiFileNaming+<Enter>d__49",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiFileNaming+<Leave>d__51",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiFileSelect", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiFileSelect+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiFileSelect+<Enter>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiFileSelect+<Leave>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiMainMenu", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiMainMenu+<Enter>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiMainMenu+<Leave>d__18",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiMainMenu+<SlideClimbOutLate>d__19",
                []);
        }
    }
}
