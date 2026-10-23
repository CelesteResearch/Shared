using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup
{
    public static partial class InstalledLogicalTypeFacts
    {
        private static void RegisterPart2(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker+<EnumerateEntities>d__33`1",
                "Monocle.Tracker.<EnumerateEntities>d__33`1", "<EnumerateEntities>d__33`1", assemblyIdentity, "Celeste",
                33554834, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker.<EnumerateEntities>d__33`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker.<EnumerateEntities>d__33`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker+<EnumerateComponents>d__39`1",
                "Monocle.Tracker.<EnumerateComponents>d__39`1", "<EnumerateComponents>d__39`1", assemblyIdentity,
                "Celeste",
                33554835, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker.<EnumerateComponents>d__39`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker.<EnumerateComponents>d__39`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker+<>c", "Monocle.Tracker.<>c", "<>c", assemblyIdentity,
                "Celeste", 33554836, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker+<>c__DisplayClass14_0",
                "Monocle.Tracker.<>c__DisplayClass14_0", "<>c__DisplayClass14_0", assemblyIdentity, "Celeste", 33554837,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker.<>c__DisplayClass14_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker.<>c__DisplayClass14_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker+<>c__DisplayClass14_1",
                "Monocle.Tracker.<>c__DisplayClass14_1", "<>c__DisplayClass14_1", assemblyIdentity, "Celeste", 33554838,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker.<>c__DisplayClass14_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker.<>c__DisplayClass14_1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracked", "Monocle.Tracked", "Tracked", assemblyIdentity,
                "Celeste",
                33554839, false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracked", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracked",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualAsset", "Monocle.VirtualAsset", "VirtualAsset",
                assemblyIdentity, "Celeste", 33554840, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualAsset", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualAsset",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture", "Monocle.VirtualTexture", "VirtualTexture",
                assemblyIdentity, "Celeste", 33554841, false, ["Monocle.VirtualAsset", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture+<>c__DisplayClass45_0",
                "Monocle.VirtualTexture.<>c__DisplayClass45_0", "<>c__DisplayClass45_0", assemblyIdentity, "Celeste",
                33554842, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture.<>c__DisplayClass45_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture.<>c__DisplayClass45_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture+<>c__DisplayClass48_0",
                "Monocle.VirtualTexture.<>c__DisplayClass48_0", "<>c__DisplayClass48_0", assemblyIdentity, "Celeste",
                33554843, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture.<>c__DisplayClass48_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture.<>c__DisplayClass48_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture+<>c__DisplayClass50_0",
                "Monocle.VirtualTexture.<>c__DisplayClass50_0", "<>c__DisplayClass50_0", assemblyIdentity, "Celeste",
                33554844, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture.<>c__DisplayClass50_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture.<>c__DisplayClass50_0",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture+<>c__DisplayClass50_1",
                "Monocle.VirtualTexture.<>c__DisplayClass50_1", "<>c__DisplayClass50_1", assemblyIdentity, "Celeste",
                33554845, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture.<>c__DisplayClass50_1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture.<>c__DisplayClass50_1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture+<>c__DisplayClass50_2",
                "Monocle.VirtualTexture.<>c__DisplayClass50_2", "<>c__DisplayClass50_2", assemblyIdentity, "Celeste",
                33554846, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture.<>c__DisplayClass50_2", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture.<>c__DisplayClass50_2",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture+<>c__DisplayClass50_3",
                "Monocle.VirtualTexture.<>c__DisplayClass50_3", "<>c__DisplayClass50_3", assemblyIdentity, "Celeste",
                33554847, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture.<>c__DisplayClass50_3", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture.<>c__DisplayClass50_3",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualRenderTarget", "Monocle.VirtualRenderTarget",
                "VirtualRenderTarget", assemblyIdentity, "Celeste", 33554848, false,
                ["Monocle.VirtualAsset", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualRenderTarget", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualRenderTarget",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualContent", "Monocle.VirtualContent", "VirtualContent",
                assemblyIdentity, "Celeste", 33554849, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualContent", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualContent",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualMap`1", "Monocle.VirtualMap`1", "VirtualMap`1",
                assemblyIdentity, "Celeste", 33554850, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualMap`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualMap`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Language", "Celeste.Language", "Language", assemblyIdentity,
                "Celeste", 33554851, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Language", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Language",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Language+<>c", "Celeste.Language.<>c", "<>c", assemblyIdentity,
                "Celeste", 33554852, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Language.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Language.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Language+<>c__DisplayClass12_0",
                "Celeste.Language.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste",
                33554853,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Language.<>c__DisplayClass12_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Language.<>c__DisplayClass12_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Language+<>c__DisplayClass16_0",
                "Celeste.Language.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity, "Celeste",
                33554854,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Language.<>c__DisplayClass16_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Language.<>c__DisplayClass16_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Language+<_GetLanguageText>d__16",
                "Celeste.Language.<_GetLanguageText>d__16", "<_GetLanguageText>d__16", assemblyIdentity, "Celeste",
                33554855, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<System.String>",
                    "System.Collections.IEnumerable", "System.Collections.Generic.IEnumerator`1<System.String>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Language.<_GetLanguageText>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Language.<_GetLanguageText>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisconnectedControllerUI", "Celeste.DisconnectedControllerUI",
                "DisconnectedControllerUI", assemblyIdentity, "Celeste", 33554856, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisconnectedControllerUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisconnectedControllerUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock", "Celeste.BounceBlock", "BounceBlock",
                assemblyIdentity,
                "Celeste", 33554857, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock+States", "Celeste.BounceBlock.States", "States",
                assemblyIdentity, "Celeste", 33554858, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock.States", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock.States",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock+RespawnDebris", "Celeste.BounceBlock.RespawnDebris",
                "RespawnDebris", assemblyIdentity, "Celeste", 33554859, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock.RespawnDebris", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock.RespawnDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock+BreakDebris", "Celeste.BounceBlock.BreakDebris",
                "BreakDebris", assemblyIdentity, "Celeste", 33554860, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock.BreakDebris", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock.BreakDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlock", "Celeste.CassetteBlock", "CassetteBlock",
                assemblyIdentity, "Celeste", 33554861, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlock+Modes", "Celeste.CassetteBlock.Modes", "Modes",
                assemblyIdentity, "Celeste", 33554862, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlock.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlock.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlock+BoxSide", "Celeste.CassetteBlock.BoxSide",
                "BoxSide",
                assemblyIdentity, "Celeste", 33554863, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlock.BoxSide", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlock.BoxSide",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlockManager", "Celeste.CassetteBlockManager",
                "CassetteBlockManager", assemblyIdentity, "Celeste", 33554864, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlockManager", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlockManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FloatySpaceBlock", "Celeste.FloatySpaceBlock", "FloatySpaceBlock",
                assemblyIdentity, "Celeste", 33554865, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FloatySpaceBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FloatySpaceBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell", "Celeste.CS10_Farewell", "CS10_Farewell",
                assemblyIdentity, "Celeste", 33554866, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<Cutscene>d__9",
                "Celeste.CS10_Farewell.<Cutscene>d__9",
                "<Cutscene>d__9", assemblyIdentity, "Celeste", 33554867, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<Cutscene>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<Cutscene>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<WaitForGranny>d__10",
                "Celeste.CS10_Farewell.<WaitForGranny>d__10", "<WaitForGranny>d__10", assemblyIdentity, "Celeste",
                33554868,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<WaitForGranny>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<WaitForGranny>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<Laugh>d__11", "Celeste.CS10_Farewell.<Laugh>d__11",
                "<Laugh>d__11", assemblyIdentity, "Celeste", 33554869, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<Laugh>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<Laugh>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<StopLaughing>d__12",
                "Celeste.CS10_Farewell.<StopLaughing>d__12", "<StopLaughing>d__12", assemblyIdentity, "Celeste",
                33554870,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<StopLaughing>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<StopLaughing>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<StepForward>d__13",
                "Celeste.CS10_Farewell.<StepForward>d__13", "<StepForward>d__13", assemblyIdentity, "Celeste", 33554871,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<StepForward>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<StepForward>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<GrannyDisappear>d__14",
                "Celeste.CS10_Farewell.<GrannyDisappear>d__14", "<GrannyDisappear>d__14", assemblyIdentity, "Celeste",
                33554872, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<GrannyDisappear>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<GrannyDisappear>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<FadeToWhite>d__15",
                "Celeste.CS10_Farewell.<FadeToWhite>d__15", "<FadeToWhite>d__15", assemblyIdentity, "Celeste", 33554873,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<FadeToWhite>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<FadeToWhite>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell+<DoFadeToWhite>d__16",
                "Celeste.CS10_Farewell.<DoFadeToWhite>d__16", "<DoFadeToWhite>d__16", assemblyIdentity, "Celeste",
                33554874,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell.<DoFadeToWhite>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell.<DoFadeToWhite>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch", "Celeste.CS10_FinalLaunch", "CS10_FinalLaunch",
                assemblyIdentity, "Celeste", 33554875, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<Cutscene>d__14",
                "Celeste.CS10_FinalLaunch.<Cutscene>d__14", "<Cutscene>d__14", assemblyIdentity, "Celeste", 33554876,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<Cutscene>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<Cutscene>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<>c__DisplayClass15_0",
                "Celeste.CS10_FinalLaunch.<>c__DisplayClass15_0", "<>c__DisplayClass15_0", assemblyIdentity, "Celeste",
                33554877, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<>c__DisplayClass15_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<>c__DisplayClass15_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<WaveCamera>d__16",
                "Celeste.CS10_FinalLaunch.<WaveCamera>d__16", "<WaveCamera>d__16", assemblyIdentity, "Celeste",
                33554878,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<WaveCamera>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<WaveCamera>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch+<BirdRoutine>d__17",
                "Celeste.CS10_FinalLaunch.<BirdRoutine>d__17", "<BirdRoutine>d__17", assemblyIdentity, "Celeste",
                33554879,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch.<BirdRoutine>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch.<BirdRoutine>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom", "Celeste.CS10_FinalRoom", "CS10_FinalRoom",
                assemblyIdentity, "Celeste", 33554880, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom+<Cutscene>d__5",
                "Celeste.CS10_FinalRoom.<Cutscene>d__5", "<Cutscene>d__5", assemblyIdentity, "Celeste", 33554881, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom.<Cutscene>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom.<Cutscene>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom+<BadelineAppears>d__6",
                "Celeste.CS10_FinalRoom.<BadelineAppears>d__6", "<BadelineAppears>d__6", assemblyIdentity, "Celeste",
                33554882, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom.<BadelineAppears>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom.<BadelineAppears>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom+<BadelineVanishes>d__7",
                "Celeste.CS10_FinalRoom.<BadelineVanishes>d__7", "<BadelineVanishes>d__7", assemblyIdentity, "Celeste",
                33554883, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom.<BadelineVanishes>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom.<BadelineVanishes>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarRotateSpinner", "Celeste.StarRotateSpinner",
                "StarRotateSpinner",
                assemblyIdentity, "Celeste", 33554884, false,
                [
                    "Celeste.RotateSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarRotateSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarRotateSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarTrackSpinner", "Celeste.StarTrackSpinner", "StarTrackSpinner",
                assemblyIdentity, "Celeste", 33554885, false,
                [
                    "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarTrackSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarTrackSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumbleWallOnRumble", "Celeste.CrumbleWallOnRumble",
                "CrumbleWallOnRumble", assemblyIdentity, "Celeste", 33554886, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumbleWallOnRumble", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumbleWallOnRumble",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock", "Celeste.CrushBlock", "CrushBlock", assemblyIdentity,
                "Celeste", 33554887, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+Axes", "Celeste.CrushBlock.Axes", "Axes",
                assemblyIdentity,
                "Celeste", 33554888, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.Axes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.Axes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+MoveState", "Celeste.CrushBlock.MoveState",
                "MoveState",
                assemblyIdentity, "Celeste", 33554889, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.MoveState", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.MoveState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+<>c__DisplayClass39_0",
                "Celeste.CrushBlock.<>c__DisplayClass39_0", "<>c__DisplayClass39_0", assemblyIdentity, "Celeste",
                33554890,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.<>c__DisplayClass39_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.<>c__DisplayClass39_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+<>c__DisplayClass41_0",
                "Celeste.CrushBlock.<>c__DisplayClass41_0", "<>c__DisplayClass41_0", assemblyIdentity, "Celeste",
                33554891,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.<>c__DisplayClass41_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.<>c__DisplayClass41_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock+<AttackSequence>d__41",
                "Celeste.CrushBlock.<AttackSequence>d__41", "<AttackSequence>d__41", assemblyIdentity, "Celeste",
                33554892,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock.<AttackSequence>d__41", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock.<AttackSequence>d__41",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlock", "Celeste.GlassBlock", "GlassBlock", assemblyIdentity,
                "Celeste", 33554893, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlock+Line", "Celeste.GlassBlock.Line", "Line",
                assemblyIdentity,
                "Celeste", 33554894, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlock.Line", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlock.Line",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GoldenBlock", "Celeste.GoldenBlock", "GoldenBlock",
                assemblyIdentity,
                "Celeste", 33554895, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GoldenBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GoldenBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IceBlock", "Celeste.IceBlock", "IceBlock", assemblyIdentity,
                "Celeste", 33554896, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IceBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IceBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningBreakerBox", "Celeste.LightningBreakerBox",
                "LightningBreakerBox", assemblyIdentity, "Celeste", 33554897, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningBreakerBox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningBreakerBox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette", "Celeste.Cassette", "Cassette", assemblyIdentity,
                "Celeste", 33554898, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide", "Celeste.Cassette.UnlockedBSide",
                "UnlockedBSide", assemblyIdentity, "Celeste", 33554899, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide+<EaseIn>d__5",
                "Celeste.Cassette.UnlockedBSide.<EaseIn>d__5", "<EaseIn>d__5", assemblyIdentity, "Celeste", 33554900,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide.<EaseIn>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide.<EaseIn>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+UnlockedBSide+<EaseOut>d__6",
                "Celeste.Cassette.UnlockedBSide.<EaseOut>d__6", "<EaseOut>d__6", assemblyIdentity, "Celeste", 33554901,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.UnlockedBSide.<EaseOut>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.UnlockedBSide.<EaseOut>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette+<CollectRoutine>d__19",
                "Celeste.Cassette.<CollectRoutine>d__19", "<CollectRoutine>d__19", assemblyIdentity, "Celeste",
                33554902,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette.<CollectRoutine>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette.<CollectRoutine>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberryPoints", "Celeste.StrawberryPoints", "StrawberryPoints",
                assemblyIdentity, "Celeste", 33554903, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberryPoints", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberryPoints",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGem", "Celeste.SummitGem", "SummitGem", assemblyIdentity,
                "Celeste", 33554904, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGem+BgFlash", "Celeste.SummitGem.BgFlash", "BgFlash",
                assemblyIdentity, "Celeste", 33554905, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGem.BgFlash", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGem.BgFlash",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGem+<SmashRoutine>d__11",
                "Celeste.SummitGem.<SmashRoutine>d__11", "<SmashRoutine>d__11", assemblyIdentity, "Celeste", 33554906,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGem.<SmashRoutine>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGem.<SmashRoutine>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BadelineAutoAnimator", "Celeste.BadelineAutoAnimator",
                "BadelineAutoAnimator", assemblyIdentity, "Celeste", 33554907, false,
                ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BadelineAutoAnimator", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BadelineAutoAnimator",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClimbBlocker", "Celeste.ClimbBlocker", "ClimbBlocker",
                assemblyIdentity, "Celeste", 33554908, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClimbBlocker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClimbBlocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreModeListener", "Celeste.CoreModeListener", "CoreModeListener",
                assemblyIdentity, "Celeste", 33554909, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreModeListener", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreModeListener",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DeathEffect", "Celeste.DeathEffect", "DeathEffect",
                assemblyIdentity,
                "Celeste", 33554910, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DeathEffect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DeathEffect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GrannyLaughSfx", "Celeste.GrannyLaughSfx", "GrannyLaughSfx",
                assemblyIdentity, "Celeste", 33554911, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GrannyLaughSfx", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GrannyLaughSfx",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect", "Celeste.LavaRect", "LavaRect", assemblyIdentity,
                "Celeste", 33554912, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect+OnlyModes", "Celeste.LavaRect.OnlyModes", "OnlyModes",
                assemblyIdentity, "Celeste", 33554913, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect.OnlyModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect.OnlyModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect+Bubble", "Celeste.LavaRect.Bubble", "Bubble",
                assemblyIdentity, "Celeste", 33554914, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect.Bubble", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect.Bubble",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect+SurfaceBubble", "Celeste.LavaRect.SurfaceBubble",
                "SurfaceBubble", assemblyIdentity, "Celeste", 33554915, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect.SurfaceBubble", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect.SurfaceBubble",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEndingHook", "Celeste.LevelEndingHook", "LevelEndingHook",
                assemblyIdentity, "Celeste", 33554916, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEndingHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEndingHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PostUpdateHook", "Celeste.PostUpdateHook", "PostUpdateHook",
                assemblyIdentity, "Celeste", 33554917, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PostUpdateHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PostUpdateHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PufferCollider", "Celeste.PufferCollider", "PufferCollider",
                assemblyIdentity, "Celeste", 33554918, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PufferCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PufferCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerCollider", "Celeste.SeekerCollider", "SeekerCollider",
                assemblyIdentity, "Celeste", 33554919, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SolidOnInvinciblePlayer", "Celeste.SolidOnInvinciblePlayer",
                "SolidOnInvinciblePlayer", assemblyIdentity, "Celeste", 33554920, false,
                ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SolidOnInvinciblePlayer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SolidOnInvinciblePlayer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SolidOnInvinciblePlayer+Outline",
                "Celeste.SolidOnInvinciblePlayer.Outline", "Outline", assemblyIdentity, "Celeste", 33554921, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SolidOnInvinciblePlayer.Outline", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SolidOnInvinciblePlayer.Outline",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaterInteraction", "Celeste.WaterInteraction", "WaterInteraction",
                assemblyIdentity, "Celeste", 33554922, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaterInteraction", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaterInteraction",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending", "Celeste.CS10_Ending", "CS10_Ending",
                assemblyIdentity,
                "Celeste", 33554923, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<>c", "Celeste.CS10_Ending.<>c", "<>c",
                assemblyIdentity,
                "Celeste", 33554924, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<Cutscene>d__30",
                "Celeste.CS10_Ending.<Cutscene>d__30",
                "<Cutscene>d__30", assemblyIdentity, "Celeste", 33554925, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<Cutscene>d__30", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<Cutscene>d__30",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<ShowPicture>d__31",
                "Celeste.CS10_Ending.<ShowPicture>d__31", "<ShowPicture>d__31", assemblyIdentity, "Celeste", 33554926,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<ShowPicture>d__31", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<ShowPicture>d__31",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<EndingRoutine>d__33",
                "Celeste.CS10_Ending.<EndingRoutine>d__33", "<EndingRoutine>d__33", assemblyIdentity, "Celeste",
                33554927,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<EndingRoutine>d__33", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<EndingRoutine>d__33",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<Zoom>d__37", "Celeste.CS10_Ending.<Zoom>d__37",
                "<Zoom>d__37", assemblyIdentity, "Celeste", 33554928, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<Zoom>d__37", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<Zoom>d__37",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<Play>d__39", "Celeste.CS10_Ending.<Play>d__39",
                "<Play>d__39", assemblyIdentity, "Celeste", 33554929, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<Play>d__39", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<Play>d__39",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<Loop>d__40", "Celeste.CS10_Ending.<Loop>d__40",
                "<Loop>d__40", assemblyIdentity, "Celeste", 33554930, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<Loop>d__40", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<Loop>d__40",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<Fade>d__41", "Celeste.CS10_Ending.<Fade>d__41",
                "<Fade>d__41", assemblyIdentity, "Celeste", 33554931, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<Fade>d__41", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<Fade>d__41",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending+<EndingRoutine>d__2",
                "Celeste.CS10_Ending.<EndingRoutine>d__2", "<EndingRoutine>d__2", assemblyIdentity, "Celeste", 33554932,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending.<EndingRoutine>d__2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending.<EndingRoutine>d__2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird", "Celeste.CS10_MissTheBird", "CS10_MissTheBird",
                assemblyIdentity, "Celeste", 33554933, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird+<Cutscene>d__8",
                "Celeste.CS10_MissTheBird.<Cutscene>d__8", "<Cutscene>d__8", assemblyIdentity, "Celeste", 33554934,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird.<Cutscene>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird.<Cutscene>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird+<StandUpFaceLeft>d__9",
                "Celeste.CS10_MissTheBird.<StandUpFaceLeft>d__9", "<StandUpFaceLeft>d__9", assemblyIdentity, "Celeste",
                33554935, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird.<StandUpFaceLeft>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird.<StandUpFaceLeft>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird+<TakeStepLeft>d__10",
                "Celeste.CS10_MissTheBird.<TakeStepLeft>d__10", "<TakeStepLeft>d__10", assemblyIdentity, "Celeste",
                33554936, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird.<TakeStepLeft>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird.<TakeStepLeft>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird+<TakeStepRight>d__11",
                "Celeste.CS10_MissTheBird.<TakeStepRight>d__11", "<TakeStepRight>d__11", assemblyIdentity, "Celeste",
                33554937, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird.<TakeStepRight>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird.<TakeStepRight>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird+<FlickerBlackhole>d__12",
                "Celeste.CS10_MissTheBird.<FlickerBlackhole>d__12", "<FlickerBlackhole>d__12", assemblyIdentity,
                "Celeste",
                33554938, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird.<FlickerBlackhole>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird.<FlickerBlackhole>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird+<OpenBlackhole>d__13",
                "Celeste.CS10_MissTheBird.<OpenBlackhole>d__13", "<OpenBlackhole>d__13", assemblyIdentity, "Celeste",
                33554939, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird.<OpenBlackhole>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird.<OpenBlackhole>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FreeBird", "Celeste.CS10_FreeBird", "CS10_FreeBird",
                assemblyIdentity, "Celeste", 33554940, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FreeBird", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FreeBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FreeBird+<Cutscene>d__2",
                "Celeste.CS10_FreeBird.<Cutscene>d__2",
                "<Cutscene>d__2", assemblyIdentity, "Celeste", 33554941, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FreeBird.<Cutscene>d__2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FreeBird.<Cutscene>d__2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone", "Celeste.CS10_Gravestone", "CS10_Gravestone",
                assemblyIdentity, "Celeste", 33554942, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone+<Cutscene>d__8",
                "Celeste.CS10_Gravestone.<Cutscene>d__8", "<Cutscene>d__8", assemblyIdentity, "Celeste", 33554943,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone.<Cutscene>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone.<Cutscene>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone+<StepForward>d__9",
                "Celeste.CS10_Gravestone.<StepForward>d__9", "<StepForward>d__9", assemblyIdentity, "Celeste", 33554944,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone.<StepForward>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone.<StepForward>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone+<BadelineAppears>d__10",
                "Celeste.CS10_Gravestone.<BadelineAppears>d__10", "<BadelineAppears>d__10", assemblyIdentity, "Celeste",
                33554945, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone.<BadelineAppears>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone.<BadelineAppears>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone+<SitDown>d__11",
                "Celeste.CS10_Gravestone.<SitDown>d__11", "<SitDown>d__11", assemblyIdentity, "Celeste", 33554946,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone.<SitDown>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone.<SitDown>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone+<BirdStuff>d__12",
                "Celeste.CS10_Gravestone.<BirdStuff>d__12", "<BirdStuff>d__12", assemblyIdentity, "Celeste", 33554947,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone.<BirdStuff>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone.<BirdStuff>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone+<BadelineRejoin>d__13",
                "Celeste.CS10_Gravestone.<BadelineRejoin>d__13", "<BadelineRejoin>d__13", assemblyIdentity, "Celeste",
                33554948, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone.<BadelineRejoin>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone.<BadelineRejoin>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Diary", "Celeste.CS03_Diary", "CS03_Diary", assemblyIdentity,
                "Celeste", 33554949, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Diary", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Diary",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Diary+<Routine>d__3", "Celeste.CS03_Diary.<Routine>d__3",
                "<Routine>d__3", assemblyIdentity, "Celeste", 33554950, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Diary.<Routine>d__3", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Diary.<Routine>d__3",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Guestbook", "Celeste.CS03_Guestbook", "CS03_Guestbook",
                assemblyIdentity, "Celeste", 33554951, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Guestbook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Guestbook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Guestbook+<Routine>d__3",
                "Celeste.CS03_Guestbook.<Routine>d__3",
                "<Routine>d__3", assemblyIdentity, "Celeste", 33554952, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Guestbook.<Routine>d__3", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Guestbook.<Routine>d__3",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo", "Celeste.CS03_Memo", "CS03_Memo", assemblyIdentity,
                "Celeste", 33554953, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage", "Celeste.CS03_Memo.MemoPage", "MemoPage",
                assemblyIdentity, "Celeste", 33554954, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<EaseIn>d__14",
                "Celeste.CS03_Memo.MemoPage.<EaseIn>d__14", "<EaseIn>d__14", assemblyIdentity, "Celeste", 33554955,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<EaseIn>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<EaseIn>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<Wait>d__15",
                "Celeste.CS03_Memo.MemoPage.<Wait>d__15", "<Wait>d__15", assemblyIdentity, "Celeste", 33554956, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<Wait>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<Wait>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+MemoPage+<EaseOut>d__16",
                "Celeste.CS03_Memo.MemoPage.<EaseOut>d__16", "<EaseOut>d__16", assemblyIdentity, "Celeste", 33554957,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.MemoPage.<EaseOut>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.MemoPage.<EaseOut>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo+<Routine>d__5", "Celeste.CS03_Memo.<Routine>d__5",
                "<Routine>d__5", assemblyIdentity, "Celeste", 33554958, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo.<Routine>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo.<Routine>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoPhone", "Celeste.CS05_TheoPhone", "CS05_TheoPhone",
                assemblyIdentity, "Celeste", 33554959, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoPhone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoPhone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoPhone+<Routine>d__4",
                "Celeste.CS05_TheoPhone.<Routine>d__4",
                "<Routine>d__4", assemblyIdentity, "Celeste", 33554960, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoPhone.<Routine>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoPhone.<Routine>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoPhone+<WalkToPhone>d__5",
                "Celeste.CS05_TheoPhone.<WalkToPhone>d__5", "<WalkToPhone>d__5", assemblyIdentity, "Celeste", 33554961,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoPhone.<WalkToPhone>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoPhone.<WalkToPhone>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoPhone+<StandBackUp>d__6",
                "Celeste.CS05_TheoPhone.<StandBackUp>d__6", "<StandBackUp>d__6", assemblyIdentity, "Celeste", 33554962,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoPhone.<StandBackUp>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoPhone.<StandBackUp>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits", "Celeste.CS07_Credits", "CS07_Credits",
                assemblyIdentity, "Celeste", 33554963, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+Fill", "Celeste.CS07_Credits.Fill", "Fill",
                assemblyIdentity, "Celeste", 33554964, false, ["Celeste.Backdrop", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.Fill", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.Fill",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<>c__DisplayClass24_0",
                "Celeste.CS07_Credits.<>c__DisplayClass24_0", "<>c__DisplayClass24_0", assemblyIdentity, "Celeste",
                33554965, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<>c__DisplayClass24_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<>c__DisplayClass24_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<Routine>d__24",
                "Celeste.CS07_Credits.<Routine>d__24",
                "<Routine>d__24", assemblyIdentity, "Celeste", 33554966, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<Routine>d__24", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<Routine>d__24",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<SetupLevel>d__25",
                "Celeste.CS07_Credits.<SetupLevel>d__25", "<SetupLevel>d__25", assemblyIdentity, "Celeste", 33554967,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<SetupLevel>d__25", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<SetupLevel>d__25",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<WaitForPlayer>d__26",
                "Celeste.CS07_Credits.<WaitForPlayer>d__26", "<WaitForPlayer>d__26", assemblyIdentity, "Celeste",
                33554968,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<WaitForPlayer>d__26", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<WaitForPlayer>d__26",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<>c__DisplayClass27_0",
                "Celeste.CS07_Credits.<>c__DisplayClass27_0", "<>c__DisplayClass27_0", assemblyIdentity, "Celeste",
                33554969, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<>c__DisplayClass27_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<>c__DisplayClass27_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<NextLevel>d__27",
                "Celeste.CS07_Credits.<NextLevel>d__27", "<NextLevel>d__27", assemblyIdentity, "Celeste", 33554970,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<NextLevel>d__27", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<NextLevel>d__27",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<FadeTo>d__28", "Celeste.CS07_Credits.<FadeTo>d__28",
                "<FadeTo>d__28", assemblyIdentity, "Celeste", 33554971, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<FadeTo>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<FadeTo>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<BadelineApproachWalking>d__29",
                "Celeste.CS07_Credits.<BadelineApproachWalking>d__29", "<BadelineApproachWalking>d__29",
                assemblyIdentity,
                "Celeste", 33554972, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<BadelineApproachWalking>d__29", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<BadelineApproachWalking>d__29",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<DustyRoutine>d__30",
                "Celeste.CS07_Credits.<DustyRoutine>d__30", "<DustyRoutine>d__30", assemblyIdentity, "Celeste",
                33554973,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<DustyRoutine>d__30", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<DustyRoutine>d__30",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<BadelineAround>d__31",
                "Celeste.CS07_Credits.<BadelineAround>d__31", "<BadelineAround>d__31", assemblyIdentity, "Celeste",
                33554974, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<BadelineAround>d__31", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<BadelineAround>d__31",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<DoEvent>d__32",
                "Celeste.CS07_Credits.<DoEvent>d__32",
                "<DoEvent>d__32", assemblyIdentity, "Celeste", 33554975, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<DoEvent>d__32", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<DoEvent>d__32",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<EventWaitJumpDash>d__33",
                "Celeste.CS07_Credits.<EventWaitJumpDash>d__33", "<EventWaitJumpDash>d__33", assemblyIdentity,
                "Celeste",
                33554976, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<EventWaitJumpDash>d__33", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<EventWaitJumpDash>d__33",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<EventWaitJumpDoubleDash>d__34",
                "Celeste.CS07_Credits.<EventWaitJumpDoubleDash>d__34", "<EventWaitJumpDoubleDash>d__34",
                assemblyIdentity,
                "Celeste", 33554977, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<EventWaitJumpDoubleDash>d__34", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<EventWaitJumpDoubleDash>d__34",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<EventClimbDown>d__35",
                "Celeste.CS07_Credits.<EventClimbDown>d__35", "<EventClimbDown>d__35", assemblyIdentity, "Celeste",
                33554978, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<EventClimbDown>d__35", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<EventClimbDown>d__35",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<EventWait>d__36",
                "Celeste.CS07_Credits.<EventWait>d__36", "<EventWait>d__36", assemblyIdentity, "Celeste", 33554979,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<EventWait>d__36", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<EventWait>d__36",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits+<BadelineCombine>d__37",
                "Celeste.CS07_Credits.<BadelineCombine>d__37", "<BadelineCombine>d__37", assemblyIdentity, "Celeste",
                33554980, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits.<BadelineCombine>d__37", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits.<BadelineCombine>d__37",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending", "Celeste.CS08_Ending", "CS08_Ending",
                assemblyIdentity,
                "Celeste", 33554981, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+TimeDisplay", "Celeste.CS08_Ending.TimeDisplay",
                "TimeDisplay", assemblyIdentity, "Celeste", 33554982, false,
                ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.TimeDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.TimeDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+<Cutscene>d__15",
                "Celeste.CS08_Ending.<Cutscene>d__15",
                "<Cutscene>d__15", assemblyIdentity, "Celeste", 33554983, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.<Cutscene>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.<Cutscene>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+<EndingRoutine>d__17",
                "Celeste.CS08_Ending.<EndingRoutine>d__17", "<EndingRoutine>d__17", assemblyIdentity, "Celeste",
                33554984,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.<EndingRoutine>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.<EndingRoutine>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+<MaddyTurns>d__18",
                "Celeste.CS08_Ending.<MaddyTurns>d__18", "<MaddyTurns>d__18", assemblyIdentity, "Celeste", 33554985,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.<MaddyTurns>d__18", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.<MaddyTurns>d__18",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+<BadelineEmerges>d__19",
                "Celeste.CS08_Ending.<BadelineEmerges>d__19", "<BadelineEmerges>d__19", assemblyIdentity, "Celeste",
                33554986, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.<BadelineEmerges>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.<BadelineEmerges>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+<OshiroEnters>d__20",
                "Celeste.CS08_Ending.<OshiroEnters>d__20", "<OshiroEnters>d__20", assemblyIdentity, "Celeste", 33554987,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.<OshiroEnters>d__20", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.<OshiroEnters>d__20",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+<OshiroSettles>d__21",
                "Celeste.CS08_Ending.<OshiroSettles>d__21", "<OshiroSettles>d__21", assemblyIdentity, "Celeste",
                33554988,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.<OshiroSettles>d__21", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.<OshiroSettles>d__21",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending+<EndingRoutine>d__2",
                "Celeste.CS08_Ending.<EndingRoutine>d__2", "<EndingRoutine>d__2", assemblyIdentity, "Celeste", 33554989,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending.<EndingRoutine>d__2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending.<EndingRoutine>d__2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird", "Celeste.CS10_CatchTheBird",
                "CS10_CatchTheBird",
                assemblyIdentity, "Celeste", 33554990, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<Cutscene>d__8",
                "Celeste.CS10_CatchTheBird.<Cutscene>d__8", "<Cutscene>d__8", assemblyIdentity, "Celeste", 33554991,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<Cutscene>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<Cutscene>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<BirdTwitches>d__9",
                "Celeste.CS10_CatchTheBird.<BirdTwitches>d__9", "<BirdTwitches>d__9", assemblyIdentity, "Celeste",
                33554992,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<BirdTwitches>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<BirdTwitches>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<BirdLooksHurt>d__10",
                "Celeste.CS10_CatchTheBird.<BirdLooksHurt>d__10", "<BirdLooksHurt>d__10", assemblyIdentity, "Celeste",
                33554993, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<BirdLooksHurt>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<BirdLooksHurt>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<BirdSquakOnGround>d__11",
                "Celeste.CS10_CatchTheBird.<BirdSquakOnGround>d__11", "<BirdSquakOnGround>d__11", assemblyIdentity,
                "Celeste", 33554994, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<BirdSquakOnGround>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<BirdSquakOnGround>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<ApproachBird>d__12",
                "Celeste.CS10_CatchTheBird.<ApproachBird>d__12", "<ApproachBird>d__12", assemblyIdentity, "Celeste",
                33554995, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<ApproachBird>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<ApproachBird>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<ApproachBirdAgain>d__13",
                "Celeste.CS10_CatchTheBird.<ApproachBirdAgain>d__13", "<ApproachBirdAgain>d__13", assemblyIdentity,
                "Celeste", 33554996, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<ApproachBirdAgain>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<ApproachBirdAgain>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<BadelineAppears>d__14",
                "Celeste.CS10_CatchTheBird.<BadelineAppears>d__14", "<BadelineAppears>d__14", assemblyIdentity,
                "Celeste",
                33554997, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<BadelineAppears>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<BadelineAppears>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<WaitABeat>d__15",
                "Celeste.CS10_CatchTheBird.<WaitABeat>d__15", "<WaitABeat>d__15", assemblyIdentity, "Celeste", 33554998,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<WaitABeat>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<WaitABeat>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<MadelineSits>d__16",
                "Celeste.CS10_CatchTheBird.<MadelineSits>d__16", "<MadelineSits>d__16", assemblyIdentity, "Celeste",
                33554999, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<MadelineSits>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<MadelineSits>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<BadelineHugs>d__17",
                "Celeste.CS10_CatchTheBird.<BadelineHugs>d__17", "<BadelineHugs>d__17", assemblyIdentity, "Celeste",
                33555000, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<BadelineHugs>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<BadelineHugs>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<StandUp>d__18",
                "Celeste.CS10_CatchTheBird.<StandUp>d__18", "<StandUp>d__18", assemblyIdentity, "Celeste", 33555001,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<StandUp>d__18", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<StandUp>d__18",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird+<ShiftCameraToBird>d__19",
                "Celeste.CS10_CatchTheBird.<ShiftCameraToBird>d__19", "<ShiftCameraToBird>d__19", assemblyIdentity,
                "Celeste", 33555002, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird.<ShiftCameraToBird>d__19", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird.<ShiftCameraToBird>d__19",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro", "Celeste.CS10_HubIntro", "CS10_HubIntro",
                assemblyIdentity, "Celeste", 33555003, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+Bird", "Celeste.CS10_HubIntro.Bird", "Bird",
                assemblyIdentity, "Celeste", 33555004, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.Bird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.Bird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+Bird+<IdleRoutine>d__3",
                "Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3", "<IdleRoutine>d__3", assemblyIdentity, "Celeste",
                33555005,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.Bird.<IdleRoutine>d__3",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+Bird+<FlyAwayRoutine>d__4",
                "Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4", "<FlyAwayRoutine>d__4", assemblyIdentity, "Celeste",
                33555006, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.Bird.<FlyAwayRoutine>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+<>c", "Celeste.CS10_HubIntro.<>c", "<>c",
                assemblyIdentity, "Celeste", 33555007, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro+<Cutscene>d__10",
                "Celeste.CS10_HubIntro.<Cutscene>d__10", "<Cutscene>d__10", assemblyIdentity, "Celeste", 33555008,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro.<Cutscene>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro.<Cutscene>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps", "Celeste.CS10_BadelineHelps",
                "CS10_BadelineHelps", assemblyIdentity, "Celeste", 33555009, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps+<Cutscene>d__6",
                "Celeste.CS10_BadelineHelps.<Cutscene>d__6", "<Cutscene>d__6", assemblyIdentity, "Celeste", 33555010,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps.<Cutscene>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps.<Cutscene>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps+<BadelineAppears>d__7",
                "Celeste.CS10_BadelineHelps.<BadelineAppears>d__7", "<BadelineAppears>d__7", assemblyIdentity,
                "Celeste",
                33555011, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps.<BadelineAppears>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps.<BadelineAppears>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps+<MadelineFacesAway>d__8",
                "Celeste.CS10_BadelineHelps.<MadelineFacesAway>d__8", "<MadelineFacesAway>d__8", assemblyIdentity,
                "Celeste", 33555012, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps.<MadelineFacesAway>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps.<MadelineFacesAway>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps+<MadelineFacesBadeline>d__9",
                "Celeste.CS10_BadelineHelps.<MadelineFacesBadeline>d__9", "<MadelineFacesBadeline>d__9",
                assemblyIdentity,
                "Celeste", 33555013, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps.<MadelineFacesBadeline>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps.<MadelineFacesBadeline>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps+<MadelineStepsForwards>d__10",
                "Celeste.CS10_BadelineHelps.<MadelineStepsForwards>d__10", "<MadelineStepsForwards>d__10",
                assemblyIdentity,
                "Celeste", 33555014, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps.<MadelineStepsForwards>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps.<MadelineStepsForwards>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps+<BadelineVanishes>d__11",
                "Celeste.CS10_BadelineHelps.<BadelineVanishes>d__11", "<BadelineVanishes>d__11", assemblyIdentity,
                "Celeste", 33555015, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps.<BadelineVanishes>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps.<BadelineVanishes>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro", "Celeste.CS10_MoonIntro", "CS10_MoonIntro",
                assemblyIdentity, "Celeste", 33555016, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro+<Cutscene>d__8",
                "Celeste.CS10_MoonIntro.<Cutscene>d__8", "<Cutscene>d__8", assemblyIdentity, "Celeste", 33555017, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro.<Cutscene>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro.<Cutscene>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro+<>c__DisplayClass9_0",
                "Celeste.CS10_MoonIntro.<>c__DisplayClass9_0", "<>c__DisplayClass9_0", assemblyIdentity, "Celeste",
                33555018, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro.<>c__DisplayClass9_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro.<>c__DisplayClass9_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro+<BadelineTurns>d__9",
                "Celeste.CS10_MoonIntro.<BadelineTurns>d__9", "<BadelineTurns>d__9", assemblyIdentity, "Celeste",
                33555019,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro.<BadelineTurns>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro.<BadelineTurns>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro+<BadelineAppears>d__10",
                "Celeste.CS10_MoonIntro.<BadelineAppears>d__10", "<BadelineAppears>d__10", assemblyIdentity, "Celeste",
                33555020, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro.<BadelineAppears>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro.<BadelineAppears>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro+<BadelineVanishes>d__11",
                "Celeste.CS10_MoonIntro.<BadelineVanishes>d__11", "<BadelineVanishes>d__11", assemblyIdentity,
                "Celeste",
                33555021, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro.<BadelineVanishes>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro.<BadelineVanishes>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro+<FadeIn>d__12",
                "Celeste.CS10_MoonIntro.<FadeIn>d__12",
                "<FadeIn>d__12", assemblyIdentity, "Celeste", 33555022, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro.<FadeIn>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro.<FadeIn>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_EnterDoor", "Celeste.CS08_EnterDoor", "CS08_EnterDoor",
                assemblyIdentity, "Celeste", 33555023, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_EnterDoor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_EnterDoor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_EnterDoor+<Cutscene>d__4",
                "Celeste.CS08_EnterDoor.<Cutscene>d__4", "<Cutscene>d__4", assemblyIdentity, "Celeste", 33555024, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_EnterDoor.<Cutscene>d__4", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_EnterDoor.<Cutscene>d__4",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_EnterDoor+<>c__DisplayClass5_0",
                "Celeste.CS08_EnterDoor.<>c__DisplayClass5_0", "<>c__DisplayClass5_0", assemblyIdentity, "Celeste",
                33555025, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_EnterDoor.<>c__DisplayClass5_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_EnterDoor.<>c__DisplayClass5_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ending", "Celeste.CS07_Ending", "CS07_Ending",
                assemblyIdentity,
                "Celeste", 33555026, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ending+<Cutscene>d__5", "Celeste.CS07_Ending.<Cutscene>d__5",
                "<Cutscene>d__5", assemblyIdentity, "Celeste", 33555027, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ending.<Cutscene>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ending.<Cutscene>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ending+<WaitABit>d__6", "Celeste.CS07_Ending.<WaitABit>d__6",
                "<WaitABit>d__6", assemblyIdentity, "Celeste", 33555028, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ending.<WaitABit>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ending.<WaitABit>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ending+<SitDown>d__7", "Celeste.CS07_Ending.<SitDown>d__7",
                "<SitDown>d__7", assemblyIdentity, "Celeste", 33555029, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ending.<SitDown>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ending.<SitDown>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ending+<BadelineApproaches>d__8",
                "Celeste.CS07_Ending.<BadelineApproaches>d__8", "<BadelineApproaches>d__8", assemblyIdentity, "Celeste",
                33555030, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ending.<BadelineApproaches>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ending.<BadelineApproaches>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal", "Celeste.CS02_Journal", "CS02_Journal",
                assemblyIdentity, "Celeste", 33555031, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal+PoemPage", "Celeste.CS02_Journal.PoemPage",
                "PoemPage",
                assemblyIdentity, "Celeste", 33555032, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal.PoemPage", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal.PoemPage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal+PoemPage+<EaseIn>d__10",
                "Celeste.CS02_Journal.PoemPage.<EaseIn>d__10", "<EaseIn>d__10", assemblyIdentity, "Celeste", 33555033,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal.PoemPage.<EaseIn>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal.PoemPage.<EaseIn>d__10",
                []);
        }
    }
}
