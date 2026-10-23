using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart17(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.MainMenuSmallButton",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MenuButton", [
                new SourceCommandMethodFacts(100668621, "MenuButton", "GetSelection", [],
                    [], []),
                new SourceCommandMethodFacts(100668622, "MenuButton", "ClearSelection", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MenuButton+<>c__DisplayClass15_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MenuButton+<>c__DisplayClass16_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MainMenuClimb", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiCredits", []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiCredits+<Enter>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.OuiCredits+<Leave>d__6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroVignette", []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroVignette+<TextSequence>d__19",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.IntroVignette+<>c__DisplayClass24_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelLoader", []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerDeadBody",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerDeadBody+<>c__DisplayClass15_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerDeadBody+<DeathRoutine>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaMode", []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaKey", [
                new SourceCommandMethodFacts(100668676, "AreaKey", "op_Equality", [],
                    [], []),
                new SourceCommandMethodFacts(100668677, "AreaKey", "op_Inequality", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.ModeProperties",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaData", [
                new SourceCommandMethodFacts(100668683, "AreaData", "GetMode", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100668684, "AreaData", "GetMode", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100668685, "AreaData", "Load", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100668686, "AreaData", "ReloadMountainViews", [],
                    [], []),
                new SourceCommandMethodFacts(100668687, "AreaData", "IsPoemRemix", [],
                    [], []),
                new SourceCommandMethodFacts(100668688, "AreaData", "GetCheckpointID", [],
                    [], []),
                new SourceCommandMethodFacts(100668689, "AreaData", "GetCheckpoint", [],
                    [], []),
                new SourceCommandMethodFacts(100668690, "AreaData", "GetCheckpointName", [],
                    [], []),
                new SourceCommandMethodFacts(100668691, "AreaData", "GetCheckpointInventory", [],
                    [], []),
                new SourceCommandMethodFacts(100668692, "AreaData", "GetCheckpointDreaming", [],
                    [], []),
                new SourceCommandMethodFacts(100668693, "AreaData", "GetCheckpointCoreMode", [],
                    [], []),
                new SourceCommandMethodFacts(100668694, "AreaData", "GetCheckpointAudioState", [],
                    [], []),
                new SourceCommandMethodFacts(100668695, "AreaData", "GetCheckpointColorGrading", [],
                    [], []),
                new SourceCommandMethodFacts(100668696, "AreaData", "Unload", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100668697, "AreaData", "Get", [], [],
                    []),
                new SourceCommandMethodFacts(100668698, "AreaData", "Get", [], [],
                    []),
                new SourceCommandMethodFacts(100668699, "AreaData", "Get", [], [],
                    []),
                new SourceCommandMethodFacts(100668700, "AreaData", "Get", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaData+<>c", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CheckpointData",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaModeStats", []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaStats", []);
            catalog.PublishDeclaredCommandMethods("Celeste._3dSoundTest", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BlockField", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Booster", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Booster+<BoostRoutine>d__31",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Checkpoint", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Checkpoint+<EaseLightsOn>d__18",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Cloud", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterBlock+Colors",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterBlockBase",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterDoor", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterDoor+<UnlockRoutine>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterSwitch", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterSwitch+<LightningRoutine>d__25",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterSwitch+<>c__DisplayClass26_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterSwitch+<>c__DisplayClass26_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterSwitch+<>c__DisplayClass26_2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterSwitch+<AbsorbRoutine>d__26",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterAbsorbEffect",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterAbsorbEffect+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DashListener", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LedgeBlocker", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustGraphic", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustGraphic+Node",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustGraphic+Eyeballs",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustGraphic+<BlinkRoutine>d__45",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SafeGroundBlocker",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SoundSource", []);
            catalog.PublishDeclaredCommandMethods("Celeste.TalkComponent", []);
            catalog.PublishDeclaredCommandMethods("Celeste.TalkComponent+HoverDisplay",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TalkComponent+TalkComponentUI",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TileInterceptor", [
                new SourceCommandMethodFacts(100668837, "TileInterceptor", "TileCheck", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.TileInterceptor+<>c__DisplayClass3_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TransitionListener",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.WindMover", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+PatrolPoint",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+RecoverBlast", [
                new SourceCommandMethodFacts(100674292, "RecoverBlast", "Spawn", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<>c__DisplayClass58_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<IdleCoroutine>d__91",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<SpottedCoroutine>d__113",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<AttackCoroutine>d__127",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<StunnedCoroutine>d__131",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<SkiddingCoroutine>d__138",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<RegenerateCoroutine>d__143",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Seeker+<ReturnedCoroutine>d__144",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustStaticSpinner",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustTrackSpinner",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snowball", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DashSwitch", [
                new SourceCommandMethodFacts(100668916, "DashSwitch", "Create", [],
                    [], []),
                new SourceCommandMethodFacts(100668922, "DashSwitch", "GetFlagName", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.DashSwitch+Sides",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Cobweb", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ResortLantern", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MrOshiroDoor", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Door", []);
        }
    }
}
