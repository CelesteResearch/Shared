using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart23(SceneEntityCatalog catalog)
        {
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
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<RedDashCoroutine>d__454",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<>c__DisplayClass472_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<PickupCoroutine>d__472",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<StarFlyCoroutine>d__509",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<FlingBirdCoroutine>d__517",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<CassetteFlyCoroutine>d__524",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<DummyWalkTo>d__538",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<DummyWalkToExact>d__539",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<DummyRunTo>d__540",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<TempleFallCoroutine>d__543",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<ReflectionFallCoroutine>d__547",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<>c__DisplayClass548_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<IntroWalkCoroutine>d__550",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<IntroJumpCoroutine>d__551",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<IntroMoonJumpCoroutine>d__552",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<MoonLanding>d__553",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<IntroWakeUpCoroutine>d__554",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<>c__DisplayClass556_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<IntroThinkForABitCoroutine>d__558",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Player+<BirdDashTutorialCoroutine>d__561",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Celeste", [
                new SourceCommandMethodFacts(100670793, "Celeste", "get_TargetCenter", [],
                    [], []),
                new SourceCommandMethodFacts(100670800, "Celeste", "Freeze", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670801, "Celeste", "get_IsMainThread", [],
                    [], []),
                new SourceCommandMethodFacts(100670802, "Celeste", "Main", [], [],
                    []),
                new SourceCommandMethodFacts(100670803, "Celeste", "ReloadAssets", [],
                    [], []),
                new SourceCommandMethodFacts(100670804, "Celeste", "ReloadLevels", [],
                    [], []),
                new SourceCommandMethodFacts(100670805, "Celeste", "ReloadGraphics", [],
                    [], []),
                new SourceCommandMethodFacts(100670806, "Celeste", "ReloadPortraits", [],
                    [], []),
                new SourceCommandMethodFacts(100670807, "Celeste", "ReloadDialog", [],
                    [], []),
                new SourceCommandMethodFacts(100670808, "Celeste", "CallProcess", [],
                    [], []),
                new SourceCommandMethodFacts(100670809, "Celeste", "PauseAnywhere", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Celeste+PlayModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SolidTiles", []);
            catalog.PublishDeclaredCommandMethods("Celeste.RunLengthEncoding", [
                new SourceCommandMethodFacts(100670818, "RunLengthEncoding", "Encode", [],
                    [], []),
                new SourceCommandMethodFacts(100670819, "RunLengthEncoding", "Decode", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.RunThread", [
                new SourceCommandMethodFacts(100670820, "RunThread", "Start", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670821, "RunThread", "RunThreadWithLogging", [],
                    [], []),
                new SourceCommandMethodFacts(100670822, "RunThread", "WaitAll", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.RunThread+<>c__DisplayClass1_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Buses", []);
            catalog.PublishDeclaredCommandMethods("Celeste.VCAs", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snapshots", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SFX", [
                new SourceCommandMethodFacts(100670824, "SFX", "Initialize", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670825, "SFX", "EventnameByHandle", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.SurfaceIndex", [
                new SourceCommandMethodFacts(100670827, "SurfaceIndex", "GetPlatformByPriority", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MagicGlow", [
                new SourceCommandMethodFacts(100670830, "MagicGlow", "Render", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Stat", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Stats", [
                new SourceCommandMethodFacts(100670831, "Stats", "MakeRequest", [],
                    [], []),
                new SourceCommandMethodFacts(100670832, "Stats", "Has", [], [],
                    []),
                new SourceCommandMethodFacts(100670833, "Stats", "Increment", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670834, "Stats", "Local", [], [],
                    []),
                new SourceCommandMethodFacts(100670835, "Stats", "Global", [], [],
                    []),
                new SourceCommandMethodFacts(100670836, "Stats", "Store", [], [],
                    []),
                new SourceCommandMethodFacts(100670837, "Stats", "Name", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.StadiaStat", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StatsForStadia", [
                new SourceCommandMethodFacts(100670839, "StatsForStadia", "MakeRequest", [],
                    [], []),
                new SourceCommandMethodFacts(100670840, "StatsForStadia", "Increment", [],
                    [], []),
                new SourceCommandMethodFacts(100670841, "StatsForStadia", "SetIfLarger", [],
                    [], []),
                new SourceCommandMethodFacts(100670842, "StatsForStadia", "BeginFrame", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Tags", [
                new SourceCommandMethodFacts(100670844, "Tags", "Initialize", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.UserIO", [
                new SourceCommandMethodFacts(100670845, "UserIO", "GetHandle", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670846, "UserIO", "GetBackupHandle", [],
                    [], []),
                new SourceCommandMethodFacts(100670847, "UserIO", "Open", [], [],
                    []),
                new SourceCommandMethodFacts(100670848, "UserIO", "Save", [], [],
                    []),
                new SourceCommandMethodFacts(100670849, "UserIO", "Load", [], [],
                    []),
                new SourceCommandMethodFacts(100670850, "UserIO", "Deserialize", [],
                    [], []),
                new SourceCommandMethodFacts(100670851, "UserIO", "Exists", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670852, "UserIO", "Delete", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670853, "UserIO", "Close", [], [],
                    []),
                new SourceCommandMethodFacts(100670854, "UserIO", "Serialize", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670855, "UserIO", "get_Saving", [],
                    [], []),
                new SourceCommandMethodFacts(100670856, "UserIO", "set_Saving", [],
                    [], []),
                new SourceCommandMethodFacts(100670857, "UserIO", "get_SavingResult", [],
                    [], []),
                new SourceCommandMethodFacts(100670858, "UserIO", "set_SavingResult", [],
                    [], []),
                new SourceCommandMethodFacts(100670859, "UserIO", "SaveHandler", [],
                    [], []),
                new SourceCommandMethodFacts(100670860, "UserIO", "SaveRoutine", [],
                    [], []),
                new SourceCommandMethodFacts(100670861, "UserIO", "SaveThread", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.UserIO+Mode", []);
            catalog.PublishDeclaredCommandMethods("Celeste.UserIO+<SaveRoutine>d__29",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SlashFx", [
                new SourceCommandMethodFacts(100670864, "SlashFx", "Burst", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewDialog", []);
            catalog.PublishDeclaredCommandMethods("Celeste.PreviewDialog+Renderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.IceTileOverlay",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Editor.LevelTemplateType",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Editor.LevelTemplate",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Editor.MapEditor",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Editor.MapEditor+MouseModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+Cloud",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+Particle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+DeadParticle",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+player",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+player_hair",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+player_hair+node",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+player_spawn",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+spring",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+balloon",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+fall_floor",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+smoke",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+fruit",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Pico8.Classic+fly_fruit",
                []);
        }
    }
}
