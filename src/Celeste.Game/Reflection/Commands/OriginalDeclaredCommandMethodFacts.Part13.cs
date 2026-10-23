using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart13(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+Item", []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+Header",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+SubHeader",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+Option`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+Slider",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+OnOff",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+Setting",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+Button",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+LanguageButton",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+<CloseAndRunRoutine>d__54",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ViewportAdjustmentUI",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.KeyDoorWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.FallWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.AngledWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DropWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LightingRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LightingRenderer+VertexPositionColorMaskTexture",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarfieldWipe", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarfieldWipe+Star",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OVR", [
                new SourceCommandMethodFacts(100667983, "OVR", "get_Loaded", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100667984, "OVR", "set_Loaded", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100667985, "OVR", "Load", [], [],
                    []),
                new SourceCommandMethodFacts(100667986, "OVR", "Unload", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewPostcard",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewPostcard+<Routine>d__2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewRecording",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GameLoader", []);
            catalog.PublishDeclaredCommandMethods("Celeste.GameLoader+<IntroRoutine>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GameLoader+<FadeInOut>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.IOverlayHandler",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Maddy3D", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MoonParticle3D",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MoonParticle3D+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snow3D", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snow3D+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiJournalGlobal",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiAssistMode", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiAssistMode+Page",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiAssistMode+<Enter>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiAssistMode+<Leave>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiAssistMode+<InputRoutine>d__18",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CoreVignette", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CoreVignette+<TextSequence>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CoreVignette+<>c__DisplayClass20_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Achievement", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Achievements", [
                new SourceCommandMethodFacts(100668034, "Achievements", "ID", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100668035, "Achievements", "Has", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100668036, "Achievements", "Register", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BinaryPacker", [
                new SourceCommandMethodFacts(100668037, "BinaryPacker", "ToBinary", [],
                    [], []),
                new SourceCommandMethodFacts(100668038, "BinaryPacker", "ToBinary", [],
                    [], []),
                new SourceCommandMethodFacts(100668039, "BinaryPacker", "CreateLookupTable", [],
                    [], []),
                new SourceCommandMethodFacts(100668040, "BinaryPacker", "AddLookupValue", [],
                    [], []),
                new SourceCommandMethodFacts(100668041, "BinaryPacker", "WriteElement", [],
                    [], []),
                new SourceCommandMethodFacts(100668042, "BinaryPacker", "ParseValue", [],
                    [], []),
                new SourceCommandMethodFacts(100668043, "BinaryPacker", "FromBinary", [],
                    [], []),
                new SourceCommandMethodFacts(100668044, "BinaryPacker", "ReadElement", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BinaryPacker+Element",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter", [
                new SourceCommandMethodFacts(100668046, "LevelEnter", "Go", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter+BSideTitle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter+BSideTitle+<EaseIn>d__10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter+BSideTitle+<EaseOut>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter+BSideTitle+<FadeTo>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter+<Routine>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainCamera",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainState", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Skybox", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Ring", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainModel", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OverworldLoader",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OverworldLoader+<Routine>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OverworldReflectionsFall",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OverworldReflectionsFall+<Routine>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OverworldReflectionsFall+<MaddyFall>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiJournalDeaths",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TestBreathingGame",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelExit", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelExit+Mode",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelExit+<Routine>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaCompleteTitle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaCompleteTitle+Letter",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MEP", []);
            catalog.PublishDeclaredCommandMethods("Celeste.AudioTrackState",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AudioState", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SeekerBarrier", []);
            catalog.PublishDeclaredCommandMethods("Celeste.TempleCrackedBlock",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DreamHeartGem", []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGem", []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGem+<CollectRoutine>d__35",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGem+<DoFakeRoutineWithBird>d__38",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HeartGem+<PlayerStepForward>d__39",
                []);
        }
    }
}
