using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart14(SceneEntityCatalog catalog)
        {
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
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenu+<>c", []);
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
                new SourceCommandMethodFacts(100670834, "OVR", "get_Loaded", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670835, "OVR", "set_Loaded", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670836, "OVR", "Load", [], [],
                    []),
                new SourceCommandMethodFacts(100670837, "OVR", "Unload", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewPostcard",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewPostcard+<Routine>d__2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewRecording",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GameLoader", [
                new SourceCommandMethodFacts(100670864, "GameLoader", "_GetNextScene", [],
                    [], []),
                new SourceCommandMethodFacts(100670865, "GameLoader", "checkModSaveDataBackups", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GameLoader+<IntroRoutine>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GameLoader+<FadeInOut>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GameLoader+<>c",
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
                new SourceCommandMethodFacts(100670954, "Achievements", "ID", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670955, "Achievements", "Has", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670956, "Achievements", "Register", [],
                    [], []),
                new SourceCommandMethodFacts(100670957, "Achievements", "orig_Register", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BinaryPacker", [
                new SourceCommandMethodFacts(100670958, "BinaryPacker", "ToBinary", [],
                    [], []),
                new SourceCommandMethodFacts(100670959, "BinaryPacker", "ToBinary", [],
                    [], []),
                new SourceCommandMethodFacts(100670960, "BinaryPacker", "CreateLookupTable", [],
                    [], []),
                new SourceCommandMethodFacts(100670961, "BinaryPacker", "AddLookupValue", [],
                    [], []),
                new SourceCommandMethodFacts(100670962, "BinaryPacker", "WriteElement", [],
                    [], []),
                new SourceCommandMethodFacts(100670963, "BinaryPacker", "ParseValue", [],
                    [], []),
                new SourceCommandMethodFacts(100670964, "BinaryPacker", "FromBinary", [],
                    [], []),
                new SourceCommandMethodFacts(100670965, "BinaryPacker", "ReadElement", [],
                    [], []),
                new SourceCommandMethodFacts(100670967, "BinaryPacker", "IsKeyLikelyToGetUnboxedByEntityData",
                    [], [], []),
                new SourceCommandMethodFacts(100670968, "BinaryPacker", "InternIfUnlikelyToUnbox",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100670969, "BinaryPacker", "ReadRunLengthEncoded", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BinaryPacker+Element",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter", [
                new SourceCommandMethodFacts(100670977, "LevelEnter", "Go", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670981, "LevelEnter", "orig_Go", [],
                    [], []),
                new SourceCommandMethodFacts(100670982, "LevelEnter", "ForceCreate", [],
                    [], []),
                new SourceCommandMethodFacts(100670983, "LevelEnter", "PlayCustomVignette", [],
                    [], []),
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
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter+<EnterWithPostcardRoutine>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnter+<ErrorRoutine>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainCamera",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainState", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Skybox", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Ring", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainModel", [
                new SourceCommandMethodFacts(100671060, "MountainModel", "hasCustomSettings", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainModel+<>c__DisplayClass48_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainModel+<>c__DisplayClass50_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OverworldLoader", [
                new SourceCommandMethodFacts(100671072, "OverworldLoader", "GetCSidePostcard", [],
                    [], []),
            ]);
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
        }
    }
}
