using System.Reflection;
using Celeste.Core.Components.Rendering;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Entities.Ascension;
using Celeste.Game.Entities.Decoration.Computers;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Game.Entities.Decoration.Resort;
using Celeste.Game.Entities.Hazards.Snowballs;
using Celeste.Game.Entities.LightSources.Torches;
using Celeste.Game.Entities.Lookouts;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;
using Celeste.Game.Entities.Platforms.Barriers;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Game.Entities.Platforms.WallBoosters;
using Celeste.Game.Entities.Triggers.Events;
using Celeste.Game.Entities.Triggers.Rendering;
using Celeste.Game.Entities.Triggers.Respawning;
using Celeste.Game.Entities.Triggers.Wind;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Game.Gameplay.Checkpoints;
using Celeste.Game.Gameplay.Collectibles.Keys;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Points;
using Celeste.Game.Gameplay.Doors.TempleGates;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Game.Gameplay.Hazards.Lightning;
using Celeste.Game.Gameplay.Hazards.Puffer;
using Celeste.Game.Gameplay.Hazards.Spinners.Dust;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Game.Gameplay.Hazards.TempleEyes;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.Gameplay.Interaction.Springs;
using Celeste.Game.Gameplay.Mechanisms.Core;
using Celeste.Game.Gameplay.Mechanisms.DashSwitches;
using Celeste.Game.Gameplay.Mechanisms.Switches;
using Celeste.Game.Gameplay.Mechanisms.SwitchGates;
using Celeste.Game.Gameplay.Platforms.Clouds;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Game.Gameplay.Platforms.MoveBlocks;
using Celeste.Game.Gameplay.Triggers.Audio;
using Celeste.Game.Gameplay.Triggers.Checkpoints;
using Celeste.Game.Gameplay.Triggers.Dialogue;
using Celeste.Game.Gameplay.Triggers.Inventory;
using Celeste.Game.Gameplay.Triggers.Movement;
using Celeste.Game.Menus.Journal;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Pause;
using Celeste.Game.Menus.Title;
using Celeste.Game.Minigames.CelesteClassic.Emulation;
using Celeste.Game.Presentation.Completion;
using Celeste.Game.Presentation.Effects.Mirrors;
using Celeste.Game.Presentation.Hud.Height;
using Celeste.Game.Presentation.Hud.Strawberries;
using Celeste.Game.Presentation.PostProcessing.ColorGrading;
using Celeste.Game.Stories.Farewell.FinalLaunch;
using Celeste.Game.Stories.Farewell.FreeBird;
using Celeste.Game.Stories.Reflection.After;
using Celeste.Game.Stories.Summit.Ascension;
using Celeste.Game.Stories.Summit.Ending;
using Celeste.Game.Stories.Temple.Cutscenes;
using Celeste.Game.UI.Dialogue.MiniTextboxes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Vignettes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Facing;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Platforms.Solids.Nega;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalOwnActorActualTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(typeof(IntroVignetteSequence),
                "Celeste.IntroVignette");
            catalog.RegisterRuntimeType(typeof(CoreVignetteSequence),
                "Celeste.CoreVignette");
            catalog.RegisterRuntimeType(typeof(SummitVignetteScene),
                "Celeste.SummitVignette");
            catalog.RegisterRuntimeType(typeof(LevelEnterSequence),
                "Celeste.LevelEnter");
            catalog.RegisterRuntimeType(typeof(LevelExitSequence),
                "Celeste.LevelExit");
            catalog.RegisterRuntimeType(typeof(OriginalLevelLoaderScene),
                "Celeste.LevelLoader");
            catalog.RegisterRuntimeType(typeof(GameLoaderScene),
                "Celeste.GameLoader");
            catalog.RegisterRuntimeType(typeof(OverworldLoaderSequence),
                "Celeste.OverworldLoader");
            catalog.RegisterRuntimeType(typeof(OverworldReflectionsFallSequence),
                "Celeste.OverworldReflectionsFall");
            catalog.RegisterRuntimeType(typeof(OverworldSequence),
                "Celeste.Overworld");
            catalog.RegisterRuntimeType(typeof(FacingDirection),
                "Celeste.Facings");
            catalog.RegisterRuntimeType(
                typeof(SeekerEffectsControllerState),
                "Celeste.SeekerEffectsController");
            catalog.RegisterRuntimeType(typeof(CS06ReflectionState),
                "Celeste.CS06_Reflection");
            catalog.RegisterRuntimeType(
                typeof(MirrorSurfacesState),
                "Celeste.MirrorSurfaces");
            catalog.RegisterRuntimeType(
                typeof(ChapterGlassBlockBackgroundSceneState),
                "Celeste.GlassBlockBg");
            catalog.RegisterRuntimeType(typeof(MainMenuSequence),
                "Celeste.OuiMainMenu");
            catalog.RegisterRuntimeType(typeof(TitleScreenSequence),
                "Celeste.OuiTitleScreen");
            catalog.RegisterRuntimeType(
                typeof(OriginalColorGradeProcess),
                "Celeste.ColorGrade");
            catalog.RegisterRuntimeType(typeof(SummitVignetteScene),
                "Celeste.SummitVignette");
            catalog.RegisterRuntimeType(typeof(OuiJournalSequence),
                "Celeste.OuiJournal");
            catalog.RegisterRuntimeType(
                typeof(ClassicConsoleRuntime),
                "Celeste.Pico8.Emulator");
            catalog.RegisterRuntimeType(
                typeof(MoveBlockBorderState),
                "Celeste.MoveBlock.Border");
            catalog.RegisterRuntimeType(
                typeof(BeforeRenderCallbackComponentState),
                "Celeste.BeforeRenderHook");
            catalog.RegisterRuntimeType(typeof(OriginalCheckpointData),
                "Celeste.CheckpointData");
            catalog.RegisterRuntimeType(typeof(AreaCompleteSequence),
                "Celeste.AreaComplete");
            catalog.RegisterRuntimeType(typeof(CompleteRendererState),
                "Celeste.CompleteRenderer");
            catalog.RegisterRuntimeType(
                typeof(CompleteRendererState.Layer),
                "Celeste.CompleteRenderer.Layer");
            catalog.RegisterRuntimeType(
                typeof(CompleteRendererState.UILayer),
                "Celeste.CompleteRenderer.UILayer");
            catalog.RegisterRuntimeType(
                typeof(CompleteRendererState.ImageLayer),
                "Celeste.CompleteRenderer.ImageLayer");
            catalog.RegisterRuntimeType(typeof(ReturnMapHintPresentation),
                "Celeste.ReturnMapHint");
            catalog.RegisterRuntimeType(typeof(ScenePostUpdateHook),
                "Celeste.PostUpdateHook");
            catalog.RegisterRuntimeType(
                typeof(OriginalAmbienceParamTriggerState),
                "Celeste.AmbienceParamTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalAltMusicTriggerState),
                "Celeste.AltMusicTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalMusicTriggerState),
                "Celeste.MusicTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalMusicFadeTriggerState),
                "Celeste.MusicFadeTrigger");
            catalog.RegisterRuntimeType(typeof(OriginalWindTrigger),
                "Celeste.WindTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalSpawnFacingTrigger),
                "Celeste.SpawnFacingTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalRespawnTargetTrigger),
                "Celeste.RespawnTargetTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalChangeRespawnTrigger),
                "Celeste.ChangeRespawnTrigger");
            catalog.RegisterRuntimeType(
                typeof(FinalLaunchCutscene),
                "Celeste.CS10_FinalLaunch");
            catalog.RegisterRuntimeType(
                typeof(OriginalHeightDisplayState),
                "Celeste.HeightDisplay");
            catalog.RegisterRuntimeType(
                typeof(OriginalSummitAscendCutscene),
                "Celeste.CS07_Ascend");
            catalog.RegisterRuntimeType(typeof(AscendStreaksState),
                "Celeste.AscendManager.Streaks");
            catalog.RegisterRuntimeType(
                typeof(OriginalAscendManagerState).GetNestedType("Fader",
                    BindingFlags.NonPublic), "Celeste.AscendManager.Fader");
            catalog.RegisterRuntimeType(
                typeof(OriginalAscendManagerState.Clouds),
                "Celeste.AscendManager.Clouds");
            catalog.RegisterRuntimeType(typeof(OriginalAscendManagerState),
                "Celeste.AscendManager");
            catalog.RegisterRuntimeType(
                typeof(OriginalBloomFadeTriggerState),
                "Celeste.BloomFadeTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalLightFadeTriggerState),
                "Celeste.LightFadeTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalFreeBirdEndingCutscene),
                "Celeste.CS10_FreeBird");
            catalog.RegisterRuntimeType(typeof(CS05Reflection1State),
                "Celeste.CS05_Reflection1");
            catalog.RegisterRuntimeType(
                typeof(OriginalEventTriggerState),
                "Celeste.EventTrigger");
            catalog.RegisterRuntimeType(
                typeof(TotalStrawberriesDisplayState),
                "Celeste.TotalStrawberriesDisplay");
            catalog.RegisterRuntimeType(
                typeof(OriginalCoreModeToggleState),
                "Celeste.CoreModeToggle");
            catalog.RegisterRuntimeType(
                typeof(OriginalTorchState), "Celeste.Torch");
            catalog.RegisterRuntimeType(
                typeof(OriginalKevinsPCState),
                "Celeste.KevinsPC");
            catalog.RegisterRuntimeType(
                typeof(OriginalSnowballState), "Celeste.Snowball");
            catalog.RegisterRuntimeType(
                typeof(OriginalWindAttackTriggerState),
                "Celeste.WindAttackTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalTrapdoorState), "Celeste.Trapdoor");
            catalog.RegisterRuntimeType(
                typeof(OriginalResortLanternState),
                "Celeste.ResortLantern");
            catalog.RegisterRuntimeType(typeof(OriginalLookoutState),
                "Celeste.Lookout");
            catalog.RegisterRuntimeType(typeof(OriginalLookoutHud),
                "Celeste.Lookout.Hud");
            catalog.RegisterRuntimeType(typeof(TextboxState),
                "Celeste.Textbox");
            catalog.RegisterRuntimeType(typeof(MiniTextboxState),
                "Celeste.MiniTextbox");
            catalog.RegisterRuntimeType(
                typeof(MiniTextboxTriggerState),
                "Celeste.MiniTextboxTrigger");
            catalog.RegisterRuntimeType(
                typeof(NoRefillTriggerState),
                "Celeste.NoRefillTrigger");
            catalog.RegisterRuntimeType(
                typeof(StopBoostTriggerState),
                "Celeste.StopBoostTrigger");
            catalog.RegisterRuntimeType(
                typeof(CheckpointBlockerTriggerState),
                "Celeste.CheckpointBlockerTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalTrackSpinnerState),
                "Celeste.TrackSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalRotateSpinnerState),
                "Celeste.RotateSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalBladeTrackSpinnerState),
                "Celeste.BladeTrackSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalBladeRotateSpinnerState),
                "Celeste.BladeRotateSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalStarTrackSpinnerState),
                "Celeste.StarTrackSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalStarRotateSpinnerState),
                "Celeste.StarRotateSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalDustTrackSpinnerState),
                "Celeste.DustTrackSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalDustRotateSpinnerState),
                "Celeste.DustRotateSpinner");
            catalog.RegisterRuntimeType(
                typeof(OriginalDustStaticSpinnerState),
                "Celeste.DustStaticSpinner");
            catalog.RegisterRuntimeType(
                typeof(BounceBlockState),
                "Celeste.BounceBlock");
            catalog.RegisterRuntimeType(
                typeof(OriginalAngryOshiroState),
                "Celeste.AngryOshiro");
            catalog.RegisterRuntimeType(
                typeof(OriginalIceTileOverlayState),
                "Celeste.IceTileOverlay");
            catalog.RegisterRuntimeType(
                typeof(OriginalRumbleTriggerState),
                "Celeste.RumbleTrigger");
            catalog.RegisterRuntimeType(
                typeof(OriginalCrumbleWallOnRumbleState),
                "Celeste.CrumbleWallOnRumble");
            catalog.RegisterRuntimeType(typeof(OriginalSeekerState),
                "Celeste.Seeker");
            catalog.RegisterRuntimeType(typeof(OriginalPufferState),
                "Celeste.Puffer");
            catalog.RegisterRuntimeType(
                typeof(LightningStrikeState),
                "Celeste.LightningStrike");
            catalog.RegisterRuntimeType(typeof(CS07EndingState),
                "Celeste.CS07_Ending");
            catalog.RegisterRuntimeType(
                typeof(TheoCrystalState),
                "Celeste.TheoCrystal");
            catalog.RegisterRuntimeType(
                typeof(OriginalDreamBlockState),
                "Celeste.DreamBlock");
            catalog.RegisterRuntimeType(
                typeof(OriginalInvisibleBarrierState),
                "Celeste.InvisibleBarrier");
            catalog.RegisterRuntimeType(
                typeof(OriginalWallBoosterState),
                "Celeste.WallBooster");
            catalog.RegisterRuntimeType(
                typeof(NegaBlockState),
                "Celeste.NegaBlock");
            catalog.RegisterRuntimeType(typeof(OriginalDecalEntity),
                "Celeste.Decal");
            catalog.RegisterRuntimeType(
                typeof(OriginalStrawberryState),
                "Celeste.Strawberry");
            catalog.RegisterRuntimeType(
                typeof(OriginalStrawberrySeedState),
                "Celeste.StrawberrySeed");
            catalog.RegisterRuntimeType(
                typeof(OriginalStrawberryPointsState), "Celeste.StrawberryPoints");
            catalog.RegisterRuntimeType(typeof(OriginalKeyState),
                "Celeste.Key");
            catalog.RegisterRuntimeType(typeof(OriginalCloudState),
                "Celeste.Cloud");
            catalog.RegisterRuntimeType(
                typeof(OriginalCrumblePlatformState),
                "Celeste.CrumblePlatform");
            catalog.RegisterRuntimeType(typeof(OriginalCheckpointState),
                "Celeste.Checkpoint");
            catalog.RegisterRuntimeType(
                typeof(OriginalSpringState), "Celeste.Spring");
            catalog.RegisterRuntimeType(
                typeof(OriginalTouchSwitchState),
                "Celeste.TouchSwitch");
            catalog.RegisterRuntimeType(
                typeof(OriginalDashSwitchState),
                "Celeste.DashSwitch");
            catalog.RegisterRuntimeType(
                typeof(OriginalTempleGateState),
                "Celeste.TempleGate");
            catalog.RegisterRuntimeType(
                typeof(OriginalSwitchGateState),
                "Celeste.SwitchGate");
            catalog.RegisterRuntimeType(
                typeof(OriginalTempleBigEyeballState),
                "Celeste.TempleBigEyeball");
            catalog.RegisterRuntimeType(
                typeof(OriginalTempleEyeState),
                "Celeste.TempleEye");
            catalog.RegisterRuntimeType(
                typeof(OriginalTempleBigEyeballState)
                    .GetNestedType("Fader", BindingFlags.NonPublic), "Celeste.TempleBigEyeball.Fader");
        }
    }
}
