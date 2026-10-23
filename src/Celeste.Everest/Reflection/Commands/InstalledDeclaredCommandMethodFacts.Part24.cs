using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart24(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleLength", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Distort", [
                new SourceCommandMethodFacts(100675749, "Distort", "get_AnxietyOrigin", [],
                    [], []),
                new SourceCommandMethodFacts(100675750, "Distort", "set_AnxietyOrigin", [],
                    [], []),
                new SourceCommandMethodFacts(100675751, "Distort", "get_Anxiety", [],
                    [], []),
                new SourceCommandMethodFacts(100675752, "Distort", "set_Anxiety", [],
                    [], []),
                new SourceCommandMethodFacts(100675753, "Distort", "get_GameRate", [],
                    [], []),
                new SourceCommandMethodFacts(100675754, "Distort", "set_GameRate", [],
                    [], []),
                new SourceCommandMethodFacts(100675755, "Distort", "get_WaterSine", [],
                    [], []),
                new SourceCommandMethodFacts(100675756, "Distort", "set_WaterSine", [],
                    [], []),
                new SourceCommandMethodFacts(100675757, "Distort", "get_WaterCameraY", [],
                    [], []),
                new SourceCommandMethodFacts(100675758, "Distort", "set_WaterCameraY", [],
                    [], []),
                new SourceCommandMethodFacts(100675759, "Distort", "get_WaterAlpha", [],
                    [], []),
                new SourceCommandMethodFacts(100675760, "Distort", "set_WaterAlpha", [],
                    [], []),
                new SourceCommandMethodFacts(100675761, "Distort", "Render", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GaussianBlur", [
                new SourceCommandMethodFacts(100675763, "GaussianBlur", "Blur", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GaussianBlur+Samples",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GaussianBlur+Direction",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Hahaha", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Hahaha+Ha", []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerHair", []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerSpriteMode",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerSprite", [
                new SourceCommandMethodFacts(100675794, "PlayerSprite", "CreateFramesMetadata", [],
                    [], []),
                new SourceCommandMethodFacts(100675795, "PlayerSprite", "ClearFramesMetadata", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerAnimMetadata",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BloomRenderer", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DisplacementRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DisplacementRenderer+Burst",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BackdropRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BackdropRenderer+<GetEach>d__9`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BackdropRenderer+<GetEach>d__10`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ScreenWipe", [
                new SourceCommandMethodFacts(100675848, "ScreenWipe", "DrawPrimitives", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.ScreenWipe+<Wait>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snow", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snow+Particle", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Parallax", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ChimneySmokeFx", [
                new SourceCommandMethodFacts(100675867, "ChimneySmokeFx", "Burst", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Dust", [
                new SourceCommandMethodFacts(100675869, "Dust", "Burst", [], [],
                    []),
                new SourceCommandMethodFacts(100675870, "Dust", "BurstFG", [], [],
                    []),
                new SourceCommandMethodFacts(100675871, "Dust", "Burst", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MapData", [
                new SourceCommandMethodFacts(100675893, "MapData", "_Process", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100675896, "MapData", "_GrowAndGet", [],
                    [], []),
                new SourceCommandMethodFacts(100675897, "MapData", "LoadCustomBackdrop", [],
                    [], []),
                new SourceCommandMethodFacts(100675898, "MapData", "ParseTags", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MapData+BackdropLoader",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MapData+<>c", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MapData+<>c__DisplayClass12_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.EntityData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DecalData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight", []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight+<>c__DisplayClass39_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight+<>c__DisplayClass40_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight+<>c__DisplayClass41_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level", [
                new SourceCommandMethodFacts(100676043, "Level", "get__PauseSnapshot", [],
                    [], []),
                new SourceCommandMethodFacts(100676044, "Level", "RegisterLoadOverride", [],
                    [], []),
                new SourceCommandMethodFacts(100676055, "Level", "LoadNewPlayer", [],
                    [], []),
                new SourceCommandMethodFacts(100676056, "Level", "LoadNewPlayerForLevel", [],
                    [], []),
                new SourceCommandMethodFacts(100676058, "Level", "LoadCustomEntity", [],
                    [], []),
                new SourceCommandMethodFacts(100676059, "Level", "_GCCollect", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100676067, "Level", "orig_ctor_Level", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+CameraLockModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+ConditionBlockModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass126_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<TransitionRoutine>d__126",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<SavingRoutine>d__141",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c", [
                new SourceCommandMethodFacts(100676122, "<>c", "orig_ctor_<>c", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass150_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass151_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<SaveFromOptions>d__152",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass153_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass154_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<ZoomTo>d__162",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<ZoomAcross>d__163",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<ZoomBack>d__164",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<SkipCutsceneRoutine>d__181",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass183_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+LoadOverride",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+EntityLoader",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<TransitionRoutine>d__37",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Facings", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Collision", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CollisionData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Actor", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Holdable", []);
            catalog.PublishDeclaredCommandMethods("Celeste.JumpThru", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DashCollisionResults",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DashCollision", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Platform", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Solid", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+IntroTypes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+ChaserStateSound",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+ChaserStateSound+Actions",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+ChaserState",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<>c__DisplayClass344_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<>c__DisplayClass344_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<DashCoroutine>d__427",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<BoostCoroutine>d__450",
                []);
        }
    }
}
