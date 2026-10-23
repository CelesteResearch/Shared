using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup
{
    public static partial class InstalledLogicalTypeFacts
    {
        private static void RegisterPart8(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.Selfie+<EndRoutine>d__11", "Celeste.Selfie.<EndRoutine>d__11",
                "<EndRoutine>d__11", assemblyIdentity, "Celeste", 33556034, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Selfie.<EndRoutine>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Selfie.<EndRoutine>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TotalStrawberriesDisplay", "Celeste.TotalStrawberriesDisplay",
                "TotalStrawberriesDisplay", assemblyIdentity, "Celeste", 33556035, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TotalStrawberriesDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TotalStrawberriesDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController", "Celeste.WindController", "WindController",
                assemblyIdentity, "Celeste", 33556036, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController+Patterns", "Celeste.WindController.Patterns",
                "Patterns", assemblyIdentity, "Celeste", 33556037, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController.Patterns", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController.Patterns",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController+<AlternatingSequence>d__21",
                "Celeste.WindController.<AlternatingSequence>d__21", "<AlternatingSequence>d__21", assemblyIdentity,
                "Celeste", 33556038, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController.<AlternatingSequence>d__21", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController.<AlternatingSequence>d__21",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController+<RightOnOffSequence>d__22",
                "Celeste.WindController.<RightOnOffSequence>d__22", "<RightOnOffSequence>d__22", assemblyIdentity,
                "Celeste", 33556039, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController.<RightOnOffSequence>d__22", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController.<RightOnOffSequence>d__22",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController+<LeftOnOffSequence>d__23",
                "Celeste.WindController.<LeftOnOffSequence>d__23", "<LeftOnOffSequence>d__23", assemblyIdentity,
                "Celeste",
                33556040, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController.<LeftOnOffSequence>d__23", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController.<LeftOnOffSequence>d__23",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController+<RightOnOffFastSequence>d__24",
                "Celeste.WindController.<RightOnOffFastSequence>d__24", "<RightOnOffFastSequence>d__24",
                assemblyIdentity,
                "Celeste", 33556041, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController.<RightOnOffFastSequence>d__24", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController.<RightOnOffFastSequence>d__24",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController+<LeftOnOffFastSequence>d__25",
                "Celeste.WindController.<LeftOnOffFastSequence>d__25", "<LeftOnOffFastSequence>d__25", assemblyIdentity,
                "Celeste", 33556042, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController.<LeftOnOffFastSequence>d__25", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController.<LeftOnOffFastSequence>d__25",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamStars", "Celeste.DreamStars", "DreamStars", assemblyIdentity,
                "Celeste", 33556043, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamStars", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamStars",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamStars+Stars", "Celeste.DreamStars.Stars", "Stars",
                assemblyIdentity, "Celeste", 33556044, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamStars.Stars", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamStars.Stars",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler", "Celeste.Autotiler", "Autotiler", assemblyIdentity,
                "Celeste", 33556045, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler+TerrainType", "Celeste.Autotiler.TerrainType",
                "TerrainType", assemblyIdentity, "Celeste", 33556046, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler.TerrainType", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler.TerrainType",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler+Masked", "Celeste.Autotiler.Masked", "Masked",
                assemblyIdentity, "Celeste", 33556047, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler.Masked", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler.Masked",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler+Tiles", "Celeste.Autotiler.Tiles", "Tiles",
                assemblyIdentity, "Celeste", 33556048, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler.Tiles", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler.Tiles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler+Generated", "Celeste.Autotiler.Generated", "Generated",
                assemblyIdentity, "Celeste", 33556049, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler.Generated", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler.Generated",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler+Behaviour", "Celeste.Autotiler.Behaviour", "Behaviour",
                assemblyIdentity, "Celeste", 33556050, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler.Behaviour", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler.Behaviour",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler+<>c", "Celeste.Autotiler.<>c", "<>c", assemblyIdentity,
                "Celeste", 33556051, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler+<>c__DisplayClass7_0",
                "Celeste.Autotiler.<>c__DisplayClass7_0", "<>c__DisplayClass7_0", assemblyIdentity, "Celeste", 33556052,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler.<>c__DisplayClass7_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler.<>c__DisplayClass7_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarsBG", "Celeste.StarsBG", "StarsBG", assemblyIdentity,
                "Celeste",
                33556053, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarsBG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarsBG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarsBG+Star", "Celeste.StarsBG.Star", "Star", assemblyIdentity,
                "Celeste", 33556054, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarsBG.Star", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarsBG.Star",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindSnowFG", "Celeste.WindSnowFG", "WindSnowFG", assemblyIdentity,
                "Celeste", 33556055, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindSnowFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindSnowFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdTutorialGui", "Celeste.BirdTutorialGui", "BirdTutorialGui",
                assemblyIdentity, "Celeste", 33556056, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdTutorialGui", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdTutorialGui",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdTutorialGui+ButtonPrompt",
                "Celeste.BirdTutorialGui.ButtonPrompt",
                "ButtonPrompt", assemblyIdentity, "Celeste", 33556057, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdTutorialGui.ButtonPrompt", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdTutorialGui.ButtonPrompt",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal", "Celeste.Decal", "Decal", assemblyIdentity, "Celeste",
                33556058, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+Banner", "Celeste.Decal.Banner", "Banner", assemblyIdentity,
                "Celeste", 33556059, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.Banner", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.Banner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+DecalImage", "Celeste.Decal.DecalImage", "DecalImage",
                assemblyIdentity, "Celeste", 33556060, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.DecalImage", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.DecalImage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+FinalFlagDecalImage", "Celeste.Decal.FinalFlagDecalImage",
                "FinalFlagDecalImage", assemblyIdentity, "Celeste", 33556061, false,
                ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.FinalFlagDecalImage", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.FinalFlagDecalImage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+CoreSwapImage", "Celeste.Decal.CoreSwapImage",
                "CoreSwapImage",
                assemblyIdentity, "Celeste", 33556062, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.CoreSwapImage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.CoreSwapImage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c__DisplayClass24_0",
                "Celeste.Decal.<>c__DisplayClass24_0",
                "<>c__DisplayClass24_0", assemblyIdentity, "Celeste", 33556063, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c__DisplayClass24_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c__DisplayClass24_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c__DisplayClass24_1",
                "Celeste.Decal.<>c__DisplayClass24_1",
                "<>c__DisplayClass24_1", assemblyIdentity, "Celeste", 33556064, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c__DisplayClass24_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c__DisplayClass24_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c__DisplayClass25_0",
                "Celeste.Decal.<>c__DisplayClass25_0",
                "<>c__DisplayClass25_0", assemblyIdentity, "Celeste", 33556065, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c__DisplayClass25_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c__DisplayClass25_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c__DisplayClass25_1",
                "Celeste.Decal.<>c__DisplayClass25_1",
                "<>c__DisplayClass25_1", assemblyIdentity, "Celeste", 33556066, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c__DisplayClass25_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c__DisplayClass25_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c__DisplayClass26_0",
                "Celeste.Decal.<>c__DisplayClass26_0",
                "<>c__DisplayClass26_0", assemblyIdentity, "Celeste", 33556067, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c__DisplayClass26_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c__DisplayClass26_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+FlagSwapImage", "Celeste.Decal.FlagSwapImage",
                "FlagSwapImage",
                assemblyIdentity, "Celeste", 33556068, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.FlagSwapImage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.FlagSwapImage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c", "Celeste.Decal.<>c", "<>c", assemblyIdentity,
                "Celeste",
                33556069, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c__DisplayClass38_0",
                "Celeste.Decal.<>c__DisplayClass38_0",
                "<>c__DisplayClass38_0", assemblyIdentity, "Celeste", 33556070, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c__DisplayClass38_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c__DisplayClass38_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal+<>c__DisplayClass38_1",
                "Celeste.Decal.<>c__DisplayClass38_1",
                "<>c__DisplayClass38_1", assemblyIdentity, "Celeste", 33556071, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal.<>c__DisplayClass38_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal.<>c__DisplayClass38_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightBeam", "Celeste.LightBeam", "LightBeam", assemblyIdentity,
                "Celeste", 33556072, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightBeam", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightBeam",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustEdges", "Celeste.DustEdges", "DustEdges", assemblyIdentity,
                "Celeste", 33556073, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustEdges", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustEdges",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox", "Celeste.Textbox", "Textbox", assemblyIdentity,
                "Celeste",
                33556074, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox+<RunRoutine>d__67", "Celeste.Textbox.<RunRoutine>d__67",
                "<RunRoutine>d__67", assemblyIdentity, "Celeste", 33556075, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox.<RunRoutine>d__67", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox.<RunRoutine>d__67",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox+<EaseOpen>d__72", "Celeste.Textbox.<EaseOpen>d__72",
                "<EaseOpen>d__72", assemblyIdentity, "Celeste", 33556076, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox.<EaseOpen>d__72", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox.<EaseOpen>d__72",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox+<EaseClose>d__73", "Celeste.Textbox.<EaseClose>d__73",
                "<EaseClose>d__73", assemblyIdentity, "Celeste", 33556077, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox.<EaseClose>d__73", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox.<EaseClose>d__73",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox+<SkipDialog>d__74", "Celeste.Textbox.<SkipDialog>d__74",
                "<SkipDialog>d__74", assemblyIdentity, "Celeste", 33556078, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox.<SkipDialog>d__74", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox.<SkipDialog>d__74",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox+<Say>d__83", "Celeste.Textbox.<Say>d__83", "<Say>d__83",
                assemblyIdentity, "Celeste", 33556079, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox.<Say>d__83", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox.<Say>d__83",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox+<SayWhileFrozen>d__84",
                "Celeste.Textbox.<SayWhileFrozen>d__84", "<SayWhileFrozen>d__84", assemblyIdentity, "Celeste", 33556080,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox.<SayWhileFrozen>d__84", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox.<SayWhileFrozen>d__84",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BestTimeDisplay", "Celeste.BestTimeDisplay", "BestTimeDisplay",
                assemblyIdentity, "Celeste", 33556081, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BestTimeDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BestTimeDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BestTimeDisplay+Modes", "Celeste.BestTimeDisplay.Modes", "Modes",
                assemblyIdentity, "Celeste", 33556082, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BestTimeDisplay.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BestTimeDisplay.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DeathsCounter", "Celeste.DeathsCounter", "DeathsCounter",
                assemblyIdentity, "Celeste", 33556083, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DeathsCounter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DeathsCounter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDisplay", "Celeste.HeartGemDisplay", "HeartGemDisplay",
                assemblyIdentity, "Celeste", 33556084, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDisplay+<>c__DisplayClass8_0",
                "Celeste.HeartGemDisplay.<>c__DisplayClass8_0", "<>c__DisplayClass8_0", assemblyIdentity, "Celeste",
                33556085, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDisplay.<>c__DisplayClass8_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDisplay.<>c__DisplayClass8_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDisplay+<AppearSequence>d__17",
                "Celeste.HeartGemDisplay.<AppearSequence>d__17", "<AppearSequence>d__17", assemblyIdentity, "Celeste",
                33556086, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDisplay.<AppearSequence>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDisplay.<AppearSequence>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpeedrunTimerDisplay", "Celeste.SpeedrunTimerDisplay",
                "SpeedrunTimerDisplay", assemblyIdentity, "Celeste", 33556087, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpeedrunTimerDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpeedrunTimerDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberriesCounter", "Celeste.StrawberriesCounter",
                "StrawberriesCounter", assemblyIdentity, "Celeste", 33556088, false,
                ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberriesCounter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberriesCounter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FadeWipe", "Celeste.FadeWipe", "FadeWipe", assemblyIdentity,
                "Celeste", 33556089, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FadeWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FadeWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindWipe", "Celeste.WindWipe", "WindWipe", assemblyIdentity,
                "Celeste", 33556090, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CurtainWipe", "Celeste.CurtainWipe", "CurtainWipe",
                assemblyIdentity,
                "Celeste", 33556091, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CurtainWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CurtainWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpotlightWipe", "Celeste.SpotlightWipe", "SpotlightWipe",
                assemblyIdentity, "Celeste", 33556092, false,
                ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpotlightWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpotlightWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaComplete", "Celeste.AreaComplete", "AreaComplete",
                assemblyIdentity, "Celeste", 33556093, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaComplete", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaComplete",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaComplete+<>c__DisplayClass14_0",
                "Celeste.AreaComplete.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
                33556094, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaComplete.<>c__DisplayClass14_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaComplete.<>c__DisplayClass14_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewPortrait", "Celeste.PreviewPortrait", "PreviewPortrait",
                assemblyIdentity, "Celeste", 33556095, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewPortrait", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPortrait",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Billboard", "Celeste.Billboard", "Billboard", assemblyIdentity,
                "Celeste", 33556096, false, ["Monocle.Component", "System.Object"], [true],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Billboard", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Billboard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainRenderer", "Celeste.MountainRenderer", "MountainRenderer",
                assemblyIdentity, "Celeste", 33556097, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overworld", "Celeste.Overworld", "Overworld", assemblyIdentity,
                "Celeste", 33556098, false,
                [
                    "Monocle.Scene", "Celeste.IOverlayHandler", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overworld", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overworld",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overworld+StartMode", "Celeste.Overworld.StartMode", "StartMode",
                assemblyIdentity, "Celeste", 33556099, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overworld.StartMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overworld.StartMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overworld+InputEntity", "Celeste.Overworld.InputEntity",
                "InputEntity", assemblyIdentity, "Celeste", 33556100, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overworld.InputEntity", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overworld.InputEntity",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overworld+<GotoRoutine>d__31",
                "Celeste.Overworld.<GotoRoutine>d__31",
                "<GotoRoutine>d__31", assemblyIdentity, "Celeste", 33556101, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overworld.<GotoRoutine>d__31", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overworld.<GotoRoutine>d__31",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel", "Celeste.OuiChapterPanel", "OuiChapterPanel",
                assemblyIdentity, "Celeste", 33556102, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+Option", "Celeste.OuiChapterPanel.Option",
                "Option",
                assemblyIdentity, "Celeste", 33556103, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.Option", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.Option",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<Enter>d__49",
                "Celeste.OuiChapterPanel.<Enter>d__49",
                "<Enter>d__49", assemblyIdentity, "Celeste", 33556104, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<Enter>d__49", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<Enter>d__49",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<Leave>d__53",
                "Celeste.OuiChapterPanel.<Leave>d__53",
                "<Leave>d__53", assemblyIdentity, "Celeste", 33556105, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<Leave>d__53", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<Leave>d__53",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<EaseOut>d__54",
                "Celeste.OuiChapterPanel.<EaseOut>d__54", "<EaseOut>d__54", assemblyIdentity, "Celeste", 33556106,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<EaseOut>d__54", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<EaseOut>d__54",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<StartRoutine>d__56",
                "Celeste.OuiChapterPanel.<StartRoutine>d__56", "<StartRoutine>d__56", assemblyIdentity, "Celeste",
                33556107,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<StartRoutine>d__56", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<StartRoutine>d__56",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<SwapRoutine>d__58",
                "Celeste.OuiChapterPanel.<SwapRoutine>d__58", "<SwapRoutine>d__58", assemblyIdentity, "Celeste",
                33556108,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<SwapRoutine>d__58", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<SwapRoutine>d__58",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<IncrementStatsDisplay>d__65",
                "Celeste.OuiChapterPanel.<IncrementStatsDisplay>d__65", "<IncrementStatsDisplay>d__65",
                assemblyIdentity,
                "Celeste", 33556109, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<IncrementStatsDisplay>d__65", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<IncrementStatsDisplay>d__65",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<IncrementStats>d__66",
                "Celeste.OuiChapterPanel.<IncrementStats>d__66", "<IncrementStats>d__66", assemblyIdentity, "Celeste",
                33556110, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<IncrementStats>d__66", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<IncrementStats>d__66",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<>c__DisplayClass22_0",
                "Celeste.OuiChapterPanel.<>c__DisplayClass22_0", "<>c__DisplayClass22_0", assemblyIdentity, "Celeste",
                33556111, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<>c__DisplayClass22_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<>c__DisplayClass22_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<>c__DisplayClass22_1",
                "Celeste.OuiChapterPanel.<>c__DisplayClass22_1", "<>c__DisplayClass22_1", assemblyIdentity, "Celeste",
                33556112, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<>c__DisplayClass22_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<>c__DisplayClass22_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<EnterClose>d__18",
                "Celeste.OuiChapterPanel.<EnterClose>d__18", "<EnterClose>d__18", assemblyIdentity, "Celeste", 33556113,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<EnterClose>d__18", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<EnterClose>d__18",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel+<StartRoutine>d__23",
                "Celeste.OuiChapterPanel.<StartRoutine>d__23", "<StartRoutine>d__23", assemblyIdentity, "Celeste",
                33556114,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel.<StartRoutine>d__23", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel.<StartRoutine>d__23",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect", "Celeste.OuiChapterSelect", "OuiChapterSelect",
                assemblyIdentity, "Celeste", 33556115, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<Enter>d__17",
                "Celeste.OuiChapterSelect.<Enter>d__17", "<Enter>d__17", assemblyIdentity, "Celeste", 33556116, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<Enter>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<Enter>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<Leave>d__18",
                "Celeste.OuiChapterSelect.<Leave>d__18", "<Leave>d__18", assemblyIdentity, "Celeste", 33556117, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<Leave>d__18", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<Leave>d__18",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<EaseOut>d__19",
                "Celeste.OuiChapterSelect.<EaseOut>d__19", "<EaseOut>d__19", assemblyIdentity, "Celeste", 33556118,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<EaseOut>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<EaseOut>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<AutoAdvanceRoutine>d__21",
                "Celeste.OuiChapterSelect.<AutoAdvanceRoutine>d__21", "<AutoAdvanceRoutine>d__21", assemblyIdentity,
                "Celeste", 33556119, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<AutoAdvanceRoutine>d__21", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<AutoAdvanceRoutine>d__21",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<>c__DisplayClass25_0",
                "Celeste.OuiChapterSelect.<>c__DisplayClass25_0", "<>c__DisplayClass25_0", assemblyIdentity, "Celeste",
                33556120, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<>c__DisplayClass25_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<>c__DisplayClass25_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<PerformCh8Unlock>d__25",
                "Celeste.OuiChapterSelect.<PerformCh8Unlock>d__25", "<PerformCh8Unlock>d__25", assemblyIdentity,
                "Celeste",
                33556121, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<PerformCh8Unlock>d__25", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<PerformCh8Unlock>d__25",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<SetupCh9Unlock>d__26",
                "Celeste.OuiChapterSelect.<SetupCh9Unlock>d__26", "<SetupCh9Unlock>d__26", assemblyIdentity, "Celeste",
                33556122, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<SetupCh9Unlock>d__26", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<SetupCh9Unlock>d__26",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<>c__DisplayClass27_0",
                "Celeste.OuiChapterSelect.<>c__DisplayClass27_0", "<>c__DisplayClass27_0", assemblyIdentity, "Celeste",
                33556123, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<>c__DisplayClass27_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<>c__DisplayClass27_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<PerformCh9Unlock>d__27",
                "Celeste.OuiChapterSelect.<PerformCh9Unlock>d__27", "<PerformCh9Unlock>d__27", assemblyIdentity,
                "Celeste",
                33556124, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<PerformCh9Unlock>d__27", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<PerformCh9Unlock>d__27",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<>c__DisplayClass23_0",
                "Celeste.OuiChapterSelect.<>c__DisplayClass23_0", "<>c__DisplayClass23_0", assemblyIdentity, "Celeste",
                33556125, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<>c__DisplayClass23_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<>c__DisplayClass23_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<EaseOut>d__28",
                "Celeste.OuiChapterSelect.<EaseOut>d__28", "<EaseOut>d__28", assemblyIdentity, "Celeste", 33556126,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<EaseOut>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<EaseOut>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect+<Enter>d__27",
                "Celeste.OuiChapterSelect.<Enter>d__27", "<Enter>d__27", assemblyIdentity, "Celeste", 33556127, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect.<Enter>d__27", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect.<Enter>d__27",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileNaming", "Celeste.OuiFileNaming", "OuiFileNaming",
                assemblyIdentity, "Celeste", 33556128, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileNaming", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileNaming",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileNaming+<Enter>d__49", "Celeste.OuiFileNaming.<Enter>d__49",
                "<Enter>d__49", assemblyIdentity, "Celeste", 33556129, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileNaming.<Enter>d__49", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileNaming.<Enter>d__49",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileNaming+<Leave>d__51", "Celeste.OuiFileNaming.<Leave>d__51",
                "<Leave>d__51", assemblyIdentity, "Celeste", 33556130, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileNaming.<Leave>d__51", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileNaming.<Leave>d__51",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect", "Celeste.OuiFileSelect", "OuiFileSelect",
                assemblyIdentity, "Celeste", 33556131, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect+<>c", "Celeste.OuiFileSelect.<>c", "<>c",
                assemblyIdentity, "Celeste", 33556132, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect+<Enter>d__7", "Celeste.OuiFileSelect.<Enter>d__7",
                "<Enter>d__7", assemblyIdentity, "Celeste", 33556133, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect.<Enter>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect.<Enter>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect+<Leave>d__9", "Celeste.OuiFileSelect.<Leave>d__9",
                "<Leave>d__9", assemblyIdentity, "Celeste", 33556134, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect.<Leave>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect.<Leave>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect+<Enter>d__4", "Celeste.OuiFileSelect.<Enter>d__4",
                "<Enter>d__4", assemblyIdentity, "Celeste", 33556135, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect.<Enter>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect.<Enter>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect+<Leave>d__6", "Celeste.OuiFileSelect.<Leave>d__6",
                "<Leave>d__6", assemblyIdentity, "Celeste", 33556136, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect.<Leave>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect.<Leave>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu", "Celeste.OuiMainMenu", "OuiMainMenu",
                assemblyIdentity,
                "Celeste", 33556137, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu+<Enter>d__17", "Celeste.OuiMainMenu.<Enter>d__17",
                "<Enter>d__17", assemblyIdentity, "Celeste", 33556138, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu.<Enter>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu.<Enter>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu+<Leave>d__18", "Celeste.OuiMainMenu.<Leave>d__18",
                "<Leave>d__18", assemblyIdentity, "Celeste", 33556139, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu.<Leave>d__18", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu.<Leave>d__18",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu+<SlideClimbOutLate>d__19",
                "Celeste.OuiMainMenu.<SlideClimbOutLate>d__19", "<SlideClimbOutLate>d__19", assemblyIdentity, "Celeste",
                33556140, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu.<SlideClimbOutLate>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu.<SlideClimbOutLate>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu+<>c", "Celeste.OuiMainMenu.<>c", "<>c",
                assemblyIdentity,
                "Celeste", 33556141, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu+<>c__DisplayClass17_0",
                "Celeste.OuiMainMenu.<>c__DisplayClass17_0", "<>c__DisplayClass17_0", assemblyIdentity, "Celeste",
                33556142,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu.<>c__DisplayClass17_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu.<>c__DisplayClass17_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiOptions", "Celeste.OuiOptions", "OuiOptions", assemblyIdentity,
                "Celeste", 33556143, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiOptions", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiOptions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiOptions+<Enter>d__8", "Celeste.OuiOptions.<Enter>d__8",
                "<Enter>d__8", assemblyIdentity, "Celeste", 33556144, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiOptions.<Enter>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiOptions.<Enter>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiOptions+<Leave>d__9", "Celeste.OuiOptions.<Leave>d__9",
                "<Leave>d__9", assemblyIdentity, "Celeste", 33556145, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiOptions.<Leave>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiOptions.<Leave>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen", "Celeste.OuiTitleScreen", "OuiTitleScreen",
                assemblyIdentity, "Celeste", 33556146, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen+<>c__DisplayClass14_0",
                "Celeste.OuiTitleScreen.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste",
                33556147, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen.<>c__DisplayClass14_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen.<>c__DisplayClass14_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen+<Enter>d__14",
                "Celeste.OuiTitleScreen.<Enter>d__14",
                "<Enter>d__14", assemblyIdentity, "Celeste", 33556148, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen.<Enter>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen.<Enter>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen+<>c__DisplayClass15_0",
                "Celeste.OuiTitleScreen.<>c__DisplayClass15_0", "<>c__DisplayClass15_0", assemblyIdentity, "Celeste",
                33556149, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen.<>c__DisplayClass15_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen.<>c__DisplayClass15_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen+<Leave>d__15",
                "Celeste.OuiTitleScreen.<Leave>d__15",
                "<Leave>d__15", assemblyIdentity, "Celeste", 33556150, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen.<Leave>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen.<Leave>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen+<FadeBgTo>d__16",
                "Celeste.OuiTitleScreen.<FadeBgTo>d__16", "<FadeBgTo>d__16", assemblyIdentity, "Celeste", 33556151,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen.<FadeBgTo>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen.<FadeBgTo>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen+<>c", "Celeste.OuiTitleScreen.<>c", "<>c",
                assemblyIdentity, "Celeste", 33556152, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Oui", "Celeste.Oui", "Oui", assemblyIdentity, "Celeste", 33556153,
                true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Oui", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Oui",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Poem", "Celeste.Poem", "Poem", assemblyIdentity, "Celeste",
                33556154,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Poem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Poem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Poem+Particle", "Celeste.Poem.Particle", "Particle",
                assemblyIdentity,
                "Celeste", 33556155, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Poem.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Poem.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TestWipes", "Celeste.TestWipes", "TestWipes", assemblyIdentity,
                "Celeste", 33556156, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TestWipes", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TestWipes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TestWipes+<routine>d__3", "Celeste.TestWipes.<routine>d__3",
                "<routine>d__3", assemblyIdentity, "Celeste", 33556157, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TestWipes.<routine>d__3", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TestWipes.<routine>d__3",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitVignette", "Celeste.SummitVignette", "SummitVignette",
                assemblyIdentity, "Celeste", 33556158, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitVignette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText", "Celeste.FancyText", "FancyText", assemblyIdentity,
                "Celeste", 33556159, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Node", "Celeste.FancyText.Node", "Node",
                assemblyIdentity,
                "Celeste", 33556160, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Node", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Node",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Char", "Celeste.FancyText.Char", "Char",
                assemblyIdentity,
                "Celeste", 33556161, false, ["Celeste.FancyText+Node", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Char", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Char",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Portrait", "Celeste.FancyText.Portrait", "Portrait",
                assemblyIdentity, "Celeste", 33556162, false, ["Celeste.FancyText+Node", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Portrait", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Portrait",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Wait", "Celeste.FancyText.Wait", "Wait",
                assemblyIdentity,
                "Celeste", 33556163, false, ["Celeste.FancyText+Node", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Wait", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Wait",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Trigger", "Celeste.FancyText.Trigger", "Trigger",
                assemblyIdentity, "Celeste", 33556164, false, ["Celeste.FancyText+Node", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Trigger", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Trigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+NewLine", "Celeste.FancyText.NewLine", "NewLine",
                assemblyIdentity, "Celeste", 33556165, false, ["Celeste.FancyText+Node", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.NewLine", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.NewLine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+NewPage", "Celeste.FancyText.NewPage", "NewPage",
                assemblyIdentity, "Celeste", 33556166, false, ["Celeste.FancyText+Node", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.NewPage", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.NewPage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Anchors", "Celeste.FancyText.Anchors", "Anchors",
                assemblyIdentity, "Celeste", 33556167, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Anchors", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Anchors",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Anchor", "Celeste.FancyText.Anchor", "Anchor",
                assemblyIdentity, "Celeste", 33556168, false, ["Celeste.FancyText+Node", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Anchor", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Anchor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText+Text", "Celeste.FancyText.Text", "Text",
                assemblyIdentity,
                "Celeste", 33556169, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText.Text", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText.Text",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MTN", "Celeste.MTN", "MTN", assemblyIdentity, "Celeste", 33556170,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MTN", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MTN",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlaybackData", "Celeste.PlaybackData", "PlaybackData",
                assemblyIdentity, "Celeste", 33556171, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlaybackData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlaybackData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameplayBuffers", "Celeste.GameplayBuffers", "GameplayBuffers",
                assemblyIdentity, "Celeste", 33556172, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameplayBuffers", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameplayBuffers",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockGenerator", "Celeste.ClutterBlockGenerator",
                "ClutterBlockGenerator", assemblyIdentity, "Celeste", 33556173, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockGenerator", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockGenerator",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockGenerator+Tile", "Celeste.ClutterBlockGenerator.Tile",
                "Tile", assemblyIdentity, "Celeste", 33556174, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockGenerator.Tile", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockGenerator.Tile",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockGenerator+TextureSet",
                "Celeste.ClutterBlockGenerator.TextureSet", "TextureSet", assemblyIdentity, "Celeste", 33556175, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockGenerator.TextureSet", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockGenerator.TextureSet",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockGenerator+<>c", "Celeste.ClutterBlockGenerator.<>c",
                "<>c", assemblyIdentity, "Celeste", 33556176, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockGenerator.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockGenerator.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ColorGrade", "Celeste.ColorGrade", "ColorGrade", assemblyIdentity,
                "Celeste", 33556177, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ColorGrade", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ColorGrade",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Commands", "Celeste.Commands", "Commands", assemblyIdentity,
                "Celeste", 33556178, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Commands", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Commands",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Commands+<>c", "Celeste.Commands.<>c", "<>c", assemblyIdentity,
                "Celeste", 33556179, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Commands.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Commands.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Commands+MeshData", "Celeste.Commands.MeshData", "MeshData",
                assemblyIdentity, "Celeste", 33556180, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Commands.MeshData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Commands.MeshData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Commands+<>O", "Celeste.Commands.<>O", "<>O", assemblyIdentity,
                "Celeste", 33556181, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Commands.<>O", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Commands.<>O",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Commands+<>c__DisplayClass10_0",
                "Celeste.Commands.<>c__DisplayClass10_0", "<>c__DisplayClass10_0", assemblyIdentity, "Celeste",
                33556182,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Commands.<>c__DisplayClass10_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Commands.<>c__DisplayClass10_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Commands+<>c__DisplayClass17_0",
                "Celeste.Commands.<>c__DisplayClass17_0", "<>c__DisplayClass17_0", assemblyIdentity, "Celeste",
                33556183,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Commands.<>c__DisplayClass17_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Commands.<>c__DisplayClass17_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Depths", "Celeste.Depths", "Depths", assemblyIdentity, "Celeste",
                33556184, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Depths", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Depths",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Dialog", "Celeste.Dialog", "Dialog", assemblyIdentity, "Celeste",
                33556185, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Dialog", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Dialog",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Dialog+<>c", "Celeste.Dialog.<>c", "<>c", assemblyIdentity,
                "Celeste",
                33556186, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Dialog.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Dialog.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Dialog+<>c__DisplayClass4_0",
                "Celeste.Dialog.<>c__DisplayClass4_0",
                "<>c__DisplayClass4_0", assemblyIdentity, "Celeste", 33556187, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Dialog.<>c__DisplayClass4_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Dialog.<>c__DisplayClass4_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Dialog+<>c__DisplayClass8_0",
                "Celeste.Dialog.<>c__DisplayClass8_0",
                "<>c__DisplayClass8_0", assemblyIdentity, "Celeste", 33556188, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Dialog.<>c__DisplayClass8_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Dialog.<>c__DisplayClass8_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Audio", "Celeste.Audio", "Audio", assemblyIdentity, "Celeste",
                33556189, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Audio", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Audio",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Audio+Banks", "Celeste.Audio.Banks", "Banks", assemblyIdentity,
                "Celeste", 33556190, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Audio.Banks", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Audio.Banks",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Audio+<>c", "Celeste.Audio.<>c", "<>c", assemblyIdentity,
                "Celeste",
                33556191, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Audio.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Audio.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Fonts", "Celeste.Fonts", "Fonts", assemblyIdentity, "Celeste",
                33556192, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Fonts", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Fonts",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Fonts+<>c", "Celeste.Fonts.<>c", "<>c", assemblyIdentity,
                "Celeste",
                33556193, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Fonts.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Fonts.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ActiveFont", "Celeste.ActiveFont", "ActiveFont", assemblyIdentity,
                "Celeste", 33556194, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ActiveFont", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ActiveFont",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameplayRenderer", "Celeste.GameplayRenderer", "GameplayRenderer",
                assemblyIdentity, "Celeste", 33556195, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameplayRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameplayRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HudRenderer", "Celeste.HudRenderer", "HudRenderer",
                assemblyIdentity,
                "Celeste", 33556196, false, ["Celeste.HiresRenderer", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HudRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HudRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Glitch", "Celeste.Glitch", "Glitch", assemblyIdentity, "Celeste",
                33556197, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Glitch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Glitch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MenuOptions", "Celeste.MenuOptions", "MenuOptions",
                assemblyIdentity,
                "Celeste", 33556198, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MenuOptions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MenuOptions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MenuOptions+<>c", "Celeste.MenuOptions.<>c", "<>c",
                assemblyIdentity,
                "Celeste", 33556199, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MenuOptions.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MenuOptions.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MenuOptions+<>c__DisplayClass1_0",
                "Celeste.MenuOptions.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste",
                33556200,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MenuOptions.<>c__DisplayClass1_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MenuOptions.<>c__DisplayClass1_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ParticleTypes", "Celeste.ParticleTypes", "ParticleTypes",
                assemblyIdentity, "Celeste", 33556201, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ParticleTypes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ParticleTypes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DeathData", "Celeste.DeathData", "DeathData", assemblyIdentity,
                "Celeste", 33556202, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DeathData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DeathData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerInventory", "Celeste.PlayerInventory", "PlayerInventory",
                assemblyIdentity, "Celeste", 33556203, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerInventory", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerInventory",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData", "Celeste.SaveData", "SaveData", assemblyIdentity,
                "Celeste", 33556204, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c", "Celeste.SaveData.<>c", "<>c", assemblyIdentity,
                "Celeste", 33556205, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass62_0",
                "Celeste.SaveData.<>c__DisplayClass62_0", "<>c__DisplayClass62_0", assemblyIdentity, "Celeste",
                33556206,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass62_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass62_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass62_1",
                "Celeste.SaveData.<>c__DisplayClass62_1", "<>c__DisplayClass62_1", assemblyIdentity, "Celeste",
                33556207,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass62_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass62_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass64_0",
                "Celeste.SaveData.<>c__DisplayClass64_0", "<>c__DisplayClass64_0", assemblyIdentity, "Celeste",
                33556208,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass64_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass64_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass65_0",
                "Celeste.SaveData.<>c__DisplayClass65_0", "<>c__DisplayClass65_0", assemblyIdentity, "Celeste",
                33556209,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass65_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass65_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass66_0",
                "Celeste.SaveData.<>c__DisplayClass66_0", "<>c__DisplayClass66_0", assemblyIdentity, "Celeste",
                33556210,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass66_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass66_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass68_0",
                "Celeste.SaveData.<>c__DisplayClass68_0", "<>c__DisplayClass68_0", assemblyIdentity, "Celeste",
                33556211,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass68_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass68_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass68_1",
                "Celeste.SaveData.<>c__DisplayClass68_1", "<>c__DisplayClass68_1", assemblyIdentity, "Celeste",
                33556212,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass68_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass68_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData+<>c__DisplayClass9_0",
                "Celeste.SaveData.<>c__DisplayClass9_0", "<>c__DisplayClass9_0", assemblyIdentity, "Celeste", 33556213,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData.<>c__DisplayClass9_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData.<>c__DisplayClass9_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Session", "Celeste.Session", "Session", assemblyIdentity,
                "Celeste",
                33556214, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Session", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Session",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Session+Counter", "Celeste.Session.Counter", "Counter",
                assemblyIdentity, "Celeste", 33556215, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Session.Counter", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Session.Counter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Session+CoreModes", "Celeste.Session.CoreModes", "CoreModes",
                assemblyIdentity, "Celeste", 33556216, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Session.CoreModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Session.CoreModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Session+Slider", "Celeste.Session.Slider", "Slider",
                assemblyIdentity,
                "Celeste", 33556217, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Session.Slider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Session.Slider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Session+SerializationOnly", "Celeste.Session.SerializationOnly",
                "SerializationOnly", assemblyIdentity, "Celeste", 33556218, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Session.SerializationOnly", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Session.SerializationOnly",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Session+SerializationOnly+Slider",
                "Celeste.Session.SerializationOnly.Slider", "Slider", assemblyIdentity, "Celeste", 33556219, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Session.SerializationOnly.Slider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Session.SerializationOnly.Slider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EntityID", "Celeste.EntityID", "EntityID", assemblyIdentity,
                "Celeste", 33556220, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EntityID", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.EntityID",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleAmount", "Celeste.RumbleAmount", "RumbleAmount",
                assemblyIdentity, "Celeste", 33556221, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleAmount", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleAmount",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpeedrunType", "Celeste.SpeedrunType", "SpeedrunType",
                assemblyIdentity, "Celeste", 33556222, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpeedrunType", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpeedrunType",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ScreenshakeAmount", "Celeste.ScreenshakeAmount",
                "ScreenshakeAmount",
                assemblyIdentity, "Celeste", 33556223, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ScreenshakeAmount", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ScreenshakeAmount",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GrabModes", "Celeste.GrabModes", "GrabModes", assemblyIdentity,
                "Celeste", 33556224, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GrabModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GrabModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrouchDashModes", "Celeste.CrouchDashModes", "CrouchDashModes",
                assemblyIdentity, "Celeste", 33556225, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrouchDashModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrouchDashModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Settings", "Celeste.Settings", "Settings", assemblyIdentity,
                "Celeste", 33556226, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Settings", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Settings",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Assists", "Celeste.Assists", "Assists", assemblyIdentity,
                "Celeste",
                33556227, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Assists", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Assists",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Assists+DashModes", "Celeste.Assists.DashModes", "DashModes",
                assemblyIdentity, "Celeste", 33556228, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Assists.DashModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Assists.DashModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StaminaDisplay", "Celeste.StaminaDisplay", "StaminaDisplay",
                assemblyIdentity, "Celeste", 33556229, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StaminaDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StaminaDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ExitBlock", "Celeste.ExitBlock", "ExitBlock", assemblyIdentity,
                "Celeste", 33556230, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ExitBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ExitBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MovingPlatform", "Celeste.MovingPlatform", "MovingPlatform",
                assemblyIdentity, "Celeste", 33556231, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MovingPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MovingPlatform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MovingPlatformLine", "Celeste.MovingPlatformLine",
                "MovingPlatformLine", assemblyIdentity, "Celeste", 33556232, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MovingPlatformLine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MovingPlatformLine",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RotatingPlatform", "Celeste.RotatingPlatform", "RotatingPlatform",
                assemblyIdentity, "Celeste", 33556233, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RotatingPlatform", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RotatingPlatform",
                []);
        }
    }
}
